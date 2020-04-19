using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    class StoryTest: StoryBase
    {
        public void Generate(SCENARIO Scenario, string queue, string group)
        {
            //Person.Load_JennyFord();

            SetLocation();
            SetBGM();


            for (int i = 1; i < 1310; i++)
            {
                IncrementGroup();
                var person = Person.GetByName("Jenny Ford", $"{i.ToString("D4")}", queue, group);
                if (person != null)
                {
                    if (i == 1)
                    {
                        person.Z = "1";
                        person.S = "1000";
                        person.X = "2000";
                        person.Y = "200";
                        person.O = "0";
                        person.T = "W..0>O.B.1500.100*W..0>X.B.1500.-1200";
                    }
                    else
                    {
                        person.Z = "1";
                        person.S = "1000";
                        person.X = "800";
                        person.Y = "200";
                    }
                    Scenario.Scenes.Add(person);
                }
            }

        }
        private void SetBGM()
        {
            var item = Sound.GetByName("Печальная тема 01", null, currentQueue, currentGroup);
            if (item != null)
            {
                Scenario.Scenes.Add(item);
            }
        }
        private void SetLocation()
        {
            var item = Location.GetByName("Apartment 001", "evening", currentQueue, currentGroup);
            if (item != null)
            {
                item.Z = "0";
                Scenario.Scenes.Add(item);
            }
        }
    }
}
