using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using static System.Console;

namespace oop13
{
    class Program
    {
        static void Main(string[] args)
        {
            XXXLog.AllUsersActions();

            LogFile.SearchDay();
            LogFile.SearchKeyWord();
            LogFile.SearchTime();
            LogFile.LastHour();

        }
    }

    class XXXLog
    {
        static StreamWriter wr = new StreamWriter(@"D:\xxxlogfile.txt");
        public static void AllUsersActions()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"D:\";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
            watcher.Filter = "*.*";
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;

            DriveInfo drive = new DriveInfo(@"D:\");
            DirectoryInfo dir = new DirectoryInfo(@"D:\oop"); 
            FileInfo file = new FileInfo(@"D:\msdia80.dll");

            WriteLine("Task 2");
            XXXDiskInfo.FreeSpace(drive);
            XXXDiskInfo.FileSystem(drive);
            XXXDiskInfo.DriveInfo(drive);
            WriteLine("Task 3");
            XXXFileInfo.FullPath(file);
            XXXFileInfo.CreatingTime(file);
            XXXFileInfo.InfoOfFile(file);
            WriteLine("Task 4");
            XXXDirInfo.AmountFiles(dir);
            XXXDirInfo.CreatingTime(dir);
            XXXDirInfo.AmountDirectories(dir);
            XXXDirInfo.ParentDir(dir);

            XXXFileManager.GetFilesAndDirectories(dir);
            XXXFileManager.Task_a();
            XXXFileManager.Task_b("docx", @"D:\");
            XXXFileManager.Task_c();

            watcher.EnableRaisingEvents = false;
            wr.Close();
        }
        public static void OnCreated(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Name: " + e.Name);
            wr.WriteLine("Action: " + e.ChangeType);
            wr.WriteLine("Path to file: " + e.FullPath);
            wr.WriteLine("Time: " + DateTime.Now);
            wr.WriteLine();
        }

        public static void OnDeleted(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Name: " + e.Name);
            wr.WriteLine("Action: " + e.ChangeType);
            wr.WriteLine("Path to file: " + e.FullPath);
            wr.WriteLine("Time: " + DateTime.Now);
            wr.WriteLine();
        }

        public static void OnRenamed(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Name: " + e.Name);
            wr.WriteLine("Action: " + e.ChangeType);
            wr.WriteLine("Path to file: " + e.FullPath);
            wr.WriteLine("Time: " + DateTime.Now);
            wr.WriteLine();
        }

        public static void OnChanged(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Name: " + e.Name);
            wr.WriteLine("Action: " + e.ChangeType);
            wr.WriteLine("Path to file: " + e.FullPath);
            wr.WriteLine("Time: " + DateTime.Now);
            wr.WriteLine();
        }
    }

    class XXXDiskInfo
    {
        public static void FreeSpace(DriveInfo driv)
        {
            WriteLine($"Free size: {driv.TotalFreeSpace}");
        }
        public static void FileSystem(DriveInfo driv)
        {
            WriteLine($"File system: {driv.DriveFormat}");
        }
        public static void DriveInfo(DriveInfo driv)
        {
            WriteLine($"Drive name: {driv.Name}");
            WriteLine($"Drive size: {driv.TotalSize}");
            WriteLine($"Drive available size {driv.AvailableFreeSpace}");
            WriteLine($"Drive label: {driv.VolumeLabel}");
        }
    }

    class XXXFileInfo
    {
        public static void FullPath(FileInfo file)
        {
            WriteLine($"Whole path: {file.FullName}");
        }
        public static void InfoOfFile(FileInfo file)
        {
            WriteLine($"Size: {file.Length}");
        }
        public static void CreatingTime(FileInfo file)
        {
            WriteLine($"Creation time: {file.CreationTime}");
            WriteLine($"Extension: {file.Extension}");
            WriteLine($"File name: {file.Name}");
        }
    }

    class XXXDirInfo
    {
        public static void AmountFiles(DirectoryInfo dir)
        {
            WriteLine($"Number of files: {dir.EnumerateFiles().Count()}");
        }
        public static void CreatingTime(DirectoryInfo dir)
        {
            WriteLine($"Time of creation: {dir.CreationTime}");
        }
        public static void AmountDirectories(DirectoryInfo dir)
        {
            WriteLine($"Number of files: {dir.EnumerateDirectories().Count()}");
        }
        public static void ParentDir(DirectoryInfo dir)
        {
            WriteLine($"Parent catalog: {dir.Parent.Name}");
        }
    }

    class XXXFileManager
    {
        static FileInfo[] files;
        static DirectoryInfo[] dirs;
        static DirectoryInfo dir;
        static FileInfo file;
        public static void GetFilesAndDirectories(DirectoryInfo dir)
        {
            files = dir.GetFiles();
            dirs = dir.GetDirectories();
        }
        public static void Task_a()
        {
            dir = Directory.CreateDirectory(@"D:\XXXInspect");
            file = new FileInfo(@"D:\XXXInspect\xxxdirinfo.txt");
            using (StreamWriter writer = new StreamWriter(@"D:\XXXInspect\xxxdirinfo.txt"))
            {
                writer.WriteLine("List of directories:");
                foreach (DirectoryInfo d in dirs)
                {
                    writer.WriteLine($"- {d.Name}");
                }
                writer.WriteLine();

                writer.WriteLine("List of files:");
                foreach (FileInfo f in files)
                {
                    writer.WriteLine($"- {f.Name}");
                }
                writer.WriteLine();
            }
            file.CopyTo(@"D:\XXXInspect\xxxdirinfo_copy.txt", true);
            file.Delete();
        }

