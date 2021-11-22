using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class StoryMaker
    {
        public string Chapter = string.Empty;
        protected int CadreNum = 0;
        protected List<string> Scenario = new List<string>();
        public string GetCadreNum()
        {
            return CadreNum.ToString("D3");
        }
        public void Generate(string path)
        {
            SCENARIO newscenario = new SCENARIO();
            newscenario.FileName = "Generated";
            GenerateScenario();
            newscenario.LoadFrom(Scenario);
            SetParameters(newscenario);
            newscenario.SaveToFile(path, null);
        }
        public StoryMaker()
        {            
            FillFrame();            
        }

        protected virtual void GenerateScenario()
        {
            string input =
           @"GroupId=0 Служебный;DSC=0 Служебный;ORD=1
Id=0001.001.001;GR=0 Служебный;ORD=1
GROUP=0001.001.001;KIND=6;A=1;Y=1;F=1;DSC=0 Служебный;ORD=1;FILE=e:\!STOGENDB\Resources\NTRPG2 1.14\Audio\BGM\0006-komari.mp3
GROUP=0001.001.001;KIND=6;A=1;Y=1;F=1;DSC=0 Служебный;ORD=2;FILE=e:\!CATALOG\sound\old-n-young.com-Pelmen-Anya_05.mp3
GROUP=0001.001.001;KIND=6;A=1;Y=1;F=1;DSC=0 Служебный;ORD=3;FILE=e:\!CATALOG\sound\old-n-young.com-Pelmen-Sasha_02.mp3
GROUP=0001.001.001;KIND=0;A=1;S=1200;X=1450;Y=-186;Z=5;DSC=0 Служебный;TEMPLATE=~4;ORD=4;FILE=__BAD_PERSON_FACE_02
GROUP=0001.001.001;KIND=0;A=1;S=200;X=-20;Y=960;Z=8;DSC=0 Служебный;TEMPLATE=~5;ORD=5;FILE=__BAD_PERSON_FACE_01
GROUP=0001.001.001;KIND=0;A=1;S=2600;X=-1700;Y=-500;Z=7;T=O.B.500.100;DSC=0 Служебный;TEMPLATE=~6;ORD=6;FILE=__RED_CURTAINS_01
GROUP=0001.001.001;KIND=0;A=1;S=200;X=2000;Y=1000;Z=11;DSC=Protagonist face;TEMPLATE=~7;ORD=7;FILE=__PROTAGONIST_FACE_01
GROUP=0001.001.001;KIND=1;A=1;S=250;X=2200;Y=145;O=100;R=2;VAlign=0;DSC=1 Эпизод 000;STR=Normal Wait;TEMPLATE=~1;ORD=0
GROUP=0001.001.001;KIND=0;A=1;S=1920;X=0;Y=0;Z=3;DSC=Bedroom 01;TEMPLATE=~300;ORD=7;FILE=__BEDROOM_01_MORNING
GROUP=0001.001.001;KIND=0;A=1;S=1000;X=100;Y=100;Z=5;DSC=Main event;TEMPLATE=~9;ORD=6;FILE=e:\!CATALOG\PRS\!!! Figures\Game CG\DATA\0000.jpg
GROUP=0001.001.001;KIND=0;A=1;S=1000;X=1560;Z=0;DSC=Frame 001;TEMPLATE=~301;ORD=7;FILE=e:\!CATALOG\PRS\!!! Backgrounds\Frames\DATA\Frame-001 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-173].png
GROUP=0001.001.001;KIND=0;A=1;S=1920;X=0;Y=0;Z=10;DSC=Main face;TEMPLATE=~8;ORD=7;FILE=e:\!CATALOG\PRS\!!! Backgrounds\Frames\DATA\Frame-001 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-173].png
GROUP=0001.001.001;KIND=0;A=1;S=920;X=1780;Y=750;Z=1;DSC=Frame 002;TEMPLATE=~302;ORD=7;FILE=e:\!CATALOG\PRS\!!! Backgrounds\Frames\DATA\Frame-001 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-173].png
GroupId=0001;DSC=Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-068;ORD=3
Id=cae791b5-748a-450d-b8f7-de160bdef373;DSC=EVENING;GR=0001;ORD=24
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=1;A=1;S=2000;X=500;Y=1200;O=100;R=2;VAlign=2;DSC=1 Эпизод 000;STR=[Ксения]~Ты правда не будешь ревновать?;TEMPLATE=1;ORD=0
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=0;A=1;DSC=$BACKGROUND;TEMPLATE=300;ORD=1;FILE=__BEDROOM_01_EVENING
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=0;A=1;DSC=Main pic test;TEMPLATE=8;ORD=5;FILE=e:\!CATALOG\PRS\!!! Figures\Game CG\DATA-TR\0001\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-068-faceA1.png
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=0;A=1;X=1560;DSC=$TEXT_FRAME1;TEMPLATE=301;ORD=2;FILE=e:\!CATALOG\PRS\!!! Backgrounds\Frames\DATA\Frame-001 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-173].png
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=0;A=1;DSC=$TEXT_FRAME2;TEMPLATE=302;ORD=3;FILE=e:\!CATALOG\PRS\!!! Backgrounds\Frames\DATA\Frame-002 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-155].png
GROUP=cae791b5-748a-450d-b8f7-de160bdef373;KIND=0;A=1;S=815;X=1800;Y=732;DSC=$PARTNER;TEMPLATE=7;ORD=6;FILE=__PROTAGONIST_FACE_01";

            List<string> par = new List<string>();
            par.Add(Environment.NewLine);
            Scenario.AddRange(input.Split(par.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
        }
        protected void SetParameters(SCENARIO scenario)
        {
            scenario.RawParameters =
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
//Def background: $$WHITE$$
DefTextSize=800;DefTextShift=1200;DefTextWidth=700;DefFontSize=28;DefTextAlignH=0;DefTextAlignV=0;DefTextBck=Cyan
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 1200; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile=e:\!CATALOG\PRS\!!! Figures\Game CG\DATA\
//Other n:\!CATALOG\JAV\JUFD\JUFD-467\1_JUFD-467_UNCENSORED.m4v
PackStory=1; PackImage=1; PackSound=1; PackVideo=0";
            scenario.AssignRawParameters();
        }

       
        // Frame
        List<Tuple<string, string, string>> framelist = new List<Tuple<string, string, string>>();
        string frameroot = @"e:\!EPCATALOG\FRAME\";
        private void FillFrame()
        {
            string catalog = "";
            framelist.Add(new Tuple<string, string, string>("Black", catalog, @"BLACK.png"));
            framelist.Add(new Tuple<string, string, string>("Frame 01", catalog, @"Frame-001 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-173].png"));
            framelist.Add(new Tuple<string, string, string>("Frame 02", catalog, @"Frame-002 [Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku-155].png"));
        }
        protected virtual string GetFileFrame(string name)
        {
            var val = framelist.Where(x => (x.Item1 == name) || (x.Item3 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(frameroot, val.Item2, val.Item3);
        }
        public string GetFrame(string group, string dsc, string name, int size, int x, int y, int z, int ord, string tran, string template, bool istemplate)
        {
            return GetImage(group, dsc, GetFileFrame(name), size, x, y, z, ord, tran, template, istemplate);
        }

        public string GetImage(string group, string dsc, string name, int size, int x, int y, int z, int ord, string tran, string template, bool istemplate)
        {
            string templatestr = null;
            if (!string.IsNullOrEmpty(template))
            {
                templatestr = istemplate ? $"TEMPLATE=~{template};" : $"TEMPLATE={template};";
            }
            string transtr = string.IsNullOrEmpty(tran) ? string.Empty : $"T={tran};";
            return $"GROUP={group};KIND=0;S={size};X={x};Y={y};Z={z};DSC={dsc};{templatestr}{transtr}ORD={ord};FILE={name}";
        }

        public string GetText(string group, string text, int size, int x, int y, int o, int r, int ord, int valign, int halign, string template, bool istemplate)
        {
            string templatestr = null;
            if (!string.IsNullOrEmpty(template))
            {
                templatestr = istemplate ? $"TEMPLATE=~{template};" : $"TEMPLATE={template};";
            }
            return $"GROUP={group};KIND=1;{templatestr}S={size};X={x};Y={y};O={o};R={r};VAlign={valign};HAlign={halign};STR={text};ORD={ord}";
        }

        public string AddByTemplate(string dsc, int kind, int z, int o, string template, string file, string trans)
        {
            string cadre = GetCadreNum();
            string str_z = (z < 0) ? string.Empty : $";Z={z}";
            string str_transform = (trans is null) ? string.Empty : $";T={trans}";
            string str_file = string.Empty;
            if (kind == 0)
            {
                str_file = string.IsNullOrEmpty(file) ? string.Empty : $";FILE={file}";
            }
            else if (kind == 1)
            {
                str_file = string.IsNullOrEmpty(file) ? string.Empty : $";STR={file}";
            }
            return $"GROUP={cadre};KIND={kind};DSC={dsc};O={o};TEMPLATE={template}{str_file}{str_transform}{str_z}";
        }

        public string AddTextByTemplate(string template, string text, string dsc = null)
        {
            if (string.IsNullOrEmpty(dsc))
                dsc = $"Cadre {CadreNum}";
            return AddByTemplate(dsc, 1, 0, 100, template, text, null);
        }
        public string AddImageByTemplate(string dsc, int z, string template, string file, string trans)
        {
            return AddImageByTemplate(dsc, z, template, file, 100, trans);
        }
        public string AddImageByTemplate(string dsc, int z, string template, string file, int o, string trans)
        {
            if (string.IsNullOrEmpty(dsc))
                dsc = $"Cadre {CadreNum}";
            return AddByTemplate(dsc, 0, z, o, template, file, trans);
        }

        public string AddImageByTemplate(string dsc, int z, string template, string file)
        {
            return AddImageByTemplate(dsc, z, template, file, null);
        }
    }

    public class CadreTransformation
    {
        public bool ApplayAllFrames = false;
        public int ApplayFrame = 0;
        public string Transformation = string.Empty;
        public CadreTransformation(string transformation, int applayFrame = 0, bool applayAllFrames = false)
        {
            Transformation = transformation;
            ApplayAllFrames = applayAllFrames;
            ApplayFrame = applayFrame;
        }
    }
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

        public List<string> FigureHidden(string transform)
        {
            return GetData(Template, Z, 0, transform);
        }
        public List<string> Figure(string transform)
        {
            return GetData(Template, Z, 100, transform);
        }
        public List<string> Figure()
        {
            return GetData(Template, Z, 100, null);
        }

        private List<string> GetData(string template, int z, int o, string transform)
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
                r.Add(Story.AddByTemplate("base", 0, z++, o, template, file_base, transform));
            if (!string.IsNullOrEmpty(file_head))
                r.Add(Story.AddByTemplate("head", 0, z++, o, template, file_head, transform));
            if (!string.IsNullOrEmpty(file_wear1))
                r.Add(Story.AddByTemplate("wear", 0, z++, o, template, file_wear1, transform));
            if (!string.IsNullOrEmpty(file_lips))
                r.Add(Story.AddByTemplate("lips", 0, z++, o, template, file_lips, transform));
            if (!string.IsNullOrEmpty(file_eyes))
                r.Add(Story.AddByTemplate("eyes", 0, z++, o, template, file_eyes, transform));
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

    public class CadreText
    {
        public CadreText(StoryMaker story) 
        {
            Story = story;
        }
        public string Template = null;
        StoryMaker Story;
        public string Show(string text) 
        {
            return Story.AddTextByTemplate(Template, text);
        }        
    }

    public class Location
    {
        public Location(StoryMaker story)
        {
            Story = story;
            FillLocations();
        }
        public string Template = null;
        StoryMaker Story;
        public int Z = 0;
        public string Current;
        public string Description;        
        public string Show()
        {            
            return Show(null);
        }
        public string Show(string transform)
        {

            string file = GetFileLocation(Current);
            return Story.AddImageByTemplate(Description, Z, Template, file, transform);
        }
        public string ShowHidden(string transform)
        {
            string file = GetFileLocation(Current);
            return Story.AddImageByTemplate(Description, Z, Template, file, 0, transform);
        }
        // Location
        List<Tuple<string, string, string>> locations = new List<Tuple<string, string, string>>();
        string locationroot = @"e:\!EPCATALOG\LOCATION\";
        private void FillLocations()
        {
            string catalog = "BEDROOM";
            locations.Add(new Tuple<string, string, string>("Bedroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -morning.png"));
            locations.Add(new Tuple<string, string, string>("Bedroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -day.png"));
            locations.Add(new Tuple<string, string, string>("Bedroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -evening.png"));
            catalog = "GARDEN";
            locations.Add(new Tuple<string, string, string>("Garden 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Garden-morning.png"));
            catalog = "HALL";
            locations.Add(new Tuple<string, string, string>("Hall 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-morning.png"));
            locations.Add(new Tuple<string, string, string>("Hall 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-day.png"));
            locations.Add(new Tuple<string, string, string>("Hall 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-evening.png"));
            catalog = "KORRIDOR";
            locations.Add(new Tuple<string, string, string>("Korridor 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-morning.png"));
            locations.Add(new Tuple<string, string, string>("Korridor 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-day.png"));
            locations.Add(new Tuple<string, string, string>("Korridor 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-evening.png"));
            catalog = "BATHROOM";
            locations.Add(new Tuple<string, string, string>("Bathroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-morning.png"));
            locations.Add(new Tuple<string, string, string>("Bathroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-day.png"));
            locations.Add(new Tuple<string, string, string>("Bathroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-evening.png"));
            catalog = "LIVINGROOM";
            locations.Add(new Tuple<string, string, string>("Livingroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-morning.png"));
            locations.Add(new Tuple<string, string, string>("Livingroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-day.png"));
            locations.Add(new Tuple<string, string, string>("Livingroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-evening.png"));
            catalog = "MANOR";
            locations.Add(new Tuple<string, string, string>("Manor 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-morning.png"));
            locations.Add(new Tuple<string, string, string>("Manor 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-day.png"));
            locations.Add(new Tuple<string, string, string>("Manor 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-evening.png"));
            catalog = "STREET";
            locations.Add(new Tuple<string, string, string>("Street 001 morning", catalog, @"001\Street-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 001 day", catalog, @"001\Street-day.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 001 evening", catalog, @"001\Street-evening.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 002 morning", catalog, @"002\0002-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 002 evening", catalog, @"002\0002-evening.jpg"));
            catalog = "CLASS";
            locations.Add(new Tuple<string, string, string>("Class 001 day", catalog, @"001\Class-day.jpg"));
            locations.Add(new Tuple<string, string, string>("Class 002 day", catalog, @"002\class-day.jpg"));
            catalog = "BUILDINGS";
            locations.Add(new Tuple<string, string, string>("Building 001 day", catalog, @"001\001.jpg"));
            locations.Add(new Tuple<string, string, string>("Building 002 evening", catalog, @"002\House-evening.jpg"));
            catalog = "CHILDROOM";
            locations.Add(new Tuple<string, string, string>("Childroom 001 morning", catalog, @"001\001-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Childroom 001 evening", catalog, @"001\001-evening.jpg"));
            locations.Add(new Tuple<string, string, string>("Childroom 002 evening", catalog, @"002\002-evening.jpg"));
            catalog = "SCHOOL";
            locations.Add(new Tuple<string, string, string>("School hall 001 day", catalog, @"HOLL\She Falls to a Perverted Bastard\hall-day.jpg"));
        }
        protected virtual string GetFileLocation(string name)
        {
            var val = locations.Where(x => (x.Item1 == name) || (x.Item3 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(locationroot, val.Item2, val.Item3);
        }
        public string GetLocation(string group, string dsc, string name, int size, int x, int y, int z, int ord, string tran, string template, bool istemplate)
        {
            return Story.GetImage(group, dsc, GetFileLocation(name), size, x, y, z, ord, tran, template, istemplate);
        }

    }

    public class CadreSound
    {
        public CadreSound(StoryMaker story)
        {
            FillBGM();            
            FillSoundEffest();
            Story = story;
        }
        StoryMaker Story;
        public string CurrentBGM;
        public string CurrentSE;
        public int BGM_Volume = 100;
        public int SE_Volume = 100;
        public string BgmMuted(string transform) 
        {
            return GetBGM(CurrentBGM, transform, false, false, false);
        }
        public string Bgm()
        {
            return GetBGM(CurrentBGM, null, false, false, true);
        }
        public string BgmStop()
        {
            return GetBGM(CurrentBGM, null, false, true, false);
        }

        //BGM
        List<Tuple<string, string, string>> bgmlist = new List<Tuple<string, string, string>>();
        string bgmroot = @"e:\!EPCATALOG\SOUND\BGM\";
        private void FillBGM()
        {
            string catalog = "NTRPG2";
            bgmlist.Add(new Tuple<string, string, string>("1", catalog, @"0001-ayaturi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("2", catalog, @"0002-tumugi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("3", catalog, @"0003-13_kumorizora.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("4", catalog, @"0004-18_huann.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("5", catalog, @"0005-19_zaiakukan.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("6", catalog, @"0006-komari.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("7", catalog, @"0007-fanfare.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("8", catalog, @"0007-gray.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("9", catalog, @"0007-onaji.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("10", catalog, @"0008-chinkou.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("11", catalog, @"0009-15_zawameki.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("12", catalog, @"0009-under.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("13", catalog, @"0011-akumu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("14", catalog, @"0012-maturi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("15", catalog, @"0012-tirihana.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("16", catalog, @"0014-kanashimi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("17", catalog, @"0017-MREND_dbs_lune_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("18", catalog, @"0018-bukikobo.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("19", catalog, @"0021-yumeno.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("20", catalog, @"0024-skytosi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("21", catalog, @"0027-doukutu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("22", catalog, @"0028-yamidoukutu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("23", catalog, @"0029-lamp.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("24", catalog, @"0038-20_kagekara.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("25", catalog, @"0050-senran.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("26", catalog, @"asa_mori01.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("27", catalog, @"asa2_0007-guild.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("28", catalog, @"dark.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("29", catalog, @"debu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("30", catalog, @"firia1_ameuta.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("31", catalog, @"hiru_boukennojunbi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("32", catalog, @"hiru2_0025-rest.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("33", catalog, @"hiru2_0025-rest.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("34", catalog, @"kaisou_0003-cpn_etd10_3_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("35", catalog, @"madoromi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("36", catalog, @"op_sti_gymno_01_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("37", catalog, @"or_madono.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("38", catalog, @"piza_0004-wev_karyudo_ok.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("39", catalog, @"pon_tokinoodori_or.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("40", catalog, @"pon_tokinoodori_or_ENDING.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("41", catalog, @"sakaba01_rosa.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("42", catalog, @"syugosya.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("43", catalog, @"yoru_kaisou.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("44", catalog, @"yoru2_0020-yosagiri.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("45", catalog, @"yugata_slowlife.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("46", catalog, @"yugata2_0014-vil.mp3"));

            catalog = "Healing";
            bgmlist.Add(new Tuple<string, string, string>("To the earth someday", catalog, @"To_the_earth_someday.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("After School 1", catalog, @"After School.ogg"));
            bgmlist.Add(new Tuple<string, string, string>("ogg00054", catalog, @"ogg00054.ogg"));
            catalog = "Active";
            bgmlist.Add(new Tuple<string, string, string>("ogg00052", catalog, @"ogg00052.ogg"));
        }
        protected virtual string GetFileBGM(string name)
        {
            if (name == "STOP") return name;
            var val = bgmlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(bgmroot, val.Item2, val.Item3);
        }
        private string GetBGM(string name, string transform, bool randomstart, bool muted, bool runAtOnce)
        {
            string cadre = Story.GetCadreNum();
            string random_start_str = randomstart ? "F=1;" : string.Empty;
            string muted_str = muted ? "Y=1;" : string.Empty;
            string transform_str = (transform is null) ? null : $"T={transform};";
            string run_str = !runAtOnce ? $"R=1;" : null;
            return $"GROUP={cadre};KIND=6;A=1;{muted_str}{random_start_str}{transform_str}{run_str}DSC={Story.Chapter};ORD=1;FILE={GetFileBGM(name)}";
        }

        //Sound Effect
        List<Tuple<string, string, string>> seffectlist = new List<Tuple<string, string, string>>();
        string seffectroot = @"e:\!EPCATALOG\SOUND\EFFECT\";
        private void FillSoundEffest()
        {
            string catalog = "Other";
            seffectlist.Add(new Tuple<string, string, string>("Wear moving 1", catalog, @"ogg00071.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Door ring 1", catalog, @"door ring 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Вжик 1", catalog, @"Вжик.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Бум 1", catalog, @"Бум 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Бег 1", catalog, @"Бег 1.ogg"));
        }
        private string GetFileSEffect(string name)
        {
            var val = seffectlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(seffectroot, val.Item2, val.Item3);
        }
        private string GetSoundEffect(string name, int loop, string transform, bool randomstart, bool muted, bool runAtOnce)
        {
            string cadre = Story.GetCadreNum();
            string random_start_str = randomstart ? "F=1;" : string.Empty;
            string muted_str = muted ? "Y=1;" : string.Empty;
            string transform_str = (transform is null) ? null : $"T={transform};";
            string run_str = !runAtOnce ? $"R=1;" : null;
            return $"GROUP={cadre};KIND=6;A=1;{muted_str}{random_start_str}{transform_str}{run_str}DSC ={Story.Chapter};ORD=1;LoopMode={loop};FILE={GetFileSEffect(name)}";
        }
        protected virtual string GetMoan(string name)
        {
            string basecatalog = @"e:\!EPCATALOG\SOUND\MOAN\";
            List<Tuple<string, string>> bgmlist = new List<Tuple<string, string>>();
            bgmlist.Add(new Tuple<string, string>("1", @"2018 Silena Moor - Fuck 01.mp3"));
            bgmlist.Add(new Tuple<string, string>("2", @"2018 Silena Moor - Fuck 01 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("3", @"2018 Silena Moor - Fuck 02.mp3"));
            bgmlist.Add(new Tuple<string, string>("4", @"2018 Silena Moor - Fuck 02 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("5", @"2018 Silena Moor - Fuck 03.mp3"));
            bgmlist.Add(new Tuple<string, string>("6", @"2018 Silena Moor - Fuck 03 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("7", @"2018 Silena Moor - Fuck 04.mp3"));
            bgmlist.Add(new Tuple<string, string>("8", @"2018 Silena Moor - Fuck 04 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("9", @"2018 Silena Moor - Fuck 05.mp3"));
            bgmlist.Add(new Tuple<string, string>("10", @"2018 Silena Moor - Fuck 05 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("11", @"old-n-young.com-Pelmen-Anya_01.mp3"));
            bgmlist.Add(new Tuple<string, string>("12", @"old-n-young.com-Pelmen-Anya_02.mp3"));
            bgmlist.Add(new Tuple<string, string>("13", @"old-n-young.com-Pelmen-Anya_03.mp3"));
            bgmlist.Add(new Tuple<string, string>("14", @"old-n-young.com-Pelmen-Anya_04.mp3"));
            bgmlist.Add(new Tuple<string, string>("15", @"old-n-young.com-Pelmen-Anya_05.mp3"));
            bgmlist.Add(new Tuple<string, string>("16", @"old-n-young.com-Pelmen-Anya_06.mp3"));
            bgmlist.Add(new Tuple<string, string>("17", @"old-n-young.com-Pelmen-Anya_07_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("18", @"old-n-young.com-Pelmen-Anya_08.mp3"));
            bgmlist.Add(new Tuple<string, string>("19", @"old-n-young.com-Pelmen-Natasha_01_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("20", @"old-n-young.com-Pelmen-Natasha_02.mp3"));
            bgmlist.Add(new Tuple<string, string>("21", @"old-n-young.com-Pelmen-Natasha_03_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("22", @"old-n-young.com-Pelmen-Natasha_04.mp3"));
            bgmlist.Add(new Tuple<string, string>("23", @"old-n-young.com-Pelmen-Natasha_05.mp3"));
            bgmlist.Add(new Tuple<string, string>("24", @"old-n-young.com-Pelmen-Natasha_06.mp3"));
            bgmlist.Add(new Tuple<string, string>("25", @"old-n-young.com-Pelmen-Natasha_07.mp3"));
            bgmlist.Add(new Tuple<string, string>("26", @"old-n-young.com-Pelmen-Natasha_08.mp3"));
            bgmlist.Add(new Tuple<string, string>("27", @"old-n-young.com-Pelmen-Natasha_09_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("28", @"old-n-young.com-Pelmen-Sasha_01.mp3"));
            bgmlist.Add(new Tuple<string, string>("29", @"old-n-young.com-Pelmen-Sasha_02.mp3"));

            var val = bgmlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(basecatalog, val.Item2);
        }
        public string SE() 
        {
            return GetSoundEffect(CurrentSE, 0, null, false, false, true);
        }
        public string SEMuted(string transform)
        {
            return GetSoundEffect(CurrentSE, 0, transform, false, false, false);
        }

    }
}
