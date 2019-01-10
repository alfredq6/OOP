using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace oop12
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gamer1 = new Game();

            StringEdit string1 = new StringEdit("String");

            Reflector.AllPartsOfClass<StringEdit>(string1);
            WriteLine("The second task: \n");
            Reflector.GetPublicMethods<StringEdit>(string1);
            Reflector.GetPublicMethods<Game>(gamer1);
            WriteLine("The third task: \n");
            Reflector.GetFieldsAndProperties<StringEdit>(string1);
            Reflector.GetFieldsAndProperties<Game>(gamer1);
            WriteLine("The forth task: \n");
            Reflector.GetInterfacesOfClass<StringEdit>(string1);
            Reflector.GetInterfacesOfClass<Game>(gamer1);
            WriteLine("The fifth task: \n");
            Reflector.NamedMethod<StringEdit>(string1);
            WriteLine("The sixth task: \n");
            Reflector.ParamsFromTXT<StringEdit>(string1);
        }
    }

    class Reflector
    {
        public static void AllPartsOfClass<T>(T obj) where T: class
        {
            StreamWriter stream_file = new StreamWriter("Test.txt");
            Type type = typeof(T);
            ConstructorInfo[] constructors = type.GetConstructors();
            stream_file.WriteLine($"Конструкторы класса {obj.GetType().Name}");
            foreach (ConstructorInfo oneOf in constructors)
            {
                stream_file.Write($"- {oneOf.DeclaringType.Name} (");
                ParameterInfo[] param = oneOf.GetParameters();
                for (int i = 0; i < param.Length; i++)
                {
                    stream_file.Write(param[i].ParameterType.Name + " " + param[i].Name);
                    if (i + 1 < param.Length)
                    {
                        Write(", ");
                    }
                }
                stream_file.Write(")\n");
            }

            FieldInfo[] fields = type.GetFields();
            stream_file.WriteLine($"\nПоля класса {obj.GetType().Name} :");
            foreach (FieldInfo o in fields)
            {
                stream_file.WriteLine($"- {o.Name}");
            }

            MethodInfo[] MethodArray = type.GetMethods();
            stream_file.WriteLine($"Методы класса {obj.GetType().Name} :\n");
            foreach (MethodInfo method in MethodArray)
            {
                stream_file.Write($"- {method.ReturnType.Name} \t {method.Name} (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    stream_file.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length)
                    {
                        stream_file.Write(", ");
                    }
                }
                stream_file.Write(")\n");
            }

            stream_file.Close();
        }

        public static void GetPublicMethods<T>(T obj) where T : class
        {
            Type type = typeof(T);
            MethodInfo[] MethodArray = type.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.Public);
            WriteLine($"Список Public методов класса {obj.GetType().Name}\n");

            foreach (MethodInfo method in MethodArray)
            {
                Write($"- {method.ReturnType.Name}\t {method.Name}()\n");
            }
        }
        public static void GetFieldsAndProperties<T>(T obj) where T : class
        {
            Type type = typeof(T);
            FieldInfo[] fieldInfo = type.GetFields();
            WriteLine($"\nПоля класса {obj.GetType().Name}");
            foreach (FieldInfo field in fieldInfo)
            {
                WriteLine($"- {field.FieldType.Name} \t {field.Name}");
            }
            PropertyInfo[] propertyInfo = type.GetProperties();
            WriteLine($"\nСвойства класса {obj.GetType().Name}");
            foreach (PropertyInfo property in propertyInfo)
            {
                WriteLine($"- {property.PropertyType.Name} \t {property.Name}");
            }

        }
        public static void GetInterfacesOfClass<T>(T obj) where T : class
        {
            Type type = typeof(T);
            Type[] interfaces = type.GetInterfaces();
            foreach (Type interf in interfaces)
            {
                WriteLine($"- {interf.Name}");
            }
        }
        public static void NamedMethod<T>(T obj) where T : class
        {
            WriteLine("Введите тип параметра");
            string str = ReadLine();
            Type type = typeof(T);
            MethodInfo[] methodInfo = type.GetMethods();
            foreach (MethodInfo method in methodInfo)
            {
                ParameterInfo[] parametr = method.GetParameters();
                for (int i = 0; i < parametr.Length; i++)
                {
                    if (parametr[i].ParameterType.Name == str)
                    {
                        Write($"- {method.ReturnType.Name} \t {method.Name} (");
                        for (int j = 0; j < parametr.Length; j++)
                        {
                            Write($"{parametr[j].ParameterType.Name} { parametr[j].Name}");
                            Write(", ");
                        }
                        Write(")\n");
                    }
                }
                if (parametr.Length == 0 && str == "")
                {
                    WriteLine($"- {method.ReturnType.Name} \t {method.Name}()");
                }
            }

        }
        public static void ParamsFromTXT<T>(T obj) where T : class
        {
            StreamReader reader = new StreamReader("parametr.txt", Encoding.Default);
            string param;
            param = reader.ReadLine();
            reader.Close();
            StringEdit.ToUpperCase(param);
        }
    }

    class StringEdit
    {
        public static string str;
        public StringEdit(string _str)
        {
            str = _str;
        }
        public static string DeletingPunctuationMarks()
        {
            string[] newArr = str.Split(new char[] { ',', '.', ';', ':', '?', '!', '-' });
            str = null;
            for (int i = 0; i < newArr.Length; i++)
            {
                str += newArr[i];
            }
            WriteLine(str);
            return str;
        }
        public static string NumberAdding()
        {
            str += 1234.ToString();
            WriteLine(str);
            return str;
        }
        public static string ToUpperCase(string param_str)
        {
            param_str = param_str.ToUpper();
            WriteLine(param_str);
            return param_str;
        }
        public static string ToLowerCase()
        {
            str = str.ToLower();
            WriteLine(str);
            return str;
        }
        public static string SpaceDeleting()
        {
            String[] words = str.Split(new char[] { ' ' });
            str = null;
            for (int i = 0; i < words.Length; i++)
            {
                str += words[i];
            }
            WriteLine(str);
            return str;
        }
    }

    interface ITest
    {
        void Test();
    }

    class Game : ITest
    {
        public void Test()
        {
            Write(" ");
        }
        public int health = 100;
        private int _health;
        public delegate void Act(string message);
        public event Act Attack;
        public event Act Heal;
        public void PlusHealth(int value)
        {
            _health = health + value;
            if (_health > 100 && health != 100)
            {
                Heal($"Превышено максимальное количесвто здоровья игрока {this.GetType().Name}, вылечено только {100 - health} очков здоровья");
                health = 100;
            }
            else if (health == 100)
            {
                Heal($"Без изменений здоровья игрока {this.GetType().Name}");
            }
            else
            {
                Heal($"Восстановлено {value} очков здоровья игрока {this.GetType().Name}");
                health = _health;
            }
        }

        public void MinusHealth(int value)
        {
            _health = health - value;
            if (_health <= 0 && health != 0)
            {
                Attack($"Превышено минимальное значение здоровья игрока {this.GetType().Name}, нанесено только {-(0 - health)} единиц урона");
                health = 0;
            }
            else if (health == 0)
            {
                Attack($"Без изменений здоровья {this.GetType().Name}");
            }
            else
            {
                Attack($"Игрок {this.GetType().Name} получает {value} единиц урона");
                health = _health;
            }
        }
        public void Stat() => WriteLine($"Количество здоровья игрока {this.GetType().Name}: {health}");
    }
}
