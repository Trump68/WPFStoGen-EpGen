using Newtonsoft.Json;
using StoGen.Classes;
using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{
    public class Sound: BaseGeneratorItem<Sound>
    {
        public Sound(string name, string type) : base(name, type) { }

        internal static void InitDefaultSounds()
        {
            Storage.Clear();
            Sound var = new Sound("Печальная тема 01", "BGM");
            var.Files.Add(new ItemData(null, @"d:\!Sound\NTRPG\0014-kanashimi.mp3",null, null, var.Name));
            Storage.Add(var);
        }

        // static     
        //private static void TestSave(string file)
        //{
        //    Storage.Clear();
        //    Sound var = new Sound("Печальная тема 01", "BGM");
        //    var.Files.Add(new Tuple<string, string>(null, @"d:\!Sound\NTRPG\0014-kanashimi.mp3"));
        //    Storage.Add(var);
        //    File.WriteAllText(file, JsonConvert.SerializeObject(Storage, Formatting.Indented));
        //}
        protected override Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = base.ToSceneInfo(spec, queue, group);
            result.Kind = 6;
            return result;
        }

    }
}
