using StoGen.Classes;
using StoGen.Classes.Transition;
using StoGenLife.NPC;
using StoGenLife.SOUND;
using StoGenMake;
using StoGenMake.Elements;
using StoGenMake.Persona;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace StoGenMake.Pers
{
    public class VNPC : NPC
    {

        #region constants
        // sound
        public static string MUSIC_MAIN_THEME = "MUSIC_MAIN_THEME";
        public static string ASMR_01 = "ASMR_01";
        public static string ORGAZM_01 = "ORGAZM_01";


        public static string ORGAZM_02 = "ORGAZM_02";
        public static string ORGAZM_03 = "ORGAZM_03";
        public static string ORGAZM_04 = "ORGAZM_04";

        // images
        public static string MAIN_PERSON_PICTURE = "MAIN_PERSON_PICTURE";

        public static string DOCIER_PICTURE = "DOCIER_PICTURE";
        //parts
        public static string RIGHT_EYE_WINK = "RIGHT_EYE_WINK";
        public static string EYES_CLOSE_01 = "EYES_CLOSE_01";
        #endregion

        public VNPC()
        {

        }
        public VNPCPersType PersonType = VNPCPersType.Real;
        public BaseScene Scene { set; get; }
        //public EntityData Data = new EntityData();

        public virtual bool CreateMenuPersone(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            return false;
        }
        //public virtual bool CreateMenuPersoneDocier(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

        //    item = new ChoiceMenuItem($"Досье на {this.Name}", this);
        //    item.Executor = delegate (object data)
        //    {
        //        this.FillDocierScene();
        //        //this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
        //        this.Scene.Generate(null);

        //        StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
        //        proc.MenuCreator = proc.OldMenuCreator;
        //        proc.GetNextCadre();
        //    };
        //    itemlist.Add(item);
        //    ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
        //    return true;
        //}
        ////public virtual void FillDocierScene()
        //{
        //    if (this.Scene == null) this.Scene = new BaseScene();
        //    this.Scene.AddActor(this);
        //    this.Scene.Cadres.Clear();
        //    //var items = this.Data.ByName("IMAGE", DOCIER_PICTURE, null);
        //    //foreach (var it in items)
        //    //{
        //    //    ScenCadre cadre;
        //    //    cadre = this.Scene.AddCadre(null, null, 200);
        //    //    cadre.VisionList.Add(it.Image);
        //    //}
        //}

        public List<VNPCCloth> ClothList { set; get; } = new List<VNPCCloth>();
        public List<VNPCFace> Faces { set; get; } = new List<VNPCFace>();
        public List<VNPCVoice> VoiceList { set; get; } = new List<VNPCVoice>();
        private VNPCFace _CurrentFace;
        public VNPCFace CurrentFace
        {
            get
            {
                if (!FaceEnabled) return null;
                if (_CurrentFace == null)
                {
                    _CurrentFace = this.Faces.First();
                }
                return _CurrentFace;
            }
            set
            {
                if (value != null) 
                _CurrentFace = value;
            }
        }
        public bool FaceEnabled
        {
            get { return this.Faces.Any(); }
        }
        VNPCCloth _Cloth;
        public VNPCCloth Cloth
        {
            get
            {
                if (_Cloth == null)
                    _Cloth = this.ClothList.FirstOrDefault();
                return _Cloth;
            }
            set
            {
                _Cloth = value;
                if (!this.ClothList.Contains(_Cloth))
                    this.ClothList.Add(_Cloth);
            }
        }
        VNPCVoice _Voice;
        public VNPCVoice Voice
        {
            get
            {
                if (_Voice == null)
                    _Voice = this.VoiceList.FirstOrDefault();
                return _Voice;
            }
            set
            {
                _Voice = value;
                if (!this.VoiceList.Contains(_Voice))
                    this.VoiceList.Add(_Voice);
            }
        }

        public virtual void AssembleFigure(ScenCadre cadre)
        {
            AssembleBody(cadre);
            AssembleHead(cadre);
            AssembleVoice(cadre);
        }
        public virtual void AssembleBody(ScenCadre cadre)
        {
            if (Cloth != null) this.Cloth.Set(cadre);
        }
        public virtual void AssembleHead(ScenCadre cadre, string name = null)
        {
            if (!FaceEnabled) return;
            this.CurrentFace = this.Faces.Where(x => x.Head.Name == name).FirstOrDefault();
            this.CurrentFace.Applay(cadre);
        }
        public virtual VNPCFace GetHead(string name)
        {
            if (!FaceEnabled) return null;
            if (!string.IsNullOrEmpty(name))
                this.CurrentFace = this.Faces.Where(x => x.Head.Name == name).FirstOrDefault();
            return this.CurrentFace;
        }
        public virtual VNPCCloth GetBody(string name)
        {
            if (!string.IsNullOrEmpty(name))
                this.Cloth = this.ClothList.Where(x => x.image.Name == name).FirstOrDefault();
            return this.Cloth;
        }

        public virtual void AssembleVoice(ScenCadre cadre)
        {
            if (Voice != null) this.Voice.Set(cadre);
        }



    }


    public class VNPCFace
    {
        public seIm Head { set; get; }
        public VNPCFace(seIm head)
        {
            this.Head = head;
        }


        public vMouth Mouth { get; set; } = new vMouth();
        public vFcSkin FaceSkin { get; set; } = new vFcSkin();
        public vBrow Brows { get; set; } = new vBrow();
        public vEye Eyes { get; set; } = new vEye();



        public VNPCEmotionalState StateEmotional { get; set; } = VNPCEmotionalState.None;
        public VNPCEmotionalGrade GradeEmotional { get; set; } = VNPCEmotionalGrade.None;

        public virtual void Reset()
        {
            Eyes.SetType(vEye.Type.OpenCenter);
            Eyes.State = VNPCBodyPart.ChangeState.Already;


            Mouth.SetType(vMouth.Type.Neitral);
            Mouth.State = VNPCBodyPart.ChangeState.Already;

            FaceSkin.SetType(vFcSkin.Type.None);
            FaceSkin.State = VNPCBodyPart.ChangeState.Already;

            Brows.SetType(vBrow.Type.Neitral);
            Brows.State = VNPCBodyPart.ChangeState.Already;


            if (StateEmotional == VNPCEmotionalState.Joy)
            {
                Mouth.SetType(vMouth.Type.OpenSense);
            }
            else if (StateEmotional == VNPCEmotionalState.Worry)
            {
                Brows.SetType(vBrow.Type.Worry);
                Mouth.SetType(vMouth.Type.OpenWorry);
            }
        }
        public virtual void Applay(ScenCadre cadre)
        {
            Reset();

            cadre.AddImage(this.Head);
            this.FaceSkin.Applay(cadre, true);
            this.Mouth.Applay(cadre, true);
            this.Eyes.Applay(cadre, true);
            this.Brows.Applay(cadre, true);
        }

        //internal void AlignTo(VNPCCloth body)
        //{
            
        //    this.Head.Reset();
        //    if (body == null) return;
        //    var align = GameWorldFactory.GameWorld.AlignList.Where(x => x.Source == this.Head.Name && x.Parent == body.image.Name).FirstOrDefault();
        //    if (align != null)
        //        align.AlignSource()
        //        this.Head.AssinFrom(align.Im);
        //}

        internal void AlignTo(seIm seIm)
        {
            //this.Head.Reset();
            //if (seIm != null)
            //    this.Head.AssignFrom(seIm);
        }
    }


    #region Base parts
    public class VNPCBodyPart
    {
        public enum ChangeState
        {
            Disabled,
            Default,
            None,
            Already,
            AlreadyPulsed,
            Go,
            GoPulsed,
            GoNone
        }
        public ChangeState State { get; set; } = ChangeState.Already;
        protected bool invisible
        {
            get
            {
                return ((State != ChangeState.Already)
                 &&
                 (State != ChangeState.GoNone));
                
            }
        }
        protected bool periodic
        {
            get
            {
                return (State == ChangeState.AlreadyPulsed)
                       ||
                       (State == ChangeState.GoPulsed);
            }
        }
        protected bool reverse
        {
            get
            {
                return (State == ChangeState.GoNone);
            }
        }

    }
    public class VNPCBodyPartSnap
    {
        public VNPCBodyPartSnap(seIm im)
        {
            image = im;
        }
        
        public seIm image { set; get; } 
    }
    #endregion

    #region Mouth
    public class vMouth : VNPCBodyPart
    {
        public enum Type
        {
            Neitral,
            OpenSense,
            Squeeze,
            OpenWorry,
            Doubt
        }
        public bool Enabled { get { return this.Items.Any(); } }
        public List<VvMouthS> Items = new List<VvMouthS>();
        private VvMouthS _Current;
        public VvMouthS Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.Items.First();
                }
                return _Current;
            }
        }
        private VvMouthS _Previous;
        public VvMouthS Previous
        {
            set { this._Previous = value; }
            get
            {
                if (_Previous == null)
                {
                    _Previous = Current;
                }
                return _Previous;
            }
        }
        public void SetType(vMouth.Type type)
        {
            Current = Items.Where(x => x.Type == type).FirstOrDefault();
            State = vMouth.ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            if (periodic)
                cadre.AddImage(Previous.image);

            if (invisible) Current.image.O = 0;
            else Current.image.O = 100;

            var image = cadre.AddImage(Current.image);
            if (invisible || reverse)
                image.T = Transitions.Mouth(200, reverse, periodic, permanent);
        }

    }
    public class VvMouthS : VNPCBodyPartSnap
    {
        public vMouth.Type Type { set; get; }
        public VvMouthS(vMouth.Type type, seIm im) : base(im)
        {
            this.Type = type;
        }
    }
    #endregion

    #region FaceSkin
    public class vFcSkin : VNPCBodyPart
    {
        public enum Type
        {
            None,
            Blush
        }
        public bool Enabled { get { return this.Items.Any(); } }
        public List<vFcSkinS> Items = new List<vFcSkinS>();
        private vFcSkinS _Current;
        public vFcSkinS Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.Items.First();
                }
                return _Current;
            }
        }
        private vFcSkinS _Previous;
        public vFcSkinS Previous
        {
            set { this._Previous = value; }
            get
            {
                if (_Previous == null)
                {
                    _Previous = Current;
                }
                return _Previous;
            }
        }
        public void SetType(vFcSkin.Type type)
        {
            Current = Items.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;

            var im = Items.Where(x => x.Type == Type.Blush).FirstOrDefault().image;
            if (im == null) return;
            
            if (invisible) im.O = 0;
            else im.O = 100;

            var image = cadre.AddImage(im);
            if (invisible|| reverse)
                image.T = Transitions.Blush(500, reverse, periodic, permanent);
        }
    }
    public class vFcSkinS : VNPCBodyPartSnap
    {
        public vFcSkin.Type Type { set; get; }
        public vFcSkinS(vFcSkin.Type type, seIm im) : base(im)
        {
            this.Type = type;
        }
    }
    #endregion

    #region Brows
    public class vBrow : VNPCBodyPart
    {
        public enum Type
        {
            Neitral,
            Worry
        }
        public bool Enabled { get { return this.Items.Any(); } }
        public List<vBrowS> Items = new List<vBrowS>();
        private vBrowS _Current;
        public vBrowS Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.Items.First();
                }
                return _Current;
            }
        }
        private vBrowS _Previous;
        public vBrowS Previous
        {
            set { this._Previous = value; }
            get
            {
                if (_Previous == null)
                {
                    _Previous = Current;
                }
                return _Previous;
            }
        }
        public void SetType(vBrow.Type type)
        {
            Current = Items.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;

            if (invisible) Current.image.O = 0;
            else Current.image.O = 100;

            var image = cadre.AddImage(Current.image);
            if (invisible|| reverse)
                image.T = Transitions.Blush(500, reverse, false, false);
        }

    }
    public class vBrowS : VNPCBodyPartSnap
    {
        public vBrow.Type Type { set; get; }
        public vBrowS(vBrow.Type type, seIm im) : base(im)
        {
            this.Type = type;
        }
    }

    #endregion

    #region Eyes
    public class vEye : VNPCBodyPart
    {
        public enum Type
        {
            OpenCenter,
            Close,
            Squeeze,
            Hide
        }
        public bool Enabled { get { return this.Items.Any(); } }
        public List<vEyeS> Items = new List<vEyeS>();
        private vEyeS _Current;
        public vEyeS Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.Items.First();
                }
                return _Current;
            }
        }
        private vEyeS _Previous;
        public vEyeS Previous
        {
            set { this._Previous = value; }
            get
            {
                if (_Previous == null)
                {
                    _Previous = Current;
                }
                return _Previous;
            }
        }
        public void SetType(vEye.Type type)
        {
            Current = Items.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            if (periodic)
            {
                cadre.AddImage(Previous.image);
            }
            
            if (invisible) Current.image.O = 0;
            else
                Current.image.O = 100;

            var image = cadre.AddImage(Current.image);
            if (invisible || reverse)
                image.T = Transitions.Eyes(200, reverse, periodic, permanent);

            var im = Items.Where(x => x.Type == Type.Close).FirstOrDefault();
            if (im == null) return;
            im.image.O = 0;
            image = cadre.AddImage(im.image);
            image.T = Transitions.Eye_Close;
        }

    }
    public class vEyeS : VNPCBodyPartSnap
    {
        public vEye.Type Type { set; get; }
        public vEyeS(vEye.Type type, seIm im) : base(im)
        {
            this.Type = type;
        }
    }
    #endregion

    public class VNPCCloth: VNPCBodyPartSnap
    {
        public VNPCClothType Type { set; get; }
        
        public VNPCCloth(VNPCClothType type, seIm im):base(im)
        {
            this.Type = type;
        }
        public virtual void Set(ScenCadre cadre)
        {
            cadre.AddImage(this.image);
        }

        internal void AlignTo(seIm seIm)
        {
           //if (seIm !=null)
           //     this.image.AssignFrom(seIm);
        }
    }
    public class VNPCVoice
    {
        public string Name { set; get; }
        public VNPCVoiceState State { set; get; } = VNPCVoiceState.None;
        public VNPCVoiceType Type { set; get; }
        public VNPCTermType TermType { set; get; }
        public VNPCVoice(string name, VNPCVoiceType type, VNPCTermType TermType)
        {
            this.Name = name;
            this.Type = type;
        }
        public VNPCVoice(SoundStore.Sounds name, VNPCVoiceType type, VNPCTermType TermType)
        {
            this.Name = Enum.GetName(typeof(SoundStore.Sounds), name);
            this.Type = type;
        }
        public virtual void Set(ScenCadre cadre)
        {
            var sound = cadre.AddSound(Name);
        }

    }
    public enum VNPCPersType
    {
        Real,
        HCG,
        Comix,
        Manga,
        ArtCG,
        JAV
    }

    public enum VNPCEmotionalState
    {
        None,
        Joy,
        Flirt,
        Worry
    }
    public enum VNPCEmotionalGrade
    {
        None,
        Light,
        Middle,
        Heavy
    }
    public enum VNPCVoiceType
    {
        Neitral
    }
    public enum VNPCTermType
    {
        None,
        Yes,
        No
    }
    public enum VNPCClothType
    {
        Undefined,
        Naked,
        Kimono,
        KimonoDecolte
    }
    public enum VNPCVoiceState
    {
        None,
        Go,
        GoPeriodic
    }
}
//public override void PrepareScene()
//{
//    this.Scene = new MainPersonScene();
//}

