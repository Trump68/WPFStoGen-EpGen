using Menu.Classes;
using StoGen.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGenerator
{

    public enum Teller
    {
        Female,
        Male,
        FemaleThoughts,
        MaleThoughts,
        Author,
        Others,
        OthersThoughts
    }
    public class StoryBase : SCENARIO
    {
        //protected Info_Scene FCurrentPosition = new Info_Scene();
        protected List<Info_Scene> Layers;
        public StoryBase() : base()
        {

        }
        public string CatalogPath;
        protected override string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=40;DefFontColor=Cyan;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
    /*    public string Name { set; get; }
       
        // MENU=======================================================
        protected bool MenuIsLive = false;
        public MenuCreatorDelegate GetMenuCreator(bool live)
        {
            MenuIsLive = live;
            return CreateMenu;
        }
        public virtual bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, MenuType type, bool goNextCadre)
        {
            string caption;
            // just for root menu
            itemlist = AddRootMenu(proc, null, goNextCadre, out caption);
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, caption);
            return true;
        }
        protected virtual List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist,bool goNextCadre, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Go To Cadre:";
            item.itemData = "Go To Cadre:";
            item.Executor = data =>
            {
                //proc.MenuCreator = proc.OldMenuCreator;
                string str1;
                //var itemlist1 = CreateMenuCadreTravel(proc, null, out str1);
                //ShowMenuGoToCadre(proc, itemlist1);
            };
            itemlist.Add(item);
            caption = "Actions:";
            return itemlist;
        }
        public bool ShowMenuGoToCadre(CadreController proc, List<ChoiceMenuItem> itemlist)
        {
            //string caption;
            //// just for current cadre selecting
            //itemlist = CreateMenuCadreTravel(proc, null, out caption);
            //ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }
        public bool ShowSubmenu(CadreController proc, List<ChoiceMenuItem> itemlist, string caption)
        {
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }
*/



    }
}
