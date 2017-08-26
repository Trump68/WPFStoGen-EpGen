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
        public static string MainFace_01                   = "Main face";
        public static string MainFace_01_blink             = "Main face-blink";
        public static string MainFace_01_blink_frown       = "Main face-blink-frown";
        public static string MainFace_01_SweatDrop         = "Main face-sweat-drop";
        public static string MainFace_01_KissPause         = "Main face-kiss-pause";
        public static string MainFace_01_KissPauseOpenEyes = "MainFace_01_KissPauseOpenEyes";
        public static string MainFace_01_TonguePlay1       = "MainFace_01_TonguePlay1";
        public static string MainFace_01_TonguePlay2       = "MainFace_01_TonguePlay2";
        public static string MainFace_01_TonguePlay3       = "MainFace_01_TonguePlay3";
        public static string MainFace_01_TonguePlay4       = "MainFace_01_TonguePlay4";

        public static string MainMusic                  = "Main theme music";
        public static string LightScream                = "Light protesting scream";
        public static string Moaning                    = "Moaning while kiss";

        public Scene01() : base()
        {
            this.Name = "Scen Kiss 01";
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01,                   string.Empty,   Scene01.MainFace_01));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_blink,             string.Empty,   Scene01.MainFace_01_blink));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_blink_frown,       string.Empty,   Scene01.MainFace_01_blink_frown));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_SweatDrop,         string.Empty,   Scene01.MainFace_01_SweatDrop));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_KissPause,         string.Empty,   Scene01.MainFace_01_KissPause));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_KissPauseOpenEyes, string.Empty,   Scene01.MainFace_01_KissPauseOpenEyes));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_TonguePlay1,       string.Empty,   Scene01.MainFace_01_TonguePlay1));            
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_TonguePlay2,       string.Empty,   Scene01.MainFace_01_TonguePlay2));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_TonguePlay3,       string.Empty,   Scene01.MainFace_01_TonguePlay3));
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01_TonguePlay4,       string.Empty,   Scene01.MainFace_01_TonguePlay4));

            this.Variables.Add(new SceneVariable("SOUND", Scene01.MainMusic,                     string.Empty,   Scene01.MainMusic));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.LightScream,                   string.Empty,   Scene01.LightScream));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.Moaning,                       string.Empty,   Scene01.Moaning));
        }
        public override void InitCadres()
        {
            this.Cadres.Add(new ScenCadre_KissStartSetup(this));
            this.Cadres.Add(new ScenCadre_KissStartAppears(this));
            this.Cadres.Add(new ScenCadre_KissStart(this));
            this.Cadres.Add(new ScenCadre_KissDesision(this));
            this.Cadres.Add(new ScenCadre_KissOrgazmApproaching(this));
            this.Cadres.Add(new ScenCadre_KissOrgazm1(this));
            this.Cadres.Add(new ScenCadre_KissPause(this));
            this.Cadres.Add(new ScenCadre_KissPauseOpenEyes(this));
            this.Cadres.Add(new ScenCadre_KissAgain(this));
            this.Cadres.Add(new ScenCadre_TonguePlay01(this));
            this.Cadres.Add(new ScenCadre_KissPause(this));
            this.Cadres.Add(new ScenCadre_TonguePlay02(this));
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
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => x.Name == Scene01.MainFace_01 && x.IsActivated);
            }
        }
        public ScenCadre_KissStartAppears(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss start, appears";
            this.Timer = 5 * 1000;

            this.VisionList.Add(ScenElementImage.Previous);

            ScenElementImage image;
            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01;
            image.IsOptional = false;
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
            image.Opacity = 100;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 0;
            image.Transition = "O.A.20.100>O.A.20.-100>W..1000>O.A.20.100>O.A.20.-100>W..1000~";
            image.IsOptional = true;
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
        public override bool IsActivated { get { return this.VisionList.Any(x=>x.IsActivated); } }
        public ScenCadre_KissDesision(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, desision";
            this.Timer = 60 * 1000;
            ScenElementImage image;

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 0;
            image.IsOptional = true;
            image.Transition = "O.B.30000.100";
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
    public class ScenCadre_KissOrgazmApproaching : ScenCadre
    {
        public override bool IsActivated { get { return this.VisionList.Any(x => x.IsActivated); } }
        public ScenCadre_KissOrgazmApproaching(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, orgazm approaching";
            this.Timer = 20 * 1000;
            ScenElementImage image;

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink_frown;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
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
        public override bool IsActivated { get { return this.VisionList.Where(x=>!x.IsOptional).Any(x => x.IsActivated); } }
        public ScenCadre_KissOrgazm1(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, orgazm 1";
            this.Timer = 5 * 1000;
            ScenElementImage image;

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink_frown;
            image.Opacity = 100;
            image.IsOptional = false;
            image.File = "#Pic01_b#";
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image); 

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = "Orgazm 1";
            image.Opacity = 0;
            image.IsOptional = true;
            image.File = "#SYS_WHITE#";
            image.Transition = "W..300>O.A.1.100>O.B.200.-50>O.A.1.50>O.B.1000.-80>O.A.1.80>O.B.2000.-100";
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 0;
            this.SoundList.Add(sound);
        }



    }
    public class ScenCadre_KissPause : ScenCadre
    {
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => (x.Name == Scene01.MainFace_01_KissPause) && x.IsActivated);
            }
        }
        public ScenCadre_KissPause(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, pause";
            this.Timer = 5 * 1000;

            ScenElementImage image;

            //image = new ScenElementImage();
            //image.SetParamsFromScene(this.Owner);
            //image.Name = Scene01.MainFace_01_blink_frown;
            //image.Opacity = 100;
            //image.IsOptional = false;
            //this.VisionList.Add(image);

            this.VisionList.Add(ScenElementImage.Previous);

            image = new ScenElementImage();
            image.Name = Scene01.MainFace_01_KissPause;
            image.SetParamsFromScene(this.Owner);
            image.IsOptional = false;
            image.Opacity = 0;
            image.Transition = "O.B.500.100";
            this.VisionList.Add(image);          

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 0;
            this.SoundList.Add(sound);
        }
    }
    public class ScenCadre_KissPauseOpenEyes : ScenCadre
    {
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => x.Name == Scene01.MainFace_01_KissPauseOpenEyes && x.IsActivated);
            }
        }
        public ScenCadre_KissPauseOpenEyes(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, pause, open eyes";
            this.Timer = 5 * 1000;

            ScenElementImage image;

            image = new ScenElementImage();
            image.Name = Scene01.MainFace_01_KissPause;
            image.SetParamsFromScene(this.Owner);
            image.IsOptional = false;
            image.Opacity = 100;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.Name = Scene01.MainFace_01_KissPauseOpenEyes;
            image.SetParamsFromScene(this.Owner);
            image.IsOptional = false;
            image.Opacity = 0;
            image.Transition = "O.B.250.100>W..1000>O.A.20.-100>";
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image);

            ScenElementSound sound;
            sound = new ScenElementSound();
            sound.Name = Scene01.MainMusic;
            sound.V = 10;
            this.SoundList.Add(sound);

            sound = new ScenElementSound();
            sound.Name = Scene01.Moaning;
            sound.V = 0;
            this.SoundList.Add(sound);
        }
    }
    public class ScenCadre_KissAgain : ScenCadre
    {
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => x.Name == Scene01.MainFace_01_blink && x.IsActivated);
            }
        }
        public ScenCadre_KissAgain(BaseScene owner) : base(owner)
        {
            this.Name = "Kiss, again";
            this.Timer = 10 * 1000;

            ScenElementImage image;

            image = new ScenElementImage();
            image.Name = Scene01.MainFace_01_KissPause;
            image.SetParamsFromScene(this.Owner);
            image.IsOptional = false;
            image.Opacity = 100;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_blink;
            image.Opacity = 0;
            image.Transition = "O.B.1000.100";
            image.IsOptional = true;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
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
    public class ScenCadre_TonguePlay01 : ScenCadre
    {
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => x.Name == Scene01.MainFace_01_TonguePlay1 && x.IsActivated);
            }
        }
        public ScenCadre_TonguePlay01(BaseScene owner) : base(owner)
        {
            this.Name = "Tongue play 1";
            this.Timer = 20 * 1000;

            ScenElementImage image;



            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_TonguePlay1;
            image.Opacity = 100;            
            image.IsOptional = true;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_TonguePlay2;
            image.Opacity = 0;
            image.Transition = "O.B.500.100>W..1000>O.B.500.-100>~";
            image.IsOptional = true;
            this.VisionList.Add(image);

            //image = new ScenElementImage();
            //image.SetParamsFromScene(this.Owner);
            //image.Name = Scene01.MainFace_01_blink;
            //image.Opacity = 100;
            //image.Transition = "O.B.1000.-100";
            //image.IsOptional = true;
            //this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
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
    public class ScenCadre_TonguePlay02 : ScenCadre
    {
        public override bool IsActivated
        {
            get
            {
                return this.VisionList.Exists(x => x.Name == Scene01.MainFace_01_TonguePlay3 && x.IsActivated);
            }
        }
        public ScenCadre_TonguePlay02(BaseScene owner) : base(owner)
        {
            this.Name = "Tongue play 2";
            this.Timer = 20 * 1000;

            ScenElementImage image;



            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_TonguePlay3;
            image.Opacity = 100;
            image.IsOptional = true;
            this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_TonguePlay4;
            image.Opacity = 0;
            image.Transition = "O.B.400.100>O.B.400.-100>~";
            image.IsOptional = true;
            this.VisionList.Add(image);

            //image = new ScenElementImage();
            //image.SetParamsFromScene(this.Owner);
            //image.Name = Scene01.MainFace_01_blink;
            //image.Opacity = 100;
            //image.Transition = "O.B.1000.-100";
            //image.IsOptional = true;
            //this.VisionList.Add(image);

            image = new ScenElementImage();
            image.SetParamsFromScene(this.Owner);
            image.Name = Scene01.MainFace_01_SweatDrop;
            image.Opacity = 100;
            image.IsOptional = true;
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
}
