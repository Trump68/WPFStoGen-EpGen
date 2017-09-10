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
        public static string ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO = "ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO";
        public PERS01():base()
        {           
            this.Name = "[ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~.Lady 01";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
            this.Data.Add("IMAGE", ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO, null, null);
        }
        FigureScene SceneFigure
        {
            get { return this.Scene as FigureScene; }
            set { this.Scene = value; }
        }

        public override void PrepareScene()
        {
            this.SceneFigure = new FigureScene();
        }

        public class FigureScene : BaseScene
        {
            public FigureScene() : base()
            {
                this.Name = "Figure scene";
                this.Cadre01_Kimono();
            }
           
            public ScenCadre Cadre01_Kimono()
            {
                ScenCadre cadre = new ScenCadre(this);
                cadre.Name = "Cadre 01";
                cadre.Timer = 300 * 1000;
                AddMainImage(cadre);
                //AddImageBlink(cadre);
                //AddMusic(cadre);
                //AddText(cadre);
                this.Cadres.Add(cadre);
                return cadre;
            }
          
            private void AddMainImage(ScenCadre cadre)
            {
                ScenElementImage image = new ScenElementImage();
                image.SizeX = 1600;
                image.SizeY = 1500;
                image.Name = PERS01.ERECTLIP_LADY_01_MAIN_FIGURE_KIMONO;
                image.Opacity = 100;
                cadre.VisionList.Add(image);
            }

         
        }
    }
}
