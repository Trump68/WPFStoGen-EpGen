﻿using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControl;
using EPCat.Model;
using StoGen.Classes.Data.Movie;
using StoGenMake;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using StoGen.Classes;
using System.Diagnostics;
using StoGen.Classes.Data.Games;
using StoGen.Classes.Scene;
using StoGenerator;
using StoGenerator.Stories;
using System.Windows.Media.Imaging;
using System.Net;

namespace EPCat
{

  
    public class EpCatViewModel: ViewModelBase
    {
        Loader _Loader = new Loader();
        public EpCatViewModel()
        {
            Instance = this;
        }
        public static EpCatViewModel Instance { set; get; }

       
        internal List<EpItem> _FolderList = new List<EpItem>();


        //bool updateenabled = false;

        

        private ObservableCollection<EpItem> _FolderListView = new ObservableCollection<EpItem>();
        public ObservableCollection<EpItem> FolderListView
        {
            get
            {                          
                return _FolderListView;
                
            }
            set
            {
                _FolderListView = value;
            }
        }


        private ObservableCollection<Info_Scene> _Scenes = new ObservableCollection<Info_Scene>();
        public ObservableCollection<Info_Scene> Scenes
        {
            get
            {
                return _Scenes;

            }
            set
            {
                _Scenes = value;
            }
        }

        EpItem _CurrentFolder;
        public EpItem CurrentFolder
        {
            get
            {
                return _CurrentFolder;
            }
            set
            {
                _CurrentFolder = value;
                if (_CurrentFolder != null)
                {
                    if (_CurrentFolder.Clips.Any())
                    {
                        this._CurrentClip = _CurrentFolder.Clips.First();
                    }
                    else
                    {
                        this._CurrentClip = Info_Clip.Default(_CurrentFolder.GID.ToString()); 
                    }
                    
                }
            }
        }


        string _ClipToProcess;
        public string ClipToProcess
        {
            get
            {
                return _ClipToProcess;
            }
            set
            {
                _ClipToProcess = value;
            }
        }

        Info_Clip _CurrentClip;
        public Info_Clip CurrentClip
        {
            get
            {
                return _CurrentClip;
            }
            set
            {
                _CurrentClip = value;
            }
        }

        Info_Scene _CurrentCombinedScene;
        public Info_Scene CurrentCombinedScene
        {
            get
            {
                if (this.Story != null)
                {
                    if (_CurrentCombinedScene == null)
                    {
                        if (this.Story.SceneInfos.Any())
                            _CurrentCombinedScene = this.Story.SceneInfos.First();
                    }
                }
                if (_CurrentCombinedScene != null)
                    recalculatePoster(_CurrentCombinedScene.Group);
                return _CurrentCombinedScene;
            }
            set
            {
                _CurrentCombinedScene = value;
               
            }
        }

        private void recalculatePoster(string group)
        {
            if (Story == null)
                return;
            if (_CurrentCombinedScene == null)
                return;           

            string fn = $"{Story.FileName}-{_CurrentCombinedScene.Group}.jpg";//"PPT-017a-0001.jpg";
            string fnpath = Path.Combine(Path.GetDirectoryName(Story.FullFileName), "StoryCaps",fn);
            Uri path = new Uri(fnpath, UriKind.Absolute);
            if (File.Exists(path.LocalPath))
            {
                _CurrentCombinedScene.Poster = new BitmapImage(path);
            }
            else
            {
                _CurrentCombinedScene.Poster = null;
            }
        }

        StoryBase _Story;
        public StoryBase Story
        {
            get
            {
                return _Story;
            }
            set
            {
                _Story = value;
            }
        }



        public string PosterPath
        {
            set { }
            get { return CurrentFolder?.PosterPath; }
        }
     

        public bool IsDeletingAllowed { get; set; } = false;
        public bool IsSavingAllowed { get; set; } = false;
        public static bool IsSynchPosterAllowed { get; set; } = false;

        public int CapsViewMode = 0;


