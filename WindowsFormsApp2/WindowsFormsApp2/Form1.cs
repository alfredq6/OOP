using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        static bool IsReady = true;

        List<Product> products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            InventoryNumberMaskedTextBox.Mask = "0000000";
            NumberMaskedTextBox.Mask = "000";
            PriceMaskedTextBox.Mask = "0000";
            TelephoneNumberMaskedTextBox.Mask = "(999) 000-0000";
            WeightMaskedTextBox.Mask = "000000";
            SizeTrackBar.Maximum = 10000;
            SizeTrackBar.TickFrequency = 1000;
            SizeTrackBar.SmallChange = 1000;
            radioButton1.Checked = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            IsReady = true;
            if (ProductNameTextBox.TextLength == 0)
            {
                ProductNameTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (!InventoryNumberMaskedTextBox.MaskCompleted)
            {
                InventoryNumberMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (SizeTrackBar.Value == 0)
            {
                SizeLabel.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (NumberMaskedTextBox.Text == "")
            {
                NumberMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (PriceMaskedTextBox.Text == "")
            {
                PriceMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (!TelephoneNumberMaskedTextBox.MaskCompleted)
            {
                TelephoneNumberMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (OrganizationNameTextBox.Text == "")
            {
                OrganizationNameTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (CountryTextBox.Text == "")
            {
                CountryTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (form2.DialogResult != DialogResult.OK)
            {
                InputAdressButton.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (WeightMaskedTextBox.Text == "")
            {
                WeightMaskedTextBox.BackColor = Color.IndianRed;
                IsReady = false;
            }
            if (IsReady)
            {
                Product product = new Product(this, form2);
                products.Add(product);
                XmlSerializer formater = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream("products.xml", FileMode.Create))
                {
                    formater.Serialize(fs, products);
                }
            }
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            List<Product> desProducts;
            using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
                desProducts = (List<Product>)formatter.Deserialize(fs);
            }
            if (desProducts != null)
            {
                foreach (Product el in desProducts)
                {
                    ListBox.Items.Add($"Название товара: {el._Name}");
                    ListBox.Items.Add($"Инвентарный номер: {el.InventoryNumber}");
                    ListBox.Items.Add($"Размер: {el._Size}");
                    ListBox.Items.Add($"Вес: {el.Weight}");
                    ListBox.Items.Add($"Тип: {el._Type}");
                    ListBox.Items.Add($"Дата поставки: {el.GettingDate}");
                    ListBox.Items.Add($"Количество: {el.Number}");
                    ListBox.Items.Add($"Цена: {el.Price}");
                    ListBox.Items.Add($"Название организации-производителя: {el.producer.OrganizationName}");
                    ListBox.Items.Add($"Страна: {el.producer.Country}");
                    ListBox.Items.Add($"Адрес: {el.producer.Adress}");
                    ListBox.Items.Add($"Номер телефона: {el.producer.TelephoneNumber}");
                    ListBox.Items.Add("__________________________________________________________________________________________________________________");
                }
            }
        }

        private void ProductNameTextBox_Click(object sender, EventArgs e)
        {
            ProductNameTextBox.BackColor = Color.Empty;
        }

        private void InventoryNumberMaskedTextBox_Click(object sender, EventArgs e)
        {
            InventoryNumberMaskedTextBox.SelectionStart = 0;
            InventoryNumberMaskedTextBox.BackColor = Color.Empty;
        }

        private void SizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SizeLabel.BackColor = Color.Empty;
            SizeLabel.Text = SizeTrackBar.Value.ToString() + " дм3";
        }

        private void TypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void NumberMaskedTextBox_Click(object sender, EventArgs e)
        {
            NumberMaskedTextBox.SelectionStart = 0;
            NumberMaskedTextBox.BackColor = Color.Empty;
        }

        private void PriceMaskedTextBox_Click(object sender, EventArgs e)
        {
            PriceMaskedTextBox.SelectionStart = 0;
            PriceMaskedTextBox.BackColor = Color.Empty;
        }

        private void TelephoneNumberMaskedTextBox_Click(object sender, EventArgs e)
        {
            TelephoneNumberMaskedTextBox.SelectionStart = 0;
            TelephoneNumberMaskedTextBox.BackColor = Color.Empty;
        }

        private void OrganizationNameTextBox_Click(object sender, EventArgs e)
        {
            OrganizationNameTextBox.SelectionStart = 0;
            OrganizationNameTextBox.BackColor = Color.Empty;
        }

        private void CountryTextBox_Click(object sender, EventArgs e)
        {
            CountryTextBox.SelectionStart = 0;
            CountryTextBox.BackColor = Color.Empty;
        }

        private void InputAdressButton_Click(object sender, EventArgs e)
        {
            InputAdressButton.BackColor = Color.Empty;
            form2.ShowDialog();
        }

        private void WeightMaskedTextBox_Click(object sender, EventArgs e)
        {
            WeightMaskedTextBox.SelectionStart = 0;
            WeightMaskedTextBox.BackColor = Color.Empty;
        }
    }
}
