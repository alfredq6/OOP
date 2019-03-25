using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp2
{
    public class StartWithZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string _value = value.ToString();
            if (!_value.StartsWith("0"))
                return true;
            else
                this.ErrorMessage = "Значение массы/количества/цены не может начинаться с нуля";
            return false;
        }
    }
    [Serializable]
    [XmlType("Product")]
    public class Product 
    {
        [XmlElement(ElementName = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Размер названия товара: [3, 50]")]
        public string _Name { get; set; }
        [XmlElement(ElementName = "InventoryNumber")]
        public string InventoryNumber;
        [XmlElement(ElementName = "Size")]
        public string _Size;
        [StartWithZero]
        [XmlElement(ElementName = "Weight")]
        public string Weight { get; set; }
        [XmlElement(ElementName = "Type")]
        public string _Type;
        [XmlElement(ElementName = "GettingDate")]
        public string GettingDate;
        [StartWithZero]
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }
        [StartWithZero]
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "producer")]
        public Producer producer;
        public Product(Form1 form, Form2 f2)
        {
            _Name = form.ProductNameTextBox.Text;
            InventoryNumber = form.InventoryNumberMaskedTextBox.Text;
            _Size = form.SizeTrackBar.Value.ToString() + "дм3";
            Weight = form.WeightMaskedTextBox.Text.TrimEnd('_');
            if (form.GettingDatePicker.Value.Month.ToString().Length < 2 && form.GettingDatePicker.Value.Day.ToString().Length < 2)
                GettingDate = $"{form.GettingDatePicker.Value.Year}-0{form.GettingDatePicker.Value.Month}-0{form.GettingDatePicker.Value.Day}";
            else if (form.GettingDatePicker.Value.Month.ToString().Length == 2 && form.GettingDatePicker.Value.Day.ToString().Length < 2)
                GettingDate = $"{form.GettingDatePicker.Value.Year}-{form.GettingDatePicker.Value.Month}-0{form.GettingDatePicker.Value.Day}";
            else if (form.GettingDatePicker.Value.Month.ToString().Length < 2 && form.GettingDatePicker.Value.Day.ToString().Length == 2)
                GettingDate = $"{form.GettingDatePicker.Value.Year}-0{form.GettingDatePicker.Value.Month}-{form.GettingDatePicker.Value.Day}";
            else
                GettingDate = $"{form.GettingDatePicker.Value.Year}-{form.GettingDatePicker.Value.Month}-{form.GettingDatePicker.Value.Day}";
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
        public override bool Equals(object objProd)
        {
            Product obj = (Product)objProd;
            if (this._Name == obj._Name
                && this.InventoryNumber == obj.InventoryNumber
                && this._Size == obj._Size
                && this.Weight == obj.Weight 
                && this.GettingDate == obj.GettingDate
                && this.Number == obj.Number 
                && this.Price == obj.Price 
                && this.producer.Adress == obj.producer.Adress 
                && this.producer.Country == obj.producer.Country 
                && this.producer.OrganizationName == obj.producer.OrganizationName 
                && this.producer.TelephoneNumber == obj.producer.TelephoneNumber)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}