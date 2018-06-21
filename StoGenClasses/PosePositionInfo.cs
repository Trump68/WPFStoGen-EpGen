using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class PosePositionInfo
    {
        public string ID { set; get; }
        public string Description { set; get; }
        public int SOS { set; get; } = 0;
        [XmlIgnore]
        public bool Active { set; get; } = true;
        [XmlIgnore]
        public string Name { get; set; }
        [XmlIgnore]
        public string Stage { get; set; }
        [XmlIgnore]
        public string Sex { get; set; }
        [XmlIgnore]
        public string Serie { get; set; }
        [XmlIgnore]
        public string Variant { get; set; }
        [XmlIgnore]
        public string XRate { get; set; }
        [XmlIgnore]
        public string Path { get; set; }
        public int Position { get; set; } 
        //[XmlIgnore]
        //public string Path;
        //[XmlIgnore]
        //public string File;

        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"SOS={SOS}");
            if (Position > 0)
                rez.Add($"POSITION={Position}");
            return string.Join(";", rez.ToArray());
        }
        public void LoadFromString(string item)
        {
            item = item.Replace("POSEPOSITION>", string.Empty);
            List<string> data = item.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("ID="))
                {
                    this.ID = str.Replace("ID=", string.Empty);
                }
                else if (str.StartsWith("SOS="))
                {
                    this.SOS = Convert.ToInt16(str.Replace("SOS=", string.Empty));
                }
                else if (str.StartsWith("POSITION="))
                {
                    this.Position = Convert.ToInt16(str.Replace("POSITION=", string.Empty));
                }
            }
        }

    }
}
