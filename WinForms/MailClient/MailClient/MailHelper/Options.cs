using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper {
   [Serializable]
   public class Options {
      public Options() {
         Servers = new Dictionary<string, SmtpServerInfo>();
      }

      public Dictionary<string, SmtpServerInfo> Servers { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
   }
   [Serializable]
   public class SmtpServerInfo {
      public SmtpServerInfo(string strName, string strAddress, int iPort) {
         Name = strName;
         Adress = strAddress;
         Port = iPort;
      }

      public string Name { get; set; }
      public string Adress { get; set; }
      public int Port { get; set; }
   }
}