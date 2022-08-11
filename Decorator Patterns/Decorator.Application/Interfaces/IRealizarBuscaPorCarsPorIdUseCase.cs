using Decorator.Application.Models.V2;
using System;

namespace Decorator.Application.Interfaces
{
    public interface IRealizarBuscaPorCarsPorIdUseCase
    {
        CarDtoV2 GetV2(int id);
    }
}
