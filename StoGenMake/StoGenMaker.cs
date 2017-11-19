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
            GenerateScen();
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
            var scen = new _2011_USA_SRL_Homeland();

            string fn = scen.Generate();

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            //window.Startfile = fn;
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            
            window.Scene = scen;
            window.Show();


        }
    }
}
