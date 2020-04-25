using StoGen.Classes;
using StoGen.Classes.Scene;
using StoGen.Classes.SceneCadres.CadreElements;
using StoGen.Classes.Transition;
using StoGenerator.CadreElements;
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

        public Story001()
        {
            JFord = JennyFord.Load();
            
           //FPersonName = "Jenny Ford";
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1000";
            FCurrentPosition.X = "800";
            FCurrentPosition.Y = "200";
        }
        //private string FPersonName;
        protected Info_Scene FCurrentPosition = new Info_Scene();
        protected Info_Scene CurrentPerson;
        protected JennyFord JFord;
        protected List<Info_Scene> JennyFord_Posture;

        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            MakeTitle();
            FillData();

        }

        protected override void FillData()
        {
            CE_Location.AddWithMusic(this,"Student Room 001", "evening", "Печальная тема 01", null);

            MakeFirsCadre("0070", Teller.Female, "Наконец ты пришел милый! Я уже заждалась!",false); //"0070"


            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_67.ToString(), JennyFord.Mouth.Mouth1_67.ToString(), JennyFord.Eyes.EyesBlink1.ToString());//"0067"
            MakeNextCadre(Teller.Female, "Надеюсь, у тебя все хорошо.");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_68.ToString(), JennyFord.Mouth.Mouth1_68.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0068"
            MakeNextCadre(Teller.Male, "Неплохо, любимая... А у тебя?");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            MakeNextCadre(Teller.MaleThoughts, "Что-то моя благоверная кислая какая-то. Встревожена что ли?");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            MakeNextCadre(Teller.Female, "У меня? Ну как тебе сказать...");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            MakeNextCadre(Teller.Female, "Вообще-то, я хотела раньше тебе сказать...");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            MakeNextCadre(Teller.Female, "Ну вообщем... ты только не злись, ладно?");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            MakeNextCadre(Teller.Female, "Обещаешь?");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            MakeNextCadre(Teller.Female, "За мной ухаживают...");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            MakeNextCadre(Teller.Female, "На работе...");

            JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            JennyFord_Posture = JFord.Blush(JennyFord_Posture, false, 5000);
            MakeNextCadre(Teller.MaleThoughts, "Что еще за новости?");



            //JennyFord_Posture = JFord.SetFace76(JennyFord_Posture); //"0076"
            //JennyFord_Posture = JFord.Blush(JennyFord_Posture); // blush
            //MakeNextCadre(Teller.MaleThoughts, "и покраснела то как!...");

            //JennyFord_Posture = JFord.SetFace76(JennyFord_Posture); //"0076"
            //JennyFord_Posture = JFord.Blush(JennyFord_Posture); // blush
            //MakeNextCadre(Teller.Female, "... ... ... ... ...");

            //JennyFord_Posture = JFord.SetFace76(JennyFord_Posture); //"0076"
            //JennyFord_Posture = JFord.Blush(JennyFord_Posture); // blush 
            //MakeNextCadre(Teller.Male, "Да ты что? Ты уверена?");

            //JennyFord_Posture = JFord.SetFace77(JennyFord_Posture); //"0077"
            //JennyFord_Posture = JFord.Blush(JennyFord_Posture, true, 5000); // end blush
            //MakeNextCadre(Teller.Female, "Ну конечно уверена!");

            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand2);
            //JennyFord_Posture = JFord.SetFace79(JennyFord_Posture); //"0079"
            //var t = JFord.WoreNightgown(null, JennyFord.Poses.Stand1);
            //t = JFord.SetFace77(t); //"0077"
            //t.ForEach(x => { x.O = "100"; x.T = Trans.Dissapearing(1000); });
            //JennyFord_Posture.AddRange(t);
            //MakeNextCadre(Teller.Female, "... ... ... ... ...");


            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand2);
            //JennyFord_Posture = JFord.SetFace86(JennyFord_Posture); //"0086"
            //MakeNextCadre(Teller.Female, "В соседнем отделе один мужчина...");

            //JennyFord_Posture = JFord.SetFace86(JennyFord_Posture); //"0086"
            //MakeNextCadre(Teller.Female, "все время проявляет знаки внимания ко мне...");

            //JennyFord_Posture = JFord.SetFace86(JennyFord_Posture); //"0086"
            //MakeNextCadre(Teller.MaleThoughts, "Неужели ты, любимая, крутишь свой пиздой так сильно, что на тебя мужики залипают...");

            //JennyFord_Posture = JFord.SetFace86(JennyFord_Posture); //"0086"
            //MakeNextCadre(Teller.Male, "И кто же он, милая?");

            //JennyFord_Posture = JFord.SetFace78(JennyFord_Posture); //"0078"
            //MakeNextCadre(Teller.Female, "ну какая разница, ты же все равно его не знаешь...");

            //JennyFord_Posture = JFord.SetFace78(JennyFord_Posture); //"0078"
            //MakeNextCadre(Teller.MaleThoughts, "класс, я еще должен знать всех твоих мужиков что ли?");


            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand1);
            //JennyFord_Posture = JFord.SetFace75(JennyFord_Posture); //"0075"
            //t = JFord.WoreNightgown(null, JennyFord.Poses.Stand2);
            //t = JFord.SetFace78(t); //"0077"
            //t.ForEach(x => { x.O = "100"; x.T = Trans.Dissapearing(1000); });
            //JennyFord_Posture.AddRange(t);
            //MakeNextCadre(Teller.Female, "Ты вообще мной не интересуешься в последнее время!");

            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand1);
            //JennyFord_Posture = JFord.SetFace75(JennyFord_Posture); //"0075"
            //MakeNextCadre(Teller.MaleThoughts, "блядь, ну начинается...");

            //JennyFord_Posture = JFord.SetFace76(JennyFord_Posture); //"0076"
            //MakeNextCadre(Teller.Male, "Любимая прости!");

            //JennyFord_Posture = JFord.SetFace76(JennyFord_Posture); //"0076"
            //MakeNextCadre(Teller.Male, "Так что там этот мужчина? Расскажи, прошу тебя!");

            //JennyFord_Posture = JFord.SetFace67(JennyFord_Posture); //"0068"
            //MakeNextCadre(Teller.Female, "ты хочешь все знать?");


            //JennyFord_Posture = JFord.SetFace67(JennyFord_Posture); //"0075" - CLOSER!!
            //JennyFord_Posture.Remove(JennyFord_Posture.Last());
            //JennyFord_Posture.ForEach(x => { x.T = "C.B.2000.300*Y.B.2000.-200*X.B.2000.-300"; });
            //MakeNextCadre(Teller.Female, "ты хочешь все знать, да?");

            //FCurrentPosition.S = "3000";
            //FCurrentPosition.X = "500";
            //FCurrentPosition.Y = "0";

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //MakeNextCadre(Teller.Female, "все-все, большой ревнивый мальчик?");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //MakeNextCadre(Teller.Male, "да, любимая, расскажи мне все. пожалуйста..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //MakeNextCadre(Teller.MaleThoughts, "...расскажи как ебешься с этим мужиком..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "...ты точно хочешь знать, любимый мой?");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, "да..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "Он делает мне комплименты..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "..говорит какая я красивая..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, ".. и все?...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "..нет..еще говорит что хотел бы бы заняться со мной..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.MaleThoughts, "...он конечно хочет ебаться с тобой..");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, ".. чем заняться?...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, ".. очень неприличными вещами!...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, ".. какими?...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, ".. очень-очень неприличными!...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, ".. а ты хочешь с ним этим заняться?...");

            //JennyFord_Posture = JFord.SetFace74_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
            //    Where(x => !x.Tags.Contains(JennyFord.Eyes.Eyes1_72.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, ".. какой ты глупый, конечно нет!...");

            //JennyFord_Posture = JFord.SetFace74_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.MaleThoughts, "...но он же тебя выебет скоро..");

            //JennyFord_Posture = JFord.SetFace74_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Male, ".. ну а если подумать?...");

            //JennyFord_Posture = JFord.SetFace72_67(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
            //    Where(x => !x.Tags.Contains(JennyFord.Eyes.Eyes1_74.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "........");

            //JennyFord_Posture = JFord.SetFace72_71(JennyFord_Posture);
            //JennyFord_Posture.Take(JennyFord_Posture.Count - 1).
            //    Where(x => !x.Tags.Contains(JennyFord.Mouth.Mouth1_67.ToString())).ToList().ForEach(x => { x.T = "Y.B.500.-2>Y.B.500.2~"; });
            //MakeNextCadre(Teller.Female, "....он очень настойчив....");
        }



        protected void MakeFirsCadre(string fileum, Teller who, string story, bool active)
        {
            
            JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand1);

            JennyFord_Posture = //JFord.SetFace70(JennyFord_Posture);
                JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_70.ToString(), JennyFord.Mouth.Mouth1_70.ToString(), null);
            JennyFord_Posture.ForEach(x => 
            {  
                x.S = FCurrentPosition.S;
                x.Y = FCurrentPosition.Y;
                x.X = "2000";
                x.T = $"{Trans.SetInvisible}>{Trans.Wait(1500)}>{Trans.Appearing(1500)}*{Trans.MoveH(1500, -1200)}";
            });
            JennyFord_Posture.First().T = 
                $"{Trans.SetInvisible}>{Trans.Appearing(1500)}*{Trans.MoveH(1500,-1200)}";
            AddScenes(JennyFord_Posture, 1, active);
            AddText(story, who, true, active);
            JennyFord_Posture = JFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();
        }

        protected void AddText(string story, Teller who, bool slow, bool active)
        {
            string tran = "W..500>O.B.400.100";
            if (who == Teller.Female)
            {               
              if (slow)
                    tran = "W..1500>O.B.400.100";
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = story, Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Cyan", F = "40", R = "2" });
            }
            else if (who == Teller.Male)
            {
                SceneInfos.Add(new Info_Scene(1)
                { Active = active, Story = $"{story}", Description = story, Group = currentGroup, Queue = currentQueue, T = tran, O = "0", Z = "Coral", F = "40", R = "2" });
            }
            else if (who == Teller.MaleThoughts)
            {
                SceneInfos.Add(new Info_Scene(1)
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
            AddScenes(JennyFord_Posture, 1, false);
            AddText(story, who, false,false);
            JennyFord_Posture = JFord.ResetPosture(JennyFord_Posture);
            IncrementGroup();
        }

        protected void MakeTitle()
        {
            Info_Scene title = new Info_Scene();
            title.Kind = 1;
            //title.File = "$$WHITE$$";
            title.Queue = currentQueue;
            title.Group = currentGroup;
            SceneInfos.Add(title);
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
            item.Name = "Change Face:";
            item.itemData = "Change Face:";
            item.Executor = data =>
            {
                //proc.MenuCreator = proc.OldMenuCreator;
                string caption2;
                var itemlist1 = CreateMenuChangeFace(proc, null, out caption2);
                ShowSubmenu(proc, itemlist1, caption2);
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem();
            item.Name = "Go To Location:";
            item.itemData = "Go To Location:";
            item.Executor = data =>
            {
                //proc.MenuCreator = proc.OldMenuCreator;
                string caption1;
                var itemlist1 = CreateMenuCadreLocation(proc, null, out caption1);
                ShowSubmenu(proc, itemlist1, caption1);
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
                    this.RemoveAllGroupsAfter(proc.CadreId);
                    CE_Location.AddWithMusic(this, ((Location)data).Name, "day", "Печальная тема 01", null);
                    proc.GetNextCadre();
                };
                itemlist.Add(item);
            }

            caption = "Выбрать локацию:";
            return itemlist;
        }
        protected List<ChoiceMenuItem> CreateMenuChangeFace(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            var faces = JFord.Files.Where(x => x.Item1.Contains(JennyFord.Face.FaceGeneric.ToString())).ToList();
            foreach (var face in faces)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{face.Item1}";
                item.itemData = face.Item2.Split(';');
                item.Executor = data =>
                {
                    JennyFord_Posture = PullCadreFromScene(proc, proc.CadreId);
                    JennyFord_Posture = JFord.GetFace(JennyFord_Posture, (data as string[])[0], (data as string[])[1], JennyFord.Eyes.EyesBlink1.ToString());
                    AddScenes(JennyFord_Posture, 1, false);
                    proc.RefreshCurrentCadre();
                };
                itemlist.Add(item);
            }

            caption = "Поменять выражение лица:";
            return itemlist;
        }

        private List<Info_Scene> PullCadreFromScene(CadreController proc, int cadreId)
        {
            List<Info_Scene> result = proc.Scene.CadreDataList[cadreId].OriginalInfo;
            currentGroup = result.First().Group;
            currentQueue = result.First().Queue;
            proc.Cadres.RemoveAt(cadreId);
            proc.Scene.CadreDataList.RemoveAt(cadreId);
            //RemoveAllGroupsAfter(cadreId - 1);
            RemoveGroupAt(cadreId);
            return result;
        }

        public bool ShowSubmenu(CadreController proc, List<ChoiceMenuItem> itemlist, string caption)
        {
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, true, caption);
            return true;
        }

    }
}
