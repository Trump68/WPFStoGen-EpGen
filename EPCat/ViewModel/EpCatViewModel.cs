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
                        this._CurrentClip = Info_Clip.Default(_CurrentFolder.GID.ToString()); 
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

        Info_Combo _CurrentCombinedScene;
        public Info_Combo CurrentCombinedScene
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


        //SkyrimPosePositionInfo _CurrentPosePosition;
        //public SkyrimPosePositionInfo CurrentPosePosition
        //{
        //    get
        //    {
        //        if (this.CurrentFolder != null)
        //        {
        //            if (_CurrentPosePosition == null)
        //            {
        //                if (this.CurrentFolder.CombinedScenes.Any())
        //                    _CurrentPosePosition = this.CurrentFolder.PosePositions.First();
        //            }
        //        }
        //        return _CurrentPosePosition;
        //    }
        //    set
        //    {
        //        _CurrentPosePosition = value;
        //    }
        //}


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


        Info_Clip _ClipTemplate = new Info_Clip();
        public Info_Clip ClipTemplate
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
        public bool IsSavingAllowed { get; set; } = true;

        public int CapsViewMode = 0;


        public void ProcessScriptFile()
        {

            this._FolderList = _Loader.ProcessScriptFile(this._FolderList, this._CapsList);
            
            if (this._FolderList == null) return;

            FillPosePositions();
            //FillMotions();

            this.FolderListView = new ObservableCollection<EpItem>(this._FolderList);
            this.CapsListView = new ObservableCollection<CapsItem>(this._CapsList.Where(x=>string.IsNullOrEmpty(x.ParentId)));
            RaisePropertyChanged(() => this.FolderListView);
            RaisePropertyChanged(() => this.CapsListView);

        }
        public void FillPosePositions()
        {
            foreach (var item in _FolderList)
            {
                foreach (var pp in item.PosePositions)
                {
                    Guid gid = Guid.Parse(pp.ID);
                    var si = _FolderList.Where(x => x.GID.Equals(gid)).FirstOrDefault();
                    if (si != null)
                    {
                        pp.Name    = si.Name;
                        pp.Stage   = si.Stage;
                        pp.Serie   = si.Serie;
                        pp.Sex     = si.PersonSex;
                        pp.Variant = si.Variant;
                        pp.XRate   = si.XRated;
                        pp.Path    = si.ItemPath;
                    }
                }
            } 
        }
        public void FillMotions()
        {
            foreach (var item in _FolderList)
            {
                foreach (var pp in item.Motions)
                {
                    Guid gid = Guid.Parse(pp.ID);
                    var si = _FolderList.Where(x => x.GID.Equals(gid)).FirstOrDefault();
                    if (si != null)
                    {
                        pp.Name = si.Name;
                        pp.Stage = si.Stage;
                        pp.Serie = si.Serie;
                        pp.Sex = si.PersonSex;
                        pp.Variant = si.Variant;
                        pp.XRate = si.XRated;                       
                    }
                }
            }
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

            GameWorldFactory.GameWorld.LoadData();
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
            newclipinfo.PositionStart = this.ClipTemplate.PositionStart;
            newclipinfo.PositionEnd = this.ClipTemplate.PositionEnd;
            if (string.IsNullOrEmpty(this.ClipTemplate.File))
            {
                newclipinfo.File = this.CurrentFolder.Videos[0];
            }
            else
            {
                newclipinfo.File = this.ClipTemplate.File;
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
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.CurrentFolder.Clips);
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            //this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();

            this.ClipTemplate.PositionEnd = 0;
            this.ClipTemplate.PositionStart = 0;

        }
        internal void AddMedia()
        {
            var last = this.CurrentFolder.Clips.LastOrDefault();


            Info_Clip newclipinfo = new Info_Clip();
            newclipinfo.ID = Guid.NewGuid().ToString();
            //newclipinfo.PositionStart = this.ClipTemplate.PositionStart;
            //newclipinfo.PositionEnd = this.ClipTemplate.PositionEnd;
            //newclipinfo.File = this.ClipTemplate.File;
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

            //this.ClipTemplate.PositionEnd = 0;
            //this.ClipTemplate.PositionStart = 0;

        }
        List<string> CopiedCombinedScene = new List<string>();
        internal void CopyCombinedScene(bool allgroup)
        {
            if (this.CurrentCombinedScene == null)
                return;
            CopiedCombinedScene.Clear();
            if (allgroup)
            {
                var col = this.CurrentFolder.CombinedScenes.Where(x => x.Group == this.CurrentCombinedScene.Group);
                foreach (var item in col)
                {
                    CopiedCombinedScene.Add(item.GenerateString());
                }
            }
            else
            {                
                CopiedCombinedScene.Add(this.CurrentCombinedScene.GenerateString());
            }
        }

        internal void AddCombinedScene(int? kind)
        {
            if (this.CurrentFolder == null) return;
            var last = this.CurrentFolder.CombinedScenes.LastOrDefault();
            
            if (kind == null && CopiedCombinedScene != null && CopiedCombinedScene.Any())
            {
                foreach (var item in CopiedCombinedScene)
                {
                    Info_Combo newclipinfo = new Info_Combo();
                    newclipinfo.LoadFromString(item);
                    addNewComb(newclipinfo);
                }
                CopiedCombinedScene.Clear();
            }
            else
            {
                Info_Combo newclipinfo = new Info_Combo();
                if (last != null)
                {
                    int r;
                    if (newclipinfo.Kind == 4 && Int32.TryParse(last.Group, out r))
                    {
                        newclipinfo.Group = $"{++r}";
                    }
                    else
                    {
                        newclipinfo.Group = last.Group;
                    }
                    
                    newclipinfo.Queue = last.Queue;
                    if (kind.HasValue)
                        newclipinfo.Kind = kind.Value;
                    else
                        newclipinfo.Kind = last.Kind;
                    newclipinfo.Description = last.Description;
                    if (!string.IsNullOrEmpty(last.File) && last.File.Contains("@"))
                    {
                        string[] vals = last.File.Split('@');
                        newclipinfo.File = vals[0] + "@";
                    }
                    try
                    {
                        string clpb = Clipboard.GetText();
                        if (clpb.EndsWith(".png") || clpb.EndsWith(".jpg"))
                        {
                            newclipinfo.File = $"{newclipinfo.File}{clpb}";
                        }
                    }
                    catch (Exception)
                    {

                    }
                   
                }
                addNewComb(newclipinfo);
            }

        }
        
        private void addNewComb(Info_Combo newclipinfo)
        {
            newclipinfo.ID = Guid.NewGuid().ToString();

            //this.CurrentFolder.CombinedScenes.Add(newclipinfo);
            int index = this.CurrentFolder.CombinedScenes.IndexOf(this.CurrentCombinedScene);
            this.CurrentFolder.CombinedScenes.Insert(index + 1, newclipinfo);

            this.CurrentCombinedScene = newclipinfo;

            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentCombinedScene);
            RaisePropertyChanged(() => this.CurrentFolder.CombinedScenes);
            //this.CurrentCombinedScene = this.CurrentFolder.CombinedScenes.Last();
        }

        internal void ShowScene()
        {
            if (this.CurrentCombinedScene == null) return;
            
            GameWorldFactory.GameWorld.LoadData();
            //BaseScene scene = null;
            var infolist = this.CurrentFolder.CombinedScenes.Where(x => x.Queue == this.CurrentCombinedScene.Queue).ToList();
            List<Info_Combo> listToShow = new List<Info_Combo>();
            infolist.Sort(delegate (Info_Combo x, Info_Combo y)
            {
                return x.Group.CompareTo(y.Group);
            });
            foreach (var item in infolist)
            {
                string its = item.GenerateString();
                Info_Combo itn = new Info_Combo();
                itn.LoadFromString(its);
                itn.File = item.File;
                itn.Path = item.Path;
                listToShow.Add(itn);

                if (string.IsNullOrEmpty(itn.Path))
                {
                    if (itn.Kind == 2 || itn.Kind == 4)
                    {
                        if (itn.File.Contains("@"))
                        {
                            string[] vals = itn.File.Split('@');
                            Guid id = Guid.Parse(vals[0]);
                            if (id != null)
                            {
                                var it = this._FolderList.Where(x => x.GID.Equals(id)).FirstOrDefault();
                                if (it != null)
                                {
                                    itn.Path = it.ItemDirectory;
                                    itn.File = vals[1];
                                    string fn = null;
                                    string path = Path.Combine(itn.Path,"PARTS");
                                    if (Directory.Exists(path))
                                       fn = Directory.GetFiles(path, $"*{vals[1]}*").ToList().FirstOrDefault();
                                    if (fn == null)
                                    {
                                        path = Path.Combine(itn.Path, "FIGURE");
                                        if (Directory.Exists(path))
                                            fn = Directory.GetFiles(path, $"*{vals[1]}*").ToList().FirstOrDefault();
                                        if (fn == null)
                                        {
                                            path = Path.Combine(itn.Path, "EVENTS");
                                            if (Directory.Exists(path))
                                                fn = Directory.GetFiles(path, $"*{vals[1]}*").ToList().FirstOrDefault();
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(fn))
                                    {
                                        itn.File = Path.GetFileName(fn);
                                        itn.Path = path;
                                    }                                                                        
                                }
                            }
                        }
                        else
                        {
                            var it = this._FolderList.Where(x => x.CombinedScenes.Where(
                                z =>
                                z.File == itn.File
                                &&
                                z.Kind == 0
                                ).Any()).FirstOrDefault();
                            if (it != null)
                            {
                                itn.Path = it.ItemDirectory;
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }

            //scene = GameWorldFactory.GetScene(listToShow);
            Scene_Combo scene = new Scene_Combo();
            scene.SetInfo(infolist);

            if (projector == null)
                projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.StartOnLoad = false;
            projector.Show();            
            projector.Start(Convert.ToInt32(this.CurrentCombinedScene.Group));
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
        public void GenerateMotion()
        {
            Skyrim.GenerateMotion(this.CurrentFolder, this.FolderListView);
        }

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
        internal void SaveCurrentSceneList()
        {
            if (this.CurrentFolder == null) return;
            if (this.CurrentFolder.CombinedScenes == null) return;
            List<string> lines = new List<string>();
            foreach (var item in this.CurrentFolder.CombinedScenes)
            {
                lines.Add(item.GenerateString());
            }
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(this.CurrentFolder.ItemPath), "SceneList.epcatsi"), lines);
        }

        internal void SaveClipToCombinedScene()
        {
            Info_Combo newclipinfo = new Info_Combo();
            newclipinfo.ID = Guid.NewGuid().ToString();
            newclipinfo.Kind = 8;
            newclipinfo.PositionStart = this.ClipTemplate.PositionStart;
            newclipinfo.PositionEnd = this.ClipTemplate.PositionEnd;
            if (string.IsNullOrEmpty(this.ClipTemplate.File))
            {
                newclipinfo.File = this.CurrentFolder.Videos[0];
            }
            else
            {
                newclipinfo.File = this.ClipTemplate.File;
            }
            addNewComb(newclipinfo);
        }

      
        #endregion
    }

}
