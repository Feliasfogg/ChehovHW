using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetAdressServer {
   public class Server {
      private Socket _Socket;
      private IPEndPoint _EndPoint;

      public Server(IPEndPoint objEndPoint) {
         _EndPoint = objEndPoint;
      }

      public async void Start() {
         _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
         _Socket.Bind(_EndPoint);
         _Socket.Listen(5);

         await ServerBeginAcceptAsync(_Socket);
      }

      public async Task ServerBeginAcceptAsync(Socket objSocket) {
         while(true) {
            Socket objLocalSocket = objSocket.Accept();
            byte[] btarrMessage = new byte[1024];

            objLocalSocket.Receive(btarrMessage);

            btarrMessage = btarrMessage.Where(b => b != '\0' && b != '\n' && b != '\r').ToArray();
            string strCommand = Encoding.ASCII.GetString(btarrMessage);

            Console.WriteLine(String.Format("{0} : {1}", objLocalSocket.RemoteEndPoint.ToString(), strCommand));

            await ExecuteCommand(strCommand, objLocalSocket);
         }
      }

      public void ServerEndAcceptAsync(Socket objLocalUsedSocket) {
         objLocalUsedSocket.Shutdown(SocketShutdown.Both);
         objLocalUsedSocket.Close();
      }

      public async Task ExecuteCommand(string strCommand, Socket objLocalSocket) {
         Regex objExpression = new Regex("[0-9]");
         if(objExpression.IsMatch(strCommand)) {
            await FindStreets(strCommand, objLocalSocket);
         }
         else {
            switch(strCommand) {
            case "make-screenshot":
               await Task.Factory.StartNew(() => { MakeScreenshot(strCommand, objLocalSocket); });
               break;
            default:
               break;
            }
         }
      }

      public void MakeScreenshot(string strCommand, Socket objLocalSocket) {
         using(Bitmap objBitMap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)) {
            using(Graphics objGraphics = Graphics.FromImage(objBitMap)) {
               objGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                  Screen.PrimaryScreen.Bounds.Y,
                  0, 0,
                  objBitMap.Size,
                  CopyPixelOperation.SourceCopy);

               BinaryFormatter objFormatter = new BinaryFormatter();
               using(MemoryStream objStream = new MemoryStream()) {
                  objFormatter.Serialize(objStream, objBitMap);
                  objLocalSocket.Send(objStream.ToArray());
               }

               ServerEndAcceptAsync(objLocalSocket);
            }
         }
      }

      public async Task FindStreets(string strCommand, Socket objLocalSocket) {
         using(StreetProvider objProvider = new StreetProvider()) {
            List<Street> objStreets = await objProvider.GetStreetByIndexAsync(strCommand);

            byte[] btarrResponse = Encoding.ASCII.GetBytes("NotFound");

            if(objStreets.Count != 0) {
               BinaryFormatter objFormatter = new BinaryFormatter();
               using(MemoryStream objStream = new MemoryStream()) {
                  objFormatter.Serialize(objStream, objStreets);
                  btarrResponse = objStream.ToArray();
               }
            }
            objLocalSocket.Send(btarrResponse);
            //objLocalSocket.BeginSend(btarrResponse, 0, btarrResponse.Length, SocketFlags.None, ServerEndAcceptAsync, objLocalSocket);
            ServerEndAcceptAsync(objLocalSocket);
         }
      }
   }
}