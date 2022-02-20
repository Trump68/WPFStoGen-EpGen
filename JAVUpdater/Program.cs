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
        public static string ACTRESS_FOLDER = @"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\!JAV_ARTIST\";
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
                    // Refresh Actress Movies 
                    CountActressMovies(list);
                    Console.WriteLine($"- done. Press key to exit");
                }
        }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
    Console.ReadKey();
        }

        private static void CountActressMovies(List<EpItem> list)
        {
            Dictionary<String,Tuple<int, int, double>> actresses = new Dictionary<String, Tuple<int, int, double>>();
            if (Directory.Exists(ACTRESS_FOLDER)) 
            {
                var files = Directory.GetFiles(ACTRESS_FOLDER,"*.bat");
                foreach (var fn in files)
                {
                    string actress_name = Path.GetFileNameWithoutExtension(fn);
                    actresses.Add(actress_name, new Tuple<int, int, double>(0, 0, 0.0));
                }

                foreach (var item in list)
                {
                    var stars = item.Star.Split(',');
                    foreach (var star in stars)
                    {
                        if (actresses.ContainsKey(star)) 
                        {
                            var value = actresses[star];
                            int total = value.Item1 + 1;
                            int exists = value.Item2;
                            double percent = value.Item3;
                            if (item.M4V > 0) 
                            {
                                exists = exists + 1;
                            }
                            if (exists > 0) 
                            {
                                percent =  (exists * 100) / total;
                            }
                            actresses[star] = new Tuple<int, int, double>(total, exists, percent);
                        }
                    }
                }

                string filetowrite = Path.Combine(ACTRESS_FOLDER,"actresses.csv");
                List<string> stlist = new List<string>();
                foreach (var item in actresses)
                {
                    stlist.Add($"{item.Key};{item.Value.Item1};{item.Value.Item2};{item.Value.Item3}");
                }
                File.WriteAllLines(filetowrite,stlist);
            }

            if (CatalogLoader.Actress_found.Any()) 
            {
                string filetowrite = Path.Combine(ACTRESS_FOLDER, $"Actress_found_{DateTime.Today.ToShortDateString()}.txt");
                File.WriteAllLines(filetowrite, CatalogLoader.Actress_found);
                foreach (var item in CatalogLoader.Actress_found)
                {
                    JAV.JavLibraryMakeBat(item);
                }
                
            }

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
                else if (line.StartsWith("ACTRESS_FOLDER="))
                {
                    ACTRESS_FOLDER = line.Replace("ACTRESS_FOLDER=", string.Empty);
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
