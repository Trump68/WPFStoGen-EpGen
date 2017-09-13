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
        public static List<VNPC> NPCList = new List<VNPC>();
       
        public static void Start(string[] args)
        {
            FillNPC();
            ExecDir = Path.GetDirectoryName(args[0]);
            if (!Directory.Exists(TemplateDirPath)) Directory.CreateDirectory(TemplateDirPath);
            if (args.Length > 1)
            {
                FileToProcess = args[1];
            }        
            //SaveTemplates();            
            GenerateScen(FileToProcess);          
        }       
        private static void FillNPC()
        {
            VNPC pers = new PERS01();            
            NPCList.Add(pers);
        }


        private static void GenerateScen(string fileToProcess)
        {
            VNPC pers = null;
            List<string> datalist = new List<string>();
            if (!string.IsNullOrEmpty(fileToProcess))
            {
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
                        pers = NPCList.FirstOrDefault(x => x.GID.Equals(gid));
                        datalist.RemoveAll(x => x.StartsWith(@"SCENPERS "));
                   }
            }
            if (pers != null)
            {
                pers.SetPersVariablesData(datalist);
                pers.PrepareScene();

                string fn = pers.Generate(fileToProcess);
                StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
                window.Startfile = fn;
                window.Show();
                //System.Diagnostics.Process.Start(fn);
            }
            else
            {
               // SceneList.ForEach(x => x.Generate(null,null));
            }
        }
        
        
        //static void  SaveTemplates()
        //{
        //    SceneList.ForEach(x => x.SaveTemplate(TemplateDirPath));
        //}

    }
}
