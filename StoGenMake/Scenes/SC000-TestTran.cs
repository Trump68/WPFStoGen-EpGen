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
            EngineHiVer = 1;
            EngineLoVer = 0;
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
            AddToGlobalImage(name, fn, path, new DifData() { s = 500, Flip = 0 });
            name = $"Evil_red"; fn = $"TestRed.png";
            AddToGlobalImage(name, fn, path, new DifData() { s = 300, Flip = 0 });
            name = $"Evil_green"; fn = $"TestGreen.png";
            AddToGlobalImage(name, fn, path, new DifData() { s = 500, Flip = 0 });

            AddGlobal(new string[] { "test" },
            new DifData[] {
                new DifData("Evil_blue") { X=100 },                
                new DifData("Evil_red","Evil_blue") {X=200},
            });

        
            int ss = 300;
            int r = 5;

            AddLocal(new string[] { "test" },
             new DifData[] {
                new DifData("Evil_blue"){ X=200 },
                new DifData("Evil_red","Evil_blue"),
            });

            AddLocal(new string[] { "test" },
             new DifData[] {
                new DifData("Evil_blue") {X=300, Rot=45, Flip =1},
                new DifData("Evil_red","Evil_blue"),
            });

            //AddLocal(new string[] { "test" },
            // new DifData[] {
            //    new DifData("Evil_blue") { X = 200, s=ss},
            //    new DifData("Evil_red","Evil_blue"),
            //});

            //AddLocal(new string[] { "test" },
            // new DifData[] {
            //    new DifData("Evil_blue") { s=ss, Rot = 20},
            //    new DifData("Evil_red","Evil_blue"),
            //});
            //AddLocal(new string[] { "test" },
            // new DifData[] {
            //    new DifData("Evil_blue") { s=ss, Rot = 30},
            //    new DifData("Evil_red","Evil_blue"),
            //});



        }
    }
}
