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
    public class TestScene: BaseScene
    {
        private VNPC FemHeadActor;
        private VNPC FemBodyActor;
        public TestScene() : base()
        {
           
        }
        protected override void MakeCadres()
        {
            SetCadre("LADY_Body_1710071009", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071008", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071007", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071006", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071005", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071004", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071003", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710071002", "LADY_Head_1710070901");

            SetCadre("LADY_Body_1710070908a", "LADY_Head_1710071000");
            SetCadre("LADY_Body_1710070908a", "LADY_Head_1710071001");

            SetCadre("LADY_Body_1710070907d", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070907c", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070907b", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070907a", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070907",  "LADY_Head_1710070901");
            
            SetCadre("LADY_Body_1710070908p", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908o", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908n", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908m", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908l", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908k", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908j", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908h", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908g", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908f", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908e", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908d", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908c", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908b", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908a", "LADY_Head_1710070901");
            SetCadre("LADY_Body_1710070908", "LADY_Head_1710070901");
            

            SetCadre("LADY_Body_1710070906", "LADY_Head_1710070906");

            SetCadre("LADY_Body_1710070905", "LADY_Head_1710070905");

            SetCadre("LADY_Body_1710070900", "LADY_Head_1710070904");
            SetCadre("LADY_Body_1710070904", "LADY_Head_1710070904");

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
