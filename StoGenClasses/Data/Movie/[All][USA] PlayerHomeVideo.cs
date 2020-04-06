using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _All__USA__PlayerHomeVideo : BaseScene
    {
        protected override void LoadData()
        {
            string path = @"d:\uTorrent\! Player Home Video\";
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            string src;
            src = $"American Pinup Girls (1997).m4v";
            AddToGlobalImage(src, src, path);
            src = $"Beverly Hills Workout (1993).m4v";
            AddToGlobalImage(src,src, path);
            src = $"Biker Dreams (1995).m4v";
            AddToGlobalImage(src, src, path);
            src = $"Biker Fantasies(1994).m4v";
            AddToGlobalImage(src, src, path);

            USA_1997_American_Pinup_Girls();
            USA_1993_Beverly_Hills_Workout();
            USA_1995_Biker_Dreams();
            USA_1994_Biker_Fantasies();
        }
        private void USA_1997_American_Pinup_Girls()
        {
            Scene_Clips st = new Scene_Clips();
            st.currentGr = "American Pinup Girls (1997).m4v";
            int speed = 100;
            List<AP> anims = new List<AP>()
            {
                //1 !!!!
                 new AP("American Pinup Girls (1997).m4v") { APS = 504.0, APE = 509.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 509.7, APE = 531.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 532.2, APE = 563.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 572.2, APE = 585.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 585.9, APE = 592.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 592.8, APE = 603.8, ALM = 3, ALC = 6 , AR=speed},
                 //2
                 new AP("American Pinup Girls (1997).m4v") { APS = 1031.1, APE = 1060.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1064.6, APE = 1073.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1074.3, APE = 1084.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1087.0, APE = 1105.7, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1110.3, APE = 1117.0, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1118.0, APE = 1125.3, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1129.9, APE = 1133.4, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1133.7, APE = 1142.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1177.7, APE = 1192.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1210.1, APE = 1221.5, ALM = 3, ALC = 6 , AR=speed},
                 //3
                 new AP("American Pinup Girls (1997).m4v") { APS = 1828.7, APE = 1846.1, ALM = 3, ALC = 6 , AR=speed},
                 new AP("American Pinup Girls (1997).m4v") { APS = 1846.3, APE = 1891.1, ALM = 3, ALC = 6 , AR=speed},


            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void USA_1993_Beverly_Hills_Workout()
        {
            Scene_Clips st = new Scene_Clips();
            st.currentGr = "Beverly Hills Workout (1993).m4v";
            int speed = 75;
            List<AP> anims = new List<AP>()
            {
                
               
                //1 Cool brunette, short hair (I)
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 231.3, APE = 240.1, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1444.0, APE = 1453, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1464.3, APE = 1466.7, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1472.1, APE = 1480.1, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2505.4, APE = 2523.4, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2526.5, APE = 2537.3, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2539.3, APE = 2545.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2545.9, APE = 2556.3, ALM = 3, ALC = 6 , AR=speed},

                
                 //2 Luxury blonde, long hair (I)
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 609.1, APE = 615.7, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 619.4, APE = 624.0, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 632.8, APE = 638.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 662.5, APE = 666.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1800.0, APE = 1810.4, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1810.7, APE = 1813.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1814.2, APE = 1819.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1822.7, APE = 1830.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 1839.0, APE = 1843.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2904.4, APE = 2915.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2916.2, APE = 2922.8, ALM = 3, ALC = 6 , AR=speed},
                 
                 //3 Luxury blonde, long hair (II)
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2103.8, APE = 2111.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2125.6, APE = 2133.2, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2147.5, APE = 2150.2, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2181.4, APE = 2190.6, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 2978.8, APE = 2984.0, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 3026.0, APE = 3029.5, ALM = 3, ALC = 6 , AR=speed},

                 //4 Luxury auburn, long hair (III)
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 3215.7, APE = 3233.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Beverly Hills Workout (1993).m4v") { APS = 3277, APE = 3289, ALM = 3, ALC = 6 , AR=speed},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void USA_1995_Biker_Dreams()
        {
            Scene_Clips st = new Scene_Clips();
            st.currentGr = "Biker Dreams (1995).m4v";
            int speed = 125;
            List<AP> anims = new List<AP>()
            {                               
                 //1 Brunette, long hair
                 new AP(currentGr) { APS = 497.5, APE = 556.7, ALM = 3, ALC = 6 , AR=speed},
                 new AP(currentGr) { APS = 557, APE = 613, ALM = 3, ALC = 6 , AR=speed},
                 new AP(currentGr) { APS = 1723, APE = 1878, ALM = 3, ALC = 6 , AR=speed},
                 //2 Brunette, long hair
                 new AP(currentGr) { APS = 2422, APE = 2439, ALM = 3, ALC = 6 , AR=speed},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void USA_1994_Biker_Fantasies()
        {
            Scene_Clips st = new Scene_Clips();
            st.currentGr = "Biker Fantasies (1994).m4v";
            int speed = 100;
            List<AP> anims = new List<AP>()
            {                               
                 //1 Auburn, long hair
                 new AP(currentGr) { APS = 208.4, APE = 226, ALM = 3, ALC = 6 , AR=speed},
                 new AP(currentGr) { APS = 1698.5, APE = 1866.5, ALM = 3, ALC = 6 , AR=speed},
                 //2 Black, long hair
                 new AP(currentGr) { APS = 899.7, APE = 913, ALM = 3, ALC = 6 , AR=speed},
                 //3 Black, long hair
                 new AP(currentGr) { APS = 1062.8, APE = 1090.3, ALM = 3, ALC = 6 , AR=speed},
                 //4 Black, long hair
                 new AP(currentGr) { APS = 1667.6, APE = 1689.0, ALM = 3, ALC = 6 , AR=speed},
                 new AP(currentGr) { APS = 2668.6, APE = 2726, ALM = 3, ALC = 6 , AR=speed},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Biker Fantasies (1994).m4v"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
