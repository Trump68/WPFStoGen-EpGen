using Menu.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.SceneCadres;
using StoGen.Classes.Transition;
using StoGenerator;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        public SCENARIO Story = null;
        private Info_Scene CurrentBackground;
        public List<INFO_SceneCadre> CadreList;
        public void SetScenario(SCENARIO story, List<INFO_SceneCadre> list)
        {
            Story = story;
            CadreList = list;
            Story.CatalogPath = this.CatalogPath;
            this.Process(null);
        }

        private string GetAbsolutePath(string path)
        {
            if (!string.IsNullOrEmpty(path) && !Path.IsPathRooted(path))
            {                
                if (!string.IsNullOrEmpty(Story.GamePath))
                {
                    return Path.Combine(Story.GamePath,path);
                }
                else if (!string.IsNullOrEmpty(Story.DefVisFile))
                {
                    return Path.Combine(Story.DefVisFile, path);
                }
                else 
                {
                    return Path.Combine(Story.CatalogPath, path);
                }
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
        public List<CadreData> Process(int? indexToInsert)
        {            
            if (Cadres == null) return null;
            List<Info_Scene> Queue = new List<Info_Scene>();

                foreach (var cadre in CadreList)
                {
                    foreach (var info in cadre.Infos)
                    {
                        //Process Parameter File
                        string s = ProcessParameterFile(info.GenerateString());
                        Queue.Add(Info_Scene.GenerateFromString(s));
                    }
                }


                      

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

            ProcessTemplates(data);

            foreach (var group in data)
            {
                var cadre = DoCadreByGroup(group, indexToInsert);
                result.Add(cadre);
                if (indexToInsert.HasValue)
                {
                    indexToInsert++;
                }
            }
            if (!string.IsNullOrEmpty(Story.DefClipPause1))
            {
                int DefClipPause1 = int.Parse(Story.DefClipPause1);
                this.CadreDataList.ForEach(x => x.DefClipPause1 = DefClipPause1);
            }
            return result;
        }

        //Dictionary<string, string> ParameterDict = new Dictionary<string, string>();
        private string ProcessParameterFile(string origin)
        {
            //ParameterDict.Clear();
            string filepath = Path.Combine(this.CatalogPath, "parameters.txt");
            if (File.Exists(filepath))
            {
                var lines = File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    if (!line.StartsWith("//") && !string.IsNullOrEmpty(line))
                    {
                        var vals = line.Split('=');
                        origin = origin.Replace(vals[0], vals[1]);
                    }
                }
            }
            return origin;
        }

        private void ProcessTemplates(List<List<Info_Scene>> data)
        {
            List<Info_Scene> templates = new List<Info_Scene>();
            foreach (var item in data)
            {                
                    templates.AddRange(item.Where(x => !string.IsNullOrEmpty(x.Template) && x.Template.Contains("~")));
            }
            foreach (var item in data)
            {
                var it = item.Where(x =>!string.IsNullOrEmpty(x.Template) && !x.Template.Contains("~"));
                foreach (var infoitem in it)
                {
                    var template = templates.FirstOrDefault(x => x.Kind == infoitem.Kind && x.Template == $"~{infoitem.Template}");
                    if (template != null)
                    {                        
                        CopyParams(infoitem, template);
                    }
                }
            }
        }

        private void CopyParams(Info_Scene info, Info_Scene infotemplate)
        {
            if (string.IsNullOrEmpty(info.Description))
                info.Description = infotemplate.Description;
            if (string.IsNullOrEmpty(info.File))
                info.File = infotemplate.File;
            if (string.IsNullOrEmpty(info.X))
                info.X = infotemplate.X;
            if (string.IsNullOrEmpty(info.Y))
                info.Y = infotemplate.Y;
            if (string.IsNullOrEmpty(info.Z))
                info.Z = infotemplate.Z;
            if (string.IsNullOrEmpty(info.S))
                info.S = infotemplate.S;
            if (string.IsNullOrEmpty(info.O))
                info.O = infotemplate.O;
            if (string.IsNullOrEmpty(info.R))
                info.R = infotemplate.R;
            if (string.IsNullOrEmpty(info.T))
                info.T = infotemplate.T;
            if (string.IsNullOrEmpty(info.LoopMode))
                info.LoopMode = infotemplate.LoopMode;
            if (string.IsNullOrEmpty(info.LoopCount))
                info.LoopCount = infotemplate.LoopCount;
            if (string.IsNullOrEmpty(info.Speed))
                info.Speed = infotemplate.Speed;
        }

        private CadreData DoCadreByGroup(List<Info_Scene> group, int? indexToInsert)
        {
            int i = 1; // picture index to correct add transitions

            seCtrl controldata = null;

                  //Control
            Info_Scene control = group.Where(x => x.Kind == 10).FirstOrDefault();
            bool muteAll = false;
            if (control != null)
            {
                controldata = new seCtrl();
                if (!string.IsNullOrEmpty(control.X))
                    controldata.TimeToShift = int.Parse(control.X);
                if (!string.IsNullOrEmpty(control.S))
                    controldata.TimeToShiftMax = int.Parse(control.S);
                if (!string.IsNullOrEmpty(control.Y))
                    controldata.ShiftStep = int.Parse(control.Y);
                if (!string.IsNullOrEmpty(control.F))
                    muteAll = (control.F == "1");

            }

            // sound
            //this.RemoveMusic();
            this.VOLUME_M = 100;
            var sounds = group.Where(x => x.Kind == 6);

            foreach (var item in sounds)
            {
                Info_Scene rez = Info_Scene.GenerateCopy(item);
                if (!string.IsNullOrEmpty(rez.File) && rez.File.StartsWith(@".\") && !string.IsNullOrEmpty(Story.GamePath))
                {
                    rez.File = rez.File.Replace(@".\", $@"{Story.GamePath}\");
                }
                if (!string.IsNullOrEmpty(rez.File) && rez.File.StartsWith(@"zip:"))
                {
                    var val = rez.File.Split(':');
                    string zipfile = val[1];
                    string zipentry = val[2];
                    string zipfullpath = Path.GetDirectoryName(zipfile);

                    if (string.IsNullOrEmpty(zipfullpath))
                    {
                        string zippath = null;
                        if (!string.IsNullOrEmpty(Story.GamePath))
                        {
                            zippath = Story.GamePath;
                        }
                        else if (!string.IsNullOrEmpty(Story.CatalogPath))
                        {
                            zippath = Story.CatalogPath;
                        }
                        zipfullpath = Path.Combine(zippath, zipfile);
                        if (!File.Exists(zipfullpath))
                        {
                            var di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                            if (di != null)
                            {
                                zippath = di.FullName;
                                zipfullpath = Path.Combine(zippath, zipfile);
                                if (!File.Exists(zipfullpath))
                                {
                                    di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                                    if (di != null)
                                    {
                                        zippath = di.FullName;
                                        zipfullpath = Path.Combine(zippath, zipfile);
                                        if (!File.Exists(zipfullpath))
                                        {
                                            di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                                            if (di != null)
                                            {
                                                zippath = di.FullName;
                                                zipfullpath = Path.Combine(zippath, zipfile);
                                                if (!File.Exists(zipfullpath))
                                                {
                                                    di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                                                    if (di != null)
                                                    {
                                                        zippath = di.FullName;
                                                        zipfullpath = Path.Combine(zippath, zipfile);
                                                        if (!File.Exists(zipfullpath))
                                                        {
                                                            di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                                                            if (di != null)
                                                            {
                                                                zippath = di.FullName;
                                                                zipfullpath = Path.Combine(zippath, zipfile);
                                                                if (!File.Exists(zipfullpath))
                                                                {
                                                                    di = Directory.GetParent(Path.GetDirectoryName(zipfullpath));
                                                                    if (di != null)
                                                                    {
                                                                        zippath = di.FullName;
                                                                        zipfullpath = Path.Combine(zippath, zipfile);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    string pathtoextract = Path.Combine(Path.GetDirectoryName(zipfullpath), Path.GetFileNameWithoutExtension(zipfile));
                    if (!Directory.Exists(pathtoextract))
                        Directory.CreateDirectory(pathtoextract);
                    var za = ZipFile.OpenRead(zipfullpath);
                    var ze = za.GetEntry(zipentry);
                    pathtoextract = Path.Combine(pathtoextract, ze.FullName);
                    if (!File.Exists(pathtoextract))
                        ze.ExtractToFile(pathtoextract,false);                    
                    rez.File = pathtoextract;
                }
                int volume = 100;
                if (!string.IsNullOrEmpty(rez.X))
                {
                    volume = int.Parse(rez.X);
                }
                bool muted = (rez.Y == "1") || muteAll;
                bool randomstart = (rez.F == "1");
                bool loop = (rez.LoopMode == "1") || (string.IsNullOrEmpty(rez.LoopMode));
                int immediatelyStart = (rez.R == "1") ? 0 : 1; 
/*                if (rez.Story == "EFFECT1")
                {
                    this.AddEffect1(rez.File, volume, loop, rez.T);
                }
                else if (rez.Story == "EFFECT1")
                {
                    this.AddEffect2(rez.File, volume, loop, rez.T);
                }                        
                else */
                    this.AddMusic(rez.File, volume, muted, randomstart, loop, rez.T, immediatelyStart);
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
                    //AddToGlobalImage("$$WHITE$$", "$$WHITE$$", string.Empty);
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
                    List<string> storylines = new List<string>();
                    List<string> textlist = null;
                    string section = null;
                    if (string.IsNullOrEmpty(vals[0]))
                    {
                        section = vals[1];
                        textlist = this.Story.Story.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                    }
                    else
                    {
                        string filename = vals[0];
                        section = vals[1];
                        story = string.Empty;
                        if (File.Exists(filename))
                        {
                            textlist = new List<string>(File.ReadAllLines(filename));
                        }
                    }
                    if (!string.IsNullOrEmpty(section) && (textlist!=null))
                    {
                        bool gotcha = false;
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
/*                    if (!string.IsNullOrEmpty(it.File))
                        AddToGlobalImage(it.File, it.File);*/
                }               
                      
            }
            if (CurrentBackground != null)// add Current Background
            {
                var it = Info_Scene.GenerateCopy(CurrentBackground);
                CurrentBackground.T = null; // after 1st adding, remove transition
                CurrentBackground.O = "100"; // after 1st adding, set visible
                it.File = GetAbsolutePath(it.File);
                it.Group = group.First().Group;
                //it.Z = "0";
                //it.X = "0";
                //it.Y = "0";
                it.S = "-2";
/*                visualsCopy.Add(it);
                if (!string.IsNullOrEmpty(it.File))
                    AddToGlobalImage(it.File, it.File);*/
            }


            List<DifData> itl = new List<DifData>();
            foreach (var item in visualsCopy)
            {
                try
                {
                    if (string.IsNullOrEmpty(item.File)) continue;
                    if (item.Kind == 8) //Clip
                    {
                        int volume = 0;
                        double PosStart = 0;
                        if (!string.IsNullOrEmpty(item.PositionStart))
                            PosStart = Convert.ToDouble(item.PositionStart);
                        double PosEnd = 0;
                        if (!string.IsNullOrEmpty(item.PositionEnd))
                            PosEnd = Convert.ToDouble(item.PositionEnd);

                        var anim = new AP(item.File)
                        {
                            APS = PosStart,
                            APE = PosEnd,
                            ALM = Convert.ToInt32(item.LoopMode),
                            ALC = Convert.ToInt32(item.LoopCount),
                            AR = Convert.ToInt32(item.Speed),
                            AV = volume
                        };


                        DifData dif = new DifData() { S = Convert.ToInt32(item.S) };
                        dif.Name = anim.File;
                        if (!string.IsNullOrEmpty(item.X))
                            dif.X = Convert.ToInt32(item.X);
                        if (!string.IsNullOrEmpty(item.Y))
                            dif.Y = Convert.ToInt32(item.Y);
                        if (!string.IsNullOrEmpty(item.O))
                            dif.O = Convert.ToInt32(item.O);
                        else
                            dif.O = 100;

                        if (!string.IsNullOrEmpty(item.R))
                            dif.R = Convert.ToInt32(item.R);
                        if (!string.IsNullOrEmpty(item.Z))
                            dif.Z = Convert.ToInt32(item.Z);
                        if (!string.IsNullOrEmpty(item.T))
                            dif.T = item.T;


                        dif.AL.Add(anim);
                        var dd = new List<DifData>();
                        itl.AddRange(dd);
                        itl.Insert(0, dif);

                    }
                    else
                    {
                        int opacity = 100;

                        string key = $"{item.File}-{item.Z}";
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
                            if (item.T.ToUpper() == "BLINK")
                            {
                                Pictures[key].T = Trans.Eyes_Blink;
                            }
                            else
                                Pictures[key].T = item.T;
                        }
                        i++;
                    }

                }
                catch (Exception ex)
                {

                    
                }
            }
            itl.AddRange(Pictures.Values.ToList());

            var result = CreateCadreData($"{story}", itl, group, indexToInsert);

            //Control
            if (controldata != null)
            {
                result.ControlData = controldata;
            }


           

            return result;
        }

/*        public override MenuCreatorDelegate GetMenuCreator(bool live)
        {
            return this.Story.GetMenuCreator(live);
        }*/

    }
}
