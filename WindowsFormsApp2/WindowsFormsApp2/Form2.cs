using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        static bool IsReady = true;
        static Form1 form1 = new Form1();
        public Form2()
        {
            InitializeComponent();
            HouseMaskedTextBox.Mask = "000";
        }

        private void OK_Click(object sender, EventArgs e)
        {
            IsReady = true;
            if (CityTextBox.TextLength == 0)
            {
                CityTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (StreetTextBox.TextLength == 0)
            {
                StreetTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (HouseMaskedTextBox.Text == "")
            {
                HouseMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (IsReady)
            {
                
                DialogResult = DialogResult.OK;
            }
        }

        private void CityTextBox_Click(object sender, EventArgs e)
        {
            CityTextBox.BackColor = Color.Empty;
        }

        private void StreetTextBox_Click(object sender, EventArgs e)
        {
            StreetTextBox.BackColor = Color.Empty;
        }

        private void HouseMaskedTextBox_Click(object sender, EventArgs e)
        {
            HouseMaskedTextBox.SelectionStart = 0;
            HouseMaskedTextBox.BackColor = Color.Empty;
        }
    }
}
