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
    public class PERS01: GenericFem
    {
        public enum FigureImages
        {
            ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO,
            ERECTLIP_LADY_01_MAIN_FIGURE_FACE,
            ERECTLIP_LADY_01_MAIN_FIGURE_FACE_BLUSH,

            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_SQUEEZE_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_HIDE_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01,

            ERECTLIP_LADY_01_MAIN_FIGURE_BROW_WORRY_01,

            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_NONE,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_01,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_OPEN_02,
            ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SMILE_01,            
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
            this.Name = "[ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~.Lady 01";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");

            FillDataImage();

            FemFace face = new FemFace(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_FACE));
            face.StateBlush = FemFace.BlushState.None;
            FemFace.FemSmile smile = new FemFace.FemSmile(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_MOUTH_SMILE_01));
            face.Smile = smile;
            FemFace.FemEyes eyes = new FemFace.FemEyes(GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_EYES_CLOSE_01),FemFace.EyesType.Close);
            face.EyesList.Add(eyes);

            this.Faces.Add(face);

            this.Face = face;

            this.Face.StateBlush = FemFace.BlushState.GoPulsed;
            this.Face.StateSmile = FemFace.SmileState.GoPulsed;
            this.Face.StateBlink = FemFace.BlinkState.Go;
        }

        FigureScene SceneFigure
        {
            get { return this.Scene as FigureScene; }
            set { this.Scene = value; }
        }

        public override void PrepareScene()
        {
            this.SceneFigure = new FigureScene(this);
        }

        public class FigureScene : BaseScene
        {
            public GenericFem Fem;

            public FigureScene(GenericFem fem) : base()
            {
                this.Fem = fem;
                this.Name = "Figure scene";
                this.SizeX = 1500;
                this.SizeY = 1600;
                string cloth = GetImageName(FigureImages.ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO);
                ScenCadre cadre;

                cadre = this.AddCadre(null, "01", 200, this);
                this.Cloth(cadre,cloth);
                this.Head(cadre);

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

            

            public void Cloth(ScenCadre cadre, string cloth)
            {
                this.AddImage(cadre, false, cloth);
            }
            public void Head(ScenCadre cadre)
            {                
                this.AddImage(cadre, false, this.Fem.Face.Name);
                if (this.Fem.Face.StateBlush != FemFace.BlushState.Disabled)
                {
                    this.Blush(cadre, this.Fem.Face.StateBlush, true);
                }
                if (this.Fem.Face.StateSmile != FemFace.SmileState.Disabled)
                {
                    this.Smile(cadre, this.Fem.Face.StateSmile, true);
                }
                if (this.Fem.Face.StateBlink != FemFace.BlinkState.None)
                {
                    this.Blink(cadre, this.Fem.Face.StateBlink);
                }
            }

            internal void Smile(ScenCadre cadre, FemFace.SmileState smile, bool permanent)
            {
                bool invisible =
                   (smile != FemFace.SmileState.Already)
                   &&
                   (smile != FemFace.SmileState.GoNone);
                bool periodic =
                   (smile == FemFace.SmileState.AlreadyPulsed)
                   ||
                   (smile == FemFace.SmileState.GoPulsed);
                bool reverse =
                    (smile == FemFace.SmileState.GoNone);

                var image = this.AddImage(cadre, invisible, this.Fem.Face.Smile.Name);
                if (invisible || reverse)
                    image.Transition = Transition.Smile(200, reverse, periodic, permanent);             
            }
            internal void Blush(ScenCadre cadre, FemFace.BlushState blush, bool permanent)
            {
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
