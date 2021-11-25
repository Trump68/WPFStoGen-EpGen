using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class Person
    {
        public string visible_distance = "Far";
        public string visible_base = null;
        public string visible_lip = null;
        public string visible_eye = null;
        public string visible_wear = null;
        public string visible_head = null;
        StoryMaker Story;
        public string Root;
        public string Template = null;
        public int Z = 5;
        public string CurrentEvent = null;
        public int O = 100;
        public Person(StoryMaker maker)
        {
            Story = maker;
        }

        protected List<Tuple<string, string, string, string>> Resources = new List<Tuple<string, string, string, string>>();

        private List<string> GetData(string template, int z)
        {
            return GetData(template, z, 100, null);
        }
        public string Event()
        {
            return Event(100, null);
        }
        public string Event(string name, string transform)
        {
            string old = this.CurrentEvent;
            this.CurrentEvent = name;
            string rez = Event(100, transform);
            this.CurrentEvent = old;
            return rez;
        }
        public string Event(string transform)
        {
            return Event(100, transform);
        }
        public string EventHidden(string transform)
        {
            return Event(0, transform);
        }
        private string Event(int o, string transform)
        {
            string str = string.Empty;
            var item = Resources.FirstOrDefault(x => x.Item1 == CurrentEvent);
            if (item != null)
            {
                str = Path.Combine(Root, item.Item4);
            }
            if (!string.IsNullOrEmpty(str))
                str = Story.AddByTemplate("base", 0, Z, o, Template, str, transform);
            return str;
        }

        public List<string> FigureHidden(string X, string Y, string transform)
        {
            return GetData(Template, X, Y, Z, 0, transform);
        }
        public List<string> FigureHidden(string transform)
        {
            return FigureHidden(null, null, transform);
        }
        public List<string> Figure(string transform)
        {
            return GetData(Template, Z, O, transform);
        }
        public List<string> Figure(string X, string Y, string transform)
        {
            return GetData(Template, X, Y, Z, O, transform);
        }
        public List<string> Figure(string X, string Y)
        {
            return GetData(Template, X, Y, Z, O, null);
        }
        public List<string> Figure()
        {
            return GetData(Template, Z, O, null);
        }
        private List<string> GetData(string template, int z, int o, string transform)
        {
            return GetData(template, null, null, z, o, transform);
        }
        private List<string> GetData(string template, string X, string Y, int z, int o, string transform)
        {
            string file_base = string.Empty;
            string file_head = string.Empty;
            string file_lips = string.Empty;
            string file_eyes = string.Empty;
            string file_wear1 = string.Empty;

            Tuple<string, string, string, string> item = null;

            if (visible_base != null)
            {
                item = Resources.FirstOrDefault(x => x.Item1 == visible_distance && x.Item2 == "Base" && x.Item3 == visible_base);
                if (item != null)
                {
                    file_base = Path.Combine(Root, item.Item4);
                }
            }
            if (visible_head != null)
            {
                item = Resources.FirstOrDefault(x => x.Item1 == visible_distance && x.Item2 == "Head" && x.Item3 == visible_head);
                if (item != null)
                {
                    file_head = Path.Combine(Root, item.Item4);
                }
            }
            if (visible_lip != null)
            {
                item = Resources.FirstOrDefault(x => x.Item1 == visible_distance && x.Item2 == "Lip" && x.Item3 == visible_lip);
                if (item != null)
                {
                    file_lips = Path.Combine(Root, item.Item4);
                }
            }
            if (visible_eye != null)
            {
                item = Resources.FirstOrDefault(x => x.Item1 == visible_distance && x.Item2 == "Eye" && x.Item3 == visible_eye);
                if (item != null)
                {
                    file_eyes = Path.Combine(Root, item.Item4);
                }
            }
            if (visible_wear != null)
            {
                item = Resources.FirstOrDefault(x => x.Item1 == visible_distance && x.Item2 == "Wear" && x.Item3 == visible_wear);
                if (item != null)
                {
                    file_wear1 = Path.Combine(Root, item.Item4);
                }
            }


            List<string> r = new List<string>();
            if (!string.IsNullOrEmpty(file_base))
                r.Add(Story.AddByTemplate("base", X, Y, 0, z++, o, template, file_base, transform));
            if (!string.IsNullOrEmpty(file_head))
                r.Add(Story.AddByTemplate("head", X, Y, 0, z++, o, template, file_head, transform));
            if (!string.IsNullOrEmpty(file_wear1))
                r.Add(Story.AddByTemplate("wear", X, Y, 0, z++, o, template, file_wear1, transform));
            if (!string.IsNullOrEmpty(file_lips))
                r.Add(Story.AddByTemplate("lips", X, Y, 0, z++, o, template, file_lips, transform));
            if (!string.IsNullOrEmpty(file_eyes))
                r.Add(Story.AddByTemplate("eyes", X, Y, 0, z++, o, template, file_eyes, transform));
            return r;
        }
        public void SetVisibleView(string distance, string figure, string head)
        {
            if (distance != null) visible_distance = distance;
            if (figure != null) visible_base = figure;
            if (head != null) visible_head = head;
        }
        public void SetVisible(string distance, string figure, string lip, string eye, string wear)
        {
            SetVisibleView(distance, figure, null);
            SetVisibleExpression(distance, lip, eye);
            SetVisibleWear(wear);
        }
        public void SetVisibleExpression(string distance, string head, string lip, string eye)
        {
            if (distance != null) visible_distance = distance;
            if (head != null) visible_head = head;
            if (lip != null) visible_lip = lip;
            if (eye != null) visible_eye = eye;
        }
        public void SetVisibleExpression(string distance, string lip, string eye)
        {
            SetVisibleExpression(distance, null, lip, eye);
        }
        public void SetVisibleExpression(string name)
        {
        }
        public void SetVisibleWear(string wear)
        {
            if (wear != null) visible_wear = wear;
        }
    }


    // Child classes
    public class Ryoujoku_Celeb_Zuma : Person
    {
        public Ryoujoku_Celeb_Zuma(StoryMaker maker) : base(maker)
        {
            Root = @"e:\!EPCATALOG\PERSONS\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\";
            Resources.Add(new Tuple<string, string, string, string>("Far", "Base", "Gown", "01_BASE.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Lip", "Tiny smile", "01_BASE_LIP_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Lip", "Sad", "01_BASE_LIP_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Lip", "Smile", "01_BASE_LIP_04.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Lip", "Neitral", "01_BASE_LIP_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "Close", "01_BASE_EYE_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "02", "01_BASE_EYE_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "Wide open", "01_BASE_EYE_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "04", "01_BASE_EYE_04.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "05", "01_BASE_EYE_05.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Eye", "06", "01_BASE_EYE_06.png"));
            Resources.Add(new Tuple<string, string, string, string>("Far", "Wear", "Boa", "01_BASE_BOA.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Base", "Gown", "02_BASE_GOWN.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Base", "Naked", "02_BASE.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "Close", "02_BASE_EYE_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "02", "02_BASE_EYE_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "Wide open", "02_BASE_EYE_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "04", "02_BASE_EYE_04.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "05", "02_BASE_EYE_05.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Eye", "06", "02_BASE_EYE_06.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Lip", "Sad", "02_BASE_LIP_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Lip", "Tiny smile", "02_BASE_LIP_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Lip", "Smile", "02_BASE_LIP_04.png"));
            Resources.Add(new Tuple<string, string, string, string>("Close", "Lip", "Neitral", "02_BASE_LIP_01.png"));

            Resources.Add(new Tuple<string, string, string, string>("Event 001", "Event 001", "Event 001", @"EVENTS\0001.jpg"));

        }
        /* public override void SetVisibleExpression(string expression)
         {
             if (expression == "calm thinking")
             {
                 visible_lip = "Neitral";
                 visible_eye = "01";
             }
             else if (expression == "calm smiling")
             {
                 visible_lip = "Tiny smile";
                 visible_eye = null;
             }
             else if (expression == "smiling")
             {
                 visible_lip = "Smile";
                 visible_eye = null;
             }
             else if (expression == "agitated")
             {
                 visible_lip = "Neitral";
                 visible_eye = "Wide open";
             }
             else if (expression == "agitated tiny smile")
             {
                 visible_lip = "Tiny smile";
                 visible_eye = "Wide open";
             }
             else if (expression == "laughing")
             {
                 visible_lip = "Smile";
                 visible_eye = "Close";
             }
             else if (expression == "amusing")
             {
                 visible_lip = "Neitral";
                 visible_eye = "Wide open";
             }
             else if (expression == "cold looking")
             {
                 visible_lip = "Neitral";
                 visible_eye = "02";
             }
         }*/
    }
    public class She_Falls_to_a_Perverted_Bastard : Person
    {
        public She_Falls_to_a_Perverted_Bastard(StoryMaker maker) : base(maker)
        {
            Root = @"e:\!EPCATALOG\PERSONS\She Falls to a Perverted Bastard\";
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "School_Dress", "01_BASE_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Sportwear wet", "01_BASE_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Sportwear", "01_BASE_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Eye", "Wide open stright", "01_BASE_EYES_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Eye", "Up stright amused", "01_BASE_EYES_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Eye", "Closed", "01_BASE_EYES_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Eye", "Up stright troubled", "01_BASE_EYES_04.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Lip", "Smile wide", "01_BASE_LIPS_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Lip", "Open wide", "01_BASE_LIPS_02.png"));

            Resources.Add(new Tuple<string, string, string, string>("Event 001", "Event 001", "Event 001", @"EVENTS\0001.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 002", "Event 002", "Event 002", @"EVENTS\0002.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 003", "Event 003", "Event 003", @"EVENTS\0003.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 004", "Event 004", "Event 004", @"EVENTS\0004.jpg"));

        }
    }
    public class Perverted_Bastard : Person
    {
        public Perverted_Bastard(StoryMaker maker) : base(maker)
        {
            Root = @"e:\!EPCATALOG\PERSONS\She Falls to a Perverted Bastard - Bad Boy\";
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Default", "01_BASE_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Head", "Default", "01_HEAD_01.png"));
        }
    }

    public class Siluette : Person
    {
        public Siluette(StoryMaker maker) : base(maker)
        {
            Root = @"e:\!EPCATALOG\PERSONS\!Siluettes\Guys\";
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Guy 01", "0001.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Guy 02", "0002.png"));
        }
    }
}
