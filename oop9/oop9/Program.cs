using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;

namespace oop9
{
    class Program
    {
        static void Main(string[] args)
        {
            NPC1 npc1 = new NPC1();
            NPC2 npc2 = new NPC2();
            npc1.Heal += Show_Message;
            npc1.Attack += Show_Message;
            npc2.Heal += Show_Message;
            npc2.Attack += Show_Message;

            npc1.MinusHealth(20);
            npc1.MinusHealth(60);
            npc1.PlusHealth(400);
            npc1.MinusHealth(200);
            npc1.MinusHealth(20);
            npc1.PlusHealth(40);
            npc1.Stat();
            WriteLine();

            npc2.MinusHealth(90);
            npc2.PlusHealth(20);
            npc2.MinusHealth(50);
            npc2.PlusHealth(80);
            npc2.PlusHealth(20);
            npc2.PlusHealth(50);
            npc2.MinusHealth(30);
            npc2.Stat();
            WriteLine();

            Func<string> editor;

            new StringEdit("И наиболее используемыми, с которыми часто приходится сталкиваться, являются Action, Predicate и Func.");
            editor = StringEdit.DeletingPunctuationMarks;
            editor += StringEdit.ToLowerCase;
            editor += StringEdit.NumberAdding;
            editor += StringEdit.SpaceDeleting;
            editor += StringEdit.ToUpperCase;
            Operation(editor);
            WriteLine($"Окнончательный результат: {StringEdit.str}");
        }
        private static void Show_Message(string message) => WriteLine(message);
        private static void Operation(Func<string> editor)
        {
            if (StringEdit.str != null)
            {
                editor();
            }
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
        public static string ToUpperCase()
        {
            str = str.ToUpper();
            WriteLine(str);
            return str;
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

    class Game
    {
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

    class NPC1 : Game
    {

    }
    class NPC2 : Game
    {

    }
}
