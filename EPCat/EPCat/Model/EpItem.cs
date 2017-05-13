using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EPCat.Model
{
    [Serializable]
    public class EpItem
    {
        public Guid GID { get; set; }
        public string ItemPath { get; set; }
        public readonly int _itemType;//0-Folder
        public int ItemType { get { return _itemType; } }
        public int ParentID { get; set; }
        public string PosterPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(ItemPath), "POSTER.JPG");
            }
        }
        public ImageSource Poster
        {
            get
            {
                return new BitmapImage(new Uri(PosterPath, UriKind.Absolute));
            }
        }
       

        public string Name { get; set; }
        public string AltTitle { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Star { get; set; }
        public string MyDescr { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string IMDB { get; set; }
        public List<string> Comments { get; set; } = new List<string>();

        public List<string> Undefined { get; set; } = new List<string>();

        public EpItem(int itemType):this()
        {       
            _itemType = itemType;
        }
        private EpItem()
        {
            this.GID = Guid.NewGuid();
        }
        public static List<EpItem> GetFolders()
            {
                List<EpItem> result = new List<EpItem>();        
                return result;
            }

        internal void UpdateFrom(EpItem item)
        {
            this.ItemPath = item.ItemPath;
            this.Name = item.Name;
            this.Country = item.Country;
            this.Year = item.Year;
            this.AltTitle = item.AltTitle;
            this.Rated = item.Rated;
            this.Star = item.Star;
            this.MyDescr = item.MyDescr;
            this.Director = item.Director;
            this.Studio = item.Studio;
            this.IMDB = item.IMDB;

            this.Comments.Clear();
            this.Comments.AddRange(item.Comments);

            this.Undefined.Clear();
            this.Undefined.AddRange(item.Undefined);
        }

        static string p_GID = "GID:";
        static string p_Name = "NAME:";
        static string p_AltTitle = "ALTTITLE:";
        static string p_Country = "COUNTRY:";
        static string p_Year = "YEAR:";
        static string p_Rated = "RATED:";
        static string p_Star = "STAR:";
        static string p_MyDescr = "MYCOMMENTS:";
        static string p_Director = "Director:";
        static string p_Studio = "Studio:";
        static string p_IMDB = "IMDB:";
        static string p_COMMENTS_BEGIN = "COMMENTS:<";
        static string p_COMMENTS_END = ">";
        public static string p_PassportName = "PASSPORT.TXT";

        internal static EpItem GetFromPassport(List<string> passport)
        {
            EpItem result = new EpItem(1);
            bool isComments = false;
            foreach (var line in passport)
            {
                string term = line.Trim();
                if (isComments)
                {
                    if (term.Contains(p_COMMENTS_END))
                    {
                        term = term.Replace(p_COMMENTS_END, string.Empty);
                        isComments = false;
                    }
                    result.Comments.Add(term);
                }
                else if (term.StartsWith(p_COMMENTS_BEGIN))
                {
                    term = term.Replace(p_COMMENTS_BEGIN, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Comments.Add(term);
                    }
                    isComments = true;
                }
                else if (term.StartsWith(p_GID))
                {
                    term = term.Replace(p_GID, string.Empty);
                    Guid temp;
                    if (Guid.TryParse(term.Trim(), out temp))
                    {
                        result.GID = temp;
                    }
                }
                else if (term.StartsWith(p_Name))
                {
                    term = term.Replace(p_Name, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Name = term;
                    }
                }
                else if (term.StartsWith(p_AltTitle))
                {
                    term = term.Replace(p_AltTitle, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.AltTitle = term;
                    }
                }
                else if (term.StartsWith(p_Country))
                {
                    term = term.Replace(p_Country, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Country = term;
                    }
                }
                else if (term.StartsWith(p_Year))
                {
                    term = term.Replace(p_Year, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (term.Length > 4) term = term.Substring(0, 4);
                        result.Year = Convert.ToInt32(term  );
                    }
                }
                else if (term.StartsWith(p_Rated))
                {
                    term = term.Replace(p_Rated, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Rated = term;
                    }
                }
                else if (term.StartsWith(p_Star))
                {
                    term = term.Replace(p_Star, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Star = term;
                    }
                }
                else if (term.StartsWith(p_MyDescr))
                {
                    term = term.Replace(p_MyDescr, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.MyDescr = term;
                    }
                }
                else if (term.StartsWith(p_Director))
                {
                    term = term.Replace(p_Director, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Director = term;
                    }
                }
                else if (term.StartsWith(p_Studio))
                {
                    term = term.Replace(p_Studio, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Studio = term;
                    }
                }
                else if (term.StartsWith(p_IMDB))
                {
                    term = term.Replace(p_IMDB, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.IMDB = term;
                    }
                }
                else if (!string.IsNullOrEmpty(term))
                {
                    result.Undefined.Add(term);
                }
            }            
            return result;
        }
        internal static List<string> SetToPassport(EpItem item)
        {
            List<string> result = new List<string>();
            result.Add(p_GID + item.GID.ToString());
            result.Add(p_Name + item.Name);
            result.Add(p_AltTitle + item.AltTitle);
            result.Add(p_Country + item.Country);
            result.Add(p_Year + (item.Year>0? item.Year.ToString():string.Empty));
            result.Add(p_Rated + item.Rated);
            result.Add(p_Star + item.Star);
            result.Add(p_MyDescr + item.MyDescr);
            result.Add(p_Director + item.Director);
            result.Add(p_Studio + item.Studio);
            result.Add(p_IMDB + item.IMDB);
            for (int i = 0; i < item.Comments.Count; i++)
            {
                if (item.Comments.Count == 1) result.Add(p_COMMENTS_BEGIN + item.Comments[i] + p_COMMENTS_END);
                else if (i == 0) result.Add(p_COMMENTS_BEGIN + item.Comments[i]);
                else if (i == (item.Comments.Count - 1)) result.Add(item.Comments[i]+p_COMMENTS_END);
                else result.Add(item.Comments[i]);
            }
            
            foreach (var s in item.Undefined)
            {
                result.Add(s);
            }
            return result;
        }
    }
}
