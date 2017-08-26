using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class Scene01: BaseScene
    {
        public static string MainFace_01          = "Main face";
        public static string MainFace_01_blink    = "Main face-blink";
        public static string MainMusic            = "Main theme music";
        public static string LightScream          = "Light protesting scream";
        public static string Moaning              = "Moaning while kiss";

        public Scene01() : base()
        {
            this.Name = "Scen Kiss 01";
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01,       "#Pic01  #",   Scene01.MainFace_01));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_blink, "#Pic01_a#",   Scene01.MainFace_01_blink));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.MainMusic,         "#Music01#",   Scene01.MainMusic));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.LightScream,       "#Scream01#",  Scene01.LightScream));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.Moaning,           "#Moaning01#", Scene01.Moaning));
        }
        public override void InitCadres()
        {
            this.Cadres.Add(new ScenCadre_KissStartSetup(this));
            this.Cadres.Add(new ScenCadre_KissStartAppears(this));
            this.Cadres.Add(new ScenCadre_KissStart(this));
            this.Cadres.Add(new ScenCadre_KissDesision(this));
            this.Cadres.Add(new ScenCadre_KissOrgazm1(this));

            base.InitCadres();
        }
        public override List<string> GetTemplate()
        {
            List<string> result = new List<string>();           
            result.AddRange(base.GetTemplate());
            return result;
        }

    }
    public class ScenCadre_KissStartSetup : ScenCadre
    {
        public ScenCadre_KissStartSetup(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss setup";
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
            sound.Name = Scene01.MainMusic;
            sound.V = 0;
            sound.Transition = "v.B.5000.10";
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.LightScream;
            sound.V = 100;
            sound.StartPlay = 0;
            sound.Transition = "W..2000>p.A.20.1";
            this.SoundList.Add(sound);
        }
    }
    public class ScenCadre_KissStartAppears : ScenCadre
    {
        public ScenCadre_KissStartAppears(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss start, appears";
            this.Timer = 5 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01;
            image.IsOptional = false;
            image.File = "#Pic01  #";
            image.Opacity = 0;
            image.Transition = "O.B.5000.100";
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 0;
            sound.Transition = "W..2000>v.B.50000.50";
            this.SoundList.Add(sound);


        }
    }
    public class ScenCadre_KissStart : ScenCadre
    {        
        public ScenCadre_KissStart(BaseScene owner):base(owner)
        {
            this.Name = "Kiss start, blink";
            this.Timer = 60 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01;
            image.IsOptional = false;
            image.File = "#Pic01  #";
            image.Opacity = 100;         
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 0;
            image.Transition = "O.A.20.100>O.A.20.-100>W..1000>O.A.20.100>O.A.20.-100>W..1000~";
            image.IsOptional = true;
            image.File = "#Pic01_a#";
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 50;
            this.SoundList.Add(sound);
        }
    }
    public class ScenCadre_KissDesision : ScenCadre
    {
        public ScenCadre_KissDesision(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, desision";
            this.Timer = 60 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01;
            image.IsOptional = false;
            image.File = "#Pic01  #";
            image.Opacity = 100;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 100;
            image.IsOptional = true;
            image.File = "#Pic01_a#";
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 50;
            this.SoundList.Add(sound);
        }



    }
    public class ScenCadre_KissOrgazm1 : ScenCadre
    {
        public ScenCadre_KissOrgazm1(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, orgazm 1";
            this.Timer = 5 * 1000;

            ScenElementImage image;
            image = new ScenElementImage();
            image.Name = Scene01.MainFace_01;
            image.SetParamsFromScene(this.Owner);
            image.IsOptional = false;
            image.File = "#Pic01  #";
            image.Opacity = 100;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 100;
            image.IsOptional = true;
            image.File = "#Pic01_a#";
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = "Orgazm 1";
            image.Opacity = 0;
            image.IsOptional = false;
            image.File = "#SYS_WHITE#";
            image.Transition = "W..300>O.A.1.100>O.B.200.-50>O.A.1.50>O.B.1000.-80>O.A.1.80>O.B.2000.-100";
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);
        }



    }
}
