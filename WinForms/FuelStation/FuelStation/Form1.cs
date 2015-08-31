using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation {
   public partial class Form1 : Form {
      private float fuelPrice;
      private float[] _priceFuelArray = { 11000, 12000, 13000, 14000 };
      private List<MyCheckBox> _MyCheckBoxsList = new List<MyCheckBox>();


      public class MyCheckBox {
         public MyCheckBox(CheckBox checkBox, TextBox textBoxPrice, TextBox textBoxCount, int price) {
            _CheckBox = checkBox;
            _TextBoxPrice = textBoxPrice;

            _TextBoxCount = textBoxCount;
            _TextBoxCount.Text = "0";
            _TextBoxCount.ReadOnly = true;

            iPrice = price;
            _TextBoxPrice.Text = iPrice.ToString();
         }

         public CheckBox _CheckBox;
         public TextBox _TextBoxPrice;
         public TextBox _TextBoxCount;
         public int iPrice;
         public int iCount;
      }

      public Form1() {
         InitializeComponent();
         this.textBoxFuelSumm.ReadOnly = true;
         this.radioButtonFuelCount.Checked = true;
         this.comboBoxFuel.SelectedIndex = 0;

         _MyCheckBoxsList.Add(new MyCheckBox(this.checkBox1, this.textBox1, this.textBox2, 5000));
         _MyCheckBoxsList.Add(new MyCheckBox(this.checkBox2, this.textBox3, this.textBox4, 4000));
         _MyCheckBoxsList.Add(new MyCheckBox(this.checkBox3, this.textBox5, this.textBox6, 6000));
         _MyCheckBoxsList.Add(new MyCheckBox(this.checkBox4, this.textBox7, this.textBox8, 4500));
      }

      private void comboBoxFuel_SelectedIndexChanged(object sender, EventArgs e) {
         this.textBoxFuelPrice.Text = _priceFuelArray[this.comboBoxFuel.SelectedIndex].ToString();
         fuelPrice = _priceFuelArray[this.comboBoxFuel.SelectedIndex];
      }

      private void radioButtonFuelCount_CheckedChanged(object sender, EventArgs e) {
         if(this.textBoxFuelSumm.ReadOnly == false) {
            this.textBoxFuelSumm.ReadOnly = true;
         }
         if(this.textBoxFuelCount.ReadOnly == true) {
            this.textBoxFuelCount.ReadOnly = false;
         }
         this.textBoxFuelSumm.Text = String.Empty;
      }

      private void radioButtonFuelSumm_CheckedChanged(object sender, EventArgs e) {
         if(this.textBoxFuelCount.ReadOnly == false) {
            this.textBoxFuelCount.ReadOnly = true;
         }
         if(this.textBoxFuelSumm.ReadOnly == true) {
            this.textBoxFuelSumm.ReadOnly = false;
         }
         this.textBoxFuelCount.Text = String.Empty;
      }

      private void buttonCountPrice_Click(object sender, EventArgs e) {
         float iPrice = fuelPrice;
         float iCount;
         float iFuelSumm;
         if(float.TryParse(this.textBoxFuelCount.Text, out iCount)) {
            iFuelSumm = iPrice * iCount;
            this.textBoxFuelFinalSumm.Text = iFuelSumm.ToString();
         }
         else {
            if(float.TryParse(this.textBoxFuelSumm.Text, out iFuelSumm)) {
               this.textBoxFuelCount.Text = (iFuelSumm / iPrice).ToString();
               this.textBoxFuelFinalSumm.Text = iFuelSumm.ToString();
            }
         }

         int iCafeSumm = 0;
         foreach(var myCheckBox in _MyCheckBoxsList) {
            if(myCheckBox._CheckBox.Checked == true) {
               int count;
               if(int.TryParse(myCheckBox._TextBoxCount.Text, out count)) {
                  iCafeSumm += count * myCheckBox.iPrice;
               }
            }
         }
         this.textBoxCafeFinalSumm.Text = iCafeSumm.ToString();
         this.textBoxAllFinalPrice.Text = (iCafeSumm + iFuelSumm).ToString();
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e) {
         foreach(var myCheckBox in _MyCheckBoxsList) {
            if(myCheckBox._CheckBox.Checked == true) {
               myCheckBox._TextBoxCount.ReadOnly = false;
            }
            else {
               myCheckBox._TextBoxCount.ReadOnly = true;
               myCheckBox.iCount = 0;
               myCheckBox._TextBoxCount.Text = myCheckBox.iCount.ToString();
            }
         }
      }
   }
}