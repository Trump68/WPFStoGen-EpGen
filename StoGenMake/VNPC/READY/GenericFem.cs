using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class GenericFem : VNPC
    {
        public class FemFace
        {
            public class FemSmile
            {
                public string Name { set; get; }
                public FemSmile(string name)
                {
                    this.Name = name;
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
            public enum SmileState
            {
                Disabled,
                None,
                Already,
                AlreadyPulsed,
                Go,
                GoPulsed,
                GoNone
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
                Close
            }
            public FemFace(string name)
            {
                this.Name = name;
            }
            public string Name { set; get; }
            public BlushState StateBlush { get; set; } = BlushState.Disabled;
            public SmileState StateSmile { get; set; } = SmileState.Disabled;
            public EyesState  StateEyes  { get; set; } = EyesState.Disabled;
            public BlinkState StateBlink { get; set; } = BlinkState.None;

            public List<FemSmile> SmileList { get; set; } = new List<FemSmile>();
            public List<FemEyes>  EyesList  { get; set; } = new List<FemEyes>();
            private FemSmile _Smile;
            public FemSmile Smile
            {
                get
                {
                    if (_Smile == null)
                        _Smile = this.SmileList.FirstOrDefault();
                    return _Smile;
                }
                set
                {
                    _Smile = value;
                    if (!this.SmileList.Contains(_Smile))
                        this.SmileList.Add(_Smile);
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
        }

        public List<FemFace> Faces { set; get; } = new List<FemFace>();
        public FemFace Face { set; get; }
        public GenericFem():base()
        {
            this.Name = "Generic Fem";
            this.GID = Guid.Parse("{8639F388-030F-4689-B5EE-020D03F4F46A}");
        }
        public override void PrepareScene()
        {
            this.Scene = new MainPersonScene();
        }
    }
    public class MainPersonScene: BaseScene
    {
        public MainPersonScene():base()
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
