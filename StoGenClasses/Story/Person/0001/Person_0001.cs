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
            
            AddEyes("Far", "Eye looking pretty",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_01.png");
            AddEyes("Far", "Eye looking pretty blush",      null, "Hear red", null, null, "FAR_HEAD_01_EYE_02.png");
            AddEyes("Far", "Eye closed laughing",           null, "Hear red", null, null, "FAR_HEAD_01_EYE_03.png");
            AddEyes("Far", "Eye closed laughing blush",     null, "Hear red", null, null, "FAR_HEAD_01_EYE_04.png");
            AddEyes("Far", "Eye frown",                     null, "Hear red", null, null, "FAR_HEAD_01_EYE_05.png");
            AddEyes("Far", "Eye frown blush",               null, "Hear red", null, null, "FAR_HEAD_01_EYE_06.png");
            AddEyes("Far", "Eye troubled",                  null, "Hear red", null, null, "FAR_HEAD_01_EYE_07.png");
            AddEyes("Far", "Eye troubled blush",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_08.png");
            AddEyes("Far", "Eye agitated",                  null, "Hear red", null, null, "FAR_HEAD_01_EYE_09.png");
            AddEyes("Far", "Eye agitated blush",            null, "Hear red", null, null, "FAR_HEAD_01_EYE_10.png");
            AddEyes("Far", "Eye scared",                    null, "Hear red", null, null, "FAR_HEAD_01_EYE_11.png");
            AddEyes("Far", "Eye scared blush",              null, "Hear red", null, null, "FAR_HEAD_01_EYE_12.png");
            AddEyes("Far", "Eye pain",                      null, "Hear red", null, null, "FAR_HEAD_01_EYE_13.png");
            AddEyes("Far", "Eye pain blush",                null, "Hear red", null, null, "FAR_HEAD_01_EYE_14.png");
            AddEyes("Far", "Eye attantion",                 null, "Hear red", null, null, "FAR_HEAD_01_EYE_15.png");
            AddEyes("Far", "Eye attantion blush",           null, "Hear red", null, null, "FAR_HEAD_01_EYE_16.png");

            AddEyesForHead("Far", "Eye looking pretty",                     new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_17.png");
            AddEyesForHead("Far", "Eye looking pretty blush",               new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_18.png");
            AddEyesForHead("Far", "Eye closed laughing",                    new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_19.png");
            AddEyesForHead("Far", "Eye closed laughing blush",              new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_20.png");
            AddEyesForHead("Far", "Eye frown",                              new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_21.png");
            AddEyesForHead("Far", "Eye frown blush",                        new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_22.png");
            AddEyesForHead("Far", "Eye troubled",                           new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_23.png");
            AddEyesForHead("Far", "Eye troubled blush",                     new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_24.png");
            AddEyesForHead("Far", "Eye agitated",                           new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_25.png");
            AddEyesForHead("Far", "Eye agitated blush",                     new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_26.png");
            AddEyesForHead("Far", "Eye scared",                             new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_27.png");
            AddEyesForHead("Far", "Eye scared blush",                       new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_28.png");
            AddEyesForHead("Far", "Eye pain",                               new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_29.png");
            AddEyesForHead("Far", "Eye pain blush",                         new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_30.png");
            AddEyesForHead("Far", "Eye attantion",                          new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_31.png");
            AddEyesForHead("Far", "Eye attantion blush",                    new string[] { "Hear brown", "Hear brown school" }, "FAR_HEAD_01_EYE_32.png");

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
        public override void Face(EMO emo, EMO_STYLE stype, EMO_EFFECT effect, int ver = 0)
        {
            

            List<Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>> result = new List<Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>>();
            switch (emo)
            {
                case EMO.Laughing:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing",          "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing blush",    "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.Blush, 1));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    break;
                case EMO.Talk_Agitated:
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    break;
                case EMO.Talk:
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip smile anime",              EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip smile anime",              EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    break;
                case EMO.Listening:
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip attantion comix",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip attantion comix",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    break;
                case EMO.Smile_fragile:
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip smile anime",              EMO_STYLE.Anime, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip smile anime",              EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip smile comix",              EMO_STYLE.Anime, EMO_EFFECT.None));                    
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip smile comix",              EMO_STYLE.Anime, EMO_EFFECT.Blush));   
                    break;
                case EMO.Smile:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye attantion",                   "Lip smile comix",              EMO_STYLE.Comix, EMO_EFFECT.None,    1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye attantion blush ",            "Lip smile comix",              EMO_STYLE.Comix, EMO_EFFECT.Blush,   1));
                    //                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip smile comix",              EMO_STYLE.Anime, EMO_EFFECT.None));                    
                    //result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip smile comix",              EMO_STYLE.Anime, EMO_EFFECT.Blush));                    
                    break;
                case EMO.Sleep:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing", "Lip attention comix", EMO_STYLE.Comix, EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing", "Lip attantion anime", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing blush", "Lip attention comix", EMO_STYLE.Comix, EMO_EFFECT.Blush, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing blush", "Lip attantion anime", EMO_STYLE.Anime, EMO_EFFECT.Blush, 1));
                    break;
                case EMO.Offended:
                    /*result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));  
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Sad:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));  */
                    break;
                case EMO.Wandering:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Suprised:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye scared",                   "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None, 1));
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Angry:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Question:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Accusing:                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye frown",                    "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None,  1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye frown blush",              "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush, 1));

/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip troubled anime",           EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Scared:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Pain:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip scared anime",             EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None));                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush));   
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));   
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));*/

                    break;
                case EMO.Troubled:                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye agitated", "Lip sad anime",               EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye agitated", "Lip sad comix",               EMO_STYLE.Comix, EMO_EFFECT.None, 1));
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip attantion anime",          EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty",           "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye looking pretty blush",     "Lip sad comix",                EMO_STYLE.Comix, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip sad anime",                EMO_STYLE.Anime, EMO_EFFECT.Blush));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown",                    "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.None));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye frown blush",              "Lip pain anime",               EMO_STYLE.Anime, EMO_EFFECT.Blush));*/
                    break;
                case EMO.Pleasured:
