﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using skinet.Core.Entities;
using skinet.Core.Specifications;

namespace skinet.Core.Interface
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}