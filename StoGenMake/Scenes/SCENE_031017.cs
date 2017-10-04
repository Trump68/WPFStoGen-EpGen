using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SCENE_031017: BaseScene
    {
        private VNPC FemHeadActor;
        private VNPC FemBodyActor;
        public SCENE_031017() : base()
        {
            FemBodyActor = new VNPC();
            this.AddActor(FemBodyActor);

            FemHeadActor = new VNPC();
            this.AddActor(FemHeadActor);
        }
        protected override void MakeCadres()
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, null, 200);
            FemBodyActor.AssembleBody(cadre);
            FemHeadActor.AssembleHead(cadre);            
        }
    }
    
}
