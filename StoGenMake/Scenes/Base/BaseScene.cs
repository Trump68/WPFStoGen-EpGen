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
        protected List<VNPC> Actors;
        protected virtual void MakeCadres()
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, null, 200);
            foreach (var actor in Actors)
            {
                actor.AssembleFigure(cadre);
            }
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
        public BaseScene()
        {
            this.Actors = new List<VNPC>();
            this.Name = "Drama scene";
            this.SizeX = 1500;
            this.SizeY = 1600;
        }
        public void AddActor(VNPC actor)
        {
            this.Actors.Add(actor);
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
        public ScenCadre AddCadre(ScenCadre cadre, string name, int timer)
        {
            if (cadre == null)
                cadre = new ScenCadre();
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

        public string Description { get; set; }
        public string Name { get; set; }
        public List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();


        public string FileToProcess = null;
        public string Generate(string FileToProcess)
        {
            this.MakeCadres();

            string fnScenario = string.Empty;
            if (string.IsNullOrEmpty(FileToProcess))
            {
                FileToProcess = this.TempFileName;
            }
            string newfnScenario = Path.GetFileNameWithoutExtension(FileToProcess) + ".stogen";
            string savepath = Path.GetDirectoryName(FileToProcess);
            fnScenario = Path.Combine(savepath, newfnScenario);

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
                        //   string newfnCadre = i.ToString("000") + "_" + item.Name + ".stogen";
                        //   string savepathCadre = Path.GetDirectoryName(FileToProcess) + @"\Cadres\";
                        //    if (!Directory.Exists(savepathCadre)) Directory.CreateDirectory(savepathCadre);
                        //   string fnCadre = Path.Combine(savepathCadre, newfnCadre);
                        //  File.WriteAllText(fnCadre, string.Join(Environment.NewLine, cadredata.ToArray()));
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
                this.Generate(null);
                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
            return true;
        }

        //protected void SetCadre(Tuple<string, string, DifData>[] imdata, bool isWhite = false)
        //{
        //    List<AlignData> list = new List<AlignData>();
        //    foreach (var item in imdata)
        //    {
        //        AlignData ni = new AlignData(item.Item1, item.Item2, item.Item3);
        //        list.Add(ni);
        //    }
        //    SetCadre(list.ToArray(), this, isWhite);
        //}

        protected void SetCadre(string name, bool white)
        {
            SetCadre(new AlignData[] { new AlignData(name) },this, white);
        }

        public static void SetCadre(AlignData[] imdata, BaseScene scene = null, bool isWhite = false, bool replace = true, string text = null)
        {
            ScenCadre cadre = null;
            if (scene != null)
            {
                cadre = scene.AddCadre(null, null, 200);
                cadre.IsWhite = isWhite;
                if (!string.IsNullOrEmpty(text))
                    cadre.AddText(text);
            }

            foreach (var item in imdata)
            {
                var sourceIm = setAlignData(item, imdata.ToList(),replace);
                if (sourceIm != null && cadre != null)
                            cadre.AddImage(sourceIm);
            }
        }

        private static seIm setAlignData(AlignData item, List<AlignData> list, bool replace)
        {

            var sourceIm = GameWorldFactory.GameWorld.CommonImageList.Where(x => x.Name == item.Name).FirstOrDefault();
            if (sourceIm != null)
            {
                if (!item.Processed)
                {
                    sourceIm.Reset();
                    var currAlign = GameWorldFactory.GameWorld.AlignList.Where(x => x.Source == sourceIm.Name && x.Parent == item.Parent && x.Tag == item.Tag).FirstOrDefault();
                    AlignData parentItem = null;
                    if (!string.IsNullOrEmpty(item.Parent))
                    {
                        parentItem = list.Where(x => x.Name == item.Parent).FirstOrDefault();
                        if (parentItem != null)
                        {
                            if (!parentItem.Processed)
                            {
                                setAlignData(parentItem, list,replace);
                            }
                        }
                    }

                    if (currAlign == null )
                    {                                                
                        currAlign = new AlignDif(item, parentItem);
                    }
                    else if (item.Im != null)
                    {
                        currAlign = new AlignDif(item, parentItem);
                        if (replace) //replace old saved
                        {
                            GameWorldFactory.GameWorld.AlignList.RemoveAll(x => x.Source == sourceIm.Name && x.Parent == item.Parent && x.Tag == item.Tag);
                        }
                    }

                    GameWorldFactory.GameWorld.AlignList.Add(currAlign);
                    if (parentItem != null)
                        currAlign.Applay(sourceIm, parentItem.Im);
                    else
                        currAlign.Applay(sourceIm);

                    if (item.Im == null)
                    {
                        item.Im = new DifData(sourceIm);
                        //item.Im.AssinFrom(sourceIm);
                    }

                    item.Processed = true;
                }
            }

            return sourceIm;

        }

        
    }

}
