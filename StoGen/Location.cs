using Newtonsoft.Json;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{

    public class Location :BaseGeneratorItem<Location>
    {
        public static string ImagePath = @"e:\!STOGENDB\DB\Bg\";
        public Location(string name, string type) : base(name, type) { }

        // static
        public static string Sys_Background_White = "Sys_White_Background";
        public static void InitDefaultLocations()
        {
            Storage.Clear();
            Location var = new Location(Sys_Background_White, "system");
            var.Files.Add(new Tuple<string, string>("system", "$$WHITE$$"));
            var = new Location("Apartment 001", "Apartment");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}01\115.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}01\117.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}01\116.jpg"));
            Storage.Add(var);
        }

        private static void TestSave(string file)
        {
            Storage.Clear();
            Location var = new Location("Apartment 001", "Apartment");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}01\115.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}01\117.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}01\116.jpg"));
            Storage.Add(var);
            File.WriteAllText(file, JsonConvert.SerializeObject(Storage,Formatting.Indented));
        }
        protected override Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = base.ToSceneInfo(spec, queue, group);
            result.Kind = 9;
            return result;
        }

    }
}
