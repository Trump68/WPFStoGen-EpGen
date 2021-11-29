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
    public class Story01 : StoryMaker
    {
        public static string Name = "She Falls to a Perverted Bastard (original)";

        protected Person Girl;
        protected Person Bastard;
        protected Person GuyA;
        protected Person GuyB;
        protected Person Hero;
        protected CadreText Text;
        protected Location Place;
        protected CadreSound Sound;
        protected Dictionary<string, string> Events;
        protected Dictionary<string, string> BGM;
        protected Dictionary<string, string> Expression;
        protected Dictionary<string, string> Locations;
        protected Dictionary<string, string> Effects;




        public Story01() : base()
        {
            Text = new CadreText(this);
            Place = new Location(this);
            Sound = new CadreSound(this);
        }

        private void CreateData() 
        {
            Girl = new She_Falls_to_a_Perverted_Bastard(this, "Комаки");
            Girl.Titles.Add("сестренка");

            Bastard = new Perverted_Bastard(this, "Футоши");
            Bastard.Titles.Add("мальчик");

            Hero = new Person(this, "Кохеи");
            GuyA = new Siluette(this, "Парень А");
            GuyB = new Siluette(this, "Парень Б");
            

            Events = new Dictionary<string, string>();
            Events.Add("1", "Event 001");
            Events.Add("2", "Event 002");
            Events.Add("3", "Event 003");
            Events.Add("4", "Event 004");
            Events.Add("5", "Event 005");
            Events.Add("6", "Event 006");
            Events.Add("7", "Event 007");
            Events.Add("8", "Event 008");
            Events.Add("9", "Event 009");
            Events.Add("10", "Event 010");
            Events.Add("11", "Event 011");
            Events.Add("12", "Event 012");
            Events.Add("13", "Event 013");

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
        private void SetGirlExpression_Sorry()
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
            CreateData();
            AddHeader();

            
            Girl.Z = 5;

            
            Bastard.Z = 8;

            
            GuyA.Z = 8;
            GuyA.O = 75;
            
            GuyB.Z = 9;
            GuyB.O = 75;


            Place.Description = "Location background";
            
            Chapter1();
/*            Chapter2();
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
            Chapter14();*/
            Chapter15();
            Chapter16();
            Chapter17();
            Chapter18();
        }
        private void Chapter1()
        {
            AddChapter("Chapter 1");           

            AddCadre(); Text.Show(". . . . . . . . . . . .");
            AddCadre(); Text.Show("Взглядов на жизнь на свете так же много, как много и людей.");
            AddCadre(); Text.Show(". . . Некоторые люди возможно заставят вас успешно сдать экзамен или найти работу.");
            AddCadre(); Text.Show(". . . Некоторые люди возможно скажут вам не тратить время зря.");
            AddCadre(); Text.Show(". . . Но дремать, наслаждаясь комфортом - это одна из разновидностей счастья.");
            AddCadre(); Text.Show(". . . Что я и делаю сейчас . . .");
            AddCadre(); Text.Show("[Голос]~'Эй ...'");
            AddCadre(); Text.Show(". . . похоже это . . .");
            AddCadre(); Text.Show("[Голос]~'Эй . . . Просыпайся . . .'");
            AddCadre(); Text.Show(". . . похоже это . . .");
            AddCadre(); Text.Show($"[{Girl.Name}]~'АХХ!!! . . . ДА ПРОСЫПАЙСЯ УЖЕ !!!'");

            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];            
            Sound.CurrentSE = Effects["Wear moving"];
            Place.Current = Locations["Hero room morning"];
            

            AddCadre(); Girl.SmartShowEvent(); Text.Show(". . . Ох! Ну что еще? . . ."); Sound.BgmMuted(transform_sound_delay_1); Sound.SE();
            AddCadre(); Girl.SmartShowEvent(); Text.Show($"[{Girl.Name}]~'О-о . . . Хорошо тут сидеть . . .'");                
            AddCadre(); Girl.SmartShowEvent(); Text.Show($". . . Я чувствую приятную мягкую тяжесть на себе . . .'");                
            AddCadre(); Girl.SmartShowEvent($"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"); Text.Show($"[{Girl.Name}]~'*вздыхает* Может мне отохнуть здесь . . . ?'");                
            AddCadre(); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}"); Text.Show($". . . Это немного . . . тяжело . . .'");                
            AddCadre(); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}"); Text.Show($"[{Girl.Name}]~. . . Я наверно  позавтракаю прямо здесь. . .'");                
            AddCadre(); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}"); Text.Show($". . . Ты не ела дома. . ?'");                
            AddCadre(); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}"); Text.Show($"[{Girl.Name}]~. . . А может, просто растянуться здесь и полежать. . ?''");                
            AddCadre(); Girl.SmartShowEvent(); Text.Show($". . . Все, я понял, понял. . .  уже встаю. . .''");                

            //Expression && Wear
            SetGirlWear_Shchool_Dress();
            SetGirlExpression_AgitatedSmile();            

            AddCadre(); Girl.SmartShowEvent(); Text.Show($"[{Girl.Name}]~. . . Ну, если так. . Тогда проснись и пой . .!"); Place.SmartShow();                
            AddCadre(); Girl.SmartShowEvent(); Text.Show($". . . Мое покрывало тут же забрали . ."); Place.SmartShow();
            AddCadre(); Girl.SmartShowEvent(); Text.Show($". . . Я уже начинаю привыкать к этому . ."); Place.SmartShow();
                
            //Expression
            SetGirlExpression_Surprised();

            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($". . Ой . . "); Place.SmartShow();

            // Expression
            SetGirlExpression_Laughing();

            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Хих . . . Ты забыл об этом . . !"); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"); Place.SmartShow();                

            //Expression
            SetGirlExpression_Troubled();

            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Но я уже привыкла обычно будить тебя . . !"); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($". . Для того чтобы наслаждаться этим общением и ее красотой . ."); Place.SmartShow();
            AddCadre(); Girl.SmartFigure(); Text.Show($". . признаюсь честно, я иногда специально просыпал . ."); Place.SmartShow();                

            //Expression
            SetGirlExpression_Surprised();

            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"); Place.SmartShow();
            AddCadre(); Girl.SmartFigure(); Sound.BgmStop(); Text.Show($". . Мы с ней друзья с детства . ."); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($". . И еще - я люблю ее . ."); Place.SmartShow();
            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($"Возможно, она еще не совсем женщина, но какая же она заботливая"); Place.SmartShow();                

            //Expression
            SetGirlExpression_Laughing();

            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Наверно как нибудь я об этом подумаю . ."); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($"Какая же у ней улыбка . ."); Place.SmartShow();                
            AddCadre(); Girl.SmartFigure(); Text.Show($"Я просто постоянно думаю о ней . ."); Place.SmartShow();                

            //Expression
            SetGirlExpression_Surprised();

            AddCadre(); Girl.SmartFigure($"{Trans.ImpactHs(200, 50)}"); Text.Show($"[{Girl.Name}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}");                
            AddCadre(); Girl.SmartFigure(); Text.Show($"[{Girl.Name}]~Давай быстрей собирайся . . !"); Place.SmartShow();                
            AddCadre(); Text.Show(". . . .");
            AddCadre(); Text.Show(". . . . Мы были обычными соседями сначала, и не были близкими друзьями . . .");
            AddCadre(); Text.Show(". . . . Ее родители развелись, когда мы еще были детьми . . .");
            AddCadre(); Text.Show(". . . . И я довольно часто видел ее на улице одну . . .");
            AddCadre(); Text.Show(". . . . Когда я позвал ее, она была счастлива . . .");
            AddCadre(); Text.Show(". . . . И мы стали проводить время вместе . . .");
            AddCadre(); Text.Show(". . . . Возможно . . . у нее нет романтических чувств ко мне . . .");
            AddCadre(); Text.Show(". . . . Но у меня - есть . . . они возникли в общем-то недавно . . .");
        }
