using StoGen.Classes.Story;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StoGen.Classes.Story.Persons;

namespace StoGen.Classes.Story
{
    public class Story02 : StoryMaker
    {
        public static string Name = "Story 02";

        protected Person Girl;
        protected CadreText Text;
        //protected Location Place;
        protected CadreSound Sound;
        protected Dictionary<string, string> Events;
        protected Dictionary<string, string> BGM;
        protected Dictionary<string, string> Expression;
        protected Dictionary<string, string> Locations;
        protected Dictionary<string, string> Effects;




        public Story02() : base()
        {
            Text = new CadreText(this);
            //Place = new Location(this);
            Sound = new CadreSound(this);
        }

        private void CreateData()
        {
            Girl = new Person(this, "Ксения");
            Girl.Titles.Add("любимая");

            //BGM = new Dictionary<string, string>();
            //BGM.Add("Komari", "0006-komari.mp3");

            Effects = new Dictionary<string, string>();
            Effects.Add("Wear moving", "Wear moving 1");
            Effects.Add("Door ring", "Door ring 1");
            Effects.Add("Вжик", "Вжик 1");
            Effects.Add("Бум", "Бум 1");
            Effects.Add("Бег мальчик", "Бег 1");
            Effects.Add("Бег девочка", "Бег 2");
            Effects.Add("Шаги в лесу 1", "шаги в лесу 1");

            // Creating events from figure
            Girl.Events.Add(new Tuple<string, string>("Event 1", @"e:\!CATALOG\PERSONS\!FEM\VAR\Azuki Kurenai\001\Event 001.jpg"));
            Girl.Events.Add(new Tuple<string, string>("Event 2", @"e:\!CATALOG\PERSONS\!FEM\VAR\Azuki Kurenai\002\001.jpg"));
            Girl.Events.Add(new Tuple<string, string>("Event 3", @"e:\!CATALOG\PERSONS\!FEM\VAR\Azuki Kurenai\003\002.jpg"));
            Girl.Events.Add(new Tuple<string, string>("Event 4", @"e:\!CATALOG\PERSONS\!FEM\VAR\Azuki Kurenai\004\001.jpg"));

            Events = new Dictionary<string, string>();
            this.Story.Add("@001\nЭто была фотка, сделанная Лысым, когда вчера они все вместе развлекались у него."
                + "~~Ксения немного смущенно хихикнула:~'-Ну да, наш хозяин оказался не из скромных."                
                + "~Как только ты ушел, он сразу взялся за меня.'"
                + "~Я смогла ему сопротивляться, но в конце он ... чуть не добился своего..." 
                + "~А все потому, что тебя слишком долго не было!'"
                );
            this.Story.Add("@002\nЭто была фотка, которую сделал наш вчерашний гость, когда вчера мы все вместе развлекались."
                + "~~Ксения смущенно покраснела:~'-Он оказался совсем не из скромных..."
                + "~Как только ты ушел, он сразу взялся за меня.'"
                + "~Я ему сопротивлялась, но он ... чуть не вставил свой хуй..."
                + "~Тебя слишком долго не было.."
                + "~А в следующий раз он может выебать меня!'"
                );            

        }


        string transform_Disapearing_2 = "W..1500>O.B.500.-100";
        string transform_Disapearing_3 = "W..500>O.B.500.-100";
        string transform_Disapearing_4 = "W..250>O.B.500.-100";
        string transform_Apearing_1 = "W..3000>O.B.500.100";
        string transform_Appearing_3 = "W..500>O.B.500.100";
        string transform_Appearing_4 = "W..250>O.B.500.100";
        string transform_Appearing_5 = "W..2000>O.B.500.100";
        string transform_Appearing_6 = "W..1000>O.B.1000.75";
        string transform_Appearing_7 = "W..1500>O.B.1000.75";
        string transform_Appearing_8 = "W..1000>O.B.500.100";
        string transform_sound_delay_1 = $"W..500>p.A.0.1";
        string transform_sound_delay_2 = $"p.A.0.1";
        private void AddHeader()
        {
            AddChapter("0-Header");

            int size_frame_2 = 920; int x_frame_2 = 1780; int y_frame_2 = 750; string template_frame_2 = "301";
            int size_frame_main = 1920; int x_frame_main = 0; int y_frame_main = 0; string template_frame_main = "0"; string transition_main = "W..1500>O.B.500.-100";
            int size_frame_main_2 = 2550; int x_frame_main_2 = -630;

            int size_frame_1 = 1000; int x_frame_1 = 1560; int y_frame_1 = 0; string template_frame_1 = "300";
            int size_figure = 1920; int x_figure = 0; int y_figure = 0; string template_figure = "8";
            int size_event = 1000; int x_event = 100; int y_event = 100; string template_event = "9";
            int size_hero_avatar = 815; int x_hero_avatar = 1800; int y_hero_avatar = 732; string template_hero_avatar = "7";
            string template_location = "300";
            string template_text = "1";
            int z = 0;


            CadreNum = CadreNum + 1;
            string cadre = CadreNum.ToString("D3");
            //string protagonst = @"e:\!EPCATALOG\AVATAR\GOOD\0003.png";
            //string background = @"e:\!EPCATALOG\LOCATION\BEDROOM\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -evening.png";
            string mainfigure = @"e:\!CATALOG\PERSONS\!FEM\VAR\Azuki Kurenai\001\Event 001_body.jpg";
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            int ord = 0;
            //text template
            ord++;
            Scenario.Add(GetText(cadre, ". . . . . . . . . . . . .", 1200, 800, 1000, 100, 2, 0, 2, 0, template_text, true));
            //location template
            ord++; z = 0;
            //Scenario.Add(GetImage(cadre, "Location backgroung 01", background, size_frame_main, x_frame_main, y_frame_main, z, ord, null, template_location, true));
            ord++; z = 0;
            //Scenario.Add(GetImage(cadre, "Location backgroung 02", background, size_frame_main_2, x_frame_main_2, y_frame_main, z, ord, null, template_location, true));
            // protagonist avatar template
            ord++; z = 11;
            //Scenario.Add(GetImage(cadre, "Hero avatar", protagonst, size_hero_avatar, x_hero_avatar, y_hero_avatar, z, ord, null, template_hero_avatar, true));
            // event template
            ord++; z = 5;
            Scenario.Add(GetImage(cadre, "Event", mainfigure, 1300, 50, 50, z, ord, null, template_event, true));
            // figure template
            ord++; z = 10;
            //Scenario.Add(GetImage(cadre, "Figure", mainfigure, 1300, 50, 50, z, 0, null, template_figure, true));
            // frame template
            ord++; z = 0;
            //Scenario.Add(GetFrame(cadre, "Frame 01", "Frame 01", size_frame_1, x_frame_1, y_frame_1, z, ord, null, template_frame_1, true));
            ord++; z = 1;
            //Scenario.Add(GetFrame(cadre, "Frame 02", "Frame 02", size_frame_2, x_frame_2, y_frame_2, z, ord, null, template_frame_2, true));
            ord++; z = 20;
            Scenario.Add(GetFrame(cadre, "Black background", "Black", size_frame_main, x_frame_main, y_frame_main, z, ord, transition_main, template_frame_main, true));

            Girl.Template = template_event;
        }

