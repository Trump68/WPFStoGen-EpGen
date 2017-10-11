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
                 
                 new AlignData("Evil_blue", new DifData() { X = 0, Y = 0, sX = 500, sY=500 })
                //,new AlignData("Evil_green", new DifData() { X = 0, Y = 0, sX = 500, sY=500 })
                ,new AlignData("Evil_green","Evil_blue", new DifData() { X = 230, Y = 0, sX = 500, sY=500 })
                
                //,new AlignData("Evil_red", new DifData() { X = 533, Y = -300, sX = 600, sY = 600 })
                //,new AlignData("Evil_green","Evil_blue", new DifData() { X = 235, Y = 142, sX = 900, sY = 900, Rot = 0, Flip = 0 })
                ,new AlignData("Evil_red","Evil_green", new DifData() { X = 3, Y = -300, sX = 500, sY = 500, Rot = 0, Flip = 0 })
            }, null);
            
            // real
            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this);


            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue",new DifData() { X=50, sX = 250, sY = 250 })
                ,new AlignData("Evil_green","Evil_blue",new DifData() { X=200 })
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
