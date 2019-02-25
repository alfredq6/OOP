namespace _2lab1
{
    partial class TextCalculator
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
            this.InputBox = new System.Windows.Forms.TextBox();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.ReplaceSubstringsButton = new System.Windows.Forms.Button();
            this.DeleteSubstringButton = new System.Windows.Forms.Button();
            this.DeleteSymbolButton = new System.Windows.Forms.Button();
            this.StringLengthButton = new System.Windows.Forms.Button();
            this.ConsonantsNumberButton = new System.Windows.Forms.Button();
            this.WordsNumberButton = new System.Windows.Forms.Button();
            this.GetSymbolByIndexButton = new System.Windows.Forms.Button();
            this.VowelsNumberButton = new System.Windows.Forms.Button();
            this.SentencesNumberButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(12, 54);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(624, 20);
            this.InputBox.TabIndex = 1;
            this.InputBox.Click += new System.EventHandler(this.InputBox_Click);
            this.InputBox.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.Color.White;
            this.OutputBox.Enabled = false;
            this.OutputBox.Location = new System.Drawing.Point(13, 155);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(623, 20);
            this.OutputBox.TabIndex = 2;
            // 
            // ReplaceSubstringsButton
            // 
            this.ReplaceSubstringsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ReplaceSubstringsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplaceSubstringsButton.Location = new System.Drawing.Point(12, 244);
            this.ReplaceSubstringsButton.Name = "ReplaceSubstringsButton";
            this.ReplaceSubstringsButton.Size = new System.Drawing.Size(203, 82);
            this.ReplaceSubstringsButton.TabIndex = 3;
            this.ReplaceSubstringsButton.Text = "Замена подстроки на другую подстроку";
            this.ReplaceSubstringsButton.UseVisualStyleBackColor = false;
            this.ReplaceSubstringsButton.Click += new System.EventHandler(this.EditSubstringsButtons_Click);
            // 
            // DeleteSubstringButton
            // 
            this.DeleteSubstringButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteSubstringButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteSubstringButton.Location = new System.Drawing.Point(221, 244);
            this.DeleteSubstringButton.Name = "DeleteSubstringButton";
            this.DeleteSubstringButton.Size = new System.Drawing.Size(206, 82);
            this.DeleteSubstringButton.TabIndex = 4;
            this.DeleteSubstringButton.Text = "Удаление подстроки";
            this.DeleteSubstringButton.UseVisualStyleBackColor = false;
            this.DeleteSubstringButton.Click += new System.EventHandler(this.EditSubstringsButtons_Click);
            // 
            // DeleteSymbolButton
            // 
            this.DeleteSymbolButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteSymbolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteSymbolButton.Location = new System.Drawing.Point(433, 244);
            this.DeleteSymbolButton.Name = "DeleteSymbolButton";
            this.DeleteSymbolButton.Size = new System.Drawing.Size(203, 82);
            this.DeleteSymbolButton.TabIndex = 5;
            this.DeleteSymbolButton.Text = "Удаление символа";
            this.DeleteSymbolButton.UseVisualStyleBackColor = false;
            this.DeleteSymbolButton.Click += new System.EventHandler(this.EditSubstringsButtons_Click);
            // 
            // StringLengthButton
            // 
            this.StringLengthButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StringLengthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringLengthButton.Location = new System.Drawing.Point(13, 471);
            this.StringLengthButton.Name = "StringLengthButton";
            this.StringLengthButton.Size = new System.Drawing.Size(203, 82);
            this.StringLengthButton.TabIndex = 6;
            this.StringLengthButton.Text = "Длина строки";
            this.StringLengthButton.UseVisualStyleBackColor = false;
            this.StringLengthButton.Click += new System.EventHandler(this.StringLengthButton_Click);
            // 
            // ConsonantsNumberButton
            // 
            this.ConsonantsNumberButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConsonantsNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsonantsNumberButton.Location = new System.Drawing.Point(221, 471);
            this.ConsonantsNumberButton.Name = "ConsonantsNumberButton";
            this.ConsonantsNumberButton.Size = new System.Drawing.Size(206, 82);
            this.ConsonantsNumberButton.TabIndex = 7;
            this.ConsonantsNumberButton.Text = "Количество согласных";
            this.ConsonantsNumberButton.UseVisualStyleBackColor = false;
            this.ConsonantsNumberButton.Click += new System.EventHandler(this.ConsonantsNumberButton_Click);
            // 
            // WordsNumberButton
            // 
            this.WordsNumberButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.WordsNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordsNumberButton.Location = new System.Drawing.Point(433, 471);
            this.WordsNumberButton.Name = "WordsNumberButton";
            this.WordsNumberButton.Size = new System.Drawing.Size(203, 82);
            this.WordsNumberButton.TabIndex = 8;
            this.WordsNumberButton.Text = "Количество слов";
            this.WordsNumberButton.UseVisualStyleBackColor = false;
            this.WordsNumberButton.Click += new System.EventHandler(this.WordsNumberButton_Click);
            // 
            // GetSymbolByIndexButton
            // 
            this.GetSymbolByIndexButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GetSymbolByIndexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetSymbolByIndexButton.Location = new System.Drawing.Point(13, 356);
            this.GetSymbolByIndexButton.Name = "GetSymbolByIndexButton";
            this.GetSymbolByIndexButton.Size = new System.Drawing.Size(203, 82);
            this.GetSymbolByIndexButton.TabIndex = 9;
            this.GetSymbolByIndexButton.Text = "Получение символа по индексу";
            this.GetSymbolByIndexButton.UseVisualStyleBackColor = false;
            this.GetSymbolByIndexButton.Click += new System.EventHandler(this.EditSubstringsButtons_Click);
            // 
            // VowelsNumberButton
            // 
            this.VowelsNumberButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.VowelsNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VowelsNumberButton.Location = new System.Drawing.Point(221, 356);
            this.VowelsNumberButton.Name = "VowelsNumberButton";
            this.VowelsNumberButton.Size = new System.Drawing.Size(206, 82);
            this.VowelsNumberButton.TabIndex = 10;
            this.VowelsNumberButton.Text = "Количество гласных";
            this.VowelsNumberButton.UseVisualStyleBackColor = false;
            this.VowelsNumberButton.Click += new System.EventHandler(this.VowelsNumberButton_Click);
            // 
            // SentencesNumberButton
            // 
            this.SentencesNumberButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SentencesNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SentencesNumberButton.Location = new System.Drawing.Point(433, 356);
            this.SentencesNumberButton.Name = "SentencesNumberButton";
            this.SentencesNumberButton.Size = new System.Drawing.Size(203, 82);
            this.SentencesNumberButton.TabIndex = 11;
            this.SentencesNumberButton.Text = "Количество предложений";
            this.SentencesNumberButton.UseVisualStyleBackColor = false;
            this.SentencesNumberButton.Click += new System.EventHandler(this.SentencesNumberButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("GOST Type AU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "Поле ввода";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("GOST Type AU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "Поле вывода";
            // 
            // TextCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(648, 565);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SentencesNumberButton);
            this.Controls.Add(this.VowelsNumberButton);
            this.Controls.Add(this.GetSymbolByIndexButton);
            this.Controls.Add(this.WordsNumberButton);
            this.Controls.Add(this.ConsonantsNumberButton);
            this.Controls.Add(this.StringLengthButton);
            this.Controls.Add(this.DeleteSymbolButton);
            this.Controls.Add(this.DeleteSubstringButton);
            this.Controls.Add(this.ReplaceSubstringsButton);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.InputBox);
            this.Name = "TextCalculator";
            this.Text = "TextCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReplaceSubstringsButton;
        private System.Windows.Forms.Button DeleteSubstringButton;
        private System.Windows.Forms.Button DeleteSymbolButton;
        private System.Windows.Forms.Button StringLengthButton;
        private System.Windows.Forms.Button ConsonantsNumberButton;
        private System.Windows.Forms.Button WordsNumberButton;
        private System.Windows.Forms.Button GetSymbolByIndexButton;
        private System.Windows.Forms.Button VowelsNumberButton;
        private System.Windows.Forms.Button SentencesNumberButton;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

