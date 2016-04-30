using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TotalCommander {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      private List<Disk> _AllDisks = new List<Disk>();

      public MainWindow() {
         InitializeComponent();

         InitialiseDisks();
      }

      public void InitialiseDisks() {
         DriveInfo[] objDrives = DriveInfo.GetDrives();
         foreach(DriveInfo disk in objDrives) {
            _AllDisks.Add(new Disk() {
               Name = disk.Name,
               CurrentDirectory = disk.RootDirectory.FullName,
               DriveInfo = disk
            });

            menuLeft.Items.Add(new MenuItem() { Header = disk.Name, Command = MediaCommands.Select });
            menuRight.Items.Add(new MenuItem() { Header = disk.Name, Command = MediaCommands.Select });
         }
      }

      public void ShowEntries(Disk objDisk, ListBox objCurrentListBox) {
         try {
            objCurrentListBox.Items.Clear();
            if(objCurrentListBox != null) {
               foreach(string strFileSystemEntry in Directory.GetFileSystemEntries(objDisk.CurrentDirectory)) {
                  objCurrentListBox.Items.Add(strFileSystemEntry);
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      //здесь мы определяем в какой панели нам выводить выранный диск
      private void Select_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
         Disk objDisk;
         Menu objCurrentMenu = (Menu)sender;
         MenuItem objSelectedDisk = (MenuItem)e.Source;

         objDisk = _AllDisks.SingleOrDefault(d => d.Name == objSelectedDisk.Header);
         if(objDisk != null) {
            objDisk.CurrentDirectory = objSelectedDisk.Header.ToString();

            switch(objCurrentMenu.Tag.ToString()) {
            case "L": {
               ShowEntries(objDisk, listBoxL);
               break;
            }
            case "R": {
               ShowEntries(objDisk, listBoxR);
               break;
            }
            }
         }
      }

      private async void ListBoxes_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
         string strElementName = ((ListBox)sender).SelectedItem.ToString();
         Disk objDisk;

         FileInfo objFile = new FileInfo(strElementName);
         DirectoryInfo objDirectory = new DirectoryInfo(strElementName);

         if(objFile.Exists) {
            await Task.Factory.StartNew(() => { Process.Start(objFile.FullName); });
         }
         else if(objDirectory.Exists) {
            objDisk = _AllDisks.SingleOrDefault(d => d.Name == objDirectory.Root.Name);

            if(objDisk != null) {
               objDisk.CurrentDirectory = strElementName;
               ShowEntries(objDisk, (ListBox)sender);
            }
         }
      }
   }
}