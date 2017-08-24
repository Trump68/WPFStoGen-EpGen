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
        public BaseScene()
        {
            InitCadres();
        }
        public void SaveTemplate(string savepath)
        {
            List<string> template = GetTemplate();
            string fn = Path.Combine(savepath, Name + ".tmpl");            
            File.WriteAllText(fn, string.Join(Environment.NewLine,template.ToArray()));
        }
        protected virtual List<string> GetTemplate()
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
        public virtual void InitCadres()
        {

        }

    }
}
