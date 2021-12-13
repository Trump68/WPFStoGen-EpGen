using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story.Persons
{
/*
    public class Demonstrator_Person0002 : StoryMaker
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




        public Demonstrator_Person0002() : base()
        {
            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);
        }

        private void CreateData()
        {
            Girl = new Girl_0002(this, "Girl");

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
                    bool isHead_used = Girl.Views.Where(x =>(x.head != null)).Any();
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
*/
    public class Girl_0002 : Person
    {        
        public Girl_0002(StoryMaker maker, string name) : base(maker, name)
        {
            Root = @"e:\!EPCATALOG\PERSONS\0002\";
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
            
     

                        AddEyes("Far", "Eye looking pretty",            null, null, null, null, "FAR_HEAD_01_EYE_01.png");
                        AddEyes("Far", "Eye looking pretty blush",      null, null, null, null, "FAR_HEAD_01_EYE_02.png");
                        AddEyes("Far", "Eye closed laughing",           null, null, null, null, "FAR_HEAD_01_EYE_03.png");
                        AddEyes("Far", "Eye closed laughing blush",     null, null, null, null, "FAR_HEAD_01_EYE_04.png");
                        AddEyes("Far", "Eye frown",                     null, null, null, null, "FAR_HEAD_01_EYE_05.png");
                        AddEyes("Far", "Eye frown blush",               null, null, null, null, "FAR_HEAD_01_EYE_06.png");
                        AddEyes("Far", "Eye troubled",                  null, null, null, null, "FAR_HEAD_01_EYE_07.png");
                        AddEyes("Far", "Eye troubled blush",            null, null, null, null, "FAR_HEAD_01_EYE_08.png");
                        AddEyes("Far", "Eye agitated",                  null, null, null, null, "FAR_HEAD_01_EYE_09.png");
                        AddEyes("Far", "Eye agitated blush",            null, null, null, null, "FAR_HEAD_01_EYE_10.png");
                        AddEyes("Far", "Eye scared",                    null, null, null, null, "FAR_HEAD_01_EYE_11.png");
                        AddEyes("Far", "Eye scared blush",              null, null, null, null, "FAR_HEAD_01_EYE_12.png");
                        AddEyes("Far", "Eye pain",                      null, null, null, null, "FAR_HEAD_01_EYE_13.png");
                        AddEyes("Far", "Eye pain blush",                null, null, null, null, "FAR_HEAD_01_EYE_14.png");
                        AddEyes("Far", "Eye attantion",                 null, null, null, null, "FAR_HEAD_01_EYE_15.png");
                        AddEyes("Far", "Eye attantion blush",           null, null, null, null, "FAR_HEAD_01_EYE_16.png");

                        AddLips("Far", "Lip laughing open anime",                                       "FAR_MOUTH_01.png");
                        AddLips("Far", "Lip sad anime",                                                 "FAR_MOUTH_05.png");
                        AddLips("Far", "Lip troubled anime",                                            "FAR_MOUTH_02.png");
                        AddLips("Far", "Lip scared anime",                                              "FAR_MOUTH_03.png");
                        AddLips("Far", "Lip pain anime",                                                "FAR_MOUTH_04.png");
                        AddLips("Far", "Lip attantion anime",                                           "FAR_MOUTH_07.png");
                        AddLips("Far", "Lip smile anime",                                               "FAR_MOUTH_06.png");
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
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing", "Lip laughing open anime", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye closed laughing blush", "Lip laughing open anime", EMO_STYLE.Anime, EMO_EFFECT.Blush, 1));
                    break;
                case EMO.Talk_Agitated:
                    break;
                case EMO.Talk:
                    break;
                case EMO.Listening:
                    break;
                case EMO.Smile_fragile:
                    break;
                case EMO.Smile:
                    break;
                case EMO.Sleep:
                    break;
                case EMO.Offended:
                    break;
                case EMO.Sad:
                    break;
                case EMO.Wandering:
                    break;
                case EMO.Suprised:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Eye scared",                   "Lip laughing open anime",      EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    break;
                case EMO.Angry:
                    break;
                case EMO.Question:
                    break;
                case EMO.Accusing:                    
                    break;
                case EMO.Scared:
                    break;
                case EMO.Pain:
                    break;
                case EMO.Troubled:                    
                    break;
                case EMO.Pleasured:
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
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "Naked 01", EMO_EFFECT.None, 1));
                    break;
                case WEAR.Swimware:
                    break;
                case WEAR.Schoolware:
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 1", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 2", EMO_EFFECT.None, 2));
                    break;
                case WEAR.Sportwear:
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 1", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Far", "School form 2", EMO_EFFECT.None, 2));
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

