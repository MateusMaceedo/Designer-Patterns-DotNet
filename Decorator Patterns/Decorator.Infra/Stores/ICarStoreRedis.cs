using Decorator.Models;

namespace Decorator.Infra.Stores
{
    public interface ICarStoreRedis
    {
        CarDtoV1 List();
        CarDtoV1 Get(int id);
    }
}
