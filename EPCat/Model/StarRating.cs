using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public static class StarRating
    {
        private static List<string> javStarR1;
        private static List<string> javStarR2;
        private static List<string> javStarR3;
        private static List<string> javStarR4;
        private static List<string> javStarR5;
        private static List<string> javStarR6;
        private static List<string> javStarR7;
        private static List<string> javStarR8;
        private static List<string> JavStarR1 { get { if (javStarR1 == null) { javStarR1 = (ConfigurationManager.AppSettings["javStarRating1"]).Split(',').ToList(); } return javStarR1; } }
        private static List<string> JavStarR2 { get { if (javStarR2 == null) { javStarR2 = (ConfigurationManager.AppSettings["javStarRating2"]).Split(',').ToList(); } return javStarR2; } }
        private static List<string> JavStarR3 { get { if (javStarR3 == null) { javStarR3 = (ConfigurationManager.AppSettings["javStarRating3"]).Split(',').ToList(); } return javStarR3; } }
        private static List<string> JavStarR4 { get { if (javStarR4 == null) { javStarR4 = (ConfigurationManager.AppSettings["javStarRating4"]).Split(',').ToList(); } return javStarR4; } }
        private static List<string> JavStarR5 { get { if (javStarR5 == null) { javStarR5 = (ConfigurationManager.AppSettings["javStarRating5"]).Split(',').ToList(); } return javStarR5; } }
        private static List<string> JavStarR6 { get { if (javStarR6 == null) { javStarR6 = (ConfigurationManager.AppSettings["javStarRating6"]).Split(',').ToList(); } return javStarR6; } }
        private static List<string> JavStarR7 { get { if (javStarR7 == null) { javStarR7 = (ConfigurationManager.AppSettings["javStarRating7"]).Split(',').ToList(); } return javStarR7; } }
        private static List<string> JavStarR8 { get { if (javStarR8 == null) { javStarR8 = (ConfigurationManager.AppSettings["javStarRating8"]).Split(',').ToList(); } return javStarR8; } }
        private static bool SetRating(List<string> list, string rating, ref EpItem item)
        {
            if (!string.IsNullOrEmpty(item.Star))
            {
                foreach (var name in list)
                {
                    if (!string.IsNullOrEmpty(name) && item.Star.Contains(name))
                    {
                        item.PersonKind = rating;
                        item.Edited = true;
                        return true;
                    }
                }
            }
            return false;
        }
        public static void SetRating(ref EpItem item)
        {
            
            // JAV person rating
            if (item.Catalog == "JAV")
            {
                if (!string.IsNullOrEmpty(item.Star))
                {
                    //item.Star.Replace();

                    if (!SetRating(JavStarR8, "8", ref item))
                    {
                        if (!SetRating(JavStarR7, "7", ref item))
                        {
                            if (!SetRating(JavStarR6, "6", ref item))
                            {
                                if (!SetRating(JavStarR5, "5", ref item))
                                {
                                    if (!SetRating(JavStarR4, "4", ref item))
                                    {
                                        if (!SetRating(JavStarR3, "3", ref item))
                                        {
                                            if (!SetRating(JavStarR2, "2", ref item))
                                            {
                                                SetRating(JavStarR1, "1", ref item);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static string GetRating(string actress)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(actress))
            {
                if (JavStarR8.Contains(actress))
                    return "8";
                if (JavStarR7.Contains(actress))
                    return "7";
                if (JavStarR6.Contains(actress))
                    return "6";
                if (JavStarR5.Contains(actress))
                    return "5";
                if (JavStarR4.Contains(actress))
                    return "4";
                if (JavStarR3.Contains(actress))
                    return "3";
                if (JavStarR2.Contains(actress))
                    return "2";
                if (JavStarR1.Contains(actress))
                    return "1";
            }
            return result;
        }
    }
}
