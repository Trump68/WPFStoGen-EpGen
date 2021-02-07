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
        public static void JavLibraryDo(string serie, int startstr, string StatusText, string disc)
        {
            if (string.IsNullOrEmpty(serie))
                serie = "GVG";

            string[] series = serie.Split(',');
            foreach (var item in series)
            {
                if (startstr == 0)
                    startstr = 1;

                int start = startstr;
                int proc = 0;
                int failure = 0;
                StatusText = $"{proc},{failure}";

                string keyword = $"{item}-{start.ToString($"D3")}";
                bool go = JavLibraryDoOne(item, keyword, disc);

                while (failure < 100)
                {
                    start++;
                    keyword = $"{item}-{start.ToString($"D3")}";
                    go = JavLibraryDoOne(item, keyword, disc);
                    if (go)
                    {
                        proc++;
                        failure = 0;
                    }
                    else
                        failure++;
                    //StatusText = $"{proc},{failure}-run";
                }
                //StatusText = $"{proc},{failure}-stopped";
            }



        }
        private static bool JavLibraryDoOne(string serie, string keyword, string disc)
        {
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
                return false;
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
                    return false;
                }

            }

            if (content.Contains("Search returned no result"))
                return false;

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


            return true;
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
        private static Dictionary<string, bool> getJAVCollections()
        {
            var list = new Dictionary<string, bool>();

            string file = $@"f:\!CATALOG\JAV\update.txt";
            var strings = File.ReadAllLines(file);
            if (strings.Contains("ALL"))
            {
                list.Add("ALL", true);
            }
            else
            {
                string path = @"f:\!CATALOG\JAV\";
                ProcessPath(ref list, strings, path);
                path = @"e:\!CATALOG\JAV\";
                ProcessPath(ref list, strings, path);
            }
            return list;

        }

        private static void ProcessPath(ref Dictionary<string, bool> list, string[] strings, string path)
        {
            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path);
                foreach (var item in dirs)
                {
                    DirectoryInfo dir = new DirectoryInfo(item);
                    string dirname = dir.Name.ToUpper();
                    if (dirname.Length <= 5)
                    {

                        if (strings.Any(x => dirname.StartsWith(x)))
                            list.Add(dirname, true);
                        else
                            list.Add(dirname, false);
                    }
                }
            }
        }

        public static void JavUpdate()
        {
            foreach (var item in JAVCollections)
            {
                if (item.Value)
                    JavUpdateSerie(item.Key, 1, "f");
            }
        }

        private static void JavUpdateSerie(string serie, int start, string disc)
        {
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
            bool go = JavLibraryDoOne(serie, keyword, disc);
            while (failure < 2)
            {
                start++;
                keyword = $"{serie}-{start.ToString($"D3")}";
                go = JavLibraryDoOne(serie, keyword, disc);
                if (go)
                {
                    proc++;
                    failure = 0;
                }
                else
                    failure++;
            }
        }

        internal static void JavLibraryMakeBat(string marker)
        {
            string path = @"D:\Work\WPFStoGen-EpGen\CATALOG\BAT";
            string file = $@"JAV - {marker}.bat";
            List<string> lines = new List<string>();
            lines.Add($@"START """" ""d:\Work\WPFStoGen-EpGen\EPCat\bin\Release\EPCat.exe"" ""d:\Work\WPFStoGen-EpGen\CATALOG\BAT\JAV - {marker}.txt"" ""d:\Work\WPFStoGen-EpGen\CATALOG\BAT\JAV - {marker}.xml"" LOAD");
            lines.Add("EXIT");
            string f = Path.Combine(path, file);
            File.WriteAllLines(f, lines);

            file = $@"JAV - {marker}.txt";
            lines.Clear();
            lines.Add($@"LOAD CATALOG d:\Work\WPFStoGen-EpGen\CATALOG\jav.cat");
            lines.Add(@"UPDATE FOLDER e:\!CATALOG\JAV\");
            lines.Add(@"UPDATE FOLDER f:\!CATALOG\JAV\");
            File.WriteAllLines(Path.Combine(path, file), lines);

            string fileorig= $@"JAV - Kasumi Risa.xml";
            string content = File.ReadAllText(Path.Combine(path,fileorig));
            file = $@"JAV - {marker}.xml";
            content = content.Replace("Kasumi Risa", marker);
            File.WriteAllText(Path.Combine(path, file),content);

            //fileorig = @"c:\Users\Boss\Desktop\CTLG\CTLG-JAV-Kasumi Risa.lnk";
            //string filedest = $@"c:\Users\Boss\Desktop\CTLG\CTLG-JAV-{marker}.lnk";
            //content = File.ReadAllText(fileorig);
            //content = content.Replace("Kasumi Risa", marker);
            //File.WriteAllText(filedest, content);
        }

        internal static void UpdateBySerieList(List<string> list)
        {
            _JAVCollections = new Dictionary<string, bool>();
            foreach (var serie in list)
            {
                string disc = "f";
                string path = $@"{disc}:\!CATALOG\JAV\{serie}";
                if (!Directory.Exists(path))
                {
                    disc = "e";
                }
                JavUpdateSerie(serie, 0, disc);
                _JAVCollections.Add(serie, true);
            }

            System.Windows.Application.Current.Shutdown();
        }
    }
}
