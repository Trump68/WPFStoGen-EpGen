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
            this.Name = "Scene02";
            this.Variables.Add(new SceneVariable("IMAGE", Scene01.MainFace_01, string.Empty, Scene01.MainFace_01));
            this.Variables.Add(new SceneVariable("SOUND", Scene01.MainMusic, string.Empty, Scene02.MainMusic));

           
        }
        public override void InitCadres()
        {            
            
            base.InitCadres();
        }
    }
    
    
}
