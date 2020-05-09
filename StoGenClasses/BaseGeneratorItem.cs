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
        public List<ItemData> Files { set; get; } = new List<ItemData>();
        public List<Info_Scene> Positions { set; get; } = new List<Info_Scene>();
        public static List<T> Storage { set; get; } = new List<T>();       
        public BaseGeneratorItem(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        protected virtual Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = null;
            if (Files.Any())
            {
                ItemData file = null;
                if (!string.IsNullOrEmpty(spec))
                {
                    file = Files.FirstOrDefault(x => x.Features == spec);
                }
                if (file == null)
                {
                    file = Files[0];
                }
                result = new Info_Scene();
                result.File = file.File;
                result.Queue = queue;
                result.Group = group;
            }
            return result;
        }
        protected virtual Info_Scene ToSceneInfo(ItemData item)
        {
            Info_Scene result = new Info_Scene();
            result.File = item.File;
            result.Tags = item.Features;
            result.FigureName = item.Figure;
            if (!string.IsNullOrEmpty(item.Direction))
                result.Direction = int.Parse(item.Direction);
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
    public class ItemData
    {
        public ItemData() { }
        public ItemData(string features, string file, string categ, string pose, string figure):this()
        {
            this.Features = features;
            this.File = file;
            this.Category = categ;
            this.Pose = pose;
            this.Figure = figure;
        }
        public string Figure { set; get; }
        public string Features { set; get; }
        public string File { set; get; }
        public string Pose { set; get; }
        public string Category { set; get; }
        public string Direction { get; internal set; }
    }
}
