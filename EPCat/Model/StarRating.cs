using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public static class StarRating
    {
        public static Dictionary<string, int> Ratings = new Dictionary<string, int>();
        public static void SetRating(EpItem item)
        {

            // JAV person rating
            if (item.Catalog == "JAV")
            {
                if (!string.IsNullOrEmpty(item.Star))
                {
                    var vals = item.Star.Split(',');
                    int ratingMax = 0;
                    foreach (var it in vals)
                    {
                        int rat;
                        if (Ratings.TryGetValue(it, out rat))
                        {
                            if (rat> ratingMax)
                            {
                                ratingMax = rat;
                            }
                        }
                    }
                    if (ratingMax > 0 && item.PersonKind != ratingMax.ToString())
                    {
                        item.PersonKind = ratingMax.ToString();
                        item.Edited = true;
                    }

                }
            }
        }
        public static string GetRating(string actress)
        {
            string result = string.Empty;
            if (Ratings.ContainsKey(actress))
            {
                result = Ratings[actress].ToString();
            }
            return result;
        }
        public static void SaveJAVActress()
        {
            List<string> lines = new List<string>();
            lines.Add($"// 1 - Ничего нет вообще определенно");
            lines.Add($"// 2 - Ничего нет");
            lines.Add($"// 3 - Иногда можно");
            lines.Add($"// 4 - Ниче так");
            lines.Add($"// 5 - Красотка");
            lines.Add($"// 6 - Красотка определенно");
            lines.Add($"// 7 - Супер");
            lines.Add($"// 8 - Супер, любимая");
            foreach (var item in Ratings)
            {
                lines.Add($"{item.Key}|{item.Value}");
            }
            string file = Path.Combine(Loader.FoldersToUpdate.Last(), "Actress.txt");
            File.WriteAllLines(file, lines);
        }
        public static void LoadJAVActress()
        {
            Ratings.Clear();
            string file = Path.Combine(Loader.FoldersToUpdate.Last(), "Actress.txt");
            var lines = File.ReadAllLines(file);
            foreach (string item in lines)
            {
                if (!item.StartsWith("//"))
                {
                    var vals = item.Split('|');
                    string acname = vals[0];
                    int rate = int.Parse(vals[1]);
                    if (!Ratings.ContainsKey(acname))
                    {
                        Ratings.Add(acname, rate);
                    }
                }
            }
        }
    }
}
