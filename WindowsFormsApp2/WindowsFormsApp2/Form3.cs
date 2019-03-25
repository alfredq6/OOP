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
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        List<XElement> ListOfProducts = new List<XElement>();
        public Form3()
        {
            InitializeComponent();
            TypeSearchComboBox.Items.Add("Промышленный");
            TypeSearchComboBox.Items.Add("Потребительский");
            PriceFromMaskedTextBox.Mask = "0000";
            PriceToMaskedTextBox.Mask = "0000";
        }

        private void PriceFromMaskedTextBox_Click(object sender, EventArgs e)
        {
            PriceFromMaskedTextBox.SelectionStart = 0;
        }

        private void PriceToMaskedTextBox_Click(object sender, EventArgs e)
        {
            PriceToMaskedTextBox.SelectionStart = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                ListOfProducts.Clear();
                SearchListBox.Items.Clear();
                XDocument xDoc = XDocument.Load("products.xml");
                foreach (XElement element in xDoc.Root.Elements("Product").ToList())
                {
                    if (TypeSearchComboBox.Text == "" && (PriceFromMaskedTextBox.Text == "" || PriceToMaskedTextBox.Text == "") && SearchByNameTextBox.Text != "")
                        if (Regex.IsMatch(element.Element("Name").Value, string.Format(@"\w*{0}\w*", SearchByNameTextBox.Text)) && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text != "" && (PriceFromMaskedTextBox.Text == "" || PriceToMaskedTextBox.Text == "") && SearchByNameTextBox.Text == "")
                        if (element.Element("Type").Value == TypeSearchComboBox.Text && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text == "" && (PriceFromMaskedTextBox.Text != "" && PriceToMaskedTextBox.Text != "") && SearchByNameTextBox.Text == "")
                        if (!(PriceToMaskedTextBox.Text.StartsWith("0") && PriceToMaskedTextBox.TextLength > 1)
                        && !(PriceFromMaskedTextBox.Text.StartsWith("0") && PriceFromMaskedTextBox.TextLength > 1)
                        && Int32.Parse(element.Element("Price").Value) >= Int32.Parse(PriceFromMaskedTextBox.Text)
                        && Int32.Parse(element.Element("Price").Value) <= Int32.Parse(PriceToMaskedTextBox.Text)
                        && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text != "" && (PriceFromMaskedTextBox.Text == "" || PriceToMaskedTextBox.Text == "") && SearchByNameTextBox.Text != "")
                        if (Regex.IsMatch(element.Element("Name").Value, string.Format(@"\w*{0}\w*", SearchByNameTextBox.Text))
                            && element.Element("Type").Value == TypeSearchComboBox.Text && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text != "" && (PriceFromMaskedTextBox.Text != "" && PriceToMaskedTextBox.Text != "") && SearchByNameTextBox.Text == "")
                        if (!(PriceToMaskedTextBox.Text.StartsWith("0") && PriceToMaskedTextBox.TextLength > 1)
                        && !(PriceFromMaskedTextBox.Text.StartsWith("0") && PriceFromMaskedTextBox.TextLength > 1)
                        && Int32.Parse(element.Element("Price").Value) >= Int32.Parse(PriceFromMaskedTextBox.Text)
                        && Int32.Parse(element.Element("Price").Value) <= Int32.Parse(PriceToMaskedTextBox.Text)
                        && element.Element("Type").Value == TypeSearchComboBox.Text && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text == "" && (PriceFromMaskedTextBox.Text != "" && PriceToMaskedTextBox.Text != "") && SearchByNameTextBox.Text != "")
                        if (!(PriceToMaskedTextBox.Text.StartsWith("0") && PriceToMaskedTextBox.TextLength > 1)
                        && !(PriceFromMaskedTextBox.Text.StartsWith("0") && PriceFromMaskedTextBox.TextLength > 1)
                        && Int32.Parse(element.Element("Price").Value) >= Int32.Parse(PriceFromMaskedTextBox.Text)
                        && Int32.Parse(element.Element("Price").Value) <= Int32.Parse(PriceToMaskedTextBox.Text)
                        && Regex.IsMatch(element.Element("Name").Value, string.Format(@"\w*{0}\w*", SearchByNameTextBox.Text)) && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                    if (TypeSearchComboBox.Text != "" && (PriceFromMaskedTextBox.Text != "" && PriceToMaskedTextBox.Text != "") && SearchByNameTextBox.Text != "")
                        if (!(PriceToMaskedTextBox.Text.StartsWith("0") && PriceToMaskedTextBox.TextLength > 1)
                        && !(PriceFromMaskedTextBox.Text.StartsWith("0") && PriceFromMaskedTextBox.TextLength > 1)
                        && Int32.Parse(element.Element("Price").Value) >= Int32.Parse(PriceFromMaskedTextBox.Text)
                        && Int32.Parse(element.Element("Price").Value) <= Int32.Parse(PriceToMaskedTextBox.Text)
                        && Regex.IsMatch(element.Element("Name").Value, string.Format(@"\w*{0}\w*", SearchByNameTextBox.Text))
                        && element.Element("Type").Value == TypeSearchComboBox.Text && !ListOfProducts.Contains(element))
                            ListOfProducts.Add(element);
                }
                if (ListOfProducts.Count() != 0)
                {
                    foreach (XElement el in ListOfProducts)
                    {
                        SearchListBox.Items.Add($"Название товара: {el.Element("Name").Value}");
                        SearchListBox.Items.Add($"Инвентарный номер: {el.Element("InventoryNumber").Value}");
                        SearchListBox.Items.Add($"Размер: {el.Element("Size").Value}");
                        SearchListBox.Items.Add($"Вес: {el.Element("Weight").Value}");
                        SearchListBox.Items.Add($"Тип: {el.Element("Type").Value}");
                        SearchListBox.Items.Add($"Дата поставки: {el.Element("GettingDate").Value}");
                        SearchListBox.Items.Add($"Количество: {el.Element("Number").Value}");
                        SearchListBox.Items.Add($"Цена: {el.Element("Price").Value}");
                        SearchListBox.Items.Add($"Название организации-производителя: {el.Element("producer").Element("OrganizationName")}");
                        SearchListBox.Items.Add($"Страна: {el.Element("producer").Element("Country")}");
                        SearchListBox.Items.Add($"Адрес: {el.Element("producer").Element("Adress")}");
                        SearchListBox.Items.Add($"Номер телефона: {el.Element("producer").Element("TelephoneNumber")}");
                        SearchListBox.Items.Add("__________________________________________________________________________________________________________________");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("sortedOrSearchedProducts.xml", FileMode.Create))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<XElement>));
                    formatter.Serialize(fs, ListOfProducts);
                }
            }
            catch (Exception) { }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            SearchListBox.Items.Clear();
            SearchByNameTextBox.Clear();
            PriceFromMaskedTextBox.Clear();
            PriceToMaskedTextBox.Clear();
            TypeSearchComboBox.SelectedItem = null;
            TypeSearchComboBox.Text = "";
            this.Close();
        }
    }
}
