using StoGen.Classes;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            FillScenes();
            SaveTemplates();            
            GenerateScen(FileToProcess);          
        }

        private static void GenerateScen(string fileToProcess)
        {
            BaseScene scene = null;
            List<string> datalist = new List<string>();
            if (!string.IsNullOrEmpty(fileToProcess))
            {
                List<string> header;
                //StoGenParser.GetProcessedFile(fileToProcess, null, KeyVarContainer, null, out header);

                
                // найти сценарий и ему передать
                datalist = Universe.LoadFileToStringList(fileToProcess);
                datalist.ForEach(x => x.Trim());
                datalist.RemoveAll(x => x.StartsWith(@"//"));
                string scenName = datalist.FirstOrDefault(x => x.StartsWith(@"SCEN "));
                if (!string.IsNullOrEmpty(scenName))
                {
                    scenName = scenName.Replace(@"SCEN ", string.Empty);
                    scene = SceneList.FirstOrDefault(x => x.Name == scenName);
                }
            }
            if (scene != null)
            {
                scene.Generate(datalist, fileToProcess);
            }
            else
            {
                SceneList.ForEach(x => x.Generate(null,null));
            }
        }
        
        static void FillScenes()
        {
            SceneList.Add(new Scene01());
        }
        static void  SaveTemplates()
        {
            SceneList.ForEach(x => x.SaveTemplate(TemplateDirPath));
        }

    }
}
