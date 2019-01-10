using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


// 4 laba 23 variant
namespace oop4
{
    interface IOperation<T> where T : class
    {
        void Add(Stroke<T> obj);
        void Delete(Stroke<T> obj);
        void Check(List<Stroke<T>> obj);
    }
    public class Stroke<T> : IOperation<T> where T : class
    {
        public static List<Stroke<T>> Strokes { get; set; } = new List<Stroke<T>>();

        public void Add(Stroke<T> obj)
        {
            Strokes.Add(obj);
        }
        public void Delete(Stroke<T> obj)
        {
            try
            {
                Strokes.Remove(obj);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                WriteLine("Stroke is deleted\n");
            }
        }
        public void Check(List<Stroke<T>> obj)
        {
            if (obj.LongCount() == 0)
            {
                WriteLine("List is empty");
            }
            else
            {
                for (int i = 0; i < obj.LongCount(); i++)
                {
                    WriteLine(obj[i].Value);
                }
            }
        }

        class Owner
        {
            int Creatorid;
            string CreatorName;
            string OrganizationName;
            public Owner(int creatorid, string creatorname, string organizationname)
            {
                Creatorid = creatorid;
                CreatorName = creatorname;
                OrganizationName = organizationname;
            }
        }
        Owner owner = new Owner(111, "Mark", "NBA");
        public string Value { get; set; }
        public Stroke() { }
        public Stroke(string value)
        {
            Value = value;
        }

        class Date
        {
            int year;
            byte month;
            byte day;
            public Date(int y, byte m, byte d)
            {
                year = y;
                month = m;
                day = d;
            }
        }
        Date DateOfCreatingOfOrganization = new Date(1921, 8, 24);

        public static bool operator <(Stroke<T> stroke1, Stroke<T> stroke2)
        {
            String[] words1 = stroke1.Value.Split(new char[] { ' ', ',', '.', ':', '-', '?', '!' });
            String[] words2 = stroke2.Value.Split(new char[] { ' ', ',', '.', ':', '-', '?', '!' });
            int len1 = 0;
            int len2 = 0;
            for (int i = 0; i < words1.Length; i++)
            {
                len1 += words1[i].Length;
            }
            for (int i = 0; i < words2.Length; i++)
            {
                len2 += words2[i].Length;
            }
            return len1 < len2;
        }
        public static bool operator >(Stroke<T> stroke1, Stroke<T> stroke2)
        {
            String[] words1 = stroke1.Value.Split(new char[] { ' ', ',', '.', ':', '-', '?', '!' });
            String[] words2 = stroke2.Value.Split(new char[] { ' ', ',', '.', ':', '-', '?', '!' });
            int len1 = 0;
            int len2 = 0;
            for (int i = 0; i < words1.Length; i++)
            {
                len1 += words1[i].Length;
            }
            for (int i = 0; i < words2.Length; i++)
            {
                len2 += words2[i].Length;
            }
            return len1 > len2;
        }
        public static string operator +(Stroke<T> stroke1, int number)
        {
            return stroke1.Value + number.ToString();
        }
        public static string operator -(Stroke<T> stroke1)
        {
            return stroke1.Value.TrimEnd(stroke1.Value[stroke1.Value.Length - 1]);
        }
        public static string operator *(Stroke<T> stroke1, char symbol)
        {
            StringBuilder newStr = new StringBuilder(stroke1.Value);
            for (int i = 0; i < newStr.Length; i++)
            {
                if (newStr[i] != ' ')
                {
                    newStr[i] = symbol;
                }
            }
            stroke1.Value = newStr.ToString();
            return stroke1.Value;
        }
    }


    static class MathOperation
    {
        public static bool HasSpecialSymbols(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '@' || str[i] == '$')
                {
                    return true;
                }
            }
            return false;
        }

        public static string DeletingPunctuationMarks(this string str)
        {
            string[] newArr = str.Split(new char[] { ',', '.', ';', ':', '?', '!', '-' });
            str = null;
            for (int i = 0; i < newArr.Length; i++)
            {
                str += newArr[i];
            }
            return str;
        }

        public static string MaxElement(this List<Stroke<string>> lt)
        {
            string maxStroke = lt[0].Value;
            if (lt != null && lt.LongCount() > 0)
            {
                for (int i = 0; i < lt.LongCount(); i++)
                {
                    if (lt[i].Value != null)
                    {
                        if (maxStroke.Length < lt[i].Value.Length)
                        {
                            maxStroke = lt[i].Value;
                        }
                    }
                }
            }
            return maxStroke;
        }

        public static string MinElement(this List<Stroke<string>> lt)
        {
            string minStroke = lt[0].Value;
            for (int i = 0; i < lt.LongCount(); i++)
            {
                if (lt[i].Value.Length < minStroke.Length)
                {
                    minStroke = lt[i].Value;
                }
            }
            return minStroke;
        }

        public static int CounterOfElements(this List<Stroke<string>> lt)
        {
            return Convert.ToInt32(lt.LongCount());
        }
    }

    class Product
    {

        public int Average { get; set; }
        public Product(int a, int ag, int cost)
        {
            Average = a;
            Age = ag;
            Cost = cost;
        }
        public int Cost { get; set; }
        public virtual void Info()
        {
            WriteLine($"Номер товара:{Average}");
        }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stroke<string> First = new Stroke<string>("As a result of a communicative act, a text may be defined");
            Stroke<string> Second = new Stroke<string>("For linguistics and? the study of language - more broadly,! a set of stable concepts.");
            Stroke<string> Third = new Stroke<string>("They are more fluid with the changing affordances of new medi@");

            Stroke<Product> newType = new Stroke<Product>();

            Stroke<string>.Strokes.Add(First);
            Stroke<string>.Strokes.Add(Second);
            Stroke<string>.Strokes.Add(Third);

            WriteLine($"A number of elements - {Stroke<string>.Strokes.CounterOfElements()}");
            WriteLine($"Max element is string: {Stroke<string>.Strokes.MaxElement()}");
            WriteLine($"Min element is string: {Stroke<string>.Strokes.MinElement()}\n");
            
            WriteLine($"Do the second string has special symbols(@, $)? - {Second.Value.HasSpecialSymbols()} \nmaybe third? - {Third.Value.HasSpecialSymbols()}");
            Second.Value = Second.Value.DeletingPunctuationMarks();
            WriteLine($"The second string after punctuation marks deleting: {Second.Value.DeletingPunctuationMarks()}\n");
            

            if (First < Second)
            {
                WriteLine("The first string is less by words then the second.");
            }
            else
            {
                WriteLine("The first string is longer by words then the second.");
            }
            WriteLine($"\nThe first String with a number: {First + 3243254}");
            WriteLine($"The second string without the last symbol: {-Second}");
            WriteLine($"The thrid string after replacing string to nessesary symbol: {Third * 'o'}\n");
            

            Stroke<string> Another = new Stroke<string>();
            Another.Delete(First);
            WriteLine("Checking of strokes:");
            Another.Check(Stroke<string>.Strokes);

            ReadKey();
        }
    }
}
