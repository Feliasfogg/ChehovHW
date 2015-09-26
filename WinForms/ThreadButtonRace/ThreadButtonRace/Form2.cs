using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadButtonRace {
   public partial class Form2 : Form {
      private SoundPlayer ObjSoundPlayer;

      public Form2() {
         InitializeComponent();
         ObjSoundPlayer = new SoundPlayer("rondondon.wav");
         ObjSoundPlayer.Play();
         this.Opacity = 1;
         this.timer1.Start();
      }

      private void timer1_Tick(object sender, EventArgs e) {
         Opacity -= 0.0035d;
         if(Opacity == 0) {
            timer1.Stop();
            ObjSoundPlayer.Stop();
            this.Close();
         }
      }
   }
}