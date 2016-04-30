namespace MvvmCurrencyConverterApp.Model {
   public class ConverterModel {
      public ConverterModel() {
         EntrySum = 0;
         ExchangeRate = 0;
      }

      public decimal EntrySum { get; set; }
      public decimal ExchangeRate { get; set; }

      public bool IsUsdChecked { get; set; }
      public bool IsByrChecked { get; set; }
   }
}