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
    public class Person : BaseGeneratorItem<Person>
    {
        public Person(string name, string type) : base(name, type) { }

        public static void TestSave(string file)
        {
            Storage.Clear();
            Load_JennyFord();
            File.WriteAllText(file, JsonConvert.SerializeObject(Storage, Formatting.Indented));
        }
        public static void Load_JennyFord()
        {
            Person var = new Person("Jenny Ford", "Wife");
            for (int i = 1; i < 1310; i++)
            {
                var.Files.Add(new Tuple<string, string>($"{i.ToString("D4")}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\{i.ToString("D4")}.png"));
            }
            Storage.Add(var);
        }
        protected override Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = base.ToSceneInfo(spec, queue, group);
            result.Kind = 0;
            return result;
        }
    }
}
