using Newtonsoft.Json;
using StoGen.Classes;
using StoGen.Classes.Transition;
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
        public List<Info_Scene> SetFeature(List<Info_Scene> posture, string pose, string feature, string itemgeneric, string tranOfPrev, string tranOfNew, bool removeAllSimilar, bool AddBeforePrev)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var info = this.Files.FirstOrDefault(x => x.Item1.Contains(feature) && x.Item1.Contains(pose));
            if (info != null)
            {
                var newFeature = this.ToSceneInfo(info);
                var oldFeature = posture.Where(x => x.Tags.Contains(itemgeneric)).OrderBy(x => x.Z).FirstOrDefault();
                if (removeAllSimilar)
                {                   
                    posture.RemoveAll(x => x.Tags.Contains(itemgeneric));
                }
                else
                {
                    posture.RemoveAll(x => x.Tags.Contains(feature));
                }
                if (!string.IsNullOrEmpty(tranOfNew))
                {
                    newFeature.T = tranOfNew;
                }

                if (AddBeforePrev)
                    posture.Add(newFeature);
                if (removeAllSimilar)
                {
                    if (oldFeature != null && (oldFeature.File != newFeature.File)) // do not add same feature
                    {
                        oldFeature.O = "100";
                        oldFeature.T = tranOfPrev;
                        posture.Add(oldFeature);
                    }
                }
                if (!AddBeforePrev)
                    posture.Add(newFeature);
            }
            return posture;
        }
        public List<Info_Scene> AddBlink(List<Info_Scene> posture, string pose, string eyes, string eyesgeneric)
        {
            return SetFeature(posture, pose, eyes, eyesgeneric, null, Trans.Eyes_Blink, false,false);
        }
        public List<Info_Scene> WoreOutfit(List<Info_Scene> posture, string pose, string outfit, string tranOfPrev)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var info = this.Files.FirstOrDefault(x => x.Item1.Contains(outfit) && x.Item1.Contains(pose));
            if (info != null)
            {
                var newfigure = this.ToSceneInfo(info);
                var oldFigure = posture.Where(x => x.Tags.Contains(Figure.Full.ToString()) && !x.Tags.Contains(pose)).OrderBy(x => x.Z).FirstOrDefault();
                posture.RemoveAll(x => x.Tags.Contains(Figure.Full.ToString()));
                posture.Insert(0, newfigure);
                if (oldFigure != null && (oldFigure.File != newfigure.File)) // do not add same feature
                {                   
                    oldFigure.O = "100";
                    oldFigure.T = tranOfPrev;
                    posture.Add(oldFigure);
                }
               
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
                story.Scenario.SceneInfoList.Add(item);
            }
        }
        internal List<Info_Scene> ResetPosture(List<Info_Scene> posture)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            foreach (var item in posture)
            {
                var d = Info_Scene.GenerateCopy(item);
                d.T = null; 
                result.Add(d);
            }
            return result;
        }
    }
}
