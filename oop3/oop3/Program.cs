using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public partial class SuperString
    {
        static SuperString()
        {
            staticString = "hi";
        }
        int valueForToString = 78609987;
        private readonly int readonlyValue;
        private const string constString = "CONST";
        private string privateString;
        public static int current = 0;
        public string publicString = "It is my public string\n";
        public static string staticString;
        public SuperString() { }
        public string str;

        public SuperString(string s)
        {
            str = s;
            readonlyValue = str.Length;
            ++current;
        }

        public string PrivateString
        {
            get
            {
                return privateString;
            }
            set
            {
                privateString = value;
            }
        }

        public string Str
        {
            get { return str; }
        }

        public string Name { get; set; }

        public int LengthOfString(out int len)
        {
            len = str.Length;
            return len;
        }

        public bool IsContain(char symbol)
        {
            foreach (char c in str)
            {
                if (c == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReplaceSymbols(ref char symb1, char symb2)
        {
            foreach (char c in str)
                if (c == symb1)
                {
                    str = str.Replace(symb1, symb2);
                }
            WriteLine($"Your new string: {str}");
        }

        public static int NumberOfSuperStringObects()
        {
            return current;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            SuperString stud = (SuperString)obj;
            return (this.Name == stud.Name);
        }

        public override int GetHashCode()
        {
            int hash = 236;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = hash * 46;
            return hash;
        }

        public override string ToString()
        {
            return valueForToString.ToString();
        }

        public void Output()
        {
            WriteLine(this.str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string newStr = "hi";
            WriteLine("Enter string: ");
            string userString = ReadLine();
            int kr;
            SuperString a = new SuperString(userString);
            WriteLine("Length of your string is " + a.LengthOfString(out kr));
            WriteLine("Which letter do you want to check?");
            char letterForChecking = Char.Parse(ReadLine());
            WriteLine(a.IsContain(letterForChecking));
            WriteLine("Which letter do you want to replace?");
            char letterForReplace = Char.Parse(ReadLine());
            WriteLine("Which letter do you want to substitute?");
            char letterForSubstitute = Char.Parse(ReadLine());
            a.ReplaceSymbols(ref letterForReplace, letterForSubstitute);
            WriteLine(a.GetType());
            a.PrivateString = newStr;
            WriteLine("Введите строки ");
            string po = ReadLine();
            string pa = ReadLine();
            string pe = ReadLine();
            SuperString[] Array = new SuperString[3];
            Array[0] = new SuperString(po);
            Array[1] = new SuperString(pa);
            Array[2] = new SuperString(pe);
            WriteLine("Какую длину строк хотите вывести?");
            int ab = int.Parse(ReadLine());
            for (int i = 0; i < 3; i++)
            {
                if (Array[i].LengthOfString(out kr) == ab)
                {
                    Array[i].Output();
                }
            }
            WriteLine("Введите слово");
            string nt = ReadLine();
            string[] arr0 = Array[0].str.Split(' ');
            string[] arr1 = Array[1].str.Split(' ');
            string[] arr2 = Array[2].str.Split(' ');
            foreach (var t in arr0)
                if (t == nt)
                    WriteLine(Array[0].str);
            foreach (var t in arr1)
                if (t == nt)
                    WriteLine(Array[1].str);
            foreach (var t in arr2)
                if (t == nt)
                    WriteLine(Array[2].str);
            var user = new { name = "Oleg", age = "19" };
            WriteLine("Имя " + user.name + " возраст " + user.age);

        }
    }
}