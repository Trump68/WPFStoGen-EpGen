﻿using DevExpress.Mvvm;
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
                //GetLeastNumImage(Path.GetDirectoryName(ItemPath) + @"\EVENTS\", PosterPath);
                //if (File.Exists(path.LocalPath)) return new BitmapImage(path);


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
        private string _SoundDirectory;
        [XmlIgnore]
        public string SoundDirectory
        {
            get
            {
                if (_SoundDirectory == null)
                {
                    if (string.IsNullOrEmpty(ItemPath)) return string.Empty;
                    _SoundDirectory =  Path.Combine(Path.GetDirectoryName(ItemPath), "SOUND");
                }
                return _SoundDirectory;
            }
        }

        public List<string> _Videos = null;
       [XmlIgnore]
        public List<string> Videos
        {
            get
            {
                if (_Videos == null)
                {
                    if (string.IsNullOrEmpty(ItemDirectory)) _Videos =  new List<string>();
                    else if (!Directory.Exists(ItemDirectory)) _Videos =  new List<string>();
                    else _Videos =  Directory.GetFiles(ItemDirectory, "*.m4v").ToList();
                }
                List<string> rez = new List<string>();
                rez.AddRange(_Videos);
                rez.AddRange(Sounds);
                return rez;
            }
        }


        private List<string> _Sounds = null;
        [XmlIgnore]
        public List<string> Sounds
        {
            get
            {
                if (_Sounds == null)
                {
                    if (string.IsNullOrEmpty(SoundDirectory)) _Sounds =  new List<string>();
                    else if (!Directory.Exists(SoundDirectory)) _Sounds = new List<string>();
                    else _Sounds = Directory.GetFiles(SoundDirectory, "*.mp3").ToList();
                }
                return _Sounds;
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
        [XmlIgnore]
        public int Scenes
        {
            get
            {
                return this.Clips.Count;
            }
        }
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
        // Virt Persons
        public string PersonName { get; set; }
        public string PersonAge { get; set; }
        public string PersonSex { get; set; }
        public string PersonType { get; set; }
        public string PersonKind { get; set; }
        public string LastCheck { get; set; }



        //
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

        

        private ObservableCollection<MovieSceneInfo> _Clips = null;
        public ObservableCollection<MovieSceneInfo> Clips
        {            
            get
            {
                if (_Clips == null)
                {
                    _Clips = new ObservableCollection<MovieSceneInfo>();

                }
                foreach (var item in _Clips)
                {
                    item.Path = Path.GetDirectoryName(this.ItemPath);
                    item.N = _Clips.IndexOf(item) + 1;
                }
                return _Clips;
            }
        }
        private ObservableCollection<CombinedSceneInfo> _CombinedScenes = null;
        public ObservableCollection<CombinedSceneInfo> CombinedScenes
        {
            get
            {
                if (_CombinedScenes == null)
                {
                    _CombinedScenes = new ObservableCollection<CombinedSceneInfo>();

                }
                foreach (var item in _CombinedScenes)
                {                    
                    item.N = _CombinedScenes.IndexOf(item) + 1;
                    if (item.Kind != 2 && item.Kind != 4)
                        item.Path = Path.GetDirectoryName(this.ItemPath);
                    if (item.Kind == 7)
                    {
                        if (string.IsNullOrEmpty(item.File) && !string.IsNullOrEmpty(item.Description))
                        {
                            string filename = Path.Combine(this.SoundDirectory, item.Description + ".mp3");
                            if (File.Exists(filename))
                            {
                                string gid = Guid.NewGuid().ToString();
                                string newpath = Path.GetFileNameWithoutExtension(filename);
                                newpath = $"{newpath}.{gid}.mp3";
                                newpath = Path.Combine(this.SoundDirectory, newpath);
                                File.Move(filename, newpath);
                                item.File = gid;
                            }
                            
                        }
                    }
                }
                return _CombinedScenes;
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
            this.LastCheck = item.LastCheck;

            this.PersonName = item.PersonName;
            this.PersonAge = item.PersonAge;
            this.PersonSex = item.PersonSex;
            this.PersonType = item.PersonType;
            this.PersonKind = item.PersonKind;

            this.SourceFolderExist = item.SourceFolderExist;

            this.Comments.Clear();
            this.Comments.AddRange(item.Comments);

            this.Clips.Clear();
            foreach (var it in item.Clips)
            {
                this.Clips.Add(it);
            }

            this.CombinedScenes.Clear();
            foreach (var it in item.CombinedScenes)
            {
                this.CombinedScenes.Add(it);
            }

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
        static string p_LastCheck = "LastCheck:";

        static string p_PersonName = "PersonName:";
        static string p_PersonAge = "PersonAge:";
        static string p_PersonSex = "PersonSex:";
        static string p_PersonType = "PersonType:";
        static string p_PersonKind = "PersonKind:";
        

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
        static string p_COMBDATA_BEGIN = "<COMBDATA";
        static string p_COMBDATA_END = "COMBDATA>";
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
            result.Add($"{p_LastEdit}{item.LastEdit}");

            if (!string.IsNullOrEmpty(item.Serie))
                result.Add(p_Serie + item.Serie);
            if (!string.IsNullOrEmpty(item.AltTitle))
                result.Add(p_AltTitle + item.AltTitle);
            if (!string.IsNullOrEmpty(item.Country))
                result.Add(p_Country + item.Country);
            if (item.Year > 0)
                result.Add(p_Year + (item.Year > 0 ? item.Year.ToString() : string.Empty));
            if (item.Month > 0)
                result.Add(p_Month + (item.Month > 0 ? item.Month.ToString() : string.Empty));
            if (item.Day > 0)
                result.Add(p_Day + (item.Day > 0 ? item.Day.ToString() : string.Empty));
            if (!string.IsNullOrEmpty(item.Rated))
                result.Add(p_Rated + item.Rated);
            if (!string.IsNullOrEmpty(item.XRated))
                result.Add(p_XRated + item.XRated);
            if (!string.IsNullOrEmpty(item.Kind))
                result.Add(p_Kind + item.Kind);
            if (!string.IsNullOrEmpty(item.Type))
                result.Add(p_Type + item.Type);
            if (!string.IsNullOrEmpty(item.Brand))
                result.Add(p_Brand + item.Brand);
            if (!string.IsNullOrEmpty(item.Star))
                result.Add(p_Star + item.Star);
            if (!string.IsNullOrEmpty(item.MyDescr))
                result.Add(p_MyDescr + item.MyDescr);
            if (!string.IsNullOrEmpty(item.Director))
                result.Add(p_Director + item.Director);
            if (!string.IsNullOrEmpty(item.Studio))
                result.Add(p_Studio + item.Studio);
            if (!string.IsNullOrEmpty(item.IMDB))
                result.Add(p_IMDB + item.IMDB);

            if (!string.IsNullOrEmpty(item.PersonName))
                result.Add(p_PersonName + item.PersonName);
            if (!string.IsNullOrEmpty(item.PersonAge))
                result.Add(p_PersonAge + item.PersonAge);
            if (!string.IsNullOrEmpty(item.PersonSex))
                result.Add(p_PersonSex + item.PersonSex);
            if (!string.IsNullOrEmpty(item.PersonType))
                result.Add(p_PersonType + item.PersonType);
            if (!string.IsNullOrEmpty(item.PersonKind))
                result.Add(p_PersonKind + item.PersonKind);
            if (!string.IsNullOrEmpty(item.LastCheck))
                result.Add(p_LastCheck + item.LastCheck);

            if (item.Comments.Count == 1)
            {
                if (!string.IsNullOrEmpty(item.Comments.First()))
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

            if (item.Clips.Count == 1)
            {
                    result.Add(p_SCENDATA_BEGIN + item.Clips.First().GenerateString() + p_SCENDATA_END);
            }
            else if (item.Clips.Count > 0)
            {
                List<string> ttt = new List<string>();
                foreach (var it in item.Clips)
                {
                    ttt.Add(it.GenerateString());
                }
                
                ttt[0] = p_SCENDATA_BEGIN + ttt.First();
                ttt[ttt.Count - 1] = ttt.Last() + p_SCENDATA_END;
                result.AddRange(ttt);
            }

            // combined scenes
            if (item.CombinedScenes.Count == 1)
            {
                result.Add(p_COMBDATA_BEGIN + item.CombinedScenes.First().GenerateString() + p_COMBDATA_END);
            }
            else if (item.CombinedScenes.Count > 0)
            {
                List<string> ttt = new List<string>();
                foreach (var it in item.CombinedScenes)
                {
                    ttt.Add(it.GenerateString());
                }

                ttt[0] = p_COMBDATA_BEGIN + ttt.First();
                ttt[ttt.Count - 1] = ttt.Last() + p_COMBDATA_END;
                result.AddRange(ttt);
            }

            return result;
        }
        internal static EpItem GetFromPassport(List<string> passport, string path)
        {
            EpItem result = new EpItem(1);
            result.ItemPath = path;
            bool isComments = false;
            bool isScenData = false;
            bool isCombData = false;
            foreach (var line in passport)
            {
                string term = line.Trim();
                // clipdata                       
                if (term.StartsWith(p_SCENDATA_BEGIN))
                {
                    term = term.Replace(p_SCENDATA_BEGIN, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        MovieSceneInfo sd = new MovieSceneInfo();
                        sd.LoadFromString(term);
                        if (!string.IsNullOrEmpty(sd.ID))
                            result.Clips.Add(sd);
                    }
                    isScenData = true;
                }
                else if (isScenData)
                {
                    if (term.Contains(p_SCENDATA_END))
                    {
                        term = term.Replace(p_SCENDATA_END, string.Empty);
                        isScenData = false;
                    }
                    MovieSceneInfo sd = new MovieSceneInfo();
                    sd.LoadFromString(term);
                    result.Clips.Add(sd);
                }
                //comb data
                else if (term.StartsWith(p_COMBDATA_BEGIN))
                {
                    term = term.Replace(p_COMBDATA_BEGIN, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        CombinedSceneInfo sd = new CombinedSceneInfo();
                        sd.LoadFromString(term);
                        if (!string.IsNullOrEmpty(sd.ID))
                            result.CombinedScenes.Add(sd);
                    }
                    isCombData = true;
                }
                else if (isCombData)
                {
                    if (term.Contains(p_COMBDATA_END))
                    {
                        term = term.Replace(p_COMBDATA_END, string.Empty);
                        isCombData = false;
                    }
                    CombinedSceneInfo sd = new CombinedSceneInfo();
                    sd.LoadFromString(term);
                    result.CombinedScenes.Add(sd);
                }

                else if (term.StartsWith(p_COMMENTS_BEGIN))
                {
                    term = term.Replace(p_COMMENTS_BEGIN, string.Empty);
                    term = term.Replace(p_COMMENTS_END, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.Comments.Add(term);
                    }
                    isComments = true;
                }
                else if (isComments)
                {
                    if (term.Contains(p_COMMENTS_END))
                    {
                        term = term.Replace(p_COMMENTS_END, string.Empty);
                        isComments = false;
                    }
                    result.Comments.Add(term);
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

                else if (term.StartsWith(p_PersonName))
                {
                    term = term.Replace(p_PersonName, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.PersonName = term;
                    }
                }
                else if (term.StartsWith(p_PersonAge))
                {
                    term = term.Replace(p_PersonAge, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.PersonAge = term;
                    }
                }
                else if (term.StartsWith(p_PersonSex))
                {
                    term = term.Replace(p_PersonSex, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.PersonSex = term;
                    }
                }
                else if (term.StartsWith(p_PersonType))
                {
                    term = term.Replace(p_PersonType, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.PersonType = term;
                    }
                }
                else if (term.StartsWith(p_PersonKind))
                {
                    term = term.Replace(p_PersonKind, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.PersonKind = term;
                    }
                }
                else if (term.StartsWith(p_LastCheck))
                {
                    term = term.Replace(p_LastCheck, string.Empty);
                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        result.LastCheck = term;
                    }
                }
            }
            return result;
        }

    }


}
