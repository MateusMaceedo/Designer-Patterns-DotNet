using Decorator.Application.Interfaces;
using Decorator.Application.Models.V2;
using Decorator.Stores;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Decorator.Application.UseCases
{
    public class RealizarBuscarPorCarsUseCase : IRealizarBuscarPorCarsUseCase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICarStore _inner;
        private readonly ILogger<RealizarBuscarPorCarsUseCase> _logger;

        public RealizarBuscarPorCarsUseCase(IMemoryCache memoryCache,
                                            ICarStore inner,
                                            ILogger<RealizarBuscarPorCarsUseCase> logger)
        {
            _memoryCache = memoryCache;
            _inner = inner;
            _logger = logger;
        }

        public CarDtoV2 ListV2()
        {
            try
            {
                // Se caso não tiver na memoria vai no banco
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
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }
    }
}