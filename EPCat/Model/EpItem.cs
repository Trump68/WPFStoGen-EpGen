﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        [XmlIgnore]
        public static DictionaryData DictionaryData = new DictionaryData();


        [XmlIgnore]
        public DictionaryData DicData { get { return EpItem.DictionaryData; } }

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
                Uri path = new Uri(PosterPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);
                return null;
            }
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
                return Directory.GetFiles(ItemDirectory, "*.m4v").ToList();
            }
        }

        List<CapsItem> _Caps = null;
        [XmlIgnore]
        public List<CapsItem> Caps
        {
            get
            {
                if (_Caps == null || CurrentPassport!= CurrentPassportImage)
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
                string[] files = Directory.GetFiles(capspath, "*.jpg");
                foreach (var f in files)
                {
                    string fn = Path.GetFileName(f);
                    CapsItem existItem = itemList.Where(x => x.FileName == fn).FirstOrDefault();
                    if (existItem != null)
                    {
                        existItem.ItemPath = f;
                        _Caps.Add(existItem);
                    }
                    else
                    {
                        CapsItem newitem = new CapsItem() { ItemPath = f, FileName = fn, Owner = _Caps };
                        if (_Caps.Any())
                            newitem.Id = _Caps.Max(x => x.Id) + 1;
                        else
                            newitem.Id = 1;
                        _Caps.Add(newitem);
                    }
                }
                 
            }            
        }


        public void SaveImagePassport()
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

        public List<CapsItem> CapsPassportData = new List<CapsItem>();


        public bool VideoPresent
        {
            get
            {
                return Videos.Any();
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
        [XmlIgnore]
        public Dictionary<int, int> DicOneVal { get; set; } = new Dictionary<int, int>();
        [XmlIgnore]
        public Dictionary<int, List<object>> DicMulVal { get; set; } = new Dictionary<int, List<object>>();




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


            foreach (var v in item.DicOneVal)
            {
                this.DicOneVal.Add(v.Key, v.Value);
            }

            foreach (var v in item.DicMulVal)
            {
                this.DicMulVal.Add(v.Key, v.Value);
            }


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
        public static string p_PassportName = "PASSPORT.TXT";
        public static string p_PassportCapsName = "PASSPORT_CAPS.TXT";
        public static string p_PassportEventsName = "PASSPORT_EVENTS.TXT";
        public static string p_PassportFiguresName = "PASSPORT_FIGURES.TXT";
        public static string p_PassportPartsName = "PASSPORT_PARTS.TXT";
        public static string p_PassportBackgroundName = "PASSPORT_BACKGROUND.TXT";
        public static string p_PassportCompositionName = "PASSPORT_COMPOSITION.TXT";

        public static string CurrentPassportImage = p_PassportCapsName;
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
                else if (term.StartsWith(p_Type00))
                {
                    term = term.Replace(p_Type00, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.DicOneVal.Add(0, Convert.ToInt32(term));
                    }
                }
                else if (term.StartsWith(p_Type01))
                {
                    term = term.Replace(p_Type01, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.DicOneVal.Add(1, Convert.ToInt32(term));                        
                    }
                }
                else if (term.StartsWith(p_Type02))
                {
                    term = term.Replace(p_Type02, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.DicOneVal.Add(2, Convert.ToInt32(term));
                    }
                }
                else if (term.StartsWith(p_Type03))
                {
                    term = term.Replace(p_Type03, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.DicOneVal.Add(3, Convert.ToInt32(term));
                    }
                }
                else if (term.StartsWith(p_Type04))
                {
                    term = term.Replace(p_Type04, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.DicOneVal.Add(4, Convert.ToInt32(term));
                    }
                }
                else if (term.StartsWith(p_Type05))
                {
                    term = term.Replace(p_Type05, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (!result.DicMulVal.ContainsKey(5)) result.DicMulVal.Add(5, new List<object>());
                        var dd = term.Split(';').ToList().Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToList();
                        foreach (var item in dd)
                        {
                            result.DicMulVal[5].Add(item);
                        }                        
                    }
                }
                else if (term.StartsWith(p_Type06))
                {
                    term = term.Replace(p_Type06, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (!result.DicMulVal.ContainsKey(6)) result.DicMulVal.Add(6, new List<object>());
                        var dd = term.Split(';').ToList().Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToList();
                        foreach (var item in dd)
                        {
                            result.DicMulVal[6].Add(item);
                        }
                    }
                }
                else if (term.StartsWith(p_Type07))
                {
                    term = term.Replace(p_Type07, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (!result.DicMulVal.ContainsKey(7)) result.DicMulVal.Add(7, new List<object>());
                        var dd = term.Split(';').ToList().Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToList();
                        foreach (var item in dd)
                        {
                            result.DicMulVal[7].Add(item);
                        }
                    }
                }
                else if (term.StartsWith(p_Type08))
                {
                    term = term.Replace(p_Type08, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (!result.DicMulVal.ContainsKey(8)) result.DicMulVal.Add(8, new List<object>());
                        var dd = term.Split(';').ToList().Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToList();
                        foreach (var item in dd)
                        {
                            result.DicMulVal[8].Add(item);
                        }
                    }
                }
                else if (term.StartsWith(p_Type09))
                {
                    term = term.Replace(p_Type09, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        if (!result.DicMulVal.ContainsKey(9)) result.DicMulVal.Add(9, new List<object>());
                        var dd = term.Split(';').ToList().Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToList();
                        foreach (var item in dd)
                        {
                            result.DicMulVal[9].Add(item);
                        }
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

            if (item.DicOneVal.ContainsKey(0) && item.DicOneVal[0] > 0) result.Add(p_Type00 + item.DicOneVal[0]);
            if (item.DicOneVal.ContainsKey(1) && item.DicOneVal[1] > 0) result.Add(p_Type01 + item.DicOneVal[1]);
            if (item.DicOneVal.ContainsKey(2) && item.DicOneVal[2] > 0) result.Add(p_Type02 + item.DicOneVal[2]);
            if (item.DicOneVal.ContainsKey(3) && item.DicOneVal[3] > 0) result.Add(p_Type03 + item.DicOneVal[3]);
            if (item.DicOneVal.ContainsKey(4) && item.DicOneVal[4] > 0) result.Add(p_Type04 + item.DicOneVal[4]);


            if (item.DicMulVal.ContainsKey(5) && item.DicMulVal[5].Any()) result.Add(p_Type05 + string.Join(";", item.DicMulVal[5].Select(x=>x.ToString()).ToArray()));
            if (item.DicMulVal.ContainsKey(6) && item.DicMulVal[6].Any()) result.Add(p_Type06 + string.Join(";", item.DicMulVal[6].Select(x => x.ToString()).ToArray()));
            if (item.DicMulVal.ContainsKey(7) && item.DicMulVal[7].Any()) result.Add(p_Type07 + string.Join(";", item.DicMulVal[7].Select(x => x.ToString()).ToArray()));
            if (item.DicMulVal.ContainsKey(8) && item.DicMulVal[8].Any()) result.Add(p_Type08 + string.Join(";", item.DicMulVal[8].Select(x => x.ToString()).ToArray()));
            if (item.DicMulVal.ContainsKey(9) && item.DicMulVal[9].Any()) result.Add(p_Type09 + string.Join(";", item.DicMulVal[9].Select(x => x.ToString()).ToArray()));

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

    

    public class CapsItem
    {

        [XmlIgnore]
        public static DictionaryData DictionaryData = new DictionaryData();


        [XmlIgnore]
        public DictionaryData DicData { get { return CapsItem.DictionaryData; } }

        public static string p_FN = "FN=";
        public static string p_Parent = "Parent=";
        public static string p_Id = "Id=";
        
        public static string p_Name = "Name=";
        public static string p_Star = "Star=";
        public static string p_Descr = "Descr=";

        public static string p_DV = "DV_";

        public string ItemPath { set; get; }
        public int Id { set; get; }
        public bool GroupsEnabled { get { return this.ParentId == 0; } }
        public string FileName { set; get; }

        private int _ParentId;
        internal List<CapsItem> Owner;
        public int ParentId
        {
            set
            {
                if (value == 0)
                {
                    Parent = null;
                }
                else
                {
                    if (this.Owner != null)
                    {
                        Parent = this.Owner.Where(x => x.Id == value).FirstOrDefault();
                    }
                }                  
                _ParentId = value;
            }
            get { return _ParentId; }
        }
        public ImageSource Thumb
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
                if (File.Exists(path.LocalPath)) return new BitmapImage(path);
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
        public CapsItem Parent
        {
            set { _Parent = value; }
            get { return _Parent; }
        }

        internal static string SetToPassport(CapsItem item)
        {
            if (!item.IsNotEmpty()) return null;
            List<string> result = new List<string>();
            result.Add(p_Id + item.Id.ToString());
            result.Add(p_FN + item.FileName.ToString());
            if (item.ParentId>0) result.Add(p_Parent + item.ParentId.ToString());

            if (!string.IsNullOrEmpty(item._Name)) result.Add(p_Name + item._Name);
            if (!string.IsNullOrEmpty(item._Description)) result.Add(p_Descr + item._Description);
            if (!string.IsNullOrEmpty(item._Star)) result.Add(p_Star + item._Star);

            if (item.ParentId == 0)
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

            return string.Join(";",result.ToArray());
        }

        private bool IsNotEmpty()
        {
            return (
                this.ParentId!=0 
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
                    result.Id = Convert.ToInt32(terms[1]);
                }
                else if (mark == p_FN)
                {
                    result.FileName = terms[1];
                }
                else if (mark == p_Parent)
                {
                    result.ParentId = Convert.ToInt32(terms[1]);
                }
                else if (mark == p_Name)
                {
                    if (result.ParentId == 0)
                    {
                        result.Name = terms[1];
                    }
                }
                else if (mark == p_Descr)
                {
                    if (result.ParentId == 0)
                    {
                        result.Description = terms[1];
                    }
                }
                else if (mark == p_Star)
                {
                    if (result.ParentId == 0)
                    {
                        result.Star = terms[1];
                    }
                }
                else if (terms[0].StartsWith(p_DV))
                {
                    if (result.ParentId == 0)
                    {
                        var s = mark.Replace(p_DV, string.Empty).Replace("=", string.Empty);
                        int si = Convert.ToInt32(s);
                        List<string> dd = terms[1].Split('|').ToList();
                        if (si < 5 || (si>9 && si <50))
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
    }

    public class ClassItem
    {
        public string Description { set; get; }
        public int Val { set; get; }
    }
}
