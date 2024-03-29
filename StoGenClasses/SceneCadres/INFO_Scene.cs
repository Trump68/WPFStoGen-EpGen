﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace StoGen.Classes
{
    public class Info_Scene
    {
        public Info_Scene()
        {
        }
        public Info_Scene(int knd): this()
        {
            this.Kind = knd;
        }
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

        public int KindOrder
        {
            get
            {
                switch (this.Kind)
                {

                    case 0:
                        return 5;
                    case 1: // 
                        return 1;
                    case 6: // 
                        return 3;
                    case 8: // 
                        return 4;
                    case 9: // 
                        return 2;
                    case 10: // 
                        return 0;
                    default: return 100;
                }
            }
        }
        [XmlIgnore]
        public string KindName
        {
            get
            {
                switch (this.Kind)
                {

                    case 0:
                        return "Pic";
                    case 1: // 
                        return "Tit";
                    case 6: // 
                        return "Snd";
                    case 8: // 
                        return "Mov";
                    case 9: // 
                        return "Bck";
                    case 10: // 
                        return "Ctr";
                    default: return "Oth";
                }
            }
        }

        public string File { set; get; }
        // 0 - standart image
        // 1- header ($$WHITE$$  in file - white background)
        // 2- external image (from another set)-- DEPRECATED
        // 3- repeat prev group -- DEPRECATED
        // 4- 1+2 -- DEPRECATED
        // 5- transform prev picture-- DEPRECATED
        // 6 - sound
        // 7 -1+6 -- DEPRECATED
        // 8 - Movie Clip
        // 9 - background picture (auto added in every next scene)
        // 10 - control flow
        public int Kind { set; get; } = 0;
        public string Description { set; get; } = string.Empty;

        public string Story { set; get; }
        public string Group { set; get; }        
        public int Order { set; get; } = -1;
        public string Tags { set; get; } = string.Empty;// for work in person's posture

        public static Info_Scene GenerateFromString(string item)
        {
            Info_Scene Rez = new Info_Scene();
            Rez.LoadFromString(item);
            return Rez;
        }
        public static Info_Scene GenerateCopy(Info_Scene item)
        {
            Info_Scene Rez = (Info_Scene)item.MemberwiseClone();

            //Rez.Align = item.Align;
            //Rez.Description = item.Description;
            //Rez.F = item.F;
            //Rez.File = item.File;
            //Rez.Group = item.Group;
            //Rez.ID = item.ID;
            //Rez.Kind = item.Kind;
            //Rez.LoopCount = item.LoopCount;
            //Rez.LoopMode = item.LoopMode;
            //Rez. = item.Align;
            //Rez.Align = item.Align;
            //Rez.Align = item.Align;
            return Rez;
        }
        // ClipProps
        public string LoopMode { set; get; }// = 1;
        public string LoopCount { set; get; }// = 1;
        public string Speed { set; get; }// = 100;
        public string ShowMovieControl { set; get; } 
        public string PositionStart { set; get; }
        public string PositionEnd { set; get; }

        //PictureProps
        public string X { set; get; }
        public string Y { set; get; }
        public string R { set; get; } //rotation (Font Style)
        public string O { set; get; } //opacity
        public string F { set; get; } //flip
        public string S { set; get; } //size
        public string T { set; get; } //transition
        public string Z { set; get; } //ZOrder
        public string Align { set; get; }// text align 0 -left, 1- right, 2-center, 3-justify
        public string VAlign { set; get; }// textbox align 0 -top, 1-center, 3-bottom
        public bool Active { get; set; } = true;
        public string FigureName { get; set; }
        public int Direction { get; internal set; }
        public string Template { get; set; }
        public string GenerateString()
        {
            List<string> rez = new List<string>();
            if (!string.IsNullOrEmpty(Group))
                rez.Add($"GROUP={Group}");
            rez.Add($"KIND={Kind}");
            if (this.Active)
                rez.Add($"A=1");
            if (!string.IsNullOrEmpty(S))
                rez.Add($"S={S}");
            if (!string.IsNullOrEmpty(X))
                rez.Add($"X={X}");
            if (!string.IsNullOrEmpty(Y))
                rez.Add($"Y={Y}");
            if (!string.IsNullOrEmpty(PositionStart))
                rez.Add($"PositionStart={PositionStart}");
            if (!string.IsNullOrEmpty(PositionEnd))
                rez.Add($"PositionEnd={PositionEnd}");
            if (!string.IsNullOrEmpty(LoopMode))
                rez.Add($"LoopMode={LoopMode}");
            if (!string.IsNullOrEmpty(LoopCount))
                rez.Add($"LoopCount={LoopCount}");
            if (!string.IsNullOrEmpty(Speed))
                rez.Add($"Speed={Speed}");
            if (!string.IsNullOrEmpty(ShowMovieControl))
                rez.Add($"ShowMovieControl={ShowMovieControl}");
            if (!string.IsNullOrEmpty(O))
                rez.Add($"O={O}");
            if (!string.IsNullOrEmpty(Z))
                rez.Add($"Z={Z}");
            if (!string.IsNullOrEmpty(F))
                rez.Add($"F={F}");
            if (!string.IsNullOrEmpty(R))
                rez.Add($"R={R}");
            if (!string.IsNullOrEmpty(T))
                rez.Add($"T={T}");
            if (!string.IsNullOrEmpty(Align))
                rez.Add($"Align={Align}");
            if (!string.IsNullOrEmpty(VAlign))
                rez.Add($"VAlign={VAlign}");
            if (!string.IsNullOrEmpty(Tags))
                rez.Add($"Tags={Tags}");
            if (Direction > 0)
                rez.Add($"Direction={Direction}");

            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            if (!string.IsNullOrEmpty(Story))
                rez.Add($"STR={Story}");

            if (!string.IsNullOrEmpty(Template))
                rez.Add($"TEMPLATE={Template}");
            if (Order>=0)
                rez.Add($"ORD={Order}");
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
            return string.Join(";", rez.ToArray());
        }
        public void LoadFromString(string item)
        {
            item = item.Replace("COMBDATA>", string.Empty);
            List<string> data = item.Split(';').ToList();
            foreach (var str in data)
            {

                if (str.StartsWith("FILE="))
                {
                    this.File = str.Replace("FILE=", string.Empty);
                    continue;
                }
                if (str.StartsWith("TEXT~") || str.StartsWith("TEXT="))
                {
                    this.Kind = 1; 
                    this.Template = str.Replace("TEXT=", string.Empty).Replace("TEXT", string.Empty);
                    continue;
                }
                if (str.StartsWith("IMAGE~") || str.StartsWith("IMAGE="))
                {
                    this.Kind = 0;
                    this.Template = str.Replace("IMAGE=", string.Empty).Replace("IMAGE", string.Empty);
                    continue;
                }
                if (str.StartsWith("SOUND~") || str.StartsWith("SOUND="))
                {
                    this.Kind = 6;
                    this.Template = str.Replace("SOUND=", string.Empty).Replace("SOUND", string.Empty);
                    continue;
                }
                if (str.StartsWith("CONTROL~") || str.StartsWith("CONTROL="))
                {
                    this.Kind = 10;
                    this.Template = str.Replace("CONTROL=", string.Empty).Replace("CONTROL", string.Empty);
                    continue;
                }
                else if (str.StartsWith("DSC="))
                {
                    this.Description = str.Replace("DSC=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("KIND="))
                {
                    this.Kind = Convert.ToInt32(str.Replace("KIND=", string.Empty));
                    continue;
                }
                else if (str.StartsWith("Align="))
                {
                    this.Align = str.Replace("Align=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("VAlign="))
                {
                    this.VAlign = str.Replace("VAlign=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("STR="))
                {
                    this.Story = str.Replace("STR=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("ORD="))
                {
                    this.Order = int.Parse(str.Replace("ORD=", string.Empty));
                    continue;
                }
                else if (str.StartsWith("Direction="))
                {
                    this.Direction = int.Parse(str.Replace("Direction=", string.Empty));
                    continue;
                }
                else if (str.Trim() == "STOP")
                {
                    if (this.Kind == 6)
                    {
                        this.Y = "1";
                        this.R = "0";
                    }
                    continue;
                }
                else if (str.StartsWith("X="))
                {
                    this.X = str.Replace("X=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("Y="))
                {
                    this.Y = str.Replace("Y=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("O="))
                {
                    this.O = str.Replace("O=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("R="))
                {
                    this.R = str.Replace("R=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("S="))
                {
                    this.S = str.Replace("S=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("F="))
                {
                    this.F = str.Replace("F=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("Z="))
                {
                    this.Z = str.Replace("Z=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("T="))
                {
                    this.T = str.Replace("T=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("GROUP="))
                {
                    this.Group = str.Replace("GROUP=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("TEMPLATE="))
                {
                    this.Template = str.Replace("TEMPLATE=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("PositionStart="))
                {                    
                    this.PositionStart = str.Replace("PositionStart=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("PositionEnd="))
                {
                    this.PositionEnd = str.Replace("PositionEnd=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("LoopMode="))
                {
                    this.LoopMode = str.Replace("LoopMode=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("LoopCount="))
                {
                    this.LoopCount = str.Replace("LoopCount=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("Speed="))
                {
                    this.Speed = str.Replace("Speed=", string.Empty);
                    continue;
                }
                else if (str.StartsWith("ShowMovieControl="))
                {
                    this.ShowMovieControl = str.Replace("ShowMovieControl=", string.Empty);
                    continue;
                }

            }
        }
    }
}
