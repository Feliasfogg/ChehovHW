using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace T9 {
   public class T9Helper {
      private List<string> objStrings = new List<string>();

      public string Source { get; set; }

      public async void OpenSource(string strPath) {
         await OpenSourceAsync(strPath);
      }

      public Task OpenSourceAsync(string strPath) {
         return Task.Factory.StartNew(() => {
            Source = strPath;
            using(StreamReader objReader = new StreamReader(new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.None), Encoding.UTF8)) {
               while(!objReader.EndOfStream) {
                  //check retries
                  objStrings.Add(objReader.ReadLine());
               }
            }
         });
      }

      public Task<string[]> GetWordAsync(string strBegin) {
         var objSourceCompletition = new TaskCompletionSource<string[]>();
         Task.Factory.StartNew(() => {
            try {
               string[] strarrFindWords = objStrings.Where(s => s.StartsWith(strBegin)).Take(5).ToArray();
               objSourceCompletition.TrySetResult(strarrFindWords);
            }
            catch(Exception ex) {
               objSourceCompletition.SetException(ex);
            }
         });
         return objSourceCompletition.Task;
      }
   }
}