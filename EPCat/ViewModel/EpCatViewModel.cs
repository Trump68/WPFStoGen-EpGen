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
using System.Windows.Media.Imaging;
using System.Net;
using System.Linq.Expressions;
using StoGen.Classes.SceneCadres;
using StoGen.Classes.Catalog;

namespace EPCat
{


    public class EpCatViewModel : ViewModelBase
    {
        public Loader _Loader = new Loader();
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


        public List<Info_Scene> Scenes
        {
            get
            {
                if (CurrentCadre == null) return null;
                return CurrentCadre.Infos;
            }
        }
        public List<INFO_SceneCadre> GroupCadres
        {
            get
            {
                if (CurrentGroup == null) return null;
                return CurrentGroup.Cadres;
            }
        }

        private ObservableCollection<INFO_SceneGroup> _Groups = new ObservableCollection<INFO_SceneGroup>();
        public ObservableCollection<INFO_SceneGroup> Groups
        {
            get
            {
                return _Groups;

            }
            set
            {
                _Groups = value;
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
                RefreshFolder();
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
        //Info_Scene _CurrentScene;

        //public Info_Scene CurrentScene
        //{
        //    get
        //    {
        //        if (this.Story != null)
        //        {
        //            if (_CurrentScene == null)
        //            {
        //                if (this.Story.SceneCadres.Any() && this.Story.SceneCadres.First().Infos.Any())
        //                    _CurrentScene = this.Story.SceneCadres.First().Infos.First();
        //            }
        //        }
        //        return _CurrentScene;
        //    }
        //    set
        //    {
        //        _CurrentScene = value;

        //    }
        //}


        Info_Scene _CurrentInfo;
        public Info_Scene CurrentInfo
        {
            get
            {
                if (this.Story != null)
                {
                    if (_CurrentInfo == null)
                    {
                        if (Story.GroupList.Any() && Story.GroupList.First().Cadres.Any() && Story.GroupList.First().Cadres.First().Infos.Any())
                            _CurrentInfo = Story.GroupList.First().Cadres.First().Infos.First();
                    }
                }
                return _CurrentInfo;
            }
            set
            {
                _CurrentInfo = value;

            }
        }
        INFO_SceneCadre _CurrentCadre;
        public INFO_SceneCadre CurrentCadre
        {
            get
            {
                if (this.Story != null)
                {
                    if (_CurrentCadre == null)
                    {
                        if (Story.GroupList.Any() && Story.GroupList.First().Cadres.Any())
                            _CurrentCadre = Story.GroupList.First().Cadres.First();
                    }
                }
                return _CurrentCadre;
            }
            set
            {
                _CurrentCadre = value;
                if (_CurrentCadre != null)
                    recalculatePoster(_CurrentCadre.Id);
                RaisePropertyChanged(() => this.Scenes);
                RaisePropertyChanged(() => this.CurrentCadre);
            }
        }
        INFO_SceneGroup _CurrentGroup;
        public INFO_SceneGroup CurrentGroup
        {
            get
            {
                if (this.Story != null)
                {
                    if (_CurrentGroup == null)
                    {
                        if (Story.GroupList.Any())
                            _CurrentGroup = Story.GroupList.First();
                    }
                }
                
                return _CurrentGroup;
            }
            set
            {
                _CurrentGroup = value;
                if (_CurrentGroup != null)
                {
                    CurrentCadre = _CurrentGroup.Cadres.First();
                }
                RaisePropertyChanged(() => this.Groups);
                RaisePropertyChanged(() => this.GroupCadres);
            }
        }


        private void recalculatePoster(string group)
        {
            if (Story == null)
                return;
            if (_CurrentCadre == null)
                return;

            string fn = $"{Story.FileName}-{_CurrentCadre.Id}.jpg";
            string fnpath = Path.Combine(Path.GetDirectoryName(Story.FullFileName), "StoryCaps", fn);

            if (File.Exists(fnpath))
            {
                MemoryStream ms = new MemoryStream();
                BitmapImage bi = new BitmapImage();

                byte[] bytArray = File.ReadAllBytes(fnpath);
                ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                _CurrentCadre.Poster = bi;
            }
            else
            {
                _CurrentCadre.Poster = null;
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
        public void SetRatingText(string dd)
        {
            RatingText = dd;
            RaisePropertyChanged(() => RatingText);
        }

        public void UpdateCurrentItem()
        {
            //if (updateenabled)
            //{
            if (this.CurrentFolder != null)
            {
                CatalogLoader.UpdateItem(this.CurrentFolder);
            }
            //}
        }


        public void RefreshFolder()
        {
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentClip);
            RaisePropertyChanged(() => this.Story);
            RaisePropertyChanged(() => this.Scenes);
            RaisePropertyChanged(() => this.Groups);
            RaisePropertyChanged(() => this.GroupCadres);
            RaisePropertyChanged(() => this.ClipToProcess);

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
            RefreshFolder();
            this.CurrentClip = this.CurrentFolder.Clips.Last();
            //this.CurrentScene = this.CurrentFolder.CombinedScenes.Last();

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
            //this.CurrentScene = this.CurrentFolder.CombinedScenes.Last();

            //TicTakToe.ClipTemplate.PositionEnd = 0;
            //TicTakToe.ClipTemplate.PositionStart = 0;

        }

        internal void CopyCombinedScene(bool allgroup)
        {
            if (this.CurrentInfo == null)
                return;
            TicTakToe.CopiedCombinedScene.Clear();
            if (allgroup)
            {
                //var col = this.Story.SceneInfos.Where(x => x.Group == this.CurrentInfo.Group);
                foreach (var item in this.CurrentCadre.Infos)
                {
                    TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
                }
            }
            else
            {
                TicTakToe.CopiedCombinedScene.Add(this.CurrentInfo.GenerateString());
            }
        }

        internal void AddCombinedScene(bool incurrentgroup, bool toEnd, int group, int kind, bool ask)
        {
            if (this.CurrentFolder == null) return;
            //var last = this.CurrentFolder.CombinedScenes.LastOrDefault();
            var clip = TicTakToe.GetClipScreenShot();
            if (string.IsNullOrEmpty(clip))
            {
                string clipFile = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipFile))
                {
                    try
                    {
                        Path.GetFileName(clipFile);
                        if (File.Exists(clipFile))
                            clip = clipFile;
                    }
                    catch
                    {

                    }
                }
            }
            bool fileinserted = false;
            INFO_SceneCadre cadre = this.CurrentCadre;
            if (!incurrentgroup)
            {
                cadre = new INFO_SceneCadre(null, this.Groups);
            }
            if (kind < 0 && TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
            {
                Info_Scene newclipinfo = new Info_Scene();
                newclipinfo.LoadFromString(TicTakToe.CopiedCombinedScene.First());

                
                if (!incurrentgroup)
                {
                    cadre.Group = this.CurrentCadre.Group;
                    string str;
                    if (ask && frmInputBox.ShowInputBox(out str, this.CurrentCadre.Description) == System.Windows.Forms.DialogResult.OK)
                        cadre.Description = str;
                    else
                        cadre.Description = this.CurrentCadre.Description;
                }

                foreach (var item in TicTakToe.CopiedCombinedScene)
                {

                    newclipinfo = new Info_Scene();
                    newclipinfo.LoadFromString(item);
                    newclipinfo.Group = cadre.Id;

                    if (newclipinfo.Kind == 0)
                    {
                        if (clip != null && !fileinserted)
                        {
                            newclipinfo.File = clip;
                            fileinserted = true;

                        }
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
                        if (TicTakToe.ClipTemplate.PositionStart > 0)
                        {
                            newclipinfo.PositionStart = (TicTakToe.ClipTemplate.PositionStart + (decimal)0.1).ToString();
                        }
                        if (TicTakToe.ClipTemplate.PositionEnd > 0)
                        {
                            newclipinfo.PositionEnd = (TicTakToe.ClipTemplate.PositionEnd - (decimal)0.1).ToString();
                        }
                        newclipinfo.PositionEnd = TicTakToe.ClipTemplate.PositionEnd.ToString();
                        if (!string.IsNullOrEmpty(TicTakToe.ClipTemplate.File))
                            newclipinfo.File = TicTakToe.ClipTemplate.File;

                    }
                    cadre.Infos.Add(newclipinfo);
                }
                if (!incurrentgroup) addNewComb(cadre);
                
            }
            else
            {


                Info_Scene newclipinfo = new Info_Scene();
                newclipinfo.Kind = kind;
                if (TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
                {
                    Info_Scene v = new Info_Scene();
                    v.LoadFromString(TicTakToe.CopiedCombinedScene[0]);
                    if (incurrentgroup)
                    {
                        newclipinfo.Group = this.CurrentInfo.Group;
                        newclipinfo.Description = this.CurrentInfo.Description;
                    }
                    else
                    {
                        newclipinfo.Group = v.Group;
                        newclipinfo.Description = v.Description;
                    }
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
                cadre.Infos.Add(newclipinfo);
                addNewComb(cadre);
            }

        }



        private void addNewComb(INFO_SceneCadre newcadre)
        {

            if (this.Story == null) return;
            if (this.CurrentGroup == null) return;
            this.CurrentGroup.Cadres.Add(newcadre);
            this.CurrentCadre = newcadre;
            RaisePropertyChanged(() => this.CurrentFolder);
            RaisePropertyChanged(() => this.CurrentInfo);
            RaisePropertyChanged(() => this.Scenes);
            RaisePropertyChanged(() => this.GroupCadres);
            MainWindow.Instance.SetGVCurrent(this.CurrentGroup.Cadres.IndexOf(this.CurrentCadre));

        }

        internal void ShowScene()
        {
            if (this.CurrentInfo == null) return;

            // GameWorldFactory.GameWorld.LoadData();
            StoryScene scene = new StoryScene();
            scene.CatalogPath = this.CurrentFolder.ItemDirectory;
            List<INFO_SceneCadre> list = new List<INFO_SceneCadre>();
            foreach (var group in Story.GroupList.OrderBy(x => x.Order))
            {
                list.AddRange(group.Cadres.OrderBy(x => x.Order));
            }
            
            scene.SetScenario(this.Story, list);

            if (projector == null)
                projector = new StoGenWPF.MainWindow();
            projector.GlobalMenuCreator = GameWorldFactory.GameWorld;
            projector.Scene = scene;
            projector.StartOnLoad = false;
            projector.Show();
            int page = list.IndexOf(CurrentCadre);
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
            //this.Scenes = this.Story.SceneInfos;
            this.Groups = this.Story.GroupList;
            RefreshFolder();
        }

        internal void ReloadScenario()
        {
            SaveScenario();
            var dir = StoryWorkDir;
            LoadScenario(Path.Combine(dir, $"{this.Story.FileName}.epcatsi"), this.CurrentFolder);
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
                CopyGroup(false, false, 0, false);
            }
            //RaisePropertyChanged(() => this.RepeatedText);
        }

        public void CopyGroup(bool atEnd, bool toEnd, int group, bool ask)
        {
            //if (atEnd)
            //{
            //    Story.SceneInfos.LastOrDefault();
            //}
            //save
            CopyCombinedScene(true);
            AddCombinedScene(false, toEnd, group, -1, ask);
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

        //internal void CopyPasteDescriptionGroup()
        //{
        //    string descr = CurrentInfo.Description;
        //    var tocopylist = Story.SceneInfos.Where(x => x.Description == descr).ToList();
        //    TicTakToe.CopiedCombinedScene.Clear();
        //    foreach (var item in tocopylist)
        //    {
        //        TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
        //    }
        //    string newgroup = null;
        //    string oldgroup = null;
        //    foreach (var item in TicTakToe.CopiedCombinedScene)
        //    {
        //        Info_Scene newclipinfo = new Info_Scene();
        //        newclipinfo.LoadFromString(item);
        //        newclipinfo.Description = IncrementDescr(descr);

        //        if (oldgroup != newclipinfo.Group)
        //        {
        //            oldgroup = newclipinfo.Group;
        //            newgroup = null;
        //        }
        //        if (newgroup == null)
        //        {

        //            newgroup = this.Story.SceneInfos.Max(x => x.Group);
        //            newgroup = IncrementGroup(newgroup, 0);
        //        }
        //        newclipinfo.Group = newgroup;
        //        addNewComb(newclipinfo);
        //    }

        //}


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
            //if (this.CurrentInfo == null) return;
            //StoryBase StoryCopy = new StoryBase();
            //StoryCopy.FileName = this.CurrentInfo.Group.Replace(".","_");
            //StoryCopy.RawParameters = this.Story.RawParameters;
            //StoryCopy.AssignRawParameters();
            //StoryCopy.Story = this.Story.Story;

            //var col = this.Story.SceneInfos.Where(x => x.Description.Contains("intro"));
            //foreach (var item in col)
            //{
            //    TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
            //}

            //col = this.Story.SceneInfos.Where(x => x.Group == this.CurrentInfo.Group);
            //foreach (var item in col)
            //{
            //    TicTakToe.CopiedCombinedScene.Add(item.GenerateString());
            //}


            //if (TicTakToe.CopiedCombinedScene != null && TicTakToe.CopiedCombinedScene.Any())
            //{
            //    foreach (var item in TicTakToe.CopiedCombinedScene)
            //    {
            //        Info_Scene newclipinfo = new Info_Scene();
            //        newclipinfo.LoadFromString(item);
            //        StoryCopy.SceneInfos.Add(newclipinfo);
            //    }
            //    StoryCopy.SaveToFile(this.CurrentFolder.ItemDirectory, this.CurrentFolder.ItemTempDirectory);
            //    SCENARIO.PackScenario(StoryCopy, CurrentFolder.ItemDirectory);
            //}
        }




        internal void CalculateCameraPosition()
        {
            try
            {
                Double cx = 0;
                Double cy = 0;
                Double cz = 0;
                Double r = 0;
                Double rx = 0;
                Double ry = 0;

                string input = Clipboard.GetText();
                string[] vals = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string pos = vals[0].Replace(@"<Position>", string.Empty).Replace(@"</Position>", string.Empty);
                string rot = vals[1].Replace(@"<Rotation>", string.Empty).Replace(@"</Rotation>", string.Empty);
                string di = vals[2].Replace(@"<Distance>", string.Empty).Replace(@"</Distance>", string.Empty);
                vals = pos.Split(',');
                cx = Convert.ToDouble(vals[0]);
                cy = Convert.ToDouble(vals[1]);
                cz = Convert.ToDouble(vals[2]);
                vals = rot.Split(',');
                rx = Convert.ToDouble(vals[1]);
                ry = Convert.ToDouble(vals[0]);
                r = Convert.ToDouble(di);
                string output = $"@Camera cx={cx} cy={cy} cz={cz} radius={r} rx={rx} ry={ry}";

                Clipboard.Clear();
                Clipboard.SetText(output);
            }
            catch
            {


            }
        }
        internal void ReformatMotion()
        {
            try
            {

                string input = Clipboard.GetText();
                string output = @"@if exp= ""tf['ABB_MOTION_BLEND']>-1""" + Environment.NewLine;
                string[] vals = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string val in vals)
                {
                    int pos = val.IndexOf("blend");
                    string s = val.Substring(0, pos) + "blend=&tf['ABB_MOTION_BLEND']";
                    output += (s + Environment.NewLine);
                }
                output += ("@else" + Environment.NewLine);
                foreach (string val in vals)
                {
                    output += (val + Environment.NewLine);
                }
                output += ("@endif" + Environment.NewLine);
                output += (@"@eval exp=""tf['ABB_MOTION_BLEND']=-1""" + Environment.NewLine);
                Clipboard.Clear();
                Clipboard.SetText(output);
            }
            catch
            {


            }
        }

        internal void AddGroup()
        {
            if (this.CurrentFolder == null) return;
            bool fileinserted = false;
            INFO_SceneGroup group = new INFO_SceneGroup(null);
            group.Description = "New Group";
            this.CurrentGroup = group;
        }
    }

}
