using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class DateToStringConverter
    {
        public static string DateToString(DateTime date)
        {
            string newFile = @"DataFiles\Orders_" + date.ToString("MMddyyyy") + ".txt";
            return newFile;
        }

        public static string FileToString(String fileName)
        {
            string date = Path.GetFileName(fileName);

            date = date.Replace("Orders_", "");

            date = date.Replace(".txt", "");

            date = date.Insert(2, "/");

            date = date.Insert(5, "/");

            return date;
        }
    }
}
