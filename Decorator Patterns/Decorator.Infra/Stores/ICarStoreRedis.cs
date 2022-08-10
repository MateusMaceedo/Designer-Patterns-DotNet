using Decorator.Models;

namespace Decorator.Infra.Stores
{
    public interface ICarStoreRedis
    {
        CarDto List();
        CarDto Get(int id);
    }
}
