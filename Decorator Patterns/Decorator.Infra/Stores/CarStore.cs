using System.Collections.Generic;
using System.Linq;
using Bogus;
using Decorator.Application.Models.V2;
using Decorator.Models;

namespace Decorator.Stores
{
    public class CarStore : ICarStore
    {
        public List<CarV1> CarStorageV1 { get; set; }
        public List<CarV2> CarStorageV2 { get; set; }

        public CarStore()
        {
             var id = 0;
             var testOrdersV1 = new Faker<CarV1>()
            .RuleFor(o => o.Id, f => ++id)
            .RuleFor(o => o.Year, f => f.Random.Int(1950, 2020))
            .RuleFor(o => o.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.Model, f => f.Vehicle.Model());
            CarStorageV1 = testOrdersV1.Generate(10);

             var testOrdersV2 = new Faker<CarV2>()
            .RuleFor(o => o.Id, f => ++id)
            .RuleFor(o => o.Year, f => f.Random.Int(1950, 2020))
            .RuleFor(o => o.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.Model, f => f.Vehicle.Model());
            CarStorageV2 = testOrdersV2.Generate(10);
        }

        public CarDtoV1 ListV1()
        {
            return new CarDtoV1("Database", CarStorageV1.ToArray());
        }

        public CarDtoV2 ListV2()
        {
            return new CarDtoV2("Database", CarStorageV2.ToArray());
        }

        public CarDtoV1 GetV1(int userid)
        {
            return new CarDtoV1("Database", CarStorageV1.FirstOrDefault(f => f.Id == userid));
        }

        public CarDtoV2 GetV2(int userid)
        {
            return new CarDtoV2("Database", CarStorageV2.FirstOrDefault(f => f.Id == userid));
        }
    }
}