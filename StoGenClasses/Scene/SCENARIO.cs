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
                    if (string.IsNullOrEmpty(Name))
                        _FileName = Name;
                    else _FileName = "Default";
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
        //text
        public string DefTextSize;
        public string DefTextShift;
        public string DefTextWidth;
        public string DefFontSize;
        public string DefFontColor;
        public string DefTextAlignH;
        public string DefTextAlignV;
        public string DefTextBck;
        //visual
        public string DefVisX;
        public string DefVisY;
        public string DefVisSize;
        public string DefVisSpeed;
        public string DefVisLM;
        public string DefVisLC;
        public string DefVisFile;
        private void AssignRawParameters()
        {
            List<string> paramlist = new List<string>();
            string rdata = RawParameters.Replace(Environment.NewLine, "~");
            var lines = rdata.Split('~');
            foreach (var line in lines)
            {
                var items = line.Split(';');             
                foreach (var item in items)
                {
                    var s = item.Trim();
                    if (!s.StartsWith("//"))
                        paramlist.Add(item.Trim());
                }
            }
            foreach (var item in paramlist)
            {
                //text
                if (item.StartsWith("DefTextSize="))
                {
                    DefTextSize = item.Replace("DefTextSize=", string.Empty);
                }
                else if (item.StartsWith("DefTextShift="))
                {
                    DefTextShift = item.Replace("DefTextShift=", string.Empty);
                }
                else if (item.StartsWith("DefTextWidth="))
                {
                    DefTextWidth = item.Replace("DefTextWidth=", string.Empty);
                }
                else if (item.StartsWith("DefFontSize="))
                {
                    DefFontSize = item.Replace("DefFontSize=", string.Empty);
                }
                else if (item.StartsWith("DefFontColor="))
                {
                    DefFontColor = item.Replace("DefFontColor=", string.Empty);
                }
                else if (item.StartsWith("DefTextAlignH="))
                {
                    DefTextAlignH = item.Replace("DefTextAlignH=", string.Empty);
                }
                else if (item.StartsWith("DefTextAlignV="))
                {
                    DefTextAlignV = item.Replace("DefTextAlignV=", string.Empty);
                }
                else if (item.StartsWith("DefTextBck="))
                {
                    DefTextBck = item.Replace("DefTextBck=", string.Empty);
                }
                //visual
                else if (item.StartsWith("DefVisX="))
                {
                    DefVisX = item.Replace("DefVisX=", string.Empty);
                }
                else if (item.StartsWith("DefVisY="))
                {
                    DefVisY = item.Replace("DefVisY=", string.Empty);
                }
                else if (item.StartsWith("DefVisSize="))
                {
                    DefVisSize = item.Replace("DefVisSize=", string.Empty);
                }
                else if (item.StartsWith("DefVisSpeed="))
                {
                    DefVisSpeed = item.Replace("DefVisSpeed=", string.Empty);
                }
                else if (item.StartsWith("DefVisLM="))
                {
                    DefVisLM = item.Replace("DefVisLM=", string.Empty);
                }
                else if (item.StartsWith("DefVisLC="))
                {
                    DefVisLC = item.Replace("DefVisLC=", string.Empty);
                }
                else if (item.StartsWith("DefVisFile="))
                {
                    DefVisFile = item.Replace("DefVisFile=", string.Empty);
                }

            }
        }

        public void LoadFrom(List<string> clipsinstr)
        {
            bool isMetadata = false;
            bool isDescription = false;
            bool isRawData = false;
            List<string> lines = new List<string>();
            List<string> description_lines = new List<string>();
            List<string> rawdata_lines = new List<string>();
            foreach (var line in clipsinstr)
            {
                if (line.StartsWith("****METADATA START****"))
                {
                    isMetadata = true;
                    continue;
                }
                else if (line.StartsWith("****METADATA END****"))
                {
                    isMetadata = false;
                    continue;
                }

                if (line.StartsWith("NAME:"))
                {
                    this.Name = line.Replace("NAME:", string.Empty);
                }
                else if (line.StartsWith("ID:"))
                {
                    this.Id = line.Replace(line, "ID:");
                    if (string.IsNullOrEmpty(this.Id)) this.Id = Guid.NewGuid().ToString();
                }
                else if (line.StartsWith("FILENAME:"))
                {
                    this.FileName = line.Replace("FILENAME:", string.Empty);
                }
                else if (line.StartsWith("FEMALE:"))
                {
                    this.Female = line.Replace("FEMALE:", string.Empty);
                }
                else if (line.StartsWith("MALE:"))
                {
                    this.Male = line.Replace("MALE:", string.Empty);
                }
                else if (line.StartsWith("KIND:"))
                {
                    this.Kind = line.Replace("KIND:", string.Empty);
                }
                else if (line.StartsWith("CATEGORY:"))
                {
                    this.Category = line.Replace("CATEGORY:", string.Empty);
                }
                else if (line.StartsWith("VARIANT:"))
                {
                    this.Variant = line.Replace("VARIANT:", string.Empty);
                }
                else if (line.StartsWith("STOPWORDS:"))
                {
                    this.StopWords = line.Replace("STOPWORDS:", string.Empty);
                }
                else if (line.StartsWith("DESCRIPTION:"))
                {
                    isDescription = true;
                    isRawData = false;
                }
                else if (line.StartsWith("RAWPARAMETERS:"))
                {
                    isDescription = false;
                    isRawData = true;
                }
                else
                {
                    if (isMetadata)
                    {
                        if (isDescription)
                        {
                            description_lines.Add(line);
                            //this.Description = $"{this.Description}{Environment.NewLine}{line}";
                        }
                        else if (isRawData)
                        {
                            rawdata_lines.Add(line);
                            //this.RawParameters = $"{this.RawParameters}{Environment.NewLine}{line}";
                        }
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }
            this.Description = string.Join(Environment.NewLine, description_lines.ToArray());
            this.RawParameters = string.Join(Environment.NewLine, rawdata_lines.ToArray());
            this.Scenes.Clear();
            foreach (var line in lines)
            {
                this.Scenes.Add(Info_Combo.GenerateFromString(line));
            }
            AssignRawParameters();
        }

        public void SaveToFile(string ScenDir, string tempDir)
        {
            List<string> lines = new List<string>();
            lines.Add($"****METADATA START****");
            lines.Add($"NAME:{this.Name}");
            lines.Add($"ID:{this.Id}");
            lines.Add($"FILENAME:{this.FileName}");
            lines.Add($"FEMALE:{this.Female}");
            lines.Add($"MALE:{this.Male}");
            lines.Add($"KIND:{this.Kind}");
            lines.Add($"CATEGORY:{this.Category}");
            lines.Add($"VARIANT:{this.Variant}");
            lines.Add($"STOPWORDS:{this.StopWords}");
            lines.Add($"DESCRIPTION:");
            lines.Add($"{this.Description}");
            lines.Add($"RAWPARAMETERS:");
            lines.Add($"{this.RawParameters}");
            lines.Add($"****METADATA END****");

            List<string> queues = Scenes.Select(x => x.Queue).Distinct().ToList();

            foreach (var item in queues)
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
