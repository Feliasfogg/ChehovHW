using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization {
   internal static class Program {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      public static Connector ObjConnector;

      private static void Main() {
         try {
            ObjConnector = new Connector("DefaultConnection");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}