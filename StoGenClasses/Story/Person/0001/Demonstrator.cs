using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story.Persons
{
    public class Demonstrator: StoryMaker
    {
        public static string Name = "Demonstrator for person 0002";

        protected Person Girl;
        protected CadreText Text;
        protected Location Place;
        protected CadreSound Sound;
        protected Dictionary<string, string> Events;
        protected Dictionary<string, string> BGM;
        protected Dictionary<string, string> Expression;
        protected Dictionary<string, string> Locations;
        protected Dictionary<string, string> Effects;




        public Demonstrator(Person person) : base()
        {
            Girl = person;
            Girl.Story = this;
            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);
        }

        private void CreateData()
        {
            //Girl = new Girl_0002(this, "Girl");

            Events = new Dictionary<string, string>();
            Events.Add("1", "Event 001");

            Expression = new Dictionary<string, string>();
            Expression.Add("smiling", "smiling");
        }


        protected override void GenerateScenario()
        {
            CreateData();
            AddHeader();
            Chapter1();
        }
        private void Chapter1()
        {
            List<string> distanceList = new List<string>();
            distanceList.Add("Far");
            distanceList.Add("Middle");
            distanceList.Add("Close");

            string Show_Body = "School form 1";
            //string Show_Body = null;

            //string Show_Head = "Hear brown school 2";
            string Show_Head = null;

            string Show_Lip = null;
            //string Show_Lip = "Lip laughing open anime";

            string Show_Eye = null;
            //string Show_Eye = "Eye scared";

            foreach (var itemDistance in distanceList)
            {
                Girl.visible_distance = itemDistance;
                var bodyList = Girl.Views.Where(x => (x.distance == Girl.visible_distance) && (x.body != null && (x.body == Show_Body || Show_Body == null)) && (x.eyes == null) && (x.lips == null) && (x.head == null)).ToList();
                foreach (var body_item in bodyList)
                {
                    bool chapterexist = false;
                    Girl.visible_base = body_item.body;
                    bool isHead_used = Girl.Views.Where(x => (x.head != null)).Any();
                    if (isHead_used)
                    {
                        var headList = Girl.Views.Where(x => (x.distance == Girl.visible_distance) && (x.body == Girl.visible_base || x.body == null) && (x.head != null && (x.head == Show_Head || Show_Head == null)) && (x.eyes == null) && (x.lips == null)).ToList();
                        foreach (var head_item in headList)
                        {
                            Girl.visible_head = head_item.head;
                            FillFace(chapterexist, Show_Eye, Show_Lip);
                        }
                    }
                    else
                    {
                        FillFace(chapterexist, Show_Eye, Show_Lip);
                    }

                }
            }

        }
        private void FillFace(bool chapterexist, string Show_Eye, string Show_Lip)
        {
            var eyesList = Girl.Views.Where(x => (x.distance == Girl.visible_distance) && (x.body == Girl.visible_base || x.body == null) && ((x.head == Girl.visible_head) || (x.head == null)) && (x.eyes != null && (x.eyes == Show_Eye || Show_Eye == null))).ToList();
            foreach (var eye_item in eyesList)
            {
                Girl.visible_eye = eye_item.eyes;
                var lipsList = Girl.Views.Where(x => (x.distance == Girl.visible_distance) && (x.body == Girl.visible_base || x.body == null) && ((x.head == Girl.visible_head) || (x.head == null)) && (x.eyes == Girl.visible_eye || x.eyes == null) && (x.lips != null && (x.lips == Show_Lip || Show_Lip == null))).ToList();
                foreach (var item_lips in lipsList)
                {
                    Girl.visible_lip = item_lips.lips;
                    if (!chapterexist)
                        AddChapter(Girl.visible_distance + "-" + Girl.visible_base);
                    AddCadre(); Text.Show($"{Girl.visible_head}~{Girl.visible_eye}~{Girl.visible_lip}"); Girl.CombineFigure();
                    chapterexist = true;
                }
            }
        }

        //================
        private void AddHeader()
        {
            AddChapter("0-Header");
            int size_figure = 1440; int x_figure = 0; int y_figure = 0; string template_figure = "8";
            string template_location = "300";
            string template_text = "1";
            Girl.Template = template_figure;
            Text.Template = template_text;
            Place.Template = template_location;
            string cadre = CadreNum.ToString("D3");
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            int ord = 0;
            //text template
            ord++;
            Scenario.Add(GetText(cadre, ". . . . . . . . . . . . .", 2000, 500, 1200, 100, 2, 0, 2, 0, template_text, true));
            // figure template
            ord++;
            Scenario.Add(GetImage(cadre, "Figure", null, size_figure, x_figure, y_figure, 0, 0, null, template_figure, true));
        }
        private void OldAddCadre(List<string> list, params string[] frames)
        {
            OldAddCadre(list, null, frames);
        }
        private void OldAddCadre(List<string> list, List<string> list2, params string[] frames)
        {
            string cadre = GetCadreNum();
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            foreach (string item in frames)
            {
                Scenario.Add(item);
            }
            if (list != null)
            {
                foreach (string item in list)
                {
                    Scenario.Add(item);
                }
            }
            if (list2 != null)
            {
                foreach (string item in list2)
                {
                    Scenario.Add(item);
                }
            }
        }
    }
}
