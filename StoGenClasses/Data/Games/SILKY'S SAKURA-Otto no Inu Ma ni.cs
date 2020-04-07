
//using StoGen.Classes.Data.Movie;
//using StoGen.Classes.Transition;
//using StoGenMake;
//using StoGenMake.Elements;
//using StoGenMake.Scenes.Base;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;

//namespace StoGen.Classes.Data.Games
//{
//    public class SILKYS_SAKURA_OttoNoInuMaNi : BaseScene
//    {

//        _ALL__ScenarioText ScenatioStorage;

//        public SILKYS_SAKURA_OttoNoInuMaNi() : base()
//        {
//            Name = "SILKYS_SAKURA_OttoNoInuMaNi";
//            EngineHiVer = 1;
//            EngineLoVer = 0;
//        }

//        List<string> data = new List<string>();



//        string BG_EVENING_CABINET = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//        string BG_EVENING_STREET = "SILKYS_SAKURA_OttoNoInuMaNi_BG07"; // evening street
//        string BG_NIGHT_SKY = "SILKYS_SAKURA_OttoNoInuMaNi_BG08"; // night sky
//        string BG_MORNING_SKY = "SILKYS_SAKURA_OttoNoInuMaNi_BG12"; // morning sky
//        string BG_LOVE_HOTEL = "SILKYS_SAKURA_OttoNoInuMaNi_BG09"; // love hotel
//        string BG_MORNING_BEDROOM = "SILKYS_SAKURA_OttoNoInuMaNi_BG10"; // morning bedroom
//        string BG_DAY_BEDROOM = "SILKYS_SAKURA_OttoNoInuMaNi_BG11"; // day bedroom
//        string BG_EVENING_BEDROOM = "SILKYS_SAKURA_OttoNoInuMaNi_BG04"; // evening bedroom


//        string MAN1 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//        string MAN2 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_2";
//        string MAN3 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_3";

//        MorfableName BadMan = new MorfableName("");
//        MorfableName GoodMan = new MorfableName("");
//        MorfableName Girl = new MorfableName("");
//        MorfableName Penis = new MorfableName("");

//        bool ORGAZM = false;
//        int s = 1370;
//        protected override void LoadData()
//        {
//            ScenatioStorage = new _ALL__ScenarioText();

//            PATH_V = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Voice\";
//            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
//            PATH_E = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Effect\";

//            this.BadMan.I = "мистер Минода";
//            this.BadMan.R = "мистера Миноды";
//            this.BadMan.D = "мистеру Миноде";
//            this.BadMan.V = "мистера Миноду";
//            this.BadMan.T = "мистером Минодой";
//            this.BadMan.P = "мистере Миноде";

//            this.GoodMan.I = "дон Витра";
//            this.GoodMan.R = "дона Витры";
//            this.GoodMan.D = "дону Витре";
//            this.GoodMan.V = "дона Витру";
//            this.GoodMan.T = "доном Витрой";
//            this.GoodMan.P = "доне Витре";

//            this.Girl.I = "Ксения";
//            this.Girl.R = "Ксении";
//            this.Girl.D = "Ксении";
//            this.Girl.V = "Ксению";
//            this.Girl.T = "Ксенией";
//            this.Girl.P = "Ксении";

//            this.Penis.I = "орган";
//            this.Penis.R = "органа";
//            this.Penis.D = "органу";
//            this.Penis.V = "орган";
//            this.Penis.T = "органом";
//            this.Penis.P = "органе";


//            string gr;
//            string src;
//            string text;


//            string path = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\EVENTS\";
//            for (int i = 1; i <= 1100; i++)
//            {
//                src = $"SILKYS_SAKURA_OttoNoInuMaNi_{i.ToString("D4")}";
//                string fn = $"{i.ToString("D4")}.png";
//                AddToGlobalImage(src, fn, path);
//                data.Add(src);
//            }

//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER", "PLACEHOLDER.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01", "BM01.png", path);


//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "BM01_1.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_2", "BM01_2.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_3", "BM01_3.png", path);

//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "BM02_1.png", path);


//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "BM02_2.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "GM01_1.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "GM01_2.png", path);
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "GM01_3.png", path);


//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG01", "BG01.png", path);//blue sky
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG02", "BG02.png", path);// day office
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG03", "BG03.png", path);// evening street
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG04", "BG04.png", path);// { Evening bedroom}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG05", "BG05.png", path);// { Morning livingroom}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG06", "BG06.png", path);// { hight office}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG07", "BG07.png", path);// { hight street}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG08", "BG08.png", path);// { hight sky}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG09", "BG09.png", path);// { love hotel}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG10", "BG10.png", path);// { morning bedroom}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG11", "BG11.png", path);// { day bedroom}
//            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG12", "BG12.png", path);// { morning sky}

//            AddToGlobalImage("FLASH_BG", "WHITE.JPG", path);


//            currentGr = "Save2-1";

//            DoScenario();
//        }



//        int Size1 = 1000;
//        int Size2 = 1000;
//        int Size3 = 1000;


//        int posX1 = 0;
//        int posX2 = 0;
//        int posX3 = 0;

//        int posY1 = 0;
//        int posY2 = 0;
//        int posY3 = 0;

//        int posZ1 = 1;
//        int posZ2 = 2;
//        int posZ3 = 3;



//        private void DoScenario()
//        {
//            Cartina_HusbCall1();
//            Cartina_GoToFinancist();
//            Cartina_FirstMeetingWithFinancist();
//            Cartina_FinanceTrap();
//            Cartina_HusbCall2();
//            Cartina_EveningCall();
//            Cartina_NaughtyProposal();
//            Cartina_WalkingAfterProposal();
//            Cartina_BeforeHusbCall3();
//            Cartina_HusbCall3();
//            Cartina_Choice3_2();
//            Cartina_MorningBeforeDate();
//            Cartina_PreparationsToDate();
//            Cartina_ChangingClothInCabinet();
//            Cartina_EveningPromenad();
//            Cartina_LoveHotelBegin();
//            Cartina_FinansistHotelBlowjob();
//            Cartina_FinansistHotelFuck();
//            Cartina_MorningAfterFinansistHotelFuck();
//            Cartina_DayAfterFinansistHotelFuck();
//            Cartina_EveningAfterFinansistHotelFuck();
//        }
//        private void Cartina_FinansistHotelFuck()
//        {
//            ScenatioStorage.PATH_V = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Voice\";
//            ScenatioStorage.PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
//            ScenatioStorage.PATH_E = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Effect\";
//            ScenatioStorage.currentGr = "18.Love Hotel - second part.";
//            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();
//            Pictures.Add("PLACEHOLDER", new DifData("SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER") { S = 1370 });
//            Pictures.Add("BACKGROUND", new DifData(BG_LOVE_HOTEL) { S = 1370 });
//            Pictures.Add("MAN1_FIGURE2", new DifData(MAN2) { });
//            Pictures.Add("MAN1_FIGURE3", new DifData(MAN3) { });
//            Pictures.Add("EVENT_1063", new DifData(data[1063 - 1]) { S = 1100 });
//            Pictures.Add("EVENT_1097", new DifData(data[1097 - 1]) { S = 1100 });

//            Dictionary<string, MorfableName> names = new Dictionary<string, MorfableName>();
//            names.Add("Girl", Girl);
//            names.Add("BadMan", BadMan);
//            names.Add("GoodMan", GoodMan);
//            names.Add("Penis", Penis);
//            ScenatioStorage.Cartina_FinansistHotelFuck(Pictures, names);
//            ScenatioStorage.DoFilter(new string[] { ScenatioStorage.currentGr });
//            this.AlignList.AddRange(ScenatioStorage.AlignList);

//        }

//        private void Cartina_FinansistHotelBlowjob()
//        {
//            ScenatioStorage.PATH_V = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Voice\";
//            ScenatioStorage.PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
//            ScenatioStorage.PATH_E = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Effect\";
//            ScenatioStorage.currentGr = "17. Finansist hotel blowjob.";
//            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();            
//            Pictures.Add("PLACEHOLDER", new DifData("SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER") { S = 1370 });
//            Pictures.Add("BACKGROUND", new DifData(BG_LOVE_HOTEL) { S = 1370 });
//            Pictures.Add("MAN1_FIGURE1", new DifData(MAN1) { });            
//            Pictures.Add("EVENT_0042", new DifData(data[0042 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0043", new DifData(data[0043 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0044", new DifData(data[0044 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0045", new DifData(data[0045 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0046", new DifData(data[0046 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0047", new DifData(data[0047 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0048", new DifData(data[0048 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0049", new DifData(data[0049 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0050", new DifData(data[0050 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0051", new DifData(data[0051 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0052", new DifData(data[0052 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0053", new DifData(data[0053 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0054", new DifData(data[0054 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0055", new DifData(data[0055 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0056", new DifData(data[0056 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0057", new DifData(data[0057 - 1]) { S = 1370 });
//            Pictures.Add("EVENT_0058", new DifData(data[0058 - 1]) { S = 1370 });
//            Dictionary<string, MorfableName> names = new Dictionary<string, MorfableName>();
//            names.Add("Girl", Girl);
//            names.Add("BadMan", BadMan);
//            names.Add("GoodMan", GoodMan);
//            names.Add("Penis", Penis);
//            ScenatioStorage.Common_Blowjob_01(Pictures, names);
//            ScenatioStorage.DoFilter(new string[] { ScenatioStorage.currentGr });
//            this.AlignList.AddRange(ScenatioStorage.AlignList);
//        }

//        private void Cartina_HusbCall1()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            AddCadre(1001, "Kohei~Я доверяю тебе. Конечно, если тебе понадобится моя помощь, сразу скажи.");
//            AddCadre(1001, "{Girl}~Да, в этот раз, пожалуйста ... ... Кохей-сан.");
//            AddCadre(0991, "В ситуациях, когда я не могу стать силой, это, безусловно, будет поворот Кохей-сан.");
//            AddCadre(0991, "Но я не полагаюсь на это с самого начала, я хочу делать то, что могу сделать для себя.");
//            AddCadre(0991, "Я верил и признался, для Асахи.");
//            AddCadre(0991, "{Girl}~Спасибо, Кохей-сан. Было хорошо поговорить.");
//            AddCadre(0992, "Kohei~Благодарю за меня. Заботиться о моей сестре об этом ... ....");
//            AddCadre(0992, "{Girl}~Потому что Асахи тоже важная сестра? Это естественно.");
//            AddCadre(0991, "Kohei~Ха-ха, я буду рад, если ты так скажешь.");
//            AddCadre(0991, "{Girl}~Хих");
//            AddCadre(0991, "Я чувствую себя спокойно, несмотря на возможность поговорить с г-ном Кохеем.");
//            AddCadre(0991, "Может быть, я был слишком в восторге от того, чтобы стать силой Асахи, может быть, это было немного сложно.");
//            AddCadre(0991, "{Girl}~Что ж, если что-то я снова свяжусь с вами?");
//            AddCadre(0991, "Kohei~Точно. Конечно, я зря беспокоюсь.");
//            AddCadre(1011, "{Girl}~Спасибо, мистер Кохей ... Я люблю тебя. ");
//            AddCadre(1014, "Kohei~Я тоже ... ... Я люблю тебя, Яой. Хорошо, спокойной ночи.");
//            AddCadre(1014, "{Girl}~Да, спокойной ночи ... Yayoi");
//            AddCadre(1014, "Встряхните маленькую руку на экране, Кохей-сан отрезал видео-чат.");
//            AddCadre(1046, "{Evening bedroom} {Girl}~Итак ... Хорошо, давайте сделаем все возможное ...!");
//            AddCadre(1046, "{Evening bedroom}~Давайте попробуем все возможное, чтобы сделать все возможное, чтобы восстановить полную улыбку Асахи.");
//            AddCadre(1046, "{Evening bedroom}~В видеочате с Кохей я так чувствовал.");

//            ClearSound();
//        }
//        private void Cartina_GoToFinancist()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            AddCadre(0000, "{Morning street}~Через два дня контакт Асахи-чан вошел в место владельца автомобиля вместе.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~Успокойся, Асахи-чан? Хорошо, потому что я буду говорить с вами правильно.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}Асахи~Ну, да... ....Спасибо, мистер Яойи ... ...");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У Асахи есть взгляд, который выглядит довольно серьезным, и ее цвет лица выглядит как кровь.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Когда я подумал, что это было непросто, мое сердце сжалось.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(В конце концов я волнуюсь ... ...)");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Мне определенно нужно как-то справляться.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Асахи не просто сестра Кохея, у меня для меня особое чувство.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители г-на Кохей и Асахи строги.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители не выступали против себя в то время, когда они вступили в брак со мной, которая была супер-частью в то время, но они не активно благословляли меня агрессивно.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Среди них Асахи-чан просто сделал меня счастливым и благословил нас.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Нет ничего несчастного, как брак, который не благословляется от другой семьи.");
//            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Как я чувствовал это, благословение от Асахи было действительно счастливым.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(Асахи-чан был там, это как я поженился)");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Поскольку Асахи благословил меня, я думаю, что смог выйти замуж.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У меня все еще мало обмена с родителями, но мне интересно, будут ли дети сделаны в будущем, это обязательно изменится.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(Потому что моя мама с нетерпением ждет этого ... ...)");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Для родителей Кохея также, если мы можем иметь детей, мы становимся первыми внуками.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Это наверняка понравится, и я почувствовал, что изменил бы то, как я отношусь к различным вещам.");
//            AddCadreAoiAsahi(1046, 1020, "{Morning street}Asahi~Это похоже на это здание.");
//            AddCadreAoiAsahi(1046, 1019, "{Morning street}Яйой~Здесь ...");
//            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Адрес, который сказал Асахи, был зданием скалы в месте, подобном району красного света в городе.");
//            AddCadreAoiAsahi(1046, 1019, "{Morning street}{Girl}~Ну, тогда пойдем ли мы?");
//            AddCadreAoiAsahi(1046, 1019, "{Morning street}Асахи~Ну, да ...");
//            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Я вошел в здание, чтобы привести Ашиги в нервное состояние.");

