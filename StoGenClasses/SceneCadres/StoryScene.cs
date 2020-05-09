using Menu.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
using StoGenerator;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes.Data.Games
{
    public class StoryScene : BaseScene
    {
        public StoryScene() : base()
        {
            Name = "Scene_Game";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        StoryBase Story = null;
        //List<Info_Scene> Queue;
      
        private Info_Scene CurrentBackground;

        //private Dictionary<string, Info_Combo> DefaultVisualDic = new Dictionary<string, Info_Combo>();

        public void SetScenario(StoryBase story, string queue)
        {
            Story = story;
            var Queue = story.SceneInfos.Where(x => x.Queue == queue && x.Active).ToList();
            Queue.Sort(delegate (Info_Scene x, Info_Scene y)
            {
                if (x.Group == null) x.Group = string.Empty;
                if (y.Group == null) y.Group = string.Empty;
                return x.Group.CompareTo(y.Group);
            });
            this.Process(Queue, null);
        }

        private string GetAbsolutePath(string path)
        {
            if (!string.IsNullOrEmpty(path) && path.StartsWith(@".\") && !string.IsNullOrEmpty(Story.GamePath))
            {
                return path.Replace(@".\", $@"{Story.GamePath}\");
            }
            return path;
        }
        private Info_Scene GetVisualByDefaultAndCurrent(Info_Scene current)
        {
            Info_Scene rez = Info_Scene.GenerateCopy(current);

            if (string.IsNullOrEmpty(rez.File))
                rez.File = Story.DefVisFile;
            rez.File = GetAbsolutePath(rez.File);


            if (string.IsNullOrEmpty(rez.LoopCount))
                rez.LoopCount = Story.DefVisLC;
            if (string.IsNullOrEmpty(rez.LoopMode))
                rez.LoopMode = Story.DefVisLM;
            if (string.IsNullOrEmpty(rez.S))
                rez.S = Story.DefVisSize;
            if (string.IsNullOrEmpty(rez.Speed))
                rez.Speed = Story.DefVisSpeed;
            if (string.IsNullOrEmpty(rez.X))
                rez.X = Story.DefVisX;
            if (string.IsNullOrEmpty(rez.Y))
                rez.Y = Story.DefVisY;

            return rez;
        }
        public List<CadreData> Process(List<Info_Scene> Queue, int? indexToInsert)
        {
            if (Queue == null) return null;
            List<CadreData> result = new List<CadreData>();
            List<List<Info_Scene>> data = new List<List<Info_Scene>>();
            //this.currentGr = Queue.First().ID;
            var grupedlist = Queue.GroupBy(x => x.Group).ToList();

            for (int i = 0; i < grupedlist.Count; i++)
            {
                var nl = grupedlist[i].ToList();
                data.Add(nl);
            }

            // TEXT
            if (!string.IsNullOrEmpty(Story.DefTextSize))
                this.DefaultSceneText.Size = Convert.ToInt32(Story.DefTextSize);
            if (!string.IsNullOrEmpty(Story.DefTextWidth))
                this.DefaultSceneText.Width = Convert.ToInt32(Story.DefTextWidth);
            if (!string.IsNullOrEmpty(Story.DefFontSize))
                this.DefaultSceneText.FontSize = Convert.ToInt32(Story.DefFontSize);
            if (!string.IsNullOrEmpty(Story.DefTextShift))
                this.DefaultSceneText.Shift = Convert.ToInt32(Story.DefTextShift);
            if (!string.IsNullOrEmpty(Story.DefFontColor))
                this.DefaultSceneText.FontColor = Story.DefFontColor;
            if (!string.IsNullOrEmpty(Story.DefFontColor))
                this.DefaultSceneText.FontStyle = Convert.ToInt32(Story.DefFontStyle);
            if (!string.IsNullOrEmpty(Story.DefTextAlignH))
                this.DefaultSceneText.Align = Convert.ToInt32(Story.DefTextAlignH);
            if (!string.IsNullOrEmpty(Story.DefTextAlignV))
                this.DefaultSceneText.VAlign = Convert.ToInt32(Story.DefTextAlignV);
            if (!string.IsNullOrEmpty(Story.DefFontName))
                this.DefaultSceneText.FontName = Story.DefFontName;

            foreach (var group in data)
            {

                result.Add(DoCadreByGroup(group, indexToInsert));
                if (indexToInsert.HasValue)
                {
                    indexToInsert++;
                }
            }
            return result;
        }
        private CadreData DoCadreByGroup(List<Info_Scene> group, int? indexToInsert)
        {
            int i = 1; // picture index to correct add transitions
            // sound
            this.VOLUME_M = 100;
            var sounds = group.Where(x => x.Kind == 6);
            foreach (var item in sounds)
            {
                Info_Scene rez = Info_Scene.GenerateCopy(item);
                if (!string.IsNullOrEmpty(rez.File) && rez.File.StartsWith(@".\") && !string.IsNullOrEmpty(Story.GamePath))
                {
                    rez.File = rez.File.Replace(@".\", $@"{Story.GamePath}\");
                }
                this.AddMusic(rez.File);
            }

            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();


            string story = string.Empty;
            string path = string.Empty;
            Info_Scene title = group.Where(x => x.Kind == 1).FirstOrDefault();
            Info_Scene copytitle = null;
            if (title != null)
            {
                copytitle = Info_Scene.GenerateCopy(title);
                // try to get text from kind 1
                if (copytitle.Story == "$$DESCRIPTION$$")
                {
                    story = copytitle.Description;
                }
                else
                story = copytitle.Story;
                if (string.IsNullOrEmpty(copytitle.File) && !string.IsNullOrEmpty(Story.DefTextBck))
                    copytitle.File = Story.DefTextBck;
                if (copytitle.File == "$$WHITE$$") // white background
                {
                    AddToGlobalImage("$$WHITE$$", "$$WHITE$$", string.Empty);
                    Pictures.Add("$$WHITE$$", new DifData("$$WHITE$$") { });
                    ++i;
                }
                if (!string.IsNullOrEmpty(copytitle.T))
                    this.DefaultSceneText.T = copytitle.T;
                if (!string.IsNullOrEmpty(copytitle.O))
                    this.DefaultSceneText.Opacity = int.Parse(copytitle.O);
                if (!string.IsNullOrEmpty(copytitle.Z))
                    this.DefaultSceneText.FontColor = copytitle.Z;
                if (!string.IsNullOrEmpty(copytitle.R))
                    this.DefaultSceneText.FontStyle = int.Parse(copytitle.R);
                if (!string.IsNullOrEmpty(copytitle.F))
                    this.DefaultSceneText.FontSize = int.Parse(copytitle.F);
                if (!string.IsNullOrEmpty(copytitle.S))
                    this.DefaultSceneText.Shift = int.Parse(copytitle.S);
                if (!string.IsNullOrEmpty(copytitle.X))
                    this.DefaultSceneText.Width = int.Parse(copytitle.X);
                if (!string.IsNullOrEmpty(copytitle.Y))
                    this.DefaultSceneText.Size = int.Parse(copytitle.Y);
                if (!string.IsNullOrEmpty(copytitle.Speed))
                    this.DefaultSceneText.FontName = copytitle.Speed;

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
                    story = string.Empty;
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
            var visuals = group.Where(x => x.Kind == 0 || x.Kind == 2 || x.Kind == 4 || x.Kind == 8 || x.Kind == 9);

            List<Info_Scene> visualsCopy = new List<Info_Scene>();
            foreach (var item in visuals)
            {
                if (item.Kind == 9) // set current background
                {
                    CurrentBackground = item;
                }
                else
                {
                    var it = GetVisualByDefaultAndCurrent(item);
                    visualsCopy.Add(it);
                    if (!string.IsNullOrEmpty(it.File))
                        AddToGlobalImage(it.File, it.File);
                }               
                      
            }
            if (CurrentBackground != null)// add Current Background
            {
                var it = Info_Scene.GenerateCopy(CurrentBackground);
                CurrentBackground.T = null; // after 1st adding, remove transition
                CurrentBackground.O = "100"; // after 1st adding, set visible
                it.File = GetAbsolutePath(it.File);
                it.Group = group.First().Group;
                it.Queue = group.First().Queue;
                it.Z = "0";
                it.X = "0";
                it.X = "0";
                it.S = "-2";
                visualsCopy.Add(it);
                if (!string.IsNullOrEmpty(it.File))
                    AddToGlobalImage(it.File, it.File);
            }


            List<DifData> itl = new List<DifData>();
            foreach (var item in visualsCopy)
            {
                if (string.IsNullOrEmpty(item.File)) continue;
                if (item.Kind == 8) //Clip
                {
                    int volume = 0;
                    var anim = new AP(item.File)
                    {
                        APS = Convert.ToDouble(item.PositionStart),
                        APE = Convert.ToDouble(item.PositionEnd),
                        ALM = Convert.ToInt32(item.LoopMode),
                        ALC = Convert.ToInt32(item.LoopCount),
                        AR = Convert.ToInt32(item.Speed),
                        AV = volume
                    };

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
                    //else
                    //    size.Z = 2;

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
                    else
                    {
                        Pictures[key].Z = 2;
                    }
                    if (!string.IsNullOrEmpty(item.R))
                    {
                        Pictures[key].R = Convert.ToInt32(item.R);
                    }
                    if (!string.IsNullOrEmpty(item.T))
                    {
                        // if apper, dont forget to set Opacity to 0, as initially figure is invisible
                        //"W..0>O.B.400.100" //--appear
                        //"W..0>O.B.400.100*W..0>X.B.400.300"--appear+move from left
                        Pictures[key].T = item.T;                                                                  
                    }
                    i++;
                }
            }
            itl.AddRange(Pictures.Values.ToList());


            return CreateCadreData($"{story}", itl, group, indexToInsert);
        }

        internal override List<CadreData> GetNextCadreData(CadreController proc, int cadreId)
        {
            List<Info_Scene> list = this.Story.GoForwardStory(proc, cadreId);
            return Process(list, cadreId);
        }


        public override MenuCreatorDelegate GetMenuCreator(bool live)
        {
            return this.Story.GetMenuCreator(live);
        }

    }
}
