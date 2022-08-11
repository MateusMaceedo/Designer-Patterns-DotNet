using Decorator.Application.Models.V2;
using Decorator.Models;

namespace Decorator.Stores
{
    public interface ICarStore
    {
        CarDtoV1 ListV1();
        CarDtoV1 GetV1(int id);
        CarDtoV2 ListV2();
        CarDtoV2 GetV2(int id);
    }
}