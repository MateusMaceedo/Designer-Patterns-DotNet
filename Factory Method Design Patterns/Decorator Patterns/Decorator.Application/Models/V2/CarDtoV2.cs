using System.Collections.Generic;
using System.Linq;

namespace Decorator.Application.Models.V2
{
    public class CarDtoV2
    {
        public List<CarV2> Cars { get; set; }
        public string From { get; set; }

        public CarDtoV2(string from, params CarV2[] cars)
        {
            Cars = cars.ToList();
            From = from;
        }

        public void FromMemory()
        {
            From = "Memory Cache";
        }
    }
}
