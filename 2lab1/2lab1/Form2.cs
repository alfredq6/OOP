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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox1.Text = "Введите заменяемую подстроку";
            textBox2.Text = "Введите заменяющую подстроку";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите заменяемую подстроку" || textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите заменяющую подстроку" || textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(textBox1.Text);
                ReturnData.stringReturn2 = regex.Replace(ReturnData.stringReturn, textBox2.Text);
                this.DialogResult = DialogResult.OK;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
