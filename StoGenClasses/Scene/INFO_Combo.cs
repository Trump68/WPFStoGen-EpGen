using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class Info_Combo
    {
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
        [XmlIgnore]
        public int N { set; get; } = 0;
        [XmlIgnore]
        public string Path;
        

        public string ID { set; get; }
        public string File { set; get; }
        // 0 - standart image
        // 1- header ($$WHITE$$  in file - white background)
        // 2- external image (from another set)
        // 3- repeat prev group 
        // 4- 1+2 
        // 5- transform prev picture
        // 6 - sound
        // 7 -1+6
        // 8 - Movie Clip
        public int Kind { set; get; } = 0;
        public string Description { set; get; } = string.Empty;

        public string Story { set; get; }
        public string Group { set; get; }
        public string Queue { set; get; }
       


        public static Info_Combo GenerateFromString(string item)
        {
            Info_Combo Rez = new Info_Combo();
            Rez.LoadFromString(item);
            return Rez;
        }
        // ClipProps
        public int LoopMode { set; get; } = 1;
        public int LoopCount { set; get; } = 1;
        public int Speed { set; get; } = 100;
        public int ShowMovieControl { set; get; } = 0;
        public decimal PositionStart { set; get; } = 0;
        public decimal PositionEnd { set; get; } = 0;

        //PictureProps
        public string X { set; get; }
        public string Y { set; get; }
        public string R { set; get; } //rotation
        public string O { set; get; } //opacity
        public string F { set; get; } //flip
        public string S { set; get; } //size
        public string T { set; get; } //transition
        public string Z { set; get; } //ZOrder
        public int Align { set; get; } = 0;// text align 0 -left, 1- right, 2-center, 3-justify


        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");

            if (!string.IsNullOrEmpty(File))
            {
                if (File.Contains(";"))
                {
                    string[] vals = File.Split(';');
                    if (vals[1].Contains("."))
                    {
                        string[] parts = vals[1].Split('.');
                        vals[1] = parts[1];
                    }
                    File = $"{vals[0]}@{vals[1]}";
                }
                else if (File.Contains("."))
                {
                    //string[] parts = File.Split('.');
                    //File = parts[1];
                }
                rez.Add($"FILE={File}");
            }
                

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
            if (!string.IsNullOrEmpty(O))
                rez.Add($"O={O}");
            if (!string.IsNullOrEmpty(S))
                rez.Add($"S={S}");
            if (!string.IsNullOrEmpty(Z))
                rez.Add($"Z={Z}");
            if (!string.IsNullOrEmpty(F))
                rez.Add($"F={F}");
            if (!string.IsNullOrEmpty(R))
                rez.Add($"R={R}");
            if (!string.IsNullOrEmpty(T))
                rez.Add($"T={T}");
            if (Align != 0)
                rez.Add($"Align={Align}");

            if (!string.IsNullOrEmpty(Group))
                rez.Add($"GROUP={Group}");
            if (!string.IsNullOrEmpty(Queue))
                rez.Add($"QUEUE={Queue}");

            if (PositionStart != 0)
                rez.Add($"PositionStart={PositionStart}");
            if (PositionEnd != 0)
                rez.Add($"PositionEnd={PositionEnd}");
            if (LoopMode != 0)
                rez.Add($"LoopMode={LoopMode}");
            if (LoopCount != 0)
                rez.Add($"LoopCount={LoopCount}");
            if (Speed != 0)
                rez.Add($"Speed={Speed}");
            if (ShowMovieControl != 0)
                rez.Add($"ShowMovieControl={ShowMovieControl}");


            return string.Join(";", rez.ToArray());
        }
        public void LoadFromString(string item)
        {
            item = item.Replace("COMBDATA>", string.Empty);
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
                else if (str.StartsWith("Align="))
                {
                    this.Align = Convert.ToInt32(str.Replace("Align=", string.Empty));
                }
                else if (str.StartsWith("STR="))
                {
                    this.Story = str.Replace("STR=", string.Empty);
                }
                else if (str.StartsWith("X="))
                {
                    this.X = str.Replace("X=", string.Empty);
                }
                else if (str.StartsWith("Y="))
                {
                    this.Y = str.Replace("Y=", string.Empty);
                }
                else if (str.StartsWith("O="))
                {
                    this.O = str.Replace("O=", string.Empty);
                }
                else if (str.StartsWith("R="))
                {
                    this.R = str.Replace("R=", string.Empty);
                }
                else if (str.StartsWith("S="))
                {
                    this.S = str.Replace("S=", string.Empty);
                }
                else if (str.StartsWith("F="))
                {
                    this.F = str.Replace("F=", string.Empty);
                }
                else if (str.StartsWith("Z="))
                {
                    this.Z = str.Replace("Z=", string.Empty);
                }
                else if (str.StartsWith("T="))
                {
                    this.T = str.Replace("T=", string.Empty);
                }


                else if (str.StartsWith("GROUP="))
                {
                    this.Group = str.Replace("GROUP=", string.Empty);
                }
                else if (str.StartsWith("QUEUE="))
                {
                    this.Queue = str.Replace("QUEUE=", string.Empty);
                }
                else if (str.StartsWith("PositionStart="))
                {                    
                    this.PositionStart = Convert.ToDecimal(str.Replace("PositionStart=", string.Empty));
                }
                else if (str.StartsWith("PositionEnd="))
                {
                    this.PositionEnd = Convert.ToDecimal(str.Replace("PositionEnd=", string.Empty));
                }
                else if (str.StartsWith("LoopMode="))
                {
                    this.LoopMode = Convert.ToInt32(str.Replace("LoopMode=", string.Empty));
                }
                else if (str.StartsWith("LoopCount="))
                {
                    this.LoopCount = Convert.ToInt32(str.Replace("LoopCount=", string.Empty));
                }
                else if (str.StartsWith("Speed="))
                {
                    this.Speed = Convert.ToInt32(str.Replace("Speed=", string.Empty));
                }
                else if (str.StartsWith("ShowMovieControl="))
                {
                    this.ShowMovieControl = Convert.ToInt32(str.Replace("ShowMovieControl=", string.Empty));
                }

            }
        }
    }
}