        public void ProcessScriptFile()
        {

            this._FolderList = _Loader.ProcessScriptFile(this._FolderList);
            
            if (this._FolderList == null) return;

            this.FolderListView = new ObservableCollection<EpItem>(this._FolderList);
           
            RaisePropertyChanged(() => this.FolderListView);

        }
     
        public void UpdateCurrentItem()
        {
            //if (updateenabled)
            //{
                if (this.CurrentFolder != null)
                {
                    _Loader.UpdateItem(this.CurrentFolder);
                }
            //}
        }


        public void RefreshFolder()
        {
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.CurrentCombinedScene);
            RaisePropertyChanged(() => this.Story);
            RaisePropertyChanged(() => this.Scenes);
        }


        internal void SetCurrentImagePassort(int selectedIndex)
        {
            EpItem.SetCurrentImagePassort(selectedIndex);
        }

        internal void CopyJPGNameToClipboard()
        {
            try
            {
                if (this.CurrentFolder != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(this.CurrentFolder.GID.ToString()
                        .Replace("{", string.Empty)
                        .Replace("}", string.Empty)
                        + ".jpg"
                        );
                }
            }
            catch (Exception)
            {

               
            }
        }
        internal void CopyGidToClipboard()
        {
            try
            {
                if (this.CurrentFolder != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(this.CurrentFolder.GID.ToString());
                }
            }
            catch (Exception)
            {
            }

        }


        StoGenWPF.MainWindow projector = null;
        internal void ShowClip()
        {
            if (this.CurrentClip == null) return;

            var videos = this.CurrentFolder.Videos;
            if (!videos.Any()) return;

            //GameWorldFactory.GameWorld.LoadData();
            BaseScene scene = null;
            string path = videos.First();
            scene = new Scene_Clips();

            scene.LoadData(new List<Info_Clip>() { this.CurrentClip });

            if (projector == null)
                    projector = new StoGenWPF.MainWindow();

            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.StartOnLoad = false;
            projector.Show();
            projector.Start();
        }
        internal void EditClip()
        {
            if (this.CurrentClip == null) return;
            var videos = this.CurrentFolder.Videos;
            if (!videos.Any()) return;
            string path = videos.First();
        }

        internal void SaveClipTemplate()
        {
            var last = this.CurrentFolder.Clips.LastOrDefault();
            

            Info_Clip newclipinfo = new Info_Clip();
            newclipinfo.ID = Guid.NewGuid().ToString();
            newclipinfo.PositionStart = TicTakToe.ClipTemplate.PositionStart;
            newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd;
            if (string.IsNullOrEmpty(TicTakToe.ClipTemplate.File))
            {
                TicTakToe.ClipTemplate.File = this.CurrentFolder.Videos[0];
            }
            newclipinfo.File = TicTakToe.ClipTemplate.File;
            if (last != null)
            {
                newclipinfo.Antagonist = last.Antagonist;
                newclipinfo.Protogonist = last.Protogonist;
                string desc = last.Description;
                if (!string.IsNullOrEmpty(desc))
                {
                    int n;
                    if (int.TryParse(desc.Substring(0,3),out n))
                    {
                        newclipinfo.Description = $"{(n+1).ToString("D3")}.00 {new string(last.Description.Skip(7).ToArray())}";
                    }
                    else
                    {
                        newclipinfo.Description = last.Description;
                    }
                }
            }
            else
            {
                newclipinfo.Description = "001.00";
            }


            this.CurrentFolder.Clips.Add(newclipinfo);
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            RefreshFolder();
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            //this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

            //TicTakToe.ClipTemplate.PositionEnd = 0;
            //TicTakToe.ClipTemplate.PositionStart = 0;

        }
        internal void AddMedia()
        {
            var last = this.CurrentFolder.Clips.LastOrDefault();


            Info_Clip newclipinfo = new Info_Clip();
            newclipinfo.ID = Guid.NewGuid().ToString();
            //newclipinfo.PositionStart = TicTakToe.ClipTemplate.PositionStart;
            //newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd;
            //newclipinfo.File = TicTakToe.ClipTemplate.File;
            if (last != null)
            {
                //    newclipinfo.Antagonist = last.Antagonist;
                //    newclipinfo.Protogonist = last.Protogonist;
                string desc = last.Description;
                if (!string.IsNullOrEmpty(desc))
                {
                    int n;
                    if (int.TryParse(desc.Substring(0, 3), out n))
                    {
                        newclipinfo.Description = $"{(n + 1).ToString("D3")}.00 {new string(last.Description.Skip(7).ToArray())}";
                    }
                    else
                    {
                        newclipinfo.Description = last.Description;
                    }
                }

            }
            else
            {
                newclipinfo.Description = "001.00";
            }


            this.CurrentFolder.Clips.Add(newclipinfo);
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.CurrentFolder.Clips);
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            //this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

