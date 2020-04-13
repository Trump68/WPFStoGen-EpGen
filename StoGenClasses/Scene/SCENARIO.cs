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
        private string _FileName;
        public string FileName
        {
            set { _FileName = value; }
            get
            {
                if (string.IsNullOrEmpty(_FileName))
                {
                    _FileName = Name;
                }
                return _FileName;
            }
        }
        public string Description { set; get; }
        public string Female { set; get; }
        public string Male { set; get; }
        public string StopWords { set; get; }
        public string Kind { set; get; }
        public string Category { set; get; }
        public string Variant { set; get; }
        public string RawParameters { set; get; }
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

        public void LoadFrom(List<string> clipsinstr)
        {
            this.Scenes.Clear();
            foreach (var line in clipsinstr)
            {
                this.Scenes.Add(Info_Combo.GenerateFromString(line));
            }
        }

        public void SaveToFile(string ScenDir, string tempDir)
        {
            if (Scenes == null) return;
            List<string> files = Scenes.Select(x => x.Queue).Distinct().ToList();
            List<string> lines = new List<string>();
            foreach (var item in files)
            {
                
                var selectedQueue = Scenes.Where(x => x.Queue == item).OrderBy(x => x.Group).ToList();
                foreach (var queue in selectedQueue)
                {
                    lines.Add(queue.GenerateString());
                }               
            }
            string fn = Path.Combine(ScenDir, $"{FileName}.epcatsi");
            Directory.CreateDirectory(tempDir);
            string bfn = Path.Combine(tempDir, $"{FileName}.epcatsi");
            if (File.Exists(fn))
            {
                File.Copy(fn, bfn, true);
                File.Delete(fn);
            }
            File.WriteAllLines(fn, lines);
        }
    }
}
