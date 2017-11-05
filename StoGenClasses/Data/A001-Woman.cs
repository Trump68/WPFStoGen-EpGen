using StoGen.Classes.Data;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class A001_Woman : BaseScene
    {
        public A001_Woman() : base()
        {
            Name = "Womans tests";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }



        protected override void LoadData()
        {
            string gr;
            string src;
            string text;

            #region Rovena
            gr = "Rovena";
            src = $"Head_IlyaKuvshinov_016_CLEAN";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
                new DifData("Head_IlyaKuvshinov_016_MOUTH",src,"var2"),
              });


            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 395, Y = 25, Sx = 255, Sy = 255, R=350, F=1},
                new DifData("Head_IlyaKuvshinov_016_MOUTH",src,"var2"),
                new DifData(src),
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 395, Y = 25, Sx = 255, Sy = 255, R=350, F=1},
                new DifData("Head_IlyaKuvshinov_016_MOUTH_2",src),
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Alena
            gr = "Alena";
            src = "Head_IlyaKuvshinov_033";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 360, Y = 40, Sx = 400, Sy = 400, F=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Olga
            gr = "Olga";
            src = "Head_IlyaKuvshinov_038";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 315, Y = 55, S = 280, R=5, F=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Musia
            gr = "Musia";
            src = "Head_IlyaKuvshinov_051";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 390, Y = 15, S = 295, F=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            #endregion

            #region Lisa (Head_IlyaKuvshinov_053)
            gr = "Lisa (Head_IlyaKuvshinov_053)";
            src = "Head_IlyaKuvshinov_053";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 390, Y = 15, S = 295, F=0},
                new DifData($"FullsArt_NetorareTsuma_PosingLegsParted_003"),
              });
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 45, Y = -10, S = 210, R=355, F=1},
                new DifData($"CleMasahiro CL-orz 51 001 Body"),
              });
            #endregion

            #region Ilena (Head_IlyaKuvshinov_054)
            gr = "Ilena (Head_IlyaKuvshinov_054)";
            src = "Head_IlyaKuvshinov_054";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, S=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 360, Y = 30, S = 250, R=385, F=1},
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
                 new DifData(src) { X = 65, Y = -5, S = 215, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 365, Y = 70, S = 270, R=735, F=0},
                new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                new DifData("FullsArt_NetorareTsuma_PosingLegsParted_003") { F=1 }
              });


            #endregion

            #region Mary1 (CleMasahiro CL-orz 51 002 Head)
            gr = "Mary (CleMasahiro CL-orz 51 002 Head)";
            src = "CleMasahiro CL-orz 51 002 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 65, S = 220, R=-80, F=0 },
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = -15, Y = -10, S = 215, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            #endregion

            #region Mary2 (CleMasahiro CL-orz 51 003 Head)
            gr = "Mary (CleMasahiro CL-orz 51 003 Head)";
            src = "CleMasahiro CL-orz 51 003 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 0, Y = 77, S = 220, R=-55, F=0 },
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 75, Y = -25, S = 215, F=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            #endregion

            #region Mary3 (CleMasahiro CL-orz 51 004 Head)
            gr = "Mary (CleMasahiro CL-orz 51 004 Head)";
            src = "CleMasahiro CL-orz 51 004 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {Y = 32, S = 220, R=40, F=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 65, Y = -35, S = 210, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            #endregion

            #region Mary4 (CleMasahiro CL-orz 51 005 Head)
            gr = "Mary (CleMasahiro CL-orz 51 005 Head)";
            src = "CleMasahiro CL-orz 51 005 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 35, Y = 47, S = 195, R=-60, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = 15, S = 190, F=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            #endregion

            #region Mary5 (CleMasahiro CL-orz 51 006 Head)
            gr = "Mary (CleMasahiro CL-orz 51 006 Head)";
            src = "CleMasahiro CL-orz 51 006 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 25, Y = 77, S = 195, R=30, F=1},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 75, Y = 20, S = 210, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 001 Body"){ X = 0, Y = -15, S = 770, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, S = 225, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, S = 800, F=0},
            });
            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, S = 225, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, S = 800, F=0},
                 new DifData("CleMasahiro CL-orz 51 001 LoveHeart"){X = 240, Y = 95, S = 40, F=1},
            });
            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) {X = 30, Y = 20, S = 225, F=0},
                 new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
                 new DifData("CleMasahiro CL-orz 51 003 Body"){X = 10, Y = 125, S = 800, F=0},
                 new DifData("CleMasahiro CL-orz 51 001 LoveHeart"){X = 240, Y = 95, S = 40, F=1},
            });
            #endregion

            #region Mary6 (CleMasahiro CL-orz 51 007 Head)
            gr = "Mary (CleMasahiro CL-orz 51 007 Head)";
            src = "CleMasahiro CL-orz 51 007 Head";

            AddLocal(new string[] { gr }, new DifData[] {
                 new DifData(src) { X = -20, Y = -5, S = 225, R=25, F=1},
                 new DifData("CleMasahiro_CL_orz_51_001_Mouth", src) { },
                 new DifData("CleMasahiro CL-orz 51 002 Body"){ Y = 135, S = 640, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 105, Y = -40, S = 230, R=10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src){ X = 339, Y = 519, S = 78, R=15, F=0 },
            new DifData("CleMasahiro CL-orz 51 001 Body") { X = 0, Y = -15, S = 770, F = 0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 25, Y = -20, S = 230, R=10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("CleMasahiro CL-orz 51 004 Body") { X = 40, Y = 165, S = 700, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 25, Y = -20, S = 230, R=10, F=0},
            new DifData("CleMasahiro_CL_orz_51_001_Mouth", src),
            new DifData("CleMasahiro CL-orz 51 004 Body") { X = 40, Y = 165, S = 700, F=0 },
            });


            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = -5, Y = 60, S = 280, R=20, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_001") { X = 40, Y = 165, S = 900, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 15, Y = 190, S = 280, R=35, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_002") { X = 40, Y = 165, S = 900, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 120, Y = 50, S = 255, R=35, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_003") { X = 275, Y = -10, S = 765, R=-90, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 70, Y = -30, S = 265, R=-25, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_004") { X = 40, Y = 125, S = 1045, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 35, Y = 5, S = 285, R=5, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_005") { X = 35, Y = 10, S = 825, R=-40, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) { X = 715, Y = 30, S = 285, R=25, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_006") { X = 30, Y = 185, S = 825, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -50, Y = 20, S = 340, R=-40, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_007") { X = 100, Y = 25, S = 925, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, S = 245, R=-20, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, S = 765, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, S = 245, R=-20, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, S = 765, F=0 },
            new DifData("Hews_Hack_BodyScene_PNG_Cock_001") {X = 435, Y = 455, S = 405, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 185, Y = -35, S = 245, R=-20, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_008") { X = 95, Y = -5, S = 765, F=0 },
            new DifData("Hews_Hack_BodyScene_PNG_010","Hews_Hack_BodyScene_PNG_008"),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 175, Y = -60, S = 235, R=5, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_011") { X = 95, Y = -5, S = 765, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 140, Y = 90, S = 235, R=-10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_012") { X = 10, Y = 5, S = 765, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 155, Y = -65, S = 230, R=-15, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_013") { X = 5, Y = 145, S = 620, F=0 },
            new DifData("Hews_Hack_BodyScene_PNG_Flower_001") {X = 125, Y = 50, S = 70, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 100, Y = -70, S = 290, R=-15, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_014") { X = 5, Y = 145, S = 620, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -15, Y = 35, S = 195, R=5, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_015") { X = 15, Y = 145, S = 620, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = -25, Y = 210, S = 260, R=40, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_016") { X = 135, Y = 5, S = 955, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData(src) {X = 330, Y = -15, S = 210, R=10, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            new DifData("Hews_Hack_BodyScene_PNG_018") { X = 135, Y = 5, S = 955, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_019") { X = 5, Y = 135, S = 625, F=0 },
            new DifData(src) {X = 295, Y = -35, S = 235, R=10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_019") { X = 5, Y = 135, S = 625, F=0 },
            new DifData("Hews_Hack_BodyScene_PNG_020") { X = 197, Y = 566, S = 280, F=0 },
            new DifData(src) {X = 295, Y = -35, S = 235, R=10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_001") { X = -3, Y = -4, S = 785, F=0 },
            new DifData(src) {X = 285, Y = -50, S = 160, R=-10, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_002") { X = -3, Y = -4, S = 1050, F=0 },
            new DifData(src) {X = 440, Y = 30, S = 215, R=-10, F=1},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src),
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_003") { X = 2, Y = 126, S = 700, F=0 },
            new DifData(src) { X = 110, Y = -40, S = 235, R=-20, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001",src),
            });

            #endregion

            #endregion

            #region Lotta (Ghettoyouth_001)
            gr = "Lotta (Ghettoyouth_001)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_004") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 410, Y = 215, S = 55, R=-10, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_005") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 347, Y = 189, S = 29, R=47, F=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_003") { X = 2, Y = 126, S = 700, F=0 },
            new DifData("Ghettoyouth_Head_PNG_001") { X = 90, Y = -40, S = 255, F=0},
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 255, Y = 130, S = 35, R=15, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_006") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 441, Y = 191, S = 34, R=42, F=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_007") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 195, Y = 201, S = 27, R=34, F=0},
            });
            #endregion

            #region Gretta (Ghettoyouth_002)
            gr = "Gretta (Ghettoyouth_002)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_008") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 482, Y = 274, S = 59, R=42, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_009") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 172, Y = 174, S = 36, R=11, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_010") { S = 765, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_011") { S = 765, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 240, Y = 187, S = 34, R=33, F=1},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_012") { S = 765, F=0 },
            });
            #endregion

            #region Loretta (Ghettoyouth_003)
            gr = "Loretta (Ghettoyouth_003)";
            src = null;

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_013") { S = 765, F=0 },
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_014") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 149, Y = 190, S = 28, R=41, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_015") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 489, Y = 205, S = 33, R=11, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_016") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 154, Y = 146, S = 21, R=28, F=0},
            });

            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Ghettoyouth_BodyScene_017") {  },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001") { X = 437, Y = 182, S = 26, R=54, F=1},
            });


            AddLocal(new string[] { gr }, new DifData[] { new DifData("Ghettoyouth_BodyScene_018") });
            AddLocal(new string[] { gr }, new DifData[] { new DifData("Ghettoyouth_BodyScene_019") });
            #endregion

            #region Nadya (Hews_Hack_017)
            gr = "Nadya Hews_Hack_017";
            src = "Hews_Hack_017";
            AddLocal(new string[] { gr }, new DifData[] {
            new DifData("Hews_Hack_BodyScene_PNG_017") { X = 135, Y = 5, S = 955, F=0 },
            new DifData("FullsArt_NetorareTsuma_LadyMouth_001"){ X = 359, Y = 200, S = 31, R=-5, F=0},
            });
            #endregion

            #region EriAyase (OyariAshito_001)            
            List<DifData> cdata;

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face01.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face01.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face01.Get(new DifData() { S = 2300 });
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face02.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face02.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face02.Get(new DifData() { S = 2300 });
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face03.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face03.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face03.Get(new DifData() { S = 2300 });
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face04.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face04.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face04.Get(new DifData());
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face05.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face05.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face05.Get(new DifData());
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);

            gr = src = SC010_OyariAshito.Lady_EriAyase_Face06.Name;
            text = SC010_OyariAshito.Lady_EriAyase_Face06.Story1;
            cdata = SC010_OyariAshito.Lady_EriAyase_Face06.Get(new DifData());
            //cdata.Add(new DifData(Devil.ManOld_001) { X = 745, Y = 255, S = 1425, F = 0 });
            AddLocal(gr, text, cdata);
            #endregion

            #region Lina Moana ([ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~")
            gr = src = SC011_HCG.Lady_LinaMoana_Face01.CName;
            text = SC011_HCG.Lady_LinaMoana_Face01.Story1;
            for (int i = 0; i < SC011_HCG.Lady_LinaMoana_Face01.Variants; i++)
            {
                cdata = SC011_HCG.Lady_LinaMoana_Face01.Get(this, i, new DifData() { });                
                AddLocal(gr, text, cdata);
            }

            gr = src = SC011_HCG.Lady_LinaMoana_Face02.CName;
            text = SC011_HCG.Lady_LinaMoana_Face02.Story1;
            for (int i = 0; i < SC011_HCG.Lady_LinaMoana_Face02.Variants; i++)
            {
                    cdata = SC011_HCG.Lady_LinaMoana_Face02.Get(this, i, new DifData() { });
                    AddLocal(gr, text, cdata);
            }

            gr = src = SC011_HCG.Lady_LinaMoana_Face03.CName;
            text = SC011_HCG.Lady_LinaMoana_Face03.Story1;
            for (int i = 0; i < SC011_HCG.Lady_LinaMoana_Face03.Variants; i++)
            {
                cdata = SC011_HCG.Lady_LinaMoana_Face03.Get(this, i,true, new DifData() { });
                AddLocal(gr, text, cdata);
            }

            gr = src = SC011_HCG.Lady_LinaMoana_Face04.CName;
            text = SC011_HCG.Lady_LinaMoana_Face04.Story1;
            for (int i = 0; i < SC011_HCG.Lady_LinaMoana_Face04.Variants; i++)
            {
                cdata = SC011_HCG.Lady_LinaMoana_Face04.Get(this, i,true, new DifData() { });
                AddLocal(gr, text, cdata);
            }

            
           
            //string path = @"Z:\DOUJIN\Enoshima Iki\[DOUJIN COLOR] Kuro Gal Bitch ga Uchi ni Kita!\";
            //for (int i = 1; i <= 21; i++)
            //{
            //    src = $"test1_{i.ToString("D3")}";
            //    string fn = $"{i.ToString("D3")}.png";
            //    AddToGlobalImage(src, fn, path);
            //}

            //gr = "test1";
            //cdata = SC011_HCG.Lady_LinaMoana_Face04.Get(this, 0,true, new DifData() { });
            //cdata.Insert(0, new DifData("test1_001") { });
            //AddLocal(gr, text, cdata);
            #endregion
        }
        protected override void MakeCadres(string cadregroup)
        {
            //cadregroup = SC011_HCG.Lady_LinaMoana_Face03.CName;
            //cadregroup = SC010_OyariAshito.Lady_EriAyase_Face03.Name;
            string[] cd = new string[] {
                SC011_HCG.Lady_LinaMoana_Face01.CName,
                SC011_HCG.Lady_LinaMoana_Face02.CName,
                SC011_HCG.Lady_LinaMoana_Face03.CName,
                SC011_HCG.Lady_LinaMoana_Face04.CName,
            };
            //string[] cd = new string[] {
            //  "test1"
            //};
            //test1
            base.MakeCadres(cd);
            this.Cadres.Reverse();
        }
    }
}
