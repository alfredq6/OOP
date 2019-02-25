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
    public partial class TextCalculator : Form
    {
        public TextCalculator()
        {
            InitializeComponent();
        }
        Form2 f2 = new Form2();
        Form5 f5 = new Form5();
        Form4 f4 = new Form4();
        Form3 f3 = new Form3();
        Button button;
        List<string> list;
        string[] sentences;
        string[] words;
        private void Form1_Load(object sender, EventArgs e)
        {
            InputBox.ForeColor = Color.Gray;
            InputBox.Text = "Введите текст";
        }

        private void InputBox_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "Введите текст" || InputBox.Text == "")
            {
                InputBox.Text = "";
                InputBox.ForeColor = Color.Black;
            }
        }

        private void StringLengthButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text = InputBox.Text.Length.ToString();
        }
        

        private void VowelsNumberButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text = Regex.Matches(InputBox.Text, @"[уеыаоэяиёюaeyuio]", RegexOptions.IgnoreCase).Count.ToString();
        }

        private void ConsonantsNumberButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text = Regex.Matches(InputBox.Text, @"[qwrtpsdfghjklzxcvbnmйцкнгшщзхъфвпрлджчсмтьб]", RegexOptions.IgnoreCase).Count.ToString();
        }

        private void SentencesNumberButton_Click(object sender, EventArgs e)
        {
            try
            {
                list = new List<string>();
                sentences = InputBox.Text.Split('.');
                foreach (string sentence in sentences)
                {
                    if (sentence != "")
                    {
                        list.Add(sentence);
                    }
                }
                OutputBox.Text = list.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WordsNumberButton_Click(object sender, EventArgs e)
        {
            try
            {
                list = new List<string>();
                words = InputBox.Text.Split(' ');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        list.Add(word);
                    }
                }
                OutputBox.Text = list.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void EditSubstringsButtons_Click(object sender, EventArgs e)
        {
            button = (Button)sender;
            ReturnData.stringReturn = InputBox.Text;
            if (button.Name.ToString() == "ReplaceSubstringsButton")
            {
                f2.ShowDialog();
                if (f2.DialogResult == DialogResult.OK) OutputBox.Text = ReturnData.stringReturn2;
            }
            if (button.Name.ToString() == "DeleteSubstringButton")
            {
                f3.ShowDialog();
                if (f3.DialogResult == DialogResult.OK) OutputBox.Text = ReturnData.stringReturn2;
            }
            if (button.Name.ToString() == "DeleteSymbolButton")
            {
                f4.ShowDialog();
                if (f4.DialogResult == DialogResult.OK) OutputBox.Text = ReturnData.stringReturn2;
            }
            if (button.Name.ToString() == "GetSymbolByIndexButton")
            {
                f5.ShowDialog();
                if (f5.DialogResult == DialogResult.OK) OutputBox.Text = ReturnData.stringReturn2;
            }
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public static class ReturnData
    {
        public static string stringReturn = "";
        public static string stringReturn2 = "";
    }
}
