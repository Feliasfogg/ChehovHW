using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization {
   public partial class Form2 : Form {
      public Form2() {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e) {
         try {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "") {
               MessageBox.Show("Fill all important fields");
               return;
            }
            if(textBox2.Text != textBox3.Text) {
               MessageBox.Show("Incorrect password");
               return;
            }
            var objUser = new UserData();
            objUser.Login = textBox1.Text;
            objUser.Password = textBox2.Text;
            objUser.FirstName = textBox4.Text;
            objUser.LastName = textBox5.Text;
            objUser.Email = textBox6.Text;

            Program.ObjConnector.Register(objUser);

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