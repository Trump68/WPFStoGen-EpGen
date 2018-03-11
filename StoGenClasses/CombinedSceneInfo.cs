using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class CombinedSceneInfo
    {
        public string ID { set; get; }
        public string File { set; get; }
        public int Kind { set; get; } = 0;
        public string Description { set; get; }
        [XmlIgnore]
        public string StoryAsString
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Story))
                    return this.Story.Replace("~", Environment.NewLine);
                else
                    return this.Story;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.Story = value.Replace(Environment.NewLine, "~");
                else
                    this.Story = value;
            }
        }
        public string Story { set; get; }
        public string Group { set; get; }
        public string Queue { set; get; }

        //PictureProps
        public string X { set; get; }
        public string Y { set; get; }

        [XmlIgnore]
        public int N { set; get; } = 0;
        [XmlIgnore]
        public string Path;

        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");
            if (!string.IsNullOrEmpty(File))
                rez.Add($"FILE={File}");
            if (Kind!=0)
                rez.Add($"KIND={Kind}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");          
            if (!string.IsNullOrEmpty(Story))
                rez.Add($"STR={Story}");
            if (!string.IsNullOrEmpty(X))
                rez.Add($"X={X}");
            if (!string.IsNullOrEmpty(Y))
                rez.Add($"Y={Y}");
            if (!string.IsNullOrEmpty(Group))
                rez.Add($"GROUP={Group}");
            if (!string.IsNullOrEmpty(Queue))
                rez.Add($"QUEUE={Queue}");
            return string.Join(";", rez.ToArray());
        }

        public void LoadFromString(string item)
        {
            item = item.Replace("SCENDATA>", string.Empty);
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
                else if (str.StartsWith("DSC="))
                {
                    this.Description = str.Replace("DSC=", string.Empty);
                }
                else if (str.StartsWith("KIND="))
                {
                    this.Kind = Convert.ToInt32(str.Replace("KIND=", string.Empty));
                }
                else if (str.StartsWith("X="))
                {
                    this.X = str.Replace("X=", string.Empty);
                }
                else if (str.StartsWith("Y="))
                {
                    this.X = str.Replace("Y=", string.Empty);
                }
                else if (str.StartsWith("GROUP="))
                {
                    this.Group = str.Replace("GROUP=", string.Empty);
                }
                else if (str.StartsWith("QUEUE="))
                {
                    this.Queue = str.Replace("QUEUE=", string.Empty);
                }
            }
        }
    }
}
