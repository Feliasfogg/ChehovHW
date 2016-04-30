using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CarFactoryApp
{
   public class CarsFactoryConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
         return CarFactory.GetCars();
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
         throw new NotImplementedException();
      }
   }
}
