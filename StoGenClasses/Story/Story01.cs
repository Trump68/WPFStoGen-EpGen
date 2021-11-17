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
        public Story01():base()
        {
            Girl = new Person(this);
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
        string template_location_2 = "302";
        string transitionlocation = "W..3000>O.B.500.-100";
        string template_text = "1";
        int z = 0;
        string Name_Girl = "Комаки";
        Person Girl;

        string transform_Disapearing_1 = "W..3000>O.B.500.-100";
        string transform_Disapearing_2 = "W..1500>O.B.500.-100";
        string transform_Disapearing_3 = "W..500>O.B.500.-100";
        string transform_Apearing_1 = "W..3000>O.B.500.100";
        string transform_music_delay_1 = $"W..2000>p.A.0.1";

        protected override void GenerateScenario()
        {                      
            AddHeader();
            Chapter1();
            Chapter2();
            Chapter3();
            Chapter4();
            Chapter5();
        }
        private void Chapter1()
        {
            AddChapter("Chapter 1");

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . . . . . . . . ."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, "Взглядов на жизнь на свете так же много, как много и людей."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . Некоторые люди возможно заставят вас успешно сдать экзамен или найти работу."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . Некоторые люди возможно скажут вам не тратить время зря."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . Но дремать, наслаждаясь комфортом - это одна из разновидностей счастья."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . Что я и делаю сейчас . . ."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, "[Голос]~'Эй ...'"));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . похоже это . . ."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, "[Голос]~'Эй . . . Просыпайся . . .'"));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . похоже это . . ."));
            CadreNum++; AddCadre(AddTextByTemplate(template_text, $"[{Name_Girl}]~'АХХ!!! . . . ДА ПРОСЫПАЙСЯ УЖЕ !!!'"));
        }
        private void Chapter2()
        {
            AddChapter("Chapter 2");

            string currentlocation = GetFileLocation("Livingroom 001 morning");

            Girl.SetVisibleView("Close", "Gown");
            Girl.SetVisibleExpression("calm smiling");

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 0, transform_Apearing_1),
                AddTextByTemplate(template_text, ". . . Ох! Ну что еще? . . ."),
                GetBGM("ogg00052", 100, transform_music_delay_1, false, false, false),
                GetSoundEffect("Wear moving 1", 100, 0, null, false, false, true),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~'О-о . . . Хорошо тут сидеть . . .'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . Я чувствую приятную мягкую тяжесть на себе . . .'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 0,  $"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~'*вздыхает* Может мне отохнуть здесь . . . ?'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100,  $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $". . . Это немного . . . тяжело . . .'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            Girl.SetVisibleExpression("smiling");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100,  $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Я наверно  позавтракаю прямо здесь. . .'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100,  $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $". . . Ты не ела дома. . ?'"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            Girl.SetVisibleExpression("calm smiling");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . А может, просто растянуться здесь и полежать. . ?''"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . Все, я понял, понял. . .  уже встаю. . .''"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleView("Far", "Gown");
            Girl.SetVisibleExpression("smiling");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Ну, если так. . Тогда проснись и пой . .!"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . Мое покрывало тут же забрали . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . Я уже начинаю привыкать к этому . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("agitated tiny smile");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . Ой . . "),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("laughing");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Хих . . . Ты забыл об этом . . !"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("amusing");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Но я уже привыкла обычно будить тебя . . !"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . Для того чтобы наслаждаться этим общением и ее красотой . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                 );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . признаюсь честно, я иногда специально просыпал . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("tiny smile");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            // затухание музыки
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                GetBGM("ogg00052", 0, null, false, true, false),
                AddTextByTemplate(template_text, $". . Мы с ней друзья с детства . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . И еще - я люблю ее . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Возможно, она не совсем леди, но какая же она заботливая"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("laughing");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Наверно как нибудь я об этом подумаю . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Какая же у ней улыбка . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Я просто постоянно думаю о ней . ."),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );

            Girl.SetVisibleExpression("amusing");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Давай быстрей собирайся . . !"),
                AddImageByTemplate("Location background", 0, template_location, currentlocation, null)
                );


            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . Мы были обычными соседями сначала, и не были близкими друзьями . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . Ее родители развелись, когда мы еще были детьми . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . И я довольно часто видел ее на улице одну . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . Когда я позвал ее, она была счастлива . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . И мы стали проводить время вместе . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . Возможно . . . у нее нет романтических чувств ко мне . . ."));

            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . . Но у меня - есть . . . они возникли в общем-то недавно . . ."));
        }
        private void Chapter3()
        {
            AddChapter("Chapter 3");

            string currentlocation = GetFileLocation("Street 001 morning");

            Girl.SetVisibleExpression("calm smiling");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 0, transform_Apearing_1),
                GetBGM("ogg00052", 100, transform_music_delay_1, false, false, false),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Ну что, ты проснулся наконец . . ?"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            Girl.SetVisibleExpression("amusing");

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"Ой . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Извини, я задумался . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            Girl.SetVisibleExpression("calm smiling");

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Да ладно, даже когда я с тобой? Соберись уже . . . !"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[Бежать в школу со всех ног уже вошло в привычку.]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[. . . Она могла бы уже давно быть в школе, но она не хочет меня бросать.]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[. . . А я пользуюсь ее добротой . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Ну серьезно. . . Почему ты всегда убегаешь . . ?"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            Girl.SetVisibleExpression("amusing");

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Может потому что ты всегда спишь?"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Это напрягает тебя?"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            Girl.SetVisibleExpression("calm smiling");

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Хмм, все равно, я бегу на занятия в свой клуб . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Ладно, я могла бы иногда проводить больше времени с тобой, как мы иногда делаем . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[. . . Такие дни просто класс . . !]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Я могу тебя будить, как только сама встаю. . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[. . . Вот всегда она так . . !]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[. . . Я боюсь за наши отношения  . . ]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );
            
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 100, transform_Disapearing_3),
                AddTextByTemplate(template_text, $"[. . . Из-за того, что она слишком наивная и немного нерешительная  . . ]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );
            
            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[. . . . . ]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[. . . Ха? ]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[. . . Погоди . . . {Name_Girl} . . . ты слишком быстро бежишь . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation)
                );

            CadreNum++; AddCadre(
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, transform_Disapearing_3),
                AddTextByTemplate(template_text, $"[. . . Она капитан команды болельщиц. . .]")
                );

            CadreNum++; AddCadre(AddTextByTemplate(template_text, $"[. . . Запыхавшись, я все-таки догнал ее. . .]"));

        }
        private void Chapter4() 
        {
            AddChapter("Chapter 4");

            string currentlocation = GetFileLocation("Class 001 day");

            Girl.SetVisibleExpression("calm smiling");
            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5, 0, transform_Apearing_1),
                GetBGM("ogg00050", 100, transform_music_delay_1, false, false, false),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Ух, еле успели . . !"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null),
                AddImageByTemplate("Black background", 20, template_frame_main, null, transform_Disapearing_2)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . .  . . "),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . уф . . уф . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"Ох. . . как-то . . справились . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                Girl.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Отлично, тогда пока, увидимся позже . . !"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(                
                Girl.GetData(template_figure, 5, 100, transform_Disapearing_3),
                AddTextByTemplate(template_text, $". . . Пока . . !"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            //stop musik
            CadreNum++; AddCadre(
                GetBGM("ogg00050", 0, null, false, true, false),
                AddTextByTemplate(template_text, $"[ Фу . . Делать это каждый раз тяжеловато. Она слишком шустрая, а я не привык к этому ]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(                
                AddTextByTemplate(template_text, $"[ Она как парень . . . или как приятель . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . Может она и не догадывается, но она очень популярна среди парней . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . Хотя еще никто не подкатывал к ней, потому что я всегда ее сопровождаю . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . (Хоть это мне и не особо помогает) . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . (Или скорей это как-то странно, потому что я сам не знаю что делать) . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[Учитель]~ . . . Хорошо, начнем урок . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $" . . . . . ."),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . (Как обычно, я думаю только об этом) . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . И слишком мало думаю об экзамене . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );

            CadreNum++; AddCadre(
                AddTextByTemplate(template_text, $"[ . . . И слишком много - об романтике, что делает меня неуверенным . . .]"),
                AddImageByTemplate("Location background", 0, template_location_2, currentlocation, null)
                );
        }
        private void Chapter5() 
        {

        }

        private void AddChapter(string chapter)
        {
            Chapter = chapter;
            Scenario.Add($"GroupId={Chapter};DSC={Chapter};ORD=1");
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
            Scenario.Add(GetImage(cadre, "Location backgroung 02", background, size_frame_main_2, x_frame_main_2, y_frame_main, z, ord, null, template_location_2, true));
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
            //CadreNum = CadreNum + 1;
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
        }
        private void AddCadre(params string[] frames)
        {
            AddCadre(null, frames);
        }
    }

}
