using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Producer
    {
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Размер названия производителя: [5, 100]")]
        [XmlElement(ElementName = "OrganizationName")]
        public string OrganizationName { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Размер названия страны: [3, 20]")]
        [RegularExpression("^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Название страны состоит только из букв")]
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "Adress")]
        public string Adress;
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber;
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Размер названия города: [2, 40]")]
        [RegularExpression("^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Название города состоит только из букв")]
        public string _City { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Размер названия улицы: [2, 20]")]
        [RegularExpression("^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Название улицы состоит только из букв")]
        public string _Street { get; set; }
        [StartWithZero]
        public string _House { get; set; }
        public Producer(Form1 form1, Form2 form2)
        {
            OrganizationName = form1.OrganizationNameTextBox.Text;
            Country = form1.CountryTextBox.Text;
            TelephoneNumber = form1.TelephoneNumberMaskedTextBox.Text;
            _City = form2.CityTextBox.Text;
            _Street = form2.StreetTextBox.Text;
            _House = form2.HouseMaskedTextBox.Text;
            Adress = "г." + _City + ", ул." + _Street + ", д." + _House;
        }
        public Producer()
        {

        }
    }
}
