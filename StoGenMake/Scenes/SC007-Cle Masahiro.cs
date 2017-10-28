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
            EngineHiVer = 1;
            EngineLoVer = 0;
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

            int ss = 100;
            gr = "Other";

            
            src = $"CleMasahiro CL-orz 51 001 LoveHeart"; fn = $"011.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            ss = 100; gr = "Mouth";
            src = $"CleMasahiro_CL_orz_51_001_Mouth";     fn = $"013.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });

            ss = 700;
            gr = "CleMasahiro CL-orz 51";
            src = $"CleMasahiro CL-orz 51 001 Body"; fn = $"002.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"CleMasahiro CL-orz 51 002 Body"; fn = $"005.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"CleMasahiro CL-orz 51 003 Body"; fn = $"010.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"CleMasahiro CL-orz 51 004 Body"; fn = $"014.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });

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

            src = $"CleMasahiro CL-orz 51 003 Head"; fn = $"006.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 129, Y = 166, s = 25, Rot=65, Flip=1 } });

            src = $"CleMasahiro CL-orz 51 004 Head"; fn = $"007.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 154, Y = 191, s = 30, Rot=20, Flip=0 } });

            src = $"CleMasahiro CL-orz 51 005 Head"; fn = $"008.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 19, Y = 121, s = 35, Rot=10, Flip=1 } });

            src = $"CleMasahiro CL-orz 51 006 Head"; fn = $"009.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 250, Flip=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 91, Y = 105, s = 35, Rot=80, Flip=0 } });

            src = $"CleMasahiro CL-orz 51 007 Head"; fn = $"012.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, s = 700, Flip=0},
                      new DifData("CleMasahiro_CL_orz_51_001_Mouth", src)
                      { X = 450, Y = 530, s = 84, Flip=0 } });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { },
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 454, Y = 509, s = 78, Rot=10, Flip=0 } });

        }

    }
}
