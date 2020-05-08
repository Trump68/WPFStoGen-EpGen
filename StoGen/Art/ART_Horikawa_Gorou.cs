using StoGen.Classes.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Art
{

    public class ART_Horikawa_Gorou : Person
    {

        public ART_Horikawa_Gorou() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\";
            Name = "ART of Horikawa Gorou";
            Type = "ART";
        }


        public static ART_Horikawa_Gorou Load()
        {
            ART_Horikawa_Gorou art = new ART_Horikawa_Gorou();

            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{art.ImagePath}0001.png", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{art.ImagePath}0002.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{art.ImagePath}0003.png", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{art.ImagePath}0004.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1004}", $@"{art.ImagePath}0005.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1005}", $@"{art.ImagePath}0006.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1006}", $@"{art.ImagePath}0007.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1007}", $@"{art.ImagePath}0008.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1008}", $@"{art.ImagePath}0009.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1009}", $@"{art.ImagePath}0010.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1010}", $@"{art.ImagePath}0011.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1011}", $@"{art.ImagePath}0012.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1012}", $@"{art.ImagePath}0013.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1013}", $@"{art.ImagePath}0014.jpg", "", "", art.Name));

            return art;
        }
    }
}
