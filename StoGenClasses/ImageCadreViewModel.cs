using MVVMApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenWPF
{
    public class ImageCadreViewModel: ViewModelBase
    {
        private int layerIndex = 0;
        public int LayerIndex
        {
            get { return layerIndex; }
            set
            {
                layerIndex = value;
                OnPropertyChanged("LayerIndex");
            }
        }
        private int propIndex = 1;
        public int PropIndex
        {
            get { return propIndex; }
            set
            {
                propIndex = value;
                OnPropertyChanged("PropIndex");
            }
        }

        private bool relativeProp = false;
        public bool RelativeProp
        {
            get { return relativeProp; }
            set
            {
                relativeProp = value;
                OnPropertyChanged("RelativeProp");
            }
        }

        private int propStep = 5;
        public int PropStep
        {
            get { return propStep; }
            set
            {
                propStep = value;
                OnPropertyChanged("PropStep");
            }
        }
        private string resultString;
        public string ResultString
        {
            get { return resultString; }
            set
            {
                resultString = value;
                OnPropertyChanged("ResultString");
            }
        }
        private string infoLocationText;
        public string InfoLocationText
        {
            get { return infoLocationText; }
            set
            {
                infoLocationText = value;
                OnPropertyChanged("InfoLocationText");
            }
        }

        private string _InfoDateText;
        public string InfoDateText
        {
            get { return _InfoDateText; }
            set
            {
                _InfoDateText = value;
                OnPropertyChanged("InfoDateText");
            }
        }
      

    }
}
