using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class CycleProc : ProcedureBase
    {
        public List<Set_View> sets = new List<Set_View>();
        public List<CycleProc> setsA = new List<CycleProc>();
        public CycleProc(int level)
            : base(level)
        {
            this.MenuCreator = CreateMenu;
        }
        public CycleProc(string fn)
           : base(0)
        {
            this.MenuCreator = CreateMenu;
            AddNewSet("DUMMY", "DUMMY", fn, null, null, null, null);
            ProcedureBase innerproc = this.setsA.First().sets.First().InsertAsProcedureTo(this, true);
            //innerproc.MenuCreator = ((Set_View)data).CreateMenu;
            this.GetNextCadre();
        }
        ProcedureBase ParentProc = null;
        public ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc)
        {
            this.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, true);
            cadre.GetProcFrame().Proc = this;
            this.ParentProc = ownerproc;
            return this;
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
                    //innerproc.ShowContextMenu();
                };
                itemlist.Add(item);
            }
            foreach (CycleProc cyc in setsA)
            {
                item = new ChoiceMenuItem(cyc.Name, cyc);
                item.Executor = delegate (object data)
                {
                    ProcedureBase innerproc = ((CycleProc)data).InsertAsProcedureTo(this);
                    innerproc.MenuCreator = ((CycleProc)data).CreateMenu;
                    this.GetNextCadre();
                };
                itemlist.Add(item);
            }

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                this.ParentProc.InnerProc = null;
                this.ParentProc.ShowContextMenu();
            }
            return true;
        }
        public CycleProc AddNewCycle(string name)
        {
            CycleProc cyc = new CycleProc(this.Level);
            cyc.Name = name;
            this.setsA.Add(cyc);
            return cyc;
        }
        public Set_View AddNewSet(string name, string path, CycleProc cyc, string country, string period, string studio, string description = null)
        {
            Set_View set = new Set_View();
            set.Init(name, path, country, period, studio, description);
            cyc.sets.Add(set);
            return set;
        }
        public Set_View AddNewSet(string nameCyc, string nameSet, string path, string country, string period, string studio, string description = null)
        {
            CycleProc cyc = this.setsA.FirstOrDefault(c => c.Name == nameCyc);
            if (cyc == null) cyc = this.AddNewCycle(nameCyc);
            return this.AddNewSet(nameSet, path, cyc, country, period, studio, description);
        }

        public string Description { get; set; }
    }
}
