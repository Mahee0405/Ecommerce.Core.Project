using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using skinet.API.Data;
using skinet.Core.Entities;
using skinet.Core.Interface;
using skinet.Core.Specifications;

namespace skinet.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySepecifaction(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySepecifaction(spec).ToListAsync();
        }

        private IQueryable<T> ApplySepecifaction(ISpecification<T> spec)
        {
            return SpecificEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
