using EPCat.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{
    public static class Generator
    {
        //public static string MakeScenario(string dir, string storyname)
        //{

        //    StoryBase story = getScen(storyname);
        //    if (story != null)
        //    {
        //        LocationStorage.InitDefaultLocations();
        //        Sound.InitDefaultSounds();
        //        story.Generate("001", "0001.001.001");
        //        story.SaveToFile(dir, Path.Combine(dir, $"TMP"));
        //        return story.FileName;
        //    }
        //    return null;
        //}
        public static string MakeScenario(EpItem item)
        {
            if (item.Kind == null) return null;
            StoryBase story = null;
            if (item.Kind.Trim() == "STOGEN-ART")
            {
               // story = new ArtGenerator(item);
            }
            else
            {
                story = getScen(item.Name);
            }
            if (story != null)
            {
                LocationStorage.InitDefaultLocations();
                Sound.InitDefaultSounds();
                story.Generate("001", "0001.001.001");
                story.SaveToFile(item.ItemDirectory, item.ItemTempDirectory);
                return story.FileName;
            }
            return null;
        }
        public static StoryBase LoadScenario(List<string> clipsinstr, EpItem item, string filename = null)
        {
            StoryBase story = new StoryBase();

            story.LoadFrom(clipsinstr);            
            if (!string.IsNullOrEmpty(filename))
            {
                story.FullFileName = filename;
                story.FileName = Path.GetFileNameWithoutExtension(filename);
            }
            return story;
        }

        private static StoryBase getScen(string storyname)
        {
            StoryBase story = null;
           
            return story;
        }

    }
}
