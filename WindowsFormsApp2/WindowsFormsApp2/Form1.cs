using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        static bool IsReady = true;
        static bool isClicked = false;
        static bool isSorted = false;
        static string CurrentDateTime = "";
        static string Act = "";
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
            Act = "";
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer2_Tick);
            timer.Start();

        }
        private string CountOfObjects()
        {
            List<Product> list = new List<Product>();
            try
            {
                using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer deformatter = new XmlSerializer(typeof(List<Product>));
                    list = (List<Product>)deformatter.Deserialize(fs);
                }
            }
            catch (Exception)
            {

            }
            return list.Count().ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now.ToString();
            SostLabel.Text = $"Количество объектов: {CountOfObjects()}, последнее выполняемое действие: {Act}, текущее время: {CurrentDateTime}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Act = "попытка сохранения данных";
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
                var results = new List<ValidationResult>();
                var results2 = new List<ValidationResult>();
                var contextOfProduct = new ValidationContext(product);
                var contextOfProducer = new ValidationContext(product.producer);
                if (!Validator.TryValidateObject(product, contextOfProduct, results, true) && !Validator.TryValidateObject(product.producer, contextOfProducer, results2, true))
                {
                    foreach (var error in results)
                        MessageBox.Show(error.ErrorMessage);

                    foreach (var error in results2)
                        MessageBox.Show(error.ErrorMessage);
                }
                else if (!Validator.TryValidateObject(product, contextOfProduct, results, true))
                    foreach (var error in results)
                        MessageBox.Show(error.ErrorMessage);
                else if (!Validator.TryValidateObject(product.producer, contextOfProducer, results2, true))
                    foreach (var error in results2)
                        MessageBox.Show(error.ErrorMessage);
                else
                {
                    try
                    {

                        Act = "сохранение данных";
                        using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
                        {
                            XmlSerializer deformatter = new XmlSerializer(typeof(List<Product>));
                            products = (List<Product>)deformatter.Deserialize(fs);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        bool IsEqual = false;
                        foreach (Product el in products)
                        {
                            if (!el.Equals(product))
                                IsEqual = false;
                            else
                                IsEqual = true;
                        }
                        if (!IsEqual)
                        {
                            products.Add(product);
                        }
                        using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
                        {
                            XmlSerializer formater = new XmlSerializer(typeof(List<Product>));
                            formater.Serialize(fs, products);
                        }
                    }
                }
            }
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            Act = "попытка вывода данных";
            ListBox.Items.Clear();
            List<Product> desProducts;
            try
            {
                using (FileStream fs = new FileStream("products.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
                    desProducts = (List<Product>)formatter.Deserialize(fs);
                }
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
                Act = "вывод данных";
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {

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
            Act = "изменение размера товара";
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
            Act = "изменение адреса";
            InputAdressButton.BackColor = Color.Empty;
            form2.ShowDialog();
        }

        private void WeightMaskedTextBox_Click(object sender, EventArgs e)
        {
            WeightMaskedTextBox.SelectionStart = 0;
            WeightMaskedTextBox.BackColor = Color.Empty;
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            поискToolStripMenuItem.Visible = true;
            сортировкаToolStripMenuItem.Visible = true;
            очиститьToolStripMenuItem.Visible = true;
            удалитьToolStripMenuItem.Visible = true;
            закрепитьToolStripMenuItem.Visible = true;
            открепитьToolStripMenuItem.Visible = true;
            сохранитьToolStripMenuItem.Visible = true;
            оПрограммеToolStripMenuItem.Visible = true;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                поискToolStripMenuItem.Visible = false;
                сортировкаToolStripMenuItem.Visible = false;
                очиститьToolStripMenuItem.Visible = false;
                удалитьToolStripMenuItem.Visible = false;
                закрепитьToolStripMenuItem.Visible = false;
                открепитьToolStripMenuItem.Visible = false;
                сохранитьToolStripMenuItem.Visible = false;
                оПрограммеToolStripMenuItem.Visible = false;
            }
        }

        private void закрепитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "закрепление панели";
            isClicked = true;
        }
        private void открепитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "открепление панели";
            isClicked = false;
        }
        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "выбор сортировки";
            isClicked = true;
        }
        private void ForSort(Comparison<XElement> comparison)
        {
            Act = "сортировка";
            try
            {
                XDocument xDoc = XDocument.Load("products.xml");
                XElement root = xDoc.Root;
                List<XElement> list = root.Elements("Product").ToList();
                root.RemoveAll();
                list.Sort(comparison);
                foreach (XElement el in list)
                    root.Add(el);
                xDoc.Save("products.xml");
            }
            catch (Exception) { }
        }

        private void поДатеПоступленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comparison<XElement> comparison = Comparator;
            ForSort(comparison);
            isSorted = true;
            int Comparator(XElement el1, XElement el2)
            {
                if (DateTime.Parse(el1.Element("GettingDate").Value).CompareTo(DateTime.Parse(el2.Element("GettingDate").Value)) == 1)
                {
                    return 1;
                }
                else if (DateTime.Parse(el1.Element("GettingDate").Value).CompareTo(DateTime.Parse(el2.Element("GettingDate").Value)) == -1)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }

        private void поСтранеПроизводителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comparison<XElement> comparison = Comparator;
            ForSort(comparison);
            isSorted = true;
            int Comparator(XElement el1, XElement el2)
            {
                if (el1.Element("producer").Element("Country").Value.CompareTo(el2.Element("producer").Element("Country").Value) == 1)
                    return 1;
                else if (el1.Element("producer").Element("Country").Value.CompareTo(el2.Element("producer").Element("Country").Value) == -1)
                    return -1;
                else
                    return 0;
            }
        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comparison<XElement> comparison = Comparator;
            ForSort(comparison);
            isSorted = true;
            int Comparator(XElement el1, XElement el2)
            {
                if (el1.Element("Name").Value.CompareTo(el2.Element("Name").Value) == 1)
                    return 1;
                else if (el1.Element("Name").Value.CompareTo(el2.Element("Name").Value) == -1)
                    return -1;
                else
                    return 0;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "сохранение результатов в другой xml-file";
            List<Product> list;
            try
            {
                if (!isSorted)
                    throw new Exception("Данные не отсортированы");
                using (FileStream fs = new FileStream("products.xml", FileMode.Open))
                {
                    XmlSerializer deformatter = new XmlSerializer(typeof(List<Product>));
                    list = (List<Product>)deformatter.Deserialize(fs);
                }
                using (FileStream fs = new FileStream("sortedOrSearchedProducts.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
                    formatter.Serialize(fs, list);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Нечего сортировать, xml-файл не существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "вывод информации 'О программе'";
            MessageBox.Show($"Версия: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()}\nРазработчик: Калупаев Максим Николаевич");
        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox;
            MaskedTextBox maskedTextBox;
            if (sender is TextBox)
            {
                textBox = (TextBox)sender;
                if (textBox.Name == "ProductNameTextBox")
                    Act = "изменение названия продукта";
                if (textBox.Name == "OrganizationNameTextBox")
                    Act = "изменение названия организации";
                if (textBox.Name == "CountryTextBox")
                    Act = "изменение страны производителя";
            }
            if (sender is MaskedTextBox)
            {
                maskedTextBox = (MaskedTextBox)sender;
                if (maskedTextBox.Name == "InventoryNumberMaskedTextBox")
                    Act = "изменение инвентарного номера";
                if (maskedTextBox.Name == "WeightMaskedTextBox")
                    Act = "изменение веса товара";
                if (maskedTextBox.Name == "NumberMaskedTextBox")
                    Act = "изменение количества товаров";
                if (maskedTextBox.Name == "PriceMaskedTextBox")
                    Act = "изменение цены товара";
                if (maskedTextBox.Name == "TelephoneNumberMaskedTextBox")
                    Act = "изменение номера телефона";
            }
            if (sender is DateTimePicker)
                Act = "изменение даты поступления";
            if (sender is RadioButton)
                Act = "изменение типа товара";
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductNameTextBox.Clear();
            InventoryNumberMaskedTextBox.Clear();
            SizeTrackBar.Value = 0;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            GettingDatePicker.Value = DateTime.Now;
            WeightMaskedTextBox.Clear();
            NumberMaskedTextBox.Clear();
            PriceMaskedTextBox.Clear();
            OrganizationNameTextBox.Clear();
            CountryTextBox.Clear();
            TelephoneNumberMaskedTextBox.Clear();
            form2.CityTextBox.Clear();
            form2.StreetTextBox.Clear();
            form2.HouseMaskedTextBox.Clear();
            Act = "очистка всех полей";
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "удаление объектов";
            try
            {
                XDocument xDoc = XDocument.Load("products.xml");
                xDoc.Root.RemoveAll();
                xDoc.Save("products.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act = "поиск";
            form3.ShowDialog();
        }
    }
}
