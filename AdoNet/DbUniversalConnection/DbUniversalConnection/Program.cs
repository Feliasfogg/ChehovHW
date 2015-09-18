using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalConnector;

namespace DbUniversalConnection
{
   class Program
   {
      static void Main(string[] args) {
         try {
            Connector objConnector = new Connector("DefaultConnection");
            objConnector.Connect();
            Console.WriteLine(objConnector.State);
            Console.WriteLine(objConnector.GetData("SELECT * FROM PERSONS"));

         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
         }
      }
   }
}