            //TicTakToe.ClipTemplate.PositionEnd = 0;
            //TicTakToe.ClipTemplate.PositionStart = 0;

        }
        
        internal void CopyCombinedScene(bool allgroup)
        {
            if (this.CurrentCombinedScene == null)
                return;
            TicTakToe.CopiedCombinedScene.Clear();
            if (allgroup)
            {
                var col = this.Story.SceneInfos.Where(x => x.Group == this.CurrentCombinedScene.Group);
                foreach (var item in col)
                {
                    TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
                }
            }
            else
            {
                TicTakToe.CopiedCombinedScene.Add(this.CurrentCombinedScene.GenerateString());
            }
        }

        internal void AddCombinedScene(bool incurrentgroup,bool toEnd, int group, int? kind)
        {
            if (this.CurrentFolder == null) return;
            //var last = this.CurrentFolder.CombinedScenes.LastOrDefault();
            var clip = TicTakToe.GetClipScreenShot();
            if (kind == null && TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
            {
                Info_Scene newclipinfo = new Info_Scene();
                newclipinfo.LoadFromString(TicTakToe.CopiedCombinedScene.First());
                string newgroup = string.Empty;
                if  (toEnd)
                    newgroup = IncrementGroupToEnd(newclipinfo.Group);
                else
                    newgroup = IncrementGroup(newclipinfo.Group, group);

                foreach (var item in TicTakToe.CopiedCombinedScene)
                {
                    newclipinfo = new Info_Scene();
                    newclipinfo.LoadFromString(item);
                    if (incurrentgroup)
                    {
                        newclipinfo.Group = this.CurrentCombinedScene.Group;
                    }
                    else 
                    {                        
                        newclipinfo.Group = newgroup;
                    }

                    if (newclipinfo.Kind == 0)
                    {
                        if (clip != null)
                            newclipinfo.File = clip;
                        else
                        {
                            string file = Path.GetFileNameWithoutExtension(newclipinfo.File);
                            int val;
                            if (int.TryParse(file, out val))
                            {
                                val++;
                                string newval = val.ToString("D" + file.Length);
                                newclipinfo.File = newclipinfo.File.Replace(file, $"{newval}");
                            }
                        }
                            
                    }
                    else if (newclipinfo.Kind == 8)
                    {
                        newclipinfo.PositionStart = TicTakToe.ClipTemplate.PositionStart.ToString();
                        newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd.ToString();
                        newclipinfo.File = TicTakToe.ClipTemplate.File;
                    }
                    addNewComb(newclipinfo);
                }
                //TicTakToe.CopiedCombinedScene.Clear();
            }
            else
            {
                if (kind.HasValue)
                {
                  
                        Info_Scene newclipinfo = new Info_Scene();
                        newclipinfo.Kind = kind.Value;
                        if (TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
                        {
                            Info_Scene v = new Info_Scene();
                            v.LoadFromString(TicTakToe.CopiedCombinedScene[0]);
                            if (incurrentgroup)
                            {
                                newclipinfo.Group = this.CurrentCombinedScene.Group;
                                newclipinfo.Description = this.CurrentCombinedScene.Description;
                            }
                            else
                            {
                                newclipinfo.Group = v.Group;
                                newclipinfo.Description = v.Description;
                            }
                            newclipinfo.Queue = v.Queue;
                            if (newclipinfo.Kind == 8 && TicTakToe.ClipTemplate != null)
                            {
                                newclipinfo.PositionStart = TicTakToe.ClipTemplate.PositionStart.ToString();
                                newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd.ToString();
                                newclipinfo.File = TicTakToe.ClipTemplate.File;
                                newclipinfo.Speed = "100";
                            }
                            else if (newclipinfo.Kind == 0 && TicTakToe.ClipScreenShot != null)
                            {
                            newclipinfo.File = TicTakToe.GetClipScreenShot();
                        }
                        }
                        addNewComb(newclipinfo);
                    
                }

            }

        }

        private string IncrementGroup(string v, int group)
        {
            var vals = v.Split('.');
            if (vals.Length == 0) return v;
            int d;
            if (int.TryParse(vals[group], out d))
            {
                ++d;
                vals[group] = (d.ToString("D" + vals[group].Length));
            }    
            return string.Join(".", vals);
        }
        private string IncrementGroupToEnd(string v)
        {
            int d = 999;
            var ddd = Story.SceneInfos.LastOrDefault();
            if (ddd != null)
            {
                var valsEnd = ddd.Group.Split('.');
                int max = int.Parse(valsEnd[0]);
                d = ++max;
            }
            var vals = v.Split('.');
            if (vals.Length == 0) return v;

            vals[0] = d.ToString("D" + vals[0].Length);

            return string.Join(".", vals);
        }
        private void addNewComb(Info_Scene newclipinfo)
        {
            //newclipinfo.ID = Guid.NewGuid().ToString();
            if (this.Story == null) return;
            this.Story.SceneInfos.Add(newclipinfo);
            this.CurrentCombinedScene = newclipinfo;
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentCombinedScene);
            RaisePropertyChanged(() => this.Scenes);
            MainWindow.Instance.SetGVCurrent(this.Story.SceneInfos.IndexOf(this.CurrentCombinedScene));

        }

        internal void ShowScene()
        {
            if (this.CurrentCombinedScene == null) return;
            
           // GameWorldFactory.GameWorld.LoadData();
            StoryScene scene = new StoryScene();
            scene.SetScenario(this.Story, this.CurrentCombinedScene.Queue);

            if (projector == null)
                projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.StartOnLoad = false;
            projector.Show();
            var m = Story.SceneInfos.Select(x => x.Group).Distinct().ToList();
            m.Sort();
            int page = m.IndexOf(this.CurrentCombinedScene.Group);
            projector.Start(page);
        }

        internal void Close(bool isSaving)
        {
            if (isSaving)
                Save();
            if (projector != null)
                projector.Close();
        }
        internal void Save()
        {
            var list = this.FolderListView.ToList();
            _Loader.SaveCatalog(ref list);
        }


        #region Pose positions
      

        internal void SaveCurrentClipList()
        {
            if (this.CurrentClip == null) return;
            List<string> lines = new List<string>();
            foreach (var item in this.CurrentFolder.Clips)
            {
                lines.Add(item.GenerateString());
            }
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(this.CurrentFolder.ItemPath), "ClipList.epcatci"), lines);
        }
        internal void SaveScenario()
        {
            if (this.Story != null)
            this.Story.SaveToFile(this.CurrentFolder.ItemDirectory, this.CurrentFolder.ItemTempDirectory);
            //this.Story.SaveToFile(this.StoryWorkDir, Path.Combine(this.StoryWorkDir,"TMP"));             
        }

        public string StoryWorkDir
        {
            get
            {
                string d = @"e:\!STOGENDB\TEMP\";
                if (Directory.Exists(d))
                    return d;
                return @"d:\temp";
            }
        }
        internal void LoadScenario(string fileName, EpItem item)
        {            
            List<string> clipsinstr = new List<string>(File.ReadAllLines(fileName));
            this.Story = Generator.LoadScenario(clipsinstr, item, fileName);
            this.Scenes = this.Story.SceneInfos;
            RefreshFolder();
        }

        internal void ClearScenes()
        {
            this.Story.SceneInfos.Clear();
        }

        internal void ReloadScenario()
        {          
            SaveScenario();
            var dir = StoryWorkDir;
            LoadScenario(Path.Combine(dir,$"{this.Story.FileName}.epcatsi"), this.CurrentFolder);
        }




        #endregion


        string _RepeatedText;
        public string RepeatedText
        {
            get
            {
                return _RepeatedText;
            }
            set
            {
                _RepeatedText = value;
            }
        }
        public string StatusText { set; get; }
        public string RatingText { set; get; }
        public int RepeatedTextStart { set; get; }
        public int RepeatedTextEnd { set; get; }

        internal void GoRepeatText()
        {
            List<string> rez = new List<string>();
            for (int i = RepeatedTextStart; i <= RepeatedTextEnd; i++)
            {
                CopyGroup(false, false, 0);
            }
            //RaisePropertyChanged(() => this.RepeatedText);
        }

        public void CopyGroup(bool atEnd, bool toEnd, int group)
        {
            if (atEnd)
            {
                CurrentCombinedScene =
                Story.SceneInfos.LastOrDefault();
            }
            //save
            CopyCombinedScene(true);
            AddCombinedScene(false, toEnd, group, null);
            // reset
            RefreshFolder();
        }

        internal string GoGenerateScenario(EpItem item)
        {
            string filename = Generator.MakeScenario(item);
            if (string.IsNullOrEmpty(filename))
                return null;
            return Path.Combine(item.ItemDirectory, $"{filename}.epcatsi");
        }

        internal void CopyPasteDescriptionGroup()
        {
            string descr = CurrentCombinedScene.Description;
            var tocopylist = Story.SceneInfos.Where(x => x.Description == descr).ToList();
            TicTakToe.CopiedCombinedScene.Clear();
            foreach (var item in tocopylist)
            {
                TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
            }
            string newgroup = null;
            string oldgroup = null;
            foreach (var item in TicTakToe.CopiedCombinedScene)
            {
                Info_Scene newclipinfo = new Info_Scene();
                newclipinfo.LoadFromString(item);
                newclipinfo.Description = IncrementDescr(descr);
               
                if (oldgroup != newclipinfo.Group)
                {
                    oldgroup = newclipinfo.Group;
                    newgroup = null;
                }
                if (newgroup == null)
                {
                   
                    newgroup = this.Story.SceneInfos.Max(x => x.Group);
                    newgroup = IncrementGroup(newgroup, 0);
                }
                newclipinfo.Group = newgroup;
                addNewComb(newclipinfo);
            }

        }


        private string IncrementDescr(string descr)
        {
            int d;
            if (int.TryParse(descr, out d))
            {
                ++d;
                descr = (d.ToString("D" + descr.Length));
            }
            return descr;
        }

        internal void CompileOne()
        {
            if (this.CurrentCombinedScene == null) return;
            StoryBase StoryCopy = new StoryBase();
            StoryCopy.FileName = this.CurrentCombinedScene.Group.Replace(".","_");
            StoryCopy.RawParameters = this.Story.RawParameters;
            StoryCopy.AssignRawParameters();
            StoryCopy.Story = this.Story.Story;

            var col = this.Story.SceneInfos.Where(x => x.Description.Contains("intro"));
            foreach (var item in col)
            {
                TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
            }

            col = this.Story.SceneInfos.Where(x => x.Group == this.CurrentCombinedScene.Group);
            foreach (var item in col)
            {
                TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
            }

            
            //AddCombinedScene(true, true, 0, null);
            if (TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
            {
                foreach (var item in TicTakToe.CopiedCombinedScene)
                {
                    Info_Scene newclipinfo = new Info_Scene();
                    newclipinfo.LoadFromString(item);
                    StoryCopy.SceneInfos.Add(newclipinfo);
                }
                StoryCopy.SaveToFile(this.CurrentFolder.ItemDirectory, this.CurrentFolder.ItemTempDirectory);
                SCENARIO.PackScenario(StoryCopy, CurrentFolder.ItemDirectory);
            }
        }
        internal void CalculateRating()
        {

            Dictionary<string, int> ratingCont = new Dictionary<string, int>();
            foreach (var item in this._FolderList)
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

            this.RatingText = dd;
            RaisePropertyChanged(() => this.RatingText);
        }

        private void processCsvFile(ref Dictionary<string, string> total,int n, List<string> old)
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
    }

}
