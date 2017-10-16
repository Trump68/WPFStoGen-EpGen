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
    public class Ilya_Kuvshinov : BaseScene
    {

        public Ilya_Kuvshinov() : base()
        {

        }

     
        protected override void MakeCadres()
        {
            for (int i = 1; i < 6; i++)
            {
                SetCadre(new AlignData[] { new AlignData($"Head_IlyaKuvshinov_{i.ToString("D3")}") }, this);
            }

            SetCadre(new AlignData[] {
                new AlignData($"Head_IlyaKuvshinov_001"),
                new AlignData("Evil_BODY_1710085001",new DifData() {X = 460, Y = 85, sX = 980, sY = 980, Flip=0}),
        }, this);

            this.Cadres.Reverse();


        }
        internal static void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            // Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~
            path = @"x:\ARTIST\Ilya Kuvshinov\PNG\";

            string dsc = "Ilya_Kuvshinov";
            string src = null;
            string fn = null;

            // Heads
            for (int i = 1; i < 6; i++)
            {
                src = $"Head_IlyaKuvshinov_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                GetIm(src, VNPCPersType.ArtCG, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            }

           

        }

    }
}
