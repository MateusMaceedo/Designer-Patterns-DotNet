using System;

namespace Decorator.Application.Models.V2
{
    public class CarV2
    {
        public DateTime DataSimulacao { get; set; }
        public int IdSimulacao { get; set; }
        public string ModelVeiculo { get; set; }
        public string BrandVeiculo { get; set; }
        public int YearVeiculo { get; set; }
        public string TipoVeiculo { get; set; }
        public string Company { get; set; }
        public string CompanySuffix { get; set; }
    }
}
