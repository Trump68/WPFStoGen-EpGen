using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    class A001_Woman : BaseScene
    {
        public A001_Woman() : base()
        {
            Name = "Womans tests";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }



        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string gr;
            string src;

            #region Rovena
            gr = "Rovena";
            src = $"Head_IlyaKuvshinov_016_CLEAN";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
                new DifData("Head_IlyaKuvshinov_016_MOUTH",src,"var2"),
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

            #region Alena
            gr = "Alena";
            src = "Head_IlyaKuvshinov_033";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 360, Y = 40, sX = 400, sY = 400, Flip=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Olga
            gr = "Olga";
            src = "Head_IlyaKuvshinov_038";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 315, Y = 55, s = 280, Rot=5, Flip=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Musia
            gr = "Musia";
            src = "Head_IlyaKuvshinov_051";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 390, Y = 15, s = 295, Flip=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Lisa (Head_IlyaKuvshinov_053)
            gr = "Lisa (Head_IlyaKuvshinov_053)";
            src = "Head_IlyaKuvshinov_053";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 390, Y = 15, s = 295, Flip=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 45, Y = -10, s = 210, Rot=355, Flip=1},
                new DifData($"CleMasahiro CL-orz 51 001 Body"),
              });
            #endregion

            #region Ilena (Head_IlyaKuvshinov_054)
            gr = "Ilena (Head_IlyaKuvshinov_054)";
            src = "Head_IlyaKuvshinov_054";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 360, Y = 30, s = 250, Rot=385, Flip=1},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });

            #endregion

            #region Mary (CleMasahiro CL-orz 51)
            #region Mary (CleMasahiro CL-orz 51 001 Head)
            gr = "Mary (CleMasahiro CL-orz 51 001 Head)";
            src = "CleMasahiro CL-orz 51 001 Head";

            AddLocal(
            new string[] { gr },
            new DifData[] {
                 new DifData(src) { X = 65, Y = -5, s = 215, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 365, Y = 70, s = 270, Rot=735, Flip=0},
                new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                new DifData("FullsArt_NetorareTsuma_PosingLegsParted_003") { Flip=1 }
              });


            #endregion

            #region Mary1 (CleMasahiro CL-orz 51 002 Head)
            gr = "Mary (CleMasahiro CL-orz 51 002 Head)";
            src = "CleMasahiro CL-orz 51 002 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 65, s = 220, Rot=-80, Flip=0 },
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = -15, Y = -10, s = 215, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            #endregion

            #region Mary2 (CleMasahiro CL-orz 51 003 Head)
            gr = "Mary (CleMasahiro CL-orz 51 003 Head)";
            src = "CleMasahiro CL-orz 51 003 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 0, Y = 77, s = 220, Rot=-55, Flip=0 },
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 75, Y = -25, s = 215, Flip=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            #endregion

            #region Mary3 (CleMasahiro CL-orz 51 004 Head)
            gr = "Mary (CleMasahiro CL-orz 51 004 Head)";
            src = "CleMasahiro CL-orz 51 004 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {Y = 32, s = 220, Rot=40, Flip=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 65, Y = -35, s = 210, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            #endregion

            #region Mary4 (CleMasahiro CL-orz 51 005 Head)
            gr = "Mary (CleMasahiro CL-orz 51 005 Head)";
            src = "CleMasahiro CL-orz 51 005 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 35, Y = 47, s = 195, Rot=-60, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 15, s = 190, Flip=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            #endregion

            #region Mary5 (CleMasahiro CL-orz 51 006 Head)
            gr = "Mary (CleMasahiro CL-orz 51 006 Head)";
            src = "CleMasahiro CL-orz 51 006 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 25, Y = 77, s = 195, Rot=30, Flip=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 75, Y = 20, s = 210, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, s = 770, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, s = 225, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, s = 800, Flip=0},
            });
            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, s = 225, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, s = 800, Flip=0},
                 new DifData("CleMasahiro CL-orz 51 001 LoveHeart"){X = 240, Y = 95, s = 40, Flip=1},
            });
            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, s = 225, Flip=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, s = 800, Flip=0},
                 new DifData("CleMasahiro CL-orz 51 001 LoveHeart"){X = 240, Y = 95, s = 40, Flip=1},
            });
            #endregion

            #region Mary6 (CleMasahiro CL-orz 51 007 Head)
            gr = "Mary (CleMasahiro CL-orz 51 007 Head)";
            src = "CleMasahiro CL-orz 51 007 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = -20, Y = -5, s = 225, Rot=25, Flip=1},
                 new DifData("CleMasahiro_CL_orz_51_001_Mouth", src) { },
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, s = 640, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 105, Y = -40, s = 230, Rot=10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src){ X = 339, Y = 519, s = 78, Rot=15, Flip=0 },
            new DifData("CleMasahiro CL-orz 51 001 Body") { X = 0, Y = -15, s = 770, Flip = 0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 25, Y = -20, s = 230, Rot=10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("CleMasahiro CL-orz 51 004 Body") { X = 40, Y = 165, s = 700, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 25, Y = -20, s = 230, Rot=10, Flip=0},
            new DifData("CleMasahiro_CL_orz_51_001_Mouth", src),
            new DifData("CleMasahiro CL-orz 51 004 Body") { X = 40, Y = 165, s = 700, Flip=0 },
            });


            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = -5, Y = 60, s = 280, Rot=20, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_001") { X = 40, Y = 165, s = 900, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 15, Y = 190, s = 280, Rot=35, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_002") { X = 40, Y = 165, s = 900, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 120, Y = 50, s = 255, Rot=35, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_003") { X = 275, Y = -10, s = 765, Rot=-90, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 70, Y = -30, s = 265, Rot=-25, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_004") { X = 40, Y = 125, s = 1045, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 35, Y = 5, s = 285, Rot=5, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_005") { X = 35, Y = 10, s = 825, Rot=-40, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 715, Y = 30, s = 285, Rot=25, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_006") { X = 30, Y = 185, s = 825, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -50, Y = 20, s = 340, Rot=-40, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_007") { X = 100, Y = 25, s = 925, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, s = 245, Rot=-20, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, s = 765, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, s = 245, Rot=-20, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, s = 765, Flip=0 },
            new DifData("Hews_Hack_BodyScene_PNG_Cock_001") {X = 435, Y = 455, s = 405, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, s = 245, Rot=-20, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, s = 765, Flip=0 },
            new DifData("Hews_Hack_BodyScene_PNG_010","Hews_Hack_BodyScene_PNG_008"),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 175, Y = -60, s = 235, Rot=5, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_011") { X = 95, Y = -5, s = 765, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 140, Y = 90, s = 235, Rot=-10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_012") { X = 10, Y = 5, s = 765, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 155, Y = -65, s = 230, Rot=-15, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_013") { X = 5, Y = 145, s = 620, Flip=0 },
            new DifData("Hews_Hack_BodyScene_PNG_Flower_001") {X = 125, Y = 50, s = 70, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 100, Y = -70, s = 290, Rot=-15, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_014") { X = 5, Y = 145, s = 620, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -15, Y = 35, s = 195, Rot=5, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_015") { X = 15, Y = 145, s = 620, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -25, Y = 210, s = 260, Rot=40, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_016") { X = 135, Y = 5, s = 955, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 330, Y = -15, s = 210, Rot=10, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_018") { X = 135, Y = 5, s = 955, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_019") { X = 5, Y = 135, s = 625, Flip=0 },
            new DifData(src) {X = 295, Y = -35, s = 235, Rot=10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_019") { X = 5, Y = 135, s = 625, Flip=0 },
            new DifData("Hews_Hack_BodyScene_PNG_020") { X = 197, Y = 566, s = 280, Flip=0 },
            new DifData(src) {X = 295, Y = -35, s = 235, Rot=10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_001") { X = -3, Y = -4, s = 785, Flip=0 },
            new DifData(src) {X = 285, Y = -50, s = 160, Rot=-10, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_002") { X = -3, Y = -4, s = 1050, Flip=0 },
            new DifData(src) {X = 440, Y = 30, s = 215, Rot=-10, Flip=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_003") { X = 2, Y = 126, s = 700, Flip=0 },
            new DifData(src) { X = 110, Y = -40, s = 235, Rot=-20, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001",src),
            });

            #endregion

            #endregion

            #region Lotta (Ghettoyouth_001)
            gr = "Lotta (Ghettoyouth_001)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_004") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 410, Y = 215, s = 55, Rot=-10, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_005") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 347, Y = 189, s = 29, Rot=47, Flip=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_003") { X = 2, Y = 126, s = 700, Flip=0 },
            new DifData("Ghettoyouth_Head_PNG_001") { X = 90, Y = -40, s = 255, Flip=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 255, Y = 130, s = 35, Rot=15, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_006") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 441, Y = 191, s = 34, Rot=42, Flip=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_007") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 195, Y = 201, s = 27, Rot=34, Flip=0},
            });
            #endregion

            #region Gretta (Ghettoyouth_002)
            gr = "Gretta (Ghettoyouth_002)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_008") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 482, Y = 274, s = 59, Rot=42, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_009") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 172, Y = 174, s = 36, Rot=11, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_010") { s = 765, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_011") { s = 765, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 240, Y = 187, s = 34, Rot=33, Flip=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_012") { s = 765, Flip=0 },
            });
            #endregion

            #region Loretta (Ghettoyouth_003)
            gr = "Loretta (Ghettoyouth_003)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_013") { s = 765, Flip=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_014") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 149, Y = 190, s = 28, Rot=41, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_015") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 489, Y = 205, s = 33, Rot=11, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_016") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 154, Y = 146, s = 21, Rot=28, Flip=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_017") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 437, Y = 182, s = 26, Rot=54, Flip=1},
            });


            AddLocal(new string[] { gr }, new DifData[] { new DifData("Ghettoyouth_BodyScene_018") });
            AddLocal(new string[] { gr }, new DifData[] { new DifData("Ghettoyouth_BodyScene_019") });
            #endregion

            #region Nadya (Hews_Hack_017)
            gr = "Nadya Hews_Hack_017";
            src = "Hews_Hack_017";
            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_017") { X = 135, Y = 5, s = 955, Flip=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001"){ X = 359, Y = 200, s = 31, Rot=-5, Flip=0},
            });
            #endregion

            #region Olya (OyariAshito_001)
            gr = src = SC010_OyariAshito.Lady_Olga.Name;
            List<DifData> cdata;

            cdata = SC010_OyariAshito.Lady_Olga.Get(new DifData() { X = 0, Y = -5, s = 768, Flip = 0 });
            cdata.Add(new DifData(Devil.ManOld_001) { X = 150, Y = 300, s = 345, Flip = 0 });
            AddLocal(gr, cdata);

            cdata = SC010_OyariAshito.Lady_Olga.Get(new DifData() {s=2300});
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 280, Y = 480, s = 625, Flip = 0 });
            AddLocal(gr, cdata);

            #endregion
        }
        protected override void MakeCadres(string cadregroup)
        {
            //cadregroup = "Mary (CleMasahiro CL-orz 51 007 Head)";
            cadregroup = SC010_OyariAshito.Lady_Olga.Name;
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
    }
}
