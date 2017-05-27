using DevExpress.Mvvm;
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


        
       
        public string PosterPath
        {
            set { }
            get { return CurrentFolder?.PosterPath; }
        }



        public List<CapsItem> CurrentCaps
        {
            get
            {

                if (CapsViewMode == 1) return _CurrentFolder?.Caps.Where(x => x.ParentId == 0).ToList();
                return _CurrentFolder?.Caps;
            }
        }
        private int CapsViewMode = 0;


        public void ProcessScriptFile()
        {
            this._FolderList = _Loader.ProcessScriptFile(this._FolderList);
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
