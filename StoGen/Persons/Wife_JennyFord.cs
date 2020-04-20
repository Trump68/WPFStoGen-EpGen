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
    public class Wife_JennyFord : Person //Kazoku ~Haha To Shimai No Kyousei~
    {
        public enum Poses
        {
            Stand1,
            Stand2
        }

        public enum Outfit
        {
            Naked,
            Nightgown
        }
        public enum Eyes
        {
            EyesGeneric,
            EyesOpen1,
            EyesOpen2,
            EyesOpen5,
            EyesClosed1,
            EyesBlink1
        }
        public enum Mouth
        {
            MouthGeneric,
            MouthClose1,
            MouthClose2,
            MouthOpen1,
            MouthOpen2,
            MouthOpen5
        }

        public Wife_JennyFord(string name, string type) : base(name, type) { }
        public static Wife_JennyFord Load()
        {
            Wife_JennyFord person = new Wife_JennyFord("Jenny Ford", "Wife");
            person.Files.Add(new Tuple<string, string>(
                $"{Feature.Full},{Poses.Stand1},{Outfit.Nightgown}",
                $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\0067.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Mouth.MouthGeneric},{Mouth.MouthOpen1}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Mouth_1_001.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Mouth.MouthGeneric},{Mouth.MouthOpen2}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Mouth_1_002.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Mouth.MouthGeneric},{Mouth.MouthClose1}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Mouth_1_003.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Mouth.MouthGeneric},{Mouth.MouthClose2}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Mouth_1_004.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Mouth.MouthGeneric},{Mouth.MouthOpen5}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Mouth_1_005.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Eyes.EyesGeneric},{Eyes.EyesOpen1}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Eyes_1_001.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Eyes.EyesGeneric},{Eyes.EyesClosed1}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Eyes_1_003.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Eyes.EyesGeneric},{Eyes.EyesOpen2}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Eyes_1_004.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Eyes.EyesGeneric},{Eyes.EyesOpen5}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Eyes_1_005.png"));
            person.Files.Add(new Tuple<string, string>($"{Feature.Feature},{Poses.Stand1},{Eyes.EyesGeneric},{Eyes.EyesBlink1}", $@"E:\!CATALOG\PRS\Story\HCG - 01\IMAGE\CHARA\37\DB\Eyes_1_blink1.png"));
            Storage.Add(person);
            return person;
        }



        public List<Info_Scene> Get(Poses pose, Outfit outfit, Eyes eyes, Mouth mouth, Feature[] features)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            // check figures
            var list = Files.Where(x => x.Item1.Contains(Feature.Full.ToString()) && x.Item1.Contains(pose.ToString())).ToList();
            if (list.Any())
            {
                GetOutfit(outfit, list, result);
                GetEyes(eyes, list, result);
                GetMouth(mouth, list, result);
            }
            return result;
        }
      
        private void GetOutfit(Outfit outfit, List<Tuple<string, string>> list, List<Info_Scene> result)
        {
            //List<Tuple<string, string>> res = new List<Tuple<string, string>>();
            var v = list.Where(x => x.Item1.Contains(Feature.Full.ToString()) && x.Item1.Contains(outfit.ToString())).ToList();
            if (v.Any())
            {
                result.Add(this.ToSceneInfo(v.First()));
                list.Clear();
                list.Add(v.First());
            }
            //return res;
        }
        private void GetEyes(Eyes eyes, List<Tuple<string, string>> list, List<Info_Scene> result)
        {
            var v = list.Where(x => x.Item1.Contains(eyes.ToString())).ToList();
            if (!v.Any())
            {
                var v1 = Files.Where(x =>
                x.Item1.Contains(Feature.Feature.ToString()) && x.Item1.Contains(eyes.ToString())).ToList();
                if (v1.Any())
                {
                    result.Add(this.ToSceneInfo(v1.First()));
                }
            }
        }
        private void GetMouth(Mouth mouth, List<Tuple<string, string>> list, List<Info_Scene> result)
        {
            var v = list.Where(x => x.Item1.Contains(mouth.ToString())).ToList();
            if (!v.Any())
            {
                var v1 = Files.Where(x =>
                x.Item1.Contains(Feature.Feature.ToString()) && x.Item1.Contains(mouth.ToString())).ToList();
                if (v1.Any())
                {
                    result.Add(this.ToSceneInfo(v1.First()));
                }
            }
        }

      

        internal void RemoveBlink(List<Info_Scene> posture, Poses pose, Eyes eyes)
        {
            Info_Scene v = FindEyes(eyes, pose);
            if (v != null)
            {
                for (int i = 0; i < posture.Count(); i++)
                {
                    if (posture[i].File == v.File)
                    {
                        posture.RemoveAt(i);
                        return;
                    }
                }
            }
        }



     
        private Info_Scene FindMouth(Mouth mouth, Poses pose)
        {
            var v = Files.Where(
                 x => x.Item1.Contains(Feature.Feature.ToString())
                 && x.Item1.Contains(pose.ToString())
                 && x.Item1.Contains(mouth.ToString())
                 ).FirstOrDefault();
            if (v != null)
            {
                return this.ToSceneInfo(v);
            }
            return null;
        }
        private Info_Scene FindEyes(Eyes eyes, Poses pose)
        {
            var v = Files.Where(
                 x => x.Item1.Contains(Feature.Feature.ToString())
                 && x.Item1.Contains(pose.ToString())
                 && x.Item1.Contains(eyes.ToString())
                 ).FirstOrDefault();
            if (v != null)
            {
                return this.ToSceneInfo(v);
            }
            return null;
        }
        public List<Info_Scene> Combine(List<Info_Scene> posture, Poses pose, Mouth mouth, bool transition)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            var newmouth = FindMouth(mouth, pose);
            if (newmouth == null)
                return posture;
            bool prevMouseFound = false;
            
            foreach (var i in posture)
            {
                var itempocy = Info_Scene.GenerateCopy(i);
                //itempocy.T = null;
                //itempocy.O = null;
                var info = Files.Where(
                    x => x.Item1.Contains(Figure.Feature.ToString())
                    &&  x.Item2 == itempocy.File).FirstOrDefault();

                if (info != null)
                {
                    bool additem = true;
                    foreach (var mv in Enum.GetValues(typeof(Mouth)))
                    {
                        if (info.Item1.Contains(mv.ToString())) // 
                        {
                            additem = false;
                            if (info.Item1.Contains(mouth.ToString()))
                            {                              
                                continue;
                            }
                            else
                            {
                                if (!transition || prevMouseFound)
                                {
                                    continue;
                                }
                                else
                                {
                                    result.Add(newmouth); // add new mouth
                                    prevMouseFound = true;
                                    itempocy.O = "100";
                                    itempocy.T = "W..0>O.B.1000.-100"; // prev mouth make it dissappearing
                                    result.Add(itempocy);
                                }
                            }
                        }
                    }
                    if (additem)
                        result.Add(itempocy);
                }
                else
                {
                    result.Add(itempocy);
                }

            }
            if (!prevMouseFound)
            {
                if (transition)
                {
                    newmouth.O = "0";
                    newmouth.T = "W..0>O.B.1000.100";// new mouth make it appearing
                }
                result.Add(newmouth);
            }

            return result;
        }
        public List<Info_Scene> Combine(List<Info_Scene> posture, Poses pose, Eyes eyes, bool transition)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            var newmouth = FindEyes(eyes, pose);
            if (newmouth == null)
                return posture;
            bool prevMouseFound = false;

            foreach (var i in posture)
            {
                var itempocy = Info_Scene.GenerateCopy(i);
                //itempocy.T = null;
                //itempocy.O = null;
                var info = Files.Where(
                    x => x.Item1.Contains(Figure.Feature.ToString())
                    && x.Item2 == itempocy.File).FirstOrDefault();

                if (info != null)
                {
                    bool additem = true;
                    foreach (var mv in Enum.GetValues(typeof(Eyes)))
                    {

                        if (info.Item1.Contains(mv.ToString())) // 
                        {
                            additem = false;
                            if (info.Item1.Contains(eyes.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                if (!transition || prevMouseFound)
                                {
                                    continue;
                                }
                                else
                                {
                                    result.Add(newmouth); // add new mouth
                                    prevMouseFound = true;
                                    itempocy.O = "100";
                                    itempocy.T = "W..0>O.B.1000.-100"; // prev mouth make it dissappearing
                                    result.Add(itempocy);
                                }
                            }
                        }
                    }
                    if (additem)
                        result.Add(itempocy);
                }
                else
                {
                    result.Add(itempocy);
                }

            }
            if (!prevMouseFound)
            {
                if (transition)
                {
                    newmouth.O = "0";
                    newmouth.T = "W..0>O.B.1000.100";// new mouth make it appearing
                }
                result.Add(newmouth);
            }

            return result;
        }




