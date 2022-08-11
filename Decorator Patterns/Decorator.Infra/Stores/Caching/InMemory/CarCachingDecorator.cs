using Decorator.Application.Interfaces;
using Decorator.Application.Models.V2;
using Decorator.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Decorator.Stores.Caching
{
    public class CarCachingDecorator<TT> : ICarStoreV1, ICarStoreV2
        where TT : ICarStoreV1, ICarStoreV2
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICarStoreV1 _inner1;
        private readonly ICarStoreV2 _inner2;
        private readonly ILogger<CarCachingDecorator<TT>> _logger;

        public CarCachingDecorator(IMemoryCache memoryCache,
                                   ILogger<CarCachingDecorator<TT>> logger, 
                                   ICarStoreV1 inner1, 
                                   ICarStoreV2 inner2)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _inner1 = inner1;
            _inner2 = inner2;
        }
        public CarDtoV1 ListV1()
        {
            // Se caso não tiver na memoria vai no banco
            var key = "Cars";
            var items = _memoryCache.Get<CarDtoV1>(key);
            if (items == null)
            {
                items = _inner1.ListV1();
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
                items = _inner1.GetV1(id);
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Configurando itens em cache para {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                 items.FromMemory();
                _logger.LogTrace("Acerto para cache {CacheKey}", key);
            }

            return items;
        }

        public CarDtoV2 ListV2()
        {
            // Se caso não tiver na memoria vai no banco
            var key = "Cars";
            var items = _memoryCache.Get<CarDtoV2>(key);
            if (items == null)
            {
                items = _inner2.ListV2();
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
                items = _inner2.GetV2(id);
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Configurando itens em cache para {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Acerto para cache {CacheKey}", key);
            }

            return items;
        }
    }
}