//            ClearSound();
//        }
//        private void Cartina_FirstMeetingWithFinancist()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            AddCadre(000, "{Morning cabinet}~В комнате, казалось, был офис, который обставил мебель, которая, казалось, была высокой, и имела какую-то сомнительную атмосферу.");
//            AddCadre(000, "{Morning cabinet}~В этой комнате Асахи-чан сталкивается с владельцем автомобиля, который поцарапан.");
//            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}Wisterie~Добро пожаловать, г-н Кимишима. Там ... ... ");
//            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Поговорив с Асахи-чан, человек владельца увидел меня");
//            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}{Girl}~Это невестка Йошио Кимишимы. Сегодня я сопровождаю ее ...");
//            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Позволь мне скрыть испуганного Асахи спиной, я пойду вперед и поприветствую.");
//            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}{Girl}~?");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Вижу, я был женат ... ... Это было давно, вы знаете?");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~После небольшого удивления, увидев меня, я так внезапно говорю.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Интересно, встретил ли я где-нибудь.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Разве ты не помнишь?");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~... ... Ах!");
//            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Я вспомнил. Конечно, этот человек является одним из партнеров, которые мои родители заимствовали.");
//            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}{Girl}~... ... конечно, мистер Миното ...?");
//            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}Wisterie~Да, это так. Ни в коем случае, что ты был тем, кем был женат, был ее старший брат.");
//            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Глядя на Чирари и Асахи, которые прятались позади меня, Мидода говорит так и улыбается.");
//            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}{Girl}~Ну, это было давно ... Извините, я не могу сразу вспомнить ...");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Ну, я не собираюсь встречаться с тобой напрямую.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Г-н Ито был одним из партнеров, который смог занять деньги у родителей, которые не смогли выполнить проект в деньгах.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Я приходил домой несколько раз, и я обменивался приветствиями.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Но не было памяти, о которой я говорил правильно, и я едва мог вспомнить свое имя, но это почти исчезло из моей памяти.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Мистер Кимисима, нет, теперь ты Кимишима-сан. Я думал, что придут ее родители.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~То, что обстоятельства ее родителей неудобны, интересно, послушаю ли я историю.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Хм ... Ну, может быть. Потому что есть и история, давайте сядем и поговорим об этом.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~Да, извините ... ... Асахи-чан? ");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Асахи~Ну, да ... ");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Г-н Асада, одетый в неповторимую атмосферу перед мистером Ито, совершенно пьян.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Напряжение достигло пика, или казалось, что ее цвет лица ухудшается.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Яйой~(Если я не уверен ... ...) ");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Особенно это был не перевод, который был связан, но он был хорошим не партнером, которого я вообще не знаю.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Я вспомнил о себе, и было бы легко говорить.");
//            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~На данный момент я был соблазнен мистером Миното и сел на кожаный диван, похожий на стойку регистрации.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Как далеко вы слышали от нее?");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Яйой~Ах, я в порядке с Яой. Yayoi");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Ну, тогда я могу назвать тебя Яйо?");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Да. Хм, я думал, что минодо поцарапал его машину ... поэтому мы попросили о консультациях по поводу расходов на ремонт. ");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Рассказ идет быстро, если вы его слушаете.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Минодо кивает и достает что-то вроде документа.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Это оценка ремонта, полученная от производителя.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Благодарю вас. ");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Документы с иностранными языками отмечены автомобилями, которые я не знаю.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~... ... Это ... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я не знаю, где это, и я даже не знаю единицы денег в первую очередь.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Говорят, что это составляет около 30 тысяч евро, общая стоимость транспортировки и стоимость ремонта.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Является ли ... ... 30 тысяч евро? ... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если я попрошу эту сумму, я не прихожу с булавками.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Сколько будет стоить японская иена евро?");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я наклонил шею рядом со мной, хорошо ли понял Асахи.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Сегодняшний курс ...... Это около 3750 000 иен, переведенных в японскую иену.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Рассматривая смартфон, г-н Сада сказал, что Сара такая.");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Скажи, сноб.? ");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Что, Junjun!?");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Только с ограниченным цветом я не могу перекрасить только часть. Я должен перевезти его на родину и раскрасить.");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Ну, но ... это так много ...?! ? ");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Вау, я, немного, просто царапина ...! ");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Сама царапина была маленькой. Но сверх того, что я думал, было глубоко включено. Поверхностный ремонт не вернется к оригиналу.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~Это ... ... такое ... ... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~Как вы поживаете, Yayoi san ...... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асахи полностью потерял кровь и имел бледно-синее лицо.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Поскольку это оценка ремонта от официального производителя, вы можете принять ее. Потому что вы можете это взять.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Это так, или это ... ... Но эта сумма денег ... Это действительно необходимо ...? ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Учитывая цену кузова, она дешевая. Этот автомобиль, цена покупки более чем в десять раз больше.");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Ну, это дорого! ? ");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Ю, в десять раз ... ... Я куплю тебе дом ...! ? ");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Я удивляюсь, когда собираются два человека.");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Мне сказали, что это дорогая иномарка, но это был не такой роскошный автомобиль.");
//            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Ноги Асахи, сидящие рядом со мной, дрожали от щетинок.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Не расстраивайся до меня до конца.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Это то, что я подумал, но, просто глядя на сумму денег, моя внутренняя часть головы стала белой.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Должен ли я говорить о конкретной компенсации, если в ней нет проблемы?");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}{Girl}~Ах, что ... ... сумма - это сумма, так зачем платить сразу ... ");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Г-н Кохей и г-н Кохей хранят столько, сколько они есть, но это не очень хорошо, но я не могу заплатить.");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Вероятно, я посоветуюсь с моими родителями, но я до сих пор не знаю, смогу ли я заплатить сразу.");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Хм ... ...");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}{Girl}~Не решите ли вы заплатить, разделив ...? ");
//            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Если вы не заплатите расходы на ремонт, автомобиль не вернется ко мне, но должен ли я выполнять процедуру разделения самостоятельно?");
//            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Яйой~Гм ... ... что, что ... ... ");
//            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}~Разумеется, как говорит г-н Минато, место для оплаты стоимости ремонта - это автомагазин, поэтому мы должны попросить вас там.");
//            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Wisterie~Ну, затраты на ремонт могут быть погашены мной.");
//            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}{Girl}~Это правда? ? ");
//            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}Wisterie~У меня будут проблемы, если машина не вернется.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Это так? ... Мне жаль беспокоить вас, но я буду спасен, если вы это сделаете. ");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Сумма стоит дорого, но она не будет выплачена, если она будет разделена.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Проблема заключается в количестве разделов.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Это совсем не так, как если бы вам сказали, что вы платите в два или три раза.");
//            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Конечно, вам нужна определенная уверенность в том, что вы можете заплатить это твердо.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~Хм ... ... Правильно, не так ли? ... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Способ говорить нежен, но есть мощные слова и голоса, которые не позволяют вам говорить.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже когда я разговаривал с родителями в доме моих родителей, я даже не портил свой голос спокойным тоном, но у меня было немного страшное впечатление.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Коллекции различных долгов приходили в дом моих родителей, но было что-то общее для этих людей.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~(Поскольку он, кажется, поделен в любом случае, посоветуйтесь с ним впоследствии ... ...) ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Нам нужно поговорить с г-ном Кохеем, и мы должны поговорить с обоими родителями.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асахи может не любить, но погашение этой суммы не может быть сделано моим собственным суждением.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~, Yayoi san ... ...., Если это нормально с разделением, то ... ... ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Пораженный ценой, Асахи, который полностью испугался, хочет принять слова минодо.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я еще не слышал о методе погашения, и я думаю, что здесь нехорошо решать.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я чувствовал, что это будет неприятно, если бы я консультировался только с Кохеем.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~(Но на этот раз Kohei все еще работает ... ...) ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~У меня не было много времени. Если это нормально держать в вертикальном положении, я бы хотел, чтобы вы ответили так.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Если вам интересно, что делать, г-н Миното также должен будет ответить.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~И Yayoi ... ...! ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асака крепко держит мою руку.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Потная рука дрожала, и я почувствовал разочарование в глазах, глядя на меня.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~(Ну, во всяком случае, вы должны заплатить ... ne.) ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если родители Асахи были необоснованны, я должен был что-то сделать.");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Ничего себе .... ОК. Я верну его, разделив, поэтому, пожалуйста, измените его. ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Я понимаю. Давайте подготовим документ сразу. ");
//            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Вот и все, мистер Муто встает.");
//            AddCadre(0000, "{Morning cabinet}~……");
//            AddCadre(0000, "{Morning cabinet}~……");
//            AddCadre(0000, "{Morning cabinet}~……");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~Вот и подпись здесь.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Некоторое время он был заимствован для мистера Миноды.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Конечно, общая стоимость ремонта.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Я заимствовал его у мистера Мито.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Асахи~Г-н Яойи ...... ");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Я понимаю ... ");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Меня радует нетерпеливый голос Асахи, я подписываю заимствованное письмо.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~...... Официальный документ находится на более позднем этапе, поэтому сегодня я его принимаю.");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Да ... ");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~Я хотел бы снова связаться с вами, но было ли лучше для вас, Яой?");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Ну, это так, пожалуйста, сделайте это со мной. ");
//            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Мы обменялись контактами с г-ном Маото, и обсуждение расходов на ремонт завершено.");

//            AddCadre(1016, "{Day street}Асахи~Yayoi, Большое вам спасибо ... Если бы я был один, я не мог бы говорить правильно ... ", -270);
//            AddCadreAoiAsahi(1049, 1016, "{Day street}{Girl}~Хорошо, это примерно ...... ");
//            AddCadreAoiAsahi(1049, 1016, "{Day street}~Асахи - чан, казалось, с облегчением почувствовала, решила ли она, что проблема решена.");
//            AddCadreAoiAsahi(1049, 1016, "{Day street}~Но я знаю, это тяжелая работа с этого момента.");

//            AddCadre(0000, "{Blue sky}~Через несколько дней после подписания взятой записки -");
//            AddCadre(0000, "{Blue sky}~Когда мне сказали, что я хотел бы поговорить о погашении, я пошел в кабинет минодо.");

