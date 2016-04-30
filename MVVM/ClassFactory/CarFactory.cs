using System.Collections.Generic;
using System.Net;

namespace CarsFactoryApp
{
   public class CarFactory
   {
      static CarFactory() {
         GoodCars = new List<Car>() {
            new Car() {
               FuelLevel = 98,
               Manufactired = "1999",
               Name = "BMW"
            },
            new Car() {
               FuelLevel = 75,
               Manufactired = "2001",
               Name = "Lada"
            },
            new Car() {
               FuelLevel = 45,
               Manufactired = "2005",
               Name = "Roll's Royce"
            }
         };
      }
      public static List<Car> GetCars() {
         return GoodCars;
      } 
      private static List<Car> GoodCars { get; set; } 
   }
}
