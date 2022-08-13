using Decorator.Application.Models.V2;
using Decorator.Models;

namespace Decorator.Stores
{
    public interface ICarStoreV1
    {
        CarDtoV1 ListV1();
        CarDtoV1 GetV1(int id);
    }
}