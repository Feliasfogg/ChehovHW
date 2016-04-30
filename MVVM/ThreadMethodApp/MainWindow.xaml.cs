using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadMethodApp
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

      public event EventHandler PlusOne;
      public void CountToNumber(object sender, EventArgs args) {
         long lNumber = 200;
         Thread someThread = new Thread(Start);
         someThread.Start(lNumber);
      }

      private void Start(object o)
      {
         long lDelimeter = (long)o;
         long lCount = 0;
         PlusOne += ShowChanges;
         while (lCount < lDelimeter)
         {
            lCount++;
            Thread.Sleep(10);
            PlusOne(lCount, EventArgs.Empty);
         }
      }

      void ShowChanges(object sender, EventArgs e)
      {
         Dispatcher.Invoke(() =>
         {
            ResultLabel.Content = ((long)sender).ToString();
         });
      }
   }
}