/*                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing",          "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.None));                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT>("Eye closed laughing blush",    "Lip attention comix",          EMO_STYLE.Comix, EMO_EFFECT.Blush));   */
                    break;
                default:
                    break;
            }
            if (result.Any()) 
            {
                if (stype != EMO_STYLE.Any)
                {
                    var n = result.Where(x => x.Item3 == stype).ToList();
                    if (n.Any()) result = n;
                }
                if (effect != EMO_EFFECT.Any)
                {
                    var n = result.Where(x => x.Item4 == effect).ToList();
                    if (n.Any()) result = n;
                }
                if (ver != 0)
                {
                    var n = result.Where(x => x.Item5 == ver).ToList();
                    if (n.Any()) result = n;
                }
                Random rnd = new Random();
                int r = rnd.Next(result.Count());
                this.visible_eye = result[r].Item1;
                this.visible_lip = result[r].Item2;
            }
        }
        public override void Body(DISTANCE dist, WEAR wear, EMO_EFFECT effect, int ver = 0)
        {
            List<Tuple<string, string, EMO_EFFECT, int>> result = new List<Tuple<string, string, EMO_EFFECT, int>>();
            switch (wear)
            {
                case WEAR.Naked:
                    break;
                case WEAR.Swimware:
                    break;
                case WEAR.Schoolware:
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 1", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 2", EMO_EFFECT.None, 2));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 3", EMO_EFFECT.None, 3));
                    break;
                case WEAR.Sportwear:
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 1", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 2", EMO_EFFECT.None, 2));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 3", EMO_EFFECT.None, 3));
                    break;
                default:
                    break;
            }


            if (result.Any())
            {
                /*                if (stype != EMO_STYLE.Any)
                                {
                                    var n = result.Where(x => x.Item3 == stype).ToList();
                                    if (n.Any()) result = n;
                                }*/
                if (effect != EMO_EFFECT.Any)
                {
                    var n = result.Where(x => x.Item3 == effect).ToList();
                    if (n.Any()) result = n;
                }
                if (ver != 0)
                {
                    var n = result.Where(x => x.Item4 == ver).ToList();
                    if (n.Any()) result = n;
                }
                Random rnd = new Random();
                int r = rnd.Next(result.Count());
                this.visible_distance = result[r].Item1;
                this.visible_base = result[r].Item2;
            }
        }
    }
}

