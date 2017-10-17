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
using static StoGenMake.GameWorld;

namespace StoGenMake.Scenes.Base
{

    public class BaseScene
    {
        protected List<VNPC> Actors;
        protected virtual void MakeCadres(string cadregroup)
        {
            //ScenCadre cadre;
            //cadre = this.AddCadre(null, null, 200);
            //foreach (var actor in Actors)
            //{
            //    actor.AssembleFigure(cadre);
            //}
            //this.AddObzor(cadre);
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
        #region Generate
        public string Generate()
        {
            return this.Generate(null);
        }
        public string Generate(string cadregroup)
        {
            this.Cadres.Clear();
            this.MakeCadres(cadregroup);

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

                    }
                    scendata.AddRange(cadredata);
                }
            }

            File.WriteAllText(fnScenario, string.Join(Environment.NewLine, scendata.ToArray()));
            return fnScenario;
        }

        #endregion

        #region Menu


        public List<string> CadreGroups = new List<string>(); 
        public bool CreateMenuScene(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;
            foreach (var it in CadreGroups)
            {
                item = new ChoiceMenuItem();
                item.Name = it;
                item.itemData = it;
                item.Executor = data =>
                {
                    //proc.MenuCreator = this.CreateMenuSceneForCadreList;
                    //proc.ShowContextMenu(doShowMenu, data);
                    
                    this.Generate(data as string);
                    StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                    proc.MenuCreator = proc.OldMenuCreator;
                    proc.GetNextCadre();

                };
                itemlist.Add(item);
            }
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        //internal bool CreateMenuSceneForCadreList(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

        //    item = new ChoiceMenuItem($"Scene {this.Name}", this);
        //    item.Executor = delegate (object data)
        //    {
        //        this.Generate(null);
        //        StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
        //        proc.MenuCreator = proc.OldMenuCreator;
        //        proc.GetNextCadre();
        //    };
        //    itemlist.Add(item);
        //    ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
        //    return true;
        //}
        #endregion

        public seTe DefaultSceneText = new seTe();
        protected void SetCadre(string name, bool white)
        {
            SetCadre(new AlignData[] { new AlignData(name) },this, white);
        }

        public static void SetCadre(AlignData[] imdata, BaseScene scene, string text)
        {
            seTe newtext = new seTe(scene.DefaultSceneText);
            newtext.Text = text;
            SetCadre(imdata, scene, false, true, newtext);
        }
        public static void SetCadre(AlignData[] imdata, BaseScene scene, seTe text)
        {
            SetCadre(imdata, scene, false, true, text);
        }
        public static void SetCadre(
            AlignData[] imdata, 
            BaseScene scene = null,
            bool isWhite = false,
            bool replace = true,
            seTe text = null)
        {
            ScenCadre cadre = null;
            if (scene != null)
            {
                cadre = scene.AddCadre(null, null, 200);
                cadre.IsWhite = isWhite;
                
                if (text != null)
                {                    
                    cadre.AddText(text);
                }
                    
            }

            foreach (var item in imdata)
            {
                var sourceIm = setAlignData(item, imdata.ToList(),replace);
                if (sourceIm != null && cadre != null)
                            cadre.AddImage(sourceIm);
            }
        }

        private static seIm setAlignData(AlignData processed, List<AlignData> list, bool replace)
        {

            var targetIm = GameWorldFactory.GameWorld.CommonImageList.Where(x => x.Name == processed.Name).FirstOrDefault();
            if (targetIm != null)
            {
                if (!processed.Processed)
                {
                    targetIm.Reset();
                    var currAlign = GameWorldFactory.GameWorld.AlignList.Where(x => x.Source == targetIm.Name && x.Parent == processed.Parent && x.Tag == processed.Tag).FirstOrDefault();
                    AlignData parentItem = null;
                    if (!string.IsNullOrEmpty(processed.Parent))
                    {
                        parentItem = list.Where(x => x.Name == processed.Parent).FirstOrDefault();
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
                        if (!string.IsNullOrEmpty(processed.Parent) && parentItem == null)
                        {
                            var parnull = GameWorldFactory.GameWorld.AlignList.Where(x => x.Source == processed.Parent && string.IsNullOrEmpty(x.Parent) && x.Tag == processed.Tag).FirstOrDefault();
                            currAlign = new AlignDif(processed, parnull.SourceIm);
                        } 
                        else
                        {
                            currAlign = new AlignDif(processed, parentItem);
                        }                                   
                        
                        GameWorldFactory.GameWorld.AlignList.Add(currAlign);
                    }
                    //else if (item.Im != null)
                    //{
                    //    currAlign = new AlignDif(item, parentItem);
                    //    //if (replace) //replace old saved
                    //    //{
                    //    //    GameWorldFactory.GameWorld.AlignList.RemoveAll(x => x.Source == sourceIm.Name && x.Parent == item.Parent && x.Tag == item.Tag);
                    //    //}
                    //}


                    if (parentItem != null)
                    {
                        currAlign.Applay(targetIm, processed, parentItem.Fact);
                    }
                    else
                        currAlign.Applay(targetIm, processed);

                    processed.Fact = targetIm;                        
                    processed.Processed = true;
                }
            }

            return targetIm;

        }

        internal static void GetIm(string name, VNPCPersType type,
                                  string desc, string path, string file, List<seIm> data,
                                  DifData defaultdifdata = null)
        {
            seIm im = GetIm(name, type, desc, path, file);
            data.Add(im);
            if (defaultdifdata != null)
            {
                SetCadre(new AlignData[] { new AlignData(name, defaultdifdata) }, null);
            }
        }
        internal static seIm GetIm(string name, VNPCPersType type,
                                  string desc, string path, string file)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = type;
            im.Description = desc;
            return im;
        }

    }

}
