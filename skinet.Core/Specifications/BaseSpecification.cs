using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace skinet.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> crieteria)
        {
            Crieteria = crieteria;

        }

        public Expression<Func<T, bool>> Crieteria
        {
            get;

        }

       
        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPageEnabled = true;
        }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();


        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }
       

        public int Skip { get; private set; }

        public bool IsPageEnabled { get; private set; }
    }
}
