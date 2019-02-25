namespace _2lab1._2
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
            this.SortAscendingButton = new System.Windows.Forms.Button();
            this.AverageButton = new System.Windows.Forms.Button();
            this.SortDescendingButton = new System.Windows.Forms.Button();
            this.MaxButton = new System.Windows.Forms.Button();
            this.MinButton = new System.Windows.Forms.Button();
            this.GenerateCollectionButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CollectionElementsListBox = new System.Windows.Forms.ListBox();
            this.RequestCollectionElementsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SortAscendingButton
            // 
            this.SortAscendingButton.Location = new System.Drawing.Point(70, 105);
            this.SortAscendingButton.Name = "SortAscendingButton";
            this.SortAscendingButton.Size = new System.Drawing.Size(179, 70);
            this.SortAscendingButton.TabIndex = 0;
            this.SortAscendingButton.Text = "Сортировать по возрастанию";
            this.SortAscendingButton.UseVisualStyleBackColor = true;
            this.SortAscendingButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // AverageButton
            // 
            this.AverageButton.Location = new System.Drawing.Point(353, 225);
            this.AverageButton.Name = "AverageButton";
            this.AverageButton.Size = new System.Drawing.Size(115, 63);
            this.AverageButton.TabIndex = 1;
            this.AverageButton.Text = "Среднее значение";
            this.AverageButton.UseVisualStyleBackColor = true;
            this.AverageButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // SortDescendingButton
            // 
            this.SortDescendingButton.Location = new System.Drawing.Point(567, 105);
            this.SortDescendingButton.Name = "SortDescendingButton";
            this.SortDescendingButton.Size = new System.Drawing.Size(179, 70);
            this.SortDescendingButton.TabIndex = 2;
            this.SortDescendingButton.Text = "Сортировать по убыванию";
            this.SortDescendingButton.UseVisualStyleBackColor = true;
            this.SortDescendingButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // MaxButton
            // 
            this.MaxButton.Location = new System.Drawing.Point(105, 225);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(110, 63);
            this.MaxButton.TabIndex = 3;
            this.MaxButton.Text = "Максимальный элемент";
            this.MaxButton.UseVisualStyleBackColor = true;
            this.MaxButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // MinButton
            // 
            this.MinButton.Location = new System.Drawing.Point(600, 225);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(108, 63);
            this.MinButton.TabIndex = 4;
            this.MinButton.Text = "Минимальный элемент";
            this.MinButton.UseVisualStyleBackColor = true;
            this.MinButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // GenerateCollectionButton
            // 
            this.GenerateCollectionButton.Location = new System.Drawing.Point(280, 105);
            this.GenerateCollectionButton.Name = "GenerateCollectionButton";
            this.GenerateCollectionButton.Size = new System.Drawing.Size(259, 70);
            this.GenerateCollectionButton.TabIndex = 5;
            this.GenerateCollectionButton.Text = "Сгенерировать коллекцию";
            this.GenerateCollectionButton.UseVisualStyleBackColor = true;
            this.GenerateCollectionButton.Click += new System.EventHandler(this.GenerateCollectionButton_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(353, 53);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(100, 20);
            this.InputBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Размер коллекции";
            // 
            // CollectionElementsListBox
            // 
            this.CollectionElementsListBox.FormattingEnabled = true;
            this.CollectionElementsListBox.Location = new System.Drawing.Point(70, 313);
            this.CollectionElementsListBox.Name = "CollectionElementsListBox";
            this.CollectionElementsListBox.Size = new System.Drawing.Size(284, 199);
            this.CollectionElementsListBox.TabIndex = 8;
            // 
            // RequestCollectionElementsListBox
            // 
            this.RequestCollectionElementsListBox.FormattingEnabled = true;
            this.RequestCollectionElementsListBox.Location = new System.Drawing.Point(470, 313);
            this.RequestCollectionElementsListBox.Name = "RequestCollectionElementsListBox";
            this.RequestCollectionElementsListBox.Size = new System.Drawing.Size(276, 199);
            this.RequestCollectionElementsListBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.RequestCollectionElementsListBox);
            this.Controls.Add(this.CollectionElementsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.GenerateCollectionButton);
            this.Controls.Add(this.MinButton);
            this.Controls.Add(this.MaxButton);
            this.Controls.Add(this.SortDescendingButton);
            this.Controls.Add(this.AverageButton);
            this.Controls.Add(this.SortAscendingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SortAscendingButton;
        private System.Windows.Forms.Button AverageButton;
        private System.Windows.Forms.Button SortDescendingButton;
        private System.Windows.Forms.Button MaxButton;
        private System.Windows.Forms.Button MinButton;
        private System.Windows.Forms.Button GenerateCollectionButton;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CollectionElementsListBox;
        private System.Windows.Forms.ListBox RequestCollectionElementsListBox;
    }
}

