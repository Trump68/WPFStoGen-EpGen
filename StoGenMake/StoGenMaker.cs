﻿using StoGen.Classes;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.IO;
using StoGenMake.Pers;
using StoGen.Classes.Data.Games;

namespace StoGenMake
{
    public static class StoGenMaker
    {
        //static string ExecDir;
        //static string TemplateDirName = "Templates";
        //static KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        static List<BaseScene> SceneList = new List<BaseScene>();
        //static string FileToProcess = null;
        //static string TemplateDirPath { get { return Path.Combine(ExecDir, TemplateDirName); } }
        public static void Start(string[] args)
        {

            //ExecDir = Path.GetDirectoryName(args[0]);
            //if (!Directory.Exists(TemplateDirPath)) Directory.CreateDirectory(TemplateDirPath);
            //if (args.Length > 1)
            //{
            //    FileToProcess = args[1];
            //}
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
            var scen = new SILKYS_SAKURA_OttoNoInuMaNi();

            string fn = scen.Generate();

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            //window.Startfile = fn;
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            
            window.Scene = scen;
            window.Show();


        }
    }
}
