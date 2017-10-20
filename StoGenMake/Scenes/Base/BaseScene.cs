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

    public class ImageAlignVec
    {
        public string Name;
        public string File;
        public DifData DefaultAlign;
        public List<ImageRelDifVec> Parents = new List<ImageRelDifVec>();
    }

    public class ImageRelDifVec
    {
        public ImageRelDifVec() { }
        public string ParentName;
        public string AlignVariant;
        public int parY = 0;
        public int dX = 0;
        public int dY = 0;
        public int psX = 1;
        public int psY = 1;
        public float dsX = 1;
        public float dsY = 1;
        public int Rot = 0;
        public int parRot = 0;
        public int parFlip = 0;
        public int Flip = 0;

        internal void CreateDifProportions(seIm parIm, seIm childIm)
        {
            if (parIm == null) return;
            if (childIm == null) return;
            dX = childIm.X - parIm.X;
            dY = childIm.Y - parIm.Y;

            Rot = childIm.Rot;
            parRot = parIm.Rot;

            parFlip = parIm.Flip;
            Flip = childIm.Flip;
            dsX = ((float)childIm.sX / (float)parIm.sX);
            dsY = ((float)childIm.sY / (float)parIm.sY);
            psX = parIm.sX;
            psY = parIm.sY;
        }

        internal void ApplyTo(seIm target, seIm actualParent)
        {
            target.sX = Convert.ToInt32(this.dsX * actualParent.sX);
            target.sY = Convert.ToInt32(this.dsY * actualParent.sY);

            // Parent rotation
            {
                target.ParentRotations.Clear();
                if (actualParent.ParentRotations != null)
                {
                    target.ParentRotations.AddRange(actualParent.ParentRotations);
                }
                if (this.parRot != actualParent.Rot)
                {
                    target.ParentRotations.Add(new Tuple<string, int>(actualParent.Name, actualParent.Rot - parRot));
                }
            }
            // Parent flip
            {
                target.ParentFlips.Clear();
                if (actualParent.ParentFlips != null)
                {
                    target.ParentFlips.AddRange(actualParent.ParentFlips);
                }
                if (this.Flip != actualParent.Flip)
                {
                    target.ParentFlips.Add(actualParent.Name);
                }
            }

            { // X,Y coord
                int xDif = this.dX;
                int yDif = this.dY;

                target.X = (int)(this.dX * ((float)actualParent.sX / psX));
                target.Y = (int)(this.dY * ((float)actualParent.sY / psY));

                target.X = target.X + actualParent.X;
                target.Y = target.Y + actualParent.Y;
            }
            target.Rot = this.Rot;
            target.Flip = this.Flip;
        }
    }
    public class CadreImageAligns
    {
        public List<DifData> AlignList = new List<DifData>();
        public List<string> MarkList = new List<string>();
        public CadreImageAligns()
        {

        }
    }

    public class BaseScene
    {
        protected List<VNPC> Actors;
        protected virtual void MakeCadres(string cadregroup)
        {
            foreach (var item in AlignList.Where(x => string.IsNullOrEmpty(cadregroup) || x.MarkList.Contains(cadregroup)))
            {
                this.CreateCadre(item);
            }
        }

        public List<CadreImageAligns> AlignList = new List<CadreImageAligns>();
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
            LoadData(
              GameWorldFactory.GameWorld.CommonImageList,
              GameWorldFactory.GameWorld.AlignList);
        }
        protected virtual void LoadData(List<seIm> data, List<AlignDif> alignData) { }
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
       
        #region Newest engine!!!

        protected void CreateCadre(CadreImageAligns item, bool isWhite = false, seTe text = null)
        {
            var cadre = new ScenCadre();
            cadre.IsWhite = isWhite;
            if (text != null)
            {
                cadre.AddText(text);
            }
            cadre.Name = $"Cadre {this.Cadres.Count + 1}";
            this.Cadres.Add(cadre);


            foreach (var ai in item.AlignList)
            {
                //faind main image info in storage
                var isi = GameWorld.ImageStorage.Where(x => x.Name == ai.Name).FirstOrDefault();
                // create image
                seIm im = new seIm();
                im.Name = isi.Name;
                im.File = isi.File;
                // there is 2 alt: assign from parent-child align or from delta align, not combined!
                if (!string.IsNullOrEmpty(ai.Parent)) //if has parent image
                {
                    // get parent-child proportion
                    var parentproportion = isi.Parents.Where(x => x.ParentName == ai.Parent).FirstOrDefault();
                    if (parentproportion != null)
                    {
                        // get real parent image from cadre
                        var realpar = cadre.VisionList.Where(x => x.Name == ai.Parent).FirstOrDefault();
                        if (realpar != null)
                        {
                            // assign to image parent-child proportion according with real parent 
                            seIm realparent = realpar as seIm;
                            parentproportion.ApplyTo(im, realparent);
                        }
                    }
                }
                else // no parent image
                {
                    // assign default align to image
                    im.AssignFrom(isi.DefaultAlign);
                    // assign delta align, if any
                    im.AssignFrom(ai);
                }

                // add image to cadre
                cadre.AddImage(im);

            }

        }
        protected void AddToGlobalImage(string name, string fn, string path, DifData defaultalign)
        {
            ImageAlignVec newIAV = new ImageAlignVec() { Name = name, File = path + fn };
            newIAV.DefaultAlign = defaultalign;
            GameWorld.ImageStorage.Add(newIAV);
        }
        protected void AddLocal(string[] marks, DifData[] difs, bool installtoglobal = false)
        {
            CadreImageAligns CAL = new CadreImageAligns();
            CAL.MarkList.AddRange(marks);
            foreach (var mark in marks)
            {
                if (!this.CadreGroups.Contains(mark)) this.CadreGroups.Add(mark);
            }
            foreach (var dif in difs)
            {
                CAL.AlignList.Add(dif);
                if (installtoglobal && !string.IsNullOrEmpty(dif.Parent))
                {
                    AddToGlobalAlign(dif);
                }
            }
            AlignList.Add(CAL);
        }
        private void AddToGlobalAlign(DifData dd)
        {
            if (!string.IsNullOrEmpty(dd.Parent))
            {
                // get child storage items
                var storageitem = GameWorld.ImageStorage.Where(x => x.Name == dd.Name).FirstOrDefault();
                if (storageitem != null)
                {
                    // check if default align for that parent is not already assigned
                    var oldalign = storageitem.Parents.Where(x => x.ParentName == dd.Parent).FirstOrDefault();
                    if (oldalign == null)
                    {
                        // Get parent image align via default align and delta
                        seIm parIm = new seIm();
                        var pardefaultalgn = GameWorld.ImageStorage.Where(x => x.Name == dd.Parent).FirstOrDefault().DefaultAlign;
                        parIm.AssignFrom(pardefaultalgn); // only default
                        // Get child image align via default align and delta
                        seIm childIm = new seIm();
                        var childdefaultalgn = storageitem.DefaultAlign;
                        childIm.AssignFrom(childdefaultalgn); // default and delta
                        childIm.AssignFrom(dd);
                        // add align for that parent
                        ImageRelDifVec newalign = new ImageRelDifVec();
                        newalign.ParentName = dd.Parent;
                        newalign.CreateDifProportions(parIm, childIm);
                        storageitem.Parents.Add(newalign);
                    }
                }
            }

        }
    

    #endregion

        #region new
    public List<CadreAlignPack> Aligns = new List<CadreAlignPack>();
        public void GenerateCadre(
           AlignData[] imdata,
           bool isWhite = false,
           seTe text = null)
        {

            ScenCadre cadre = this.AddCadre(null, null, 200);
            cadre.IsWhite = isWhite;
            if (text != null)
            {
                cadre.AddText(text);
            }
            foreach (var item in imdata)
            {
                var sourceIm = ApplyAlignData(item, imdata.ToList(), true);
                if (sourceIm != null) cadre.AddImage(sourceIm);
            }
        }
        private seIm ApplyAlignData(AlignData processed, List<AlignData> list, bool replace)
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
                                ApplyAlignData(parentItem, list, replace);
                            }
                        }
                    }

                    //if (currAlign == null)
                    //{
                    //    if (!string.IsNullOrEmpty(processed.Parent) && parentItem == null)
                    //    {
                    //        var parnull = GameWorldFactory.GameWorld.AlignList.Where(x => x.Source == processed.Parent && string.IsNullOrEmpty(x.Parent) && x.Tag == processed.Tag).FirstOrDefault();
                    //        currAlign = new AlignDif(processed, parnull.SourceIm);
                    //    }
                    //    else
                    //    {
                    //        currAlign = new AlignDif(processed, parentItem);
                    //    }

                    //    GameWorldFactory.GameWorld.AlignList.Add(currAlign);
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

        internal CadreAlignPack AddIm(string name, VNPCPersType type,
                    string desc, string path, string file,
                    List<seIm> data,
                    AlignData[] imdata)
        {
            CadreAlignPack result = null;
            seIm im = GetIm(name, type, desc, path, file);
            data.Add(im);
            result = new CadreAlignPack(imdata);
            this.Aligns.Add(result);

            foreach (var item in imdata)
            {
                AddAlignData(im, item, imdata.ToList());
            }
            return result;
        }
        private void AddAlignData(seIm targetIm, AlignData processed, List<AlignData> list)
        {
            if (targetIm == null)
                targetIm = GameWorldFactory.GameWorld.CommonImageList.Where(x => x.Name == processed.Name).FirstOrDefault();
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
                            AddAlignData(null, parentItem, list);
                        }
                    }
                }

                if (currAlign == null)
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
            }
        }

        #endregion

        #region old
        protected void SetCadre(string name, bool white)
        {
            SetCadre(new AlignData[] { new AlignData(name) }, this, white);
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
                var sourceIm = setAlignData(item, imdata.ToList(), replace);
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
                                setAlignData(parentItem, list, replace);
                            }
                        }
                    }

                    if (currAlign == null)
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

        protected static seIm GetIm(string name, VNPCPersType type,
                                  string desc, string path, string file)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = type;
            im.Description = desc;
            return im;
        }

        #endregion
    }

}
