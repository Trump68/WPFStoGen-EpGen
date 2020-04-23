using StoGen.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.Transition;
using StoGenerator.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGenerator.Stories
{
    public class Story001: StoryBase
    {


        //private string FPersonName;
        protected Info_Scene FCurrentPosition = new Info_Scene();
        protected Info_Scene CurrentPerson;
        protected Wife_JennyFord JennyFord;
        protected List<Info_Scene> JennyFord_Posture;

        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);

            JennyFord = Wife_JennyFord.Load();
            //FPersonName = "Jenny Ford";
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1000";
            FCurrentPosition.X = "800";
            FCurrentPosition.Y = "200";
            MakeLocation("Student Room 001", "evening", "Печальная тема 01");
            FillData();

        }
        protected void MakeLocation(string location,string feature, string music)
        {
            MakeLocationCadre(location, feature, music, null);
        }
        protected override void FillData()
        {

            MakeFirsCadre("0070", Teller.Female, "Наконец ты пришел милый! Я уже заждалась!",false); //"0070"

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

            JennyFord_Posture = JennyFord.SetFace72(JennyFord_Posture); //"0072"
            JennyFord_Posture = JennyFord.Blush(JennyFord_Posture, false, 5000); // begin blush
            MakeNextCadre(Teller.MaleThoughts, "Что еще за новости?");

            JennyFord_Posture = JennyFord.SetFace76(JennyFord_Posture); //"0076"
            JennyFord_Posture = JennyFord.Blush(JennyFord_Posture); // blush
            MakeNextCadre(Teller.MaleThoughts, "и покраснела то как!...");

            JennyFord_Posture = JennyFord.SetFace76(JennyFord_Posture); //"0076"
            JennyFord_Posture = JennyFord.Blush(JennyFord_Posture); // blush
            MakeNextCadre(Teller.Female, "... ... ... ... ...");

            JennyFord_Posture = JennyFord.SetFace76(JennyFord_Posture); //"0076"
            JennyFord_Posture = JennyFord.Blush(JennyFord_Posture); // blush 
            MakeNextCadre(Teller.Male, "Да ты что? Ты уверена?");

            JennyFord_Posture = JennyFord.SetFace77(JennyFord_Posture); //"0077"
            JennyFord_Posture = JennyFord.Blush(JennyFord_Posture, true, 5000); // end blush
            MakeNextCadre(Teller.Female, "Ну конечно уверена!");

            JennyFord_Posture = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand2);
            JennyFord_Posture = JennyFord.SetFace79(JennyFord_Posture); //"0079"
            var t = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand1);
            t = JennyFord.SetFace77(t); //"0077"
            t.ForEach(x => { x.O = "100"; x.T = Trans.Dissapearing(1000); });
            JennyFord_Posture.AddRange(t);
            MakeNextCadre(Teller.Female, "... ... ... ... ...");


            JennyFord_Posture = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand2);
            JennyFord_Posture = JennyFord.SetFace86(JennyFord_Posture); //"0086"
            MakeNextCadre(Teller.Female, "В соседнем отделе один мужчина...");

            JennyFord_Posture = JennyFord.SetFace86(JennyFord_Posture); //"0086"
            MakeNextCadre(Teller.Female, "все время проявляет знаки внимания ко мне...");

            JennyFord_Posture = JennyFord.SetFace86(JennyFord_Posture); //"0086"
            MakeNextCadre(Teller.MaleThoughts, "Неужели ты, любимая, крутишь свой пиздой так сильно, что на тебя мужики залипают...");

            JennyFord_Posture = JennyFord.SetFace86(JennyFord_Posture); //"0086"
            MakeNextCadre(Teller.Male, "И кто же он, милая?");

            JennyFord_Posture = JennyFord.SetFace78(JennyFord_Posture); //"0078"
            MakeNextCadre(Teller.Female, "ну какая разница, ты же все равно его не знаешь...");

            JennyFord_Posture = JennyFord.SetFace78(JennyFord_Posture); //"0078"
            MakeNextCadre(Teller.MaleThoughts, "класс, я еще должен знать всех твоих мужиков что ли?");


            JennyFord_Posture = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand1);
            JennyFord_Posture = JennyFord.SetFace75(JennyFord_Posture); //"0075"
            t = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand2);
            t = JennyFord.SetFace78(t); //"0077"
            t.ForEach(x => { x.O = "100"; x.T = Trans.Dissapearing(1000); });
            JennyFord_Posture.AddRange(t);
            MakeNextCadre(Teller.Female, "Ты вообще мной не интересуешься в последнее время!");

            JennyFord_Posture = JennyFord.WoreNightgown(null, Wife_JennyFord.Poses.Stand1);
            JennyFord_Posture = JennyFord.SetFace75(JennyFord_Posture); //"0075"
            MakeNextCadre(Teller.MaleThoughts, "блядь, ну начинается...");

            JennyFord_Posture = JennyFord.SetFace76(JennyFord_Posture); //"0076"
            MakeNextCadre(Teller.Male, "Любимая прости!");

            JennyFord_Posture = JennyFord.SetFace76(JennyFord_Posture); //"0076"
            MakeNextCadre(Teller.Male, "Так что там этот мужчина? Расскажи, прошу тебя!");

            JennyFord_Posture = JennyFord.SetFace67(JennyFord_Posture); //"0068"
            MakeNextCadre(Teller.Female, "ты хочешь все знать?");


            JennyFord_Posture = JennyFord.SetFace67(JennyFord_Posture); //"0075" - CLOSER!!
            JennyFord_Posture.Remove(JennyFord_Posture.Last());
            JennyFord_Posture.ForEach(x => { x.T = "C.B.2000.300*Y.B.2000.-200*X.B.2000.-300"; });
            MakeNextCadre(Teller.Female, "ты хочешь все знать, да?");

            FCurrentPosition.S = "3000";
            FCurrentPosition.X = "500";
            FCurrentPosition.Y = "0";

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            MakeNextCadre(Teller.Female, "все-все, большой ревнивый мальчик?");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            MakeNextCadre(Teller.Male, "да, любимая, расскажи мне все. пожалуйста..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            MakeNextCadre(Teller.MaleThoughts, "...расскажи как ебешься с этим мужиком..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "...ты точно хочешь знать, любимый мой?");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, "да..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "Он делает мне комплименты..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "..говорит какая я красивая..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, ".. и все?...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "..нет..еще говорит что хотел бы бы заняться со мной..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.MaleThoughts, "...он конечно хочет ебаться с тобой..");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, ".. чем заняться?...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, ".. очень неприличными вещами!...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, ".. какими?...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, ".. очень-очень неприличными!...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, ".. а ты хочешь с ним этим заняться?...");

            JennyFord_Posture = JennyFord.SetFace74_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
                Where(x => !x.Tags.Contains(Wife_JennyFord.Eyes.Eyes1_72.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, ".. какой ты глупый, конечно нет!...");

            JennyFord_Posture = JennyFord.SetFace74_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.MaleThoughts, "...но он же тебя выебет скоро..");

            JennyFord_Posture = JennyFord.SetFace74_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Male, ".. ну а если подумать?...");

            JennyFord_Posture = JennyFord.SetFace72_67(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
                Where(x => !x.Tags.Contains(Wife_JennyFord.Eyes.Eyes1_74.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "........");

            JennyFord_Posture = JennyFord.SetFace72_71(JennyFord_Posture);
            JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
                Where(x => !x.Tags.Contains(Wife_JennyFord.Mouth.Mouth1_67.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            MakeNextCadre(Teller.Female, "....он очень настойчив....");
        }
        protected void MakeFirsCadre(string fileum, Teller who, string story, bool active)
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
            JennyFord.AddToStory(this, JennyFord_Posture, 1, active);
            AddText(story, who, true, active);
            JennyFord_Posture = JennyFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();
        }

        protected void AddText(string story, Teller who, bool slow, bool active)
        {
            string tran = "W..500>O.B.400.100";
            if (who == Teller.Female)
            {               
              if (slow)
                    tran = "W..1500>O.B.400.100";
                ObservableSceneInfoList.Add(new Info_Scene(1)
                { Active = active, Story = story, Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Cyan", F = "40", R = "2" });
            }
            else if (who == Teller.Male)
            {
                ObservableSceneInfoList.Add(new Info_Scene(1)
                { Active = active, Story = $"{story}", Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Coral", F = "40", R = "2" });
            }
            else if (who == Teller.MaleThoughts)
            {
                ObservableSceneInfoList.Add(new Info_Scene(1)
                { Active = active, Story = $"[{story}]", Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "White", F = "35", R = "3" });
            }
        }


        protected void MakeNextCadre( Teller who, string story)
        {
            JennyFord_Posture.ForEach(x =>
            {
                x.S = FCurrentPosition.S;
                x.Y = FCurrentPosition.Y;
                x.X = FCurrentPosition.X;               
            });
            JennyFord.AddToStory(this, JennyFord_Posture, 1, false);
            AddText(story, who, false,false);
            JennyFord_Posture = JennyFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();
        }
        protected void MakeLocationCadre(string location, string locationspec, string music, string musicspec)
        {
            var item = Sound.GetByName(music, musicspec, currentQueue, currentGroup);
            if (item != null)
            {
                //item.Active = true;
                ObservableSceneInfoList.Add(item);
            }
            item = StoGenerator.Location.GetByName(location, locationspec, currentQueue, currentGroup);
            if (item != null)
            {
                //item.Active = true;
                item.Z = "0";
                ObservableSceneInfoList.Add(item);
            }
            IncrementGroup();
        }


        //MENU
        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            string caption;

            itemlist = AddRootMenu(proc, null, out caption);
            itemlist = base.AddRootMenu(proc, itemlist, out caption);
            caption = "Выбрать действие:";
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, caption);
            return true;
        }
        protected List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Go To Location:";
            item.itemData = "Go To Location:";
            item.Executor = data =>
            {
                proc.MenuCreator = proc.OldMenuCreator;
                string str1;
                var itemlist1 = CreateMenuCadreLocation(proc, null, out str1);
                ShowMenuGoToLocation(proc, itemlist1);
            };
            itemlist.Add(item);
            caption = "Actions:";
            return itemlist;
        }
        protected List<ChoiceMenuItem> CreateMenuCadreLocation(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            foreach (var location in StoGenerator.Location.Storage)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{location.Name}";
                item.itemData = location;
                MenuDescriptopnItem mdi1 = new MenuDescriptopnItem("Тип", location.Type, true);
                item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
                item.Executor = data =>
                {   
                    var group = this.GetGroupedList()[proc.CadreId].Key;
                    while (this.ObservableSceneInfoList.Last().Group != group)
                    {
                        this.ObservableSceneInfoList.Remove(this.ObservableSceneInfoList.Last());
                    }
                    MakeLocation(((Location)data).Name, "day", "Печальная тема 01");
                    proc.GetNextCadre();
                };
                itemlist.Add(item);
            }

            caption = "Выбрать локацию:";
            return itemlist;
        }
        public bool ShowMenuGoToLocation(CadreController proc, List<ChoiceMenuItem> itemlist)
        {
            string caption;
            // just for current cadre selecting
            itemlist = CreateMenuCadreLocation(proc, null, out caption);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }
       
    }
}
