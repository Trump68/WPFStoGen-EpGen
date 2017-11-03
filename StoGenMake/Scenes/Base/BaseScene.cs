using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;
using System.IO;
using StoGenLife.NPC;
using StoGenMake.Pers;
using StoGen.Classes;
using static StoGenMake.GameWorld;
using System.Windows.Media;

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
        public string Parent;
        public string Tag;
        public int Xd = 0;
        public int Yd = 0;
        public int pSx = 1;
        public int pSy = 1;
        public float dSx = 1;
        public float dSy = 1;
        public int R = 0;
        public int pR = 0;
        public int pF = 0;
        public int F = 0;
        public int pO = -1;
        public int dO = 0;
        public string pT;

        internal void CreateDifProportions(seIm parIm, seIm childIm)
        {
            if (parIm == null) return;
            if (childIm == null) return;
            Xd = childIm.X - parIm.X;
            Yd = childIm.Y - parIm.Y;

            R = childIm.R;
            pR = parIm.R;

            pF = parIm.F;
            F = childIm.F;
            dSx = ((float)childIm.Sx / (float)parIm.Sx);
            dSy = ((float)childIm.Sy / (float)parIm.Sy);
            pSx = parIm.Sx;
            pSy = parIm.Sy;
            pT = parIm.T;
            pO = parIm.O;
            dO = childIm.O - parIm.O;
        }

        //! new!!!!
        internal void ApplyTo(seIm target, seIm actualParent, DifData delta)
        {
            target.Sx = Convert.ToInt32(this.dSx * actualParent.Sx);
            target.Sy = Convert.ToInt32(this.dSy * actualParent.Sy);
            //int dR = 0;
            // Parent rotation
            {
                target.ParentRotations.Clear();
                if (actualParent.ParentRotations != null && actualParent.ParentRotations.Any())
                {
                    target.ParentRotations.AddRange(actualParent.ParentRotations);
                }
                if (this.pR != actualParent.R)
                {
                    var dR = actualParent.R - pR;
                    target.ParentRotations.Add(new Tuple<string, int>(actualParent.Name, dR));
                }
            }
            // Parent flip
            {
                target.ParentFlips.Clear();
                if (actualParent.ParentFlips != null)
                {
                    target.ParentFlips.AddRange(actualParent.ParentFlips);
                }
                if (this.pF != actualParent.F)
                {
                    target.ParentFlips.Add(actualParent.Name);
                }
            }

            { // X,Y coord
               
                target.X = this.Xd;
                target.Y = this.Yd;

                if (delta.Xd.HasValue) target.X = target.X + delta.Xd.Value;
                if (delta.Yd.HasValue) target.Y = target.Y + delta.Yd.Value;

                target.X = (int)(this.Xd * ((float)actualParent.Sx / pSx));
                target.Y = (int)(this.Yd * ((float)actualParent.Sy / pSy));               

                target.X = target.X + actualParent.X;
                target.Y = target.Y + actualParent.Y;
            }
            target.R = this.R;
            if (delta.Rd.HasValue) target.R = target.R + delta.Rd.Value;
            target.F = this.F;

            // transition
            target.T = this.pT; //default
            target.T = actualParent.T; // parent
            if (delta.T != null) //delta
                target.T = delta.T;
            
            // opacity
            target.O = this.pO;
              if (delta.Od.HasValue) target.O = target.O + delta.Od.Value;
        }
    }
    public class CadreData
    {
        public bool IsGlobalAlign = false;
        public List<DifData> AlignList = new List<DifData>();
        public List<string> MarkList = new List<string>();
        public seTe TextData;
        public CadreData()
        {

        }
    }

    public class BaseScene
    {
        public int EngineHiVer = 0;
        public int EngineLoVer = 0;
        
        protected virtual void MakeCadres(string cadregroup)
        {
            foreach (var item in AlignList.Where(x => string.IsNullOrEmpty(cadregroup) || x.MarkList.Contains(cadregroup)))
            {
                seTe te = null;
                bool isWhite = false;                
                if (item.IsGlobalAlign)
                {
                    te = new seTe();
                    te.FontSize = 60;
                    te.Size = 100;
                    te.Bottom = 0;
                    te.Shift = 700;
                    te.Text = "SETUP";
                }
                else
                {
                    te = item.TextData; 
                }
                this.CreateCadre(item, isWhite, te);
            }
        }

        public List<CadreData> AlignList = new List<CadreData>();
        public Guid GID { set; get; }
        public BaseScene()
        {
            this.Name = "Drama scene";
            LoadData();
        }
        protected virtual void LoadData() { }
        //public void AddActor(VNPC actor)
        //{
        //    this.Actors.Add(actor);
        //}
        //public ViewingTransitionState StateViewingTransition = ViewingTransitionState.None;
        //protected void AddObzor(ScenCadre cadre)
        //{
        //    if (this.StateViewingTransition == ViewingTransitionState.Go)
        //    {
        //        foreach (var image in cadre.VisionList)
        //        {
        //            if (!string.IsNullOrEmpty(image.Transition))
        //            {
        //                image.Transition = image.Transition + "*" + Transition.Obzor();
        //            }
        //            else
        //                image.Transition = Transition.Obzor();
        //        }
        //    }
        //}

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

        public seTe DefaultSceneText = new seTe()
           { Shift = 1000,
            FontSize = 26,
            Size = 760,
            Bottom = 0,
            Width =366,
            FontColor = "Aqua"};
                    //te.FontSize = 60;
                    //te.Size = 100;
                    //te.Bottom = 0;
                    //te.Shift = 700;
       
        #region Newest engine!!!

        protected void CreateCadre(CadreData item, bool isWhite = false, seTe text = null)
        {
            var cadre = new ScenCadre();
            cadre.IsWhite = isWhite;
            cadre.Name = $"Cadre {this.Cadres.Count + 1}";
            this.Cadres.Add(cadre);


            foreach (var ai in item.AlignList)
            {
                //faind main image info in storage
                var isi = GameWorld.ImageStorage.Where(x => x.Name == ai.Name).FirstOrDefault();
                if (isi == null) continue;
                // create image
                seIm im = new seIm();
                im.Name = isi.Name;
                im.File = isi.File;
                // there is 2 alt: assign from parent-child align or from delta align, not combined!
                if (!string.IsNullOrEmpty(ai.Parent)) //if has parent image
                {
                    // get parent-child proportion
                    var parentproportion = isi.Parents.Where(x => x.Parent == ai.Parent && x.Tag == ai.Tag).FirstOrDefault();
                    if (parentproportion != null)
                    {
                        // get real parent image from cadre
                        var realpar = cadre.VisionList.Where(x => x.Name == ai.Parent).FirstOrDefault();
                        if (realpar != null)
                        {
                            // assign to image parent-child proportion according with real parent 
                            seIm realparent = realpar as seIm;
                            parentproportion.ApplyTo(im, realparent, ai);
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
            if (text != null)
            {
                cadre.AddText(text);
            }

        }
        protected void AddToGlobalImage(string name, string fn, string path, DifData defaultalign)
        {
            ImageAlignVec newIAV = new ImageAlignVec() { Name = name, File = path + fn };
            newIAV.DefaultAlign = defaultalign;
            newIAV.DefaultAlign.Name = name;
            GameWorld.ImageStorage.Add(newIAV);
        }
        protected void AddLocal(string[] marks, DifData[] difs) { Add(marks, difs, false); }
        protected void AddLocal(string[] marks, List<DifData> difs) { Add(marks, difs.ToArray()); }
        public void AddLocal(string mark, List<DifData> difs) { Add(new string[] { mark }, difs.ToArray()); }
        public void AddLocal(string mark, string text, List<DifData> difs) { Add(new string[] { mark },text, difs.ToArray()); }
        public void AddLocal(string mark, DifData dif) { Add(new string[] { mark }, new DifData[] { dif } ); }
        public void AddGlobal(string[] marks, DifData[] difs)
        { Add(marks, difs, true); }
        private void Add(
            string[] marks,
            DifData[] difs,
            bool installtoglobal = false)
        {
            Add(marks, difs, null, installtoglobal);
        }
        private void Add(
            string[] marks,
            string text,
            DifData[] difs,            
            bool installtoglobal = false)
        {
            seTe textData = new seTe(this.DefaultSceneText);
            textData.Text = text;
            Add(marks, difs, textData, installtoglobal);
        }
        private void Add(
            string[] marks,
            DifData[] difs,
            seTe text,
            bool installtoglobal = false)
        {
            CadreData cadreData = new CadreData();
            cadreData.TextData = text;
            cadreData.MarkList.AddRange(marks);
            foreach (var mark in marks)
            {
                if (!this.CadreGroups.Contains(mark)) this.CadreGroups.Add(mark);
            }
            foreach (var dif in difs)
            {
                cadreData.AlignList.Add(dif);
                if (installtoglobal && !string.IsNullOrEmpty(dif.Parent))
                {
                    cadreData.IsGlobalAlign = true;
                    AddToGlobalAlign(dif, difs.Where(x=>x.Name == dif.Parent).FirstOrDefault());
                }
            }
            AlignList.Add(cadreData);
        }
        private void AddToGlobalAlign(DifData dd, DifData pardelta)
        {
            if (!string.IsNullOrEmpty(dd.Parent))
            {
                // get child storage items
                var storageitem = GameWorld.ImageStorage.Where(x => x.Name == dd.Name).FirstOrDefault();
                if (storageitem != null)
                {
                    // check if default align for that parent is not already assigned
                    var oldalign = storageitem.Parents.Where(x => x.Parent == dd.Parent && x.Tag == dd.Tag).FirstOrDefault();
                    if (oldalign == null)
                    {
                        // Get parent image align via default align and delta
                        seIm parIm = new seIm();
                        var pardefaultalgn = GameWorld.ImageStorage.Where(x => x.Name == dd.Parent).FirstOrDefault().DefaultAlign;
                        parIm.AssignFrom(pardefaultalgn); // default and delta
                        parIm.AssignFrom(pardelta);
                        // Get child image align via default align and delta
                        seIm childIm = new seIm();
                        var childdefaultalgn = storageitem.DefaultAlign;
                        childIm.AssignFrom(childdefaultalgn); // default and delta
                        childIm.AssignFrom(dd);
                        // add align for that parent
                        ImageRelDifVec newalign = new ImageRelDifVec();
                        newalign.Tag = dd.Tag;
                        newalign.Parent = dd.Parent;
                        newalign.CreateDifProportions(parIm, childIm);
                        storageitem.Parents.Add(newalign);
                    }
                }
            }

        }
    

    #endregion

    
    }

}
