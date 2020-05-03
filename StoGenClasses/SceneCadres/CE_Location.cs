using StoGen.Classes;
using StoGen.Classes.SceneCadres.CadreElements;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.CadreElements
{
    public class CE_Location
    {
        public static List<Info_Scene> Get(string name, string spec)
        {
            List<Info_Scene> result = new List<Info_Scene>();
            var item = LocationStorage.GetByName(name, spec, StoryBase.currentQueue, StoryBase.currentGroup); 
            if (item == null)
                item = LocationStorage.GetByName(name, "day", StoryBase.currentQueue, StoryBase.currentGroup);
            if (item == null)
                item = LocationStorage.GetByName(name, null, StoryBase.currentQueue, StoryBase.currentGroup);
            if (item != null)
            {
                item.Z = "0";
                item.O = "0";
                item.T = Trans.Appearing(1000);
                result.Add(item);
            }
            return result;
        }
        public static List<Info_Scene> Add(StoryBase story,string name, string spec)
        {
            List<Info_Scene> infos = new List<Info_Scene>();
            infos.AddRange(CE_Location.Get(name, spec));
            story.AddScenes(infos,1,false);
            story.IncrementGroup();
            return infos;
        }
        public static List<Info_Scene> Get(List<Info_Scene> posture, string name, string spec)
        {
            if (posture == null)
                posture = new List<Info_Scene>();
            posture.AddRange(CE_Location.Get(name, spec));
            return posture;
        }
        public static List<Info_Scene> AddWithMusic(StoryBase story, string name, string spec, string musicname, string musicspec)
        {
            List<Info_Scene> infos = new List<Info_Scene>();
            infos.AddRange(CE_Location.Get(name, spec));
            infos.AddRange(CE_Music.Get(musicname, musicspec));
            story.AddScenes(infos,1, false);
            story.IncrementGroup();
            return infos;
        }

    }
}
