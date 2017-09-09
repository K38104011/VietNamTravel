using VNT.Core.Model;

namespace VNT.Core.Business.Contract
{
    public interface IUserBusiness
    {
        void Create(User user);
        bool IsExisted(User user);
    }
}
