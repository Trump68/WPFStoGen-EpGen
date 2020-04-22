using StoGen.Classes.Interfaces;
using StoGenMake;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class ScenarioProc : ProcedureBase
    {
        private BaseScene Scene;
        public ScenarioProc(string fn, BaseScene scene)
           : base(0)
        {
            Scene = scene;
            this.MenuCreator = CreateMenu;
            var i = 0;
            foreach (var ad in Scene.CadreDataList)
            {
                var AppCadre = new Cadre(this, true);
                AppCadre.ImageFr.ShowMovieControls = true;
                AppCadre.AlignData = ad;
            }
            this.ShowContextMenuOnInit = false;
            this.GoFirstCadre();
        }      
        public override bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {

            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

                     
           
            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {

            }
            return true;
        }


    }
}
