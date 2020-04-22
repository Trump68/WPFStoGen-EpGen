using StoGen.Classes;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.IO;
using StoGen.Classes.Data.Games;
using StoGen.Classes.Data.Movie;
using System.Linq;
using System.Windows;
using StoGen.Classes.Scene;
using StoGen.ModelClasses;

namespace StoGenMake
{
    public static class StoGenMaker
    {
        static List<BaseScene> SceneList = new List<BaseScene>();
        static bool ExitOnComplete = false;
        public static void Start(string[] args)
        {
            //GenerateScen();
            if (args.Length > 1)
            {
                ExitOnComplete = true;
                string file = args[1];
                
                string extension = Path.GetExtension(file);
                if (extension == ".epcatci")
                {
                    List<string> clipsinstr = new List<string>(File.ReadAllLines(file));
                    List<Info_Clip> clips = new List<Info_Clip>();
                    foreach (var item in clipsinstr)
                    {
                        clips.Add(Info_Clip.GenerateFromString(item));
                    }
                    StoGenWPF.MainWindow.ReadIni(file);
                    GetScene(clips, null);
                }
                else if (extension == ".epcatsi")
                {
                    List<string> clipsinstr = new List<string>(File.ReadAllLines(file));
                    SCENARIO scenario = new SCENARIO();
                    scenario.GamePath = Path.GetDirectoryName(file);
                    scenario.LoadFrom(clipsinstr);
                    StoGenWPF.MainWindow.ReadIni(file);
                    GetScene(null, scenario);
                }
                else if (extension == ".epcatsz")
                {
                    SCENARIO scenario = new SCENARIO();
                    scenario.LoadFromZip(file);
                    StoGenWPF.MainWindow.ReadIni(file);
                    GetScene(null, scenario);
                }
            }
            
        }
      
        private static void GetScene(List<Info_Clip> clips, SCENARIO scenario)
        {
            GameWorldFactory.GameWorld.LoadData();
            BaseScene scene = null;
            if (clips != null)
            {
                scene = new Scene_Clips();
                scene.LoadData(clips);
            }
            else if (scenario != null)
            {
                scene = new Scene_Combo();
                ((Scene_Combo)scene).SetScenario(scenario, scenario.SceneInfoList[0].Queue);
            }

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            Projector.ProjectorWindow = window;
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            window.Scene = scene;
            window.Show();
            window.IsVisibleChanged += Window_IsVisibleChanged;

        }

        private static void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ExitOnComplete)
            {
                StoGenWPF.MainWindow.Stop();
                Application.Current.Shutdown();
            }
                
            //Environment.Exit(0)
        }

        private static void Window_Closed(object sender, System.EventArgs e)
        {
           
            
        }

        //private static void GenerateScen()
        //{

        //    GameWorldFactory.GameWorld.LoadData();
        //    //var scen = new SC001_FoolsArt();
        //    //  var scen = new SC000_TestTran();
        //    //var scen = new SC002_IlyaKuvshinov();
        //    //var scen = new TestScene();
        //    //var scen = new SC007_CleMasahiro();
        //    //var scen = new A001_Woman();
        //    //var scen = new SILKYS_SAKURA_OttoNoInuMaNi();
        //    // var scen = new _2011_USA_SRL_Homeland();
        //    //var scen = new _ALL__Mainstream();
        //    //var scen = new _ALL__WEB();
        //    //var scen = new _All__USA__PlayerHomeVideo();
        //    //var scen = new _ALL__Asian();
        //    //var scen = new _ERO__Best();
        //    //string fn = scen.Generate();

        //    StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
        //    //window.Startfile = fn;
        //    window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            
        //    window.Scene = scen;
        //    window.Show();


        //}
    }
}
