using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization {
   public partial class Form4 : Form {
      public Form4() {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e) {
         try {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") {
               MessageBox.Show("Fill all fields");
               return;
            }
            if(textBox2.Text != textBox3.Text) {
               MessageBox.Show("Passwords must match");
            }

            var objUser = new UserData();
            objUser.Password = textBox2.Text;
            objUser.Email = textBox1.Text;
            Program.ObjConnector.ChangePassword(objUser);
            MessageBox.Show("Password changed!");
            this.Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void button2_Click(object sender, EventArgs e) {
         this.Close();
      }
   }
}