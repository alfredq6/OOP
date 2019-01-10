using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace oop11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December" };
            var nLengthMonths = from m in months
                                 where (m.Length == 5)
                                 select m;

            WriteLine("Размер слова равен 5: ");
            foreach (string n in nLengthMonths) {
                Write(n + " ");
            }

            var SumAndWintMonths = from m in months
                                    where (m == "January" || m == "February" || m == "December" || m == "June" || m == "Jule" || m == "August")
                                    select m;

            WriteLine("\n\nЗимние и летние месяцы: ");
            foreach (string n in SumAndWintMonths)
            {
                Write(n + " ");
            }

            var orderedMonths = from m in months
                                orderby m
                                select m;

            WriteLine("\n\nОтсортированные в алфавитном порядке месяцы: ");
            foreach (string m in orderedMonths)
            {
                Write(m + " ");
            }

            var MonthsHasU_AndLengthFour = from m in months
                                           where (m.Length >= 4 && m.Contains("u"))
                                           select m;

            WriteLine("\n\nМесяцы, имеющие u в названии и состоящие из 4 и более символов: ");
            foreach (string m in MonthsHasU_AndLengthFour)
            {
                Write(m + " ");
            }

            List<SuperString> ListForSuperString = new List<SuperString>();

            List<Date> date = new List<Date> { new Date(24, 11, 2007), new Date(9, 12, 1999), new Date(18, 7, 2016), new Date(21, 12, 2012), new Date(5, 9, 2016), new Date(9, 2, 2017)};

            var nessesaryYear = from d in date
                                where d.Year == 2016
                                select d;

            WriteLine("\n\nСписок дат 2016 года: ");
            foreach (Date n in nessesaryYear)
            {
                WriteLine($"{n.Day}.{n.Month}.{n.Year}");
            }

            var nessesaryMonth = from d in date
                                 where d.Month == 12
                                 select d;

            WriteLine("\nСписок дат декабря месяца: ");
            foreach (Date n in nessesaryMonth)
            {
                WriteLine($"{n.Day}.{n.Month}.{n.Year}");
            }

            var dateRange = from d in date  
                            where (d.Year >= 1990 && d.Year <= 2010)
                            select d;

            WriteLine("\nСписок дат с 1990 по 2010 года: ");
            foreach(Date n in dateRange)
            {
                WriteLine($"{n.Day}.{n.Month}.{n.Year}");
            }

            int maxValue = date[0].Day + date[0].Month + date[0].Year;
            foreach (Date n in date)
            {
                if (maxValue <= (n.Day + n.Month + n.Year))
                {
                    maxValue = n.Day + n.Month + n.Year;
                }
            }

            var dateMax = from d in date
                          where ((d.Day + d.Month + d.Year) == maxValue)
                          select d;

            WriteLine("\nМаксимальная дата: ");
            foreach (Date n in dateMax)
            {
                WriteLine($"{n.Day}.{n.Month}.{n.Year}");
            }

            var firstDateforDay = from d in date
                                  where (d.Day == 10)
                                  select d;

            WriteLine("\nПервая дата в массиве для дня под номером 10: ");
            foreach (Date n in firstDateforDay)
            {
                if (n.Day == 10)
                {
                    WriteLine($"{n.Day}.{n.Month}.{n.Year}");
                    break;
                }
            }

            var sortDate = from d in date
                           orderby d.Day orderby d.Month orderby d.Year
                           select d;

            WriteLine("\nУпорядоченный список дат: ");
            foreach (Date n in sortDate)
            {
                WriteLine($"{n.Day}.{n.Month}.{n.Year}");
            }

            Random random = new Random();
            int[] num = {random.Next(0,100), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100),
            random.Next(0,100), random.Next(0,100), random.Next(0,100), random.Next(0,100), random.Next(0,100), random.Next(0,100), random.Next(0,100)};

            var num_linq = from z in num
                           where (z > num.Min() && z < num.Max())
                           orderby z
                           select z + 1;

            WriteLine();
            foreach (int d in num_linq)
            {
                Write(d + "   ");
            }
            WriteLine("\n");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = players.Join(teams, 
             p => p.Team, 
             t => t.Name, 
             (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country }); 

            foreach (var item in result)
                WriteLine("{0} - {1} ({2})", item.Name, item.Team, item.Country);
        }
    }


    class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        
        public Date(int d, int m, int y)
        {
            Day = d;
            Month = m;
            Year = y;
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public partial class SuperString
    {
        
    }
}
