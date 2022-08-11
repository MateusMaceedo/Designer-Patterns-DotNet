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
        private readonly ICarStore _inner;
        private readonly ILogger<RealizarBuscaPorCarsPorIdUseCase> _logger;

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
