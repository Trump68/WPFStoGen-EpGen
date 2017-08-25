using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;

namespace StoGenMake.Elements
{
    public class ScenElement
    {
        public string Name { set; get; }
        public bool IsOptional { get; internal set; }
        public string File { get; internal set; }
        public string Transition { get; internal set; }
        internal virtual string GetTemplate()
        {
            return null;
        }

    }

    public class ScenElementImage : ScenElement
    {
        public int SizeX = 900;
        public int SizeY = 600;
        public int SizeMode = 1;
        public int X = 0;
        public int Y = 0;
        public int Opacity = 100;

        

        internal override string GetTemplate()
        {
            string strpart = this.Name + ";";
            if (this.IsOptional) strpart = strpart + " optional;";
            return $"    IMAGE {strpart.PadRight(50)}{this.File}";
        }

        internal string GetElementData()
        {
            //#014 #;SizeX=800;SizeY=600;SizeMode=1;X=300;Timer=16000;Opacity=0;TRN=O.B.5000.100
            List<string> result = new List<string>();
            result.Add($"{this.File.PadRight(20)}");
            result.Add($"SizeX={this.SizeX.ToString().PadRight(4)}");
            result.Add($"SizeY={this.SizeY.ToString().PadRight(4)}");
            result.Add($"SizeMode={this.SizeMode}");            
            result.Add($"X={this.X.ToString().PadRight(4)}");
            result.Add($"Y={this.Y.ToString().PadRight(4)}");
            result.Add($"Opacity={this.Opacity.ToString().PadRight(3)}");
            if (!string.IsNullOrEmpty(this.Transition)) result.Add($"TRN={this.Transition}");
            return string.Join(";", result.ToArray());
        }

        internal void SetSizeFromScene(BaseScene scene)
        {
            this.SizeX = scene.SizeX;
            this.SizeY = scene.SizeY;
            this.X = scene.X;
            this.Y = scene.Y;
        }
    }

    public class ScenElementSound: ScenElement
    {
    }

    public class ScenElementText: ScenElement
    {
    }

}
