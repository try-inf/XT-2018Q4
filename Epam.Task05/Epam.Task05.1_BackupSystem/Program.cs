using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task05._1_BackupSystem
{
    public class Program
    {
        static string projpath = Directory.GetCurrentDirectory();

        public static List<LogEntry> currentLog = new List<LogEntry>() { };

        public static void Main(string[] args)
        {
            Init();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void Init()
        {
            Console.WriteLine("By using this application you can watch all changes in specified directory and its subdirectories");
            Console.WriteLine("By default, the folder that will be wathced is located in the сurrent project directory and called \"folder2watch\".");
            Console.WriteLine();
            Console.WriteLine("You can choose an option to do:");
            Console.WriteLine("\t 1: To watch the folder.");
            Console.WriteLine("\t 2: To rollback to some time.");
            Console.WriteLine();
            Console.WriteLine("If you want to quit application type \"exit\".");
            Console.WriteLine();
            Console.Write("Your choice: ");

            if (!Directory.Exists(Path.Combine(projpath, "folder2watch")))
                Directory.CreateDirectory(Path.Combine(projpath, "folder2watch"));

            while (true)
            {
                string s = Console.ReadLine();
                
                if (s == "1")
                {
                    SystemWatcherDemo();
                    break;
                }
                else if (s == "2")
                {
                    Rollback();
                    break;
                }
                else if (s.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose the correct option.");
                }

            }
        }

        private static void SystemWatcherDemo()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = projpath + @"\folder2watch";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(onChanged);
            watcher.Created += new FileSystemEventHandler(onCreated);
            watcher.Deleted += new FileSystemEventHandler(onDeleted);
            watcher.Renamed += new RenamedEventHandler(onRenamed);
            

            watcher.EnableRaisingEvents = true;
            Console.WriteLine("The folder is watching....");
            Console.WriteLine();
            Console.WriteLine(@"Type 'exit' and press enter to quit watching and return to main menu");
            while (Console.ReadLine() != "exit") ;
            watcher.IncludeSubdirectories = false;
            SaveLog();
            Init();

        }

        private static void Rollback()
        {
            OpenLog();
            DateTime dt;
            while (true)
            {
                Console.WriteLine("Please enter rollback Date (input format: dd.mm.yyyy hh:mm:ss): ");
                bool check = DateTime.TryParse(Console.ReadLine(), out DateTime result);
                if (check)
                {
                    Console.Write("Is it correct Date and Time to rollback: {0}? (y/n)", result);
                    string s = Console.ReadLine();
                    if (s.ToLower() == "y")
                    {
                        dt = result;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }

            Console.WriteLine("you entered: {0} ", dt);

            List<DateTime> dates = new List<DateTime> { };
            foreach (var item in currentLog)
            {
                string format = (item.DT_Modify.Substring(13, 1) == ":") ? "dd.MM.yyyy HH:mm:ss" : "dd.MM.yyyy H:mm:ss";
                dates.Add(DateTime.ParseExact(item.DT_Modify, format, CultureInfo.CurrentCulture));
            }
            
            DateTime searchDate = dates.Where(x => x <= dt).Max();
            Console.WriteLine("desirable date: {0}", searchDate);

            int n = Array.IndexOf(dates.ToArray(), searchDate);

            for (int i = currentLog.Count - 1; i > n; i--)
            {
                string action = currentLog[i].TypeOfChange;

                switch (action)
                {
                    case "Created":
                        if (File.Exists(currentLog[i].FullPath))
                        {
                            File.Delete(currentLog[i].FullPath);
                        }

                        DeleteEmptyDirs(i, n);
                        break;
                    case "Renamed":
                        if (File.Exists(currentLog[i].FullPath))
                        {
                            File.Move(currentLog[i].FullPath, currentLog[i].OldFullPath);
                        }

                        DeleteEmptyDirs(i, n);
                        break;
                    case "Changed":
                        if (currentLog[i].DT_Modify == currentLog[i].DT_Change)
                        {
                            string copyfrom = string.Empty;
                            string copyto = string.Empty;

                            for (int t = i; t > 0; t--)
                            {
                                if (currentLog[t].TypeOfChange == "Create" && currentLog[t].FullPath == currentLog[i].FullPath)
                                {
                                    copyfrom = currentLog[t].BackUpFolder + "\\" + currentLog[t].FileName.Substring(currentLog[t].FileName.LastIndexOf(@"\"), (currentLog[t].FileName.Length));
                                    copyto = currentLog[t].FullPath;
                                    break;
                                }
                            }

                            if (File.Exists(currentLog[i].FullPath))
                             {
                                 Console.WriteLine("It's needed to copy from ({0}) to ({1})", copyfrom, copyto);
                                 File.Move(copyfrom, copyto);
                             }
                        }

                        DeleteEmptyDirs(i, n);
                        break;
                    case "Deleted":
                        string d_copyfrom = string.Empty;
                        string d_copyto = string.Empty;

                        for (int t = i; t > 0; t--)
                        {

                            if (currentLog[t].TypeOfChange == "Create" && currentLog[t].FullPath == currentLog[i].FullPath)
                            {
                                d_copyfrom = currentLog[t].BackUpFolder + "\\" + currentLog[t].FileName.Substring(currentLog[t].FileName.LastIndexOf(@"\"), (currentLog[t].FileName.Length));
                                d_copyto = currentLog[t].FullPath;
                                break;
                            }
                        }

                        if (File.Exists(currentLog[i].FullPath))
                        {
                            File.Move(d_copyfrom, d_copyto);
                        }

                        DeleteEmptyDirs(i, n);
                        break;
                }
            }
        }

        private static void OpenLog()
        {
            currentLog.RemoveRange(0, currentLog.Count);
            if (File.Exists(projpath + @"\logfile.log"))
            {
                string[] data = File.ReadAllLines(projpath + @"\logfile.log").ToArray();
                
                foreach (string str in data)
                {
                    string[] value = str.Split(',');
                    currentLog.Add(new LogEntry(value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8]));
                }
            }
        }
        

        private static void SaveLog()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < currentLog.ToArray().Length; i++)
            {
                sb = sb.Append(currentLog[i].DT_Modify).Append(",").Append(currentLog[i].TypeOfChange)
                    .Append(",").Append(currentLog[i].FileName).Append(",").Append(currentLog[i].OldFileName)
                    .Append(",").Append(currentLog[i].FullPath).Append(",").Append(currentLog[i].OldFullPath)
                    .Append(",").Append(currentLog[i].BackUpFolder).Append(",").Append(currentLog[i].DT_Create).Append(",").Append(currentLog[i].DT_Change).Append(Environment.NewLine);
            }
            File.AppendAllText(projpath + @"\logfile.log", sb.ToString());
        }

        private static void DeleteEmptyDirs(int i, int n)
        {
            int m = currentLog.IndexOf(currentLog[i]);
            string comparingWith = currentLog[i].FullPath.Substring(0, currentLog[i].FullPath.LastIndexOf(@"\"));
            int count = 0;
            for (int j = m - 1; j > n; j--)
            {
                string comparingStr = currentLog[j].FullPath.Substring(0, currentLog[j].FullPath.LastIndexOf(@"\"));
                if (comparingWith == comparingStr)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                DirectoryInfo myDirectory = new DirectoryInfo(comparingWith);
                int fcount = myDirectory.GetFiles().Count();
                int dcount = myDirectory.GetDirectories().Count();
                if (fcount == 0 && dcount == 0)
                {
                    myDirectory.Delete();
                }
            }
        }



        private static void onChanged(object source, FileSystemEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);
            DirectoryInfo dir = new DirectoryInfo(projpath);

            DateTime ActionTimeDate = DateTime.Now;
            currentLog.Add(new LogEntry(ActionTimeDate.ToString(), e.ChangeType.ToString(), e.Name, null, e.FullPath, null, null, f.CreationTime.ToString(), f.LastWriteTime.ToString()));
        }

        private static void onCreated(object source, FileSystemEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);

            DirectoryInfo backuproot = new DirectoryInfo(projpath + @"\backup");

            DateTime ActionTimeDate = DateTime.Now;
            string a = ActionTimeDate.ToString();
            string dirname = string.Empty;
            if (a.Substring(13,1) == ":")
            {
                dirname = a.Substring(6, 4) + a.Substring(3, 2) + a.Substring(0, 2) + a.Substring(11, 2) + a.Substring(14, 2) + a.Substring(17, 2);
            }
            else
            {
                dirname = a.Substring(6, 4) + a.Substring(3, 2) + a.Substring(0, 2) + a.Substring(11, 1) + a.Substring(13, 2) + a.Substring(16, 2);
            }

            string backupfolder = string.Empty;
            if (e.Name.Contains(@"\"))
            {
                string subdirectories = e.Name.Substring(0, e.Name.LastIndexOf(@"\"));
                backuproot.CreateSubdirectory(dirname + "\\" + subdirectories);
                backupfolder = backuproot + "\\" + dirname + "\\" + subdirectories;
            }
            else
            {
                backuproot.CreateSubdirectory(dirname);
                backupfolder = backuproot + "\\" + dirname;
            }

            currentLog.Add(new LogEntry(ActionTimeDate.ToString(), e.ChangeType.ToString(), e.Name.ToString(), null, e.FullPath.ToString(), null, backupfolder, f.CreationTime.ToString(), null));

            Thread.Sleep(200);
            

            File.Copy(e.FullPath, projpath + "\\backup\\" + dirname + "\\" + e.Name, true);
        }

        private static void onDeleted(object source, FileSystemEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);
            DateTime ActionTimeDate = DateTime.Now;

            currentLog.Add(new LogEntry(ActionTimeDate.ToString(), e.ChangeType.ToString(), e.Name, null, e.FullPath, null, null, null, null));
        }

        private static void onRenamed(object source, RenamedEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);
            DateTime ActionTimeDate = DateTime.Now;
            currentLog.Add(new LogEntry(ActionTimeDate.ToString(), e.ChangeType.ToString(), e.Name, e.OldName, e.FullPath, e.OldFullPath, null, f.CreationTime.ToString(), f.LastWriteTime.ToString()));
        }
    }
}
