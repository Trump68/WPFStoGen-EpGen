﻿using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Games
{
    public class Scene_Combo : BaseScene
    {
        public Scene_Combo() : base()
        {
            Name = "Scene_Game";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        SCENARIO Scenario = null;
        List<Info_Combo> Queue;
        List<List<Info_Combo>> data = new List<List<Info_Combo>>();
        //private Dictionary<string, Info_Combo> DefaultVisualDic = new Dictionary<string, Info_Combo>();

        public void SetScenario(SCENARIO scenario, string queue)
        {
            Scenario = scenario;
            Queue = scenario.Scenes.Where(x => x.Queue == queue).ToList();
            Queue.Sort(delegate (Info_Combo x, Info_Combo y)
            {
                if (x.Group == null) x.Group = string.Empty;
                if (y.Group == null) y.Group = string.Empty;
                return x.Group.CompareTo(y.Group);
            });
            this.Process();
        }

        private Info_Combo GetVisualByDefaultAndCurrent(Info_Combo current)
        {
            Info_Combo rez = Info_Combo.GenerateCopy(current);
            //Info_Combo def = null;
            //if (string.IsNullOrEmpty(rez.File))
            //{
            //    if (DefaultVisualDic.Any())
            //    {
            //        if (DefaultVisualDic.First().Value.Kind == rez.Kind)
            //            def = DefaultVisualDic.First().Value;
            //    }
            //}
            //else
            //{
            //    if (DefaultVisualDic.ContainsKey(rez.File))
            //        def = DefaultVisualDic[rez.File];
            //}
            //if (def != null)
            //{
                if (string.IsNullOrEmpty(rez.File))             
                    rez.File = Scenario.DefVisFile;
                if (string.IsNullOrEmpty(rez.LoopCount))
                rez.LoopCount = Scenario.DefVisLC; 
                if (string.IsNullOrEmpty(rez.LoopMode))
                    rez.LoopMode = Scenario.DefVisLM;
            if (string.IsNullOrEmpty(rez.S))
                    rez.S = Scenario.DefVisSize;
            if (string.IsNullOrEmpty(rez.Speed))
                rez.Speed = Scenario.DefVisSpeed;
            if (string.IsNullOrEmpty(rez.X))
                rez.X = Scenario.DefVisX;
            if (string.IsNullOrEmpty(rez.Y))
                rez.Y = Scenario.DefVisY;
            //if (string.IsNullOrEmpty(rez.O))
            //        rez.O = def.O;
            //    //if (string.IsNullOrEmpty(rez.PositionEnd))
            //    //    rez.PositionEnd = def.PositionEnd;
            //    //if (string.IsNullOrEmpty(rez.PositionStart))
            //    //    rez.PositionStart = def.PositionStart;
            //    //if (string.IsNullOrEmpty(rez.R))
            //    //    rez.R = def.R;
            //    if (string.IsNullOrEmpty(rez.S))
            //        rez.S = def.S;
            //    if (string.IsNullOrEmpty(rez.ShowMovieControl))
            //        rez.ShowMovieControl = def.ShowMovieControl;
            //    if (string.IsNullOrEmpty(rez.Speed))
            //        rez.Speed = def.Speed;
            //    if (string.IsNullOrEmpty(rez.VAlign))
            //        rez.VAlign = def.VAlign;
            //    if (string.IsNullOrEmpty(rez.X))
            //        rez.X = def.X;
            //    if (string.IsNullOrEmpty(rez.Y))
            //        rez.Y = def.Y;
            //    if (string.IsNullOrEmpty(rez.Z))
            //        rez.Z = def.Z;
            ////}
            //else if (!string.IsNullOrEmpty(rez.File))
            //{
            //    DefaultVisualDic.Add(rez.File, rez);
            //}
            return rez;
        }

        public bool Process()
        {
            data.Clear();
            this.currentGr = Queue.First().ID;
            var grupedlist = Queue.GroupBy(x => x.Group).ToList();

            for (int i = 0; i < grupedlist.Count; i++)
            {
                var nl = grupedlist[i].ToList();
                data.Add(nl);
            }

            // TEXT
            if (!string.IsNullOrEmpty(Scenario.DefTextSize))
                this.DefaultSceneText.Size = Convert.ToInt32(Scenario.DefTextSize);
            if (!string.IsNullOrEmpty(Scenario.DefTextWidth))
                this.DefaultSceneText.Width = Convert.ToInt32(Scenario.DefTextWidth);
            if (!string.IsNullOrEmpty(Scenario.DefFontSize))
                this.DefaultSceneText.FontSize = Convert.ToInt32(Scenario.DefFontSize);
            if (!string.IsNullOrEmpty(Scenario.DefTextShift))
                this.DefaultSceneText.Shift = Convert.ToInt32(Scenario.DefTextShift);
            if (!string.IsNullOrEmpty(Scenario.DefFontColor))
                this.DefaultSceneText.FontColor = Scenario.DefFontColor;
            if (!string.IsNullOrEmpty(Scenario.DefTextAlignH))
                this.DefaultSceneText.Align = Convert.ToInt32(Scenario.DefTextAlignH);
            if (!string.IsNullOrEmpty(Scenario.DefTextAlignV))
                this.DefaultSceneText.VAlign = Convert.ToInt32(Scenario.DefTextAlignV);

            foreach (var group in data)
            {
                DoCadreByGroup(group);
            }
            return true;
        }
        


        private void DoCadreByGroup(List<Info_Combo> group)
        {
            // sound
            this.VOLUME_M = 100;
            var sounds = group.Where(x => x.Kind == 6);
            foreach (var item in sounds)
            {
                this.AddMusic(item.File);
            }

            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();
          

            string story = string.Empty;
            string path = string.Empty;
            Info_Combo title = group.Where(x => x.Kind == 1).FirstOrDefault();
            Info_Combo copytitle = null;
            if (title != null)
            {
                copytitle = Info_Combo.GenerateCopy(title);
                // try to get text from kind 1
                story = copytitle.Story;
                if (string.IsNullOrEmpty(copytitle.File) && !string.IsNullOrEmpty(Scenario.DefTextBck))
                    copytitle.File = Scenario.DefTextBck;
                if (copytitle.File == "$$WHITE$$") // white background
                {
                    AddToGlobalImage("$$WHITE$$", "$$WHITE$$",string.Empty);
                    Pictures.Add("$$WHITE$$", new DifData("$$WHITE$$") { });
                }

            }

            // try to get text from kind 4
            if (string.IsNullOrEmpty(story))
            {                
                title = group.Where(x => x.Kind == 4).FirstOrDefault();                
                if (title != null)
                {
                    story = title.Story;
                }
            }

            // try to get text from kind 0
            if (string.IsNullOrEmpty(story))
            {
                title = group.Where(x => x.Kind == 0).FirstOrDefault();
                if (title != null)
                {
                    story = title.Story;
                }
            }
            // try to get text from kind 8
            if (string.IsNullOrEmpty(story))
            {
                title = group.Where(x => x.Kind == 8).FirstOrDefault();
                if (title != null)
                {
                    story = title.Story;
                }
            }
            // try to get text from file
            if (!string.IsNullOrEmpty(story))
            {
                // text should have filename@section
                if (story.Contains("@"))
                {
                    string[] vals = story.Split('@');
                    string filename = vals[0];
                    string section = vals[1];
                    if (File.Exists(filename))
                    {
                        List<string> textlist = new List<string>(File.ReadAllLines(filename));
                        bool gotcha = false;
                        List<string> storylines = new List<string>();
                        foreach (string line in textlist)
                        {
                           
                            // get text from section within a file
                            if (line.StartsWith($"@{section}"))
                            {
                                gotcha = true;
                                continue;
                                //story = line.Replace($"@{section}", string.Empty).Trim();                                
                            }
                            else if (line.StartsWith($"@"))
                            {
                                gotcha = false;
                            }
                            if (gotcha)
                            {
                                storylines.Add(line);
                            }
                        }
                        story = string.Join("~", storylines.ToArray());
                    }
                }
            }

            
            // PICTURES- kind 5 (transform)
            List<OpEf> trans = new List<OpEf>();
            var prevtranpictures = group.Where(x => x.Kind == 5);
            foreach (var item in prevtranpictures)
            {
                int z = 1;

                int opacity = 100;
                if (!string.IsNullOrEmpty(item.O))
                {
                    opacity = Convert.ToInt32(item.O);
                }
                if (!string.IsNullOrEmpty(item.Z))
                {
                    z = Convert.ToInt32(item.Z);
                }
                if (!string.IsNullOrEmpty(item.T))
                {
                    trans.Add(new OpEf(z, true, opacity, item.T));
                    //trans.Add(OpEf.HidePrev(1));
                }
            }


            // PICTURES and Clips- kind 0,2,4,8
            var infopictures = group.Where(x => x.Kind == 0 || x.Kind == 2 || x.Kind == 4 || x.Kind == 8);

            List<Info_Combo> infopicturesMod = new List<Info_Combo>();
            foreach (var item in infopictures)
            {
                var it = GetVisualByDefaultAndCurrent(item);
                infopicturesMod.Add(it);
                if (!string.IsNullOrEmpty(it.File))
                {                   
                   AddToGlobalImage(it.File, it.File);
                }
            }
            int i = 1;
            List<DifData> itl = new List<DifData>();
            foreach (var item in infopicturesMod)
            {
                if (string.IsNullOrEmpty(item.File)) continue;
                if (item.Kind == 8) //Clip
                {
                    int volume = 0;
                    var anim = new AP(item.File)
                    { APS = Convert.ToDouble(item.PositionStart),
                      APE = Convert.ToDouble(item.PositionEnd),
                      ALM = Convert.ToInt32(item.LoopMode),
                      ALC = Convert.ToInt32(item.LoopCount),
                      AR = Convert.ToInt32(item.Speed),
                      AV = volume};

                    //if (string.IsNullOrEmpty(item.S) || item.S == "0") item.S = "800";

                    DifData size = new DifData() { S = Convert.ToInt32(item.S) };
                    size.Name = anim.File;
                    if (!string.IsNullOrEmpty(item.X))
                        size.X = Convert.ToInt32(item.X);
                    if (!string.IsNullOrEmpty(item.Y))
                        size.Y = Convert.ToInt32(item.Y);
                    if (!string.IsNullOrEmpty(item.O))
                        size.O = Convert.ToInt32(item.O);
                    if (!string.IsNullOrEmpty(item.R))
                        size.R = Convert.ToInt32(item.R);
                    if (!string.IsNullOrEmpty(item.Z))
                        size.Z = Convert.ToInt32(item.Z);

                    size.AL.Add(anim);
                    var dd = new List<DifData>();
                    itl.AddRange(dd);
                    itl.Insert(0, size);
                    //DoC2($"{story}", itl, null);
                    //AddAnim(anim.File, item.Story, itl, anim);
                }
                else
                {
                    int opacity = 100;

                    //if (Pictures.ContainsKey(item.Description))
                    //{
                    //    item.Description = $"{item.Description}{item.File}";

                    //}
                    string key = item.File;
                    Pictures.Add(key, new DifData(item.File) { });
                    if (!string.IsNullOrEmpty(item.X))
                        Pictures[key].X = Convert.ToInt32(item.X);
                    if (!string.IsNullOrEmpty(item.Y))
                        Pictures[key].Y = Convert.ToInt32(item.Y);
                    if (!string.IsNullOrEmpty(item.O))
                    {
                        Pictures[key].O = Convert.ToInt32(item.O);
                        opacity = Pictures[key].O.Value;
                    }
                    if (!string.IsNullOrEmpty(item.S))
                    {
                        Pictures[key].S = Convert.ToInt32(item.S);
                    }
                    if (!string.IsNullOrEmpty(item.F))
                    {
                        Pictures[key].F = Convert.ToInt32(item.F);
                    }
                    if (!string.IsNullOrEmpty(item.Z))
                    {
                        Pictures[key].Z = Convert.ToInt32(item.Z);
                    }
                    if (!string.IsNullOrEmpty(item.R))
                    {
                        Pictures[key].R = Convert.ToInt32(item.R);
                    }
                    if (!string.IsNullOrEmpty(item.T))
                    {
                        Pictures[key].T = item.T;
                        trans.Add(new OpEf(i, false, opacity, item.T));
                    }
                    i++;
                }
            }
            itl.AddRange(Pictures.Values.ToList());
            
                //trans.Add(OpEf.AppCurr(1, "W..0>O.B.400.100*W..0>X.B.400.300")); //--appear+move from left
                //trans.Add(OpEf.AppCurr(1, "W..0>O.B.400.100"));                  //--appear
            CreateCadreData($"{story}", itl, trans);            
        }
    }
}
