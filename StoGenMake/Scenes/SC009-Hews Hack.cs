using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    class SC009_Hews_Hack : BaseScene
    {
        public SC009_Hews_Hack() : base()
        {
            Name = "SC000-Various";
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


            string src = null;
            string fn = null;
            int ss = 700;
            string gr = null;
            #region artist Hews Hack

            gr = "artist Hews Hack PNG";
            path = @"Z:\ARTIST\Hews Hack\DBR\";
            for (int i = 1; i <= 20; i++)
            {
                if (i == 9) continue;
                src = $"Hews_Hack_BodyScene_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            gr = "artist Hews Hack PNG Cock";
            src = $"Hews_Hack_BodyScene_PNG_Cock_002"; fn = $"002_COCK.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Hews_Hack_BodyScene_PNG_Cock_001"; fn = $"001_COCK.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                 new DifData("Hews_Hack_BodyScene_PNG_Cock_001") { },
                 new DifData("Hews_Hack_BodyScene_PNG_Cock_002", "Hews_Hack_BodyScene_PNG_Cock_001")
                 {},
            });
            src = $"Hews_Hack_BodyScene_PNG_Cock_003"; fn = $"003_COCK.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Hews_Hack_BodyScene_PNG_Cock_004"; fn = $"004_COCK.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Hews_Hack_BodyScene_PNG_Cock_005"; fn = $"004_COCK.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Hews_Hack_BodyScene_PNG_Flower_001"; fn = $"001_Flower.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = ss });

            AddGlobal(new string[] { gr }, new DifData[] {
                 new DifData("Hews_Hack_BodyScene_PNG_008") { },
                 new DifData("Hews_Hack_BodyScene_PNG_010", "Hews_Hack_BodyScene_PNG_008")
                 {X = 303, Y = 461, s = 425, Flip=0},
            });
            #endregion
        }
    }
}
