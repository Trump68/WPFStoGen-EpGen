using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Persons
{
    public class BobLulam: Person
    {
        public BobLulam(string name, string type) : base(name, type) { }
        public static string ImagePath = @"e:\!STOGENDB\READY\CHR\M\Bo Lulam\";
        public static string ArtName = "Bob Lulam";
        public static BobLulam Load()
        {
            BobLulam person = new BobLulam(BobLulam.ArtName, "bully");

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{OutfitName.CasHome_I}", $@"{ImagePath}001.png", "Казуальный", "Поза 1", person.Name));

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{ImagePath}001.png", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{ImagePath}002.png", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{ImagePath}003.jpg", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{ImagePath}004.jpg", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1004}", $@"{ImagePath}005.jpg", "", "", person.Name));

            person.Positions.Add(new Info_Scene() { S= "1400", X = "0", Y= "150", Z="1", Story ="Default" });
            return person;
        }        
    }
}
