using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
using StreetAdressServer;

namespace StreetAdress {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      private Socket _Socket;

      public MainWindow() {
         InitializeComponent();
      }

      private bool TryConnect() {
         _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
         _Socket.Connect(IPAddress.Parse("127.0.0.1"), 88);
         if (_Socket.Connected) {
            return true;
         }
         else {
            return false;
         }
      }

      private async Task ProcessingImage(byte[] btarrResponse) {
         Bitmap objBitMap;
         BinaryFormatter objFormatter = new BinaryFormatter();
         using(MemoryStream objStream = new MemoryStream()) {
            await objStream.WriteAsync(btarrResponse, 0, btarrResponse.Length);
            objStream.Position = 0;
            objBitMap = (Bitmap)objFormatter.Deserialize(objStream);
            objBitMap.Save(@"D:\screenshot.jpg");
         }
      }

      private async Task ProcessingStreets(byte[] btarrResponse) {
         BinaryFormatter objFormatter = new BinaryFormatter();
         using(MemoryStream objStream = new MemoryStream()) {
            await objStream.WriteAsync(btarrResponse, 0, btarrResponse.Length);
            objStream.Position = 0;

            List<Street> objStreets = (List<Street>)objFormatter.Deserialize(objStream);
            ShowStreets(objStreets);
         }
      }

      private async Task<DataHeader> GetDataHeader(byte[] btarrHeader) {
         BinaryFormatter objFormatter = new BinaryFormatter();
         DataHeader objHeader;
         using(MemoryStream objStream = new MemoryStream()) {
            await objStream.WriteAsync(btarrHeader, 0, btarrHeader.Length);
            objStream.Position = 0;
            objHeader = (DataHeader)objFormatter.Deserialize(objStream);
         }
         return objHeader;
      }

      private void ShowStreets(List<Street> objStreets) {
         listBox1.Items.Clear();
         foreach(Street street in objStreets) {
            listBox1.Items.Add(new ListBoxItem() {
               Content = String.Format("{0} {1}", street.Adress, street.Index)
            });
         }
      }

      private async void Button_Click(object sender, RoutedEventArgs e) {
         try {
            string strCommand = textBox1.Text;
            if(TryConnect()) {
               byte[] buffer = new byte[1024];
               _Socket.Send(Encoding.ASCII.GetBytes(strCommand));
               _Socket.Receive(buffer);

               await ProcessingStreets(buffer);
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private async void Button_Click_1(object sender, RoutedEventArgs e) {
         try {
            byte[] btarrCommand = Encoding.ASCII.GetBytes("make-screenshot");
            if(TryConnect()) {
               byte[] buffer = new byte[500000];
               _Socket.Send(btarrCommand);
               _Socket.Receive(buffer);

               await ProcessingImage(buffer);
               MessageBox.Show(@"Screenshot saved on D:\");
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}