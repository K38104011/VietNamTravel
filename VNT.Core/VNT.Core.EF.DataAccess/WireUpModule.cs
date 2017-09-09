using Autofac;
using VNT.Core.EF.DataAccess.Repository;
using VNT.Core.EF.DataAccess.Repository.Contract;

namespace VNT.Core.EF.DataAccess
{
    public class WireUpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            base.Load(builder);
        }
    }
}
