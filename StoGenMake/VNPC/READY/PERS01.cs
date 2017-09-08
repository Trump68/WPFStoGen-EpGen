using StoGenMake.Elements;
using StoGenMake.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class PERS01: GenericFem
    {
        public PERS01():base()
        {
            this.Scene = new Scene02();
            this.Name = "[Oda Non] Non Virgin.Lady 1";
            this.GID = Guid.Parse("{39FCD7CD-C3A5-497A-9D10-84F2DF6DB34B}");
        }

      
    }
}
