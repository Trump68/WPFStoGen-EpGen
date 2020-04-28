using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Art
{
    public class ART_Momofuki_Rio : Person
    {

        public ART_Momofuki_Rio(string name, string type) : base(name, type) { }
        public static string ImagePath = @"e:\!STOGENDB\READY\ART\Momofuki_Rio\";

        public static ART_Momofuki_Rio Load()
        {
            ART_Momofuki_Rio art = new ART_Momofuki_Rio("ART of Momofuki Rio", "ART");
           
            for (int ii = 1; ii <= 83; ii++)
            {
                art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{ii}", $@"{ImagePath}{ii.ToString("D3")}.jpg", "Обложка", "Цвет")); 
            }

            int i = 84;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{ImagePath}002a.jpg", "", ""));i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1000}", $@"{ImagePath}002-mouth01.png", "", "")); i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.NipplesGeneric},{Feature.FeatureNipples}{1000}", $@"{ImagePath}002-nipples01.png", "", "")); i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1000}", $@"{ImagePath}002-blush01.png", "", "")); i++;

            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{ImagePath}003a.jpg", "", "")); i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1001}", $@"{ImagePath}003-mouth01.png", "", "")); i++;

            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{ImagePath}002b.jpg", "", "")); i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1002}", $@"{ImagePath}002-mouth02.png", "", "")); i++;

            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{ImagePath}004a.jpg", "", "")); i++;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Feature.MouthNormal}{1003}", $@"{ImagePath}004-mouth01.png", "", "")); i++;

            return art;
        }

    }
}
