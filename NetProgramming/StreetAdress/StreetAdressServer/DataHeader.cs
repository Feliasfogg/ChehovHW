using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StreetAdressServer
{
   [Serializable]
   public class DataHeader
   {
      public int Size { get; set; }
      public string Type { get; set; }

      public byte[] GetBytes() {
         byte[] btarrBuffer;
         using(MemoryStream objStream = new MemoryStream()) {
            BinaryFormatter objFormatter = new BinaryFormatter();
            objFormatter.Serialize(objStream, this);
            btarrBuffer = objStream.GetBuffer();
         }
         return btarrBuffer;
      }
   }
}
