using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ThreadButtonRace {
   public partial class Form1 : Form {
      private List<Button> objButtonList;
      private List<Thread> objThreadList;
      private Random objRandom;
      private int iSleepTime;
      private SoundPlayer objSoundPlayer;

      private delegate void StartRace(Button btn);

      public Form1() {
         InitializeComponent();

         objSoundPlayer = new SoundPlayer("main.wav");

         iSleepTime = 200;

         objRandom = new Random();

         objButtonList = new List<Button>();
         objButtonList.Add(button2);
         objButtonList.Add(button3);
         objButtonList.Add(button4);
         objButtonList.Add(button5);

         objThreadList = new List<Thread>();
         foreach(var objButton in objButtonList) {
            objThreadList.Add(new Thread(Moving));
         }
      }

      public void Moving(object objBtn) {
         var objButton = (Button)objBtn;
         while(objButton.Left < pictureBox1.Left - objButton.Width) {
            objButton.Left = objButton.Left + objRandom.Next(5, 30);
            Thread.Sleep(iSleepTime);
         }
         foreach(var objThread in objThreadList) {
            if(objThread != Thread.CurrentThread) {
               objThread.Abort();
            }
         }

         objButton.BackColor = Color.Yellow;
         MessageBox.Show("Winner is " + objButton.Text);
      }

      private void button1_Click(object sender, EventArgs e) {
         for(int iI = 0; iI < objButtonList.Count; ++iI) {
            if(objThreadList[iI].ThreadState != ThreadState.Aborted) {
               objThreadList[iI].Start(objButtonList[iI]);
            }
            else {
               objThreadList[iI] = new Thread(Moving);
               objThreadList[iI].Start(objButtonList[iI]);
            }
         }
         button1.Enabled = false;
         objSoundPlayer.Play();
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
         foreach(var objThread in objThreadList) {
            if(objThread.ThreadState != ThreadState.Suspended) {
               objThread.Abort();
            }
         }
         this.Dispose();
         this.Close();
      }

      private void button6_Click(object sender, EventArgs e) {
         foreach(var objThread in objThreadList) {
            if(objThread.IsAlive) {
               if(objThread.ThreadState != ThreadState.Suspended) {
                  objThread.Suspend();
               }
               if(objThread.ThreadState == ThreadState.Suspended) {
                  objThread.Resume();
               }
            }
         }
      }


      private void button7_Click(object sender, EventArgs e) {
         try {
            foreach(var objThread in objThreadList) {
               if(objThread.ThreadState != ThreadState.Suspended) {
                  objThread.Abort();
               }
               else {
                  objThread.Resume();
                  objThread.Abort();
               }
            }

            foreach(var objButton in objButtonList) {
               objButton.Left = pictureBox2.Left - objButton.Width;
               objButton.BackColor = Color.AliceBlue;
            }
            button1.Enabled = true;
         }
         catch(Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void trackBar1_ValueChanged(object sender, EventArgs e) {
         iSleepTime = 200 - trackBar1.Value * 20;
      }
   }
}