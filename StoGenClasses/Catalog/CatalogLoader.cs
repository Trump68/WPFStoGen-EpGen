using EPCat.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Catalog
{
    public class CatalogLoader
    {
        public static List<string> Actress_found = new List<string>();
        private static List<string> _Actress_to_track;
        public static List<string> FoundActress;
        private static List<string> Actress_to_track 
        {
            get 
            {
                if (_Actress_to_track == null)
                {
                    _Actress_to_track = new List<string>();
                    _Actress_to_track.Add("Natsume Iroha");
                    _Actress_to_track.Add("Kijima Airi");                    
                    _Actress_to_track.Add("Tsukino Runa");
                    _Actress_to_track.Add("Momonogi Kana");
                    _Actress_to_track.Add("Aiga Mizuki");
                    _Actress_to_track.Add("Aizawa Minami");
                    _Actress_to_track.Add("Akari Tsumugi");
                    _Actress_to_track.Add("Amami Tsubasa");
                    _Actress_to_track.Add("Aoi Tsukasa");
                    _Actress_to_track.Add("Aso Nozomi");
                    _Actress_to_track.Add("Fukada Eimi");
                    _Actress_to_track.Add("Futaba Ema");
                    _Actress_to_track.Add("Hatano Yui");
                    _Actress_to_track.Add("Iioka Kanako");
                    _Actress_to_track.Add("Imai Kaho");
                    _Actress_to_track.Add("Kaede Karen");
                    _Actress_to_track.Add("Kawakami Nanami");
                    _Actress_to_track.Add("Kawakita Saika");
                    _Actress_to_track.Add("Kimijima Mio");
                    _Actress_to_track.Add("Kujou Michiru");
                    _Actress_to_track.Add("Matsumoto Ichika");
                    _Actress_to_track.Add("Mikami Yua");
                    _Actress_to_track.Add("Mino Suzume");
                    _Actress_to_track.Add("Misaki Nanami");
                    _Actress_to_track.Add("Mitsumi An");
                    _Actress_to_track.Add("Mitani Akari");
                    _Actress_to_track.Add("Narumi Konoha");
                    _Actress_to_track.Add("Ogura Yuna");
                    _Actress_to_track.Add("Ono Yuuko");
                    _Actress_to_track.Add("Satou Hakune");
                    _Actress_to_track.Add("Shinoda Yuu");
                    _Actress_to_track.Add("Shirasaka Mian");
                    _Actress_to_track.Add("Shirato Hana");
                    _Actress_to_track.Add("Shiromine Miu");
                    _Actress_to_track.Add("Suzumori Remu");
                    _Actress_to_track.Add("Tsujii Honoka");
                    _Actress_to_track.Add("Usui Saryuu");
                    _Actress_to_track.Add("Utsunomiya Shion");
                    _Actress_to_track.Add("Yamaguchi Haru");                    
                    _Actress_to_track.Add("Hayashi Ryou");
                    _Actress_to_track.Add("Nagashima Saori");
                    _Actress_to_track.Add("Kuriyama Rio");
                    _Actress_to_track.Add("Komatsu Azu");
                    _Actress_to_track.Add("Yamagishi Aika");
                    _Actress_to_track.Add("Yoshitaka Nene");
                    _Actress_to_track.Add("Kotooka Miyuki");
                    _Actress_to_track.Add("Natsuki Maron");
                    _Actress_to_track.Add("Tsujii Honoka");
                    
                }
                return _Actress_to_track;
            }
        }
        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
        public static int CreateUpdateFromPassport(string passportPath, ref List<EpItem> list, bool IsSynchPosterAllowed, string CurrentCatalog, string BackupCatalog)
        {
            FoundActress = new List<string>();
            int result = 0;
            List<string> passport = new List<string>(File.ReadAllLines(passportPath));
            if (passport != null)
            {

                EpItem item = EpItem.GetFromPassport(passport, passportPath);

                if (item.GID == null || Guid.Empty.Equals(item.GID))
                {
                    item.GID = Guid.NewGuid();
                    item.Edited = true;

                }

                string dirname = Path.GetDirectoryName(passportPath);
                if (string.IsNullOrEmpty(item.Name))
                {
                    if (passportPath.Contains(@"/HEN/"))
                        item.Catalog = "HEN";
                    else if (passportPath.Contains(@"/MOV/"))
                        item.Catalog = "MOV";
                    else if (passportPath.Contains(@"/AMA/"))
                        item.Catalog = "AMA";
                    else if (passportPath.Contains(@"/JAV/"))
                        item.Catalog = "JAV";
                    else if (passportPath.Contains(@"/WEB/"))
                        item.Catalog = "WEB";
                    else if (passportPath.Contains(@"/PTD/"))
                        item.Catalog = "PTD";
                    else if (passportPath.Contains(@"/PRS/"))
                        item.Catalog = "PRS";
                    else if (passportPath.Contains(@"/COM/"))
                        item.Catalog = "COM";


                    item.Name = UppercaseWords(Path.GetFileName(dirname));
                    if (string.IsNullOrEmpty(item.Director) && item.Catalog == "HEN" && item.Kind == "Hentai Artist")
                    {
                        string director = Directory.GetParent(dirname).Name;
                        item.Director = UppercaseWords(director);
                    }
                    else if (string.IsNullOrEmpty(item.Studio) && item.Catalog == "HEN" && item.Kind == "GameCG")
                    {
                        string studio = Directory.GetParent(dirname).Name;
                        item.Studio = studio.ToUpper();
                    }
                }

                // JAV person rating                
                StarRating.SetRating(item);


                item.SourceFolderExist = true;
                // size
                var filesmp3 = Directory.GetFiles(dirname, "*.m4v").ToList();
                long s = 0;
                int d = 1000000;
                bool isUncensored = false;
                bool isUncensoredByMe = false;
                bool isEnhanced = false;
                bool isLeaked = false;
                foreach (string fn in filesmp3)
                {
                    string pf = fn.ToUpper();

                    if (pf.Contains("UNCENSOREDBM"))
                    {
                        isUncensoredByMe = true;
                    }
                    else if (pf.Contains("UNCENSORED"))
                    {
                        isUncensored = true;
                    }
                    if (pf.Contains("LEAKED"))
                    {
                        isLeaked = true;
                    }
                    if (pf.Contains("ENHANCED"))
                    {
                        isEnhanced = true;
                    }
                    try
                    {
                        FileInfo fi = new FileInfo(fn);
                        s += fi.Length;
                        item.M4V += 1;
                    }
                    catch (Exception)
                    {
                        // path too long exception
                        //throw;
                    }
                }
                if (s > 0)
                    item.Size = Convert.ToInt32((s / d));


                var existingItem = list.Where(x => x.GID == item.GID).FirstOrDefault();
                if (item.GID == Guid.Parse("6d819c03-4f1d-4020-9cbf-44e0e472b504")) 
                {
                    int dddd = 1;
                }
                if (existingItem == null)
                {
                    if (string.IsNullOrEmpty(item.Type) || (!item.Type.ToUpper().Contains("OMNIBUS")))
                    {
                        if (string.IsNullOrEmpty(item.Kind) || (!item.Kind.ToUpper().Contains("SKIP")))
                        {

                                if (string.IsNullOrEmpty(item.Name))
                                {
                                    string name = Path.GetFileName(Path.GetDirectoryName(passportPath)).ToLower();
                                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                                    item.Name = cultInfo.ToTitleCase(name);
                                    item.Edited = true;
                                }
                                if (isUncensoredByMe)
                                    item.Kind = "UNCBM";
                                else if (isUncensored)
                                    item.Kind = "UNC";
                                if (isLeaked)
                                    item.Kind = "UNCL";
                                if (isEnhanced)
                                    item.Kind = $"{item.Kind}ENH";

                                item.Brand = $"{DateTime.Now.Year.ToString("D4")}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}";
                                if (!string.IsNullOrEmpty(item.Star))
                                {
                                    List<string> stars = item.Star.Split(',').ToList();
                                    bool converted;
                                    stars = NormalizeJavStars(stars, out converted);
                                if (converted) 
                                {
                                    item.Rated = "Name converted";
                                }
                                    item.Star = string.Join(",", stars);
                                    string found_actress = string.Empty;
                                    
                                    foreach (var actress in Actress_to_track)
                                    {
                                        if (stars.Contains(actress))
                                        {
                                            if (!FoundActress.Contains(actress))
                                            {
                                                FoundActress.Add(actress);
                                            }
                                            Actress_found.Add($"{item.Name}-{actress}");
                                            found_actress = actress;
                                            break;
                                        }
                                    }

                                    if (string.IsNullOrEmpty(found_actress))
                                        Console.WriteLine($"{item.Name} - new! {AddedTotal}");
                                    else
                                        Console.WriteLine($"{item.Name} - new for tracked actress - {found_actress}! {AddedTotal}");
                                }
                            list.Add(item);
                            result = 1;
                            
                        }
                    }
                }
                else
                {
                    if (isUncensoredByMe && (string.IsNullOrEmpty(existingItem.Kind) || existingItem.Kind != "UNCBM"))
                    {
                        item.Kind = "UNCBM";
                        item.LastEdit++;
                    }
                    else if (isUncensored && (string.IsNullOrEmpty(existingItem.Kind) || existingItem.Kind != "UNC"))
                    {
                        item.Kind = "UNC";
                        item.LastEdit++;
                    }
                    if (isLeaked && (string.IsNullOrEmpty(existingItem.Kind) || existingItem.Kind != "UNCL"))
                    {
                        item.Kind = "UNCL";
                        item.LastEdit++;
                    }
                    if (isEnhanced && (string.IsNullOrEmpty(existingItem.Kind) || (!existingItem.Kind.Contains("ENH"))))
                    {
                        item.Kind = $"{item.Kind}ENH";
                        item.LastEdit++;
                    }
                    if (existingItem.LastEdit < item.LastEdit)
                    {
                        existingItem.UpdateFrom(item);
                    }
                    else
                    {
                        // always
                        existingItem.Size = item.Size;
                        existingItem.M4V = item.M4V;
                        existingItem.SetItemPath(item.ItemPath);
                        existingItem.SourceFolderExist = item.SourceFolderExist;
                        existingItem.PersonKind = item.PersonKind;
                    }
                    Console.WriteLine($"{item.Name}");

                }
                if (item.Edited)
                {
                    UpdateItem(item);                    
                }

                //Backup
                if (!string.IsNullOrEmpty(BackupCatalog))
                {
                    bool dod = false;
                    if (item.Kind == "UNCBM")
                    {
                        dod = true;
                    }
                    else if (item.Kind == "UNC")
                    {
                        dod = true;
                    }
                    else if (!string.IsNullOrEmpty(item.Star))
                    {
                        var vals = item.Star.Split(',');
                        if (vals.Any(x => CatalogLoader.BACKUP_ACTRESS_LIST.Contains(x)))
                        {
                            dod = true;
                        }
                    }

                    if (dod)
                    {
                        string targetPath = Path.Combine(BackupCatalog, item.Serie, item.Name);
                        List<string> existingFiles = new List<string>();
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }
                        else
                        {
                            existingFiles = Directory.GetFiles(targetPath, "*.m4v").ToList();
                            foreach (string fn in existingFiles)
                            {
                                string file = Path.GetFileName(fn);
                                string filedest = Path.Combine(dirname, file);
                                if (!File.Exists(filedest))
                                {
                                    Console.WriteLine($"Delete file:{file}");
                                    File.Delete(fn);
                                }
                            }
                        }
                        foreach (string fn in filesmp3)
                        {
                            string file = Path.GetFileName(fn);
                            string filedest = Path.Combine(targetPath, file);
                            if (!File.Exists(filedest))
                            {
                                Console.WriteLine($"Backup file:{file}");
                                File.Copy(fn, filedest, false);
                            }
                        }

                    }
                }
                if (IsSynchPosterAllowed)
                {
                    //poster
                    bool copyPoster = false;
                    bool reversecopyPoster = false;
                    string dirPoster = EpItem.GetCatalogPosterDir(CurrentCatalog);
                    string newPostername = Path.Combine(dirPoster, $"{item.GID}.jpg");

                    if (existingItem == null)
                    {
                        copyPoster = true;
                    }
                    else
                    {
                        if (existingItem.LastEdit < item.LastEdit)
                        {
                            copyPoster = true;
                        }
                        else
                        {
                            copyPoster = !File.Exists(newPostername);
                            reversecopyPoster = !copyPoster;
                        }
                    }
                    if (copyPoster)
                    {
                        bool posterExist = File.Exists(item.PosterPath);
                        if (posterExist)
                        {
                            try
                            {
                                File.Copy(item.PosterPath, newPostername, true);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else if (reversecopyPoster)
                    {
                        bool posterExist = File.Exists(newPostername);
                        if (posterExist)
                        {
                            try
                            {
                                if (!File.Exists(item.PosterPath))
                                    File.Copy(newPostername, item.PosterPath, false);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static List<string> NormalizeJavStars(List<string> stars, out bool converted)
        {
            converted = true;
            var result = new List<string>();
            foreach (var item in stars)
            {
                if (item == "Umi Yatugake") result.Add("Yatsugake Umi");
                else if (item == "乃木絢愛") result.Add("Nogi Ayame");
                else if (item == "七嶋舞") result.Add("Nanashima Mai");
                else if (item == "流川夕") result.Add("Rukawa Yuu");
                else if (item == "Remu Suzumori") result.Add("Suzumori Remu");
                else if (item == "美ノ嶋めぐり") result.Add("Minoshima Meguri");
                else if (item == "唯月優花") result.Add("Yuzuki Yuka");
                else if (item == "Be Kawai tomorrow") result.Add("Kawai Asuna");
                else if (item == "Suzu Matuoka") result.Add("Matsuoka Suzu");
                else if (item == "Non Nonoura") result.Add("Nonoura Non");
                else if (item == "小鳩麦") result.Add("Kobato Mugi");
                else if (item == "乃木絢愛") result.Add("Nogi Ayame");
                else if (item == "Miu Nakamura") result.Add("Nakamura Miu");
                else if (item == "藤田こずえ") result.Add("Fujita Kozue");
                else if (item == "Natsume Aya Haru") result.Add("Natsume Iroha");
                else if (item == "Tubaki Sannomiya") result.Add("Sannomiya Tsubaki");
                else if (item == "Riona Hirose") result.Add("Hirose Riona");
                else if (item == "Hiiragi Kaede") result.Add("Kaede Hiiragi");
                else if (item == "Tenharu Noa") result.Add("Noa Amaharu");
                else if (item == "Rena Kodama") result.Add("Kodama Rena");
                else if (item == "Kana Kusakabe") result.Add("Kusakabe Kana");
                else if (item == "Nanase Asahina") result.Add("Asahina Nanase");
                else if (item == "Kano Kasii") result.Add("Kashii Hananoki");
                else if (item == "工藤ララ") result.Add("Kudou Rara");
                else if (item == "如月えれな") result.Add("Kisaragi Erena");
                else if (item == "Violet Minagawa") result.Add("Mizukawa Sumire");
                else if (item == "Sumire Kuramoto") result.Add("Kuramoto Sumire");
                else if (item == "北野未奈") result.Add("Kitano Mina");
                else if (item == "Itou Mai snow") result.Add("Itou Mayuki");
                else if (item == "Moko Sakura") result.Add("Sakura Moko");
                else if (item == "Yui Amane") result.Add("Amane Yui");
                else if (item == "Natu Hinata") result.Add("Hinata Natsu");
                else if (item == "Hutaba Kurimiya") result.Add("Kurimiya Futaba");
                else if (item == "Azusa Sinonome") result.Add("Shinonome Azusa");
                else if (item == "Rino3 Sakai") result.Add("Sakai Rino");
                else if (item == "Asahi Kawakita") result.Add("Kawakita Asahi");
                else if (item == "Ena Satuki") result.Add("Satsuki Ena");
                else if (item == "Yuria Yoshine") result.Add("Yoshine Yuria");
                else if (item == "Misuzu Mihune") result.Add("Hanamori Mirai");
                else if (item == "Nene Tanaka") result.Add("Tanaka Nene");
                else if (item == "乙アリス") result.Add("Seina Arisa");
                else if (item == "Rino Yuuki") result.Add("Yuki Rino");
                else if (item == "Rena Aoi") result.Add("Aoi Rena");
                else if (item == "Wooden floor plug for a door of center hinge pivot Aoi") result.Add("Kururigi Aoi");
                else if (item == "Mao Hamasaki") result.Add("Hamasaki Mao");
                else if (item == "Riho Huzimori") result.Add("Yamamoto Shuri");
                else if (item == "Titose Yuki") result.Add("Saegusa Chitose");
                else if (item == "Itika Matumoto") result.Add("Matsumoto Ichika");
                else if (item == "Sara Aizawa") result.Add("Aizawa Sara");
                else if (item == "Maron Natuki") result.Add("Natsuki Maron");                
                else if (item == "Honoka Tuzii") result.Add("Tsujii Honoka");
                else if (item == "有岡みう") result.Add("Arioka Miu");
                else if (item == "南いろは") result.Add("Minami Iroha");
                else if (item == "Meru Itou") result.Add("Itou Meru");
                else if (item == "Karina Nishida") result.Add("Nishita Karina");
                else if (item == "Airi Honoka") result.Add("Honoka Airi");
                else if (item == "黒川すみれ") result.Add("Kurokawa Sumire");
                else if (item == "Bi valley Akari") result.Add("Mitani Akari");
                else if (item == "Rui Nanase") result.Add("Nanase Rui");
                else if (item == "Yuuri Hukada") result.Add("Fukada Yuuri");
                else if (item == "Meisa Kawakita") result.Add("Kawakita Meisa");
                else if (item == "Nanami Kawakami") result.Add("Kawakami Nanami");
                else if (item == "Mio Nozaki") result.Add("Nosaki Mio");
                else if (item == "Itika Nanzyou") result.Add("Nanjou Ichika");
                else if (item == "Itika Seta") result.Add("Seta Ichihana");
                else if (item == "Tubaki Siraisi") result.Add("Shiraishi Tsubaki");
                else if (item == "Yunon Hosimiya") result.Add("Hoshimiya Yunon");
                else if (item == "Ai2 Yuuki") result.Add("Yuuki Ai");
                else if (item == "Haruka Miyana") result.Add("Miyana You");
                else if (item == "夏木りん") result.Add("Natsuki Rin");
                else if (item == "Yuko Ono") result.Add("Ono Yuuko");
                else if (item == "Yume Nikaido") result.Add("Nikaidou Yume");
                else if (item == "Momo Honda") result.Add("Honda Momo");
                else if (item == "Miyu Horisawa") result.Add("Horisawa Mayu");
                else if (item == "時田亜美") result.Add("Tokita Ami");
                else if (item == "Moe Angel") result.Add("Amatsuka Moe");
                else if (item == "There is Hashimoto") result.Add("Hashimoto Arina");
                else if (item == "Nene Yoshitaka") result.Add("Yoshitaka Nene");
                else if (item == "本郷愛") result.Add("Hongou Ai");
                else if (item == "Momo Honda") result.Add("Honda Momo");
                else if (item == "Kaname Momoziri") result.Add("Momojiri Kaname");
                else if (item == "Ruru Amakumi") result.Add("Tengoku Ruru");
                else if (item == "Miyu Horisawa") result.Add("Horisawa Mayu");
                else if (item == "時田亜美") result.Add("Tokita Ami");
                else if (item == "望実れい") result.Add("Nozomi Rei");
                else if (item == "五十嵐なつ") result.Add("Igarashi Natsu");
                else if (item == "雪宮みづき") result.Add("Setsumiyamizuki");
                else if (item == "Rika Tubaki") result.Add("Tsubaki Rika");
                else if (item == "Mirai Sena") result.Add("Sena Mirai");
                else if (item == "神谷さつき") result.Add("Kamiya Satsuki");
                else if (item == "Himari Kinosita") result.Add("Hanazawa Himari");
                else if (item == "Reona Tomiyasu") result.Add("Tomiyasu Reona");
                else if (item == "若月みいな") result.Add("Wakatsuki Miina");
                else if (item == "佐伯由美香") result.Add("Saeki Yumika");
                else if (item == "Momoka Kato") result.Add("Katou Momoka");
                else if (item == "音琴るい") result.Add("Otogoto Rui");
                else if (item == "Honioi Yonekura") result.Add("Yonekura Honoka");
                else if (item == "成咲優美") result.Add("Narisa Yumi");
                else if (item == "Satori Fujinami") result.Add("Fujinami Satori");
                else if (item == "Rin East") result.Add("Azuma Rin");
                else if (item == "平井栞奈") result.Add("Hirai Kanna");
                else if (item == "Rinka Tahara") result.Add("Tahara Rika");
                else if (item == "Misono Mizuhara") result.Add("Mizuhara Misono");
                else if (item == "Ituka Tosaki") result.Add("Tosaki Itsuka");
                else if (item == "Anna3") result.Add("Anna");
                else if (item == "Mei Kamisaka") result.Add("Kamisaka Mei");
                else if (item == "Hana Sirato") result.Add("Shirato Hana");
                else if (item == "市川愛茉") result.Add("Ichikawa Ema");
                else if (item == "Kana Yura") result.Add("Yura Kana");
                else if (item == "Miria2 Haduki") result.Add("Hazuki Miria");
                else if (item == "花芽ありす") result.Add("Kaga Arisu");
                else if (item == "Ai Sayama") result.Add("Sayama Ai");
                else if (item == "Hana Himesaki") result.Add("Himesaki Hana");
                else if (item == "高橋りほ") result.Add("Takahashi Riho");
                else if (item == "Rika Aimi") result.Add("Aimi Rika");
                else if (item == "Yuzu Shirakawa") result.Add("Shirakawa Yuzu");
                else if (item == "横宮七海") result.Add("Yokomiya Nanami");
                else if (item == "Hana Himesaki") result.Add("Himesaki Hana");
                else if (item == "Alice Mizushima") result.Add("Mizushima Arisu");
                else if (item == "Fujikawa greens cord") result.Add("Fujikawa Nao");
                else if (item == "Mahiro Itiki") result.Add("Ichiki Mahiro");
                else if (item == "京花萌") result.Add("Kyohana Moe");
                else if (item == "木下ひまり") result.Add("Hanazawa Himari");
                else if (item == "柳井ひな") result.Add("Yanai Hina");
                else if (item == "Mikako Horiuti") result.Add("Horiuchi Mikako");
                else if (item == "Ayu Togawa") result.Add("Togawa Ayu");
                else if (item == "Hina Hirose") result.Add("Hirose Hina");
                else if (item == "Setu Himeno") result.Add("Himeno Setsu");
                else if (item == "Hikaru Miyanisi") result.Add("Miyanishi Hikaru");
                else if (item == "Mai Kanami") result.Add("Kanami Mai");
                else if (item == "Miu Siromine") result.Add("Shiromine Miu");
                else if (item == "Iyona Huzii") result.Add("Fujii Iyona");
                else if (item == "Ema Hutaba") result.Add("Futaba Ema");
                else if (item == "Hikari Azusa") result.Add("Azusa Hikari");
                else if (item == "Anna Kami") result.Add("Kami Anna");
                else if (item == "Karen Kaede") result.Add("Kaede Karen");
                else if (item == "Yuzuriha Karen") result.Add("Kaede Karen");                
                else if (item == "Sakura Sora Momo") result.Add("Sakura Momo");
                else if (item == "Tsubasa Amami") result.Add("Amami Tsubasa");
                else if (item == "Yume Nishinomiya") result.Add("Nishimiya Yume");
                else if (item == "Nanami Misaki") result.Add("Misaki Nanami");
                else if (item == "Nozomi Shima Airi") result.Add("Kijima Airi");
                else if (item == "Airi Kijima") result.Add("Kijima Airi");
                else if (item == "Amiri Saitou") result.Add("Saitou Amiri");
                else if (item == "Miyuu Inamori") result.Add("Inamori Miyuu");
                else if (item == "Uta Iori") result.Add("Iori Hane");
                else if (item == "Anna Hanayagi") result.Add("Hanayagi Anna");
                else if (item == "Yuri Homma") result.Add("Honma Yuri");
                else if (item == "Reina Momozono") result.Add("Momozono Rena");
                else if (item == "An Mitumi") result.Add("Mitsumi An");
                else if (item == "Erina3") result.Add("ERINA");
                else if (item == "Aoi Itino") result.Add("Ichino Aoi");
                else if (item == "Nanami Tanaka") result.Add("Tanaka Nanami");
                else if (item == "Miharu Oku") result.Add("Okumi Haruka");
                else if (item == "An Komatu") result.Add("Komatsu Azu");
                else if (item == "水戸かな") result.Add("Mito Kana");
                else if (item == "Nina Nishimura") result.Add("Nishimura Nina");
                else if (item == "Rio Kuriyama") result.Add("Kuriyama Rio");
                else if (item == "hakuishi***") result.Add("Shiraishi Marina");
                else if (item == "Minami Yasu") result.Add("Yasu Minami");
                else if (item == "Mahuyu Akatuki") result.Add("Akatsuki Mafuyu");
                else if (item == "Haato Ririi") result.Add("Lily Heart");
                else if (item == "Chaoyang Mizuno") result.Add("Mizuno Asahi");
                else if (item == "Hitomi Honda") result.Add("Honda Hitomi");
                else if (item == "Maiko Ayase") result.Add("Ayase Maiko");
                else if (item == "Yuu Shinoda") result.Add("Shinoda Yuu");
                else if (item == "Zyun Suehiro") result.Add("Suehiro Jun");
                else if (item == "Kou Sirahana") result.Add("Shirahana Kou");
                else if (item == "Ririko Kinosita") result.Add("Kinoshita Ririko");
                else if (item == "Minato Maiha") result.Add("Maihane Mishou");
                else if (item == "夏川うみ") result.Add("Natsukawa Umi");
                else if (item == "水戸かな") result.Add("Mito Kana");
                else if (item == "Mio Kamisiro") result.Add("Ueshiro Mio");
                else if (item == "Nao Jinguji") result.Add("Jinguuji Nao");
                else if (item == "Yuuki Sinomiya") result.Add("Sasamiya Yuuki");
                else if (item == "Hiziri Maihara") result.Add("Maikawa Sena");
                else if (item == "Saori Nagasima") result.Add("Nagashima Saori");
                else if (item == "Yumi Kazama") result.Add("Kazama Yumi");
                else if (item == "Yuuka Aota") result.Add("Aota Haruka");
                else if (item == "Maki Houjou") result.Add("Houjou Maki");
                else if (item == "Nagasima Saori") result.Add("Nagashima Saori");
                else if (item == "Siromine Miu") result.Add("Shiromine Miu");
                else if (item == "Toujyou Natu") result.Add("Toujou Natsu");
                else if (item == "Tukino Runa2") result.Add("Tsukino Runa");
                else if (item == "Huzimori Riho") result.Add("Yamamoto Shuri");
                else if (item == "Jinguji Nao") result.Add("Jinguuji Nao");
                else if (item == "Kana Momonogi") result.Add("Momonogi Kana");
                else if (item == "Nanatumori Riri") result.Add("Nanatsumori Riri");
                else if (item == "Ayumi Ryou") result.Add("Hayashi Ryou");
                else if (item == "Hosikawa Mai2") result.Add("Hoshikawa Mai");
                else if (item == "Yui Nishikawa") result.Add("Nishikawa Yui");
                else if (item == "Nishinomiya Yume") result.Add("Nishimiya Yume");
                else if (item == "Muto Ayaka") result.Add("Mutou Ayaka");
                else if (item == "Siki Akane") result.Add("Shiki Akane");
                else if (item == "Sirasaka Mian") result.Add("Shirasaka Mian");
                else if (item == "Sirato Hana") result.Add("Shirato Hana");
                else if (item == "Ayaka Kawakita") result.Add("Kawakita Saika");
                else if (item == "北野未奈") result.Add("Kitano Mina");                
                else if (item == "Mitumi An") result.Add("Mitsumi An");
                else if (item == "Nozomi Shima Airi") result.Add("Kijima Airi");                
                else if (item == "Minami Aizawa") result.Add("Aizawa Minami");
                else if (item == "成美このは") result.Add("Narumi Konoha");
                else if (item == "上原瑞穂") result.Add("Uehara Mizuho");
                else if (item == "Akesato Tsumugi") result.Add("Akari Tsumugi");
                else if (item == "九重かんな") result.Add("Kokonoe Kanna");
                else if (item == "三田杏") result.Add("Mita An");
                else if (item == "野間あんな") result.Add("Noma Anna");
                else if (item == "Hayashi Eri") result.Add("Kouduki Yaya");
                else if (item == "Natsume Aya Haru") result.Add("Natsume Iroha");
                else if (item == "Hara Sarasa") result.Add("Natsume Iroha");
                else if (item == "Iroha Natsume") result.Add("Natsume Iroha");
                else if (item == "God Hata Ichika") result.Add("Kamihata Ichika");
                else if (item == "Asami Sena") result.Add("Sasamoto Yurara");
                else if (item == "Masami Ichikawa") result.Add("Ichikawa Masami");
                else if (item == "Mizuno Chaoyang") result.Add("Mizuno Asahi");
                else if (item == "Sakurai Yumi3") result.Add("Sakurai Yumi");
                else if (item == "Tuzii Honoka") result.Add("Tsujii Honoka");
                else if (item == "Satou Sion") result.Add("Satou Hakune");
                else if (item == "希のぞみ") result.Add("Sasaki Nozomi");
                else if (item == "Ayano Kato") result.Add("Katou Ayano");
                else if (item == "Kuzyou Mitiru") result.Add("Kujou Michiru");
                else if (item == "弘川れいな") result.Add("Hirokawa Reina");
                else if (item == "Be Rumi Asahina (bud forest Shizuku)") result.Add("Memori Shizuku");
                else if (item == "Matumoto Itika") result.Add("Matsumoto Ichika");
                else if (item == "Kizaki Jieshika") result.Add("Kizaki Jessica");
                else if (item == "Mio Kimishima") result.Add("Kimijima Mio");                                               
                else if (item == "Rio (Yunoki Tina)") result.Add("Rio");                
                else if (item == "本田岬") result.Add("Honda Misaki");
                else if (item == "Nozomi Aso") result.Add("Aso Nozomi");
                else if (item == "usuisakiryu") result.Add("Usui Saryuu");
                else if (item == "Yuma Asami") result.Add("Asami Yuma");
                else if (item == "hakuishi***") result.Add("Shiraishi Marina");
                else if (item == "RION") result.Add("Utsunomiya Shion");
                else if (item == "Be Morisawa (Kanako Iioka)") result.Add("Iioka Kanako");
                else if (item == "Eriko Miura") result.Add("Miura Eriko");
                else if (item == "Ono Yuko") result.Add("Ono Yuuko");
                else if (item == "Honjo Yuuka") result.Add("Honjou Yuka");
                else if (item == "Kokura reason greens") result.Add("Ogura Yuna");
                else if (item == "恵さわ") result.Add("Megumi Sawa");
                else if (item == "Yamaguti Haru") result.Add("Yamaguchi Haru");
                else if (item == "Chitose Hara") result.Add("Hara Chitose");
                else if (item == "Midori Akagi") result.Add("Akagi Ao");
                else if (item == "Aizawa Haruka (Koto Kuroki sound)") result.Add("Aizawa Haruka");
                else if (item == "Shiori Abe greens") result.Add("Abe Kanna");
                else if (item == "sanjo*a") result.Add("Mikami Yua");
                else if (item == "Ito Chinami") result.Add("Itou Chinami");
                else if (item == "Hutaba Ema") result.Add("Futaba Ema");
                else if (item == "Hukada Eimi") result.Add("Fukada Eimi");
                else if (item == "眞野ほのか") result.Add("Shinno Honoka");
                else if (item == "Bi valley Akari") result.Add("Mitani Akari");
                else if (item == "Isihara Rio") result.Add("");
                else if (item == "Rin Yuna") result.Add("Hayashi Yuna");
                else if (item == "Yuna Hayashi") result.Add("Hayashi Yuna");
                else if (item == "Be Fujii Ai") result.Add("Fujii Aisa");
                else if (item == "Komatu An") result.Add("Komatsu Azu");
                else if (item == "Ryou Ayumi") result.Add("Hayashi Ryou");
                else if (item == "Miura Ayumi") result.Add("Hayashi Ryou");
                else if (item == "sankishiaihana") result.Add("Yamagishi Aika");
                else if (item == "Sankishiaihana") result.Add("Yamagishi Aika");
                else if (item == "Itika Hosimiya") result.Add("Hoshimiya Ichika");
                else if (item == "Akari Neo") result.Add("Neo Akari");
                else if (item == "Miru2") result.Add("Sakamichi Miru");
                else if (item == "Kizaki Jieshika") result.Add("Kizaki Jessica");
                else if (item == "Jieshika Kizaki") result.Add("Kizaki Jessica");
                else if (item == "Kaede Huua") result.Add("Kaede Fuua");
                else if (item == "Minami Aizawa") result.Add("Aizawa Minami");
                else if (item == "桂木凛") result.Add("Katsuragi Rin");
                else if (item == "流川夕") result.Add("Rukawa Yu");
                else if (item == "Runa2 Tukino") result.Add("Tsukino Runa");
                else if (item == "Takeuti Yuki2") result.Add("Takeuchi Yuuki");
                else if (item == "Misaki Sakura2") result.Add("Misaki Sakura");
                else if (item == "Takeuti Natuki") result.Add("Takeuchi Natsuki");
                else if (item == "Nozomi Shima Airi") result.Add("Kijima Airi");
                else if (item == "Huzimori riho") result.Add("Huzimori Riho");
                else if (item == "Isikawa mio") result.Add("Ishikawa Mio");
                else if (item == "Isikawa Mio") result.Add("Ishikawa Mio");
                else if (item == "Hosimiya Itika") result.Add("Hoshimiya Ichika");
                
                else
                {
                    converted = false;
                    result.Add(item);
                }
            }
            return result;
        }

        public static void UpdateItem(EpItem item)
        {
            if (!Directory.Exists(Path.GetDirectoryName(item.ItemPath))) return;
            List<string> passportData = EpItem.SetToPassport(item);
            File.WriteAllLines(item.ItemPath, passportData);
        }
        public static int AddedTotal = 0;
        public static List<string> BACKUP_ACTRESS_LIST;

        public static void UpdateFolder(string parameters, ref List<EpItem> list, bool isCheck, bool IsSynchPosterAllowed, string BackupCatalog, string CurrentCatalog, bool inner)
        {
            int result = 0;
            string itemPath = parameters.ToUpper();
            if (CurrentCatalog == "JAV")
            {
                if (!JAV.FoldersToUpdate.Contains("ALL") && !JAV.FoldersToUpdate.Contains("All"))
                {
                    if (isCheck && !inner)
                    {
                        string dirname = Path.GetFileName(itemPath);

                        if (JAV.FoldersToUpdate.Exists(x => itemPath.Contains(x)))
                        {
                            if (JAV.FoldersToUpdate.Exists(x => dirname == x))
                            {
                                inner = true;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                } }
            isCheck = true;


            if (!Directory.Exists(itemPath)) return;
            //Console.WriteLine($"Update folder {itemPath}..");
            List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportName).ToList();
            foreach (var passport in passportList)
            {
                AddedTotal = AddedTotal + CatalogLoader.CreateUpdateFromPassport(passport, ref list, IsSynchPosterAllowed, CurrentCatalog, BackupCatalog);
            }
            //result = added;
            //if (added > 0)
            //    Console.WriteLine($"Added {added} !");
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                UpdateFolder(dir, ref list, isCheck, IsSynchPosterAllowed, BackupCatalog, CurrentCatalog, inner);
            }
        }
        public static List<EpItem> LoadCatalog(string parameters)
        {
            List<EpItem> list = new List<EpItem>();
            string itemPath = parameters.ToLower();
            string dir = EpItem.GetCatalogPosterDir(itemPath);
            EpItem.CatalogPosterDir = dir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(itemPath))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<EpItem>));
                try
                {
                    using (var sr = new StreamReader(itemPath))
                    {
                        list = serializer.Deserialize(sr) as List<EpItem>;
                    }
                }
                catch { }
            }
            return list;
        }
    }
}
