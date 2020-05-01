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
        public CelledStory():base()
        {
            CurrentCell = Cell.Storage.First();
        }

        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            string caption;

            itemlist = AddRootMenu(proc, null, out caption);
            itemlist = base.AddRootMenu(proc, itemlist, out caption);
            caption = "Выбрать действие:";
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, caption);
            return true;
        }
        protected List<ChoiceMenuItem> AddMenu_GoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Идти куда:";
            item.itemData = "Идти куда:";
            item.Executor = data =>
            {
                string caption2;
                var itemlist1 = CreateMenuGoToLocation(proc, null, out caption2);
                ShowSubmenu(proc, itemlist1, caption2);
            };
            itemlist.Add(item);
            caption = "Действия:";
            return itemlist;
        }
        private List<ChoiceMenuItem> CreateMenuGoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            foreach (var cell in this.CurrentCell.NearByCells)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{cell.FullName}";
                item.itemData = cell;
                item.Executor = data =>
                {
                    CurrentCell = data as Cell;
                    F_Posture = new List<Info_Scene>();
                    F_Posture.Add(CurrentCell.Picture("day").FirstOrDefault());
                    MakeNextCadre(Teller.Author,null);
                    Projector.ImageCadre.InfoLocationText = CurrentCell.FullName;
                    proc.GetNextCadre();
                };
                itemlist.Add(item);
            }

            caption = "Идти куда:";
            return itemlist;
        }
       
    }
}
