using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.ViewModel;

namespace Exam4.Model
{
   public class Currency: ViewModelBase {
      private double _Value;
      private double _Cost;
      public double Value {
         get { return _Value; }
         set { _Value = value;
            base.OnPropertyChanged("Value");
         }
      }
      public double Cost { get; set; }
   }
}
