using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper {
   public class MailProvider : IDisposable {
      private MailBaseModelContainer _ObjBaseModel;

      public MailProvider() {
         _ObjBaseModel = new MailBaseModelContainer();
      }

      public Receiver GetReceiver(int iId, string strName) {
         return _ObjBaseModel.Receivers.FirstOrDefault(r => r.Id == iId && r.Name == strName);
      }

      public Group GetGroupByName(string strName) {
         return _ObjBaseModel.Groups.FirstOrDefault(g => g.Name == strName);
      }

      public Group GetGroup(int iId, string strName) {
         return _ObjBaseModel.Groups.SingleOrDefault(r => r.Id == iId && r.Name == strName);
      }

      public Group GetGroupById(int iId) {
         return _ObjBaseModel.Groups.SingleOrDefault(gr => gr.Id == iId);
      }

      public void AddEmail(Email objEmail) {
         _ObjBaseModel.Emails.Add(objEmail);
      }

      public void AddReceiver(Receiver objReceiver) {
         _ObjBaseModel.Receivers.Add(objReceiver);
      }

      public Email GetEmailById(int iId) {
         return _ObjBaseModel.Emails.SingleOrDefault(e => e.Id == iId);
      }

      public List<Receiver> GetReceiversByGroupId(int iId) {
         return _ObjBaseModel.Receivers.Where(r => r.Group.Id == iId).ToList();
      }

      public List<Group> GetAllGroups() {
         return _ObjBaseModel.Groups.OrderBy(gr => gr.Name).ToList();
      }

      public MailBaseModelContainer Base {
         get { return _ObjBaseModel; }
      }

      public List<Email> GetEmailsByReceiverId(int iId) {
         return _ObjBaseModel.Emails.Where(em => em.Receiver.Id == iId).
            OrderBy(o => o.Sended).ToList();
      }

      public void AddGroup(Group objGroup) {
         _ObjBaseModel.Groups.Add(objGroup);
      }

      public void RemoveEmailById(int iId) {
         Email objEmail = _ObjBaseModel.Emails.SingleOrDefault(e => e.Id == iId);
         _ObjBaseModel.Emails.Remove(objEmail);
      }

      public void RemoveReceiver(Receiver objReceiver) {
         _ObjBaseModel.Receivers.Remove(objReceiver);
         Email[] objEmails = _ObjBaseModel.Emails.Where(e => e.Receiver.Id == objReceiver.Id).ToArray();
         _ObjBaseModel.Emails.RemoveRange(objEmails);
      }

      public void RemoveGroup(Group objGroup) {
         _ObjBaseModel.Groups.Remove(objGroup);
      }

      public void SaveChanges() {
         _ObjBaseModel.SaveChanges();
      }

      public void Dispose() {
         _ObjBaseModel.SaveChanges();
         _ObjBaseModel.Dispose();
      }
   }
}