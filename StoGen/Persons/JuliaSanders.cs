﻿using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Persons
{
    public class JuliaSanders : Person 
    {
        public JuliaSanders() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\CHR\F\JuliaSanders\";
            Name = "Julia Sanders";
            Age = 28;
            Sex = 'F';
            Tribe = "Oosaki Shinya";
        }
        public static JuliaSanders Load()
        {
            JuliaSanders person = new JuliaSanders();

            person.Positions.Add(new Info_Scene() { S = "1200", X = "400", Y = "0", Z = "1", Story = "Default" });

            int i = 1;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i},{OutfitName.CasHome_I}{1}", $@"{person.ImagePath}Outfit01_1.png", "Вечерний домашний наряд - халатик", "Поза 1", person.Name)); ++i;


            return person;
        }
    }
}
