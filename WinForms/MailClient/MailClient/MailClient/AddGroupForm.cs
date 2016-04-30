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
   public partial class AddGroupForm : Form {
      private int iNodeId;

      public AddGroupForm(int iNodeId) {
         InitializeComponent();
         this.iNodeId = iNodeId;
      }

      private void button1_Click(object sender, EventArgs e) {
         if(textBox1.Text == String.Empty) {
            MessageBox.Show("Please, fill all fields");
            return;
         }

         try {
            using(var objProvider = new MailProvider()) {
               Group objFirstGroup = objProvider.Base.Groups.OrderBy(c => c.Id).FirstOrDefault();

               //if no one nodes in base
               if(objFirstGroup == null) {
                  objFirstGroup = new Group() {
                     Name = textBox1.Text,
                     LeftKey = 1,
                     RightKey = 2,
                     Level = 0
                  };
                  objProvider.Base.Groups.Add(objFirstGroup);
                  objProvider.SaveChanges();
               }
               else {
                  Group objParentNode = objProvider.GetGroupById(iNodeId);
                  //Обновляем ключи существующего дерева, узлы стоящие за родительским узлом:
                  //UPDATE my_tree SET left_key = left_key + 2, right_ key = right_ key + 2 WHERE left_key > $right_ key
                  var objResultList = objProvider.Base.Groups.Where(group => group.LeftKey > objParentNode.RightKey).
                     ToList();

                  foreach(var gr in objResultList) {
                     gr.LeftKey += 2;
                     gr.RightKey += 2;
                  }
                  objProvider.SaveChanges();

                  //Обновляем родительскую ветку:
                  //UPDATE my_tree SET right_key = right_key + 2 WHERE right_key >= $right_key AND left_key < $right_key
                  objResultList = objProvider.Base.Groups.Where(group => group.RightKey >= objParentNode.RightKey && group.LeftKey < objParentNode.RightKey).ToList();
                  foreach(var gr in objResultList) {
                     gr.RightKey += 2;
                  }
                  objProvider.SaveChanges();


                  //Теперь добавляем новый узел :
                  //INSERT INTO my_tree SET left_key = $right_key, right_key = $right_key + 1, level = $level + 1[дополнительные параметры]
                  var objNewNode = new Group() {
                     Name = textBox1.Text,
                     LeftKey = objParentNode.RightKey - 2,
                     RightKey = objParentNode.RightKey - 1,
                     Level = objParentNode.Level + 1
                  };
                  objProvider.AddGroup(objNewNode);
                  objProvider.SaveChanges();
               }
            }
            this.Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}