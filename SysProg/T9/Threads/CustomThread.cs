using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads {
   public class CustomThread {
      private static int Number { get; set; }
      public int CurrentNumber { get; set; }
      private Thread Thread { get; set; }

      public CustomThread(ParameterizedThreadStart objDelegate) {
         Thread = new Thread(objDelegate);
         ++Number;
         CurrentNumber = Number;
      }

      public void Start() {
         Thread.Start(this);
      }
      public void Abort()
      {
         Thread.Abort();
      }
   }
}