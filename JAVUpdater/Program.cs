using EPCat.Model;
using StoGen.Classes.Catalog;
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
        public static string DISC = "n";
        public static int From = 0;
        public static string BACKUPFOLDER = @"f:\!CATALOG\JAV";
        public static int FAILURE = 10;
        public static int DAYTHRESHOLD = 3;
        public static int SYNCHPOSTER = 0;
        public static int INTERNETUPDATE = 0;
        public static int INTERNETUPDATEAFTER = 0;
        public static int CATALOGUPDATE = 0;
        public static int DOBACKUP = 0;
        static void Main(string[] args)
        {
            try
            {
                ReadIni();
                string Catalog = $@"d:\Work\WPFStoGen-EpGen\CATALOG\jav.cat";
                JAV.FoldersToUpdate = JavSerie.Split(',').ToList();
                JAV.ApdateAfter = INTERNETUPDATEAFTER;
                if (INTERNETUPDATE > 0)
                    DoUpdate();
                if (CATALOGUPDATE > 0)
                {
                    Console.WriteLine($"Loading Catalog {Catalog}..");
                    List<EpItem> list = CatalogLoader.LoadCatalog(Catalog);
                    if (list == null)
                        list = new List<EpItem>();
                    Console.WriteLine($"- done.");
                    StarRating.LoadJAVActress(FOLDERS.First());
                    if (DOBACKUP == 0  || !Directory.Exists(BACKUPFOLDER))
                    {
                        BACKUPFOLDER = null;
                    }
                    JAV.SaveCatalog(ref list, (SYNCHPOSTER != 0), Catalog, FOLDERS, BACKUPFOLDER);                    
                    Console.WriteLine($"- done. Press key to exit");
                }
        }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
    Console.ReadKey();
        }
        private static void ReadIni()
        {
            List<string> lines = File.ReadAllLines("..\\..\\JAVUpdater.ini").ToList();
            bool isSectionBACKUPACTRESS = false;
            CatalogLoader.BACKUP_ACTRESS_LIST = new List<string>();
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
                else if (line.StartsWith("BACKUPFOLDER="))
                {
                    BACKUPFOLDER = line.Replace("BACKUPFOLDER=", string.Empty);
                }
                else if (line.StartsWith("DISC="))
                {
                    DISC = line.Replace("DISC=", string.Empty);
                }
                else if (line.StartsWith("DAYTHRESHOLD="))
                {
                    string DAYTHRESHOLDstr = line.Replace("DAYTHRESHOLD=", string.Empty);
                    if (!string.IsNullOrEmpty(DAYTHRESHOLDstr))
                        DAYTHRESHOLD = int.Parse(DAYTHRESHOLDstr);
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
                else if (line.StartsWith("SYNCHPOSTER="))
                {
                    string fromstr = line.Replace("SYNCHPOSTER=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        SYNCHPOSTER = int.Parse(fromstr);
                }
                else if (line.StartsWith("DOBACKUP="))
                {
                    string fromstr = line.Replace("DOBACKUP=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        DOBACKUP = int.Parse(fromstr);
                }
                else if (line.StartsWith("INTERNETUPDATE="))
                {
                    string fromstr = line.Replace("INTERNETUPDATE=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        INTERNETUPDATE = int.Parse(fromstr);
                }
                else if (line.StartsWith("INTERNETUPDATEAFTER="))
                {
                    string fromstr = line.Replace("INTERNETUPDATEAFTER=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        INTERNETUPDATEAFTER = int.Parse(fromstr);
                }
                else if (line.StartsWith("CATALOGUPDATE="))
                {
                    string fromstr = line.Replace("CATALOGUPDATE=", string.Empty);
                    if (!string.IsNullOrEmpty(fromstr))
                        CATALOGUPDATE = int.Parse(fromstr);
                }
                else if (line.StartsWith("<=BACKUPACTRESS=>"))
                {
                    isSectionBACKUPACTRESS = true;
                }
                else if (isSectionBACKUPACTRESS)
                {
                    isSectionBACKUPACTRESS = true;
                    CatalogLoader.BACKUP_ACTRESS_LIST.Add(line.Trim());
                }
            }
        }
        private static void DoUpdate()
        {
            var disks = DISC.Split(',');
            foreach (var item in disks)
            {
                JAV.JavLibraryDo(JavSerie, From, item, FAILURE, DAYTHRESHOLD);
            }
            
        }
    }
}
