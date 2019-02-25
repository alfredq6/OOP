using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Введите индекс";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите индекс" || textBox1.Text == "")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            bool isNumber = true;
            try
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (!(textBox1.Text[i] >= '0' && textBox1.Text[i] <= '9'))
                    {
                        isNumber = false;
                        break;
                    }
                }
                if (isNumber)
                {
                    if (Convert.ToInt32(textBox1.Text) - 1 < ReturnData.stringReturn.Length && Convert.ToInt32(textBox1.Text) > 0)
                    {
                        ReturnData.stringReturn2 = ReturnData.stringReturn[Convert.ToInt32(textBox1.Text) - 1].ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        ReturnData.stringReturn2 = "Индекс находится вне границ длины строки";
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    ReturnData.stringReturn2 = "Необходимо ввести целочисленный индекс";
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
