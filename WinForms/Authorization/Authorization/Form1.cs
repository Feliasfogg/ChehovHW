using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization {
   public partial class Form1 : Form {
      public Form1() {
         InitializeComponent();
      }

      private void textBox1_GotFocus(object sender, EventArgs e) {
         textBox1.Text = String.Empty;
         textBox1.ForeColor = Color.Black;
      }

      private void textBox1_LostFocus(object sender, EventArgs e) {
         if(textBox1.Text == String.Empty) {
            textBox1.Text = "Login";
            textBox1.ForeColor = Color.Gray;
         }
         else {
            textBox1.ForeColor = Color.Black;
         }
      }

      private void textBox2_GotFocus(object sender, EventArgs e) {
         textBox2.Text = String.Empty;
         textBox2.ForeColor = Color.Black;
      }

      private void textBox2_LostFocus(object sender, EventArgs e) {
         if(textBox2.Text == String.Empty) {
            textBox2.Text = "Password";
            textBox2.ForeColor = Color.Gray;
         }
         else {
            textBox2.ForeColor = Color.Black;
         }
      }

      private void button1_Click(object sender, EventArgs e) {
         try {
            label1.Text = "Searching...";
            label1.Refresh();
            progressBar1.Value = progressBar1.Minimum;
            for(int i = progressBar1.Minimum; i < progressBar1.Maximum; ++i) {
               progressBar1.Value = i;
               progressBar1.Refresh();
               Thread.Sleep(30);
            }
            progressBar1.Value = progressBar1.Minimum;


            var objUser = new UserData();
            objUser.Login = textBox1.Text;
            objUser.Password = textBox2.Text;

            string strUserId=Program.ObjConnector.LogIn(objUser);

            if (strUserId != String.Empty)
            {
               this.Hide();
               Form3 objForm3 = new Form3(Program.ObjConnector.GetUserInfo(strUserId));
               objForm3.ShowDialog();
               this.Show();
               return;
            }

            label1.ForeColor = Color.Red;
            label1.Text = "User not found";
            label1.Refresh();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var objForm2 = new Form2();
         this.Hide();
         objForm2.ShowDialog();
         this.Show();
      }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         Form4 objForm4 = new Form4();
         this.Hide();
         objForm4.ShowDialog();
         this.Show();
      }
   }
}