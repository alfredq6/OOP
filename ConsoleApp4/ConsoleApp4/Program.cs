using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperList<string> supList = new SuperList<string>();
            try
            {
                supList += "string 1";
                supList += "string 2";
                supList += "string 3";
                supList += "string 4";
                supList += "string 5";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var firstValue = from el in supList
                             where el == supList.First<string>().ToString()
                             select el.ToString();
            Console.WriteLine($"Первый элемент коллекции List: {firstValue.First<string>()}");


            Doctor doctor = new Doctor();
            Sick sick = new Sick();
            sick.TempUp += doctor.Heal;
            sick.TempPlus();


            Timur timur = new Timur(5);
            for (int i = 0; i < 5; i++)
            {
                timur[i] = i;
                Console.WriteLine(timur[i]);
            }
            Timur[] timurs = new Timur[5];


            ooo<Fig> ds = new ooo<Fig>();
        }
    }

    class Fig { }
    class ooo<T> where T : Fig { }

    class Doctor
    {
        public void Heal()
        {
            Console.WriteLine("Доктор лечит больного");
        }
    }

    class Timur
    {
        int[] arr;
        int length;
        public Timur(int size)
        {
            arr = new int[size];
            length = size;
        }
        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }

    class Sick
    {
        public delegate void Act();
        public event Act TempUp;
        public int temperature = 36;
        public void TempPlus()
        {
            temperature += 1;
            if (temperature != 36)
            {
                TempUp?.Invoke();
            }
        }
    }

    class SuperList<T> : List<T>  where T : class
    {
        public static SuperList<T> operator +(SuperList<T> obj1, T _value) 
        {
            if (obj1.Count <= 3)
            {
                obj1.Add(_value);
                Console.WriteLine($"Элемент {_value} добавлен");
                return obj1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
