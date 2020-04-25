using StoGen.Classes;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGen.Classes.Scene;
using StoGenerator.Stories;

namespace StoGenerator.Persons
{
    public class JennyFord : Person //Kazoku ~Haha To Shimai No Kyousei~
    {
        public static string ImagePath = @"e:\!STOGENDB\READY\CHR\F\JennyFord\";


      
        public enum Eyes
        {
            Eyes2_78,
            Eyes1_70,
            Eyes1_67,
            Eyes1_68,
            Eyes1_69,
            Eyes1_71,
            Eyes1_72,
            Eyes1_73,
            Eyes1_74,
            Eyes1_75,
            Eyes1_76,
            Eyes1_77,
            EyesBlink1,
            EyesBlink2,
            Eyes2_80,
            Eyes2_83,
            Eyes2_81,
            Eyes2_84,
            Eyes2_79,
            Eyes2_82,
            Eyes2_85,
            Eyes2_87,
            Eyes2_86,
            Eyes2_88,
        }
        public enum Mouth
        {
            Mouth2_78,
            Mouth1_70,
            Mouth1_67,
            Mouth1_68,
            Mouth1_71,
            Mouth1_69,
            Mouth1_72,
            Mouth1_74,
            Mouth1_73,
            Mouth1_75,
            Mouth1_77,
            Mouth1_76,
            Mouth2_79,
            Mouth2_80,
            Mouth2_81,
            Mouth2_83,
            Mouth2_84,
            Mouth2_85,
            Mouth2_82,
            Mouth2_86,
            Mouth2_88,
            Mouth2_87
        }