//            ClearSound();
//        }
//        private void Cartina_FinanceTrap()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~О ... о ... да ... Извините. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Ну, это мгновение ... ... вкус не должен быть плохим.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот почему сам мистер Ми Ито сам кофе.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Не было абсолютно никакого места, чтобы осмотреться, но в этом офисе есть только стол мистера Миното.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Гм ... ... Ты работаешь одна? ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~── О, я был один.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это так правильно? ... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~У меня есть вещи в доме моих родителей и даю мне деньги, но какая работа вы здесь делаете?");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Место, где это место, также является местом, которое находится на одном шагу от входа в центр города, а не в офисный город.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это было многолюдное здание с несколько подозрительной атмосферой, и была атмосфера, в которой я ничего не мог сказать.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я хотел бы подтвердить это как можно скорее. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Да ... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Г-н Минато так сказал и достал документ.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Письмо было напечатано и написано как соглашение о заимствовании.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Хм, это ...? ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~На днях я заимствовал написанное вами письмо, сделав его официальным документом.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это официальный документ ... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот что я сказал, я снова посмотрю на это.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Что-то трудное написано, и я даже не знаю, с чего смотреть.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Хорошо, давайте проверим их. Если есть моменты, о которых стоит беспокоиться, вы можете поговорить позже позже.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Да ... ... Пожалуйста ... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато также сел на диван и объяснил о соглашении о заимствовании.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Контент состоял в том, что я заплачу все деньги, которые он взял за ремонт автомобиля, заимствованный у мистера Мито.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это означает, что мы заимствуем у мистера Мито, используя его для расходов на ремонт ... не так ли? ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~О, вот и все. И ты вернешь его мне. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Да ... ... Но эта сумма ...... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Сумма, написанная там, была больше, чем предыдущая история.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Кроме того, доля, называемая процентными ставками, увеличивается, а в части, записанной как ежемесячная сумма погашения, была написана сумма, которую я не представлял.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Из-за обесценения йены на нее влияет обменный курс. Кроме того, это только оценка до последней.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Ну, это правильно .... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я не совсем понимаю, интересно, это что-то в этом роде.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Конечно, по телевизионным новостям, я чувствую, что обесценивание йены продолжается, и импортируемые продукты растут, я говорил о такой истории.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Стоимость ремонта автомобиля может быть такой же.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Но проблема была не в сумме, а в ежемесячной сумме погашения.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Ах, это ... ... Это ежемесячная сумма погашения, но ее трудно заплатить ... ... Можете ли вы продлить срок погашения еще немного ...? ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~В текущем документе период погашения составляет один год.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Ежемесячная сумма погашения была больше, чем бюджет нашей семьи.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Но у меня не было больше времени на погашение.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Это ... ... Такое ... ... Но эта сумма невозможна ...... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~У вас нет проблем, даже если вы так говорите. Вы сказали, что заплатите, разделив вас, и вы ничего не сказали о периоде погашения?");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Это ...! Да, но ... ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Тонус г-на Минато спокоен, и голос ее холодный.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Я помню атмосферу, когда я был где-то в доме родителей.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(В те дни, когда я разговаривал с отцами, это было так ...) ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Это было потрясающе, и это не стало эмоциональным, но было такое впечатление, что остров не существует.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(Интересно, что я должен делать ...... Такая сумма, не очень ... но ...) ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Разумеется, вам, возможно, придется подумать о том, как погасить его, консультируясь с Kohei-san и вашими родителями.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Асахи может не нравиться, но я не мог сделать ничего, что мог.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Ну, пока это консультации по конкретному методу погашения, я не соглашусь, конечно. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Эх ...... ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Есть много способов оплаты. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато сказал так и улыбнулся.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это должна быть улыбка, но это выглядело как очень ослепительное выражение.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~(Что вы делаете ... ...) ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Интересно, следует ли мне поговорить с г-ном Минато о методе погашения, как есть.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Однако, похоже, это не простой метод погашения.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Когда я услышал эту историю, я почувствовал, что больше не могу вернуться.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Вы решаете, что делать, вы решаете.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Это ... ... ");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Минато говорит так, но я не думаю, что у меня есть варианты.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Конечно, может быть, я действительно понял, что говорю, но я не могу избавиться от беспокойства.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~(...... Kohei Mi)");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Лицо Коэи перешло мне в голову, когда меня мысленно преследовали.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Если Кохей-сан, он может как-то справиться.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Даже г-н Минато может обсудить это должным образом.");
//            AddCadreAoiMinodo(1050, "{Morning cabinet}~Хотя я не хочу неудобств, если я не проконсультируюсь здесь, это может вызвать еще большие неудобства.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}{Girl}~Ах ... ... это ... Пожалуйста, позвольте мне поговорить с моей семьей однажды ... ... ");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Мне удалось выжать мой голос и рассказать Миото.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~...... Где будут меняться условия консультаций?");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}{Girl}~Да, но ... время от времени ... Я просто хочу поговорить ... ");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Чтобы не пить власть минодо, отчаянно старайтесь отважиться.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Если вы можете доверять г-ну Кохеи, вы наверняка сумеете что-то сделать.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Я могу сделать это, чтобы не спешить с заключением здесь, но как-нибудь вернуться домой.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~Это так? В этом случае давайте подождем ответ до конца этой недели.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}Яйой~Ох ... О, спасибо ... ");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Наконец г-н Минато принял мою просьбу.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~Отчаянно стимулируйте освобождение и держите его в секрете, не ставя его на лицо.");
//            AddCadreAoiMinodo(1051, "{Morning cabinet}~С этим мне удалось заработать время, чтобы поговорить с Kohei-san каким-то образом.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Хорошо, тогда я извиню себя. ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я был в отчаянии говорить спокойно, так что я не мог понять, когда я торопился.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я ожидаю ответа как можно скорее.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минодо не выражает ничего выражения, и я не совсем уверен, что вы думаете.");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~(Во всяком случае, давайте поговорим с Кохей ... ...) ");
//            AddCadreAoiMinodo(1049, "{Morning cabinet}~С этой мыслью я быстро пришел домой.");

//            ClearSound();
//        }
//        private void Cartina_HusbCall2()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


//            AddCadre(0000, "{Evening bedroom}~Ночью той ночью я был готов ругать Кохея, и я все признал.");
//            AddCadre(0998, "KoheiЭто должно было случиться. ");
//            AddCadre(0998, "{Girl}~Мне очень жаль, я что-то ранил ... Я не хотел беспокоить вас дополнительными неудобствами, но так получилось ... ");
//            AddCadre(0998, "Мне было очень жаль, что он не беспокоил мистера Кохея, который занят работой.");
//            AddCadre(0997, "Kohei~Потому что ты собираешься думать об Асахи, не так ли? Все в порядке, я знаю. ");
//            AddCadre(1002, "Яйой~Кохей-сан ...! Э-э ... Э-э ... Го ... ... ");
//            AddCadre(1002, "Это был предел, который я мог переносить своими слезами.");
//            AddCadre(1001, "Kohei~Тебе не нужно плакать, я не думаю об этом. ");
//            AddCadre(0996, "{Girl}~Но, я ... .... ");
//            AddCadre(0997, "Kohei~Вместо этого, я хочу проверить, что это похоже на этот контракт, поэтому я хочу, чтобы вы отправили его на персональный компьютер и отправили его ... .... ");
//            AddCadre(0997, "{Girl}~Ну, ты можешь это сделать ... ....? ");
//            AddCadre(0997, "Я чувствовал, что мне кое-что было сказано несколько сложнее.");
//            AddCadre(0997, "Kohei~Это не так сложно, так что все в порядке. Рядом с компьютером есть принтер, верно? ");
//            AddCadre(0997, "{Girl}~Принтер об этом ... ...? ");
//            AddCadre(0997, "Kohei~Правильно. Когда откроется это место, мне интересно, разместите ли вы там документ. ");
//            AddCadre(1002, "{Girl}~Er ... ... документ ...... ");
//            AddCadre(1002, "Будучи объясненным Кохей, я сделаю то, что сказал.");
//            AddCadre(1002, "Г-н Кохей научил меня осторожно, не используя как можно больше технических терминов.");
//            AddCadre(0000, "{Black screen}~....");
//            AddCadre(0000, "{Black screen}~.... ....");
//            AddCadre(0000, "{Black screen}~.... .... ....");
//            AddCadre(0991, "{Girl}~Итак, нажмите здесь, в конце ... ... Ах, это сработало! ");
//            AddCadre(0991, "Kohei~Да, это звучит неплохо. Он автоматически переключился на мой смартфон, так что все в порядке. ");
//            AddCadre(0991, "{Girl}~Это так? Это было хорошо ...");
//            AddCadre(0993, "Kohei~Действительно, соглашение о заимствовании ... ... Хм ... ...");
//            AddCadre(0993, "Г-н Кохей смотрит на документы, которые я взял, и имеет сложное выражение.");
//            AddCadre(0998, "{Girl}~(Kohei-san ......)");
//            AddCadre(0998, "Я молчал и уставился на экран моего компьютера, чтобы это не мешало этой идее.");
//            AddCadre(0998, "Kohei~Контактный номер другой стороны - это номер, написанный здесь, не так ли? ");
//            AddCadre(0998, "Яйой~Эх, да .... ");
//            AddCadre(0997, "Kohei~Я понимаю. Хорошо, тогда я попытаюсь как-нибудь попытаться. ");
//            AddCadre(1002, "{Girl}~ぅ ...... Извините, я занят ... ");
//            AddCadre(1002, "Kohei~Первоначально это проблема, поднятая Асахи, вам не нужно столько страдать.");
//            AddCadre(1002, "{Girl}~Кохей-сан ...... ");
//            AddCadre(1001, "Kohei~Я свяжусь с вами снова, если что-то будет. В любом случае, мне больше не нужно волноваться, поэтому не смотрите на меня так, я хочу, чтобы вы улыбались, как обычно. ");
//            AddCadre(1006, "{Girl}~... .... Да, спасибо ... ... ты. ");
//            AddCadre(1006, "Слезы, казалось, переполнились добрыми словами Кохея.");
//            AddCadre(1006, "Но если ты заплачешь, Кохей-сан будет грустно.");
//            AddCadre(1006, "С чувством сожаления и благодарности, на мой взгляд, я улыбнулся.");
//            AddCadre(1009, "Kohei~Да, улыбка - лучшая для Яйоя. Ну тогда, спокойной ночи ... Я люблю тебя. ");
//            AddCadre(1014, "{Girl}~Я тоже тебя люблю, ты ... ... Не подталкивай себя? ");
//            AddCadre(1011, "Хорошо, даже если вы выглядите так, ваше тело сильное.");
//            AddCadre(1011, "Несмотря на то, что я занят только работой, я действительно занят, полагаясь на неприятные вещи.");
//            AddCadre(1011, "Тем не менее, Кохей-сан улыбался с другой стороны экрана ПК, сказав это.");
//            AddCadre(1011, "Яйой~(На самом деле спасибо, Кохей-сан ... ...) ");

//            ClearSound();
//        }
//        private void Cartina_EveningCall()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            AddCadre(0000, "{Evening livingroom}~После нескольких дней Кохей-сан получил телефонный звонок.");
//            AddCadre(1049, "{Evening livingroom}{Girl}~Алло ......?");
//            AddCadreAoiKohei(1049, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Я подумал, что было бы лучше спешить, поэтому я позвонил ей. Теперь все в порядке?");
//            AddCadre(1049, "{Evening livingroom}{Girl}~Эх, да .... ");
//            AddCadre(1049, "{Evening livingroom}~Потому что я знаю, что это мистер Минодо, я нервничаю, когда звоню с Кохеем.");
//            AddCadre(1049, "{Evening livingroom}~Рука с телефоном слегка дрожала.");
//            AddCadreAoiKohei(1049, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Скажу до заключения? Что касается расходов на ремонт, я думаю, что я уменьшу сумму.");
//            AddCadre(1048, "{Evening livingroom}{Girl}~Эх ...! ? Это так ...? ");
//            AddCadreAoiKohei(1048, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~В документах были различные недостатки, я указал, что мы тоже пришли с другой стороны.");
//            AddCadre(1048, "{Evening livingroom}{Girl}~Я вижу ... ничего себе ... ... ");
//            AddCadre(1048, "{Evening livingroom}{Girl}~В моем сознании не было ничего, чтобы выяснить легитимность суммы.");
//            AddCadre(1048, "{Evening livingroom}{Girl}~I think that Mr. Kohei is great, after all, to think of such a thing.");
//            AddCadreAoiKohei(1048, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Although it can not be said that repair expenses are escaped as expected, I think that it can be suppressed to some extent");
//            AddCadre(1048, "{Evening livingroom}{Girl}~Thank you, Kohei-san ... I can not believe it. I am sorry, let me take time and effort on this ... ... ");
//            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~No, I am the one who apologizes. I'm really sorry I can not stay by my side");
//            AddCadre(1046, "{Evening livingroom}{Girl}~When I apologize at the phone entrance, on the contrary Kohei apologizes to Mr. Kohei.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~It was a feeling that my heart was tightened to that voice that seemed to be sorry.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~No, that's not the case ....");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~But I guess I was worrying a lot? I was able to do something if I was by my side ... ... ");
//            AddCadre(1050, "{Evening livingroom}{Girl}~You ... ...");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Tears seemed to be overflowing with the thought of Kohei's me.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~(I can not bother you any more any more ... ...)");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Even though I am busy with work, I do not want to put an extra burden.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~The problem is the remaining amount and how to repay it ..");
//            AddCadre(1050, "{Evening livingroom}{Girl}~... ... Do not worry, you. If I can keep even the amount, I will have it.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "{Evening livingroom}Kohei~Is that so?");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Yes. Mr. Minoto also does not know anything at all, so I will say that the concrete repayment method will ride in consultation.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~I see ... okay, but are you all right?");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Kohei - san 's voice on the phone's door seemed really worried.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Even just listening to such a voice, I feel sorry and my chest tightened.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Uhufu, all right. But thank you very much. Thanks to Kohei - san, it is likely to manage somehow. ");
//            AddCadre(1050, "{Evening livingroom}{Girl}~It was good not to be a video chat.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~I can do it with words, but I did not have confidence to pretend to expressions.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~...... If Yayoi says so, I will believe it.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Thank you, you ... ....");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~...... But if it seems to be a difficult thing, do not hesitate to ask me for consultation. I am going to do not want labor if it is for you. ");
//            AddCadre(1050, "{Evening livingroom}{Girl}~... Yeah, I know.");
//            AddCadre(1050, "{Evening livingroom}~Kohei-san said that, I decided to do something about it myself.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Well then, please contact me if there is something again.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~Yes, I know. Um ... ... Thank you for your concern, you. ");
//            AddCadre(1050, "{Evening livingroom}~To the voice worried voice of the phone mouth, with the meaning of making the peace of mind, put it in words and convey it.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~I really appreciate Mr. Kohei.");
//            AddCadre(1050, "{Evening livingroom}{Girl}~I always feel annoying and burdening always, I think I'm really sorry, I wonder if I can return it properly.");
//            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~We are couple, so do not say anything strangely like that. ");
//            AddCadre(1050, "{Evening livingroom}~Finally it got a little light tone, Kohei-san said so.");
//            AddCadre(1046, "{Evening livingroom}{Girl}~Hehe ... ... That's right, it is a couple.");
//            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~that's right. I think that it is a couple who will help each other.");
//            AddCadre(1046, "{Evening livingroom}{Girl}~I think so too .... ");
//            AddCadre(1046, "{Evening livingroom}~That is why I also want to become Kohei's power properly.");
//            AddCadre(1046, "{Evening livingroom}~In order to support Kohei - san who is tough work, I also have to work hard so that I do not increase the extra burden.");
//            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Well then, I have preparation for tomorrow, so I will cut it soon.");
//            AddCadre(1046, "{Evening livingroom}{Girl}~Yeah ... Good night, Kohei-san.");
//            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Good night, Yayoi.");
//            AddCadre(1046, "{Evening livingroom}~Kohei's voice, saying good night, is really relieved.");
//            AddCadre(1046, "{Evening livingroom}~I'd like to listen forever, but surely I will be busy working tomorrow, so it is not good to tell me.");
//            AddCadre(1046, "{Evening livingroom}~I trimmed my disappointing feeling behind my heart and I softly pushed the call button.");
//            AddCadre(1046, "{Evening livingroom}{Girl}~Fuh ... ... Thank you so much, Kohei-san ......");
//            AddCadre(1046, "{Evening livingroom}~After that I have to do something with my own power.");
//            AddCadre(1046, "{Evening livingroom}{Girl}~I clutched the broken phone and I thought so strongly.");

