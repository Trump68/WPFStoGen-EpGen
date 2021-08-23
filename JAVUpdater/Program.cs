using EPCat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAVUpdater
{
    class Program
    {
        public static string JavSerie;
        public static List<string> FOLDERS;
        public static int From = 0;
        public static string DISC = "n";
        public static int FAILURE = 10;

        static void Main(string[] args)
        {
            ReadIni();
            JAV.FoldersToUpdate = FOLDERS;
            DoUpdate();
        }
        private static void ReadIni()
        {
            List<string> lines = File.ReadAllLines("..\\..\\JAVUpdater.ini").ToList();
            foreach (var line in lines)
            {
                if (line.StartsWith("SERIE="))
                {
                    JavSerie = line.Replace("SERIE=", string.Empty);
                }
                else if (line.StartsWith("FOLDERS="))
                {
                    FOLDERS = line.Replace("FOLDERS=", string.Empty).Split(',').ToList();
                }
                else if (line.StartsWith("DISC="))
                {
                    DISC = line.Replace("DISC=", string.Empty);
                }
                else if (line.StartsWith("FROM="))
                {
                    string fromstr = line.Replace("FROM=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        From = int.Parse(fromstr);
                }
                else if (line.StartsWith("FAILURE="))
                {
                    string fromstr = line.Replace("FAILURE=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        FAILURE = int.Parse(fromstr);
                }
            }
        }
        private static void DoUpdate()
        {
            JAV.JavLibraryDo(JavSerie, From, DISC, FAILURE);
        }
    }
}
