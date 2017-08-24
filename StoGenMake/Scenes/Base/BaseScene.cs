using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;

namespace StoGenMake.Scenes.Base
{
    public class BaseScene
    {
        public string Description { get; set; }
        List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();
    }
}
