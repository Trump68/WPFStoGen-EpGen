﻿using Newtonsoft.Json;
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
        public enum OutfitName
        {
            CasHome_I,
            OutfitDefault_I
        }
        public enum FaceName
        {
            FaceNeitral_I,
            FaceDefault_I
        }
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
            FeatureBlink,
            FaceGeneric
        }
        public enum Poses
        {
            Pose,
        }
        public Person(string name, string type) : base(name, type) { }
        public Info_Scene GetPositionByName(string name)
        {
            var position = Positions.Where(x => x.Story == name).FirstOrDefault();
            if (position == null)
                position = Positions.Where(x => x.Story == "Default").FirstOrDefault();
            if (position == null)
                position = Positions.FirstOrDefault();
            return position;
        }



        protected override Info_Scene ToSceneInfo(ItemData item)
        {
            Info_Scene result = base.ToSceneInfo(item);
            result.Kind = 0;
            return result;
        }
        public List<Info_Scene> AddBlink(List<Info_Scene> posture, string eyes, Info_Scene position)
        {
            return SetFeature(posture, eyes, null, Trans.Eyes_Blink, false, position);
        }
        public List<Info_Scene> SetFeature(List<Info_Scene> posture, string feature, string tranOfPrev, string tranOfNew, bool AddBeforePrev, Info_Scene position)
        {
            if (posture == null) posture = new List<Info_Scene>();
            var info = this.Files.FirstOrDefault(x => x.Features.Contains(feature));
            if (info != null)
            {
                string itemgeneric = info.Features.Split(',')[1];
                var newFeature = this.ToSceneInfo(info);
                newFeature.Description = info.Category;
                if (newFeature.Kind == 0 && position != null)
                {
                    newFeature.S = position.S;
                    newFeature.X = position.X;
                    newFeature.Y = position.Y;
                }
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
                        if (x.Kind == 0 && position == null)
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
        public List<Info_Scene> GetFace(List<Info_Scene> posture, string eyes, string mouth, string blink, Info_Scene position)
        {
            if (posture == null) posture = new List<Info_Scene>();
            posture = SetFeature(posture, eyes, Trans.Dissapearing(1000), null, true, position);
            posture = SetFeature(posture, mouth, Trans.Dissapearing(1000), null, true, position);
            if (!string.IsNullOrEmpty(blink))
            {
                AddBlink(posture, blink, position);
                posture.Last().O = "100";
            }
            var figure = posture.Where(x => x.Tags.Contains(Generic.FigureGeneric.ToString())).FirstOrDefault();
            if (figure != null)
            {
                posture.ForEach(x =>
                {
                    x.Group = figure.Group;
                    x.Queue = figure.Queue;
                });

            }

            return posture;
        }
        public List<Info_Scene> GetFace(List<Info_Scene> posture, string face, Info_Scene position)
        {
            var info = this.Files.FirstOrDefault(x => x.Features.Contains(face));
            if (info != null)
            {
                var vals = info.File.Split(',');
                string eyes = vals[0];
                string mouth = vals[1];
                string blink = vals[2];
                return GetFace(posture, eyes, mouth, blink, position);
            }
            return posture;
        }
        public List<Info_Scene> GetFigure(List<Info_Scene> layers, string outfit, string tranOfPrev, string tranOfNew, Info_Scene position)
        {
            if (layers == null) layers = new List<Info_Scene>();
            ItemData info = null;
            if (string.IsNullOrEmpty(outfit))
            {
                info = this.Files.FirstOrDefault(x => x.Features.Contains($"{Generic.FigureGeneric}"));
            }
            else
                info = this.Files.FirstOrDefault(x => x.Features.Contains(outfit));
            if (info != null)
            {
                var newfigure = this.ToSceneInfo(info);
                newfigure.Description = info.Category;                
                if (newfigure.Kind == 0 && position != null)
                {
                    newfigure.S = position.S;
                    newfigure.X = position.X;
                    newfigure.Y = position.Y;
                }
                var oldFigure = layers.Where(x => x.Tags.Contains($"{Generic.FigureGeneric}")).OrderBy(x => x.Z).FirstOrDefault();
                layers.RemoveAll(x =>
                x.Tags.Contains($"{Generic.FigureGeneric}")
                ||
                (x.Tags.Contains($"{Generic.FeatureGeneric}")));
                layers.Insert(0, newfigure);
                if (oldFigure != null) // do not add same feature
                {
                    layers.ForEach(x =>
                    {
                        x.Group = oldFigure.Group;
                        x.Queue = oldFigure.Queue;
                        if (x.Kind == 0 && position == null)
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
                        layers.Add(oldFigure);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(tranOfNew))
                    {
                        newfigure.T = tranOfNew;
                        newfigure.O = "0";
                    }
                }
            }
            return layers;
        }
        public List<Info_Scene> CombinePerson(List<Info_Scene> posture, ItemData feature, Info_Scene position, int ms)
        {
            List<string> features = feature.File.Split(',').ToList();
            if (features.Count == 1)
            {
                posture = GetFigure(posture, feature.Features, Trans.Dissapearing(ms), Trans.Appearing(ms), position);
            }
            else
            {
                foreach (var it in features)
                {
                    if (it == features.First())
                        posture = GetFigure(posture, it, Trans.Dissapearing(ms), Trans.Appearing(ms), position);
                    else
                    {
                        posture = SetFeature(posture, it, Trans.Dissapearing(ms), Trans.Appearing(ms), true, position);
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




        // Static Storage
        private static List<Person> _Storage;
        public static List<Person> Storage
        {
            get
            {
                if (_Storage == null)
                {
                    _Storage = new List<Person>();
                }
                return _Storage;
            }
        }
        private Cell _CurrentHome;
        public Cell CurrentHome
        {
            get { return _CurrentHome; }
            set { _CurrentHome = value; if (!_CurrentHome.HomeOf.Contains(this)) _CurrentHome.HomeOf.Add(this); }
        }
        private Cell _CurrentCell;
        public Cell CurrentCell
        {
            get { return _CurrentCell; }
            set { _CurrentCell = value; if (!_CurrentCell.Persons.Contains(this)) _CurrentCell.Persons.Add(this); }
        }
    }
}
