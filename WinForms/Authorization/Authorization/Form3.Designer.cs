namespace Authorization
{
   partial class Form3
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
         this.label2 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(357, 31);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(96, 24);
         this.label2.TabIndex = 2;
         this.label2.Text = "Welcome!";
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
         this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox1.Location = new System.Drawing.Point(262, 61);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(277, 213);
         this.pictureBox1.TabIndex = 3;
         this.pictureBox1.TabStop = false;
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(16, 59);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(211, 215);
         this.richTextBox1.TabIndex = 4;
         this.richTextBox1.Text = "";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(60, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 24);
         this.label1.TabIndex = 5;
         this.label1.Text = "You profile";
         // 
         // Form3
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(549, 304);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.label2);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "Form3";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Profile";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.Label label1;
   }
}