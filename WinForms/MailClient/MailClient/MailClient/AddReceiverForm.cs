using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailHelper;

namespace MailClient {
   public partial class AddReceiverForm : Form {
      private int iNodeId;

      public AddReceiverForm(int iNodeId) {
         InitializeComponent();
         this.iNodeId = iNodeId;
      }

      private void button1_Click(object sender, EventArgs e) {
         if(textBox1.Text == String.Empty || textBox2.Text == String.Empty) {
            MessageBox.Show("Please, fill all fields");
            return;
         }
         try {
            using(var objProvider = new MailProvider()) {
               Group objReceiverGroup = objProvider.GetGroupById(iNodeId);
               if(objReceiverGroup == null) {
                  throw new ArgumentException("Cant find group with current ID: " + iNodeId);
               }

               var objReciever = new Receiver();
               objReciever.Name = textBox1.Text;
               objReciever.Email = textBox2.Text;
               objReciever.Group = objReceiverGroup;

               objProvider.AddReceiver(objReciever);
            }
            this.Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}