using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1 {
   public class BaseProvider : IDisposable {
      private UderDbModelContainer _Container = new UderDbModelContainer();

      public List<Contact> GetAllContactsForUser(User objUser) {
         return _Container.Contacts.Where(contact => contact.UserId == objUser.Id).ToList();
      }

      public User AddUser(string strName) {
         _Container.Users.Add(new User { Name = strName });
         _Container.SaveChanges();
         return _Container.Users.OrderByDescending(user => user.Id).FirstOrDefault();
      }

      public User GetUserByName(string strName) {
         return _Container.Users.FirstOrDefault(user => user.Name == strName);
      }
      public void Save() {
         _Container.SaveChanges();
      }
      public void AddContact(User objUser, Contact objContact) {
         User tempUser = _Container.Users.FirstOrDefault(user => user.Id == objUser.Id);
         tempUser.Contacts.Add(objContact);
         _Container.SaveChanges();
      }
      public void RemoveContact(string strId, string strTelephone) {
         User tempUser = _Container.Users.FirstOrDefault(user => user.Id == Convert.ToInt32(strId));
         Contact tempContact = _Container.Contacts.FirstOrDefault(contact => contact.Telephone == strTelephone);
         tempUser.Contacts.Remove(tempContact);
         _Container.SaveChanges();
      }
      public void Dispose() {
         _Container.SaveChanges();
         _Container.Dispose();
      }
   }
}