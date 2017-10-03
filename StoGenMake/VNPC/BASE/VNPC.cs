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
    public class VNPC:NPC
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
        public VNPCFace Face { set; get; }
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
            this.Cloth.Set(cadre);            
            this.Face.SetFace(cadre);
            this.Voice.Set(cadre);
        }
       

       
       
    }

}
public class VNPCFace
{


    public VNPCFace(string name, string mainimage)
    {
        this.Name = name;
        this.MainImage = mainimage;
    }

    public string Name { set; get; }
    public VNPCBlushState StateBlush { get; set; } = VNPCBlushState.Disabled;
    public VNPCMouthState StateMouth { get; set; } = VNPCMouthState.Disabled;
    public VNPCEyesState StateEyes { get; set; } = VNPCEyesState.Disabled;
    public VNPCBlinkState StateBlink { get; set; } = VNPCBlinkState.None;
    public VNPCBrowsState StateBrows { get; set; } = VNPCBrowsState.None;


    public List<VNPCBrows> BrowsList { get; set; } = new List<VNPCBrows>();
    public List<VNPCMouth> MouthList { get; set; } = new List<VNPCMouth>();
    public List<VNPCEyes> EyesList { get; set; } = new List<VNPCEyes>();
    public List<VNPCSkin> SkinList { get; set; } = new List<VNPCSkin>();

    private VNPCMouth _Mouth;
    public VNPCMouth Mouth
    {
        get
        {
            if (_Mouth == null)
                _Mouth = this.MouthList.FirstOrDefault();
            return _Mouth;
        }
        set
        {
            _Mouth = value;
            if (!this.MouthList.Contains(_Mouth))
                this.MouthList.Add(_Mouth);
        }
    }
    private VNPCMouth _MouthDefault;
    public VNPCMouth MouthDefault
    {
        get
        {
            if (_MouthDefault == null)
                _MouthDefault = this.MouthList.FirstOrDefault();
            return _MouthDefault;
        }
        set
        {
            _MouthDefault = value;
            if (!this.MouthList.Contains(_MouthDefault))
                this.MouthList.Add(_MouthDefault);
        }
    }

    private VNPCEyes _Eyes;
    public VNPCEyes Eyes
    {
        get
        {
            if (_Eyes == null)
                _Eyes = this.EyesList.FirstOrDefault();
            return _Eyes;
        }
        set
        {
            _Eyes = value;
            if (!this.EyesList.Contains(_Eyes))
                this.EyesList.Add(_Eyes);
        }
    }
    private VNPCEyes _EyesDefault;
    public VNPCEyes EyesDefault
    {
        get
        {
            if (_EyesDefault == null)
                _EyesDefault = this.EyesList.FirstOrDefault();
            return _EyesDefault;
        }
        set
        {
            _EyesDefault = value;
            if (!this.EyesList.Contains(_EyesDefault))
                this.EyesList.Add(_EyesDefault);
        }
    }

    private VNPCBrows _Brows;
    public VNPCBrows Brows
    {
        get
        {
            if (_Brows == null)
                _Brows = this.BrowsList.FirstOrDefault();
            return _Brows;
        }
        set
        {
            _Brows = value;
            if (!this.BrowsList.Contains(_Brows))
                this.BrowsList.Add(_Brows);
        }
    }

    public VNPCEmotionalState StateEmotional { get; set; } = VNPCEmotionalState.None;
    public VNPCEmotionalGrade GradeEmotional { get; set; } = VNPCEmotionalGrade.None;
    public string MainImage { get; private set; }

    public virtual void Reset()
    {
        EyesDefault = EyesList.Where(x => x.Type == VNPCEyesType.OpenCenter).FirstOrDefault();
        MouthDefault = MouthList.Where(x => x.Type == VNPCMouthType.Neitral).FirstOrDefault();
        Eyes = EyesDefault;
        Mouth = MouthDefault;

        StateEyes = VNPCEyesState.Already;
        StateMouth = VNPCMouthState.Already;
        StateBlink = VNPCBlinkState.Go;
        StateBlush = VNPCBlushState.None;
        StateBrows = VNPCBrowsState.None;

        if (StateEmotional == VNPCEmotionalState.Joy)
        {
            SetMouthType(VNPCMouthType.OpenSense);
        }
        else if (StateEmotional == VNPCEmotionalState.Worry)
        {
            SetBrowsType(VNPCBrowsType.Worry);
            SetMouthType(VNPCMouthType.OpenWorry);
        }
    }
    public virtual void SetFace(ScenCadre cadre)
    {
        Reset();

        cadre.AddImage(false, MainImage);

        if (StateBlush != VNPCBlushState.Disabled)
        {
            this.SetBlushState(cadre, StateBlush, true);
        }
        if (StateMouth != VNPCMouthState.Disabled)
        {
            SetMouthState(cadre, StateMouth, true);
        }
        if (StateEyes != VNPCEyesState.Disabled)
        {
            this.SetEyesState(cadre, StateEyes, true);
        }
        if (StateBlink != VNPCBlinkState.None)
        {
            this.SetBlinkState(cadre, StateBlink);
        }
        this.SetBrowsState(cadre, StateBrows);
       
    }   
    private void SetMouthType(VNPCMouthType type)
    {
        Mouth = MouthList.Where(x => x.Type == type).FirstOrDefault();
        StateMouth = VNPCMouthState.GoPulsed;
    }
    private void FaceExitateBlush()
    {
        StateBlush = VNPCBlushState.GoPulsed;
    }
   
