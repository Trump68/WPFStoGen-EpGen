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
            string gr = null; 

            gr = "Raw data";
            for (int i = 1; i <= 39; i++)
            {
                src = $"Dtym_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            gr = "Face";
            for (int i = 1; i <= 7; i++)
            {
                src = $"Dtym_Face_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            gr = "Body";
            for (int i = 8; i <= 13; i++)
            {
                src = $"Dtym_Body_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
           
        }

    }
}
