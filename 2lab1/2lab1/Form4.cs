using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Введите удаляемый символ";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите удаляемый символ" || textBox1.Text == "")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 1 && ReturnData.stringReturn != "")
                {
                    Regex regex = new Regex(textBox1.Text);
                    ReturnData.stringReturn2 = regex.Replace(ReturnData.stringReturn, "");
                    this.DialogResult = DialogResult.OK;
                }
                else if (textBox1.Text.Length == 1)
                {
                    ReturnData.stringReturn2 = "Необходимо ввести одиночный символ";
                    this.DialogResult = DialogResult.OK;
                }
                else if (ReturnData.stringReturn == "")
                {
                    ReturnData.stringReturn2 = "Ошибка: пустая строка";
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
