using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Art
{

    public class ART_Horikawa_Gorou : Person
    {

        public ART_Horikawa_Gorou(string name, string type) : base(name, type) { }
        public static string ImagePath = @"e:\!STOGENDB\READY\ART\Horikawa_Gorou\";

        public static ART_Horikawa_Gorou Load()
        {
            ART_Horikawa_Gorou art = new ART_Horikawa_Gorou("ART of Horikawa Gorou", "ART");

            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{ImagePath}0001.png", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{ImagePath}0002.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{ImagePath}0003.png", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{ImagePath}0004.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1004}", $@"{ImagePath}0005.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1005}", $@"{ImagePath}0006.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1006}", $@"{ImagePath}0007.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1007}", $@"{ImagePath}0008.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1008}", $@"{ImagePath}0009.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1009}", $@"{ImagePath}0010.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1010}", $@"{ImagePath}0011.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1011}", $@"{ImagePath}0012.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1012}", $@"{ImagePath}0013.jpg", "", "", art.Name));
            art.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1013}", $@"{ImagePath}0014.jpg", "", "", art.Name));

            return art;
        }
    }
}
