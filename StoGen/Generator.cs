﻿using StoGen.Classes.Scene;
using StoGenerator.Stories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{
    public static class Generator
    {
        public static string MakeScenario(string dir, string storyname)
        {

            StoryBase story = null;
            if (string.IsNullOrEmpty(storyname))
                story = new Works_Horikawa_Gorou(); //default

            else if(storyname == Works_Momofuki_Rio.StoryName)
                story = new Works_Momofuki_Rio();
            else if (storyname == Works_Horikawa_Gorou.StoryName)
                story = new Works_Horikawa_Gorou();
            else if (storyname == Story001.StoryName)
                story = new Story001();
            else if (storyname == Person_Jenny_Ford.StoryName)
                story = new Person_Jenny_Ford();


            if (story != null)
            {
                Location.InitDefaultLocations();
                Sound.InitDefaultSounds();
                story.Generate("001", "0001.001.001");
                story.SaveToFile(dir, Path.Combine(dir, $"TMP"));
                return story.FileName;
            }
            return null;
        }


    }
}
