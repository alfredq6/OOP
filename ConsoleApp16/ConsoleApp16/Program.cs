using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp16
{
	class Program
	{
		static void Main(string[] args)
		{
			//Задание 1
			DDGLog.FileW();

			//Задание 2-5 вызываются в DDGLog

			//Задание 6
			LogFileSearch.SearchName();
			LogFileSearch.SearchDay();
			LogFileSearch.SearchTime();
			LogFileSearch.LastHourOnly();
		}
	}

	class DDGLog
	{
		static StreamWriter wr = new StreamWriter(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
		public static void FileW()
		{
			try
			{
				FileSystemWatcher watcher = new FileSystemWatcher();
				watcher.Path = @"D:\Programming\ConsoleApp16";
				watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
				watcher.Filter = "*.*";
				watcher.Created += new FileSystemEventHandler(OnCreated);
				watcher.Deleted += new FileSystemEventHandler(OnDeleted);
				watcher.Renamed += new RenamedEventHandler(OnRenamed);
				watcher.Changed += new FileSystemEventHandler(OnChanged);
				watcher.EnableRaisingEvents = true;

				WriteLine("Задание 2.");
				DDGDiskInfo.Info();
				WriteLine("Задание 3.");
				DDGFileInfo.Info();
				WriteLine("Задание 4.");
				DDGDIrInfo.Info();
				//Задание 5.
				DDGFileManager.A();
				DDGFileManager.B();
				DDGFileManager.C();

				watcher.EnableRaisingEvents = false;
				wr.Close();
			}
			catch (Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}
		public static void OnCreated(object sendler, FileSystemEventArgs e)
		{
			wr.WriteLine("Имя: " + e.Name);
			wr.WriteLine("Действие: " + e.ChangeType);
			wr.WriteLine("Путь к файлу^ " + e.FullPath);
			wr.WriteLine("Время: " + DateTime.Now);
			wr.WriteLine();
		}

		public static void OnDeleted(object sendler, FileSystemEventArgs e)
		{
			wr.WriteLine("Имя: " + e.Name);
			wr.WriteLine("Действие: " + e.ChangeType);
			wr.WriteLine("Путь к файлу^ " + e.FullPath);
			wr.WriteLine("Время: " + DateTime.Now);
			wr.WriteLine();
		}

		public static void OnRenamed(object sendler, FileSystemEventArgs e)
		{
			wr.WriteLine("Имя: " + e.Name);
			wr.WriteLine("Действие: " + e.ChangeType);
			wr.WriteLine("Путь к файлу^ " + e.FullPath);
			wr.WriteLine("Время: " + DateTime.Now);
			wr.WriteLine();
		}

		public static void OnChanged(object sendler, FileSystemEventArgs e)
		{
			wr.WriteLine("Имя: " + e.Name);
			wr.WriteLine("Действие: " + e.ChangeType);
			wr.WriteLine("Путь к файлу^ " + e.FullPath);
			wr.WriteLine("Время: " + DateTime.Now);
			wr.WriteLine();
		}
	}

	class DDGDiskInfo
	{
		static DriveInfo[] drives = DriveInfo.GetDrives();
		public static void Info()
		{
			try
			{
				foreach(DriveInfo dr in drives)
				{
					WriteLine("Имя диска: " + dr.Name);
					WriteLine("Свободное место на диске: " + dr.TotalFreeSpace);
					WriteLine("Файловая система: " + dr.DriveFormat);
					WriteLine("Объем: " + dr.TotalSize);
					WriteLine("Доступный объем: " + dr.AvailableFreeSpace);
					WriteLine("Метка тома: " + dr.VolumeLabel);
					WriteLine();
				}
			}
			catch (Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}		 
		}
	}

	class DDGFileInfo
	{
		public static void Info()
		{
			try
			{
				WriteLine("Введите путь к файлу, информацию о котором хотите просмотреть...");
				string s = ReadLine();
				FileInfo file = new FileInfo(s);
				WriteLine("Имя файла: " + file.Name);
				WriteLine("размер файла: " + file.Length + " байт");
				WriteLine("расширение файла: " + file.Extension);
				WriteLine("Полный путь: " + file.FullName);
				WriteLine("Время создания: " + file.CreationTime);
				WriteLine();
			}
			catch(Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}
	}

	class DDGDIrInfo
	{
		public static void Info()
		{
			try
			{
				WriteLine("Введите путь директория...");
				string str = ReadLine();
				DirectoryInfo dir = new DirectoryInfo(str);
				WriteLine("Полное имя директория: " + dir.FullName);
				WriteLine("Время создания: " + dir.CreationTime);
				WriteLine("Количество файлов: " + dir.EnumerateFiles().Count());
				WriteLine("Количество поддиректориев: " + dir.EnumerateDirectories().Count());
				WriteLine("Родительский директорий: " + dir.Root);
				WriteLine();
			}
			catch(Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}
	}

	class DDGFileManager
	{
		static DriveInfo drive = new DriveInfo(@"D:\");
		static DirectoryInfo dir;
		static string[] files = Directory.GetFiles(@"D:\");
		static string[] directories = Directory.GetDirectories(@"D:\");
		static FileInfo file;

		public static void A()
		{
			try
			{
				dir = Directory.CreateDirectory(@"D:\Programming\ConsoleApp16\DDGInspect");
				file = new FileInfo(@"D:\Programming\ConsoleApp16\DDGInspect\ddgdirinfo.txt");
				using (StreamWriter writer = new StreamWriter(@"D:\Programming\ConsoleApp16\DDGInspect\ddgdirinfo.txt"))
				{
					writer.WriteLine("Список директоиев диска D:");
					foreach (string s in directories)
						writer.WriteLine(s);
					writer.WriteLine();
					writer.WriteLine("Список файлов диска D:");
					foreach (string s in files)
						writer.WriteLine(s);
					writer.WriteLine();
				}
				file.CopyTo(@"D:\Programming\ConsoleApp16\DDGInspect\ddgdirinfo_copy.txt", true);
				file.Delete();
			}
			catch(Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}

		public static void B()
		{
			try
			{
				dir = Directory.CreateDirectory(@"D:\Programming\ConsoleApp16\DDGFiles");
				DirectoryInfo d = new DirectoryInfo(@"D:\Hello");
				FileInfo[] file = d.GetFiles("*.txt*");
				for (int i = 0; i < file.Length; i++)
					file[i].CopyTo(@"D:\Programming\ConsoleApp16\DDGFiles\" + file[i].Name, true);
				d = new DirectoryInfo(@"D:\Programming\ConsoleApp16\DDGFiles");
				d.MoveTo(@"D:\Programming\ConsoleApp16\DDGInspect\DDGFiles");
			}
			catch(Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}

		public static void C()
		{
			try
			{
				DirectoryInfo directory=new DirectoryInfo(@"D:\Programming\ConsoleApp16\DDGInspect\DDGFiles");
				FileInfo[] Fil = directory.GetFiles("*");
				ZipFile.CreateFromDirectory(@"D:\Programming\ConsoleApp16\DDGInspect\DDGFiles", @"D:\Programming\ConsoleApp16\DDGInspect\DDGFiles.zip");
				ZipFile.ExtractToDirectory(@"D:\Programming\ConsoleApp16\DDGInspect\DDGFiles.zip", @"D:\Programming\ConsoleApp16");
			}
			catch (Exception ex)
			{
				WriteLine("Ошибка: " + ex.Message);
			}
		}
	}

	class LogFileSearch
	{
		static int count;
		static StreamReader streamreader = new StreamReader(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
		static string line;
		static string[] LogBlock = new string[5];
		public static void SearchName()
		{
			WriteLine("Введите имя для поиска по имени (например laba12.txt)...");
			string name = ReadLine();
			WriteLine($"Поиск по имени <{name}>");
			bool check = false;
			while(!streamreader.EndOfStream)
			{
				LogBlock[0] = streamreader.ReadLine();
				LogBlock[1] = streamreader.ReadLine();
				LogBlock[2] = streamreader.ReadLine();
				LogBlock[3] = streamreader.ReadLine();
				LogBlock[4] = streamreader.ReadLine();
				check = true;
				if(check)
				{
					line = LogBlock[0];
					line = line.Substring(line.IndexOf(' ') + 1);
					if (line == name)
					{
						WriteLine(LogBlock[0]);
						WriteLine(LogBlock[1]);
						WriteLine(LogBlock[2]);
						WriteLine(LogBlock[3]);
						WriteLine(LogBlock[4]);
						check = false;
					}
				}
			}
			streamreader.Close();
		}
		public static void SearchDay()
		{
			streamreader = new StreamReader(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
			WriteLine("Укажите дату для поиска (например 23)...");
			string name = ReadLine();
			WriteLine($"Поиск по дате <{name}>");
			bool check = false;
			while(!streamreader.EndOfStream)
			{
				LogBlock[0] = streamreader.ReadLine();
				LogBlock[1] = streamreader.ReadLine();
				LogBlock[2] = streamreader.ReadLine();
				LogBlock[3] = streamreader.ReadLine();
				LogBlock[4] = streamreader.ReadLine();
				check = true;
				if(check)
				{
					line = LogBlock[3];
					line = line.Substring(line.IndexOf(' ') + 1, 2);
					if(line==name)
					{
						WriteLine(LogBlock[0]);
						WriteLine(LogBlock[1]);
						WriteLine(LogBlock[2]);
						WriteLine(LogBlock[3]);
						WriteLine(LogBlock[4]);
						check = false;
					}
				}
			}
			streamreader.Close();
		}
		public static void SearchTime()
		{
			streamreader = new StreamReader(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
			WriteLine("Введите время time1 (например 15)...");
			string time1 = ReadLine();
			WriteLine("Введите время time2 (например 23)...");
			string time2 = ReadLine();
			WriteLine($"Поиск по времени <{time1} - {time2}>");
			bool check = false;
			while(!streamreader.EndOfStream)
			{
				LogBlock[0] = streamreader.ReadLine();
				LogBlock[1] = streamreader.ReadLine();
				LogBlock[2] = streamreader.ReadLine();
				LogBlock[3] = streamreader.ReadLine();
				LogBlock[4] = streamreader.ReadLine();
				count++;
				check = true;
				if(check)
				{
					line = LogBlock[3];
					line = line.Substring(line.IndexOf(' ') + 1);
					line = line.Substring(line.IndexOf(' ') + 1);
					line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
					if(Convert.ToInt32(time1)<=Convert.ToInt32(line)&&Convert.ToInt32(time2)>=Convert.ToInt32(line))
					{
						WriteLine(LogBlock[0]);
						WriteLine(LogBlock[1]);
						WriteLine(LogBlock[2]);
						WriteLine(LogBlock[3]);
						WriteLine(LogBlock[4]);
						check = false;
					}
				}
			}
			streamreader.Close();
			WriteLine("Количество записей: " + count);
		}
		public static void LastHourOnly()
		{
			streamreader = new StreamReader(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
			List<string> ListLog = new List<string>();
			List<string> ListLogResult = new List<string>();
			DateTime time = DateTime.Now;
			int Hour = time.Hour;
			string Date = time.Day + "." + time.Month + "." + time.Year;
			string line, line2;
			while(!streamreader.EndOfStream)
			{
				ListLog.Add(streamreader.ReadLine());
			}
			streamreader.Close();
			for(int i=0;i<ListLog.Count;i++)
			{
				if(ListLog[i].Contains("Время"))
				{
					line = ListLog[i];
					line = line.Substring(line.IndexOf(' ') + 1);
					line2 = line.Substring(0, line.IndexOf(' '));
					line = line.Substring(line.IndexOf(' ') + 1);
					line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
					if(Hour==Convert.ToInt32(line) && Date==line2)
					{
						ListLogResult.Add(ListLog[i - 3]);
						ListLogResult.Add(ListLog[i - 2]);
						ListLogResult.Add(ListLog[i - 1]);
						ListLogResult.Add(ListLog[i]);
						ListLogResult.Add(ListLog[i + 1]);
					}
				}
			}
			StreamWriter writer = new StreamWriter(@"D:\Programming\ConsoleApp16\ddglofgile.txt");
			for (int i = 0; i < ListLogResult.Count; i++)
				writer.WriteLine(ListLogResult[i]);
			writer.Close();
		}
	}
}
