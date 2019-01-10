using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace oop5
{
    class MoneyException : Exception
    {

        public int Money { get; set; }
        public MoneyException(string message, int value)
       : base(message)
        {
            Money = value;
        }
    }
    class StrException : Exception
    {
        public string Name { get; set; }
        public StrException(string message, string value)
       : base(message)
        { }
    }
    [DataContract]
    public class ManException : Exception
    {
        [DataMember]
        public int Age { get; set; }
        public ManException(string message, int value)
       : base(message)
        { }
    }
    [Serializable][DataContract]
    public class Man
    {
        [DataMember]
        private int money;
        [DataMember]
        private string name;
        [DataMember]
        private int age;
        public Man(int a, string n, int m)
        {
            Age = a;
            Name = n;
            Money = m;
        }
        public Man()
        {

        }
        [DataMember]
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 18)
                    throw new ManException("Too small", value);
                else
                    age = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                if (value.Length < 2)
                    throw new StrException("Too little name", value);
                else
                    name = value;
            }
        }
        [DataMember]
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 100)
                {
                    throw new MoneyException("a few money", value);
                }
                else
                    money = value;
            }
        }
    }

}
