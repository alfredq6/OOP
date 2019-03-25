namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GettingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.InventoryNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PriceMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.OrganizationNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TelephoneNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OutputButton = new System.Windows.Forms.Button();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.NumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.InputAdressButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.WeightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поДатеПоступленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поСтранеПроизводителяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрепитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открепитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.SostLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(13, 102);
            this.ProductNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.ProductNameTextBox.TabIndex = 0;
            this.ProductNameTextBox.Click += new System.EventHandler(this.ProductNameTextBox_Click);
            this.ProductNameTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название товара:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Инвентарный номер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Размер:";
            // 
            // SizeTrackBar
            // 
            this.SizeTrackBar.LargeChange = 10;
            this.SizeTrackBar.Location = new System.Drawing.Point(10, 209);
            this.SizeTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SizeTrackBar.Name = "SizeTrackBar";
            this.SizeTrackBar.Size = new System.Drawing.Size(138, 45);
            this.SizeTrackBar.SmallChange = 5;
            this.SizeTrackBar.TabIndex = 5;
            this.SizeTrackBar.ValueChanged += new System.EventHandler(this.SizeTrackBar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(71, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 6;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeLabel.Location = new System.Drawing.Point(71, 178);
            this.SizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(57, 17);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = "0.0 дм3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 358);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Дата поступления:";
            // 
            // GettingDatePicker
            // 
            this.GettingDatePicker.Location = new System.Drawing.Point(12, 377);
            this.GettingDatePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GettingDatePicker.Name = "GettingDatePicker";
            this.GettingDatePicker.Size = new System.Drawing.Size(128, 20);
            this.GettingDatePicker.TabIndex = 11;
            this.GettingDatePicker.ValueChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 410);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Количество:";
            // 
            // InventoryNumberMaskedTextBox
            // 
            this.InventoryNumberMaskedTextBox.Location = new System.Drawing.Point(10, 147);
            this.InventoryNumberMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InventoryNumberMaskedTextBox.Name = "InventoryNumberMaskedTextBox";
            this.InventoryNumberMaskedTextBox.Size = new System.Drawing.Size(132, 20);
            this.InventoryNumberMaskedTextBox.TabIndex = 14;
            this.InventoryNumberMaskedTextBox.Click += new System.EventHandler(this.InventoryNumberMaskedTextBox_Click);
            this.InventoryNumberMaskedTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 448);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Цена (BYN):";
            // 
            // PriceMaskedTextBox
            // 
            this.PriceMaskedTextBox.Location = new System.Drawing.Point(13, 478);
            this.PriceMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PriceMaskedTextBox.Name = "PriceMaskedTextBox";
            this.PriceMaskedTextBox.Size = new System.Drawing.Size(128, 20);
            this.PriceMaskedTextBox.TabIndex = 16;
            this.PriceMaskedTextBox.Click += new System.EventHandler(this.PriceMaskedTextBox_Click);
            this.PriceMaskedTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(421, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(269, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Название организации производителя:";
            // 
            // OrganizationNameTextBox
            // 
            this.OrganizationNameTextBox.Location = new System.Drawing.Point(424, 95);
            this.OrganizationNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OrganizationNameTextBox.Name = "OrganizationNameTextBox";
            this.OrganizationNameTextBox.Size = new System.Drawing.Size(256, 20);
            this.OrganizationNameTextBox.TabIndex = 18;
            this.OrganizationNameTextBox.Click += new System.EventHandler(this.OrganizationNameTextBox_Click);
            this.OrganizationNameTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(704, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Страна производства:";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(707, 95);
            this.CountryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(149, 20);
            this.CountryTextBox.TabIndex = 20;
            this.CountryTextBox.Click += new System.EventHandler(this.CountryTextBox_Click);
            this.CountryTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(421, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Адрес:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(704, 115);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Номер телефона:";
            // 
            // TelephoneNumberMaskedTextBox
            // 
            this.TelephoneNumberMaskedTextBox.Location = new System.Drawing.Point(707, 145);
            this.TelephoneNumberMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TelephoneNumberMaskedTextBox.Name = "TelephoneNumberMaskedTextBox";
            this.TelephoneNumberMaskedTextBox.Size = new System.Drawing.Size(149, 20);
            this.TelephoneNumberMaskedTextBox.TabIndex = 24;
            this.TelephoneNumberMaskedTextBox.Click += new System.EventHandler(this.TelephoneNumberMaskedTextBox_Click);
            this.TelephoneNumberMaskedTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(206, 77);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 26);
            this.label13.TabIndex = 25;
            this.label13.Text = "Характеристики";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(210, 107);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 26);
            this.label14.TabIndex = 26;
            this.label14.Text = "<<<Товара";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(176, 137);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(226, 26);
            this.label15.TabIndex = 27;
            this.label15.Text = "Производителя>>>";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(9, 509);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(152, 35);
            this.SaveButton.TabIndex = 29;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OutputButton
            // 
            this.OutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputButton.Location = new System.Drawing.Point(10, 549);
            this.OutputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(152, 35);
            this.OutputButton.TabIndex = 30;
            this.OutputButton.Text = "Вывести";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(181, 178);
            this.ListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(675, 407);
            this.ListBox.TabIndex = 31;
            // 
            // NumberMaskedTextBox
            // 
            this.NumberMaskedTextBox.Location = new System.Drawing.Point(11, 428);
            this.NumberMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NumberMaskedTextBox.Name = "NumberMaskedTextBox";
            this.NumberMaskedTextBox.Size = new System.Drawing.Size(128, 20);
            this.NumberMaskedTextBox.TabIndex = 32;
            this.NumberMaskedTextBox.Click += new System.EventHandler(this.NumberMaskedTextBox_Click);
            this.NumberMaskedTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // InputAdressButton
            // 
            this.InputAdressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputAdressButton.Location = new System.Drawing.Point(424, 140);
            this.InputAdressButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputAdressButton.Name = "InputAdressButton";
            this.InputAdressButton.Size = new System.Drawing.Size(255, 28);
            this.InputAdressButton.TabIndex = 33;
            this.InputAdressButton.Text = "Ввести адрес";
            this.InputAdressButton.UseVisualStyleBackColor = true;
            this.InputAdressButton.Click += new System.EventHandler(this.InputAdressButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(10, 257);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 17);
            this.label16.TabIndex = 34;
            this.label16.Text = "Масса (г):";
            // 
            // WeightMaskedTextBox
            // 
            this.WeightMaskedTextBox.Location = new System.Drawing.Point(13, 275);
            this.WeightMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WeightMaskedTextBox.Name = "WeightMaskedTextBox";
            this.WeightMaskedTextBox.Size = new System.Drawing.Size(128, 20);
            this.WeightMaskedTextBox.TabIndex = 35;
            this.WeightMaskedTextBox.Click += new System.EventHandler(this.WeightMaskedTextBox_Click);
            this.WeightMaskedTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(36, 1);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 17);
            this.radioButton1.TabIndex = 36;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Промышленный";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(36, 23);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 17);
            this.radioButton2.TabIndex = 37;
            this.radioButton2.Text = "Потребительский";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(9, 306);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(150, 50);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.закрепитьToolStripMenuItem,
            this.открепитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseEnter += new System.EventHandler(this.menuStrip1_MouseEnter);
            this.menuStrip1.MouseLeave += new System.EventHandler(this.menuStrip1_MouseLeave);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Visible = false;
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поДатеПоступленияToolStripMenuItem,
            this.поСтранеПроизводителяToolStripMenuItem,
            this.поToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            this.сортировкаToolStripMenuItem.Visible = false;
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // поДатеПоступленияToolStripMenuItem
            // 
            this.поДатеПоступленияToolStripMenuItem.Name = "поДатеПоступленияToolStripMenuItem";
            this.поДатеПоступленияToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.поДатеПоступленияToolStripMenuItem.Text = "По дате поступления";
            this.поДатеПоступленияToolStripMenuItem.Click += new System.EventHandler(this.поДатеПоступленияToolStripMenuItem_Click);
            // 
            // поСтранеПроизводителяToolStripMenuItem
            // 
            this.поСтранеПроизводителяToolStripMenuItem.Name = "поСтранеПроизводителяToolStripMenuItem";
            this.поСтранеПроизводителяToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.поСтранеПроизводителяToolStripMenuItem.Text = "По стране производителя";
            this.поСтранеПроизводителяToolStripMenuItem.Click += new System.EventHandler(this.поСтранеПроизводителяToolStripMenuItem_Click);
            // 
            // поToolStripMenuItem
            // 
            this.поToolStripMenuItem.Name = "поToolStripMenuItem";
            this.поToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.поToolStripMenuItem.Text = "По названию";
            this.поToolStripMenuItem.Click += new System.EventHandler(this.поToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Visible = false;
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Visible = false;
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Visible = false;
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Visible = false;
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // закрепитьToolStripMenuItem
            // 
            this.закрепитьToolStripMenuItem.Name = "закрепитьToolStripMenuItem";
            this.закрепитьToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.закрепитьToolStripMenuItem.Text = "Закрепить";
            this.закрепитьToolStripMenuItem.Visible = false;
            this.закрепитьToolStripMenuItem.Click += new System.EventHandler(this.закрепитьToolStripMenuItem_Click);
            // 
            // открепитьToolStripMenuItem
            // 
            this.открепитьToolStripMenuItem.Name = "открепитьToolStripMenuItem";
            this.открепитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.открепитьToolStripMenuItem.Text = "Открепить";
            this.открепитьToolStripMenuItem.Visible = false;
            this.открепитьToolStripMenuItem.Click += new System.EventHandler(this.открепитьToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Состояние:";
            // 
            // SostLabel
            // 
            this.SostLabel.AutoSize = true;
            this.SostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SostLabel.Location = new System.Drawing.Point(80, 35);
            this.SostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SostLabel.Name = "SostLabel";
            this.SostLabel.Size = new System.Drawing.Size(16, 13);
            this.SostLabel.TabIndex = 41;
            this.SostLabel.Text = "...";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 594);
            this.Controls.Add(this.SostLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WeightMaskedTextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.InputAdressButton);
            this.Controls.Add(this.NumberMaskedTextBox);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TelephoneNumberMaskedTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.OrganizationNameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PriceMaskedTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.InventoryNumberMaskedTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GettingDatePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SizeTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button InputAdressButton;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox ProductNameTextBox;
        internal System.Windows.Forms.DateTimePicker GettingDatePicker;
        internal System.Windows.Forms.MaskedTextBox InventoryNumberMaskedTextBox;
        internal System.Windows.Forms.MaskedTextBox PriceMaskedTextBox;
        internal System.Windows.Forms.TextBox OrganizationNameTextBox;
        internal System.Windows.Forms.TextBox CountryTextBox;
        internal System.Windows.Forms.MaskedTextBox TelephoneNumberMaskedTextBox;
        internal System.Windows.Forms.MaskedTextBox NumberMaskedTextBox;
        internal System.Windows.Forms.MaskedTextBox WeightMaskedTextBox;
        internal System.Windows.Forms.TrackBar SizeTrackBar;
        internal System.Windows.Forms.RadioButton radioButton1;
        internal System.Windows.Forms.RadioButton radioButton2;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрепитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поДатеПоступленияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поСтранеПроизводителяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открепитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SostLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

