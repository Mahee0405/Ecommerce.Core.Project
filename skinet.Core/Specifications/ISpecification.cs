﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace skinet.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Crieteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}