//            ClearSound();
//        }
//        private void Cartina_NaughtyProposal()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            // ANTRACT=============================================================
//            Size1 = 1500; posX1 = -70;
//            // music.arc_000007.wav
//            //voice?
//            AddCadr(1049, null, "{Morning street}{Girl}~(I have to work hard to negotiate ... ...) ");
//            AddCadr(1049, null, "{Morning street}~I have thought of various things, but after all we have to pay by dividing.");
//            AddCadr(1049, null, "{Morning street}~Because of Kohei - san, it seems that the amount can be lowered, but it is still not an amount that can be paid in bulk.");
//            AddCadr(1049, null, "{Morning street}~The problem is the repayment period of the money borrowed from Mr. Mito.");
//            AddCadr(1049, null, "{Morning street}~I can not pay for it unless I keep it as long as possible.");
//            AddCadr(1049, null, "{Morning street}~Of course I did not mean to pay Kohei-san's salary, I planned to go to the part again.");
//            //voice?
//            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "{Girl}~(The store manager says it is not enough manpower ... ...)");
//            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "The amount of repayment about the amount that can be earned for the part at the supermarket was my ideal.");
//            AddCadr(0, null, "...");
//            AddCadr(0, null, "... ...");
//            AddCadr(0, null, "... ... ...");

//            //music.arc_000005.wav
//            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When I visited Mr. Minodo's office, I was kept waiting a while because I was working.");
//            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even while sitting on the sofa and waiting, the tension is rising.");
//            Size1 = 1500; posX1 = 300;
//            Size2 = 0715; posX2 = 155; posY2 = 55;
//            //effect.arc_000020.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I am sorry, I have kept you waiting.");
//            //voice? voice.arc_000550.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Good, but... ...");
//            //voice? voice.arc_000551.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you talk with sincerity, you should know Mr. Minodo.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I thought so, but the idea was a bit sweeter.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I received a message from my husband. You seemed to know a lot?");
//            //voice? voice.arc_000552.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Oh ... oh, yes ... ... that job, finance related work ...");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Indeed, that's what it is.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Although I do not show much on facial expressions, Mr. Muto's voice seemed a little sullen.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps what asked to Mr. Kohei might have been damaged by tantrums.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~So, can we talk a specific story today?");
//            //voice?  voice.arc_000553.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Yes ... .... Um, I can not pay in bulk, so I thought that I would like to split ... so we pay monthly payment ...... ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If the previous borrowing agreement is invalid, there is no reason to accept it.");
//            //voice? voice.arc_000554.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well ... but, but ... ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The money may be the one the husband has said, but instead you will be paid in bulk.");
//            //voice? voice.arc_000555.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well ... that! I can not do it ...!");
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, if you say that you can not pay, you just have to pay her again.");
//            //voice? voice.arc_000556.ogg
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~She's ... Asahi-chan! What? Such a terrible ... ...! ");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~What is terrible? Do you think that the victim is me?");
//            //voice? voice.arc_000557.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well, that was ... .... Well, it was ... .... Excuse me ......");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even though the tone was calm, there was a tremendous force in the voice.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as Mr. Minato is surely the one who has been hurt by the car, it is incorrect to say that it is awful.");
//            //voice? voice.arc_000558.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~But Asahi-chan .... It's impossible for her, please somehow split it ... ....?");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I wonder if she has parents, too? If that is difficult, you may consult your husband again.");
//            //voice? voice.arc_000559.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well, that's in trouble ....");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wonder what I should do.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is not the amount that I can pay for Asahi and I'm sorry to consult Kohei.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you go to the home of the Kimishima family to consult, Asahi will also be sad, and as a result it places a burden on Kohei.");
//            //voice? voice.arc_000560.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(I want to manage it by myself, but ... ...)");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I would like to make it monthly repayment at some amount to earn part-time.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "How can I accept Mr. Muto from it?");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While I felt my back getting wet with cold sweat, I was desperately thinking.");
//            //voice?  voice.arc_000561.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~I will do anything I can ... ... I will pay all the repair expenses as well, so why can not you do something ...?");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But I can not think of anything in my head.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As Kohei-san, there was nothing to solve the problem.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~That's right.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Then, Mr. Minoto starts looking at something with a difficult expression.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps, will he step up.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "So expecting while waiting, I will look like Mr. Minoto's sharp eyes shoot through me.");
//            //voice?  voice.arc_000562.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~ぅ ...");
//            //music.arc_000004.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If you ... ... If Yayoi will be mine for only a week, I do not mind drinking that condition.");
//            //voice?  voice.arc_000563.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~! What?");
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even if it is dull, I know what it means.");
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I do not think that I should say such a thing, I am surprised that I will not speak at once.");
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~what will you do?");
//            //voice?   voice.arc_000564.ogg
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Mum ... It is impossible! I can not do that ...! Wow, my husband is ... ...!");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When refusing to return to me, unexpectedly Mr. Minoto nods with conviction.");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, it will be.");
//            //voice?  voice.arc_000565.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well then, then ...... ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Then, I will just give out the condition for her. ");
//            //voice?  voice.arc_000566.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Become What? Oh, Asahi is still a student! What?");
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Is not it a wonderful adult anymore? At least, the body. ");
//            //voice?  voice.arc_000567.ogg
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Huh! ! ");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "No way, Mr. Minoto was a person to say such a thing.");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I also thought that they were a bad joke, but they seem to be seriously saying.");
//            //voice?  voice.arc_000568.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(What do you do ... ... such ... ...)");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "At least, I can not let such a condition by Asahi.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I think that I must manage to do something, but I was unlikely to get an answer soon.");
//            //voice?  voice.arc_0005669.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~прошу вас....позвольте мне все обдумать....");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I do not mind it, but I am busy too. Oh yeah ... the time to divide for you is another 10 minutes.");
//            //voice?  voice.arc_000570.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~... that, such a ... ...");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I can not do such a conclusion in ten minutes.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As I said before, I thought after going home once, but Mr. Motoi did not seem to forgive it.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps last time I brought the documents home and consulted with Kohei might also be affecting.");
//            //voice? voice.arc_000571.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Maybe you do not want to talk to Mr. Kohei ... ...) ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you would like to talk to Kohei-san, I have to call this place now.");
//            //voice? voice.arc_000572.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(But, this time Kohei-san is also working ... ...)");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wish it was at least a lunch break or overtime time.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is painful to call Kohei-san who is working while troubling you.");
//            //voice? voice.arc_000573.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(ооо ...... что же мне делать ... ....!?)");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Only time will pass as I can not answer anything.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Every time Mr. Minato saw the wrist watch, I felt that he was going to be hunted down.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~... ... It's only five minutes.");
//            //voice? voice.arc_000574.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~хлюп! !");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "We have to decide whether to accept Mr. Minodo's request or not.");
//            //voice? voice.arc_000575.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~это будет .... только неделю ... это так ...?");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Oh, no doubt. I do not mind letting you keep it in writing properly if you wish. ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If Mr. Minodo says so, I think that it is only one week indeed.");
//            //voice? voice.arc_000576.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...пожалуйста, если вас не затруднит ...");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Wait a while.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Mr. Minodo said so, operated the personal computer, printed out the document and brought it.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~This is the document. Because it is not a contract, it is like a letter. ");
//            //voice? voice.arc_000577.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...хо..хорошо ...");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There, it says that I will leave to myself about payment of repair costs instead of becoming Freedom of Mr. Minato for only a week.");
//            //voice? voice.arc_000578.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~... ... а как отменить это соглашение? ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~You only have to pay for your good. ");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While saying that, Mr. Minato sat down next to me.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I got my body beyond necessity and put my hands around my thighs.");
//            //voice? voice.arc_000579.ogg
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~No matter how many times you pay, it does not matter about the amount of each time.");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I was concerned about Mr. Minodo's hand, but desperately I listened to that word and followed the letters of the document.");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There may be something inconvenient to me.");
//            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as far as I see, the papers have written only what is convenient for me.");
//            //voice? voice.arc_000580.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Well, this is really okay .... If this is the case, I can do anything without inconveniencing anyone ....)");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Of course, the price is great.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~It is you who decide, Yayoi. If you accept this, please sign it.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If I drink this condition, everything can be solved well.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Asahi is not worrying about it, nor does it rely on your parents.");
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "And above all, I did not put unnecessary inconvenience to Kohei-san.");
//            //voice? voice.arc_000581.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~ .... окей, я согласна ...");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "You only have to endure it for a week and endure it.");
//            //voice? voice.arc_000582.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Прости меня Кохей... ...)");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Apologizing to Mr. Kohei in my mind, I signed the document.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~...... Then, it is established with this. ");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Make sure the document I signed, Mister Mutsu muttered.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The period is a week from tomorrow. I will contact you as soon as time comes, so you can come here.");
//            //voice? voice.arc_000583.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Yes, ...");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Although it is over talk, is there something?");
//            //voice? voice.arc_000584.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~нет ... ... мне наверно уже пора ......");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Ah.");
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "After finishing talking with Mr. Minato, I left the office.");
//            // ANTRACT =====================


//            ClearSound();
//        }
//        private void Cartina_WalkingAfterProposal()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            // ANTRACT=============================================================
//            // music.arc_000001.wav
//            Size1 = 1100; posX1 = 135; posY1 = 55;
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The sun had already begun to slip out of us how long it took us so long.");
//            //effect.arc_000014.wav
//            //voice.arc_000585.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "……");
//            //effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I am walking with a hula while thinking about the signed documents.");
//            //effect.arc_000014.wav
//            //voice.arc_000586.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(С завтрашнего дня, я ... .... принадлежу мистеру Минато ... ...)");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The feelings I regret as soon as they come in, it becomes painful just by thinking.");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I wonder if I did something terribly inevitable.");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I guess that is probably the case.");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But in that situation there was no other answer and I could not afford to consult anyone.");
//            // effect.arc_000014.wav
//            //voice.arc_000587.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(But what shall I do ... ... I promised that kind of ... ...) ");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Perhaps it was better for you to trust Mr. Kohei obediently, without thinking about doing anything by yourself.");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even though I thought so, I felt like it is now.");
//            // effect.arc_000014.wav
//            //voice.arc_000588.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(I do not want to put a burden on Kohei-san any more any more ... ...) ");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Though thinking about the future with me, I am doing my best while working hard.");
//            // effect.arc_000014.wav
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "However, I may be betraying that kind of Kohei as a result.");
//            // effect.arc_000014.wav
//            //voice.arc_000589.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~.... хлюп.... Я......");
//            // effect.arc_000014.wav
//            //voice.arc_000590.ogg
//            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Ой...");
//            // effect.arc_000014.wav
//            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Maybe because I was disappointed, my feet were hula and I was sticking out to the roadway.");
//            // effect.arc_000014.wav
//            //voice.arc_000591.ogg
//            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(Hit run ...... !?)");
//            // effect.arc_000014.wav
//            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even if I look at the car coming close to me, my body does not move at all.");
//            // effect.arc_000014.wav
//            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The moment I thought it was no good, suddenly someone was pulling my arm.");
//            Size2 = 655; posX2 = 125; posY2 = 115;
//            // effect.arc_000014.wav
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Oops! It is dangerous!");
//            // effect.arc_000014.wav
//            //voice.arc_000592.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Ах ...!");
//            //// effect.arc_000014.wav
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Driver~Watch out! Do you want to be run over! driver");
//            //// effect.arc_000014.wav
//            //voice.arc_000593.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I'm sorry ...");
//            // effect.arc_000014.wav
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The car stopped at the limit, but if I stayed in the carriage as it was, it may have been ruined in safety.");
//            posX1 = 480;
//            // effect.arc_000014.wav
//            //voice.arc_000594.ogg
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, thank you ...... ");
//            // effect.arc_000014.wav
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Was it okay?");
//            // effect.arc_000014.wav
//            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "So I was told that I was the manager who helped me.");
//            // effect.arc_000014.wav
//            //voice.arc_000595.ogg
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, the store manager san ...... ");
//            // effect.arc_000014.wav
//            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~I was worried because I was walking with the hula. Well, it was good to make it in time. ");
//            // effect.arc_000014.wav
//            //voice.arc_000596.ogg
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I'm sorry, I am worried ... ... ");
//            // effect.arc_000014.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If the manager did not notice me, what was going on?");
//            // effect.arc_000014.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Is he feeling ill? Or was there something? ");
//            // effect.arc_000014.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The manager is worried about me and he puts such words.");
//            // effect.arc_000014.wav
//            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But it is not like I can talk very much.");
//            // effect.arc_000014.wav
//            //voice.arc_000597.ogg
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I was a little bait ... ... It's okay. I'm really thankful to you. ");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Make a smile somehow, cheat the manager.");
//            //effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Did you believe it, the manager did not ask you anything more than that?");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~That's fine ...... Husband's on a business trip? If something happens, do not hesitate to tell me. ");
//            // effect.arc_000014.wav
//            //voice.arc_000598.ogg 
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I will do ... Yes, thank you. ");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If I can tell you the problem I am having, what kind of face will the manager say?");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Suddenly such a thing passed the mind, but of course I could not say it.");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Well then, I will return to the store.");
//            // effect.arc_000014.wav
//            //voice.arc_000599.ogg 
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, yes ... I will excuse you. ");
//            // effect.arc_000014.wav
//            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Lower his head to the store manager who helped me and leave that place.");
//            // effect.arc_000014.wav
//            //voice.arc_000600.ogg 
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(If you do not stand firm ... ...) ");
//            // effect.arc_000014.wav
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "My head was full of Mr. Mihara, but I will tell myself so.");
//            // effect.arc_000014.wav
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Let's at least think after returning home.");
//            // effect.arc_000014.wav
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Because it is supposed to be irreparable when it comes to accidents.");



