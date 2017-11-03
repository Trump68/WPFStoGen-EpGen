﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;
using StoGenMake.Pers;
using StoGenLife.SOUND;
using StoGenMake.Persona;

namespace StoGenMake.Elements
{
    public class ScenElement
    {

        public string Name { set; get; }
        public string Part { set; get; }
        public bool IsOptional { get; internal set; }
        public string File { get; internal set; }
        public string T { get; internal set; }
        public virtual bool IsActivated { get; } = true;

        internal virtual void ApplyData(string[] vals)
        {

        }
        internal virtual string GetElementData()
        {
            return string.Empty;
        }
        
    }
    public class seIm : ScenElement
    {
        public seIm(
            int x, int y, int sX, int sY, int rot, int opac,
            string file, string name = null) : this(file,name)
        {
            this.X = x;
            this.Y = y;
            this.Sx = sX;
            this.Sy = sY;
            this.R = rot;
            this.O = opac;
        }

        internal void Reset()
        {
          Sx = 500;
          Sy = 500;
          SizeMode = 1;
          X = 0;
          Y = 0;
          O = 100;
          Timer = -1;
          F = 0;
          R  = 0;
        }

        public seIm(string file, string name = null) : this()
        {            
            this.File = file;
            this.Name = name;
        }

        internal void AssignFrom(DifData dd)
        {
            if (dd == null) return;
            if (dd.X.HasValue) this.X = dd.X.Value;
            if (dd.Y.HasValue) this.Y = dd.Y.Value;
            if (dd.Sy.HasValue) this.Sy = dd.Sy.Value;
            if (dd.Sx.HasValue) this.Sx = dd.Sx.Value;
            if (dd.R.HasValue) this.R = dd.R.Value;
            if (dd.F.HasValue) this.F = dd.F.Value;
            if (dd.O.HasValue) this.O = dd.O.Value;
            if (!string.IsNullOrEmpty(dd.T)) this.T = dd.T;
        }

        public seIm() { }


        public static seIm Previous = new seIm() {};

        internal static string GetWhiteImage()
        {
            List<string> result = new List<string>();           
            result.Add($"AutoPics=WHITE");
            result.Add($"Level=-1");
            return string.Join(";", result.ToArray());
        }

        public int Sx = 900;
        public int Sy = 600;
        public int SizeMode = 1;
        public int X = 0;
        public int Y = 0;
        public int O = 100;
        public int Timer = -1;
        public int F = 0;
        public int R { get; internal set; } = 0;
        public override bool IsActivated { get { return (this == Previous) || (!string.IsNullOrEmpty(this.File)); } }

        public VNPCPersType PersonType { get; internal set; }
        public string Description { get; internal set; }
        public List<Tuple<string, int>> ParentRotations { get; internal set; } = new List<Tuple<string, int>>();
        public List<string> ParentFlips { get; internal set; } = new List<string>();
        public string ParRot
        {
            get
            {
                if (ParentRotations.Any())
                {
                    List<string> rez = new List<string>();
                    foreach (var item in ParentRotations)
                    {
                        rez.Add($"{item.Item1}@{item.Item2}");
                    }
                    return string.Join(",", rez.ToArray());
                }
                return string.Empty;
            }
        }
        public string ParFlip
        {
            get
            {
                if (ParentFlips.Any())
                {
                    List<string> rez = new List<string>();
                    foreach (var item in ParentFlips)
                    {
                        rez.Add($"{item}");
                    }
                    return string.Join(",", rez.ToArray());
                }
                return string.Empty;
            }
        }
        internal override string GetElementData()
        {           
            List<string> result = new List<string>();
            if (this == Previous)
            {
                result.Add($"AutoPics=PREVIOUS");
            }
            else
            {
                result.Add($"AutoPics={this.File.PadRight(20)}");
                result.Add($"SizeX={this.Sx.ToString().PadRight(4)}");
                result.Add($"SizeY={this.Sy.ToString().PadRight(4)}");
                result.Add($"SizeMode={this.SizeMode}");
                result.Add($"X={(this.X).ToString().PadRight(4)}");
                result.Add($"Y={(this.Y).ToString().PadRight(4)}");
                result.Add($"Rot={this.R.ToString().PadRight(4)}");
                result.Add($"Opacity={this.O.ToString().PadRight(3)}");
                result.Add($"Flip={this.F.ToString().PadRight(3)}");
                result.Add($"Name={this.Name.PadRight(3)}");

                if (this.Timer > 0) result.Add($"Timer={this.Timer.ToString().PadRight(7)}");
                if (!string.IsNullOrEmpty(this.T)) result.Add($"TRN={this.T}");   
                if (this.ParentRotations.Any()) result.Add($"ParRot={this.ParRot}");
                if (this.ParentFlips.Any())
                    result.Add($"ParFlip={this.ParFlip}");
            }
            return string.Join(";", result.ToArray());
        }

