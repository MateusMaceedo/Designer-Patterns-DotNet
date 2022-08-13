using Decorator.Application.Models.V2;
using Decorator.Application.Request;
using Decorator.Application.Response;
using System.Threading.Tasks;

namespace Decorator.Application.Interfaces
{
    public interface IRealizarBuscarPorCarsUseCase
    {
        Task<SimulacaoCarResponse> ConsultaVeiculo(SimulacaoCarRequest request);
    }
}
