using StoGen.Classes;
using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static StoGenMake.Pers.VNPC;

namespace StoGenMake.Pers
{
    public class LADY_011017 : VNPC
    {

        public LADY_011017 () : base()
        {
            this.Name = "Maria Delgado";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
            this.PersonType = VNPCPersType.HCG;

            this.Description = "[ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~";
            

            FillDataImage();            
        }
        private void FillDataImage()
        {
            string path = $@"x:\STOGEN\LADY\HCG\LADY_011017\";
            // sound
            //this.Data.Add("SOUND", MUSIC_MAIN_THEME, null, null);
            //this.Data.Add("SOUND", ASMR_01, null, null);
            //this.Data.Add("SOUND", ORGAZM_01, null, null);
            //this.Data.Add("SOUND", ORGAZM_02, null, null);
            //this.Data.Add("SOUND", ORGAZM_03, null, null);
            //this.Data.Add("SOUND", ORGAZM_04, null, null);
            

            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}04a_1.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}01.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}01a_2.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}01a_3.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}02a_3.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}02a_4.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}02a_7.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}03.png"));
            //this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, new seIm($@"{path}03a_1.png"));

            this.VoiceList.Add(new VNPCVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_01, VNPCVoiceType.Neitral, VNPCTermType.None));
            this.VoiceList.Add(new VNPCVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_02, VNPCVoiceType.Neitral, VNPCTermType.None));
            this.VoiceList.Add(new VNPCVoice(SoundStore.Sounds.ASMR_BellaBrookz_Girlfriend_Roleplay_03, VNPCVoiceType.Neitral, VNPCTermType.None));

            this.ClothList.Add(new VNPCCloth(VNPCClothType.Kimono,new seIm($@"{path}04a_24.png")));
            this.ClothList.Add(new VNPCCloth(VNPCClothType.KimonoDecolte, new seIm($@"{path}04a_19.png")));
            this.ClothList.Add(new VNPCCloth(VNPCClothType.Naked, new seIm($@"{path}04a_20.png")));

            var face = new VNPCFace(new seIm($@"{path}04a_23.png", "Face 01"));
            face.Mouth.Items.Add(new VvMouthS(vMouth.Type.Neitral, new seIm($@"{path}04a_26.png")));
            face.Mouth.Items.Add(new VvMouthS(vMouth.Type.OpenSense, new seIm($@"{path}04a_3.png")));
            face.Mouth.Items.Add(new VvMouthS(vMouth.Type.Squeeze, new seIm($@"{path}04a_4.png")));
            face.Mouth.Items.Add(new VvMouthS(vMouth.Type.OpenWorry, new seIm($@"{path}04a_22.png")));
            face.Eyes.Items.Add(new vEyeS(vEye.Type.OpenCenter, new seIm($@"{path}04a_25.png")));
            face.Eyes.Items.Add(new vEyeS(vEye.Type.Close, new seIm($@"{path}04a_17.png")));
            face.Eyes.Items.Add(new vEyeS(vEye.Type.Squeeze, new seIm($@"{path}04a_6.png")));
            face.Eyes.Items.Add(new vEyeS(vEye.Type.Hide, new seIm($@"{path}04a_13.png")));
            face.Brows.Items.Add(new vBrowS(vBrow.Type.Worry, new seIm($@"{path}04a_8.png")));
            face.FaceSkin.Items.Add(new vFcSkinS(vFcSkin.Type.Blush, new seIm($@"{path}04a_2.png")));
            this.Faces.Add(face);

            this.Cloth = this.ClothList.FirstOrDefault(x => x.Type == VNPCClothType.Kimono);
            this.Voice = this.VoiceList.FirstOrDefault(x => x.Type == VNPCVoiceType.Neitral);
            this.Voice.State = VNPCVoiceState.None;

        }    
        
        #region Menu
        public override bool CreateMenuPersone(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem("Оглядеть...", this);
            item.Executor = delegate (object data)
            {
                
                this.Scene.Generate(null);

                StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();

            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Смотреть в лицо ...", this);
            item.Executor = delegate (object data)
            {

                
                this.Scene.Generate(null);

                StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Общение ...", this);
            item.Executor = delegate (object data)
            {
                proc.MenuCreator = this.CreateMenuTalk;
                proc.ShowContextMenu(doShowMenu,data);
            };
            itemlist.Add(item);

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu(true,null);
            }


            return true;
        }
        private bool CreateMenuTalk(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            if (this.FaceEnabled)
            {
                item = new ChoiceMenuItem("Пошутить...", this);
                item.Executor = delegate (object data)
                {
                    CurrentFace.StateEmotional = VNPCEmotionalState.Joy;
                    CurrentFace.GradeEmotional = VNPCEmotionalGrade.Light;

                    
                    this.Scene.Generate(null);

                    StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
                    proc.MenuCreator = proc.OldMenuCreator;
                    proc.GetNextCadre();

                };
                itemlist.Add(item);

                item = new ChoiceMenuItem("Обидеть...", this);
                item.Executor = delegate (object data)
                {
                    CurrentFace.StateEmotional = VNPCEmotionalState.Worry;
                    CurrentFace.GradeEmotional = VNPCEmotionalGrade.Light;

                    this.Scene.Generate(null);

                    StoGenParser.AddCadresToProcFromFile(proc, this.Scene.TempFileName, null, StoGenParser.DefaultPath);
                    proc.MenuCreator = proc.OldMenuCreator;
                    proc.GetNextCadre();

                };
                itemlist.Add(item);
            }

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu(true,null);
            }


            return true;
        } 
        #endregion
    }

   
    //public override void PrepareScene()
    //{
    //    this.SceneFigure.NextCadre("Reset");
    //    /*
    //    FaceReset();
    //    FaceMouthFlirting();
    //    this.SceneFigure.NextCadre("Flirting");

    //    FaceReset();
    //    FaceMouthFlirting();
    //    FaceExitateBlush();
    //    this.SceneFigure.NextCadre("Flirting,exitate");

    //    FaceReset();
    //    FaceMouthInsulted();
    //    this.SceneFigure.NextCadre("Insulted");

    //    FaceReset();
    //    FaceMouthInsulted();
    //    FaceExitateBlush();
    //    this.SceneFigure.NextCadre("Insulted,exitate");

    //    FaceReset();
    //    FaceMouthWorry();
    //    this.SceneFigure.NextCadre("Worried lightly");

    //    FaceReset();
    //    FaceMouthDoubt();
    //    this.SceneFigure.NextCadre("Doubt lightly");

    //    FaceReset();
    //    FaceEyesSqueeze();
    //    this.SceneFigure.NextCadre("Eyes squeeze");

    //    FaceReset();
    //    FaceEyesHide();
    //    this.SceneFigure.NextCadre("Eyes hide");

    //    FaceReset();
    //    FaceBrowsWorry();
    //    this.SceneFigure.NextCadre("Brows worry");
    //    */
    //   // this.SceneFigure.Cadres.Reverse();
    //}
    //public class PERS01Scene : DramaScene
    //{
    //    public PERS01 Fem;

    //    public PERS01Scene(PERS01 fem) : base(fem)
    //    {

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -smile", 200);
    //        //this.Smile(cadre, true, true);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -blushsmile", 200);
    //        //this.Blush(cadre, true, false);
    //        //this.Smile(cadre, true, false);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -talk", 200);
    //        //this.TalkSmile(cadre);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -blushtalk", 200);
    //        //this.Blush(cadre, false, false);
    //        //this.TalkSmile(cadre);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueeze", 200);
    //        //this.MouthSqueeze(cadre, true, true);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlush", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushTalk", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);
    //        //this.TalkFrown(cadre);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueeze", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);
    //        //this.EyesSqueeze(cadre, false, false);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueezeTalk", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);
    //        //this.EyesSqueeze(cadre, false, false);
    //        //this.BrowWorry(cadre, false, false);
    //        //this.TalkFrown(cadre);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesSqueezeLipsO", 200);                
    //        //this.Blush(cadre, true, true);
    //        //this.EyesSqueeze(cadre, false, false);
    //        //this.BrowWorry(cadre, false, false);
    //        //this.BrowWorry(cadre, false, false);
    //        //this.LipsO(cadre, false, false);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesHide", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);
    //        //this.EyesHide(cadre, false, false);
    //        //this.BrowWorry(cadre, false, false);

    //        //cadre = this.AddCadre(KimonoFigure(), "Kimono main -mouthSqueezeBlushEyesClose", 200);
    //        //this.MouthSqueeze(cadre, false, false);
    //        //this.Blush(cadre, true, true);
    //        //this.EyesClose(cadre, false, false);
    //        //this.BrowWorry(cadre, false, false);
    //        //this.Cadres.Reverse();
    //    }



    //    //private void TalkSmile(ScenCadre cadre)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SMILE_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Talk();
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void TalkFrown(ScenCadre cadre)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Talk();
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void MouthNone(ScenCadre cadre)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_NONE);
    //    //    image.Opacity = 100;
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void MouthSqueeze(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SQUEEZE_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.MouthSqueeze(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void MouthOpen(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_02);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.MouthOpen(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void EyesSqueeze(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_SQUEEZE_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Smile(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void BrowWorry(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_BROW_WORRY_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Smile(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void LipsO(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_LIPS_O_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Smile(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void EyesHide(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_HIDE_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Smile(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //    //private void EyesClose(ScenCadre cadre, bool restore, bool permanent)
    //    //{
    //    //    ScenElementImage image = new ScenElementImage();
    //    //    image.SizeX = sizeX;
    //    //    image.SizeY = sizeY;
    //    //    image.Name = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01);
    //    //    image.Opacity = 0;
    //    //    image.Transition = Transition.Smile(500, restore, permanent);
    //    //    cadre.VisionList.Add(image);
    //    //}
    //}
}
