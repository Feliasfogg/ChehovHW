using System;
using System.Collections.Generic;
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

namespace Exam3
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         TextBoxProperty = "SampleText1";
      }


      public string TextBoxProperty
      {
         get { return (string)GetValue(TextBoxPropertyProperty); }
         set { SetValue(TextBoxPropertyProperty, value); }
      }

      // Using a DependencyProperty as the backing store for TextBoxProperty.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty TextBoxPropertyProperty =
          DependencyProperty.Register("TextBoxProperty", typeof(string), typeof(MainWindow), new PropertyMetadata("SampleText"));


   }
}
