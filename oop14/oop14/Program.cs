using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using static System.Console;
using oop5;

namespace oop14
{
    class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man(20, "John", 500);
            Man woman = new Man(19, "Alice", 200);
            Man[] men = new Man[] { man, woman };
            ManException manException = new ManException("message", 123);

            WriteLine("Binary serialization: ");
            BinaryFormatter Bformatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                Bformatter.Serialize(fs, man);
            }
            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                Man newMan = (Man)Bformatter.Deserialize(fs);
                WriteLine($"Name: {newMan.Name}, Age: {newMan.Age}, Money: {newMan.Money}");
            }

            WriteLine("\nSOAP serialization: ");
            SoapFormatter Sformatter = new SoapFormatter();
            using (FileStream fs = new FileStream("soap.dat", FileMode.OpenOrCreate))
            {
                Sformatter.Serialize(fs, man);
            }
            using (FileStream fs = new FileStream("soap.dat", FileMode.OpenOrCreate))
            {
                Man newMan = (Man)Sformatter.Deserialize(fs);
                WriteLine($"Name: {newMan.Name}, Age: {newMan.Age}, Money: {newMan.Money}");
            }

            WriteLine("\nXML serialization: ");
            XmlSerializer Xserializer = new XmlSerializer(typeof(Man));
            using (FileStream fs = new FileStream("X.xml", FileMode.OpenOrCreate))
            {
                Xserializer.Serialize(fs, man);
            }
            using (FileStream fs = new FileStream("X.xml", FileMode.OpenOrCreate))
            {
                Man newMan = (Man)Xserializer.Deserialize(fs);
                WriteLine($"Name: {newMan.Name}, Age: {newMan.Age}, Money: {newMan.Money}");
            }

            WriteLine("\nJSON serialization: ");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Man));
            using (FileStream fs = new FileStream("jsonser.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, man);
            }
            using (FileStream fs = new FileStream("jsonser.json", FileMode.OpenOrCreate))
            {
                Man newMan = (Man)jsonSerializer.ReadObject(fs);
                WriteLine($"Name: {newMan.Name}, Age: {newMan.Age}, Money: {newMan.Money}");
            }

            WriteLine("\nBinary serialization of array: ");
            using (FileStream fs = new FileStream("mas.dat", FileMode.OpenOrCreate))
            {
                Bformatter.Serialize(fs, men);
            }
            using (FileStream fs = new FileStream("mas.dat", FileMode.OpenOrCreate))
            {
                Man[] newMen = (Man[])Bformatter.Deserialize(fs);
                WriteLine($"Name: {newMen[0].Name}, Age: {newMen[0].Age}, Money: {newMen[0].Money}");
                WriteLine($"Name: {newMen[1].Name}, Age: {newMen[1].Age}, Money: {newMen[1].Money}");
            }

            WriteLine("\nby XPath: ");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("X.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode child = xDoc.SelectSingleNode("//Man/name");
            if (child != null)
            {
                WriteLine(child.OuterXml);
            }
            XmlNodeList childs = xRoot.SelectNodes("*");
            foreach (XmlNode ch in childs)
            {
                WriteLine(ch.OuterXml);
            }

            WriteLine("\nLinq to XML:");
            XDocument xDocument = new XDocument();
            XElement man1 = new XElement("Name");
            XAttribute man1_name = new XAttribute("Name", "Leha");
            XElement age1 = new XElement("Age", "21");
            XElement money1 = new XElement("Money", "600");
            man1.Add(man1_name);
            man1.Add(age1);
            man1.Add(money1);

            XElement man2 = new XElement("Name");
            XAttribute man2_name = new XAttribute("Name", "Serega");
            XElement age2 = new XElement("Age", "22");
            XElement money2 = new XElement("Money", "1000");
            man2.Add(man2_name);
            man2.Add(age2);
            man2.Add(money2);

            XElement man3 = new XElement("Name");
            XAttribute man3_name = new XAttribute("Name", "Sanya");
            XElement age3 = new XElement("Age", "20");
            XElement money3 = new XElement("Money", "300");
            man3.Add(man3_name);
            man3.Add(age3);
            man3.Add(money3);

            XElement people = new XElement("people");
            people.Add(man1);
            people.Add(man2);
            people.Add(man3);

            xDocument.Add(people);
            xDocument.Save("Xlinq.xml");

            XDocument xdoc = XDocument.Load("Xlinq.xml");
            var byAge = from el in xdoc.Element("people").Elements("Name")
                    where Convert.ToInt32(el.Element("Age").Value) >= 21
                    select new Man
                    {
                        Name = el.Attribute("Name").Value,
                        Age = Convert.ToInt32(el.Element("Age").Value),
                        Money = Convert.ToInt32(el.Element("Money").Value)
                    };
            WriteLine("Age is >= 21:");
            foreach (var el in byAge)
            {
                WriteLine($"Name: {el.Name}, Age: {el.Age}, Money: {el.Money}");
            }

            var byMoney = from el in xdoc.Element("people").Elements("Name")
                          where Convert.ToInt32(el.Element("Money").Value) >= 500
                          select new Man
                          {
                              Name = el.Attribute("Name").Value,
                              Age = Convert.ToInt32(el.Element("Age").Value),
                              Money = Convert.ToInt32(el.Element("Money").Value)
                          };
            WriteLine("\nHas money >= 500");
            foreach (var el in byMoney)
            {
                WriteLine($"Name: {el.Name}, Age: {el.Age}, Money: {el.Money}");
            }
        }
    }
}
