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
using StoGenMake.Scenes.Base;
using StoGenMake.Scenes;
using StoGenMake.Elements;

namespace StoGenMake
{
    public static class GameWorldFactory
    {
        private static GameWorld _GameWorld;
        public static GameWorld GameWorld
        {
            get
            {
                if (_GameWorld == null)
                {
                    _GameWorld = new GameWorld();
                }
                return _GameWorld;
            }
        }
    }
    public class GameWorld: IMenuCreator
    {
        public List<VNPC>          PersoneList  { get; internal set; }
        public List<seIm>          CommonImageList { get; internal set; }
       
        public List<AlignDif> AlignList { get; internal set; }
        public List<VisualLocaton> LocationList { get; internal set; }
        public List<BaseScene> SceneList { get; internal set; }
        public VNPC CurrentPersone { get; internal set; }
        

        public GameWorld()
        {
           
            this.PersoneList  = new List<VNPC>();
            this.CommonImageList = new List<seIm>();
            this.AlignList = new List<AlignDif>();

            this.LocationList = new List<VisualLocaton>();
            this.SceneList = new List<BaseScene>();

            GameWorldDataLoader.LoadPersList(this.PersoneList);
            GameWorldDataLoader.LoadFemHeadList(this.CommonImageList, this.AlignList);
            GameWorldDataLoader.LoadFemBodyList(this.CommonImageList);
            GameWorldDataLoader.LoadManBodyList(this.CommonImageList);
            GameWorldDataLoader.LoadManHeadList(this.CommonImageList);


            //Hara Shigeyuki
            Hara_Shigeyuki.LoadData(this.CommonImageList, this.AlignList);
            //Fools Art Gallery Homare
            Fools_Art_Homare.LoadData(this.CommonImageList, this.AlignList);
            TestTran.LoadData(this.CommonImageList, this.AlignList);

            this.PersoneList.Add(new LADY_011017 ());
            this.SceneList.Add(new TestScene());
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

            // Меню scenes
            item = new ChoiceMenuItem("Scenes ...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuScenes;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, false);
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

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        private bool CreateMenuScenes(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            foreach (var scene in this.SceneList)
            {
                item = new ChoiceMenuItem();
                item.Name = scene.Name;
                item.Data = this;
                item.Executor = data =>
                {
                    proc.MenuCreator = scene.CreateMenuScene;
                    proc.ShowContextMenu();
                };
                itemlist.Add(item);
            }

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        private bool CreateMenuDosie(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;


            foreach (var it in Enum.GetValues(typeof(VNPCPersType)))
            {
                item = new ChoiceMenuItem();
                item.Name = Enum.GetName(typeof(VNPCPersType), it);
                item.Data = it;
                item.Executor = data =>
                {
                    proc.MenuCreatorData = data;
                    proc.MenuCreator = this.CreateMenuDocierForType;
                    proc.ShowContextMenu();
                };
                itemlist.Add(item);
            }
           

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        private bool CreateMenuDocierForType(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            foreach (var pers in PersoneList.Where(x=>x.PersonType == (VNPCPersType)proc.MenuCreatorData))
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

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
    }
    public class AlignData
    {
        public string Parent;
        public string Name;
        public string Tag;
        public bool Processed = false;
        public DifData Im;
        public seIm Fact;
        public AlignData(string name) : this(name, null, null, null) { }
        public AlignData(string name, DifData im) : this(name, null, null, im) { }
        public AlignData(string name, string parent) : this(name, parent, null, null) { }
        public AlignData(string name, string parent, DifData im) : this(name, parent, null, im) { }
        public AlignData(string name, string parent, string tag, DifData im)
        {
            Parent = parent;
            Name = name;
            Tag = tag;
            Im = im;
        }
    }
    public class DifData
    {
        public bool relative = true;
        public DifData() { }
        public DifData(bool rel):this()
        {
            this.relative = rel;
        }
        public DifData(AlignData item):this()
        {
           this.Name = item.Name;
           this.Parent = item.Parent;
            if (item.Im != null)
            {
                this.X = item.Im.X;
                this.Y = item.Im.Y;
                this.sY = item.Im.sY;
                this.sX = item.Im.sX;
                this.Rot = item.Im.Rot;
                this.Flip = item.Im.Flip;
            }
            
        }

        public DifData(seIm item) : this()
        {
            this.Name = item.Name;
            
            this.X = item.X;
            this.Y = item.Y;
            this.sY = item.sY;
            this.sX = item.sX;
            this.Rot = item.Rot;
            this.Flip = item.Flip;
        }

        public string Name { set; get; }
        public string Parent { set; get; }
        public int? X { set; get; }
        public int? Y { set; get; }
        public int? sX { set; get; }
        public int? sY { set; get; }
        public int? Rot { set; get; }
        public int? Flip { set; get; }
    }


}
