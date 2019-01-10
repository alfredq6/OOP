using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace oop10
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            ArrayList arrayList = new ArrayList { 3, 54, 12, 32, 89 };
            arrayList.Add("Some_string");
            arrayList.Add(student);
            arrayList.RemoveAt(3);
            WriteLine($"Number of elements in arraylist: {arrayList.Count}");
            Write("Elements of arraylist: ");
            foreach (object element in arrayList)
            {
                Write(element + " ");
            }
            WriteLine("\nEnter value ");
            string value = ReadLine();
            bool being = false;
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i].ToString() == value)
                {
                    being = true;
                    WriteLine($"{arrayList[i]} (its index is {i + 1})");
                }
            }
            if (!being)
            {
                WriteLine("Entered value has bot found");
            }

            // 9 SortedSet<T> float Queue<T>

            SortedSet<float> vs = new SortedSet<float> { 2.4f, 64.2f, 23.78f, 23.11f, 91.001f };
            WriteLine("Sorted Set: ");

            foreach (float elem in vs)
            {
                Write(elem + " ");
            }
            WriteLine("\nEnter nessesary value for deleting elemets");
            float n = float.Parse(ReadLine());
            vs.Remove(n);
            vs.Add(23f);
            // #####
            Queue<float> queue = new Queue<float>();
            foreach (float elem in vs)
            {
                queue.Enqueue(elem);
            }
            Write("Queue: ");
            foreach (float elem in queue)
            {
                Write(elem + " ");
            }
            WriteLine("\nEnter float value (12,34) ");
            value = ReadLine();
            being = false;
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.Dequeue().ToString() == value)
                {
                    WriteLine("Your value in queue: " + value);
                    being = true;
                }
            }
            if (!being)
            {
                WriteLine("Entered value has bot found");
            }
            //##############################################################

            vs.Clear();
            queue.Clear();

            SortedSet<User> setOfUsers = new SortedSet<User>();
            setOfUsers.Add(new User("Name1"));
            setOfUsers.Add(new User("Name2"));
            setOfUsers.Add(new User("Name3"));
            setOfUsers.Add(new User("Name4"));
            setOfUsers.Add(new User("Name5"));

            WriteLine("Sorted Set: ");
            foreach (User user in setOfUsers)
            {
                Write(user.Name + " ");
            }
            WriteLine("\nEnter nessesary for deleting user name ");
            string _value = ReadLine();
            foreach (User user in setOfUsers)
            {
                if (user.Name == _value)
                {
                    setOfUsers.Remove(user);
                }
            }
            setOfUsers.Add(new User("AddedName"));


            Queue<User> queueOfUsers = new Queue<User>();
            foreach(User user in setOfUsers)
            {
                queueOfUsers.Enqueue(user);
            }
            Write("Users in queue: ");
            foreach(User user in queueOfUsers)
            {
                Write(user + " ");
            }

            WriteLine("\nEnter float value (12,34) ");
            value = ReadLine();
            being = false;
            for (int i = 0; i < queueOfUsers.Count; i++)
            {
                if (queueOfUsers.Dequeue().Name == value)
                {
                    WriteLine("Your value in queue: " + value);
                    being = true;
                }
            }
            if (!being)
            {
                WriteLine("Entered value has bot found");
            }

            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User ("Bill"),
                new User ("Tom"),
                new User ("Alice")
            };

            users.CollectionChanged += Users_CollectionChanged;

            users.Add(new User("Bob"));
            users.RemoveAt(1);
            users[0] = new User("Anders");

            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine("Добавлен новый объект: {0}", newUser.Name);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine("Удален объект: {0}", oldUser.Name);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine("Объект {0} заменен объектом {1}",
                                        replacedUser.Name, replacingUser.Name);
                    break;
            }
        }
    }

    class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }

    class Student
    {

    }
}