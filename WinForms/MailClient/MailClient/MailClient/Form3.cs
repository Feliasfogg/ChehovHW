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
   public partial class Form3 : Form {
      private int iNodeId;

      public Form3(int iNodeId) {
         InitializeComponent();
         this.iNodeId = iNodeId;
      }

      private void button1_Click(object sender, EventArgs e) {
         if(textBox1.Text == String.Empty) {
            MessageBox.Show("Please, fill all fields");
            return;
         }

         try {
            var objFirstGroup = Form1.objModel.Groups.OrderBy(c => c.Id).FirstOrDefault();

            //if no one nodes in base
            if(objFirstGroup == null) {
               objFirstGroup = new Group() {
                  Name = textBox1.Text,
                  LeftKey = 1,
                  RightKey = 2,
                  Level = 0
               };
               Form1.objModel.Groups.Add(objFirstGroup);
               Form1.objModel.SaveChanges();
            }
            else {
               var objParentNode = Form1.objModel.Groups.Where(gr => gr.Id == iNodeId).Single();
               //Обновляем ключи существующего дерева, узлы стоящие за родительским узлом:
               //UPDATE my_tree SET left_key = left_key + 2, right_ key = right_ key + 2 WHERE left_key > $right_ key
               var objResultList = Form1.objModel.Groups.Where(group => group.LeftKey > objParentNode.RightKey).
                  ToList();

               foreach(var gr in objResultList) {
                  gr.LeftKey += 2;
                  gr.RightKey += 2;
               }
               Form1.objModel.SaveChanges();

               //Обновляем родительскую ветку:
               //UPDATE my_tree SET right_key = right_key + 2 WHERE right_key >= $right_key AND left_key < $right_key
               objResultList = Form1.objModel.Groups.Where(group => group.RightKey >= objParentNode.RightKey && group.LeftKey < objParentNode.RightKey).ToList();
               foreach(var gr in objResultList) {
                  gr.RightKey += 2;
               }
               Form1.objModel.SaveChanges();

               //Теперь добавляем новый узел :
               //INSERT INTO my_tree SET left_key = $right_key, right_key = $right_key + 1, level = $level + 1[дополнительные параметры]
               var objNewNode = new Group() {
                  Name = textBox1.Text,
                  LeftKey = objParentNode.RightKey - 2,
                  RightKey = objParentNode.RightKey - 1,
                  Level = objParentNode.Level + 1
               };
               Form1.objModel.Groups.Add(objNewNode);
               Form1.objModel.SaveChanges();
            }
            this.Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}