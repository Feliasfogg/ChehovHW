using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAjaxApp {
   public partial class WebForm1 : System.Web.UI.Page {
      private Dictionary<string, List<string>> _Country = new Dictionary<string, List<string>>();
      private List<string> _Cities = new List<string>();

      protected void Page_Load(object sender, EventArgs e) {
      }

      protected void Button1_Click(object sender, EventArgs e) {
         //Label1.Text = TextBox1.Text;
      }

      protected override void OnInit(EventArgs e) {
         _Cities.Add("Минск");
         _Cities.Add("Гомель");
         _Country.Add("Беларусь", _Cities);
         _Country.Add("Лаос", _Cities);

         DropDownList1.DataSource = _Country.Keys;
         DropDownList1.DataBind();

      }

      protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) {
         DropDownList2.DataSource = _Country[DropDownList2.SelectedItem.ToString()];
         DropDownList2.DataBind();
      }
   }
}