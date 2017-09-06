using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;
using System.IO;
using StoGenLife.NPC;

namespace StoGenMake.Scenes.Base
{
   
    public class BaseScene
    {
        public List<SceneVariable> Variables = new List<SceneVariable>();

        public int SizeX = 800;
        public int SizeY = 600;
        public int X = 300;
        public int Y = 0;
        private int Version = 0;
        public BaseScene()
        {
            InitCadres();
        }
        public void SaveTemplate(string savepath)
        {
            List<string> template = GetTemplate();
            if (!Directory.Exists(Path.Combine(savepath, Name))) Directory.CreateDirectory(Path.Combine(savepath, Name));
            string fn = Path.Combine(savepath, Name, Name + ".tmpl");
            File.WriteAllText(fn, string.Join(Environment.NewLine, template.ToArray()));
        }
        public virtual List<string> GetTemplate()
        {
            List<string> result = new List<string>();
            result.Add($"SCEN {this.Name}");
            result.Add($"SCENDATA Ver={this.Version}; Location={this.X},{this.Y},{this.SizeX},{this.SizeY}");
            result.Add($"//===========================//");
            foreach (var item in this.Variables)
            {
                result.Add($"//{item.Description}");
                result.Add($"{item.Type.PadRight(10)};{item.Name.PadRight(50)};{item.Value}");
            }

            return result;
        }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();
        

        public string FileToProcess = null;
        public virtual void InitCadres()
        {
            this.Cadres.ForEach(x => x.InitValuesFromScene());
        }


        internal string Generate(List<string> datalist, string fileToProcess)
        {
            FileToProcess = fileToProcess;
            SetSceneData(datalist);

            string fnScenario = @".\Templates\" + this.Name + @"\" + this.Name + ".stogen";            
            if (!string.IsNullOrEmpty(FileToProcess))
            {
                string newfnScenario = Path.GetFileNameWithoutExtension(FileToProcess) + ".stogen";
                string savepath = Path.GetDirectoryName(FileToProcess);
                fnScenario = Path.Combine(savepath, newfnScenario);
            }


            List<string> scendata = new List<string>();
            foreach (var item in this.Cadres)
            {
                item.InitValuesFromScene();
                int i = 0;
                if (item.IsActivated)
                {
                    var cadredata = item.GetCadreData();
                    if (!string.IsNullOrEmpty(FileToProcess))
                    {
                        string newfnCadre = i.ToString("000")+"_"+item.Name+ ".stogen";
                        string savepathCadre = Path.GetDirectoryName(FileToProcess) + @"\Cadres\";
                        if (!Directory.Exists(savepathCadre)) Directory.CreateDirectory(savepathCadre);
                        string fnCadre = Path.Combine(savepathCadre, newfnCadre);
                        File.WriteAllText(fnCadre, string.Join(Environment.NewLine, cadredata.ToArray()));
                    }                    
                    scendata.AddRange(cadredata);
                }
            }

            

            File.WriteAllText(fnScenario, string.Join(Environment.NewLine, scendata.ToArray()));
            return fnScenario;
        }

        public virtual void SetSceneData(List<string> scendata)
        {
            List<string> result = new List<string>();
            if (scendata != null)
            {
                SetSceneCommonDats(scendata);
                
                foreach (var item in scendata)
                {
                    string[] vals = item.Split(';');
                    var val = this.Variables.Where(x => x.Type == vals[0].Trim() && x.Name == vals[1].Trim()).FirstOrDefault();
                    if (val != null) val.Value = vals[2].Trim();
                }
            }                       
        }

        private void SetSceneCommonDats(List<string> scendata)
        {
            if (scendata == null) return;
            List<string> datastr = scendata.Where(x => x.StartsWith(@"SCENDATA ")).ToList();
            if (datastr != null)
            {
                scendata.RemoveAll(x => x.StartsWith(@"SCENDATA "));
                List<string> vals = datastr.First().Split(';').ToList();
                foreach (var item in vals)
                {
                    if (item.Trim().StartsWith("Location"))
                    {
                        var vals2 = item.Split('=');
                        string[] items = vals2[1].Split(',');
                        this.X = int.Parse(items[0]);
                        this.Y = int.Parse(items[1]);
                        this.SizeX = int.Parse(items[2]);
                        this.SizeY = int.Parse(items[3]);
                    }                    
                }
            }

            //datastr = scendata.Where(x => x.StartsWith(@"SCENPERS ")).ToList();
            //if (datastr != null && datastr.Any())
            //{
                
            //    scendata.RemoveAll(x => x.StartsWith(@"SCENPERS "));
            //    List<string> vals = datastr.First().Replace(@"SCENPERS ",string.Empty).Split(';').ToList();
            //    foreach (var item in vals)
            //    {
            //        if (item.Trim().StartsWith("NPC"))
            //        {
            //            var vals2 = item.Split('=');
            //            string[] items = vals2[1].Split(',');
            //            foreach (var pers in items)
            //            {
            //                Guid gid = Guid.Parse(pers);
            //                var persona = StoGenMaker.NPCList.Where(x => x.GID.Equals(gid)).FirstOrDefault();
            //                if (persona != null)
            //                {
            //                    this.NPCList.Add(persona);
            //                }
            //            }
            //        }
            //    }

            //}
        }
    }
    public class SceneVariable
    {
        public string Type;
        public string Name;
        public string Description;
        public string Value;
        public SceneVariable(string type, string name, string val, string desc)
        {
            Type = type;
            Name = name;
            Description = desc;
            Value = val;
        }
    }
}
