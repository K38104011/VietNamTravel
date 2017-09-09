using System;
using VNT.Core.EF.DataAccess.Repository.Contract;

namespace VNT.Core.EF.DataAccess.Repository
{
    public partial class BaseRepository<T> : IBaseRepository<T>, IDisposable
    {
    }
}
