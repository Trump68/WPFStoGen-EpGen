using StoGen.Classes.Catalog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public static class JAV
    {
        public static void JavLibraryDo(string serie, int startstr, string disc, int failureTreshold, int daysTreshold)
        {
            if (string.IsNullOrEmpty(serie))
                serie = "GVG";
            DateTime today = DateTime.Now.Date;
            List<string> series = serie.Split(',').ToList();
            if (serie == "ALL")
            {
                series = Directory.GetDirectories($@"{disc}:\!CATALOG\JAV\").Select(x=>Path.GetFileName(x)).ToList();
                
            }
            List<string> Total = new List<string>();
            int total = 0;
            foreach (var item in series)
            {
                
                string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{item}\", "updated.txt");                
                if (File.Exists(check))
                {
                    var lines = File.ReadAllLines(check);
                    if (lines.Any())
                    {
                       if (lines[0] == "completed")
                       {                            
                            Console.WriteLine($"{item} - completed");
                            continue;
                       }                       
                       DateTime last;
                       if (DateTime.TryParse(lines[0], out last))
                       {
                            if (last.Date.AddDays(daysTreshold) >= today)
                            {                                
                                Console.WriteLine($"{item} - too early");
                                continue;
                            }
                       }                           
                    }
                }

                Console.WriteLine($"{item} - start");
                if (startstr == 0)
                    startstr = 1;

                int start = startstr;
                int proc = 0;
                int failure = 0;

                string keyword = $"{item}-{start.ToString($"D3")}";
                JavLibraryDoOne(item, keyword, disc) ;
                
                while (failure < failureTreshold)
                {
                    start++;
                    keyword = $"{item}-{start.ToString($"D3")}";
                    int go = JavLibraryDoOne(item, keyword, disc);
                    if (go == 100)
                    {                        
                        proc++;
                        total++;
                        failure = 0;
                        Console.Write($" - done {total}\n");
                    }
                    if (go == 50)
                    {
                        failure = 0;
                    }
                    else
                    {
                        if (failure>0)
                            Console.Write($" - skipped {failure}\n");
                        failure++;
                    }                 
                }
                string str = $"{item} - complete {proc}\n";
                Console.WriteLine(str);
                Total.Add(str);
                File.WriteAllText(check,$"{today}");
            }

            Console.WriteLine("Added total:");
            foreach (string item in Total)
            {
                Console.WriteLine(item);
            }            

        }
        private static int JavLibraryDoOne(string serie, string keyword, string disc)
        {

            string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{serie}\{keyword}", EpItem.p_PassportName);
            if (File.Exists(check))
            {
                return 50;
            }

            Console.Write($"    Get {keyword}");
            WebRequest request = WebRequest.Create($"http://www.javlibrary.com/en/vl_searchbyid.php?keyword={keyword}");
            request.Method = "GET";
            string content = null;
            WebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            try
            {
                response = request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception)
            {
                return 0;
            }

            int pos = -1;
            if (content.Contains(@"<div class=""videos"">"))
            {
                pos = content.IndexOf(@"<div class=""videos"">");
                content = content.Substring(pos);
                pos = content.IndexOf(@"<a href=");
                content = content.Substring(pos + 10, 14);
                request = WebRequest.Create($"http://www.javlibrary.com/en{content}");
                request.Method = "GET";
                try
                {
                    response = request.GetResponse();
                    stream = response.GetResponseStream();
                    reader = new StreamReader(stream);
                    content = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                }
                catch (Exception)
                {
                    return 0;
                }

            }

            if (content.Contains("Search returned no result"))
                return 1;

            // 1. title
            pos = content.IndexOf(@"post-title text");
            string title = content.Substring(pos + 30);
            pos = title.IndexOf(@">");
            title = title.Substring(pos + 1);
            pos = title.IndexOf(@"<");
            title = title.Substring(0, pos);
            // 2. year
            pos = content.IndexOf(@"video_date");
            string year = content.Substring(pos);
            pos = year.IndexOf(@"text");
            year = year.Substring(pos + 6, 4);
            // 3. star
            pos = content.IndexOf(@"video_cast");
            string starall = content.Substring(pos);
            List<string> stars = new List<string>();
            pos = starall.IndexOf(@"rel=""tag"">");
            while (pos > 0)
            {
                starall = starall.Substring(pos + 10);
                pos = starall.IndexOf(@"<");
                stars.Add(starall.Substring(0, pos));
                pos = starall.IndexOf(@"rel=""tag"">");
            }
            //4. Genre
            pos = content.IndexOf(@"video_genres");
            string genreall = content.Substring(pos);
            List<string> genres = new List<string>();
            pos = genreall.IndexOf(@"rel=""category tag"">");
            while (pos > 0)
            {
                genreall = genreall.Substring(pos + 19);
                pos = genreall.IndexOf(@"<");
                genres.Add(genreall.Substring(0, pos));
                pos = genreall.IndexOf(@"rel=""category tag"">");
            }
            //5. Director
            pos = content.IndexOf(@"video_director");
            string directorall = content.Substring(pos);
            pos = directorall.IndexOf(@"</div> <!-- end of video_director -->");
            directorall = directorall.Substring(0, pos);
            List<string> directors = new List<string>();
            pos = directorall.IndexOf(@"rel=""tag"">");
            while (pos > 0)
            {
                directorall = directorall.Substring(pos + 10);
                pos = directorall.IndexOf(@"<");
                directors.Add(directorall.Substring(0, pos));
                pos = directorall.IndexOf(@"rel=""tag"">");
            }
            //6. Picture
            pos = content.IndexOf(@"video_jacket_img");
            string pic = content.Substring(pos + 25);
            pos = pic.IndexOf(@".jpg");
            pic = $"http://{pic.Substring(0, pos + 4)}";



            string path = $@"{disc}:\!CATALOG\JAV\{serie}";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path = $@"{path}\{keyword}";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string passortpath = Path.Combine(path, EpItem.p_PassportName);
            string posterpath = Path.Combine(path, "POSTER.jpg");
            if (!File.Exists(passortpath))
            {
                EpItem item = new EpItem(0);
                item.Name = keyword;
                item.AltTitle = title;
                item.Catalog = "JAV";
                item.Year = Convert.ToInt32(year);
                item.Star = string.Join(",", stars.ToArray());
                item.Serie = serie;
                item.Type = string.Join(",", genres.ToArray());
                item.Stage = "Stub";
                item.Director = string.Join(",", directors.ToArray());
                List<string> lines = EpItem.SetToPassport(item);
                File.WriteAllLines(passortpath, lines);
            }
            else
            {
                List<string> passport = new List<string>(File.ReadAllLines(passortpath));
                if (passport != null)
                {
                    EpItem item = EpItem.GetFromPassport(passport, passortpath);
                    bool edited = false;
                    if (item.Year < 1)
                    {
                        item.Year = Convert.ToInt32(year);
                        edited = true;
                    }
                    if (string.IsNullOrEmpty(item.Star) && stars.Any())
                    {
                        item.Star = string.Join(",", stars.ToArray());
                        edited = true;
                    }
                    if (string.IsNullOrEmpty(item.Director) && directors.Any())
                    {
                        item.Director = string.Join(",", directors.ToArray());
                        edited = true;
                    }
                    if (string.IsNullOrEmpty(item.Serie))
                    {
                        item.Serie = serie;
                        edited = true;
                    }
                    if (string.IsNullOrEmpty(item.AltTitle))
                    {
                        item.AltTitle = title;
                        edited = true;
                    }
                    if (string.IsNullOrEmpty(item.Type) && genres.Any())
                    {
                        item.Type = string.Join(",", genres.ToArray());
                        edited = true;
                    }
                    if (item.Catalog != "JAV")
                    {
                        item.Catalog = "JAV";
                        edited = true;
                    }
                    if (edited)
                    {
                        ++item.LastEdit;
                        List<string> lines = EpItem.SetToPassport(item);
                        File.WriteAllLines(passortpath, lines);
                    }
                }

            }
            if (!File.Exists(posterpath))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {

                        client.DownloadFile(pic, posterpath);
                    }
                    catch (Exception)
                    {
                                              
                    }

                }
            }

            return 100;
        }


        private static List<string> _JAVExclusions = null;
        public static List<string> JAVExclusions
        {
            get
            {
                if (_JAVExclusions == null)
                {
                    _JAVExclusions = new List<string>();
                }
                return _JAVExclusions;
            }
        }
        private static Dictionary<string, bool> _JAVCollections = null;
        public static Dictionary<string, bool> JAVCollections
        {
            get
            {
                if (_JAVCollections == null)
                {
                    _JAVCollections = getJAVCollections();
                }
                return _JAVCollections;
            }
        }
        public static List<string> FoldersToUpdate = new List<string>();
        private static Dictionary<string, bool> getJAVCollections()
        {
            var list = new Dictionary<string, bool>();
            
            string file = Path.Combine(FoldersToUpdate.Last(), "update.txt");
            if (File.Exists(file))
            {
                var strings = File.ReadAllLines(file);
                List<string> listtocheck = new List<string>();
                foreach (string str in strings)
                {
                    if (str.Trim() == "ALL")
                        list.Add("ALL", true);
                    else if (str.Contains("!NO_TYPE_"))
                        JAVExclusions.Add(str.Trim().Replace("!NO_TYPE_",string.Empty));
                    else
                        listtocheck.Add(str);
                }

                foreach (var path in FoldersToUpdate)
                {
                    ProcessPath(ref list, ref listtocheck, path);

                }
            }
            return list;

        }

        private static void ProcessPath(ref Dictionary<string, bool> list, ref List<string> strings, string path)
        {
            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path);
                foreach (var item in dirs)
                {
                    string dir = Path.GetFileName(item);
                    if (strings.Contains(dir))
                    {
                        list.Add(dir, true);
                        strings.Remove(dir);
                    }
                    //else
                    //{
                    //    list.Add(dir, false);
                    //}
                }
                //foreach (var item in dirs)
                //{
                //    DirectoryInfo dir = new DirectoryInfo(item);
                //    string dirname = dir.Name.ToUpper();
                //    if (dirname.Length <= 5)
                //    {

                //        if (strings.Any(x => dirname.StartsWith(x)))
                //            list.Add(dirname, true);
                //        else if (!list.ContainsKey(dirname))
                //            list.Add(dirname, false);
                //    }
                //}
            }
        }

        public static void JavUpdate()
        {
            foreach (var item in JAVCollections)
            {
                if (item.Value)
                    JavUpdateSerie(item.Key, 1, "f,e");
            }
        }

        private static void JavUpdateSerie(string serie, int start, string disclist)
        {
            if (start == 0)
                start++;
            var discs = disclist.Split(',');
            string disc = string.Empty;
            foreach (var item in discs)
            {
                disc = item;
                string alreadyexist = $@"{item}:\!CATALOG\JAV\{serie}";
                if (Directory.Exists(alreadyexist)) break;
            }

            string path = $@"{disc}:\!CATALOG\JAV\{serie}";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            else
            {
                while (true)
                {
                    string existing = $"{serie}-{start.ToString($"D3")}";
                    if (!Directory.Exists(Path.Combine(path, existing)))
                    {
                        break;
                    }
                    start++;
                }
            }

            int proc = 0;
            int failure = 0;
            string keyword = $"{serie}-{start.ToString($"D3")}";
            int go = JavLibraryDoOne(serie, keyword, disc);
            while (failure < 2)
            {
                start++;

                while (true)
                {
                    string existing = $"{serie}-{start.ToString($"D3")}";
                    if (!Directory.Exists(Path.Combine(path, existing)))
                    {
                        break;
                    }
                    start++;
                }

                keyword = $"{serie}-{start.ToString($"D3")}";
                go = JavLibraryDoOne(serie, keyword, disc);
                if (go == 100)
                {
                    proc++;
                    failure = 0;
                }
                else
                    failure++;
            }
        }

        public static void JavLibraryMakeBat(string marker)
        {
            string path = @"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\!JAV_ARTIST\";
            string file = $@"{marker}.bat";
            List<string> lines = new List<string>();
            lines.Add($@"START """" ""d:\Work\WPFStoGen-EpGen\EPCat\bin\Release\EPCat.exe"" "".\RES\{marker}.txt"" "".\RES\{marker}.xml"" LOAD");
            lines.Add("EXIT");
            string f = Path.Combine(path, file);
            File.WriteAllLines(f, lines);

            string pathRes = Path.Combine(path, @"RES");


            file = $@"{marker}.txt";
            lines.Clear();
            lines.Add($@"LOAD CATALOG d:\Work\WPFStoGen-EpGen\CATALOG\jav.cat");
            foreach (var lpath in FoldersToUpdate)
            {
                lines.Add($@"UPDATE FOLDER {lpath}");
            }
            File.WriteAllLines(Path.Combine(pathRes, file), lines);

            string fileorig= $@"Hayashi Yuna.xml";
            string content = File.ReadAllText(Path.Combine(pathRes, fileorig));
            file = $@"{marker}.xml";
            content = content.Replace("Hayashi Yuna", marker);
            File.WriteAllText(Path.Combine(pathRes, file),content);

        }

        public static Dictionary<string, string> _JAVupdated;
        private static int threshold_days = 0;
        private static int threshold_hours = 0;
        private static void LoadThreshold()
        {

            string file = Path.Combine(FoldersToUpdate.Last(), "updated.txt");
            var strings = File.ReadAllLines(file);

            _JAVupdated = new Dictionary<string, string>();
            foreach (var item in strings)
            {
                if (item.Contains("threshold_days="))
                {
                    string td = item.Replace("threshold_days=", string.Empty);
                    if (!string.IsNullOrEmpty(td))
                    {
                        threshold_days = Convert.ToInt32(td);
                    }
                }
                else if (item.Contains("threshold_hours="))
                {
                    string td = item.Replace("threshold_hours=", string.Empty);
                    if (!string.IsNullOrEmpty(td))
                    {
                        threshold_hours = Convert.ToInt32(td);
                    }
                }
                else
                {
                    var vals = item.Split('=');
                    string serie = vals[0];
                    string updated = vals[1];
                    if (!_JAVupdated.ContainsKey(serie))
                    {
                        _JAVupdated.Add(serie, updated);
                    }
                    else
                    {
                        _JAVupdated[serie] = updated;
                    }
                }
            }
        }
        private static bool CheckThreshold(string serie)
        {
            bool result = false;
            if (!_JAVupdated.ContainsKey(serie))
            {
                _JAVupdated.Add(serie, DateTime.Now.ToString());
                return true;
            }
            else
            {
                DateTime dt = DateTime.Parse(_JAVupdated[serie]);
                DateTime treshold = dt.AddDays(threshold_days).AddHours(threshold_hours);
                if (DateTime.Now> treshold)
                {
                    _JAVupdated[serie] = DateTime.Now.ToString();
                    return true;
                }                
            }
            return result;
        }
        private static void SaveThreshold()
        {
            List<string> lines = new List<string>();
            lines.Add($"threshold_days={threshold_days}");
            lines.Add($"threshold_hours={threshold_hours}");
            foreach (var item in _JAVupdated)
            {
                lines.Add($"{item.Key}={item.Value}");
            }

            string file = Path.Combine(FoldersToUpdate.Last(), "updated.txt");
            File.WriteAllLines(file, lines);
        }
        private static void SaveUpdate()
        {
            List<string> lines = new List<string>();
            foreach (var item in _JAVupdated)
            {
                lines.Add($"{item.Key}");
            }
            string file = Path.Combine(FoldersToUpdate.Last(), "update.txt");            
            File.WriteAllLines(file, lines);
        }
        internal static void UpdateBySerieList(List<string> list)
        {
            LoadThreshold();
            _JAVCollections = new Dictionary<string, bool>();
            foreach (var serie in list)
            {
                _JAVCollections.Add(serie, true);
                if (!CheckThreshold(serie))
                    continue;
                string disc = string.Empty;
                foreach (var lpath in FoldersToUpdate)
                {
                    disc = lpath[0].ToString();
                    string path = Path.Combine(lpath, serie);
                    if (Directory.Exists(path))
                        break;
                }
                JavUpdateSerie(serie, 0, disc);
            }
            SaveThreshold();
            SaveUpdate();
            System.Windows.Application.Current.Shutdown();
        }

        public static string CalculateRating(List<EpItem> _FolderList)
        {

            Dictionary<string, int> ratingCont = new Dictionary<string, int>();
            foreach (var item in _FolderList)
            {
                if (!string.IsNullOrEmpty(item.Star))
                {
                    var vals = item.Star.Split(',');
                    foreach (var val in vals)
                    {
                        if (!ratingCont.ContainsKey(val))
                        {
                            ratingCont.Add(val, 0);
                        }
                        ratingCont[val] = ratingCont[val] + 1;
                    }
                }
            }
            string dd = string.Empty;
            var f = ratingCont.OrderByDescending(x => x.Value);
            var i = 1;
            List<string> csv = new List<string>();

            foreach (var item in f)
            {
                string r = StarRating.GetRating(item.Key);
                if (string.IsNullOrEmpty(r))
                    r = "??????";
                dd = $"{dd}{Environment.NewLine}{item.Value}:{item.Key} - {i}, rating {r}";
                csv.Add($"{item.Key},{item.Value}");
                i++;

            }
            string datev = $"{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}.csv";

            File.WriteAllLines($@"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\{datev}", csv);


            Dictionary<string, string> total = new Dictionary<string, string>();
            var old = File.ReadAllLines(@"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\8-29-16-47.csv").ToList();
            int n = 0;
            processCsvFile(ref total, n, old);
            n++;
            old = File.ReadAllLines($@"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\{datev}").ToList();
            processCsvFile(ref total, n, old);

            List<string> totals = new List<string>();
            foreach (var item in total)
            {
                totals.Add($"{item.Key},{item.Value}");
            }
            File.WriteAllLines($@"d:\Work\WPFStoGen-EpGen\CATALOG\BAT\total.csv", totals);

            return dd;
        }
        private static void processCsvFile(ref Dictionary<string, string> total, int n, List<string> old)
        {
            foreach (var item in old)
            {
                var vals = item.Split(',');


                if (!total.ContainsKey(vals[0]))
                {
                    List<string> sl = new List<string>();
                    for (int i = 0; i < n; i++)
                    {
                        sl.Add("0");
                    }
                    total.Add(vals[0], string.Join(",", sl.ToArray()));
                }
                if (string.IsNullOrEmpty(total[vals[0]]))
                    total[vals[0]] = $"{vals[1]}";
                else
                    total[vals[0]] = $"{total[vals[0]]},{vals[1]}";
            }
        }

        public static void ReloadCollection()
        {
            _JAVCollections = getJAVCollections();
            //StarRating.SaveJAVActress();
        }
      
        public static void SaveCatalog(ref List<EpItem> list, bool IsSynchPosterAllowed,string CurrentCatalog, List<string> folders)
        {
            Console.WriteLine($"Reload JAV collection..");
            JAV.ReloadCollection();
            CatalogLoader.AddedTotal = 0;
            foreach (var item in folders)
            {
                CatalogLoader.UpdateFolder(item, ref list, false, IsSynchPosterAllowed, CurrentCatalog,false);
            }
            Console.WriteLine($"Added Total: {CatalogLoader.AddedTotal}");

            Console.WriteLine($"Backup catalog..");
            if (string.IsNullOrEmpty(CurrentCatalog)) return;
            if (File.Exists(CurrentCatalog))
                File.Copy(CurrentCatalog, Path.ChangeExtension(CurrentCatalog, "bak"), true);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<EpItem>));
            Console.WriteLine($"Save catalog..");
            using (var writer = new StreamWriter(CurrentCatalog))
            {

                serializer.Serialize(writer, list);
            }
        }

        //private static void UpdateFolder(string parameters, ref List<EpItem> list, bool isCheck, bool synchCaption, string CurrentCatalog, List<string> folders)
        //{
        //    string itemPath = parameters.ToUpper();
        //    if (isCheck)
        //    {
        //        string dirname = Path.GetFileName(itemPath);

        //        if (folders.Exists(x => itemPath.Contains(x)))
        //        {
        //            if (!folders.Exists(x => itemPath == x))
        //            {
        //                if (!JAV.FoldersToUpdate.Contains("ALL") && JAV.FoldersToUpdate.Any())
        //                {
        //                    if (!JAV.FoldersToUpdate.Contains(dirname.ToUpper())) return;
        //                    isCheck = false;
        //                }
        //            }
        //        }
        //    }


        //    Console.WriteLine($"Update folder {itemPath}..");
        //    if (!Directory.Exists(itemPath)) return;
        //    List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportName).ToList();
        //    foreach (var passport in passportList)
        //    {
        //        CatalogLoader.CreateUpdateFromPassport(passport, ref list, synchCaption, CurrentCatalog);
        //    }
        //    List<string> dirList = Directory.GetDirectories(itemPath).ToList();
        //    foreach (var dir in dirList)
        //    {
        //        CatalogLoader.UpdateFolder(dir, ref list, isCheck, synchCaption, CurrentCatalog);
        //    }
        //}
    }
}
