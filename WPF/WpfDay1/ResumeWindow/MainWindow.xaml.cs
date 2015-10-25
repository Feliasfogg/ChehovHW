using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResumeWindow {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      public MainWindow() {
         InitializeComponent();
      }

      private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
         EmployeeType eEmployeeType = EmployeeType.SysAdm;
         List<Skills> objSkills = new List<Skills>();
         if(RadioButton1.IsChecked == true) {
            eEmployeeType = EmployeeType.SysAdm;
         }
         if(RadioButton2.IsChecked == true) {
            eEmployeeType = EmployeeType.Programmer;
         }
         if(RadioButton3.IsChecked == true) {
            eEmployeeType = EmployeeType.ProductManager;
         }

         if(CheckBox1.IsChecked == true) {
            objSkills.Add(Skills.CSharp);
         }
         if(CheckBox2.IsChecked == true) {
            objSkills.Add(Skills.CPlusPlus);
         }
         if(CheckBox3.IsChecked == true) {
            objSkills.Add(Skills.Linux);
         }

         var objInfo = new ResumeInfo() {
            FirstName = TextBox1.Text,
            LastName = TextBox2.Text,
            BirthDate = TextBox3.Text,
            EmployeeType = eEmployeeType,
            Skills = objSkills
         };


         using(var objWriter = new StreamWriter("list.txt")) {
            objWriter.Write(objInfo.ToString());
         }
      }

      private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
         this.Close();
      }
   }
}