using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC005_Dtym : BaseScene
    {
 
        public SC005_Dtym() : base()
        {
            Name = "Dtym";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }


        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            path = @"x:\ARTIST\Dtym\DBR\";

            string dsc = "Dtym";
            string src = null;
            string fn = null;
            int ss = 700;
            for (int i = 1; i <= 6; i++)
            {
                src = $"Dtym BodyScene {i.ToString("D3")}";
                fn = $"Body_{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            }
        }

    }
}
