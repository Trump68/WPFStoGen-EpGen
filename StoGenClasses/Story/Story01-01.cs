using StoGen.Classes.Story.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class Story01_01 : Story01
    {
        public static string Name = "She Falls to a Perverted Bastard (variant 1)";


        public Story01_01() : base()
        {


        }
        private void CreateData()        
        {
            Girl = new She_Falls_to_a_Perverted_Bastard(this, "Комаки");
            Girl.Titles.Add("сестренка");

            Bastard = new Perverted_Bastard(this, "Футоши");
            Bastard.Titles.Add("мальчик");

            Hero = new Person(this, "Кохеи");
            GuyA = new Siluette(this, "Парень А");
            GuyB = new Siluette(this, "Парень Б");


            Events = new Dictionary<string, string>();
            Events.Add("1", "Event 001");
            Events.Add("2", "Event 002");
            Events.Add("3", "Event 003");
            Events.Add("4", "Event 004");
            Events.Add("5", "Event 005");
            Events.Add("6", "Event 006");
            Events.Add("7", "Event 007");
            Events.Add("8", "Event 008");

            BGM = new Dictionary<string, string>();
            BGM.Add("Good morning", "ogg00052");
            BGM.Add("After School", "After School 1");
            BGM.Add("ogg00054", "ogg00054");
            BGM.Add("Runned into it", "Runned into it");
            BGM.Add("In the Barn", "In the Barn");

            Expression = new Dictionary<string, string>();
            Expression.Add("smiling", "smiling");
            Expression.Add("calm smiling", "calm smiling");
            Expression.Add("agitated tiny smile", "agitated tiny smile");
            Expression.Add("laughing", "laughing");
            Expression.Add("amusing", "amusing");
            Expression.Add("tiny smile", "tiny smile");

            Locations = new Dictionary<string, string>();
            Locations.Add("Hero room morning", "Childroom 001 morning");
            Locations.Add("Hero room evening", "Childroom 001 evening");
            Locations.Add("Girl room evening", "Childroom 002 evening");
            Locations.Add("Street morning", "Street 002 morning");
            Locations.Add("Street evening", "Street 002 evening");
            Locations.Add("Class day", "Class 002 day");
            Locations.Add("Schoolyard day", "Building 001 day");
            Locations.Add("Schoolyard morning", "Building 001 morning");
            Locations.Add("House evening", "Building 002 evening");
            Locations.Add("School hall day", "School hall 001 day");
            Locations.Add("Forest day", "Forest 001 day");
            Locations.Add("Сарай", "Childroom 003 night");
            Locations.Add("Раздевалка", "School dresser 001 day");


            Effects = new Dictionary<string, string>();
            Effects.Add("Wear moving", "Wear moving 1");
            Effects.Add("Door ring", "Door ring 1");
            Effects.Add("Вжик", "Вжик 1");
            Effects.Add("Бум", "Бум 1");
            Effects.Add("Бег мальчик", "Бег 1");
            Effects.Add("Бег девочка", "Бег 2");
            Effects.Add("Шаги в лесу 1", "шаги в лесу 1");

        }

        protected override void GenerateScenario()
        {
            CreateData();           
        }
    }
}