/*        private void Chapter2()
        {
            AddChapter("Chapter 2");

            Place.Current = Locations["Street morning"];
            Sound.CurrentBGM = BGM["Good morning"];

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Apearing_1),
                Sound.oldBgmMuted(transform_sound_delay_1),
                Text.OldShow($"[{Girl.Name}]~. . . Ну что, ты проснулся наконец . . ?"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );
           

            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"Ой . . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}]~Да ладно, даже когда я с тобой? Соберись уже . . . !"),
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
                Text.OldShow($"[{Girl.Name}]~. . . Может потому что ты всегда спишь?"),
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
                Text.OldShow($"[{Girl.Name}]~. . . Хмм, все равно, я бегу на занятия в свой клуб . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . Ладно, я могла бы иногда проводить больше времени с тобой, как мы иногда делаем . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Такие дни просто класс . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . Я могу тебя будить, как только сама встаю. . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Вот всегда она так . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[. . . Я боюсь за наши отношения  . . ]"),
                Place.OldShow()
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[{Girl.Name}]~. . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[. . . Погоди . . . {Girl.Name} . . . ты слишком быстро бежишь . . .]"),
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
                Text.OldShow($"[{Girl.Name}]~. . . Ух, еле успели . . !"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
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
                Text.OldShow($"[{Girl.Name}]~. . . Отлично, тогда пока, увидимся позже . . !"),
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
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($". . . {Girl.Name} сегодня на тренировке команды болельщиц . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[Я рассеяно смотрю на школьный двор . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Girl.Name}]~Ой . . . наконец я тебя нашла ! ! !"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            CadreNum++; OldAddCadre(// д.краснеет(ее майка стала прозрачная от пота)
                Girl.oldFigureHidden(transform_Apearing_1),
                Text.OldShow($"[{Girl.Name}]~. . . Ну, как дела ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}]~. . . Я вижу тебя за милю . . !"),
                Place.OldShow()
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . Погоди . . !"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}]~. . . Ты в порядке . . ?"),
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
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}]~. . . Ты в порядке . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~Слушай, [{Hero.Name}], иногда ты очень странный . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~Когда я тебя вижу, то невольно хочу подойти . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[Капитан команды]~Ей, {Girl.Name} ! . . А кто сказал, что тренировка закончена . . ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            //Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~Упс . . нет, я не закончила тренировку . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~Капитан следит за мной все время . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . Все нормально . . ?"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}] . . . Хмм . . Думаю, он всего лишь слишком строгий . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . ."),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
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
                Text.OldShow($"[{Girl.Name}] . . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}] . . . Увидимся . . . !"),
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

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ уф, тренировка закончена. . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . я иду домой одна. . . ]"));


            CadreNum++; OldAddCadre( 
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . во время тренировки. . . я просто бегаю и не могу ни о чем другом думать . . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . и это мне не нравится . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . я приду домой, но там никого нет. . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . и даже если кто-то будет дома, это мне не поможет никак. . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["House evening"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Как я и предполагала - дома никого нет. .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Когда моих родителей нет дома, я чувствую облегчение. .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. .  ведь тогда мне не нужно бороться с чувством неловкости . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. .  но в то же время, когда их нет - мне одиноко . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. .  и так было всегда . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. .  . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
                );

            Place.Current = Locations["Girl room evening"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Но я так и не привыкла быть одной  . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_3)
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Было время когда я проводила время на улице  . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[(*вздыхает*) здесь мне нечего делать . . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Когда это становится невыносимым, я опять делаю это . .]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . ладно тогда . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . . .]"),
                Place.OldShow()
                //AddImageByTemplate("Black background", 20, template_frame_main, null, 0, transform_Apearing_1)
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
                Text.OldShow($"[{Hero.Name}]~[. . О-о-о. .]"),
                Place.OldShow()             
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Хих . .]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . {Hero.Name},ты устал верно? Давай поедим снеков  . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . Извини . . . я только поужинал  . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . Подожди . . . а кто тебя впустил  . . ?]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . М-м . . . твоя . . мама  . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );


            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . Ух  . .  почему я не могу побыть один . . .]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($". . . . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Он иногда говорит такое  . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Но мой друг . . будет со мной . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Наверно я злоупотребляю его терпением . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~. . Итак  . .  что ты там говорила про снеки . . ?"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Ну вот видите . . !]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . Их полно в магазине, так что . . давай их возьмем . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~[. . Я их уже принесла . . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . Серьезно  . .  ты только снеки купила . . ?]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            // Expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . Да мне все равно . . !]"),
                Place.OldShow()
                );

            // Expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . Хих . . "),
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

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . Получается, я все время создаю ему проблемы . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . Я знаю, что мне нужно изменить это . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . И мне от этого грустно . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . [{Hero.Name}], мне очень жаль . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . я бы хотела, чтобы все продолжалось так, как сейчас. .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . и чтобы ничего не менялось . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . я знаю, что надо относиться к ней . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[? ? ?]~. . Эй . ."));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . не как к другу . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[? ? ?]~. . Проснись . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . а как к той, кого я люблю . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . да проснись уже . . !"));

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
                           Text.OldShow($"[{Girl.Name}]~. . . Опять? Тебе самому не надоело . . ?")
                           );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . уф . ."));

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Girl.Name}]~(*вздох*). . . Я устала от этого уже . . ?")
                           );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Hero.Name}]~. . живот . . болит . .")
                );
            
            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Hero.Name}]~[. . стоп, во первых, я не мог заснуть, потому что слишком много вчера сьел . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Hero.Name}]~[. . так что это ЕЕ вина . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Hero.Name}]~[. . и я наконец сегодня посплю . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent( $"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[{Hero.Name}]~. . накрываюсь одеялом с головой . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(transform_Disapearing_3),
                Text.OldShow($"[{Girl.Name}]~. . Эй ! Кончай прятаться и вылезай из под одеяла . . !")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~[. . Говори что хочешь - мне все равно, даже если опоздаю в школу . .]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Girl.Name}]~(*вздыхает*). . Ну хорошо - вижу, что это не поможет . .")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~. . . .")
                );

            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Text.OldShow($"[{Hero.Name}]~. .")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~. . ?")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~тишина. .")
                );

            Girl.CurrentEvent = Events["2"];

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Girl.Name}]~(*посапывает*)"),
                           Sound.oldBgm()
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent( $"{Trans.ImpactHs(200, 50)}"),
                           Text.OldShow($"[{Hero.Name}]~так ты тоже спишь . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Girl.Name}]~(*посапывает*)")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                           Text.OldShow($"[{Hero.Name}]~у нее должно быть много дел. .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . я чувствую что-то мягкое . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . вместе с моим другом детства . . то есть с девушкой которую я люблю . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . может это . . опасно . . ?]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($". . *жим* . . *жим* . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . ого . . неважно, что об этом думать, но это не выглядит как дружба . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . от ее тепла . . я стал представлять, как она лежит подо мной . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . на что это похоже . .]")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow(". . . . . .")
                           );

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Hero.Name}]~[ . . ух . . становится жарко . .]")
                           );            

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(Events["1"]),
                           Girl.oldEvent(Events["2"], transform_Disapearing_4),
                           Text.OldShow($"[{Girl.Name}]~Ох . . . Я заснула . . .")
                           );

            Girl.CurrentEvent = Events["1"];

            CadreNum++; OldAddCadre(
                           Girl.oldEvent(),
                           Text.OldShow($"[{Girl.Name}]~[ . . черт . .]")            
                           );

            Place.Current = Locations["Hero room morning"];

            CadreNum++; OldAddCadre(
                Text.OldShow($". . {Girl.Name} быстро встала . ."),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Appearing_4),
                Text.OldShow($"[{Girl.Name}]~. . А а а а . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[{Girl.Name}]~. . Что ты тут делал . . ? !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~. . я . . ничего . . ? !"),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . Не знаю что происходит, но это многое упрощает . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . Давай, проснись и пой . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . . !"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . если я что-то не сделаю. . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[. . если она увидит мой стояк, она будет смеяться надо мной до конца жизни. . !]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~ . . сейчас, подожди . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[ . . она силой забрала одеяло у меня . . ]"),
                Place.OldShow($"{Trans.ImpactHs(200, 50)}")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[ . . нет . . ]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . "),
                Place.OldShow(),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~ . . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~[ . . она не заметила . . ?]"),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~. . а . ?"),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . . "),
                Place.OldShow()
                );

            // expression
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Girl.Name}]~. . ну давай, пошли уже. ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~. . . "),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Text.OldShow($"[{Hero.Name}]~. . понял . ."),
                Place.OldShow()
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_4),
                Text.OldShow($". . . ."),
                Place.OldShow(transform_Disapearing_4)
                );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . она . . не сказала ни слова . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . но я уверен, что она видела . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . . . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . стоп, а она вообще думает об ЭТИХ вещах. . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . например, представляя как она обнимает другого человека . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . как она склоняется к незнакомцу . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . я чувствую ревность . . ]"));
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
                Text.OldShow($"[{Girl.Name}]~. . . ну ладно . . я пойду . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_4),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . да . . ? . . ну . . ладно . . .")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . убежала . . .]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . я ее уже еле вижу, бастрая как метеор . . .")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . хм . . ? кажется, я кого-то вижу . . .")
                );

            CadreNum++; OldAddCadre(
                Sound.oldBgmStop(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . хм . . ?")
                );

            SetBastard();

            CadreNum++; OldAddCadre(
                Bastard.oldFigureHidden(transform_Appearing_4),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . берегись . . !")
                );

            Sound.CurrentSE = Effects["Бум"];

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.Wait(500)}>{Trans.ImpactHs(200, 50)}"),
              Girl.oldFigureHidden($"O.B.500.100>{Trans.ImpactHs(200, 50)}"),
              Place.OldShow(),
              Text.OldShow($" . . Ааааааа . . "),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . Ой, чуть не убились . . ")
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
              Text.OldShow($"[{Girl.Name}]~ . . ! ! ! . . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . прости ! ! ! . . прости ! ! ! . . . с тобой все в порядке . . ! ! ! ?")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . э-э-э . . Да, вроде . . ")
              );


            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . я дико извиняюсь . . у тебя ничего не болит . . .?")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . вроде нет . . .")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . ты уверен . . . ?")
              );


            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.oldFigure($"{Trans.ImpactHs(200, 30)}"),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . *Сжал* . . "),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . еще немного, здесь. . *трогает*")
              );


            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure($"{Trans.MoveHs(50, -20)}"),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . вот тут ? . . больно . . .?"),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($""),
              Girl.oldFigure($""),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . все нормально. . ")
              );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . слава богу . . .!")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(10, 50)}"),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . . . ")
              );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
              Bastard.oldFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"),
              Girl.oldFigure($"{Trans.ImpactHs(200, 30)}"),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . *сжал*"),
              Sound.oldSE()
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~ . . еще раз извини, что налетела на тебя . . .!")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(),
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . хе хе . . ")
              );

            CadreNum++; OldAddCadre(
              Bastard.oldFigure(transform_Disapearing_2),
              Girl.oldFigure(transform_Disapearing_2),
              Place.OldShow(transform_Disapearing_2),
              Text.OldShow($". . . . ")
              );

            Sound.CurrentSE = Effects["Бег мальчик"];

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~ . . {Girl.Name}, ты в порядке . . ?"),
                Sound.oldSE()
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
              Girl.oldFigureHidden(transform_Appearing_4),
              Place.OldShowHidden(transform_Appearing_4),
              Text.OldShow($"[{Girl.Name}]~. . о , {Hero.Name}. . да . . все в порядке . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Hero.Name}]~. . я плохо видел, что сдесь произошло . . ?")
              );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~. . тут был вот этот {Bastard.Titles[0]}, и. . ")
              );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~. . ой, он только что был здесь . . ушел . . .")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Hero.Name}]~. . ? ты все еще спишь . . .?")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow($"{Trans.ImpactHs(200, 30)}"),
              Text.OldShow($"[{Girl.Name}]~. . он определенно был еще недавно здесь . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Hero.Name}]~. . тебе надо смотреть внимательно, куда бежишь . . .")
              );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~. . ха ха . . это точно . . ")
              );

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Hero.Name}]~. . похоже ты не пострадала, так что пошли . . .")
              );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
              Girl.oldFigure(),
              Place.OldShow(),
              Text.OldShow($"[{Girl.Name}]~. . да, пошли . . ")
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

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . В итоге мы так и не выяснили ничего . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . Наверно мне повезло просто . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . С {Girl.Name} все эти штуки насчет секса . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . Мы никогда не говорили об этом с ней. Для того чтобы не повредить нашим отношениям . . . "));
            
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . Думаю, у нас есть негласное правило . . . "));

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . . *вздох* . . . "));

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
                Text.OldShow($"[{Hero.Name}]~. . . уроки закончились . . . ")
                );

            Sound.CurrentBGM = BGM["After School"];

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . я все время был занят своими мыслями, и время пробежала незаметно . . . "),
                Sound.oldBgm()
                );

            //Figure
            SetGirlWear_Sportwear();
            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigureHidden(transform_Appearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. . . Ох . . {Hero.Name} ! ! ! ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . ? ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. .  Ого !  Ты уже переоделась ? ? ")
                );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  Хих . У нас сейчас игра . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. . . Переодеваться было непросто . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. .  . я был очарован ею . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. .  . она выглядела потрясающе. . ]")
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . раз у меня игра, ты идешь домой один. . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. .  . о, мне надо тоже кое что тут еще сделать, так что я буду в школе еще час . . ")
                );

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . но за час я точно не успею . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. .  . ничего, я подожду . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . на самом деле может быть я задержусь и после игры . . ")
                );

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . у новичков проблемы с формой . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . и я обещала помочь им. так что ты наверно можешь . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . не ждать меня . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. .  . о , ну хорошо . . ")
                );

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . Но в любом случае - спасибо . . ")
                );

            SetGirlExpression_AgitatedSmile();

            Sound.CurrentSE = Effects["Бег девочка"];

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . Увидимся . . !"),
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
                Text.OldShow($"[{Girl.Name}]~. .  . Ах да, завтра у нас тренировка с утра, так что я не приду тебя будить . . !")              
                );

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. .  . Пожалуйста, не проспи . . !")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(transform_Disapearing_3),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. .  . Исчезла как молния . . "),
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
                Text.OldShow($"[{Hero.Name}]~[. . хм ? . . ]"),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . хм ? . . ]"),
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
                Text.OldShow($"[{Hero.Name}]~[. .  . Вот черт . . я так и думал . . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[ .  . Куча парней смотрят на нее такими же глазами . . ]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[ А ее это совсем не волнует . . Я тревожусь за нее . .]")
                );

            CadreNum++; OldAddCadre(
                GuyA.oldFigure(),
                GuyB.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[ Я вспомнил ее беззаботную улыбку . . И моя тревога только возросла . .]")
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

            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . . я опять это сделала . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . . я жестоко поступила с {Hero.Name} вчера . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . . пока я думала об этом . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . . то не заметила небольшую тень. . . ]"));

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
                Text.OldShow($"{Girl.Name}]~. . . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . я . . врезалась в кого-то . . ?")
                );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow(". . . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . этот {Bastard.Titles[0]} . . . который был вчера . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . не могу поверить, что я врезалась в него снова . . !")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . нужно встать . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . я пытаюсь двинуться . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . это сложно, потому что он лежит на мне . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . он . . тяжелее, чем кажется . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . . уффф. .ухххх . . .")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . . он обнимает меня, и очень крепко . . .")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . я не должна думать об этом . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . но когда кто-от ТАК вжимается в тебя . . .")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . хочется типа . . . защитить его . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . не знаю точно, что это . . . но такое часто бывает со мной . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . . уффф. .ухххх . . .")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . . . ?")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . с ним все в порядке ? . . он не ударился ? . . ")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldEvent(),
                 Text.OldShow($"{Girl.Name}]~. . . нужно встать . . ")
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
                 Text.OldShow($"{Girl.Name}]~. . . прошу прощения, я не смотрела куда иду . . ")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . да, это тот же самый вчерашний {Bastard.Titles[0]} . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . и на этот раз я налетела на него очень сильно . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . я такая дура . . ]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . с тобой все хорошо ? . . ]")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . ох . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . ты сильно ударился ? . . может быть, поранился ? . .]")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . наверно нет . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure($"{Trans.ImpactHs(200, 50)}>{Trans.ImpactHs(200, 50)}>{Trans.ImpactHs(200, 50)}"),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . охх . . "),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~[. . . и тут вдруг он скривился от боли . .]")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~. . . что с тобой . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . кажется, я подвернул ногу . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~. . . о нет . . что же делать .. надо вызвать скорую . . .")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . да все нормально . . я только немного ее подвернул . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . я живу рядом . . я дойду . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~. . . ты уверен, что сможешь . . ?")
                 );

            CadreNum++; OldAddCadre(
                Girl.oldFigure(),
                Bastard.oldFigure(),
                Place.OldShow(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . да, просто чуть-чуть больно идти . . ")
                );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"),
                 Bastard.oldFigure(),
                 Place.OldShow(),
                 Text.OldShow($"{Girl.Name}]~. . . ты не сможешь . . !")
                 );

            CadreNum++; OldAddCadre(
                 Girl.oldFigure(transform_Disapearing_2),
                 Bastard.oldFigure(transform_Disapearing_2),
                 Place.OldShow(transform_Disapearing_2),
                 Text.OldShow($" . . ")
                 );

            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . как дошло до этого . . ?]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . я не хочу быть одна . . и с родителями тоже не хочу . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . я всем приношу проблемы и неприятности . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . даже {Hero.Name} . .  всегда прихожу без приглашения . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . когда нибудь, он решит, что я надоедливая . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . . . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . это произошло со мной, потому что я неосторожная. . ]"));
            CadreNum++; OldAddCadre(Text.OldShow($"{Girl.Name}]~[. . надо быть более ответственной. . ]"));

            Sound.CurrentSE = Effects["Wear moving"];

            CadreNum++; OldAddCadre(
                Sound.oldSE(),
                Text.OldShow($". . . .")
                );

            Girl.CurrentEvent = Events["4"];

            CadreNum++; OldAddCadre(
                Girl.oldEventHidden(transform_Appearing_3),
                Sound.oldBgm(),
                Text.OldShow($"{Girl.Name}]~. . Ладненько . . Все хорошо ? . . Хорошо ухватился ? ")
                );

            Sound.CurrentSE = Effects["Вжик"];

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~ . . хе хе . . ага . . *Сжал* . . "),
                Sound.oldSE()
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . Нгх . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . это . . не там немного . .]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . он схватился . . ?]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . больно . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . нет . . хе хе . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . как сильно он схатился за меня . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . я чувствую его дыхание на своей шее . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . это щекотно . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . не помню, когда меня так сильно обнимали . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~[. . мне от этого . . жарко . . ]")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . да, я забыла спросить как тебя зовут . .  ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[Незнакомый {Bastard.Titles[0]}]~. . {Bastard.Name} . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . очень приятно, {Bastard.Name} ,  я {Girl.Name} . .  ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"[{Bastard.Name}]~. . Могу я звать тебя '{Girl.Titles[0]}' . . ?")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . хи-хих . . это немного смущает . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . но . . я не против . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent(),
                Text.OldShow($"{Girl.Name}]~. . Ну тогда, {Girl.Titles[0]} доставит тебя домой, так что направляй . . ")
                );

            CadreNum++; OldAddCadre(
                Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 50)}"),
                Text.OldShow($"[{Bastard.Name}]~ . . хе хе . . "),
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
                Text.OldShow($"[{Hero.Name}]~. . . . . . "),
                Sound.oldBgmMuted(transform_sound_delay_1)
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~. . . Это чувство покоя . . . ")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . Я точно опоздаю в школу . . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(transform_Disapearing_2),
                Text.OldShow($"[{Hero.Name}]~[. . . Стоп. Она сказала что у ней с утра тренировка . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~[. . . Может быть она и не выглядит очень уж заботливой, но она именно такая . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~[. . . Можно даже сказать - по матерински заботливая . . . ]")
                );

            CadreNum++; OldAddCadre(
                Text.OldShow($"[{Hero.Name}]~[. . . Мне нужно перестать злоупотреблять ее добротой . . . ]")
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
                Text.OldShow($"[{Hero.Name}]~[. . . я тихонько проскользнул в класс . . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . ну хорошо . . а где {Girl.Name} . . ? ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . . . ]"),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . Стоп. Ее нет . . ?]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . Тренировка уже закончилась, она должна быть здесь . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . Она никогда не опаздывала раньше . . ]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . Что же заставило ЕЕ не придти вовремя. . ?]")
                );

            CadreNum++; OldAddCadre(
                Place.OldShow(),
                Text.OldShow($"[{Hero.Name}]~[. . . ]")
                );

            CadreNum++; OldAddCadre(Place.OldShow(transform_Disapearing_2));
        }
        private void Chapter11()
        {
            AddChapter("Chapter 11", "Chapter 11 - сарай в лесу");

            Sound.CurrentSE = Effects["Шаги в лесу 1"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . мне надо все обдумать . . . "), Sound.oldSE(1));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . все равно я опоздала в школу . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . и даже никого не предупредила . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . да и никого дома нет все равно . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . и это к лучшему . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . мои родители редко бывают дома, так уж сложилось . . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . наш дом вообще не выглядит жилым. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . и мне в нем неуютно. . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . . . "));            
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . Эй! Это уже настоящий лес. Ты уверен что мы идем правильно  . . ?"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~. . . хе-хе . . Мы почти пришли  . . "));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~. . . . . ?"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~. . . Все, мы на месте  . . "), Sound.oldSEStop());

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
                Text.OldShow($"[{Girl.Name}]~. . . На месте ? . . . "),
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
                Text.OldShow($"[{Girl.Name}]~[. . Среди деревьев, старый сарай . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Я кажется, видела такие на стройке . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Стены грязные, и заросли травой . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Его можно найти только если подойти близко . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Если честно, он слишком грязный . . ]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. . Ммм . . Это же не твой дом, правда? . . ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Bastard.Name}]~. . Конечно нет !. . Это моя секретная база ! ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. . Секретная база ? ? ! !")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Я хотела отвести его домой и извиниться перед его родителями . . .]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . А это совсем не то . . .]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~[. . Слушай, может нам лучше пойти к твоему дому . . . ?]")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Bastard.Name}]~. . Да кому это нужно ! "),
                Sound.oldBgmStop()
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 50)}"),
                Girl.oldFigure(Girl_X, null),
                Place.OldShow(),
                Text.OldShow($"[{Bastard.Name}]~. . Давай зайдем внутрь ! ")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null),
                Girl.oldFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"),
                Place.OldShow(),
                Text.OldShow($"[{Girl.Name}]~. . Эй, не тащи меня !")
                );

            CadreNum++; OldAddCadre(
                Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2),
                Girl.oldFigure(Girl_X, null, transform_Disapearing_2),
                Place.OldShow(transform_Disapearing_2),
                Text.OldShow($". . ")
                );

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . Наверно мне не надо об этом спрашивать . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . Он играет один в таком месте . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . На это должна быть причина . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . На это должна быть причина . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . И я дала ему повести себя внутрь. .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . .]"));
        }
        private void Chapter12()
        {
            AddChapter("Chapter 12", "Chapter 12 - Бинтование ноги мерзавцу");

            Place.Current = Locations["Сарай"];

            CadreNum++; OldAddCadre(Text.OldShow($". . . . . . "), Place.OldShowHidden(transform_Appearing_3));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Внутри сарая темновато, но прикольно . . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . На стенах пластиковые панели. Наверно прикрывают дыры в стенах . . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Есть так же что то вроде матраса и полки. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Наверно он нашел это. Или принес из дома. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Все это похоже на секретную базу, где {Hero.Name} и я в детстве играли. . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[. . . Хих. Это прикольно . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~[. . . Хе - хе . . Это место глубоко в лесу . . Так что никто не придет сюда ! ]"), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[. . . . . ]"));

            Girl.CurrentEvent = Events["5"];
            Sound.CurrentBGM = BGM["Runned into it"];

            CadreNum++; OldAddCadre(Text.OldShow($"[. . . . . ]"), Girl.oldEventHidden(transform_Appearing_3), Sound.oldBgm());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Я посадила {Bastard.Name}  на матрас и стала бинтовать его лодыжку . . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Я всегда беру бинт с собой когда иду на тренировку . . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Хорошо что я взяла его.  Никогда не знаешь где пригодится. . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . Эта нога, верно . . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ . (*сглотнул слюну*). "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~М-м-м {Girl.Titles[0]}. . ты хорошенькая, правда. . "), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . О . . О чем ты говоришь . . ? "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ . Ты очень красива. Наверняка ты очень популярна . . верно ? "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . О . . я . . ? ]"), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($" . . . . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . Меня еще не называли хорошенькой . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . И {Hero.Name} не называл. ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($". . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Он наверно думает о моих чувствах. . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Это первый раз когда меня назвали хорошенькой. . . мне надо постараться получше . .]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Надо бинтовать лучше . .]"), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ Хих . . спасибо ! . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~Ты смеешся ! . . Ты самая красивая девчонка из всех которых я видел!"), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . ахаха . . много ли ты видел девчонок . . ?]"), Girl.oldEvent());

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ Ок. Поняла. Хватит. Мне. Льстить. ! ! "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Не то чтобы мне было неприятно . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Думаю он пытается просто быть вежливым, как умеет . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ На самом деле, мне это очень приятно . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Надо его тоже как то поблагодарить . ! ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . ."), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Неужели мне так легко польстить ?]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~Слушай {Girl.Titles[0]} . . Ты можешь приходить на эту секретную базу, когда захочешь!"), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ Поняла! Спасибо . . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ Он мне доверяет . .]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ *уххх*  *уффф*"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . я забинтовала твою ногу, но тебе надо пойти к врачу . ."), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ хорошо "), Girl.oldEvent());

            Girl.CurrentEvent = Events["5"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ Нога не распухла , так что все будет хорошо. . "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ (*пялится*) "), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Bastard.Name}]~ . . хехе . .  "), Girl.oldEvent());

            Girl.CurrentEvent = Events["6"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~ . . что это было. . ?"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . я чувствую как на меня смотрят . . ]"), Girl.oldEvent());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . . . ]"), Girl.oldEvent(transform_Disapearing_2));

            Place.Current = Locations["Сарай"];
            SetGirlExpression_Surprised();
            string Bastard_X = "-350";
            string Girl_X = "350";

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(Girl_X, null, transform_Appearing_3), Bastard.oldFigureHidden(Bastard_X, null, transform_Appearing_3), Text.OldShow($"[{Girl.Name}]~ . Ну все, готово. Не туго ?"), Place.OldShowHidden(transform_Appearing_3),Sound.oldBgmStop() );
            CadreNum++; OldAddCadre(Girl.oldFigure(), Bastard.oldFigure(), Text.OldShow($"[{Bastard.Name}]~ . Все норм . ."), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Bastard.Name}]~ . Но {Girl.Titles[0]} должна идти в школу. ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Bastard.Name}]~ . Ты придешь еше, правда . . ?"), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Girl.Name}]~ . Не волнуйся, я зайду на обратном пути . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null,$"{Trans.ImpactHs(200, 50)}"), Text.OldShow($"[{Bastard.Name}]~ . О да ! ! !. . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Bastard.Name}]~ . Только не говори НИКОМУ об этом месте, ладно ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.OldShow($"[{Bastard.Name}]~ . О нем знаешь только ты, {Girl.Titles[0]} . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2), Text.OldShow($". . . "), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . я переживала, но должна была идти в школу . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . ух ты . . секрет . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . только мой . . .]"));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Girl.Name}]~[ . . это прикольно . . .]"));

        }
        private void Chapter13()
        {
            AddChapter("Chapter 13", "Chapter 13 - Она опоздала в класс, с приоткрытой грудью");

            SetGirlWear_Shchool_Dress_Cleavage();
            Place.Current = Locations["Class day"];

            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . Закончен второй урок . . ]"), Place.OldShowHidden(transform_Appearing_3));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . Она так и не связалась со мной . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~[. . Серьезно . . Что случилось ? . . ]"), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.OldShow($"[{Girl.Name}]~(*вздыхает*) . . Так я и думала . . Я сильно опоздала . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . Я почувствовал облегчение, как только увидел ее . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Я думал это ты мне скажешь, что я опаздываю . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ах, {Hero.Name} ! . . Доброе утро . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Где ты была ? Я говорила, что у тебя игра . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Дело в том . . у меня были проблемы . . "), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . м-м-м-м . . э-э-э-э . . . "), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . хих . . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Я . . . я проспала . . ! "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . Видя как странно ведет себя {Girl.Name}, я чувствую тревогу . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Кстати, что с твоей формой ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Хм . . ? "), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ой . .  Пуговица оторвалась . . "), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ха ха . . наверно закатилась где-то . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Быстрей переодевайся . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Да все нормально, я переоденусь перед тренировкой . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . это для МЕНЯ не нормально . . ]"), Place.OldShow($"{Trans.ImpactHs(200, 50)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . хоть это эгоистично . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . но я не хочу чтобы другие парни смотрели на ее грудь . . ]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Пошли сядем на наши места . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Text.OldShow($"[{Hero.Name}]~. . Но я никогда не смогу сказать ей это . . "), Place.OldShow(transform_Disapearing_2));
            CadreNum++; OldAddCadre(Text.OldShow($"[{Hero.Name}]~. . Все что мне остается - смотреть на ее приоткрытую грудь . . "));
            CadreNum++; OldAddCadre(Text.OldShow($". . "));

        }
        private void Chapter14()
        {
            AddChapter("Chapter 14", "Chapter 14 - размолвка с другом");

            SetGirlWear_Shchool_Dress_Cleavage();
            SetGirlExpression_Laughing();
            Place.Current = Locations["Раздевалка"];
            Sound.CurrentBGM = BGM["After School"];

            CadreNum++; OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.OldShow($"[{Girl.Name}]~[. . хих хих хих . . ]"), Place.OldShowHidden(transform_Appearing_3), Sound.oldBgm());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Ты какая-то слишком веселая для того, кто опоздал на уроки . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . После школы . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . я сопровождаю {Girl.Name} на ее тренировку . . "), Place.OldShow());

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure($"{Trans.ImpactHs(200, 50)}"), Text.OldShow($"[{Girl.Name}]~. . А ? Ты говоришь про меня . . ?"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Ты весь урок как-то улыбалась про себя . . Это странно . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . закатное солнце освещало лицо {Girl.Name} . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . раньше я всегда любовался этим . ."), Place.OldShow());

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ох . . Наверно это было написано на моем лице. . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . и слишком сильно . .]"), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ох . . Да просто это ерунда . . которая меня развеселила . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~[. . да ладно . . непривычно что ты так говоришь . .]"), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . подожди-ка . . ты отведала новые снеки ? . ."), Place.OldShow());

            SetGirlExpression_Troubled();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Ты всегда думаешь обо мне так . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Помнишь те снеки которые ты мне приносила ? . . У меня в комнате еще лежит пачка . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . О . . да . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Если появились новые, их не обязательно покупать, это расточительно . . "), Place.OldShow($"{Trans.ImpactHs(200, 50)}"));

            SetGirlExpression_Laughing();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~. . Я не собираюсь скрывать свои карты, пока ты такой скряга . . "), Place.OldShow($"{Trans.ImpactHs(200, 50)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Да ? . . "), Place.OldShow());

            SetGirlExpression_Surprised();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~(*вздыхает*) Если это ты, {Hero.Name} . . Ты меня поймешь . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Чо ты хочешь сказать ? . . "), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~Ты правда не понимаешь . . ?"), Place.OldShow(), Sound.oldBgmStop());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Hero.Name}]~. . Как я могу понять, когда ты ничего не говоришь ? . . "), Place.OldShow($"{Trans.ImpactHs(200, 50)}"));

            SetGirlExpression_AgitatedSmile();

            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($"[{Girl.Name}]~Ахах . . хорошо . . мне надо идти . !"), Place.OldShow($"{Trans.ImpactHs(200, 50)}"));
            CadreNum++; OldAddCadre(Girl.oldFigure(transform_Disapearing_2), Text.OldShow($"[{Hero.Name}]~. . Что ? . . Эй ! . ."), Place.OldShow());
            CadreNum++; OldAddCadre(Girl.oldFigure(), Text.OldShow($". ."), Place.OldShow(transform_Disapearing_2));

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . После тренировки. Я покинула друзей по команде. . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Как обычно, я шла домой. Одна . . . ]");

            Place.Current = Locations["Street evening"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . . . ]"); Place.SmartShow();

        }*/
        private void Chapter15()
        {
            AddChapter("Chapter 15", "Chapter 15 - Перевязывание ноги мерзавцу, глазеющему в декольте");

            Sound.CurrentSE = Effects["Шаги в лесу 1"]; Sound.CurrentBGM = BGM["Runned into it"]; Girl.CurrentEvent = Events["5"];

            AddCadre(); Text.Show($". . . . "); Sound.SELoop();
            AddCadre(); Text.Show($". . . . ");            
            AddCadre(); Text.Show($". . . . "); Sound.SEStop(); Sound.Bgm();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ну хорошо, просто сиди вот так. . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . снова я сижу перед {Bastard.Name}у . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . я должна проверить его ногу . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . надеюсь, она не распухла . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~(*глотает слюнки*) . . класс ! . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Girl.Name}]~А ?. . Ты сказал что-то ? . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~Хм . . Нет, ничего . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["5"];

            AddCadre(); Text.Show($"[{Girl.Name}]~Да ?. . Постой . . Бинт развязался . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . ой . . застежка слетела . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . ты знаешь где она ? . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Нет, я не видел ее . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . странно . . я уверена, она была здесь . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . плохо . . у меня нет другой . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~О!. . Наверно, я обронил ее там . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartHideEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . М-м-м . . здесь . . ?");
            AddCadre(); Text.Show($"[{Bastard.Name}]~Хе-хе-хе. . Да, там . .");

            Girl.CurrentEvent = Events["7"]; Sound.CurrentBGM = BGM["In the Barn"];
            
            AddCadre(); Text.Show($"[{Girl.Name}]~. . За полкой . . ?"); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}"); Sound.Bgm();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Вау (*уфф*) (*уфф*). . "); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я не вижу отсюда . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Ух. . Не достать . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*уфф*) (*уфф*). . она дальше . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["8"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Там . . ?"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Стоя на коленях, я протянула руку так далеко, как смогла . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ух . . Не могу достать . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*уфф*) (*уфф*). . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ух ! . . Никак не достать . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Тело женственное такое . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Она близко уже . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . не могу . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["7"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ты уверен что она здесь? . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Да, еще чуть-чуть . . (*уфф*) . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");

            Girl.CurrentEvent = Events["8"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Мне надо носить больше креплений для бинта с собой . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . хе-хе . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Тут жарко. Одежда даже промокла . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Почти достала . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Вот она . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Уфффф . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . ? . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я об этом не думала, но . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . наверно я была в очень неприличной позе . .]"); Sound.BgmStop();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Но здесь никого, кроме {Bastard.Name} нет . .]");

            Girl.CurrentEvent = Events["5"];  Sound.CurrentBGM = BGM["Runned into it"]; 

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ну вот. Постарайся не терять это больше, хорошо . . ?"); Girl.SmartShowEvent(); Sound.Bgm();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Ладно . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я осмотрела ногу и перебинтовала . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Выглядит хорошо . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Хе-хе . ."); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["6"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . ? . ."); Girl.SmartShowEvent();
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

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Хорошо . . Я все сделала на сегодня !"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Неожиданно я поняла, что наулице уже темно . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Вау. Просто ничего не видно. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Что ж. Его нога вроде в порядке. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Он не собирается идти домой. Похоже мне надо идти домой. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Слушай, {Girl.Titles[0]} !"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);

            SetGirlExpression_Surprised();

            AddCadre(); Text.Show($"[{Bastard.Name}]~Давай ляжем здесь и поболтаем немного . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Что ? . . Ну . . Уже слишком поздно . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Пожалуйста ! . . Мне одному грустно ! . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Уже было поздно . . Я подумала о его семье . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Но когда ты одинока, разумные доводы не работают . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Когда один в своей комнате . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Как мне это знакомо . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);

            SetGirlExpression_AgitatedSmile();

            AddCadre(); Text.Show($"[{Girl.Name}]~Я понимаю тебя . . "); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Но уже темно, поэтому недолго, ладно ? . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Правда ? . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Хе-хе . . {Girl.Titles[0]} . . . ложись сюда . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 50)}");

            Sound.CurrentSE = Effects["Wear moving"];
            SetGirlExpression_Surprised();

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Подожди . . Не тяни меня так . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null); Sound.SE();
            AddCadre(); Text.Show($" . . . "); Place.SmartHide(); Girl.CombineFigureHide(Girl_X, null); Bastard.CombineFigureHide(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ . . В итоге . . Я решила остаться с ним . .]"); 
        }
        private void Chapter17()
        {
            AddChapter("Chapter 17", "Chapter 17 - Тискание в амбаре на матрасе");

            AddCadre(); Text.Show($". . . . ");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . И знаешь это. . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Да . . ");
            AddCadre(); Text.Show($". . . . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Мы говорили о школе, популярных фильмах и тому подобном . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Уже совсем темно . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я чувствую, что он стал прижиматься ко мне все больше. . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Похоже он действительно одинок. . ]");
            AddCadre(); Text.Show($". . . . ");

            Sound.CurrentSE = Effects["Вжик"];

            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*вжимается*) . . "); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Ой . . это . . ");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*вжимается*)  (*тискает*). . "); 
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Не надо . . мне щекотно . . ");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Хе - хе . . Занешь, где я это делаю . . ?"); 
            AddCadre(); Text.Show($"[{Girl.Name}]~. . хих . . здесь? . . ");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*сжимает*)  (*тискает*). . "); Sound.SE();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . {Girl.Titles[0]} . . .  Ты когда-нибудь пробовала . . ?");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*сжимает*)  (*сжимает*). . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Не надо . . это щекотно . . ");
            AddCadre(); Text.Show($". . . . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . И вот так . . я продолжала играть в его игру . . ]");            
        }
        private void Chapter18()
        {
            AddChapter("Chapter 18", "Chapter 18 -");

            AddCadre(); Text.Show($". . . . ");
            AddCadre(); Text.Show($". . . . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Сначала . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я думала, это просто игра . . ]");

            Sound.CurrentBGM = BGM["In the Barn"];
            Girl.CurrentEvent = Events["9"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . когда тебя щекотят . . . в темноте . . ]"); Girl.SmartShowEvent(); Sound.Bgm();
            AddCadre(); Text.Show($". . . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Не успела я оглянуться . . Дошло до этого. . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . и вот мы уже лежим так некоторое время . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . . !"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . В конце концов, наступила тишина . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я не могу ничего вымолвить . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . хехе . . (*уффф*) . . (*уффф*) "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*сжимает*) . . "); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");

            Girl.CurrentEvent = Events["10"];

            AddCadre(); Text.Show($". . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Он . . делает так . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . специально . . да ? . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . его руки . . гладят мою грудь . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . и медленно сжимают ее . .]"); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["11"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . что мне делать . . остановить его ? . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*сжимает*) . . "); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");

            Girl.CurrentEvent = Events["9"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . н-н-г . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . {Girl.Titles[0]} . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . . "); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . это значит . . что он хочет трогать меня ? . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . . . "); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["11"];

            AddCadre(); Text.Show($". . . . "); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . в конце концов, он же мужчина . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . из всех девочек, почему - я ?. . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Но неужели он действительно хочет . . ]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[Я повредила ему ногу . . Поэтому, наверно я должна . . позволить ему немножко . .]"); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["9"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[Только чуть-чуть . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[Я закрываю глаза . .]"); Girl.SmartHideEvent();            
            AddCadre(); Text.Show($"[{Girl.Name}]~. . н-н-г . .");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*сжимает*) . . ");
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*тискает*) . . ");
            AddCadre(); Text.Show($". . . . ");

            Girl.CurrentEvent = Events["11"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[Стоп . . он не собирается останавливаться . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . (*уфф*) . . (*уфф*) . . они классные . . ");

            Girl.CurrentEvent = Events["9"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . напротив . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . он увеличивает усилия . . сжимает мою грудь сильней . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. .  . . !"); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["12"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . ?"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . я чувствую что-то в груди . . странное . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . что-то тянущее . . от кончиков грудей до ног . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . что это ? . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Bastard.Name}]~. .  . . !"); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . аа-х . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");

            Girl.CurrentEvent = Events["13"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . какое-то тревожащее чувство внизу . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . моя попа упирается в {Bastard.Name} . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~! . . хе - хе - хе . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");

            Girl.CurrentEvent = Events["12"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . может . . мне надо  . . остановить . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . как только я об этом подумала . .]"); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($". . (*шелест*) . . (*шелест*)"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . ? . .]"); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["13"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . подождите . . неужели он . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . хочет сунуть руку мне в блузку. . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . мое сердце даже подпрыгнуло. . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . ! ! ! . . .]"); Girl.SmartShowEvent();

            Place.Current = Locations["Сарай"];
            Sound.CurrentSE = Effects["Wear moving"];            
            SetGirlWear_Shchool_Dress_Cleavage();
            SetGirlExpression_Troubled();
            string Bastard_X = "-350";
            string Girl_X = "350";

            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Х-х . .М-м-м . . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null); Sound.BgmStop(); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Ошеломленная я вскочила на ноги. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Э, {Girl.Titles[0]}, что случилось ?"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Мне пора домой . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Эх . . Но ты ведь придешь еще, правда ? . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Ну пожалуйста! Обещаешь? . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Хих . . Не могу обещать, что приду . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"); Bastard.CombineFigure(Bastard_X, null);

            Sound.CurrentSE = Effects["Шаги в лесу 1"];

            AddCadre(); Text.Show($". . "); Place.SmartHide(); Girl.CombineFigureHide(Girl_X, null); Bastard.CombineFigureHide(Bastard_X, null); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Я выбежала, все еще потрясенная . . .]");

            Place.Current = Locations["Forest day"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Все это меня поразило . . я думала, мы просто играем, но. .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Он сказал, что он сам пойдет домой. . Поэтому, я не стала его ждать . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null);            
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Надо будет потом извиниться . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null);

            SetGirlExpression_Sorry();

            AddCadre(); Text.Show($". .  . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  Какое странное чувство . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null);
            AddCadre(); Place.SmartHide(); Girl.CombineFigureHide(Girl_X, null);


        }
            //================

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

            Girl.Template = template_figure;
            Bastard.Template = template_figure;
            GuyA.Template = template_figure;
            GuyB.Template = template_figure;
            Text.Template = template_text;
            Place.Template = template_location;


            CadreNum = CadreNum + 1;
            string cadre = CadreNum.ToString("D3");
            string protagonst = @"e:\!EPCATALOG\AVATAR\GOOD\0003.png";
            string background = @"e:\!EPCATALOG\LOCATION\BEDROOM\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -evening.png";
            string mainfigure = @"e:\!EPCATALOG\PERSONS\Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\01_BASE.png";
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            int ord = 0;
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