        protected override void GenerateScenario()
        {
            CreateData();
            AddHeader();            
            Chapter1("Chapter 1", "Chapter 1");
        }
        
        protected virtual void Chapter1(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            //AddCadre(); Text.Show(". . . . . . . . . . . .");
            //Sound.CurrentSE = Effects["Wear moving"];
            //Place.Current = Locations["Hero room morning"];


            Girl.CurrentEvent = "Event 1";
            Sound.CurrentBGM = "6";
            AddCadre(); Girl.SmartShowEvent(); Text.Show("@001"); Sound.Bgm(); Sound.SE();
            AddCadre(); Girl.SmartShowEvent(); Text.Show("@002");
            Girl.CurrentEvent = "Event 2"; AddCadre(); Girl.SmartShowEvent(); Text.Show("@002");
            Girl.CurrentEvent = "Event 3"; AddCadre(); Girl.SmartShowEvent(); Text.Show("@002");
            Girl.CurrentEvent = "Event 4"; AddCadre(); Girl.SmartShowEvent(); Text.Show("@001");
            /*

            
            AddCadre(); Girl.CombineFigure(); Text.Show($"[{Girl.Name}]~'О-о . . . Хорошо тут сидеть . . .'");
            AddCadre(); Girl.CombineFigure(); Text.Show($". . . Я чувствую приятную мягкую тяжесть на себе . . .'");
            AddCadre(); Girl.CombineFigure($"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"); Text.Show($"[{Girl.Name}]~'*вздыхает* Может мне отохнуть здесь . . . ?'");
            AddCadre(); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"); Text.Show($". . . Это немного . . . тяжело . . .'");
            AddCadre(); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"); Text.Show($"[{Girl.Name}]~. . . Я наверно  позавтракаю прямо здесь. . .'");
            AddCadre(); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"); Text.Show($". . . Ты не ела дома. . ?'");
            AddCadre(); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"); Text.Show($"[{Girl.Name}]~. . . А может, просто растянуться здесь и полежать. . ?''");
            AddCadre(); Girl.CombineFigure(); Text.Show($". . . Все, я понял, понял. . .  уже встаю. . .''");


            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);


            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ну, если так. . Тогда проснись и пой . .!"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . Мое покрывало тут же забрали . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . Я уже начинаю привыкать к этому . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . Ой . . "); Place.SmartShow(); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Хих . . . Ты забыл об этом . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Но я уже привыкла обычно будить тебя . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . Для того чтобы наслаждаться этим общением и ее красотой . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . признаюсь честно, я иногда специально просыпал . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Suprised, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . Мы с ней друзья с детства . ."); Place.SmartShow(); Girl.CombineFigure(); Sound.BgmStop();
            AddCadre(); Text.Show($". . И еще - я люблю ее . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Возможно, она еще не совсем женщина, но какая же она заботливая"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Наверно как нибудь я об этом подумаю . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Какая же у ней улыбка . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Я просто постоянно думаю о ней . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Suprised, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~Давай быстрей собирайся . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show(". . . .");
            AddCadre(); Text.Show(". . . . Мы были обычными соседями сначала, и не были близкими друзьями . . .");
            AddCadre(); Text.Show(". . . . Ее родители развелись, когда мы еще были детьми . . .");
            AddCadre(); Text.Show(". . . . И я довольно часто видел ее на улице одну . . .");
            AddCadre(); Text.Show(". . . . Когда я позвал ее, она была счастлива . . .");
            AddCadre(); Text.Show(". . . . И мы стали проводить время вместе . . .");
            AddCadre(); Text.Show(". . . . Возможно . . . у нее нет романтических чувств ко мне . . .");
            AddCadre(); Text.Show(". . . . Но у меня - есть . . . они возникли в общем-то недавно . . .");
            */
        }


    }

}

