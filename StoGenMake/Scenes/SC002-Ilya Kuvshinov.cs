using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC002_IlyaKuvshinov : BaseScene
    {
        public SC002_IlyaKuvshinov() : base()
        {
            Name = "Ilya Kuvshinov";
        }

        protected override void MakeCadres(string cadregroup)
        {
            //cadregroup = "global alignment";
            base.MakeCadres(cadregroup);
        }

        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            string src = null;
            string fn = null;
            path = @"d:\Temp\";
            // test
            src = $"Evil_blue"; fn = $"TestBlue.png";
            AddToGlobalImage(src, fn, path, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });


            //path = @"x:\ARTIST\Ilya Kuvshinov\PNG\";
            path = @"d:\Process2+\! Comix\ilya kuvshinov\PNG\";


            // raw Heads
            for (int i = 1; i <= 16; i++)
            {
                src = $"Head_IlyaKuvshinov_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
                AddLocal(new string[] { "All heads", $"Head {i.ToString("D3")}" }, new DifData[] { new DifData(src) });
            }



            //combos
            AddToGlobalImage($"Head_IlyaKuvshinov_016_CLEAN", $"016_CLEAN.png", path, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            AddToGlobalImage($"Head_IlyaKuvshinov_016_MOUTH", $"016_MOUTH.png", path, new DifData() { X = 100, Y = 100, sX = 100, sY = 100, Flip = 0 });
            AddToGlobalImage($"Head_IlyaKuvshinov_016_MOUTH_2", $"016_MOUTH_2.png", path, new DifData() { X = 100, Y = 100, sX = 100, sY = 100, Flip = 0 });

            AddGlobal(
                new string[] { "All heads", "global alignment" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, sX = 85, sY = 85},
                });

            AddGlobal(
               new string[] { "All heads", "global alignment" },
               new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH_2","Head_IlyaKuvshinov_016_CLEAN") { X = 315, Y = 522, sX = 78, sY = 78, Rot=9, Flip=0},
               });

            AddGlobal(
                new string[] { "All heads", "global alignment" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN","var2") { X = 321, Y = 515, sX = 75, sY = 75 },
                });

          

            AddGlobal(
            new string[] { "Test", "global alignment" },
            new DifData[] {
                new DifData("Evil_blue"),
                new DifData("Head_IlyaKuvshinov_016_CLEAN","Evil_blue"),
            });


           

//AddLocal(
//new string[] { "Test", "Head 016 combo align" },
//new DifData[] {
//                            new DifData("Evil_blue"){ sX = 300, sY = 300, Flip=1, Rot = 40},
//                            new DifData("Head_IlyaKuvshinov_016_CLEAN","Evil_blue"),
//                            new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN"),
//});

//AddLocal(
//new string[] { "Test", "Head 016 combo align" },
//new DifData[] {
//                            new DifData("Evil_blue"){ sX = 300, sY = 300, Flip=1, Rot = 40},
//                            new DifData("Head_IlyaKuvshinov_016_CLEAN","Evil_blue"){ Flip=1},
//                            new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN"),
//});

        }
    }
}
