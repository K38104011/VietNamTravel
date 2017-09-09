using System.Linq;
using VNT.Core.Business.Contract;
using VNT.Core.EF.DataAccess.Repository.Contract;
using VNT.Core.Model;

namespace VNT.Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _repository;

        public UserBusiness(IUserRepository userRepository)
        {
            _repository = userRepository;
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
