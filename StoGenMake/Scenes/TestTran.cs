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
                 
                 new AlignData("Evil_red", new DifData() { X = 700, Y=400, sX = 5, sY=5})
                 ,new AlignData("Evil_blue", new DifData() { sX = 500, sY=500 })
                ,new AlignData("Evil_green","Evil_blue", new DifData() { X = 230, sX = 400, sY=400 })               
                //,new AlignData("Evil_red","Evil_green", new DifData() { X = 233, Y = -300, sX = 500, sY = 500 })
            }, null);

            //// real
            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red")
            }, this);


            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue",new DifData() { Rot =45  })
                 //,new AlignData("Evil_green","Evil_blue",new DifData() { Rot=90 }) // absolute 1030
                 ,new AlignData("Evil_green","Evil_blue",new DifData() { Rot =45  }) // absolute 1030
                //,new AlignData("Evil_green","Evil_blue",new DifData() { X=300 })
                //,new AlignData("Evil_red","Evil_green",new DifData() { X=100 })
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
