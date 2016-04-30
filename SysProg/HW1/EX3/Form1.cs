using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX3 {
   public partial class Form1 : Form {
      private Stopwatch _stopWatch = new Stopwatch();

      public Form1() {
         InitializeComponent();
         ShowStartText();
      }

      private void button1_Click(object sender, EventArgs e) {
         _stopWatch.Stop();
         long ms = _stopWatch.ElapsedMilliseconds;
         textBox1.Clear();
         _stopWatch.Reset();
         MessageBox.Show(String.Format("{0} ms elapsed", ms));
         ShowStartText();
      }

      private void ShowStartText() {
         button1.Enabled = false;
         Thread.Sleep(1000);
         button1.Enabled = true;
         textBox1.Text = "Press the button!";
         _stopWatch.Start();
      }
   }
}