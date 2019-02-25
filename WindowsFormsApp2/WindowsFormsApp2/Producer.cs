using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Producer
    {
        [XmlElement(ElementName = "OrganizationName")]
        public string OrganizationName;
        [XmlElement(ElementName = "Country")]
        public string Country;
        [XmlElement(ElementName = "Adress")]
        public string Adress;
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber;
        public Producer(Form1 form1, Form2 form2)
        {
            OrganizationName = form1.OrganizationNameTextBox.Text;
            Country = form1.CountryTextBox.Text;
            TelephoneNumber = form1.TelephoneNumberMaskedTextBox.Text;
            Adress = "г." + form2.CityTextBox.Text + ", ул." + form2.StreetTextBox.Text + ", д." + form2.HouseMaskedTextBox.Text;
        }
        public Producer()
        {

        }
    }
}
