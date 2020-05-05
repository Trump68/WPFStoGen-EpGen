using StoGen.Classes;
using StoGen.Classes.Transition;
using StoGenerator.CadreElements;
using StoGenerator.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenerator.Person;

namespace StoGenerator.Stories
{
    public class Person_Bob_Lulam : StoryBase
    {

        public static string StoryName = "Bob Lulam - Evil Coach";
        protected BobLulam Art;
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
        public Person_Bob_Lulam() : base()
        {
            this.Name = Person_Bob_Lulam.StoryName;
            this.FileName = this.Name;
            Art = BobLulam.Load();
        }
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            //MakeTitle();
            FillData();
        }
        protected override void FillData()
        {
            Info_Scene position = new Info_Scene() { Z = "1", S = "1366", X = "0", Y = "0" };
            int fs = 32;
            CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, "sdsd");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1001}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, "sdsd");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1002}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, "sdsd");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1003}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, "sdsd");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1004}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, "sdsd");
        }
    }
}
