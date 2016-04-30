using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MediaFileLib {
   [Serializable]
   public class PlayList {
      public PlayList() {
         MediaFiles = new List<MediaFile>();
      }

      public List<MediaFile> MediaFiles { get; private set; }
      public string Name { get; set; }

      /// <summary>
      /// save current file
      /// </summary>
      /// <param name="strFileName"></param>
      public void Save(string strFileName) {
         using(FileStream fs = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)) {
            BinaryFormatter objFormatter = new BinaryFormatter();
            objFormatter.Serialize(fs, MediaFiles);
         }
      }

      /// <summary>
      /// Open current file
      /// </summary>
      /// <param name="strFileName"></param>
      public void Open(string strFileName) {
         using(FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
            BinaryFormatter objFormatter = new BinaryFormatter();
            MediaFiles = (List<MediaFile>)objFormatter.Deserialize(fs);
         }
      }
   }
}