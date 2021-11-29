using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story.Persons
{

    public class Demonstrator_Person0001 : StoryMaker
    {
        public static string Name = "Demonstrator for person 0001";

        protected Person Girl;
        protected CadreText Text;
        protected Location Place;
        protected CadreSound Sound;
        protected Dictionary<string, string> Events;
        protected Dictionary<string, string> BGM;
        protected Dictionary<string, string> Expression;
        protected Dictionary<string, string> Locations;
        protected Dictionary<string, string> Effects;




        public Demonstrator_Person0001() : base()
        {
            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);
        }

        private void CreateData()
        {
            Girl = new Girl_0001(this, "Girl");

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

            string Show_Body = "School form 3";
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
                    var headList = Girl.Views.Where(x => (x.distance == Girl.visible_distance) && (x.body == Girl.visible_base || x.body == null) && (x.head != null && (x.head == Show_Head || Show_Head == null)) && (x.eyes == null) && (x.lips == null)).ToList();
                    foreach (var head_item in headList)
                    {
                        Girl.visible_head = head_item.head;                        
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
        private void OldAddCadre(params string[] frames)
        {
            OldAddCadre(null, frames);
        }
    }

    public class Girl_0001 : Person
    {        
        public Girl_0001(StoryMaker maker, string name) : base(maker, name)
        {
            Root = @"e:\!EPCATALOG\PERSONS\0001\";
            Source = "Mahou Kishi Arika & Rin Shoujo ni Muragaru Otoko-tachi no Ma no Te _Soredemo Watashi-tachi wa Makenai!!";

            AddBody("Far", "Naked 01", "FAR_BASE_NAKED_01.png");
            AddBody("Far", "Naked 02", "FAR_BASE_NAKED_02.png");
            AddBody("Far", "Panty 1", "FAR_BASE_PANTY_01.png");
            AddBody("Far", "Panty 2", "FAR_BASE_PANTY_02.png");
            AddBody("Far", "Lif 1", "FAR_BASE_LIF_01.png");
            AddBody("Far", "Lif 2", "FAR_BASE_LIF_02.png");
            AddBody("Far", "Nighttie", "FAR_BASE_NIGHTIE_01.png");

            AddBody("Far", "School form 1", "FAR_BASE_SCHOOL_01.png");
            AddBody("Far", "School form 2", "FAR_BASE_SCHOOL_02.png");
            AddBody("Far", "School form 3", "FAR_BASE_SCHOOL_03.png");


            AddHead("Far", "Hear brown", "Nighttie", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Lif 1", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Lif 2", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Panty 1", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Panty 2", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Naked 01", null, null, null, "FAR_HEAD_01.png");
            AddHead("Far", "Hear brown", "Naked 02", null, null, null, "FAR_HEAD_01.png");

            AddHead("Far", "Hear red", "Nighttie", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Lif 1", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Lif 2", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Panty 1", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Panty 2", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Naked 01", null, null, null, "FAR_HEAD_02.png");
            AddHead("Far", "Hear red", "Naked 02", null, null, null, "FAR_HEAD_02.png");


            AddHead("Far", "Hear brown school", "School form 1", null , null, null,"FAR_HEAD_03.png");
            AddHead("Far", "Hear brown school", "School form 2", null, null, null, "FAR_HEAD_03.png");
            AddHead("Far", "Hear brown school", "School form 3", null, null, null, "FAR_HEAD_03.png");


            AddEyes("Far", "[red] Eye looking pretty",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_01.png");           
            AddEyes("Far", "[red] Eye looking pretty blush",      null, "Hear red", null, null, "FAR_HEAD_01_EYE_02.png");
            AddEyes("Far", "[red] Eye closed laughing",           null, "Hear red", null, null, "FAR_HEAD_01_EYE_03.png");
            AddEyes("Far", "[red] Eye closed laughing blush",     null, "Hear red", null, null, "FAR_HEAD_01_EYE_04.png");
            AddEyes("Far", "[red] Eye frown",                     null, "Hear red", null, null, "FAR_HEAD_01_EYE_05.png");
            AddEyes("Far", "[red] Eye frown blush",               null, "Hear red", null, null, "FAR_HEAD_01_EYE_06.png");
            AddEyes("Far", "[red] Eye troubled",                  null, "Hear red", null, null, "FAR_HEAD_01_EYE_07.png");
            AddEyes("Far", "[red] Eye troubled blush",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_08.png");
            AddEyes("Far", "[red] Eye agitated",                  null, "Hear red", null, null, "FAR_HEAD_01_EYE_09.png");
            AddEyes("Far", "[red] Eye agitated blush",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_10.png");
            AddEyes("Far", "[red] Eye scared",                    null, "Hear red", null, null, "FAR_HEAD_01_EYE_11.png");
            AddEyes("Far", "[red] Eye scared blush",              null, "Hear red", null, null, "FAR_HEAD_01_EYE_12.png");
            AddEyes("Far", "[red] Eye pain",                      null, "Hear red", null, null, "FAR_HEAD_01_EYE_13.png");
            AddEyes("Far", "[red] Eye pain blush",                null, "Hear red", null, null, "FAR_HEAD_01_EYE_14.png");
            AddEyes("Far", "[red] Eye attantion",                 null, "Hear red", null, null, "FAR_HEAD_01_EYE_15.png");
            AddEyes("Far", "[red] Eye attantion blush",           null, "Hear red", null, null, "FAR_HEAD_01_EYE_16.png");

            AddEyes("Far", "[brn] Eye looking pretty",            null, "Hear brown", null, null, "FAR_HEAD_01_EYE_17.png");
            AddEyes("Far", "[brn] Eye looking pretty blush",      null, "Hear brown", null, null, "FAR_HEAD_01_EYE_18.png");
            AddEyes("Far", "[brn] Eye closed laughing",           null, "Hear brown", null, null, "FAR_HEAD_01_EYE_19.png");
            AddEyes("Far", "[brn] Eye closed laughing blush",     null, "Hear brown", null, null, "FAR_HEAD_01_EYE_20.png");
            AddEyes("Far", "[brn] Eye frown",                     null, "Hear brown", null, null, "FAR_HEAD_01_EYE_21.png");
            AddEyes("Far", "[brn] Eye frown blush",               null, "Hear brown", null, null, "FAR_HEAD_01_EYE_22.png");
            AddEyes("Far", "[brn] Eye troubled",                  null, "Hear brown", null, null, "FAR_HEAD_01_EYE_23.png");
            AddEyes("Far", "[brn] Eye troubled blush",            null, "Hear brown", null, null, "FAR_HEAD_01_EYE_24.png");
            AddEyes("Far", "[brn] Eye agitated",                  null, "Hear brown", null, null, "FAR_HEAD_01_EYE_25.png");
            AddEyes("Far", "[brn] Eye agitated blush",            null, "Hear brown", null, null, "FAR_HEAD_01_EYE_26.png");
            AddEyes("Far", "[brn] Eye scared",                    null, "Hear brown", null, null, "FAR_HEAD_01_EYE_27.png");
            AddEyes("Far", "[brn] Eye scared blush",              null, "Hear brown", null, null, "FAR_HEAD_01_EYE_28.png");
            AddEyes("Far", "[brn] Eye pain",                      null, "Hear brown", null, null, "FAR_HEAD_01_EYE_29.png");
            AddEyes("Far", "[brn] Eye pain blush",                null, "Hear brown", null, null, "FAR_HEAD_01_EYE_30.png");
            AddEyes("Far", "[brn] Eye attantion",                 null, "Hear brown", null, null, "FAR_HEAD_01_EYE_31.png");
            AddEyes("Far", "[brn] Eye attantion blush",           null, "Hear brown", null, null, "FAR_HEAD_01_EYE_32.png");

            AddEyes("Far", "[brn-sch] Eye looking pretty",            null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_17.png");
            AddEyes("Far", "[brn-sch] Eye looking pretty blush",      null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_18.png");
            AddEyes("Far", "[brn-sch] Eye closed laughing",           null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_19.png");
            AddEyes("Far", "[brn-sch] Eye closed laughing blush",     null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_20.png");
            AddEyes("Far", "[brn-sch] Eye frown",                     null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_21.png");
            AddEyes("Far", "[brn-sch] Eye frown blush",               null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_22.png");
            AddEyes("Far", "[brn-sch] Eye troubled",                  null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_23.png");
            AddEyes("Far", "[brn-sch] Eye troubled blush",            null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_24.png");
            AddEyes("Far", "[brn-sch] Eye agitated",                  null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_25.png");
            AddEyes("Far", "[brn-sch] Eye agitated blush",            null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_26.png");
            AddEyes("Far", "[brn-sch] Eye scared",                    null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_27.png");
            AddEyes("Far", "[brn-sch] Eye scared blush",              null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_28.png");
            AddEyes("Far", "[brn-sch] Eye pain",                      null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_29.png");
            AddEyes("Far", "[brn-sch] Eye pain blush",                null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_30.png");
            AddEyes("Far", "[brn-sch] Eye attantion",                 null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_31.png");
            AddEyes("Far", "[brn-sch] Eye attantion blush",           null, "Hear brown school", null, null, "FAR_HEAD_01_EYE_32.png");

            AddLips("Far", "Lip laughing open anime",                                       "FAR_MOUTH_01.png");
            AddLips("Far", "Lip sad anime",                                                 "FAR_MOUTH_02.png");
            AddLips("Far", "Lip troubled anime",                                            "FAR_MOUTH_03.png");
            AddLips("Far", "Lip scared anime",                                              "FAR_MOUTH_04.png");
            AddLips("Far", "Lip pain anime",                                                "FAR_MOUTH_05.png");
            AddLips("Far", "Lip attantion anime",                                           "FAR_MOUTH_06.png");
            AddLips("Far", "Lip smile anime",                                               "FAR_MOUTH_07.png");
            AddLips("Far", "Lip attention comix",                                           "FAR_MOUTH_08.png");
            AddLips("Far", "Lip smile comix",                                               "FAR_MOUTH_09.png");
            AddLips("Far", "Lip sad comix",                                                 "FAR_MOUTH_10.png");

        }
    }
}

