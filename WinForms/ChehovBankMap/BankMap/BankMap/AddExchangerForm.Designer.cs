namespace BankMap
{
   partial class AddExchangerForm
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
         this.label1 = new System.Windows.Forms.Label();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.textBox4 = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.textBox6 = new System.Windows.Forms.TextBox();
         this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
         this.textBox2 = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(42, 18);
         this.label1.TabIndex = 1;
         this.label1.Text = "Bank";
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(4, 21);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(252, 26);
         this.comboBox1.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(1, 66);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(159, 18);
         this.label2.TabIndex = 3;
         this.label2.Text = "Currency exchanger №";
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.numericUpDown1.Location = new System.Drawing.Point(169, 67);
         this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDown1.Name = "numericUpDown1";
         this.numericUpDown1.Size = new System.Drawing.Size(87, 24);
         this.numericUpDown1.TabIndex = 4;
         this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(4, 152);
         this.textBox1.Name = "textBox1";
         this.textBox1.ReadOnly = true;
         this.textBox1.Size = new System.Drawing.Size(252, 24);
         this.textBox1.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(1, 131);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(76, 18);
         this.label3.TabIndex = 7;
         this.label3.Text = "Longtitude";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(3, 188);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(59, 18);
         this.label4.TabIndex = 8;
         this.label4.Text = "Latitude";
         // 
         // button1
         // 
         this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.button1.Location = new System.Drawing.Point(218, 362);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 31);
         this.button1.TabIndex = 9;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // textBox3
         // 
         this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox3.Location = new System.Drawing.Point(275, 21);
         this.textBox3.Name = "textBox3";
         this.textBox3.Size = new System.Drawing.Size(222, 24);
         this.textBox3.TabIndex = 10;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(272, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(51, 18);
         this.label5.TabIndex = 11;
         this.label5.Text = "Phone";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(272, 48);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(62, 18);
         this.label6.TabIndex = 13;
         this.label6.Text = "Address";
         // 
         // textBox4
         // 
         this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox4.Location = new System.Drawing.Point(275, 66);
         this.textBox4.Multiline = true;
         this.textBox4.Name = "textBox4";
         this.textBox4.Size = new System.Drawing.Size(222, 62);
         this.textBox4.TabIndex = 12;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(272, 131);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(79, 18);
         this.label7.TabIndex = 15;
         this.label7.Text = "Open Date";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(3, 275);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(82, 18);
         this.label8.TabIndex = 17;
         this.label8.Text = "Work Time";
         // 
         // textBox6
         // 
         this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox6.Location = new System.Drawing.Point(4, 296);
         this.textBox6.Name = "textBox6";
         this.textBox6.Size = new System.Drawing.Size(252, 24);
         this.textBox6.TabIndex = 16;
         // 
         // monthCalendar1
         // 
         this.monthCalendar1.Location = new System.Drawing.Point(275, 158);
         this.monthCalendar1.Name = "monthCalendar1";
         this.monthCalendar1.TabIndex = 18;
         // 
         // textBox2
         // 
         this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox2.Location = new System.Drawing.Point(6, 209);
         this.textBox2.Name = "textBox2";
         this.textBox2.ReadOnly = true;
         this.textBox2.Size = new System.Drawing.Size(252, 24);
         this.textBox2.TabIndex = 19;
         // 
         // AddExchangerForm
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(514, 397);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.monthCalendar1);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.textBox6);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.textBox4);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.textBox3);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.numericUpDown1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AddExchangerForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "AddExchangerForm";
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown numericUpDown1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox textBox4;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.TextBox textBox6;
      private System.Windows.Forms.MonthCalendar monthCalendar1;
      private System.Windows.Forms.TextBox textBox2;
   }
}