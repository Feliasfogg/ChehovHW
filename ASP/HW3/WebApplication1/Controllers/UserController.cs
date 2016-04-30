using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
   public class UserController : Controller {
      private BaseProvider _Provider = new BaseProvider();

      // GET: User
      public ActionResult Index() {
         return View();
      }

      public ActionResult ShowContacts() {
         User objUser = (User)Session["user"];
         if(objUser == null) {
            return Redirect("/User/Register");
         }
         return View(objUser);
      }

      [HttpPost]
      public ActionResult ShowContacts(string Name, string Telephone) {
         User objUser = (User)Session["user"];
         var objContact = new Contact() {
            Name = Name,
            Telephone = Telephone
         };
         objUser.Contacts.Add(objContact);
         _Provider.AddContact(objUser, objContact);
         return View(objUser);
      }

      public ActionResult Register() {
         return View();
      }
      [HttpGet]
      public ActionResult RemoveContact(string iId, string strTelephone) {
         _Provider.RemoveContact(iId, strTelephone);
         return View();
      }

      [HttpPost]
      public ActionResult Register(string Name) {
         User objUser;
         objUser = _Provider.GetUserByName(Name);
         if(objUser == null) {
            objUser = _Provider.AddUser(Name);
         }

         Session["user"] = objUser;
         return RedirectToRoute(new { controller = "User", action = "ShowContacts" });
      }
   }
}