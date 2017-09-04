using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class Scene02 : BaseScene
    {
        public static string MainMusic = "Main theme music";
        public Scene02() : base()
        {
            this.Name = "Pers presenter";
            this.Variables.Add(new SceneVariable("SOUND", Scene01.MainMusic, string.Empty, Scene02.MainMusic));            
        }
    }
    

    public class ScenCadre_PersonaPresent : ScenCadre
    {
        public ScenCadre_PersonaPresent(BaseScene owner) : base(owner)
        {
            this.Name = "Pers present";
            this.Timer = 5 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = "Black";
            image.Opacity = 100;
            image.IsOptional = false;
            image.File = "#SYS_BLACK#";
            this.VisionList.Add(image);


            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene02.MainMusic;
            sound.V = 0;
            sound.Transition = "v.B.5000.10";
            this.SoundList.Add(sound);

            ScenElementText text = new ScenElementText();
            text.Text = this.Owner.NPCList.First().Description;
            this.TextList.Add(text);
        }
    }
}
