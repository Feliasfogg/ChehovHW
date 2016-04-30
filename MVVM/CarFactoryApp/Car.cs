namespace CarFactoryApp
{
   public class Car
   {
      public string Name { get; set; }
      public string Manufactired { get; set; }
      public int FuelLevel { get; set; }
      public override string ToString() {
         return Name + ", " + Manufactired + ", уровень топлива: " + FuelLevel.ToString();
      }
   }
}
