using AutoMapper;
using Decorator.Application.Interfaces;
using Decorator.Application.Request;
using Decorator.Application.Response;
using Decorator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Decorator.Application.UseCases
{
    public class RealizarBuscarPorCarsUseCase : IRealizarBuscarPorCarsUseCase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICarStoreV2 _inner2;
        private readonly ILogger<RealizarBuscarPorCarsUseCase> _logger;
        private readonly IRealizarBuscarPorCarsRepository _realizarBuscarPorCarsRepository;
        private readonly IMapper _mapper;
        public RealizarBuscarPorCarsUseCase(IMemoryCache memoryCache,
                                            ICarStoreV2 inner,
                                            ILogger<RealizarBuscarPorCarsUseCase> logger,
                                            IRealizarBuscarPorCarsRepository realizarBuscarPorCarsRepository, 
                                            IMapper mapper)
        {
            _memoryCache = memoryCache;
            _inner2 = inner;
            _logger = logger;
            _realizarBuscarPorCarsRepository = realizarBuscarPorCarsRepository;
            _mapper = mapper;
        }

        public Task<SimulacaoCarResponse> ConsultaVeiculo(SimulacaoCarRequest request)
        {
            throw new NotImplementedException();
        }
    }
}