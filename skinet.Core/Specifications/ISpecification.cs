using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace skinet.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Crieteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPageEnabled { get; }
    }
}
