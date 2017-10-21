using StoGen.Classes.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class ScenarioProc : ProcedureBase
    {
        public List<ScenarioSet> sets = new List<ScenarioSet>();
        


        public ScenarioProc(string fn, IMenuCreator globalMenuCreator)
           : base(0)
        {
           
            this.MenuCreator = CreateMenu;
            ScenarioSet set = new ScenarioSet();
            set.GlobalMenuCreator = globalMenuCreator;
            set.Init(fn);
            this.sets.Add(set);
            set.InsertAsProcedureTo(this,true);
            this.ShowContextMenuOnInit = false;
            this.GetNextCadre();
           
        }
      
        public override bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {

            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

                     
           
            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                //this.ParentProc.InnerProc = null;
                //this.ParentProc.ShowContextMenu();
            }
            return true;
        }           

    }
}
