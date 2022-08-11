using System.Collections.Generic;
using System.Linq;
using Bogus;
using Decorator.Application.Models.V2;
using Decorator.Models;

namespace Decorator.Stores
{
    public class CarStoreV1 : ICarStoreV1
    {
        public List<CarV1> CarStorageV1 { get; set; }

        public CarStoreV1()
        {
            var id = 0;
            var testOrdersV1 = new Faker<CarV1>()
            .RuleFor(o => o.Id, f => ++id)
            .RuleFor(o => o.Year, f => f.Random.Int(1950, 2020))
            .RuleFor(o => o.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.Model, f => f.Vehicle.Model());
            CarStorageV1 = testOrdersV1.Generate(10);
        }

        public CarDtoV1 ListV1()
        {
            return new CarDtoV1("Database", CarStorageV1.ToArray());
        }

        public CarDtoV1 GetV1(int userid)
        {
            return new CarDtoV1("Database", CarStorageV1.FirstOrDefault(f => f.Id == userid));
        }
    }
}