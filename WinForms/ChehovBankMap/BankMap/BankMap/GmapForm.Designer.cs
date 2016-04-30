namespace BankMap
{
   partial class GmapForm
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
         this.components = new System.ComponentModel.Container();
         this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.addExchangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.findNearestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.label19 = new System.Windows.Forms.Label();
         this.label20 = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.radioButton3 = new System.Windows.Forms.RadioButton();
         this.comboBox2 = new System.Windows.Forms.ComboBox();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label11 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label16 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label17 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label18 = new System.Windows.Forms.Label();
         this.contextMenuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // gMapControl1
         // 
         this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.gMapControl1.Bearing = 0F;
         this.gMapControl1.CanDragMap = true;
         this.gMapControl1.ContextMenuStrip = this.contextMenuStrip1;
         this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
         this.gMapControl1.GrayScaleMode = true;
         this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
         this.gMapControl1.LevelsKeepInMemmory = 5;
         this.gMapControl1.Location = new System.Drawing.Point(3, 3);
         this.gMapControl1.MarkersEnabled = true;
         this.gMapControl1.MaxZoom = 18;
         this.gMapControl1.MinZoom = 1;
         this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
         this.gMapControl1.Name = "gMapControl1";
         this.gMapControl1.NegativeMode = false;
         this.gMapControl1.PolygonsEnabled = true;
         this.gMapControl1.RetryLoadTile = 0;
         this.gMapControl1.RoutesEnabled = true;
         this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
         this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
         this.gMapControl1.ShowTileGridLines = false;
         this.gMapControl1.Size = new System.Drawing.Size(921, 709);
         this.gMapControl1.TabIndex = 1;
         this.gMapControl1.Zoom = 13D;
         this.gMapControl1.OnMarkerClick += GMapControl1OnOnMarkerClick;
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExchangerToolStripMenuItem,
            this.findNearestToolStripMenuItem});
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size(151, 48);
         // 
         // addExchangerToolStripMenuItem
         // 
         this.addExchangerToolStripMenuItem.Name = "addExchangerToolStripMenuItem";
         this.addExchangerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
         this.addExchangerToolStripMenuItem.Text = "AddExchanger";
         this.addExchangerToolStripMenuItem.Click += new System.EventHandler(this.addExchangerToolStripMenuItem_Click);
         // 
         // findNearestToolStripMenuItem
         // 
         this.findNearestToolStripMenuItem.Name = "findNearestToolStripMenuItem";
         this.findNearestToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
         this.findNearestToolStripMenuItem.Text = "FindNearest";
         this.findNearestToolStripMenuItem.Click += new System.EventHandler(this.findNearestToolStripMenuItem_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.Location = new System.Drawing.Point(4, 3);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.gMapControl1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
         this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
         this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
         this.splitContainer1.Size = new System.Drawing.Size(1285, 715);
         this.splitContainer1.SplitterDistance = 927;
         this.splitContainer1.TabIndex = 2;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this.label10);
         this.groupBox2.Controls.Add(this.label14);
         this.groupBox2.Controls.Add(this.label15);
         this.groupBox2.Controls.Add(this.label19);
         this.groupBox2.Controls.Add(this.label20);
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(21, 228);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(306, 212);
         this.groupBox2.TabIndex = 63;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Best sell rate";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(13, 31);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(40, 18);
         this.label3.TabIndex = 56;
         this.label3.Text = "USD";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(13, 82);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 18);
         this.label4.TabIndex = 57;
         this.label4.Text = "EUR";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(14, 139);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 18);
         this.label5.TabIndex = 58;
         this.label5.Text = "RUR";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(88, 31);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(42, 18);
         this.label6.TabIndex = 59;
         this.label6.Text = "Bank";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.Location = new System.Drawing.Point(153, 139);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(42, 18);
         this.label10.TabIndex = 64;
         this.label10.Text = "Bank";
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label14.Location = new System.Drawing.Point(88, 82);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(42, 18);
         this.label14.TabIndex = 60;
         this.label14.Text = "Bank";
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label15.Location = new System.Drawing.Point(153, 82);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(42, 18);
         this.label15.TabIndex = 63;
         this.label15.Text = "Bank";
         // 
         // label19
         // 
         this.label19.AutoSize = true;
         this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label19.Location = new System.Drawing.Point(88, 139);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(42, 18);
         this.label19.TabIndex = 61;
         this.label19.Text = "Bank";
         // 
         // label20
         // 
         this.label20.AutoSize = true;
         this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label20.Location = new System.Drawing.Point(153, 31);
         this.label20.Name = "label20";
         this.label20.Size = new System.Drawing.Size(42, 18);
         this.label20.TabIndex = 62;
         this.label20.Text = "Bank";
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Controls.Add(this.label1);
         this.groupBox3.Controls.Add(this.radioButton3);
         this.groupBox3.Controls.Add(this.comboBox2);
         this.groupBox3.Controls.Add(this.comboBox1);
         this.groupBox3.Controls.Add(this.radioButton2);
         this.groupBox3.Controls.Add(this.radioButton1);
         this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox3.Location = new System.Drawing.Point(21, 465);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(306, 230);
         this.groupBox3.TabIndex = 62;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Filter";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(6, 167);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(85, 18);
         this.label2.TabIndex = 65;
         this.label2.Text = "Select bank";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(6, 117);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(82, 18);
         this.label1.TabIndex = 63;
         this.label1.Text = "Select map";
         // 
         // radioButton3
         // 
         this.radioButton3.AutoSize = true;
         this.radioButton3.Checked = true;
         this.radioButton3.Location = new System.Drawing.Point(12, 23);
         this.radioButton3.Name = "radioButton3";
         this.radioButton3.Size = new System.Drawing.Size(41, 22);
         this.radioButton3.TabIndex = 64;
         this.radioButton3.TabStop = true;
         this.radioButton3.Text = "All";
         this.radioButton3.UseVisualStyleBackColor = true;
         this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
         // 
         // comboBox2
         // 
         this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox2.FormattingEnabled = true;
         this.comboBox2.Items.AddRange(new object[] {
            "All"});
         this.comboBox2.Location = new System.Drawing.Point(9, 191);
         this.comboBox2.Name = "comboBox2";
         this.comboBox2.Size = new System.Drawing.Size(270, 26);
         this.comboBox2.TabIndex = 63;
         this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
         // 
         // comboBox1
         // 
         this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Items.AddRange(new object[] {
            "GoogleMap",
            "OpenStreetMap"});
         this.comboBox1.Location = new System.Drawing.Point(9, 138);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(270, 26);
         this.comboBox1.TabIndex = 59;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(11, 79);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(143, 22);
         this.radioButton2.TabIndex = 1;
         this.radioButton2.Text = "Only best sell rate";
         this.radioButton2.UseVisualStyleBackColor = true;
         this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Location = new System.Drawing.Point(11, 51);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(144, 22);
         this.radioButton1.TabIndex = 0;
         this.radioButton1.Text = "Only best buy rate";
         this.radioButton1.UseVisualStyleBackColor = true;
         this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.label11);
         this.groupBox1.Controls.Add(this.label12);
         this.groupBox1.Controls.Add(this.label13);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label16);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label17);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label18);
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(21, 9);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(306, 195);
         this.groupBox1.TabIndex = 60;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Best buy rate";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label11.Location = new System.Drawing.Point(11, 44);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(40, 18);
         this.label11.TabIndex = 40;
         this.label11.Text = "USD";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label12.Location = new System.Drawing.Point(11, 95);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(40, 18);
         this.label12.TabIndex = 41;
         this.label12.Text = "EUR";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label13.Location = new System.Drawing.Point(12, 152);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(41, 18);
         this.label13.TabIndex = 42;
         this.label13.Text = "RUR";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(86, 44);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(42, 18);
         this.label7.TabIndex = 47;
         this.label7.Text = "Bank";
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label16.Location = new System.Drawing.Point(151, 152);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(42, 18);
         this.label16.TabIndex = 55;
         this.label16.Text = "Bank";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(86, 95);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(42, 18);
         this.label8.TabIndex = 48;
         this.label8.Text = "Bank";
         // 
         // label17
         // 
         this.label17.AutoSize = true;
         this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label17.Location = new System.Drawing.Point(151, 95);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(42, 18);
         this.label17.TabIndex = 54;
         this.label17.Text = "Bank";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(86, 152);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(42, 18);
         this.label9.TabIndex = 49;
         this.label9.Text = "Bank";
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label18.Location = new System.Drawing.Point(151, 44);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(42, 18);
         this.label18.TabIndex = 53;
         this.label18.Text = "Bank";
         // 
         // GmapForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1281, 719);
         this.Controls.Add(this.splitContainer1);
         this.Name = "GmapForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "GoogleMap";
         this.Load += new System.EventHandler(this.Form2_Load);
         this.contextMenuStrip1.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private GMap.NET.WindowsForms.GMapControl gMapControl1;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem addExchangerToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.ToolStripMenuItem findNearestToolStripMenuItem;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox comboBox2;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.RadioButton radioButton3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.Label label20;

   }
}