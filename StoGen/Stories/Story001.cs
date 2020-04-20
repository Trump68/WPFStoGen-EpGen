using StoGen.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
using StoGenerator.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class Story001: StoryBase
    {
        string rawparameters =
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=40;DefFontColor=Cyan;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";

        //private string FPersonName;
        private Info_Scene FCurrentPosition = new Info_Scene();
        private Info_Scene CurrentPerson;
        Wife_JennyFord JennyFord;
        List<Info_Scene> JennyFord_Posture;

        public void Generate(SCENARIO scenario, string queue, string group)
        {
            Scenario = scenario;
            currentGroup = group;
            currentQueue = queue;
            Scenario.RawParameters = rawparameters;
            Scenario.AssignRawParameters();

            JennyFord = Wife_JennyFord.Load();


            //FPersonName = "Jenny Ford";
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1000";
            FCurrentPosition.X = "800";
            FCurrentPosition.Y = "200";

            MakeLocationCadre("Apartment 001", "evening", "Печальная тема 01",null);

            MakeFirsCadre("0070", Teller.Female,"Наконец ты пришел милый! Я уже заждалась!"); //"0070"

            JennyFord_Posture = JennyFord.SetFace67(JennyFord_Posture); //"0067"
            MakeNextCadre(Teller.Female, "Надеюсь, у тебя все хорошо.");

            JennyFord_Posture = JennyFord.SetFace68(JennyFord_Posture); //"0068"
            MakeNextCadre(Teller.Male, "Неплохо, любимая... А у тебя?");

            JennyFord_Posture = JennyFord.SetFace71(JennyFord_Posture); //"0071"
            MakeNextCadre(Teller.MaleThoughts, "Что-то моя благоверная кислая какая-то. Встревожена что ли?");

            JennyFord_Posture = JennyFord.SetFace71(JennyFord_Posture); //"0071"
            MakeNextCadre(Teller.Female, "У меня? Ну как тебе сказать...");

            JennyFord_Posture = JennyFord.SetFace71(JennyFord_Posture); //"0071"
            MakeNextCadre(Teller.Female, "Вообще-то, я хотела раньше тебе сказать...");

            JennyFord_Posture = JennyFord.SetFace71(JennyFord_Posture); //"0071"
            MakeNextCadre(Teller.Female, "Ну вообщем... ты только не злись, ладно?");

            JennyFord_Posture = JennyFord.SetFace71(JennyFord_Posture); //"0071"
            MakeNextCadre(Teller.Female, "Обещаешь?");

            JennyFord_Posture = JennyFord.SetFace72(JennyFord_Posture); //"0072"
            MakeNextCadre(Teller.Female, "За мной ухаживают...");

            JennyFord_Posture = JennyFord.SetFace72(JennyFord_Posture); //"0072"
            MakeNextCadre(Teller.Female, "На работе...");

            //MakeNextCadre("0072", Teller.Female,
            //"На работе... за мной ухаживают...");
            //MakeNextCadre(null, Teller.MaleThoughts,
            //"Что еще за новости?");
            //MakeNextCadre("0076", Teller.MaleThoughts,
            //"и покраснела то как!...");
            //MakeNextCadre(null, Teller.Female,
            //"... ... ... ... ...");
            //MakeNextCadre(null,Teller.Male,
            //"Ухаживают? Ты уверена?");
            //MakeNextCadre("0077", Teller.Female,
            //"Ну конечно уверена!");
            //MakeNextCadre("0079", Teller.Female,
            //"... ... ... ... ...");
            //MakeNextCadre(null, Teller.Female,
            //"В соседнем отделе есть один мужчина...");
            //MakeNextCadre("0086", Teller.Female,
            //"который проявляет знаки внимания...");
            //MakeNextCadre(null, Teller.MaleThoughts,
            //"Ага... ну неужели ты крутишь свой пиздой там так сильно, что на тебя мужики залипают...");
            //MakeNextCadre(null, Teller.Male,
            //"И кто же он, милая?");
            //MakeNextCadre("0078", Teller.Female,
            //"ну какая разница, ты же его не знаешь...");
            //MakeNextCadre(null, Teller.MaleThoughts,
            //"класс, я еще должен знать всех твоих мужиков что ли?");
            //MakeNextCadre("0075", Teller.Female,
            //"Ты вообще мной не интересуешься в последнее время!");
            //MakeNextCadre(null, Teller.MaleThoughts,
            //"блядь, начинается...");
        }

        private void Do(Wife_JennyFord.Poses pose, Wife_JennyFord.Mouth mouth, bool transition)
        {
            JennyFord_Posture = JennyFord.Combine(JennyFord_Posture, pose, mouth, transition);
            //JennyFord.AddBlink(JennyFord_Posture, pose, Wife_JennyFord.Eyes.EyesClosed1);
        }
        private void Do(Wife_JennyFord.Poses pose, Wife_JennyFord.Mouth mouth, Wife_JennyFord.Eyes eyes, bool transition)
        {
            JennyFord_Posture = JennyFord.Combine(JennyFord_Posture, pose, mouth, transition);
            JennyFord.RemoveBlink(JennyFord_Posture, pose, Wife_JennyFord.Eyes.EyesClosed1);
            JennyFord_Posture = JennyFord.Combine(JennyFord_Posture, pose, eyes, transition);
            //JennyFord.AddBlink(JennyFord_Posture, pose, Wife_JennyFord.Eyes.EyesClosed1);
        }

        private void MakeFirsCadre(string fileum, Teller who, string story)
        {
            
            JennyFord_Posture = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand1);
            JennyFord_Posture = JennyFord.SetFace70(JennyFord_Posture);
            JennyFord_Posture.ForEach(x => 
            {  
                x.S = FCurrentPosition.S;
                x.Y = FCurrentPosition.Y;
                x.X = "2000";
                x.T = $"{Trans.SetInvisible}>{Trans.Wait(1500)}>{Trans.Appearing(1500)}*{Trans.MoveH(1500, -1200)}";
            });
            JennyFord_Posture.First().T = 
                $"{Trans.SetInvisible}>{Trans.Appearing(1500)}*{Trans.MoveH(1500,-1200)}";
            JennyFord.AddToStory(this, JennyFord_Posture, 1);
            AddText(story, who, true);
            JennyFord_Posture = JennyFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();
        }
        //private void ResetTransitions()
        //{
        //    JennyFord_Posture = JennyFord.ResetTransitions(JennyFord_Posture);           
        //}
        private void AddText(string story, Teller who, bool slow= false)
        {
            string tran = "W..500>O.B.400.100";
            if (who == Teller.Female)
            {               
              if (slow)
                    tran = "W..1500>O.B.400.100";
                Scenario.Scenes.Add(new Info_Scene(1)
                { Story = story, Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Cyan", F = "40", R = "2" });
            }
            else if (who == Teller.Male)
            {
                Scenario.Scenes.Add(new Info_Scene(1)
                { Story = $"{story}", Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Coral", F = "40", R = "2" });
            }
            else if (who == Teller.MaleThoughts)
            {
                Scenario.Scenes.Add(new Info_Scene(1)
                { Story = $"[{story}]", Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "White", F = "35", R = "3" });
            }
        }
       

        private void MakeNextCadre( Teller who, string story)
        {
            JennyFord_Posture.ForEach(x =>
            {
                x.S = FCurrentPosition.S;
                x.Y = FCurrentPosition.Y;
                x.X = FCurrentPosition.X;               
            });
            JennyFord.AddToStory(this, JennyFord_Posture, 1);
            AddText(story, who, true);
            JennyFord_Posture = JennyFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();

            //AddText(story, who);
            //int z = 1;
            //foreach (var itempocy in JennyFord_Posture)
            //{
            //    itempocy.Queue = currentQueue;
            //    itempocy.Group = currentGroup;
            //    itempocy.Z = (z++).ToString();
            //    itempocy.S = FCurrentPosition.S;
            //    itempocy.X = FCurrentPosition.X;
            //    itempocy.Y = FCurrentPosition.Y;
            //    Scenario.Scenes.Add(itempocy);
            //}


            //Info_Scene personNext = null;
            //if (CurrentPerson != null)
            //{
            //    var prev = Info_Scene.GenerateCopy(CurrentPerson);
            //    prev.Group = currentGroup;
            //    prev.Queue = currentQueue;
            //    prev.Z = "2";
            //    prev.O = "100";
            //    prev.S = FCurrentPosition.S;
            //    prev.X = FCurrentPosition.X;
            //    prev.Y = FCurrentPosition.Y;
            //    prev.T = null;
            //    if (!string.IsNullOrEmpty(next))
            //        prev.T = "W..0>O.B.1000.-100";
            //    Scenario.Scenes.Add(prev);
            //}

            //if (!string.IsNullOrEmpty(next))
            //{
            //    personNext = Person.GetByName(JennyFord.Name, $"{next}", currentQueue, currentGroup);
            //    if (personNext != null)
            //    {
            //        personNext.O = "100";
            //        personNext.Z = FCurrentPosition.Z;
            //        personNext.S = FCurrentPosition.S;
            //        personNext.X = FCurrentPosition.X;
            //        personNext.Y = FCurrentPosition.Y;
            //        Scenario.Scenes.Add(personNext);
            //        CurrentPerson = personNext;
            //    }
            //}

            //var eyes = Person.GetByName(JennyFord.Name, $"Eyes_1_002", currentQueue, currentGroup);
            //if (eyes != null)
            //{
            //    eyes.Z = "3";
            //    eyes.S = FCurrentPosition.S;
            //    eyes.X = "800";
            //    eyes.Y = FCurrentPosition.Y;
            //    eyes.O = "0";
            //    eyes.T = Transitions.Eyes_Blink;
            //    Scenario.Scenes.Add(eyes);
            //}

            IncrementGroup();
        }
        private void MakeLocationCadre(string location, string locationspec, string music, string musicspec)
        {
            var item = Sound.GetByName(music, musicspec, currentQueue, currentGroup);
            if (item != null)
            {
                Scenario.Scenes.Add(item);
            }
            item = Location.GetByName(location, locationspec, currentQueue, currentGroup);
            if (item != null)
            {
                item.Z = "0";
                Scenario.Scenes.Add(item);
            }
            IncrementGroup();
        }

    }
}
