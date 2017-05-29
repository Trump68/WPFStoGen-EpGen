﻿using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControl;
using EPCat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public List<CapsItem> CurrentCaps
        {
            get
            {

                if (CapsViewMode == 1) return _CurrentFolder?.Caps.Where(x => string.IsNullOrEmpty(x.ParentId)).ToList();
                return _CurrentFolder?.Caps;
            }
        }
        private int CapsViewMode = 0;


        public void ProcessScriptFile()
        {
            this._FolderList = _Loader.ProcessScriptFile(this._FolderList, this._CapsList);
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
        }

        internal void SetCapsViewMode(int newValue)
        {
            CapsViewMode = newValue;
        }

        internal void SetCurrentImagePassort(int selectedIndex)
        {
            EpItem.SetCurrentImagePassort(selectedIndex);
        }
    }

}
