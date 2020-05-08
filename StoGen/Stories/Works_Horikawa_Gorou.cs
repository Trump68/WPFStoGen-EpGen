using StoGen.Classes;
using StoGen.Classes.Transition;
using StoGenerator.Art;
using StoGenerator.CadreElements;
using static StoGen.Classes.Persons.Person;

namespace StoGenerator.Stories
{
    public class Works_Horikawa_Gorou : StoryBase
    {
        public static string StoryName = "Horikawa Gorou Works";
        protected ART_Horikawa_Gorou Art;
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
        public Works_Horikawa_Gorou() : base()
        {
            this.Name = Works_Horikawa_Gorou.StoryName;
            this.FileName = this.Name;
            Art = ART_Horikawa_Gorou.Load();
            //FCurrentPosition.Z = "1";
            //FCurrentPosition.S = "1366";
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
            Info_Scene position = new Info_Scene() { Z = "1", S = "1366" , X = "0" , Y = "0" };
            int fs = 32;
            CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1013}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1003}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1004}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0002");

            position.S = "1200";
            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1005}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0003");



            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1000}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);           
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1001}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");


            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1002}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");


            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1006}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1007}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1008}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1009}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1010}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1011}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1005}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");

            Layers = Art.SetFeature(null, $"{Feature.FeatureFigure}{1012}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
            MakeNextCadre(Teller.Female, fs, @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\Horikawa_Gorou.txt@0001");


        }
    }
}
