using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam {
   public class Car {
      public Car() {
         Model = "Audi";
         Year = 1981;
      }

      public string Model { get; set; }
      public int Year { get; set; }

      public override string ToString() {
         return String.Format("Model {0} Year {1}", Model, Year);
      }
   }
}