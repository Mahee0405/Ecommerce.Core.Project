using System;
using System.Collections;
using System.Threading.Tasks;
using skinet.API.Data;
using skinet.Core.Entities;
using skinet.Core.Interface;

namespace skinet.Infrastructure.Data
{
    public class UnitofWork : IUnitofWork
    {
        private readonly StoreContext _context;
        private Hashtable _repository;

        public UnitofWork(StoreContext context)
        {
            _context = context;
        }

        public async  Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repsository<TEntity>() where TEntity : BaseEntity
        {
            if (_repository == null) _repository = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repository.ContainsKey(type))
            {
                var repostioryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repostioryType.MakeGenericType(typeof(TEntity)), _context);

                _repository.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repository[type];
        }
    }
}
