using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BankHelper {
   public class BankProvider : IDisposable {
      private BankBaseModelContainer _ObjBankDataBase;

      public BankBaseModelContainer DataBase {
         get { return _ObjBankDataBase; }
      }

      public BankProvider() {
         _ObjBankDataBase = new BankBaseModelContainer();
      }

      public Task LoadCurrencyRateInfo() {
         return Task.Run(() => {
               var objXml = new XmlDocument();
               objXml.Load("http://www.obmennik.by/xml/kurs.xml");
               XmlNodeList objNodes = objXml.GetElementsByTagName("bank-id");

               List<Bank> objBanks = GetAllBanks();
               if(objBanks.Count == 0) {
                  foreach(XmlNode node in objNodes) {
                     var objBank = new Bank {
                        Xmld = Convert.ToInt32(node["idbank"].InnerText)
                     };
                     AddBank(objBank);
                  }
               }
               SaveChanges();

               foreach(XmlNode node in objNodes) {
                  Bank objBank = GetBankByXmlId(Convert.ToInt32(node["idbank"].InnerText));
                  if(objBank == null) {
                     break;
                  }

                  DateTime objDateTime = DateParser(node["date"].InnerText, node["time"].InnerText);

                  //по сути очень кривая проверка, 
                  //если в базе уже лежат данные хотя бы одного курса валют за данный день, то прерываем все
                  ExchangeRate objExchange = GetRateByDate(objBank, "USD", objDateTime);
                  if(objExchange != null) {
                     return;
                  }

                  var objUsdRate = new ExchangeRate() {
                     Bank = objBank,
                     CurrencyName = "USD",
                     Buy = Convert.ToDouble(node["usd"]["buy"].InnerText),
                     Sale = Convert.ToDouble(node["usd"]["sell"].InnerText),
                     Date = objDateTime
                  };

                  var objEurRate = new ExchangeRate() {
                     Bank = objBank,
                     CurrencyName = "EUR",
                     Buy = Convert.ToDouble(node["eur"]["buy"].InnerText),
                     Sale = Convert.ToDouble(node["eur"]["sell"].InnerText),
                     Date = objDateTime
                  };

                  var objRurRate = new ExchangeRate() {
                     Bank = objBank,
                     CurrencyName = "RUR",
                     Buy = Convert.ToDouble(node["rur"]["buy"].InnerText),
                     Sale = Convert.ToDouble(node["rur"]["sell"].InnerText),
                     Date = objDateTime
                  };

                  AddExchangeRate(objUsdRate);
                  AddExchangeRate(objEurRate);
                  AddExchangeRate(objRurRate);
               }
            });
      }

      public List<Bank> GetAllBanks() {
         return _ObjBankDataBase.Banks.OrderBy(b => b.Name).ToList();
      }

      public Bank GetBankByName(string strName) {
         return _ObjBankDataBase.Banks.SingleOrDefault(b => b.Name == strName);
      }

      public Bank GetBankByXmlId(int iId) {
         return _ObjBankDataBase.Banks.SingleOrDefault(b => b.Xmld == iId);
      }

      public List<CurrencyExchanger> GetAllExchangers() {
         return _ObjBankDataBase.CurrencyExchangers.ToList();
      }

      public CurrencyExchanger GetExchangerByPlaceId(string strId) {
         return _ObjBankDataBase.CurrencyExchangers.SingleOrDefault(e => e.GMapId == strId);
      }

      public CurrencyExchanger GetExchangerById(int iId) {
         return _ObjBankDataBase.CurrencyExchangers.SingleOrDefault(ex => ex.Id == iId);
      }

      public CurrencyExchanger GetNearestExchanger(double dX, double dY, List<CurrencyExchanger> objExchangers) {
         double distance;
         CurrencyExchanger objNearestExchanger = objExchangers[0];
         distance = GetDistance(dX, dY, objNearestExchanger.X, objNearestExchanger.Y);
         foreach(var exchanger in objExchangers) {
            double dNewDistance = GetDistance(dX, dY, exchanger.X, exchanger.Y);
            if(dNewDistance < distance) {
               distance = dNewDistance;
               objNearestExchanger = exchanger;
            }
         }
         return objNearestExchanger;
      }

      public List<ExchangeRate> GetAllRatesByDate(DateTime objDateTime) {
         return _ObjBankDataBase.ExchangeRates.Where(r => r.Date == objDateTime).ToList();
      }

      public ExchangeRate GetRateByDate(Bank objBank, string strName, DateTime objDateTime) {
         return _ObjBankDataBase.ExchangeRates.FirstOrDefault(r => r.Date == objDateTime && r.CurrencyName == strName && r.Bank.Id == objBank.Id);
      }

      public ExchangeRate GetRateByBank(string strCurrencyName, Bank objBank) {
         return _ObjBankDataBase.ExchangeRates.
            Where(r => r.Bank.Id == objBank.Id && r.CurrencyName == strCurrencyName).
            OrderBy(e => e.Date).FirstOrDefault();
      }

      public ExchangeRate GetBestBuyRate(string strCurrencyName) {
         return _ObjBankDataBase.ExchangeRates.Where(r => r.CurrencyName == strCurrencyName && r.Date.Day == DateTime.Today.Day)
            .OrderBy(r => r.Buy).FirstOrDefault();
      }

      public ExchangeRate GetBestSellRate(string strCurrencyName) {
         return _ObjBankDataBase.ExchangeRates.Where(r => r.CurrencyName == strCurrencyName && r.Date.Day == DateTime.Today.Day).
            OrderByDescending(r => r.Sale).FirstOrDefault();
      }

      public void AddExchanger(CurrencyExchanger objExchanger) {
         _ObjBankDataBase.CurrencyExchangers.Add(objExchanger);
      }

      public void AddBank(Bank objBank) {
         _ObjBankDataBase.Banks.Add(objBank);
      }

      public void AddExchangeRate(ExchangeRate objRate) {
         _ObjBankDataBase.ExchangeRates.Add(objRate);
      }

      public void SaveChanges() {
         _ObjBankDataBase.SaveChanges();
      }

      private double GetDistance(double dMyX, double dMyY, double dX, double dY) {
         return Math.Pow(dX - dMyX, 2) + Math.Pow(dY - dMyY, 2);
      }

      /// <summary>
      /// create DateTime object from xml strings
      /// </summary>
      /// <param name="strDate">string with date</param>
      /// <param name="strTime">string with time</param>
      /// <returns></returns>
      private DateTime DateParser(string strDate, string strTime) {
         string[] strarrDate = strDate.Split('-');
         string[] strarrTime = strTime.Split(':');

         var objDatetime = new DateTime(
            Convert.ToInt32(strarrDate[0]), //year
            Convert.ToInt32(strarrDate[1]), //month
            Convert.ToInt32(strarrDate[2]), //day
            Convert.ToInt32(strarrTime[0]), //hour
            Convert.ToInt32(strarrTime[1]), //min
            Convert.ToInt32(strarrTime[2]) //sec
            );
         return objDatetime;
      }

      /// <summary>
      /// Save all changes in base and dispose base object
      /// </summary>
      public void Dispose() {
         _ObjBankDataBase.SaveChanges();
         _ObjBankDataBase.Dispose();
      }
   }
}