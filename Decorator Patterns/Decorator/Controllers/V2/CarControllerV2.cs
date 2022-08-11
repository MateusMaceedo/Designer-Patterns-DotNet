using Decorator.Application.Attributes;
using Decorator.Application.Interfaces;
using Decorator.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Decorator.Controllers
{
    [ApiVersion("2.0")]
    [Route("cars/v{version:apiVersion}/simulacoes")]
    public class CarControllerV2 : ApiController
    {
        private readonly ILogger<CarControllerV2> __logger;
        private readonly IRealizarBuscaPorCarsPorIdUseCase _realizarBuscaPorCarsPorIdUseCase;
        private readonly IRealizarBuscarPorCarsUseCase _realizarBuscarPorCarsUseCase;

        public CarControllerV2(ILogger<CarControllerV2> logger, 
                               IRealizarBuscaPorCarsPorIdUseCase realizarBuscaPorCarsPorIdUseCase, 
                               IRealizarBuscarPorCarsUseCase realizarBuscarPorCarsUseCase)
        {
            __logger = logger;
            _realizarBuscaPorCarsPorIdUseCase = realizarBuscaPorCarsPorIdUseCase;
            _realizarBuscarPorCarsUseCase = realizarBuscarPorCarsUseCase;
        }

        /// <summary>
        /// Obtém todos os carros.
        /// </summary>
        /// <returns>Retorna os carros encontrados</returns>
        /// <response code="200">Retorna os carros encontrados</response>
        [CustomResponse(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return ResponseOk(_realizarBuscarPorCarsUseCase.ListV2());
            }
            catch (System.Exception)
            {
                __logger.LogError("Error ao realizar Consulta de Cars");
                throw new System.Exception("Error ao realizar Consulta de Cars");
            }
        }

        /// <summary>
        /// Obtém um carros pelo seu identificador.
        /// </summary>
        /// <param name="id">id do carros</param>
        /// <returns>Retorna o carro encontrado</returns>
        /// <response code="200">Retorna o carro encontrado</response>
        /// <response code="400">Se o id passado for nulo</response>
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var car = _realizarBuscaPorCarsPorIdUseCase.GetV2(id);

                if (car is null)
                {
                    return ResponseNotFound();
                }

                return ResponseOk(_realizarBuscaPorCarsPorIdUseCase.GetV2(id));
            }
            catch (System.Exception)
            {
                __logger.LogError($"Error ao realizar Consulta de Cars, por id '{id}'");
                throw new System.Exception("Error ao realizar Consulta de Cars");
            }
        }
    }
}
