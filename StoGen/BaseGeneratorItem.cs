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
    public class BaseGeneratorItem<T> 
    {
        public string Name { set; get; } = "Default Name";
        public string Type { set; get; } = "Default Type";
        public List<Tuple<string, string>> Files { set; get; } = new List<Tuple<string, string>>();
        public static List<T> Storage { set; get; } = new List<T>();
        public BaseGeneratorItem(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        public static void LoadFromFile(string file)
        {
            Storage.AddRange(JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file)));
        }
        protected virtual Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = null;
            if (Files.Any())
            {
                Tuple<string, string> file = null;
                if (!string.IsNullOrEmpty(spec))
                {
                    file = Files.FirstOrDefault(x => x.Item1 == spec);
                }
                if (file == null)
                {
                    file = Files[0];
                }
                result = new Info_Scene();
                result.File = file.Item2;
                result.Queue = queue;
                result.Group = group;
            }
            return result;
        }
        protected virtual Info_Scene ToSceneInfo(Tuple<string, string> item)
        {
            Info_Scene result = new Info_Scene();
            result.File = item.Item2;
            result.Tags = item.Item1;
            return result;
        }
        public static Info_Scene GetByName(string name, string spec, string queue, string group)
        {
            var d = Storage.Where(x => ((x as BaseGeneratorItem<T>).Name == name)).FirstOrDefault();
            if (d != null)
            {
                return (d as BaseGeneratorItem<T>).ToSceneInfo(spec, queue, group);
            }
            return null;
        }
    }
}
