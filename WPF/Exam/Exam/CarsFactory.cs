using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam {
   public class CarsFactory {
      public static List<Car> GetCarsFromFactory() {
         var cars = new List<Car>(5);
         for(int i = 0; i < 5; ++i) {
            cars.Add(new Car());
         }
         return cars;
      }
   }
}