//            ClearSound();
//        }
//        private void Cartina_BeforeHusbCall3()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

//            // ANTRACT=============================================================
//            posX1 = 135;
//            // music.arc_000009.wav
//            // evening livingroom
//            //voice.arc_000601.ogg 
//            AddCadr(1049, null, null, "{Girl}~Fuh ... ... this time already ...... ");
//            AddCadr(1049, null, null, "By the time I came back home, the outside of the window was completely dark.");
//            AddCadr(1049, null, null, "I should prepare dinner soon, but I could not feel like that.");
//            AddCadr(1049, null, null, "To begin with, I have only one person, and I do not have an appetite now.");
//            AddCadr(1049, null, null, "As I thought, my head was full of promises with Mr. Koto.");
//            //voice.arc_000602.ogg 
//            AddCadr(1050, null, null, "{Girl}~(Tomorrow I have to go to Mr. Mioto's place ...) ");
//            AddCadr(1050, null, null, "I wonder what exactly is done.");
//            AddCadr(1050, null, null, "I think that there is nothing to injure, but after all it may be necessary to prepare.");
//            // voice.arc_000603.ogg
//            AddCadr(1050, null, null, "{Girl}~(That's ... that's right, surely ... ....) ");
//            AddCadr(1050, null, null, "Because Mr. Minato is a man and saying that I will make a woman free, I think that it is what I imagined.");
//            // voice.arc_000604.ogg
//            AddCadr(1050, null, null, "{Girl}~Ah  !");
//            AddCadr(1050, null, null, "It may be too late if I regret it now.");
//            AddCadr(1050, null, null, "I already signed the document and there is no other way to pay the repair cost.");
//            AddCadr(1050, null, null, "I want to think that it was an unavoidable choice, but feelings depressed.");
//            AddCadr(1050, null, null, "I could not suppress my feelings of regret as if I should have confided to Mr. Kohei.");
//            // voice.arc_000605.ogg
//            AddCadr(1050, null, null, "{Girl}~(I wonder what I should do ... ...) ");
//            AddCadr(1050, null, null, "No matter how much I think, the answer is unlikely.");
//            AddCadr(1050, null, null, "While I was doing it, it was time for video chatting with Kohei when I noticed it.");
//            // voice.arc_000606.ogg
//            AddCadr(1048, null, null, "{Girl}~I can not hurry ... ");
//            AddCadr(1048, null, null, "If you have a depressed face, you surely understand to Kohei.");
//            //effect.arc_000020.wav
//            AddCadr(0, null, null, "While heading to the bedroom where the personal computer is placed, I try to smile frantically.");
//            AddCadr(0, null, null, "But I was laughing properly, even if I looked in the mirror I could not understand myself well.");

//            ClearSound();
//        }
//        private void Cartina_HusbCall3()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


//            // evening bedroom
//            // voice.arc_000607.ogg
//            AddCadr(1049, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~It is almost time ... ");
//            Size1 = 1370; posX1 = 0; posY1 = 0;
//            // voice.arc_000608.ogg
//            //effect.arc_000039.wav
//            AddCadr(0991, null, null, "{Girl}~... .... Good work, you. How is your job?");
//            AddCadr(0991, null, null, "Kohei~Thank you. Well, is the worker doing well? ");
//            AddCadr(0991, null, null, "Try not to think about Mr. Minato and speak as normally as possible.");
//            // voice.arc_000609.ogg
//            AddCadr(0991, null, null, "{Girl}~(Okay, unless you realize Kohei ... ...) ");
//            AddCadr(0991, null, null, "It's a small screen on a personal computer, and even if it looks a little strange, I can not notice it.");
//            AddCadr(0991, null, null, "So talking to myself, talk to Kohei-san in the screen.");
//            AddCadr(0991, null, null, "Kohei~By the way, what happened to the other case? ");
//            AddCadr(0991, null, null, "But from Kohei-san, it was cut out.");
//            AddCadr(0991, null, null, "I did not want to talk much, but I can not ignore it.");
//            // voice.arc_000610.ogg
//            AddCadr(1001, null, null, "{Girl}~(What shall I do ......) ");

//            ClearSound();
//        }
//        private void Cartina_Choice3_2()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });
//            //============================================
//            // CHOICE 3-2
//            //============================================

//            // voice.arc_000611.ogg
//            AddCadr(1001, null, null, "{Girl}~ah");
//            AddCadr(1001, null, null, "To be honest, I would like to talk to Mr. Kohei.");
//            AddCadr(1001, null, null, "After all it is a problem in my hand and I think I can not do any more.");
//            AddCadr(1001, null, null, "It is better for Kohei to be scolded by Mr. Kohei as it is supposed to be as free as his freedom for only a week as it is.");
//            // voice.arc_000612.ogg
//            AddCadr(1001, null, null, "{Girl}~(But I'm busy with work ... I'm getting tired.)");
//            AddCadr(1001, null, null, "I felt something like tiredness different from what I usually do, looking anxiously.");
//            AddCadr(1001, null, null, "It's a long business trip and maybe I'm not getting tired well.");
//            AddCadr(1001, null, null, "As I thought, it seems as though I was sorry for any further burden.");
//            // voice.arc_000613.ogg
//            AddCadr(1001, null, null, "{Girl}~(Because of me, I can not put any further inconvenience ... ...) ");
//            AddCadr(1001, null, null, "It is my wife 's job to protect the house while my husband is out.");
//            AddCadr(1001, null, null, "Because I told myself to do something, I have to work hard until the end.");
//            // voice.arc_000614.ogg
//            AddCadr(1007, null, null, "{Girl}~Yeah, I managed to repay it in part.");
//            AddCadr(1008, null, null, "Kohei~Is that so? ");
//            // voice.arc_000615.ogg
//            AddCadr(1008, null, null, "{Girl}~Yup. Well .... I do not want to put too much strain on household budget, so I'd like to part time again ... is it good?");
//            AddCadr(1008, null, null, "Kohei~Of course it does not matter, but at that supermarket? ");
//            // voice.arc_000616.ogg
//            AddCadr(1008, null, null, "{Girl}~Is that so. Because the manager was lamenting because they were short of people, I am indebted to him in various ways and thinking of going to help me just because it is good.");
//            AddCadr(1008, null, null, "I am surprised even by myself that a lie will come out as irregularities.");
//            AddCadr(1008, null, null, "Of course, I also thought that the store manager would seem hard to have thought of going out to the part again.");
//            AddCadr(1008, null, null, "But I have not thought about anything concrete yet, why can you say such a thing towards Mr. Kohei?");
//            // voice.arc_000617.ogg
//            AddCadr(1003, null, null, "{Girl}~(I'm lying to Kohei-san ... ...)");
//            AddCadr(1003, null, null, "My heart aches with that fact.");
//            AddCadr(1003, null, null, "I never had ever lied to Kohei-san.");
//            AddCadr(1002, null, null, "Kohei~I see ... I guess it is OK, but if it seems to be tough, I would like you to say it properly. ");
//            // voice.arc_000618.ogg
//            AddCadr(1007, null, null, "{Girl}~Of course, Kohei-san.");
//            // voice.arc_000619.ogg
//            AddCadr(0992, null, null, "{Girl}~Well then, are you eating properly? It looks somewhat pale face ...");
//            AddCadr(0992, null, null, "To avoid pursuit from Kohei, on the other hand, I will tell it from my side.");
//            AddCadr(0993, null, null, "Kohei~Ah ... no, I am busy ... ... ");
//            // voice.arc_000620.ogg
//            AddCadr(0993, null, null, "{Girl}~You can not afford a lunch box at a convenience store? At least let's eat something proper in the store? ");
//            AddCadr(0993, null, null, "Kohei~That's right, there is a set menu restaurant in the neighborhood, so I will go there as much as possible. ");
//            // voice.arc_000621.ogg
//            AddCadr(0993, null, null, "{Girl}~I think that is good. Please come back fine, Kohei-san?");
//            AddCadr(0991, null, null, "Kohei~Yes, I will be careful. Well then ... ... ");
//            // voice.arc_000622.ogg
//            AddCadr(0991, null, null, "{Girl}~Yeah ... Good luck with your work, good night, you.");
//            AddCadr(0991, null, null, "Kohei~I think that Yayoi is too hard, but do not push yourself? Well then, good night. ");
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "In the end they smiled at each other and finished the video chat.");
//            Size1 = 1100; posX1 = 135; posY1 = 55;
//            // voice.arc_000623.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~ahh");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "When I cut off my PC, my chest is tightened again.");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "It was the first time I was born, I lied to Kohei-san.");
//            // voice.arc_000624.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~But if you confidently tell the truth, I will put more burden ... ...");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I do not think I'm sorry, but I could not do anything else.");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Anyway, now I have to solve the problem of Asahi and return to life as soon as possible.");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I am worried about things from tomorrow, but I have to decide my resolution.");
//            // voice.arc_000625.ogg
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~(I'm sorry, Mr. Kohei ... ... When is your time ... ...) ");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "As a result it may cause more inconvenience, but let's try hard as much as possible.");
//            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Because I still do not know what Mr. Minodo will ask me.");

//            // ANTRACT=============================================================

//            ClearSound();
//        }
//        private void Cartina_MorningBeforeDate()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


//            // ANTRACT=============================================================
//            posX1 = -215;
//            posX3 = 520; posY3 = 60; Size3 = 1000;
//            // music.arc_000001.wav
//            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Today is Asahi came from the morning as school was closed.");
//            // voice.arc_000626.ogg
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~I'm glad you came to visit us, Asahi.");
//            // voice?
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~ah");
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Of course, it just did not come to play normally.");
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "You can also tell from Mr. Muto's point of view about his facial expressions.");
//            // voice?
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um, Yayoi ... ... What has become of it from that ... ....? ");
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "As I thought, I asked with an uneasy expression.");
//            // voice.arc_000627.ogg
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~Even if you do not worry it's okay, as we have already discussed with Mr. Nioto. ");
//            // voice?
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~But money, ... ");
//            // voice.arc_000628.ogg
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~It was decided to pay by splitting, but I do not have to worry about that either ... ... is it? ");
//            // voice?
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um ... ... I'm sorry, it's because of me ... But, is it really okay ...? ");
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Although I said that I was not worried, I was still anxious.");
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I wonder if I can not depend on them any more.");
//            // voice.arc_000629.ogg
//            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~...... Actually, I also consulted Kohei-san.");

//            //music.arc_000006.wav
//            // voice?
//            AddCadr(1046, 1018, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Er ...... Onii-chan! What? ");
//            // voice.arc_000630.ogg
//            AddCadr(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~Yes. Kohei-san negotiated, the repair expenses also cheaper?");
//            AddCadr(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "To resolve Asahi's anxiety, speak brightly with a smile on purpose.");
//            // voice?
//            AddCadr(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~I see, Onii-chan ... ... ");
//            AddCadr(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi, who had been making her feel uneasy, also healed his expression as soon as Kohei-san's story came out.");
//            // voice.arc_000631.ogg
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~(You really trust me, Mr. Kohei)");
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I can understand that feeling as well.");
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Mr. Kohei is calm and calm all the time, so he is a very reliable person.");
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "If Kohei-san deals with it, it seems that it has already been solved.");
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi who stayed together much longer than me, maybe the size of that trust is more than me.");
//            // voice.arc_000632.ogg
//            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~... ... So you are already safe?");
//            // voice?
//            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Yeah ... but, thanks a lot, Yayoi. ");
//            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi seems relieved and smiles anyhow.");
//            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I finally seemed able to regain a smile and I was happy.");


//            ClearSound();
//        }
//        private void Cartina_PreparationsToDate()
//        {
//            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
//            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
//            //Z1 = 2;
//            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
//            CurrentSounds = new List<seSo>();
//            //int i = 636; // cound indexer
//            //Music
//            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


//            // ANTRAKT=================
//            // day livingroom
//            // music.arc_000001.wav

