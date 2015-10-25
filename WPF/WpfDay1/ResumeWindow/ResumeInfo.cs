using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using ResumeWindow;

namespace ResumeWindow {
   public enum Skills {
      CSharp,
      CPlusPlus,
      Linux
   }

   public enum EmployeeType {
      SysAdm,
      Programmer,
      ProductManager
   }

   public class ResumeInfo {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string BirthDate { get; set; }
      public List<Skills> Skills { get; set; }
      public EmployeeType EmployeeType { get; set; }

      public override string ToString() {
         string strInfo = String.Format("FirstName: {0}\nLastName: {1}\nBirthDate: {2}\n", FirstName, LastName, BirthDate);
         strInfo += "Specialization: ";
         switch(EmployeeType) {
         case EmployeeType.SysAdm:
            strInfo += "SystemAdministrator\n";
            break;
         case EmployeeType.Programmer:
            strInfo += "Programmer\n";
            break;
         case EmployeeType.ProductManager:
            strInfo += "ProductManager\n";
            break;
         default:
            break;
         }
         strInfo += "Skills: ";
         foreach(Skills skill in Skills) {
            switch(skill) {
            case ResumeWindow.Skills.CPlusPlus:
               strInfo += "C++\n";
               break;
            case ResumeWindow.Skills.CSharp:
               strInfo += "C#\n";
               break;
            case ResumeWindow.Skills.Linux:
               strInfo = "Linux\n";
               break;
            }
         }
         return strInfo;
      }
   }
}