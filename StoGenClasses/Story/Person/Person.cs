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
        public int Z = 0;
        public string CurrentEvent = null;
        public int O = 100;

        private int LastCadreEventIdx = -1;
        private string LastEventFile = null;
        private string LastEvent = null;               

        private int LastCadreBaseIdx = -1;
        private string LastBaseFile = null;
        private string LastBase = null;

        private int LastCadreHeadIdx = -1;
        private string LastHeadFile = null;
        private string LastHead = null;

        private int LastCadreLipsIdx = -1;
        private string LastLipsFile = null;
        private string LastLips = null;

        private int LastCadreEyesIdx = -1;
        private string LastEyesFile = null;
        private string LastEyes = null;

        private int LastCadreWearIdx = -1;
        private string LastWearFile = null;
        private string LastWear = null;

        public Person(StoryMaker maker)
        {
            Story = maker;
        }
        protected List<Tuple<string, string, string, string>> Resources = new List<Tuple<string, string, string, string>>();
        private List<string> GetData(string template, int z)
        {
            return GetData(template, z, 100, null);
        }
        // event
        public void SmartShowEvent()
        {
            SmartShowEvent(null);
        }            
        public void SmartShowEvent(string transform)
        {            
            string str = string.Empty;
            string transit = string.Empty;
            var item = Resources.FirstOrDefault(x => x.Item1 == CurrentEvent);
            if (item != null)
            {
                str = Path.Combine(Root, item.Item4);
            }
            if (!string.IsNullOrEmpty(str))
            {
                Z = Story.NextFreeZ + 1;
                int opacity = 0;
                if (LastCadreEventIdx == Story.PrevCadreIdx) // location showed in prev cadre
                {
                    if (str != LastEventFile) // different
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear500 : $"{StoryMaker.TransitionAppear500}>{transform}";
                        Story.AddOldFrame(LastEvent);
                    }
                    else // exact same
                    {
                        transit = string.IsNullOrEmpty(transform) ? null : transform;
                        opacity = 100;
                    }
                }
                else if (LastCadreEventIdx < Story.PrevCadreIdx) // last cadre was without location
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear500 : $"{StoryMaker.TransitionAppear500}>{transform}";
                }
                
                Story.Scenario.Add(Story.AddByTemplate("base", 0, Z, opacity, Template, str, transit));
                LastEvent = Story.Scenario.Last();
                LastEventFile = str;
                LastCadreEventIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }
        }
        public void SmartHideEvent()
        {
            SmartHideEvent(null);
        }
        public void SmartHideEvent(string transform)
        {
            string str = string.Empty;
            string transit = string.Empty;
            var item = Resources.FirstOrDefault(x => x.Item1 == CurrentEvent);
            if (item != null)
            {
                str = Path.Combine(Root, item.Item4);
            }
            if (!string.IsNullOrEmpty(str))
            {
                if (LastCadreEventIdx == Story.PrevCadreIdx) // location showed in prev cadre
                {
                    if (str != LastEventFile) // different
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear500 : $"{StoryMaker.TransitionAppear500}>{transform}>{StoryMaker.TransitDissappear500}";
                    }
                    else // exact same
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear500 : $"{transform}>{StoryMaker.TransitDissappear500}";
                    }
                }
                else if (LastCadreEventIdx < Story.PrevCadreIdx) // last cadre was without location
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear500 : $"{StoryMaker.TransitionAppear500}>{transform}>{StoryMaker.TransitDissappear500}";
                }

                Story.Scenario.Add(Story.AddByTemplate("base", 0, Z, 100, Template, str, transit));
            }
        }
        //Figure
        public void SmartFigure()
        {
            SmartFigure(null);
        }
        public void SmartFigure(string transform)
        {
            SmartFigure("0", "0", transform);
        }
        public void SmartFigure(string X, string Y, string transform)
        {
             SmartGetData(Template, X, Y, transform);            
        }
        public void SmartFigure(string X, string Y)
        {
            SmartGetData(Template, X, Y, null);
        }
        public void SmartFigureHide(string X, string Y)
        {
            SmartGetData(Template, X, Y, StoryMaker.TransitDissappear500, true);
        }
        public void SmartFigureHide()
        {
            SmartGetData(Template, null, null, StoryMaker.TransitDissappear500, true);
        }
        private string SmartGetTransorm(string str, string transform, int lastIdx, string lastFile, string lastObj, out int Opacity)
        {            
            string transit = string.Empty;
            Opacity = 0;
            if (!string.IsNullOrEmpty(str))
            {                
                if (lastIdx == Story.PrevCadreIdx) // location showed in prev cadre
                {
                    if (str != lastFile) // different
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear500 : $"{StoryMaker.TransitionAppear500}>{transform}";
                        Story.AddOldFrame(lastObj);
                    }
                    else // exact same
                    {
                        transit = string.IsNullOrEmpty(transform) ? null : transform;
                        Opacity = 100;
                    }
                }
                else if (lastIdx < Story.PrevCadreIdx) // last cadre was without location
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear500 : $"{StoryMaker.TransitionAppear500}>{transform}";
                }
            }
            return transit;
        }
        private void SmartGetData(string template, string X, string Y, string transform, bool isDissaper = false)
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
            {
                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper)
                    transit = SmartGetTransorm(file_base, transform, LastCadreBaseIdx, LastBaseFile, LastBase, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("base", X, Y, 0, Z, opacity, template, file_base, transit);
                Story.Scenario.Add(str);
                LastBaseFile = file_base;
                LastBase = str;                
                LastCadreBaseIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }                
            if (!string.IsNullOrEmpty(file_head)) 
            {
                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper)
                    transit = SmartGetTransorm(file_head, transform, LastCadreHeadIdx, LastHeadFile, LastHead, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("head", X, Y, 0, Z, opacity, template, file_head, transit);
                Story.Scenario.Add(str);
                LastHeadFile = file_head;
                LastHead = str;
                LastCadreHeadIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }
            if (!string.IsNullOrEmpty(file_lips))
            {
                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper)
                    transit = SmartGetTransorm(file_lips, transform, LastCadreLipsIdx, LastLipsFile, LastLips, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("lips", X, Y, 0, Z, opacity, template, file_lips, transit);
                Story.Scenario.Add(str);
                LastLipsFile = file_lips;
                LastLips = str;
                LastCadreLipsIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }
            if (!string.IsNullOrEmpty(file_eyes))
            {
                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper)
                    transit = SmartGetTransorm(file_eyes, transform, LastCadreEyesIdx, LastEyesFile, LastEyes, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("eyes", X, Y, 0, Z, opacity, template, file_eyes, transit);
                Story.Scenario.Add(str);
                LastEyesFile = file_eyes;
                LastEyes = str;
                LastCadreEyesIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }
            if (!string.IsNullOrEmpty(file_wear1))
            {
                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper)
                    transit = SmartGetTransorm(file_wear1, transform, LastCadreWearIdx, LastWearFile, LastWear, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("wear", X, Y, 0, Z, opacity, template, file_wear1, transit);
                Story.Scenario.Add(str);
                LastWearFile = file_wear1;
                LastWear = str;
                LastCadreWearIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }                                
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

        // old =====================================================
        public List<string> oldFigureHidden(string X, string Y, string transform)
        {
            return GetData(Template, X, Y, Z, 0, transform);
        }
        public List<string> oldFigureHidden(string transform)
        {
            return oldFigureHidden(null, null, transform);
        }
        public List<string> oldFigure(string transform)
        {
            return GetData(Template, Z, O, transform);
        }
        public List<string> oldFigure(string X, string Y, string transform)
        {
            return GetData(Template, X, Y, Z, O, transform);
        }
        public List<string> oldFigure(string X, string Y)
        {
            return GetData(Template, X, Y, Z, O, null);
        }
        public List<string> oldFigure()
        {
            return GetData(Template, Z, O, null);
        }
        public string oldEvent()
        {
            return oldEvent(100, null);
        }
        public string oldEvent(string name, string transform)
        {
            string old = this.CurrentEvent;
            this.CurrentEvent = name;
            string rez = oldEvent(100, transform);
            this.CurrentEvent = old;
            return rez;
        }
        public string oldEvent(string transform)
        {
            return oldEvent(100, transform);
        }
        public string oldEventHidden(string transform)
        {
            return oldEvent(0, transform);
        }
        private string oldEvent(int o, string transform)
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
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "School Dress", "01_BASE_01.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Sportwear wet", "01_BASE_02.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "Sportwear", "01_BASE_03.png"));
            Resources.Add(new Tuple<string, string, string, string>("Middle", "Base", "School Dress cleavage", "01_BASE_04.png"));
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
            Resources.Add(new Tuple<string, string, string, string>("Event 005", "Event 005", "Event 005", @"EVENTS\0005.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 006", "Event 006", "Event 006", @"EVENTS\0006.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 007", "Event 007", "Event 007", @"EVENTS\0007.jpg"));
            Resources.Add(new Tuple<string, string, string, string>("Event 008", "Event 008", "Event 008", @"EVENTS\0008.jpg"));
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
