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
        public Scene01() : base()
        {
            this.Name = "Scene01";
            this.Description = "Scene01 descr";
        }
        public override void InitCadres()
        {
            ScenCadre cadre = new ScenCadre();               
            this.Cadres.Add(cadre);
        }
        protected override List<string> GetTemplate()
        {
            return base.GetTemplate();
        }
    }
}
