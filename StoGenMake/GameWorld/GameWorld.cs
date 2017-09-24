using StoGen.Classes;
using StoGen.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoGenMake.Pers;

namespace StoGenMake
{
    public class GameWorld: IMenuCreator
    {
        public VNPC CurrentPersone { get; internal set; }

        public bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null)
                itemlist = new List<ChoiceMenuItem>();
            proc.OldMenuCreator = this.CreateMenu;
            ChoiceMenuItem item = new ChoiceMenuItem($"{CurrentPersone.Name}...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CurrentPersone.CreateMenuPersone;                
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Переместиться ...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuRelocation;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);
            if (doShowMenu)
            {
                if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
                {
                    //proc.CurrentCadre.Repaint(true);
                }
            }
            return true;
        }
        private bool CreateMenuRelocation(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = new ChoiceMenuItem();
            item = new ChoiceMenuItem();
            item.Name = "Школу";
            item.Data = this;
            item.Executor = delegate (object data)
            {

                proc.GetNextCadre();
                proc.MenuCreator = proc.OldMenuCreator;
                
            };
            itemlist.Add(item);

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);

            return true;
        }
      
    }
}
