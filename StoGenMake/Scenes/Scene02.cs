using StoGenLife.NPC;
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
        public static string MainFace_01 = "Main face";
        public Scene02() : base()
        {
            this.Name = "[Oda Non] Non Virgin.Lady 1";
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01, string.Empty, Scene01.MainFace_01));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.MainMusic, string.Empty, Scene02.MainMusic));

           
        }
        public override void InitCadres()
        {
            this.NPCList.Add(new DefaultNPC());

            this.Cadres.Add(new ScenCadre_Cadre01(this));
            base.InitCadres();
        }
    }
    

    public class ScenCadre_Cadre01 : ScenCadre
    {
        public ScenCadre_Cadre01(BaseScene owner) : base(owner)
        {
            this.Name = "Cadre 01";
            this.Timer = 5 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SizeX = 1600;
            image.SizeY = 1500;
            image.Name = Scene02.MainFace_01;
            image.Opacity = 100;
            image.IsOptional = false;
            this.VisionList.Add(image);


            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene02.MainMusic;
            sound.V = 0;
            sound.Transition = "v.B.5000.10";
            this.SoundList.Add(sound);

            if (this.Owner.NPCList.Any())
            {
                ScenElementText text = new ScenElementText();
                text.Text = this.Owner.NPCList.First().Description;
                this.TextList.Add(text);
            }
        }
    }
}
