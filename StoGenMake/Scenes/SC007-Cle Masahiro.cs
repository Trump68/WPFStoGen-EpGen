using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenMake.GameWorld;

namespace StoGenMake.Scenes.Base
{
    public class SC007_CleMasahiro : BaseScene
    {

        public SC007_CleMasahiro() : base()
        {
            Name = "Cle Masahiro";
        }

        protected override void MakeCadres(string cadregroup)
        {
            cadregroup = "CleMasahiro CL-orz 51";
            base.MakeCadres(cadregroup);
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            //#region CL-orz 51
            string path = null;
            path = @"D:\Process2+\! Comix\Cle Masahiro\[Doujin] CL-orz 51\";
            
            string src = null;
            string fn = null;
            string gr = null;

            //#region Raw data
            //for (int i = 1; i <= 1; i++)
            //{
            //    src = $"CleMasahiro CL-orz 51 {i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
            //    AddToGlobalImage(src, fn, path, new DifData() { s = 800 });
            //    AddLocal(new string[] { "All raw data", $"Raw pic {i.ToString("D3")}" }, new DifData[] { new DifData(src) });
            //}
            //#endregion

            La01_CL_orz_51(path);
        }

        private void La01_CL_orz_51(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            string gr2 = null;
            int ss = 800;

            gr = "CleMasahiro CL-orz 51";
            gr2 = "CleMasahiro CL-orz 51 Global Align";

            //src = $"CleMasahiro CL-orz 51 001"; fn = $"001.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });

            src = $"CleMasahiro CL-orz 51 001 Body"; fn = $"002.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            
            src = $"CleMasahiro CL-orz 51 001 Head"; fn = $"003.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr2 },
                      new DifData[] {
                          new DifData(src),
                          new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src){  X = 340, Y = 465, s = 125, Rot=70, Flip=0 } });
           
            //AddLocal(
            // new string[] { gr },
            // new DifData[] {
            //    new DifData("CleMasahiro CL-orz 51 001 Head") { X = 75, Y = 20, s = 205, Flip=0},
            //    new DifData("FullsArt_NetorareTsuma_LadyMouth_001","CleMasahiro CL-orz 51 001 Head"),
            //    new DifData("CleMasahiro CL-orz 51 001 Body"),
            // });


        }

    }
}
