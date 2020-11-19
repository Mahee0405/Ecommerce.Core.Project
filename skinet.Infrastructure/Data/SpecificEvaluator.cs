using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using skinet.Core.Entities;
using skinet.Core.Specifications;

namespace skinet.Infrastructure.Data
{
    public class SpecificEvaluator<TEntity> where TEntity: BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Crieteria !=null)
            {
                query = query.Where(spec.Crieteria);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