    private void SetEyesType(VNPCEyesType type)
    {
        Eyes = EyesList.Where(x => x.Type == type).FirstOrDefault();
        StateEyes = VNPCEyesState.GoPulsed;
    }
    private void SetBrowsType(VNPCBrowsType type)
    {
        Brows = BrowsList.Where(x => x.Type == type).FirstOrDefault();
        StateBrows = VNPCBrowsState.Go;
    }

    public virtual void SetBlushState(ScenCadre cadre, VNPCBlushState state, bool permanent)
    {
        if (state == VNPCBlushState.None) return;
        bool invisible =
            (state != VNPCBlushState.Already)
            &&
            (state != VNPCBlushState.GoNone);
        bool periodic =
            (state == VNPCBlushState.AlreadyPulsed)
            ||
            (state == VNPCBlushState.GoPulsed);
        bool reverse =
            (state == VNPCBlushState.GoNone);

        if (state == VNPCBlushState.None) return;

        var image = cadre.AddImage(invisible, SkinList.Where(x => x.BlushState == VNPCBlushState.Go).FirstOrDefault().Name);
        if (invisible || reverse)
            image.Transition = Transition.Blush(500, reverse, periodic, permanent);
    }
    protected virtual void SetEyesState(ScenCadre cadre, VNPCEyesState state, bool permanent)
    {
        bool invisible =
           (state != VNPCEyesState.Already)
           &&
           (state != VNPCEyesState.GoNone);
        bool periodic =
           (state == VNPCEyesState.AlreadyPulsed)
           ||
           (state == VNPCEyesState.GoPulsed);
        bool reverse =
            (state == VNPCEyesState.GoNone);

        if (periodic)
        {
            cadre.AddImage(false, EyesDefault.Name);
        }
        var image = cadre.AddImage(invisible, Eyes.Name);
        if (invisible || reverse)
            image.Transition = Transition.Eyes(200, reverse, periodic, permanent);
    }
    protected virtual void SetMouthState(ScenCadre cadre, VNPCMouthState state, bool permanent)
    {
        bool invisible =
           (state != VNPCMouthState.Already)
           &&
           (state != VNPCMouthState.GoNone);
        bool periodic =
           (state == VNPCMouthState.AlreadyPulsed)
           ||
           (state == VNPCMouthState.GoPulsed);
        bool reverse =
            (state == VNPCMouthState.GoNone);

        if (periodic)
        {
            cadre.AddImage(false, MouthDefault.Name);
        }
        var image = cadre.AddImage(invisible, Mouth.Name);
        if (invisible || reverse)
            image.Transition = Transition.Mouth(200, reverse, periodic, permanent);
    }
    protected virtual void SetBrowsState(ScenCadre cadre, VNPCBrowsState state)
    {
        if (state == VNPCBrowsState.None) return;
        bool invisible =
            (state != VNPCBrowsState.Already)
            &&
            (state != VNPCBrowsState.GoNone);
        bool reverse =
            (state == VNPCBrowsState.GoNone);

        var image = cadre.AddImage(invisible, Brows.Name);
        if (invisible || reverse)
            image.Transition = Transition.Blush(500, reverse, false, false);
    }
    protected virtual void SetBlinkState(ScenCadre cadre, VNPCBlinkState state)
    {
        bool invisible = true;
        var image = cadre.AddImage(invisible, EyesList.Where(x => x.Type == VNPCEyesType.Close).FirstOrDefault().Name);
        image.Transition = Transition.Eyes_Blink;
    }
}
public class VNPCMouth
{
    public string Name { set; get; }
    public VNPCMouthType Type { set; get; }
    public VNPCMouth(string name, VNPCMouthType type)
    {
        this.Name = name;
        this.Type = type;
    }
}
public class VNPCSkin
{
    public string Name { set; get; }
    public VNPCBlushState BlushState { set; get; }
    public VNPCSkin(string name, VNPCBlushState blushState)
    {
        this.Name = name;
        this.BlushState = blushState;
    }
}
public class VNPCBrows
{
    public string Name { set; get; }
    public VNPCBrowsType Type { set; get; }
    public VNPCBrows(string name, VNPCBrowsType type)
    {
        this.Name = name;
        this.Type = type;
    }
}
public class VNPCEyes
{
    public string Name { set; get; }
    public VNPCEyesType Type { set; get; } = VNPCEyesType.OpenCenter;
    public VNPCEyes(string name, VNPCEyesType type)
    {
        this.Name = name;
        this.Type = type;
    }
}
public enum VNPCBlushState
{
    Disabled,
    None,
    Already,
    AlreadyPulsed,
    Go,
    GoPulsed,
    GoNone
}
public enum VNPCMouthState
{
    Disabled,
    None,
    Already,
    AlreadyPulsed,
    Go,
    GoPulsed,
    GoNone
}
public enum VNPCMouthType
{
    Neitral,
    OpenSense,
    Squeeze,
    OpenWorry,
    Doubt
}
public enum VNPCEyesState
{
    Disabled,
    None,
    Already,
    AlreadyPulsed,
    Go,
    GoPulsed,
    GoNone
}
public enum VNPCBlinkState
{
    None,
    Go
}
public enum VNPCEyesType
{
    OpenCenter,
    Close,
    Squeeze,
    Hide
}
public enum VNPCBrowsState
{
    Disabled,
    None,
    Already,
    AlreadyPulsed,
    Go,
    GoPulsed,
    GoNone
}
public enum VNPCBrowsType
{
    Neitral,
    Worry
}
public class VNPCCloth
{
    public string Name { set; get; }
    public VNPCClothType Type { set; get; }
    public VNPCCloth(string name, VNPCClothType type)
    {
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
