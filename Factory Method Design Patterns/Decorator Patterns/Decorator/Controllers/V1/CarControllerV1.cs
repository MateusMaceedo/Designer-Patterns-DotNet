using Decorator.Application.Attributes;
using Decorator.Controllers.Base;
using Decorator.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Decorator.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [Route("cars/v{version:apiVersion}/simulacoes")]
    public class CarControllerV1 : ApiController
    {
        private readonly ILogger<CarControllerV1> _logger;
        private readonly ICarStoreV1 _store1;

        public CarControllerV1(ICarStoreV1 store,
                             ILogger<CarControllerV1> logger)
        {
            _store1 = store;
            _logger = logger;
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
                return ResponseOk(_store1.ListV1());
            }
            catch (System.Exception)
            {
                _logger.LogError("Error ao realizar Consulta de Cars");
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
                var car = _store1.GetV1(id);

                if(car is null)
                {
                    return ResponseNotFound();
                }

                return ResponseOk(_store1.GetV1(id));
            }
            catch (System.Exception)
            {
                _logger.LogError($"Error ao realizar Consulta de Cars, por id '{id}'");
                throw new System.Exception("Error ao realizar Consulta de Cars");
            }
        }
    }
}
