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
            cadregroup = "Head 016 combo align";
            base.MakeCadres(cadregroup);
        }

        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            path = @"x:\ARTIST\Ilya Kuvshinov\PNG\";

            string src = null;
            string fn = null;            
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

            AddLocal(
                new string[] { "All heads", "Head 016 combo align" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, sX = 85, sY = 85, Flip = 0  },
                }, true);

            AddLocal(
               new string[] { "All heads", "Head 016 combo align" },
               new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN") { Rot=40 , X=300, Y=100, sX =300, sY = 300},
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, sX = 85, sY = 85, Flip = 0  },
               }, false);

            AddLocal(
             new string[] { "All heads", "Head 016 combo align" },
             new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN") { Rot=50 , X=300, Y=100},
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, sX = 85, sY = 85, Flip = 0  },
             }, false);
        }
    }
}
