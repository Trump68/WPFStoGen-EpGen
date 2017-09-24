using StoGen.Classes;
using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGenMake.Pers
{
    public class PERS01: GenericFem
    {
        //FigureScene.ViewingTransitionState StateViewingTransition = BaseScene.ViewingTransitionState.None;
        public enum FigureImages
        {
            ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO,
            ERECTLIP_LADY_01_MAIN_FIGURE_KIMONODECOLTE,
            ERECTLIP_LADY_01_MAIN_FIGURE_NAKED,

            ERECTLIP_LADY_01_MAIN_FIGURE_FACE,
            ERECTLIP_LADY_01_MAIN_FIGURE_FACE_BLUSH,

            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_OPENCENTER_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_SQUEEZE_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_HIDE_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01,

            ERECTLIP_LADY_01_MAIN_FIGURE_BROW_WORRY_01,

            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_CLOSENEITRAL,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_02,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPENSENSE_01,            
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SQUEEZE_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_LIPS_O_01
        }
        private static string GetImageName(FigureImages val)
        {
            return Enum.GetName(typeof(FigureImages), val);
        }

        private void FillDataImage()
        {
            var list = Enum.GetNames(typeof(FigureImages)).ToList();
            list.ForEach(x => this.Data.Add("IMAGE", x, null, null));
        }
        public PERS01():base()
        {           
            //this.Name = "[ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~.Lady 01";
            this.Name = "Maria Delgado";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
            this.TempFileName = $@"d:\temp\{this.Name}.stogen";
            FillDataImage(); 
        }

        FigureScene SceneFigure
        {
            get { return this.Scene as FigureScene; }
            set { this.Scene = value; }
        }
        
        private void GenerateScene()
        {                    
            string fn = this.Generate(this.TempFileName);
        }
        private void SetObzor()
        {
            this.SceneFigure.StateViewingTransition = BaseScene.ViewingTransitionState.Go;
        }

        public void PlanScene()
        {
            this.SceneFigure = new FigureScene(this);
           // this.SceneFigure.StateViewingTransition = this.StateViewingTransition;
            SetFace();
            SetCloth();
            SetVoice();

            this.Cloth = this.ClothList.FirstOrDefault(x => x.Type == ClothType.Kimono);
            this.Voice = this.VoiceList.FirstOrDefault(x => x.Type == VoiceType.Neitral);
            this.StateVoice = VoiceState.Go;

            FaceReset();
        }

        public override void PrepareScene()
        {
            PlanScene();
            this.SceneFigure.NextCadre("Reset");
            /*
            FaceReset();
            FaceMouthFlirting();
            this.SceneFigure.NextCadre("Flirting");

            FaceReset();
            FaceMouthFlirting();
            FaceExitateBlush();
            this.SceneFigure.NextCadre("Flirting,exitate");

            FaceReset();
            FaceMouthInsulted();
            this.SceneFigure.NextCadre("Insulted");

            FaceReset();
            FaceMouthInsulted();
            FaceExitateBlush();
            this.SceneFigure.NextCadre("Insulted,exitate");

            FaceReset();
            FaceMouthWorry();
            this.SceneFigure.NextCadre("Worried lightly");

            FaceReset();
            FaceMouthDoubt();
            this.SceneFigure.NextCadre("Doubt lightly");

            FaceReset();
            FaceEyesSqueeze();
            this.SceneFigure.NextCadre("Eyes squeeze");

            FaceReset();
            FaceEyesHide();
            this.SceneFigure.NextCadre("Eyes hide");

            FaceReset();
            FaceBrowsWorry();
            this.SceneFigure.NextCadre("Brows worry");
            */
           // this.SceneFigure.Cadres.Reverse();
        }

        private void SetVoice()
        {
            this.VoiceList.Add(new FemVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_01, VoiceType.Neitral,TermType.None));
            this.VoiceList.Add(new FemVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_02, VoiceType.Neitral, TermType.None));
            this.VoiceList.Add(new FemVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_03, VoiceType.Neitral, TermType.None));
        }

        private void SetCloth()
        {
            this.ClothList.Add(new FemCloth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO),ClothType.Kimono));
            this.ClothList.Add(new FemCloth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_KIMONODECOLTE), ClothType.KimonoDecolte));
            this.ClothList.Add(new FemCloth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_NAKED), ClothType.Naked));
        }
        private void SetFace()
        {
            FemFace face = new FemFace(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_FACE));
            this.Face = face;

            face.MouthList.Add(new FemFace.FemMouth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_CLOSENEITRAL), FemFace.MouthType.Neitral));
            face.MouthList.Add(new FemFace.FemMouth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPENSENSE_01), FemFace.MouthType.OpenSense));
            face.MouthList.Add(new FemFace.FemMouth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SQUEEZE_01), FemFace.MouthType.Squeeze));
            face.MouthList.Add(new FemFace.FemMouth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_01), FemFace.MouthType.OpenWorry));
            face.MouthList.Add(new FemFace.FemMouth(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_02), FemFace.MouthType.Doubt));

            face.EyesList.Add(new FemFace.FemEyes(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_OPENCENTER_01), FemFace.EyesType.OpenCenter));
            face.EyesList.Add(new FemFace.FemEyes(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01), FemFace.EyesType.Close));
            face.EyesList.Add(new FemFace.FemEyes(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_SQUEEZE_01), FemFace.EyesType.Squeeze));
            face.EyesList.Add(new FemFace.FemEyes(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_HIDE_01), FemFace.EyesType.Hide));

            face.BrowsList.Add(new FemFace.FemBrows(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_BROW_WORRY_01), FemFace.BrowsType.Worry));
        }

        private void FaceReset()
        {
            this.Face.EyesDefault = this.Face.EyesList.Where(x => x.Type == FemFace.EyesType.OpenCenter).FirstOrDefault();
            this.Face.MouthDefault = this.Face.MouthList.Where(x => x.Type == FemFace.MouthType.Neitral).FirstOrDefault();
            this.Face.Eyes = this.Face.EyesDefault;
            this.Face.Mouth = this.Face.MouthDefault;

            this.Face.StateEyes = FemFace.EyesState.Already;
            this.Face.StateMouth = FemFace.MouthState.Already;
            this.Face.StateBlink = FemFace.BlinkState.Go;
            this.Face.StateBlush = FemFace.BlushState.None;
            this.Face.StateBrows = FemFace.BrowsState.None;

            if (StateEmotional == EmotionalState.Joy)
            {
                FaceMouthFlirting();
            }
            else if (StateEmotional == EmotionalState.Worry)
            {
                FaceBrowsWorry();
                FaceMouthWorry();
            }
        }
        private void FaceMouthFlirting()
        {
            this.Face.Mouth = this.Face.MouthList.Where(x => x.Type == FemFace.MouthType.OpenSense).FirstOrDefault();
            this.Face.StateMouth = FemFace.MouthState.GoPulsed;        
        }
        private void FaceMouthWorry()
        {
            this.Face.Mouth = this.Face.MouthList.Where(x => x.Type == FemFace.MouthType.OpenWorry).FirstOrDefault();
            this.Face.StateMouth = FemFace.MouthState.GoPulsed;
        }
        private void FaceMouthDoubt()
        {
            this.Face.Mouth = this.Face.MouthList.Where(x => x.Type == FemFace.MouthType.Doubt).FirstOrDefault();
            this.Face.StateMouth = FemFace.MouthState.GoPulsed;
        }
        private void FaceExitateBlush()
        {
            this.Face.StateBlush = FemFace.BlushState.GoPulsed;
        }
        private void FaceMouthInsulted()
        {
            this.Face.Mouth = this.Face.MouthList.Where(x => x.Type == FemFace.MouthType.Squeeze).FirstOrDefault();
            this.Face.StateMouth = FemFace.MouthState.GoPulsed;
        }
        private void FaceEyesSqueeze()
        {
            this.Face.Eyes = this.Face.EyesList.Where(x => x.Type == FemFace.EyesType.Squeeze).FirstOrDefault();
            this.Face.StateEyes = FemFace.EyesState.GoPulsed;
        }
        private void FaceEyesHide()
        {
            this.Face.Eyes = this.Face.EyesList.Where(x => x.Type == FemFace.EyesType.Hide).FirstOrDefault();
            this.Face.StateEyes = FemFace.EyesState.GoPulsed;
        }
        private void FaceBrowsWorry()
        {
            this.Face.Brows = this.Face.BrowsList.Where(x => x.Type == FemFace.BrowsType.Worry).FirstOrDefault();
            this.Face.StateBrows = FemFace.BrowsState.Go;
        }

    
        public override bool CreateMenuPersone(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem("Оглядеть...", this);
            item.Executor = delegate (object data)
            {
                              
                PlanScene();
                SetObzor();
                this.SceneFigure.NextCadre("Cadre"+proc.Cadres.Count);
                GenerateScene();

                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);                
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
                
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Смотреть в лицо ...",this);
            item.Executor = delegate (object data)
            {
                
                PlanScene();
                this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                GenerateScene();

                
                StoGenParser.AddCadresToProcFromFile(proc,this.TempFileName,null, StoGenParser.DefaultPath);                                
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Общение ...", this);
            item.Executor = delegate (object data)
            {
                proc.MenuCreator = this.CreateMenuTalk;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu();
            }
            

            return true;
        }
        private bool CreateMenuTalk(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem("Пошутить...", this);
            item.Executor = delegate (object data)
            {
                SetJoy(EmotionalGrade.Light);
                PlanScene();
                
                
                this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                GenerateScene();

                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();

            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Обидеть...", this);
            item.Executor = delegate (object data)
            {
                SetWorry(EmotionalGrade.Light);
                PlanScene();
               

                this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                GenerateScene();

                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();

            };
            itemlist.Add(item);


            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu();
            }


            return true;
        }

        private void SetJoy(EmotionalGrade v)
        {
            this.StateEmotional = EmotionalState.Joy;
            this.GradeEmotional = v;
        }
        private void SetWorry(EmotionalGrade v)
        {
            this.StateEmotional = EmotionalState.Worry;
            this.GradeEmotional = v;
        }

        public class FigureScene : BaseScene
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
            public FigureScene(GenericFem fem) : base()
            {
                this.Fem = fem;
                this.Name = "Figure scene";
                this.SizeX = 1500;
                this.SizeY = 1600;
                

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -smile", 200);
                //this.Smile(cadre, true, true);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -blushsmile", 200);
                //this.Blush(cadre, true, false);
                //this.Smile(cadre, true, false);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -talk", 200);
                //this.TalkSmile(cadre);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -blushtalk", 200);
                //this.Blush(cadre, false, false);
                //this.TalkSmile(cadre);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueeze", 200);
                //this.MouthSqueeze(cadre, true, true);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlush", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushTalk", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);
                //this.TalkFrown(cadre);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueeze", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);
                //this.EyesSqueeze(cadre, false, false);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueezeTalk", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);
                //this.EyesSqueeze(cadre, false, false);
                //this.BrowWorry(cadre, false, false);
                //this.TalkFrown(cadre);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueezeLipsO", 200);                
                //this.Blush(cadre, true, true);
                //this.EyesSqueeze(cadre, false, false);
                //this.BrowWorry(cadre, false, false);
                //this.BrowWorry(cadre, false, false);
                //this.LipsO(cadre, false, false);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesHide", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);
                //this.EyesHide(cadre, false, false);
                //this.BrowWorry(cadre, false, false);

                //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesClose", 200);
                //this.MouthSqueeze(cadre, false, false);
                //this.Blush(cadre, true, true);
                //this.EyesClose(cadre, false, false);
                //this.BrowWorry(cadre, false, false);
                //this.Cadres.Reverse();
            }

            

            public void Cloth(ScenCadre cadre)
            {
                this.AddImage(cadre, false, this.Fem.Cloth.Name);
            }
            public void Head(ScenCadre cadre)
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

            private void AddObzor(ScenCadre cadre)
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

            private void SetEyes(ScenCadre cadre, FemFace.EyesState eyes, bool permanent)
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

            internal void Mouth(ScenCadre cadre, FemFace.MouthState smile, bool permanent)
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
            internal void Blush(ScenCadre cadre, FemFace.BlushState blush, bool permanent)
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

                var image = this.AddImage(cadre, invisible, GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_FACE_BLUSH));
                if (invisible || reverse)
                   image.Transition = Transition.Blush(500, reverse, periodic, permanent);
            }
            internal void Voice(ScenCadre cadre, GenericFem.VoiceState voice)
            {
                if (voice == VoiceState.None) return;
                var sound = this.AddSound(cadre, Fem.Voice.Name);
                // var sound = this.AddSound(cadre,SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_01);
                //sound.Transition = Transition.Blush(500, reverse, periodic, permanent);
            }
            private void Brows(ScenCadre cadre, FemFace.BrowsState brows)
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
            internal void Blink(ScenCadre cadre, FemFace.BlinkState blink)
            {
                bool invisible = true;
                var image = this.AddImage(cadre, invisible, this.Fem.Face.EyesList.Where(x=>x.Type == FemFace.EyesType.Close).FirstOrDefault().Name);
                image.Transition = Transition.Eyes_Blink;               
            }
            //private void TalkSmile(ScenCadre cadre)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SMILE_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Talk();
            //    cadre.VisionList.Add(image);
            //}
            //private void TalkFrown(ScenCadre cadre)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Talk();
            //    cadre.VisionList.Add(image);
            //}
            //private void MouthNone(ScenCadre cadre)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_NONE);
            //    image.Opacity = 100;
            //    cadre.VisionList.Add(image);
            //}
            //private void MouthSqueeze(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SQUEEZE_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.MouthSqueeze(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void MouthOpen(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_02);
            //    image.Opacity = 0;
            //    image.Transition = Transition.MouthOpen(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void EyesSqueeze(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_SQUEEZE_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Smile(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void BrowWorry(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_BROW_WORRY_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Smile(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void LipsO(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_LIPS_O_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Smile(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void EyesHide(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_HIDE_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Smile(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
            //private void EyesClose(ScenCadre cadre, bool restore, bool permanent)
            //{
            //    ScenElementImage image = new ScenElementImage();
            //    image.SizeX = sizeX;
            //    image.SizeY = sizeY;
            //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01);
            //    image.Opacity = 0;
            //    image.Transition = Transition.Smile(500, restore, permanent);
            //    cadre.VisionList.Add(image);
            //}
        }
    }
}
