using StoGenMake.Elements;
using StoGenMake.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class GenericFem : VNPC
    {
        public GenericFem():base()
        {
            this.Scene = new Scene02();
            this.Name = "Generic Fem";
            this.GID = Guid.Parse("{8639F388-030F-4689-B5EE-020D03F4F46A}");
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
