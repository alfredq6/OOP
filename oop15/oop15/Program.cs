using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace oop15
{
    class Program
    {
        public static int num;
        static Thread thread, thread1, thread2;
        static AutoResetEvent AutoR1 = new AutoResetEvent(true), AutoR2 = new AutoResetEvent(true);
        static void Main(string[] args)
        {

            Process[] processes = Process.GetProcesses();
            WriteLine("Task 1");
            for (int i = 0; i < processes.Length; i++)
            {
                try
                {
                    WriteLine($"ID: {processes[i].Id}\tProcess name: {processes[i].ProcessName}\tStart time: {processes[i].StartTime}\tPriority: {processes[i].PriorityClass}\tResponding: " + (processes[i].Responding ? "Run" : "Stop"));
                }
                catch (Exception ex)
                {
                    WriteLine($"ID: {processes[i].Id}\tProcess name: {processes[i].ProcessName}\tException - {ex.Message}");
                }
            }

            WriteLine("\nTask 2");
            AppDomain domain = AppDomain.CurrentDomain;
            WriteLine($"Domain name: {domain.FriendlyName}");
            WriteLine($"ID: {domain.Id}");
            WriteLine($"Path: {domain.BaseDirectory}");
            WriteLine("All assemblies:");
            var Assemblies = from asembl in domain.GetAssemblies()
                             orderby asembl.GetName().Name
                             select asembl;
            foreach (var asembl in Assemblies)
            {
                WriteLine($"Assembly name: {asembl.GetName().Name}\tVersion: {asembl.GetName().Version}");
            }

            AppDomain newDomain = AppDomain.CreateDomain("New domain");
            domain.DomainUnload += DomUnload;
            domain.AssemblyLoad += AssLoad;
            WriteLine($"Domain {newDomain.FriendlyName}");
            newDomain.Load("oop5");
            Assembly[] assembl = newDomain.GetAssemblies();
            foreach (Assembly assemb in assembl)
            {
                WriteLine($"Name: {assemb.GetName().Name}");
            }
            AppDomain.Unload(newDomain);
            WriteLine("Domain unload\n");

            WriteLine("Task 3\nEnter number ");

            num = Convert.ToInt32(ReadLine());
            thread = new Thread(new ThreadStart(Task3));
            thread.Name = "Task 3 thread";
            thread.Start();
            thread.Join();

            WriteLine("\nTask 4");
            WriteLine("Enter number again ");
            num = Convert.ToInt32(ReadLine());
            thread1 = new Thread(new ThreadStart(Chet));
            thread2 = new Thread(new ThreadStart(Nechet));
            thread1.Start();
            thread2.Priority = ThreadPriority.AboveNormal;
            thread2.Start();
            thread2.Join();
            WriteLine("One is chet and another one is nechet: ");
            thread1 = new Thread(new ThreadStart(Chet2));
            thread2 = new Thread(new ThreadStart(Nechet2));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            WriteLine("\nTask 5");
            int y = 3;
            TimerCallback time = new TimerCallback(TC);
            Timer tm = new Timer(time, y, 2000, 1000);

        }
        private static void DomUnload(object sender, EventArgs e)
        {
            WriteLine("Domain is unload");
        }

        private static void AssLoad(object sender, AssemblyLoadEventArgs args)
        {
            WriteLine("Assembly is load");
        }
        public static bool Simple(int t)
        {
            for (int i = 2; i < t / 2; i++)
            {
                if (t % i == 0)
                    return false;
            }
            return true;
        }

        public static void Task3()
        {
            StreamWriter stream = new StreamWriter("task3.txt");
            for (int i = 0; i < num; i++)
            {
                if (Simple(i) && i != 4)
                {
                    Write(i + ", ");
                    stream.Write(i + ", ");
                    Thread.Sleep(300);
                }
                if (i == num / 3)
                {
                    try
                    {
                        thread.Abort();
                    }
                    catch
                    {
                        WriteLine();
                        WriteLine("Thread is paused ");
                        Thread.ResetAbort();
                        WriteLine("Thread's work is resumed");
                    }
                }
            }

            WriteLine();
            stream.Close();
            WriteLine("Thread info: ");
            WriteLine($"ID: {thread.ManagedThreadId}");
            WriteLine($"Name: {thread.Name}");
            WriteLine($"Status: {thread.ThreadState}");
            WriteLine($"Priority: {thread.Priority}");
        }
        public static void Chet()
        {
            FileStream fs = new FileStream("task4.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            WriteLine("Четные числа: ");
            sw.WriteLine("Четные числа: ");
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                {
                    Write(i + ", ");
                    sw.Write(i + ", ");
                }
            }
            WriteLine();
            sw.WriteLine();
            sw.Close();
            fs.Close();
        }

        public static void Nechet()
        {
            thread1.Join();
            FileStream fs = new FileStream("task4.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            WriteLine("Нечетные числа: ");
            sw.WriteLine("Нечетные числа: ");
            for (int i = 0; i < num; i++)
            {
                if (i % 2 != 0)
                {
                    Write(i + ", ");
                    sw.Write(i + ", ");
                }
            }
            WriteLine();
            sw.WriteLine();
            sw.Close();
            fs.Close();
        }
        public static void Chet2()
        {
            for (int i = 0; i <= num; i++)
            {
                AutoR2.WaitOne();
                if (i % 2 == 0)
                    Write(i + ", ");
                AutoR1.Set();
            }
        }

        public static void Nechet2()
        {
            for (int i = 0; i <= num; i++)
            {
                AutoR1.WaitOne();
                if (i % 2 != 0)
                    Write(i + ", ");
                AutoR2.Set();
            }
        }

        public static void TC(object t)
        {
            int x = (int)t;
            for (int i = 1; i <= x; i++)
                WriteLine($"{i}+{i} = {i + i}");
            WriteLine();
        }
    }
}
