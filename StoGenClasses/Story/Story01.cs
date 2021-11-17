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
        private List<Tuple<string, string>> BGMResources = new List<Tuple<string, string>>();

        int size_frame_2 = 920; int x_frame_2 = 1780; int y_frame_2 = 750; string template_frame_2 = "301";
        int size_frame_main = 1920; int x_frame_main = 0; int y_frame_main = 0; string template_frame_main = "0"; string transition_main = "W..1500>O.B.500.-100";
        int size_frame_1 = 1000; int x_frame_1 = 1560; int y_frame_1 = 0; string template_frame_1 = "300";
        int size_figure = 1920; int x_figure = 0; int y_figure = 0; string template_figure = "8";
        int size_event = 1000; int x_event = 100; int y_event = 100; string template_event = "9";
        int size_hero_avatar = 815; int x_hero_avatar = 1800; int y_hero_avatar = 732; string template_hero_avatar = "7";
        string template_location = "300"; string transitionlocation = "W..3000>O.B.500.-100";
        string template_text = "1";
        int z = 0;
        string Name_Girl = "Комаки";


        protected override void GenerateScenario()
        {
            int group = 0;
            
            AddChapter("0-Header");
            AddHeader();

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

            Person person = new Person(this);
            person.SetVisibleView("Close", "Gown");
            person.SetVisibleExpression("calm smiling");

            AddChapter("Chapter 2");

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5),
                AddTextByTemplate(template_text, ". . . Ох! Ну что еще? . . ."),
                GetBGM("ogg00052", 100, $"W..2000>p.A.0.1", false, false, false),
                GetSoundEffect("Wear moving 1", 100, 0, null, false, false, true),
                AddImageByTemplate("Location background", 0, template_location, null, null),
                AddImageByTemplate("Location foreground", 19, template_location, null, "W..3000>O.B.500.-100"),
                AddImageByTemplate("Black background", 20, template_frame_main, null, "W..1500>O.B.500.-100")                
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~'О-о . . . Хорошо тут сидеть . . .'"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5),
                AddTextByTemplate(template_text, $". . . Я чувствую приятную мягкую тяжесть на себе . . .'"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.MoveVs(20, -30)}>{Trans.Wait(500)}>{Trans.MoveVs(20, 30)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~'*вздыхает* Может мне отохнуть здесь . . . ?'"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $". . . Это немного . . . тяжело . . .'"),
                AddImageByTemplate("Location background", 0, template_location, null, $"{Trans.ImpactHs(200, 100)}")
                );

            person.SetVisibleExpression("smiling");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Я наверно  позавтракаю прямо здесь. . .'"),
                AddImageByTemplate("Location background", 0, template_location, null, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $". . . Ты не ела дома. . ?'"),
                AddImageByTemplate("Location background", 0, template_location, null, $"{Trans.ImpactHs(200, 100)}")
                );

            person.SetVisibleExpression("calm smiling");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . А может, просто растянуться здесь и полежать. . ?''"),
                AddImageByTemplate("Location background", 0, template_location, null, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . . Все, я понял, понял. . .  уже встаю. . .''"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleView("Far", "Gown");
            person.SetVisibleExpression("smiling");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~. . . Ну, если так. . Тогда проснись и пой . .!"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . . Мое покрывало тут же забрали . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . . Я уже начинаю привыкать к этому . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("agitated tiny smile");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Разве ты не говорил, что встаешь рано, потому что у тебя экзамен сегодня . . ?"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . Ой . . "),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("laughing");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Хих . . . Ты забыл об этом . . !"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . Нет . . Кстати, ты теперь каждый раз будешь приходить так рано и будить меня . . ?"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("amusing");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Но я уже привыкла обычно будить тебя . . !"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . Для того чтобы наслаждаться этим общением и ее красотой . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                 );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . признаюсь честно, я иногда специально просыпал . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("tiny smile");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Кстати, ты собираешься завтракать? Пропускать завтрак вредно. . !"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            // затухание музыки
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                GetBGM("ogg00052", 0 , null, false, true, false),
                AddTextByTemplate(template_text, $". . Мы с ней друзья с детства . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $". . И еще - я люблю ее . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Хмм. . Наверно мне самой надо приносить тебе завтрак . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"Возможно, она не совсем леди, но какая же она заботливая"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("laughing");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Наверно как нибудь я об этом подумаю . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"Какая же у ней улыбка . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"Я просто постоянно думаю о ней . ."),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );

            person.SetVisibleExpression("amusing");
            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, $"{Trans.ImpactHs(200, 100)}"),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Ой, посмотри сколько время . . Ты можешь опоздать . . !"),
                AddImageByTemplate("Location background", 0, template_location, null, $"{Trans.ImpactHs(200, 100)}")
                );

            CadreNum++; AddCadre(
                person.GetData(template_figure, 5, null),
                AddTextByTemplate(template_text, $"[{Name_Girl}]~Давай быстрей собирайся . . !"),
                AddImageByTemplate("Location background", 0, template_location, null, null)
                );
            
            CadreNum++; AddCadre(AddTextByTemplate(template_text, ". . . ."));
        }
        private void AddChapter(string chapter)
        {
            Chapter = chapter;
            Scenario.Add($"GroupId={Chapter};DSC={Chapter};ORD=1");
        }

        private void AddHeader()
        {
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
            Scenario.Add(GetImage(cadre, "Location backgroung", background, size_frame_main, x_frame_main, y_frame_main, z, ord, template_location, true));
            // protagonist avatar template
            ord++; z = 11;
            Scenario.Add(GetImage(cadre, "Hero avatar", protagonst, size_hero_avatar, x_hero_avatar, y_hero_avatar, z, ord, template_hero_avatar, true));
            // event template
            ord++; z = 5;
            Scenario.Add(GetImage(cadre, "Event", mainfigure, size_event, x_event, y_event, z, ord, template_event, true));
            // figure template
            ord++; z = 10;
            Scenario.Add(GetImage(cadre, "Figure", mainfigure, size_figure, x_figure, y_figure, z, ord, template_figure, true));
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
