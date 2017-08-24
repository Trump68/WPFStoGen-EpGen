using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Elements
{
    public class ScenCadre
    {
        public string Description { set; get; }
        public List<ScenElement> VisionList = new List<ScenElement>();
        public List<ScenElement> SoundList = new List<ScenElement>();
        public List<ScenElement> TextList = new List<ScenElement>();

        internal IEnumerable<string> GetTemplate()
        {
            List<string> result = new List<string>();
            result.Add("PartSta#"+ Description);
            result.Add("PartEnd#");
            return result;
            
        }
    }
}
