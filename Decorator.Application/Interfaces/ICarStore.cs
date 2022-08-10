using Decorator.Models;
using System.Threading.Tasks;

namespace Decorator.Stores
{
    public interface ICarStore
    {
        CarDto List();
        CarDto Get(int id);
    }
}