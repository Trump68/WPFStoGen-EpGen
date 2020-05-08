using StoGen.Classes;
using StoGen.Classes.Persons;
using StoGen.Classes.Transition;
using StoGenerator.Art;
using StoGenerator.CadreElements;
using System.Linq;

namespace StoGenerator.Stories
{
    public class Works_Momofuki_Rio : StoryBase
    {
        public static string StoryName = "Momofuki Rio Works";
        protected ART_Momofuki_Rio Art;
        protected override string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=1200;DefTextShift=1000;DefTextWidth=900;DefFontSize=32;DefFontColor=#E74C3C;DefTextAlignH=3;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 1200; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
        public Works_Momofuki_Rio() : base()
        {
            this.Name = Works_Momofuki_Rio.StoryName;
            this.FileName = this.Name;
            Art = ART_Momofuki_Rio.Load();
            //FCurrentPosition.Z = "1";
            //FCurrentPosition.S = "1200";
            //FCurrentPosition.X = "0";
            //FCurrentPosition.Y = "0";
        }
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            //MakeTitle();
            FillData();
        }
        protected override void FillData()
        {
            Info_Scene position = new Info_Scene() { Z = "1", S = "1200", X = "0", Y = "0" };
            int fs = 32;
            CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);

            Layers = Art.SetFeature(null, $"{Person.Feature.FeatureFigure}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.MouthNormal}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.FeatureNipples}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers.Last().T = Trans.Pulsation(500, 100);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.FeatureBlush}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers.Last().T = Trans.Pulsation(500, 100);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Momofuki_Rio\Momofuki_Rio.txt@0001");

            Layers = Art.SetFeature(null, $"{Person.Feature.FeatureFigure}{1001}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.MouthNormal}{1001}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Momofuki_Rio\Momofuki_Rio.txt@0001");

            Layers = Art.SetFeature(null, $"{Person.Feature.FeatureFigure}{1002}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.MouthNormal}{1002}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Momofuki_Rio\Momofuki_Rio.txt@0002");

            Layers = Art.SetFeature(null, $"{Person.Feature.FeatureFigure}{1003}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            Layers = Art.SetFeature(Layers, $"{Person.Feature.MouthNormal}{1003}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Momofuki_Rio\Momofuki_Rio.txt@0003");

            for (int i = 1; i <= 83; i++)
            {
                Layers = Art.SetFeature(null, $"{Person.Feature.FeatureFigure}{i}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
                MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Momofuki_Rio\Momofuki_Rio.txt@0000");
            }
        }
    }
}
