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

            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);

            Events = new Dictionary<string, string>();            
            Events.Add("1", "Event 001");
            Events.Add("2", "Event 002");

            BGM = new Dictionary<string, string>();
            BGM.Add("Good morning", "ogg00052");
            BGM.Add("After School", "After School 1");
            BGM.Add("ogg00054", "ogg00054");

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
            Locations.Add("House evening", "Building 002 evening");
            Locations.Add("School hall day", "School hall 001 day");
            

            Effects = new Dictionary<string, string>();
            Effects.Add("Wear moving", "Wear moving 1");
            Effects.Add("Door ring", "Door ring 1");
            Effects.Add("Вжик", "Вжик 1");
            Effects.Add("Бум", "Бум 1");
            Effects.Add("Бег", "Бег 1");

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
        string bastard_title = "мальчик";
        Person Girl;
        Person Bastard;
        CadreText Text;
        Location Place;
        CadreSound Sound;

        string transform_Disapearing_2 = "W..1500>O.B.500.-100";
        string transform_Disapearing_3 = "W..500>O.B.500.-100";
        string transform_Disapearing_4 = "W..250>O.B.500.-100";
        string transform_Apearing_1 = "W..3000>O.B.500.100";
        string transform_Appearing_3 = "W..500>O.B.500.100";
        string transform_Appearing_4 = "W..250>O.B.500.100";
        string transform_Appearing_5 = "W..2000>O.B.1000.100";
        string transform_sound_delay_1 = $"W..500>p.A.0.1";

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
            Girl.SetVisibleView("Middle", "School_Dress", null);
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
        }
        private void Chapter1()
        {
            AddChapter("Chapter 1");

            CadreNum++; AddCadre(Text.Show(". . . . . . . . . . . ."));
            CadreNum++; AddCadre(Text.Show("Взглядов на жизнь на свете так же много, как много и людей."));
            CadreNum++; AddCadre(Text.Show(". . . Некоторые люди возможно заставят вас успешно сдать экзамен или найти работу."));
            CadreNum++; AddCadre(Text.Show(". . . Некоторые люди возможно скажут вам не тратить время зря."));
            CadreNum++; AddCadre(Text.Show(". . . Но дремать, наслаждаясь комфортом - это одна из разновидностей счастья."));
            CadreNum++; AddCadre(Text.Show(". . . Что я и делаю сейчас . . ."));
            CadreNum++; AddCadre(Text.Show("[Голос]~'Эй ...'"));
            CadreNum++; AddCadre(Text.Show(". . . похоже это . . ."));
            CadreNum++; AddCadre(Text.Show("[Голос]~'Эй . . . Просыпайся . . .'"));
            CadreNum++; AddCadre(Text.Show(". . . похоже это . . ."));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~'АХХ!!! . . . ДА ПРОСЫПАЙСЯ УЖЕ !!!'"));
        }
        private void Chapter2()
        {            
            AddChapter("Chapter 2");

            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];            
            Sound.CurrentSE = Effects["Wear moving"];
            Place.Current = Locations["Hero room morning"];
            


            CadreNum++; AddCadre(
                Girl.EventHidden(transform_Apearing_1),
                Text.Show(". . . Ох! Ну что еще? . . ."),
                Sound.BgmMuted(transform_sound_delay_1),
                Sound.SE()
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Girl}]~'О-о . . . Хорошо тут сидеть . . .'")
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($". . . Я чувствую приятную мягкую тяжесть на себе . . .'")
                );

            CadreNum++; AddCadre(
                Girl.Event($"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"),
                Text.Show($"[{Name_Girl}]~'*вздыхает* Может мне отохнуть здесь . . . ?'")
                );

            CadreNum++; AddCadre(
                Girl.Event($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($". . . Это немного . . . тяжело . . .'")
                );

            CadreNum++; AddCadre(
                Girl.Event($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Girl}]~. . . Я наверно  позавтракаю прямо здесь. . .'")
                );

            CadreNum++; AddCadre(
                Girl.Event($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($". . . Ты не ела дома. . ?'")
                );

            CadreNum++; AddCadre(
                Girl.Event($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Girl}]~. . . А может, просто растянуться здесь и полежать. . ?''")
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($". . . Все, я понял, понял. . .  уже встаю. . .''")
                );

            //Expression && Wear
            SetGirlWear_Shchool_Dress();
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Girl}]~. . . Ну, если так. . Тогда проснись и пой . .!"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($". . . Мое покрывало тут же забрали . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($". . . Я уже начинаю привыкать к этому . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . Ой . . "),
                Place.Show()
                );


            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Хих . . . Ты забыл об этом . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Но я уже привыкла обычно будить тебя . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . Для того чтобы наслаждаться этим общением и ее красотой . ."),
                Place.Show()
                 );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . признаюсь честно, я иногда специально просыпал . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"),
                Place.Show()
                );


            CadreNum++; AddCadre(
                Girl.Figure(),
                Sound.BgmStop(),
                Text.Show($". . Мы с ней друзья с детства . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . И еще - я люблю ее . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Возможно, она еще не совсем женщина, но какая же она заботливая"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Наверно как нибудь я об этом подумаю . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Какая же у ней улыбка . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Я просто постоянно думаю о ней . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Girl}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Давай быстрей собирайся . . !"),
                Place.Show()
                );


            CadreNum++; AddCadre(Text.Show(". . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . Мы были обычными соседями сначала, и не были близкими друзьями . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . Ее родители развелись, когда мы еще были детьми . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . И я довольно часто видел ее на улице одну . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . Когда я позвал ее, она была счастлива . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . И мы стали проводить время вместе . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . Возможно . . . у нее нет романтических чувств ко мне . . ."));

            CadreNum++; AddCadre(Text.Show(". . . . Но у меня - есть . . . они возникли в общем-то недавно . . ."));
        }
        private void Chapter3()
        {
            AddChapter("Chapter 3");

            Place.Current = Locations["Street morning"];
            Sound.CurrentBGM = BGM["Good morning"];

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.FigureHidden(transform_Apearing_1),
                Sound.BgmMuted(transform_sound_delay_1),
                Text.Show($"[{Name_Girl}]~. . . Ну что, ты проснулся наконец . . ?"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );
           

            CadreNum++; AddCadre(
                Girl.Figure($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"Ой . . ."),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Извини, я задумался . . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Да ладно, даже когда я с тобой? Соберись уже . . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[Бежать в школу со всех ног уже вошло в привычку.]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . Она могла бы уже давно быть в школе, но она не хочет меня бросать.]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . А я пользуюсь ее добротой . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Ну серьезно. . . Почему ты всегда убегаешь . . ?"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Может потому что ты всегда спишь?"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Это напрягает тебя?"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Хмм, все равно, я бегу на занятия в свой клуб . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Ладно, я могла бы иногда проводить больше времени с тобой, как мы иногда делаем . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . Такие дни просто класс . . !]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Я могу тебя будить, как только сама встаю. . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . Вот всегда она так . . !]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . Я боюсь за наши отношения  . . ]"),
                Place.Show()
                );
            
            CadreNum++; AddCadre(
                Girl.Figure($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Girl}]~. . ."),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(transform_Disapearing_3),
                Text.Show($"[. . . Из-за того, что она слишком наивная и немного нерешительная  . . ]"),
                Place.Show()
                );
            
            CadreNum++; AddCadre(
                Text.Show($"[. . . . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[. . . Ха? ]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Text.Show($"[. . . Погоди . . . {Name_Girl} . . . ты слишком быстро бежишь . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Place.Show(transform_Disapearing_3),
                Text.Show($"[. . . Она капитан команды болельщиц. . .]")
                );

            CadreNum++; AddCadre(Text.Show($"[. . . Запыхавшись, я все-таки догнал ее. . .]"));

        }
        private void Chapter4() 
        {
            AddChapter("Chapter 4");

            //Expression
            SetGirlExpression_Surprised();

            Place.Current = Locations["Class day"];
            Sound.CurrentBGM= BGM["After School"];

            CadreNum++; AddCadre(
                Girl.FigureHidden(transform_Apearing_1),
                Sound.BgmMuted(transform_sound_delay_1),
                Text.Show($"[{Name_Girl}]~. . . Ух, еле успели . . !"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . .  . . "),
                Place.Show());

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . . уф . . уф . . ."),
                Place.Show());

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Ох. . . как-то . . справились . . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Отлично, тогда пока, увидимся позже . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(                
                Girl.Figure(transform_Disapearing_3),
                Text.Show($". . . Пока . . !"),
                Place.Show()
                );

            //stop musik
            CadreNum++; AddCadre(
                Sound.BgmStop(),
                Text.Show($"[ Фу . . Делать это каждый раз тяжеловато. Она слишком шустрая, а я не привык к этому ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(                
                Text.Show($"[ Она как парень . . . или как приятель . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . Может она и не догадывается, но она очень популярна среди парней . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . Хотя еще никто не подкатывал к ней, потому что я всегда ее сопровождаю . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . (Хоть это мне и не особо помогает) . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . (Или скорей это как-то странно, потому что я сам не знаю что делать) . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[Учитель]~ . . . Хорошо, начнем урок . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($" . . . . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . (Как обычно, я думаю только об этом) . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[ . . . И слишком мало думаю об экзамене . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(                
                Text.Show($"[ . . . И слишком много - об романтике, что делает меня неуверенным . . .]"),
                Place.Show()
                );
        }
        private void Chapter5() 
        {
            AddChapter("Chapter 5");

            //Figure
            SetGirlWear_Sportwear_wet();
            //Expression
            SetGirlExpression_AgitatedSmile();

            Place.Current = Locations["Schoolyard day"];
            Sound.CurrentBGM = BGM["ogg00054"];

            CadreNum++; AddCadre(
                Sound.BgmMuted(transform_sound_delay_1),
                Text.Show($". . . Ах да . . "),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; AddCadre(
                Text.Show($". . . {Name_Girl} сегодня на тренировке команды болельщиц . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[Я рассеяно смотрю на школьный двор . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Girl}]~Ой . . . наконец я тебя нашла ! ! !"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(// д.краснеет(ее майка стала прозрачная от пота)
                Girl.FigureHidden(transform_Apearing_1),
                Text.Show($"[{Name_Girl}]~. . . Ну, как дела ?"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . Если честно, просто сопровождать ее домой, для меня уже счастье . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . И я чувствую, как сильно бьется мое сердце . . .]"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Я вижу тебя за милю . . !"),
                Place.Show()
                );
            
            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . . Погоди . . !"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );
            
            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . И я могу видеть ее лифчик. . . и ее грудь . . ]"),
                Place.Show()
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Ты в порядке . . ?"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . ммммм . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Ой. . . ладно, ничего . . "),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[. . . смотрю на небо, как идиот . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . . Облака . . "),
                Place.Show()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . Ты в порядке . . ?"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Слушай, [{Name_Hero}], иногда ты очень странный . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Когда я тебя вижу, то невольно хочу подойти . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[Капитан команды]~Ей, {Name_Girl} ! . . А кто сказал, что тренировка закончена . . ?"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Упс . . нет, я не закончила тренировку . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~Капитан следит за мной все время . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . Все нормально . . ?"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Неожиданно для себя, я наклоняюсь к ней . . ."),
                Place.Show()
                );


            //Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}] . . . Хмм . . Думаю, он всего лишь слишком строгий . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . ."),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Когда дело касается романтических чувств, она очень наивная . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Она не думает о том, что эти парни смотрят на нее как на потенциальную партнершу для любви . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Просто потому, что никто не подходит к ней . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"Хотя она нак привлекательна . . . больше чем они могут себе представить . . ."),
                Place.Show()
                );

            //Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}] . . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}] . . . Увидимся . . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(transform_Disapearing_3),
                Sound.BgmStop(),
                Text.Show($" . . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($" . . . Она собирается продолжить тренировку, в ТАКОМ виде . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($" . . . Уверен, все парни будут пялиться на нее . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($" . . . . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Text.Show($" . . .  Как не смотри, а она очень женственна . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Place.Show(transform_Disapearing_3)
                );
        }
        private void Chapter6()
        {
            AddChapter("Chapter 6", "Chapter 6 - Попытка скоротать грустный вечер с другом.");


            //Figure
            SetGirlWear_Shchool_Dress();
            //Expression
            SetGirlExpression_Troubled();


            Place.Current = Locations["Street evening"];

            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~. . . "));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[ уф, тренировка закончена. . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . . я иду домой одна. . . ]"));


            CadreNum++; AddCadre( 
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . во время тренировки. . . я просто бегаю и не могу ни о чем другом думать . . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . и это мне не нравится . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . я приду домой, но там никого нет. . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . и даже если кто-то будет дома, это мне не поможет никак. . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["House evening"];

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Как я и предполагала - дома никого нет. .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Когда моих родителей нет дома, я чувствую облегчение. .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. .  ведь тогда мне не нужно бороться с чувством неловкости . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. .  но в то же время, когда их нет - мне одиноко . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. .  и так было всегда . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. .  . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["Girl room evening"];

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Но я так и не привыкла быть одной  . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Было время когда я проводила время на улице  . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[(*вздыхает*) здесь мне нечего делать . . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Когда это становится невыносимым, я опять делаю это . .]"),
                Place.Show()
                );

            // Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . ладно тогда . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . . .]"),
                Place.Show(),
                AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            //effect
            Sound.CurrentSE = Effects["Door ring"];
            
            CadreNum++; AddCadre(
                Text.Show($". . *звонок* . ."),
                Sound.SE()
                );
    
            CadreNum++; AddCadre(Text.Show($". . . ."));

            Place.Current = Locations["Hero room evening"];

            CadreNum++; AddCadre(
                Text.Show($". . Хи-я-я-я !. ."),
                Place.Show()
                );

            Sound.CurrentBGM = BGM["Good morning"];
            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.FigureHidden(transform_Apearing_1),
                Sound.BgmMuted(transform_sound_delay_1),
                Text.Show($"[{Name_Hero}]~[. . О-о-о. .]"),
                Place.Show()             
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Хих . .]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . {Name_Hero},ты устал верно? Давай поедим снеков  . . !]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . Извини . . . я только поужинал  . . ]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . Подожди . . . а кто тебя впустил  . . ?]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . М-м . . . твоя . . мама  . . ]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );


            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . Ух  . .  почему я не могу побыть один . . .]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($". . . . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Он иногда говорит такое  . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Но мой друг . . будет со мной . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Наверно я злоупотребляю его терпением . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~. . Итак  . .  что ты там говорила про снеки . . ?"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Ну вот видите . . !]"),
                Place.Show()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . Их полно в магазине, так что . . давай их возьмем . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~[. . Я их уже принесла . . !]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . Серьезно  . .  ты только снеки купила . . ?]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . Да мне все равно . . !]"),
                Place.Show()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . Хих . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Sound.BgmStop(),
                Place.Show(transform_Disapearing_3),
                Text.Show($". . . . ")                
                );

        }
        private void Chapter7()
        {
            AddChapter("Chapter 7", "Chapter 7 - Утренний стояк и неловкость");

            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . Получается, я все время создаю ему проблемы . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . Я знаю, что мне нужно изменить это . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . И мне от этого грустно . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . [{Name_Hero}], мне очень жаль . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . я бы хотела, чтобы все продолжалось так, как сейчас. .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~[. . и чтобы ничего не менялось . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . я знаю, что надо относиться к ней . .]"));
            CadreNum++; AddCadre(Text.Show($"[? ? ?]~. . Эй . ."));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . не как к другу . .]"));
            CadreNum++; AddCadre(Text.Show($"[? ? ?]~. . Проснись . . "));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . а как к той, кого я люблю . .]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Girl}]~. . да проснись уже . . !"));

            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];
            Sound.CurrentSE = Effects["Wear moving"];

            CadreNum++; AddCadre(
                           Girl.EventHidden(transform_Appearing_3),
                           Text.Show(". . . Вау . . ."),
                           Sound.Bgm(),
                           Sound.SE()
                           );
            
            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Girl}]~. . . Опять? Тебе самому не надоело . . ?")
                           );

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . уф . ."));

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Girl}]~(*вздох*). . . Я устала от этого уже . . ?")
                           );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Hero}]~. . живот . . болит . .")
                );
            
            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Hero}]~[. . стоп, во первых, я не мог заснуть, потому что слишком много вчера сьел . .]")
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Hero}]~[. . так что это ЕЕ вина . .]")
                );

            CadreNum++; AddCadre(
                Girl.Event(),
                Text.Show($"[{Name_Hero}]~[. . и я наконец сегодня посплю . .]")
                );

            CadreNum++; AddCadre(
                Girl.Event( $"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Hero}]~. . накрываюсь одеялом с головой . .")
                );

            CadreNum++; AddCadre(
                Girl.Event(transform_Disapearing_3),
                Text.Show($"[{Name_Girl}]~. . Эй ! Кончай прятаться и вылезай из под одеяла . . !")
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Hero}]~[. . Говори что хочешь - мне все равно, даже если опоздаю в школу . .]")
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Girl}]~(*вздыхает*). . Ну хорошо - вижу, что это не поможет . .")
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Hero}]~. . . .")
                );

            CadreNum++; AddCadre(
                Sound.BgmStop(),
                Text.Show($"[{Name_Hero}]~. .")
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Hero}]~. . ?")
                );

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Hero}]~тишина. .")
                );

            Girl.CurrentEvent = Events["2"];

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Girl}]~(*посапывает*)"),
                           Sound.Bgm()
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show(". . . . . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event( $"{Trans.ImpactHs(200, 100)}"),
                           Text.Show($"[{Name_Hero}]~так ты тоже спишь . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Girl}]~(*посапывает*)")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show(". . . . . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event($"{Trans.ImpactHs(200, 100)}"),
                           Text.Show($"[{Name_Hero}]~у нее должно быть много дел. .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show(". . . . . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . я чувствую что-то мягкое . .]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show(". . . . . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . вместе с моим другом детства . . то есть с девушкой которую я люблю . .]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . может это . . опасно . . ?]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($". . *жим* . . *жим* . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . ого . . неважно, что об этом думать, но это не выглядит как дружба . .]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . от ее тепла . . я стал представлять, как она лежит подо мной . .]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . на что это похоже . .]")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show(". . . . . .")
                           );

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Hero}]~[ . . ух . . становится жарко . .]")
                           );            

            CadreNum++; AddCadre(
                           Girl.Event(Events["1"]),
                           Girl.Event(Events["2"], transform_Disapearing_4),
                           Text.Show($"[{Name_Girl}]~Ох . . . Я заснула . . .")
                           );

            Girl.CurrentEvent = Events["1"];

            CadreNum++; AddCadre(
                           Girl.Event(),
                           Text.Show($"[{Name_Girl}]~[ . . черт . .]")            
                           );

            Place.Current = Locations["Hero room morning"];

            CadreNum++; AddCadre(
                Text.Show($". . {Name_Girl} быстро встала . ."),
                Place.Show()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.EventHidden(transform_Appearing_4),
                Text.Show($"[{Name_Girl}]~. . А а а а . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure($"{Trans.ImpactHs(200, 100)}"),
                Text.Show($"[{Name_Girl}]~. . Что ты тут делал . . ? !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~. . я . . ничего . . ? !"),
                Place.Show()
                );

            // expression
            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . Не знаю что происходит, но это многое упрощает . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . Давай, проснись и пой . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . . !"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . если я что-то не сделаю. . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[. . если она увидит мой стояк, она будет смеяться надо мной до конца жизни. . !]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~ . . сейчас, подожди . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[ . . она силой забрала одеяло у меня . . ]"),
                Place.Show($"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[ . . нет . . ]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . "),
                Place.Show(),
                Sound.BgmStop()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~ . . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~[ . . она не заметила . . ?]"),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~. . а . ?"),
                Place.Show()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . . "),
                Place.Show()
                );

            // expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Girl}]~. . ну давай, пошли уже. ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~. . . "),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Text.Show($"[{Name_Hero}]~. . понял . ."),
                Place.Show()
                );

            CadreNum++; AddCadre(
                Girl.Figure(transform_Disapearing_4),
                Text.Show($". . . ."),
                Place.Show(transform_Disapearing_4)
                );

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . она . . не сказала ни слова . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . но я уверен, что она видела . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . . . ?]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . стоп, а она вообще думает об ЭТИХ вещах. . ?]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . например, представляя как она обнимает другого человека . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . как она склоняется к незнакомцу . . ]"));
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~[. . я чувствую ревность . . ]"));
        }
        private void Chapter8() 
        {
            AddChapter("Chapter 8", "Chapter 8 - Первая встреча с мерзавцем.");

            Sound.CurrentBGM = BGM["Good morning"];           
            Place.Current = Locations["Street morning"];
            // expression
            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(      
                Girl.FigureHidden(transform_Appearing_4),
                Place.Show(),
                Text.Show(". . . . . ."),
                Sound.BgmMuted(transform_sound_delay_1)
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show("[. . . это немного странно. . .]")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show("[. . . похоже мы оба не знаем что сказать . . .]")
                );

            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Girl}]~. . . ну ладно . . я пойду . . .")
                );

            CadreNum++; AddCadre(
                Girl.Figure(transform_Disapearing_4),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . да . . ? . . ну . . ладно . . .")
                );

            CadreNum++; AddCadre(
                Place.Show(),
                Text.Show($"[{Name_Hero}]~[. . . убежала . . .]")
                );

            CadreNum++; AddCadre(
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . я ее уже еле вижу, бастрая как метеор . . .")
                );

            CadreNum++; AddCadre(
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . хм . . ? кажется, я кого-то вижу . . .")
                );

            CadreNum++; AddCadre(
                Sound.BgmStop(),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . хм . . ?")
                );

            SetBastard();

            CadreNum++; AddCadre(
                Bastard.FigureHidden(transform_Appearing_4),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . берегись . . !")
                );

            Sound.CurrentSE = Effects["Бум"];

            CadreNum++; AddCadre(
              Bastard.Figure($"{Trans.Wait(500)}>{Trans.ImpactHs(200, 100)}"),
              Girl.FigureHidden($"O.B.500.100>{Trans.ImpactHs(200, 100)}"),
              Place.Show(),
              Text.Show($" . . Ааааааа . . "),
              Sound.SE()
              );

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . Ой, чуть не убились . . ")
              );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; AddCadre(
              Bastard.Figure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.Figure($"{Trans.ImpactHs(200, 30)}"),
              Place.Show(),
              Text.Show($" . . *Сжал* . . "),
              Sound.SE()
              );

            SetGirlExpression_Surprised();


            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . ! ! ! . . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . прости ! ! ! . . прости ! ! ! . . . с тобой все в порядке . . ! ! ! ?")
              );

            CadreNum++; AddCadre(
              Bastard.Figure($""),
              Girl.Figure($""),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . э-э-э . . Да, вроде . . ")
              );


            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . я дико извиняюсь . . у тебя ничего не болит . . .?")
              );

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[Незнакомец]~. . вроде нет . . .")
              );

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . ты уверен . . . ?")
              );


            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; AddCadre(
              Bastard.Figure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.Figure($"{Trans.ImpactHs(200, 30)}"),
              Place.Show(),
              Text.Show($"[Незнакомец]~. . *Сжал* . . "),
              Sound.SE()
              );

            CadreNum++; AddCadre(
              Bastard.Figure($""),
              Girl.Figure($""),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . . . ")
              );

            CadreNum++; AddCadre(
              Bastard.Figure($""),
              Girl.Figure($""),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . еще немного, здесь. . *трогает*")
              );


            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure($"{Trans.MoveHs(50, -20)}"),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . вот тут ? . . больно . . .?"),
              Sound.SE()
              );

            CadreNum++; AddCadre(
              Bastard.Figure($""),
              Girl.Figure($""),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . . . ")
              );

            CadreNum++; AddCadre(
              Bastard.Figure($""),
              Girl.Figure($""),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . все нормально. . ")
              );

            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . слава богу . . .!")
              );

            CadreNum++; AddCadre(
              Bastard.Figure($"{Trans.MoveHs(10, 50)}"),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . . . ")
              );

            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
              Bastard.Figure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.Figure($"{Trans.ImpactHs(200, 30)}"),
              Place.Show(),
              Text.Show($"[Незнакомец]~. . *сжал*"),
              Sound.SE()
              );

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~ . . еще раз извини, что налетела на тебя . . .!")
              );

            CadreNum++; AddCadre(
              Bastard.Figure(),
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[Незнакомец]~ . . хе хе . . ")
              );

            CadreNum++; AddCadre(
              Bastard.Figure(transform_Disapearing_2),
              Girl.Figure(transform_Disapearing_2),
              Place.Show(transform_Disapearing_2),
              Text.Show($". . . . ")
              );

            Sound.CurrentSE = Effects["Бег"];

            CadreNum++; AddCadre(
                Text.Show($"[{Name_Hero}]~ . . {Name_Girl}, ты в порядке . . ?"),
                Sound.SE()
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
              Girl.FigureHidden(transform_Appearing_4),
              Place.ShowHidden(transform_Appearing_4),
              Text.Show($"[{Name_Girl}]~. . о , {Name_Hero}. . да . . все в порядке . . ")
              );

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Hero}]~. . я плохо видел, что сдесь произошло . . ?")
              );

            SetGirlExpression_Surprised();

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~. . тут был вот этот {bastard_title}, и. . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~. . ой, он только что был здесь . . ушел . . .")
              );

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Hero}]~. . ? ты все еще спишь . . .?")
              );

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show($"{Trans.ImpactHs(200, 30)}"),
              Text.Show($"[{Name_Girl}]~. . он определенно был еще недавно здесь . . ")
              );

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Hero}]~. . тебе надо смотреть внимательно, куда бежишь . . .")
              );

            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~. . ха ха . . это точно . . ")
              );

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Hero}]~. . похоже ты не пострадала, так что пошли . . .")
              );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
              Girl.Figure(),
              Place.Show(),
              Text.Show($"[{Name_Girl}]~. . да, пошли . . ")
              );

            Sound.CurrentSE = Effects["Бег"];

            CadreNum++; AddCadre(
              Girl.Figure(transform_Disapearing_2),
              Place.Show(),
              Text.Show($". . . . "),
              Sound.SE()
              );

            CadreNum++; AddCadre(
              Place.Show(transform_Disapearing_2),
              Text.Show($". . . . ")
              );

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . В итоге мы так и не выяснили ничего . . "));

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . Наверно мне повезло просто . . "));

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . С {Name_Girl} все эти штуки насчет секса . . "));

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . Мы никогда не говорили об этом с ней. Для того чтобы не повредить нашим отношениям . . . "));
            
            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . Думаю, у нас есть негласное правило . . . "));

            CadreNum++; AddCadre(Text.Show($"[{Name_Hero}]~. . . *вздох* . . . "));

            CadreNum++; AddCadre(
              Bastard.FigureHidden(transform_Appearing_5),
              Place.ShowHidden(transform_Appearing_4),
              Text.Show($". . . . ")
              );

            CadreNum++; AddCadre(
              Bastard.Figure(transform_Disapearing_2),
              Place.Show(transform_Disapearing_2)
              );

        }
        private void Chapter9()
        {
            AddChapter("Chapter 9");
            
            Place.Current = Locations["School hall day"];

            CadreNum++; AddCadre(
                Place.Show(transform_Appearing_3),
                Text.Show($"[{Name_Hero}]~. . . уроки закончились . . . ")
                );

            Sound.CurrentBGM = BGM["After School"];

            CadreNum++; AddCadre(
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . я все время был занят своими мыслями, и время пробежала незаметно . . . "),
                Sound.Bgm()
                );

            //Figure
            SetGirlWear_Sportwear();
            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.FigureHidden(transform_Appearing_3),
                Place.Show(),
                Text.Show($"[{Name_Girl}]~. . . Ох . . {Name_Hero} ! ! ! ")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. . . ? ")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~. .  Ого !  Ты уже переоделась ? ? ")
                );

            SetGirlExpression_Laughing();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Girl}]~. .  Хих . У нас сейчас игра . . ")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Girl}]~. . . Переодеваться было непросто . . ")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~[. .  . я был очарован ею . . ]")
                );

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Hero}]~[. .  . она выглядела потрясающе. . ]")
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; AddCadre(
                Girl.Figure(),
                Place.Show(),
                Text.Show($"[{Name_Girl}]~. .  . раз у меня игра, ты идешь домой один. . ")
                );

        }
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
        private void AddCadre(List<string> list, params string[] frames)
        {
            AddCadre(list, null, frames);
        }
        private void AddCadre(List<string> list, List<string> list2, params string[] frames)
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
        private void AddCadre(params string[] frames)
        {
            AddCadre(null, frames);
        }
    }

}
