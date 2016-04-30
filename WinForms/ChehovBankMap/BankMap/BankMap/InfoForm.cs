using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankHelper;

namespace BankMap {
   public partial class InfoForm : Form {
      private int iExchangerId;

      public InfoForm(int iExchangerId) {
         InitializeComponent();
         this.iExchangerId = iExchangerId;
      }

      private void button1_Click(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               Bank objBank = objProvider.GetBankByName(((Bank)comboBox1.Items[comboBox1.SelectedIndex]).Name);
               CurrencyExchanger objExchanger = objProvider.GetExchangerById(iExchangerId);

               objExchanger.Bank = objBank;
               objExchanger.Address = textBox4.Text;
               objExchanger.Number = (int)numericUpDown1.Value;
               objExchanger.Phone = textBox3.Text;
               objExchanger.WorkTime = textBox6.Text;
               objExchanger.X = Convert.ToDouble(textBox1.Text);
               objExchanger.Y = Convert.ToDouble(textBox2.Text);
            }
            Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void InfoForm_Load(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               List<Bank> objBanks = objProvider.GetAllBanks();
               comboBox1.Items.AddRange(objBanks.ToArray());

               CurrencyExchanger objExchanger = objProvider.GetExchangerById(iExchangerId);
               comboBox1.SelectedIndex = comboBox1.Items.IndexOf(objExchanger.Bank);
               textBox1.Text = objExchanger.X.ToString();
               textBox2.Text = objExchanger.Y.ToString();
               textBox3.Text = objExchanger.Phone;
               textBox4.Text = objExchanger.Address;
               textBox6.Text = objExchanger.WorkTime;
               textBox5.Text = objExchanger.OpenDate.ToString();
               if(objExchanger.Number != null) {
                  numericUpDown1.Value = (decimal)objExchanger.Number;
               }

               //usd
               label14.Text = objProvider.GetRateByBank("USD", objExchanger.Bank).Buy.ToString();
               label15.Text = objProvider.GetRateByBank("USD", objExchanger.Bank).Sale.ToString();
               //eur
               label16.Text = objProvider.GetRateByBank("EUR", objExchanger.Bank).Buy.ToString();
               label17.Text = objProvider.GetRateByBank("EUR", objExchanger.Bank).Sale.ToString();
               //rur
               label18.Text = objProvider.GetRateByBank("RUR", objExchanger.Bank).Buy.ToString();
               label19.Text = objProvider.GetRateByBank("RUR", objExchanger.Bank).Sale.ToString();
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void button2_Click(object sender, EventArgs e) {
         Close();
      }
   }
}