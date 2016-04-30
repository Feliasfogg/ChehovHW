using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Threads {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      public int iThreadsCounter = 1;
      private Semaphore objSemaphore = null;

      public MainWindow() {
         InitializeComponent();
      }

      private void Button_Click(object sender, RoutedEventArgs e) {
         var objCustomThread = new CustomThread(Operation);
         listBox3.Items.Add(new ListBoxItem() {
            Tag = objCustomThread,
            Content = $"Thread {objCustomThread.CurrentNumber}--> created"
         });
      }

      private void Operation(object arg) {
         CustomThread objCustomThread = arg as CustomThread;

         int iCount = 0;
         
         if(!Semaphore.TryOpenExisting("MY_SEMAPHORE", out objSemaphore)) {
            objSemaphore = new Semaphore(iThreadsCounter, iThreadsCounter, "MY_SEMAPHORE");
         }

         ListBoxItem objListBoxItem = null;
         try {
            objSemaphore.WaitOne();

            Dispatcher.BeginInvoke(new ThreadStart(() => {
               foreach(ListBoxItem item in listBox2.Items) {
                  if((item.Tag as CustomThread) == objCustomThread) {
                     listBox2.Items.Remove(item);
                     break;
                  }
               }

               objListBoxItem = new ListBoxItem() {
                  Content = String.Format("Thread {0}--> {1}", objCustomThread.CurrentNumber, iCount),
                  Tag = objCustomThread
               };
               listBox1.Items.Add(objListBoxItem);
            }));

            while(iCount < 100) {
               ++iCount;
               Thread.Sleep(100);
               Dispatcher.BeginInvoke(new ThreadStart(() => { objListBoxItem.Content = String.Format("Thread {0}--> {1}", objCustomThread.CurrentNumber, iCount); }));
            }
            Dispatcher.BeginInvoke(new ThreadStart(() => { listBox1.Items.Remove(objListBoxItem); }));
         }
         finally {
            objSemaphore.Release();
         }
      }

      private void listBox3_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
         ListBoxItem objItem = listBox3.SelectedItem as ListBoxItem;

         if(listBox1.Items.Count >= iThreadsCounter) {
            listBox2.Items.Add(new ListBoxItem() {
               Content = String.Format("Thread {0} -->await", (objItem.Tag as CustomThread).CurrentNumber),
               Tag = objItem.Tag
            });
         }

         (objItem.Tag as CustomThread).Start();
         listBox3.Items.Remove(objItem);
      }

      private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<decimal> e) {
         iThreadsCounter = Convert.ToInt32(numericUpDown.Value);
      }

      private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
         ListBoxItem objItem = listBox1.SelectedItem as ListBoxItem;
         (objItem.Tag as CustomThread).Abort();
         listBox1.Items.Remove(objItem);
      }
   }
}