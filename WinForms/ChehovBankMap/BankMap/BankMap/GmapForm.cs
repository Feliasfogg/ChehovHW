using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BankHelper;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace BankMap {
   public partial class GmapForm : Form {
      private GMapOverlay objMarkersOverlay;

      public GmapForm() {
         InitializeComponent();
         objMarkersOverlay = new GMapOverlay();
      }

      private void Form2_Load(object sender, EventArgs e) {
         comboBox1.SelectedIndex = 0;
         //Пример честно скопипащен
         //Настройки для компонента GMap.
         gMapControl1.Bearing = 0;
         gMapControl1.Dock = DockStyle.Fill;

         //Указываем что перетаскивание карты осуществляется 
         //с использованием левой клавишей мыши.
         //По умолчанию - правая.
         gMapControl1.DragButton = MouseButtons.Left;

         //Указываем, что будем использовать карты Google.
         gMapControl1.MapProvider = GMapProviders.GoogleMap;
         //указываем источник данных - только интернет
         GMaps.Instance.Mode = AccessMode.ServerOnly;

         //Указываем элементу управления,
         //что необходимо при открытии карты прейти
         //к Площади победы в Минске
         gMapControl1.Position = new PointLatLng(53.9085385, 27.5744717);
         
         //fill best Buy and Sell rates
         using(var objProvider = new BankProvider()) {
            List<Bank> objBanks = objProvider.GetAllBanks();
            comboBox2.SelectedIndex = 0;
            comboBox2.Items.AddRange(objBanks.ToArray());


            //best buy rate
            label7.Text = objProvider.GetBestBuyRate("USD").Buy.ToString();
            label18.Text = objProvider.GetBestBuyRate("USD").Bank.ToString();
            label8.Text = objProvider.GetBestBuyRate("EUR").Buy.ToString();
            label17.Text = objProvider.GetBestBuyRate("EUR").Bank.ToString();
            label9.Text = objProvider.GetBestBuyRate("RUR").Buy.ToString();
            label16.Text = objProvider.GetBestBuyRate("RUR").Bank.ToString();

            //best sell rate
            label6.Text = objProvider.GetBestSellRate("USD").Sale.ToString();
            label20.Text = objProvider.GetBestSellRate("USD").Bank.ToString();
            label14.Text = objProvider.GetBestSellRate("EUR").Sale.ToString();
            label15.Text = objProvider.GetBestSellRate("EUR").Bank.ToString();
            label19.Text = objProvider.GetBestSellRate("RUR").Sale.ToString();
            label10.Text = objProvider.GetBestSellRate("RUR").Bank.ToString();
         }

         DrawMarkers();
      }

      /// <summary>
      /// show info form about exchanger
      /// </summary>
      /// <param name="item"></param>
      /// <param name="mouseEventArgs"></param>
      private void GMapControl1OnOnMarkerClick(GMapMarker item, MouseEventArgs mouseEventArgs) {
         try {
            if(item.Tag == null) {
               throw new ArgumentNullException("CurrencyExchanger.Id is null");
            }
            //костыль, когда я подсвечиваю маркер синим в findNearestToolStripMenuItem_Click, 
            //я по сути не меняю цвет маркера(ненашел как, маразм честно говоря иметь возможность поставить маркер но неиметь возхможности изменить цвет)
            //а доабвляю новый слой с маркером поверх старого,
            //потому при нажатии на него выскакивло две формочки INFO, и был поставлен костыль, который проверяет не входит ли синий маркер в 
            //первый массив маркеров, а он не входит.
            if(!objMarkersOverlay.Markers.Contains(item)) return;


            var objInfoForm = new InfoForm((int)item.Tag);
            objInfoForm.ShowDialog();

            UpdateMarkers();
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Select MapProvider
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
         switch(comboBox1.SelectedIndex) {
         case 0:
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            break;
         case 1:
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            break;
         default:
            break;
         }
      }

      /// <summary>
      /// filter exchangers by bank
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
         try {
            DrawMarkers();
            using(var objProvider = new BankProvider()) {
               Bank objBank = objProvider.GetBankByName(comboBox2.SelectedItem.ToString());
               if(objBank == null) {
                  DrawMarkers();
               }
               else {
                  for(int iI = 0; iI < objMarkersOverlay.Markers.Count; ++iI) {
                     var exchanger = objProvider.GetExchangerById((int)objMarkersOverlay.Markers[iI].Tag);
                     if(exchanger.Bank.Id != objBank.Id) {
                        objMarkersOverlay.Markers.RemoveAt(iI);
                        --iI;
                     }
                  }
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void addExchangerToolStripMenuItem_Click(object sender, EventArgs e) {
         PointLatLng objPoint = GetCursorPosition();
         var objAddExhangerForm = new AddExchangerForm(objPoint.Lat, objPoint.Lng);
         objAddExhangerForm.ShowDialog();

         DrawMarkers();
      }

      /// <summary>
      /// find nearest exhanger from current mouse position
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void findNearestToolStripMenuItem_Click(object sender, EventArgs e) {
         PointLatLng objPosition = GetCursorPosition();
         using(var objProvider = new BankProvider()) {
            List<CurrencyExchanger> objExchangers = new List<CurrencyExchanger>();
            foreach (var marker in objMarkersOverlay.Markers) {
               CurrencyExchanger exchanger = objProvider.GetExchangerById((int)marker.Tag);
               if (exchanger != null) {
                  objExchangers.Add(exchanger);
               }
            }
            CurrencyExchanger objNearestExchanger = objProvider.GetNearestExchanger(objPosition.Lat, objPosition.Lng, objExchangers);

            var objMarker = new GMarkerGoogle(new PointLatLng(objNearestExchanger.X, objNearestExchanger.Y), GMarkerGoogleType.blue);
            objMarker.Tag = objNearestExchanger.Id;
            gMapControl1.UpdateMarkerLocalPosition(objMarker);
            var markersOverlay = new GMapOverlay();
            markersOverlay.Markers.Add(objMarker);
            gMapControl1.Overlays.Add(markersOverlay);
         }
      }

      /// <summary>
      /// Show exchangers with best buy price
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void radioButton1_CheckedChanged(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               List<ExchangeRate> objBestBuyRates = new List<ExchangeRate>();
               objBestBuyRates.Add(objProvider.GetBestBuyRate("USD"));
               objBestBuyRates.Add(objProvider.GetBestBuyRate("EUR"));
               objBestBuyRates.Add(objProvider.GetBestBuyRate("RUR"));

               List<CurrencyExchanger> objExchangers = new List<CurrencyExchanger>();
               foreach(var rate in objBestBuyRates) {
                  objExchangers.AddRange(objProvider.DataBase.CurrencyExchangers.Where(ce => ce.Bank.Id == rate.Bank.Id).ToArray());
               }
               objMarkersOverlay = new GMapOverlay();

               foreach(var exchanger in objExchangers) {
                  var objMarker = new GMarkerGoogle(new PointLatLng(exchanger.X, exchanger.Y), GMarkerGoogleType.green) {
                     Tag = exchanger.Id,
                     ToolTipText = String.Format("{0} office:{1}\nBuy\nUSD {2}\nEUR {3}\nRUR {4}",
                        exchanger.Bank.Name,
                        exchanger.Number,
                        objBestBuyRates[0].Buy,
                        objBestBuyRates[1].Buy,
                        objBestBuyRates[2].Buy
                        )
                  };
                  gMapControl1.UpdateMarkerLocalPosition(objMarker);
                  objMarkersOverlay.Markers.Add(objMarker);
               }
               gMapControl1.Overlays.Clear();
               gMapControl1.Overlays.Add(objMarkersOverlay);
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// Show exchangers with best sell price
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void radioButton2_CheckedChanged(object sender, EventArgs e) {
         try {
            using(var objProvider = new BankProvider()) {
               List<ExchangeRate> objBestSellRates = new List<ExchangeRate>();
               objBestSellRates.Add(objProvider.GetBestSellRate("USD"));
               objBestSellRates.Add(objProvider.GetBestSellRate("EUR"));
               objBestSellRates.Add(objProvider.GetBestSellRate("RUR"));

               List<CurrencyExchanger> objExchangers = new List<CurrencyExchanger>();
               foreach(var rate in objBestSellRates) {
                  objExchangers.AddRange(objProvider.DataBase.CurrencyExchangers.Where(ce => ce.Bank.Id == rate.Bank.Id).ToArray());
               }

               objMarkersOverlay = new GMapOverlay();

               foreach(var exchanger in objExchangers) {
                  var objMarker = new GMarkerGoogle(new PointLatLng(exchanger.X, exchanger.Y), GMarkerGoogleType.green) {
                     Tag = exchanger.Id,
                     ToolTipText = String.Format("{0} office:{1}\nBuy\nUSD {2}\nEUR {3}\nRUR {4}",
                        exchanger.Bank.Name,
                        exchanger.Number,
                        objBestSellRates[0].Buy,
                        objBestSellRates[1].Buy,
                        objBestSellRates[2].Buy
                        )
                  };
                  gMapControl1.UpdateMarkerLocalPosition(objMarker);
                  objMarkersOverlay.Markers.Add(objMarker);
               }
               gMapControl1.Overlays.Clear();
               gMapControl1.Overlays.Add(objMarkersOverlay);
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void radioButton3_CheckedChanged(object sender, EventArgs e) {
         DrawMarkers();
      }

      /// <summary>
      /// get current cursor position
      /// </summary>
      /// <returns></returns>
      private PointLatLng GetCursorPosition() {
         int iX = contextMenuStrip1.Location.X - this.Left - 80;
         int iY = contextMenuStrip1.Location.Y - this.Top - 80;
         double dX = gMapControl1.FromLocalToLatLng(iX, iY).Lat;
         double dY = gMapControl1.FromLocalToLatLng(iX, iY).Lng;

         return new PointLatLng(dX, dY);
      }

      /// <summary>
      /// update marker info
      /// </summary>
      private void UpdateMarkers() {
         try {
            using(var objProvider = new BankProvider()) {
               foreach(var marker in objMarkersOverlay.Markers) {
                  CurrencyExchanger objExchanger = objProvider.GetExchangerById((int)marker.Tag);

                  ExchangeRate objUsd = objProvider.GetRateByBank("USD", objExchanger.Bank);
                  ExchangeRate objEur = objProvider.GetRateByBank("EUR", objExchanger.Bank);
                  ExchangeRate objRur = objProvider.GetRateByBank("RUR", objExchanger.Bank);

                  marker.ToolTipText = String.Format(
                     "{0} office:{1}\nBuy\n" +
                        "USD:{2}\nEUR:{3}\nRUR:{4}\n" +
                        "Sell\n" +
                        "USD:{5}\nEUR:{6}\nRUR:{7}",
                     objExchanger.Bank.Name,
                     objExchanger.Number,
                     objUsd.Buy,
                     objEur.Buy,
                     objRur.Buy,
                     objUsd.Sale,
                     objEur.Sale,
                     objRur.Sale
                     );

                  var objPositon = new PointLatLng(objExchanger.X, objExchanger.Y);
                  if(marker.Position != objPositon) {
                     marker.Position = objPositon;
                  }
                  gMapControl1.UpdateMarkerLocalPosition(marker);
               }
            }
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      /// <summary>
      /// draw all CurrencyExchangers markers on map
      /// </summary>
      private void DrawMarkers() {
         try {
            using(var objProvider = new BankProvider()) {
               objMarkersOverlay.Clear();
               List<CurrencyExchanger> objExchangers = objProvider.GetAllExchangers();

               foreach(var exchanger in objExchangers) {
                  ExchangeRate objUsd = objProvider.GetRateByBank("USD", exchanger.Bank);
                  ExchangeRate objEur = objProvider.GetRateByBank("EUR", exchanger.Bank);
                  ExchangeRate objRur = objProvider.GetRateByBank("RUR", exchanger.Bank);

                  var objMarker = new GMarkerGoogle(new PointLatLng(exchanger.X, exchanger.Y), GMarkerGoogleType.yellow) {
                     ToolTipText = String.Format(
                        "{0} office:{1}\nBuy\n" +
                           "USD:{2}\nEUR:{3}\nRUR:{4}\n" +
                           "Sell\n" +
                           "USD:{5}\nEUR:{6}\nRUR:{7}",
                        exchanger.Bank.Name,
                        exchanger.Number,
                        objUsd.Buy,
                        objEur.Buy,
                        objRur.Buy,
                        objUsd.Sale,
                        objEur.Sale,
                        objRur.Sale
                        ),
                     Tag = exchanger.Id
                  };

                  objMarkersOverlay.Markers.Add(objMarker);
                  gMapControl1.UpdateMarkerLocalPosition(objMarker);
               }
            }
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(objMarkersOverlay);
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}