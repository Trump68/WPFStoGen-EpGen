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
    public class StoGenMaker
    {
        string ExecDir;
        string TemplateDirName = "Templates";
        KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        List<BaseScene> SceneList = new List<BaseScene>();
        string FileToProcess = null;
        string TemplateDirPath { get { return Path.Combine(ExecDir, TemplateDirName); } }

        public StoGenMaker(string[] args)
        {
            ExecDir = Path.GetDirectoryName(args[0]);
            if (!Directory.Exists(TemplateDirPath)) Directory.CreateDirectory(TemplateDirPath);
            if (args.Length > 1)
            {
                FileToProcess = args[1];
            }
        }

        public void Start()
        {
            FillScenes();
            SaveTemplates();            
            GenerateScen(FileToProcess);          
        }

        private void GenerateScen(string fileToProcess)
        {
            SceneList.ForEach(x => x.Generate(fileToProcess));
        }

        void FillScenes()
        {
            SceneList.Add(new Scene01());
        }
        void SaveTemplates()
        {
            SceneList.ForEach(x => x.SaveTemplate(TemplateDirPath));
        }

    }
}