        internal void AssignFrom(seIm image)
        {
            this.O = image.O;
            this.F = image.F;
            this.SizeMode = image.SizeMode;
            this.Sx = image.Sx;
            this.Sy = image.Sy;
            this.X = image.X;
            this.Y = image.Y;
            this.R = image.R;
            this.Part = image.Part;
            this.File = image.File;
            this.Name = image.Name;
            this.T = image.T;
            this.ParentRotations.Clear();
            this.ParentRotations.AddRange(image.ParentRotations);
            this.ParentFlips.Clear();
            this.ParentFlips.AddRange(image.ParentFlips);

        }




    }

    public class ScenElementSound : ScenElement
    {
       
        public int V = 100;
        public string Group;
        public int StartPlay = -1;
        public override bool IsActivated { get { return !string.IsNullOrEmpty(this.File); } }
        internal override string GetElementData()
        {
            //#014 #;SizeX=800;SizeY=600;SizeMode=1;X=300;Timer=16000;Opacity=0;TRN=O.B.5000.100
            List<string> result = new List<string>();
            result.Add($"{this.File.PadRight(20)}");
            result.Add($"v={this.V.ToString().PadRight(4)}");
            if (!string.IsNullOrEmpty(this.Group))
                result.Add($"Group={this.Group.PadRight(4)}");
            if (StartPlay > -1) result.Add($"Start={this.StartPlay.ToString().PadRight(4)}");
            if (!string.IsNullOrEmpty(this.T)) result.Add($"TRN={this.T}");
            return string.Join(";", result.ToArray());
        }       
    }

    public class seTe : ScenElement
    {
        public string Text;
        public int Width = 0;
        public int Shift = 0;
        public int Size = 600;
        public int FontSize = 25;
        public int Opacity = 100;
        public int Bottom = 0;
        public bool AutoShow = true;
        public bool ClearBack = true;
        public string FontColor = "Yellow";
        public string FontName;
        public string Tran;


        public seTe() : base() { }
        public seTe(seTe origin):this()
        {
            this.Text = origin.Text;
            this.Shift = origin.Shift;
            this.Size = origin.Size;
            this.Width = origin.Width;
            this.Tran = origin.Tran;
            this.FontSize = origin.FontSize;
            this.Opacity = origin.Opacity;
            this.Bottom = origin.Bottom;
            this.FontColor = origin.FontColor;
            this.FontName = origin.FontName;
            this.AutoShow = origin.AutoShow;
            this.ClearBack = origin.ClearBack;
        }

       

        public override bool IsActivated { get { return !string.IsNullOrEmpty(this.Text); } }
        internal override string GetElementData()
        {            
            List<string> result = new List<string>();
            result.Add($"CadreText=;~={this.Text}");
            result.Add($"Opacity={this.Opacity}");
            result.Add($"FontSize={this.FontSize}");
            result.Add($"Shift={this.Shift}");
            result.Add($"Width={this.Width}");
            result.Add($"Size={this.Size}");
            result.Add($"Bottom={this.Bottom}");

            if (this.AutoShow)
                result.Add($"AutoShow={1}");
            else
                result.Add($"AutoShow={0}");

            if (this.ClearBack)
                result.Add($"ClearBack={1}");
            else
                result.Add($"ClearBack={0}");
            if (!string.IsNullOrEmpty(this.T)) result.Add($"TRN={this.T}");
            if (!string.IsNullOrEmpty(this.FontColor)) result.Add($"FontColor={this.FontColor}");
            if (!string.IsNullOrEmpty(this.FontName)) result.Add($"FontName={this.FontName}");
            return string.Join(";", result.ToArray());
        }
    }
}

