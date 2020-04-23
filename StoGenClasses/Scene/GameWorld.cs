using StoGen.Classes;
using StoGen.Classes.Interfaces;
using System.Collections.Generic;
using StoGenMake.Scenes.Base;
using StoGenMake.Elements;
using StoGenMake.Scenes;
using StoGen.Classes.Data;
using StoGen.Classes.Data.Games;
using StoGen.Classes.Data.Movie;
using System;

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

        //public static BaseScene GetScene(List<CombinedSceneInfo> infolist)
        //{
        //    Scene_Game scene = new Scene_Game();
        //    scene.SetInfo(infolist);
        //    return scene;
        //}
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

            //this.SceneList.Add(new AUX01_Accesuar());
            //this.SceneList.Add(new SC000_Various());
            //this.SceneList.Add(new SC000_TestTran());
            //this.SceneList.Add(new SC002_IlyaKuvshinov());
            //this.SceneList.Add(new SC001_FoolsArt());
            //this.SceneList.Add(new SC007_CleMasahiro());
            //this.SceneList.Add(new SC009_Hews_Hack());
            //this.SceneList.Add(new SC010_OyariAshito());
            //this.SceneList.Add(new SC011_HCG());

            ////this.SceneList.Add(new A001_Woman());
            //this.SceneList.Add(new SILKYS_SAKURA_OttoNoInuMaNi());
            //this.SceneList.Add(new _2011_USA_SRL_Homeland());


        }


        #region Menu
        public bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            if (itemlist == null)
                itemlist = new List<ChoiceMenuItem>();
            proc.OldMenuCreator = this.CreateMenu;
            ChoiceMenuItem item = null;



            // Меню scenes
            item = new ChoiceMenuItem("Scenes ...", this);
            item.Executor = data =>
            {
                //proc.MenuCreator = CreateMenuScenes;
                proc.ShowContextMenu(true, Data);
            };
            itemlist.Add(item);

            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, false,"Global menu");
            return true;
        }
       
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
