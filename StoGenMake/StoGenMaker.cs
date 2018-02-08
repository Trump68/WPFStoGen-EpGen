using StoGen.Classes;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.IO;
using StoGenMake.Pers;
using StoGen.Classes.Data.Games;
using StoGen.Classes.Data.Movie;

namespace StoGenMake
{
    public static class StoGenMaker
    {
        static List<BaseScene> SceneList = new List<BaseScene>();
        public static void Start(string[] args)
        {
            //GenerateScen();
            GetScene(@"d:\uTorrent\ToConvert\ADN-051.avi", "E82608F1-2DA5-4D4C-ADE7-60E562D8557D", null);
        }
        private static void GetScene(string path, string filter, string par)
        {
            GameWorldFactory.GameWorld.LoadData();


            BaseScene scene = null;
            if (filter == "E82608F1-2DA5-4D4C-ADE7-60E562D8557D")
            {
                scene = new _JAV_Common(filter,path);                
                scene.Generate(filter);
            }

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            window.Scene = scene;
            window.Show();

        }
        private static void GenerateScen()
        {

            GameWorldFactory.GameWorld.LoadData();
            //var scen = new SC001_FoolsArt();
            //  var scen = new SC000_TestTran();
            //var scen = new SC002_IlyaKuvshinov();
            //var scen = new TestScene();
            //var scen = new SC007_CleMasahiro();
            //var scen = new A001_Woman();
            //var scen = new SILKYS_SAKURA_OttoNoInuMaNi();
            // var scen = new _2011_USA_SRL_Homeland();
            //var scen = new _ALL__Mainstream();
            //var scen = new _ALL__WEB();
            //var scen = new _All__USA__PlayerHomeVideo();
            var scen = new _ALL__Asian(null,null);
            //var scen = new _ERO__Best();
            string fn = scen.Generate();

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            //window.Startfile = fn;
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            
            window.Scene = scen;
            window.Show();


        }
    }
}
