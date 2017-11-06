using StoGen.Classes;
using StoGen.Classes.Interfaces;
using System.Collections.Generic;
using StoGenMake.Scenes.Base;
using StoGenMake.Elements;
using StoGenMake.Scenes;
using StoGen.Classes.Data;
using StoGen.Classes.Data.Games;

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
    public class GameWorld : IMenuCreator
    {
        // !!! new engine
        public static List<ImageAlignVec> ImageStorage = new List<ImageAlignVec>();
        // !!! new engine

        
        public List<BaseScene> SceneList { get; internal set; }
        


        public GameWorld()
        {
            this.SceneList = new List<BaseScene>();
        }
        public void LoadData()
        {

            this.SceneList.Add(new AUX01_Accesuar());
            this.SceneList.Add(new SC000_Various());
            this.SceneList.Add(new SC000_TestTran());
            this.SceneList.Add(new SC002_IlyaKuvshinov());
            this.SceneList.Add(new SC001_FoolsArt());
            this.SceneList.Add(new SC007_CleMasahiro());
            this.SceneList.Add(new SC009_Hews_Hack());
            this.SceneList.Add(new SC010_OyariAshito());
            this.SceneList.Add(new SC011_HCG());

            this.SceneList.Add(new A001_Woman());
            this.SceneList.Add(new SILKYS_SAKURA_OttoNoInuMaNi());
            //this.PersoneList.Add(new LADY_011017());


        }


        #region Menu
        public bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            if (itemlist == null)
                itemlist = new List<ChoiceMenuItem>();
            proc.OldMenuCreator = this.CreateMenu;
            ChoiceMenuItem item = null;

            // Если есть CurrentPersone - создаем его меню
            //if (CurrentPersone != null)
            //{
            //    item = new ChoiceMenuItem($"{CurrentPersone.Name}...", this);
            //    item.Executor = data =>
            //    {
            //        proc.MenuCreator = CurrentPersone.CreateMenuPersone;
            //        proc.ShowContextMenu(true,Data);
            //    };
            //    itemlist.Add(item);
            //}

            //// Меню вызова досье
            //item = new ChoiceMenuItem("Досье ...", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuDosie;
            //    proc.ShowContextMenu(true, Data);
            //};
            //itemlist.Add(item);


            //// Меню перемещения по локациям
            //item = new ChoiceMenuItem("Переместиться ...", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuRelocation;
            //    proc.ShowContextMenu(true, Data);
            //};
            //itemlist.Add(item);

            // Меню scenes
            item = new ChoiceMenuItem("Scenes ...", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuScenes;
                proc.ShowContextMenu(true, Data);
            };
            itemlist.Add(item);

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, false);
            return true;
        }
        //private bool CreateMenuRelocation(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    ChoiceMenuItem item = null;

        //    foreach (var loc in LocationList)
        //    {
        //        item = new ChoiceMenuItem();
        //        item.Name = loc.Name;
        //        item.itemData = this;
        //        item.Executor = data =>
        //        {
        //            proc.MenuCreator = loc.CreateMenuLocationDocier;
        //            proc.ShowContextMenu(doShowMenu, Data);
        //        };
        //        itemlist.Add(item);
        //    }

        //    ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
        //    return true;
        //}
        private bool CreateMenuScenes(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            foreach (var scene in this.SceneList)
            {
                item = new ChoiceMenuItem();
                item.Name = scene.Name;
                item.itemData = this;
                item.Executor = data =>
                {
                    proc.MenuCreator = scene.CreateMenuScene;
                    proc.ShowContextMenu(doShowMenu, Data);
                };
                itemlist.Add(item);
            }

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
            return true;
        }
        //private bool CreateMenuDosie(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    ChoiceMenuItem item = null;


        //    foreach (var it in Enum.GetValues(typeof(VNPCPersType)))
        //    {
        //        item = new ChoiceMenuItem();
        //        item.Name = Enum.GetName(typeof(VNPCPersType), it);
        //        item.itemData = it;
        //        item.Executor = data =>
        //        {
        //            proc.MenuCreatorData = data;
        //            proc.MenuCreator = this.CreateMenuDocierForType;
        //            proc.ShowContextMenu(doShowMenu,Data);
        //        };
        //        itemlist.Add(item);
        //    }


        //    ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
        //    return true;
        //}
        //private bool CreateMenuDocierForType(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    ChoiceMenuItem item = null;

        //    foreach (var pers in PersoneList.Where(x => x.PersonType == (VNPCPersType)proc.MenuCreatorData))
        //    {
        //        item = new ChoiceMenuItem();
        //        item.Name = pers.Name;
        //        item.itemData = this;
        //        item.Executor = data =>
        //        {
        //            proc.MenuCreator = pers.CreateMenuPersoneDocier;
        //            proc.ShowContextMenu(doShowMenu, Data);
        //        };
        //        itemlist.Add(item);
        //    }

        //    ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true);
        //    return true;
        //}

        #endregion

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
  
    public class CadreAlignPack
    {
        public List<AlignData> AlignList = new List<AlignData>();
        public List<string> MarkList = new List<string>();
        

        public CadreAlignPack(AlignData[] alignlist)
        {
            AlignList.AddRange(alignlist);
        }

        public CadreAlignPack(AlignData[] alignlist, string[] marklist)
        {
            AlignList.AddRange(alignlist);
            MarkList.AddRange(marklist);
        }
    }
}
