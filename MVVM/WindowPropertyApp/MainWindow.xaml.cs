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

namespace WindowPropertyApp
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      public int Number
      {
         get { return (int)GetValue(NumberProperty); }
         set { SetValue(NumberProperty, value); }
      }

      public static readonly DependencyProperty NumberProperty =
          DependencyProperty.Register("Number", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
   }
}
