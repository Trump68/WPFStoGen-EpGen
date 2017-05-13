using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EPCat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EPCat
{
    public class EpCatViewModel: ViewModelBase
    {
        Loader _Loader = new Loader();
        public EpCatViewModel()
        {

        }

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


        public EpItem CurrentFolder { get; set; }

        public void ProcessScriptFile()
        {
            this._FolderList = _Loader.ProcessScriptFile(this._FolderList);
            this.FolderListView = new ObservableCollection<EpItem>(this._FolderList);
            RaisePropertyChanged(() => this.FolderListView);
            
        }

        internal void UpdateCurrentItem()
        {
            //if (updateenabled)
            //{
                if (this.CurrentFolder != null)
                {
                    _Loader.UpdateItem(this.CurrentFolder);
                }
            //}
        }
    }

}
