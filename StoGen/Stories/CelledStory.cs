using StoGen.Classes;
using StoGen.ModelClasses;
using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class CelledStory : StoryBase
    {
        protected Cell CurrentCell;
        protected Cell OldCell;
        public CelledStory():base()
        {
            CurrentCell = Cell.Storage.First();
        }

        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            string caption;
            int mode = (int)Data;
            int viewNum = mode;
            if (mode == 1)
            {
                itemlist = CreateMenuGoToLocation(proc, null, out caption);
            }
            else
            {
                itemlist = AddRootMenu(proc, null, out caption);
                itemlist = base.AddRootMenu(proc, itemlist, out caption);
            }
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, caption, viewNum);
            return true;
        }
        protected override List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            this.AddMenu_GoToLocation(proc, itemlist, out caption);
            caption = "Выбрать действие:";
            return itemlist;
        }
        protected List<ChoiceMenuItem> AddMenu_GoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Идти куда:";
            item.Executor = data =>
            {
                string tmp;
                var itemlist1 = CreateMenuGoToLocation(proc, null, out tmp);
                ShowSubmenu(proc, itemlist1, tmp);
            };
            caption = item.Name;
            itemlist.Add(item);
            return itemlist;
        }
        protected List<ChoiceMenuItem> CreateMenuGoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            foreach (var cell in this.CurrentCell.NearByCells)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{cell.Name}";
                item.itemData = cell;
                item.SetPicture(cell.Picture("day").FirstOrDefault()?.File);
                item.Executor = data =>
                {
                    OldCell = CurrentCell;
                    CurrentCell = data as Cell;
                    F_Posture = new List<Info_Scene>();
                    F_Posture.Add(CurrentCell.Picture("day").FirstOrDefault());
                    MakeNextCadre(Teller.Author,null);
                    Projector.ImageCadre.InfoLocationText = CurrentCell.FullName;
                    proc.GetNextCadre();
                };
                itemlist.Add(item);
            }
            if (OldCell == null || (OldCell.LocationKind > CurrentCell.LocationKind))
            {
                itemlist.Reverse();
            }
            //else if (OldCell.LocationKind == CurrentCell.LocationKind)
            //{
            //    var a = itemlist.First();
            //    itemlist.RemoveAt(0);
            //    itemlist.Add(a);
            //}
            caption = "Куда?";
            return itemlist;
        }
       
    }
}
