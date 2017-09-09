using Autofac;
using VNT.Core.Business.Contract;

namespace VNT.Core.Business
{
    public class WireUpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<VNT.Core.EF.DataAccess.WireUpModule>();
            builder.RegisterType<UserBusiness>().As<IUserBusiness>();
            base.Load(builder);
        }
    }
}
