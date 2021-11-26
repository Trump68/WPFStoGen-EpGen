using StoGen.Classes.Story;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class Story01 : StoryMaker
    {
        public Story01() : base()
        {
            Girl = new She_Falls_to_a_Perverted_Bastard(this);
            Bastard = new Perverted_Bastard(this);
            GuyA = new Siluette(this);
            GuyB = new Siluette(this);

            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);
            
            Events = new Dictionary<string, string>();            
            Events.Add("1", "Event 001");
            Events.Add("2", "Event 002");
            Events.Add("3", "Event 003");
            Events.Add("4", "Event 004");
            Events.Add("5", "Event 005");
            Events.Add("6", "Event 006");
            Events.Add("7", "Event 007");
            Events.Add("8", "Event 008");

            BGM = new Dictionary<string, string>();
            BGM.Add("Good morning", "ogg00052");
            BGM.Add("After School", "After School 1");
            BGM.Add("ogg00054", "ogg00054");
            BGM.Add("Runned into it", "Runned into it");
            BGM.Add("In the Barn", "In the Barn");

            Expression = new Dictionary<string, string>();
            Expression.Add("smiling", "smiling");
            Expression.Add("calm smiling", "calm smiling");
            Expression.Add("agitated tiny smile", "agitated tiny smile");
            Expression.Add("laughing", "laughing");
            Expression.Add("amusing", "amusing");
            Expression.Add("tiny smile", "tiny smile");

            Locations = new Dictionary<string, string>();
            Locations.Add("Hero room morning", "Childroom 001 morning");
            Locations.Add("Hero room evening", "Childroom 001 evening");
            Locations.Add("Girl room evening", "Childroom 002 evening");
            Locations.Add("Street morning", "Street 002 morning");
            Locations.Add("Street evening", "Street 002 evening");
            Locations.Add("Class day", "Class 002 day");
            Locations.Add("Schoolyard day", "Building 001 day");
            Locations.Add("Schoolyard morning", "Building 001 morning");
            Locations.Add("House evening", "Building 002 evening");
            Locations.Add("School hall day", "School hall 001 day");
            Locations.Add("Forest day", "Forest 001 day");
            Locations.Add("Сарай", "Childroom 003 night");
            Locations.Add("Раздевалка", "School dresser 001 day");
            

            Effects = new Dictionary<string, string>();
            Effects.Add("Wear moving", "Wear moving 1");
            Effects.Add("Door ring", "Door ring 1");
            Effects.Add("Вжик", "Вжик 1");
            Effects.Add("Бум", "Бум 1");
            Effects.Add("Бег мальчик", "Бег 1");
            Effects.Add("Бег девочка", "Бег 2");
            Effects.Add("Шаги в лесу 1", "шаги в лесу 1");
            

        }
        private List<Tuple<string, string>> BGMResources = new List<Tuple<string, string>>();

        int size_frame_2 = 920; int x_frame_2 = 1780; int y_frame_2 = 750; string template_frame_2 = "301";
        int size_frame_main = 1920; int x_frame_main = 0; int y_frame_main = 0; string template_frame_main = "0"; string transition_main = "W..1500>O.B.500.-100";
        int size_frame_main_2 = 2550; int x_frame_main_2 = -630;

        int size_frame_1 = 1000; int x_frame_1 = 1560; int y_frame_1 = 0; string template_frame_1 = "300";
        int size_figure = 1920; int x_figure = 0; int y_figure = 0; string template_figure = "8";
        int size_event = 1000; int x_event = 100; int y_event = 100; string template_event = "9";
        int size_hero_avatar = 815; int x_hero_avatar = 1800; int y_hero_avatar = 732; string template_hero_avatar = "7";
        string template_location = "300";
        string transitionlocation = "W..3000>O.B.500.-100";
        string template_text = "1";
        int z = 0;
        string Name_Girl = "Комаки";
        string Name_Hero = "Кохеи";
        string Name_Bastard = "Футоши";
        string bastard_title = "мальчик";
        string girl_title = "сестренка";
        

        Person Girl;
        Person Bastard;
        Person GuyA;
        Person GuyB;

        CadreText Text;
        Location Place;
        CadreSound Sound;

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

        string transform_squizee = $"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}";

        Dictionary<string, string> Events;
        Dictionary<string, string> BGM;
        Dictionary<string, string> Expression;
        Dictionary<string, string> Locations;
        Dictionary<string, string> Effects;

        private void SetGirlExpression_AgitatedSmile()
        {
            Girl.SetVisibleExpression("Middle", "Smile wide", "Wide open stright");
        }
        private void SetGirlExpression_Surprised()
        { 
            Girl.SetVisibleExpression("Middle", "Open wide", "Up stright amused");
        }
        private void SetGirlExpression_Troubled()
        {
            Girl.SetVisibleExpression("Middle", "Open wide", "Up stright troubled");
        }
        private void SetGirlExpression_Laughing()
        {
            Girl.SetVisibleExpression("Middle", "Smile wide", "Closed");
        }
        private void SetGirlWear_Shchool_Dress()
        {
            Girl.SetVisibleView("Middle", "School Dress", null);
        }
        private void SetGirlWear_Shchool_Dress_Cleavage()
        {
            Girl.SetVisibleView("Middle", "School Dress cleavage", null);
        }
        private void SetGirlWear_Sportwear_wet()
        {
            Girl.SetVisibleView("Middle", "Sportwear wet", null);
        }
        private void SetGirlWear_Sportwear()
        {
            Girl.SetVisibleView("Middle", "Sportwear", null);
        }
        private void SetBastard()
        {
            Bastard.SetVisibleView("Middle", "Default", "Default");
        }


        protected override void GenerateScenario()
        {            
            AddHeader();

            Girl.Template = template_figure;            
            Girl.Z = 5;

            Bastard.Template = template_figure;
            Bastard.Z = 8;

            GuyA.Template = template_figure;
            GuyA.Z = 8;
            GuyA.O = 75;
            GuyB.Template = template_figure;
            GuyB.Z = 9;
            GuyB.O = 75;



            Text.Template = template_text;

            Place.Template = template_location;
            Place.Z = 0;
            Place.Description = "Location background";
            

            Chapter1();
            Chapter2();
            Chapter3();
            Chapter4();
            Chapter5();
            Chapter6();
            Chapter7();
            Chapter8();
            Chapter9();
            Chapter10();
            Chapter11();
            Chapter12();
            Chapter13();
            Chapter14();
            Chapter15();
            Chapter16();
        }
        private void Chapter1()
        {
            AddChapter("Chapter 1");


            CadreNum++; OldAddCadre(Text.OldShow(". . . . . . . . . . . ."));
            CadreNum++; OldAddCadre(Text.OldShow("Взглядов на жизнь на свете так же много, как много и людей."));
            CadreNum++; OldAddCadre(Text.OldShow(". . . Некоторые люди возможно заставят вас успешно сдать экзамен или найти работу."));
            CadreNum++; OldAddCadre(Text.OldShow(". . . Некоторые люди возможно скажут вам не тратить время зря."));
            CadreNum++; OldAddCadre(Text.OldShow(". . . Но дремать, наслаждаясь комфортом - это одна из разновидностей счастья."));
            CadreNum++; OldAddCadre(Text.OldShow(". . . Что я и делаю сейчас . . ."));
            CadreNum++; OldAddCadre(Text.OldShow("[Голос]~'Эй ...'"));
            CadreNum++; OldAddCadre(Text.OldShow(". . . похоже это . . ."));
            CadreNum++; OldAddCadre(Text.OldShow("[Голос]~'Эй . . . Просыпайся . . .'"));
            CadreNum++; OldAddCadre(Text.OldShow(". . . похоже это . . ."));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~'АХХ!!! . . . ДА ПРОСЫПАЙСЯ УЖЕ !!!'"));

            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];            
            Sound.CurrentSE = Effects["Wear moving"];
            Place.Current = Locations["Hero room morning"];
            


            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Apearing_1),
                Text.OldShow(". . . Ох! Ну что еще? . . ."),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Girl}]~'О-о . . . Хорошо тут сидеть . . .'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($". . . Я чувствую приятную мягкую тяжесть на себе . . .'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"),
                Text.OldShow($"[{Name_Girl}]~'*вздыхает* Может мне отохнуть здесь . . . ?'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($". . . Это немного . . . тяжело . . .'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Girl}]~. . . Я наверно  позавтракаю прямо здесь. . .'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($". . . Ты не ела дома. . ?'")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Girl}]~. . . А может, просто растянуться здесь и полежать. . ?''")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($". . . Все, я понял, понял. . .  уже встаю. . .''")
                );

            //Expression && Wear
            SetGirlWear_Shchool_Dress();
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Girl}]~. . . Ну, если так. . Тогда проснись и пой . .!"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($". . . Мое покрывало тут же забрали . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($". . . Я уже начинаю привыкать к этому . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . Ой . . "),
                Place.OldShow()
                );


            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Хих . . . Ты забыл об этом . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Но я уже привыкла обычно будить тебя . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . Для того чтобы наслаждаться этим общением и ее красотой . ."),
                Place.OldShow()
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . признаюсь честно, я иногда специально просыпал . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"),
                Place.OldShow()
                );


            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Sound.oldBgmStop(),
                Text.OldShow($". . Мы с ней друзья с детства . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . И еще - я люблю ее . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Возможно, она еще не совсем женщина, но какая же она заботливая"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Наверно как нибудь я об этом подумаю . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Какая же у ней улыбка . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Я просто постоянно думаю о ней . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Girl}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Давай быстрей собирайся . . !"),
                Place.OldShow()
                );


            CadreNum++; OldAddCadre(Text.OldShow(". . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . Мы были обычными соседями сначала, и не были близкими друзьями . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . Ее родители развелись, когда мы еще были детьми . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . И я довольно часто видел ее на улице одну . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . Когда я позвал ее, она была счастлива . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . И мы стали проводить время вместе . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . Возможно . . . у нее нет романтических чувств ко мне . . ."));

            CadreNum++; OldAddCadre(Text.OldShow(". . . . Но у меня - есть . . . они возникли в общем-то недавно . . ."));
        }
        private void Chapter2()
        {
            AddChapter("Chapter 2");

            Place.Current = Locations["Street morning"];
            Sound.CurrentBGM = BGM["Good morning"];

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Apearing_1),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Text.OldShow($"[{Name_Girl}]~. . . Ну что, ты проснулся наконец . . ?"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );
           

            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"Ой . . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Извини, я задумался . . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Да ладно, даже когда я с тобой? Соберись уже . . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[Бежать в школу со всех ног уже вошло в привычку.]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Она могла бы уже давно быть в школе, но она не хочет меня бросать.]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . А я пользуюсь ее добротой . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Ну серьезно. . . Почему ты всегда убегаешь . . ?"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Может потому что ты всегда спишь?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Это напрягает тебя?"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Хмм, все равно, я бегу на занятия в свой клуб . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Ладно, я могла бы иногда проводить больше времени с тобой, как мы иногда делаем . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Такие дни просто класс . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Я могу тебя будить, как только сама встаю. . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Вот всегда она так . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Я боюсь за наши отношения  . . ]"),
                Place.OldShow()
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Girl}]~. . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Text.OldShow($"[. . . Из-за того, что она слишком наивная и немного нерешительная  . . ]"),
                Place.OldShow()
                );
            
            CadreNum++; OldAddCadre(
                Text.OldShow($"[. . . . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[. . . Ха? ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[. . . Погоди . . . {Name_Girl} . . . ты слишком быстро бежишь . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(transform_Disapearing_3),
                Text.OldShow($"[. . . Она капитан команды болельщиц. . .]")
                );

            CadreNum++; OldAddCadre(Text.OldShow($"[. . . Запыхавшись, я все-таки догнал ее. . .]"));

        }
        private void Chapter3() 
        {
            AddChapter("Chapter 3");

            //Expression
            SetGirlExpression_Surprised();

            Place.Current = Locations["Class day"];
            Sound.CurrentBGM= BGM["After School"];

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Apearing_1),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Text.OldShow($"[{Name_Girl}]~. . . Ух, еле успели . . !"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . .  . . "),
                Place.OldShow());

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . уф . . уф . . ."),
                Place.OldShow());

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Ох. . . как-то . . справились . . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Отлично, тогда пока, увидимся позже . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(                
                Girl.oldFigure(transform_Disapearing_3),
                Text.OldShow($". . . Пока . . !"),
                Place.OldShow()
                );

            //stop musik
            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Text.OldShow($"[ Фу . . Делать это каждый раз тяжеловато. Она слишком шустрая, а я не привык к этому ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(                
                Text.OldShow($"[ Она как парень . . . или как приятель . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . Может она и не догадывается, но она очень популярна среди парней . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . Хотя еще никто не подкатывал к ней, потому что я всегда ее сопровождаю . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . (Хоть это мне и не особо помогает) . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . (Или скорей это как-то странно, потому что я сам не знаю что делать) . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[Учитель]~ . . . Хорошо, начнем урок . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($" . . . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . (Как обычно, я думаю только об этом) . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[ . . . И слишком мало думаю об экзамене . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(                
                Text.OldShow($"[ . . . И слишком много - об романтике, что делает меня неуверенным . . .]"),
                Place.OldShow()
                );
        }
        private void Chapter4() 
        {
            AddChapter("Chapter 4");

            //Figure
            SetGirlWear_Sportwear_wet();
            //Expression
            SetGirlExpression_AgitatedSmile();

            Place.Current = Locations["Schoolyard day"];
            Sound.CurrentBGM = BGM["ogg00054"];

            CadreNum++; OldAddCadre(
                Sound.oldBgmMuted(transform_sound_delay_1),
                Text.OldShow($". . . Ах да . . "),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($". . . {Name_Girl} сегодня на тренировке команды болельщиц . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[Я рассеяно смотрю на школьный двор . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Girl}]~Ой . . . наконец я тебя нашла ! ! !"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(// д.краснеет(ее майка стала прозрачная от пота)
                Girl.oldFigureHidden(transform_Apearing_1),
                Text.OldShow($"[{Name_Girl}]~. . . Ну, как дела ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Если честно, просто сопровождать ее домой, для меня уже счастье . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . И я чувствую, как сильно бьется мое сердце . . .]"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Я вижу тебя за милю . . !"),
                Place.OldShow()
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . Погоди . . !"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . И я могу видеть ее лифчик. . . и ее грудь . . ]"),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Ты в порядке . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . ммммм . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Ой. . . ладно, ничего . . "),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . смотрю на небо, как идиот . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . Облака . . "),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . Ты в порядке . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Слушай, [{Name_Hero}], иногда ты очень странный . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Когда я тебя вижу, то невольно хочу подойти . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[Капитан команды]~Ей, {Name_Girl} ! . . А кто сказал, что тренировка закончена . . ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Упс . . нет, я не закончила тренировку . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~Капитан следит за мной все время . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . Все нормально . . ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Неожиданно для себя, я наклоняюсь к ней . . ."),
                Place.OldShow()
                );


            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}] . . . Хмм . . Думаю, он всего лишь слишком строгий . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Когда дело касается романтических чувств, она очень наивная . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Она не думает о том, что эти парни смотрят на нее как на потенциальную партнершу для любви . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Просто потому, что никто не подходит к ней . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"Хотя она нак привлекательна . . . больше чем они могут себе представить . . ."),
                Place.OldShow()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}] . . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}] . . . Увидимся . . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Sound.oldBgmStop(),
                Text.OldShow($" . . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($" . . . Она собирается продолжить тренировку, в ТАКОМ виде . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($" . . . Уверен, все парни будут пялиться на нее . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($" . . . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($" . . .  Как не смотри, а она очень женственна . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(transform_Disapearing_3)
                );
        }
        private void Chapter5()
        {
            AddChapter("Chapter 5", "Chapter 5 - Попытка скоротать грустный вечер с другом.");


            //Figure
            SetGirlWear_Shchool_Dress();
            //Expression
            SetGirlExpression_Troubled();


            Place.Current = Locations["Street evening"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ уф, тренировка закончена. . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . я иду домой одна. . . ]"));


            CadreNum++; OldAddCadre( 
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . во время тренировки. . . я просто бегаю и не могу ни о чем другом думать . . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . и это мне не нравится . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . я приду домой, но там никого нет. . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . и даже если кто-то будет дома, это мне не поможет никак. . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["House evening"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Как я и предполагала - дома никого нет. .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Когда моих родителей нет дома, я чувствую облегчение. .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. .  ведь тогда мне не нужно бороться с чувством неловкости . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. .  но в то же время, когда их нет - мне одиноко . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. .  и так было всегда . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. .  . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["Girl room evening"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Но я так и не привыкла быть одной  . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Было время когда я проводила время на улице  . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[(*вздыхает*) здесь мне нечего делать . . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Когда это становится невыносимым, я опять делаю это . .]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . ладно тогда . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . . .]"),
                Place.OldShow(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            //effect
            Sound.CurrentSE = Effects["Door ring"];
            
            CadreNum++; OldAddCadre(
                Text.OldShow($". . *звонок* . ."),
                Sound.oldSE()
                );
    
            CadreNum++; OldAddCadre(Text.OldShow($". . . ."));

            Place.Current = Locations["Hero room evening"];

            CadreNum++; OldAddCadre(
                Text.OldShow($". . Хи-я-я-я !. ."),
                Place.OldShow()
                );

            Sound.CurrentBGM = BGM["Good morning"];
            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Apearing_1),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Text.OldShow($"[{Name_Hero}]~[. . О-о-о. .]"),
                Place.OldShow()             
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Хих . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . {Name_Hero},ты устал верно? Давай поедим снеков  . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . Извини . . . я только поужинал  . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . Подожди . . . а кто тебя впустил  . . ?]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . М-м . . . твоя . . мама  . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );


            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . Ух  . .  почему я не могу побыть один . . .]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Он иногда говорит такое  . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Но мой друг . . будет со мной . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Наверно я злоупотребляю его терпением . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~. . Итак  . .  что ты там говорила про снеки . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Ну вот видите . . !]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . Их полно в магазине, так что . . давай их возьмем . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~[. . Я их уже принесла . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . Серьезно  . .  ты только снеки купила . . ?]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . Да мне все равно . . !]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . Хих . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Place.OldShow(transform_Disapearing_3),
                Text.OldShow($". . . . ")                
                );

        }
        private void Chapter6()
        {
            AddChapter("Chapter 6", "Chapter 6 - Утренний стояк и неловкость");

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . Получается, я все время создаю ему проблемы . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . Я знаю, что мне нужно изменить это . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . И мне от этого грустно . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . [{Name_Hero}], мне очень жаль . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . я бы хотела, чтобы все продолжалось так, как сейчас. .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . и чтобы ничего не менялось . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . я знаю, что надо относиться к ней . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[? ? ?]~. . Эй . ."));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . не как к другу . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[? ? ?]~. . Проснись . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . а как к той, кого я люблю . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . да проснись уже . . !"));

            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];
            Sound.CurrentSE = Effects["Wear moving"];

            CadreNum++; OldAddCadre(
                           Girl.oldEventHidden(transform_Appearing_3),
                           Text.OldShow(". . . Вау . . ."),
                           Sound.oldBgm(),
                           Sound.oldSE()
                           );
            
            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Girl}]~. . . Опять? Тебе самому не надоело . . ?")
                           );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . уф . ."));

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Girl}]~(*вздох*). . . Я устала от этого уже . . ?")
                           );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Hero}]~. . живот . . болит . .")
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Hero}]~[. . стоп, во первых, я не мог заснуть, потому что слишком много вчера сьел . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Hero}]~[. . так что это ЕЕ вина . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Hero}]~[. . и я наконец сегодня посплю . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent( $"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Hero}]~. . накрываюсь одеялом с головой . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(transform_Disapearing_3),
                Text.OldShow($"[{Name_Girl}]~. . Эй ! Кончай прятаться и вылезай из под одеяла . . !")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~[. . Говори что хочешь - мне все равно, даже если опоздаю в школу . .]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Girl}]~(*вздыхает*). . Ну хорошо - вижу, что это не поможет . .")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~. . . .")
                );

            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Text.OldShow($"[{Name_Hero}]~. .")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~. . ?")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~тишина. .")
                );

            Girl.CurrentEvent = Events["2"];

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Girl}]~(*посапывает*)"),
                           Sound.oldBgm()
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent( $"{Trans.ImpactHs(200, 100)}"),
                           Text.OldShow($"[{Name_Hero}]~так ты тоже спишь . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Girl}]~(*посапывает*)")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                           Text.OldShow($"[{Name_Hero}]~у нее должно быть много дел. .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . я чувствую что-то мягкое . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . вместе с моим другом детства . . то есть с девушкой которую я люблю . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . может это . . опасно . . ?]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($". . *жим* . . *жим* . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . ого . . неважно, что об этом думать, но это не выглядит как дружба . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . от ее тепла . . я стал представлять, как она лежит подо мной . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . на что это похоже . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Hero}]~[ . . ух . . становится жарко . .]")
                           );            

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(Events["1"]),
                           Girl.oldEvent(Events["2"], transform_Disapearing_4),
                           Text.OldShow($"[{Name_Girl}]~Ох . . . Я заснула . . .")
                           );

            Girl.CurrentEvent = Events["1"];

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Name_Girl}]~[ . . черт . .]")            
                           );

            Place.Current = Locations["Hero room morning"];

            CadreNum++; OldAddCadre(
                Text.OldShow($". . {Name_Girl} быстро встала . ."),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Appearing_4),
                Text.OldShow($"[{Name_Girl}]~. . А а а а . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Girl}]~. . Что ты тут делал . . ? !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~. . я . . ничего . . ? !"),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . Не знаю что происходит, но это многое упрощает . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . Давай, проснись и пой . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . если я что-то не сделаю. . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[. . если она увидит мой стояк, она будет смеяться надо мной до конца жизни. . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~ . . сейчас, подожди . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[ . . она силой забрала одеяло у меня . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[ . . нет . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . "),
                Place.OldShow(),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~ . . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~[ . . она не заметила . . ?]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~. . а . ?"),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . . "),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Girl}]~. . ну давай, пошли уже. ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~. . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Name_Hero}]~. . понял . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_4),
                Text.OldShow($". . . ."),
                Place.OldShow(transform_Disapearing_4)
                );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . она . . не сказала ни слова . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . но я уверен, что она видела . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . . . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . стоп, а она вообще думает об ЭТИХ вещах. . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . например, представляя как она обнимает другого человека . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . как она склоняется к незнакомцу . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . я чувствую ревность . . ]"));
        }
        private void Chapter7() 
        {
            AddChapter("Chapter 7", "Chapter 7 - Первая встреча с мерзавцем.");

            Sound.CurrentBGM = BGM["Good morning"];           
            Place.Current = Locations["Street morning"];
            // expression
            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(      
                Girl.oldFigureHidden(transform_Appearing_4),
                Place.OldShow(),
                Text.OldShow(". . . . . ."),
                Sound.oldBgmMuted(transform_sound_delay_1)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow("[. . . это немного странно. . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow("[. . . похоже мы оба не знаем что сказать . . .]")
                );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . . ну ладно . . я пойду . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_4),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . да . . ? . . ну . . ладно . . .")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . убежала . . .]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . я ее уже еле вижу, бастрая как метеор . . .")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . хм . . ? кажется, я кого-то вижу . . .")
                );

            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . хм . . ?")
                );

            SetBastard();

            CadreNum++; OldAddCadre(
                Bastard.oldFigureHidden(transform_Appearing_4),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . берегись . . !")
                );

            Sound.CurrentSE = Effects["Бум"];

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.Wait(500)}>{Trans.ImpactHs(200, 100)}"),
              Girl.oldFigureHidden($"O.B.500.100>{Trans.ImpactHs(200, 100)}"),
              Place.OldShow(),
              Text.OldShow($" . . Ааааааа . . "),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . Ой, чуть не убились . . ")
              );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.oldFigure($"{Trans.ImpactHs(200, 30)}"),
              Place.OldShow(),
              Text.OldShow($" . . *Сжал* . . "),
              Sound.oldSE()
              );

            SetGirlExpression_Surprised();


            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . ! ! ! . . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . прости ! ! ! . . прости ! ! ! . . . с тобой все в порядке . . ! ! ! ?")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . э-э-э . . Да, вроде . . ")
              );


            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . я дико извиняюсь . . у тебя ничего не болит . . .?")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~. . вроде нет . . .")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . ты уверен . . . ?")
              );


            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.oldFigure($"{Trans.ImpactHs(200, 30)}"),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~. . *Сжал* . . "),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . еще немного, здесь. . *трогает*")
              );


            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure($"{Trans.MoveHs(50, -20)}"),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . вот тут ? . . больно . . .?"),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . все нормально. . ")
              );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . слава богу . . .!")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(10, 50)}"),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . . . ")
              );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.oldFigure($"{Trans.ImpactHs(200, 30)}"),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~. . *сжал*"),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~ . . еще раз извини, что налетела на тебя . . .!")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {bastard_title}]~ . . хе хе . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(transform_Disapearing_2),
              Girl.oldFigure(transform_Disapearing_2),
              Place.OldShow(transform_Disapearing_2),
              Text.OldShow($". . . . ")
              );

            Sound.CurrentSE = Effects["Бег мальчик"];

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~ . . {Name_Girl}, ты в порядке . . ?"),
                Sound.oldSE()
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
              Girl.oldFigureHidden(transform_Appearing_4),
              Place.OldShowHidden(transform_Appearing_4),
              Text.OldShow($"[{Name_Girl}]~. . о , {Name_Hero}. . да . . все в порядке . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Hero}]~. . я плохо видел, что сдесь произошло . . ?")
              );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~. . тут был вот этот {bastard_title}, и. . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~. . ой, он только что был здесь . . ушел . . .")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Hero}]~. . ? ты все еще спишь . . .?")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow($"{Trans.ImpactHs(200, 30)}"),
              Text.OldShow($"[{Name_Girl}]~. . он определенно был еще недавно здесь . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Hero}]~. . тебе надо смотреть внимательно, куда бежишь . . .")
              );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~. . ха ха . . это точно . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Hero}]~. . похоже ты не пострадала, так что пошли . . .")
              );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Name_Girl}]~. . да, пошли . . ")
              );

            Sound.CurrentSE = Effects["Бег мальчик"];

            CadreNum++; OldAddCadre(
              Girl.oldFigure(transform_Disapearing_2),
              Place.OldShow(),
              Text.OldShow($". . . . "),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Place.OldShow(transform_Disapearing_2),
              Text.OldShow($". . . . ")
              );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . В итоге мы так и не выяснили ничего . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . Наверно мне повезло просто . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . С {Name_Girl} все эти штуки насчет секса . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . Мы никогда не говорили об этом с ней. Для того чтобы не повредить нашим отношениям . . . "));
            
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . Думаю, у нас есть негласное правило . . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . . *вздох* . . . "));

            CadreNum++; OldAddCadre(
              Bastard.oldFigureHidden(transform_Appearing_5),
              Place.OldShowHidden(transform_Appearing_4),
              Text.OldShow($". . . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(transform_Disapearing_2),
              Place.OldShow(transform_Disapearing_2)
              );

        }
        private void Chapter8()
        {
            AddChapter("Chapter 8", "Chapter 8 - Обсуждение сисек парнями");
            
            Place.Current = Locations["School hall day"];

            CadreNum++; OldAddCadre(
                Place.OldShowHidden(transform_Appearing_3),
                Text.OldShow($"[{Name_Hero}]~. . . уроки закончились . . . ")
                );

            Sound.CurrentBGM = BGM["After School"];

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . я все время был занят своими мыслями, и время пробежала незаметно . . . "),
                Sound.oldBgm()
                );

            //Figure
            SetGirlWear_Sportwear();
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Appearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . . Ох . . {Name_Hero} ! ! ! ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . ? ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. .  Ого !  Ты уже переоделась ? ? ")
                );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  Хих . У нас сейчас игра . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . . Переодеваться было непросто . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. .  . я был очарован ею . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. .  . она выглядела потрясающе. . ]")
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . раз у меня игра, ты идешь домой один. . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. .  . о, мне надо тоже кое что тут еще сделать, так что я буду в школе еще час . . ")
                );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . но за час я точно не успею . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. .  . ничего, я подожду . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . на самом деле может быть я задержусь и после игры . . ")
                );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . у новичков проблемы с формой . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . и я обещала помочь им. так что ты наверно можешь . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . не ждать меня . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. .  . о , ну хорошо . . ")
                );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . Но в любом случае - спасибо . . ")
                );

            SetGirlExpression_AgitatedSmile();

            Sound.CurrentSE = Effects["Бег девочка"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . Увидимся . . !"),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(                
                Place.OldShow(),
                Text.OldShow($". . . . . ")
                );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Appearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . Ах да, завтра у нас тренировка с утра, так что я не приду тебя будить . . !")              
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. .  . Пожалуйста, не проспи . . !")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. .  . Исчезла как молния . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($". . . . . ")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($". . (*шепот*) . . . ")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . хм ? . . ]"),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . хм ? . . ]"),
                Sound.oldBgmStop()
                );

            GuyA.SetVisibleView("Middle", "Guy 01", null);
            GuyB.SetVisibleView("Middle", "Guy 02", null);

            CadreNum++; OldAddCadre(
                GuyA.oldFigureHidden(transform_Appearing_6),
                GuyB.oldFigureHidden(transform_Appearing_7),
                Place.OldShow(),
                Text.OldShow($"[Парень А]~[. . Черт . . Видел, какие сиськи? Прикольно они у ней трясутся . . .]")              
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Парень Б]~[. . Да уж . . У нее они всегда так трясуться . . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Парень А]~[. . Как бы я хотел подойти к ней сзади и тискать их . . !]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Парень Б]~[. . Трахать ее между таких сисек . . Это наверно кайф !]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Парень А]~[. . Хехе. Я знаю, девчонки с такими сиськами любят, когда их тискают . . !]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($". . . . ")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. .  . Вот черт . . я так и думал . . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[ .  . Куча парней смотрят на нее такими же глазами . . ]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[ А ее это совсем не волнует . . Я тревожусь за нее . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[ Я вспомнил ее беззаботную улыбку . . И моя тревога только возросла . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(transform_Disapearing_3),
                GuyB.oldFigure(transform_Disapearing_3),
                Place.OldShow(transform_Disapearing_3),
                Text.OldShow($"[ . . . .]")
                );


        }
        private void Chapter9()
        {
            AddChapter("Chapter 9", "Chapter 9 - Вторая встреча с мерзавцем.");

            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . . я опять это сделала . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . . я жестоко поступила с {Name_Hero} вчера . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . . пока я думала об этом . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . . то не заметила небольшую тень. . . ]"));

            Girl.CurrentEvent = Events["3"];
            Sound.CurrentBGM = BGM["Runned into it"];
            Sound.CurrentSE = Effects["Бум"];



            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Appearing_3),
                Text.OldShow(". . . . . . ! !"),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . я . . врезалась в кого-то . . ?")
                );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow(". . . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . этот {bastard_title} . . . который был вчера . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . не могу поверить, что я врезалась в него снова . . !")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . нужно встать . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . я пытаюсь двинуться . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . это сложно, потому что он лежит на мне . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . он . . тяжелее, чем кажется . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {bastard_title}]~. . . уффф. .ухххх . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . . он обнимает меня, и очень крепко . . .")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . я не должна думать об этом . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . но когда кто-от ТАК вжимается в тебя . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . хочется типа . . . защитить его . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . не знаю точно, что это . . . но такое часто бывает со мной . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {bastard_title}]~. . . уффф. .ухххх . . .")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . с ним все в порядке ? . . он не ударился ? . . ")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Name_Girl}]~. . . нужно встать . . ")
                 );

            Sound.CurrentSE = Effects["Wear moving"];

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(transform_Disapearing_2),
                 Text.OldShow($". . . ну вот, готово . . "),
                 Sound.oldSE()
                 );

            CadreNum++; OldAddCadre(Text.OldShow($". . . я обхватила его руками, ка будто обнимая, и встала вместе с ним . . "));

            Place.Current = Locations["Street morning"];
            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                 Girl.oldFigureHidden(transform_Appearing_8),
                 Bastard.oldFigureHidden(transform_Appearing_5),
                 Place.OldShowHidden(transform_Appearing_4),
                 Text.OldShow($"{Name_Girl}]~. . . прошу прощения, я не смотрела куда иду . . ")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . да, это тот же самый вчерашний {bastard_title} . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . и на этот раз я налетела на него очень сильно . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . я такая дура . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . с тобой все хорошо ? . . ]")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . ты сильно ударился ? . . может быть, поранился ? . .]")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . наверно нет . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure($"{Trans.ImpactHs(200, 100)}>{Trans.ImpactHs(200, 100)}>{Trans.ImpactHs(200, 100)}"),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . охх . . "),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~[. . . и тут вдруг он скривился от боли . .]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~. . . что с тобой . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . кажется, я подвернул ногу . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~. . . о нет . . что же делать .. надо вызвать скорую . . .")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . да все нормально . . я только немного ее подвернул . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . я живу рядом . . я дойду . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~. . . ты уверен, что сможешь . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . да, просто чуть-чуть больно идти . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Name_Girl}]~. . . ты не сможешь . . !")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(transform_Disapearing_2),
                 Bastard.oldFigure(transform_Disapearing_2),
                 Place.OldShow(transform_Disapearing_2),
                 Text.OldShow($" . . ")
                 );

            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . как дошло до этого . . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . я не хочу быть одна . . и с родителями тоже не хочу . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . я всем приношу проблемы и неприятности . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . даже {Name_Hero} . .  всегда прихожу без приглашения . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . когда нибудь, он решит, что я надоедливая . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . это произошло со мной, потому что я неосторожная. . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Name_Girl}]~[. . надо быть более ответственной. . ]"));

            Sound.CurrentSE = Effects["Wear moving"];

            CadreNum++; OldAddCadre(
                Sound.oldSE(),
                Text.OldShow($". . . .")
                );

            Girl.CurrentEvent = Events["4"];

            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Appearing_3),
                Sound.oldBgm(),
                Text.OldShow($"{Name_Girl}]~. . Ладненько . . Все хорошо ? . . Хорошо ухватился ? ")
                );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[Незнакомый {bastard_title}]~ . . хе хе . . ага . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . Нгх . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . это . . не там немного . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . он схватился . . ?]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . больно . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {bastard_title}]~. . нет . . хе хе . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . как сильно он схатился за меня . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . я чувствую его дыхание на своей шее . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . это щекотно . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . не помню, когда меня так сильно обнимали . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~[. . мне от этого . . жарко . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . да, я забыла спросить как тебя зовут . .  ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {bastard_title}]~. . {Name_Bastard} . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . очень приятно, {Name_Bastard} ,  я {Name_Girl} . .  ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Name_Bastard}]~. . Могу я звать тебя '{girl_title}' . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . хи-хих . . это немного смущает . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . но . . я не против . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Name_Girl}]~. . Ну тогда, {girl_title} доставит тебя домой, так что направляй . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 100)}"),
                Text.OldShow($"[{Name_Bastard}]~ . . хе хе . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(transform_Disapearing_2),
                Text.OldShow($". . . . ")                
                );
        }
        private void Chapter10()
        {
            AddChapter("Chapter 10", "Chapter 10 - она не пришла в школу");

            CadreNum++; OldAddCadre(Text.OldShow($". . . . . . "));
            
            Place.Current = Locations["Hero room morning"];
            Sound.CurrentBGM = BGM["Good morning"];

            CadreNum++; OldAddCadre(
                Place.OldShowHidden(transform_Appearing_3),
                Text.OldShow($"[{Name_Hero}]~. . . . . . "),
                Sound.oldBgmMuted(transform_sound_delay_1)
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~. . . Это чувство покоя . . . ")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . Я точно опоздаю в школу . . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(transform_Disapearing_2),
                Text.OldShow($"[{Name_Hero}]~[. . . Стоп. Она сказала что у ней с утра тренировка . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~[. . . Может быть она и не выглядит очень уж заботливой, но она именно такая . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~[. . . Можно даже сказать - по матерински заботливая . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Name_Hero}]~[. . . Мне нужно перестать злоупотреблять ее добротой . . . ]")
                );

            Place.Current = Locations["Schoolyard morning"];

            CadreNum++; OldAddCadre(
                Place.OldShowHidden(transform_Appearing_3),
                Text.OldShow($". . . . . . ")
                );

            Place.Current = Locations["Class day"];

            CadreNum++; OldAddCadre(
                Place.OldShowHidden(transform_Appearing_3),
                Text.OldShow($". . . . . . ")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . я тихонько проскользнул в класс . . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . ну хорошо . . а где {Name_Girl} . . ? ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . . . ]"),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . Стоп. Ее нет . . ?]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . Тренировка уже закончилась, она должна быть здесь . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . Она никогда не опаздывала раньше . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . Что же заставило ЕЕ не придти вовремя. . ?]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Name_Hero}]~[. . . ]")
                );

            CadreNum++; OldAddCadre(Place.OldShow(transform_Disapearing_2));
        }
        private void Chapter11()
        {
            AddChapter("Chapter 11", "Chapter 11 - сарай в лесу");

            Sound.CurrentSE = Effects["Шаги в лесу 1"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . мне надо все обдумать . . . "), Sound.oldSE(1));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . все равно я опоздала в школу . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . и даже никого не предупредила . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . да и никого дома нет все равно . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . и это к лучшему . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . мои родители редко бывают дома, так уж сложилось . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . наш дом вообще не выглядит жилым. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . и мне в нем неуютно. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . . . "));            
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . Эй! Это уже настоящий лес. Ты уверен что мы идем правильно  . . ?"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~. . . хе-хе . . Мы почти пришли  . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~. . . . . ?"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~. . . Все, мы на месте  . . "), Sound.oldSEStop());

            Place.Current = Locations["Forest day"];
            Sound.CurrentBGM = BGM["Runned into it"];

            SetGirlExpression_Surprised();
            SetGirlWear_Shchool_Dress();
            string Bastard_X = "-350";
            string Girl_X = "350";

            CadreNum++; OldAddCadre(
                Bastard.oldFigureHidden(Bastard_X, null, transform_Appearing_3),
                Girl.oldFigureHidden(Girl_X, null, transform_Appearing_3),
                Place.OldShowHidden(transform_Appearing_3),
                Text.OldShow($"[{Name_Girl}]~. . . На месте ? . . . "),
                Sound.oldBgm()
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($". . . . . . ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Среди деревьев, старый сарай . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Я кажется, видела такие на стройке . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Стены грязные, и заросли травой . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Его можно найти только если подойти близко . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Если честно, он слишком грязный . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . Ммм . . Это же не твой дом, правда? . . ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Bastard}]~. . Конечно нет !. . Это моя секретная база ! ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null, $"{Trans.ImpactHs(200, 100)}"),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . Секретная база ? ? ! !")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Я хотела отвести его домой и извиниться перед его родителями . . .]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . А это совсем не то . . .]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~[. . Слушай, может нам лучше пойти к твоему дому . . . ?]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Bastard}]~. . Да кому это нужно ! "),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 100)}"),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Name_Bastard}]~. . Давай зайдем внутрь ! ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null, $"{Trans.ImpactHs(200, 100)}"),
                Place.OldShow(),
                Text.OldShow($"[{Name_Girl}]~. . Эй, не тащи меня !")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2),
                Girl.oldFigure(Girl_X, null, transform_Disapearing_2),
                Place.OldShow(transform_Disapearing_2),
                Text.OldShow($". . ")
                );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . Наверно мне не надо об этом спрашивать . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . Он играет один в таком месте . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . На это должна быть причина . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . На это должна быть причина . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . И я дала ему повести себя внутрь. .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . .]"));
        }
        private void Chapter12()
        {
            AddChapter("Chapter 12", "Chapter 12 - Бинтование ноги мерзавцу");

            Place.Current = Locations["Сарай"];

            CadreNum++; OldAddCadre(Text.OldShow($". . . . . . "), Place.OldShowHidden(transform_Appearing_3));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Внутри сарая темновато, но прикольно . . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . На стенах пластиковые панели. Наверно прикрывают дыры в стенах . . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Есть так же что то вроде матраса и полки. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Наверно он нашел это. Или принес из дома. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Все это похоже на секретную базу, где {Name_Hero} и я в детстве играли. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[. . . Хих. Это прикольно . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~[. . . Хе - хе . . Это место глубоко в лесу . . Так что никто не придет сюда ! ]"), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[. . . . . ]"));

            Girl.CurrentEvent = Events["5"];
            Sound.CurrentBGM = BGM["Runned into it"];

            CadreNum++; OldAddCadre(Text.OldShow($"[. . . . . ]"), Girl.oldEventHidden(transform_Appearing_3), Sound.oldBgm());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Я посадила {Name_Bastard}  на матрас и стала бинтовать его лодыжку . . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Я всегда беру бинт с собой когда иду на тренировку . . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Хорошо что я взяла его.  Никогда не знаешь где пригодится. . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . Эта нога, верно . . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ . (*сглотнул слюну*). "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~М-м-м {girl_title}. . ты хорошенькая, правда. . "), Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"));

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . О . . О чем ты говоришь . . ? "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ . Ты очень красива. Наверняка ты очень популярна . . верно ? "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . О . . я . . ? ]"), Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"));

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($" . . . . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . Меня еще не называли хорошенькой . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . И {Name_Hero} не называл. ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($". . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Он наверно думает о моих чувствах. . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Это первый раз когда меня назвали хорошенькой. . . мне надо постараться получше . .]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Надо бинтовать лучше . .]"), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ Хих . . спасибо ! . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~Ты смеешся ! . . Ты самая красивая девчонка из всех которых я видел!"), Girl.oldEvent($"{Trans.ImpactHs(200, 100)}"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . ахаха . . много ли ты видел девчонок . . ?]"), Girl.oldEvent());

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ Ок. Поняла. Хватит. Мне. Льстить. ! ! "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Не то чтобы мне было неприятно . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Думаю он пытается просто быть вежливым, как умеет . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ На самом деле, мне это очень приятно . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Надо его тоже как то поблагодарить . ! ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . ."), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Неужели мне так легко польстить ?]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~Слушай {girl_title} . . Ты можешь приходить на эту секретную базу, когда захочешь!"), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ Поняла! Спасибо . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ Он мне доверяет . .]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ *уххх*  *уффф*"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . я забинтовала твою ногу, но тебе надо пойти к врачу . ."), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ хорошо "), Girl.oldEvent());

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ Нога не распухла , так что все будет хорошо. . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ (*пялится*) "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Bastard}]~ . . хехе . .  "), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~ . . что это было. . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . я чувствую как на меня смотрят . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . . . ]"), Girl.oldEvent(transform_Disapearing_2));

            Place.Current = Locations["Сарай"];
            SetGirlExpression_Surprised();
            string Bastard_X = "-350";
            string Girl_X = "350";

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(Girl_X, null, transform_Appearing_3), Bastard.oldFigureHidden(Bastard_X, null, transform_Appearing_3), Text.OldShow($"[{Name_Girl}]~ . Ну все, готово. Не туго ?"), Place.OldShowHidden(transform_Appearing_3),Sound.oldBgmStop() );
            CadreNum++; OldAddCadre(Girl.oldFigure(), Bastard.oldFigure(), Text.OldShow($"[{Name_Bastard}]~ . Все норм . ."), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Name_Bastard}]~ . Но {girl_title} должна идти в школу. ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Name_Bastard}]~ . Ты придешь еше, правда . . ?"), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Name_Girl}]~ . Не волнуйся, я зайду на обратном пути . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null,$"{Trans.ImpactHs(200, 100)}"), Text.OldShow($"[{Name_Bastard}]~ . О да ! ! !. . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Name_Bastard}]~ . Только не говори НИКОМУ об этом месте, ладно ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Name_Bastard}]~ . О нем знаешь только ты, {girl_title} . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2), Text.OldShow($". . . "), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . я переживала, но должна была идти в школу . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . ух ты . . секрет . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . только мой . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Girl}]~[ . . это прикольно . . .]"));

        }
        private void Chapter13()
        {
            AddChapter("Chapter 13", "Chapter 13 - Она опоздала в класс, с приоткрытой грудью");

            SetGirlWear_Shchool_Dress_Cleavage();
            Place.Current = Locations["Class day"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . Закончен второй урок . . ]"), Place.OldShowHidden(transform_Appearing_3));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . Она так и не связалась со мной . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~[. . Серьезно . . Что случилось ? . . ]"), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.OldShow($"[{Name_Girl}]~(*вздыхает*) . . Так я и думала . . Я сильно опоздала . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . Я почувствовал облегчение, как только увидел ее . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Я думал это ты мне скажешь, что я опаздываю . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ах, {Name_Hero} ! . . Доброе утро . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Где ты была ? Я говорила, что у тебя игра . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Дело в том . . у меня были проблемы . . "), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . м-м-м-м . . э-э-э-э . . . "), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . хих . . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Я . . . я проспала . . ! "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . Видя как странно ведет себя {Name_Girl}, я чувствую тревогу . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Кстати, что с твоей формой ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Хм . . ? "), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ой . .  Пуговица оторвалась . . "), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ха ха . . наверно закатилась где-то . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Быстрей переодевайся . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Да все нормально, я переоденусь перед тренировкой . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . это для МЕНЯ не нормально . . ]"), Place.OldShow($"{Trans.ImpactHs(200, 100)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . хоть это эгоистично . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . но я не хочу чтобы другие парни смотрели на ее грудь . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Пошли сядем на наши места . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Text.OldShow($"[{Name_Hero}]~. . Но я никогда не смогу сказать ей это . . "), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Name_Hero}]~. . Все что мне остается - смотреть на ее приоткрытую грудь . . "));
            CadreNum++; OldAddCadre(Text.OldShow($". . "));

        }
        private void Chapter14()
        {
            AddChapter("Chapter 14", "Chapter 14 - размолвка с другом");

            SetGirlWear_Shchool_Dress_Cleavage();
            SetGirlExpression_Laughing();
            Place.Current = Locations["Раздевалка"];
            Sound.CurrentBGM = BGM["After School"];

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.OldShow($"[{Name_Girl}]~[. . хих хих хих . . ]"), Place.OldShowHidden(transform_Appearing_3), Sound.oldBgm());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Ты какая-то слишком веселая для того, кто опоздал на уроки . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . После школы . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . я сопровождаю {Name_Girl} на ее тренировку . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure($"{Trans.ImpactHs(200, 100)}"), Text.OldShow($"[{Name_Girl}]~. . А ? Ты говоришь про меня . . ?"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Ты весь урок как-то улыбалась про себя . . Это странно . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . закатное солнце освещало лицо {Name_Girl} . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . раньше я всегда любовался этим . ."), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ох . . Наверно это было написано на моем лице. . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . и слишком сильно . .]"), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ох . . Да просто это ерунда . . которая меня развеселила . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~[. . да ладно . . непривычно что ты так говоришь . .]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . подожди-ка . . ты отведала новые снеки ? . ."), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Ты всегда думаешь обо мне так . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Помнишь те снеки которые ты мне приносила ? . . У меня в комнате еще лежит пачка . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . О . . да . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Если появились новые, их не обязательно покупать, это расточительно . . "), Place.OldShow($"{Trans.ImpactHs(200, 100)}"));

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~. . Я не собираюсь скрывать свои карты, пока ты такой скряга . . "), Place.OldShow($"{Trans.ImpactHs(200, 100)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Да ? . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~(*вздыхает*) Если это ты, {Name_Hero} . . Ты меня поймешь . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Чо ты хочешь сказать ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~Ты правда не понимаешь . . ?"), Place.OldShow(), Sound.oldBgmStop());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Hero}]~. . Как я могу понять, когда ты ничего не говоришь ? . . "), Place.OldShow($"{Trans.ImpactHs(200, 100)}"));

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Name_Girl}]~Ахах . . хорошо . . мне надо идти . !"), Place.OldShow($"{Trans.ImpactHs(200, 100)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Text.OldShow($"[{Name_Hero}]~. . Что ? . . Эй ! . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($". ."), Place.OldShow(transform_Disapearing_2));

            AddCadre(); Text.Show($"[{Name_Girl}]~[. . . . ]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . После тренировки. Я покинула друзей по команде. . . ]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Как обычно, я шла домой. Одна . . . ]");

            Place.Current = Locations["Street evening"];

            AddCadre(); Text.Show($"[{Name_Girl}]~[. . . . . ]"); Place.SmartShow();

        }
        private void Chapter15()
        {
            AddChapter("Chapter 15", "Chapter 15 - Перевязывание ноги мерзавцу, глазеющему в декольте");

            Sound.CurrentSE = Effects["Шаги в лесу 1"]; Sound.CurrentBGM = BGM["Runned into it"]; Girl.CurrentEvent = Events["5"];

            AddCadre(); Text.Show($". . . . "); Sound.SELoop();
            AddCadre(); Text.Show($". . . . ");            
            AddCadre(); Text.Show($". . . . "); Sound.SEStop(); Sound.Bgm();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . Ну хорошо, просто сиди вот так. . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . снова я сижу перед {Name_Bastard}у . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . я должна проверить его ногу . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . надеюсь, она не распухла . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~(*глотает слюнки*) . . класс ! . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Name_Girl}]~А ?. . Ты сказал что-то ? . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~Хм . . Нет, ничего . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["5"];

            AddCadre(); Text.Show($"[{Name_Girl}]~Да ?. . Постой . . Бинт развязался . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . ой . . застежка слетела . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Name_Girl}]~. . ты знаешь где она ? . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Нет, я не видел ее . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . странно . . я уверена, она была здесь . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . плохо . . у меня нет другой . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~О!. . Наверно, я обронил ее там . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartHideEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . М-м-м . . здесь . . ?");
            AddCadre(); Text.Show($"[{Name_Bastard}]~Хе-хе-хе. . Да, там . .");

            Girl.CurrentEvent = Events["7"]; Sound.CurrentBGM = BGM["In the Barn"];
            
            AddCadre(); Text.Show($"[{Name_Girl}]~. . За полкой . . ?"); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 100)}"); Sound.Bgm();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Вау (*уфф*) (*уфф*). . "); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 100)}");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Я не вижу отсюда . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Ух. . Не достать . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . (*уфф*) (*уфф*). . она дальше . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["8"];

            AddCadre(); Text.Show($"[{Name_Girl}]~. . Там . . ?"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Стоя на коленях, я протянула руку так далеко, как смогла . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . Ух . . Не могу достать . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 100)}");
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . (*уфф*) (*уфф*). . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . Ух ! . . Никак не достать . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Тело женственное такое . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Она близко уже . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~. . не могу . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["7"];

            AddCadre(); Text.Show($"[{Name_Girl}]~. . Ты уверен что она здесь? . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 100)}");
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Да, еще чуть-чуть . . (*уфф*) . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 100)}");

            Girl.CurrentEvent = Events["8"];

            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Мне надо носить больше креплений для бинта с собой . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . хе-хе . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Тут жарко. Одежда даже промокла . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Почти достала . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Вот она . .]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Уфффф . .]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . ? . .]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Я об этом не думала, но . .]");
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . наверно я была в очень неприличной позе . .]"); Sound.BgmStop();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Но здесь никого, кроме {Name_Bastard} нет . .]");

            Girl.CurrentEvent = Events["5"];  Sound.CurrentBGM = BGM["Runned into it"]; 

            AddCadre(); Text.Show($"[{Name_Girl}]~. . Ну вот. Постарайся не терять это больше, хорошо . . ?"); Girl.SmartShowEvent(); Sound.Bgm();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Ладно . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Я осмотрела ногу и перебинтовала . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Выглядит хорошо . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Хе-хе . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Name_Girl}]~. . ? . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartHideEvent(); Sound.BgmStop();
        }
        private void Chapter16()
        {
            AddChapter("Chapter 16", "Chapter 16 - Она осталась вечером у мерзавца");

            Place.Current = Locations["Сарай"];
            SetGirlWear_Shchool_Dress_Cleavage();
            SetGirlExpression_AgitatedSmile();
            string Bastard_X = "-350";
            string Girl_X = "350";

            AddCadre(); Text.Show($"[{Name_Girl}]~. . Хорошо . . Я все сделала на сегодня !"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Неожиданно я поняла, что наулице уже темно . .]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Вау. Просто ничего не видно. . .]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Что ж. Его нога вроде в порядке. . .]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[. . Он не собирается идти домой. Похоже мне надо идти домой. . .]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Bastard}]~. . Слушай, {girl_title} !"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);

            SetGirlExpression_Surprised();

            AddCadre(); Text.Show($"[{Name_Bastard}]~Давай ляжем здесь и поболтаем немного . . "); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~Что ? . . Ну . . Уже слишком поздно . . "); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Bastard}]~Пожалуйста ! . . Мне одному грустно ! . ."); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[ Уже было поздно . . Я подумала о его семье . . ]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[ Но когда ты одинока, разумные доводы не работают . . ]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[ Когда один в своей комнате . . ]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[ Как мне это знакомо . . ]"); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);

            SetGirlExpression_AgitatedSmile();

            AddCadre(); Text.Show($"[{Name_Girl}]~Я понимаю тебя . . "); Place.SmartShow($"{Trans.ImpactHs(200, 100)}"); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~Но уже темно, поэтому недолго, ладно ? . . "); Place.SmartShow(); Girl.SmartFigure(Girl_X, null, $"{Trans.ImpactHs(200, 100)}"); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Bastard}]~Правда ? . . ."); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Bastard}]~Хе-хе . . {girl_title} . . . ложись сюда . ."); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 100)}");

            Sound.CurrentSE = Effects["Wear moving"];
            SetGirlExpression_Surprised();

            AddCadre(); Text.Show($"[{Name_Girl}]~. . Подожди . . Не тяни меня так . . "); Place.SmartShow(); Girl.SmartFigure(Girl_X, null); Bastard.SmartFigure(Bastard_X, null); Sound.SE();
            AddCadre(); Text.Show($" . . . "); Place.SmartHide(); Girl.SmartFigureHide(Girl_X, null); Bastard.SmartFigureHide(Bastard_X, null);
            AddCadre(); Text.Show($"[{Name_Girl}]~[ . . В итоге . . Я решила остаться с ним . .]"); 
        }


            //================
        private void AddChapter(string chapter, string description = null)
        {
            Chapter = chapter;
            string dsc = string.IsNullOrEmpty(description) ? chapter : description;
            Scenario.Add($"GroupId={Chapter};DSC={dsc};ORD=1");
        }


        private void AddHeader()
        {
            AddChapter("0-Header");
            CadreNum = CadreNum + 1;
            string cadre = CadreNum.ToString("D3");
            string protagonst = @"e:\!EPCATALOG\AVATAR\GOOD\0003.png";
            string background = @"e:\!EPCATALOG\LOCATION\BEDROOM\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -evening.png";
            string mainfigure = @"e:\!EPCATALOG\PERSONS\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\01_BASE.png";
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            int ord = 0;
            //sound
            /*r.Add($"GROUP={group};KIND=6;A=1;Y=1;F=1;DSC={dsc};ORD=1;FILE={GetFileBGM("0006-komari.mp3")}");
            r.Add($"GROUP={group};KIND=6;A=1;Y=1;F=1;DSC={dsc};ORD=1;FILE={GetMoan("old-n-young.com-Pelmen-Anya_05.mp3")}");
            r.Add($"GROUP={group};KIND=6;A=1;Y=1;F=1;DSC={dsc};ORD=1;FILE={GetMoan("old-n-young.com-Pelmen-Sasha_02.mp3")}");
            */
/*
            Scenario.Add($"GROUP={cadre};KIND=6;Y=1;F=1;DSC={Chapter};ORD=1;FILE={GetMoan("old-n-young.com-Pelmen-Anya_05.mp3")}");
            ord++;
            Scenario.Add($"GROUP={cadre};KIND=6;Y=1;F=1;DSC={Chapter};ORD=1;FILE={GetMoan("old-n-young.com-Pelmen-Sasha_02.mp3")}");*/
            //text template
            ord++;
            Scenario.Add(GetText(cadre, ". . . . . . . . . . . . .", 2000, 500, 1200, 100, 2, 0, 2, 0, template_text, true));
            //location template
            ord++; z = 0;
            Scenario.Add(GetImage(cadre, "Location backgroung 01", background, size_frame_main, x_frame_main, y_frame_main, z, ord, null, template_location, true));
            ord++; z = 0;
            Scenario.Add(GetImage(cadre, "Location backgroung 02", background, size_frame_main_2, x_frame_main_2, y_frame_main, z, ord, null, template_location, true));
            // protagonist avatar template
            ord++; z = 11;
            Scenario.Add(GetImage(cadre, "Hero avatar", protagonst, size_hero_avatar, x_hero_avatar, y_hero_avatar, z, ord, null, template_hero_avatar, true));
            // event template
            ord++; z = 5;
            Scenario.Add(GetImage(cadre, "Event", mainfigure, size_event, x_event, y_event, z, ord, null, template_event, true));
            // figure template
            ord++; z = 10;
            Scenario.Add(GetImage(cadre, "Figure", mainfigure, size_figure, x_figure, y_figure, z, 0, null, template_figure, true));
            // frame template
            ord++; z = 0;
            Scenario.Add(GetFrame(cadre, "Frame 01", "Frame 01", size_frame_1, x_frame_1, y_frame_1, z, ord, null, template_frame_1, true));
            ord++; z = 1;
            Scenario.Add(GetFrame(cadre, "Frame 02", "Frame 02", size_frame_2, x_frame_2, y_frame_2, z, ord, null, template_frame_2, true));
            ord++; z = 20;
            Scenario.Add(GetFrame(cadre, "Black background", "Black", size_frame_main, x_frame_main, y_frame_main, z, ord, transition_main, template_frame_main, true));
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

}