//public class MainPersonScene : BaseScene
//{
//    public MainPersonScene() : base()
//    {
//        this.Name = "Main person scene";
//    }
//    internal void Wink()
//    {
//        this.AddCadre_Wink();
//    }
//    public ScenCadre AddMainCadre(bool blink)
//    {
//        ScenCadre cadre = new ScenCadre(this);
//        cadre.Name = "Cadre 01";
//        cadre.Timer = 300 * 1000;
//        AddMainImage(cadre);
//        if (blink)
//            AddImageBlink(cadre);

//        AddMusic(cadre);
//        AddText(cadre);
//        this.Cadres.Add(cadre);
//        return cadre;
//    }
//    private void AddCadre_Wink()
//    {
//        ScenCadre cadre = new ScenCadre(this);
//        cadre.Name = "Cadre Wink";
//        cadre.Timer = 5 * 1000;
//        AddMainImage(cadre);
//        AddImageWink(cadre);
//        AddMusic(cadre);
//        AddText(cadre);
//        this.Cadres.Add(cadre);
//    }
//    private void AddMainImage(ScenCadre cadre)
//    {
//        ScenElementImage image = GetMainImage();
//        cadre.VisionList.Add(image);
//    }
//    private ScenElementImage GetMainImage()
//    {
//        ScenElementImage image = new ScenElementImage();
//        image.SizeX = 1600;
//        image.SizeY = 1500;
//        image.Name = VNPC.MAIN_PERSON_PICTURE;
//        image.Opacity = 100;
//        return image;
//    }
//    private void AddImageWink(ScenCadre cadre)
//    {
//        ScenElementImage image = GetMainImage();
//        image.Part = VNPC.RIGHT_EYE_WINK;
//        image.Opacity = 0;
//        image.Transition = Transition.Eye_Wink;
//        cadre.VisionList.Add(image);
//    }
//    private void AddImageBlink(ScenCadre cadre)
//    {
//        ScenElementImage image = GetMainImage();
//        image.Part = VNPC.EYES_CLOSE_01;
//        image.Opacity = 0;
//        image.Transition = Transition.Eyes_Blink;
//        cadre.VisionList.Add(image);
//    }
//    private void AddEyesClose(ScenCadre cadre)
//    {
//        ScenElementImage image = GetMainImage();
//        image.Part = VNPC.EYES_CLOSE_01;
//        image.Opacity = 0;
//        image.Transition = Transition.Eye_Close;
//        cadre.VisionList.Add(image);
//    }
//    private void AddMusic(ScenCadre cadre)
//    {
//        ScenElementSound sound;
//        sound = new ScenElementSound();
//        sound.Name = VNPC.MUSIC_MAIN_THEME;
//        sound.V = 0;
//        sound.Transition = "v.B.5000.10";
//        cadre.SoundList.Add(sound);
//    }
//    private void AddVoice(ScenCadre cadre, string voice)
//    {
//        ScenElementSound sound;
//        sound = new ScenElementSound();
//        sound.Name = voice;
//        sound.V = 0;
//        sound.Transition = "v.B.5000.100";
//        cadre.SoundList.Add(sound);
//    }
//    private void AddText(ScenCadre cadre)
//    {
//        ScenElementText text = new ScenElementText();
//        text.Text = "fff";
//        cadre.TextList.Add(text);
//    }

//    internal void ASMR_01(bool blink)
//    {
//        ScenCadre cadre = AddMainCadre(blink);
//        cadre.Name = "ASMR_01";
//        AddVoice(cadre, VNPC.ASMR_01);
//    }

//    internal void ORGAZM_01()
//    {
//        ScenCadre cadre = AddMainCadre(false);
//        cadre.Name = "ORGAZM_01";
//        AddEyesClose(cadre);
//        AddVoice(cadre, VNPC.ORGAZM_01);
//    }

//}
