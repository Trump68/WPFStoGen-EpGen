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
        }

        protected override void MakeCadres(string cadregroup)
        {
            cadregroup = "Betty (CleMasahiro CL-orz 51 002 Head)";
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
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

            #region Betty (CleMasahiro CL-orz 51 001 Head)
            gr = "Betty (CleMasahiro CL-orz 51 001 Head)";
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

            #region Mary (CleMasahiro CL-orz 51 002 Head)
            gr = "Betty (CleMasahiro CL-orz 51 002 Head)";
            src = "CleMasahiro CL-orz 51 002 Head";

            AddLocal(  new string[] { gr }, new DifData[] {
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
        }
    }
}
