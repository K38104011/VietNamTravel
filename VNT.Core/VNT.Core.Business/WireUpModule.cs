using Autofac;
using VNT.Core.Business.Contract;
using VNT.Sdk;

namespace VNT.Core.Business
{
    public class WireUpModule : Bootstrapper
    {
        public override void WireUp()
        {
            ContainerBuilder.RegisterType<UserBusiness>().As<IUserBusiness>();
        }
    }
}
