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


        SkyrimPosePositionInfo _CurrentPosePosition;
        public SkyrimPosePositionInfo CurrentPosePosition
        {
            get
            {
                if (this.CurrentFolder != null)
                {
                    if (_CurrentPosePosition == null)
                    {
                        if (this.CurrentFolder.CombinedScenes.Any())
                            _CurrentPosePosition = this.CurrentFolder.PosePositions.First();
                    }
                }
                return _CurrentPosePosition;
            }
            set
            {
                _CurrentPosePosition = value;
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
        internal void CopyGidToClipboard()
        {
            if (this.CurrentFolder != null)
            {
                Clipboard.Clear();
                Clipboard.SetText(this.CurrentFolder.GID.ToString());
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
        internal void AddMedia()
        {
            var last = this.CurrentFolder.Clips.LastOrDefault();


            MovieSceneInfo newclipinfo = new MovieSceneInfo();
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
        internal void CopyCombinedScene()
        {
            if (this.CurrentCombinedScene == null)
                return;
            CopiedCombinedScene.Clear();
            if (this.CurrentCombinedScene.Kind == 1)
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
            
            if (CopiedCombinedScene != null && CopiedCombinedScene.Any())
            {
                foreach (var item in CopiedCombinedScene)
                {
                    CombinedSceneInfo newclipinfo = new CombinedSceneInfo();
                    newclipinfo.LoadFromString(item);
                    addNewComb(newclipinfo);
                }
                CopiedCombinedScene.Clear();
            }
            else
            {
                CombinedSceneInfo newclipinfo = new CombinedSceneInfo();
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
                    string clpb = Clipboard.GetText();
                    if (clpb.EndsWith(".png") || clpb.EndsWith(".jpg"))
                    {
                        newclipinfo.File = $"{newclipinfo.File}{clpb}";
                    }
                }
                addNewComb(newclipinfo);
            }

        }
        
        private void addNewComb(CombinedSceneInfo newclipinfo)
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
            BaseScene scene = null;
            var infolist = this.CurrentFolder.CombinedScenes.Where(x => x.Queue == this.CurrentCombinedScene.Queue).ToList();
            List<CombinedSceneInfo> listToShow = new List<CombinedSceneInfo>();

            foreach (var item in infolist)
            {
                string its = item.GenerateString();
                CombinedSceneInfo itn = new CombinedSceneInfo();
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

            scene = GameWorldFactory.GetScene(listToShow);


            if (projector == null)
                projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.Show();
            projector.Start();
        }

        internal void Close()
        {
            Save();
            if (projector != null)
                projector.Close();
        }
        internal void Save()
        {
            _Loader.SaveCatalog();
        }

        public void CopyItem()
        {
            copiedItem = this.CurrentFolder;
        }

        #region Pose positions
        EpItem copiedItem = null; 
        internal void AddPosePosition()
        {
            if (this.copiedItem == null) return;
            SkyrimPosePositionInfo newpp = new SkyrimPosePositionInfo();
            this.CurrentPosePosition = newpp;
            newpp.ID = copiedItem.GID.ToString();
            newpp.Name = copiedItem.Name;
            newpp.Serie = copiedItem.Serie;
            newpp.Sex = copiedItem.PersonSex;
            newpp.Stage = copiedItem.Stage;
            newpp.Variant = copiedItem.Variant;
            newpp.XRate = copiedItem.XRated;

            this.CurrentFolder.PosePositions.Add(newpp);

            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentPosePosition);
            RaisePropertyChanged(() => this.CurrentFolder.PosePositions);

            this.copiedItem = null;
        }
        internal void AddPosePositionToCopied()
        {
            if (this.copiedItem == null) return;
            SkyrimPosePositionInfo newpp = new SkyrimPosePositionInfo();
            this.CurrentPosePosition = newpp;
            newpp.ID = CurrentFolder.GID.ToString();
            newpp.Name = CurrentFolder.Name;
            newpp.Serie = CurrentFolder.Serie;
            newpp.Sex = CurrentFolder.PersonSex;
            newpp.Stage = CurrentFolder.Stage;
            newpp.Variant = CurrentFolder.Variant;
            newpp.XRate = CurrentFolder.XRated;

            copiedItem.PosePositions.Add(newpp);

            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentPosePosition);
            RaisePropertyChanged(() => this.CurrentFolder.PosePositions);

        }

        
        public void GenerateMotion()
        {
            List<SkyrimPosePositionInfo> valid = new List<SkyrimPosePositionInfo>();
            foreach (var item in this.CurrentFolder.PosePositions)
            {
                if (!item.Active) continue;
                if (string.IsNullOrEmpty(item.Path)) continue;
                valid.Add(item);
            }
            List<SkyrimPosePositionInfo> valid0 = valid.Where(x => x.Position == 0).ToList();
            List<SkyrimPosePositionInfo> valid1 = valid.Where(x => x.Position == 1).ToList();
            List<SkyrimPosePositionInfo> valid2 = valid.Where(x => x.Position == 2).ToList();
            //Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo> possible
            //    = new Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo>(null, null, null);
            List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>> possible =
                new List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>>();

            
            foreach (var item0 in valid0)
            {
                if (valid1.Any())
                {
                    foreach (var item1 in valid1)
                    {
                        if (valid2.Any())
                        {
                            foreach (var item2 in valid2)
                            {
                                possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, item2));
                                
                            }
                        }
                        else
                        {
                            possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, null));
                        }
                    }
                }
                else
                {
                    possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, null, null));
                }
            }


            int stage = 0;
            string destinationPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\ABAnims01\";

            List<int> erections = new List<int>();
            foreach (var item in possible)
            {
                stage++;
                if (item.Item1 != null)
                {
                    docopyfile(item.Item1.Path, destinationPath, stage, 1);
                    erections.Add(item.Item1.SOS);
                }
                if (item.Item2 != null)
                {
                    docopyfile(item.Item2.Path, destinationPath, stage, 2);
                    erections.Add(item.Item2.SOS);
                }
                if (item.Item3 != null)
                {
                    docopyfile(item.Item3.Path, destinationPath, stage, 3);
                    erections.Add(item.Item3.SOS);
                }
            }
            RebuildSkript(erections);
        }
        private void docopyfile(string path, string destpath,int stage, int position)
        {
            string dest = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dest))
            {
                string file = Directory.GetFiles(dest, "*.hkx").FirstOrDefault();
                if (!string.IsNullOrEmpty(file))
                {
                    File.Copy(file, Path.Combine(destpath, $"AB01_Fuck_A{position}_S{stage}.hkx"), true);
                }
            }
        }
        internal void DeletePosePosition()
        {
            this.CurrentFolder.PosePositions.Remove(CurrentPosePosition);
        }
        private void RebuildSkript(List<int> erections)
        {
            string sourceFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\_SexLabFramework.psc";
            string destFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc";
            List<string> source = new List<string>(File.ReadAllLines(sourceFile));

            source.Add(@"int[] function AB_GetErection()");
            source.Add(@"     int[] Erection = new int[128]");
            //source.Add(@"     int i");
            //source.Add(@"     while i < erection.Length");
            int i = 0;
            foreach (var item in erections)
            {
                if (item != 0)
                {
                    source.Add($@"     erection[{i}] = {item}");
                    //source.Add($@"     i += 1");
                }
                i++;
            }
            //source.Add(@"     endwhile");
            source.Add(@"     return erection");
            source.Add(@"endFunction");

            File.WriteAllLines(destFile, source);
            //"C:\Program Files (x86)\Steam\steamapps\common\skyrim\Papyrus Compiler\ScriptCompile.bat" "$(FILE_NAME)" "$(CURRENT_DIRECTORY)"
            runBuild();
        }
        void runBuild()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @"d:\SteamLibrary\steamapps\common\Skyrim\Papyrus Compiler\ScriptCompileAdv.bat"; 
            pProcess.StartInfo.Arguments = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc"; //argument
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            //pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd(); //The output result
            pProcess.WaitForExit();
            MessageBox.Show(output);
        }
        #endregion
    }

}