//            // voice.arc_000633.ogg
//            AddCadr(1046, 1016, null, "{Girl}~Oh, I am sorry, Asahi-chan. I have to go out soon.");
//            // voice?
//            AddCadr(1046, 1016, null, "Asahi~Was it already such a time? I have to go home soon ... I will come to play again, Mr. Yayoi. ");
//            // voice.arc_000634.ogg
//            AddCadr(1047, 1016, null, "{Girl}~Yeah, come back to visit anytime.");
//            //effect.arc_000020.wav
//            AddCadr(1047, 0, null, "Asahi goes out of the room with a dash.");
//            AddCadr(1047, 0, null, "I enjoyed talking with Asahi slowly after a long absence.");
//            AddCadr(1047, 0, null, "But it is about time we promised to Mr. Muto.");
//            AddCadr(1050, 0, null, "{Girl}~I have to go make up properly ...");
//            AddCadr(1050, 0, null, "It is usually about a base makeup, I do not do very well.");
//            AddCadr(1050, 0, null, "But as expected it did not go that way.");
//            AddCadr(1050, 0, null, "Although I am cheerful if I think about what will happen, I can not translate without going beyond what I have promised.");
//            // voice.arc_000635.ogg
//            AddCadr(1050, 0, null, "{Girl}~(Even Minato is not that bad so far ... ...)");
//            AddCadr(1050, 0, null, "I was hoping for a little bit that he would not do seriously serious things.");

//            ClearSound();
//        }
//        private void Cartina_ChangingClothInCabinet()
//        {
//            string BG = BG_EVENING_CABINET; // evening cabinet
//            string MAN = MAN1;

//            currentGr = "14.Переодевание у финансиста";
//            posZ1 = 2;
//            Size2 = 680; posX2 = -70; posY2 = 525; posZ2 = 1;
//            int i = 637; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000005.wav");
//            //Music ============================

//            //1
//            AddEffect1($"effect.arc_000020.wav", SoundPauseShort, false);//Effect - shoot door
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseLong, false);
//            DoC(1049, 0, null, BG, $"{Girl}~Простите? ...... ", new OpEf(1, false, 500, false, 2000));
//            //2
//            DoC(1049, 0, null, BG, $"Когда я, вошла, волнуясь даже больше, чем раньше, {BadMan} еще работал.");
//            //3
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Я еще не закончил, подождите.", new OpEf(2, false, 350, false, 0));
//            //4
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, MAN, BG, $"{Girl}~....хорошо....");
//            //5 
//            DoC(1049, 0, null, BG, $"{BadMan} сидел за столом, перебирая документы с озабоченным выражением лица.", new OpEf(2, true, 500, true, 0));
//            //6
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, null, BG, $"{Girl}~(Наверное, какое-то важное дело ...)");
//            //7
//            DoC(1049, 0, null, BG, $"Я знаю, что он работает в финансовой сфере, в которой я ничего не понимаю.");
//            //8
//            DoC(1049, 0, null, BG, $"Может быть, это инвестирование, или что-то подобное.");
//            //9
//            DoC(1049, 0, null, BG, $"Пока я оценивала обстановку, {BadMan} убрал документы и поднялся из-за стола.");
//            //==== Change position
//            posX2 = 845; posY2 = 55; Size2 = 715;
//            //10
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Простите, что заставил вас ждать.", new OpEf(2, false, 350, false, 0));
//            //11
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, MAN, BG, $"{Girl}~совсем нет... ....");
//            //12
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Я уже успел переодеться, теперь вы не могли бы надеть другое платье?.");
//            //13
//            DoC(1049, 0, MAN, BG, $"Посмотрел на меня и показал на бумажный пакет у моих ног.");
//            //14
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1048, 0, MAN, BG, $"{Girl}~ Надеть другое платье...?", new OpEf(1, true, 350, true, 0));
//            //15
//            DoC(1048, 0, MAN, BG, $"Я никак не ожидала такого предложения.");
//            //16
//            DoC(1048, 0, MAN, BG, $"{BadMan}~Размер должен подойти.");
//            //17
//            DoC(1048, 0, MAN, BG, $"{BadMan} непреклонно указал на бумажный пакет.");
//            //18
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1048, 0, MAN, BG, $"{Girl}~ да ... ...");
//            //19
//            DoC(1049, 0, MAN, BG, $"Не знаю, зачем ему нужно, что бы я переоделать, но мне придется сделать это."
//                , new OpEf(1, true, 350, true, 0));
//            //20
//            DoC(1049, 0, MAN, BG, $"Ведь я обязалась неделю быть его женщиной, начиная с сегодняшнего дня.");
//            //21
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Ваше новое платье здесь, в пакете. Можете воспользоваться туалетом.");
//            //22
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, MAN, BG, $"{Girl}~Здесь...? ");
//            //23
//            DoC(1049, 0, MAN, BG, $"Я подняла пакет с наклейкой известной фирмы и заглянула внутрь.");
//            //24
//            DoC(1049, 0, MAN, BG, "Внутри на самом деле была одежда.");
//            //25
//            DoC(1049, 0, MAN, BG, "Но ее фасон был, кажется, какой-то не совсем обычный.");
//            //26
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, MAN, BG, $"{Girl}~оох ... что это ...!! ?");
//            //27
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Я думаю, что для вашего тела это подойдет.");
//            //28
//            DoC(1049, 0, MAN, BG, $"{BadMan} настроен достаточно откровенно, и выражается без обиняков.");
//            //29
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, MAN, BG, $"{Girl}~о ... ах ... раз так ... хорошо... ");
//            //30
//            DoC(1049, 0, MAN, BG, "Наверно, мне не нужно было переодеваться, но...");
//            //31
//            DoC(1049, 0, MAN, BG, "Вокруг была какая-то такая атмосфера, что я не смогла отказаться.");
//            //32
//            DoC(0, 0, null, BG, "...", new OpEf(1, true, 350, true, 0), new OpEf(2, true, 350, true, 0));
//            //33
//            DoC(0, 0, null, BG, "... ...");
//            //34
//            DoC(0, 0, null, BG, "... ... ...");
//            //35
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~вот... ...я переоделась ...... ", new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
//            //36
//            DoC(1073, 0, MAN, BG, $"{BadMan} приготовил для меня очень откровенное платье.");
//            //37
//            DoC(1073, 0, MAN, BG, "Линии тела были открыты полностью, было много открытых участков, где-то было видно даже белье.");
//            //38
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~(ооо... мне так неловко......) ");
//            //39
//            DoC(1073, 0, MAN, BG, $"Мое тело в зеркале туалетной комнате было вызывающе открыто.");
//            //40
//            DoC(1073, 0, MAN, BG, $"{BadMan}~──О, как я и думал, это вам подходит");
//            //41
//            DoC(1073, 0, MAN, BG, $"{BadMan} довольно улыбался, разглядывая меня.");
//            //42
//            DoC(1073, 0, MAN, BG, $"Первый раз я видела у него такое выражние лица.");
//            //43
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~что же я должна сделать дальше ...... ");
//            //44
//            DoC(1073, 0, MAN, BG, $"Я ждала, что теперь потребует от меня {BadMan},который продолжал довольно улыбаться.");
//            //45
//            DoC(1073, 0, MAN, BG, $"От волнения и возбуждения ладони мои стали влажными.");
//            //46
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Ах да, для начала, хотите пойти поужинать? Я с утра был слишком занят, чтобы поесть, и проголодался.");
//            //47
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, MAN, BG, $"{Girl}~оох ...  ужин ... ....?", new OpEf(1, true, 350, true, 0));
//            //48
//            DoC(1070, 0, MAN, BG, $"{BadMan}~Вы уже ужинали?");
//            //49
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, MAN, BG, $"{Girl}~Да ...то есть... еще нет ...");
//            //50
//            DoC(1070, 0, MAN, BG, $"От врлнения у меня не было аппетита, к тому же я хорошо пообедала.");
//            //51
//            DoC(1070, 0, MAN, BG, $"{BadMan}~Что ж, отлично. Есть один французский ресторан, где я часто обедаю, так что пойдем туда.");
//            //52
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~В таком виде ...?", new OpEf(1, true, 350, true, 0));
//            //53
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Нет проблем, там свободная обстановка.");
//            //54
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~Но...");
//            //55
//            DoC(1073, 0, MAN, BG, $"Я чувствую себя слишком неловко в таком наряде, чтобы пойти в нем в общественное место.");
//            //56
//            DoC(1073, 0, MAN, BG, $"Тем более во французский ресторан.");
//            //57
//            DoC(1073, 0, MAN, BG, $"Так как это {BadMan}, я думаю, что он очень дорогой.");
//            //58
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Пойдемте же. ");
//            //59
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~(Если пойти в таком наряде, может случиться скандал ... ... ...)");
//            //60
//            DoC(1073, 0, MAN, BG, $"Но я не могу отказаться, ведь {BadMan} кажется, это нравится.");
//            //61
//            DoC(1073, 0, MAN, BG, $"Мне было очень стыдно, но я решила пережить и это.");


//            ClearSound(true, true, true);
//        }
//        private void Cartina_EveningPromenad()
//        {
//            string BG = BG_EVENING_STREET; // evening cabinet
//            string MAN = MAN1;

//            currentGr = "15.Вечерний променад.";
//            posZ1 = 2; posX1 = 470;
//            Size2 = 680; posX2 = 155; posY2 = 525; posZ2 = 1;

//            int i = 654; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000005.wav");
//            //Music ============================


//            //1            
//            AddEffect2($"effect.arc_000017.wav", SoundPauseNone, false);//Effect - crowd
//            DoC(0, 0, null, BG, $"После того, как мы поужинали во французском ресторане, {BadMan} повел меня на прогулку по ночному городу.");
//            //2
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Обслуживание было хорошим, и блюда были неплохи, верно?"
//                , new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
//            //3
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~Да, ... это было прекрасно ......");
//            //4
//            DoC(1073, 0, MAN, BG, $"Взяв меня под руку, {BadMan} кивнул.");
//            //5
//            DoC(1073, 0, MAN, BG, $"Я ответила ему, чтобы поддержать разговор, но на самом деле я не помню, какой был вкус этих блюд.");
//            //6
//            DoC(1073, 0, MAN, BG, $"Я знаю, что это были деликатесы, но мне было не до них, потому что все люди вокруг, включая официантов, смотрели на меня.");
//            //7
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~(я не чувствую, что наелась ......)");
//            //8
//            DoC(1073, 0, MAN, BG, $"Даже идя по ночной улице, каждый взгляд проходящего мужчины тревожил меня.");
//            //9
//            DoC(1073, 0, MAN, BG, $"Это было естественно, потому что я чувствовала себя наполовину голой.");
//            //10
//            DoC(1073, 0, MAN, BG, $"{BadMan}~............ ");
//            //11
//            DoC(1073, 0, MAN, BG, $"Наверно {BadMan} был доволен, наблюдая мое смущение.");
//            //12
//            DoC(1073, 0, MAN, BG, $"{BadMan}, кажется, наслаждался.");
//            //13
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Еше слишком рано идти в бар ... ... Пойдем в кино?");
//            //14
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~........?");
//            //15
//            DoC(1070, 0, MAN, BG, $"{BadMan}, глядя на часы, протянул руку и обнял меня за талию."
//                , new OpEf(1, true, 350, true, 0));
//            //16
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~......."
//                , new OpEf(1, true, 350, true, 0));
//            //17
//            DoC(1073, 0, MAN, BG, $"На самом деле, было трудно сказать, была ли это талия, или ягодицы.");
//            //18
//            DoC(1073, 0, MAN, BG, $"Он как будто погладил их, в ответ я невольно тихо вскрикнула.");
//            //19
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Прогуляемся?");
//            //20
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~д ... ... да ... ...");
//            //21
//            DoC(1073, 0, MAN, BG, $"Я не смогла даже отвести его руку, и он продолжал держать меня меня за попу.");
//            //22
//            DoC(1073, 0, MAN, BG, $"Я боялась, что это было заметно всем.");
//            //23
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~(пожалуйста ... лишь бы не встретить никого знакомого ... ...)");
//            //24
//            DoC(1073, 0, MAN, BG, $"Я мысленно молилась, сгорая от смущения."
//                , new OpEf(1, false, 350, true, 0), new OpEf(2, false, 350, true, 0));

