using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient {
   public class SmtpHelper {
      public SmtpHelper(string strName, string strServer, int iPort) {
         Name = strName;
         Server = strServer;
         Port = iPort;
      }

      public string Name { get; set; }
      public string Server { get; set; }
      public int Port { get; set; }
   }
}