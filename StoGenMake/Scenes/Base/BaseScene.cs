using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;
using System.IO;
using StoGenLife.NPC;
using StoGenMake.Pers;
using StoGenLife.SOUND;
using StoGenMake.Entity;
using StoGen.Classes;

namespace StoGenMake.Scenes.Base
{
   
    public class BaseScene
    {
        public List<VNPC> Actors;
        public void NextCadre(string name)
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, name, 200, this);
            this.Actors[0].SetCloth(cadre);
            this.Actors[0].SetHead(cadre);

            this.AddObzor(cadre);
        }

        public Guid GID { set; get; }
        public enum ViewingTransitionState
        {
            Disabled,
            None,           
            Go
        }
        public int SizeX = 800;
        public int SizeY = 600;
        public int X = 300;
        public int Y = 0;
        private int Version = 0;
        public BaseScene(List<VNPC> actors)
        {
            this.Actors = actors;
            foreach (var item in this.Actors)
            {
                item.Scene = this;
            }

            this.Name = "Drama scene";
            this.SizeX = 1500;
            this.SizeY = 1600;
        }
        public ViewingTransitionState StateViewingTransition = ViewingTransitionState.None;
        protected void AddObzor(ScenCadre cadre)
        {
            if (this.StateViewingTransition == ViewingTransitionState.Go)
            {
                foreach (var image in cadre.VisionList)
                {
                    if (!string.IsNullOrEmpty(image.Transition))
                    {
                        image.Transition = image.Transition + "*" + Transition.Obzor();
                    }
                    else
                        image.Transition = Transition.Obzor();
                }
            }
        }

        private string _TempFileName;
        public string TempFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_TempFileName))
                {
                    if (!string.IsNullOrEmpty(this.Name)) _TempFileName = $@"d:\temp\{this.Name}.stogen";
                    else
                        _TempFileName = $@"d:\temp\{this.GID}.stogen";
                }
                return _TempFileName;
            }
            set
            {
                _TempFileName = value;
            }
        }
        public ScenCadre AddCadre(ScenCadre cadre, string name, int timer, BaseScene owner)
        {
            if (cadre == null)
                cadre = new ScenCadre(owner);
            if (name == null)
            {
                name = $"Cadre { this.Cadres.Count + 1}";
            }
            if (timer < 1) timer = 60;
            cadre.Timer = timer * 1000;
            cadre.Name = name;
            this.Cadres.Add(cadre);
            return cadre;
        }
        public ScenElementImage AddImage(ScenCadre cadre, bool invisible, string name)
        {
            ScenElementImage image = new ScenElementImage();
            image.SizeX = SizeX;
            image.SizeY = SizeY;
            image.Name = name;
            if (invisible)
                image.Opacity = 0;
            else
                image.Opacity = 100;
            cadre.VisionList.Add(image);
            return image;
        }
        public ScenElementSound AddSound(ScenCadre cadre, string name)
        {
            ScenElementSound sound = new ScenElementSound();            
            sound.Name = name;
            sound.File = SoundStore.ValByName(name);
            cadre.SoundList.Add(sound);
            return sound;
        }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();
        

        public string FileToProcess = null;
        public virtual void InitCadres(List<EntityVariable> vars)
        {
            this.Cadres.ForEach(x => x.InitValuesFromPers(vars));
        }

      
        private void SetSceneCommonDats(List<string> scendata)
        {
            if (scendata == null) return;
            List<string> datastr = scendata.Where(x => x.StartsWith(@"SCENDATA ")).ToList();
            if (datastr != null)
            {
                scendata.RemoveAll(x => x.StartsWith(@"SCENDATA "));
                List<string> vals = datastr.First().Split(';').ToList();
                foreach (var item in vals)
                {
                    if (item.Trim().StartsWith("Location"))
                    {
                        var vals2 = item.Split('=');
                        string[] items = vals2[1].Split(',');
                        this.X = int.Parse(items[0]);
                        this.Y = int.Parse(items[1]);
                        this.SizeX = int.Parse(items[2]);
                        this.SizeY = int.Parse(items[3]);
                    }
                }
            }

           
        }
        internal string Generate()
        {
            string fnScenario = string.Empty;
            if (!string.IsNullOrEmpty(this.TempFileName))
            {
                string newfnScenario = Path.GetFileNameWithoutExtension(FileToProcess) + ".stogen";
                string savepath = Path.GetDirectoryName(FileToProcess);
                fnScenario = Path.Combine(savepath, newfnScenario);
            }

            List<string> scendata = new List<string>();
            foreach (var item in this.Cadres)
            {
                //item.InitValuesFromPers(this.Data.Variables);
                int i = 0;
                if (item.IsActivated)
                {
                    var cadredata = item.GetCadreData();
                    if (!string.IsNullOrEmpty(FileToProcess))
                    {
                        string newfnCadre = i.ToString("000") + "_" + item.Name + ".stogen";
                        string savepathCadre = Path.GetDirectoryName(FileToProcess) + @"\Cadres\";
                        if (!Directory.Exists(savepathCadre)) Directory.CreateDirectory(savepathCadre);
                        string fnCadre = Path.Combine(savepathCadre, newfnCadre);
                        File.WriteAllText(fnCadre, string.Join(Environment.NewLine, cadredata.ToArray()));
                    }
                    scendata.AddRange(cadredata);
                }
            }

            File.WriteAllText(fnScenario, string.Join(Environment.NewLine, scendata.ToArray()));
            return fnScenario;
        }
        internal bool CreateMenuScene(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem($"Scene {this.Name}", this);
            item.Executor = delegate (object data)
            {
                //this.FillDocierScene();
                //this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                //this.Generate(this.TempFileName);

                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
            return true;
        }
        internal void Prepare()
        {
            foreach (var item in this.Actors)
            {
                item.Prepare();
            }
        }
    }
    public class SceneVariable
    {
        public string Type;
        public string Name;
        public string Description;
        public string Value;
        public SceneVariable(string type, string name, string val, string desc)
        {
            Type = type;
            Name = name;
            Description = desc;
            Value = val;
        }
    }
}
