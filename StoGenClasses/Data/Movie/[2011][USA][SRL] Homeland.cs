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
            Scene1();
            Scene2();
            Scene3();
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
                new AP() { APS = 227.80, APE = 230.1, ALM = 3, ALC = 7 }
                );//super fuck
            
        }
        private void AC(string n,params AP[] animations)
        {
            List<DifData> cdata;
            cdata = new List<DifData>();
            List<AP> al = new List<AP>();
            al.AddRange(animations);
            al.ForEach(x => { x.AR = Rate; x.AV = 0; if (x.ALM < 0) x.ALM = MODE; });
            cdata.Add(new DifData(n) { S = S1, X = X1, Y = Y1, AL = al });
            AddLocal(CurrentGr, text, cdata, this.CurrentSounds);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Scene3"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
