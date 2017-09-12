using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace VNT.Sdk
{
    public abstract class Bootstrapper : Module
    {
        protected ContainerBuilder ContainerBuilder;

        public abstract void WireUp();

        protected override void Load(ContainerBuilder builder)
        {
            ContainerBuilder = builder;
            var executingDir = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var assemblyPath = Path.Combine(executingDir, "VNT.Core.EF.DataAccess" + ".dll");
            var type = Assembly.LoadFrom(assemblyPath).GetTypes().Single(x => x.FullName == "VNT.Core.EF.DataAccess.WireUpModule");
                //.GetExecutingAssembly()
                //.GetReferencedAssemblies()
                //.Select(Assembly.Load)
                //.Select(x => x.GetTypes()).First();
            var method = typeof(ModuleRegistrationExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Single(m => m.Name == "RegisterModule" && m.IsGenericMethodDefinition &&
                             m.GetParameters()[0].ParameterType == typeof(ContainerBuilder));
            var generic = method.MakeGenericMethod(type);
            generic.Invoke(null, new object[] { ContainerBuilder });
            WireUp();
            base.Load(builder);
        }
    }
}
