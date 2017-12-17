using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _ERO__Best: BaseScene
    {
        protected override void LoadData()
        {
            
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            string src;
            string path;

            path = @"e:\Process2\!!Data\EroFilms\System\Mask\";
            src = $"Vertical.png";
            AddToGlobalImage("Vertical Mask", src, path);

            path = @"e:\Process2\!!Data\EroFilms\1999\[USA] Hot Club California\";
            src = $"Hot Club California.m4v";
            AddToGlobalImage(src, src, path);

            USA_1999_Hot_Club_California();
        }
        private void USA_1999_Hot_Club_California()
        {
            _ALL__ScenarioText st = new _ALL__ScenarioText();
            st.currentGr = "Hot Club California.m4v";
            int speed = 50;
            List<List<AP>> anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)!!!!!!!!!!!!                 
                new AP("Hot Club California.m4v") { APS = 3953.9, APE = 3956.3, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3959.2, APE = 3962.5, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3965.6, APE = 3968.4, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3971.2, APE = 3977.2, ALM = 1, ALC = 1 , AR=speed},
                }
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };          
            st.VideoFrame800(anims, music,
                new List<DifData>() {
                new DifData() { Name = "Vertical Mask", S=800 }
                } );

            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Hot Club California.m4v"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
