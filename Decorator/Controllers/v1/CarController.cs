using Decorator.Application.Attributes;
using Decorator.Application.Interfaces;
using Decorator.Controllers.Base;
using Decorator.Models;
using Decorator.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Decorator.Controllers
{
    [Route("cars/v1/simulacoes")]
    public class CarController : ApiController
    {
        private readonly ILogger<CarController> __logger;
        //private readonly IRealizarBuscarPorCarsUseCase _realizarBuscarPorCarsUseCase;
        //private readonly IRealizarBuscaPorCarsPorIdUseCase _realizarBuscaPorCarsPorIdUseCase;
        private readonly ICarStore _store;

        public CarController(ICarStore store,
                             //IRealizarBuscarPorCarsUseCase realizarBuscarPorCars,
                             //IRealizarBuscaPorCarsPorIdUseCase realizarBuscaPorCarsPorIdUseCase, 
                             ILogger<CarController> logger)
        {
            _store = store;
            //_realizarBuscarPorCarsUseCase = realizarBuscarPorCars;
            //_realizarBuscaPorCarsPorIdUseCase = realizarBuscaPorCarsPorIdUseCase;
            __logger = logger;
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
                return ResponseOk(_store.List());
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
                var car = _store.Get(id);

                if(car is null)
                {
                    return ResponseNotFound();
                }

                return ResponseOk(_store.Get(id));
            }
            catch (System.Exception)
            {
                __logger.LogError($"Error ao realizar Consulta de Cars, por id '{id}'");
                throw new System.Exception("Error ao realizar Consulta de Cars");
            }
        }
    }
}
