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
    public class SC006_Erotibot : BaseScene
    {  
        public SC006_Erotibot() : base()
        {
            Name = "Erotibot";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }


        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
        protected override void LoadData()
        {
            string path = null;


            path = @"Z:\ARTIST\Erotibot\DBR\";

            string dsc = "Erotibot";
            string src = null;
            string fn = null;

            int ss = 700;
            for (int i = 1; i <= 9; i++)
            {
                if (i == 8) continue;
                src = $"Erotibot BodyScene {i.ToString("D3")}";
                fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            }
        }

    }
}
