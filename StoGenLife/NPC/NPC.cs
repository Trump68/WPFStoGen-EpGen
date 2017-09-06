using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.NPC
{
    
    [Serializable]
    public class NPC
    {
        public Guid GID { set; get; }
        public string Description { set; get; }  
        public string Name { set; get; }
    }
}
