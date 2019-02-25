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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Введите удаляемую подстроку";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите удаляемую подстроку" || textBox1.Text == "")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(textBox1.Text);
                if (ReturnData.stringReturn != "")
                {
                    ReturnData.stringReturn2 = regex.Replace(ReturnData.stringReturn, "");
                    this.DialogResult = DialogResult.OK;
                }
                else
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
