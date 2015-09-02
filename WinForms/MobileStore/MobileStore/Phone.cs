using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore {
   [Serializable]
   public class Phone {
      public string Model { get; set; }
      public string Os { get; set; }
      public string Cpu { get; set; }
      public int Price { get; set; }
      public string ImagePath { get; set; }
      public List<string> OptionsList { get; set; }

      public override string ToString() {
         return String.Format("{0} {1} Цена {2}", Model, Os, Price.ToString());
      }

      public Phone() {
         OptionsList = new List<string>();
      }
   }
}