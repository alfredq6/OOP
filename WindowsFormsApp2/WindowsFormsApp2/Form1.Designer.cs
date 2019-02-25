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
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(17, 69);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(170, 22);
            this.ProductNameTextBox.TabIndex = 0;
            this.ProductNameTextBox.Click += new System.EventHandler(this.ProductNameTextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название товара:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Инвентарный номер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Размер:";
            // 
            // SizeTrackBar
            // 
            this.SizeTrackBar.LargeChange = 10;
            this.SizeTrackBar.Location = new System.Drawing.Point(13, 204);
            this.SizeTrackBar.Name = "SizeTrackBar";
            this.SizeTrackBar.Size = new System.Drawing.Size(184, 56);
            this.SizeTrackBar.SmallChange = 5;
            this.SizeTrackBar.TabIndex = 5;
            this.SizeTrackBar.ValueChanged += new System.EventHandler(this.SizeTrackBar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(95, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 6;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeLabel.Location = new System.Drawing.Point(95, 181);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(69, 20);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = "0.0 дм3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Тип:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(17, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Дата поступления:";
            // 
            // GettingDatePicker
            // 
            this.GettingDatePicker.Location = new System.Drawing.Point(17, 399);
            this.GettingDatePicker.Name = "GettingDatePicker";
            this.GettingDatePicker.Size = new System.Drawing.Size(169, 22);
            this.GettingDatePicker.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 446);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Количество:";
            // 
            // InventoryNumberMaskedTextBox
            // 
            this.InventoryNumberMaskedTextBox.Location = new System.Drawing.Point(13, 142);
            this.InventoryNumberMaskedTextBox.Name = "InventoryNumberMaskedTextBox";
            this.InventoryNumberMaskedTextBox.Size = new System.Drawing.Size(174, 22);
            this.InventoryNumberMaskedTextBox.TabIndex = 14;
            this.InventoryNumberMaskedTextBox.Click += new System.EventHandler(this.InventoryNumberMaskedTextBox_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 513);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Цена (BYN):";
            // 
            // PriceMaskedTextBox
            // 
            this.PriceMaskedTextBox.Location = new System.Drawing.Point(17, 536);
            this.PriceMaskedTextBox.Name = "PriceMaskedTextBox";
            this.PriceMaskedTextBox.Size = new System.Drawing.Size(169, 22);
            this.PriceMaskedTextBox.TabIndex = 16;
            this.PriceMaskedTextBox.Click += new System.EventHandler(this.PriceMaskedTextBox_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(561, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(344, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Название организации производителя:";
            // 
            // OrganizationNameTextBox
            // 
            this.OrganizationNameTextBox.Location = new System.Drawing.Point(565, 69);
            this.OrganizationNameTextBox.Name = "OrganizationNameTextBox";
            this.OrganizationNameTextBox.Size = new System.Drawing.Size(340, 22);
            this.OrganizationNameTextBox.TabIndex = 18;
            this.OrganizationNameTextBox.Click += new System.EventHandler(this.OrganizationNameTextBox_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(939, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Страна производства:";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(943, 69);
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(197, 22);
            this.CountryTextBox.TabIndex = 20;
            this.CountryTextBox.Click += new System.EventHandler(this.CountryTextBox_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(561, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Адрес:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(939, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Номер телефона:";
            // 
            // TelephoneNumberMaskedTextBox
            // 
            this.TelephoneNumberMaskedTextBox.Location = new System.Drawing.Point(943, 142);
            this.TelephoneNumberMaskedTextBox.Name = "TelephoneNumberMaskedTextBox";
            this.TelephoneNumberMaskedTextBox.Size = new System.Drawing.Size(197, 22);
            this.TelephoneNumberMaskedTextBox.TabIndex = 24;
            this.TelephoneNumberMaskedTextBox.Click += new System.EventHandler(this.TelephoneNumberMaskedTextBox_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(251, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 32);
            this.label13.TabIndex = 25;
            this.label13.Text = "Характеристики";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(276, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 32);
            this.label14.TabIndex = 26;
            this.label14.Text = "<<<Товара";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(235, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(284, 32);
            this.label15.TabIndex = 27;
            this.label15.Text = "Производителя>>>";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(13, 585);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(202, 43);
            this.SaveButton.TabIndex = 29;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OutputButton
            // 
            this.OutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputButton.Location = new System.Drawing.Point(13, 639);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(202, 43);
            this.OutputButton.TabIndex = 30;
            this.OutputButton.Text = "Вывести";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 16;
            this.ListBox.Location = new System.Drawing.Point(241, 182);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(899, 500);
            this.ListBox.TabIndex = 31;
            // 
            // NumberMaskedTextBox
            // 
            this.NumberMaskedTextBox.Location = new System.Drawing.Point(17, 469);
            this.NumberMaskedTextBox.Name = "NumberMaskedTextBox";
            this.NumberMaskedTextBox.Size = new System.Drawing.Size(170, 22);
            this.NumberMaskedTextBox.TabIndex = 32;
            this.NumberMaskedTextBox.Click += new System.EventHandler(this.NumberMaskedTextBox_Click);
            // 
            // InputAdressButton
            // 
            this.InputAdressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputAdressButton.Location = new System.Drawing.Point(565, 136);
            this.InputAdressButton.Name = "InputAdressButton";
            this.InputAdressButton.Size = new System.Drawing.Size(340, 34);
            this.InputAdressButton.TabIndex = 33;
            this.InputAdressButton.Text = "Ввести адрес";
            this.InputAdressButton.UseVisualStyleBackColor = true;
            this.InputAdressButton.Click += new System.EventHandler(this.InputAdressButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(13, 252);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 20);
            this.label16.TabIndex = 34;
            this.label16.Text = "Масса (г):";
            // 
            // WeightMaskedTextBox
            // 
            this.WeightMaskedTextBox.Location = new System.Drawing.Point(16, 275);
            this.WeightMaskedTextBox.Name = "WeightMaskedTextBox";
            this.WeightMaskedTextBox.Size = new System.Drawing.Size(170, 22);
            this.WeightMaskedTextBox.TabIndex = 35;
            this.WeightMaskedTextBox.Click += new System.EventHandler(this.WeightMaskedTextBox_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(48, 1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(135, 21);
            this.radioButton1.TabIndex = 36;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Промышленный";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(48, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(146, 21);
            this.radioButton2.TabIndex = 37;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Потребительский";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(15, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 61);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 731);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SizeTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductNameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label label5;
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
    }
}

