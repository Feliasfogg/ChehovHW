using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EX2 {
   [Serializable]
   public class Bank {
      private int _money;
      private int _percent;
      private string _name;

      public int Money {
         get { return this._money; }
         set {
            this._money = value;
            PropertyChanged(this);
         }
      }

      public int Percent {
         get { return this._percent; }
         set {
            this._percent = value;
            PropertyChanged(this);
         }
      }

      public string Name {
         get { return this._name; }
         set {
            this._name = value;
            PropertyChanged(this);
         }
      }

      public override string ToString() {
         return String.Format("Name: {0}\nMoney {1},\nPercent {2}", _name, _money, _percent);
      }

      private static void PropertyChanged(Bank objBank) {
         var objThread = new Thread(() => {
            using(StreamWriter objStreamWriter = new StreamWriter("bank.txt")) {
               objStreamWriter.Write(objBank.ToString());
            }
         });
         objThread.Start();
      }
   }
}