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
            
            string src = null;
            string fn = null;
            string gr = null;

            path = @"D:\Process2+\! Comix\Cle Masahiro\[Doujin] CL-orz 51\";
            La01_CL_orz_51(path);
        }

        private void La01_CL_orz_51(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 250;

            gr = "CleMasahiro CL-orz 51";
            src = $"CleMasahiro CL-orz 51 001 Body"; fn = $"002.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"CleMasahiro CL-orz 51 002 Body"; fn = $"005.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });

            src = $"CleMasahiro CL-orz 51 001 Head"; fn = $"003.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 110, Y = 147, s = 35, Rot=75, Flip=0 } });

            src = $"CleMasahiro CL-orz 51 002 Head"; fn = $"004.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 56, Y = 141, s = 30, Rot=35, Flip=1 } });
        }

    }
}
