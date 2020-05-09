using EPCat.Model;
using StoGen.Classes;
using StoGen.Classes.Persons;
using StoGen.Classes.Transition;
using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class ArtGenerator : StoryBase
    {
        //public static string StoryName = "Art Generator";
        protected Person Art;
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
        private EpItem CatalogItem;
        public ArtGenerator(EpItem catalogItem) : base()
        {
            CatalogItem = catalogItem;
            this.Name = CatalogItem.Name;
            this.FileName = this.Name;
            Art = new Person();
            Art.ImagePath = Path.Combine(CatalogItem.ItemDirectory, "DATA");            
        }
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            Sound.InitDefaultSounds();
            FillData();
        }
        protected override void FillData()
        {
            var files = Directory.GetFiles(Art.ImagePath,"*.*").Where(s => s.EndsWith(".jpg") || s.EndsWith(".png")); ;
            int i = 0;
            foreach (var file in files)
            {
                var g = Guid.NewGuid();
                Art.Files.Add(new ItemData($"{Person.Generic.FigureGeneric},{g}", $@"{file}", null, null, $"{g}"));
                i++;
            }
            //

            Info_Scene position = new Info_Scene() { Z = "1", S = "1200", X = "0", Y = "0" };
            int fs = 32;
            CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);
            i = 0;
            foreach (var item in Art.Files)
            {
                Layers = Art.SetFeature(null, $"{Person.Generic.FigureGeneric},{item.Figure}", Trans.Dissapearing(1000), Trans.Appearing(1000), true, position);
                MakeNextCadre(Teller.Female, fs, $"{Path.Combine(CatalogItem.ItemDirectory, "story.txt")}@{i.ToString("D4")}");
                i++;
            }
        }
    }
}
