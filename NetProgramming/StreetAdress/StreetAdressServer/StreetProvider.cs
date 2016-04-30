using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetAdressServer {
   public class StreetProvider : IDisposable {
      private StreetAdressModelContainer _StreetDataBase = new StreetAdressModelContainer();

      public async Task<List<Street>> GetStreetByIndexAsync(string strIndex) {
         return await _StreetDataBase.Streets.Where(street => street.Index == strIndex).OrderBy(s => s.Adress).ToListAsync();
      }

      public void Dispose() {
         _StreetDataBase.Dispose();
      }
   }
}