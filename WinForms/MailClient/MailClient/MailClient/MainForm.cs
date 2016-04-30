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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters.Binary;
using MailHelper;

namespace MailClient {
   public partial class MainForm : Form {
      private Options objOptions;


      public MainForm() {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, EventArgs e) {
         try {
            var objOptionsFile = new FileInfo("options.bin");
            if(objOptionsFile.Exists) {
               using(var objStream = new FileStream("options.bin", FileMode.Open, FileAccess.Read, FileShare.Read)) {
                  var objFormatter = new BinaryFormatter();
                  objOptions = (Options)objFormatter.Deserialize(objStream);
               }
            }
            else {
               objOptions = new Options();
               objOptions.Servers.Add("Mail.ru", new SmtpServerInfo("Mail.ru", "smtp.mail.ru", 25));
               objOptions.Servers.Add("Gmail", new SmtpServerInfo("GMail", "smtp.gmail.com", 58));
               objOptions.Servers.Add("Yandex", new SmtpServerInfo("Yandex", "smtp.yandex.ru", 25));
               objOptions.Email = "ivanitstep@mail.ru";
               objOptions.Password = "ivan123456789";
            }


            comboBox1.Items.AddRange(objOptions.Servers.Keys.ToArray());
            comboBox1.SelectedIndex = 0;

            textBox6.Text = objOptions.Email;
            textBox7.Text = objOptions.Password;

            timer1.Start();

            UpdateTree();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void timer1_Tick(object sender, EventArgs e) {
         backgroundWorker1.RunWorkerAsync();
      }

      /// <summary>
      /// send Email method
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button2_Click(object sender, EventArgs e) {
         try {
            using(var objProvider = new MailProvider()) {
               //create Email
               if(textBox8.Text == String.Empty || richTextBox2.Text == String.Empty) {
                  throw new ArgumentNullException("Fill all fields!");
               }
               //if selected node is Group
               Group objGroup = objProvider.GetGroup((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
               Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);

               if(objGroup != null) {
                  foreach(var receiver in objGroup.Receivers) {
                     var objEmail = new Email() {
                        Receiver = receiver,
                        Text = richTextBox2.Text,
                        Header = textBox8.Text,
                        SendingTime = DateTime.Now
                     };
                     objProvider.AddEmail(objEmail);
                     SendEmail(objEmail);
                  }
               }

               //if receiver
               if(objReceiver != null) {
                  var objEmail = new Email() {
                     Receiver = objReceiver,
                     Text = richTextBox2.Text,
                     Header = textBox8.Text,
                     SendingTime = DateTime.Now
                  };
                  objProvider.AddEmail(objEmail);
                  SendEmail(objEmail);
               }
            }
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
            using(var objProvider = new MailProvider()) {
               Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
               if(objReceiver != null) {
                  if(textBox1.Text == String.Empty || textBox2.Text == String.Empty) {
                     throw new ArgumentNullException("Receiver.Name or Receiver.Email");
                  }

                  objReceiver.Name = textBox1.Text;
                  objReceiver.Email = textBox2.Text;
                  objReceiver.Group = objProvider.GetGroupByName(comboBox2.SelectedItem.ToString());
                  //clear fileds
                  textBox1.Clear();
                  textBox2.Clear();
               }
            }
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
            using(var objProvider = new MailProvider()) {
               Group objGroup = objProvider.GetGroupByName(comboBox2.SelectedItem.ToString());
               if(objGroup != null) {
                  if(textBox3.Text == String.Empty) {
                     throw new ArgumentNullException("Group Name");
                  }
                  objGroup.Name = textBox3.Text;
                  objProvider.SaveChanges();
                  comboBox2.Items.Clear();
                  comboBox2.Items.AddRange(objProvider.GetAllGroups().ToArray());
               }
            }
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
            if(textBox8.Text == String.Empty || richTextBox2.Text == String.Empty) {
               throw new ArgumentNullException("Fill all fileds");
            }
            using(var objProvider = new MailProvider()) {
               var objEmail = new Email() {
                  Header = textBox8.Text,
                  Text = richTextBox2.Text,
                  SendingTime = GetTime(),
                  Sended = false,
                  Receiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name)
               };

               objProvider.AddEmail(objEmail);
            }
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
         try {
            using(var objProvider = new MailProvider()) {
               var objTempEmail = (Email)listBox1.SelectedItem;

               Email objEmail = objProvider.GetEmailById(objTempEmail.Id);
               if(objEmail == null) {
                  throw new ArgumentNullException("Cant find email with Id=" + objTempEmail.Id);
               }
               objEmail.Text = richTextBox3.Text;
               objEmail.Header = textBox9.Text;
            }
            UpdateListBox1();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Delete Email from listBox
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button7_Click(object sender, EventArgs e) {
         try {
            using(var objProvider = new MailProvider()) {
               var objTempEmail = (Email)listBox1.SelectedItem;

               objProvider.RemoveEmailById(objTempEmail.Id);

               label18.Text = String.Empty;
               textBox10.Clear();
               textBox9.Clear();
               richTextBox3.Clear();
            }
            UpdateListBox1();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void button8_Click(object sender, EventArgs e) {
         try {
            objOptions.Servers[comboBox1.SelectedItem.ToString()].Adress = textBox4.Text;
            objOptions.Servers[comboBox1.SelectedItem.ToString()].Port = Convert.ToInt32(textBox5.Text);
            objOptions.Email = textBox6.Text;
            objOptions.Password = textBox7.Text;

            using(var objStream = new FileStream("options.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)) {
               var objFormatter = new BinaryFormatter();
               objFormatter.Serialize(objStream, objOptions);
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// this method create TreeView from NestedSetsTree
      /// </summary>
      /// <param name="objLogicNode">node of NestedSetsTree</param>
      /// <param name="objVisualNode">node of TreeView</param>
      private void CreateTreeView(Group objLogicNode, TreeNode objVisualNode) {
         using(var objProvider = new MailProvider()) {
            //выборка всех recievers котоыре принадлежат к текущей группе
            List<Receiver> objReceivers = objProvider.GetReceiversByGroupId(objLogicNode.Id);

            foreach(var reciever in objReceivers) {
               var objNewTreeNode = new TreeNode() {
                  Tag = reciever.Id,
                  Name = reciever.Name,
                  Text = reciever.Name
               };
               objVisualNode.Nodes.Add(objNewTreeNode);
            }
            //выбор подчиненных узлов на первом уровне, т.е на всех непосредсвенных детей родительского узла
            //SELECT id, name, level FROM my_tree WHERE left_key >= $left_key AND right_key <= $right_key ORDER BY left_key

            var objChildNodes = objProvider.Base.Groups.
               Where(gr => gr.LeftKey > objLogicNode.LeftKey && gr.RightKey < objLogicNode.RightKey && gr.Level == objLogicNode.Level + 1).
               OrderBy(b => b.LeftKey).
               ToList();

            //add all childs on one level
            foreach(var node in objChildNodes) {
               var objNewTreeNode = new TreeNode() {
                  Tag = node.Id,
                  Name = node.Name,
                  Text = node.Name,
               };
               objVisualNode.Nodes.Add(objNewTreeNode);
               CreateTreeView(node, objNewTreeNode);
            }
         }
      }

      /// <summary>
      /// creates form for adding receiver
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ToolStripMenuItem1_Click(object sender, EventArgs e) {
         var objPopUpForm = new AddReceiverForm((int)treeView1.SelectedNode.Tag);
         objPopUpForm.ShowDialog();
         UpdateTree();
      }

      /// <summary>
      /// creates form for adding group
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ToolStripMenuItem2_Click(object sender, EventArgs e) {
         AddGroupForm objPopUpForm = null;
         if(treeView1.SelectedNode != null) {
            objPopUpForm = new AddGroupForm((int)treeView1.SelectedNode.Tag);
         }
         else {
            objPopUpForm = new AddGroupForm(0);
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
            using(var objProvider = new MailProvider()) {
               //get parent  group node
               Group objParentGroup = objProvider.GetGroup((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
               //get receiver node
               Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);

               //if selected is receiver node
               if(objReceiver != null) {
                  objProvider.RemoveReceiver(objReceiver);
               }

               //if selected is group parent node
               if(objParentGroup != null) {
                  //get all childs Recievers
                  List<Group> objChildsToDeleteList = objProvider.Base.Groups.
                     Where(gr => gr.LeftKey >= objParentGroup.LeftKey && gr.RightKey <= objParentGroup.RightKey).ToList();
                  //delete all childs
                  foreach(var node in objChildsToDeleteList) {
                     List<Receiver> objReceiversList = objProvider.Base.Receivers.Where(r => r.Group.Id == node.Id).ToList();
                     for(int iJ = 0; iJ < objReceiversList.Count; ++iJ) {
                        objProvider.RemoveReceiver(objReceiversList[iJ]);
                     }
                     objProvider.RemoveGroup(node);
                  }

                  //update parent branch
                  List<Group> objParentsList = objProvider.Base.Groups.Where(gr => gr.RightKey > objParentGroup.RightKey && gr.LeftKey < objParentGroup.LeftKey).ToList();
                  foreach(var node in objParentsList) {
                     node.RightKey = node.RightKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
                  }

                  //update other childs
                  List<Group> objChildList = objProvider.Base.Groups.Where(gr => gr.LeftKey > objParentGroup.RightKey).ToList();
                  foreach(var node in objChildList) {
                     node.LeftKey = node.LeftKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
                     node.RightKey = node.RightKey - (objParentGroup.RightKey - objParentGroup.LeftKey + 1);
                  }
               }
            }
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
            using(var objProvider = new MailProvider()) {
               Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
               Group objGroup = objProvider.GetGroup((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);

               comboBox2.Items.Clear();
               comboBox2.Items.AddRange(objProvider.GetAllGroups().ToArray());
               listBox1.Items.Clear();
               richTextBox1.Clear();

               //clear MailList fields
               textBox10.Clear();
               textBox9.Clear();
               richTextBox3.Clear();
               label18.Text = String.Empty;

               //if node is receiver
               if(objReceiver != null) {
                 comboBox2.SelectedItem = objReceiver.Group;

                  textBox1.Text = objReceiver.Name;
                  textBox2.Text = objReceiver.Email;
                  richTextBox1.Text = String.Format("{0}: {1}\n", objReceiver.Name, objReceiver.Email);

                  UpdateListBox1();

                  textBox1.Enabled = true;
                  textBox2.Enabled = true;
                  textBox3.Enabled = false;
                  textBox3.Clear();
                  button4.Enabled = false;
               }
               //if group
               if(objGroup != null) {
                  comboBox2.SelectedItem = objGroup;
                  textBox3.Text = objGroup.Name;
                  List<Receiver> objrReceivers = objProvider.GetReceiversByGroupId(objGroup.Id);
                  foreach (var receiver in objrReceivers)
                  {
                     richTextBox1.Text += String.Format("{0}: {1}\n", receiver.Name, receiver.Email);
                  }

                  textBox3.Enabled = true;
                  textBox1.Clear();
                  textBox1.Enabled = false;
                  textBox2.Clear();
                  textBox2.Enabled = false;
                  button4.Enabled = true;
               }
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
            using(var objProvider = new MailProvider()) {
               var objTempEmail = (Email)listBox1.SelectedItem;
               Email objEmail = objProvider.GetEmailById(objTempEmail.Id);
               if(objEmail == null) {
                  return;
               }

               textBox10.Text = objEmail.SendingTime.ToString("dd-MM-yyyy ddd HH:mm");
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
         textBox4.Text = objOptions.Servers[comboBox1.SelectedItem.ToString()].Adress;
         textBox5.Text = objOptions.Servers[comboBox1.SelectedItem.ToString()].Port.ToString();
      }

      /// <summary>
      /// Sort Emails by sended flag
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
         try {
            using(var objProvider = new MailProvider()) {
               Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
               if(objReceiver == null) {
                  return;
               }

               List<Email> objEmails = objProvider.GetEmailsByReceiverId(objReceiver.Id);
               listBox1.Items.Clear();
               if(objEmails.Count != 0) {
                  listBox1.Items.AddRange(objEmails.ToArray());
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
         try {
            using(var objProvider = new MailProvider()) {
               List<Email> objEmails = objProvider.Base.Emails.Where(em => em.SendingTime <= DateTime.Now && em.Sended == false).ToList();
               foreach(var email in objEmails) {
                  SendEmail(email);
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void UpdateListBox1() {
         using(var objProvider = new MailProvider()) {
            listBox1.Items.Clear();
            Receiver objReceiver = objProvider.GetReceiver((int)treeView1.SelectedNode.Tag, treeView1.SelectedNode.Name);
            List<Email> objEmails = objProvider.GetEmailsByReceiverId(objReceiver.Id);

            if(objEmails.Count != 0) {
               listBox1.Items.AddRange(objEmails.ToArray());
               listBox1.SelectedIndex = 0;
            }
         }
      }

      /// <summary>
      /// Get Receiver object by Id and Name
      /// </summary>
      /// <param name="iId"></param>
      /// <param name="strName"></param>
      /// <returns></returns>
      /// <summary>
      /// Get Group object by Id and Name
      /// </summary>
      /// <returns></returns>
      /// <summary>
      /// redrawable TreeView
      /// </summary>
      private void UpdateTree() {
         //create TreeView
         using(var objProvider = new MailProvider()) {
            Group objRootNode = objProvider.Base.Groups.OrderBy(c => c.Id).FirstOrDefault();
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
      }

      private DateTime GetTime() {
         DateTime objSelectedDateTime = monthCalendar1.SelectionStart.Date;
         objSelectedDateTime = objSelectedDateTime.AddHours((int)numericUpDown1.Value);
         objSelectedDateTime = objSelectedDateTime.AddMinutes((int)numericUpDown2.Value);
         return objSelectedDateTime;
      }

      private void SendEmail(Email objEmail) {
         var objSmtpClient = new SmtpClient(
            objOptions.Servers[comboBox1.SelectedItem.ToString()].Adress,
            objOptions.Servers[comboBox1.SelectedItem.ToString()].Port);

         objSmtpClient.Credentials = new NetworkCredential(objOptions.Email, objOptions.Password);
         objSmtpClient.EnableSsl = true;

         var objMailMessage = new MailMessage();
         objMailMessage.From = new MailAddress(objOptions.Email);
         objMailMessage.To.Add(objEmail.Receiver.Email);
         objMailMessage.Subject = objEmail.Header;
         objMailMessage.Body = objEmail.Text;
         objSmtpClient.Send(objMailMessage);

         objEmail.Sended = true;
      }
   }
}