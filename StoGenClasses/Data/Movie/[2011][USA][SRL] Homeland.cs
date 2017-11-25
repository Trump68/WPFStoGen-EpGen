using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _2011_USA_SRL_Homeland : BaseScene
    {
        private string CurrentGr;

        int S1 = 800;
        int S2 = 800;
        int S3 = 800;
        int X1 = 0;
        int X2 = 0;
        int X3 = 0;
        int Y1 = 0;
        int Y2 = 0;
        int Y3 = 0;
        int Z1 = 1;
        int Z2 = 2;
        int Z3 = 3;
        int MODE = 0;
        string text = string.Empty;
        int Rate = 100;
        protected override void LoadData()
        {
            string path = @"d:\uTorrent\Homeland\Season 1\";
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            
            string src;
            int i = 1;
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e01.xvid.bdrip.lostfilm.[qqss44] 0001.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e01.xvid.bdrip.lostfilm.[qqss44] 0002.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e01.xvid.bdrip.lostfilm.[qqss44] 0006.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e01.xvid.bdrip.lostfilm.[qqss44] 0007.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e02.xvid.bdrip.lostfilm.[qqss44] 0003.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e02.xvid.bdrip.lostfilm.[qqss44] 0004.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e02.xvid.bdrip.lostfilm.[qqss44] 0005.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e02.xvid.bdrip.lostfilm.[qqss44] 0007.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e03.xvid.bdrip.lostfilm.[qqss44] 0002.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e03.xvid.bdrip.lostfilm.[qqss44] 0003.m4v", path);
            src = $"2011_USA_SRL_Homeland_{(i++).ToString("D4")}";
            AddToGlobalImage(src, "Homeland.s01e03.xvid.bdrip.lostfilm.[qqss44] 0005.m4v", path);
            path = @"d:\temp\";
            src = $"woho1";
            AddToGlobalImage(src, "1.png", path);
            Scene1();
            Scene2();
            Scene3();
            Scene4();
            Scene5();
            Scene6();
            Scene7();
            Scene8();
            Scene9();
            Scene10();
            Scene11();
        }
        private void Scene1()
        {
            CurrentGr = "Scene1";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0001";
            Rate = 80;
            AC(file, new AP() { APS = 000.15, APE = 003.30 });//fuck
            AC(file, new AP() { APS = 003.30, APE = 007.1 });//fuck
            AC(file, new AP() { APS = 007.20, APE = 035.3 });//fuck

            AC(file, new AP() { APS = 07.10, APE = 048.7 });
            AC(file, new AP() { APS = 042.60, APE = 045.3 });
            AC(file, new AP() { APS = 048.90, APE = 077.8 });
            AC(file, new AP() { APS = 078.00, APE = 080.9 });

            //AddMusic("music.arc_000003.wav");
            //AddMusic("music.arc_000007.wav");
            //AddMusic("music.arc_000010.wav");
            AddMusic("music.arc_000008.wav");
            AC(file, new AP() { APS = 000.15, APE = 003.30 }
                   , new AP() { APS = 003.30, APE = 007.1, ALM = 3, ALC = 6 }
                   , new AP() { APS = 007.10, APE = 020.60, ALM = 2 });//super fuck
        }
        private void Scene2()
        {
            CurrentGr = "Scene2";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0002";
            Rate = 80;
            //AC(file, new AP() { APS = 000.00, APE = 012.7 });
            //AC(file, new AP() { APS = 025.20, APE = 027.4 });
            //AC(file, new AP() { APS = 033.50, APE = 035.4 });
            //AC(file, new AP() { APS = 039.10, APE = 042.4 });

            AC(file, new AP() { APS = 000.00, APE = 012.7 },
            new AP() { APS = 025.20, APE = 027.4 },
            new AP() { APS = 033.50, APE = 035.4 },
            new AP() { APS = 039.10, APE = 042.4 });
        }
        private void Scene3()
        {
            CurrentGr = "Scene3";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0003";
            AddMusic("music.arc_000003.wav");
            Rate = 90;
            AC(file, new AP() { APS = 000.00, APE = 006.9, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 030.00, APE = 032.4, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 038.50, APE = 046.0, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 055.00, APE = 060.8, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 065.70, APE = 071.4, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 079.40, APE = 081.2, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 094.20, APE = 118.7, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 121.00, APE = 131.8, ALM = 3, ALC = 3 });
            AC(file, new AP() { APS = 137.90, APE = 150.5});
            AC(file, new AP() { APS = 197.50, APE = 203.4 });
            AC(file, new AP() { APS = 208.00, APE = 217.1 });
            AC(file, new AP() { APS = 221.70, APE = 230.1 });
            AC(file, 
                new AP() { APS = 224.90, APE = 227.7, ALM = 3, ALC = 3 },
                new AP() { APS = 227.80, APE = 230.1, ALM = 3, ALC = 7 },
                new AP() { APS = 239.80, APE = 241.6, ALM = 3, ALC = 7 },
                new AP() { APS = 249.20, APE = 260.2 },
                new AP() { APS = 267.50, APE = 276.0, ALM = 2 }
                );//super fuck
            
        }
        private void Scene4()
        {
            CurrentGr = "Scene4";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0004";
            Rate = 80;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 000.00, APE = 018.3 });
            Rate = 50;
            AC(file, 
                new AP() { APS = 020.70, APE = 022.0 },
                new AP() { APS = 021.30, APE = 022.0, ALM = 3, ALC = 6 },
                new AP() { APS = 021.30, APE = 022.0, ALM = 2 }
                );
            AC(file, new AP() { APS = 028.20, APE = 037.9 });
            AC(file, new AP() { APS = 046.30, APE = 051.7, ALM = 3, ALC = 6 }); /// face expression!!!
            AC(file, new AP() { APS = 056.2, APE = 058.8, ALM = 3, ALC = 6 }); /// face expression!!!
        }
        private void Scene5()
        {
            CurrentGr = "Scene5";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0005";
            Rate = 100;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 008.50, APE = 010.3, ALM = 3, ALC = 6 });
           
        }
        private void Scene6()
        {
            CurrentGr = "Scene6";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0006";
            Rate = 75;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 029.20, APE = 037.3, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 042.20, APE = 048.6, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 050.30, APE = 053.0, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 064.90, APE = 068.0, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 071.80, APE = 075.0, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 101.70, APE = 104.5, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 106.30, APE = 109.9, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 113.80, APE = 118.7, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 122.4, APE = 125.8, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 128.4, APE = 146.1, ALM = 3, ALC = 6 });
        }
        private void Scene7()
        {
            CurrentGr = "Scene7";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0007";
            Rate = 75;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 11.5, APE = 017.4, ALM = 3, ALC = 6 }); //fuck
            AC(file, new AP() { APS = 17.60, APE = 019.6, ALM = 3, ALC = 6 }); //fuck
            AC(file, 
                new AP() { APS = 17.60, APE = 018.5, ALM = 3, ALC = 6 }
              , new AP() { APS = 18.70, APE = 019.6, ALM = 3, ALC = 6 }
            );//fuck
        }
        private void Scene8()
        {
            CurrentGr = "Scene8";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0008";
            Rate = 100;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 003.30, APE = 004.7, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 023.00, APE = 026.5, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 028.60, APE = 030.2, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 043.40, APE = 045.8, ALM = 3, ALC = 6 });
        }
        private void Scene9()
        {
            CurrentGr = "Scene9";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0009";
            Rate = 100;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 104.10, APE = 111.7, ALM = 3, ALC = 6 });
        }
        private void Scene10()
        {
            CurrentGr = "Scene10";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0010";
            Rate = 100;
            AddMusic("music.arc_000005.wav");
            AC(file, 
                new AP() { APS = 000.10, APE = 007.2 },
                new AP() { APS = 010.10, APE = 028.2 });
            AC(file, new AP() { APS = 033.30, APE = 036.0, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 041.10, APE = 077.2, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 095.80, APE = 0114.4, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 114.70, APE = 0127.8, ALM = 3, ALC = 6 });// naked
            AC(file, new AP() { APS = 126.90, APE = 0127.8, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 121.70, APE = 0127.8, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 136.80, APE = 0142.0, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 142.20, APE = 0170.7, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 170.90, APE = 0178.8, ALM = 3, ALC = 6 });//naked !!
            AC(file, new AP() { APS = 197.10, APE = 0236.9, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 226.60, APE = 0236.9, ALM = 3, ALC = 6 });//naked
            AC(file, new AP() { APS = 216.20, APE = 0221.6, ALM = 3, ALC = 6 });//naked
        }
        private void Scene11()
        {
            CurrentGr = "Scene11";
            MODE = 1;
            string file = "2011_USA_SRL_Homeland_0011";
            Rate = 100;
            AddMusic("music.arc_000005.wav");
            AC(file, new AP() { APS = 124.4, APE = 176.0, ALM = 3, ALC = 6 });
            AC(file, new AP() { APS = 02.5, APE = 061.3, ALM = 3, ALC = 6 }); //fuck 
            AC(file, new AP() { APS = 02.5, APE = 017.7, ALM = 3, ALC = 6 }); //fuck !!!
        }
        private void AC(string n,params AP[] animations)
        {
            List<DifData> cdata;
            cdata = new List<DifData>();
            List<AP> al = new List<AP>();
            al.AddRange(animations);
            al.ForEach(x => { x.AR = Rate; x.AV = 0; if (x.ALM < 0) x.ALM = MODE; });
            cdata.Add(new DifData(n) { S = S1, X = X1, Y = Y1, AL = al });
            //cdata.Add(new DifData("woho1") { X = -135, Y = -135, S = 1120, F = 0 });
            AddLocal(CurrentGr, text, cdata, this.CurrentSounds);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Scene11"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
