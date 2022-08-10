using Decorator.Application.Interfaces;
using Decorator.Models;
using Decorator.Stores;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        public CarDto RealizarBuscarPorCars()
        {
            return _inner.List();
        }
    }
}