using StoGenMake.Elements;
using StoGenMake.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class PERS01:VNPC
    {
        public PERS01():base()
        {
            this.Scene = new Scene02();
            this.Name = "[Oda Non] Non Virgin.Lady 1";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
        }

        public override void PrepareScene()
        {
            ScenCadre cadre = new ScenCadre(this.Scene);
            cadre.Name = "Cadre 01";
            cadre.Timer = 5 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SizeX = 1600;
            image.SizeY = 1500;
            image.Name = Scene02.MainFace_01;
            image.Opacity = 100;
            image.IsOptional = false;
            cadre.VisionList.Add(image);


            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene02.MainMusic;
            sound.V = 0;
            sound.Transition = "v.B.5000.10";
            cadre.SoundList.Add(sound);

            ScenElementText text = new ScenElementText();
            text.Text = "fff";
            cadre.TextList.Add(text);

            this.Scene.Cadres.Add(cadre);
        }
    }
}
