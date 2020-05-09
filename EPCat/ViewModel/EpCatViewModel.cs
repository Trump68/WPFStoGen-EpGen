using DevExpress.Mvvm;
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
                return _CurrentCombinedScene;
            }
            set
            {
                _CurrentCombinedScene = value;
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
                newclipinfo.File = this.CurrentFolder.Videos[0];
            }
            else
            {
                newclipinfo.File = TicTakToe.ClipTemplate.File;
            }
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

            TicTakToe.ClipTemplate.PositionEnd = 0;
            TicTakToe.ClipTemplate.PositionStart = 0;

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

        internal void AddCombinedScene(bool incurrentgroup,bool toEnd, int? kind)
        {
            if (this.CurrentFolder == null) return;
            //var last = this.CurrentFolder.CombinedScenes.LastOrDefault();
            var clip = TicTakToe.GetClipScreenShot();
            if (kind == null && TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
            {
                foreach (var item in TicTakToe.CopiedCombinedScene)
                {
                    Info_Scene newclipinfo = new Info_Scene();
                    newclipinfo.LoadFromString(item);
                    if (incurrentgroup)
                    {
                        newclipinfo.Group = this.CurrentCombinedScene.Group;
                    }
                    else if (toEnd)
                    {
                        string newgroup = IncrementGroupToEnd(newclipinfo.Group);
                        newclipinfo.Group = newgroup;
                    }
                    else
                    {
                        string newgroup = IncrementGroup(newclipinfo.Group);
                        newclipinfo.Group = newgroup;
                    }

                    if (clip != null && newclipinfo.Kind == 0)
                    {
                        newclipinfo.File = clip;
                    }
                    else if (newclipinfo.Kind == 8)
                    {
                        newclipinfo.PositionStart = TicTakToe.ClipTemplate.PositionStart.ToString();
                        newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd.ToString();
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
                        }
                        else
                        {
                            newclipinfo.Group = v.Group;
                        }
                        newclipinfo.Queue = v.Queue;
                       
                    }                    
                    addNewComb(newclipinfo);
                }

            }

        }

        private string IncrementGroup(string v)
        {
            var vals = v.Split('.');
            if (vals.Length == 0) return v;
            int d;
            if (int.TryParse(vals[0], out d))
            {
                ++d;
                vals[0] = (d.ToString("D" + vals[0].Length));
            }    
            return string.Join(".", vals);
        }
        private string IncrementGroupToEnd(string v)
        {
            var vals = v.Split('.');
            if (vals.Length == 0) return v;
            int d = 999;
            vals[0] = d.ToString("D" + vals[0].Length);

            return string.Join(".", vals);
        }
        private void addNewComb(Info_Scene newclipinfo)
        {
            //newclipinfo.ID = Guid.NewGuid().ToString();
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
            _Loader.SaveCatalog();
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
            this.Story.SaveToFile(this.StoryWorkDir, Path.Combine(this.StoryWorkDir,"TMP"));             
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
            this.Story = Generator.LoadScenario(clipsinstr, item);
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

        public int RepeatedTextStart { set; get; }
        public int RepeatedTextEnd { set; get; }

        internal void GoRepeatText()
        {
            List<string> rez = new List<string>();
            for (int i = RepeatedTextStart; i <= RepeatedTextEnd; i++)
            {
                rez.Add(RepeatedText.Replace("[x]",$"{i}"));
            }
            RepeatedText = string.Join(Environment.NewLine, rez.ToArray());
            RaisePropertyChanged(() => this.RepeatedText);
        }

        //internal string  GoGenerateScenario(string storyname)
        //{         
        //    string filename = Generator.MakeScenario(StoryWorkDir, storyname);
        //    if (string.IsNullOrEmpty(filename))
        //        return null;
        //    return Path.Combine(StoryWorkDir, $"{filename}.epcatsi");
        //}

        internal string GoGenerateScenario(EpItem item)
        {
            string filename = Generator.MakeScenario(item);
            if (string.IsNullOrEmpty(filename))
                return null;
            return Path.Combine(item.ItemDirectory, $"{filename}.epcatsi");
        }
    }

}
