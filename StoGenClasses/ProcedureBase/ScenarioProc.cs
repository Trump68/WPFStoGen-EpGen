using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class ScenarioProc : ProcedureBase
    {
        public List<ScenarioSet> sets = new List<ScenarioSet>();

       
        public ScenarioProc(string fn)
           : base(0)
        {
            this.MenuCreator = CreateMenu;
            ScenarioSet set = new ScenarioSet();
            set.Init(fn);
            this.sets.Add(set);
            set.InsertAsProcedureTo(this,true);
            this.ShowContextMenuOnInit = false;                     
            this.GetNextCadre();
        }
      
        public override bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            foreach (Set_View set in sets)
            { 
                item = new ChoiceMenuItem(
                    set.Name, set,
                    new MenuDescriptopnItem("Period", set.Period),
                    new MenuDescriptopnItem("Country", set.Country),
                    new MenuDescriptopnItem("Studio", set.Studio),
                    new MenuDescriptopnItem("Description", set.Description)
                    );
                item.Executor = delegate (object data)
                {
                    ProcedureBase innerproc = ((Set_View)data).InsertAsProcedureTo(this, true);
                    innerproc.MenuCreator = ((Set_View)data).CreateMenu;
                    this.GetNextCadre();
                  
                };
                itemlist.Add(item);
            }
            //foreach (CycleProc cyc in setsA)
            //{
            //    item = new ChoiceMenuItem(cyc.Name, cyc);
            //    item.Executor = delegate (object data)
            //    {
            //        ProcedureBase innerproc = ((CycleProc)data).InsertAsProcedureTo(this);
            //        innerproc.MenuCreator = ((CycleProc)data).CreateMenu;
            //        this.GetNextCadre();
            //    };
            //    itemlist.Add(item);
            //}

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                //this.ParentProc.InnerProc = null;
                //this.ParentProc.ShowContextMenu();
            }
            return true;
        }           

    }
}
