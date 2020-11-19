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

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        
    }
}
