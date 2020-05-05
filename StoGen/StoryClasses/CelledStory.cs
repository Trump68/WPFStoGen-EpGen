using Menu.Classes;
using StoGen.Classes;
using StoGen.ModelClasses;
using StoGenerator.CadreElements;
using StoGenerator.StoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class CelledStory : TimedStory
    {
        private enum MovementDirection
        {
            In,Out
        }
        private Cell _CurrentCell;
        private Cell _OldCell;
        public Cell CurrentCell
        {
            get { return _CurrentCell; }
            set
            {
                _OldCell = _CurrentCell;
                _CurrentCell = value;
            }
        }
        private MovementDirection MoveDirection
        {
            get
            {
                if (_OldCell == null || (_OldCell.LocationKind > CurrentCell.LocationKind))
                {
                    return MovementDirection.Out;
                }
                return MovementDirection.In;
            }
        }
        public CelledStory(DateTime date, string startAtAddress):base(date)
        {
            CurrentCell = Cell.GetByAddress(null, startAtAddress);
        }
        protected virtual void GoToCell(Cell cell, CadreController proc, bool goNextCadre)
        {
            //if (F_Posture == null)
            // всегда начинаем кадр с локации
            Layers = new List<Info_Scene>();
            if (cell == null)
                cell = Cell.Storage.First();
            CurrentCell = cell;
            FillCadreContent();
            if (proc != null)
            {
                MakeNextCadre(Teller.Author, null);      
                if (goNextCadre)         
                    proc.GetNextCadre();               
            }
            Projector.ImageCadre.InfoLocationText = CurrentCell.FullName;
        }
        protected virtual void FillCadreContent()
        {
            var pic = CurrentCell.Picture(TimeOfDay).FirstOrDefault();
            pic.Description = CurrentCell.FullName;
            Layers.Add(pic);
        }
        public void GoToCellByAddress(string address, CadreController proc)
        {           
            Cell cell = Cell.GetByAddress(null, address);
            if (cell != null)
            {
                GoToCell(cell, proc,false);
            }
        }
        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, MenuType type, bool goNextCadre)
        {
            string caption;            
            string cap = null;
            if (type == MenuType.Cell)
            {
                if (MenuIsLive)
                {
                    itemlist = FillMenu_GoToLocation_ByData(proc, null, goNextCadre, out caption);
                    cap = caption;
                }            
            }
            else if(type == MenuType.Common)
            {
                if (MenuIsLive)
                    itemlist = AddRootMenu(proc, null, goNextCadre, out caption);
            }
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, cap, type);
            return true;
        }
        protected override List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist,bool goNextCadre, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            if (MenuIsLive)
                this.AddMenu_GoToLocation(proc, itemlist, goNextCadre, out caption);
            itemlist = base.AddRootMenu(proc, itemlist, goNextCadre, out caption);
            caption = "Выбрать действие:";
            return itemlist;
        }
        protected List<ChoiceMenuItem> AddMenu_GoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist,bool goNextCadre, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Идти куда:";
            item.Executor = data =>
            {
                string tmp;
                var itemlist1 = FillMenu_GoToLocation_ByData(proc, null, goNextCadre, out tmp);
                ShowSubmenu(proc, itemlist1, tmp);
            };
            caption = item.Name;
            itemlist.Add(item);
            return itemlist;
        }
        protected List<ChoiceMenuItem> FillMenu_GoToLocation_ByData(CadreController proc, List<ChoiceMenuItem> itemlist, bool goNextCadre, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            foreach (var cell in this.CurrentCell.NearByCells)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{cell.Name}";
                item.itemData = cell;
                item.SetPicture(cell.Picture(TimeOfDay).FirstOrDefault()?.File);
                item.Executor = data =>
                {
                    GoToCell(data as Cell, proc, goNextCadre);                  
                };
                itemlist.Add(item);
            }
            if (MoveDirection == MovementDirection.Out)
                itemlist.Reverse();
            caption = "Куда";
            return itemlist;
        }
        //protected List<ChoiceMenuItem> CreateMenuCadreLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    foreach (var location in StoGenerator.LocationStorage.Storage)
        //    {
        //        var item = new ChoiceMenuItem();
        //        item.Name = $"{location.Name}";
        //        item.itemData = location;
        //        MenuDescriptopnItem mdi1 = new MenuDescriptopnItem("Тип", location.Type, true);
        //        item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
        //        item.Executor = data =>
        //        {
        //            this.RemoveAllGroupsAfter(proc.CadreId);
        //            CE_Location.AddWithMusic(this, ((LocationStorage)data).Name, "day", "Печальная тема 01", null);
        //            proc.GetNextCadre();
        //        };
        //        itemlist.Add(item);
        //    }

        //    caption = "Выбрать локацию:";
        //    return itemlist;
        //}
        //item = new ChoiceMenuItem();
        //item.Name = "Go To Location:";
        //item.itemData = "Go To Location:";
        //item.Executor = data =>
        //{
        //    string caption1;
        //    var itemlist1 = CreateMenuCadreLocation(proc, null, out caption1);
        //    ShowSubmenu(proc, itemlist1, caption1);
        //};
        //itemlist.Add(item);

        protected override void GenerateNewStoryStep(CadreController proc)
        {
           base.GenerateNewStoryStep(proc);
        }
    }
}
