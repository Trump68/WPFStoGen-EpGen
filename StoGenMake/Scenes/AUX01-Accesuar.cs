﻿using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class AUX01_Accesuar: BaseScene
    {
        public AUX01_Accesuar() : base()
        {
            Name = "Accesuars";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string gr;
            string src;
            string path;

            #region Flowers
            gr = src = "Flowers";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData("Hews_Hack_BodyScene_PNG_Flower_001") {X = 300, Y = 25, s=600}                
              });


            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 395, Y = 25, sX = 255, sY = 255, Rot=350, Flip=1},
                new DifData("Head_IlyaKuvshinov_016_MOUTH",src,"var2"),
                new DifData(src),
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 395, Y = 25, sX = 255, sY = 255, Rot=350, Flip=1},
                new DifData("Head_IlyaKuvshinov_016_MOUTH_2",src),
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion
        }
        }
    }
