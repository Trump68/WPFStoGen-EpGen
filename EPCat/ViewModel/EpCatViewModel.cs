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

        internal void Close()
        {
            _Loader.SaveCatalog();           
        }
        

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
                this._CurrentClip = _CurrentFolder.Clips.First();
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

        internal void ShowClip()
        {
            if (this.CurrentClip == null) return;

            var videos = this.CurrentFolder.Videos;            
            if (!videos.Any()) return;

            string path = videos.First();
            
            GameWorldFactory.GameWorld.LoadData();
            BaseScene scene = null;


            scene = new _Clip_Default();
            if (scene.LoadData(this.CurrentClip.ID, path))
                 scene.Generate(this.CurrentClip.ID);

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            window.Scene = scene;
            window.Show();            
        }
    }

}
