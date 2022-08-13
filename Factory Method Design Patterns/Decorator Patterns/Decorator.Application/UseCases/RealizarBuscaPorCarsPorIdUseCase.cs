using Decorator.Application.Interfaces;
using Decorator.Application.Models.V2;
using Decorator.Stores;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Decorator.Application.UseCases
{
    public class RealizarBuscaPorCarsPorIdUseCase : IRealizarBuscaPorCarsPorIdUseCase 
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICarStoreV2 _inner2;
        private readonly ILogger<RealizarBuscaPorCarsPorIdUseCase> _logger;

        public RealizarBuscaPorCarsPorIdUseCase(IMemoryCache memoryCache, 
                                                ICarStoreV2 inner2, 
                                                ILogger<RealizarBuscaPorCarsPorIdUseCase> logger)
        {
            _memoryCache = memoryCache;
            _inner2 = inner2;
            _logger = logger;
        }

        public CarDtoV2 GetV2(int id)
        {
            _logger.LogError($"Consulta '{id}'");
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
