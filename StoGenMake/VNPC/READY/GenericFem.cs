using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenMake.Pers.GenericFem;

namespace StoGenMake.Pers
{
    public class GenericFem : VNPC
    {
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
        public override void PrepareScene()
        {
            this.Scene = new MainPersonScene();
        }
        public class MainPersonScene : BaseScene
        {
            public MainPersonScene() : base()
            {
                this.Name = "Main person scene";
            }
            internal void Wink()
            {
                this.AddCadre_Wink();
            }
            public ScenCadre AddMainCadre(bool blink)
            {
                ScenCadre cadre = new ScenCadre(this);
                cadre.Name = "Cadre 01";
                cadre.Timer = 300 * 1000;
                AddMainImage(cadre);
                if (blink)
                    AddImageBlink(cadre);

                AddMusic(cadre);
                AddText(cadre);
                this.Cadres.Add(cadre);
                return cadre;
            }
            private void AddCadre_Wink()
            {
                ScenCadre cadre = new ScenCadre(this);
                cadre.Name = "Cadre Wink";
                cadre.Timer = 5 * 1000;
                AddMainImage(cadre);
                AddImageWink(cadre);
                AddMusic(cadre);
                AddText(cadre);
                this.Cadres.Add(cadre);
            }
            private void AddMainImage(ScenCadre cadre)
            {
                ScenElementImage image = GetMainImage();
                cadre.VisionList.Add(image);
            }
            private ScenElementImage GetMainImage()
            {
                ScenElementImage image = new ScenElementImage();
                image.SizeX = 1600;
                image.SizeY = 1500;
                image.Name = VNPC.MAIN_PERSON_PICTURE;
                image.Opacity = 100;
                return image;
            }
            private void AddImageWink(ScenCadre cadre)
            {
                ScenElementImage image = GetMainImage();
                image.Part = VNPC.RIGHT_EYE_WINK;
                image.Opacity = 0;
                image.Transition = Transition.Eye_Wink;
                cadre.VisionList.Add(image);
            }
            private void AddImageBlink(ScenCadre cadre)
            {
                ScenElementImage image = GetMainImage();
                image.Part = VNPC.EYES_CLOSE_01;
                image.Opacity = 0;
                image.Transition = Transition.Eyes_Blink;
                cadre.VisionList.Add(image);
            }
            private void AddEyesClose(ScenCadre cadre)
            {
                ScenElementImage image = GetMainImage();
                image.Part = VNPC.EYES_CLOSE_01;
                image.Opacity = 0;
                image.Transition = Transition.Eye_Close;
                cadre.VisionList.Add(image);
            }
            private void AddMusic(ScenCadre cadre)
            {
                ScenElementSound sound;
                sound = new ScenElementSound();
                sound.Name = VNPC.MUSIC_MAIN_THEME;
                sound.V = 0;
                sound.Transition = "v.B.5000.10";
                cadre.SoundList.Add(sound);
            }
            private void AddVoice(ScenCadre cadre, string voice)
            {
                ScenElementSound sound;
                sound = new ScenElementSound();
                sound.Name = voice;
                sound.V = 0;
                sound.Transition = "v.B.5000.100";
                cadre.SoundList.Add(sound);
            }
            private void AddText(ScenCadre cadre)
            {
                ScenElementText text = new ScenElementText();
                text.Text = "fff";
                cadre.TextList.Add(text);
            }

            internal void ASMR_01(bool blink)
            {
                ScenCadre cadre = AddMainCadre(blink);
                cadre.Name = "ASMR_01";
                AddVoice(cadre, VNPC.ASMR_01);
            }

            internal void ORGAZM_01()
            {
                ScenCadre cadre = AddMainCadre(false);
                cadre.Name = "ORGAZM_01";
                AddEyesClose(cadre);
                AddVoice(cadre, VNPC.ORGAZM_01);
            }

        }
    }
    public class FemScene : BaseScene
    {
        public GenericFem Fem;
        public void NextCadre(string name)
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, name, 200, this);
            this.Cloth(cadre);
            this.Head(cadre);

            this.AddObzor(cadre);
        }
        public FemScene(GenericFem fem) : base()
        {
            this.Fem = fem;
            this.Name = "Figure scene";
            this.SizeX = 1500;
            this.SizeY = 1600;           
        }

        protected virtual void Cloth(ScenCadre cadre)
        {
            this.AddImage(cadre, false, this.Fem.Cloth.Name);
        }
        protected virtual void Head(ScenCadre cadre)
        {
            this.AddImage(cadre, false, this.Fem.Face.Name);
            if (this.Fem.Face.StateBlush != FemFace.BlushState.Disabled)
            {
                this.Blush(cadre, this.Fem.Face.StateBlush, true);
            }
            if (this.Fem.Face.StateMouth != FemFace.MouthState.Disabled)
            {
                this.Mouth(cadre, this.Fem.Face.StateMouth, true);
            }
            if (this.Fem.Face.StateEyes != FemFace.EyesState.Disabled)
            {
                this.SetEyes(cadre, this.Fem.Face.StateEyes, true);
            }
            if (this.Fem.Face.StateBlink != FemFace.BlinkState.None)
            {
                this.Blink(cadre, this.Fem.Face.StateBlink);
            }
            this.Brows(cadre, this.Fem.Face.StateBrows);
            this.Voice(cadre, this.Fem.StateVoice);

        }

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
                this.AddImage(cadre, false, this.Fem.Face.EyesDefault.Name);
            }
            var image = this.AddImage(cadre, invisible, this.Fem.Face.Eyes.Name);
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
                this.AddImage(cadre, false, this.Fem.Face.MouthDefault.Name);
            }
            var image = this.AddImage(cadre, invisible, this.Fem.Face.Mouth.Name);
            if (invisible || reverse)
                image.Transition = Transition.Mouth(200, reverse, periodic, permanent);
        }
        protected virtual void Blush(ScenCadre cadre, FemFace.BlushState blush, bool permanent)
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
        protected virtual void Voice(ScenCadre cadre, GenericFem.VoiceState voice)
        {
            if (voice == VoiceState.None) return;
            var sound = this.AddSound(cadre, Fem.Voice.Name);
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

            var image = this.AddImage(cadre, invisible, this.Fem.Face.Brows.Name);
            if (invisible || reverse)
                image.Transition = Transition.Blush(500, reverse, false, false);
        }
        protected virtual void Blink(ScenCadre cadre, FemFace.BlinkState blink)
        {
            bool invisible = true;
            var image = this.AddImage(cadre, invisible, this.Fem.Face.EyesList.Where(x => x.Type == FemFace.EyesType.Close).FirstOrDefault().Name);
            image.Transition = Transition.Eyes_Blink;
        }        
    }
}
