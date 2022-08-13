﻿using System;
using System.Threading.Tasks;

namespace Decorator.Domain.Interfaces.Context
{
    public interface IDynamoDbContext<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task SaveAsync(T item);
        Task DeleteByIdAsync(T item);
    }
}
