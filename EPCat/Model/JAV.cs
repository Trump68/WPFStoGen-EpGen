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
        public static void JavLibraryDo(string RepeatedText, int RepeatedTextStart, string StatusText)
        {
            if (string.IsNullOrEmpty(RepeatedText))
                RepeatedText = "GVG";

            string[] series = RepeatedText.Split(',');
            foreach (var item in series)
            {
                if (RepeatedTextStart == 0)
                    RepeatedTextStart = 1;

                int start = RepeatedTextStart;
                int proc = 0;
                int failure = 0;
                StatusText = $"{proc},{failure}";

                string keyword = $"{item}-{start.ToString($"D3")}";
                bool go = JavLibraryDoOne(item, keyword);

                while (failure < 100)
                {
                    start++;
                    keyword = $"{item}-{start.ToString($"D3")}";
                    go = JavLibraryDoOne(item, keyword);
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
        private static bool JavLibraryDoOne(string serie, string keyword)
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



            string path = $@"e:\!CATALOG\JAV\{serie}";
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
        public static void JavUpdate()
        {
            //MOODYZ
            JavUpdateSerie("MIAA", 319);
            JavUpdateSerie("MIZD", 1);
            JavUpdateSerie("MIMK", 1);
            JavUpdateSerie("MIFD", 1);
            JavUpdateSerie("MIDE", 826);
            JavUpdateSerie("MIAE", 359);
            JavUpdateSerie("MIGD", 787);
            JavUpdateSerie("MDYD", 1);
            JavUpdateSerie("MDLD", 1);
            JavUpdateSerie("MDED", 1);
            JavUpdateSerie("MIID", 203);
            JavUpdateSerie("RMID", 203);
            //JavUpdateSerie("MIBD", 999); - completed
            //JavUpdateSerie("MIDD", 999); - completed
            //JavUpdateSerie("MIAD", 999); - completed


            //LUNATICS
            JavUpdateSerie("LULU", 1);

            //Attakers
            //JavUpdateSerie("ATVR", 1); - VR
            //JavUpdateSerie("ADS", 1);
            JavUpdateSerie("SHKD", 909);
            JavUpdateSerie("RBD", 989);
            JavUpdateSerie("SSPD", 163);
            JavUpdateSerie("JBD", 259);
            JavUpdateSerie("ATID", 440);
            JavUpdateSerie("ATAD", 150);
            JavUpdateSerie("ATKD", 309);

            //WANZ FACTORY
            JavUpdateSerie("WANZ", 984);
            JavUpdateSerie("BMW", 215);
            // retired:
            //JavUpdateSerie("HP", 101);
            //JavUpdateSerie("KW", 104);
            //JavUpdateSerie("SA", 102);
            //JavUpdateSerie("WS", 103);
            //JavUpdateSerie("VA", 102);
            //JavUpdateSerie("MC", 111);
            //JavUpdateSerie("WX", 106);
            //JavUpdateSerie("MD", 105);
            //JavUpdateSerie("SK", 110);
            //JavUpdateSerie("MO", 116);
            //JavUpdateSerie("FG", 110);
            //JavUpdateSerie("ZB", 110);
            //JavUpdateSerie("IA", 101);
            //JavUpdateSerie("TW", 112);
            //JavUpdateSerie("SO", 117);
            //JavUpdateSerie("SP", 109);
            //JavUpdateSerie("CO", 108);
            //JavUpdateSerie("AY", 105);
            //JavUpdateSerie("WF", 101);
            //JavUpdateSerie("IE", 100);
            //JavUpdateSerie("NWF", 1);
            //JavUpdateSerie("WSD", 1);
            //JavUpdateSerie("NAW", 1);
            //JavUpdateSerie("WWW", 100);
            //JavUpdateSerie("WNZ", 100);
            //JavUpdateSerie("WNZS", 100);
            //JavUpdateSerie("PPS", 200);



        }
        private static void JavUpdateSerie(string serie, int start)
        {
            string path = $@"e:\!CATALOG\JAV\{serie}";
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
            bool go = JavLibraryDoOne(serie, keyword);
            while (failure < 50)
            {
                start++;
                keyword = $"{serie}-{start.ToString($"D3")}";
                go = JavLibraryDoOne(serie, keyword);
                if (go)
                {
                    proc++;
                    failure = 0;
                }
                else
                    failure++;
            }
        }

    }
}
