using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class MovieSceneInfo
    {
        [XmlIgnore]
        public string Path;
        
        public string Description { set; get; }
        public string Protogonist { set; get; }
        public string Antagonist { set; get; }
        public int LoopMode { set; get; } = 1;
        public string Grade { set; get; }
        public int LoopCount { set; get; } = 1;
        public int Speed { set; get; } = 100;
        [XmlIgnore]
        public int N { set; get; } = 0;
        public string File { set; get; }
        public string ID { set; get; }
        public decimal PositionStart { set; get; } = 0;
        public decimal PositionEnd { set; get; } = 0;
        [XmlIgnore]
        public ImageSource Poster
        {
            get
            {
                try
                {
                    //// try to get from source dir
                    string PosterPath = $@"{Path}\CLIPCAPS\0000.{this.ID}.jpg";
                    Uri path = new Uri(PosterPath, UriKind.Absolute);
                    if (System.IO.File.Exists(path.LocalPath)) return new BitmapImage(path);
                }
                catch (Exception)
                {

                }
                return null;
            }
        }
        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");
            if (!string.IsNullOrEmpty(File))
                  rez.Add($"FILE={File}");
            rez.Add($"LM={this.LoopMode}");
            rez.Add($"LC={this.LoopCount}");
            rez.Add($"START={PositionStart}");
            rez.Add($"END={PositionEnd}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            rez.Add($"SPD={Speed}");
            if (!string.IsNullOrEmpty(Protogonist))
                rez.Add($"PRT={Protogonist}");
            if (!string.IsNullOrEmpty(Antagonist))
                rez.Add($"ANT={Antagonist}");
            if (!string.IsNullOrEmpty(Grade))
                rez.Add($"GRD={Grade}");
            return string.Join(";", rez.ToArray());
        }

        public void LoadFromString(string item)
        {
            List<string> data = item.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("ID="))
                {
                    this.ID = str.Replace("ID=", string.Empty);
                }
                else if (str.StartsWith("FILE="))
                {
                    this.File = str.Replace("FILE=", string.Empty);
                }
                else if (str.StartsWith("START="))
                {
                    this.PositionStart = Convert.ToDecimal(str.Replace("START=", string.Empty));
                }
                else if (str.StartsWith("END="))
                {
                    this.PositionEnd = Convert.ToDecimal(str.Replace("END=", string.Empty));
                }
                else if (str.StartsWith("DSC="))
                {
                    this.Description = str.Replace("DSC=", string.Empty);
                }
                else if (str.StartsWith("LM="))
                {
                    this.LoopMode = Convert.ToInt32(str.Replace("LM=", string.Empty));
                }
                else if (str.StartsWith("LC="))
                {
                    this.LoopCount = Convert.ToInt32(str.Replace("LC=", string.Empty));
                }
                else if (str.StartsWith("SPD="))
                {
                    this.LoopCount = Convert.ToInt32(str.Replace("SPD=", string.Empty));
                }
                else if (str.StartsWith("GRD="))
                {
                    this.Grade = str.Replace("GRD=", string.Empty);
                }
                else if (str.StartsWith("PRT="))
                {
                    this.Protogonist = str.Replace("PRT=", string.Empty);
                }
                else if (str.StartsWith("ANT="))
                {
                    this.Antagonist = str.Replace("ANT=", string.Empty);
                }
            }
        }
    }
}
