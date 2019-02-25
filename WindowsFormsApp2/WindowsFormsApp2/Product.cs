using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    [XmlRoot(Namespace = "WindowsFormsApp2")]
    [XmlType("Product")]
    public class Product 
    {
        [XmlElement(ElementName = "Name")]
        public string _Name;
        [XmlElement(ElementName = "InventoryNumber")]
        public string InventoryNumber;
        [XmlElement(ElementName = "Size")]
        public string _Size;
        [XmlElement(ElementName = "Weight")]
        public string Weight;
        [XmlElement(ElementName = "Type")]
        public string _Type;
        [XmlElement(ElementName = "GettingDate")]
        public string GettingDate;
        [XmlElement(ElementName = "Number")]
        public string Number;
        [XmlElement(ElementName = "Price")]
        public string Price;
        [XmlElement(ElementName = "producer")]
        public Producer producer;
        public Product(Form1 form, Form2 f2)
        {
            _Name = form.ProductNameTextBox.Text;
            InventoryNumber = form.InventoryNumberMaskedTextBox.Text;
            _Size = form.SizeTrackBar.Value.ToString() + "дм3";
            Weight = form.WeightMaskedTextBox.Text.TrimEnd('_');
            GettingDate = form.GettingDatePicker.Text;
            Number = form.NumberMaskedTextBox.Text.TrimEnd('_');
            Price = form.PriceMaskedTextBox.Text.TrimEnd('_');
            if (form.radioButton1.Checked)
                _Type = form.radioButton1.Text;
            else if (form.radioButton2.Checked)
                _Type = form.radioButton2.Text;
            producer = new Producer(form,f2);
        }
        public Product()
        {

        }
    }
}