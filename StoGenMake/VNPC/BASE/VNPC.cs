using StoGenLife.NPC;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class VNPC:NPC
    {
        public BaseScene Scene { set; get; }
        public virtual void PrepareScene() { }
    }
}
