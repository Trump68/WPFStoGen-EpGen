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
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
            this.Description = "This is default NPC description";
        }
    }
}
