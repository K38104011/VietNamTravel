using System.Linq;

namespace VNT.Core.EF.DataAccess.Repository.Contract
{
    public interface IBaseRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();
        void Insert(T entity, bool saveChanges = false);
    }
}