// New +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public List<Info_Scene> WoreNightgown(List<Info_Scene> posture, Poses pose)
        {
            return WoreOutfit(posture, pose.ToString(), Outfit.Nightgown.ToString());
        }
      
        public List<Info_Scene> SetFace70(List<Info_Scene> posture)
        {         
            if (posture == null) posture = new List<Info_Scene>();
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            posture = SetFeature(posture, pose.ToString(), Eyes.EyesClosed1.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = SetFeature(posture, pose.ToString(), Mouth.MouthOpen2.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            return posture;
        }
        public List<Info_Scene> SetFace67(List<Info_Scene> posture)
        {
            if (posture == null) posture = new List<Info_Scene>();
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            posture = SetFeature(posture, pose.ToString(), Eyes.EyesOpen1.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null,true,true);
            posture = SetFeature(posture, pose.ToString(), Mouth.MouthClose1.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = AddBlink(posture, Eyes.EyesBlink1);
            return posture;
        }
        public List<Info_Scene> SetFace68(List<Info_Scene> posture)
        {
            if (posture == null) posture = new List<Info_Scene>();
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            posture = SetFeature(posture, pose.ToString(), Eyes.EyesOpen1.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = SetFeature(posture, pose.ToString(), Mouth.MouthOpen1.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = AddBlink(posture, Eyes.EyesBlink1);
            return posture;
        }
        public List<Info_Scene> SetFace71(List<Info_Scene> posture)
        {
            if (posture == null) posture = new List<Info_Scene>();
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            posture = SetFeature(posture, pose.ToString(), Eyes.EyesOpen1.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = SetFeature(posture, pose.ToString(), Mouth.MouthClose2.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = AddBlink(posture, Eyes.EyesBlink1);
            return posture;
        }
        public List<Info_Scene> SetFace72(List<Info_Scene> posture)
        {
            if (posture == null) posture = new List<Info_Scene>();
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            posture = SetFeature(posture, pose.ToString(), Eyes.EyesOpen5.ToString(), Eyes.EyesGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = SetFeature(posture, pose.ToString(), Mouth.MouthOpen5.ToString(), Mouth.MouthGeneric.ToString(), Trans.Dissapearing(1000), null, true, true);
            posture = AddBlink(posture, Eyes.EyesBlink1);
            return posture;
        }
        public List<Info_Scene> AddBlink(List<Info_Scene> posture, Eyes eyes)
        {
            Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            return base.AddBlink(posture, pose.ToString(), eyes.ToString(), Eyes.EyesGeneric.ToString());
        }
    }
}
