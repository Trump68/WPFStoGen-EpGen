using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;
using StoGenMake.Pers;
using StoGenLife.SOUND;

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

        internal virtual void InitValues(List<VNPCVariable> variables)
        {
            var val = variables.Where(x => x.Name == this.Name && x.Part == this.Part).FirstOrDefault();
            if (val != null)
            {
                string fn = val.Value;
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
    public class ScenElementImage : ScenElement
    {
        public static ScenElementImage Previous = new ScenElementImage() {};
        public int SizeX = 900;
        public int SizeY = 600;
        public int SizeMode = 1;
        public int X = 0;
        public int Y = 0;
        public int Opacity = 100;
        public int Timer = -1;
        public override bool IsActivated { get { return (this == Previous) || (!string.IsNullOrEmpty(this.File)); } }
        internal override void ApplyData(string[] vals)
        {
            this.File = vals[1].Trim();
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
                result.Add($"{this.File.PadRight(20)}");
                result.Add($"SizeX={this.SizeX.ToString().PadRight(4)}");
                result.Add($"SizeY={this.SizeY.ToString().PadRight(4)}");
                result.Add($"SizeMode={this.SizeMode}");
                result.Add($"X={this.X.ToString().PadRight(4)}");
                result.Add($"Y={this.Y.ToString().PadRight(4)}");
                result.Add($"Opacity={this.Opacity.ToString().PadRight(3)}");
                if (this.Timer > 0) result.Add($"Timer={this.Timer.ToString().PadRight(7)}");
                if (!string.IsNullOrEmpty(this.Transition)) result.Add($"TRN={this.Transition}");               
            }
            return string.Join(";", result.ToArray());
        }

        internal void SetParamsFromScene(BaseScene scene)
        {
            this.SizeX = scene.SizeX;
            this.SizeY = scene.SizeY;
            this.X = scene.X;
            this.Y = scene.Y;
        }
    }

    public class ScenElementSound : ScenElement
    {
       
        public int V = 100;
        public string Group;
        public int StartPlay = -1;
        public override bool IsActivated { get { return !string.IsNullOrEmpty(this.File); } }
        internal override void ApplyData(string[] vals)
        {
            this.File = vals[1].Trim();
        }
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

