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
                new DifData($"Body_PosingLegsParted_1710083003"),
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
                new DifData($"Body_PosingLegsParted_1710083003"),
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
                new DifData($"Body_PosingLegsParted_1710083003"),
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
                new DifData($"Body_PosingLegsParted_1710083003"),
              });
            #endregion

            #region Lisa
            gr = "Lisa";
            src = "Head_IlyaKuvshinov_053";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 390, Y = 15, s = 295, Flip=0},
                new DifData($"Body_PosingLegsParted_1710083003"),
              });
            #endregion


            #region Ilena
            gr = "Ilena";
            src = "Head_IlyaKuvshinov_054";
            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 300, Y = 25, s=600},
              });

            AddLocal(new string[] { gr }, new DifData[] {
                new DifData(src) {X = 360, Y = 30, s = 250, Rot=385, Flip=1},
                new DifData($"Body_PosingLegsParted_1710083003"),
              });
            #endregion
        }
    }
}
