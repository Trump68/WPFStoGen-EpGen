using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _ALL__WEB : BaseScene
    {
        protected override void LoadData()
        {
            string path = @"d:\PANDA\";
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            string src;
            int i = 1;
            src = $"A_{(i++).ToString("D4")}";
            AddToGlobalImage(src, @"2011-12-29 23.28.m4v", path);
            src = $"A_{(i++).ToString("D4")}";
            AddToGlobalImage(src, @"2011-12-30 00.04.m4v", path);
            src = $"A_{(i++).ToString("D4")}";
            AddToGlobalImage(src, @"2011-12-30 08.39.m4v", path);
            src = $"A_{(i++).ToString("D4")}";
            AddToGlobalImage(src, @"2012-01-01 19.34.m4v", path);

            Scene1();
        }
        private void Scene1()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Scene1";

            List<AP> anims = new List<AP>()
            {
                 new AP("A_0001") { APS = 0, APE = 101.0, ALM = 3, ALC = 6 }
                ,new AP("A_0002") { APS = 0, APE = 97.0, ALM = 3, ALC = 6 }
                ,new AP("A_0003") { APS = 0, APE = 55.0, ALM = 3, ALC = 6 }
                ,new AP("A_0004") { APS = 06, APE = 36.0, ALM = 3, ALC = 6 }
                ,new AP("A_0004") { APS = 10.2, APE = 11.4, ALM = 3, ALC = 100 }
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { "Scene1" });
            this.AlignList.AddRange(st.AlignList);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Scene1"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
