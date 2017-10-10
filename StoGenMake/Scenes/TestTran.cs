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
            // Set align
            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue", new seIm() { X = 33, Y = 22, sX = 600, sY = 600, Rot = 0, Flip = 0 })
                ,new AlignData("Evil_green","Evil_blue", new seIm() { X = 335, Y = 310, sX = 900, sY = 900, Rot = 20, Flip = 0 })
                ,new AlignData("Evil_red","Evil_green", new seIm() { X = 355, Y = -261, sX = 600, sY = 600, Rot = 80, Flip = 0 })
            }, null);

            // real
            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this);

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue", new seIm() { X = 200 })
                ,new AlignData("Evil_red","Evil_green")
            }, this);

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue",new seIm() { X = 133 })
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this);

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue",new seIm() { sX = 1200, sY = 1200 })
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this);

        }
        internal static void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            
            path = @"d:\Temp\";
            //raw
           
            data.Add(GetIm($"Evil_blue", VNPCPersType.Manga, "qqw", path, $"TestBlue.png"));
            data.Add(GetIm($"Evil_red", VNPCPersType.Manga, "we", path, $"TestRed.png"));
            data.Add(GetIm($"Evil_green", VNPCPersType.Manga, "er", path, $"TestGreen.png"));

           

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
