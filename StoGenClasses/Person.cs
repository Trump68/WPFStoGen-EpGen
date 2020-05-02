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

        public enum Generic
        {
            //FaceGeneric,
            EyesGeneric,
            MouthGeneric,
            FeatureGeneric,
            NipplesGeneric,
            FigureGeneric,
            BlushGeneric,
            BlinkGeneric,
            WeddingRingGeneric,
            PregnantTammyGeneric,
            PantyGeneric,
            BraGeneric,
            PantyhoseGeneric,
            BluseGeneric,
            SkirtGeneric,
            ShoesGeneric,
            PubicGeneric
        }
        public enum Feature
        {
            FeatureFigure,
            FeatureBlush,
            FeatureNipples,
            WeddingRing,
            PregnantTammy,
            PregnantPanty,
            NormalPanty,
            NormalBra,
            PantyhoseNormal,
            BluseNormal,
            SkirtNormal,
            ShoesNormal,
            MouthNormal,
            PubicNormal,
            FeatureBlink
        }
        public enum Poses
        {
            Pose,
        }
        public Person(string name, string type) : base(name, type) { }

        public static void TestSave(string file)
        {
            Storage.Clear();
            File.WriteAllText(file, JsonConvert.SerializeObject(Storage, Formatting.Indented));
        }
        protected override Info_Scene ToSceneInfo(Tuple<string, string, string, string> item)
        {
            Info_Scene result = base.ToSceneInfo(item);
            result.Kind = 0;
            return result;
        }
        public List<Info_Scene> AddBlink(List<Info_Scene> posture, string eyes)
        {
            return SetFeature(posture, eyes, null, Trans.Eyes_Blink, false);
        }
        public List<Info_Scene> SetFeature(List<Info_Scene> posture, string feature, string tranOfPrev, string tranOfNew, bool AddBeforePrev)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var info = this.Files.FirstOrDefault(x => x.Item1.Contains(feature));
            if (info != null)
            {
                string itemgeneric = info.Item1.Split(',')[1];
                var newFeature = this.ToSceneInfo(info);
                newFeature.Description = info.Item3;
                var oldFeature = posture.Where(x => x.Tags.Contains(itemgeneric)).OrderBy(x => x.Z).FirstOrDefault();
                posture.RemoveAll(x => x.Tags.Contains(itemgeneric));
                if (!string.IsNullOrEmpty(tranOfNew))
                {
                    newFeature.O = "0";
                    newFeature.T = tranOfNew;
                }

                if (AddBeforePrev)
                    posture.Add(newFeature);
                if (oldFeature != null)
                {
                    if (oldFeature.File != newFeature.File)// do not add same feature
                    {
                        oldFeature.O = "100";
                        oldFeature.T = tranOfPrev;
                        posture.Add(oldFeature);
                    }
                }
                if (!AddBeforePrev)
                    posture.Add(newFeature);
                var figure = posture.Where(x => x.Tags.Contains(Generic.FigureGeneric.ToString())).FirstOrDefault();
                if (figure != null)
                {
                    posture.ForEach(x =>
                    {
                        x.Group = figure.Group;
                        x.Queue = figure.Queue;
                        if (x.Kind == 0)
                        {
                            x.S = figure.S;
                            x.X = figure.X;
                            x.Y = figure.Y;
                        }
                    });

                }
            }
            return posture;
        }
        public List<Info_Scene> GetFace(List<Info_Scene> posture, string eyes, string mouth, string blink)
        {
            if (posture == null) posture = new List<Info_Scene>();
            posture = SetFeature(posture, eyes, Trans.Dissapearing(1000), null, true);
            posture = SetFeature(posture, mouth, Trans.Dissapearing(1000), null, true);
            if (!string.IsNullOrEmpty(blink))
            {
                AddBlink(posture, blink);
                posture.Last().O = "100";
            }
            var figure = posture.Where(x => x.Tags.Contains(Generic.FigureGeneric.ToString())).FirstOrDefault();
            if (figure != null)
            {
                posture.ForEach(x =>
                {
                    x.Group = figure.Group;
                    x.Queue = figure.Queue;
                    if (x.Kind == 0)
                    {
                        x.S = figure.S;
                        x.X = figure.X;
                        x.Y = figure.Y;
                    }
                });

            }

            return posture;
        }
        public List<Info_Scene> GetFigure(List<Info_Scene> posture, string outfit, string tranOfPrev)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var info = this.Files.FirstOrDefault(x => x.Item1.Contains(outfit));
            if (info != null)
            {
                var newfigure = this.ToSceneInfo(info);
                newfigure.Description = info.Item3;
                var oldFigure = posture.Where(x => x.Tags.Contains(Generic.FigureGeneric.ToString())).OrderBy(x => x.Z).FirstOrDefault();
                posture.RemoveAll(x =>
                x.Tags.Contains(Generic.FigureGeneric.ToString())
                ||
                (x.Tags.Contains(Generic.FeatureGeneric.ToString())));
                posture.Insert(0, newfigure);
                if (oldFigure != null) // do not add same feature
                {
                    posture.ForEach(x =>
                    {
                        x.Group = oldFigure.Group;
                        x.Queue = oldFigure.Queue;
                        if (x.Kind == 0)
                        {
                            x.S = oldFigure.S;
                            x.X = oldFigure.X;
                            x.Y = oldFigure.Y;
                        }
                    });
                    if (oldFigure.File != newfigure.File)
                    {
                        oldFigure.O = "100";
                        oldFigure.T = tranOfPrev;
                        posture.Add(oldFigure);
                    }
                }
            }
            return posture;
        }

        public virtual List<Tuple<string, string>> GetAllFaceCombinations()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();           
            return list;
        }

    }
}
