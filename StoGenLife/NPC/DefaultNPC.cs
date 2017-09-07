using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.NPC
{
    [Serializable]
    public class DefaultNPC: NPC
    {
        public DefaultNPC():base()
        {            
            this.Description = "This is default NPC description";
        }
    }
}
