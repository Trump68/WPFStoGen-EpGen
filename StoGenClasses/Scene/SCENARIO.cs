using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoGen.Classes.Scene
{
    public class SCENARIO
    {
        public SCENARIO()
        {
            
        }
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Female { set; get; }
        public string Male { set; get; }
        public string RawParameterList { set; get; }
        private ObservableCollection<Info_Combo> _Scenes = null;
        public ObservableCollection<Info_Combo> Scenes
        {
            get
            {
                if (_Scenes == null)
                {
                    _Scenes = new ObservableCollection<Info_Combo>();

                }
                return _Scenes;
            }
        }
    }
}
