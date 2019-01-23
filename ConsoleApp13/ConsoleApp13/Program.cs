using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp13
{
	class Date
	{
		public int day;
		public int month;
		public int year;
		public Date(int d, int m, int y)
		{
			Day = d;
			Month = m;
			Year = y;
		}
		public int Day
		{
			set
			{
				day = value;
			}
			get
			{
				return day;
			}
		}
		public int Month
		{
			set
			{
				month = value;
			}
			get
			{
				return month;
			}
		}
		public int Year
		{
			set
			{
				year = value;
			}
			get
			{
				return year;
			}
		}
	}

	interface Itest
	{
		void Test();
	}

	class Month : Itest
	{
		public int month_i;
		public string month_s;

		public Month(int month, string month_str)
		{
			month_i = month;
			month_s = month_str;
		}
		public void Test()
		{
			WriteLine("Interface");
		}
		public static int test1(int t1)
		{
			return t1;
		}
		public static void test2(int t2, char t3, string t4)
		{
			
		}
		private void test3()
		{

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Date date1 = new Date(23, 6, 2010);
			Date date2 = new Date(4, 8, 2003);
			Date date3 = new Date(15, 11, 2015);
			Date date4 = new Date(11, 3, 1999);

			Month month1 = new Month(17, "June");
			Month month2 = new Month(12, "February");
			Month month3 = new Month(7, "March");
			Month month4 = new Month(21, "May");

			WriteLine("Задание 1.");
			Reflector.first<Month>(month2);
			WriteLine("В файл записан экземпляр класса Month");
			WriteLine("\n");

			WriteLine("Задание 2.");
			Reflector.second<Month>(month2);
			WriteLine("\n");

			WriteLine("Задание 3.");
			Reflector.third<Date>(date1);
			WriteLine("\n");

			WriteLine("Задание 4.");
			Reflector.fourth<Month>(month2);
			WriteLine("\n");

			WriteLine("Задание 5.");
			Reflector.fifth<Month>(month2);
			WriteLine("\n");

			WriteLine("Задание 6.");
			Reflector.sixth<Month>(month2, "test1");
			WriteLine("\n");
		}
	}

	class Reflector
	{
		//a)

		public static void first<T>(T obj) where T : class
		{
			StreamWriter filestream = new StreamWriter("first.txt");
			Type t = typeof(T);
			ConstructorInfo[] constructors = t.GetConstructors();
			filestream.WriteLine($"Конструкторы {obj.ToString()}\n");
			foreach (ConstructorInfo ct in constructors)
			{
				filestream.Write(" " + ct.DeclaringType.Name + "(");
				ParameterInfo[] p = ct.GetParameters();
				for (int i = 0; i < p.Length; i++)
				{
					filestream.Write(p[i].ParameterType.Name + " " + p[i].Name);
					if (i + 1 < p.Length)
						filestream.Write(", ");
				}
				filestream.WriteLine(")\n");
			}

			FieldInfo[] fieldinfo = t.GetFields();
			filestream.WriteLine($"\nПоля {obj.ToString()}");
			foreach (FieldInfo f in fieldinfo)
				filestream.WriteLine(" " + f.Name);

			MethodInfo[] Methodarr = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			filestream.WriteLine($"Список методов Public класса {obj.ToString()}\n");
			foreach (MethodInfo m in Methodarr)
			{
				filestream.Write(" " + m.ReturnType.Name + " " + m.Name + "(");
				ParameterInfo[] p = m.GetParameters();
				for (int i = 0; i < p.Length; i++)
				{
					filestream.Write(p[i].ParameterType.Name + " " + p[i].Name);
					if (i + 1 < p.Length)
						filestream.Write(", ");
				}
				filestream.WriteLine(")\n");
			}

			Methodarr = t.GetMethods();
			filestream.WriteLine($"Список всех методов класса {obj.ToString()}\n");
			foreach (MethodInfo m in Methodarr)
			{
				filestream.Write(" " + m.ReturnType.Name + " " + m.Name + "(");
				ParameterInfo[] p = m.GetParameters();
				for (int i = 0; i < p.Length; i++)
				{
					filestream.Write(p[i].ParameterType.Name + " " + p[i].Name);
					if (i + 1 < p.Length)
						filestream.Write(", ");
				}
				filestream.WriteLine(")\n");
			}
			filestream.Close();
		}

		//b)

		public static void second<T>(T obj) where T : class
		{
			Type t = typeof(T);
			MethodInfo[] Methodarr = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			WriteLine($"Список методов класса {obj.ToString()}");
			foreach (MethodInfo m in Methodarr)
				Write(" " + m.ReturnType.Name + " " + m.Name + "()\n");
		}

		//c)

		public static void third<T>(T obj) where T : class
		{
			Type t = typeof(T);
			FieldInfo[] fieldinfo = t.GetFields();
			WriteLine($"Поля {obj.ToString()}");
			foreach (FieldInfo f in fieldinfo)
				WriteLine(" " + f.FieldType.Name + " " + f.Name);
			PropertyInfo[] prop = t.GetProperties();
			WriteLine($"Свойства {obj.ToString()}");
			foreach (PropertyInfo pr in prop)
				WriteLine(" " + pr.PropertyType.Name + " " + pr.Name);
		}

		//d)

		public static void fourth<T>(T obj) where T : class
		{
			Type t = typeof(T);
			Type[] interfaces = t.GetInterfaces();
			foreach (Type type in interfaces)
				WriteLine(" " + type.Name);
		}

		//e)
		public static void fifth<T>(T obj) where T : class
		{
			WriteLine("Введите тип параметра (ввод с большой буквы)");
			string str = ReadLine();
			Type t = typeof(T);
			MethodInfo[] methodInfo = t.GetMethods();
			foreach (MethodInfo m in methodInfo)
			{
				ParameterInfo[] p = m.GetParameters();
				for (int i = 0; i < p.Length; i++)
				{
					if (p[i].ParameterType.Name == str)
					{
						Write(" " + m.ReturnType.Name + " " + m.Name + "(");
						for (int j = 0; j < p.Length; j++)
						{
							Write(p[j].ParameterType.Name + " " + p[j].Name);
							Write(", ");
						}
						Write(")\n");
					}
				}
				if (p.Length == 0 && str == "")
				{
					WriteLine(" " + m.ReturnType.Name + " " + m.Name + "()");
				}
			}
		}

		//f)
		public static void sixth<T>(T obj, string method)
		{
			string path = "var.txt";
			StreamReader streamreader = new StreamReader(path);
			Type t = typeof(T);
			var meth = t.GetMethod(method);
			int count = meth.GetParameters().Count();
			object[] parametres = new object[count];
			int i = 0;
			while (streamreader.EndOfStream == false)
			{
				int y = int.Parse(streamreader.ReadLine());
				parametres[i] = y;
			}
			int x = (int)meth.Invoke(null, parametres);
			WriteLine(x);
			ReadKey();
		}

	}
}
