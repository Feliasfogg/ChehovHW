using System;
using System.Windows.Input;

namespace MvvmCurrencyConverterApp.Infrastructure {
   public class AppCommand : ICommand {
      private Action<object> _execute;
      private Predicate<object> _canExecute;

      public AppCommand(Action<object> execute)
         : this(execute, null) {
      }

      public AppCommand(Action<object> execute, Predicate<object> canExecute = null) {
         if(execute == null) {
            throw new ArgumentNullException();
         }

         _execute = execute;
         _canExecute = canExecute;
      }

      public bool CanExecute(object parameter) {
         return _canExecute == null ? true : _canExecute.Invoke(parameter);
      }

      public void Execute(object parameter) {
         _execute.Invoke(parameter);
      }

      public event EventHandler CanExecuteChanged {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }
   }
}