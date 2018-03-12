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
        internal List<CapsItem> _CapsList = new List<CapsItem>();


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


        private ObservableCollection<CapsItem> _CapsListView = new ObservableCollection<CapsItem>();
        public ObservableCollection<CapsItem> CapsListView
        {
            get
            {
                return _CapsListView;

            }
            set
            {
                _CapsListView = value;
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
                        this._CurrentClip = new MovieSceneInfo() { Description = "Default", ID = _CurrentFolder.ToString() };
                    }
                    if (_CurrentFolder.CombinedScenes.Any())
                    {
                        this._CurrentCombinedScene = _CurrentFolder.CombinedScenes.First();
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

        MovieSceneInfo _CurrentClip;
        public MovieSceneInfo CurrentClip
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

        CombinedSceneInfo _CurrentCombinedScene;
        public CombinedSceneInfo CurrentCombinedScene
        {
            get
            {
                if (this.CurrentFolder != null)
                {
                    if (_CurrentCombinedScene == null)
                    {
                        if (this.CurrentFolder.CombinedScenes.Any())
                            _CurrentCombinedScene = this.CurrentFolder.CombinedScenes.First();
                    }
                }
                return _CurrentCombinedScene;
            }
            set
            {
                _CurrentCombinedScene = value;
            }
        }

        CapsItem _CurrentCapsGroup;
        public CapsItem CurrentCapsGroup
        {
            get
            {
                return _CurrentCapsGroup;
            }
            set
            {
                _CurrentCapsGroup = value;
                RaisePropertyChanged(() => this.CurrentCapsForGroup);
            }
        }


        MovieSceneInfo _ClipTemplate = new MovieSceneInfo();
        public MovieSceneInfo ClipTemplate
        {
            get
            {
                return _ClipTemplate;
            }
            set
            {              
                _ClipTemplate = value;
            }
        }

        

        public List<CapsItem> CurrentCapsForGroup
        {
            get
            {
                List<CapsItem> result = null;
                if (_CurrentCapsGroup != null)
                {
                    result = new List<CapsItem>();
                    result.Add(_CurrentCapsGroup);
                    result.AddRange(_CurrentCapsGroup.ChildList);
                }
                return result;
            }
        }
        public string PosterPath
        {
            set { }
            get { return CurrentFolder?.PosterPath; }
        }
        public ObservableCollection<CapsItem> CurrentCaps
        {
            get
            {
                if (_CurrentFolder != null)
                {
                    //if (CapsViewMode == 1) return _CurrentFolder?.Caps.Where(x => string.IsNullOrEmpty(x.ParentId)).ToList();
                    return new ObservableCollection<CapsItem>(_CurrentFolder?.Caps);
                }
                return null;
            }
        }

        public bool IsDeletingAllowed { get; set; } = false;

        public int CapsViewMode = 0;


        public void ProcessScriptFile()
        {
            this._FolderList = _Loader.ProcessScriptFile(this._FolderList, this._CapsList);
            if (this._FolderList == null) return;
            this.FolderListView = new ObservableCollection<EpItem>(this._FolderList);
            this.CapsListView = new ObservableCollection<CapsItem>(this._CapsList.Where(x=>string.IsNullOrEmpty(x.ParentId)));
            RaisePropertyChanged(() => this.FolderListView);
            RaisePropertyChanged(() => this.CapsListView);

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

        internal void RefreshCaps()
        {
            RaisePropertyChanged(() => this.CurrentCaps);            
        }
        public void RefreshFolder()
        {
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.CurrentCombinedScene);
        }

        public void UpdateCapsFile()
        {
            _CurrentFolder?.SaveImagePassport();

            if (this.CurrentCapsGroup != null)
            {
                string pass = this.CurrentCapsGroup.PassportPath;

                List<string> lines = new List<string>();
                foreach (var cap in this._CapsList.Where(x => x.PassportPath == pass))
                {
                    string s = CapsItem.SetToPassport(cap);
                    if (!string.IsNullOrEmpty(s)) lines.Add(s);
                }
                if (lines.Any())
                {
                    File.WriteAllLines(pass, lines);
                }
            }
        }
        public void UpdateGroup()
        {
            if (this.CurrentCapsGroup != null)
            {
                string pass = this.CurrentCapsGroup.PassportPath;

                List<string> lines = new List<string>();
                foreach (var cap in this._CapsList.Where(x => x.PassportPath == pass))
                {
                    string s = CapsItem.SetToPassport(cap);
                    if (!string.IsNullOrEmpty(s)) lines.Add(s);
                }
                if (lines.Any())
                {
                    File.WriteAllLines(pass, lines);
                }
            }
        }
        internal void SetCapsViewMode(int newValue)
        {
            CapsViewMode = newValue;
            RefreshCaps();
        }

        internal void SetCurrentImagePassort(int selectedIndex)
        {
            EpItem.SetCurrentImagePassort(selectedIndex);
        }

        internal void CopyJPGNameToClipboard()
        {
            if (this.CurrentFolder != null)
            {
                Clipboard.Clear();
                Clipboard.SetText(this.CurrentFolder.GID.ToString()
                    .Replace("{", string.Empty)
                    .Replace("}", string.Empty)
                    +".jpg"
                    );
            }

        }


        StoGenWPF.MainWindow projector = null;
        internal void ShowClip()
        {
            if (this.CurrentClip == null) return;
            var videos = this.CurrentFolder.Videos;            
            if (!videos.Any()) return;
            string path = videos.First();            
            GameWorldFactory.GameWorld.LoadData();
            BaseScene scene = null;

            scene = new _Clip_Default();
            if (scene.LoadData(this.CurrentClip, path))
                 scene.Generate(this.CurrentClip.ID);

            if (projector == null)
                    projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
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
            

            MovieSceneInfo newclipinfo = new MovieSceneInfo();
            newclipinfo.ID = Guid.NewGuid().ToString();
            newclipinfo.PositionStart = this.ClipTemplate.PositionStart;
            newclipinfo.PositionEnd = this.ClipTemplate.PositionEnd;
            newclipinfo.File = this.ClipTemplate.File;
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
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.CurrentFolder.Clips);
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

            this.ClipTemplate.PositionEnd = 0;
            this.ClipTemplate.PositionStart = 0;

        }

        string CopiedCombinedScene = null;
        internal void CopyCombinedScene()
        {
            if (this.CurrentCombinedScene == null)
                return;            
            CopiedCombinedScene = this.CurrentCombinedScene.GenerateString();
        }

        internal void AddCombinedScene()
        {
            var last = this.CurrentFolder.CombinedScenes.LastOrDefault();
            CombinedSceneInfo newclipinfo = new CombinedSceneInfo();
            if (CopiedCombinedScene != null)
            {
                newclipinfo.LoadFromString(CopiedCombinedScene);
                CopiedCombinedScene = null;
            }
            else
            {
                if (last != null)
                {
                    newclipinfo.Group = last.Group;
                    newclipinfo.Queue = last.Queue;
                }
            }

            newclipinfo.ID = Guid.NewGuid().ToString();

            this.CurrentFolder.CombinedScenes.Add(newclipinfo);
            this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentCombinedScene);
            RaisePropertyChanged(() => this.CurrentFolder.CombinedScenes);
            this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

        }

        internal void ShowScene()
        {
            if (this.CurrentCombinedScene == null) return;
            GameWorldFactory.GameWorld.LoadData();
            BaseScene scene = null;
            var infolist = this.CurrentFolder.CombinedScenes.Where(x => x.Queue == this.CurrentCombinedScene.Queue).ToList();
            foreach (var item in infolist)
            {
                if (string.IsNullOrEmpty(item.Path))
                {
                    if (item.Kind == 2)
                    {
                        var it = this._FolderList.Where(x => x.CombinedScenes.Where(z => z.ID != item.ID && z.File == item.File).Any()).FirstOrDefault();
                        if (it != null)
                        {                         
                            item.Path = it.ItemDirectory;
                        }
                    }
                    else
                    {

                    }
                }
            }

            scene = GameWorldFactory.GetScene(infolist);


            if (projector == null)
                projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.Show();
            projector.Start();
        }

        internal void Close()
        {
            _Loader.SaveCatalog();
            if (projector != null)
                projector.Close();
        }

    }

}
