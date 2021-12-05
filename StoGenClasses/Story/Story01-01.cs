using StoGen.Classes.Story.Persons;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class Story01_01 : Story01
    {
        public static string Name = "She Falls to a Perverted Bastard (variant 1)";


        public Story01_01() : base()
        {


        }

        private void CreateData()        
        {
            Girl = new Girl_0001(this, "Комаки");
            Girl.Titles.Add("сестренка");

            Bastard = new Perverted_Bastard(this, "Футоши");
            Bastard.Titles.Add("мальчик");

            Hero = new Person(this, "Кохеи");
            GuyA = new Siluette(this, "Парень А");
            GuyB = new Siluette(this, "Парень Б");




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

            // Creating events from figure

            Girl.SetVisibleView("Far", "School form 1", "Hear brown school");
            Girl.Face(EMO.Smile, EMO_STYLE.Any, EMO_EFFECT.None, 1);

            Events = new Dictionary<string, string>();                                    
            Events.Add("1", Girl.CombineEventByFigure("Event 001"));

            Girl.Face(EMO.Sleep, EMO_STYLE.Any, EMO_EFFECT.None, 1);
            Events.Add("2", Girl.CombineEventByFigure("Event 002"));

        }
        private void AddHeader()
        {
            AddChapter("0-Header");

            int size_frame_main = 1920; int x_frame_main = 0; int y_frame_main = 0; string template_frame_main = "0"; string transition_main = "W..1500>O.B.500.-100";            
            int size_figure = 1920; int x_figure = 0; int y_figure = 0; string template_figure = "8";
            string template_location = "300";
            string template_text = "1";
            
            


            Girl.Template = template_figure;
            Bastard.Template = template_figure;
            GuyA.Template = template_figure;
            GuyB.Template = template_figure;
            Text.Template = template_text;
            Place.Template = template_location;

            CadreNum = CadreNum + 1;
            string cadre = CadreNum.ToString("D3");
            Scenario.Add($"Id={cadre};GR={Chapter};ORD=1");
            int ord = 0;
            //text template
            ord++;
            Scenario.Add(GetText(cadre, ". . . . . . . . . . . . .", 2000, 500, 1200, 100, 2, 0, 2, 0, template_text, true));
            // figure template
            Scenario.Add(GetImage(cadre, "Figure", null, size_figure, x_figure, y_figure, 0, 0, null, template_figure, true));
            //location template
            Scenario.Add(GetImage(cadre, "Location backgroung", null, size_frame_main, x_frame_main, y_frame_main, 0, ord, null, template_location, true));
        }

        protected override void GenerateScenario()
        {
            CreateData();
            AddHeader();
            Chapter1("Chapter 1", "Chapter 1 - вступление, утром разбудить друга");
            Chapter2("Chapter 2", "Chapter 2 - бежим в школу");
            Chapter3("Chapter 3", "Chapter 3 - успели в школу");
            Chapter4("Chapter 4", "Chapter 4 - на тренировке в потной майке");
            Chapter5("Chapter 5", "Chapter 5 - Попытка скоротать грустный вечер с другом.");
            Chapter6("Chapter 6", "Chapter 6 - Утренний стояк и неловкость");
        }
        /*        protected override void Chapter1(string chapter, string description = null)
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
        */
    }
}
