using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;
using System.IO;

namespace StoGenMake.Scenes.Base
{
    public class BaseScene
    {
        public int SizeX = 800;
        public int SizeY = 600;
        public int X = 300;
        public int Y = 0;

        public BaseScene()
        {
            InitCadres();
        }
        public void SaveTemplate(string savepath)
        {
            List<string> template = GetTemplate();
            if (!Directory.Exists(Path.Combine(savepath, Name))) Directory.CreateDirectory(Path.Combine(savepath, Name));
            string fn = Path.Combine(savepath, Name, Name + ".tmpl");            
            File.WriteAllText(fn, string.Join(Environment.NewLine,template.ToArray()));
        }
        public virtual List<string> GetTemplate()
        {
            List<string> result  = new List<string>();
            foreach (var item in this.Cadres)
            {
                result.AddRange(item.GetTemplate());
            }
            return result;
        }
        public string Description { get; set; }
        public string Name { get; set; }
        protected List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();
        public string FileToProcess = null;
        public virtual void InitCadres()
        {

        }


        internal void Generate(string fileToProcess)
        {            
            List<string> scendata = GetSceneData();

            FileToProcess = fileToProcess;

            string fn = @".\Templates\"+this.Name +@"\"+ this.Name + ".stogen";
            if (!string.IsNullOrEmpty(FileToProcess))
            {
                string newfn = Path.GetFileNameWithoutExtension(FileToProcess) + ".stogen";
                string savepath = Path.GetDirectoryName(FileToProcess);
                fn = Path.Combine(savepath, newfn);
            }

            File.WriteAllText(fn, string.Join(Environment.NewLine, scendata.ToArray()));
        }

        public virtual List<string> GetSceneData()
        {
            return new List<string>();
        }
    }
}
