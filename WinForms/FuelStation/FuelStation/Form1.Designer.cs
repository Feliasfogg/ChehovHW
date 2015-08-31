namespace FuelStation
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
         this.groupBoxStation = new System.Windows.Forms.GroupBox();
         this.textBoxFuelFinalSumm = new System.Windows.Forms.TextBox();
         this.groupBoxFuel = new System.Windows.Forms.GroupBox();
         this.radioButtonFuelSumm = new System.Windows.Forms.RadioButton();
         this.radioButtonFuelCount = new System.Windows.Forms.RadioButton();
         this.textBoxFuelSumm = new System.Windows.Forms.TextBox();
         this.textBoxFuelCount = new System.Windows.Forms.TextBox();
         this.textBoxFuelPrice = new System.Windows.Forms.TextBox();
         this.labelFuelPrice = new System.Windows.Forms.Label();
         this.comboBoxFuel = new System.Windows.Forms.ComboBox();
         this.labelFuelType = new System.Windows.Forms.Label();
         this.groupBoxCafe = new System.Windows.Forms.GroupBox();
         this.groupBoxCafeContent = new System.Windows.Forms.GroupBox();
         this.checkBox4 = new System.Windows.Forms.CheckBox();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.textBox8 = new System.Windows.Forms.TextBox();
         this.textBox7 = new System.Windows.Forms.TextBox();
         this.textBox6 = new System.Windows.Forms.TextBox();
         this.textBox4 = new System.Windows.Forms.TextBox();
         this.textBox5 = new System.Windows.Forms.TextBox();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.labelCafeCount = new System.Windows.Forms.Label();
         this.labelCafePrice = new System.Windows.Forms.Label();
         this.textBoxCafeFinalSumm = new System.Windows.Forms.TextBox();
         this.buttonCountPrice = new System.Windows.Forms.Button();
         this.textBoxAllFinalPrice = new System.Windows.Forms.TextBox();
         this.labelFinalPrice = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.groupBoxStation.SuspendLayout();
         this.groupBoxFuel.SuspendLayout();
         this.groupBoxCafe.SuspendLayout();
         this.groupBoxCafeContent.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxStation
         // 
         this.groupBoxStation.Controls.Add(this.label7);
         this.groupBoxStation.Controls.Add(this.label1);
         this.groupBoxStation.Controls.Add(this.textBoxFuelFinalSumm);
         this.groupBoxStation.Controls.Add(this.groupBoxFuel);
         this.groupBoxStation.Controls.Add(this.textBoxFuelPrice);
         this.groupBoxStation.Controls.Add(this.labelFuelPrice);
         this.groupBoxStation.Controls.Add(this.comboBoxFuel);
         this.groupBoxStation.Controls.Add(this.labelFuelType);
         this.groupBoxStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBoxStation.Location = new System.Drawing.Point(12, 12);
         this.groupBoxStation.Name = "groupBoxStation";
         this.groupBoxStation.Size = new System.Drawing.Size(333, 337);
         this.groupBoxStation.TabIndex = 0;
         this.groupBoxStation.TabStop = false;
         this.groupBoxStation.Text = "Топливо";
         // 
         // textBoxFuelFinalSumm
         // 
         this.textBoxFuelFinalSumm.Location = new System.Drawing.Point(19, 250);
         this.textBoxFuelFinalSumm.Multiline = true;
         this.textBoxFuelFinalSumm.Name = "textBoxFuelFinalSumm";
         this.textBoxFuelFinalSumm.ReadOnly = true;
         this.textBoxFuelFinalSumm.Size = new System.Drawing.Size(273, 81);
         this.textBoxFuelFinalSumm.TabIndex = 10;
         // 
         // groupBoxFuel
         // 
         this.groupBoxFuel.Controls.Add(this.label9);
         this.groupBoxFuel.Controls.Add(this.label8);
         this.groupBoxFuel.Controls.Add(this.radioButtonFuelSumm);
         this.groupBoxFuel.Controls.Add(this.radioButtonFuelCount);
         this.groupBoxFuel.Controls.Add(this.textBoxFuelSumm);
         this.groupBoxFuel.Controls.Add(this.textBoxFuelCount);
         this.groupBoxFuel.Location = new System.Drawing.Point(6, 129);
         this.groupBoxFuel.Name = "groupBoxFuel";
         this.groupBoxFuel.Size = new System.Drawing.Size(321, 93);
         this.groupBoxFuel.TabIndex = 9;
         this.groupBoxFuel.TabStop = false;
         // 
         // radioButtonFuelSumm
         // 
         this.radioButtonFuelSumm.AutoSize = true;
         this.radioButtonFuelSumm.Location = new System.Drawing.Point(28, 57);
         this.radioButtonFuelSumm.Name = "radioButtonFuelSumm";
         this.radioButtonFuelSumm.Size = new System.Drawing.Size(64, 17);
         this.radioButtonFuelSumm.TabIndex = 10;
         this.radioButtonFuelSumm.TabStop = true;
         this.radioButtonFuelSumm.Text = "Сумма";
         this.radioButtonFuelSumm.UseVisualStyleBackColor = true;
         this.radioButtonFuelSumm.CheckedChanged += new System.EventHandler(this.radioButtonFuelSumm_CheckedChanged);
         // 
         // radioButtonFuelCount
         // 
         this.radioButtonFuelCount.AutoSize = true;
         this.radioButtonFuelCount.Location = new System.Drawing.Point(27, 19);
         this.radioButtonFuelCount.Name = "radioButtonFuelCount";
         this.radioButtonFuelCount.Size = new System.Drawing.Size(94, 17);
         this.radioButtonFuelCount.TabIndex = 9;
         this.radioButtonFuelCount.TabStop = true;
         this.radioButtonFuelCount.Text = "Количество";
         this.radioButtonFuelCount.UseVisualStyleBackColor = true;
         this.radioButtonFuelCount.CheckedChanged += new System.EventHandler(this.radioButtonFuelCount_CheckedChanged);
         // 
         // textBoxFuelSumm
         // 
         this.textBoxFuelSumm.Location = new System.Drawing.Point(142, 54);
         this.textBoxFuelSumm.Name = "textBoxFuelSumm";
         this.textBoxFuelSumm.Size = new System.Drawing.Size(121, 20);
         this.textBoxFuelSumm.TabIndex = 8;
         // 
         // textBoxFuelCount
         // 
         this.textBoxFuelCount.Location = new System.Drawing.Point(142, 16);
         this.textBoxFuelCount.Name = "textBoxFuelCount";
         this.textBoxFuelCount.Size = new System.Drawing.Size(121, 20);
         this.textBoxFuelCount.TabIndex = 7;
         // 
         // textBoxFuelPrice
         // 
         this.textBoxFuelPrice.Location = new System.Drawing.Point(148, 86);
         this.textBoxFuelPrice.Name = "textBoxFuelPrice";
         this.textBoxFuelPrice.ReadOnly = true;
         this.textBoxFuelPrice.Size = new System.Drawing.Size(121, 20);
         this.textBoxFuelPrice.TabIndex = 4;
         // 
         // labelFuelPrice
         // 
         this.labelFuelPrice.AutoSize = true;
         this.labelFuelPrice.ForeColor = System.Drawing.Color.Red;
         this.labelFuelPrice.Location = new System.Drawing.Point(60, 89);
         this.labelFuelPrice.Name = "labelFuelPrice";
         this.labelFuelPrice.Size = new System.Drawing.Size(37, 13);
         this.labelFuelPrice.TabIndex = 2;
         this.labelFuelPrice.Text = "Цена";
         // 
         // comboBoxFuel
         // 
         this.comboBoxFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxFuel.FormattingEnabled = true;
         this.comboBoxFuel.Items.AddRange(new object[] {
            "АИ-95",
            "АИ-98",
            "АИ-99",
            "Диз.Топ."});
         this.comboBoxFuel.Location = new System.Drawing.Point(148, 36);
         this.comboBoxFuel.Name = "comboBoxFuel";
         this.comboBoxFuel.Size = new System.Drawing.Size(121, 21);
         this.comboBoxFuel.TabIndex = 1;
         this.comboBoxFuel.SelectedIndexChanged += new System.EventHandler(this.comboBoxFuel_SelectedIndexChanged);
         // 
         // labelFuelType
         // 
         this.labelFuelType.AutoSize = true;
         this.labelFuelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelFuelType.ForeColor = System.Drawing.Color.Blue;
         this.labelFuelType.Location = new System.Drawing.Point(57, 36);
         this.labelFuelType.Name = "labelFuelType";
         this.labelFuelType.Size = new System.Drawing.Size(50, 13);
         this.labelFuelType.TabIndex = 0;
         this.labelFuelType.Text = "Бензин";
         // 
         // groupBoxCafe
         // 
         this.groupBoxCafe.Controls.Add(this.label2);
         this.groupBoxCafe.Controls.Add(this.groupBoxCafeContent);
         this.groupBoxCafe.Controls.Add(this.textBoxCafeFinalSumm);
         this.groupBoxCafe.Location = new System.Drawing.Point(363, 12);
         this.groupBoxCafe.Name = "groupBoxCafe";
         this.groupBoxCafe.Size = new System.Drawing.Size(333, 337);
         this.groupBoxCafe.TabIndex = 11;
         this.groupBoxCafe.TabStop = false;
         this.groupBoxCafe.Text = "Мини-кафе";
         // 
         // groupBoxCafeContent
         // 
         this.groupBoxCafeContent.Controls.Add(this.label6);
         this.groupBoxCafeContent.Controls.Add(this.label5);
         this.groupBoxCafeContent.Controls.Add(this.label4);
         this.groupBoxCafeContent.Controls.Add(this.label3);
         this.groupBoxCafeContent.Controls.Add(this.checkBox4);
         this.groupBoxCafeContent.Controls.Add(this.checkBox3);
         this.groupBoxCafeContent.Controls.Add(this.checkBox2);
         this.groupBoxCafeContent.Controls.Add(this.checkBox1);
         this.groupBoxCafeContent.Controls.Add(this.textBox8);
         this.groupBoxCafeContent.Controls.Add(this.textBox7);
         this.groupBoxCafeContent.Controls.Add(this.textBox6);
         this.groupBoxCafeContent.Controls.Add(this.textBox4);
         this.groupBoxCafeContent.Controls.Add(this.textBox5);
         this.groupBoxCafeContent.Controls.Add(this.textBox3);
         this.groupBoxCafeContent.Controls.Add(this.textBox2);
         this.groupBoxCafeContent.Controls.Add(this.textBox1);
         this.groupBoxCafeContent.Controls.Add(this.labelCafeCount);
         this.groupBoxCafeContent.Controls.Add(this.labelCafePrice);
         this.groupBoxCafeContent.Location = new System.Drawing.Point(6, 19);
         this.groupBoxCafeContent.Name = "groupBoxCafeContent";
         this.groupBoxCafeContent.Size = new System.Drawing.Size(317, 203);
         this.groupBoxCafeContent.TabIndex = 11;
         this.groupBoxCafeContent.TabStop = false;
         // 
         // checkBox4
         // 
         this.checkBox4.AutoSize = true;
         this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBox4.ForeColor = System.Drawing.Color.Blue;
         this.checkBox4.Location = new System.Drawing.Point(17, 161);
         this.checkBox4.Name = "checkBox4";
         this.checkBox4.Size = new System.Drawing.Size(84, 17);
         this.checkBox4.TabIndex = 25;
         this.checkBox4.Text = "Coca-Cola";
         this.checkBox4.UseVisualStyleBackColor = true;
         this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBox3.ForeColor = System.Drawing.Color.Blue;
         this.checkBox3.Location = new System.Drawing.Point(17, 125);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(89, 17);
         this.checkBox3.TabIndex = 24;
         this.checkBox3.Text = "Чизбургер";
         this.checkBox3.UseVisualStyleBackColor = true;
         this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // checkBox2
         // 
         this.checkBox2.AutoSize = true;
         this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBox2.ForeColor = System.Drawing.Color.Blue;
         this.checkBox2.Location = new System.Drawing.Point(17, 82);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(89, 17);
         this.checkBox2.TabIndex = 23;
         this.checkBox2.Text = "Гамбургер";
         this.checkBox2.UseVisualStyleBackColor = true;
         this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBox1.ForeColor = System.Drawing.Color.Blue;
         this.checkBox1.Location = new System.Drawing.Point(17, 43);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(71, 17);
         this.checkBox1.TabIndex = 22;
         this.checkBox1.Text = "Хот-дог";
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // textBox8
         // 
         this.textBox8.Location = new System.Drawing.Point(240, 161);
         this.textBox8.Name = "textBox8";
         this.textBox8.Size = new System.Drawing.Size(71, 20);
         this.textBox8.TabIndex = 21;
         // 
         // textBox7
         // 
         this.textBox7.Location = new System.Drawing.Point(115, 161);
         this.textBox7.Name = "textBox7";
         this.textBox7.ReadOnly = true;
         this.textBox7.Size = new System.Drawing.Size(71, 20);
         this.textBox7.TabIndex = 20;
         // 
         // textBox6
         // 
         this.textBox6.Location = new System.Drawing.Point(240, 122);
         this.textBox6.Name = "textBox6";
         this.textBox6.Size = new System.Drawing.Size(71, 20);
         this.textBox6.TabIndex = 18;
         // 
         // textBox4
         // 
         this.textBox4.Location = new System.Drawing.Point(240, 82);
         this.textBox4.Name = "textBox4";
         this.textBox4.Size = new System.Drawing.Size(71, 20);
         this.textBox4.TabIndex = 16;
         // 
         // textBox5
         // 
         this.textBox5.Location = new System.Drawing.Point(115, 125);
         this.textBox5.Name = "textBox5";
         this.textBox5.ReadOnly = true;
         this.textBox5.Size = new System.Drawing.Size(71, 20);
         this.textBox5.TabIndex = 19;
         // 
         // textBox3
         // 
         this.textBox3.Location = new System.Drawing.Point(115, 82);
         this.textBox3.Name = "textBox3";
         this.textBox3.ReadOnly = true;
         this.textBox3.Size = new System.Drawing.Size(71, 20);
         this.textBox3.TabIndex = 17;
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(240, 43);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(71, 20);
         this.textBox2.TabIndex = 15;
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(115, 43);
         this.textBox1.Name = "textBox1";
         this.textBox1.ReadOnly = true;
         this.textBox1.Size = new System.Drawing.Size(71, 20);
         this.textBox1.TabIndex = 11;
         // 
         // labelCafeCount
         // 
         this.labelCafeCount.AutoSize = true;
         this.labelCafeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelCafeCount.ForeColor = System.Drawing.Color.Blue;
         this.labelCafeCount.Location = new System.Drawing.Point(211, 17);
         this.labelCafeCount.Name = "labelCafeCount";
         this.labelCafeCount.Size = new System.Drawing.Size(76, 13);
         this.labelCafeCount.TabIndex = 11;
         this.labelCafeCount.Text = "Количество";
         // 
         // labelCafePrice
         // 
         this.labelCafePrice.AutoSize = true;
         this.labelCafePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelCafePrice.ForeColor = System.Drawing.Color.Red;
         this.labelCafePrice.Location = new System.Drawing.Point(140, 16);
         this.labelCafePrice.Name = "labelCafePrice";
         this.labelCafePrice.Size = new System.Drawing.Size(37, 13);
         this.labelCafePrice.TabIndex = 12;
         this.labelCafePrice.Text = "Цена";
         // 
         // textBoxCafeFinalSumm
         // 
         this.textBoxCafeFinalSumm.Location = new System.Drawing.Point(20, 250);
         this.textBoxCafeFinalSumm.Multiline = true;
         this.textBoxCafeFinalSumm.Name = "textBoxCafeFinalSumm";
         this.textBoxCafeFinalSumm.ReadOnly = true;
         this.textBoxCafeFinalSumm.Size = new System.Drawing.Size(273, 81);
         this.textBoxCafeFinalSumm.TabIndex = 10;
         // 
         // buttonCountPrice
         // 
         this.buttonCountPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.buttonCountPrice.ForeColor = System.Drawing.Color.Red;
         this.buttonCountPrice.Location = new System.Drawing.Point(45, 384);
         this.buttonCountPrice.Name = "buttonCountPrice";
         this.buttonCountPrice.Size = new System.Drawing.Size(273, 98);
         this.buttonCountPrice.TabIndex = 12;
         this.buttonCountPrice.Text = "Рассчитать";
         this.buttonCountPrice.UseVisualStyleBackColor = true;
         this.buttonCountPrice.Click += new System.EventHandler(this.buttonCountPrice_Click);
         // 
         // textBoxAllFinalPrice
         // 
         this.textBoxAllFinalPrice.Location = new System.Drawing.Point(386, 384);
         this.textBoxAllFinalPrice.Multiline = true;
         this.textBoxAllFinalPrice.Name = "textBoxAllFinalPrice";
         this.textBoxAllFinalPrice.ReadOnly = true;
         this.textBoxAllFinalPrice.Size = new System.Drawing.Size(273, 98);
         this.textBoxAllFinalPrice.TabIndex = 12;
         // 
         // labelFinalPrice
         // 
         this.labelFinalPrice.AutoSize = true;
         this.labelFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelFinalPrice.ForeColor = System.Drawing.Color.Blue;
         this.labelFinalPrice.Location = new System.Drawing.Point(396, 356);
         this.labelFinalPrice.Name = "labelFinalPrice";
         this.labelFinalPrice.Size = new System.Drawing.Size(90, 25);
         this.labelFinalPrice.TabIndex = 11;
         this.labelFinalPrice.Text = "ИТОГО:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(19, 231);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(60, 13);
         this.label1.TabIndex = 11;
         this.label1.Text = "К оплате";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label2.Location = new System.Drawing.Point(32, 234);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(60, 13);
         this.label2.TabIndex = 12;
         this.label2.Text = "К оплате";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label3.ForeColor = System.Drawing.Color.Red;
         this.label3.Location = new System.Drawing.Point(192, 44);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(35, 16);
         this.label3.TabIndex = 26;
         this.label3.Text = "руб";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label4.ForeColor = System.Drawing.Color.Red;
         this.label4.Location = new System.Drawing.Point(192, 80);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(35, 16);
         this.label4.TabIndex = 27;
         this.label4.Text = "руб";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label5.ForeColor = System.Drawing.Color.Red;
         this.label5.Location = new System.Drawing.Point(191, 128);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(35, 16);
         this.label5.TabIndex = 28;
         this.label5.Text = "руб";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label6.ForeColor = System.Drawing.Color.Red;
         this.label6.Location = new System.Drawing.Point(191, 162);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(35, 16);
         this.label6.TabIndex = 29;
         this.label6.Text = "руб";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label7.ForeColor = System.Drawing.Color.Red;
         this.label7.Location = new System.Drawing.Point(275, 89);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(35, 16);
         this.label7.TabIndex = 30;
         this.label7.Text = "руб";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label8.ForeColor = System.Drawing.Color.Red;
         this.label8.Location = new System.Drawing.Point(269, 20);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(17, 16);
         this.label8.TabIndex = 31;
         this.label8.Text = "л";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label9.ForeColor = System.Drawing.Color.Red;
         this.label9.Location = new System.Drawing.Point(269, 57);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(35, 16);
         this.label9.TabIndex = 32;
         this.label9.Text = "руб";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(708, 522);
         this.Controls.Add(this.labelFinalPrice);
         this.Controls.Add(this.textBoxAllFinalPrice);
         this.Controls.Add(this.buttonCountPrice);
         this.Controls.Add(this.groupBoxCafe);
         this.Controls.Add(this.groupBoxStation);
         this.Name = "Form1";
         this.Text = "Автозаправка";
         this.groupBoxStation.ResumeLayout(false);
         this.groupBoxStation.PerformLayout();
         this.groupBoxFuel.ResumeLayout(false);
         this.groupBoxFuel.PerformLayout();
         this.groupBoxCafe.ResumeLayout(false);
         this.groupBoxCafe.PerformLayout();
         this.groupBoxCafeContent.ResumeLayout(false);
         this.groupBoxCafeContent.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStation;
        private System.Windows.Forms.TextBox textBoxFuelPrice;
        private System.Windows.Forms.Label labelFuelPrice;
        private System.Windows.Forms.ComboBox comboBoxFuel;
        private System.Windows.Forms.Label labelFuelType;
        private System.Windows.Forms.TextBox textBoxFuelSumm;
        private System.Windows.Forms.TextBox textBoxFuelCount;
        private System.Windows.Forms.GroupBox groupBoxFuel;
        private System.Windows.Forms.TextBox textBoxFuelFinalSumm;
        private System.Windows.Forms.RadioButton radioButtonFuelSumm;
        private System.Windows.Forms.RadioButton radioButtonFuelCount;
        private System.Windows.Forms.GroupBox groupBoxCafe;
        private System.Windows.Forms.GroupBox groupBoxCafeContent;
        private System.Windows.Forms.TextBox textBoxCafeFinalSumm;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelCafeCount;
        private System.Windows.Forms.Label labelCafePrice;
        private System.Windows.Forms.Button buttonCountPrice;
        private System.Windows.Forms.TextBox textBoxAllFinalPrice;
        private System.Windows.Forms.Label labelFinalPrice;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

