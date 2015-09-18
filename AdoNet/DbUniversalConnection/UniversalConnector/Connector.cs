using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalConnector {
   internal interface IMultiConnector {
      string ConnectionString { get; }
      string ProviderName { get; }
      ConnectionState State { get; } //ConnectionState - перечисление из System.Data 
      void Connect();
      string GetData(string Command);
   }

   public class Connector : IMultiConnector {
      private dynamic objDbConnection;

      public Connector(string strSectionName) {
         SectionName = strSectionName;
         switch(ConfigurationManager.ConnectionStrings[SectionName].ProviderName) {
         case "System.Data.SqlClient":
            objDbConnection = new SqlConnection();
            break;
         case "System.Data.OleDb":
            objDbConnection = new OleDbConnection();
            break;
         case "System.Data.Odbc":
            objDbConnection = new OdbcConnection();
            break;
         case "System.Data.OracleClient":
            objDbConnection = new OracleConnection();
            break;
         default:
            throw new ArgumentException("Неверное имя секции app.config");
         }
         objDbConnection.ConnectionString = ConfigurationManager.ConnectionStrings[SectionName].ConnectionString;
      }

      public string SectionName { get; private set; }

      public string ConnectionString {
         get { return ConfigurationManager.ConnectionStrings[SectionName].ConnectionString; }
      }

      public string ProviderName {
         get { return ConfigurationManager.ConnectionStrings[SectionName].ProviderName; }
      }

      public ConnectionState State {
         get { return objDbConnection.State; }
      }

      public void Connect() {
         objDbConnection.Open();
      }

      public string GetData(string strCommand) {
         var objCommand = objDbConnection.CreateCommand();
         objCommand.CommandText = strCommand;
         var objDataReader = objCommand.ExecuteReader();
         string strData = "";
         while(objDataReader.Read() != false) {
            strData += String.Format("{0} {1} {2} {3}\n",
               objDataReader["id"],
               objDataReader["Name"],
               objDataReader["Subject"],
               objDataReader["Salary"]);
         }
         if(strData == "") {
            return "Empty string";
         }
         return strData;
      }
   }
}