using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class LocationUnit_Aratments_01 : StoryBase
    {

        public static string StoryName = "Location Unit - Aratments 01";
        protected override string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=1100;DefTextShift=1380;DefTextWidth=500;DefFontSize=32;DefFontStyle=2;DefFontName=Segoe Print;DefFontColor=Black;DefTextAlignH=0;DefTextAlignV=9;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 1200; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
        public LocationUnit_Aratments_01() : base()
        {
            this.Name = LocationUnit_Aratments_01.StoryName;
            this.FileName = this.Name;

        }
        public override void Generate(string queue, string group)
        {
            FillData();
        }
        protected override void FillData()
        {
            int fs = 32;
            CE_Location.Add(this, "Romantic 001", "Cream Satin with Bow");
            //F_Posture = Art.SetFeature(null, $"{Feature.FeatureFigure}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true);
            //MakeNextCadre(Teller.Female, fs, "sdsd");
        }
    }
}
