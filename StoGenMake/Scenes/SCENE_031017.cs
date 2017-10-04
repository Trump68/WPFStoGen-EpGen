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
        private string MainImage = @"D:\Temp\(Aca los Maistros 04)-19 copy 3.png";
        private VNPC FemActor;
        public SCENE_031017() : base()
        {
            FemActor = new VNPC();
            this.AddActor(FemActor);
        }
        protected override void MakeCadres()
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, null, 200);
            cadre.AddImage(false, this.MainImage);
            FemActor.AssembleFigure(cadre);            
        }
    }
    
}
