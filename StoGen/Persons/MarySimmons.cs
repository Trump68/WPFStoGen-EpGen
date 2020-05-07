using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Persons
{
    public class MarySimmons : Person //artist : oosaki shinya
    {
        public MarySimmons() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\CHR\F\MarySimmons\";
            Name = "Mary Simmons";
            Age = 22;
            Sex = 'F';
            Tribe = "Oosaki Shinya";
        }
        public static MarySimmons Load()
        {
            MarySimmons person = new MarySimmons();

            person.Positions.Add(new Info_Scene() { S = "1200", X = "400", Y = "0", Z = "1", Story = "Default" });

            int i = 1;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i},{OutfitName.CasHome_I}{1}", $@"{person.ImagePath}Outfit01_1.png", "Вечерний домашний наряд - халатик", "Поза 1", person.Name)); ++i;


            return person;
        }
    }
}
