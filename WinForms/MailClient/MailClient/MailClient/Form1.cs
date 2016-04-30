using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;

namespace MailClient {
   public partial class Form1 : Form {
      public static MailBaseModelContainer objModel;
      private List<SmtpHelper> objSmtpList;
      private string strEmail = "ivanitstep@mail.ru";
      private string strPassword = "ivan123456789";


      public Form1() {
         InitializeComponent();
         objModel = new MailBaseModelContainer();
         objSmtpList = new List<SmtpHelper>();
         objSmtpList.Add(new SmtpHelper("Mail.ru", "smtp.mail.ru", 25));
         objSmtpList.Add(new SmtpHelper("GMail", "smtp.gmail.com", 58));
         objSmtpList.Add(new SmtpHelper("Yandex", "smtp.yandex.ru", 25));

         comboBox1.Items.AddRange(objSmtpList.Select(s => s.Name).ToArray());
         comboBox1.SelectedIndex = 0;

         textBox6.Text = strEmail;
         textBox7.Text = strPassword;

         timer1.Start();

         UpdateTree();
      }


      private void button1_Click(object sender, EventArgs e) {
         int iUnixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - 6 * 3600;
      }

      /// <summary>
      /// send Email method
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button2_Click(object sender, EventArgs e) {
         try {
            Receiver objReceiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            if(objReceiver == null) {
               throw new ArgumentNullException("No such receiver");
            }
            //create smtp object
            var objSmtpClient = new SmtpClient(
               objSmtpList[comboBox1.SelectedIndex].Server,
               objSmtpList[comboBox1.SelectedIndex].Port);
            objSmtpClient.Credentials = new NetworkCredential(textBox6.Text, textBox7.Text);
            objSmtpClient.EnableSsl = true;

            //create Email
            if(textBox8.Text == String.Empty || richTextBox2.Text == String.Empty) {
               throw new ArgumentNullException("Fill all fields!");
            }

            var objMailMessage = new MailMessage();
            objMailMessage.From = new MailAddress(strEmail);
            objMailMessage.To.Add(objReceiver.Email);
            objMailMessage.Subject = textBox8.Text;
            objMailMessage.Body = richTextBox2.Text;
            objSmtpClient.Send(objMailMessage);
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// change receiver info
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button3_Click(object sender, EventArgs e) {
         try {
            Receiver objReceiver = objModel.Receivers.Where(r => r.Id == (int)treeView1.SelectedNode.Tag && r.Name == treeView1.SelectedNode.Name).SingleOrDefault();
            if(objReceiver == null) {
               throw new ArgumentNullException("No such receiver");
            }
            if(textBox1.Text == String.Empty || textBox2.Text == String.Empty) {
               throw new ArgumentNullException("Fill all fields!");
            }

            objReceiver.Name = textBox1.Text;
            objReceiver.Email = textBox2.Text;
            objReceiver.Group = objModel.Groups.Where(gr => gr.Name == comboBox2.SelectedItem).SingleOrDefault();
            objModel.SaveChanges();

            UpdateTree();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// change group info
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button4_Click(object sender, EventArgs e) {
         try {
            Group objGroup = objModel.Groups.Where(gr => gr.Name == comboBox2.SelectedItem).SingleOrDefault();
            if(objGroup == null) {
               throw new ArgumentNullException("No such groupe");
            }
            if(textBox3.Text == String.Empty) {
               throw new ArgumentNullException("Fill New group name field");
            }
            objGroup.Name = textBox3.Text;
            objModel.SaveChanges();
            UpdateTree();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// add email to schedule
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button5_Click(object sender, EventArgs e) {
         try {
            DateTime objUnixtimeDate = monthCalendar1.SelectionRange.Start.ToUniversalTime();
            DateTime objStartPointDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan objDifference = objUnixtimeDate - objStartPointDate;
            //we must substract 6 hours from the current time
            int iUnixTime = (int)objDifference.TotalSeconds + ((int)numericUpDown1.Value - 6) * 3600 + (int)numericUpDown2.Value * 60;


            if(textBox8.Text == String.Empty || richTextBox2.Text == String.Empty) {
               throw new ArgumentNullException("Fill all fileds");
            }

            var objEmail = new Email() {
               Header = textBox8.Text,
               Text = richTextBox2.Text,
               SendingTime = iUnixTime,
               Sended = false,
               Receiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name)
            };

            objModel.Emails.Add(objEmail);
            objModel.SaveChanges();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Update current Email info
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button6_Click(object sender, EventArgs e) {
         var objTempEmail = (Email)listBox1.SelectedItem;
         objTempEmail.Text = richTextBox3.Text;
         objTempEmail.Header = textBox9.Text;

         objModel.SaveChanges();

         UpdateListBox1();
      }

      /// <summary>
      /// Delete Email from listBox
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button7_Click(object sender, EventArgs e) {
         var objTempEmail = (Email)listBox1.SelectedItem;
         objModel.Emails.Remove(objTempEmail);
         objModel.SaveChanges();

         label18.Text = String.Empty;
         textBox10.Clear();
         textBox9.Clear();
         richTextBox3.Clear();

         UpdateListBox1();
      }

      /// <summary>
      /// this method create TreeView from NestedSetsTree
      /// </summary>
      /// <param name="objLogicNode">node of NestedSetsTree</param>
      /// <param name="objVisualNode">node of TreeView</param>
      private void CreateTreeView(Group objLogicNode, TreeNode objVisualNode) {
         //выборка всех recievers котоыре принадлежат к текущей группе
         var objReceiversList = objModel.Receivers.Where(r => r.Group.Id == objLogicNode.Id).ToList();

         foreach(var reciever in objReceiversList) {
            var objNewTreeNode = new TreeNode() {
               Tag = reciever.Id,
               Name = reciever.Name,
               Text = reciever.Name
            };
            objVisualNode.Nodes.Add(objNewTreeNode);
         }
         //выбор подчиненных узлов на первом уровне, т.е на всех непосредсвенных детей родительского узла
         //SELECT id, name, level FROM my_tree WHERE left_key >= $left_key AND right_key <= $right_key ORDER BY left_key
         var objChildNodesList = objModel.Groups.
            Where(gr => gr.LeftKey > objLogicNode.LeftKey && gr.RightKey < objLogicNode.RightKey && gr.Level == objLogicNode.Level + 1).
            OrderBy(b => b.LeftKey).
            ToList();

         //add all childs on one level
         foreach(var node in objChildNodesList) {
            var objNewTreeNode = new TreeNode() {
               Tag = node.Id,
               Name = node.Name,
               Text = node.Name
            };
            objVisualNode.Nodes.Add(objNewTreeNode);
            CreateTreeView(node, objNewTreeNode);
         }
      }

      /// <summary>
      /// creates form for adding receiver
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ToolStripMenuItem1_Click(object sender, EventArgs e) {
         var objPopUpForm = new Form2((int)treeView1.SelectedNode.Tag);
         objPopUpForm.ShowDialog();
         UpdateTree();
      }

      /// <summary>
      /// creates form for adding group
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ToolStripMenuItem2_Click(object sender, EventArgs e) {
         Form3 objPopUpForm = null;
         if(treeView1.SelectedNode != null) {
            objPopUpForm = new Form3((int)treeView1.SelectedNode.Tag);
         }
         else {
            objPopUpForm = new Form3(0);
         }

         objPopUpForm.ShowDialog();
         UpdateTree();
      }

      /// <summary>
      /// delete group and all child nodes
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ToolStripMenuItem3_Click(object sender, EventArgs e) {
         try {
            //get parent  group node
            Group objParentGroup = GetGroup((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            //get receiver node
            Receiver objReceiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);

            //if selected is receiver node
            if(objReceiver != null) {
               objModel.Receivers.Remove(objReceiver);
               return;
            }

            //if selected is group parent node
            if(objParentGroup != null) {
               //get all childs Recievers
               List<Group> objChildsToDeleteList = objModel.Groups.
                  Where(gr => gr.LeftKey >= objParentGroup.LeftKey && gr.RightKey <= objParentGroup.RightKey).ToList();
               //delete all childs
               foreach(var node in objChildsToDeleteList) {
                  List<Receiver> objReceiversList = objModel.Receivers.Where(r => r.Group.Id == node.Id).ToList();
                  for(int iJ = 0; iJ < objReceiversList.Count; ++iJ) {
                     objModel.Receivers.Remove(objReceiversList[iJ]);
                  }
                  objModel.Groups.Remove(node);
               }

               //update parent branch
               List<Group> objParentsList = objModel.Groups.Where(gr => gr.RightKey > objParentGroup.RightKey && gr.LeftKey < objParentGroup.LeftKey).ToList();
               foreach(var node in objParentsList) {
                  node.RightKey = node.RightKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
               }

               //update other childs
               List<Group> objChildList = objModel.Groups.Where(gr => gr.LeftKey > objParentGroup.RightKey).ToList();
               foreach(var node in objChildList) {
                  node.LeftKey = node.LeftKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
                  node.RightKey = node.RightKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
               }
            }

            objModel.SaveChanges();
            UpdateTree();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// get info about node
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
         try {
            treeView1.SelectedNode = e.Node;

            if(e.Button == MouseButtons.Right) {
               contextMenuStrip1.Show();
            }

            Receiver objReceiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            Group objGroup = GetGroup((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            List<string> objGroupsList = objModel.Groups.Select(gr => gr.Name).ToList();

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(objGroupsList.ToArray());
            listBox1.Items.Clear();

            if(objReceiver != null) {
               comboBox2.SelectedIndex = comboBox2.Items.IndexOf(objReceiver.Group.Name);

               textBox1.Text = objReceiver.Name;
               textBox2.Text = objReceiver.Email;
               richTextBox1.Text = String.Format("{0} {1}\n", objReceiver.Name, objReceiver.Email);

               UpdateListBox1();

               textBox1.Enabled = true;
               textBox2.Enabled = true;
               textBox3.Enabled = false;
               textBox3.Clear();
               button4.Enabled = false;
            }

            if(objGroup != null) {
               comboBox2.SelectedIndex = comboBox2.Items.IndexOf(objGroup.Name);
               textBox3.Text = objGroup.Name;

               textBox3.Enabled = true;
               textBox1.Clear();
               textBox1.Enabled = false;
               textBox2.Clear();
               textBox2.Enabled = false;
               button4.Enabled = true;
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Show info about selected email
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
         try {
            var objTempEmail = (Email)listBox1.SelectedItem;
            Email objEmail = objModel.Emails.Where(em => em.Id == objTempEmail.Id).SingleOrDefault();
            if(objEmail == null) {
               return;
            }

            textBox10.Text = ConvertFromUnixTimestamp(objEmail.SendingTime).ToString("yy-MMM-dd ddd HH:mm");
            richTextBox3.Text = objEmail.Text;
            textBox9.Text = objEmail.Header;
            if(objEmail.Sended) {
               label18.ForeColor = Color.DarkGreen;
               label18.Text = "Sended";
            }
            else {
               label18.ForeColor = Color.DarkOrange;
               label18.Text = "Awaits for sending";
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// change SMTP options
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
         textBox4.Text = objSmtpList[comboBox1.SelectedIndex].Server;
         textBox5.Text = objSmtpList[comboBox1.SelectedIndex].Port.ToString();
      }

      /// <summary>
      /// Sort Emails by sended flag
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
         try {
            Receiver objReceiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            if(objReceiver == null) {
               return;
            }

            List<Email> objEmails = objModel.Emails.Where(em => em.Receiver.Id == objReceiver.Id).
               OrderBy(o => o.Sended).ToList();
            listBox1.Items.Clear();
            if(objEmails.Count != 0) {
               listBox1.Items.AddRange(objEmails.ToArray());
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
         try {
            int iUnixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - 6 * 3600;

            List<Email> objEmails = objModel.Emails.Where(em => em.SendingTime <= iUnixTime && em.Sended == false).ToList();

            foreach(var email in objEmails) {
               var objSmtpClient = new SmtpClient(
                  objSmtpList[comboBox1.SelectedIndex].Server,
                  objSmtpList[comboBox1.SelectedIndex].Port);
               objSmtpClient.Credentials = new NetworkCredential(textBox6.Text, textBox7.Text);
               objSmtpClient.EnableSsl = true;

               var objMailMessage = new MailMessage();
               objMailMessage.From = new MailAddress(strEmail);
               objMailMessage.To.Add(email.Receiver.Email);
               objMailMessage.Subject = email.Header;
               objMailMessage.Body = email.Text;
               objSmtpClient.Send(objMailMessage);

               email.Sended = true;
            }
            objModel.SaveChanges();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void timer1_Tick(object sender, EventArgs e) {
         backgroundWorker1.RunWorkerAsync();
      }

      /// <summary>
      /// Get Receiver object by Id and Name
      /// </summary>
      /// <param name="iId"></param>
      /// <param name="strName"></param>
      /// <returns></returns>
      private Receiver GetReceiver(int iId, string strName) {
         return objModel.Receivers.Where(r => r.Id == iId && r.Name == strName).SingleOrDefault();
      }

      /// <summary>
      /// Get Group object by Id and Name
      /// </summary>
      /// <returns></returns>
      private Group GetGroup(int iId, string strName) {
         return objModel.Groups.Where(r => r.Id == iId && r.Name == strName).SingleOrDefault();
      }

      /// <summary>
      /// redrawable TreeView
      /// </summary>
      private void UpdateTree() {
         //create TreeView
         Group objRootNode = objModel.Groups.OrderBy(c => c.Id).Take(1).SingleOrDefault();
         if(objRootNode == null) {
            return;
         }

         treeView1.Nodes.Clear();


         var objVisualRootNode = new TreeNode {
            Tag = objRootNode.Id,
            Name = objRootNode.Name,
            Text = objRootNode.Name
         };
         treeView1.Nodes.Add(objVisualRootNode);

         CreateTreeView(objRootNode, objVisualRootNode);
         treeView1.ExpandAll();

         treeView1.SelectedNode = objVisualRootNode;
      }

      private DateTime ConvertFromUnixTimestamp(int iUnixTime) {
         DateTime objStartDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
         return objStartDate.AddSeconds(iUnixTime);
      }

      private void UpdateListBox1() {
         listBox1.Items.Clear();
         Receiver objReceiver = GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
         List<Email> objEmails = objModel.Emails.
            Where(em => em.Receiver.Id == objReceiver.Id).OrderBy(o => o.SendingTime)
            .ToList();

         if(objEmails.Count != 0) {
            listBox1.Items.AddRange(objEmails.ToArray());
            listBox1.SelectedIndex = 0;
         }
      }
   }
}