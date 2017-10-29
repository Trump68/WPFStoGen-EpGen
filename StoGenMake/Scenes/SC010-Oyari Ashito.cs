using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    class SC010_OyariAshito: BaseScene
    {
        public SC010_OyariAshito() : base()
        {
            Name = "SC010_OyariAshito";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            string src = null;
            string fn = null;
            int ss = 700;
            string gr = null;
            #region artist Hews Hack

            gr = "OyariAshito_KawaikuteShikatagaNai2";
            path = @"z:\ARTIST\Oyari Ashito\OyariAshito_KawaikuteShikatagaNai2\";
            for (int i = 1; i <= 20; i++)
            {
                src = $"OyariAshito_KawaikuteShikatagaNai2_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 20; i++)
            {
                src = $"OyariAshito_KawaikuteShikatagaNai2_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
        }
        protected override void MakeCadres(string cadregroup)
        {
            cadregroup = "OyariAshito_KawaikuteShikatagaNai2";
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
    }
}
