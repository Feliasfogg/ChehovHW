using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BankHelper;

namespace BankMap {
   public partial class AddExchangerForm : Form {
      public AddExchangerForm(double dX, double dY) {
         InitializeComponent();

         using(var objProvider = new BankProvider()) {
            List<Bank> objBanks = objProvider.GetAllBanks();
            foreach(var bank in objBanks) {
               comboBox1.Items.Add(bank);
            }
         }
         comboBox1.SelectedIndex = 0;

         textBox1.Text = dX.ToString();
         textBox2.Text = dY.ToString();
      }

      private void button1_Click(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               Bank objBank = objProvider.GetBankByName(((Bank)comboBox1.Items[comboBox1.SelectedIndex]).Name);

               var objExchanger = new CurrencyExchanger() {
                  Number = (int)numericUpDown1.Value,
                  Bank = objBank,
                  X = Convert.ToDouble(textBox1.Text),
                  Y = Convert.ToDouble(textBox2.Text),
                  Phone = textBox3.Text,
                  Address = textBox4.Text,
                  OpenDate = monthCalendar1.SelectionStart.Date,
                  WorkTime = textBox6.Text
               };
               objProvider.AddExchanger(objExchanger);
            }
            Close();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}