using StoGen.Classes;
using StoGenLife.NPC;
using StoGenLife.SOUND;
using StoGenMake;
using StoGenMake.Elements;
using StoGenMake.Entity;
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
        public EntityData Data = new EntityData();

        public virtual bool CreateMenuPersone(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            return false;
        }
        public virtual bool CreateMenuPersoneDocier(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem($"Досье на {this.Name}", this);
            item.Executor = delegate (object data)
            {
                this.FillDocierScene();
                //this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                this.Scene.Generate(null);

                StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
            return true;
        }
        public virtual void FillDocierScene()
        {
            if (this.Scene == null) this.Scene = new BaseScene();
            this.Scene.AddActor(this);
            this.Scene.Cadres.Clear();
            var items = this.Data.ByName("IMAGE", DOCIER_PICTURE, null);
            foreach (var it in items)
            {
                ScenCadre cadre;
                cadre = this.Scene.AddCadre(null, null, 200);

                ScenElementImage image;
                image = new ScenElementImage();
                image.Name = $"DOCIER_PICTURE {cadre.VisionList.Count}";
                image.File = it.Value;
                cadre.VisionList.Add(image);
            }
        }

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
        public virtual void AssembleHead(ScenCadre cadre)
        {
            if (FaceEnabled) this.CurrentFace.Applay(cadre);
        }
        public virtual void AssembleVoice(ScenCadre cadre)
        {
            if (Voice != null) this.Voice.Set(cadre);
        }



    }


    public class VNPCFace
    {

        public VNPCFace(string name, string file)
        {
            this.Name = name;
            this.File = file;
        }
        public string File { set; get; }
        public string Name { set; get; }


        public VNPCMouth Mouth { get; set; } = new VNPCMouth();
        public VNPCFaceSkin FaceSkin { get; set; } = new VNPCFaceSkin();
        public VNPCBrows Brows { get; set; } = new VNPCBrows();
        public VNPCEyes Eyes { get; set; } = new VNPCEyes();



        public VNPCEmotionalState StateEmotional { get; set; } = VNPCEmotionalState.None;
        public VNPCEmotionalGrade GradeEmotional { get; set; } = VNPCEmotionalGrade.None;

        public virtual void Reset()
        {
            Eyes.SetType(VNPCEyes.Type.OpenCenter);
            Eyes.State = VNPCBodyPart.ChangeState.Already;


            Mouth.SetType(VNPCMouth.Type.Neitral);
            Mouth.State = VNPCBodyPart.ChangeState.Already;

            FaceSkin.SetType(VNPCFaceSkin.Type.None);
            FaceSkin.State = VNPCBodyPart.ChangeState.Already;

            Brows.SetType(VNPCBrows.Type.Neitral);
            Brows.State = VNPCBodyPart.ChangeState.Already;


            if (StateEmotional == VNPCEmotionalState.Joy)
            {
                Mouth.SetType(VNPCMouth.Type.OpenSense);
            }
            else if (StateEmotional == VNPCEmotionalState.Worry)
            {
                Brows.SetType(VNPCBrows.Type.Worry);
                Mouth.SetType(VNPCMouth.Type.OpenWorry);
            }
        }
        public virtual void Applay(ScenCadre cadre)
        {
            Reset();

            cadre.AddImage(false, File, Name);

            this.FaceSkin.Applay(cadre, true);
            this.Mouth.Applay(cadre, true);
            this.Eyes.Applay(cadre, true);
            this.Brows.Applay(cadre, true);
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
                return (State != ChangeState.Already)
                 &&
                 (State != ChangeState.GoNone);
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
        public VNPCBodyPartSnap(string file, string name)
        {
            this.File = file;
            this.Name = name;
        }
        public string File { set; get; }
        public string Name { set; get; }

    }
    #endregion

    #region Mouth
    public class VNPCMouth : VNPCBodyPart
    {
        public enum Type
        {
            Neitral,
            OpenSense,
            Squeeze,
            OpenWorry,
            Doubt
        }
        public bool Enabled { get { return this.SnapList.Any(); } }
        public List<VNPCMouthSnap> SnapList = new List<VNPCMouthSnap>();
        private VNPCMouthSnap _Current;
        public VNPCMouthSnap Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.SnapList.First();
                }
                return _Current;
            }
        }
        private VNPCMouthSnap _Previous;
        public VNPCMouthSnap Previous
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
        public void SetType(VNPCMouth.Type type)
        {
            Current = SnapList.Where(x => x.Type == type).FirstOrDefault();
            State = VNPCMouth.ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            if (periodic)
                cadre.AddImage(false, Previous.File);
            var image = cadre.AddImage(invisible, Current.File);
            if (invisible || reverse)
                image.Transition = Transition.Mouth(200, reverse, periodic, permanent);
        }

    }
    public class VNPCMouthSnap : VNPCBodyPartSnap
    {
        public VNPCMouth.Type Type { set; get; }
        public VNPCMouthSnap(VNPCMouth.Type type, string file, string name) : base(file, name)
        {
            this.Type = type;
        }
    }
    #endregion

    #region FaceSkin
    public class VNPCFaceSkin : VNPCBodyPart
    {
        public enum Type
        {
            None,
            Blush
        }
        public bool Enabled { get { return this.SnapList.Any(); } }
        public List<VNPCFaceSkinSnap> SnapList = new List<VNPCFaceSkinSnap>();
        private VNPCFaceSkinSnap _Current;
        public VNPCFaceSkinSnap Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.SnapList.First();
                }
                return _Current;
            }
        }
        private VNPCFaceSkinSnap _Previous;
        public VNPCFaceSkinSnap Previous
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
        public void SetType(VNPCFaceSkin.Type type)
        {
            Current = SnapList.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            var image = cadre.AddImage(invisible, SnapList.Where(x => x.Type == Type.Blush).FirstOrDefault().File, null);
            if (invisible || reverse)
                image.Transition = Transition.Blush(500, reverse, periodic, permanent);
        }
    }
    public class VNPCFaceSkinSnap : VNPCBodyPartSnap
    {
        public VNPCFaceSkin.Type Type { set; get; }
        public VNPCFaceSkinSnap(VNPCFaceSkin.Type type, string file, string name) : base(file, name)
        {
            this.Type = type;
        }
    }
    #endregion

    #region Brows
    public class VNPCBrows : VNPCBodyPart
    {
        public enum Type
        {
            Neitral,
            Worry
        }
        public bool Enabled { get { return this.SnapList.Any(); } }
        public List<VNPCBrowSnap> SnapList = new List<VNPCBrowSnap>();
        private VNPCBrowSnap _Current;
        public VNPCBrowSnap Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.SnapList.First();
                }
                return _Current;
            }
        }
        private VNPCBrowSnap _Previous;
        public VNPCBrowSnap Previous
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
        public void SetType(VNPCBrows.Type type)
        {
            Current = SnapList.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            var image = cadre.AddImage(invisible, Current.File, null);
            if (invisible || reverse)
                image.Transition = Transition.Blush(500, reverse, false, false);
        }

    }
    public class VNPCBrowSnap : VNPCBodyPartSnap
    {
        public VNPCBrows.Type Type { set; get; }
        public VNPCBrowSnap(VNPCBrows.Type type, string file, string name) : base(file, name)
        {
            this.Type = type;
        }
    }

    #endregion

    #region Eyes
    public class VNPCEyes : VNPCBodyPart
    {
        public enum Type
        {
            OpenCenter,
            Close,
            Squeeze,
            Hide
        }
        public bool Enabled { get { return this.SnapList.Any(); } }
        public List<VNPCEyesSnap> SnapList = new List<VNPCEyesSnap>();
        private VNPCEyesSnap _Current;
        public VNPCEyesSnap Current
        {
            set { this._Current = value; }
            get
            {
                if (_Current == null)
                {
                    _Current = this.SnapList.First();
                }
                return _Current;
            }
        }
        private VNPCEyesSnap _Previous;
        public VNPCEyesSnap Previous
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
        public void SetType(VNPCEyes.Type type)
        {
            Current = SnapList.Where(x => x.Type == type).FirstOrDefault();
            State = ChangeState.GoPulsed;
        }
        public void Applay(ScenCadre cadre, bool permanent)
        {
            if (!Enabled) return;
            if (periodic)
            {
                cadre.AddImage(false, Previous.File, null);
            }
            var image = cadre.AddImage(invisible, Current.File, null);
            if (invisible || reverse)
                image.Transition = Transition.Eyes(200, reverse, periodic, permanent);

            image = cadre.AddImage(invisible, SnapList.Where(x => x.Type == Type.Close).FirstOrDefault().File, null);
            image.Transition = Transition.Eyes_Blink;
        }

    }
    public class VNPCEyesSnap : VNPCBodyPartSnap
    {
        public VNPCEyes.Type Type { set; get; }
        public VNPCEyesSnap(VNPCEyes.Type type, string file, string name) : base(file, name)
        {
            this.Type = type;
        }
    }
    #endregion

    public class VNPCCloth
    {
        public string Name { set; get; }
        public string MainImage { get; private set; }
        public VNPCClothType Type { set; get; }
        public VNPCCloth(string file, string name, VNPCClothType type)
        {
            this.MainImage = file;
            this.Name = name;
            this.Type = type;
        }
        public virtual void Set(ScenCadre cadre)
        {
            cadre.AddImage(false, Name);
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
            if (State == VNPCVoiceState.None) return;
            var sound = cadre.AddSound(Name);
        }

    }
    public enum VNPCPersType
    {
        Real,
        HCG,
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
