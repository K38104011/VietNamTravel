using System.Linq;
using System.Security.Cryptography;
using VNT.Core.Business.Contract;
using VNT.Core.EF.DataAccess.Model;
using VNT.Core.EF.DataAccess.Repository;

namespace VNT.Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserRepository _repository;

        public UserBusiness()
        {
            _repository = new UserRepository();
        }

        public void Create(User user)
        {
            _repository.Insert(user, true);
            _repository.Dispose();
        }

        public bool IsExisted(User user)
        {
            if (user == null)
            {
                return false;
            }
            var result = _repository.GetAll()
                .Any(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
            _repository.Dispose();
            return result;
        }
    }
}
