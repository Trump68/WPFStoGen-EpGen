using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _JAV_Common : BaseScene
    {
        public _JAV_Common(string filter, string moviePath) : base(filter, moviePath) { }
        protected override void LoadData(string loadFilter)
        {
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";

            // Test   
            string filter = loadFilter;
            AddToGlobalImage(filter, this.MoviePath); Test(filter);
            if (loadFilter == filter) return;
        }

        private void Test(string filter)
        {
            _ALL__ScenarioText st = new _ALL__ScenarioText();
            st.currentGr = filter;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            st.VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>() {
                new List<AP>() { // shower 
                new AP(filter) { APS = 0, APE = 10, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                new AP(filter) { APS = 0, APE = 10, ALM = 1, ALC = 1 , AR=speed},
                new AP(filter) { APS = 0, APE = 10, ALM = 1, ALC = 1 , AR=speed}, //fuck
                new AP(filter) { APS = 0, APE = 10, ALM = 1, ALC = 1 , AR=speed},
                } }; st.VideoFrame800(anims, music);
            //st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }

    }
}