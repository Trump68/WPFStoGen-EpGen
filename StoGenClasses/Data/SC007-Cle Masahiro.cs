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
        protected override void LoadData()
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

            
            src = $"CleMasahiro CL-orz 51 001 LoveHeart"; fn = $"011.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            ss = 100; gr = "Mouth";
            src = $"CleMasahiro_CL_orz_51_001_Mouth";     fn = $"013.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });

            ss = 700;
            gr = "CleMasahiro CL-orz 51";
            src = $"CleMasahiro CL-orz 51 001 Body"; fn = $"002.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            src = $"CleMasahiro CL-orz 51 002 Body"; fn = $"005.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            src = $"CleMasahiro CL-orz 51 003 Body"; fn = $"010.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            src = $"CleMasahiro CL-orz 51 004 Body"; fn = $"014.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });

            src = $"CleMasahiro CL-orz 51 001 Head"; fn = $"003.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 110, Y = 147, S = 35, R=75, F=0 } });

            src = $"CleMasahiro CL-orz 51 002 Head"; fn = $"004.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 56, Y = 141, S = 30, R=35, F=1 } });

            src = $"CleMasahiro CL-orz 51 003 Head"; fn = $"006.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 129, Y = 166, S = 25, R=65, F=1 } });

            src = $"CleMasahiro CL-orz 51 004 Head"; fn = $"007.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 154, Y = 191, S = 30, R=20, F=0 } });

            src = $"CleMasahiro CL-orz 51 005 Head"; fn = $"008.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 19, Y = 121, S = 35, R=10, F=1 } });

            src = $"CleMasahiro CL-orz 51 006 Head"; fn = $"009.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 250, F=0},
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 91, Y = 105, S = 35, R=80, F=0 } });

            src = $"CleMasahiro CL-orz 51 007 Head"; fn = $"012.png"; AddToGlobalImage(src, fn, path, new DifData() { S = ss });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { X=0, Y=0, S = 700, F=0},
                      new DifData("CleMasahiro_CL_orz_51_001_Mouth", src)
                      { X = 450, Y = 530, S = 84, F=0 } });
            AddGlobal(new string[] { gr }, new DifData[] {
                      new DifData(src) { },
                      new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src)
                      { X = 454, Y = 509, S = 78, R=10, F=0 } });

        }

    }
}
