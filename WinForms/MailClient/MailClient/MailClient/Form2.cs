using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient {
   public partial class Form2 : Form {
      private int iNodeId;

      public Form2(int iNodeId) {
         InitializeComponent();
         this.iNodeId = iNodeId;
      }

      private void button1_Click(object sender, EventArgs e) {
         if(textBox1.Text==String.Empty || textBox2.Text == String.Empty) {
            MessageBox.Show("Please, fill all fields");
            return;
         }
         try {
            var objReceiverGroup = Form1.objModel.Groups.Where(gr => gr.Id == iNodeId).Single();
            if(objReceiverGroup == null) throw new ArgumentException("Cant find group with current ID: " + iNodeId);

            var objReciever = new Receiver();
            objReciever.Name = textBox1.Text;
            objReciever.Email = textBox2.Text;
            objReciever.Group = objReceiverGroup;

            Form1.objModel.Receivers.Add(objReciever);
            Form1.objModel.SaveChanges();

            this.Close();
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}