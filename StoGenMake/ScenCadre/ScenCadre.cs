using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;

namespace StoGenMake.Elements
{
    public class ScenCadre
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public List<ScenElementImage> VisionList = new List<ScenElementImage>();
        public List<ScenElementSound> SoundList = new List<ScenElementSound>();
        public List<ScenElementText> TextList = new List<ScenElementText>();
        protected BaseScene Owner;

        public ScenCadre(BaseScene owner)
        {
            this.Owner = owner;
        }

        internal virtual IEnumerable<string> GetTemplate()
        {
            List<string> result = new List<string>();
            return result;
        }
        public virtual List<string> GetCadreData()
        {
            return new List<string>();
        }
    }
}
