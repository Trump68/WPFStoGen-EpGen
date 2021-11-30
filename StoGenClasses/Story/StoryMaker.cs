using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
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
        public int CurrCadreIdx = -1;
        public int PrevCadreIdx = -1;
        public int NextFreeZ = 0;
        public List<string> Scenario = new List<string>();
        public static string TransitionAppear750 = $"O.B.750.100";
        public static string TransitDissappear1000 = "O.B.1000.-100";
        public static string TransitDissappear250 = "O.B.250.-100";
        public static string StoryPath;

        public string GetCadreNum()
        {
            return CadreNum.ToString("D3");
        }
        public static string GetValue(string input, string template)
        {
            string result = string.Empty;
            int index = input.IndexOf(template);
            if (index > -1)
            {
                index = index + template.Length;
                string cr = input[index].ToString();
                while (cr != ";")
                {
                    result = result + cr;
                    index = index + 1;
                    if (input.Length <= (index))
                        break;
                    cr = input[index].ToString();
                }
            }
            return result;
        }
        public void AddOldFrame(string lastframe)
        {
            string test = ";Z=";
            string old = lastframe;
            string oldval = StoryMaker.GetValue(old, ";Z=");
            if (!string.IsNullOrEmpty(oldval))
            {
                int newval = Convert.ToInt32(oldval);
                old = old.Replace($";Z={oldval}", $";Z={(newval - 1)}");
            }
            else
            {
                old = $"{old};Z={(Convert.ToInt32(oldval) - 1)}";
            }
            oldval = StoryMaker.GetValue(old, ";O=");
            if (!string.IsNullOrEmpty(oldval))
            {                
                old = old.Replace($";O={oldval}", $";O={100}");
            }
            else
            {
                old = $"{old};O={100}";
            }

            oldval = StoryMaker.GetValue(old, "GROUP=");
            old = old.Replace($"GROUP={oldval}", $"GROUP={GetCadreNum()}");

            oldval = StoryMaker.GetValue(old, ";T=");
            if (!string.IsNullOrEmpty(oldval))
            {
                //old = old.Replace($";T={oldval}", $";T={StoryMaker.TransitDissappear2000}>{oldval}");
                old = old.Replace($";T={oldval}", $";T={Trans.Wait(500)}>{StoryMaker.TransitDissappear250}");
            }
            else 
            {
                old = $"{old};T={Trans.Wait(500)}>{StoryMaker.TransitDissappear250}";
            }            
            Scenario.Add(old);
        }

        public void Generate(string path)
        {
            StoryMaker.StoryPath = path;
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
        protected virtual void AddChapter(string chapter, string description = null)
        {
            Chapter = chapter;
            string dsc = string.IsNullOrEmpty(description) ? chapter : description;
            Scenario.Add($"GroupId={Chapter};DSC={dsc};ORD=1");
        }

        protected void AddCadre()
        {
            CadreNum++;
            string cadre = GetCadreNum();
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            PrevCadreIdx = CurrCadreIdx;
            CurrCadreIdx = Scenario.Count() - 1;
            NextFreeZ = 0;
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
            return AddByTemplate(dsc, null, null, kind, z, o, template, file, trans);
        }
        public string AddByTemplate(string dsc, string x, string y, int kind, int z, int o, string template, string file, string trans)
        {
            string cadre = GetCadreNum();
            string str_x = (string.IsNullOrEmpty(x)) ? string.Empty : $";X={x}";
            string str_y = (string.IsNullOrEmpty(y)) ? string.Empty : $";Y={y}";
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
            return $"GROUP={cadre};KIND={kind};DSC={dsc};O={o};TEMPLATE={template}{str_file}{str_transform}{str_z}{str_x}{str_y}";
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

    public class CadreText
    {
        public CadreText(StoryMaker story) 
        {
            Story = story;
        }
        public string Template = null;
        StoryMaker Story;
        public string OldShow(string text) 
        {
            return Story.AddTextByTemplate(Template, text);
        }
        public void Show(string text)
        {
            Story.Scenario.Add(Story.AddTextByTemplate(Template, text));
        }
    }

}
