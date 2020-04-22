using StoGen.Classes.Interfaces;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class ScenarioProc : ProcedureBase
    {
        //public List<ScenarioSet> sets = new List<ScenarioSet>();
        public ScenarioProc(string fn, IMenuCreator globalMenuCreator, BaseScene scene)
           : base(0)
        {
           
            this.MenuCreator = CreateMenu;
            this.Scene = scene;
            var i = 0;
            foreach (var ad in this.Scene.AlignList)
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
