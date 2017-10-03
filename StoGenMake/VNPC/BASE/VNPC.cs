using StoGen.Classes;
using StoGenLife.NPC;
using StoGenLife.SOUND;
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
        public enum PersType
        {
            Real,
            HCG,
            JAV
        }
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
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, null, null);
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, RIGHT_EYE_WINK, null);
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, EYES_CLOSE_01, null);
            // sound
            this.Data.Add("SOUND", MUSIC_MAIN_THEME, null, null);
            this.Data.Add("SOUND", ASMR_01, null, null);
            this.Data.Add("SOUND", ORGAZM_01, null, null);
            this.Data.Add("SOUND", ORGAZM_02, null, null);
            this.Data.Add("SOUND", ORGAZM_03, null, null);
            this.Data.Add("SOUND", ORGAZM_04, null, null);
        }
        public PersType PersonType = PersType.Real;
        public BaseScene Scene { set; get; }
        public EntityData Data = new EntityData();
        public void SetPersVariablesData(List<string> datalist)
        {
            List<string> result = new List<string>();
            if (datalist != null)
            {
                foreach (var item in datalist)
                {
                    string[] vals = item.Split(';');
                    if (vals.Length == 3)
                    {
                        Data.SetByName(vals[0].Trim(),vals[1].Trim(), null, vals[2].Trim());
                    }
                    else if(vals.Length == 4)
                    {
                        Data.SetByName(vals[0].Trim(), vals[1].Trim(), vals[2].Trim(), vals[3].Trim());
                    }
                }
            }
        }
      
   
        public virtual void Prepare() { }

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
                this.Scene.Generate();

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
            if (this.Scene == null) this.Scene = new BaseScene(new List<VNPC> { this });
            this.Scene.Cadres.Clear();
            var items = this.Data.ByName("IMAGE", DOCIER_PICTURE, null);            
            foreach (var it in items)
            {
                ScenCadre cadre;
                cadre = this.Scene.AddCadre(null, null, 200, this.Scene);

                ScenElementImage image;
                image = new ScenElementImage();                
                image.Name = $"DOCIER_PICTURE {cadre.VisionList.Count}";
                image.File = it.Value;
                cadre.VisionList.Add(image);
            }
        }


        public enum EmotionalState
        {
            None,
            Joy,
            Flirt,
            Worry
        }
        public enum EmotionalGrade
        {
            None,
            Light,
            Middle,
            Heavy
        }
        public EmotionalState StateEmotional { get; set; } = EmotionalState.None;
        public EmotionalGrade GradeEmotional { get; set; } = EmotionalGrade.None;
        public class FemFace
        {

            public class FemMouth
            {
                public string Name { set; get; }
                public MouthType Type { set; get; }
                public FemMouth(string name, MouthType type)
                {
                    this.Name = name;
                    this.Type = type;
                }
            }
            public class FemBrows
            {
                public string Name { set; get; }
                public BrowsType Type { set; get; }
                public FemBrows(string name, BrowsType type)
                {
                    this.Name = name;
                    this.Type = type;
                }
            }
            public class FemEyes
            {
                public string Name { set; get; }
                public EyesType Type { set; get; } = EyesType.OpenCenter;
                public FemEyes(string name, EyesType type)
                {
                    this.Name = name;
                    this.Type = type;
                }
            }
            public enum BlushState
            {
                Disabled,
                None,
                Already,
                AlreadyPulsed,
                Go,
                GoPulsed,
                GoNone
            }
            public enum MouthState
            {
                Disabled,
                None,
                Already,
                AlreadyPulsed,
                Go,
                GoPulsed,
                GoNone
            }
            public enum MouthType
            {
                Neitral,
                OpenSense,
                Squeeze,
                OpenWorry,
                Doubt
            }
            public enum EyesState
            {
                Disabled,
                None,
                Already,
                AlreadyPulsed,
                Go,
                GoPulsed,
                GoNone
            }
            public enum BlinkState
            {
                None,
                Go
            }
            public enum EyesType
            {
                OpenCenter,
                Close,
                Squeeze,
                Hide
            }
            public enum BrowsState
            {
                Disabled,
                None,
                Already,
                AlreadyPulsed,
                Go,
                GoPulsed,
                GoNone
            }
            public enum BrowsType
            {
                Neitral,
                Worry
            }
            public FemFace(string name)
            {
                this.Name = name;
            }
            public string Name { set; get; }
            public BlushState StateBlush { get; set; } = BlushState.Disabled;
            public MouthState StateMouth { get; set; } = MouthState.Disabled;
            public EyesState StateEyes { get; set; } = EyesState.Disabled;
            public BlinkState StateBlink { get; set; } = BlinkState.None;
            public BrowsState StateBrows { get; set; } = BrowsState.None;




            public List<FemBrows> BrowsList { get; set; } = new List<FemBrows>();
            public List<FemMouth> MouthList { get; set; } = new List<FemMouth>();
            public List<FemEyes> EyesList { get; set; } = new List<FemEyes>();

            private FemMouth _Mouth;
            public FemMouth Mouth
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
            private FemMouth _MouthDefault;
            public FemMouth MouthDefault
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

            private FemEyes _Eyes;
            public FemEyes Eyes
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
            private FemEyes _EyesDefault;
            public FemEyes EyesDefault
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

            private FemBrows _Brows;
            public FemBrows Brows
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

        }
        public class FemCloth
        {
            public string Name { set; get; }
            public ClothType Type { set; get; }
            public FemCloth(string name, ClothType type)
            {
                this.Name = name;
                this.Type = type;
            }
        }
        public class FemVoice
        {
            public string Name { set; get; }
            public VoiceType Type { set; get; }
            public TermType TermType { set; get; }
            public FemVoice(string name, VoiceType type, TermType TermType)
            {
                this.Name = name;
                this.Type = type;
            }
            public FemVoice(SoundStore.Sounds name, VoiceType type, TermType TermType)
            {
                this.Name = Enum.GetName(typeof(SoundStore.Sounds), name);
                this.Type = type;
            }

        }
        public enum VoiceType
        {
            Neitral
        }
        public enum TermType
        {
            None,
            Yes,
            No
        }
        public enum ClothType
        {
            Naked,
            Kimono,
            KimonoDecolte
        }
        public enum VoiceState
        {
            None,
            Go,
            GoPeriodic
        }
        public List<FemCloth> ClothList { set; get; } = new List<FemCloth>();
        public List<FemFace> Faces { set; get; } = new List<FemFace>();
        public List<FemVoice> VoiceList { set; get; } = new List<FemVoice>();
        public FemFace Face { set; get; }
        FemCloth _Cloth;
        public FemCloth Cloth
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
        FemVoice _Voice;
        public FemVoice Voice
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
        public VoiceState StateVoice { set; get; } = VoiceState.None;
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
       


        public virtual void SetCloth(ScenCadre cadre)
        {
            // this.Fem.Cloth.Name
            this.Scene.AddImage(cadre, false, Cloth.Name);
        }
        public virtual void SetHead(ScenCadre cadre)
        {

            this.Scene.AddImage(cadre, false, Face.Name);
            if (Face.StateBlush != FemFace.BlushState.Disabled)
            {
                this.Blush(cadre, Face.StateBlush, true);
            }
            if (Face.StateMouth != FemFace.MouthState.Disabled)
            {
                this.Mouth(cadre, Face.StateMouth, true);
            }
            if (Face.StateEyes != FemFace.EyesState.Disabled)
            {
                this.SetEyes(cadre, Face.StateEyes, true);
            }
            if (Face.StateBlink != FemFace.BlinkState.None)
            {
                this.Blink(cadre, Face.StateBlink);
            }
            this.Brows(cadre, Face.StateBrows);
            this.GetVoice(cadre, StateVoice);
        }
        protected virtual void SetEyes(ScenCadre cadre, FemFace.EyesState eyes, bool permanent)
        {
            bool invisible =
               (eyes != FemFace.EyesState.Already)
               &&
               (eyes != FemFace.EyesState.GoNone);
            bool periodic =
               (eyes == FemFace.EyesState.AlreadyPulsed)
               ||
               (eyes == FemFace.EyesState.GoPulsed);
            bool reverse =
                (eyes == FemFace.EyesState.GoNone);

            if (periodic)
            {
                this.Scene.AddImage(cadre, false, Face.EyesDefault.Name);
            }
            var image = this.Scene.AddImage(cadre, invisible, Face.Eyes.Name);
            if (invisible || reverse)
                image.Transition = Transition.Eyes(200, reverse, periodic, permanent);
        }
        protected virtual void Mouth(ScenCadre cadre, FemFace.MouthState smile, bool permanent)
        {
            bool invisible =
               (smile != FemFace.MouthState.Already)
               &&
               (smile != FemFace.MouthState.GoNone);
            bool periodic =
               (smile == FemFace.MouthState.AlreadyPulsed)
               ||
               (smile == FemFace.MouthState.GoPulsed);
            bool reverse =
                (smile == FemFace.MouthState.GoNone);

            if (periodic)
            {
                this.Scene.AddImage(cadre, false, Face.MouthDefault.Name);
            }
            var image = this.Scene.AddImage(cadre, invisible, Face.Mouth.Name);
            if (invisible || reverse)
                image.Transition = Transition.Mouth(200, reverse, periodic, permanent);
        }
        public virtual void Blush(ScenCadre cadre, FemFace.BlushState blush, bool permanent)
        {
            if (blush == FemFace.BlushState.None) return;
            bool invisible =
                (blush != FemFace.BlushState.Already)
                &&
                (blush != FemFace.BlushState.GoNone);
            bool periodic =
                (blush == FemFace.BlushState.AlreadyPulsed)
                ||
                (blush == FemFace.BlushState.GoPulsed);
            bool reverse =
                (blush == FemFace.BlushState.GoNone);
        }
        protected virtual void GetVoice(ScenCadre cadre, VNPC.VoiceState voice)
        {
            if (voice == VoiceState.None) return;
            var sound = this.Scene.AddSound(cadre, Voice.Name);
            // var sound = this.AddSound(cadre,SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_01);
            //sound.Transition = Transition.Blush(500, reverse, periodic, permanent);
        }
        protected virtual void Brows(ScenCadre cadre, FemFace.BrowsState brows)
        {
            if (brows == FemFace.BrowsState.None) return;
            bool invisible =
                (brows != FemFace.BrowsState.Already)
                &&
                (brows != FemFace.BrowsState.GoNone);
            bool reverse =
                (brows == FemFace.BrowsState.GoNone);

            var image = this.Scene.AddImage(cadre, invisible, Face.Brows.Name);
            if (invisible || reverse)
                image.Transition = Transition.Blush(500, reverse, false, false);
        }
        protected virtual void Blink(ScenCadre cadre, FemFace.BlinkState blink)
        {
            bool invisible = true;
            var image = this.Scene.AddImage(cadre, invisible, Face.EyesList.Where(x => x.Type == FemFace.EyesType.Close).FirstOrDefault().Name);
            image.Transition = Transition.Eyes_Blink;
        }
    }

}

