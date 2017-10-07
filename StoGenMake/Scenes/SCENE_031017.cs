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
           
        }
        protected override void MakeCadres()
        {
            SetCadre("LADY_Body_1710070900", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070901", "LADY_Head_1710070901");

            SetCadre("LADY_Body_1710070901", "LADY_Head_1710070902");
            SetCadre("LADY_Body_1710070902", "LADY_Head_1710070902");

            SetCadre("LADY_Body_1710070903", "LADY_Head_1710070903");
            SetCadre("LADY_Body_1710070900", "LADY_Head_1710070903");
        }

        private void SetCadre(string bodyN, string headN)
        {
            var cadre = this.AddCadre(null, null, 200);

            FemBodyActor = GameWorldFactory.GameWorld.CommonFemBodyList.Where(x => x.Name == bodyN).FirstOrDefault();
            var body = FemBodyActor.GetBody(null);
            FemBodyActor.AssembleBody(cadre);

            FemHeadActor = GameWorldFactory.GameWorld.CommonFemHeadList.Where(x => x.Name == headN).FirstOrDefault();
            var head = FemHeadActor.GetHead(null);
            head.AlignTo(body);
            FemHeadActor.AssembleHead(cadre);
        }
    }
    
}
