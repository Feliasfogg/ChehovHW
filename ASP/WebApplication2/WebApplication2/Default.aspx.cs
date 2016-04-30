using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2 {
   public class User {
      public int secretInt { get; set; }
      public int Hits { get; set; }
      [Required]
      public string Email { get; set; }
      [Required]
      public string PhoneNumber { get; set; }
      [Required]
      public string Name { get; set; }
   }

   public partial class Default : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         var user = new User();
         user.Email = email.Value;
         user.PhoneNumber = userPhoneNumber.Value;
         user.Name = userName.Value;

         if (user.Name != null) {

         }

         Debug.WriteLine(user.Email);
         Debug.WriteLine(user.PhoneNumber);

         //User currentUser;
         //if(Session["user"] != null) {
         //   currentUser = (User)(Session["user"]);
         //}
         //else {
         //   currentUser = new User();
         //   currentUser.secretInt = new Random().Next(1000);
         //   currentUser.Hits += 1;
         //   Session["user"] = currentUser;

         //}
         //hits.InnerText = currentUser.Hits.ToString();
         //sessionId.InnerText = currentUser.secretInt.ToString();
         //Debug.WriteLine(currentUser.secretInt);
         //Debug.WriteLine(currentUser.Hits);
      }
   }
}