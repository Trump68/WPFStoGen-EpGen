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
            this.DefaultSceneText.Shift = 200;
            this.DefaultSceneText.Size = 60;
            this.DefaultSceneText.FontSize = 20;
            this.DefaultSceneText.FontColor = "Yellow";
            //// real
            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this,"TEST");

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue", new DifData() {Rot = 20 })
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
            }, this);

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue", new DifData() {Rot = 20 })
                ,new AlignData("Evil_green","Evil_blue", new DifData() {Rot = -20 })
                ,new AlignData("Evil_red","Evil_green")
            }, this);

            SetCadre(new AlignData[] {
                 new AlignData("Evil_blue", new DifData() {Rot = 20 })
                ,new AlignData("Evil_green","Evil_blue", new DifData() {Rot = -20 })
                ,new AlignData("Evil_red","Evil_green", new DifData() {Rot = 20 })
            }, this);

        }
        internal static void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            
            path = @"d:\Temp\";
            string dsc = string.Empty;
            //raw
            GetIm($"Evil_blue", VNPCPersType.Manga, dsc, path, $"TestBlue.png", data);
            GetIm($"Evil_blue2", VNPCPersType.Manga, dsc, path, $"TestBlue.png", data);
            GetIm($"Evil_red", VNPCPersType.Manga, dsc, path, $"TestRed.png", data);
            GetIm($"Evil_green", VNPCPersType.Manga, dsc, path, $"TestGreen.png", data);
        }
    }

}
