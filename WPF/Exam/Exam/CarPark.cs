using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam {
   public class CarPark {
      public CarPark() {
         Cars = new List<Car>(5);
         for(int i = 0; i < 5; ++i) {
            Cars.Add(new Car());
         }
      }

      public List<Car> Cars { get; set; }
   }
}