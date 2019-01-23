using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> circles = new List<Circle> { new Circle(13), new Circle(5), new Circle(10) };
            Circle circle0 = circles.First<Circle>();
            foreach (Circle c in circles)
            {
                if (((IComparable)c).CompareTo(circle0) == 0)
                {
                    Console.WriteLine("Равны");
                }
                if (((IComparable)c).CompareTo(circle0) == 1)
                {
                    Console.WriteLine("Больше");
                }
                if (((IComparable)c).CompareTo(circle0) == -1)
                {
                    Console.WriteLine("Меньше");
                }
            }
            circles.Sort();
            foreach (Circle c in circles)
            {
                Console.WriteLine(c.CircleArea());
            }

            PDate date0 = new PDate(32, 13);
            PDate date1 = new PDate(12, 12);
            PDate date2 = new PDate(31, 12);
            PDate date3 = new PDate(2, 9);
            PDate date4 = new PDate(23, 5);
            PMDate date01 = new PMDate(32, 121, -12);
            PMDate date5 = new PMDate(31, 12, 2018);
            Console.WriteLine($"date1 < date2 : {date1 < date2}");
            Console.WriteLine($"date4 > date3 : {date4 > date3}");
            Console.WriteLine($"Дата до NextDay() : {date2.Day}.{date2.Month}");
            date2.NextDay();
            Console.WriteLine($"Дата после NextDay() : {date2.Day}.{date2.Month}");
            Console.WriteLine($"Дата до NextDay() : {date5.Day}.{date5.Month}.{date5.Year}");
            date5.NextDay();
            Console.WriteLine($"Дата после NextDay() : {date2.Day}.{date2.Month}.{date5.Year}");

            A a = new A();
            Console.WriteLine($"a.x = {a.x}");
            B b = new B();
            Console.WriteLine($"b.x = {b.x}");
            b.ds();

        }
        
    }
    class A
    {
        public int x = 10;
    }
    class B : A
    {
        new public int x = 5;
        public void ds()
        {
            Console.WriteLine(base.x);
        }
    }
    class PDate
    {
        public int day;
        public int month;
        public int Day
        {
            get
            {
                return this.day;
            }
            set
            {
                if (value >= 1 && value <= 31)
                {
                    this.day = value;
                }
                else
                {
                    Console.WriteLine("Некорректный номер дня");
                }
            }
        }
        public int Month
        {
            get
            {
                return this.month;
            }
            set
            {
                if (value >= 1 && value <= 12)
                {
                    this.month = value;
                }
                else
                {
                    Console.WriteLine("Некорректный номер месяца");
                }
            }
        }
        public PDate()
        {

        }
        public PDate(int _day, int _month)
        {
            Day = _day;
            Month = _month;
        }
        public virtual void NextDay()
        {
            if (this.day < 31)
            {
                this.day += 1;
            }
            if (this.day == 31)
            {
                if (this.month == 12)
                {
                    this.month = 1;
                    this.day = 1;
                }
                this.day = 1;
            }
        }
        public static bool operator >(PDate _date1, PDate _date2)
        {
            if (_date1.month > _date2.month)
            {
                return true;
            }
            if (_date1.month == _date2.month)
            {
                if (_date1.day > _date2.day)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
        public static bool operator <(PDate _date1, PDate _date2)
        {
            if (_date1.month < _date2.month)
            {
                return true;
            }
            if (_date1.month == _date2.month)
            {
                if (_date1.day < _date2.day)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
    }
    class PMDate : PDate
    {
        public int year;
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                if (value >= 0)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Неккоректный номер года");
                }
            }
        }
        public PMDate(int _day, int _month, int _year) : base(_day, _month)
        {
            Year = _year;
        }
        public PMDate()
        {

        }
        public override void NextDay()
        {
            if (this.day < 31)
            {
                this.day += 1;
            }
            if (this.day == 31)
            {
                if (this.month == 12)
                {
                    this.month = 1;
                    this.day = 1;
                    this.year += 1;
                }
                this.day = 1;
            }

        }
    }


    class Circle : IComparable
    {
        private int radius;
        public Circle() { }
        public Circle(int _radius)
        {
            radius = _radius;
        }
        public double CircleArea()
        {
            return this.radius*this.radius*Math.PI;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        int IComparable.CompareTo(object obj)
        {
            Circle newObj = (Circle)obj;
            if (this.CircleArea() > newObj.CircleArea())
            {
                return 1;
            }
            if (this.CircleArea() < newObj.CircleArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    
}
