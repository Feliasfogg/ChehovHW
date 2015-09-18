using System.Drawing;

namespace Authorization
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.linkLabel1 = new System.Windows.Forms.LinkLabel();
         this.linkLabel2 = new System.Windows.Forms.LinkLabel();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.textBox2);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.button1);
         this.groupBox1.Location = new System.Drawing.Point(270, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(224, 269);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Credentials";
         // 
         // textBox2
         // 
         this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
         this.textBox2.ForeColor = System.Drawing.Color.Gray;
         this.textBox2.Location = new System.Drawing.Point(38, 121);
         this.textBox2.Multiline = true;
         this.textBox2.Name = "textBox2";
         this.textBox2.PasswordChar = '*';
         this.textBox2.Size = new System.Drawing.Size(144, 30);
         this.textBox2.TabIndex = 4;
         this.textBox2.Text = "Password";
         this.textBox2.GotFocus += new System.EventHandler(this.textBox2_GotFocus);
         this.textBox2.LostFocus += new System.EventHandler(this.textBox2_LostFocus);
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
         this.textBox1.ForeColor = System.Drawing.Color.Gray;
         this.textBox1.Location = new System.Drawing.Point(38, 40);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(144, 30);
         this.textBox1.TabIndex = 3;
         this.textBox1.Text = "Login";
         this.textBox1.GotFocus += new System.EventHandler(this.textBox1_GotFocus);
         this.textBox1.LostFocus += new System.EventHandler(this.textBox1_LostFocus);
         // 
         // button1
         // 
         this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.button1.Location = new System.Drawing.Point(38, 188);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(144, 53);
         this.button1.TabIndex = 2;
         this.button1.Text = "Log In";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
         this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(222, 269);
         this.pictureBox1.TabIndex = 1;
         this.pictureBox1.TabStop = false;
         // 
         // linkLabel1
         // 
         this.linkLabel1.AutoSize = true;
         this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
         this.linkLabel1.Location = new System.Drawing.Point(12, 331);
         this.linkLabel1.Name = "linkLabel1";
         this.linkLabel1.Size = new System.Drawing.Size(113, 17);
         this.linkLabel1.TabIndex = 2;
         this.linkLabel1.TabStop = true;
         this.linkLabel1.Text = "Forget password";
         this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
         // 
         // linkLabel2
         // 
         this.linkLabel2.AutoSize = true;
         this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
         this.linkLabel2.Location = new System.Drawing.Point(411, 333);
         this.linkLabel2.Name = "linkLabel2";
         this.linkLabel2.Size = new System.Drawing.Size(84, 17);
         this.linkLabel2.TabIndex = 3;
         this.linkLabel2.TabStop = true;
         this.linkLabel2.Text = "Registration";
         this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
         // 
         // progressBar1
         // 
         this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.progressBar1.Location = new System.Drawing.Point(12, 287);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(480, 41);
         this.progressBar1.TabIndex = 4;
         this.progressBar1.Value = this.progressBar1.Minimum;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
         this.label1.Location = new System.Drawing.Point(239, 300);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(0, 20);
         this.label1.TabIndex = 5;
         // 
         // Form1
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(498, 358);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this.linkLabel2);
         this.Controls.Add(this.linkLabel1);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form1";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Authorization";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.LinkLabel linkLabel2;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.Label label1;
   }
}

