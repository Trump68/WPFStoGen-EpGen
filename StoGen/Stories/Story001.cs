using StoGen.Classes;
using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class Story001: StoryBase
    {
        string rawparameters =
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=30;DefFontColor=Cyan;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";

        private string FPersonName;
        private Info_Scene FCurrentPosition = new Info_Scene();
        public void Generate(SCENARIO scenario, string queue, string group)
        {
            Scenario = scenario;
            currentGroup = group;
            currentQueue = queue;
            Scenario.RawParameters = rawparameters;
            Scenario.AssignRawParameters();

            Person.Load_JennyFord();
            FPersonName = "Jenny Ford";
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1000";
            FCurrentPosition.X = "800";
            FCurrentPosition.Y = "200";

            MakeLocationCadre("Apartment 001", "evening", "Печальная тема 01",null);
            MakeFirsCadre("0070","Наконец ты пришел! Заждалась!");
            MakeNextCadre("0070","0067", "Надеюсь, у тебя все хорошо.");

           
       
        }
        private void MakeFirsCadre(string fileum, string story)
        {
            Scenario.Scenes.Add(new Info_Scene(1) { Story = story, Group = currentGroup, Queue = currentQueue });

            var person = Person.GetByName(FPersonName, $"{fileum}", currentQueue, currentGroup);
            if (person != null)
            {
                    person.Z = FCurrentPosition.Z;
                    person.S = FCurrentPosition.S;
                    person.X = "2000";
                    person.Y = FCurrentPosition.Y;
                    person.O = "0";
                    person.T = "W..0>O.B.1500.100*W..0>X.B.1500.-1200";
                Scenario.Scenes.Add(person);
                IncrementGroup();
            }
        }
        private void MakeNextCadre(string prev, string next, string story)
        {
            Scenario.Scenes.Add(new Info_Scene(1) { Story = story, Group = currentGroup, Queue = currentQueue });

            var person = Person.GetByName(FPersonName, $"{next}", currentQueue, currentGroup);
            if (person != null)
            {
                person.Z = FCurrentPosition.Z;
                person.S = FCurrentPosition.S;
                person.X = FCurrentPosition.X;
                person.Y = FCurrentPosition.Y;
                Scenario.Scenes.Add(person);
            }
            person = Person.GetByName(FPersonName, $"{prev}", currentQueue, currentGroup);
            if (person != null)
            {
                person.Z = "2";
                person.S = FCurrentPosition.S;
                person.X = FCurrentPosition.X;
                person.Y = FCurrentPosition.Y;
                person.T = "W..0>O.B.200.-100";
                Scenario.Scenes.Add(person);
            }
            
            IncrementGroup();
        }
        private void MakeLocationCadre(string location, string locationspec, string music, string musicspec)
        {
            var item = Sound.GetByName(music, musicspec, currentQueue, currentGroup);
            if (item != null)
            {
                Scenario.Scenes.Add(item);
            }
            item = Location.GetByName(location, locationspec, currentQueue, currentGroup);
            if (item != null)
            {
                item.Z = "0";
                Scenario.Scenes.Add(item);
            }
            IncrementGroup();
        }

    }
}
