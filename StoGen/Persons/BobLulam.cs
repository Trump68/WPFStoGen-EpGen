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
        public BobLulam() : base()
        {
            Tribe = "Unknown";
            Age = 36;
            Sex = 'M';
            Name = "Bob Lulam";
            ImagePath = @"e:\!STOGENDB\READY\CHR\M\Bo Lulam\";           
        }

        public static BobLulam Load()
        {
            BobLulam person = new BobLulam();
            
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{OutfitName.CasHome_I}", $@"{person.ImagePath}001.png", "Казуальный", "Поза 1", person.Name));

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{person.ImagePath}001.png", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{person.ImagePath}002.png", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{person.ImagePath}003.jpg", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{person.ImagePath}004.jpg", "", "", person.Name));
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1004}", $@"{person.ImagePath}005.jpg", "", "", person.Name));

            person.Positions.Add(new Info_Scene() { S= "1400", X = "0", Y= "150", Z="1", Story ="Default" });
            return person;
        }        
    }
}
