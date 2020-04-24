using StoGen.Classes;
using StoGen.Classes.Scene;
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
        public StoryBase() : base()
        {
        }
        protected string rawparameters =
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

        public static string currentQueue;
        public static string currentGroup;
        public string Name { set; get; }
        public void IncrementGroup()
        {
            var vals = currentGroup.Split('.');
            if (vals.Length == 0) return;
            int d;
            if (int.TryParse(vals[0], out d))
            {
                ++d;
                vals[0] = (d.ToString("D" + vals[0].Length));
            }
            currentGroup = string.Join(".", vals);
        }
        public virtual void GenerateNextCadre() { }
        public virtual void Generate(string queue, string group)
        {
            currentGroup = group;
            currentQueue = queue;
            RawParameters = rawparameters;
            AssignRawParameters();
        }
        protected virtual void FillData()
        {
        }
        protected virtual void MakeLocation()
        {

        }

        internal List<Info_Scene> GetNextGroups(int lastgrouId)
        {
            var grupedlist = GetGroupedList();
            lastgrouId++;
            if (lastgrouId > grupedlist.Count() - 1)
            {

            }
            else
            {
                var last = grupedlist[lastgrouId].Select(x => x).ToList();
                if (!last.First().Active)
                {
                    last.ForEach(x => x.Active = true);
                    return last;
                }
            }
            return null; ;
        }

        public void RemoveAllGroupsAfterIndex(int index)
        {
            var group = this.GetGroupedList()[index].Key;
            while (this.SceneInfos.Last().Group != group)
            {
                this.SceneInfos.Remove(this.SceneInfos.Last());
            }
        }

        // MENU
        public MenuCreatorDelegate GetMenuCreator()
        {
            return CreateMenu;
        }
        public virtual bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            string caption;
            // just for root menu
            itemlist = AddRootMenu(proc, null, out caption);
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, caption);
            return true;
        }
        protected List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Go To Cadre:";
            item.itemData = "Go To Cadre:";
            item.Executor = data =>
            {
                proc.MenuCreator = proc.OldMenuCreator;
                string str1;
                var itemlist1 = CreateMenuCadreTravel(proc, null, out str1);
                ShowMenuGoToCadre(proc, itemlist1);
            };
            itemlist.Add(item);
            caption = "Actions:";
            return itemlist;
        }
        protected List<ChoiceMenuItem> CreateMenuCadreTravel(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;
            var grupedlist = SceneInfos.Where(x => x.Active && x.Kind == 1).GroupBy(x => x.Group).ToList();
            foreach (var it in grupedlist)
            {
                item = new ChoiceMenuItem();
                item.Name = it.First().Story;
                item.itemData = it;
                //MenuDescriptopnItem mdi1 = new MenuDescriptopnItem(" ", "9. Перейти на кадр:", true);                
                //item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
                item.Executor = data =>
                {
                    proc.MenuCreator = proc.OldMenuCreator;
                    var index = grupedlist.IndexOf(it);
                    proc.GoToCadre(++index);

                };
                itemlist.Add(item);
            }
            caption = "Go To Cadre:";
            return itemlist;
        }       
        public bool ShowMenuGoToCadre(CadreController proc, List<ChoiceMenuItem> itemlist)
        {
            string caption;
            // just for current cadre selecting
            itemlist = CreateMenuCadreTravel(proc, null, out caption);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }

      



    }
}
