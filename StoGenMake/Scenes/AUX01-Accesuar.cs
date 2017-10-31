using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public static class Mouth
    {
        public static string Sensual_001 = $"FullsArt_NetorareTsuma_LadyMouth_001";
    }
    public static class Devil
    {
        public static string ManOld_001 = "FullsArt_NetorareTsuma_EvilManBody_001";
        public static string ManOld_002 = "FullsArt_NetorareTsuma_EvilManBody_002";
        public static string ManOld_003 = "FullsArt_NetorareTsuma_EvilManBody_003";

        public static string ManOld_004 = "FullsArt_NetorareTsuma_EvilManHead_001";
        public static string ManOld_005 = "FullsArt_NetorareTsuma_EvilManHead_002";
        public static string ManOld_006 = "FullsArt_NetorareTsuma_EvilManHead_003";
        public static string ManOld_007 = "FullsArt_NetorareTsuma_EvilManHead_004";

        public static string ManHand_001 = "FullsArt_NetorareTsuma_EvilManHands_001";

        public static string ManPot_001 = "FullsArt_NetorareTsuma_EvilManPot_001";
    }
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
            string fn;

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

            #region Mouth
            AddToGlobalImage(Mouth.Sensual_001, "MOUTH_01.png", SC001_FoolsArt.Path, new DifData() { s = 100 });
            #endregion
            #region Devils
            AddToGlobalImage(Devil.ManOld_001, "EVIL_BODY_01.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            AddToGlobalImage(Devil.ManOld_002, "EVIL_BODY_02.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            AddToGlobalImage(Devil.ManOld_003, "EVIL_BODY_03.png", SC001_FoolsArt.Path, new DifData() { s = 500 });

            AddToGlobalImage(Devil.ManOld_004, "EVIL_HEAD_01.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            AddToGlobalImage(Devil.ManOld_005, "EVIL_HEAD_02.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            AddToGlobalImage(Devil.ManOld_006, "EVIL_HEAD_03.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            AddToGlobalImage(Devil.ManOld_007, "EVIL_HEAD_04.png", SC001_FoolsArt.Path, new DifData() { s = 500 });

            AddToGlobalImage(Devil.ManHand_001, "HANDS_01.png", SC001_FoolsArt.Path, new DifData() { s = 500 });

            AddToGlobalImage(Devil.ManPot_001, "EVIL_POT_01.png", SC001_FoolsArt.Path, new DifData() { s = 500 });
            #endregion

        }
    }
    }
