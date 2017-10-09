using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class TestTran : BaseScene
    {

        public TestTran() : base()
        {

        }
        protected override void MakeCadres()
        {

            SetCadre(new Tuple<string, string, seIm>[] {
               new  Tuple<string, string, seIm>("Evil_green",null, new seIm() { X = 335, Y = 310, sX = 900, sY = 900, Rot = 20, Flip = 0 })
              ,new  Tuple<string, string, seIm>("Evil_blue",null, new seIm() { X = 33, Y = 22, sX = 953, sY = 953, Rot = 0, Flip = 0 })
              ,new  Tuple<string, string, seIm>("Evil_red",null, new seIm() { X = 355, Y = -261, sX = 600, sY = 600, Rot = 80, Flip = 0 })
            }, false);
            //

        }
        internal static void LoadData(List<seIm> data, List<AlignData> alignData)
        {
            string path = null;

            // Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~
            path = @"d:\Temp\";
            //raw
           
            data.Add(GetIm($"Evil_blue", VNPCPersType.Manga, "qqw", path, $"TestBlue.png"));
            data.Add(GetIm($"Evil_red", VNPCPersType.Manga, "we", path, $"TestRed.png"));
            data.Add(GetIm($"Evil_green", VNPCPersType.Manga, "Fools_Art_werHomare", path, $"TestGreen.png"));
        }
        internal static seIm GetIm(string name, VNPCPersType type, string desc, string path, string file)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = VNPCPersType.Comix;
            im.Description = desc;
            return im;
        }
    }

}
