using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class SkyrimMotionInfo
    {
        public string ID { set; get; }
        public string Description { set; get; }
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
        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            return string.Join(";", rez.ToArray());
        }
        public void LoadFromString(string item)
        {
            item = item.Replace("MOTION>", string.Empty);
            List<string> data = item.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("ID="))
                {
                    this.ID = str.Replace("ID=", string.Empty);
                }
            }
        }

    }
}
