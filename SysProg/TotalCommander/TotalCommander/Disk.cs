using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
   public class Disk
   {
      public string Name { get; set; }
      public string CurrentDirectory { get; set; }

      public DriveInfo DriveInfo { get; set; }
      public DirectoryInfo DirectoryInfo { get; set; }
   }
}
