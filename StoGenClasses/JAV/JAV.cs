using CloudFlareUtilities;
using StoGen.Classes;
using StoGen.Classes.Catalog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPCat.Model
{


    public static class JAV
    {
        public static int SLEEP = 0;
        public static void JavLibraryDo(string serie, int startstr, string disc, int failureTreshold, int daysTreshold)
        {
            //WebBrowserForm wbf = new WebBrowserForm();
            //wbf.ShowDialog();

            int max = 10000;
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
                string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{item}\", "completed");
                if (File.Exists(check))
                {
                    Console.WriteLine($"{item} - completed");
                    continue;
                }
                check = Path.Combine($@"{disc}:\!CATALOG\JAV\{item}\", "completed.txt");
                if (File.Exists(check))
                {
                    Console.WriteLine($"{item} - completed");
                    continue;
                }
                check = Path.Combine($@"{disc}:\!CATALOG\JAV\{item}\", "updated.txt");                
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
                    foreach (var ln in lines)
                    {
                        //if (ln.Contains("START="))
                        //{
                        //    string val = ln.Replace("START=", string.Empty);
                        //    startstr = int.Parse(val);
                        //}
                        //else 
                        if (ln.Contains("MAX="))
                        {
                            string val = ln.Replace("MAX=", string.Empty);
                            max = int.Parse(val);
                        }
                    }
                }

                Console.WriteLine($"{item} - start");
                //if (startstr == 0)
                //    startstr = 1;

                int start = startstr;
                int proc = 0;
                int failure = 0;

                //string keyword = $"{item}-{start.ToString($"D3")}";
                int go = 0;
                while (failure < failureTreshold && start<=max)
                {
                    start++;
                    string keyword = $"{item}-{start.ToString($"D3")}";
                    go = GetFromLib(item, keyword, disc);
                    //go = GetFromLib("ZUKO", "ZUKO-001", disc);
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
                        failure++;
                        if (failure > 0)                            
                            Console.Write($" - skipped {failure}\n");
                    }            
                    
                }
                string str = $"{item} - complete {proc}\n";
                Console.WriteLine(str);
                Total.Add(str);

                List<string> ddd = new List<string>();
                if (Directory.Exists($@"{disc}:\!CATALOG\JAV\{item}\"))
                {
                    ddd.Add($"{today}");
                    ddd.Add($"START={startstr}");
                    File.WriteAllLines(check, ddd.ToArray());
                }
            }

            Console.WriteLine("Added total:");
            foreach (string item in Total)
            {
                Console.WriteLine(item);
            }            

        }
        private static int JavLibraryDoOneJavLibrary(string serie, string keyword, string disc, out string title, out string year, out List<string> stars, out List<string> genres, out string pic)
        {

            title = null;
            year = null;
            pic = null;
            stars = new List<string>();
            genres = new List<string>();
            string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{serie}\{keyword}", EpItem.p_PassportName);
            if (File.Exists(check))
            {
                return 50;
            }



            Console.Write($"    Get {keyword}");
            HttpWebRequest request = WebRequest.Create($"https://g64w.com/en/vl_searchbyid.php?keyword={keyword}") as HttpWebRequest;
            

            request.Method = "GET";
//            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:98.0) Gecko/20100101 Firefox/98.0";
            request.Accept = "*/*";
            request.Headers.Add("Accept-Encoding:  gzip, deflate, br");

            


           // CookieContainer cookieContainer = new CookieContainer();
           // Cookie userNameCookie = new Cookie("over18", "1", "/", "www.javbus.com");
           // Cookie timezoneCookie = new Cookie("existmag", "mag", "/", "www.javbus.com");
           // Cookie unkCookie = new Cookie("PHPSESSID", "gontgfkvndqlsnmq87vqrjmp96", "/", "www.javbus.com");
           // cookieContainer.Add(timezoneCookie);
           // cookieContainer.Add(userNameCookie);
           // cookieContainer.Add(unkCookie);
            
            //request.CookieContainer = cookieContainer;

            string content = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            //ServicePointManager.Expect100Continue = true;
           // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Stream stream = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                string mess = ex.Message;
                Console.Write($" {mess}\n");
                return 0;
            }

            int pos = -1;
            if (content.Contains(@"<div class=""videos"">"))
            {
                pos = content.IndexOf(@"<div class=""videos"">");
                content = content.Substring(pos);
                pos = content.IndexOf(@"<a href=");
                content = content.Substring(pos + 10, 14);
                request = WebRequest.Create($"https://g64w.com/en{content}") as HttpWebRequest;
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
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
            title = content.Substring(pos + 30);
            pos = title.IndexOf(@">");
            title = title.Substring(pos + 1);
            pos = title.IndexOf(@"<");
            title = title.Substring(0, pos);
            // 2. year
            pos = content.IndexOf(@"video_date");
            year = content.Substring(pos);
            pos = year.IndexOf(@"text");
            year = year.Substring(pos + 6, 4);
            // 3. star
            pos = content.IndexOf(@"video_cast");
            string starall = content.Substring(pos);
            stars = new List<string>();
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
            genres = new List<string>();
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
            pic = content.Substring(pos + 25);
            pos = pic.IndexOf(@".jpg");
            pic = $"http://{pic.Substring(0, pos + 4)}";



           

            return 100;
        }
        public static async Task<string> GetResponseText(string address)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(address);
        }
        static string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
        
        private static int JavLibraryDoOneJavBus(string serie, string keyword, string disc, out string title, out string year, out List<string> stars, out List<string> genres, out string pic)
        {
            title = null;
            year = null;
            pic = null;
            stars = new List<string>();
            genres = new List<string>();
            string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{serie}\{keyword}", EpItem.p_PassportName);
            if (File.Exists(check))
            {
                return 50;
            }


            Console.Write($"    Get {keyword}");
            WebRequest request = WebRequest.Create($"https://www.javbus.com/en/{keyword}") as WebRequest;
            //WebRequest request = WebRequest.Create($"https://www.javbus.com/en/OOMN-234") as WebRequest;
           

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
            catch (WebException ex)
            {
                string mess = ex.Message;
                if (mess.Contains("404"))
                    return 1;
                Console.Write($" {mess}\n");
                return 0;
            }

            int pos = -1;
            int pos1 = -1;
            // 1. title
            pos = content.IndexOf(@"<title>")+7;
            pos1 = content.IndexOf(@"</title>");
            title = content.Substring(pos, pos1- pos);
            // 2. year
            pos = content.IndexOf(@"Release Date")+13;
            year = content.Substring(pos, 4);
            // 3. star
            pos = content.IndexOf(@"<div class=""star-name""><a href=""https://www.javbus.com/en/star/");
            if (pos > -1)
            {
                string starall = content.Substring(pos);
                while (pos > 0)
                {
                    starall = starall.Substring(50);
                    pos = starall.IndexOf(@"title=""") + 7;
                    pos1 = starall.IndexOf(@""">", pos);
                    string starname = starall.Substring(pos, pos1 - pos);
                    string[] parts = starname.Split(' ');
                    if (parts.Length == 2)
                        starname = UppercaseFirst(parts[0]) + " " + UppercaseFirst(parts[1]);
                    if (!stars.Contains(starname))
                        stars.Add(starname);
                    pos = starall.IndexOf(@"<div class=""star-name""><a href=""https://www.javbus.com/en/star/");
                }
            }

            //4. Genre
            pos = content.IndexOf(@"<span class=""genre""><label><input type=""checkbox"" name=""gr_sel"" value=");
            if (pos > -1)
            {
                string genreall = content.Substring(pos);
                while (pos > 0)
                {
                    genreall = genreall.Substring(30);
                    pos = genreall.IndexOf(@">") + 1;
                    pos1 = genreall.IndexOf(@"<", pos);
                    string starname = genreall.Substring(pos, pos1 - pos).Trim();
                    if (!genres.Contains(starname) && !string.IsNullOrWhiteSpace(starname))
                        genres.Add(starname);
                    pos = genreall.IndexOf(@"<span class=""genre""><label><input type=""checkbox"" name=""gr_sel"" value=");
                }
            }
          
            //6. Picture
            pos = content.IndexOf(@"<a class=""bigImage"" href=");
            pic = content.Substring(pos + 26);
            pos = pic.IndexOf(@".jpg");
            pic = $"https://www.javbus.com{pic.Substring(0, pos + 4)}";


            return 100;
        }

        private static int JavLibraryJavdatabase(string serie, string keyword, string disc, out string title, out string year, out List<string> stars, out List<string> genres, out string pic)
        {
            title = null;
            year = null;
            pic = null;
            stars = new List<string>();
            genres = new List<string>();
            string check = Path.Combine($@"{disc}:\!CATALOG\JAV\{serie}\{keyword}", EpItem.p_PassportName);
            if (File.Exists(check))
            {
                return 50;
            }

            Thread.Sleep(SLEEP);
            Console.Write($"    Get {keyword}");
            WebRequest request = WebRequest.Create($"https://www.javdatabase.com/movies/{keyword}") as WebRequest;
            //WebRequest request = WebRequest.Create($"https://www.javdatabase.com/movies/AVSA-291") as WebRequest;
            
            //WebRequest request = WebRequest.Create($"https://www.javbus.com/en/OOMN-234") as WebRequest;


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
            catch (WebException ex)
            {
                string mess = ex.Message;
                if (mess.Contains("404"))
                    return 1;
                Console.Write($" {mess}\n");
                return 0;
            }

            try
            {
                int pos = -1;
            int pos1 = -1;
                // 1. title
            string ddd = @"<div class=""col-md-10 col-lg-10 col-xxl-10 col-8""><p class=""mb-1""><b>Title: </b>";
                //@"<div class=""col-md-10 col-lg-10 col-xxl-10 col-8""><p class=""mb-1""><b>Title: </b>
            pos1 = content.IndexOf(ddd);
                if (pos1 == -1) 
                {
                    throw new Exception("Wrong format !!!!!!!!!!!!!!!!!!!!!!");
                }
            pos = pos1 + ddd.Length;
            pos1 = content.IndexOf(@"</p><p class=""mb-1""><b>", pos);
            title = content.Substring(pos, pos1 - pos);
                // 2. year
                ddd = @"<p class=""mb-1""><b>Release Date: </b>";
            pos = content.IndexOf(ddd)+ddd.Length;
            year = content.Substring(pos,4);
            // 3. star
            pos = content.IndexOf(@"Actress/Idols</h2><div class=""row"">");
            if (pos > -1)
            {
                //</a></p><div class="idol-thumb">
                string starall = content.Substring(pos);
                while (pos > 0)
                {
                    //starall = starall.Substring(50);
                    pos = starall.IndexOf(@"""cut-text"" href=""https://www.javdatabase.com/idols/")+50;
                    starall = starall.Substring(pos);
                    pos = starall.IndexOf(@"/"">")+3;
                    pos1 = starall.IndexOf(@"</a></p><div class=""idol-thumb"">");
                    string starname = starall.Substring(pos, pos1 - pos);
                    if (!stars.Contains(starname))
                        stars.Add(starname);
                    pos = starall.IndexOf(@"""cut-text"" href=""https://www.javdatabase.com/idols/");
                }
            }

            //4. Genre
            pos = content.IndexOf(@"<p class=""mb-1""><b>Genre(s): </b><span class=""btn btn-primary btn-sm"">");
            if (pos > -1)
            {
                string genreall = content.Substring(pos);
                while (pos > 0)
                {
                    //genreall = genreall.Substring(30);
                    pos = genreall.IndexOf(@"<a href=""https://www.javdatabase.com/genres")+30;
                    genreall = genreall.Substring(pos);
                    pos = genreall.IndexOf(@"rel=""tag"">")+10;
                    pos1 = genreall.IndexOf(@"</a></span>");
                    string starname = genreall.Substring(pos, pos1 - pos).Trim();
                    if (!genres.Contains(starname) && !string.IsNullOrWhiteSpace(starname))
                        genres.Add(starname);
                    pos = genreall.IndexOf(@"<a href=""https://www.javdatabase.com/genres");
                }
            }

            //6. Picture
            pos = content.IndexOf(@"data-src=""https://www.javdatabase.com/covers/full")+10;
            pos1 = content.IndexOf(@""" width=""", pos);
            pic = content.Substring(pos, pos1 - pos).Trim();


            return 100;
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                Console.Write($" {mess}\n");
                return 0;
            }
        }


        private static int GetFromLib(string serie, string keyword, string disc)
        {
            string title1;
            string year1;
            List<string> stars1;
            List<string> genres1;
            string pic1;
            string title2;
            string year2;
            List<string> stars2;
            List<string> genres2;
            string pic2;
            
            //int rez = JavLibraryDoOneJavBus(serie, keyword, disc, out title1, out year1, out stars1, out genres1, out pic1);
            int rez = JavLibraryJavdatabase(serie, keyword, disc, out title1, out year1, out stars1, out genres1, out pic1);
            


            //int rez = JavLibraryDoOneJavLibrary(serie, keyword, disc, out title1, out year1, out stars1, out genres1, out pic1);

            /*
            if (rez != 100) 
            {
                rez = JavLibraryDoOneJavBus(serie, keyword, disc, out title2, out year2, out stars2, out genres2, out pic2);
            }
            else if (string.IsNullOrEmpty(title1) || string.IsNullOrEmpty(year1) || string.IsNullOrEmpty(pic1) || !stars1.Any() || !genres1.Any())
            {
                JavLibraryDoOneJavBus(serie, keyword, disc, out title2, out year2, out stars2, out genres2, out pic2);
                title1 = !string.IsNullOrEmpty(title1) ? title1 : title2;
                year1 = !string.IsNullOrEmpty(year1) ? year1 : year2;
                pic1 = !string.IsNullOrEmpty(pic1) ? pic1 : pic2;
                stars1 = stars1.Any() ? stars1 : stars2;
                genres1 = genres1.Any() ? genres1 : genres2;
            }
            */
            if (rez == 100)
                SaveDataToPassport(serie, keyword, disc, title1, year1, stars1, genres1, pic1);

            return rez;
        }
        private static async Task<string> getcontent(string adr) 
        {
            string content = null;
            try
            {
                // Create the clearance handler.
                var handler = new ClearanceHandler
                {
                    MaxRetries = 100 // Optionally specify the number of retries, if clearance fails (default is 3).
                };

                // Create a HttpClient that uses the handler to bypass CloudFlare's JavaScript challange.
                var client = new HttpClient(handler);

                // Use the HttpClient as usual. Any JS challenge will be solved automatically for you.
                content = await client.GetStringAsync(@"https://www.jav28.com");
            }
            catch (Exception ex)
            {
                var sdfsdfsdf = 1;
                // After all retries, clearance still failed.
            }
            /*
            catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            {
                // After all retries, clearance still failed.
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                // Looks like we ran into a timeout. Too many clearance attempts?
                // Maybe you should increase client.Timeout as each attempt will take about five seconds.
            }
            */
            return content;
        }
        private static int JavLibraryDoOneJav28(string serie, string keyword, string disc, out string title, out string year, out List<string> stars, out List<string> genres, out string pic)
        {
            title = null;
            year = null;
            pic = null;
            stars = new List<string>();
            genres = new List<string>();
            Console.Write($"    Get {keyword}");

            //var task = getcontent($"https://www.jav28.com/en/movie/{keyword}");
            //Task<string> task = Task.Run<string>(async () => await getcontent($"https://www.jav28.com/en/movie/{keyword}"));
            string content = getcontent($"https://www.jav28.com/en/movie/{keyword}").GetAwaiter().GetResult();
            

            //WebRequest request = WebRequest.Create($"https://www.jav28.com/en/movie/{keyword}") as WebRequest;
            //WebRequest request = WebRequest.Create($"https://www.jav28.com/en/movie/OOMN-234") as WebRequest;

            /*
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
            catch (WebException ex)
            {
                string mess = ex.Message;
                if (mess.Contains("404"))
                    return 1;
                Console.Write($" {mess}\n");
                return 0;
            }
            */

            int pos = -1;
            int pos1 = -1;
            // 1. title
            pos = content.IndexOf(@"<title>") + 7;
            pos1 = content.IndexOf(@"</title>");
            title = content.Substring(pos, pos1 - pos);
            // 2. year
            pos = content.IndexOf(@"Release Date") + 13;
            year = content.Substring(pos, 4);
            // 3. star
            pos = content.IndexOf(@"<div class=""star-name""><a href=""https://www.javbus.com/en/star/");
            string starall = content.Substring(pos);
            while (pos > 0)
            {
                starall = starall.Substring(50);
                pos = starall.IndexOf(@"title=""") + 7;
                pos1 = starall.IndexOf(@""">", pos);
                string starname = starall.Substring(pos, pos1 - pos);
                string[] parts = starname.Split(' ');
                if (parts.Length == 2)
                    starname = parts[1] + " " + parts[2];
                if (!stars.Contains(starname))
                    stars.Add(starname);
                pos = starall.IndexOf(@"<div class=""star-name""><a href=""https://www.javbus.com/en/star/");
            }

            //4. Genre
            pos = content.IndexOf(@"<span class=""genre""><label><input type=""checkbox"" name=""gr_sel"" value=");
            string genreall = content.Substring(pos);
            while (pos > 0)
            {
                genreall = genreall.Substring(30);
                pos = genreall.IndexOf(@">") + 1;
                pos1 = genreall.IndexOf(@"<", pos);
                string starname = genreall.Substring(pos, pos1 - pos).Trim();
                if (!genres.Contains(starname) && !string.IsNullOrWhiteSpace(starname))
                    genres.Add(starname);
                pos = genreall.IndexOf(@"<span class=""genre""><label><input type=""checkbox"" name=""gr_sel"" value=");
            }


            //6. Picture
            pos = content.IndexOf(@"<a class=""bigImage"" href=");
            pic = content.Substring(pos + 26);
            pos = pic.IndexOf(@".jpg");
            pic = $"https://www.javbus.com{pic.Substring(0, pos + 4)}";
                using (WebClient client = new WebClient())
                {
                    try
                    {

                        client.DownloadFile(pic, @"c:\temp\TEST.JPG");
                    }
                    catch (Exception)
                    {
                        pic = null;
                    }

                }            
            return 100;
        }
        private static int SaveDataToPassport(string serie, string keyword, string disc, string title, string year, List<string> stars, List<string> genres, string pic)
        {
            
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
                //item.Director = string.Join(",", directors.ToArray());
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
                        if (pic.Contains(".webp"))
                        {
                            posterpath = Path.Combine(path, "POSTER.webp");
                            if (!File.Exists(posterpath)) 
                            {
                                client.DownloadFile(pic, posterpath);
                            }
                        }
                        else
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
            int go = GetFromLib(serie, keyword, disc);
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
                go = GetFromLib(serie, keyword, disc);
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


            string fileorig = $@"Hayashi Yuna.txt";
            string content = File.ReadAllText(Path.Combine(pathRes, fileorig));
            file = $@"{marker}.txt";
            File.WriteAllText(Path.Combine(pathRes, file), content);

            fileorig= $@"Hayashi Yuna.xml";
            content = File.ReadAllText(Path.Combine(pathRes, fileorig));
            file = $@"{marker}.xml";
            content = content.Replace("Hayashi Yuna", marker);
            File.WriteAllText(Path.Combine(pathRes, file),content);

        }

        public static Dictionary<string, string> _JAVupdated;
        private static int threshold_days = 0;
        private static int threshold_hours = 0;
        public static int ApdateAfter;


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
      
        public static void SaveCatalog(ref List<EpItem> list, bool IsSynchPosterAllowed,string CurrentCatalog, List<string> folders, string BackupFolder)
        {
            Console.WriteLine($"Reload JAV collection..");
            JAV.ReloadCollection();
            CatalogLoader.AddedTotal = 0;

            foreach (var item in folders)
            {
                CatalogLoader.UpdateFolder(item, ref list, false, IsSynchPosterAllowed, BackupFolder, CurrentCatalog, false);
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

    }
}
