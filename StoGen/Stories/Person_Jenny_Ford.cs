using StoGen.Classes.Transition;
using StoGenerator.CadreElements;
using StoGenerator.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenerator.Person;

namespace StoGenerator.Stories
{
    class Person_Jenny_Ford : StoryBase
    {
        public static string StoryName = "Person Jenny Ford";
        protected JennyFord person;
        protected override string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=1200;DefTextShift=1000;DefTextWidth=900;DefFontSize=32;DefFontColor=Cyan;DefTextAlignH=3;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 1200; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
        public Person_Jenny_Ford() : base()
        {
            this.Name = Person_Jenny_Ford.StoryName;
            this.FileName = this.Name;
            person = JennyFord.Load();
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1200";
            FCurrentPosition.X = "500";
            FCurrentPosition.Y = "0";
        }
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            //MakeTitle();
            FillData();
        }
        protected override void FillData()
        {
            int fs = 32;
            int ms = 1000;
            //CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);
            foreach (var item in person.Files)
            {
                if (item.Item1.Contains($"{Generic.FigureGeneric}"))
                {
                    F_Posture = this.CombinePerson(F_Posture, item, person, ms);                  
                    MakeNextCadre(Teller.Female, fs, @"");
                }
            }
        }
    }
}
