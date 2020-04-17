using StoGen.Classes.Scene;
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
        public static void MakeStory(string dir, string name)
        {
            Location.InitDefaultLocations();
            //Location.TestSave(Path.Combine(dir, "LocationList.txt"));
            Location.LoadFromFile(Path.Combine(dir, "LocationList.txt"));

            //Sound.TestSave(Path.Combine(dir, "SoundList.txt"));
            Sound.LoadFromFile(Path.Combine(dir, "SoundList.txt"));

            //Person.TestSave(Path.Combine(dir, "PersonList.txt"));
            //Person.LoadFromFile(Path.Combine(dir, "PersonList.txt"));

            MakeScenario(dir, name);
        }

        private static void MakeScenario(string dir, string name)
        {
            string rawparameters = @"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=30;DefFontColor=White;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";

            SCENARIO Scenario = new SCENARIO();
            Scenario.Name = name;
            Scenario.FileName = name;
            Scenario.RawParameters = rawparameters;
            

            Story001 story = new Story001();
            //StoryTest story = new StoryTest();
            
            story.Generate(Scenario, "001", "0001.001.001");


            Scenario.SaveToFile(dir, null);
        }

    
    }
}
