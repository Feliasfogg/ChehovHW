using System.Collections.Generic;

namespace CarFactoryApp
{
   public class CarFactory
   {
      static CarFactory()
      {
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
      private static  List<Car> GoodCars { get; set; }

      public static List<Car> GetCars() {
         return GoodCars;
      }
   }
}
