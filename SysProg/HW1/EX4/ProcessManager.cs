using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EX4 {
   public class ProcessManager {
      public ProcessManager() {
         Processes = Process.GetProcesses().OrderBy(proc => proc.ProcessName).ToList();
      }

      public List<Process> Processes { get; private set; }

      public List<Process> GetChildrens(Process objProcess) {
         List<Process> objChildrens = new List<Process>();
         try {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(String.Format("Select ProcessID From Win32_Process Where ParentProcessID={0}", objProcess.Id));

            foreach(ManagementObject managementObject in objSearcher.Get()) {
               objChildrens.Add(Process.GetProcessById(Convert.ToInt32(managementObject["ProcessID"])));
            }

            return objChildrens;
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
            return objChildrens;
         }
      }
   }
}