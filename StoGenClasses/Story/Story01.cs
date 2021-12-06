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


        // Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //private void SetGirlExpression_AgitatedSmile()
        //{
        //Girl.SetVisibleExpression("Middle", "Smile wide", "Wide open stright");

        //}


        //Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //        private void Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1)
        //        { 
        //            Girl.SetVisibleExpression("Middle", "Open wide", "Up stright amused");
        //        }
        //Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //private void  Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //{
        //  Girl.SetVisibleExpression("Middle", "Open wide", "Up stright troubled");
        //}
        //Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //private void  Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1)
        //{
        //    Girl.SetVisibleExpression("Middle", "Open wide", "Up stright troubled");
        //}


        //Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);
        //private void Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1)
        //{
        //Girl.SetVisibleExpression("Middle", "Smile wide", "Closed");
        //}
        /*        private void SetGirlWear_Shchool_Dress()
                {
                    Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 1);
                    //Girl.SetVisibleView("Middle", "School Dress", null);
                }
        */
        /*   private void SetGirlWear_Shchool_Dress_Cleavage()
           {
               Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 2);
               Girl.SetVisibleView("Middle", "School Dress cleavage", null);
           }*/
        /* private void SetGirlWear_Sportwear_wet()
         {
             Girl.Body(DISTANCE.Middle, WEAR.Sportwear, EMO_EFFECT.Sweat, 1);
             Girl.SetVisibleView("Middle", "Sportwear wet", null);
         }*/
        /*        private void SetGirlWear_Sportwear()
                {
                    Girl.Body(DISTANCE.Middle, WEAR.Sportwear, EMO_EFFECT.None, 1);
                    Girl.SetVisibleView("Middle", "Sportwear", null);
                }*/





        protected override void GenerateScenario()
        {
            CreateData();
            AddHeader();

            GuyA.O = 75;
            GuyB.O = 75;
            Place.Description = "Location background";

            Chapter1("Chapter 1", "Chapter 1 - вступление, утром разбудить друга");
            Chapter2("Chapter 2", "Chapter 2 - бежим в школу");
            Chapter3("Chapter 3", "Chapter 3 - успели в школу");
            Chapter4("Chapter 4", "Chapter 4 - на тренировке в потной майке");
            Chapter5("Chapter 5", "Chapter 5 - Попытка скоротать грустный вечер с другом.");
            Chapter6("Chapter 6", "Chapter 6 - Утренний стояк и неловкость");
            Chapter7("Chapter 7", "Chapter 7 - Первая встреча с мерзавцем.", null);
            //Chapter8();
            //Chapter9();
            //Chapter10();
            //Chapter11();
            //Chapter12();
            //Chapter13();
            //Chapter14(); 
            Chapter15();
            Chapter16();
            Chapter17();
            Chapter18();
        }
        protected virtual void Chapter1(string chapter, string description = null)
        {
            AddChapter(chapter, description);

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


            AddCadre(); Girl.CombineFigure(); Text.Show(". . . Ох! Ну что еще? . . ."); Sound.Bgm(); Sound.SE();
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

        }
        protected void Chapter2(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            Place.Current = Locations["Street morning"];
            Sound.CurrentBGM = BGM["Good morning"];

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ну что, ты проснулся наконец . . ?"); Place.SmartShow(); Girl.CombineFigureHide(); Sound.BgmMuted(transform_sound_delay_1);
            AddCadre(); Text.Show($"Ой . . ."); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"Извини, я задумался . . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Да ладно, даже когда я с тобой? Соберись уже . . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[Бежать в школу со всех ног уже вошло в привычку.]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . Она могла бы уже давно быть в школе, но она не хочет меня бросать.]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . А я пользуюсь ее добротой . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Ну серьезно. . . Почему ты всегда убегаешь . . ?"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Может потому что ты всегда спишь?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Это напрягает тебя?"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Хмм, все равно, я бегу на занятия в свой клуб . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ладно, я могла бы иногда проводить больше времени с тобой, как мы иногда делаем . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . Такие дни просто класс . . !]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Я могу тебя будить, как только сама встаю. . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . Вот всегда она так . . !]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . Я боюсь за наши отношения  . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . ."); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[. . . Из-за того, что она слишком наивная и немного нерешительная  . . ]"); Place.SmartShow(); Girl.CombineFigureHide();

            AddCadre(); Text.Show($"[. . . . . ]"); Place.SmartShow();
            AddCadre(); Text.Show($"[. . . Ха? ]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[. . . Погоди . . . {Girl.Name} . . . ты слишком быстро бежишь . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[. . . Она капитан команды болельщиц. . .]"); Place.SmartHide();
            AddCadre(); Text.Show($"[. . . Запыхавшись, я все-таки догнал ее. . .]");

        }
        protected void Chapter3(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            Place.Current = Locations["Class day"];
            Sound.CurrentBGM = BGM["After School"];

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ух, еле успели . . !"); Place.SmartShow(); Girl.CombineFigure(); Sound.BgmMuted(transform_sound_delay_1);
            AddCadre(); Text.Show($". . .  . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . уф . . уф . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Ох. . . как-то . . справились . . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Отлично, тогда пока, увидимся позже . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . Пока . . !"); Place.SmartShow(); Girl.CombineFigureHide();
            //stop musik
            AddCadre(); Text.Show($"[ Фу . . Делать это каждый раз тяжеловато. Она слишком шустрая, а я не привык к этому ]"); Place.SmartShow(); Sound.BgmStop();
            AddCadre(); Text.Show($"[ Она как парень . . . или как приятель . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . Может она и не догадывается, но она очень популярна среди парней . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . Хотя еще никто не подкатывал к ней, потому что я всегда ее сопровождаю . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . (Хоть это мне и не особо помогает) . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . (Или скорей это как-то странно, потому что я сам не знаю что делать) . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[Учитель]~ . . . Хорошо, начнем урок . . ."); Place.SmartShow();
            AddCadre(); Text.Show($" . . . . . ."); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . (Как обычно, я думаю только об этом) . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . И слишком мало думаю об экзамене . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[ . . . И слишком много - об романтике, что делает меня неуверенным . . .]"); Place.SmartHide();
        }
        protected void Chapter4(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            //Figure
            Girl.Body(DISTANCE.Middle, WEAR.Sportwear, EMO_EFFECT.Sweat, 1);
            //Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            Place.Current = Locations["Schoolyard day"];
            Sound.CurrentBGM = BGM["ogg00054"];

            AddCadre(); Text.Show($". . . Ах да . . "); Place.SmartShow(); Sound.BgmMuted(transform_sound_delay_1);
            AddCadre(); Text.Show($". . . {Girl.Name} сегодня на тренировке команды болельщиц . . "); Place.SmartShow();
            AddCadre(); Text.Show($"[Я рассеяно смотрю на школьный двор . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[{Girl.Name}]~Ой . . . наконец я тебя нашла ! ! !"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ну, как дела ?"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . Если честно, просто сопровождать ее домой, для меня уже счастье . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . И я чувствую, как сильно бьется мое сердце . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Я вижу тебя за милю . . !"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($". . . Погоди . . !"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . И я могу видеть ее лифчик. . . и ее грудь . . ]"); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ты в порядке . . ?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . ммммм . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Ой. . . ладно, ничего . . "); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[. . . смотрю на небо, как идиот . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . Облака . . "); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Ты в порядке . . ?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~Слушай, [{Hero.Name}], иногда ты очень странный . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~Когда я тебя вижу, то невольно хочу подойти . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[Капитан команды]~Ей, {Girl.Name} ! . . А кто сказал, что тренировка закончена . . ?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($" . . . "); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Упс . . нет, я не закончила тренировку . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~Капитан следит за мной все время . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . Все нормально . . ?"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"Неожиданно для себя, я наклоняюсь к ней . . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}] . . . Хмм . . Думаю, он всего лишь слишком строгий . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . ."); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"Когда дело касается романтических чувств, она очень наивная . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Она не думает о том, что эти парни смотрят на нее как на потенциальную партнершу для любви . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Просто потому, что никто не подходит к ней . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"Хотя она нак привлекательна . . . больше чем они могут себе представить . . ."); Place.SmartShow(); Girl.CombineFigure();

            //Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}] . . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}] . . . Увидимся . . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($" . . . "); Place.SmartShow(); Girl.CombineFigureHide();
            AddCadre(); Text.Show($" . . . Она собирается продолжить тренировку, в ТАКОМ виде . . ."); Place.SmartShow();
            AddCadre(); Text.Show($" . . . Уверен, все парни будут пялиться на нее . . ."); Place.SmartShow();
            AddCadre(); Text.Show($" . . . . . ."); Place.SmartShow();
            AddCadre(); Text.Show($" . . .  Как не смотри, а она очень женственна . . ."); Place.SmartShow();
            AddCadre(); Place.SmartHide();
        }
        protected void Chapter5(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            //Figure
            Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 1);
            //Expression
            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;


            Place.Current = Locations["Street evening"];

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . ");
            AddCadre(); Text.Show($"[{Girl.Name}]~[ уф, тренировка закончена. . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . я иду домой одна. . . ]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . во время тренировки. . . я просто бегаю и не могу ни о чем другом думать . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . и это мне не нравится . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . я приду домой, но там никого нет. . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . и даже если кто-то будет дома, это мне не поможет никак. . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]"); Place.SmartShow(); Girl.CombineFigure();

            Place.Current = Locations["House evening"];

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Как я и предполагала - дома никого нет. .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Когда моих родителей нет дома, я чувствую облегчение. .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  ведь тогда мне не нужно бороться с чувством неловкости . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  но в то же время, когда их нет - мне одиноко . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  и так было всегда . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. .  . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Но я так и не привыкла быть одной  . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Было время когда я проводила время на улице  . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[(*вздыхает*) здесь мне нечего делать . . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Когда это становится невыносимым, я опять делаю это . .]"); Place.SmartShow(); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . ладно тогда . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]"); Place.SmartShow(); Girl.CombineFigure();

            //effect
            Sound.CurrentSE = Effects["Door ring"];

            AddCadre(); Text.Show($". . *звонок* . ."); Sound.SE();
            AddCadre(); Text.Show($". . . .");

            Place.Current = Locations["Hero room evening"];
            AddCadre(); Text.Show($". . Хи-я-я-я !. ."); Place.SmartShow();

            Sound.CurrentBGM = BGM["Good morning"];
            // Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Hero.Name}]~[. . О-о-о. .]"); Place.SmartShow(); Girl.CombineFigure(); Sound.BgmMuted(transform_sound_delay_1);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Хих . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . {Hero.Name},ты устал верно? Давай поедим снеков  . . !]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Извини . . . я только поужинал  . . ]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Подожди . . . а кто тебя впустил  . . ?]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . М-м . . . твоя . . мама  . . ]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Ух  . .  почему я не могу побыть один . . .]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Он иногда говорит такое  . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Но мой друг . . будет со мной . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Наверно я злоупотребляю его терпением . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show("[{Hero.Name}]~. . Итак  . .  что ты там говорила про снеки . . ?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Ну вот видите . . !]"); Place.SmartShow(); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Их полно в магазине, так что . . давай их возьмем . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я их уже принесла . . !]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Серьезно  . .  ты только снеки купила . . ?]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Да мне все равно . . !]"); Place.SmartShow(); Girl.CombineFigure();

            // Expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Хих . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . . "); Place.SmartHide(); Girl.CombineFigureHide(); Sound.BgmStop();
        }
        protected void Chapter6(string chapter, string description = null)
        {
            AddChapter(chapter, description);

            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Получается, я все время создаю ему проблемы . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Я знаю, что мне нужно изменить это . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . И мне от этого грустно . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . [{Hero.Name}], мне очень жаль . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . я бы хотела, чтобы все продолжалось так, как сейчас. .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . и чтобы ничего не менялось . .]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . я знаю, что надо относиться к ней . .]");
            AddCadre(); Text.Show($"[? ? ?]~. . Эй . .");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . не как к другу . .]");
            AddCadre(); Text.Show($"[? ? ?]~. . Проснись . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . а как к той, кого я люблю . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . да проснись уже . . !");


            Girl.CurrentEvent = Events["1"];
            Sound.CurrentBGM = BGM["Good morning"];
            Sound.CurrentSE = Effects["Wear moving"];

            AddCadre(); Text.Show(". . . Вау . . ."); Girl.SmartShowEvent(); Sound.Bgm(); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . Опять? Тебе самому не надоело . . ?"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . уф . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Girl.Name}]~(*вздох*). . . Я устала от этого уже . . ?"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . живот . . болит . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . стоп, во первых, я не мог заснуть, потому что слишком много вчера сьел . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . так что это ЕЕ вина . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . и я наконец сегодня посплю . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . накрываюсь одеялом с головой . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Эй ! Кончай прятаться и вылезай из под одеяла . . !"); Girl.SmartHideEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . Говори что хочешь - мне все равно, даже если опоздаю в школу . .]");
            AddCadre(); Text.Show($"[{Girl.Name}]~(*вздыхает*). . Ну хорошо - вижу, что это не поможет . .");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . .");
            AddCadre(); Text.Show($"[{Hero.Name}]~. ."); Sound.BgmStop();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . ?");
            AddCadre(); Text.Show($"[{Hero.Name}]~тишина. .");

            Girl.CurrentEvent = Events["2"];

            AddCadre(); Text.Show($"[{Girl.Name}]~(*посапывает*)"); Girl.SmartShowEvent(); Sound.Bgm();
            AddCadre(); Text.Show(". . . . . .");
            AddCadre(); Text.Show($"[{Hero.Name}]~так ты тоже спишь . ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Girl.Name}]~(*посапывает*)"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~у нее должно быть много дел. ."); Girl.SmartShowEvent($"{Trans.ImpactHs(200, 50)}");
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . я чувствую что-то мягкое . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show(". . . . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . вместе с моим другом детства . . то есть с девушкой которую я люблю . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . может это . . опасно . . ?]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($". . *жим* . . *жим* . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . ого . . неважно, что об этом думать, но это не выглядит как дружба . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . от ее тепла . . я стал представлять, как она лежит подо мной . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . на что это похоже . .]"); Girl.SmartShowEvent();
            AddCadre(); Text.Show(". . . . . ."); Girl.SmartShowEvent();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . ух . . становится жарко . .]"); Girl.SmartShowEvent();

            Girl.CurrentEvent = Events["1"];

            AddCadre(); Text.Show($"[{Girl.Name}]~Ох . . . Я заснула . . ."); Girl.SmartShowEvent(); //Sound.Bgm();
            AddCadre(); Text.Show($"[{Girl.Name}]~[ . . черт . .]"); Girl.SmartShowEvent();

            Place.Current = Locations["Hero room morning"];

            AddCadre(); Text.Show($". . {Girl.Name} быстро встала . ."); Girl.SmartShowEvent();

            // expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . А а а а . ."); Place.SmartShow(); Girl.SmartHideEvent(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Что ты тут делал . . ? !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . я . . ничего . . ? !"); Place.SmartShow(); Girl.CombineFigure();

            // expression
            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Не знаю что происходит, но это многое упрощает . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . Давай, проснись и пой . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . . !"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . если я что-то не сделаю. . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . если она увидит мой стояк, она будет смеяться надо мной до конца жизни. . !]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~ . . сейчас, подожди . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . она силой забрала одеяло у меня . . ]"); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . нет . . ]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~ . . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~[ . . она не заметила . . ?]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . . "); Place.SmartShow(); Girl.CombineFigure();

            // expression
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Hero.Name}]~. . а . ?"); Place.SmartShow(); Girl.CombineFigure();

            // expression
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . ну давай, пошли уже. ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . понял . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($". . . ."); Place.SmartHide(); Girl.CombineFigureHide();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . она . . не сказала ни слова . . ]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . но я уверен, что она видела . . ]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . . . ?]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . стоп, а она вообще думает об ЭТИХ вещах. . ?]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . например, представляя как она обнимает другого человека . . ]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . . . ]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . как она склоняется к незнакомцу . . ]");
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . я чувствую ревность . . ]");
        }
        protected void Chapter7(string chapter, string description, string girlXshift)
        {
            AddChapter(chapter, description);

            Sound.CurrentBGM = BGM["Good morning"];
            Place.Current = Locations["Street morning"];
            // expression
            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;

            AddCadre(); Text.Show(". . . . . ."); Place.SmartShow(); Girl.CombineFigure(); Sound.BgmMuted(transform_sound_delay_1);
            AddCadre(); Text.Show("[. . . это немного странно. . .]"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show("[. . . похоже мы оба не знаем что сказать . . .]"); Place.SmartShow(); Girl.CombineFigure();

            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;

            AddCadre(); Text.Show($"[{Girl.Name}]~. . . ну ладно . . я пойду . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . да . . ? . . ну . . ладно . . ."); Place.SmartShow(); Girl.CombineFigureHide();
            AddCadre(); Text.Show($"[{Hero.Name}]~[. . . убежала . . .]"); Place.SmartShow();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . я ее уже еле вижу, бастрая как метеор . . ."); Place.SmartShow();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . хм . . ? кажется, я кого-то вижу . . ."); Place.SmartShow();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . хм . . ?"); Place.SmartShow(); Sound.BgmStop();

            Bastard.SetVisibleView("Middle", "Default", "Default");

            AddCadre(); Text.Show($"[{Hero.Name}]~. . . берегись . . !"); Place.SmartShow(); Bastard.CombineFigure();

            Sound.CurrentSE = Effects["Бум"];

            AddCadre(); Text.Show($" . . Ааааааа . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift,null, $"O.B.500.100>{Trans.ImpactHs(200, 50)}"); Bastard.CombineFigure($"{Trans.Wait(500)}>{Trans.ImpactHs(200, 50)}"); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~ . . Ой, чуть не убились . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();

            Sound.CurrentSE = Effects["Вжик"];

            AddCadre(); Text.Show($" . . *Сжал* . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"); Sound.SE();

            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~ . . ! ! ! . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();

            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;

            AddCadre(); Text.Show($"[{Girl.Name}]~ . . прости ! ! ! . . прости ! ! ! . . . с тобой все в порядке . . ! ! ! ?"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . э-э-э . . Да, вроде . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~ . . я дико извиняюсь . . у тебя ничего не болит . . .?"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . вроде нет . . ."); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~ . . ты уверен . . . ?"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();

            Sound.CurrentSE = Effects["Вжик"];

            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . *Сжал* . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null, $"{Trans.ImpactHs(200, 30)}"); Bastard.CombineFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"); Sound.SE();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . еще немного, здесь. . *трогает*"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~ . . вот тут ? . . больно . . .?"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null, $"{Trans.MoveHs(50, -20)}"); Bastard.CombineFigure(); Sound.SE();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . все нормально. . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();

            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~ . . слава богу . . .!"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure($"{Trans.MoveHs(10, 50)}");

            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . *сжал*"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null, $"{Trans.ImpactHs(200, 30)}"); Bastard.CombineFigure($"{Trans.MoveHs(200, 10)}>{Trans.MoveHs(200, -10)}"); Sound.SE();
            AddCadre(); Text.Show($"[{Girl.Name}]~ . . еще раз извини, что налетела на тебя . . .!"); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . хе хе . . "); Place.SmartShow(); Girl.CombineFigure(girlXshift, null); Bastard.CombineFigure();
            AddCadre(); Text.Show($" . . "); Place.SmartHide(); Girl.CombineFigureHide(girlXshift, null); Bastard.CombineFigureHide();

            Sound.CurrentSE = Effects["Бег мальчик"];

            AddCadre(); Text.Show($"[{Hero.Name}]~ . . {Girl.Name}, ты в порядке . . ?"); Sound.SE();

            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . о , {Hero.Name}. . да . . все в порядке . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . я плохо видел, что сдесь произошло . . ?"); Place.SmartShow(); Girl.CombineFigure();

            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . тут был вот этот {Bastard.Titles[0]}, и. . "); Place.SmartShow(); Girl.CombineFigure();

            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;

            AddCadre(); Text.Show($"[{Girl.Name}]~. . ой, он только что был здесь . . ушел . . ."); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . ? ты все еще спишь . . .?"); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Girl.Name}]~. . он определенно был еще недавно здесь . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . тебе надо смотреть внимательно, куда бежишь . . ."); Place.SmartShow(); Girl.CombineFigure();

            Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . ха ха . . это точно . . "); Place.SmartShow(); Girl.CombineFigure();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . похоже ты не пострадала, так что пошли . . ."); Place.SmartShow(); Girl.CombineFigure();

            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~. . да, пошли . . "); Place.SmartShow(); Girl.CombineFigure();

            Sound.CurrentSE = Effects["Бег мальчик"];

            AddCadre(); Text.Show($". . . . "); Place.SmartShow(); Girl.CombineFigureHide(); Sound.SE();
            AddCadre(); Text.Show($". . . . "); Place.SmartHide();
            AddCadre(); Text.Show($"[{Hero.Name}]~. . В итоге мы так и не выяснили ничего . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . Наверно мне повезло просто . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . С {Girl.Name} все эти штуки насчет секса . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . Мы никогда не говорили об этом с ней. Для того чтобы не повредить нашим отношениям . . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . Думаю, у нас есть негласное правило . . . ");
            AddCadre(); Text.Show($"[{Hero.Name}]~. . . *вздох* . . . ");
            AddCadre(); Text.Show($". . . . ");Place.SmartShow(); Bastard.CombineFigure();
            AddCadre(); Text.Show($". . . . "); Place.SmartHide(); Bastard.CombineFigureHide();

        }
        /*
                    private void Chapter8()
                    {
                        AddChapter("Chapter 8", "Chapter 8 - Обсуждение сисек парнями");

                        Place.Current = Locations["School hall day"];

                        AddCadre(); OldAddCadre(
                            Place.SmartShowHidden(transform_Appearing_3),
                            Text.Show($"[{Hero.Name}]~. . . уроки закончились . . . ")
                            );

                        Sound.CurrentBGM = BGM["After School"];

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. . . я все время был занят своими мыслями, и время пробежала незаметно . . . "),
                            Sound.oldBgm()
                            );

                        //Figure
                        Girl.Body(DISTANCE.Middle, WEAR.Sportwear, EMO_EFFECT.None, 1);
                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(
                            Girl.oldFigureHidden(transform_Appearing_3),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. . . Ох . . {Hero.Name} ! ! ! ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. . . ? ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. .  Ого !  Ты уже переоделась ? ? ")
                            );

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  Хих . У нас сейчас игра . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. . . Переодеваться было непросто . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. .  . я был очарован ею . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. .  . она выглядела потрясающе. . ]")
                            );

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . раз у меня игра, ты идешь домой один. . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. .  . о, мне надо тоже кое что тут еще сделать, так что я буду в школе еще час . . ")
                            );

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . но за час я точно не успею . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. .  . ничего, я подожду . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . на самом деле может быть я задержусь и после игры . . ")
                            );

                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . у новичков проблемы с формой . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . и я обещала помочь им. так что ты наверно можешь . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . не ждать меня . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. .  . о , ну хорошо . . ")
                            );

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . Но в любом случае - спасибо . . ")
                            );

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        Sound.CurrentSE = Effects["Бег девочка"];

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(transform_Disapearing_3),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . Увидимся . . !"),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(                
                            Place.SmartShow(),
                            Text.Show($". . . . . ")
                            );

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(
                            Girl.oldFigureHidden(transform_Appearing_3),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . Ах да, завтра у нас тренировка с утра, так что я не приду тебя будить . . !")              
                            );

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. .  . Пожалуйста, не проспи . . !")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(transform_Disapearing_3),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. .  . Исчезла как молния . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($". . . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($". . (*шепот*) . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . хм ? . . ]"),
                            Sound.oldBgmStop()
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . хм ? . . ]"),
                            Sound.oldBgmStop()
                            );

                        GuyA.SetVisibleView("Middle", "Guy 01", null);
                        GuyB.SetVisibleView("Middle", "Guy 02", null);

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigureHidden(transform_Appearing_6),
                            GuyB.oldFigureHidden(transform_Appearing_7),
                            Place.SmartShow(),
                            Text.Show($"[Парень А]~[. . Черт . . Видел, какие сиськи? Прикольно они у ней трясутся . . .]")              
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Парень Б]~[. . Да уж . . У нее они всегда так трясуться . . .]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Парень А]~[. . Как бы я хотел подойти к ней сзади и тискать их . . !]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Парень Б]~[. . Трахать ее между таких сисек . . Это наверно кайф !]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Парень А]~[. . Хехе. Я знаю, девчонки с такими сиськами любят, когда их тискают . . !]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($". . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. .  . Вот черт . . я так и думал . . .]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[ .  . Куча парней смотрят на нее такими же глазами . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[ А ее это совсем не волнует . . Я тревожусь за нее . .]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(),
                            GuyB.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[ Я вспомнил ее беззаботную улыбку . . И моя тревога только возросла . .]")
                            );

                        AddCadre(); OldAddCadre(
                            GuyA.oldFigure(transform_Disapearing_3),
                            GuyB.oldFigure(transform_Disapearing_3),
                            Place.SmartShow(transform_Disapearing_3),
                            Text.Show($"[ . . . .]")
                            );


                    }
                    private void Chapter9()
                    {
                        AddChapter("Chapter 9", "Chapter 9 - Вторая встреча с мерзавцем.");

                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . . я опять это сделала . . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . . я жестоко поступила с {Hero.Name} вчера . . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . . пока я думала об этом . . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . . то не заметила небольшую тень. . . ]"));

                        Girl.CurrentEvent = Events["3"];
                        Sound.CurrentBGM = BGM["Runned into it"];
                        Sound.CurrentSE = Effects["Бум"];



                        AddCadre(); OldAddCadre(
                            Girl.oldEventHidden(transform_Appearing_3),
                            Text.Show(". . . . . . ! !"),
                            Sound.BgmMuted(transform_sound_delay_1),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . ох . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . я . . врезалась в кого-то . . ?")
                            );

                        Sound.CurrentSE = Effects["Вжик"];

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show(". . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . этот {Bastard.Titles[0]} . . . который был вчера . . ?")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . не могу поверить, что я врезалась в него снова . . !")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . нужно встать . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . ох . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . я пытаюсь двинуться . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . это сложно, потому что он лежит на мне . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . он . . тяжелее, чем кажется . .")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . . . .")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . . уффф. .ухххх . . .")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . . он обнимает меня, и очень крепко . . .")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . . . .")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . я не должна думать об этом . . .")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . но когда кто-от ТАК вжимается в тебя . . .")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . хочется типа . . . защитить его . . ?")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . не знаю точно, что это . . . но такое часто бывает со мной . . ?")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . . . ?")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . *Сжал* . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . . уффф. .ухххх . . .")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . . . ?")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . с ним все в порядке ? . . он не ударился ? . . ")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(),
                             Text.Show($"{Girl.Name}]~. . . нужно встать . . ")
                             );

                        Sound.CurrentSE = Effects["Wear moving"];

                        AddCadre(); OldAddCadre(
                             Girl.oldEvent(transform_Disapearing_2),
                             Text.Show($". . . ну вот, готово . . "),
                             Sound.oldSE()
                             );

                        AddCadre(); OldAddCadre(Text.Show($". . . я обхватила его руками, ка будто обнимая, и встала вместе с ним . . "));

                        Place.Current = Locations["Street morning"];
                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(
                             Girl.oldFigureHidden(transform_Appearing_8),
                             Bastard.oldFigureHidden(transform_Appearing_5),
                             Place.SmartShowHidden(transform_Appearing_4),
                             Text.Show($"{Girl.Name}]~. . . прошу прощения, я не смотрела куда иду . . ")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . да, это тот же самый вчерашний {Bastard.Titles[0]} . . ]")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . и на этот раз я налетела на него очень сильно . . ]")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . я такая дура . . ]")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . с тобой все хорошо ? . . ]")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . ох . . ")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . ты сильно ударился ? . . может быть, поранился ? . .]")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . наверно нет . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure($"{Trans.ImpactHs(200, 50)}>{Trans.ImpactHs(200, 50)}>{Trans.ImpactHs(200, 50)}"),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . охх . . "),
                            Sound.oldBgmStop()
                            );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~[. . . и тут вдруг он скривился от боли . .]")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~. . . что с тобой . . ?")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . кажется, я подвернул ногу . . ")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~. . . о нет . . что же делать .. надо вызвать скорую . . .")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . да все нормально . . я только немного ее подвернул . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . я живу рядом . . я дойду . . ")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~. . . ты уверен, что сможешь . . ?")
                             );

                        AddCadre(); OldAddCadre(
                            Girl.CombineFigure(),
                            Bastard.oldFigure(),
                            Place.SmartShow(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . да, просто чуть-чуть больно идти . . ")
                            );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"),
                             Bastard.oldFigure(),
                             Place.SmartShow(),
                             Text.Show($"{Girl.Name}]~. . . ты не сможешь . . !")
                             );

                        AddCadre(); OldAddCadre(
                             Girl.CombineFigure(transform_Disapearing_2),
                             Bastard.oldFigure(transform_Disapearing_2),
                             Place.SmartShow(transform_Disapearing_2),
                             Text.Show($" . . ")
                             );

                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . как дошло до этого . . ?]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . я не хочу быть одна . . и с родителями тоже не хочу . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . я всем приношу проблемы и неприятности . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . даже {Hero.Name} . .  всегда прихожу без приглашения . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . когда нибудь, он решит, что я надоедливая . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . . . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . это произошло со мной, потому что я неосторожная. . ]"));
                        AddCadre(); OldAddCadre(Text.Show($"{Girl.Name}]~[. . надо быть более ответственной. . ]"));

                        Sound.CurrentSE = Effects["Wear moving"];

                        AddCadre(); OldAddCadre(
                            Sound.oldSE(),
                            Text.Show($". . . .")
                            );

                        Girl.CurrentEvent = Events["4"];

                        AddCadre(); OldAddCadre(
                            Girl.oldEventHidden(transform_Appearing_3),
                            Sound.oldBgm(),
                            Text.Show($"{Girl.Name}]~. . Ладненько . . Все хорошо ? . . Хорошо ухватился ? ")
                            );

                        Sound.CurrentSE = Effects["Вжик"];

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~ . . хе хе . . ага . . *Сжал* . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . Нгх . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . это . . не там немного . .]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . он схватился . . ?]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . больно . . ?")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . нет . . хе хе . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . как сильно он схатился за меня . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . я чувствую его дыхание на своей шее . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . это щекотно . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . не помню, когда меня так сильно обнимали . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~[. . мне от этого . . жарко . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . да, я забыла спросить как тебя зовут . .  ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"[Незнакомый {Bastard.Titles[0]}]~. . {Bastard.Name} . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . очень приятно, {Bastard.Name} ,  я {Girl.Name} . .  ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"[{Bastard.Name}]~. . Могу я звать тебя '{Girl.Titles[0]}' . . ?")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . хи-хих . . это немного смущает . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . но . . я не против . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(),
                            Text.Show($"{Girl.Name}]~. . Ну тогда, {Girl.Titles[0]} доставит тебя домой, так что направляй . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent($"{Trans.Wait(300)}>{Trans.ImpactHs(200, 50)}"),
                            Text.Show($"[{Bastard.Name}]~ . . хе хе . . "),
                            Sound.oldSE()
                            );

                        AddCadre(); OldAddCadre(
                            Girl.oldEvent(transform_Disapearing_2),
                            Text.Show($". . . . ")                
                            );
                    }
                    private void Chapter10()
                    {
                        AddChapter("Chapter 10", "Chapter 10 - она не пришла в школу");

                        AddCadre(); OldAddCadre(Text.Show($". . . . . . "));

                        Place.Current = Locations["Hero room morning"];
                        Sound.CurrentBGM = BGM["Good morning"];

                        AddCadre(); OldAddCadre(
                            Place.SmartShowHidden(transform_Appearing_3),
                            Text.Show($"[{Hero.Name}]~. . . . . . "),
                            Sound.BgmMuted(transform_sound_delay_1)
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~. . . Это чувство покоя . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . Я точно опоздаю в школу . . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(transform_Disapearing_2),
                            Text.Show($"[{Hero.Name}]~[. . . Стоп. Она сказала что у ней с утра тренировка . . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Text.Show($"[{Hero.Name}]~[. . . Может быть она и не выглядит очень уж заботливой, но она именно такая . . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Text.Show($"[{Hero.Name}]~[. . . Можно даже сказать - по матерински заботливая . . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Text.Show($"[{Hero.Name}]~[. . . Мне нужно перестать злоупотреблять ее добротой . . . ]")
                            );

                        Place.Current = Locations["Schoolyard morning"];

                        AddCadre(); OldAddCadre(
                            Place.SmartShowHidden(transform_Appearing_3),
                            Text.Show($". . . . . . ")
                            );

                        Place.Current = Locations["Class day"];

                        AddCadre(); OldAddCadre(
                            Place.SmartShowHidden(transform_Appearing_3),
                            Text.Show($". . . . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . я тихонько проскользнул в класс . . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . ну хорошо . . а где {Girl.Name} . . ? ]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . . . ]"),
                            Sound.oldBgmStop()
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . Стоп. Ее нет . . ?]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . Тренировка уже закончилась, она должна быть здесь . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . Она никогда не опаздывала раньше . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . Что же заставило ЕЕ не придти вовремя. . ?]")
                            );

                        AddCadre(); OldAddCadre(
                            Place.SmartShow(),
                            Text.Show($"[{Hero.Name}]~[. . . ]")
                            );

                        AddCadre(); OldAddCadre(Place.SmartShow(transform_Disapearing_2));
                    }
                    private void Chapter11()
                    {
                        AddChapter("Chapter 11", "Chapter 11 - сарай в лесу");

                        Sound.CurrentSE = Effects["Шаги в лесу 1"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . мне надо все обдумать . . . "), Sound.oldSE(1));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . все равно я опоздала в школу . . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . и даже никого не предупредила . . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . да и никого дома нет все равно . . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . и это к лучшему . . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . мои родители редко бывают дома, так уж сложилось . . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . наш дом вообще не выглядит жилым. . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . и мне в нем неуютно. . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . . . "));            
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . Эй! Это уже настоящий лес. Ты уверен что мы идем правильно  . . ?"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~. . . хе-хе . . Мы почти пришли  . . "));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~. . . . . ?"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~. . . Все, мы на месте  . . "), Sound.oldSEStop());

                        Place.Current = Locations["Forest day"];
                        Sound.CurrentBGM = BGM["Runned into it"];

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);
                        Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 1);
                        string Bastard_X = "-350";
                        string Girl_X = "350";

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigureHidden(Bastard_X, null, transform_Appearing_3),
                            Girl.oldFigureHidden(Girl_X, null, transform_Appearing_3),
                            Place.SmartShowHidden(transform_Appearing_3),
                            Text.Show($"[{Girl.Name}]~. . . На месте ? . . . "),
                            Sound.oldBgm()
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($". . . . . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Среди деревьев, старый сарай . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Я кажется, видела такие на стройке . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Стены грязные, и заросли травой . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Его можно найти только если подойти близко . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Если честно, он слишком грязный . . ]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. . Ммм . . Это же не твой дом, правда? . . ")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Bastard.Name}]~. . Конечно нет !. . Это моя секретная база ! ")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. . Секретная база ? ? ! !")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Я хотела отвести его домой и извиниться перед его родителями . . .]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . А это совсем не то . . .]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~[. . Слушай, может нам лучше пойти к твоему дому . . . ?]")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Bastard.Name}]~. . Да кому это нужно ! "),
                            Sound.oldBgmStop()
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 50)}"),
                            Girl.CombineFigure(Girl_X, null),
                            Place.SmartShow(),
                            Text.Show($"[{Bastard.Name}]~. . Давай зайдем внутрь ! ")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null),
                            Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"),
                            Place.SmartShow(),
                            Text.Show($"[{Girl.Name}]~. . Эй, не тащи меня !")
                            );

                        AddCadre(); OldAddCadre(
                            Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2),
                            Girl.CombineFigure(Girl_X, null, transform_Disapearing_2),
                            Place.SmartShow(transform_Disapearing_2),
                            Text.Show($". . ")
                            );

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . Наверно мне не надо об этом спрашивать . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . Он играет один в таком месте . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . На это должна быть причина . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . На это должна быть причина . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . И я дала ему повести себя внутрь. .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . .]"));
                    }
                    private void Chapter12()
                    {
                        AddChapter("Chapter 12", "Chapter 12 - Бинтование ноги мерзавцу");

                        Place.Current = Locations["Сарай"];

                        AddCadre(); OldAddCadre(Text.Show($". . . . . . "), Place.SmartShowHidden(transform_Appearing_3));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Внутри сарая темновато, но прикольно . . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . На стенах пластиковые панели. Наверно прикрывают дыры в стенах . . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Есть так же что то вроде матраса и полки. . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Наверно он нашел это. Или принес из дома. . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Видимо он много стараний приложил здесь. . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Все это похоже на секретную базу, где {Hero.Name} и я в детстве играли. . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[. . . Хих. Это прикольно . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~[. . . Хе - хе . . Это место глубоко в лесу . . Так что никто не придет сюда ! ]"), Place.SmartShow(transform_Disapearing_2));
                        AddCadre(); OldAddCadre(Text.Show($"[. . . . . ]"));

                        Girl.CurrentEvent = Events["5"];
                        Sound.CurrentBGM = BGM["Runned into it"];

                        AddCadre(); OldAddCadre(Text.Show($"[. . . . . ]"), Girl.oldEventHidden(transform_Appearing_3), Sound.oldBgm());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Я посадила {Bastard.Name}  на матрас и стала бинтовать его лодыжку . . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Я всегда беру бинт с собой когда иду на тренировку . . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Хорошо что я взяла его.  Никогда не знаешь где пригодится. . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . Эта нога, верно . . ?"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ . (*сглотнул слюну*). "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~М-м-м {Girl.Titles[0]}. . ты хорошенькая, правда. . "), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));

                        Girl.CurrentEvent = Events["6"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . О . . О чем ты говоришь . . ? "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ . Ты очень красива. Наверняка ты очень популярна . . верно ? "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . О . . я . . ? ]"), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));

                        Girl.CurrentEvent = Events["5"];

                        AddCadre(); OldAddCadre(Text.Show($" . . . . . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . Меня еще не называли хорошенькой . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . И {Hero.Name} не называл. ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($". . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Он наверно думает о моих чувствах. . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Это первый раз когда меня назвали хорошенькой. . . мне надо постараться получше . .]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Надо бинтовать лучше . .]"), Girl.oldEvent());

                        Girl.CurrentEvent = Events["6"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ Хих . . спасибо ! . . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~Ты смеешся ! . . Ты самая красивая девчонка из всех которых я видел!"), Girl.oldEvent($"{Trans.ImpactHs(200, 50)}"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . ахаха . . много ли ты видел девчонок . . ?]"), Girl.oldEvent());

                        Girl.CurrentEvent = Events["5"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ Ок. Поняла. Хватит. Мне. Льстить. ! ! "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Не то чтобы мне было неприятно . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Думаю он пытается просто быть вежливым, как умеет . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ На самом деле, мне это очень приятно . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Надо его тоже как то поблагодарить . ! ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . ."), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Неужели мне так легко польстить ?]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~Слушай {Girl.Titles[0]} . . Ты можешь приходить на эту секретную базу, когда захочешь!"), Girl.oldEvent());

                        Girl.CurrentEvent = Events["6"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ Поняла! Спасибо . . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ Он мне доверяет . .]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ *уххх*  *уффф*"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . я забинтовала твою ногу, но тебе надо пойти к врачу . ."), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ хорошо "), Girl.oldEvent());

                        Girl.CurrentEvent = Events["5"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ Нога не распухла , так что все будет хорошо. . "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ (*пялится*) "), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Bastard.Name}]~ . . хехе . .  "), Girl.oldEvent());

                        Girl.CurrentEvent = Events["6"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . ?"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~ . . что это было. . ?"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . я чувствую как на меня смотрят . . ]"), Girl.oldEvent());
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . . . ]"), Girl.oldEvent(transform_Disapearing_2));

                        Place.Current = Locations["Сарай"];
                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);
                        string Bastard_X = "-350";
                        string Girl_X = "350";

                        AddCadre(); OldAddCadre(Girl.oldFigureHidden(Girl_X, null, transform_Appearing_3), Bastard.oldFigureHidden(Bastard_X, null, transform_Appearing_3), Text.Show($"[{Girl.Name}]~ . Ну все, готово. Не туго ?"), Place.SmartShowHidden(transform_Appearing_3),Sound.oldBgmStop() );
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Bastard.oldFigure(), Text.Show($"[{Bastard.Name}]~ . Все норм . ."), Place.SmartShow());

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.Show($"[{Bastard.Name}]~ . Но {Girl.Titles[0]} должна идти в школу. ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.Show($"[{Bastard.Name}]~ . Ты придешь еше, правда . . ?"), Place.SmartShow());

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.Show($"[{Girl.Name}]~ . Не волнуйся, я зайду на обратном пути . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null,$"{Trans.ImpactHs(200, 50)}"), Text.Show($"[{Bastard.Name}]~ . О да ! ! !. . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.Show($"[{Bastard.Name}]~ . Только не говори НИКОМУ об этом месте, ладно ? . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(Girl_X, null), Bastard.oldFigure(Bastard_X, null), Text.Show($"[{Bastard.Name}]~ . О нем знаешь только ты, {Girl.Titles[0]} . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(transform_Disapearing_2), Bastard.oldFigure(Bastard_X, null, transform_Disapearing_2), Text.Show($". . . "), Place.SmartShow(transform_Disapearing_2));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . я переживала, но должна была идти в школу . . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . ух ты . . секрет . . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . только мой . . .]"));
                        AddCadre(); OldAddCadre(Text.Show($"[{Girl.Name}]~[ . . это прикольно . . .]"));

                    }
                    private void Chapter13()
                    {
                        AddChapter("Chapter 13", "Chapter 13 - Она опоздала в класс, с приоткрытой грудью");

                        Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 2);
                        Place.Current = Locations["Class day"];

                        AddCadre(); OldAddCadre(Text.Show($"[{Hero.Name}]~[. . Закончен второй урок . . ]"), Place.SmartShowHidden(transform_Appearing_3));
                        AddCadre(); OldAddCadre(Text.Show($"[{Hero.Name}]~[. . Она так и не связалась со мной . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Text.Show($"[{Hero.Name}]~[. . Серьезно . . Что случилось ? . . ]"), Place.SmartShow());

                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.Show($"[{Girl.Name}]~(*вздыхает*) . . Так я и думала . . Я сильно опоздала . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . Я почувствовал облегчение, как только увидел ее . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Я думал это ты мне скажешь, что я опаздываю . . "), Place.SmartShow());

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ах, {Hero.Name} ! . . Доброе утро . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Где ты была ? Я говорила, что у тебя игра . . "), Place.SmartShow());

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Дело в том . . у меня были проблемы . . "), Place.SmartShow());

                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . м-м-м-м . . э-э-э-э . . . "), Place.SmartShow());

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . хих . . . "), Place.SmartShow());

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Я . . . я проспала . . ! "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . Видя как странно ведет себя {Girl.Name}, я чувствую тревогу . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Кстати, что с твоей формой ? . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Хм . . ? "), Place.SmartShow());

                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ой . .  Пуговица оторвалась . . "), Place.SmartShow());

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ха ха . . наверно закатилась где-то . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Быстрей переодевайся . . "), Place.SmartShow());

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Да все нормально, я переоденусь перед тренировкой . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . это для МЕНЯ не нормально . . ]"), Place.SmartShow($"{Trans.ImpactHs(200, 50)}"));
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . хоть это эгоистично . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . но я не хочу чтобы другие парни смотрели на ее грудь . . ]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Пошли сядем на наши места . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(transform_Disapearing_2), Text.Show($"[{Hero.Name}]~. . Но я никогда не смогу сказать ей это . . "), Place.SmartShow(transform_Disapearing_2));
                        AddCadre(); OldAddCadre(Text.Show($"[{Hero.Name}]~. . Все что мне остается - смотреть на ее приоткрытую грудь . . "));
                        AddCadre(); OldAddCadre(Text.Show($". . "));

                    }
                    private void Chapter14()
                    {
                        AddChapter("Chapter 14", "Chapter 14 - размолвка с другом");

                        Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 2);
                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);
                        Place.Current = Locations["Раздевалка"];
                        Sound.CurrentBGM = BGM["After School"];

                        AddCadre(); OldAddCadre(Girl.oldFigureHidden(transform_Appearing_3), Text.Show($"[{Girl.Name}]~[. . хих хих хих . . ]"), Place.SmartShowHidden(transform_Appearing_3), Sound.oldBgm());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Ты какая-то слишком веселая для того, кто опоздал на уроки . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . После школы . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . я сопровождаю {Girl.Name} на ее тренировку . . "), Place.SmartShow());

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure($"{Trans.ImpactHs(200, 50)}"), Text.Show($"[{Girl.Name}]~. . А ? Ты говоришь про меня . . ?"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Ты весь урок как-то улыбалась про себя . . Это странно . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . закатное солнце освещало лицо {Girl.Name} . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . раньше я всегда любовался этим . ."), Place.SmartShow());

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ох . . Наверно это было написано на моем лице. . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . и слишком сильно . .]"), Place.SmartShow());

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ох . . Да просто это ерунда . . которая меня развеселила . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~[. . да ладно . . непривычно что ты так говоришь . .]"), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . подожди-ка . . ты отведала новые снеки ? . ."), Place.SmartShow());

                         Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);;

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Ты всегда думаешь обо мне так . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Помнишь те снеки которые ты мне приносила ? . . У меня в комнате еще лежит пачка . . "), Place.SmartShow());

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . О . . да . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Если появились новые, их не обязательно покупать, это расточительно . . "), Place.SmartShow($"{Trans.ImpactHs(200, 50)}"));

                        Girl.Face(EMO.Laughing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~. . Я не собираюсь скрывать свои карты, пока ты такой скряга . . "), Place.SmartShow($"{Trans.ImpactHs(200, 50)}"));
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Да ? . . "), Place.SmartShow());

                        Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~(*вздыхает*) Если это ты, {Hero.Name} . . Ты меня поймешь . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Чо ты хочешь сказать ? . . "), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~Ты правда не понимаешь . . ?"), Place.SmartShow(), Sound.oldBgmStop());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Hero.Name}]~. . Как я могу понять, когда ты ничего не говоришь ? . . "), Place.SmartShow($"{Trans.ImpactHs(200, 50)}"));

                        Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1); 

                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($"[{Girl.Name}]~Ахах . . хорошо . . мне надо идти . !"), Place.SmartShow($"{Trans.ImpactHs(200, 50)}"));
                        AddCadre(); OldAddCadre(Girl.CombineFigure(transform_Disapearing_2), Text.Show($"[{Hero.Name}]~. . Что ? . . Эй ! . ."), Place.SmartShow());
                        AddCadre(); OldAddCadre(Girl.CombineFigure(), Text.Show($". ."), Place.SmartShow(transform_Disapearing_2));

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

            Girl.CurrentEvent = Events["5"]; Sound.CurrentBGM = BGM["Runned into it"];

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
            Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 2);
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);
            string Bastard_X = "-350";
            string Girl_X = "350";

            AddCadre(); Text.Show($"[{Girl.Name}]~. . Хорошо . . Я все сделала на сегодня !"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Неожиданно я поняла, что наулице уже темно . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Вау. Просто ничего не видно. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Что ж. Его нога вроде в порядке. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[. . Он не собирается идти домой. Похоже мне надо идти домой. . .]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~. . Слушай, {Girl.Titles[0]} !"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);

            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Bastard.Name}]~Давай ляжем здесь и поболтаем немного . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Что ? . . Ну . . Уже слишком поздно . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Пожалуйста ! . . Мне одному грустно ! . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Уже было поздно . . Я подумала о его семье . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Но когда ты одинока, разумные доводы не работают . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Когда один в своей комнате . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~[ Как мне это знакомо . . ]"); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($". . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);

            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            AddCadre(); Text.Show($"[{Girl.Name}]~Я понимаю тебя . . "); Place.SmartShow($"{Trans.ImpactHs(200, 50)}"); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Girl.Name}]~Но уже темно, поэтому недолго, ладно ? . . "); Place.SmartShow(); Girl.CombineFigure(Girl_X, null, $"{Trans.ImpactHs(200, 50)}"); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Правда ? . . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null);
            AddCadre(); Text.Show($"[{Bastard.Name}]~Хе-хе . . {Girl.Titles[0]} . . . ложись сюда . ."); Place.SmartShow(); Girl.CombineFigure(Girl_X, null); Bastard.CombineFigure(Bastard_X, null, $"{Trans.ImpactHs(200, 50)}");

            Sound.CurrentSE = Effects["Wear moving"];
            Girl.Face(EMO.Accusing, EMO_STYLE.Any, EMO_EFFECT.None, 1);

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
            Girl.Body(DISTANCE.Middle, WEAR.Schoolware, EMO_EFFECT.None, 2);
            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1); ;
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

            Girl.Face(EMO.Troubled, EMO_STYLE.Any, EMO_EFFECT.None, 1);

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
    }

}

