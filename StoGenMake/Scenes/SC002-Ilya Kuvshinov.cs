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
            EngineHiVer = 1;
            EngineLoVer = 0;
        }

        protected override void MakeCadres(string cadregroup)
        {
            //cadregroup = "global alignment";
            base.MakeCadres(cadregroup);
        }

        protected override void LoadData()
        {
            string path = null;
            string src = null;
            string fn = null;
            path = @"d:\Temp\";
            // test
            src = $"Evil_blue"; fn = $"TestBlue.png";
            AddToGlobalImage(src, fn, path, new DifData() { X = 100, Y = 100, Sx = 500, Sy = 500, F = 0 });


            path = @"z:\ARTIST\Ilya Kuvshinov\PNG\";
            //path = @"d:\Process2+\! Comix\ilya kuvshinov\PNG\";


            // raw Heads
            for (int i = 1; i <= 105; i++)
            {
                src = $"Head_IlyaKuvshinov_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { S = 500 });
                AddLocal(new string[] { "All heads", $"Head {i.ToString("D3")}" }, new DifData[] { new DifData(src) });
            }



            //combos
            AddToGlobalImage($"Head_IlyaKuvshinov_016_CLEAN", $"016_CLEAN.png", path, new DifData() { X = 100, Y = 100, Sx = 500, Sy = 500, F = 0 });
            AddToGlobalImage($"Head_IlyaKuvshinov_016_MOUTH", $"016_MOUTH.png", path, new DifData() { X = 100, Y = 100, Sx = 100, Sy = 100, F = 0 });
            AddToGlobalImage($"Head_IlyaKuvshinov_016_MOUTH_2", $"016_MOUTH_2.png", path, new DifData() { X = 100, Y = 100, Sx = 100, Sy = 100, F = 0 });

            AddGlobal(
                new string[] { "All heads", "global alignment" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, Sx = 85, Sy = 85},
                });

            AddGlobal(
               new string[] { "All heads", "global alignment" },
               new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH_2","Head_IlyaKuvshinov_016_CLEAN") { X = 315, Y = 522, Sx = 78, Sy = 78, R=9, F=0},
               });

            AddGlobal(
                new string[] { "All heads", "global alignment" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN","var2") { X = 321, Y = 515, Sx = 75, Sy = 75 },
                });


        }
    }
}
