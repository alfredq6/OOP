namespace WindowsFormsApp2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchByNameTextBox = new System.Windows.Forms.TextBox();
            this.TypeSearchComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PriceFromMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PriceToMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SearchListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "По названию";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(196, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "По типу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(342, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "По цене";
            // 
            // SearchByNameTextBox
            // 
            this.SearchByNameTextBox.Location = new System.Drawing.Point(19, 31);
            this.SearchByNameTextBox.Name = "SearchByNameTextBox";
            this.SearchByNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.SearchByNameTextBox.TabIndex = 3;
            // 
            // TypeSearchComboBox
            // 
            this.TypeSearchComboBox.FormattingEnabled = true;
            this.TypeSearchComboBox.Location = new System.Drawing.Point(167, 31);
            this.TypeSearchComboBox.Name = "TypeSearchComboBox";
            this.TypeSearchComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeSearchComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(379, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "до:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(319, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "от:";
            // 
            // PriceFromMaskedTextBox
            // 
            this.PriceFromMaskedTextBox.Location = new System.Drawing.Point(340, 31);
            this.PriceFromMaskedTextBox.Name = "PriceFromMaskedTextBox";
            this.PriceFromMaskedTextBox.Size = new System.Drawing.Size(33, 20);
            this.PriceFromMaskedTextBox.TabIndex = 7;
            this.PriceFromMaskedTextBox.Click += new System.EventHandler(this.PriceFromMaskedTextBox_Click);
            // 
            // PriceToMaskedTextBox
            // 
            this.PriceToMaskedTextBox.Location = new System.Drawing.Point(402, 31);
            this.PriceToMaskedTextBox.Name = "PriceToMaskedTextBox";
            this.PriceToMaskedTextBox.Size = new System.Drawing.Size(33, 20);
            this.PriceToMaskedTextBox.TabIndex = 8;
            this.PriceToMaskedTextBox.Click += new System.EventHandler(this.PriceToMaskedTextBox_Click);
            // 
            // SearchListBox
            // 
            this.SearchListBox.FormattingEnabled = true;
            this.SearchListBox.Location = new System.Drawing.Point(19, 108);
            this.SearchListBox.Name = "SearchListBox";
            this.SearchListBox.Size = new System.Drawing.Size(416, 329);
            this.SearchListBox.TabIndex = 9;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchButton.Location = new System.Drawing.Point(167, 70);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(121, 32);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(93, 443);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(121, 42);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(242, 443);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(121, 42);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 506);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchListBox);
            this.Controls.Add(this.PriceToMaskedTextBox);
            this.Controls.Add(this.PriceFromMaskedTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TypeSearchComboBox);
            this.Controls.Add(this.SearchByNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchByNameTextBox;
        private System.Windows.Forms.ComboBox TypeSearchComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox PriceFromMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox PriceToMaskedTextBox;
        private System.Windows.Forms.ListBox SearchListBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
    }
}