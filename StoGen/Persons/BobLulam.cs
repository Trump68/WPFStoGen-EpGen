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
        public static string Name = "Bob Lulam";
        public static BobLulam Load()
        {
            BobLulam art = new BobLulam(BobLulam.Name, "bully");

            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1000}", $@"{ImagePath}001.png", "", ""));
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1001}", $@"{ImagePath}002.png", "", ""));
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1002}", $@"{ImagePath}003.jpg", "", ""));
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1003}", $@"{ImagePath}004.jpg", "", ""));
            art.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{1004}", $@"{ImagePath}005.jpg", "", ""));
            return art;
        }
    }
}
