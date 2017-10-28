using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class SC003_HaraShigeyuki : BaseScene
    {
     
        public SC003_HaraShigeyuki() : base()
        {
            Name = "Hara Shigeyuki";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);            
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            #region Abunai Hitozuma - Shouko no Bouken
            int ss = 995;
            string path = null;
            string fn;
            string src;

            string gr = "Row data";

            //Bodies and scenes
            gr = "Raw data";
            path = @"x:\DOUJIN\Hara Shigeyuki\Abunai Hitozuma - Shouko no Bouken\";
            for (int i = 1; i <= 10; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_SceneBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            for (int i = 1; i <= 262; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_SceneBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
         

            // evil man body face
            gr = "evil man body face";
            path = @"x:\DOUJIN\Hara Shigeyuki\Abunai Hitozuma - Shouko no Bouken\";
            for (int i = 11; i <= 22; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_EvilManBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            #endregion
        }
    }

}
