﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;
using StoGenMake.Pers;
using StoGenLife.SOUND;
using StoGenMake.Entity;

namespace StoGenMake.Elements
{
    public class ScenElement
    {

        public string Name { set; get; }
        public string Part { set; get; }
        public bool IsOptional { get; internal set; }
        public string File { get; internal set; }
        public string Transition { get; internal set; }
        public virtual bool IsActivated { get; } = true;

        internal virtual void ApplyData(string[] vals)
        {

        }
        internal virtual string GetElementData()
        {
            return string.Empty;
        }

        internal virtual void InitValues(List<EntityVariable> variables)
        {
            var val = variables.Where(x => x.Group == this.Name && x.Part == this.Part).FirstOrDefault();
            if (val != null)
            {
                string fn = val.Image.File;
                if (val.Type == "SOUND")
                {
                    string soundval = SoundStore.ValByName(fn);
                    if (!string.IsNullOrEmpty(soundval))
                        fn = soundval;
                }
                this.File = fn;
            }
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
            this.sX = sX;
            this.sY = sY;
            this.Rot = rot;
            this.Opa = opac;
        }

        internal void Reset()
        {
          sX = 500;
          sY = 500;
          SizeMode = 1;
          X = 0;
          Y = 0;
          Opa = 100;
          Timer = -1;
          Flip = 0;
          Rot  = 0;
        }

        public seIm(string file, string name = null) : this()
        {            
            this.File = file;
            this.Name = name;
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

        public int sX = 900;
        public int sY = 600;
        public int SizeMode = 1;
        public int X = 0;
        public int Y = 0;
        public int Opa = 100;
        public int Timer = -1;
        public int Flip = 0;
        public int Rot { get; internal set; } = 0;
        public override bool IsActivated { get { return (this == Previous) || (!string.IsNullOrEmpty(this.File)); } }

        public VNPCPersType PersonType { get; internal set; }
        public string Description { get; internal set; }
        public List<Tuple<string, int>> ParentRotations { get; internal set; } = new List<Tuple<string, int>>();
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
                result.Add($"SizeX={this.sX.ToString().PadRight(4)}");
                result.Add($"SizeY={this.sY.ToString().PadRight(4)}");
                result.Add($"SizeMode={this.SizeMode}");
                result.Add($"X={(this.X).ToString().PadRight(4)}");
                result.Add($"Y={(this.Y).ToString().PadRight(4)}");
                result.Add($"Rot={this.Rot.ToString().PadRight(4)}");
                result.Add($"Opacity={this.Opa.ToString().PadRight(3)}");
                result.Add($"Flip={this.Flip.ToString().PadRight(3)}");
                
                if (this.Timer > 0) result.Add($"Timer={this.Timer.ToString().PadRight(7)}");
                if (!string.IsNullOrEmpty(this.Transition)) result.Add($"TRN={this.Transition}");   
                if (this.ParentRotations.Any()) result.Add($"ParRot={this.ParRot}");
            }
            return string.Join(";", result.ToArray());
        }

        internal void AssinFrom(seIm image)
        {
            this.Opa = image.Opa;
            this.Flip = image.Flip;
            this.SizeMode = image.SizeMode;
            this.sX = image.sX;
            this.sY = image.sY;
            this.X = image.X;
            this.Y = image.Y;
            this.Rot = image.Rot;
            this.Part = image.Part;
            this.File = image.File;
            this.Name = image.Name;
            this.Transition = image.Transition;
            this.ParentRotations.AddRange(image.ParentRotations);

            //im.Flip = sr.Flip;
            //im.Opa= sr.Opa;
            //im.Part = sr.Part;
            //im.Rot = sr.Rot;
            //im.SizeMode = sr.SizeMode;
            //im.sX = sr.sX;
            //im.sY = sr.sY;
            //im.Timer = sr.Timer;
            //im.Transition = sr.Transition;
            //im.X = sr.X;
            //im.Y = sr.Y;
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
            if (!string.IsNullOrEmpty(this.Transition)) result.Add($"TRN={this.Transition}");
            return string.Join(";", result.ToArray());
        }       
    }

    public class ScenElementText : ScenElement
    {
        public string Text;
        public override bool IsActivated { get { return !string.IsNullOrEmpty(this.Text); } }
        internal override string GetElementData()
        {            
            List<string> result = new List<string>();
            result.Add($"{this.Text}");            
            if (!string.IsNullOrEmpty(this.Transition)) result.Add($"TRN={this.Transition}");
            return string.Join(";", result.ToArray());
        }
    }
}

