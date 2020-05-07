using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Persons.Fems
{

    public class _FemaleStandart : Person
    {
        public _FemaleStandart() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\CHR\F\_FemaleStandart\";
            Name = "_Female Standart";
            Age = 24;
            Sex = 'F';
            Tribe = "Oosaki Shinya";
        }
        public static _FemaleStandart Load()
        {
            _FemaleStandart person = new _FemaleStandart();

            person.Positions.Add(new Info_Scene() { S = "1200", X = "400", Y = "0", Z = "1", Story = "Default" });

            int i = 1;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i},{OutfitName.CasHome_I}{1}", $@"{person.ImagePath}Outfit01_1.png", "Казуальный по умолчанию", "Поза 1", person.Name)); ++i;


            return person;
        }
    }
}
