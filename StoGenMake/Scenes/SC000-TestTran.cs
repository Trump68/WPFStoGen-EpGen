using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class SC000_TestTran : BaseScene
    {

        public SC000_TestTran() : base()
        {
            this.Name = "Transition test";
        }
        protected override void MakeCadres(string cadregroup)
        {
            this.DefaultSceneText.Shift = 200;
            this.DefaultSceneText.Size = 60;
            this.DefaultSceneText.FontSize = 20;
            this.DefaultSceneText.FontColor = "Yellow";
            //// real
            cadregroup = "test";

            base.MakeCadres(cadregroup);
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            path = @"d:\Temp\";
            string fn = string.Empty;
            string name = string.Empty;
            //raw

            name = $"Evil_blue"; fn = $"TestBlue.png";
            AddToGlobalImage(name, fn, path, new DifData() { sX = 500, sY = 500, Flip = 0 });
            name = $"Evil_red"; fn = $"TestRed.png";
            AddToGlobalImage(name, fn, path, new DifData() { sX = 500, sY = 500, Flip = 0 });
            name = $"Evil_green"; fn = $"TestGreen.png";
            AddToGlobalImage(name, fn, path, new DifData() { s = 500, Flip = 0 });

            AddGlobal(new string[] { "glob" },
            new DifData[] {
                new DifData("Evil_blue"),
                new DifData("Evil_red","Evil_blue") { s = 300, Rot = 90 },
            });

        
            int ss = 500;
            int r = 5;
            AddLocal(new string[] { "test" },
             new DifData[] {
                new DifData("Evil_blue") { s=ss, Rot = 45},
                new DifData("Evil_red","Evil_blue"),
            });

            AddLocal(new string[] { "test" },
             new DifData[] {
                new DifData("Evil_blue") { s=ss, Rot = 10},
                new DifData("Evil_red","Evil_blue"),
            });

//            AddLocal(new string[] { "test" },
// new DifData[] {
//                new DifData("Evil_blue") { X=199, Y=99, s=ss, Rot = r+40},
//                new DifData("Evil_red","Evil_blue"),
//});

//            AddLocal(new string[] { "test" },
// new DifData[] {
//                new DifData("Evil_blue") { X=199, Y=99, s=ss, Rot = r+60},
//                new DifData("Evil_red","Evil_blue"),
//});

//            AddLocal(new string[] { "test" },
// new DifData[] {
//                new DifData("Evil_blue") { X=199, Y=99, s=ss, Rot = r+80},
//                new DifData("Evil_red","Evil_blue"),
//});

        }
    }
}
