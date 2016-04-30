using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW1 {
   internal class Program {
      private static void Main(string[] args) {
         List<string> objList = new List<string>();
         objList.Add("string1");
         objList.Add("string2");
         objList.Add("string3");

         var threadStart = new ParameterizedThreadStart(ThreadFunk);
         var thread = new Thread(threadStart);
         thread.Start(objList);
      }

      public static void ThreadFunk(object obj) {
         var list = obj as List<string>;
         list.ForEach(s => { Console.WriteLine(s.ToString()); });
      }
   }
}