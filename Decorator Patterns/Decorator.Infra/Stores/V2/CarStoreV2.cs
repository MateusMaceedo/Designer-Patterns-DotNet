using Bogus;
using Decorator.Application.Interfaces;
using Decorator.Application.Models.V2;
using System.Collections.Generic;
using System.Linq;

namespace Decorator.Infra.Stores.V2
{
    public class CarStoreV2 : ICarStoreV2
    {
        public List<CarV2> CarStorageV2 { get; set; }

        public CarStoreV2()
        {
            var id = 0;
            var testOrdersV2 = new Faker<CarV2>()
            .RuleFor(o => o.IdSimulacao, f => ++id)
            .RuleFor(o => o.YearVeiculo, f => f.Random.Int(1950, 2020))
            .RuleFor(o => o.BrandVeiculo, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.ModelVeiculo, f => f.Vehicle.Model());
            CarStorageV2 = testOrdersV2.Generate(10);
        }

        public CarDtoV2 ListV2()
        {
            return new CarDtoV2("Database", CarStorageV2.ToArray());
        }

        public CarDtoV2 GetV2(int userid)
        {
            return new CarDtoV2("Database", CarStorageV2.FirstOrDefault(f => f.IdSimulacao == userid));
        }
    }
}
