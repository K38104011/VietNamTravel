using System.Linq;

namespace VNT.Core.EF.DataAccess.Repository
{
    public partial class BaseRepository<T> where T : class, new()
    {
        protected readonly VietNamTravelDbContext Context = new VietNamTravelDbContext();

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public void Insert(T entity, bool saveChanges = false)
        {
            Context.Set<T>().Add(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