        public JennyFord(string name, string type) : base(name, type) { }
        public static JennyFord Load()
        {
            JennyFord person = new JennyFord("Jenny Ford", "Wife");
            int i = 1;
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{ImagePath}Figure001_1.png","Голая","Поза 1")); ++i;
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1}",
                "Голая,соски", "Поза 1")); ++i;
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", 
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1}",
                "Голая,соски,обр.кольцо(г)", "Поза 1")); ; ++i;
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PregnantTammy}{1}",
                "Голая,соски,обр.кольцо(г),беременная", "Поза 1")); ; ++i;

            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1}", $@"{ImagePath}Blush_1_001.png", null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.NipplesGeneric},{Feature.FeatureNipples}{1}", $@"{ImagePath}Nipple001_1.png", null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.WeddingRingGeneric},{Feature.WeddingRing}{1}", $@"{ImagePath}FingerRing001_1.png", null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.PregnantTammyGeneric},{Feature.PregnantTammy}{1}", $@"{ImagePath}PregnantTammyNaked001_1.png", null, $"{Poses.Pose}{1}"));
            
            //person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Poses.Pose}{1},{Outfit.Nightgown}",$@"{ImagePath}Nightgown1.png",null,null));
            //person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FigureGeneric},{Poses.Pose}{2},{Outfit.Nightgown}",$@"{ImagePath}Nightgown2.png",null,null));


            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},,{Generic.MouthGeneric},{Mouth.Mouth1_67}", $@"{ImagePath}Mouth_1_067.png",null,null));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_68}", $@"{ImagePath}Mouth_1_068.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_69}", $@"{ImagePath}Mouth_1_069.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_70}", $@"{ImagePath}Mouth_1_070.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_71}", $@"{ImagePath}Mouth_1_071.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_72}", $@"{ImagePath}Mouth_1_072.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_73}", $@"{ImagePath}Mouth_1_073.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_74}", $@"{ImagePath}Mouth_1_074.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_75}", $@"{ImagePath}Mouth_1_075.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_76}", $@"{ImagePath}Mouth_1_076.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth1_77}", $@"{ImagePath}Mouth_1_077.png",null, $"{Poses.Pose}{1}"));


            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_67}", $@"{ImagePath}Eyes_1_067.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_68}", $@"{ImagePath}Eyes_1_068.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_69}", $@"{ImagePath}Eyes_1_069.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_70}", $@"{ImagePath}Eyes_1_070.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_71}", $@"{ImagePath}Eyes_1_071.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_72}", $@"{ImagePath}Eyes_1_072.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_73}", $@"{ImagePath}Eyes_1_073.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_74}", $@"{ImagePath}Eyes_1_074.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_75}", $@"{ImagePath}Eyes_1_075.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_76}", $@"{ImagePath}Eyes_1_076.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes1_77}", $@"{ImagePath}Eyes_1_077.png",null, $"{Poses.Pose}{1}"));

            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.BlinkGeneric},{Eyes.EyesBlink1}", $@"{ImagePath}Eyes_1_blink1.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1}", $@"{ImagePath}Blush_1_001.png",null, $"{Poses.Pose}{1}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.BlinkGeneric},{Eyes.EyesBlink2}", $@"{ImagePath}Eyes_2_blink1.png",null, $"{Poses.Pose}{2}"));

            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_78}", $@"{ImagePath}Mouth_2_078.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_79}", $@"{ImagePath}Mouth_2_079.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_80}", $@"{ImagePath}Mouth_2_080.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_81}", $@"{ImagePath}Mouth_2_081.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_82}", $@"{ImagePath}Mouth_2_082.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_83}", $@"{ImagePath}Mouth_2_083.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_84}", $@"{ImagePath}Mouth_2_084.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_85}", $@"{ImagePath}Mouth_2_085.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_86}", $@"{ImagePath}Mouth_2_086.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_87}", $@"{ImagePath}Mouth_2_087.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.Mouth2_88}", $@"{ImagePath}Mouth_2_088.png",null, $"{Poses.Pose}{2}"));            
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_78}", $@"{ImagePath}Eyes_2_078.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_79}", $@"{ImagePath}Eyes_2_079.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_80}", $@"{ImagePath}Eyes_2_080.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_81}", $@"{ImagePath}Eyes_2_081.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_82}", $@"{ImagePath}Eyes_2_082.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_83}", $@"{ImagePath}Eyes_2_083.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_84}", $@"{ImagePath}Eyes_2_084.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_85}", $@"{ImagePath}Eyes_2_085.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_86}", $@"{ImagePath}Eyes_2_086.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_87}", $@"{ImagePath}Eyes_2_087.png",null, $"{Poses.Pose}{2}"));
            person.Files.Add(new Tuple<string, string, string, string>($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.Eyes2_88}", $@"{ImagePath}Eyes_2_088.png",null, $"{Poses.Pose}{2}"));
            Storage.Add(person);
            return person;
        }



        //public List<Info_Scene> Get(Poses pose, Outfit outfit, Eyes eyes, Mouth mouth, Feature[] features)
        //{
        //    List<Info_Scene> result = new List<Info_Scene>();
        //    // check figures
        //    var list = Files.Where(x => x.Item1.Contains(Figure.Full.ToString()) && x.Item1.Contains(pose.ToString())).ToList();
        //    if (list.Any())
        //    {
        //        GetOutfit(outfit, list, result);
        //        GetEyes(eyes, list, result);
        //        GetMouth(mouth, list, result);
        //    }
        //    return result;
        //}      
        //private void GetOutfit(Outfit outfit, List<new Tuple<string, string, string, string>> list, List<Info_Scene> result)
        //{
        //    //List<new Tuple<string, string, string, string>> res = new List<new Tuple<string, string, string, string>>();
        //    var v = list.Where(x => x.Item1.Contains(Figure.Full.ToString()) && x.Item1.Contains(outfit.ToString())).ToList();
        //    if (v.Any())
        //    {
        //        result.Add(this.ToSceneInfo(v.First()));
        //        list.Clear();
        //        list.Add(v.First());
        //    }
        //    //return res;
        //}
        //private void GetEyes(Eyes eyes, List<new Tuple<string, string, string, string>> list, List<Info_Scene> result)
        //{
        //    var v = list.Where(x => x.Item1.Contains(eyes.ToString())).ToList();
        //    if (!v.Any())
        //    {
        //        var v1 = Files.Where(x =>
        //        x.Item1.Contains(Generic.FeatureGeneric.ToString()) && x.Item1.Contains(eyes.ToString())).ToList();
        //        if (v1.Any())
        //        {
        //            result.Add(this.ToSceneInfo(v1.First()));
        //        }
        //    }
        //}
        //private void GetMouth(Mouth mouth, List<new Tuple<string, string, string, string>> list, List<Info_Scene> result)
        //{
        //    var v = list.Where(x => x.Item1.Contains(mouth.ToString())).ToList();
        //    if (!v.Any())
        //    {
        //        var v1 = Files.Where(x =>
        //        x.Item1.Contains(Generic.FeatureGeneric.ToString()) && x.Item1.Contains(mouth.ToString())).ToList();
        //        if (v1.Any())
        //        {
        //            result.Add(this.ToSceneInfo(v1.First()));
        //        }
        //    }
        //}
        //internal void RemoveBlink(List<Info_Scene> posture, Poses pose, Eyes eyes)
        //{
        //    Info_Scene v = FindEyes(eyes, pose);
        //    if (v != null)
        //    {
        //        for (int i = 0; i < posture.Count(); i++)
        //        {
        //            if (posture[i].File == v.File)
        //            {
        //                posture.RemoveAt(i);
        //                return;
        //            }
        //        }
        //    }
        //}




        //private Info_Scene FindMouth(Mouth mouth, Poses pose)
        //{
        //    var v = Files.Where(
        //         x => x.Item1.Contains(Generic.FeatureGeneric.ToString())
        //         && x.Item1.Contains(pose.ToString())
        //         && x.Item1.Contains(mouth.ToString())
        //         ).FirstOrDefault();
        //    if (v != null)
        //    {
        //        return this.ToSceneInfo(v);
        //    }
        //    return null;
        //}
        //private Info_Scene FindEyes(Eyes eyes, Poses pose)
        //{
        //    var v = Files.Where(
        //         x => x.Item1.Contains(Generic.FeatureGeneric.ToString())
        //         && x.Item1.Contains(pose.ToString())
        //         && x.Item1.Contains(eyes.ToString())
        //         ).FirstOrDefault();
        //    if (v != null)
        //    {
        //        return this.ToSceneInfo(v);
        //    }
        //    return null;
        //}
        //public List<Info_Scene> Combine(List<Info_Scene> posture, Poses pose, Mouth mouth, bool transition)
        //{
        //    List<Info_Scene> result = new List<Info_Scene>();
        //    var newmouth = FindMouth(mouth, pose);
        //    if (newmouth == null)
        //        return posture;
        //    bool prevMouseFound = false;

        //    foreach (var i in posture)
        //    {
        //        var itempocy = Info_Scene.GenerateCopy(i);
        //        //itempocy.T = null;
        //        //itempocy.O = null;
        //        var info = Files.Where(
        //            x => x.Item1.Contains(Generic.FeatureGeneric.ToString())
        //            &&  x.Item2 == itempocy.File).FirstOrDefault();

        //        if (info != null)
        //        {
        //            bool additem = true;
        //            foreach (var mv in Enum.GetValues(typeof(Mouth)))
        //            {
        //                if (info.Item1.Contains(mv.ToString())) // 
        //                {
        //                    additem = false;
        //                    if (info.Item1.Contains(mouth.ToString()))
        //                    {                              
        //                        continue;
        //                    }
        //                    else
        //                    {
        //                        if (!transition || prevMouseFound)
        //                        {
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            result.Add(newmouth); // add new mouth
        //                            prevMouseFound = true;
        //                            itempocy.O = "100";
        //                            itempocy.T = "W..0>O.B.1000.-100"; // prev mouth make it dissappearing
        //                            result.Add(itempocy);
        //                        }
        //                    }
        //                }
        //            }
        //            if (additem)
        //                result.Add(itempocy);
        //        }
        //        else
        //        {
        //            result.Add(itempocy);
        //        }

        //    }
        //    if (!prevMouseFound)
        //    {
        //        if (transition)
        //        {
        //            newmouth.O = "0";
        //            newmouth.T = "W..0>O.B.1000.100";// new mouth make it appearing
        //        }
        //        result.Add(newmouth);
        //    }

        //    return result;
        //}
        //public List<Info_Scene> Combine(List<Info_Scene> posture, Poses pose, Eyes eyes, bool transition)
        //{
        //    List<Info_Scene> result = new List<Info_Scene>();
        //    var newmouth = FindEyes(eyes, pose);
        //    if (newmouth == null)
        //        return posture;
        //    bool prevMouseFound = false;

        //    foreach (var i in posture)
        //    {
        //        var itempocy = Info_Scene.GenerateCopy(i);
        //        //itempocy.T = null;
        //        //itempocy.O = null;
        //        var info = Files.Where(
        //            x => x.Item1.Contains(Generic.FeatureGeneric.ToString())
        //            && x.Item2 == itempocy.File).FirstOrDefault();

        //        if (info != null)
        //        {
        //            bool additem = true;
        //            foreach (var mv in Enum.GetValues(typeof(Eyes)))
        //            {

        //                if (info.Item1.Contains(mv.ToString())) // 
        //                {
        //                    additem = false;
        //                    if (info.Item1.Contains(eyes.ToString()))
        //                    {
        //                        continue;
        //                    }
        //                    else
        //                    {
        //                        if (!transition || prevMouseFound)
        //                        {
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            result.Add(newmouth); // add new mouth
        //                            prevMouseFound = true;
        //                            itempocy.O = "100";
        //                            itempocy.T = "W..0>O.B.1000.-100"; // prev mouth make it dissappearing
        //                            result.Add(itempocy);
        //                        }
        //                    }
        //                }
        //            }
        //            if (additem)
        //                result.Add(itempocy);
        //        }
        //        else
        //        {
        //            result.Add(itempocy);
        //        }

        //    }
        //    if (!prevMouseFound)
        //    {
        //        if (transition)
        //        {
        //            newmouth.O = "0";
        //            newmouth.T = "W..0>O.B.1000.100";// new mouth make it appearing
        //        }
        //        result.Add(newmouth);
        //    }

        //    return result;
        //}




        // New +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //public List<Info_Scene> WoreNightgown(List<Info_Scene> posture, Poses pose)
        //{
        //    return GetFigure(posture, pose.ToString(), Outfit.Nightgown.ToString(), Trans.Dissapearing(1000));
        //}

        //public List<Info_Scene> SetFace70(List<Info_Scene> posture)
        //{         
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_70.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_70.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace72_67(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_72.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_67.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace72_71(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_72.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_71.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace74_67(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_74.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_67.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace71(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_71.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_71.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace72(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_72.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_72.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);            
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace75(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_75.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_75.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace76(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_76.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_76.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);           
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace77(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes1_77.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth1_77.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink1);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace78(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes2_78.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth2_78.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink2);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace79(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes2_79.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth2_79.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink2);
        //    return posture;
        //}
        //public List<Info_Scene> SetFace86(List<Info_Scene> posture)
        //{
        //    if (posture == null) posture = new List<Info_Scene>();
        //    Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
        //    posture = SetFeature(posture, pose.ToString(), Eyes.Eyes2_86.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = SetFeature(posture, pose.ToString(), Mouth.Mouth2_86.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
        //    posture = AddBlink(posture, Eyes.EyesBlink2);
        //    return posture;
        //}

        public List<Info_Scene> AddBlink(List<Info_Scene> posture, Eyes eyes)
        {
            //Poses pose = (!posture.Any() || posture.First().Tags.Contains($"{Poses.Pose}{1}")) ? Poses.Stand1 : Poses.Stand2;
            posture = base.AddBlink(posture, eyes.ToString());
            posture.Last().O = "100";
            return posture;
        }
        internal List<Info_Scene> Blush(List<Info_Scene> posture, bool reverse = false, int? speed = null)
        {
            //Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            string transition = null;
            if (speed.HasValue)
            {
                transition = Trans.Appearing(speed.Value);
                if (reverse)
                    transition = Trans.Dissapearing(speed.Value);
            }                
            posture = SetFeature(posture, Feature.FeatureBlush.ToString()+"1",null, transition, false);
            posture.Last().O = "0";
            if (reverse)
            {
                posture.Last().O = "100";
            }
            return posture;
        }
        internal List<Info_Scene> RemoveBlush(List<Info_Scene> posture)
        {
            posture.RemoveAll(x => x.Tags.Contains(Feature.FeatureBlush.ToString()+"1"));
            return posture;
        }
    }
}
