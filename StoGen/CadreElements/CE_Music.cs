using StoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.SceneCadres.CadreElements
{
    public class CE_Music 
    {
        public static List<Info_Scene> Get(string name, string spec)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            var item = Sound.GetByName(name, spec, StoryBase.currentQueue, StoryBase.currentGroup);
            if (item != null)
            {
                result.Add(item);
            }
            return result;
        }

    }
}
