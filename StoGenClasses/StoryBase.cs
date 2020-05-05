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
        protected void MakeTitle()
        {
            Info_Scene title = new Info_Scene();
            title.Kind = 1;
            //title.File = "$$WHITE$$";
            title.Queue = currentQueue;
            title.Group = currentGroup;
            SceneInfos.Add(title);
            IncrementGroup();
        }
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
        public virtual void Generate(string queue, string group)
        {
            currentGroup = group;
            currentQueue = queue;
        }
        protected virtual void FillData()
        {
        }     

        public void RemoveAllGroupsAfter(int index)
        {
            var group = this.GetGroupedList()[index].Key;
            while (this.SceneInfos.Last().Group != group)
            {
                this.SceneInfos.Remove(this.SceneInfos.Last());
            }
        }
        public void RemoveGroupAt(int index)
        {
            var group = this.GetGroupedList()[index].Key;
            for (int i = 0; i < this.SceneInfos.Count(); i++)
            {
                if (this.SceneInfos[i].Group == group)
                {
                    this.SceneInfos.RemoveAt(i);
                    i--;
                }
            }
        }
        public void AddScenes(List<Info_Scene> list,int startLevel,bool active)
        {
            foreach (var item in list)
            {
                if (item.Kind == 0)
                    item.Z = (startLevel++).ToString();
                item.Group = StoryBase.currentGroup;
                item.Queue = StoryBase.currentQueue;
                item.Active = active;
                if (!SceneInfos.Contains(item))
                {
                    SceneInfos.Add(item);
                }
            }
        }
        protected List<Info_Scene> PullCadreFromScene(CadreController proc, int cadreId)
        {
            List<Info_Scene> result = proc.Scene.CadreDataList[cadreId].OriginalInfo;
            currentGroup = result.First().Group;
            currentQueue = result.First().Queue;
            proc.Cadres.RemoveAt(cadreId);
            proc.Scene.CadreDataList.RemoveAt(cadreId);
            RemoveGroupAt(cadreId);
            return result;
        }
        protected void AddText(string story, Teller who, bool slow, bool active, int? fontSize = null)
        {
            string tran = "W..500>O.B.400.100";
            string fs = null;
            if (fontSize.HasValue)
                fs = $"{fontSize.Value}";
            if (who == Teller.Female)
            {
                if (slow)
                    tran = "W..1500>O.B.400.100";
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = story, Description = story, Group = currentGroup, Queue = currentQueue, S = fs, T = tran, O = "0", R = "2" });
            }
            else if (who == Teller.Male)
            {
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = $"{story}", Description = story, Group = currentGroup, Queue = currentQueue, S = fs, T = tran, O = "0", R = "2" });
            }
            else if (who == Teller.MaleThoughts)
            {
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = $"[{story}]", Description = story, Group = currentGroup, Queue = currentQueue, S = fs, T = tran, O = "0",  R = "3" });
            }
            else if (who == Teller.Author)
            {
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = $"[{story}]", Description = story, Group = currentGroup, Queue = currentQueue, S = fs, T = tran, O = "0", R = "3" });
            }
        }
        protected void MakeNextCadre(Teller who, string story)
        {
            MakeNextCadre(who, null, story);
        }
        protected void MakeNextCadre(Teller who, int? fontSize, string story)
        {
            //Layers.ForEach(x =>
            //{                
            //    if (x.Kind == 0)
            //    {
            //        x.S = FCurrentPosition.S;
            //        x.Y = FCurrentPosition.Y;
            //        x.X = FCurrentPosition.X;
            //    }
            //});
            AddScenes(Layers, 1, false); 
            if (!string.IsNullOrEmpty(story))                        
                AddText(story, who, false, false);
            Layers = ResetPosture(Layers);
            IncrementGroup();
        }
        protected List<Info_Scene> ResetPosture(List<Info_Scene> posture)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            foreach (var item in posture)
            {
                var d = Info_Scene.GenerateCopy(item);
                d.T = null;
                result.Add(d);
            }
            return result;
        }


        // MAIN! Miving story AHEAD
        public List<Info_Scene> GoForwardStory(CadreController proc, int lastgrouId)
        {
            List<Info_Scene> result = null;
            var grupedlist = GetGroupedList();
            if (lastgrouId > grupedlist.Count() - 1)
            {
                GenerateNewStoryStep(proc);
            }
            result = ShowReneratedStep(lastgrouId);               
            return result;
        }
        private List<Info_Scene> ShowReneratedStep(int lastgrouId)
        {
            var grupedlist = GetGroupedList();
            //lastgrouId++;
            var last = grupedlist[lastgrouId].Select(x => x).ToList();
            if (!last.First().Active)
            {
                last.ForEach(x => x.Active = true);
            }
            return last;
        }
        protected virtual void GenerateNewStoryStep(CadreController proc)
        {
            var MenuCreator = GetMenuCreator(true);
            if (MenuCreator != null)
            {
                MenuCreator(proc, true, null, MenuType.Cell, false); // change last argument to default
            }
        }

        // MENU
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
                MenuDescriptopnItem mdi1 = new MenuDescriptopnItem(" ", it.First().Description, true);                
                item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
                item.Executor = data =>
                {
                   // proc.MenuCreator = proc.OldMenuCreator;
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
        public bool ShowSubmenu(CadreController proc, List<ChoiceMenuItem> itemlist, string caption)
        {
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }




    }
}