//            DoC(0, 0, null, null, $"....");
//            DoC(0, 0, null, null, $".... ....");
//            DoC(0, 0, null, null, $".... .... ....");
//            //25
//            DoC(0, 0, null, BG, $"После кино, {BadMan} продолжил гулять.");
//            //26
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Только музыка была хороша, а сценарий и игра - нет."
//                , new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
//            //27
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~да, правда ......");
//            //28
//            DoC(1073, 0, MAN, BG, $"Почему-то меня обидело, как {BadMan} говорил о картине.");
//            //29
//            DoC(1073, 0, MAN, BG, $"Кино было длинным, но содержание не очень понятным.");
//            //30
//            DoC(1073, 0, MAN, BG, $"Иностранная картина, из которой я запомнила только красивые виды.");
//            //31
//            DoC(1073, 0, MAN, BG, $"{BadMan} рукой все время касался моих бедер, и я не могла сконцентрироваться.");
//            //32
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Тут рядом бар. Вы пьете саке?");
//            //33
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, MAN, BG, $"{Girl}~д ......, да ... ... только если немного ... ... "
//                , new OpEf(1, true, 350, true, 0));
//            //34
//            DoC(1070, 0, MAN, BG, $"Я поняла, что сейчас мы пойдем в бар. Наверно он собирается выпить.");
//            //35
//            DoC(1070, 0, MAN, BG, $"{GoodMan} не пьет, и поэтому я тоже редко пробовала.");
//            //36
//            DoC(1070, 0, MAN, BG, $"Когда я жила с родителями, я пробовала напитки моего отца.");
//            //37
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, MAN, BG, $"{Girl}~(Я должна постараться не пить слишком много ......)");
//            //38
//            DoC(1070, 0, MAN, BG, $"Пока что, {BadMan} хоть и дал волю рукам, но остальном вел себя как джентельмен.");
//            //39
//            DoC(1070, 0, MAN, BG, $"Но я не лумаю, что так будет и дальше.");
//            //40
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~(Он наверно постарается напоить меня ... или что-то еще... )"
//                , new OpEf(1, true, 350, true, 0));
//            //41
//            DoC(1073, 0, MAN, BG, $"Если так, я не должна быть пьяной.");
//            //42
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Что ж, пойдем.");
//            //43
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, MAN, BG, $"{Girl}~хорошо, ...");
//            //44
//            DoC(1070, 0, MAN, BG, $"Я должна вести себя правильно, чтобы ничего плохого не случилось.");
//            //45
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"...",
//                new OpEf(1, true, 250, true, 0), new OpEf(2, true, 250, true, 0));
//            //46
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ...");
//            //47
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ... ...");
//            //48
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~..........",
//                new OpEf(1, false, 250, false, 0), new OpEf(2, false, 250, false, 0));
//            //49
//            DoC(1073, 0, MAN, BG, $"{BadMan}~Прогуляемся, чтобы проветрить алкоголь.");
//            //50
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, MAN, BG, $"{Girl}~ах ... ... да ... ... ");
//            //51
//            DoC(1073, 0, MAN, BG, $"Благодаря тому, что ранее был ужин, я не слишком опьянела.");
//            //52
//            DoC(1073, 0, MAN, BG, $"Конечно, ликер подействовал на меня, но голова не слишком кружилась.");
//            //53
//            DoC(1073, 0, MAN, BG, $"А {BadMan} снова все время держал руку на моей попе.");
//            //54
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"...",
//                OpEf.HidePrev(1), OpEf.HidePrev(2));
//            //55
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ...");
//            //56
//            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ... ...");
//            //57
//            DoC(0, 0, null, BG, $"Улица по которой мы шли, привела к дому с яркими неоновыми огнями.");

//            posX1 = -435; posY1 = 435;
//            //58
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1070, 0, null, BG, $"{Girl}~(это...это ... ... похоже на ... ...?)"
//                , OpEf.AppearCurrent(1));
//            //59
//            DoC(0, 0, null, BG, $"Лампы давали неровный свет, и люди, которые заходили внутрь прятали лица."
//                , OpEf.HidePrev(1));
//            //60
//            DoC(0, 0, null, BG, $"Чувство тревоги усилилось, я задрожала, увидев этих заходящих туда мужчин и женщин.");
//            //61
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1071, 0, null, BG, $"{Girl}~(ох ...... что же мне делать ...... я в отчаянии ... ....) "
//                , OpEf.AppearCurrent(1));
//            //62
//            DoC(0, 0, null, BG, $"Я не хочу чтобы {GoodMan} оказался как-то предан мной."
//                , OpEf.HidePrev(1));
//            //63
//            DoC(0, 0, null, BG, $"Но если я зашла уже так далеко, а сейчас откажусь, то все станет напрасно..");
//            //64
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1072, 0, null, BG, $"{Girl}~(Ну хотя бы теперь ... понятно, к чему все шло......) "
//                , OpEf.AppearCurrent(1));
//            //65
//            DoC(0, 0, null, BG, $"Может быть, все это случилось из-за ликера?"
//                , OpEf.HidePrev(1));
//            //66
//            DoC(1073, 0, MAN, BG, $"{BadMan}~...... Мы заходим?"
//                , OpEf.AppearCurrent(2));
//            //67
//            DoC(1073, 0, MAN, BG, $"{BadMan} остановился прямо на входе.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            //68
//            DoC(1069, 0, MAN, BG, $"{Girl}~.....!",
//                OpEf.HidePrev(1));
//            //69
//            DoC(1069, 0, MAN, BG, $"Это был дом для свиданий.");
//            //70
//            DoC(1069, 0, MAN, BG, $"Я все стояла, и тогда {BadMan} рукой подтолкнул меня вперед.");
//            //71
//            DoC(1069, 0, MAN, BG, $"Я чувствовала, что не могу противиться этой руке.");
//            //72
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1071, 0, MAN, BG, $"{Girl}~(Ооо... ... {GoodMan} ... ...! Спаси меня ... ...!)"
//                , OpEf.HidePrev(1));
//            //73
//            DoC(1071, 0, MAN, BG, $"Шагнув ко входу, я мысленно взывала ему.");

//            //Clear sound
//            ClearSound(true, true, true);
//        }
//        private void Cartina_LoveHotelBegin()
//        {
//            string BG = BG_LOVE_HOTEL; // evening cabinet
//            string MAN = MAN1;

//            currentGr = "16.Love Hotel - begin.";
//            int i = 672; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000007.wav");
//            //Music ============================

//            // Decoration change -LOVE HOTEL
//            Size2 = 0715; posX2 = 155; posY2 = 55;
//            Size1 = 1100; posX1 = 70; posY1 = 55;
//            //1
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, null, BG, $"{Girl}~(Так вот, как это выглядит ...)"
//                , OpEf.AppearCurrent(1));
//            //2
//            DoC(1073, 0, null, BG, $"Когда я и {GoodMan} еще только встречались, мы никогда не бывали здесь.");
//            //3
//            DoC(1073, 0, null, BG, $"Обстановка в первом доме свиданий, в который я попала, разочаровала меня немного.");
//            //4
//            DoC(1073, 0, null, BG, $"До этого, я думала, что тут будет все более необычно.");
//            //5
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1073, 0, null, BG, $"{Girl}~(Тут все как-то обыкновенно ....) ");
//            //6
//            DoC(1073, 0, null, BG, $"Удивительно, что я думала сейчас о таких пустяках.");
//            //7
//            posX1 = 470; posX2 = 155;
//            DoC(1073, 0, MAN, BG, $"{BadMan}~{Girl}?"
//                , OpEf.AppearCurrent(2));
//            //8
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1069, 0, MAN, BG, $"{Girl}~.... ... да..! "
//                , OpEf.HidePrev(1));
//            //9
//            DoC(1069, 0, MAN, BG, $"{BadMan}~Сначала нужно принять душ.");
//            //10
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1069, 0, MAN, BG, $"{Girl}~тогда ... да, я ... ... ");
//            //11
//            DoC(1069, 0, MAN, BG, $"После этих слов, напряжение возросло.");
//            //12
//            DoC(1073, 0, MAN, BG, $"Я поняла, что ЭТО началось, и почувствовала, как задрожали ноги."
//                , OpEf.HidePrev(1));
//            //13
//            AddEffect2($"effect.arc_000108.wav", SoundPauseNone, false);//Effect - shower   (also effect.arc_000106.wav)         
//            DoC(0, 0, null, BG_NIGHT_SKY, $"...");
//            //14
//            DoC(0, 0, null, BG_NIGHT_SKY, $"... ...");
//            //15
//            DoC(0, 0, null, BG_NIGHT_SKY, $"... ... ...");
//            //16
//            RemoveEffect2();
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, null, BG, $"{Girl}~о ... ... извините, что вам пришлось ждать ...... "
//                , OpEf.AppearCurrent(1));
//            //17
//            DoC(1050, 0, null, BG, $"Я приняла душ и переоделась.");
//            //18
//            DoC(1050, 0, null, BG, $"Я старалась держаться так, как будто ничего не происходило.");
//            //19
//            DoC(1050, 0, MAN, BG, $"{BadMan}~Что, вы сменили одежду? "
//                , OpEf.AppearCurrent(2));
//            //20
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, MAN, BG, $"{Girl}~да ... , так ... ... ");
//            //21
//            DoC(1050, 0, MAN, BG, $"{BadMan}~……хм. Хорошо, я не возражаю. ");
//            //22
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, MAN, BG, $"{Girl}~Простите меня ... ");
//            //23
//            DoC(1050, 0, MAN, BG, $"Я не собиралась становиться собственностью, которой владел {BadMan} ... ...И все же, {BadMan} указал мне на место, я не смогла сказать слово против.");
//            //24
//            DoC(1050, 0, MAN, BG, $"Когда я смотрела на него, у меня дрожала даже спина.");
//            //25
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, MAN, BG, $"{Girl}~ Мне страшно... ");
//            //26
//            DoC(1050, 0, MAN, BG, $"Я думаю, что это человек умеет создавать какую-то странную атмосферу.");
//            //27
//            DoC(1050, 0, MAN, BG, $"Первый раз в жизни я боялась мужчину.");
//            //28
//            DoC(1050, 0, MAN, BG, $"{BadMan}~Итак ... ... Итак, не хочешь сначала обслужить ротиком?");
//            //29
//            DoC(1050, 0, null, BG, $"{BadMan} сказал эти слова, садясь на край кровати."
//                , OpEf.HidePrev(2));
//            //30
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, null, BG, $"{Girl}~... ...обслужить... ...?");
//            //31
//            posX2 = -15; posY2 = 475;
//            DoC(1048, 0, MAN, BG, $"{BadMan}~Ты раньше не делала минет? Я слишком устал, чтобы разгадывать загадки. Я должен передохнуть."
//                , OpEf.HidePrev(1), OpEf.AppearCurrent(2));
//            //32
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1050, 0, null, BG, $"{Girl}~!!!"
//                , OpEf.HidePrev(1), OpEf.HidePrev(2));
//            //33
//            DoC(1050, 0, null, BG, $"Конечно, мне не следует переспрашивать его.");
//            //34
//            DoC(1050, 0, MAN, BG, $"{BadMan}~В чем дело? "
//                , OpEf.AppearCurrent(2));
//            //35
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, null, BG, $"{Girl}~о, это не ... ... то чтобы ... ... у меня нет большого опыта ... ... "
//                , OpEf.HidePrev(1), OpEf.HidePrev(2));
//            //36
//            DoC(1049, 0, null, BG, $"{GoodMan} - я подумала о нем, мне надо было научиться с ним.");
//            //37
//            DoC(1049, 0, null, BG, $"Я стала делать это, но не смогла, и больше мы не пробовали.");
//            //38
//            DoC(1049, 0, MAN, BG, $"{BadMan}~Вижу ... что ж, я не ожидал такого."
//                , OpEf.AppearCurrent(2));
//            //39
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, null, BG, $"{Girl}~хорошо ... "
//                , OpEf.HidePrev(2));
//            //40
//            DoC(1049, 0, null, BG, $"Не смотря на это я не могла сдвинуться с места.");
//            //41
//            DoC(1049, 0, null, BG, $"Я боялась того, что надо сделать ... но может это будет для меня лучше.");
//            //42
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, null, BG, $"{Girl}~(Я постараюсь и {BadMan} будет удовлетворен, и тогда ... ...) ");
//            //43
//            DoC(1049, 0, null, BG, $"Если добиться эякуляции ртом, то до можно избежать самого худшего.");
//            //44
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(1049, 0, null, BG, $"{Girl}~Хорошо, я согласна ... ... сделать это ... ... ");
//            //45
//            DoC(1049, 0, null, BG, $"Едва слышно промолвив эти слова, я опустилась на колени перед {BadMan}.");

//            ClearSound(true, true, true);
//        }

//        private void Cartina_MorningAfterFinansistHotelFuck()
//        {
//            string BG = BG_MORNING_BEDROOM; //
//            string MAN = MAN2;

//            currentGr = "19.At Home after hotel fuck.";
//            int i = 856; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000001.wav");
//            //Music ============================

//            DoC(0, 0, null, BG, $"The next day, when I woke up I was already close to lunch.");
//            DoC(0, 0, null, BG, $"I came back yesterday and seemed to have gone to bed without changing clothes.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            int g = 1063;
//            posX1 = 135;
//            DoC(g, 0, null, BG, $"{Girl}~Uoo ... ... ... head ... hurts ... ",
//                OpEf.AppearCurrent(1)
//            );
//            DoC(g, 0, null, BG, $"Besides, I still have liquor yesterday, I feel a little headache and I am not feeling well.");
//            DoC(g, 0, null, BG, $"I wonder if you should take something even medicine.");
//            DoC(g, 0, null, BG, $"When I woke up as I thought of such things, the events of yesterday came back at once.");
//            g = 1062;
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~ ... ... ... me ...  ... ",
//                 OpEf.HidePrev(1));
//            DoC(g, 0, null, BG, $"I was drunk on Mr. Minato, and entered a love hotel together.");
//            DoC(g, 0, null, BG, $"I never crossed the last line, but I can not deny the fact that I forgave my body.");
//            g = 1064;
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~I have done such a thing ... ... ... ",
//                 OpEf.HidePrev(1));
//            DoC(g, 0, null, BG, $"I accepted it thought that I would not refuse, but my heart aches when I think about Kohei.");
//            DoC(g, 0, null, BG, $"But at the same time, there was a relieved part.");
//            DoC(g, 0, null, BG, $"If I had crossed the last line, I could not see Kohei's face anymore.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~I was okay not to be ... ... I guess it's useless, surely ... Yayoi");
//            DoC(g, 0, null, BG, $"Also, my promise with Mr. Minato lasts a week.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~You are called again ... ...");
//            DoC(g, 0, null, BG, $"Because I just finished is still one day, I do not know what's coming.");
//            DoC(g, 0, null, BG, $"I feel heavy considering that fact.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~ ahh.....");
//            DoC(g, 0, null, BG, $"I definitely do not want to cross a line. I do not want to do something like yesterday again.");
//            DoC(g, 0, null, BG, $"Perhaps I can dig into Mr. Mitsudo if I lie to the point that I have fallen ill.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~But, I'm going to be able to see through lies I throw up .");
//            DoC(g, 0, null, BG, $"Even just one day yesterday, it's Minafuji was able to understand a little.");
//            DoC(g, 0, null, BG, $"...... I want to say, but I can not read any action at all and I can not understand that behavior.I only understood.");
//            DoC(g, 0, null, BG, $"In the end it was such a thing, but I still do not know why why I took a meal or a movie.");
//            Size2 = 1500; posX2 = 0; posY2 = 0;
//            MAN = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
//            DoC(g, 0, MAN, BG, $"",
//                OpEf.AppCurr(2, "W..0>O.B.2000.+100"));
//        }
//        private void Cartina_DayAfterFinansistHotelFuck()
//        {
//            string BG = BG_DAY_BEDROOM; //
//            string MAN = MAN2;

