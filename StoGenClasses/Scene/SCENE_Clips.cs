using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class Scene_Clips : BaseScene
    {
        public override bool LoadData(List<Info_Clip> minfos)
        {
            base.LoadData(minfos);
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            ShowClip(this.MoviePath);
            return true;
        }

        private void ShowClip(string filter)
        {
            currentGr = filter;
            List<string> music = new List<string>();// { $"{PATH_M}music.arc_000005.wav" };
            //List<List<AP>> anims;

            double posStart = 0;
            double posEnd = 60000;
            int loopMode = 1;
            int loopCount = 1;
            int speed = 100;
            string text = string.Empty;

            var anims = new List<List<AP>>();
            int volume = 100;
            VOLUME_M = 0;
            this.VOLUME_M = 0;
            if (this.MoviewInfo != null)
            {
                foreach (var item in MoviewInfo)
                {
                    AddToGlobalImage(item.File, item.File);
                    posStart = Convert.ToDouble(item.PositionStart);
                    posEnd = Convert.ToDouble(item.PositionEnd);
                    loopMode = item.LoopMode;
                    loopCount = item.LoopCount;
                    speed = item.Speed;
                    text = item.Story;
                    anims.Add(new List<AP>());

                    anims.Last().Add(new AP(filter) { APS = posStart, APE = posEnd, ALM = loopMode, ALC = loopCount, AR = speed, AV = volume, File = item.File });
                    //anims. new AP(filter) { APS = posStart, APE = posEnd, ALM = loopMode, ALC = loopCount, AR = speed, AV = volume };
                }
                
            }

           

            //anims = new List<List<AP>>() {
            //    new List<AP>() { // shower 
            //    new AP(filter) { APS = posStart, APE = posEnd, ALM = loopMode, ALC = loopCount , AR=speed, AV=volume},
            //    } };
            VideoFrame800(anims, music, text);
            //this.AlignList.AddRange(AlignList);
        }
        //public void VideoFrame800(List<AP> anims, List<string> music)
        //{
        //    List<List<AP>> anims2 = new List<List<AP>>();
        //    anims2.Add(anims);
        //    VideoFrame800(anims2, music);
        //}
        //public void VideoFrame800(List<List<AP>> anims, List<string> music, List<DifData> pics = null)
        //{
        //    VideoFrame800(anims, music, string.Empty, pics);
        //}
        public void VideoFrame800(List<List<AP>> anims, List<string> music,string text, List<DifData> pics = null)
        {
            if (music.Any())
                AddMusic(music[0]);
            foreach (var item in anims)
            {
                List<DifData> itl = new List<DifData>();
                DifData size = new DifData() { S = 800 };
                size.Name = item[0].File;
                size.AL.AddRange(item);
                if (pics == null) pics = new List<DifData>();
                itl.AddRange(pics);
                itl.Insert(0, size);
                //AddAnim(item[0].File, text, itl, item.ToArray());
                Add(new string[] { item[0].File }, itl.ToArray(), null, null, false);
            }
        }

    }
}