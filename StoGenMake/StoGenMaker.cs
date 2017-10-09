using StoGen.Classes;
using StoGenLife.NPC;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StoGenMake.Pers;

namespace StoGenMake
{
    public static class StoGenMaker
    {
        static string ExecDir;
        static string TemplateDirName = "Templates";
        static KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        static List<BaseScene> SceneList = new List<BaseScene>();
        static string FileToProcess = null;
        static string TemplateDirPath { get { return Path.Combine(ExecDir, TemplateDirName); } }
        public static void Start(string[] args)
        {

            ExecDir = Path.GetDirectoryName(args[0]);
            if (!Directory.Exists(TemplateDirPath)) Directory.CreateDirectory(TemplateDirPath);
            if (args.Length > 1)
            {
                FileToProcess = args[1];
            }
            GenerateScen(FileToProcess);
        }
        private static void GenerateScen(string fileToProcess)
        {
            
            VNPC pers = null;
            
            if (!string.IsNullOrEmpty(fileToProcess) && File.Exists(fileToProcess))
            {
                List<string> datalist = new List<string>();
                List<string> header;
                // найти сценарий и ему передать
                datalist = Universe.LoadFileToStringList(fileToProcess);
                datalist.ForEach(x => x.Trim());
                datalist.RemoveAll(x => x.StartsWith(@"//"));


                string persName = datalist.FirstOrDefault(x => x.StartsWith(@"SCENPERS "));
                if (!string.IsNullOrEmpty(persName))
                {
                    persName = persName.Replace(@"SCENPERS ", string.Empty).Replace(@"NPC=", string.Empty);
                    Guid gid = Guid.Parse(persName.Trim());
                    var dd = GameWorldFactory.GameWorld.PersoneList;
                    var d = dd.FirstOrDefault(x => x.GID.Equals(gid));
                    pers = GameWorldFactory.GameWorld.PersoneList.FirstOrDefault(x => x.GID.Equals(gid));
                    datalist.RemoveAll(x => x.StartsWith(@"SCENPERS "));
                }
            }

            //var scen = new BaseScene();
            //if (pers != null)
            //{
            //    scen.AddActor(pers);
            //    GameWorldFactory.GameWorld.CurrentPersone = pers;
            //}            
            var scen = new Fools_Art_Homare();

            string fn = scen.Generate(fileToProcess);

            StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            window.Startfile = fn;
            window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            window.Show();


        }
    }
}
