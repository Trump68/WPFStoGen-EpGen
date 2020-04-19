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
        public enum Figure
        {
            Full,
            Feature
        }
        public enum Feature
        {
            Full,
            Head,
            Feature
        }
        public Person(string name, string type) : base(name, type) { }

        public static void TestSave(string file)
        {
            Storage.Clear();
            File.WriteAllText(file, JsonConvert.SerializeObject(Storage, Formatting.Indented));
        }

        protected override Info_Scene ToSceneInfo(Tuple<string, string> item)
        {
            Info_Scene result = base.ToSceneInfo(item);
            result.Kind = 0;
            return result;
        }
        protected List<Info_Scene> SetFeature(List<Info_Scene> posture, string pose, string feature, string itemgeneric, string transition)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var neweyes = this.Files.FirstOrDefault(x => x.Item1.Contains(feature) && x.Item1.Contains(pose));
            if (neweyes != null)
            {
                var oldeyes = posture.Where(x => x.Tags.Contains(itemgeneric)).OrderBy(x => x.Z).FirstOrDefault();
                posture.RemoveAll(x => x.Tags.Contains(itemgeneric));
                posture.Add(this.ToSceneInfo(neweyes));
                if (oldeyes != null && !string.IsNullOrEmpty(transition))
                {
                    oldeyes.O = "0";
                    oldeyes.T = transition;
                    posture.Add(oldeyes);
                }
            }
            return posture;
        }
        public List<Info_Scene> WoreOutfit(List<Info_Scene> posture, string pose, string outfit)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var v = this.Files.FirstOrDefault(x => x.Item1.Contains(outfit) && x.Item1.Contains(pose));
            if (v != null)
            {
                posture.RemoveAll(x => x.Tags.Contains(Feature.Full.ToString()));
                posture.Add(this.ToSceneInfo(v));
            }
            return posture;
        }
        internal void AddToStory(StoryBase story, List<Info_Scene> posture, int startLevel)
        {
            foreach (var item in posture)
            {
                item.Z = (startLevel++).ToString();
                item.Group = story.currentGroup;
                item.Queue = story.currentQueue;
                story.Scenario.Scenes.Add(item);
            }
        }
    }
}
