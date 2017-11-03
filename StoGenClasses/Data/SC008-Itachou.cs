using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC008_Itachou : BaseScene
    {
        public SC008_Itachou() : base()
        {
            Name = "SC008-Itachou";
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

            #region [Douin] 4years after
            string dsc = "[Douin] 4years after";
            path = @"Z:\ARTIST\Itachou\[Douin] 4years after\";
            gr = "[Douin] 4years after JPG";
            for (int i = 1; i <= 14; i++)
            {
                src = $"Itachou_Douin_4years_after_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            gr = "[Douin] 4years after PNG";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Itachou_Douin_4years_after_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion

            #region [Douin] Bad End de Peace
            gr = dsc = "[Douin] Bad End de Peace JPG";
            path = @"Z:\ARTIST\Itachou\[Douin] Bad End de Peace\";
            for (int i = 1; i <= 5; i++)
            {
                src = ($"{gr}_BodyScene_JPG_{i.ToString("D3")}").Replace(" ","_"); fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            gr = dsc = "[Douin] Bad End de Peace PNG";
            for (int i = 1; i <= 1; i++)
            {
                src = ($"{gr}_BodyScene_PNG_{i.ToString("D3")}").Replace(" ", "_"); ; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion

            #region [Douin] captive
            gr = dsc = "[Douin] captive PNG";
            path = @"Z:\ARTIST\Itachou\[Douin] captive\";
            for (int i = 1; i <= 5; i++)
            {
                src = ($"{gr}_BodyScene_PNG_{i.ToString("D3")}").Replace(" ", "_"); fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
        }

    }
}