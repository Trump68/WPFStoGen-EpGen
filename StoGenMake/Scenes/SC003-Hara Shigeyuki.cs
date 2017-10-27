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

            string gr = "Lady face";
            // faces
            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Hara Shigeyuki\";
            for (int i = 1; i < 6; i++)
            {                
                src = $"HaraShigeyuki_AbunaiHitozuma_LadyFace_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            //Bodies and scenes
            gr = "Raw data";
            path = @"x:\DOUJIN\Hara Shigeyuki\Abunai Hitozuma - Shouko no Bouken\";
            for (int i = 5; i <= 8; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_SceneBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 9; i <= 23; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_SceneBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 25; i <= 271; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_SceneBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }


            // evil man body
            gr = "evil man body";
            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            for (int i = 1; i <= 4; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_EvilManBody_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            // evil man face
            gr = "evil man face";
            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            for (int i = 5; i <= 9; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_EvilManFace_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            
            for (int i = 1; i <= 3; i++)
            {
                src = $"HaraShigeyuki_AbunaiHitozuma_EvilManFace_a{i.ToString("D3")}"; fn = $"{i.ToString("D3")}a.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
        }
    }

}
