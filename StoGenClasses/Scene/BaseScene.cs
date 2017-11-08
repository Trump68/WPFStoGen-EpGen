using System;
using System.Collections.Generic;
using System.Linq;
using StoGenMake.Elements;
using System.IO;
using StoGen.Classes;

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
        public float cSx = 1;
        public float cSy = 1;
        public int R = 0;
        public int pR = 0;
        public int pF = 0;
        public int F = 0;
        public int pO = -1;
        public int cO = -1;
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

            //dSx = ((float)childIm.Sx / (float)parIm.Sx);
            //dSy = ((float)childIm.Sy / (float)parIm.Sy);
            cSx = childIm.Sx;
            cSy = childIm.Sy;

            pSx = parIm.Sx;
            pSy = parIm.Sy;

            pT = parIm.T;
            pO = parIm.O;
            cO = childIm.O;
            dO = childIm.O - parIm.O;
        }

        //! new!!!!
        internal void ApplyTo(seIm target, seIm actualParent, DifData delta)
        {
            float dSx = ((float)cSx / (float)pSx);
            float dSy = ((float)cSy / (float)pSy);
            if (delta != null )
            {
                if (delta.Sx.HasValue)
                    dSx = ((float)delta.Sx / (float)pSx);
                if (delta.Sy.HasValue)
                    dSy = ((float)delta.Sy / (float)pSy);
            }
            target.Sx = Convert.ToInt32(dSx * actualParent.Sx);
            target.Sy = Convert.ToInt32(dSy * actualParent.Sy);
           
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

                target.X = (int)(target.X * ((float)actualParent.Sx / pSx));
                target.Y = (int)(target.Y * ((float)actualParent.Sy / pSy));               

                target.X = target.X + actualParent.X;
                target.Y = target.Y + actualParent.Y;

                //if (delta != null && delta.Xd.HasValue)
                //    target.X = target.X + delta.X.Value;
                //if (delta != null && delta.Y.HasValue)
                //    target.Y = delta.Y.Value;
            }
            target.R = this.R;
            if (delta.Rd.HasValue) target.R = target.R + delta.Rd.Value;
            if (delta.R.HasValue) target.R = delta.R.Value;

            target.F = this.F;

            // transition
            target.T = this.pT; //default
            target.T = actualParent.T; // parent
            if (delta.T != null) //delta
                target.T = delta.T;
            
            // opacity
            if (this.cO > -1 )
                target.O = this.cO;
              //if (delta.Od.HasValue) target.O = target.O + delta.Od.Value;
        }
    }
    public class CadreData
    {
        public bool IsGlobalAlign = false;
        public List<seSo> SoundList = new List<seSo>();
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
        
        protected virtual void MakeCadres(string[] cadregroups, bool all = false)
        {
            foreach (var item in AlignList.Where(
                x =>
                all
                ||
                x.MarkList.Any(z=>cadregroups.Contains(z))))
            {
                MakeCadre(item);
            }
        }
        protected virtual void MakeCadres(string cadregroup)
        {
            MakeCadres(new string[] { cadregroup }, (cadregroup == null));
        }
        private void MakeCadre(CadreData item)
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
                im.Parent = ai.Parent;
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
                    //im.AssignFrom(isi.DefaultAlign);
                    // assign delta align, if any
                    im.AssignFrom(ai);

                }               
                // add image to cadre
                cadre.AddImage(im);
            }
            cadre.SoundList.AddRange(item.SoundList);
            if (text != null)
            {
                cadre.AddText(text);
            }

        }
        public void AddToGlobalImage(string name, string fn, string path)
        {
            ImageAlignVec newIAV = new ImageAlignVec() { Name = name, File = path + fn };
            newIAV.DefaultAlign = new DifData();
            newIAV.DefaultAlign.Name = name;
            GameWorld.ImageStorage.Add(newIAV);
        }
        protected void AddLocal(string[] marks, DifData[] difs) { Add(marks, difs, false); }
        protected void AddLocal(string[] marks, List<DifData> difs) { Add(marks, difs.ToArray()); }
        public void AddLocal(string mark, List<DifData> difs) { Add(new string[] { mark }, difs.ToArray()); }
        public void AddLocal(string mark, string text, List<DifData> difs, List<seSo> sounds = null)
        {
            Add(new string[] { mark },text, difs.ToArray(), sounds);
        }
        public void AddLocal(string mark, DifData dif) { Add(new string[] { mark }, new DifData[] { dif } ); }
        public void AddGlobal(string[] marks, DifData[] difs)
        { Add(marks, difs, true); }
        private void Add(
            string[] marks,
            DifData[] difs,
            bool installtoglobal = false)
        {
            Add(marks, difs,null, null, installtoglobal);
        }
        private void Add(
            string[] marks,
            string text,
            DifData[] difs,
            List<seSo> sounds,
            bool installtoglobal = false)
        {
            seTe textData = new seTe(this.DefaultSceneText);
            textData.Text = text;
            Add(marks, difs, textData, sounds, installtoglobal);
        }
        private void Add(
            string[] marks,
            DifData[] difs,            
            seTe text,
            List<seSo> sounds,
            bool installtoglobal = false
            )
        {
            CadreData cadreAlignData = new CadreData();
            cadreAlignData.TextData = text;
            if (sounds != null && sounds.Any())
                cadreAlignData.SoundList.AddRange(sounds);
            cadreAlignData.MarkList.AddRange(marks);
            foreach (var mark in marks)
            {
                if (!this.CadreGroups.Contains(mark)) this.CadreGroups.Add(mark);
            }
            foreach (var dif in difs)
            {
                cadreAlignData.AlignList.Add(dif);
                if (installtoglobal && !string.IsNullOrEmpty(dif.Parent))
                {
                    cadreAlignData.IsGlobalAlign = true;
                    AddToGlobalAlign(dif, difs.Where(x=>x.Name == dif.Parent).FirstOrDefault());
                }
            }
            AlignList.Add(cadreAlignData);
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

    public class DifData
    {

        public DifData() { }
        public DifData(string name) : this() { Name = name; }
        public DifData(string name, string parent) : this() { Name = name; Parent = parent; }
        public DifData(AlignData item) : this()
        {
            this.Name = item.Name;
            this.Parent = item.Parent;
            if (item.Im != null)
            {
                this.X = item.Im.X;
                this.Y = item.Im.Y;
                this.Sy = item.Im.Sy;
                this.Sx = item.Im.Sx;
                this.R = item.Im.R;
                this.F = item.Im.F;
            }

        }
        public DifData(seIm item) : this()
        {
            this.Name = item.Name;

            this.X = item.X;
            this.Y = item.Y;
            this.Sy = item.Sy;
            this.Sx = item.Sx;
            this.R = item.R;
            this.F = item.F;
        }
        public DifData(string name, string parent, string tag) : this(name, parent)
        {
            this.Tag = tag;
        }
        public string Tag { set; get; }
        public string Name { set; get; }
        public string Parent { set; get; }
        public int? X { set; get; }
        public int? Xd { set; get; }
        public int? Y { set; get; }
        public int? Yd { set; get; }
        public int? S
        {
            set
            {
                Sy = value;
                Sx = value;
            }
            get { return Sx; }
        }
        public int? Sx { set; get; }
        public int? Sy { set; get; }
        public int? R { set; get; } //rotation
        public int? Rd { set; get; } //increment rotation
        public int? F { set; get; } // flip   
        public int? O { set; get; }
        public int? Od { set; get; }
        public string T { set; get; }

        internal void AssingFrom(DifData value, bool withnames = false)
        {
            if (value == null) return;
            if (value.F.HasValue) this.F = value.F;
            if (value.X.HasValue) this.X = value.X;
            if (value.Y.HasValue) this.Y = value.Y;
            if (value.R.HasValue) this.R = value.R;
            if (value.S.HasValue) this.S = value.S;
            if (value.O.HasValue) this.S = value.O;
            if (value.Rd.HasValue) this.Rd = value.Rd;
            if (value.Od.HasValue) this.Od = value.Od;
            if (value.Xd.HasValue) this.Xd = value.Xd;
            if (value.Yd.HasValue) this.Yd = value.Yd;
            if (string.IsNullOrEmpty(value.T)) this.T = value.T;
            if (withnames)
            {
                this.Name = value.Name;
                this.Parent = value.Parent;
            }
        }

        internal void Clear()
        {
            this.F = null;
            this.X = null;
            this.Y = null;
            this.R = null;
            this.S = null;
            this.O = null;
            this.T = null;
            this.Rd = null;
            this.Od = null;
            this.Xd = null;
            this.Yd = null;
        }
    }
}
