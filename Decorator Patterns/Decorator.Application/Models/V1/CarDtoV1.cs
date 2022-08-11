using System.Collections.Generic;
using System.Linq;

namespace Decorator.Models
{
    public class CarDtoV1
    {
        public List<CarV1> Cars { get; set; }
        public string From { get; set; }

        public CarDtoV1(string from, params CarV1[] cars)
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
