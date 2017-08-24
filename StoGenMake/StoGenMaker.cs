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
        string TemplateDirPath { get { return Path.Combine(ExecDir, TemplateDirName); } }

        public StoGenMaker(string[] args)
        {
            ExecDir = Path.GetDirectoryName(args[0]);
            if (!Directory.Exists(TemplateDirPath)) Directory.CreateDirectory(TemplateDirPath);
        }

        public void Start()
        {
            FillScenes();
            SaveTemplates();
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
