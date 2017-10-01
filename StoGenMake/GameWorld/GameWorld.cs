using StoGen.Classes;
using StoGen.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoGenMake.Pers;
using StoGenMake.Location;

namespace StoGenMake
{
    public class GameWorld: IMenuCreator
    {
        public List<VNPC>          PersoneList  { get; internal set; }
        public List<VisualLocaton> LocationList { get; internal set; }
        
        public VNPC CurrentPersone { get; internal set; }
        public GameWorld()
        {
           
            this.PersoneList  = new List<VNPC>();
            this.LocationList = new List<VisualLocaton>();

            this.AddGenericPers("Generic Person 001", @"c:\", "example01.jpg", "example02.jpg");
        }

        private void AddGenericPers(string name,string path,params string[] piclist)
        {
            VNPC pers = null;
            pers = new VNPC();
            if (string.IsNullOrEmpty(name))
                name = $"Generic Person {this.PersoneList.Count}";
            pers.Name = name;
            foreach (var item in piclist)
            {
                pers.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, null, $@"{path}{item}");
            }                       
            this.PersoneList.Add(pers);
        }

        public bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null)
                itemlist = new List<ChoiceMenuItem>();
            proc.OldMenuCreator = this.CreateMenu;
            ChoiceMenuItem item = null;

            // Если есть CurrentPersone - создаем его меню
            if (CurrentPersone != null)
            {
                item = new ChoiceMenuItem($"{CurrentPersone.Name}...", this);
                item.Executor = data =>
                {
                    proc.MenuCreator = CurrentPersone.CreateMenuPersone;
                    proc.ShowContextMenu();
                };
                itemlist.Add(item);
            }

            // Меню вызова досье
            item = new ChoiceMenuItem("Досье ...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuDosie;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);
            

            // Меню перемещения по локациям
            item = new ChoiceMenuItem("Переместиться ...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuRelocation;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);



            FinalizeShowMenu(proc, doShowMenu, itemlist, false);
            return true;
        }
        private bool CreateMenuRelocation(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            foreach (var loc in LocationList)
            {
                item = new ChoiceMenuItem();
                item.Name = loc.Name;
                item.Data = this;
                item.Executor = data =>
                {
                    proc.MenuCreator = loc.CreateMenuLocationDocier;
                    proc.ShowContextMenu();
                };
                itemlist.Add(item);
            }

            FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        private bool CreateMenuDosie(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            foreach (var pers in PersoneList)
            {
                item = new ChoiceMenuItem();
                item.Name = pers.Name;
                item.Data = this;
                item.Executor = data =>
                {
                    proc.MenuCreator = pers.CreateMenuPersoneDocier;
                    proc.ShowContextMenu();
                };
                itemlist.Add(item);
            }           

            FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        private void FinalizeShowMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, bool processCancel)
        {
            if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
            {
                
            }
            else if (processCancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);
        }
    }
}
