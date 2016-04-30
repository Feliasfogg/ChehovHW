using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam5 {
   public class MyClass {
      public MyClass() {
         Value = 0;
      }
      public int Value { get; private set; }
      public void DoSomeWork() {
         while(Value != 100) {
            ++Value;
            ValueChanged(this, null);
            Thread.Sleep(500);
         }
      }
      public event EventHandler ValueChanged;
   }
}
