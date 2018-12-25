using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task05._1_BackupSystem
{
    public class LogEntry
    {
        public string DT_Modify { get; set; }
        public string TypeOfChange { get; set; }
        public string FileName { get; set; }
        public string OldFileName { get; set; }
        public string FullPath { get; set; }
        public string OldFullPath { get; set; }
        public string BackUpFolder { get; set; }
        public string DT_Create { get; set; }
        public string DT_Change { get; set; }

        public LogEntry() { }

        public LogEntry(string dt_Modify, string typeOfChange, string fileName, string oldFileName, string fullPath,
            string oldFullPath, string backUpFolder, string dt_Create, string dt_Change)
        {
            DT_Modify = dt_Modify;
            TypeOfChange = typeOfChange;
            FileName = fileName;
            OldFileName = oldFileName;
            FullPath = fullPath;
            OldFullPath = oldFullPath;
            BackUpFolder = backUpFolder;
            DT_Create = dt_Create;
            DT_Change = dt_Change;
        }

        private static DateTime MinDate(DateTime[] nums)
        {
            DateTime min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }

            return min;
        }

    }
}
