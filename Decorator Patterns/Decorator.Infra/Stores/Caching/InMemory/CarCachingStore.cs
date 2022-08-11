using System;
using Decorator.Application.Models.V2;
using Decorator.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Decorator.Stores.Caching
{
    public class CarCachingStore : ICarStore
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICarStore _inner;
        private readonly ILogger<CarCachingStore> _logger;

        public CarCachingStore(IMemoryCache memoryCache, 
                               ICarStore inner, 
                               ILogger<CarCachingStore> logger)
        {
            _memoryCache = memoryCache;
            _inner = inner;
            _logger = logger;
        }

        public CarDtoV1 ListV1()
        {
            var key = "Cars";
            var items = _memoryCache.Get<CarDtoV1>(key);
            if (items == null)
            {
                items = _inner.ListV1();
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Setting items in cache for {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return items;
        }

        public CarDtoV1 GetV1(int id)
        {
            var key = $"Cars:{id}";
            var items = _memoryCache.Get<CarDtoV1>(key);
            if (items == null)
            {
                items = _inner.GetV1(id);
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Setting items in cache for {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return items;
        }

        public CarDtoV2 ListV2()
        {
            var key = "Cars";
            var items = _memoryCache.Get<CarDtoV2>(key);
            if (items == null)
            {
                items = _inner.ListV2();
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Setting items in cache for {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return items;
        }

        public CarDtoV2 GetV2(int id)
        {
            var key = $"Cars:{id}";
            var items = _memoryCache.Get<CarDtoV2>(key);
            if (items == null)
            {
                items = _inner.GetV2(id);
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Setting items in cache for {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return items;
        }
    }
}