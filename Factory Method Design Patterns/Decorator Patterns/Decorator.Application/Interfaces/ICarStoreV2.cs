using Decorator.Application.Models.V2;

namespace Decorator.Application.Interfaces
{
    public interface ICarStoreV2
    {
        CarDtoV2 ListV2();
        CarDtoV2 GetV2(int id);
    }
}
