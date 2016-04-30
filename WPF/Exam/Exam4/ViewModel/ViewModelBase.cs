using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Exam4.Annotations;

namespace Exam4.ViewModel
{
  public class ViewModelBase:INotifyPropertyChanged
   {
     public event PropertyChangedEventHandler PropertyChanged;

     [NotifyPropertyChangedInvocator]
     protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
         //проверка подписи на событие
         //то же самое что if(PropertyChanged!=null){PropertyChanged(..,..); }
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
  }
}
