using System.Windows.Input;
using MvvmCurrencyConverterApp.Infrastructure;
using MvvmCurrencyConverterApp.Model;

namespace MvvmCurrencyConverterApp.ViewModel {
   public class MainWindowViewModel : ViewModelBase {
      public decimal Result { get; set; }

      private ConverterModel _currentClient;

      public ConverterModel ModelClient {
         get {
            if(_currentClient == null) {
               _currentClient = new ConverterModel();
            }
            return _currentClient;
         }
         set {
            _currentClient = value;
            OnPropertyChanged("ModelClient");
         }
      }

      private AppCommand _computeCommand;

      public ICommand Compute {
         get {
            if(_computeCommand == null) {
               _computeCommand = new AppCommand(ExecuteAppCommand, CanExecuteComputeCommand);
            }
            return _computeCommand;
         }
      }

      public void ExecuteAppCommand(object parameter) {
         if(ModelClient.IsUsdChecked) {
            Result = ModelClient.EntrySum * ModelClient.ExchangeRate;
         }
         else {
            if(ModelClient.IsByrChecked) {
               Result = ModelClient.EntrySum / ModelClient.ExchangeRate;
            }
         }
         OnPropertyChanged("Result");
         //Для работы binfing'a отслеживаемый параметр должен быть членом класса, который наследует INotifyPropertyChanged (здесь он внутри ViewModelBase)
      }

      public bool CanExecuteComputeCommand(object parameter) {
         if((ModelClient.EntrySum != 0 && ModelClient.ExchangeRate != 0) && (ModelClient.IsByrChecked || ModelClient.IsUsdChecked)) {
            return true;
         }
         return false;
      }
   }
}