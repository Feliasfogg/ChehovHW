using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization {
   internal class Connector {
      public SqlConnection DbConnection { get; private set; }

      public Connector(string strSection) {
         DbConnection = new SqlConnection();
         DbConnection.ConnectionString = ConfigurationManager.ConnectionStrings[strSection].ConnectionString;
      }

      public string LogIn(UserData objUser) {
         DbConnection.Open();
         string strQuery =
            "SELECT * FROM Users WHERE Login='" + objUser.Login + "' AND Password='" + objUser.Password + "';";
         SqlCommand objCommand = DbConnection.CreateCommand();
         objCommand.CommandText = strQuery;
         SqlDataReader objDataReader = objCommand.ExecuteReader();

         string strUserId = String.Empty;
         if(objDataReader.Read() != false) {
            strUserId=objDataReader["id"].ToString();
         }
         DbConnection.Close();
         return strUserId;
      }

      public string GetUserInfo(string strUserId) {
         DbConnection.Open();
         string strData = String.Empty;
         string strQuery =
            "SELECT * FROM UsersInfo, Users WHERE UsersInfo.UserId="+strUserId+" AND Users.Id="+strUserId+";";

         SqlCommand objCommand = DbConnection.CreateCommand();
         objCommand.CommandText = strQuery;
         SqlDataReader objDataReader = objCommand.ExecuteReader();

         if(objDataReader.Read() != false) {
            strData =
               String.Format(
                  "Login: {0}\n" +
                     "Password {1}\n" +
                     "Email {2}\n" +
                     "Last Name: {3}\n" +
                     "First Name {4}" +
                     "Adress {5}\n" +
                     "Phone {6}\n" +
                     "Code {7}\n",
                  objDataReader["Login"],
                  objDataReader["Password"],
                  objDataReader["Email"],
                  objDataReader["LastName"],
                  objDataReader["FirstName"],
                  objDataReader["Adres"],
                  objDataReader["Code"],
                  objDataReader["UserId"]
                  );
         }
         DbConnection.Close();
         return strData;
      }

      public void Register(UserData objUser) {
         string strQuery =
            "INSERT INTO Users (Login, Password, Email) VALUES ('" + objUser.Login + "', '" + objUser.Password + "', '" +
               objUser.Email + "' );";
         DbConnection.Open();
         SqlCommand objCommand = DbConnection.CreateCommand();
         objCommand.CommandText = strQuery;
         objCommand.ExecuteNonQuery();

         strQuery = "SELECT Id FROM users WHERE Login='" + objUser.Login + "';";
         objCommand.CommandText = strQuery;
         var varDataReader = objCommand.ExecuteReader();
         string strUserId = String.Empty;
         if(varDataReader.Read() != false) {
            strUserId = varDataReader["Id"].ToString();
         }
         varDataReader.Close();
         if(strUserId != String.Empty) {
            strQuery = "INSERT INTO UsersInfo (LastName, FirstName, UserId) VALUES ('" +
               objUser.LastName + "', '" + objUser.FirstName + "'," + strUserId.ToString() + " );";
            objCommand.CommandText = strQuery;
            objCommand.ExecuteNonQuery();
         }
         DbConnection.Close();
      }

      public void ChangePassword(UserData objUser) {
         DbConnection.Open();
         string strQuery =
            "UPDATE Users SET Password='" + objUser.Password + "' WHERE Email='" + objUser.Email + "';";
         SqlCommand objCommand = DbConnection.CreateCommand();
         objCommand.CommandText = strQuery;
         objCommand.ExecuteNonQuery();
         DbConnection.Close();
      }
   }
}