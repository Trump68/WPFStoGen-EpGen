using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story.Persons
{
    public enum EMO 
    {
        Talk_Agitated,
        Offended,
        Sad,
        Wandering,
        Suprised,
        Angry,
        Question,
        Accusing,
        Scared,
        Pain,
        Troubled,
        Talk,
        Listening,
        Smile_fragile,
        Smile,
        Laughing,
        Pleasured,
        Sleep,
    }
    public enum DISTANCE
    {
        Far,
        Middle,
        Close
    }
    public enum WEAR
    {
        Naked,
        Swimware,
        Schoolware,
        Sportwear
    }
    public enum EMO_STYLE
    {
        Any,
        Anime,
        Comix        
    }
    public enum EMO_EFFECT
    {
        None,
        Any,
        Blush,
        Tears,
        Sweat
    }


    public class Person
    {
        public string Source;
        public class FigureElement 
        {
            public string kind;
            public string distance;
            public string body;
            public string head;
            public string eyes;
            public string lips;
            public string wear;
            public string file;
            //"Far", "Lip", "Tiny smile", "01_BASE_LIP_01.png"
            public FigureElement(string Distance, string Kind, string Body, string Head, string Eyes, string Lips, string Wear, string File) 
            {
                kind = Kind;  distance = Distance; body = Body; head = Head; eyes = Eyes; lips = Lips; wear = Wear; file = File;
            }
        }
        public void AddBody(string distance, string name, string file)
        {
            Views.Add(new FigureElement(distance, "Base", name, null, null, null, null, file));
        }
        public void AddBody(string distance, string name, string Head, string Eyes, string Lips, string Wear, string file)
        {
            Views.Add(new FigureElement(distance, "Base", name, Head, Eyes, Lips, Wear, file));
        }
        public void AddEyes(string distance, string name, string file)
        {
            Views.Add(new FigureElement(distance, "Eye", null, null, name, null, null, file));
        }
        public void AddEyes(string distance, string name, string Body, string Head, string Lips, string Wear, string file)
        {
            Views.Add(new FigureElement(distance, "Eye", Body, Head, name, Lips, Wear, file));
        }
        public void AddEyesForHead(string distance, string name, string[] Head, string file)
        {
            foreach (var head in Head)
            {
                Views.Add(new FigureElement(distance, "Eye", null, head, name, null, null, file));
            }            
        }
        public void AddLips(string distance, string name, string file)
        {
            Views.Add(new FigureElement(distance, "Lip", null, null, null, name, null, file));
        }
        public void AddLips(string distance, string name, string Body, string Head, string Eyes,string Wear, string file)
        {
            Views.Add(new FigureElement(distance, "Lip", Body, Head, Eyes, name, Wear, file));
        }
        public void AddHead(string distance, string name, string file)
        {
            Views.Add(new FigureElement(distance, "Head", null, name, null, null, null, file));
        }
        public void AddHead(string distance, string name, string Body, string Eyes, string Lips, string Wear, string file)
        {
            Views.Add(new FigureElement(distance, "Head", Body, name, Eyes, Lips, Wear, file));
        }
        public virtual void Face(EMO emo, EMO_STYLE stype, EMO_EFFECT effect, int ver = 0) 
        {            
        }
        public virtual void Body(DISTANCE dist, WEAR wear, EMO_EFFECT effect, int ver = 0)
        { 
        }
        public string Name;
        public List<string> Titles = new List<string>();
        public List<FigureElement> Views = new List<FigureElement>();
        public List<Tuple<string, string>> Events = new List<Tuple<string, string>>();


        public string visible_distance = "Far";
        public string visible_base = null;
        public string visible_lip = null;
        public string visible_eye = null;
        public string visible_wear = null;
        public string visible_head = null;
        public StoryMaker Story;
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

        private int LastCadreCombinedIdx = -1;
        private string LastCombinedFile = null;
        private string LastCombined = null;

        private List<string> Keys = new List<string>();

        public Person(StoryMaker maker, string name)
        {
            Story = maker;
            Name = name;
        }
        
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
            var item = Events.FirstOrDefault(x => x.Item1 == CurrentEvent);
            if (item != null)
            {
                if (Path.IsPathRooted(item.Item2))
                    str = item.Item2;
                else 
                    str = Path.Combine(Root, item.Item2);
            }
            if (!string.IsNullOrEmpty(str))
            {
                Z = Story.NextFreeZ + 1;
                int opacity = 0;
                if ((LastEvent != null) && (LastCadreEventIdx == Story.PrevCadreIdx)) // location showed in prev cadre
                {
                    if (str != LastEventFile) // different
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";
                        Story.AddOldFrame(LastEvent);
                    }
                    else // exact same
                    {
                        transit = string.IsNullOrEmpty(transform) ? null : transform;
                        opacity = 100;
                    }
                }
                else if (LastCadreEventIdx <= Story.PrevCadreIdx) // last cadre was without location
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";
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
                            Z = Story.NextFreeZ + 1;
            string str = string.Empty;
            string transit = string.Empty;
            var item = Events.FirstOrDefault(x => x.Item1 == CurrentEvent);
            if (item != null)
            {
                str = Path.Combine(Root, item.Item2);
            }
            if (!string.IsNullOrEmpty(str))
            {
                Z = Story.NextFreeZ + 1;
                if (LastCadreEventIdx == Story.PrevCadreIdx) // location showed in prev cadre
                {
                    if (str != LastEventFile) // different
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{StoryMaker.TransitionAppear750}>{transform}>{StoryMaker.TransitDissappear1000}";
                    }
                    else // exact same
                    {
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{transform}>{StoryMaker.TransitDissappear1000}";
                    }
                }
                else if (LastCadreEventIdx < Story.PrevCadreIdx) // last cadre was without location
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{StoryMaker.TransitionAppear750}>{transform}>{StoryMaker.TransitDissappear1000}";
                }

                Story.Scenario.Add(Story.AddByTemplate("base", 0, Z, 100, Template, str, transit));
                Story.NextFreeZ = Z + 1;
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
            SmartGetData(Template, X, Y, StoryMaker.TransitDissappear1000, true);
        }
        public void SmartFigureHide()
        {
            SmartGetData(Template, null, null, StoryMaker.TransitDissappear1000, true);
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
                        transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";
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
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";
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

            List<string> images = new List<string>();

            FigureElement item = null;            
            if (visible_base != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Base" && x.body == visible_base);
                if (item != null)
                {
                    file_base = Path.Combine(Root, item.file);
                    images.Add(file_base);
                }
            }
            if (visible_head != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Head" && x.head == visible_head);
                if (item != null)
                {
                    file_head = Path.Combine(Root, item.file);
                    images.Add(file_head);
                }
            }
            if (visible_lip != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Lip" && x.lips == visible_lip);
                if (item != null)
                {
                    file_lips = Path.Combine(Root, item.file);
                    images.Add(file_lips);
                }
            }
            if (visible_eye != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Eye" && x.eyes == visible_eye);
                if (item != null)
                {
                    file_eyes = Path.Combine(Root, item.file);
                    images.Add(file_eyes);
                }
            }
            if (visible_wear != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Wear" && x.wear == visible_wear);
                if (item != null)
                {
                    file_wear1 = Path.Combine(Root, item.file);
                    images.Add(file_wear1);
                }
            }            

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



        public void CombineFigure()
        {
            CombineFigure(null);
        }
        public void CombineFigure(string transform)
        {
            CombineFigure("0", "0", transform);
        }
        public void CombineFigure(string X, string Y, string transform)
        {
            CombineFigure(Template, X, Y, transform);
        }
        public void CombineFigure(string X, string Y)
        {
            CombineFigure(Template, X, Y, null);
        }
        private string DoCombine(ref List<string> images) 
        {
            if (images == null) return null;
            string file_base = string.Empty;
            string file_head = string.Empty;
            string file_lips = string.Empty;
            string file_eyes = string.Empty;
            string file_wear1 = string.Empty;

            string key = string.Empty;
           
           

            FigureElement item = null;
            if (visible_base != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Base" && x.body == visible_base);
                if (item != null)
                {
                    file_base = Path.Combine(Root, item.file);
                    images.Add(file_base);
                    key = $"{key}_base_{visible_base}";
                }
            }
            if (visible_head != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Head" && x.head == visible_head);
                if (item != null)
                {
                    file_head = Path.Combine(Root, item.file);
                    images.Add(file_head);
                    key = $"{key}_head_{visible_head}";
                }
            }
            if (visible_eye != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Eye" && x.eyes == visible_eye && ((x.head == visible_head) || (x.head == null)) );
                if (item != null)
                {
                    file_eyes = Path.Combine(Root, item.file);
                    images.Add(file_eyes);
                    key = $"{key}_eye_{visible_eye}";
                }
            }
            if (visible_lip != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Lip" && x.lips == visible_lip);
                if (item != null)
                {
                    file_lips = Path.Combine(Root, item.file);
                    images.Add(file_lips);
                    key = $"{key}_lip_{visible_lip}";
                }
            }
            if (visible_wear != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Wear" && x.wear == visible_wear);
                if (item != null)
                {
                    file_wear1 = Path.Combine(Root, item.file);
                    images.Add(file_wear1);
                    key = $"{key}_wear_{visible_wear}";
                }
            }
            return key;
        }
        public void CombineFigure(string template, string X, string Y, string transform, bool isDissaper = false)
        {
            List<string> images = new List<string>();
            string key = DoCombine(ref images);

            if (!string.IsNullOrEmpty(key) && images.Any())
            {
                string CombinedFile = null;
                CombinedFile = Path.Combine(StoryMaker.StoryPath,"_TMP", $"{Name}_{visible_distance}_{key}.png");
                if (!Keys.Contains(key))
                {
                    Bitmap result = ImageHelper.CombineBitmap(images.ToArray());
                    result.SavePNG(CombinedFile);
                    Keys.Add(key);
                }

                Z = Story.NextFreeZ + 1;
                int opacity;
                string transit = transform;
                if (!isDissaper && (LastCombined != null))
                    transit = SmartGetTransorm(CombinedFile, transform, LastCadreCombinedIdx, LastCombinedFile, LastCombined, out opacity);
                else
                    opacity = this.O;
                string str = Story.AddByTemplate("combined figure", X, Y, 0, Z, opacity, template, CombinedFile, transit);
                Story.Scenario.Add(str);
                LastCombinedFile = CombinedFile;
                LastCombined = str;
                LastCadreCombinedIdx = Story.CurrCadreIdx;
                Story.NextFreeZ = Z + 1;
            }
        }

        public string CombineEventByFigure(string eventName)
        {
            List<string> images = new List<string>();
            string key = DoCombine(ref images);

            if (!string.IsNullOrEmpty(key) && images.Any())
            {
                string CombinedFile = null;
                CombinedFile = Path.Combine(StoryMaker.StoryPath, "_TMP", $"{Name}_{visible_distance}_{key}.png");
                if (!Keys.Contains(key))
                {
                    Bitmap result = ImageHelper.CombineBitmap(images.ToArray());
                    result.SavePNG(CombinedFile);
                    Keys.Add(key);
                }
                Events.Add(new Tuple<string, string>(eventName, CombinedFile));
            }
            return eventName;
        }

        public void CombineFigureHide(string X, string Y)
        {
            CombineFigure(Template, X, Y, StoryMaker.TransitDissappear1000, true);
        }
        public void CombineFigureHide()
        {
            CombineFigure(Template, null, null, StoryMaker.TransitDissappear1000, true);
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

            FigureElement item = null;
            if (visible_base != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Base" && x.body == visible_base);
                if (item != null)
                {
                    file_base = Path.Combine(Root, item.file);;
                }
            }
            if (visible_head != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Head" && x.head == visible_head);
                if (item != null)
                {
                    file_head = Path.Combine(Root, item.file);
                }
            }
            if (visible_lip != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Lip" && x.lips == visible_lip);
                if (item != null)
                {
                    file_lips = Path.Combine(Root, item.file);
                }
            }
            if (visible_eye != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Eye" && x.eyes == visible_eye);
                if (item != null)
                {
                    file_eyes = Path.Combine(Root, item.file);
                }
            }
            if (visible_wear != null)
            {
                item = Views.FirstOrDefault(x => x.distance == visible_distance && x.kind == "Wear" && x.wear == visible_wear);
                if (item != null)
                {
                    file_wear1 = Path.Combine(Root, item.file);
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
        public Ryoujoku_Celeb_Zuma(StoryMaker maker, string name) : base(maker, name)
        {
/*            Root = @"e:\!EPCATALOG\PERSONS\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\";
            Views.Add(new FigureElement("Far", "Base", "Gown", null, null, null, null, "01_BASE.png"));

            Views.Add(new Tuple<string, string, string, string>("Close", "Base", "Gown", "02_BASE_GOWN.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Base", "Naked", "02_BASE.png"));

            Views.Add(new Tuple<string, string, string, string>("Far", "Lip", "Tiny smile", "01_BASE_LIP_01.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Lip", "Sad", "01_BASE_LIP_02.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Lip", "Smile", "01_BASE_LIP_04.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Lip", "Neitral", "01_BASE_LIP_03.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "Close", "01_BASE_EYE_01.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "02", "01_BASE_EYE_02.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "Wide open", "01_BASE_EYE_03.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "04", "01_BASE_EYE_04.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "05", "01_BASE_EYE_05.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Eye", "06", "01_BASE_EYE_06.png"));
            Views.Add(new Tuple<string, string, string, string>("Far", "Wear", "Boa", "01_BASE_BOA.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "Close", "02_BASE_EYE_01.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "02", "02_BASE_EYE_02.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "Wide open", "02_BASE_EYE_03.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "04", "02_BASE_EYE_04.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "05", "02_BASE_EYE_05.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Eye", "06", "02_BASE_EYE_06.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Lip", "Sad", "02_BASE_LIP_02.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Lip", "Tiny smile", "02_BASE_LIP_03.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Lip", "Smile", "02_BASE_LIP_04.png"));
            Views.Add(new Tuple<string, string, string, string>("Close", "Lip", "Neitral", "02_BASE_LIP_01.png"));

            Views.Add(new Tuple<string, string, string, string>("Event 001", "Event 001", "Event 001", @"EVENTS\0001.jpg"));
*/
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
        public She_Falls_to_a_Perverted_Bastard(StoryMaker maker, string name) : base(maker, name)
        {
            Root = @"e:\!EPCATALOG\PERSONS\She Falls to a Perverted Bastard\";
            
            AddBody("Middle", "School Dress",               "01_BASE_01.png");
            AddBody("Middle", "Sportwear wet",              "01_BASE_02.png");
            AddBody("Middle", "Sportwear",                  "01_BASE_03.png");
            AddBody("Middle", "School Dress cleavage",      "01_BASE_04.png");

            AddEyes("Middle", "Wide open stright",          "01_BASE_EYES_01.png");
            AddEyes("Middle", "Up stright amused",          "01_BASE_EYES_02.png");
            AddEyes("Middle", "Closed",                     "01_BASE_EYES_03.png");
            AddEyes("Middle", "Up stright troubled",        "01_BASE_EYES_04.png");

            AddLips("Middle", "Smile wide",                 "01_BASE_LIPS_01.png");
            AddLips("Middle", "Open wide",                  "01_BASE_LIPS_02.png");
                        

            Events.Add(new Tuple<string, string>("Event 001", @"EVENTS\0001.jpg"));
            Events.Add(new Tuple<string, string>("Event 002", @"EVENTS\0002.jpg"));
            Events.Add(new Tuple<string, string>("Event 003", @"EVENTS\0003.jpg"));
            Events.Add(new Tuple<string, string>("Event 004", @"EVENTS\0004.jpg"));
            Events.Add(new Tuple<string, string>("Event 005", @"EVENTS\0005.jpg"));
            Events.Add(new Tuple<string, string>("Event 006", @"EVENTS\0006.jpg"));
            Events.Add(new Tuple<string, string>("Event 007", @"EVENTS\0007.jpg"));
            Events.Add(new Tuple<string, string>("Event 008", @"EVENTS\0008.jpg"));
            Events.Add(new Tuple<string, string>("Event 009", @"EVENTS\0009.jpg"));
            Events.Add(new Tuple<string, string>("Event 010", @"EVENTS\0010.jpg"));
            Events.Add(new Tuple<string, string>("Event 011", @"EVENTS\0011.jpg"));
            Events.Add(new Tuple<string, string>("Event 012", @"EVENTS\0012.jpg"));
            Events.Add(new Tuple<string, string>("Event 013", @"EVENTS\0013.jpg"));
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
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Middle", "School Dress", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Middle", "School Dress cleavage", EMO_EFFECT.None, 2));
                    break;
                case WEAR.Sportwear:
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Middle", "Sportwear", EMO_EFFECT.None, 1));
                    result.Add(new Tuple<string, string, EMO_EFFECT, int>("Middle", "Sportwear wet", EMO_EFFECT.Sweat, 1));
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
        public override void Face(EMO emo, EMO_STYLE stype, EMO_EFFECT effect, int ver = 0)
        {


            List<Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>> result = new List<Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>>();
            switch (emo)
            {
                case EMO.Laughing:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Wide open stright", "Smile wide", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    break;
                case EMO.Talk_Agitated:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Wide open stright", "Smile wide", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    break;
                case EMO.Talk:
                    break;
                case EMO.Listening:
                    break;
                case EMO.Smile_fragile:
                    break;
                case EMO.Smile:
                    break;
                case EMO.Offended:
                    break;
                case EMO.Sad:
                    break;
                case EMO.Wandering:
                    break;
                case EMO.Suprised:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Up stright amused", "Open wide", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    break;
                case EMO.Angry:
                    break;
                case EMO.Question:
                    break;
                case EMO.Accusing:
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Up stright amused", "Open wide", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
                    break;
                case EMO.Scared:
                    break;
                case EMO.Pain:
                    break;
                case EMO.Troubled:                    
                    result.Add(new Tuple<string, string, EMO_STYLE, EMO_EFFECT, int>("Up stright troubled", "Open wide", EMO_STYLE.Anime, EMO_EFFECT.None, 1));
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
    }
    public class Perverted_Bastard : Person
    {
        public Perverted_Bastard(StoryMaker maker, string name) : base(maker, name)
        {
            Root = @"e:\!EPCATALOG\PERSONS\She Falls to a Perverted Bastard - Bad Boy\";
            AddBody("Middle", "Default",                    "01_BASE_01.png");
            AddHead("Middle", "Default",                    "01_HEAD_01.png");
        }
    }
    public class Siluette : Person
    {
        public Siluette(StoryMaker maker, string name) : base(maker, name)
        {
            Root = @"e:\!EPCATALOG\PERSONS\!Siluettes\Guys\";
            AddBody("Middle", "Guy 01",                     "0001.png");
            AddBody("Middle", "Guy 02",                     "0002.png");
        }
    }
   
}
