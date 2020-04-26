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
            int i = 1;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}001.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}002.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}003.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}004.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}005.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}006.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}007.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}008.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}009.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}010.jpg", "Оболжка", "Цвет")); ++i;

            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}011.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}012.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}013.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}014.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}015.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}016.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}017.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}018.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}019.jpg", "Оболжка", "Цвет")); ++i;
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}020.jpg", "Оболжка", "Цвет")); ++i;

            return art;
        }

    }
}
