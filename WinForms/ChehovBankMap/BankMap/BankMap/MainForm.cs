using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Windows.Forms;
using System.Xml;
using BankHelper;

namespace BankMap {
   public partial class MainForm : Form {
      public MainForm() {
         InitializeComponent();
      }

      private void googleMapToolStripMenuItem_Click_1(object sender, EventArgs e) {
         var objGmapForm = new GmapForm();
         objGmapForm.MdiParent = this;
         objGmapForm.Show();
      }

      private async void MainForm_Load(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               var objLoadingForm = new LoadingForm();
               objLoadingForm.MdiParent = this;
               objLoadingForm.Show();

               await objProvider.LoadCurrencyRateInfo();
               objLoadingForm.Close();
            }
            var objGmapForm = new GmapForm();
            objGmapForm.MdiParent = this;
            googleMapToolStripMenuItem.Enabled = true;
            loadGoogleMapToolStripMenuItem.Enabled = true;
            objGmapForm.Show();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void loadGoogleMapToolStripMenuItem_Click(object sender, EventArgs e) {
         try {
            LoadExchangersPositionInfo();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void LoadExchangersPositionInfo() {
         //gets data from GoogleMaps API, but I can use only geodata(GPS), without details about object
         //method gets first 20 objects
         const string API_KEY = "AIzaSyDX98l2EABQiA28ogGNFHSjVlGfVF7DdlY";
         string strUri = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=банк+минск&language=rus&key=" + API_KEY;


         var objRequest = HttpWebRequest.CreateHttp(strUri);
         objRequest.Method = "GET";
         objRequest.ContentType = new ContentType("application/json").ToString();
         HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
         XmlDocument objXml = new XmlDocument();

         using(Stream objResponseStream = objResponse.GetResponseStream()) {
            using(var objReader = new StreamReader(objResponseStream)) {
               string strResponse = objReader.ReadToEnd();
               objXml.LoadXml(strResponse);

               XmlNodeList objNodes = objXml.GetElementsByTagName("result");
               using(var objProvider = new BankProvider()) {
                  var objBank = objProvider.GetBankByName("Альфа-Банк");
                  foreach(XmlNode node in objNodes) {
                     double dX = Convert.ToDouble(node["geometry"]["location"]["lat"].InnerText);
                     double dY = Convert.ToDouble(node["geometry"]["location"]["lng"].InnerText);
                     string strPlaceId = node["place_id"].InnerText;
                     //if bank office with current GooglePlaceId exists in base - break
                     if(objProvider.GetExchangerByPlaceId(strPlaceId) != null) break; 

                     var objExchanger = new CurrencyExchanger() {
                        Bank = objBank,
                        X = dX,
                        Y = dY,
                        GMapId = strPlaceId
                     };
                     objProvider.AddExchanger(objExchanger);
                  }
               }
            }
         }
      }
   }
}