        public static void Task_b(string ext, string path)
        {
            dir = Directory.CreateDirectory(@"D:\XXXFiles");
            DirectoryInfo dir2 = new DirectoryInfo(path);
            FileInfo[] files2 = dir2.GetFiles($"*.{ext}*");
            foreach (FileInfo f in files2)
            {
                f.CopyTo(@"D:\XXXFiles\" + f.Name, true);
            }
            DirectoryInfo d = new DirectoryInfo(@"D:\XXXFiles");
            d.MoveTo(@"D:\XXXInspect\XXXFiles");
        }

        public static void Task_c()
        {
            Directory.CreateDirectory(@"D:\XXXInspect\Other");
            ZipFile.CreateFromDirectory(@"D:\XXXInspect\XXXFiles", @"D:\XXXInspect\XXXFiles.zip");
            ZipFile.ExtractToDirectory(@"D:\XXXInspect\XXXFiles.zip", @"D:\XXXInspect\Other");
        }
    }

    class LogFile
    {
        static string[] lines = new string[5];
        static string line;
        static int count = 0;
        static bool check = false;
        static string word;
        static string date;
        static string hours;
        static string minutes;
        public static void SearchKeyWord()
        {
            StreamReader streamReader = new StreamReader(@"D:\xxxlogfile.txt");
            WriteLine("Enter keyword");
            word = ReadLine();
            check = false;
            while (!streamReader.EndOfStream)
            {
                lines[0] = streamReader.ReadLine();
                lines[1] = streamReader.ReadLine();
                lines[2] = streamReader.ReadLine();
                lines[3] = streamReader.ReadLine();
                lines[4] = streamReader.ReadLine();
                check = true;
                if (check)
                {
                    line = lines[0];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    if (line == word)
                    {
                        WriteLine(lines[0]);
                        WriteLine(lines[1]);
                        WriteLine(lines[2]);
                        WriteLine(lines[3]);
                        WriteLine(lines[4]);
                        check = false;
                    }
                }
            }
            streamReader.Close();
        }

        public static void SearchDay()
        {
            StreamReader streamReader = new StreamReader(@"D:\xxxlogfile.txt");
            WriteLine("Set date: ");
            date = ReadLine();
            check = false;
            while (!streamReader.EndOfStream)
            {
                lines[0] = streamReader.ReadLine();
                lines[1] = streamReader.ReadLine();
                lines[2] = streamReader.ReadLine();
                lines[3] = streamReader.ReadLine();
                lines[4] = streamReader.ReadLine();
                check = true;
                if (check)
                {
                    line = lines[3];
                    line = line.Substring(line.IndexOf(' ') + 1, 2);
                    if (line == date)
                    {
                        WriteLine(lines[0]);
                        WriteLine(lines[1]);
                        WriteLine(lines[2]);
                        WriteLine(lines[3]);
                        WriteLine(lines[4]);
                        check = false;
                    }
                }
            }
            streamReader.Close();
        }

        public static void SearchTime()
        {
            StreamReader streamReader = new StreamReader(@"D:\xxxlogfile.txt");
            WriteLine("Enter hours: ");
            hours = ReadLine();
            WriteLine("Enter minutes: ");
            minutes = ReadLine();
            check = false;
            while (!streamReader.EndOfStream)
            {
                lines[0] = streamReader.ReadLine();
                lines[1] = streamReader.ReadLine();
                lines[2] = streamReader.ReadLine();
                lines[3] = streamReader.ReadLine();
                lines[4] = streamReader.ReadLine();
                count++;
                check = true;
                if (check)
                {
                    line = lines[3];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
                    if (Convert.ToInt32(hours) <= Convert.ToInt32(line) && Convert.ToInt32(minutes) >= Convert.ToInt32(line))
                    {
                        WriteLine(lines[0]);
                        WriteLine(lines[1]);
                        WriteLine(lines[2]);
                        WriteLine(lines[3]);
                        WriteLine(lines[4]);
                        check = false;
                    }
                }
            }
            streamReader.Close();
            WriteLine($"Count of notes: {count}");
        }

        public static void LastHour()
        {
            StreamReader streamReader = new StreamReader(@"D:\xxxlogfile.txt");
            List<string> ListLog = new List<string>();
            List<string> ListLogResult = new List<string>();
            DateTime time = DateTime.Now;
            int Hour = time.Hour;
            string Date = time.Day + "." + time.Month + "." + time.Year;
            string line, line2;
            while (!streamReader.EndOfStream)
            {
                ListLog.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            for (int i = 0; i < ListLog.Count; i++)
            {
                if (ListLog[i].Contains("Время"))
                {
                    line = ListLog[i];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line2 = line.Substring(0, line.IndexOf(' '));
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
                    if (Hour == Convert.ToInt32(line) && Date == line2)
                    {
                        ListLogResult.Add(ListLog[i - 3]);
                        ListLogResult.Add(ListLog[i - 2]);
                        ListLogResult.Add(ListLog[i - 1]);
                        ListLogResult.Add(ListLog[i]);
                        ListLogResult.Add(ListLog[i + 1]);
                    }
                }
            }
            StreamWriter writer = new StreamWriter(@"D:\xxxlogfile.txt", true);
            writer.WriteLine("\n\nFor last hour:");
            for (int i = 0; i < ListLogResult.Count; i++)
                writer.WriteLine(ListLogResult[i]);
            writer.Close();
        }
    }
}
