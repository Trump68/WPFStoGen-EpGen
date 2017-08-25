using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class Scene01: BaseScene
    {
        private int Version = 0;
        public Scene01() : base()
        {
            this.Name = "Scen Kiss 01";            
        }
        public override void InitCadres()
        {
            ScenCadreKissStart cadre = new ScenCadreKissStart(this);            
            this.Cadres.Add(cadre);
        }
        public override List<string> GetTemplate()
        {
            List<string> result = new List<string>();
            result.Add($"SCEN {this.Name}, Ver={this.Version}, Location={this.X},{this.Y},{this.SizeX},{this.SizeY}");
            result.Add($"//===========================//");
            result.AddRange(base.GetTemplate());
            return result;
        }
        public override List<string> GetSceneData()
        {
            List<string> result = new List<string>();
            foreach (var item in this.Cadres)
            {
                result.AddRange(item.GetCadreData());
            }            
            return result;
        }
    }

    public class ScenCadreKissStart : ScenCadre
    {        

        public ScenCadreKissStart(BaseScene owner):base(owner)
        {
            this.Name = "Kiss start";

            ScenElementImage image;

            //#014 #;SizeX=800;SizeY=600;SizeMode=1;X=300;Timer=16000;Opacity=0;TRN=O.B.5000.100
            image = new ScenElementImage();
            image.SetSizeFromScene(this.Owner);
            image.Name = "Main face";
            image.IsOptional = false;
            image.File = "#Pic01  #";
            image.Opacity = 0;
            image.Transition = "O.B.5000.100";            
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetSizeFromScene(this.Owner);
            image.Name = "Main face-blink";
            image.IsOptional = true;
            image.File = "#Pic01_a#";
            this.VisionList.Add(image);

        }
        internal override IEnumerable<string> GetTemplate()
        {
            List<string> result = new List<string>();

            result.Add($"CADRE {this.Name}");

            foreach (var item in this.VisionList)
            {
                result.Add(item.GetTemplate());
            }
            return result;
        }

        public override List<string> GetCadreData()
        {
            List<string> result = new List<string>();
            result.Add($"PartSta# {this.Name.PadRight(100)}");

            foreach (var item in this.VisionList)
            {
                result.Add(" "+item.GetElementData());
            }

            result.Add($"PartEnd#");
            return result;
        }

    }
}
