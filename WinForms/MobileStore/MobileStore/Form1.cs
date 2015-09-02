using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileStore {
   public partial class Form1 : Form {
      public Form1() {
         InitializeComponent();
         _PhoneList = new List<Phone>();
         _OptionsList = new List<string>();
         comboBox1.SelectedIndex = 0;
      }

      private void ShowPhones() {
         listBox1.Items.Clear();
         foreach(var phone in _PhoneList) {
            listBox1.Items.Add(phone.ToString());
         }
      }

      private void ShowOptions() {
         checkedListBox1.Items.Clear();
         foreach(var item in _OptionsList) {
            checkedListBox1.Items.Add(item);
         }
      }

      private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
         try {
            if(listBox1.SelectedIndex < 0) {
               return;
            }
            var phone = _PhoneList[listBox1.SelectedIndex];
            //information form
            textBox1.Text = phone.Model;
            textBox2.Text = phone.Os;
            textBox3.Text = phone.Cpu;
            textBox4.Text = phone.Price.ToString();

            if(phone.ImagePath != null) {
               var imageInfo = new FileInfo(phone.ImagePath);
               if(imageInfo.Exists) {
                  pictureBox1.BackgroundImage = Image.FromFile(phone.ImagePath);
               }
               else {
                  pictureBox1.BackgroundImage = pictureBox1.ErrorImage;
               }
            }
            else {
               pictureBox1.BackgroundImage = pictureBox1.ErrorImage;
            }

            //properties form
            textBox8.Text = phone.Model;
            comboBox1.Text = phone.Os;
            textBox6.Text = phone.Cpu;
            textBox5.Text = phone.Price.ToString();
            textBox10.Text = phone.ImagePath;
            if(phone.OptionsList == null) {
               ShowOptions();
               return;
            }

            ShowOptions();
            listBox2.Items.Clear();
            foreach(var str in phone.OptionsList) {
               if(!_OptionsList.Contains(str)) {
                  _OptionsList.Add(str);
                  ShowOptions();
               }
               if(checkedListBox1.Items.IndexOf(str) != -1) {
                  checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(str), true);
                  listBox2.Items.Add(str);
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void button6_Click(object sender, EventArgs e) {
         if(!String.IsNullOrEmpty(textBox9.Text)) {
            if(!_OptionsList.Contains(textBox9.Text)) {
               _OptionsList.Add(textBox9.Text);
            }
            checkedListBox1.Items.Add(textBox9.Text);
            textBox9.Clear();
         }
         else {
            MessageBox.Show("Введите опцию для добавления");
         }
      }

      private void button5_Click(object sender, EventArgs e) {
         try {
            var phone = new Phone();

            if(!String.IsNullOrEmpty(textBox8.Text)) {
               phone.Model = textBox8.Text;
            }
            else {
               MessageBox.Show("Введите модель телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            if(!String.IsNullOrEmpty(comboBox1.Text)) {
               phone.Os = comboBox1.Text;
            }
            else {
               MessageBox.Show("Введите ОС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            if(!String.IsNullOrEmpty(textBox6.Text)) {
               phone.Cpu = textBox6.Text;
            }
            else {
               MessageBox.Show("Введите модель процессора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            if(!String.IsNullOrEmpty(textBox5.Text)) {
               int price;
               if(Int32.TryParse(textBox5.Text, out price)) {
                  phone.Price = price;
               }
               else {
                  MessageBox.Show("Неверный формат цены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
               }
            }
            else {
               MessageBox.Show("Введите цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            if(!String.IsNullOrEmpty(textBox10.Text)) {
               phone.ImagePath = textBox10.Text;
            }
            else {
               MessageBox.Show("Не задана картинка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            foreach(var item in checkedListBox1.CheckedItems) {
               phone.OptionsList.Add(item.ToString());
            }

            if(listBox1.SelectedIndex != -1) {
               _PhoneList[listBox1.SelectedIndex] = phone;
               MessageBox.Show("Информация успешно изменена");
            }
            else {
               _PhoneList.Add(phone);
               listBox1.SelectedIndex = listBox1.Items.Count - 1;
               MessageBox.Show("Телефон успешно добавлен");
            }
            ShowPhones();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void button9_Click(object sender, EventArgs e) {
         button5_Click(sender, e);
      }

      private void button8_Click(object sender, EventArgs e) {
         listBox1.SelectedIndex = -1;
         textBox8.Clear();
         textBox6.Clear();
         textBox10.Clear();
         textBox5.Clear();
         for(int i = 0; i < checkedListBox1.Items.Count; ++i) {
            checkedListBox1.SetItemChecked(i, false);
         }
      }

      private void button3_Click(object sender, EventArgs e) {
         try {
            if(listBox1.Items.Count == 0) {
               MessageBox.Show("Нечего сохранять", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            //write phones db
            using(FileStream fs = new FileStream("phones.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)) {
               try {
                  var bf = new BinaryFormatter();
                  bf.Serialize(fs, _PhoneList);
               }
               catch(Exception ex) {
                  MessageBox.Show(ex.Message);
               }
            }
            //write options db
            using(FileStream fs = new FileStream("options.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)) {
               try {
                  var bf = new BinaryFormatter();
                  bf.Serialize(fs, _OptionsList);
                  MessageBox.Show("Файл сохранен");
               }
               catch(Exception ex) {
                  MessageBox.Show(ex.Message);
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void button4_Click(object sender, EventArgs e) {
         //read phones database
         using(FileStream fs = new FileStream("phones.bin", FileMode.Open, FileAccess.Read, FileShare.Read)) {
            try {
               var bf = new BinaryFormatter();
               _PhoneList = (List<Phone>)bf.Deserialize(fs);
               ShowPhones();
            }
            catch(Exception ex) {
               MessageBox.Show(ex.Message);
            }
         }
         //read options database
         using(FileStream fs = new FileStream("options.bin", FileMode.Open, FileAccess.Read, FileShare.Read)) {
            try {
               var bf = new BinaryFormatter();
               _OptionsList = (List<string>)bf.Deserialize(fs);
               ShowOptions();
            }
            catch(Exception ex) {
               MessageBox.Show(ex.Message);
            }
         }
      }

      private void button2_Click(object sender, EventArgs e) {
         _PhoneList.Clear();
         ShowPhones();
         MessageBox.Show("Список очищен");
      }

      private void button1_Click(object sender, EventArgs e) {
         if(listBox1.SelectedIndex != -1) {
            _PhoneList.RemoveAt(listBox1.SelectedIndex);
            ShowPhones();
         }
      }

      private void button7_Click(object sender, EventArgs e) {
         if(checkedListBox1.SelectedIndex != -1) {
            _OptionsList.RemoveAt(checkedListBox1.SelectedIndex);
            checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
         }
      }

      private void button10_Click(object sender, EventArgs e) {
         try {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"../";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
               textBox10.Text = openFileDialog1.FileName;
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }
   }
}