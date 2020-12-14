using System;
using System.Threading.Tasks;
using skinet.Core.Entities;

namespace skinet.Core.Interface
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<TEntity> Repsository<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();
    }
}
