using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Scene
{
    public class SceneMaker
    {
        public string Name;
        protected BaseScene Scene;
        public int Variant;
        public SceneMaker(BaseScene scene, string name)
        {
            this.Scene = scene;
            this.Name = name;
        }
        protected List<string> PartList = new List<string>();
        public virtual List<DifData> Get(DifData delta)
        {
            List<DifData> result = new List<DifData>();            
            return result;
        }
    }
}
