namespace ThreadButtonRace
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.button1 = new System.Windows.Forms.Button();
         this.button6 = new System.Windows.Forms.Button();
         this.button7 = new System.Windows.Forms.Button();
         this.trackBar1 = new System.Windows.Forms.TrackBar();
         this.label1 = new System.Windows.Forms.Label();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.progressBar2 = new System.Windows.Forms.ProgressBar();
         this.button5 = new System.Windows.Forms.Button();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.button4 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.pictureBox3 = new System.Windows.Forms.PictureBox();
         this.pictureBox4 = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(10, 487);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 45);
         this.button1.TabIndex = 0;
         this.button1.Text = "START";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button6
         // 
         this.button6.Location = new System.Drawing.Point(201, 487);
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size(75, 45);
         this.button6.TabIndex = 7;
         this.button6.Text = "PAUSE";
         this.button6.UseVisualStyleBackColor = true;
         this.button6.Click += new System.EventHandler(this.button6_Click);
         // 
         // button7
         // 
         this.button7.Location = new System.Drawing.Point(106, 487);
         this.button7.Name = "button7";
         this.button7.Size = new System.Drawing.Size(75, 45);
         this.button7.TabIndex = 8;
         this.button7.Text = "RESET";
         this.button7.UseVisualStyleBackColor = true;
         this.button7.Click += new System.EventHandler(this.button7_Click);
         // 
         // trackBar1
         // 
         this.trackBar1.LargeChange = 1;
         this.trackBar1.Location = new System.Drawing.Point(322, 487);
         this.trackBar1.Maximum = 5;
         this.trackBar1.Name = "trackBar1";
         this.trackBar1.Size = new System.Drawing.Size(229, 45);
         this.trackBar1.TabIndex = 9;
         this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(411, 519);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(43, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "SPEED";
         // 
         // progressBar1
         // 
         this.progressBar1.Location = new System.Drawing.Point(153, 23);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(1132, 23);
         this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this.progressBar1.TabIndex = 11;
         this.progressBar1.Value = this.progressBar1.Maximum;
         // 
         // progressBar2
         // 
         this.progressBar2.Location = new System.Drawing.Point(153, 439);
         this.progressBar2.Name = "progressBar2";
         this.progressBar2.Size = new System.Drawing.Size(1132, 23);
         this.progressBar2.TabIndex = 12;
         this.progressBar2.Value = this.progressBar2.Maximum;
         // 
         // button5
         // 
         this.button5.BackgroundImage = global::ThreadButtonRace.Properties.Resources.chuck;
         this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.button5.Location = new System.Drawing.Point(12, 64);
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size(122, 95);
         this.button5.TabIndex = 6;
         this.button5.Text = "Chuck";
         this.button5.UseVisualStyleBackColor = true;
         // 
         // pictureBox2
         // 
         this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pictureBox2.Image = global::ThreadButtonRace.Properties.Resources.finish2;
         this.pictureBox2.Location = new System.Drawing.Point(137, 23);
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size(10, 426);
         this.pictureBox2.TabIndex = 5;
         this.pictureBox2.TabStop = false;
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox1.Image = global::ThreadButtonRace.Properties.Resources.finish2;
         this.pictureBox1.Location = new System.Drawing.Point(1291, 23);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(73, 426);
         this.pictureBox1.TabIndex = 4;
         this.pictureBox1.TabStop = false;
         // 
         // button4
         // 
         this.button4.BackColor = System.Drawing.SystemColors.Control;
         this.button4.BackgroundImage = global::ThreadButtonRace.Properties.Resources.stalone;
         this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.button4.Location = new System.Drawing.Point(12, 165);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(122, 92);
         this.button4.TabIndex = 3;
         this.button4.Text = "Selvester";
         this.button4.UseVisualStyleBackColor = true;
         // 
         // button3
         // 
         this.button3.BackgroundImage = global::ThreadButtonRace.Properties.Resources.chan;
         this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.button3.Location = new System.Drawing.Point(9, 263);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(122, 91);
         this.button3.TabIndex = 2;
         this.button3.Text = "Jacky";
         this.button3.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.BackgroundImage = global::ThreadButtonRace.Properties.Resources.bruc;
         this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.button2.Location = new System.Drawing.Point(9, 362);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(122, 78);
         this.button2.TabIndex = 1;
         this.button2.Text = "Bruce";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // pictureBox3
         // 
         this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox3.Image = global::ThreadButtonRace.Properties.Resources.finish2;
         this.pictureBox3.Location = new System.Drawing.Point(1291, 247);
         this.pictureBox3.Name = "pictureBox3";
         this.pictureBox3.Size = new System.Drawing.Size(73, 215);
         this.pictureBox3.TabIndex = 13;
         this.pictureBox3.TabStop = false;
         // 
         // pictureBox4
         // 
         this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pictureBox4.Image = global::ThreadButtonRace.Properties.Resources.finish2;
         this.pictureBox4.Location = new System.Drawing.Point(137, 241);
         this.pictureBox4.Name = "pictureBox4";
         this.pictureBox4.Size = new System.Drawing.Size(10, 221);
         this.pictureBox4.TabIndex = 14;
         this.pictureBox4.TabStop = false;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(1350, 538);
         this.Controls.Add(this.pictureBox4);
         this.Controls.Add(this.pictureBox3);
         this.Controls.Add(this.progressBar2);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.trackBar1);
         this.Controls.Add(this.button7);
         this.Controls.Add(this.button6);
         this.Controls.Add(this.button5);
         this.Controls.Add(this.pictureBox2);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.button4);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form1";
         this.ShowIcon = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MadRace";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.PictureBox pictureBox2;
      private System.Windows.Forms.Button button5;
      private System.Windows.Forms.Button button6;
      private System.Windows.Forms.Button button7;
      private System.Windows.Forms.TrackBar trackBar1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.ProgressBar progressBar2;
      private System.Windows.Forms.PictureBox pictureBox3;
      private System.Windows.Forms.PictureBox pictureBox4;
   }
}

