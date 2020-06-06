using StoGen.Classes.Persons;
using StoGen.Classes.SceneCadres.CadreElements;
using StoGenerator.Persons;
using StoGenerator.StoryClasses;
using System;

namespace StoGenerator.Stories
{
    public class Story001 : PersonizedStory
    {
        public static string StoryName = "Story 001";
        public static DateTime DateStart = new DateTime(2020, 6, 1, 8, 0, 0);
        public static string startAtAddress = "Квартира N2,Дом N1,Жасминовая улица";
        public Story001():base(DateStart, startAtAddress, new DefaultPersonManager())
        {
            this.Name = Story001.StoryName;
            this.FileName = this.Name;
        }

        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            FillData();

        }
        protected override void FillPersonStorage()
        {
            Person.Storage.Clear();

            Person.LoadPassportsFolder(@"e:\!CATALOG\PRS\!STO GEN PERSON\");

            base.FillPersonStorage();
        }
        protected override void FillData()
        {
            GoToCell(CurrentCell, null, false);
            Layers.AddRange(CE_Music.Get("Печальная тема 01", null));
            MakeNextCadre(Teller.Author, null);

            //F_Posture = JFord.GetFigure(F_Posture, $"{Feature.FeatureFigure}{1}", Trans.Dissapearing(1000));
            //F_Posture = JFord.SetFeature(F_Posture, $"{Feature.FeatureNipples}{1}", Trans.Dissapearing(1000), null, true);
            //MakeNextCadre(Teller.Female, "Наконец ты пришел милый! Я уже заждалась!");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_67.ToString(), JennyFord.Mouth.Mouth1_67.ToString(), JennyFord.Eyes.EyesBlink1.ToString());//"0067"
            //MakeNextCadre(Teller.Female, "Надеюсь, у тебя все хорошо.");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_68.ToString(), JennyFord.Mouth.Mouth1_68.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0068"
            //MakeNextCadre(Teller.Male, "Неплохо, любимая... А у тебя?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            //MakeNextCadre(Teller.MaleThoughts, "Что-то моя благоверная кислая какая-то. Встревожена что ли?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            //MakeNextCadre(Teller.Female, "У меня? Ну как тебе сказать...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            //MakeNextCadre(Teller.Female, "Вообще-то, я хотела раньше тебе сказать...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            //MakeNextCadre(Teller.Female, "Ну вообщем... ты только не злись, ладно?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_71.ToString(), JennyFord.Mouth.Mouth1_71.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0071"
            //MakeNextCadre(Teller.Female, "Обещаешь?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            //MakeNextCadre(Teller.Female, "За мной ухаживают...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            //MakeNextCadre(Teller.Female, "На работе...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_72.ToString(), JennyFord.Mouth.Mouth1_72.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0072"
            //F_Posture = JFord.Blush(F_Posture, false, 5000);
            //MakeNextCadre(Teller.MaleThoughts, "Что еще за новости?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_76.ToString(), JennyFord.Mouth.Mouth1_76.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0076"
            //F_Posture = JFord.Blush(F_Posture);
            //MakeNextCadre(Teller.MaleThoughts, "и покраснела то как!...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_76.ToString(), JennyFord.Mouth.Mouth1_76.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0076"
            //F_Posture = JFord.Blush(F_Posture);
            //MakeNextCadre(Teller.Female, "... ... ... ... ...");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_76.ToString(), JennyFord.Mouth.Mouth1_76.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0076"
            //F_Posture = JFord.Blush(F_Posture);
            //MakeNextCadre(Teller.Male, "Да ты что? Ты уверена?");

            //F_Posture = JFord.GetFace(F_Posture, JennyFord.Eyes.Eyes1_77.ToString(), JennyFord.Mouth.Mouth1_77.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0077"
            //F_Posture = JFord.Blush(F_Posture, true, 5000);
            //MakeNextCadre(Teller.Female, "Ну конечно уверена!");


            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand2);
            //JennyFord_Posture = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes2_79.ToString(), JennyFord.Mouth.Mouth2_79.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0079"
            //var t = JFord.WoreNightgown(null, JennyFord.Poses.Stand2);
            //t = JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_77.ToString(), JennyFord.Mouth.Mouth1_77.ToString(), JennyFord.Eyes.EyesBlink1.ToString()); //"0077"
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
        protected void MakeFirstCadre(string fileum, Teller who, string story, bool active)
        {
            //JennyFord_Posture = JFord.WoreNightgown(null, JennyFord.Poses.Stand1);
            //JennyFord_Posture = 
            //    JFord.GetFace(JennyFord_Posture, JennyFord.Eyes.Eyes1_70.ToString(), JennyFord.Mouth.Mouth1_70.ToString(), null);
            //JennyFord_Posture.ForEach(x => 
            //{  
            //    x.S = FCurrentPosition.S;
            //    x.Y = FCurrentPosition.Y;
            //    x.X = "2000";
            //    x.T = $"{Trans.SetInvisible}>{Trans.Wait(1500)}>{Trans.Appearing(1500)}*{Trans.MoveH(1500, -1200)}";
            //});
            //JennyFord_Posture.First().T = 
            //    $"{Trans.SetInvisible}>{Trans.Appearing(1500)}*{Trans.MoveH(1500,-1200)}";
            //AddScenes(JennyFord_Posture, 1, active);
            //AddText(story, who, true, active);
            //JennyFord_Posture = JFord.ResetPosture(JennyFord_Posture);
            //IncrementGroup();
        }


    }
}



//Texture2D img;
//// Start is called before the first frame update
//void Start()
//{
//    StartCoroutine(LoadImg());
//}

//IEnumerator LoadImg()
//{
//    yield return 0;
//    img = LoadPNG(@"e:\!CATALOG\PRS\!STO GEN ART\Quuni\DATA\001.png");
//}
//// Update is called once per frame
//void Update()
//{

//}
//private void OnGUI()
//{
//    GUILayout.Label(img);
//}
//public static Texture2D LoadPNG(string filePath)
//{

//    Texture2D tex = null;
//    byte[] fileData;

//    if (File.Exists(filePath))
//    {
//        fileData = File.ReadAllBytes(filePath);
//        tex = new Texture2D(2, 2);
//        tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
//    }
//    return tex;
//}