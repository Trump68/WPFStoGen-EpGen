﻿using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _Clip_Default : BaseScene
    {
        public override bool LoadData(string loadFilter, string moviePath)
        {
            base.LoadData(loadFilter, moviePath);
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";

            string filter = loadFilter;
            AddToGlobalImage(filter, this.MoviePath);
            ShowClip(filter);
            return true;
        }

        private void ShowClip(string filter)
        {
            currentGr = filter;
            List<string> music = new List<string>();// { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>() {
                new List<AP>() { // shower 
                new AP(filter) { APS = 0, APE = 60000, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                } };
            VideoFrame800(anims, music);
            this.AlignList.AddRange(AlignList);
        }
        public void VideoFrame800(List<AP> anims, List<string> music)
        {
            List<List<AP>> anims2 = new List<List<AP>>();
            anims2.Add(anims);
            VideoFrame800(anims2, music);
        }
        public void VideoFrame800(List<List<AP>> anims, List<string> music, List<DifData> pics = null)
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
                AddAnim(item[0].File, string.Empty, itl, item.ToArray());
            }
        }
    }
}