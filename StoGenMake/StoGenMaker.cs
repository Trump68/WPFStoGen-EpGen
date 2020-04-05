using StoGen.Classes;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.IO;
using StoGenMake.Pers;
using StoGen.Classes.Data.Games;
using StoGen.Classes.Data.Movie;
using System.Linq;

namespace StoGenMake
{
    public static class StoGenMaker
    {
        static List<BaseScene> SceneList = new List<BaseScene>();
        public static void Start(string[] args)
        {
            //GenerateScen();
            if (args.Length > 1)
            {
                string file = args[1];
                List<string> clipsinstr = new List<string>(File.ReadAllLines(file));
                List<MovieSceneInfo> clips = new List<MovieSceneInfo>();
                foreach (var item in clipsinstr)
                {
                    clips.Add(MovieSceneInfo.GenerateFromString(item));
                }
                GetScene(clips);
            }
            
        }
        private static void GetScene(List<MovieSceneInfo> clips)
        {
            GameWorldFactory.GameWorld.LoadData();
            _Clip_Default scene = null;
            scene = new _Clip_Default();
            scene.LoadData(clips);

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
            var scen = new _ALL__Asian();
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