//            currentGr = "20.Day after hotel fuck.";
//            int i = 863; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000007.wav");
//            //Music ============================

//            DoC(0, 0, null, BG, $"While I was anxious, I was frightened and waited, but even though evening I did not hear from Mr. Mito.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            int g = 1049;
//            posX1 = 135;
//            DoC(g, 0, null, BG, $"{Girl}~I wonder if I should contact you from ...?",
//                OpEf.AppearCurrent(1)
//            );
//            DoC(g, 0, null, BG, $"I just wait at home, but my sense of mental exhaustion is terrible.");
//            DoC(g, 0, null, BG, $"Today I was not cleaned and washing, but I was completely tired.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~(But I also have trouble contacting me and becoming a snorkeler)");
//            DoC(g, 0, null, BG, $"It is not necessary if there is no contact, because that person is kind enough for me.");
//            g = 1050;
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~ahhh",
//                OpEf.HidePrev(1));
//            DoC(g, 0, null, BG, $"After all, I could only sigh.");
//            Size2 = 1500; posX2 = 0; posY2 = 0;
//            MAN = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
//            DoC(g, 0, MAN, BG, $"",
//                OpEf.AppCurr(2, "W..0>O.B.2000.+100"));
//        }
//        private void Cartina_EveningAfterFinansistHotelFuck()
//        {
//            string BG = BG_EVENING_BEDROOM; //
//            string MAN = MAN2;

//            currentGr = "21.Evening after hotel fuck.";
//            int i = 863; // voice indexer
//            CurrentSounds = new List<seSo>();
//            //Music ============================
//            AddMusic("music.arc_000009.wav");
//            //Music ============================

//            DoC(0, 0, null, BG, $"I kept waiting at home forever, but there was no contact from Mr. Minato");
//            DoC(0, 0, null, BG, $"The date of the clock's hand is about to change soon.");

//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            int g = 1049;
//            posX1 = 135;
//            DoC(g, 0, null, BG, $"{Girl}~Anything, I will not be called from such a time ... Yayoi",
//                OpEf.AppearCurrent(1)
//            );
//            DoC(g, 0, null, BG, $"Kohei, too, was busy with work today and I could not video chat.");
//            DoC(g, 0, null, BG, $"But, it is painful to see the face properly now, so I feel like I was not good.");
//            g = 1050;
//            posX1 = 135;
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~ahh",
//                OpEf.HidePrev(1)
//            );
//            DoC(g, 0, null, BG, $"Мне немного грустно, что я чувствую облегчение, что не могу поговорить с г-ном Кохеем.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~I have not been called today, but I have five days to keep promises.");
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            DoC(g, 0, null, BG, $"{Girl}~I wonder if it is tomorrow ...... Yayoi");
//            DoC(g, 0, null, BG, $"When I think about things from tomorrow, I feel still heavy.");
//            DoC(g, 0, null, BG, $"It's about time we had to go to bed, but I thought of various things, I had not been able to sleep yet for a while.");
//            Size2 = 1500; posX2 = 0; posY2 = 0;
//            MAN = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
//            DoC(g, 0, MAN, BG, $"",
//                OpEf.AppCurr(2, "W..0>O.B.2000.+100"));

//            CurrentSounds.RemoveAll(x => x.Name == "MUSIC");
//            AddEffect2($"effect.arc_000018.wav", SoundPauseNone, false);//Effect - night
//            BG = BG_NIGHT_SKY;
//            DoC(0, 0, null, BG, $".....",
//                OpEf.HidPrev(2, "W..0>O.B.2000.-100"));
//            DoC(0, 0, null, BG, $"..... .....");
//            DoC(0, 0, null, BG, $"..... ..... .....");
//            CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");

//            BG = BG_MORNING_SKY;
//            DoC(0, 0, null, BG, $"But even the next day -",
//              OpEf.HidPrev(0, "W..0>O.B.2000.-100"));
//            DoC(0, 0, null, BG, $"And next day -");

//            AddMusic("music.arc_000001.wav");
//            BG = BG_MORNING_BEDROOM; //
//            DoC(0, 0, null, BG, $"There was no contact from Mr. Minato.",
//                       OpEf.HidPrev(0, "W..0>O.B.2000.-100"));

//            i = 870;
//            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
//            g = 1049;
//            posX1 = 135;
//            DoC(g, 0, null, BG, $"{Girl}~Three days left ...... What do you mean ...?",
//                OpEf.AppearCurrent(1)
//            );

//        }
   



//        private void AddCadr(int index, string Bg, string text, OpEf op = null)
//        { DoC(index, 0, null, Bg, text, op); }
//        private void AddCadr(int index, string Bg, string text)
//        { AddCadr(index, null, Bg, text); }
//        private void AddCadr(int index, string man, string Bg, string text)
//        { DoC(index, 0, man, Bg, text); }
//        private void AddCadr(int index, int index1, string Bg, string text)
//        { DoC(index, index1, null, Bg, text); }
//        private void DoC(int index, int index1, string man, string Bg, string text)
//        {
//            DoC(index, index1, man, Bg, text, null);
//        }
//        private void DoC(int index, int index1, string man, string Bg, string text, params OpEf[] oefa)
//        {

//            string g = null;
//            string g1 = null;
//            if (index > 0) g = data[index - 1];
//            if (index1 > 0) g1 = data[index1 - 1];
//            DoC(g, g1, man, Bg, text, oefa);
//        }
//        private void DoC(string g, string g1, string man, string Bg, string text, params OpEf[] oefa)
//        {

//            if (string.IsNullOrEmpty(Bg))
//                Bg = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";

//            List<DifData> cdata = null;

//            cdata = new List<DifData>()
//            {
//               new DifData(Bg) { S = s, F = 0}
//            };

//            #region Z Staff
//            if (posZ3 == 3)
//            {
//                if (g1 != null)
//                {
//                    cdata.Add(new DifData(g1) { S = Size3, X = posX3, Y = posY3 });
//                }
//            }
//            else if (posZ2 == 3)
//            {
//                if (!string.IsNullOrEmpty(man))
//                {
//                    cdata.Add(new DifData(man) { S = Size2, X = posX2, Y = posY2 });
//                }
//            }
//            else if (posZ1 == 3)
//            {
//                if (g != null)
//                {
//                    cdata.Add(new DifData(g) { S = Size1, X = posX1, Y = posY1 });
//                }
//            }

//            if (posZ3 == 2)
//            {
//                if (g1 != null)
//                {
//                    cdata.Add(new DifData(g1) { S = Size3, X = posX3, Y = posY3 });
//                }
//            }
//            else if (posZ2 == 2)
//            {
//                if (!string.IsNullOrEmpty(man))
//                {
//                    cdata.Add(new DifData(man) { S = Size2, X = posX2, Y = posY2 });
//                }
//            }
//            else if (posZ1 == 2)
//            {
//                if (g != null)
//                {
//                    cdata.Add(new DifData(g) { S = Size1, X = posX1, Y = posY1 });
//                }
//            }

//            if (posZ3 == 1)
//            {
//                if (g1 != null)
//                {
//                    cdata.Add(new DifData(g1) { S = Size3, X = posX3, Y = posY3 });
//                }
//            }
//            else if (posZ2 == 1)
//            {
//                if (!string.IsNullOrEmpty(man))
//                {
//                    cdata.Add(new DifData(man) { S = Size2, X = posX2, Y = posY2 });
//                }
//            }
//            else if (posZ1 == 1)
//            {
//                if (g != null)
//                {
//                    cdata.Add(new DifData(g) { S = Size1, X = posX1, Y = posY1 });
//                }
//            }

//            #endregion

//            if (oefa != null)
//            {
//                foreach (var oef in oefa)
//                {
//                    if (oef != null)
//                    {
//                        DifData d = null;
//                        if (!oef.P)
//                        {
//                            d = cdata[oef.L];
//                        }
//                        else
//                        {
//                            var old = this.AlignList.Last().AlignList[oef.L];
//                            d = new DifData();
//                            d.AssingFrom(old);
//                            d.Name = old.Name;
//                            d.Parent = old.Parent;
//                            d.S = old.S;
//                            cdata.Add(d);
//                        }
//                        if (oef.Tran != null)
//                        {
//                            d.O = oef.O;
//                            d.T = oef.Tran;
//                        }
//                        else
//                        {
//                            if (oef.D)
//                            {
//                                if (d != null)
//                                {
//                                    d.O = 100;
//                                    d.T = $"W..{oef.W}>O.B.{oef.T}.-100";
//                                }
//                            }
//                            else
//                            {
//                                if (d != null)
//                                {
//                                    d.O = 0;
//                                    d.T = $"W..{oef.W}>O.B.{oef.T}.100";
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            if (ORGAZM)
//            {
//                cdata.Add(new DifData() { Name = "FLASH_BG", O = 0, S = 1370, T = Transitions.Orgazm });
//                ORGAZM = false;
//            }

//            AddLocal(currentGr, text, cdata, this.CurrentSounds);
//            this.ClearSound(false, true, true);
//        }


//        private void AddCadre2(int index, string text, int? Xx = null)
//        {
//            string im = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
//            if (index > 0)
//                im = data[index - 1];
//            List<DifData> cdata = null;
//            if (Xx.HasValue)
//            {
//                cdata = new List<DifData>()
//                {
//                    new DifData(im) {X = -95, S = 1525, F = 0},
//                };
//            }
//            else
//            {
//                cdata = new List<DifData>()
//                {
//                    new DifData(im) {X = -95, S = 1525, F = 0},
//                };
//            }
//            AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadreAoiKohei(int index, string gm, string text)
//        {
//            List<DifData> cdata = new List<DifData>() {
//            new DifData(data[index - 1]) { X = 0, S = s, F = 0},
//            new DifData(gm) { Y = 540, S = 230, F = 0},
//            }; AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadre(int index, string text, int? Xx = null)
//        {
//            string im = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
//            if (index > 0)
//                im = data[index - 1];
//            List<DifData> cdata = null;
//            if (Xx.HasValue)
//            {
//                cdata = new List<DifData>()
//                {
//                    new DifData(im) {X = Xx, S = s, F = 0},
//                };
//            }
//            else
//            {
//                cdata = new List<DifData>()
//                {
//                    new DifData(im) { S = s, F = 0},
//                };
//            }
//            AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadreAoiMinodo(int index, string text)
//        {
//            List<DifData> cdata = new List<DifData>() {
//             new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -115, Y = -15, S = 2095, F = 0},
//             new DifData(data[index - 1]) { X = -425, S = 1500, F = 0},
//            }; AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadreAoiAsahi(int index, int index1, string text)
//        {
//            List<DifData> cdata = new List<DifData>() {
//            new DifData(data[index - 1]) { X = 385, S = s, F = 0},
//            new DifData(data[index1 - 1]) { X = -330, S = s, F = 0},
//            }; AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadreAoiAsahiKimishima(int index, int index1, int index2, string text)
//        {
//            List<DifData> cdata = new List<DifData>() {
//            new DifData(data[index1 - 1]) { X = 450, S = 1230, F = 0},
//            new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -485, Y = 5, S = 1540, F = 0},
//            new DifData(data[index - 1]) { X = 65, S = 1230, F = 0},
//            }; AddLocal(currentGr, text, cdata);
//        }
//        private void AddCadreAoiAsahiKimishim2(int index, int index1, int index2, string text)
//        {
//            List<DifData> cdata = new List<DifData>() {
//            new DifData(data[index1 - 1]) { X = 320, S = 1500, F = 0},
//            new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -695, Y = -15, S = 2095, F = 0},
//            new DifData(data[index - 1]) { X = -35, S = 1500, F = 0},
//            }; AddLocal(currentGr, text, cdata);
//        }



//        protected override void DoFilter(string cadregroup)
//        {

//            string[] cd = new string[] {
//              "18.Love Hotel - second part."
//               // "21.Evening after hotel fuck."
//            };
//            base.DoFilter(cd);
//            this.AlignList.Reverse();
//        }
//    }

//    public class MorfableName
//    {
//        public MorfableName(string i)
//        {
//            this.I = i;
//        }
//        public override string ToString()
//        {
//            return this.I;
//        }
//        public string I;
//        public string R;
//        public string V;
//        public string T;
//        public string D;
//        public string P;
//    }
//}
