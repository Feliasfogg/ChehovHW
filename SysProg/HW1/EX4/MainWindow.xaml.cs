using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace EX4 {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      private ProcessManager _Manager = new ProcessManager();
      private List<Process> _Processes;

      public MainWindow() {
         InitializeComponent();
         _Processes = _Manager.Processes;

         BuildTree();
      }

      private async void BuildTree() {
         textBlock.Text = "LOADING INFO ABOUT PROCESSES";
         await BuildTreeViewAsync();
         textBlock.Text = "COMPLETED";
      }

      private Task BuildTreeViewAsync() {
         return Task.Factory.StartNew(() => {
            try {
               for(int i = 0; i < _Processes.Count; ++i) {
                  BuildTreeView(_Processes[i], null);
               }
            }
            catch(Exception ex) {
               MessageBox.Show(ex.Message);
            }
         });
      }

      private void BuildTreeView(Process proc, TreeViewItem objParentItem) {
         try {
            if(objParentItem != null) {
               this.Dispatcher.BeginInvoke(new ThreadStart(() => {
                  List<Process> childs = _Manager.GetChildrens(proc);

                  TreeViewItem objTreeViewItem = new TreeViewItem();
                  objTreeViewItem.Tag = proc.Id;
                  objTreeViewItem.Header = proc.ProcessName;


                  objParentItem.Items.Add(objTreeViewItem);

                  if(childs.Count != 0) {
                     childs.ForEach(process => { BuildTreeView(process, objTreeViewItem); });
                  }
               }));
            }
            else {
               this.Dispatcher.BeginInvoke(new ThreadStart(() => {
                  List<Process> childs = _Manager.GetChildrens(proc);

                  TreeViewItem objTreeViewItem = new TreeViewItem();
                  objTreeViewItem.Tag = proc.Id;
                  objTreeViewItem.Header = proc.ProcessName;

                  treeView.Items.Add(objTreeViewItem);

                  //if(childs.Count != 0) {
                  //   childs.ForEach(process => { BuildTreeView(process, objTreeViewItem); });
                  //}
               }));
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
         Process objProcess = Process.GetProcessById(Convert.ToInt32((treeView.SelectedItem as TreeViewItem).Tag));

         string strOutput = String.Format("Name: {0}\nPID: {1}\n", objProcess.ProcessName, objProcess.Id);
         textBlock.Text = strOutput;
      }
   }
}