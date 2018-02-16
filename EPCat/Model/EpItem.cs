using DevExpress.Mvvm;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace EPCat.Model
{

    public class DictionaryData
    {
        public Dictionary<int, string> Dict_Name { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, List<ClassItem>> Dict_Class { get; set; } = new Dictionary<int, List<ClassItem>>();
    }

    

    [Serializable]
    public class EpItem
    {


        public Guid GID { get; set; }
        public bool GroupsEnabled { get { return true; } }

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
                // try to get from source dir
                Uri path = new Uri(PosterPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);
                GetLeastNumImage(Path.GetDirectoryName(ItemPath), PosterPath);
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);
                GetLeastNumImage(Path.GetDirectoryName(ItemPath) + @"\EVENTS\", PosterPath);
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);


                // try to get from catalog poster dir
                string dirPoster = EpItem.CatalogPosterDir;
                dirPoster = Path.Combine(dirPoster, $"{GID}.jpg");
                path = new Uri(dirPoster, UriKind.Absolute);
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);

                return null;
            }
        }
        private bool GetLeastNumImage(string ItemPath, string PosterPath)
        {
            bool ok = false;
            if (!Directory.Exists(ItemPath)) return ok;
            List<string> files = Directory.GetFiles(ItemPath, "*.jpg").ToList();
            if (files.Any())
            {
                var filenames = files.Where(x => !x.ToUpper().StartsWith("CAP") && !x.ToUpper().StartsWith("SCREEN")).ToList();
                string fn = filenames.Where(x =>
                {
                   string fnn = Path.GetFileNameWithoutExtension(x);
                   int rez;
                   if (Int32.TryParse(fnn, out rez))
                   {
                      return true;
                   }
                   return false;
                }).OrderBy(z=>Convert.ToInt32(Path.GetFileNameWithoutExtension(z))).FirstOrDefault();
                if (string.IsNullOrEmpty(fn))
                {
                    fn = filenames.FirstOrDefault();
                }
                if (!string.IsNullOrEmpty(fn))
                {
                    File.Copy(fn, PosterPath);
                    //if (File.Exists(path.LocalPath)) return new BitmapImage(path);
                    ok = true;
                }
            }
            return ok;
        }
        public string ItemDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(ItemPath)) return string.Empty;
                return Path.GetDirectoryName(ItemPath);
            }
        }
        public List<string> Videos
        {
            get
            {
                if (string.IsNullOrEmpty(ItemDirectory)) return new List<string>();
                if (!Directory.Exists(ItemDirectory)) return new List<string>();
                return Directory.GetFiles(ItemDirectory, "*.m4v").ToList();
            }
        }

        List<CapsItem> _Caps = null;
        [XmlIgnore]
        public List<CapsItem> Caps
        {
            get
            {
                if (_Caps == null || CurrentPassport != CurrentPassportImage)
                {
                    RefreshImageLists();
                    CurrentPassport = CurrentPassportImage;
                }
                return _Caps;
            }
        }
        private string CurrentPassport;
        public void RefreshImageLists()
        {
            CapsPassportData.Clear();
            string foldername = Path.GetFileNameWithoutExtension(CurrentPassportImage).Split('_')[1];
            string capspath = Path.Combine(ItemDirectory, foldername);
            string ImagePassportPath = Path.Combine(ItemDirectory, CurrentPassportImage);
            _Caps = new List<CapsItem>();
            List<CapsItem> itemList = new List<CapsItem>();
            if (!CapsPassportData.Any() && File.Exists(ImagePassportPath))
            {
                List<string> passport = new List<string>(File.ReadAllLines(ImagePassportPath));
                if (passport != null)
                {
                    itemList = CapsItem.GetListFromPassport(passport);
                }
            }
            itemList.ForEach(x => { x.Parent = itemList.Where(p => p.Id == x.ParentId).FirstOrDefault(); x.Owner = _Caps; });

            if (Directory.Exists(capspath))
            {
                List<string> files = Directory.GetFiles(capspath, "*.jpg").ToList();
                files.AddRange(Directory.GetFiles(capspath, "*.png"));

                int pos = 0;
                List<string> newfiles = new List<string>();
                foreach (var f in files)
                {
                    pos++;
                    string fn = CapsItem.ConvertRenameFilename(f, pos);
                    newfiles.Add(fn);
                }

                foreach (var f in newfiles)
                {

                    string fn = Path.GetFileName(f);
                    CapsItem existItem = itemList.Where(x => x.Id == fn).FirstOrDefault();
                    if (existItem != null)
                    {
                        existItem.ItemPath = f;
                        _Caps.Add(existItem);
                    }
                    else
                    {
                        CapsItem newitem = new CapsItem() { ItemPath = f, Id = fn, Owner = _Caps };
                        _Caps.Add(newitem);
                    }
                }

            }
        }


        public void SaveImagePassport()
        {
            if (_Caps != null)
            {
                List<string> lines = new List<string>();
                foreach (var cap in _Caps)
                {
                    string s = CapsItem.SetToPassport(cap);
                    if (!string.IsNullOrEmpty(s)) lines.Add(s);
                }
                if (lines.Any())
                    File.WriteAllLines(Path.Combine(this.ItemDirectory, CurrentPassportImage), lines);
            }
        }
        public List<CapsItem> CapsPassportData = new List<CapsItem>();


        public bool VideoPresent
        {
            get
            {
                return Videos.Any();
            }
        }
        public string Name { get; set; }
        public string Catalog { get; set; } = "MOV";
        public int LastEdit { get; set; }
        public string AltTitle { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Rated { get; set; }
        public string XRated { get; set; }
        public string Kind { get; set; }
        public string Serie { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Star { get; set; }
        public string MyDescr { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string IMDB { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public string CommentsAsString
        {
            get
            {
                return string.Join(Environment.NewLine, this.Comments.ToArray());
            }
            set
            {
                this.Comments = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            }
        }

        public List<string> Undefined { get; set; } = new List<string>();

        private ObservableCollection<MovieSceneInfo> _Clips = null;
        [XmlIgnore]
        public ObservableCollection<MovieSceneInfo> Clips
        {            
            get
            {
                if (_Clips == null)
                {
                    _Clips = new ObservableCollection<MovieSceneInfo>();
                    foreach (var item in this.ScenData)
                    {
                        MovieSceneInfo sd = new MovieSceneInfo();
                        sd.LoadFromString(item);
                        _Clips.Add(sd);
                    }
                }
                return _Clips;
            }
        }

        public void UpdateScenDataFromClipInfoList()
        {
            this.ScenData.Clear();
            foreach (var item in Clips)
            {
                this.ScenData.Add(item.GenerateString());
            } 
        }

        List<string> _ScenData = new List<string>();
        public List<string> ScenData
        {
            get
            {
                return _ScenData;
            }
            set
            {
                _ScenData = value;
            }
        }


        [XmlIgnore]
        public string ScenDataAsString
        {
            get
            {
                return string.Join(Environment.NewLine, this.ScenData.ToArray());
            }
            set
            {
                this.ScenData = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            }
        }

        [XmlIgnore]
        public bool SourceFolderExist { get; set; } = false;

        public EpItem(int itemType) : this()
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
            this.Serie = item.Serie;
            this.Catalog = item.Catalog;
            this.LastEdit = item.LastEdit;
            this.Country = item.Country;
            this.Year = item.Year;
            this.Month = item.Month;
            this.Day = item.Day;
            this.AltTitle = item.AltTitle;
            this.Rated = item.Rated;
            this.XRated = item.XRated;
            this.Kind = item.Kind;
            this.Type = item.Type;
            this.Brand = item.Brand;
            this.Star = item.Star;
            this.MyDescr = item.MyDescr;
            this.Director = item.Director;
            this.Studio = item.Studio;
            this.IMDB = item.IMDB;
            this.SourceFolderExist = item.SourceFolderExist;

            this.Comments.Clear();
            this.Comments.AddRange(item.Comments);

            this.ScenData.Clear();
            this.ScenData.AddRange(item.ScenData);

            this.Undefined.Clear();
            this.Undefined.AddRange(item.Undefined);
        }

        static string p_GID = "GID:";
        static string p_Name = "NAME:";
        static string p_Catalog = "CATALOG:";
        static string p_Serie = "SERIE:";
        static string p_LastEdit = "LASTEDIT:";
        static string p_AltTitle = "ALTTITLE:";
        static string p_Country = "COUNTRY:";
        static string p_Year = "YEAR:";
        static string p_Month = "MONTH:";
        static string p_Day = "Day:";
        static string p_Rated = "RATED:";
        static string p_XRated = "XRATED:";
        static string p_Kind = "KIND:";
        static string p_Type = "TYPE:";
        static string p_Brand = "BRAND:";
        static string p_Star = "STAR:";
        static string p_MyDescr = "MYCOMMENTS:";
        static string p_Director = "Director:";
        static string p_Studio = "Studio:";
        static string p_IMDB = "IMDB:";
        static string p_Type00 = "TYPE00:";
        static string p_Type01 = "TYPE01:";
        static string p_Type02 = "TYPE02:";
        static string p_Type03 = "TYPE03:";
        static string p_Type04 = "TYPE04:";
        static string p_Type05 = "TYPE05:";
        static string p_Type06 = "TYPE06:";
        static string p_Type07 = "TYPE07:";
        static string p_Type08 = "TYPE08:";
        static string p_Type09 = "TYPE09:";

        static string p_COMMENTS_BEGIN = "COMMENTS:<";
        static string p_COMMENTS_END = ">";
        static string p_SCENDATA_BEGIN = "<SCENDATA";
        static string p_SCENDATA_END = "SCENDATA>";
        public static string p_PassportName = "PASSPORT.TXT";
        public static string p_PassportCapsName = "PASSPORT_CAPS.TXT";
        public static string p_PassportEventsName = "PASSPORT_EVENTS.TXT";
        public static string p_PassportFiguresName = "PASSPORT_FIGURES.TXT";
        public static string p_PassportPartsName = "PASSPORT_PARTS.TXT";
        public static string p_PassportBackgroundName = "PASSPORT_BACKGROUND.TXT";
        public static string p_PassportCompositionName = "PASSPORT_COMPOSITION.TXT";

        public static string CurrentPassportImage = p_PassportCapsName;
        internal static string CatalogPosterDir;

        internal static void SetCurrentImagePassort(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    CurrentPassportImage = p_PassportCapsName;
                    break;
                case 1:
                    CurrentPassportImage = p_PassportEventsName;
                    break;
                case 2:
                    CurrentPassportImage = p_PassportFiguresName;
                    break;
                case 3:
                    CurrentPassportImage = p_PassportPartsName;
                    break;
                case 4:
                    CurrentPassportImage = p_PassportBackgroundName;
                    break;
                case 5:
                    CurrentPassportImage = p_PassportCompositionName;
                    break;
                default:
                    CurrentPassportImage = p_PassportCapsName;
                    break;
            }
        }


        internal static EpItem GetFromPassport(List<string> passport)
        {
            EpItem result = new EpItem(1);
            bool isComments = false;
            bool isScenData = false;
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
                if (isScenData)
                {
                    if (term.Contains(p_SCENDATA_END))
                    {
                        term = term.Replace(p_SCENDATA_END, string.Empty);
                        isScenData = false;
                    }
                    result.ScenData.Add(term);
                }
                else if (term.StartsWith(p_SCENDATA_BEGIN))
                {
                    term = term.Replace(p_SCENDATA_BEGIN, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.ScenData.Add(term);
                    }
                    isScenData = true;
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
                else if (term.StartsWith(p_Catalog))
                {
                    term = term.Replace(p_Catalog, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Catalog = term;
                    }
                }
                else if (term.StartsWith(p_Serie))
                {
                    term = term.Replace(p_Serie, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Serie = term;
                    }
                }
                else if (term.StartsWith(p_LastEdit))
                {
                    term = term.Replace(p_LastEdit, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.LastEdit = Convert.ToInt32(term);
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
                        result.Year = Convert.ToInt32(term);
                    }
                }
                else if (term.StartsWith(p_Month))
                {
                    term = term.Replace(p_Month, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (term.Length > 2) term = term.Substring(0, 2);
                        result.Month = Convert.ToInt32(term);
                    }
                }
                else if (term.StartsWith(p_Day))
                {
                    term = term.Replace(p_Day, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (term.Length > 2) term = term.Substring(0, 2);
                        result.Day = Convert.ToInt32(term);
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
                else if (term.StartsWith(p_XRated))
                {
                    term = term.Replace(p_XRated, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.XRated = term;
                    }
                }
                else if (term.StartsWith(p_Kind))
                {
                    term = term.Replace(p_Kind, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Kind = term;
                    }
                }
                else if (term.StartsWith(p_Type))
                {
                    term = term.Replace(p_Type, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Type = term;
                    }
                }
                else if (term.StartsWith(p_Brand))
                {
                    term = term.Replace(p_Brand, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Brand = term;
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

        internal static string GetCatalogPosterDir(string itemPath)
        {
            string dir = Path.GetDirectoryName(itemPath);
            string catname = Path.GetFileNameWithoutExtension(itemPath);
            return $@"{dir}\POSTERS.{catname}";
        }

        internal static List<string> SetToPassport(EpItem item)
        {
            List<string> result = new List<string>();
            result.Add(p_GID + item.GID.ToString());
            result.Add(p_Name + item.Name);
            result.Add(p_Catalog + item.Catalog);
            result.Add(p_Serie + item.Serie);
            result.Add($"{p_LastEdit}{item.LastEdit}");
            result.Add(p_AltTitle + item.AltTitle);
            result.Add(p_Country + item.Country);
            result.Add(p_Year + (item.Year > 0 ? item.Year.ToString() : string.Empty));
            result.Add(p_Month + (item.Month > 0 ? item.Month.ToString() : string.Empty));
            result.Add(p_Day + (item.Day > 0 ? item.Day.ToString() : string.Empty));
            result.Add(p_Rated + item.Rated);
            result.Add(p_XRated + item.XRated);
            result.Add(p_Kind + item.Kind);
            result.Add(p_Type + item.Type);
            result.Add(p_Brand + item.Brand);
            result.Add(p_Star + item.Star);
            result.Add(p_MyDescr + item.MyDescr);
            result.Add(p_Director + item.Director);
            result.Add(p_Studio + item.Studio);
            result.Add(p_IMDB + item.IMDB);

            if (item.Comments.Count == 1)
            {
                result.Add(p_COMMENTS_BEGIN + item.Comments.First() + p_COMMENTS_END);
            }
            else if (item.Comments.Count > 0)
            {
                List<string> ttt = new List<string>();
                ttt.AddRange(item.Comments);
                ttt[0] = p_COMMENTS_BEGIN + item.Comments.First();
                ttt[ttt.Count-1] = item.Comments.Last() + p_COMMENTS_END;
                result.AddRange(ttt);               
            }

            if (item.ScenData.Count == 1)
            {
                result.Add(p_SCENDATA_BEGIN + item.ScenData.First() + p_SCENDATA_END);
            }
            else if (item.ScenData.Count > 0)
            {
                List<string> ttt = new List<string>();
                ttt.AddRange(item.ScenData);
                ttt[0] = p_SCENDATA_BEGIN + item.ScenData.First();
                ttt[ttt.Count - 1] = item.ScenData.Last() + p_SCENDATA_END;
                result.AddRange(ttt);
            }


            foreach (var s in item.Undefined)
            {
                result.Add(s);
            }
            return result;
        }

    }



    public class CapsItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        [XmlIgnore]
        public static DictionaryData DictionaryData = new DictionaryData();


        [XmlIgnore]
        public DictionaryData DicData { get { return CapsItem.DictionaryData; } }

        //public static string p_FN = "FN=";
        public static string p_Parent = "Parent=";
        public static string p_Id = "Id=";

        public static string p_Name = "Name=";
        public static string p_Star = "Star=";
        public static string p_Descr = "Descr=";

        public static string p_DV = "DV_";

        public string ItemPath { set; get; }
        public string GroupName { set; get; }
        public string Id { set; get; }

        public string ShortId
        {
            get
            {
                return Id.Substring(0, 4);
            }
        }
        public bool GroupsEnabled { get { return string.IsNullOrEmpty(this.ParentId); } }
        // public string FileName { set; get; }

        private string _ParentId;
        internal List<CapsItem> Owner;
        public string ParentId
        {
            set
            {
                _ParentId = value;
                OnPropertyChanged("ParentId");
            }
            get { return _ParentId; }
        }
        public ImageSource Thumb
        {
            set { }
            get
            {
                if (string.IsNullOrEmpty(ItemPath)) return null;
                Uri path = new Uri(ItemPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath))
                {

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = path;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.DecodePixelHeight = 150;
                    bitmap.EndInit();
                    return bitmap;

                }
                return null;
            }
        }
        public ImageSource Picture
        {
            set { }
            get
            {
                Uri path = new Uri(ItemPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath))
                {

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = path;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    return bitmap;
                }

                return null;
            }
        }
        private string _Description;
        public string Description
        {
            set
            {
                if ((Parent == null))
                {
                    _Description = value;
                }
                OnPropertyChanged("Description");
            }
            get
            {
                if (Parent != null) return Parent.Description;
                return _Description;
            }
        }
        private string _Name;
        public string Name
        {
            set
            {
                if ((Parent == null))
                {
                    _Name = value;
                }
                OnPropertyChanged("Name");
            }
            get
            {
                if (Parent != null) return Parent.Name;
                return _Name;
            }
        }
        private string _Star;
        public string Star
        {
            set
            {
                if ((Parent == null))
                {
                    _Star = value;
                }
                OnPropertyChanged("Star");
            }
            get
            {
                if (Parent != null) return Parent.Star;
                return _Star;
            }
        }


        Dictionary<int, int> _DicOneVal = new Dictionary<int, int>();
        [XmlIgnore]
        public Dictionary<int, int> DicOneVal
        {
            get
            {
                if (Parent != null) return Parent.DicOneVal;
                return _DicOneVal;
            }
        }


        Dictionary<int, List<object>> _DicMulVal = new Dictionary<int, List<object>>();
        [XmlIgnore]
        public Dictionary<int, List<object>> DicMulVal
        {
            get
            {
                if (Parent != null) return Parent.DicMulVal;
                return _DicMulVal;
            }
        }

        CapsItem _Parent;

        [XmlIgnore]
        public List<CapsItem> ChildList { set; get; } = new List<CapsItem>();


        public int ChildCount { set; get; } = 0;
        public string ShortIdChildCount
        {
            get { return $"{ShortId} / {ChildCount}"; }
        }
        public CapsItem Parent
        {
            set
            {
                _Parent = value;
                /*
                if (_Parent == null)
                {
                    if (!string.IsNullOrEmpty(this._ParentId))
                    {
                        this._ParentId = null;
                    }
                }                    
                else if (this._ParentId != value.ParentId)
                {
                    this._ParentId = value.ParentId;
                    if (!value.ChildList.Contains(this)) value.ChildList.Add(this);
                }
                */
            }
            get { return _Parent; }
        }

        public string PassportPath { get; set; }

        internal static string SetToPassport(CapsItem item)
        {
            if (!item.IsNotEmpty()) return null;
            List<string> result = new List<string>();
            result.Add(p_Id + item.Id);

            if (!string.IsNullOrEmpty(item.ParentId)) result.Add(p_Parent + item.ParentId);

            if (!string.IsNullOrEmpty(item._Name)) result.Add(p_Name + item._Name);
            if (!string.IsNullOrEmpty(item._Description)) result.Add(p_Descr + item._Description);
            if (!string.IsNullOrEmpty(item._Star)) result.Add(p_Star + item._Star);

            if (string.IsNullOrEmpty(item.ParentId))
            {
                foreach (var it in item.DicOneVal)
                {
                    result.Add(p_DV + it.Key.ToString() + "=" + it.Value);
                }

                foreach (var it in item.DicMulVal)
                {
                    if (it.Value != null)
                    {
                        var dd = it.Value.Where(x => x != null).Select(x => (int)x);
                        result.Add(p_DV + it.Key.ToString() + "=" + string.Join("|", dd));
                    }
                }
            }

            return string.Join(";", result.ToArray());
        }

        private bool IsNotEmpty()
        {
            return (
                (!string.IsNullOrEmpty(this.ParentId))
                || !string.IsNullOrEmpty(this.Description)
                || !string.IsNullOrEmpty(this.Name)
                || !string.IsNullOrEmpty(this.Star)
                );
        }

        internal static CapsItem GetFromPassport(string passport)
        {
            CapsItem result = new CapsItem();
            List<string> vals = passport.Split(';').ToList();
            foreach (var val in vals)
            {
                string[] terms = val.Split('=');

                string mark = terms[0] + "=";
                if (mark == p_Id)
                {
                    result.Id = terms[1];
                }
                else if (mark == p_Parent)
                {
                    result.ParentId = terms[1];
                }
                else if (mark == p_Name)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Name = terms[1];
                    }
                }
                else if (mark == p_Descr)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Description = terms[1];
                    }
                }
                else if (mark == p_Star)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Star = terms[1];
                    }
                }
                else if (terms[0].StartsWith(p_DV))
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        var s = mark.Replace(p_DV, string.Empty).Replace("=", string.Empty);
                        int si = Convert.ToInt32(s);
                        List<string> dd = terms[1].Split('|').ToList();
                        if (si < 5 || (si > 9 && si < 50))
                        {
                            result.DicOneVal[si] = Convert.ToInt32(dd[0]);
                        }
                        else
                        {
                            foreach (var item in dd)
                            {
                                if (!result.DicMulVal.ContainsKey(si)) result.DicMulVal.Add(si, new List<object>());
                                result.DicMulVal[si].Add(Convert.ToInt32(item));
                            }
                        }
                    }
                }
            }
            return result;
        }
        internal static List<CapsItem> GetListFromPassport(List<string> passport)
        {
            List<CapsItem> result = new List<CapsItem>();
            foreach (var line in passport)
            {
                string term = line.Trim();
                CapsItem item = GetFromPassport(term);
                if (item != null) result.Add(item);
            }
            return result;
        }

        internal static string ConvertRenameFilename(string f, int pos)
        {
            //"0001.AD33A40B681D4A70846CE20EC7F16EEE"
            string fn = Path.GetFileNameWithoutExtension(f);
            if (fn.Length != 37 || fn.Substring(4, 1) != ".")
            {
                string path = Path.GetDirectoryName(f);
                string newf = Path.Combine(path, $"{pos.ToString("D4")}.{Guid.NewGuid().ToString("N")}{Path.GetExtension(f)}");
                File.Move(f, newf);
                f = newf;
            }
            return f;
        }
    }

    public class ClassItem
    {
        public string Description { set; get; }
        public int Val { set; get; }
    }


}
