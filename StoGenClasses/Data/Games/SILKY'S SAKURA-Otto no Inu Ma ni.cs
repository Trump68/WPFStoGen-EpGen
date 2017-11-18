
using StoGenMake;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StoGen.Classes.Data.Games
{
    public class SILKYS_SAKURA_OttoNoInuMaNi : BaseScene
    {
        class OpEf //Opacity transition effect
        {
            //new OpEf(1, true, 250, true, 1000)); to dissapear previous
            //new OpEf(1, false,250, false,1000) to appear current
            //new OpEf(1, true, 100, "W..0>O.B.400.-100*W..0>Y.B.200.300")
            public static OpEf AppearCurrent(int i)
            {
               return new OpEf(i, false, 250, false, 0);
            }
            public static OpEf AppCurr(int i, string t)
            {
                return new OpEf(i, false, 0, t);
            }
            public static OpEf HidPrev(int i, string t)
            {
                return new OpEf(i, true, 100, t);
            }
            public static OpEf HidePrev(int i)
            {
                return new OpEf(i, true, 250, true, 0);
            }
            public OpEf(int l, bool p, int t, bool d, int w)
            {
                L = l;
                P = p;
                T = t;
                W = w;
                D = d;
            }
            //string CurrentTran = "W..1000>X.B.3000.100";
            public string Tran = null;
            public OpEf(int l, bool p, int o, string tran)
            {
                L = l;
                P = p;                
                O = o;
                Tran = tran;
            }
            public OpEf(int l, int t)
            {
                L = l;               
                T = t;
            }
            public int L = 0; // pic level            
            public bool P = false; // false - current, true - previous
            public int T = 500; //speed time, ms
            public int W = 500; //wait time, ms
            public bool D = true;//direction, true - dissapeared, false - appeared

            public int O { get; set; } = 100;
        }
        public SILKYS_SAKURA_OttoNoInuMaNi() : base()
        {
            Name = "SILKYS_SAKURA_OttoNoInuMaNi";
            EngineHiVer = 1;
            EngineLoVer = 0;

           

        }

        List<string> data = new List<string>();
        List<seSo> CurrentSounds = new List<seSo>();
        string PATH_V = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Voice\";
        string PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
        string PATH_E = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Effect\";
        int VOLUME_V = 9;
        int VOLUME_M = 1;
        int VOLUME_E = 9;
        int VOLUME_E2 = 1; // prolonged effect {loop=true}

        int SoundPauseNone = 0;
        int SoundPauseShort = 500;
        int SoundPauseNorm = 1000;
        int SoundPauseLong = 2000;
        string BG_EVENING_CABINET = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
        string BG_EVENING_STREET = "SILKYS_SAKURA_OttoNoInuMaNi_BG07"; // evening street
        string BG_NIGHT_SKY = "SILKYS_SAKURA_OttoNoInuMaNi_BG08"; // night sky
        string BG_LOVE_HOTEL = "SILKYS_SAKURA_OttoNoInuMaNi_BG09"; // love hotel
        string MAN1 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
        string MAN2 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_2";
        string MAN3 = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_3";
        
        HumanName BadMan = new HumanName("");
        HumanName GoodMan = new HumanName("");
        HumanName Girl = new HumanName("");

        bool ORGAZM = false;
        int s = 1370;
        protected override void LoadData()
        {
            this.BadMan.I = "мистер Минода";
            this.BadMan.R = "мистера Миноды";
            this.BadMan.D = "мистеру Миноде";
            this.BadMan.V = "мистера Миноду";
            this.BadMan.T = "мистером Минодой";
            this.BadMan.P = "мистере Миноде";

            this.GoodMan.I = "дон Витра";
            this.GoodMan.R = "дона Витры";
            this.GoodMan.D = "дону Витре";
            this.GoodMan.V = "дона Витру";
            this.GoodMan.T = "доном Витрой";
            this.GoodMan.P = "доне Витре";

            this.Girl.I = "Ксения";
            this.Girl.R = "Ксении";
            this.Girl.D = "Ксении";
            this.Girl.V = "Ксению";
            this.Girl.T = "Ксенией";
            this.Girl.P = "Ксении";

            string gr;
            string src;
            string text;
            

            string path = @"d:\Process2+\HCG\SILKY'S SAKURA\Otto no Inu Ma ni\EVENTS\";
            for (int i = 1; i <= 1100; i++)
            {
                src = $"SILKYS_SAKURA_OttoNoInuMaNi_{i.ToString("D4")}";
                string fn = $"{i.ToString("D4")}.png";                
                AddToGlobalImage(src, fn, path);
                data.Add(src);
            }
            
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER", "PLACEHOLDER.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01", "BM01.png", path);
            

            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "BM01_1.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_2", "BM01_2.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM01_3", "BM01_3.png", path);

            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "BM02_1.png", path);


            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "BM02_2.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "GM01_1.png", path);
	        AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "GM01_2.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "GM01_3.png", path);


            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG01", "BG01.png", path);//blue sky
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG02", "BG02.png", path);// day office
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG03", "BG03.png", path);// evening street
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG04", "BG04.png", path);// { Evening bedroom}
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG05", "BG05.png", path);// { Morning livingroom}
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG06", "BG06.png", path);// { hight office}
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG07", "BG07.png", path);// { hight street}
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG08", "BG08.png", path);// { hight sky}
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG09", "BG09.png", path);// { love hotel}

            AddToGlobalImage("FLASH_BG", "WHITE.JPG", path);

            this.DefaultSceneText.Size = 200;
            this.DefaultSceneText.Width = 1000;
            this.DefaultSceneText.FontSize = 32;            
            this.DefaultSceneText.Shift = 250;
            this.DefaultSceneText.FontColor = "White";

            currentGr = "Save2-1";

            DoScenario();
        }
        string currentGr;
        int S1 = 1000;
        int S2 = 1000;
        int S3 = 1000;
        

        int X1 = 0;
        int X2 = 0;
        int X3 = 0;
        
        int Y1 = 0;
        int Y2 = 0;
        int Y3 = 0;

        int Z1 = 1;
        int Z2 = 2;
        int Z3 = 3;



        private void DoScenario()
        {                       
            Cartina_HusbCall1();
            Cartina_GoToFinancist();
            Cartina_FirstMeetingWithFinancist();
            Cartina_FinanceTrap();
            Cartina_HusbCall2();
            Cartina_EveningCall();
            Cartina_NaughtyProposal();
            Cartina_WalkingAfterProposal();
            Cartina_BeforeHusbCall3();
            Cartina_HusbCall3();
            Cartina_Choice3_2();
            Cartina_MorningBeforeDate();
            Cartina_PreparationsToDate();
            Cartina_ChangingClothInCabinet();
            Cartina_EveningPromenad();
            Cartina_LoveHotelBegin();
            Cartina_Blowjob();
            Cartina_FinansistHotelFuck();
        }

        private void Cartina_HusbCall1()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            AddCadre(1001, "Kohei~Я доверяю тебе. Конечно, если тебе понадобится моя помощь, сразу скажи.");
            AddCadre(1001, "{Girl}~Да, в этот раз, пожалуйста ... ... Кохей-сан.");
            AddCadre(0991, "В ситуациях, когда я не могу стать силой, это, безусловно, будет поворот Кохей-сан.");
            AddCadre(0991, "Но я не полагаюсь на это с самого начала, я хочу делать то, что могу сделать для себя.");
            AddCadre(0991, "Я верил и признался, для Асахи.");
            AddCadre(0991, "{Girl}~Спасибо, Кохей-сан. Было хорошо поговорить.");
            AddCadre(0992, "Kohei~Благодарю за меня. Заботиться о моей сестре об этом ... ....");
            AddCadre(0992, "{Girl}~Потому что Асахи тоже важная сестра? Это естественно.");
            AddCadre(0991, "Kohei~Ха-ха, я буду рад, если ты так скажешь.");
            AddCadre(0991, "{Girl}~Хих");
            AddCadre(0991, "Я чувствую себя спокойно, несмотря на возможность поговорить с г-ном Кохеем.");
            AddCadre(0991, "Может быть, я был слишком в восторге от того, чтобы стать силой Асахи, может быть, это было немного сложно.");
            AddCadre(0991, "{Girl}~Что ж, если что-то я снова свяжусь с вами?");
            AddCadre(0991, "Kohei~Точно. Конечно, я зря беспокоюсь.");
            AddCadre(1011, "{Girl}~Спасибо, мистер Кохей ... Я люблю тебя. ");
            AddCadre(1014, "Kohei~Я тоже ... ... Я люблю тебя, Яой. Хорошо, спокойной ночи.");
            AddCadre(1014, "{Girl}~Да, спокойной ночи ... Yayoi");
            AddCadre(1014, "Встряхните маленькую руку на экране, Кохей-сан отрезал видео-чат.");
            AddCadre(1046, "{Evening bedroom} {Girl}~Итак ... Хорошо, давайте сделаем все возможное ...!");
            AddCadre(1046, "{Evening bedroom}~Давайте попробуем все возможное, чтобы сделать все возможное, чтобы восстановить полную улыбку Асахи.");
            AddCadre(1046, "{Evening bedroom}~В видеочате с Кохей я так чувствовал.");

            ClearSound();
        }
        private void Cartina_GoToFinancist()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            AddCadre(0000, "{Morning street}~Через два дня контакт Асахи-чан вошел в место владельца автомобиля вместе.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~Успокойся, Асахи-чан? Хорошо, потому что я буду говорить с вами правильно.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Асахи~Ну, да... ....Спасибо, мистер Яойи ... ...");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У Асахи есть взгляд, который выглядит довольно серьезным, и ее цвет лица выглядит как кровь.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Когда я подумал, что это было непросто, мое сердце сжалось.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(В конце концов я волнуюсь ... ...)");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Мне определенно нужно как-то справляться.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Асахи не просто сестра Кохея, у меня для меня особое чувство.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители г-на Кохей и Асахи строги.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители не выступали против себя в то время, когда они вступили в брак со мной, которая была супер-частью в то время, но они не активно благословляли меня агрессивно.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Среди них Асахи-чан просто сделал меня счастливым и благословил нас.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Нет ничего несчастного, как брак, который не благословляется от другой семьи.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Как я чувствовал это, благословение от Асахи было действительно счастливым.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(Асахи-чан был там, это как я поженился)");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Поскольку Асахи благословил меня, я думаю, что смог выйти замуж.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У меня все еще мало обмена с родителями, но мне интересно, будут ли дети сделаны в будущем, это обязательно изменится.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}{Girl}~(Потому что моя мама с нетерпением ждет этого ... ...)");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Для родителей Кохея также, если мы можем иметь детей, мы становимся первыми внуками.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Это наверняка понравится, и я почувствовал, что изменил бы то, как я отношусь к различным вещам.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Asahi~Это похоже на это здание.");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}Яйой~Здесь ...");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Адрес, который сказал Асахи, был зданием скалы в месте, подобном району красного света в городе.");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}{Girl}~Ну, тогда пойдем ли мы?");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}Асахи~Ну, да ...");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Я вошел в здание, чтобы привести Ашиги в нервное состояние.");

            ClearSound();
        }
        private void Cartina_FirstMeetingWithFinancist()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            AddCadre(000, "{Morning cabinet}~В комнате, казалось, был офис, который обставил мебель, которая, казалось, была высокой, и имела какую-то сомнительную атмосферу.");
            AddCadre(000, "{Morning cabinet}~В этой комнате Асахи-чан сталкивается с владельцем автомобиля, который поцарапан.");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}Wisterie~Добро пожаловать, г-н Кимишима. Там ... ... ");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Поговорив с Асахи-чан, человек владельца увидел меня");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}{Girl}~Это невестка Йошио Кимишимы. Сегодня я сопровождаю ее ...");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Позволь мне скрыть испуганного Асахи спиной, я пойду вперед и поприветствую.");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}{Girl}~?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Вижу, я был женат ... ... Это было давно, вы знаете?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~После небольшого удивления, увидев меня, я так внезапно говорю.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Интересно, встретил ли я где-нибудь.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Разве ты не помнишь?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~... ... Ах!");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Я вспомнил. Конечно, этот человек является одним из партнеров, которые мои родители заимствовали.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}{Girl}~... ... конечно, мистер Миното ...?");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}Wisterie~Да, это так. Ни в коем случае, что ты был тем, кем был женат, был ее старший брат.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Глядя на Чирари и Асахи, которые прятались позади меня, Мидода говорит так и улыбается.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}{Girl}~Ну, это было давно ... Извините, я не могу сразу вспомнить ...");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Ну, я не собираюсь встречаться с тобой напрямую.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Г-н Ито был одним из партнеров, который смог занять деньги у родителей, которые не смогли выполнить проект в деньгах.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Я приходил домой несколько раз, и я обменивался приветствиями.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Но не было памяти, о которой я говорил правильно, и я едва мог вспомнить свое имя, но это почти исчезло из моей памяти.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Мистер Кимисима, нет, теперь ты Кимишима-сан. Я думал, что придут ее родители.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~То, что обстоятельства ее родителей неудобны, интересно, послушаю ли я историю.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Хм ... Ну, может быть. Потому что есть и история, давайте сядем и поговорим об этом.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}{Girl}~Да, извините ... ... Асахи-чан? ");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Асахи~Ну, да ... ");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Г-н Асада, одетый в неповторимую атмосферу перед мистером Ито, совершенно пьян.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Напряжение достигло пика, или казалось, что ее цвет лица ухудшается.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Яйой~(Если я не уверен ... ...) ");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Особенно это был не перевод, который был связан, но он был хорошим не партнером, которого я вообще не знаю.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Я вспомнил о себе, и было бы легко говорить.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~На данный момент я был соблазнен мистером Миното и сел на кожаный диван, похожий на стойку регистрации.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Как далеко вы слышали от нее?");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Яйой~Ах, я в порядке с Яой. Yayoi");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Ну, тогда я могу назвать тебя Яйо?");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Да. Хм, я думал, что минодо поцарапал его машину ... поэтому мы попросили о консультациях по поводу расходов на ремонт. ");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Рассказ идет быстро, если вы его слушаете.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Минодо кивает и достает что-то вроде документа.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Это оценка ремонта, полученная от производителя.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Благодарю вас. ");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Документы с иностранными языками отмечены автомобилями, которые я не знаю.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~... ... Это ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я не знаю, где это, и я даже не знаю единицы денег в первую очередь.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Говорят, что это составляет около 30 тысяч евро, общая стоимость транспортировки и стоимость ремонта.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Является ли ... ... 30 тысяч евро? ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если я попрошу эту сумму, я не прихожу с булавками.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Сколько будет стоить японская иена евро?");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я наклонил шею рядом со мной, хорошо ли понял Асахи.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Сегодняшний курс ...... Это около 3750 000 иен, переведенных в японскую иену.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Рассматривая смартфон, г-н Сада сказал, что Сара такая.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Скажи, сноб.? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Что, Junjun!?");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Только с ограниченным цветом я не могу перекрасить только часть. Я должен перевезти его на родину и раскрасить.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Ну, но ... это так много ...?! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Вау, я, немного, просто царапина ...! ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Сама царапина была маленькой. Но сверх того, что я думал, было глубоко включено. Поверхностный ремонт не вернется к оригиналу.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~Это ... ... такое ... ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~Как вы поживаете, Yayoi san ...... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асахи полностью потерял кровь и имел бледно-синее лицо.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Поскольку это оценка ремонта от официального производителя, вы можете принять ее. Потому что вы можете это взять.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Это так, или это ... ... Но эта сумма денег ... Это действительно необходимо ...? ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Учитывая цену кузова, она дешевая. Этот автомобиль, цена покупки более чем в десять раз больше.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Ну, это дорого! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}{Girl}~Ю, в десять раз ... ... Я куплю тебе дом ...! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Я удивляюсь, когда собираются два человека.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Мне сказали, что это дорогая иномарка, но это был не такой роскошный автомобиль.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Ноги Асахи, сидящие рядом со мной, дрожали от щетинок.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Не расстраивайся до меня до конца.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Это то, что я подумал, но, просто глядя на сумму денег, моя внутренняя часть головы стала белой.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Должен ли я говорить о конкретной компенсации, если в ней нет проблемы?");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}{Girl}~Ах, что ... ... сумма - это сумма, так зачем платить сразу ... ");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Г-н Кохей и г-н Кохей хранят столько, сколько они есть, но это не очень хорошо, но я не могу заплатить.");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Вероятно, я посоветуюсь с моими родителями, но я до сих пор не знаю, смогу ли я заплатить сразу.");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Хм ... ...");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}{Girl}~Не решите ли вы заплатить, разделив ...? ");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Если вы не заплатите расходы на ремонт, автомобиль не вернется ко мне, но должен ли я выполнять процедуру разделения самостоятельно?");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Яйой~Гм ... ... что, что ... ... ");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}~Разумеется, как говорит г-н Минато, место для оплаты стоимости ремонта - это автомагазин, поэтому мы должны попросить вас там.");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Wisterie~Ну, затраты на ремонт могут быть погашены мной.");
            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}{Girl}~Это правда? ? ");
            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}Wisterie~У меня будут проблемы, если машина не вернется.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}{Girl}~Это так? ... Мне жаль беспокоить вас, но я буду спасен, если вы это сделаете. ");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Сумма стоит дорого, но она не будет выплачена, если она будет разделена.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Проблема заключается в количестве разделов.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Это совсем не так, как если бы вам сказали, что вы платите в два или три раза.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Конечно, вам нужна определенная уверенность в том, что вы можете заплатить это твердо.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~Хм ... ... Правильно, не так ли? ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Способ говорить нежен, но есть мощные слова и голоса, которые не позволяют вам говорить.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже когда я разговаривал с родителями в доме моих родителей, я даже не портил свой голос спокойным тоном, но у меня было немного страшное впечатление.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Коллекции различных долгов приходили в дом моих родителей, но было что-то общее для этих людей.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~(Поскольку он, кажется, поделен в любом случае, посоветуйтесь с ним впоследствии ... ...) ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Нам нужно поговорить с г-ном Кохеем, и мы должны поговорить с обоими родителями.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асахи может не любить, но погашение этой суммы не может быть сделано моим собственным суждением.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~, Yayoi san ... ...., Если это нормально с разделением, то ... ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Пораженный ценой, Асахи, который полностью испугался, хочет принять слова минодо.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я еще не слышал о методе погашения, и я думаю, что здесь нехорошо решать.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я чувствовал, что это будет неприятно, если бы я консультировался только с Кохеем.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~(Но на этот раз Kohei все еще работает ... ...) ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~У меня не было много времени. Если это нормально держать в вертикальном положении, я бы хотел, чтобы вы ответили так.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Если вам интересно, что делать, г-н Миното также должен будет ответить.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~И Yayoi ... ...! ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асака крепко держит мою руку.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Потная рука дрожала, и я почувствовал разочарование в глазах, глядя на меня.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~(Ну, во всяком случае, вы должны заплатить ... ne.) ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если родители Асахи были необоснованны, я должен был что-то сделать.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}{Girl}~Ничего себе .... ОК. Я верну его, разделив, поэтому, пожалуйста, измените его. ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Я понимаю. Давайте подготовим документ сразу. ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Вот и все, мистер Муто встает.");
            AddCadre(0000, "{Morning cabinet}~……");
            AddCadre(0000, "{Morning cabinet}~……");
            AddCadre(0000, "{Morning cabinet}~……");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~Вот и подпись здесь.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Некоторое время он был заимствован для мистера Миноды.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Конечно, общая стоимость ремонта.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Я заимствовал его у мистера Мито.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Асахи~Г-н Яойи ...... ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Я понимаю ... ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Меня радует нетерпеливый голос Асахи, я подписываю заимствованное письмо.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~...... Официальный документ находится на более позднем этапе, поэтому сегодня я его принимаю.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Да ... ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~Я хотел бы снова связаться с вами, но было ли лучше для вас, Яой?");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}{Girl}~Ну, это так, пожалуйста, сделайте это со мной. ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Мы обменялись контактами с г-ном Маото, и обсуждение расходов на ремонт завершено.");

            AddCadre(1016, "{Day street}Асахи~Yayoi, Большое вам спасибо ... Если бы я был один, я не мог бы говорить правильно ... ", -270);
            AddCadreAoiAsahi(1049, 1016, "{Day street}{Girl}~Хорошо, это примерно ...... ");
            AddCadreAoiAsahi(1049, 1016, "{Day street}~Асахи - чан, казалось, с облегчением почувствовала, решила ли она, что проблема решена.");
            AddCadreAoiAsahi(1049, 1016, "{Day street}~Но я знаю, это тяжелая работа с этого момента.");

            AddCadre(0000, "{Blue sky}~Через несколько дней после подписания взятой записки -");
            AddCadre(0000, "{Blue sky}~Когда мне сказали, что я хотел бы поговорить о погашении, я пошел в кабинет минодо.");

            ClearSound();
        }
        private void Cartina_FinanceTrap()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~О ... о ... да ... Извините. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Ну, это мгновение ... ... вкус не должен быть плохим.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот почему сам мистер Ми Ито сам кофе.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Не было абсолютно никакого места, чтобы осмотреться, но в этом офисе есть только стол мистера Миното.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Гм ... ... Ты работаешь одна? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~── О, я был один.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это так правильно? ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~У меня есть вещи в доме моих родителей и даю мне деньги, но какая работа вы здесь делаете?");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Место, где это место, также является местом, которое находится на одном шагу от входа в центр города, а не в офисный город.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это было многолюдное здание с несколько подозрительной атмосферой, и была атмосфера, в которой я ничего не мог сказать.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я хотел бы подтвердить это как можно скорее. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Да ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Г-н Минато так сказал и достал документ.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Письмо было напечатано и написано как соглашение о заимствовании.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Хм, это ...? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~На днях я заимствовал написанное вами письмо, сделав его официальным документом.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это официальный документ ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот что я сказал, я снова посмотрю на это.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Что-то трудное написано, и я даже не знаю, с чего смотреть.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Хорошо, давайте проверим их. Если есть моменты, о которых стоит беспокоиться, вы можете поговорить позже позже.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Да ... ... Пожалуйста ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато также сел на диван и объяснил о соглашении о заимствовании.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Контент состоял в том, что я заплачу все деньги, которые он взял за ремонт автомобиля, заимствованный у мистера Мито.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Это означает, что мы заимствуем у мистера Мито, используя его для расходов на ремонт ... не так ли? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~О, вот и все. И ты вернешь его мне. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Да ... ... Но эта сумма ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Сумма, написанная там, была больше, чем предыдущая история.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Кроме того, доля, называемая процентными ставками, увеличивается, а в части, записанной как ежемесячная сумма погашения, была написана сумма, которую я не представлял.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Из-за обесценения йены на нее влияет обменный курс. Кроме того, это только оценка до последней.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Ну, это правильно .... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я не совсем понимаю, интересно, это что-то в этом роде.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Конечно, по телевизионным новостям, я чувствую, что обесценивание йены продолжается, и импортируемые продукты растут, я говорил о такой истории.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Стоимость ремонта автомобиля может быть такой же.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Но проблема была не в сумме, а в ежемесячной сумме погашения.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Ах, это ... ... Это ежемесячная сумма погашения, но ее трудно заплатить ... ... Можете ли вы продлить срок погашения еще немного ...? ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~В текущем документе период погашения составляет один год.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Ежемесячная сумма погашения была больше, чем бюджет нашей семьи.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Но у меня не было больше времени на погашение.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Это ... ... Такое ... ... Но эта сумма невозможна ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~У вас нет проблем, даже если вы так говорите. Вы сказали, что заплатите, разделив вас, и вы ничего не сказали о периоде погашения?");
            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Это ...! Да, но ... ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Тонус г-на Минато спокоен, и голос ее холодный.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Я помню атмосферу, когда я был где-то в доме родителей.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(В те дни, когда я разговаривал с отцами, это было так ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Это было потрясающе, и это не стало эмоциональным, но было такое впечатление, что остров не существует.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(Интересно, что я должен делать ...... Такая сумма, не очень ... но ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Разумеется, вам, возможно, придется подумать о том, как погасить его, консультируясь с Kohei-san и вашими родителями.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Асахи может не нравиться, но я не мог сделать ничего, что мог.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Ну, пока это консультации по конкретному методу погашения, я не соглашусь, конечно. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Эх ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Есть много способов оплаты. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато сказал так и улыбнулся.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это должна быть улыбка, но это выглядело как очень ослепительное выражение.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~(Что вы делаете ... ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Интересно, следует ли мне поговорить с г-ном Минато о методе погашения, как есть.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Однако, похоже, это не простой метод погашения.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Когда я услышал эту историю, я почувствовал, что больше не могу вернуться.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Вы решаете, что делать, вы решаете.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~Это ... ... ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Минато говорит так, но я не думаю, что у меня есть варианты.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Конечно, может быть, я действительно понял, что говорю, но я не могу избавиться от беспокойства.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}{Girl}~(...... Kohei Mi)");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Лицо Коэи перешло мне в голову, когда меня мысленно преследовали.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Если Кохей-сан, он может как-то справиться.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Даже г-н Минато может обсудить это должным образом.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Хотя я не хочу неудобств, если я не проконсультируюсь здесь, это может вызвать еще большие неудобства.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}{Girl}~Ах ... ... это ... Пожалуйста, позвольте мне поговорить с моей семьей однажды ... ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Мне удалось выжать мой голос и рассказать Миото.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~...... Где будут меняться условия консультаций?");
            AddCadreAoiMinodo(1051, "{Morning cabinet}{Girl}~Да, но ... время от времени ... Я просто хочу поговорить ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Чтобы не пить власть минодо, отчаянно старайтесь отважиться.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Если вы можете доверять г-ну Кохеи, вы наверняка сумеете что-то сделать.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Я могу сделать это, чтобы не спешить с заключением здесь, но как-нибудь вернуться домой.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~Это так? В этом случае давайте подождем ответ до конца этой недели.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Яйой~Ох ... О, спасибо ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Наконец г-н Минато принял мою просьбу.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Отчаянно стимулируйте освобождение и держите его в секрете, не ставя его на лицо.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~С этим мне удалось заработать время, чтобы поговорить с Kohei-san каким-то образом.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}{Girl}~Хорошо, тогда я извиню себя. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я был в отчаянии говорить спокойно, так что я не мог понять, когда я торопился.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я ожидаю ответа как можно скорее.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минодо не выражает ничего выражения, и я не совсем уверен, что вы думаете.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~(Во всяком случае, давайте поговорим с Кохей ... ...) ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~С этой мыслью я быстро пришел домой.");

            ClearSound();
        }
        private void Cartina_HusbCall2()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


            AddCadre(0000, "{Evening bedroom}~Ночью той ночью я был готов ругать Кохея, и я все признал.");
            AddCadre(0998, "KoheiЭто должно было случиться. ");
            AddCadre(0998, "{Girl}~Мне очень жаль, я что-то ранил ... Я не хотел беспокоить вас дополнительными неудобствами, но так получилось ... ");
            AddCadre(0998, "Мне было очень жаль, что он не беспокоил мистера Кохея, который занят работой.");
            AddCadre(0997, "Kohei~Потому что ты собираешься думать об Асахи, не так ли? Все в порядке, я знаю. ");
            AddCadre(1002, "Яйой~Кохей-сан ...! Э-э ... Э-э ... Го ... ... ");
            AddCadre(1002, "Это был предел, который я мог переносить своими слезами.");
            AddCadre(1001, "Kohei~Тебе не нужно плакать, я не думаю об этом. ");
            AddCadre(0996, "{Girl}~Но, я ... .... ");
            AddCadre(0997, "Kohei~Вместо этого, я хочу проверить, что это похоже на этот контракт, поэтому я хочу, чтобы вы отправили его на персональный компьютер и отправили его ... .... ");
            AddCadre(0997, "{Girl}~Ну, ты можешь это сделать ... ....? ");
            AddCadre(0997, "Я чувствовал, что мне кое-что было сказано несколько сложнее.");
            AddCadre(0997, "Kohei~Это не так сложно, так что все в порядке. Рядом с компьютером есть принтер, верно? ");
            AddCadre(0997, "{Girl}~Принтер об этом ... ...? ");
            AddCadre(0997, "Kohei~Правильно. Когда откроется это место, мне интересно, разместите ли вы там документ. ");
            AddCadre(1002, "{Girl}~Er ... ... документ ...... ");
            AddCadre(1002, "Будучи объясненным Кохей, я сделаю то, что сказал.");
            AddCadre(1002, "Г-н Кохей научил меня осторожно, не используя как можно больше технических терминов.");
            AddCadre(0000, "{Black screen}~....");
            AddCadre(0000, "{Black screen}~.... ....");
            AddCadre(0000, "{Black screen}~.... .... ....");
            AddCadre(0991, "{Girl}~Итак, нажмите здесь, в конце ... ... Ах, это сработало! ");
            AddCadre(0991, "Kohei~Да, это звучит неплохо. Он автоматически переключился на мой смартфон, так что все в порядке. ");
            AddCadre(0991, "{Girl}~Это так? Это было хорошо ...");
            AddCadre(0993, "Kohei~Действительно, соглашение о заимствовании ... ... Хм ... ...");
            AddCadre(0993, "Г-н Кохей смотрит на документы, которые я взял, и имеет сложное выражение.");
            AddCadre(0998, "{Girl}~(Kohei-san ......)");
            AddCadre(0998, "Я молчал и уставился на экран моего компьютера, чтобы это не мешало этой идее.");
            AddCadre(0998, "Kohei~Контактный номер другой стороны - это номер, написанный здесь, не так ли? ");
            AddCadre(0998, "Яйой~Эх, да .... ");
            AddCadre(0997, "Kohei~Я понимаю. Хорошо, тогда я попытаюсь как-нибудь попытаться. ");
            AddCadre(1002, "{Girl}~ぅ ...... Извините, я занят ... ");
            AddCadre(1002, "Kohei~Первоначально это проблема, поднятая Асахи, вам не нужно столько страдать.");
            AddCadre(1002, "{Girl}~Кохей-сан ...... ");
            AddCadre(1001, "Kohei~Я свяжусь с вами снова, если что-то будет. В любом случае, мне больше не нужно волноваться, поэтому не смотрите на меня так, я хочу, чтобы вы улыбались, как обычно. ");
            AddCadre(1006, "{Girl}~... .... Да, спасибо ... ... ты. ");
            AddCadre(1006, "Слезы, казалось, переполнились добрыми словами Кохея.");
            AddCadre(1006, "Но если ты заплачешь, Кохей-сан будет грустно.");
            AddCadre(1006, "С чувством сожаления и благодарности, на мой взгляд, я улыбнулся.");
            AddCadre(1009, "Kohei~Да, улыбка - лучшая для Яйоя. Ну тогда, спокойной ночи ... Я люблю тебя. ");
            AddCadre(1014, "{Girl}~Я тоже тебя люблю, ты ... ... Не подталкивай себя? ");
            AddCadre(1011, "Хорошо, даже если вы выглядите так, ваше тело сильное.");
            AddCadre(1011, "Несмотря на то, что я занят только работой, я действительно занят, полагаясь на неприятные вещи.");
            AddCadre(1011, "Тем не менее, Кохей-сан улыбался с другой стороны экрана ПК, сказав это.");
            AddCadre(1011, "Яйой~(На самом деле спасибо, Кохей-сан ... ...) ");

            ClearSound();
        }
        private void Cartina_EveningCall()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            AddCadre(0000, "{Evening livingroom}~После нескольких дней Кохей-сан получил телефонный звонок.");
            AddCadre(1049, "{Evening livingroom}{Girl}~Алло ......?");
            AddCadreAoiKohei(1049, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Я подумал, что было бы лучше спешить, поэтому я позвонил ей. Теперь все в порядке?");
            AddCadre(1049, "{Evening livingroom}{Girl}~Эх, да .... ");
            AddCadre(1049, "{Evening livingroom}~Потому что я знаю, что это мистер Минодо, я нервничаю, когда звоню с Кохеем.");
            AddCadre(1049, "{Evening livingroom}~Рука с телефоном слегка дрожала.");
            AddCadreAoiKohei(1049, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Скажу до заключения? Что касается расходов на ремонт, я думаю, что я уменьшу сумму.");
            AddCadre(1048, "{Evening livingroom}{Girl}~Эх ...! ? Это так ...? ");
            AddCadreAoiKohei(1048, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~В документах были различные недостатки, я указал, что мы тоже пришли с другой стороны.");
            AddCadre(1048, "{Evening livingroom}{Girl}~Я вижу ... ничего себе ... ... ");
            AddCadre(1048, "{Evening livingroom}{Girl}~В моем сознании не было ничего, чтобы выяснить легитимность суммы.");
            AddCadre(1048, "{Evening livingroom}{Girl}~I think that Mr. Kohei is great, after all, to think of such a thing.");
            AddCadreAoiKohei(1048, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Although it can not be said that repair expenses are escaped as expected, I think that it can be suppressed to some extent");
            AddCadre(1048, "{Evening livingroom}{Girl}~Thank you, Kohei-san ... I can not believe it. I am sorry, let me take time and effort on this ... ... ");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~No, I am the one who apologizes. I'm really sorry I can not stay by my side");
            AddCadre(1046, "{Evening livingroom}{Girl}~When I apologize at the phone entrance, on the contrary Kohei apologizes to Mr. Kohei.");
            AddCadre(1050, "{Evening livingroom}{Girl}~It was a feeling that my heart was tightened to that voice that seemed to be sorry.");
            AddCadre(1050, "{Evening livingroom}{Girl}~No, that's not the case ....");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~But I guess I was worrying a lot? I was able to do something if I was by my side ... ... ");
            AddCadre(1050, "{Evening livingroom}{Girl}~You ... ...");
            AddCadre(1050, "{Evening livingroom}{Girl}~Tears seemed to be overflowing with the thought of Kohei's me.");
            AddCadre(1050, "{Evening livingroom}{Girl}~(I can not bother you any more any more ... ...)");
            AddCadre(1050, "{Evening livingroom}{Girl}~Even though I am busy with work, I do not want to put an extra burden.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~The problem is the remaining amount and how to repay it ..");
            AddCadre(1050, "{Evening livingroom}{Girl}~... ... Do not worry, you. If I can keep even the amount, I will have it.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "{Evening livingroom}Kohei~Is that so?");
            AddCadre(1050, "{Evening livingroom}{Girl}~Yes. Mr. Minoto also does not know anything at all, so I will say that the concrete repayment method will ride in consultation.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~I see ... okay, but are you all right?");
            AddCadre(1050, "{Evening livingroom}{Girl}~Kohei - san 's voice on the phone's door seemed really worried.");
            AddCadre(1050, "{Evening livingroom}{Girl}~Even just listening to such a voice, I feel sorry and my chest tightened.");
            AddCadre(1050, "{Evening livingroom}{Girl}~Uhufu, all right. But thank you very much. Thanks to Kohei - san, it is likely to manage somehow. ");
            AddCadre(1050, "{Evening livingroom}{Girl}~It was good not to be a video chat.");
            AddCadre(1050, "{Evening livingroom}{Girl}~I can do it with words, but I did not have confidence to pretend to expressions.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~...... If Yayoi says so, I will believe it.");
            AddCadre(1050, "{Evening livingroom}{Girl}~Thank you, you ... ....");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~...... But if it seems to be a difficult thing, do not hesitate to ask me for consultation. I am going to do not want labor if it is for you. ");
            AddCadre(1050, "{Evening livingroom}{Girl}~... Yeah, I know.");
            AddCadre(1050, "{Evening livingroom}~Kohei-san said that, I decided to do something about it myself.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Well then, please contact me if there is something again.");
            AddCadre(1050, "{Evening livingroom}{Girl}~Yes, I know. Um ... ... Thank you for your concern, you. ");
            AddCadre(1050, "{Evening livingroom}~To the voice worried voice of the phone mouth, with the meaning of making the peace of mind, put it in words and convey it.");
            AddCadre(1050, "{Evening livingroom}{Girl}~I really appreciate Mr. Kohei.");
            AddCadre(1050, "{Evening livingroom}{Girl}~I always feel annoying and burdening always, I think I'm really sorry, I wonder if I can return it properly.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~We are couple, so do not say anything strangely like that. ");
            AddCadre(1050, "{Evening livingroom}~Finally it got a little light tone, Kohei-san said so.");
            AddCadre(1046, "{Evening livingroom}{Girl}~Hehe ... ... That's right, it is a couple.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~that's right. I think that it is a couple who will help each other.");
            AddCadre(1046, "{Evening livingroom}{Girl}~I think so too .... ");
            AddCadre(1046, "{Evening livingroom}~That is why I also want to become Kohei's power properly.");
            AddCadre(1046, "{Evening livingroom}~In order to support Kohei - san who is tough work, I also have to work hard so that I do not increase the extra burden.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Well then, I have preparation for tomorrow, so I will cut it soon.");
            AddCadre(1046, "{Evening livingroom}{Girl}~Yeah ... Good night, Kohei-san.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Good night, Yayoi.");
            AddCadre(1046, "{Evening livingroom}~Kohei's voice, saying good night, is really relieved.");
            AddCadre(1046, "{Evening livingroom}~I'd like to listen forever, but surely I will be busy working tomorrow, so it is not good to tell me.");
            AddCadre(1046, "{Evening livingroom}~I trimmed my disappointing feeling behind my heart and I softly pushed the call button.");
            AddCadre(1046, "{Evening livingroom}{Girl}~Fuh ... ... Thank you so much, Kohei-san ......");
            AddCadre(1046, "{Evening livingroom}~After that I have to do something with my own power.");
            AddCadre(1046, "{Evening livingroom}{Girl}~I clutched the broken phone and I thought so strongly.");

            ClearSound();
        }
        private void Cartina_NaughtyProposal()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            // ANTRACT=============================================================
            S1 = 1500; X1 = -70;
            // music.arc_000007.wav
            //voice?
            AddCadr(1049, null, "{Morning street}{Girl}~(I have to work hard to negotiate ... ...) ");
            AddCadr(1049, null, "{Morning street}~I have thought of various things, but after all we have to pay by dividing.");
            AddCadr(1049, null, "{Morning street}~Because of Kohei - san, it seems that the amount can be lowered, but it is still not an amount that can be paid in bulk.");
            AddCadr(1049, null, "{Morning street}~The problem is the repayment period of the money borrowed from Mr. Mito.");
            AddCadr(1049, null, "{Morning street}~I can not pay for it unless I keep it as long as possible.");
            AddCadr(1049, null, "{Morning street}~Of course I did not mean to pay Kohei-san's salary, I planned to go to the part again.");
            //voice?
            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "{Girl}~(The store manager says it is not enough manpower ... ...)");
            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "The amount of repayment about the amount that can be earned for the part at the supermarket was my ideal.");
            AddCadr(0, null, "...");
            AddCadr(0, null, "... ...");
            AddCadr(0, null, "... ... ...");

            //music.arc_000005.wav
            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When I visited Mr. Minodo's office, I was kept waiting a while because I was working.");
            AddCadr(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even while sitting on the sofa and waiting, the tension is rising.");
            S1 = 1500; X1 = 300;
            S2 = 0715; X2 = 155; Y2 = 55;
            //effect.arc_000020.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I am sorry, I have kept you waiting.");
            //voice? voice.arc_000550.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Good, but... ...");
            //voice? voice.arc_000551.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you talk with sincerity, you should know Mr. Minodo.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I thought so, but the idea was a bit sweeter.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I received a message from my husband. You seemed to know a lot?");
            //voice? voice.arc_000552.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Oh ... oh, yes ... ... that job, finance related work ...");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Indeed, that's what it is.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Although I do not show much on facial expressions, Mr. Muto's voice seemed a little sullen.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps what asked to Mr. Kohei might have been damaged by tantrums.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~So, can we talk a specific story today?");
            //voice?  voice.arc_000553.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Yes ... .... Um, I can not pay in bulk, so I thought that I would like to split ... so we pay monthly payment ...... ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If the previous borrowing agreement is invalid, there is no reason to accept it.");
            //voice? voice.arc_000554.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well ... but, but ... ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The money may be the one the husband has said, but instead you will be paid in bulk.");
            //voice? voice.arc_000555.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well ... that! I can not do it ...!");
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, if you say that you can not pay, you just have to pay her again.");
            //voice? voice.arc_000556.ogg
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~She's ... Asahi-chan! What? Such a terrible ... ...! ");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~What is terrible? Do you think that the victim is me?");
            //voice? voice.arc_000557.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well, that was ... .... Well, it was ... .... Excuse me ......");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even though the tone was calm, there was a tremendous force in the voice.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as Mr. Minato is surely the one who has been hurt by the car, it is incorrect to say that it is awful.");
            //voice? voice.arc_000558.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~But Asahi-chan .... It's impossible for her, please somehow split it ... ....?");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I wonder if she has parents, too? If that is difficult, you may consult your husband again.");
            //voice? voice.arc_000559.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well, that's in trouble ....");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wonder what I should do.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is not the amount that I can pay for Asahi and I'm sorry to consult Kohei.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you go to the home of the Kimishima family to consult, Asahi will also be sad, and as a result it places a burden on Kohei.");
            //voice? voice.arc_000560.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(I want to manage it by myself, but ... ...)");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I would like to make it monthly repayment at some amount to earn part-time.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "How can I accept Mr. Muto from it?");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While I felt my back getting wet with cold sweat, I was desperately thinking.");
            //voice?  voice.arc_000561.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~I will do anything I can ... ... I will pay all the repair expenses as well, so why can not you do something ...?");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But I can not think of anything in my head.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As Kohei-san, there was nothing to solve the problem.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~That's right.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Then, Mr. Minoto starts looking at something with a difficult expression.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps, will he step up.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "So expecting while waiting, I will look like Mr. Minoto's sharp eyes shoot through me.");
            //voice?  voice.arc_000562.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~ぅ ...");
            //music.arc_000004.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If you ... ... If Yayoi will be mine for only a week, I do not mind drinking that condition.");
            //voice?  voice.arc_000563.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~! What?");
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even if it is dull, I know what it means.");
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I do not think that I should say such a thing, I am surprised that I will not speak at once.");
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~what will you do?");
            //voice?   voice.arc_000564.ogg
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Mum ... It is impossible! I can not do that ...! Wow, my husband is ... ...!");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When refusing to return to me, unexpectedly Mr. Minoto nods with conviction.");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, it will be.");
            //voice?  voice.arc_000565.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Well then, then ...... ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Then, I will just give out the condition for her. ");
            //voice?  voice.arc_000566.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Become What? Oh, Asahi is still a student! What?");
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Is not it a wonderful adult anymore? At least, the body. ");
            //voice?  voice.arc_000567.ogg
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Huh! ! ");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "No way, Mr. Minoto was a person to say such a thing.");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I also thought that they were a bad joke, but they seem to be seriously saying.");
            //voice?  voice.arc_000568.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(What do you do ... ... such ... ...)");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "At least, I can not let such a condition by Asahi.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I think that I must manage to do something, but I was unlikely to get an answer soon.");
            //voice?  voice.arc_0005669.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~прошу вас....позвольте мне все обдумать....");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I do not mind it, but I am busy too. Oh yeah ... the time to divide for you is another 10 minutes.");
            //voice?  voice.arc_000570.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~... that, such a ... ...");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I can not do such a conclusion in ten minutes.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As I said before, I thought after going home once, but Mr. Motoi did not seem to forgive it.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps last time I brought the documents home and consulted with Kohei might also be affecting.");
            //voice? voice.arc_000571.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Maybe you do not want to talk to Mr. Kohei ... ...) ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you would like to talk to Kohei-san, I have to call this place now.");
            //voice? voice.arc_000572.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(But, this time Kohei-san is also working ... ...)");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wish it was at least a lunch break or overtime time.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is painful to call Kohei-san who is working while troubling you.");
            //voice? voice.arc_000573.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(ооо ...... что же мне делать ... ....!?)");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Only time will pass as I can not answer anything.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Every time Mr. Minato saw the wrist watch, I felt that he was going to be hunted down.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~... ... It's only five minutes.");
            //voice? voice.arc_000574.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~хлюп! !");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "We have to decide whether to accept Mr. Minodo's request or not.");
            //voice? voice.arc_000575.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~это будет .... только неделю ... это так ...?");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Oh, no doubt. I do not mind letting you keep it in writing properly if you wish. ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If Mr. Minodo says so, I think that it is only one week indeed.");
            //voice? voice.arc_000576.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...пожалуйста, если вас не затруднит ...");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Wait a while.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Mr. Minodo said so, operated the personal computer, printed out the document and brought it.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~This is the document. Because it is not a contract, it is like a letter. ");
            //voice? voice.arc_000577.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...хо..хорошо ...");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There, it says that I will leave to myself about payment of repair costs instead of becoming Freedom of Mr. Minato for only a week.");
            //voice? voice.arc_000578.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~... ... а как отменить это соглашение? ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~You only have to pay for your good. ");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While saying that, Mr. Minato sat down next to me.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I got my body beyond necessity and put my hands around my thighs.");
            //voice? voice.arc_000579.ogg
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~...");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~No matter how many times you pay, it does not matter about the amount of each time.");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I was concerned about Mr. Minodo's hand, but desperately I listened to that word and followed the letters of the document.");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There may be something inconvenient to me.");
            AddCadr(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as far as I see, the papers have written only what is convenient for me.");
            //voice? voice.arc_000580.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Well, this is really okay .... If this is the case, I can do anything without inconveniencing anyone ....)");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Of course, the price is great.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~It is you who decide, Yayoi. If you accept this, please sign it.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If I drink this condition, everything can be solved well.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Asahi is not worrying about it, nor does it rely on your parents.");
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "And above all, I did not put unnecessary inconvenience to Kohei-san.");
            //voice? voice.arc_000581.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~ .... окей, я согласна ...");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "You only have to endure it for a week and endure it.");
            //voice? voice.arc_000582.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~(Прости меня Кохей... ...)");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Apologizing to Mr. Kohei in my mind, I signed the document.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~...... Then, it is established with this. ");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Make sure the document I signed, Mister Mutsu muttered.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The period is a week from tomorrow. I will contact you as soon as time comes, so you can come here.");
            //voice? voice.arc_000583.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~Yes, ...");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Although it is over talk, is there something?");
            //voice? voice.arc_000584.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "{Girl}~нет ... ... мне наверно уже пора ......");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Ah.");
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "After finishing talking with Mr. Minato, I left the office.");
            // ANTRACT =====================


            ClearSound();
        }
        private void Cartina_WalkingAfterProposal()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            // ANTRACT=============================================================
            // music.arc_000001.wav
            S1 = 1100; X1 = 135; Y1 = 55;
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The sun had already begun to slip out of us how long it took us so long.");
            //effect.arc_000014.wav
            //voice.arc_000585.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "……");
            //effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I am walking with a hula while thinking about the signed documents.");
            //effect.arc_000014.wav
            //voice.arc_000586.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(С завтрашнего дня, я ... .... принадлежу мистеру Минато ... ...)");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The feelings I regret as soon as they come in, it becomes painful just by thinking.");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I wonder if I did something terribly inevitable.");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I guess that is probably the case.");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But in that situation there was no other answer and I could not afford to consult anyone.");
            // effect.arc_000014.wav
            //voice.arc_000587.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(But what shall I do ... ... I promised that kind of ... ...) ");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Perhaps it was better for you to trust Mr. Kohei obediently, without thinking about doing anything by yourself.");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even though I thought so, I felt like it is now.");
            // effect.arc_000014.wav
            //voice.arc_000588.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(I do not want to put a burden on Kohei-san any more any more ... ...) ");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Though thinking about the future with me, I am doing my best while working hard.");
            // effect.arc_000014.wav
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "However, I may be betraying that kind of Kohei as a result.");
            // effect.arc_000014.wav
            //voice.arc_000589.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~.... хлюп.... Я......");
            // effect.arc_000014.wav
            //voice.arc_000590.ogg
            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Ой...");
            // effect.arc_000014.wav
            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Maybe because I was disappointed, my feet were hula and I was sticking out to the roadway.");
            // effect.arc_000014.wav
            //voice.arc_000591.ogg
            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(Hit run ...... !?)");
            // effect.arc_000014.wav
            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even if I look at the car coming close to me, my body does not move at all.");
            // effect.arc_000014.wav
            AddCadr(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The moment I thought it was no good, suddenly someone was pulling my arm.");
            S2 = 655; X2 = 125; Y2 = 115;
            // effect.arc_000014.wav
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Oops! It is dangerous!");
            // effect.arc_000014.wav
            //voice.arc_000592.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Ах ...!");
            //// effect.arc_000014.wav
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Driver~Watch out! Do you want to be run over! driver");
            //// effect.arc_000014.wav
            //voice.arc_000593.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I'm sorry ...");
            // effect.arc_000014.wav
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The car stopped at the limit, but if I stayed in the carriage as it was, it may have been ruined in safety.");
            X1 = 480;
            // effect.arc_000014.wav
            //voice.arc_000594.ogg
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, thank you ...... ");
            // effect.arc_000014.wav
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Was it okay?");
            // effect.arc_000014.wav
            AddCadr(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "So I was told that I was the manager who helped me.");
            // effect.arc_000014.wav
            //voice.arc_000595.ogg
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, the store manager san ...... ");
            // effect.arc_000014.wav
            AddCadr(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~I was worried because I was walking with the hula. Well, it was good to make it in time. ");
            // effect.arc_000014.wav
            //voice.arc_000596.ogg
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I'm sorry, I am worried ... ... ");
            // effect.arc_000014.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If the manager did not notice me, what was going on?");
            // effect.arc_000014.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Is he feeling ill? Or was there something? ");
            // effect.arc_000014.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The manager is worried about me and he puts such words.");
            // effect.arc_000014.wav
            AddCadr(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But it is not like I can talk very much.");
            // effect.arc_000014.wav
            //voice.arc_000597.ogg
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I was a little bait ... ... It's okay. I'm really thankful to you. ");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Make a smile somehow, cheat the manager.");
            //effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Did you believe it, the manager did not ask you anything more than that?");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~That's fine ...... Husband's on a business trip? If something happens, do not hesitate to tell me. ");
            // effect.arc_000014.wav
            //voice.arc_000598.ogg 
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~I will do ... Yes, thank you. ");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If I can tell you the problem I am having, what kind of face will the manager say?");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Suddenly such a thing passed the mind, but of course I could not say it.");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Well then, I will return to the store.");
            // effect.arc_000014.wav
            //voice.arc_000599.ogg 
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~Oh, yes ... I will excuse you. ");
            // effect.arc_000014.wav
            AddCadr(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Lower his head to the store manager who helped me and leave that place.");
            // effect.arc_000014.wav
            //voice.arc_000600.ogg 
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "{Girl}~(If you do not stand firm ... ...) ");
            // effect.arc_000014.wav
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "My head was full of Mr. Mihara, but I will tell myself so.");
            // effect.arc_000014.wav
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Let's at least think after returning home.");
            // effect.arc_000014.wav
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Because it is supposed to be irreparable when it comes to accidents.");



            ClearSound();
        }
        private void Cartina_BeforeHusbCall3()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });

            // ANTRACT=============================================================
            X1 = 135;
            // music.arc_000009.wav
            // evening livingroom
            //voice.arc_000601.ogg 
            AddCadr(1049, null, null, "{Girl}~Fuh ... ... this time already ...... ");
            AddCadr(1049, null, null, "By the time I came back home, the outside of the window was completely dark.");
            AddCadr(1049, null, null, "I should prepare dinner soon, but I could not feel like that.");
            AddCadr(1049, null, null, "To begin with, I have only one person, and I do not have an appetite now.");
            AddCadr(1049, null, null, "As I thought, my head was full of promises with Mr. Koto.");
            //voice.arc_000602.ogg 
            AddCadr(1050, null, null, "{Girl}~(Tomorrow I have to go to Mr. Mioto's place ...) ");
            AddCadr(1050, null, null, "I wonder what exactly is done.");
            AddCadr(1050, null, null, "I think that there is nothing to injure, but after all it may be necessary to prepare.");
            // voice.arc_000603.ogg
            AddCadr(1050, null, null, "{Girl}~(That's ... that's right, surely ... ....) ");
            AddCadr(1050, null, null, "Because Mr. Minato is a man and saying that I will make a woman free, I think that it is what I imagined.");
            // voice.arc_000604.ogg
            AddCadr(1050, null, null, "{Girl}~Ah  !");
            AddCadr(1050, null, null, "It may be too late if I regret it now.");
            AddCadr(1050, null, null, "I already signed the document and there is no other way to pay the repair cost.");
            AddCadr(1050, null, null, "I want to think that it was an unavoidable choice, but feelings depressed.");
            AddCadr(1050, null, null, "I could not suppress my feelings of regret as if I should have confided to Mr. Kohei.");
            // voice.arc_000605.ogg
            AddCadr(1050, null, null, "{Girl}~(I wonder what I should do ... ...) ");
            AddCadr(1050, null, null, "No matter how much I think, the answer is unlikely.");
            AddCadr(1050, null, null, "While I was doing it, it was time for video chatting with Kohei when I noticed it.");
            // voice.arc_000606.ogg
            AddCadr(1048, null, null, "{Girl}~I can not hurry ... ");
            AddCadr(1048, null, null, "If you have a depressed face, you surely understand to Kohei.");
            //effect.arc_000020.wav
            AddCadr(0, null, null, "While heading to the bedroom where the personal computer is placed, I try to smile frantically.");
            AddCadr(0, null, null, "But I was laughing properly, even if I looked in the mirror I could not understand myself well.");

            ClearSound();
        }
        private void Cartina_HusbCall3()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


            // evening bedroom
            // voice.arc_000607.ogg
            AddCadr(1049, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~It is almost time ... ");
            S1 = 1370; X1 = 0; Y1 = 0;
            // voice.arc_000608.ogg
            //effect.arc_000039.wav
            AddCadr(0991, null, null, "{Girl}~... .... Good work, you. How is your job?");
            AddCadr(0991, null, null, "Kohei~Thank you. Well, is the worker doing well? ");
            AddCadr(0991, null, null, "Try not to think about Mr. Minato and speak as normally as possible.");
            // voice.arc_000609.ogg
            AddCadr(0991, null, null, "{Girl}~(Okay, unless you realize Kohei ... ...) ");
            AddCadr(0991, null, null, "It's a small screen on a personal computer, and even if it looks a little strange, I can not notice it.");
            AddCadr(0991, null, null, "So talking to myself, talk to Kohei-san in the screen.");
            AddCadr(0991, null, null, "Kohei~By the way, what happened to the other case? ");
            AddCadr(0991, null, null, "But from Kohei-san, it was cut out.");
            AddCadr(0991, null, null, "I did not want to talk much, but I can not ignore it.");
            // voice.arc_000610.ogg
            AddCadr(1001, null, null, "{Girl}~(What shall I do ......) ");

            ClearSound();
        }
        private void Cartina_Choice3_2()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });
            //============================================
            // CHOICE 3-2
            //============================================

            // voice.arc_000611.ogg
            AddCadr(1001, null, null, "{Girl}~ah");
            AddCadr(1001, null, null, "To be honest, I would like to talk to Mr. Kohei.");
            AddCadr(1001, null, null, "After all it is a problem in my hand and I think I can not do any more.");
            AddCadr(1001, null, null, "It is better for Kohei to be scolded by Mr. Kohei as it is supposed to be as free as his freedom for only a week as it is.");
            // voice.arc_000612.ogg
            AddCadr(1001, null, null, "{Girl}~(But I'm busy with work ... I'm getting tired.)");
            AddCadr(1001, null, null, "I felt something like tiredness different from what I usually do, looking anxiously.");
            AddCadr(1001, null, null, "It's a long business trip and maybe I'm not getting tired well.");
            AddCadr(1001, null, null, "As I thought, it seems as though I was sorry for any further burden.");
            // voice.arc_000613.ogg
            AddCadr(1001, null, null, "{Girl}~(Because of me, I can not put any further inconvenience ... ...) ");
            AddCadr(1001, null, null, "It is my wife 's job to protect the house while my husband is out.");
            AddCadr(1001, null, null, "Because I told myself to do something, I have to work hard until the end.");
            // voice.arc_000614.ogg
            AddCadr(1007, null, null, "{Girl}~Yeah, I managed to repay it in part.");
            AddCadr(1008, null, null, "Kohei~Is that so? ");
            // voice.arc_000615.ogg
            AddCadr(1008, null, null, "{Girl}~Yup. Well .... I do not want to put too much strain on household budget, so I'd like to part time again ... is it good?");
            AddCadr(1008, null, null, "Kohei~Of course it does not matter, but at that supermarket? ");
            // voice.arc_000616.ogg
            AddCadr(1008, null, null, "{Girl}~Is that so. Because the manager was lamenting because they were short of people, I am indebted to him in various ways and thinking of going to help me just because it is good.");
            AddCadr(1008, null, null, "I am surprised even by myself that a lie will come out as irregularities.");
            AddCadr(1008, null, null, "Of course, I also thought that the store manager would seem hard to have thought of going out to the part again.");
            AddCadr(1008, null, null, "But I have not thought about anything concrete yet, why can you say such a thing towards Mr. Kohei?");
            // voice.arc_000617.ogg
            AddCadr(1003, null, null, "{Girl}~(I'm lying to Kohei-san ... ...)");
            AddCadr(1003, null, null, "My heart aches with that fact.");
            AddCadr(1003, null, null, "I never had ever lied to Kohei-san.");
            AddCadr(1002, null, null, "Kohei~I see ... I guess it is OK, but if it seems to be tough, I would like you to say it properly. ");
            // voice.arc_000618.ogg
            AddCadr(1007, null, null, "{Girl}~Of course, Kohei-san.");
            // voice.arc_000619.ogg
            AddCadr(0992, null, null, "{Girl}~Well then, are you eating properly? It looks somewhat pale face ...");
            AddCadr(0992, null, null, "To avoid pursuit from Kohei, on the other hand, I will tell it from my side.");
            AddCadr(0993, null, null, "Kohei~Ah ... no, I am busy ... ... ");
            // voice.arc_000620.ogg
            AddCadr(0993, null, null, "{Girl}~You can not afford a lunch box at a convenience store? At least let's eat something proper in the store? ");
            AddCadr(0993, null, null, "Kohei~That's right, there is a set menu restaurant in the neighborhood, so I will go there as much as possible. ");
            // voice.arc_000621.ogg
            AddCadr(0993, null, null, "{Girl}~I think that is good. Please come back fine, Kohei-san?");
            AddCadr(0991, null, null, "Kohei~Yes, I will be careful. Well then ... ... ");
            // voice.arc_000622.ogg
            AddCadr(0991, null, null, "{Girl}~Yeah ... Good luck with your work, good night, you.");
            AddCadr(0991, null, null, "Kohei~I think that Yayoi is too hard, but do not push yourself? Well then, good night. ");
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "In the end they smiled at each other and finished the video chat.");
            S1 = 1100; X1 = 135; Y1 = 55;
            // voice.arc_000623.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~ahh");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "When I cut off my PC, my chest is tightened again.");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "It was the first time I was born, I lied to Kohei-san.");
            // voice.arc_000624.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~But if you confidently tell the truth, I will put more burden ... ...");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I do not think I'm sorry, but I could not do anything else.");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Anyway, now I have to solve the problem of Asahi and return to life as soon as possible.");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I am worried about things from tomorrow, but I have to decide my resolution.");
            // voice.arc_000625.ogg
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "{Girl}~(I'm sorry, Mr. Kohei ... ... When is your time ... ...) ");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "As a result it may cause more inconvenience, but let's try hard as much as possible.");
            AddCadr(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Because I still do not know what Mr. Minodo will ask me.");

            // ANTRACT=============================================================

            ClearSound();
        }
        private void Cartina_MorningBeforeDate()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


            // ANTRACT=============================================================
            X1 = -215;
            X3 = 520; Y3 = 60; S3 = 1000;
            // music.arc_000001.wav
            AddCadr(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Today is Asahi came from the morning as school was closed.");
            // voice.arc_000626.ogg
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~I'm glad you came to visit us, Asahi.");
            // voice?
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~ah");
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Of course, it just did not come to play normally.");
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "You can also tell from Mr. Muto's point of view about his facial expressions.");
            // voice?
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um, Yayoi ... ... What has become of it from that ... ....? ");
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "As I thought, I asked with an uneasy expression.");
            // voice.arc_000627.ogg
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~Even if you do not worry it's okay, as we have already discussed with Mr. Nioto. ");
            // voice?
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~But money, ... ");
            // voice.arc_000628.ogg
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~It was decided to pay by splitting, but I do not have to worry about that either ... ... is it? ");
            // voice?
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um ... ... I'm sorry, it's because of me ... But, is it really okay ...? ");
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Although I said that I was not worried, I was still anxious.");
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I wonder if I can not depend on them any more.");
            // voice.arc_000629.ogg
            AddCadr(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~...... Actually, I also consulted Kohei-san.");

            //music.arc_000006.wav
            // voice?
            AddCadr(1046, 1018, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Er ...... Onii-chan! What? ");
            // voice.arc_000630.ogg
            AddCadr(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~Yes. Kohei-san negotiated, the repair expenses also cheaper?");
            AddCadr(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "To resolve Asahi's anxiety, speak brightly with a smile on purpose.");
            // voice?
            AddCadr(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~I see, Onii-chan ... ... ");
            AddCadr(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi, who had been making her feel uneasy, also healed his expression as soon as Kohei-san's story came out.");
            // voice.arc_000631.ogg
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~(You really trust me, Mr. Kohei)");
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I can understand that feeling as well.");
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Mr. Kohei is calm and calm all the time, so he is a very reliable person.");
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "If Kohei-san deals with it, it seems that it has already been solved.");
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi who stayed together much longer than me, maybe the size of that trust is more than me.");
            // voice.arc_000632.ogg
            AddCadr(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "{Girl}~... ... So you are already safe?");
            // voice?
            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Yeah ... but, thanks a lot, Yayoi. ");
            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi seems relieved and smiles anyhow.");
            AddCadr(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I finally seemed able to regain a smile and I was happy.");


            ClearSound();
        }
        private void Cartina_PreparationsToDate()
        {
            //string BG = "SILKYS_SAKURA_OttoNoInuMaNi_BG06"; // evening cabinet
            //string MAN = "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1";
            //Z1 = 2;
            //S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;
            CurrentSounds = new List<seSo>();
            //int i = 636; // cound indexer
            //Music
            //CurrentSounds.Add(new seSo() { File = $"{PATH_M}music.arc_000005.wav", Name = "MUSIC", V = VOLUME_M });


            // ANTRAKT=================
            // day livingroom
            // music.arc_000001.wav

            // voice.arc_000633.ogg
            AddCadr(1046, 1016, null, "{Girl}~Oh, I am sorry, Asahi-chan. I have to go out soon.");
            // voice?
            AddCadr(1046, 1016, null, "Asahi~Was it already such a time? I have to go home soon ... I will come to play again, Mr. Yayoi. ");
            // voice.arc_000634.ogg
            AddCadr(1047, 1016, null, "{Girl}~Yeah, come back to visit anytime.");
            //effect.arc_000020.wav
            AddCadr(1047, 0, null, "Asahi goes out of the room with a dash.");
            AddCadr(1047, 0, null, "I enjoyed talking with Asahi slowly after a long absence.");
            AddCadr(1047, 0, null, "But it is about time we promised to Mr. Muto.");
            AddCadr(1050, 0, null, "{Girl}~I have to go make up properly ...");
            AddCadr(1050, 0, null, "It is usually about a base makeup, I do not do very well.");
            AddCadr(1050, 0, null, "But as expected it did not go that way.");
            AddCadr(1050, 0, null, "Although I am cheerful if I think about what will happen, I can not translate without going beyond what I have promised.");
            // voice.arc_000635.ogg
            AddCadr(1050, 0, null, "{Girl}~(Even Minato is not that bad so far ... ...)");
            AddCadr(1050, 0, null, "I was hoping for a little bit that he would not do seriously serious things.");

            ClearSound();
        }
        private void Cartina_ChangingClothInCabinet()
        {
            string BG = BG_EVENING_CABINET; // evening cabinet
            string MAN = MAN1;            

            currentGr = "14.Переодевание у финансиста";
            Z1 = 2;
            S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;            
            int i = 637; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000005.wav");
            //Music ============================

            //1
            AddEffect1($"effect.arc_000020.wav", SoundPauseShort, false);//Effect - shoot door
            AddVoice($"voice.arc_000{i++}.ogg",  SoundPauseLong, false);            
            DoC(1049, 0, null, BG, $"{Girl}~Простите? ...... ", new OpEf(1,false,500,false,2000));
            //2
            DoC(1049, 0, null, BG, $"Когда я, вошла, волнуясь даже больше, чем раньше, {BadMan} еще работал.");            
            //3
            DoC(1049, 0, MAN,  BG, $"{BadMan}~Я еще не закончил, подождите.", new OpEf(2, false, 350, false, 0));
            //4
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, MAN,  BG, $"{Girl}~....хорошо....");
            //5 
            DoC(1049, 0, null, BG, $"{BadMan} сидел за столом, перебирая документы с озабоченным выражением лица.", new OpEf(2, true, 500, true, 0));
            //6
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, null, BG, $"{Girl}~(Наверное, какое-то важное дело ...)");
            //7
            DoC(1049, 0, null, BG, $"Я знаю, что он работает в финансовой сфере, в которой я ничего не понимаю.");
            //8
            DoC(1049, 0, null, BG, $"Может быть, это инвестирование, или что-то подобное.");
            //9
            DoC(1049, 0, null, BG, $"Пока я оценивала обстановку, {BadMan} убрал документы и поднялся из-за стола.");
            //==== Change position
            X2 = 845; Y2 = 55; S2 = 715;
            //10
            DoC(1049, 0, MAN,  BG, $"{BadMan}~Простите, что заставил вас ждать.", new OpEf(2, false, 350, false, 0));
            //11
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, MAN,  BG, $"{Girl}~совсем нет... ....");
            //12
            DoC(1049, 0, MAN,  BG, $"{BadMan}~Я уже успел переодеться, теперь вы не могли бы надеть другое платье?.");
            //13
            DoC(1049, 0, MAN,  BG, $"Посмотрел на меня и показал на бумажный пакет у моих ног.");
            //14
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1048, 0, MAN,  BG, $"{Girl}~ Надеть другое платье...?", new OpEf(1, true, 350, true, 0));
            //15
            DoC(1048, 0, MAN, BG, $"Я никак не ожидала такого предложения.");
            //16
            DoC(1048, 0, MAN, BG, $"{BadMan}~Размер должен подойти.");
            //17
            DoC(1048, 0, MAN, BG, $"{BadMan} непреклонно указал на бумажный пакет.");
            //18
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1048, 0, MAN, BG, $"{Girl}~ да ... ...");
            //19
            DoC(1049, 0, MAN, BG, $"Не знаю, зачем ему нужно, что бы я переоделать, но мне придется сделать это."
                , new OpEf(1, true, 350, true, 0));
            //20
            DoC(1049, 0, MAN, BG, $"Ведь я обязалась неделю быть его женщиной, начиная с сегодняшнего дня.");
            //21
            DoC(1049, 0, MAN, BG, $"{BadMan}~Ваше новое платье здесь, в пакете. Можете воспользоваться туалетом.");
            //22
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, MAN, BG, $"{Girl}~Здесь...? ");
            //23
            DoC(1049, 0, MAN, BG, $"Я подняла пакет с наклейкой известной фирмы и заглянула внутрь.");
            //24
            DoC(1049, 0, MAN, BG, "Внутри на самом деле была одежда.");
            //25
            DoC(1049, 0, MAN, BG, "Но ее фасон был, кажется, какой-то не совсем обычный.");
            //26
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, MAN, BG, $"{Girl}~оох ... что это ...!! ?");
            //27
            DoC(1049, 0, MAN, BG, $"{BadMan}~Я думаю, что для вашего тела это подойдет.");
            //28
            DoC(1049, 0, MAN, BG, $"{BadMan} настроен достаточно откровенно, и выражается без обиняков.");
            //29
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, MAN, BG, $"{Girl}~о ... ах ... раз так ... хорошо... ");
            //30
            DoC(1049, 0, MAN, BG, "Наверно, мне не нужно было переодеваться, но...");
            //31
            DoC(1049, 0, MAN, BG, "Вокруг была какая-то такая атмосфера, что я не смогла отказаться.");
            //32
            DoC(0, 0, null, BG, "...", new OpEf(1, true, 350, true, 0), new OpEf(2, true, 350, true, 0));
            //33
            DoC(0, 0, null, BG, "... ...");
            //34
            DoC(0, 0, null, BG, "... ... ...");
            //35
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~вот... ...я переоделась ...... ", new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
            //36
            DoC(1073, 0, MAN, BG, $"{BadMan} приготовил для меня очень откровенное платье.");
            //37
            DoC(1073, 0, MAN, BG, "Линии тела были открыты полностью, было много открытых участков, где-то было видно даже белье.");
            //38
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~(ооо... мне так неловко......) ");
            //39
            DoC(1073, 0, MAN, BG, $"Мое тело в зеркале туалетной комнате было вызывающе открыто.");
            //40
            DoC(1073, 0, MAN, BG, $"{BadMan}~──О, как я и думал, это вам подходит");
            //41
            DoC(1073, 0, MAN, BG, $"{BadMan} довольно улыбался, разглядывая меня.");
            //42
            DoC(1073, 0, MAN, BG, $"Первый раз я видела у него такое выражние лица.");
            //43
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~что же я должна сделать дальше ...... ");
            //44
            DoC(1073, 0, MAN, BG, $"Я ждала, что теперь потребует от меня {BadMan},который продолжал довольно улыбаться.");
            //45
            DoC(1073, 0, MAN, BG, $"От волнения и возбуждения ладони мои стали влажными.");
            //46
            DoC(1073, 0, MAN, BG, $"{BadMan}~Ах да, для начала, хотите пойти поужинать? Я с утра был слишком занят, чтобы поесть, и проголодался.");
            //47
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, MAN, BG, $"{Girl}~оох ...  ужин ... ....?", new OpEf(1, true, 350, true, 0));
            //48
            DoC(1070, 0, MAN, BG, $"{BadMan}~Вы уже ужинали?");
            //49
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, MAN, BG, $"{Girl}~Да ...то есть... еще нет ...");
            //50
            DoC(1070, 0, MAN, BG, $"От врлнения у меня не было аппетита, к тому же я хорошо пообедала.");
            //51
            DoC(1070, 0, MAN, BG, $"{BadMan}~Что ж, отлично. Есть один французский ресторан, где я часто обедаю, так что пойдем туда.");
            //52
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~В таком виде ...?", new OpEf(1, true, 350, true, 0));
            //53
            DoC(1073, 0, MAN, BG, $"{BadMan}~Нет проблем, там свободная обстановка.");
            //54
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);            
            DoC(1073, 0, MAN, BG, $"{Girl}~Но...");
            //55
            DoC(1073, 0, MAN, BG, $"Я чувствую себя слишком неловко в таком наряде, чтобы пойти в нем в общественное место.");
            //56
            DoC(1073, 0, MAN, BG, $"Тем более во французский ресторан.");
            //57
            DoC(1073, 0, MAN, BG, $"Так как это {BadMan}, я думаю, что он очень дорогой.");
            //58
            DoC(1073, 0, MAN, BG, $"{BadMan}~Пойдемте же. ");
            //59
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~(Если пойти в таком наряде, может случиться скандал ... ... ...)");
            //60
            DoC(1073, 0, MAN, BG, $"Но я не могу отказаться, ведь {BadMan} кажется, это нравится.");            
            //61
            DoC(1073, 0, MAN, BG, $"Мне было очень стыдно, но я решила пережить и это.");


            ClearSound(true, true, true);
        }
        private void Cartina_EveningPromenad()
        {
            string BG = BG_EVENING_STREET; // evening cabinet
            string MAN = MAN1;

            currentGr = "15.Вечерний променад.";
            Z1 = 2; X1 = 470;
            S2 = 680; X2 = 155; Y2 = 525; Z2 = 1;

            int i = 654; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000005.wav");
            //Music ============================


            //1            
            AddEffect2($"effect.arc_000017.wav", SoundPauseNone, false);//Effect - crowd
            DoC(0, 0, null, BG, $"После того, как мы поужинали во французском ресторане, {BadMan} повел меня на прогулку по ночному городу.");
            //2
            DoC(1073, 0, MAN, BG, $"{BadMan}~Обслуживание было хорошим, и блюда были неплохи, верно?"
                , new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
            //3
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~Да, ... это было прекрасно ......");
            //4
            DoC(1073, 0, MAN, BG, $"Взяв меня под руку, {BadMan} кивнул.");
            //5
            DoC(1073, 0, MAN, BG, $"Я ответила ему, чтобы поддержать разговор, но на самом деле я не помню, какой был вкус этих блюд.");
            //6
            DoC(1073, 0, MAN, BG, $"Я знаю, что это были деликатесы, но мне было не до них, потому что все люди вокруг, включая официантов, смотрели на меня.");
            //7
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~(я не чувствую, что наелась ......)");
            //8
            DoC(1073, 0, MAN, BG, $"Даже идя по ночной улице, каждый взгляд проходящего мужчины тревожил меня.");
            //9
            DoC(1073, 0, MAN, BG, $"Это было естественно, потому что я чувствовала себя наполовину голой.");
            //10
            DoC(1073, 0, MAN, BG, $"{BadMan}~............ ");
            //11
            DoC(1073, 0, MAN, BG, $"Наверно {BadMan} был доволен, наблюдая мое смущение.");
            //12
            DoC(1073, 0, MAN, BG, $"{BadMan}, кажется, наслаждался.");
            //13
            DoC(1073, 0, MAN, BG, $"{BadMan}~Еше слишком рано идти в бар ... ... Пойдем в кино?");
            //14
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~........?");
            //15
            DoC(1070, 0, MAN, BG, $"{BadMan}, глядя на часы, протянул руку и обнял меня за талию."
                ,new OpEf(1, true, 350, true, 0));
            //16
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~......."
                , new OpEf(1, true, 350, true, 0));
            //17
            DoC(1073, 0, MAN, BG, $"На самом деле, было трудно сказать, была ли это талия, или ягодицы.");
            //18
            DoC(1073, 0, MAN, BG, $"Он как будто погладил их, в ответ я невольно тихо вскрикнула.");
            //19
            DoC(1073, 0, MAN, BG, $"{BadMan}~Прогуляемся?");
            //20
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);            
            DoC(1073, 0, MAN, BG, $"{Girl}~д ... ... да ... ...");
            //21
            DoC(1073, 0, MAN, BG, $"Я не смогла даже отвести его руку, и он продолжал держать меня меня за попу.");
            //22
            DoC(1073, 0, MAN, BG, $"Я боялась, что это было заметно всем.");
            //23
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~(пожалуйста ... лишь бы не встретить никого знакомого ... ...)");
            //24
            DoC(1073, 0, MAN, BG, $"Я мысленно молилась, сгорая от смущения."
                , new OpEf(1, false, 350, true, 0), new OpEf(2, false, 350, true , 0));

            DoC(0, 0, null, null, $"....");
            DoC(0, 0, null, null, $".... ....");
            DoC(0, 0, null, null, $".... .... ....");
            //25
            DoC(0, 0, null, BG, $"После кино, {BadMan} продолжил гулять.");
            //26
            DoC(1073, 0, MAN, BG, $"{BadMan}~Только музыка была хороша, а сценарий и игра - нет."
                , new OpEf(1, false, 350, false, 0), new OpEf(2, false, 350, false, 0));
            //27
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~да, правда ......");
            //28
            DoC(1073, 0, MAN, BG, $"Почему-то меня обидело, как {BadMan} говорил о картине.");
            //29
            DoC(1073, 0, MAN, BG, $"Кино было длинным, но содержание не очень понятным.");
            //30
            DoC(1073, 0, MAN, BG, $"Иностранная картина, из которой я запомнила только красивые виды.");
            //31
            DoC(1073, 0, MAN, BG, $"{BadMan} рукой все время касался моих бедер, и я не могла сконцентрироваться.");
            //32
            DoC(1073, 0, MAN, BG, $"{BadMan}~Тут рядом бар. Вы пьете саке?");
            //33
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, MAN, BG, $"{Girl}~д ......, да ... ... только если немного ... ... "
                ,new OpEf(1, true, 350, true, 0));
            //34
            DoC(1070, 0, MAN, BG, $"Я поняла, что сейчас мы пойдем в бар. Наверно он собирается выпить.");
            //35
            DoC(1070, 0, MAN, BG, $"{GoodMan} не пьет, и поэтому я тоже редко пробовала.");
            //36
            DoC(1070, 0, MAN, BG, $"Когда я жила с родителями, я пробовала напитки моего отца.");
            //37
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, MAN, BG, $"{Girl}~(Я должна постараться не пить слишком много ......)");
            //38
            DoC(1070, 0, MAN, BG, $"Пока что, {BadMan} хоть и дал волю рукам, но остальном вел себя как джентельмен.");
            //39
            DoC(1070, 0, MAN, BG, $"Но я не лумаю, что так будет и дальше.");
            //40
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);            
            DoC(1073, 0, MAN, BG, $"{Girl}~(Он наверно постарается напоить меня ... или что-то еще... )"
                , new OpEf(1, true, 350, true, 0));
            //41
            DoC(1073, 0, MAN, BG, $"Если так, я не должна быть пьяной.");
            //42
            DoC(1073, 0, MAN, BG, $"{BadMan}~Что ж, пойдем.");
            //43
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, MAN, BG, $"{Girl}~хорошо, ...");
            //44
            DoC(1070, 0, MAN, BG, $"Я должна вести себя правильно, чтобы ничего плохого не случилось.");
            //45
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"...",
                new OpEf(1, true, 250, true, 0), new OpEf(2, true, 250, true, 0));
            //46
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ...");
            //47
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ... ...");
            //48
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, MAN, BG, $"{Girl}~..........",
                new OpEf(1, false, 250, false, 0), new OpEf(2, false, 250, false, 0));
            //49
            DoC(1073, 0, MAN, BG, $"{BadMan}~Прогуляемся, чтобы проветрить алкоголь.");
            //50
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);            
            DoC(1073, 0, MAN, BG, $"{Girl}~ах ... ... да ... ... ");
            //51
            DoC(1073, 0, MAN, BG, $"Благодаря тому, что ранее был ужин, я не слишком опьянела.");
            //52
            DoC(1073, 0, MAN, BG, $"Конечно, ликер подействовал на меня, но голова не слишком кружилась.");
            //53
            DoC(1073, 0, MAN, BG, $"А {BadMan} снова все время держал руку на моей попе.");
            //54
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"...",
                OpEf.HidePrev(1), OpEf.HidePrev(2));
            //55
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ...");
            //56
            DoC(0, 0, null, $"SILKYS_SAKURA_OttoNoInuMaNi_BG08", $"... ... ...");
            //57
            DoC(0, 0, null, BG, $"Улица по которой мы шли, привела к дому с яркими неоновыми огнями.");

            X1 = -435; Y1 = 435;
            //58
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1070, 0, null, BG, $"{Girl}~(это...это ... ... похоже на ... ...?)"
                ,OpEf.AppearCurrent(1));
            //59
            DoC(0, 0, null, BG, $"Лампы давали неровный свет, и люди, которые заходили внутрь прятали лица."
                , OpEf.HidePrev(1));
            //60
            DoC(0, 0, null, BG, $"Чувство тревоги усилилось, я задрожала, увидев этих заходящих туда мужчин и женщин.");
            //61
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1071, 0, null, BG, $"{Girl}~(ох ...... что же мне делать ...... я в отчаянии ... ....) "
                , OpEf.AppearCurrent(1));
            //62
            DoC(0, 0, null, BG, $"Я не хочу чтобы {GoodMan} оказался как-то предан мной."
                , OpEf.HidePrev(1));
            //63
            DoC(0, 0, null, BG, $"Но если я зашла уже так далеко, а сейчас откажусь, то все станет напрасно..");
            //64
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1072, 0, null, BG, $"{Girl}~(Ну хотя бы теперь ... понятно, к чему все шло......) "
                , OpEf.AppearCurrent(1));
            //65
            DoC(0, 0, null, BG, $"Может быть, все это случилось из-за ликера?"
                , OpEf.HidePrev(1));
            //66
            DoC(1073, 0, MAN, BG, $"{BadMan}~...... Мы заходим?"
                , OpEf.AppearCurrent(2));
            //67
            DoC(1073, 0, MAN, BG, $"{BadMan} остановился прямо на входе.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //68
            DoC(1069, 0, MAN, BG, $"{Girl}~.....!",
                OpEf.HidePrev(1));
            //69
            DoC(1069, 0, MAN, BG, $"Это был дом для свиданий.");
            //70
            DoC(1069, 0, MAN, BG, $"Я все стояла, и тогда {BadMan} рукой подтолкнул меня вперед.");
            //71
            DoC(1069, 0, MAN, BG, $"Я чувствовала, что не могу противиться этой руке.");
            //72
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1071, 0, MAN, BG, $"{Girl}~(Ооо... ... {GoodMan} ... ...! Спаси меня ... ...!)"
                ,OpEf.HidePrev(1));
            //73
            DoC(1071, 0, MAN, BG, $"Шагнув ко входу, я мысленно взывала ему.");

            //Clear sound
            ClearSound(true, true, true);
        }
        private void Cartina_LoveHotelBegin()
        {
            string BG = BG_LOVE_HOTEL; // evening cabinet
            string MAN = MAN1;

            currentGr = "16.Love Hotel - begin.";
            int i = 672; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000007.wav");
            //Music ============================

            // Decoration change -LOVE HOTEL
            S2 = 0715; X2 = 155; Y2 = 55;
            S1 = 1100; X1 = 70; Y1 = 55;
            //1
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, null, BG, $"{Girl}~(Так вот, как это выглядит ...)"
                , OpEf.AppearCurrent(1));
            //2
            DoC(1073, 0, null, BG, $"Когда я и {GoodMan} еще только встречались, мы никогда не бывали здесь.");
            //3
            DoC(1073, 0, null, BG, $"Обстановка в первом доме свиданий, в который я попала, разочаровала меня немного.");
            //4
            DoC(1073, 0, null, BG, $"До этого, я думала, что тут будет все более необычно.");
            //5
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1073, 0, null, BG, $"{Girl}~(Тут все как-то обыкновенно ....) ");
            //6
            DoC(1073, 0, null, BG, $"Удивительно, что я думала сейчас о таких пустяках.");
            //7
            X1 = 470;X2 = 155;            
            DoC(1073, 0, MAN, BG, $"{BadMan}~{Girl}?"
                ,OpEf.AppearCurrent(2));
            //8
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1069, 0, MAN, BG, $"{Girl}~.... ... да..! "
                , OpEf.HidePrev(1));
            //9
            DoC(1069, 0, MAN, BG, $"{BadMan}~Сначала нужно принять душ.");
            //10
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1069, 0, MAN, BG, $"{Girl}~тогда ... да, я ... ... ");
            //11
            DoC(1069, 0, MAN, BG, $"После этих слов, напряжение возросло.");
            //12
            DoC(1073, 0, MAN, BG, $"Я поняла, что ЭТО началось, и почувствовала, как задрожали ноги."
                , OpEf.HidePrev(1));
            //13
            AddEffect2($"effect.arc_000108.wav", SoundPauseNone, false);//Effect - shower   (also effect.arc_000106.wav)         
            DoC(0, 0, null, BG_NIGHT_SKY, $"...");
            //14
            DoC(0, 0, null, BG_NIGHT_SKY, $"... ...");
            //15
            DoC(0, 0, null, BG_NIGHT_SKY, $"... ... ...");
            //16
            RemoveEffect2();
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, null, BG, $"{Girl}~о ... ... извините, что вам пришлось ждать ...... "
                , OpEf.AppearCurrent(1));
            //17
            DoC(1050, 0, null, BG, $"Я приняла душ и переоделась.");
            //18
            DoC(1050, 0, null, BG, $"Я старалась держаться так, как будто ничего не происходило.");
            //19
            DoC(1050, 0, MAN, BG, $"{BadMan}~Что, вы сменили одежду? "
                , OpEf.AppearCurrent(2));
            //20
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, MAN, BG, $"{Girl}~да ... , так ... ... ");
            //21
            DoC(1050, 0, MAN, BG, $"{BadMan}~……хм. Хорошо, я не возражаю. ");
            //22
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, MAN, BG, $"{Girl}~Простите меня ... ");
            //23
            DoC(1050, 0, MAN, BG, $"Я не собиралась становиться собственностью, которой владел {BadMan} ... ...И все же, {BadMan} указал мне на место, я не смогла сказать слово против.");
            //24
            DoC(1050, 0, MAN, BG, $"Когда я смотрела на него, у меня дрожала даже спина.");
            //25
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, MAN, BG, $"{Girl}~ Мне страшно... ");
            //26
            DoC(1050, 0, MAN, BG, $"Я думаю, что это человек умеет создавать какую-то странную атмосферу.");
            //27
            DoC(1050, 0, MAN, BG, $"Первый раз в жизни я боялась мужчину.");
            //28
            DoC(1050, 0, MAN, BG, $"{BadMan}~Итак ... ... Итак, не хочешь сначала обслужить ротиком?");
            //29
            DoC(1050, 0, null, BG, $"{BadMan} сказал эти слова, садясь на край кровати."
                , OpEf.HidePrev(2));
            //30
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, null, BG, $"{Girl}~... ...обслужить... ...?");
            //31
            X2 = -15; Y2 = 475;
            DoC(1048, 0, MAN, BG, $"{BadMan}~Ты раньше не делала минет? Я слишком устал, чтобы разгадывать загадки. Я должен передохнуть."
                , OpEf.HidePrev(1), OpEf.AppearCurrent(2));
            //32
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1050, 0, null, BG, $"{Girl}~!!!"
                , OpEf.HidePrev(1), OpEf.HidePrev(2));
            //33
            DoC(1050, 0, null, BG, $"Конечно, мне не следует переспрашивать его.");
            //34
            DoC(1050, 0, MAN, BG, $"{BadMan}~В чем дело? "
                , OpEf.AppearCurrent(2));
            //35
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, null, BG, $"{Girl}~о, это не ... ... то чтобы ... ... у меня нет большого опыта ... ... "
                , OpEf.HidePrev(1), OpEf.HidePrev(2));
            //36
            DoC(1049, 0, null, BG, $"{GoodMan} - я подумала о нем, мне надо было научиться с ним.");
            //37
            DoC(1049, 0, null, BG, $"Я стала делать это, но не смогла, и больше мы не пробовали.");
            //38
            DoC(1049, 0, MAN, BG, $"{BadMan}~Вижу ... что ж, я не ожидал такого."
                ,OpEf.AppearCurrent(2));
            //39
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, null, BG, $"{Girl}~хорошо ... "
                , OpEf.HidePrev(2));
            //40
            DoC(1049, 0, null, BG, $"Не смотря на это я не могла сдвинуться с места.");
            //41
            DoC(1049, 0, null, BG, $"Я боялась того, что надо сделать ... но может это будет для меня лучше.");
            //42
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, null, BG, $"{Girl}~(Я постараюсь и {BadMan} будет удовлетворен, и тогда ... ...) ");
            //43
            DoC(1049, 0, null, BG, $"Если добиться эякуляции ртом, то до можно избежать самого худшего.");
            //44
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1049, 0, null, BG, $"{Girl}~Хорошо, я согласна ... ... сделать это ... ... ");
            //45
            DoC(1049, 0, null, BG, $"Едва слышно промолвив эти слова, я опустилась на колени перед {BadMan}.");

            ClearSound(true,true,true);
        }
        private void Cartina_Blowjob()
        {
            string BG = BG_LOVE_HOTEL; // evening cabinet
            string MAN = MAN1;

            currentGr = "17.Finansist minet.";
            int i = 686; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000003.wav");
            //Music ============================


            X1 = 0; Y1 = 0; S1 = 1370;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0042, 0, null, null, $"{Girl}~ ... ... ... ... ");
            DoC(0042, 0, null, null, $"Я оказалась на коленях, перед пахом {BadMan.R}.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0042, 0, null, null, $"{Girl}~...............");
            DoC(0042, 0, null, null, $"Что делать дальше, я не понимала.");
            DoC(0042, 0, null, null, $"По сравнению с {GoodMan.T} все было по-другому, я растерялась.");
            DoC(0042, 0, null, null, $"{BadMan}~Может быть, пора его уже достать? ");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0042, 0, null, null, $"{Girl}~........");
            DoC(0042, 0, null, null, $"{BadMan} приподнялся и выпятил пах.");
            DoC(0042, 0, null, null, $"Достать это из его брюк ... ... мне на самом деле нужно это сделать?");
            DoC(0042, 0, null, null, $"Я не делала такого даже с {GoodMan.T}.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0042, 0, null, null, $"{Girl}~(Я должна ... ... должна ...) ");
            DoC(0042, 0, null, null, $"Пальцы осторожно берут застежку молнии и медленно тянут ее вниз.");            
            AddEffect1($"effect.arc_000075.wav", SoundPauseShort, false); // effect - zipper
            DoC(0042, 0, null, null, $"Ширинка раскрывается, и оттуда с силой выпрыгивает пенис {BadMan.R}.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0044, 0, null, null, $"{Girl}~........."
                , OpEf.HidePrev(1));
            DoC(0044, 0, null, null, $"Прямо перед моими глазами - интимная часть мужчины, и притом - не моего мужа.");
            DoC(0044, 0, null, null, $"Я не была ни с кем, кроме {GoodMan.R}, поэтому, возможно, что мне было чуть-чуть любопытно.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0044, 0, null, null, $"{Girl}~........");
            DoC(0044, 0, null, null, $"{BadMan}~Впечатляет, правда?");
            DoC(0044, 0, null, null, $"Интонация голоса {BadMan.R} была насмешливая.");
            DoC(0044, 0, null, null, $"{BadMan} явно забавлялся моей реакцией.");
            DoC(0044, 0, null, null, $"Но эта реакция была бы неуместна для опытной женщины, у меня же это было в первый раз.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0044, 0, null, null, $"{Girl}~(... ... у других он выглядит так... ... ...!?)");
            DoC(0044, 0, null, null, $"Хоть еще не полностью возбужденный, он был больше, чем {GoodMan.R}, и какой-то более жесткий.");
            DoC(0044, 0, null, null, $"Даже не прикасаясь к нему, я чувствовала, что он твердый.");
            DoC(0044, 0, null, null, $"Возможно, потому что он был весь увит толстыми венами.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0044, 0, null, null, $"{Girl}~(Наверно, это потому, что {BadMan} больше, чем {GoodMan} ...)");
            DoC(0044, 0, null, null, $"Так как я раньше видела 'его' только у {GoodMan.V}, то не могла сказать, среднего он размера, или большого.");
            DoC(0044, 0, null, null, $"{BadMan}~Долго будем разглядывать?");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0043, 0, null, null, $"{Girl}~... ... ...... ... ... ",
                OpEf.HidePrev(1));
            DoC(0043, 0, null, null, $"Немного осмелев, я на самом деле рассматривала его 'штуку'.");
            DoC(0043, 0, null, null, $"Работать ртом - значит лизать это.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0043, 0, null, null, $"{Girl}~..........");
            DoC(0043, 0, null, null, $"Если бы это был {GoodMan}, я делала бы все, несмотря на стыд.");
            DoC(0043, 0, null, null, $"Но как делать такие вещи с другим мужчиной?");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0043, 0, null, null, $"{Girl}~(Если я сделаю это, то пути назад уже может не быть ... ...)");
            DoC(0043, 0, null, null, $"От меня могут потребовать чего-то большего, чем просто полизать это.");
            DoC(0043, 0, null, null, $"Тогда ... ... Если сделать все хорошо, и он будет удовлетворен, тогда мое самое важное место будет спасено.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0043, 0, null, null, $"{Girl}~(... ... но я должна хорошо постараться ... ... ...)");
            DoC(0043, 0, null, null, $"Я решилась и осторожно дотронулась языком до {BadMan.R}.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~............."
                 ,OpEf.HidePrev(1));
            DoC(0045, 0, null, null, $"Язык коснулся чего-то очень горячего и твердого.");
            DoC(0045, 0, null, null, $"If you have not been drinking liquor Maybe, I think I could not be such a thing.");
            DoC(0045, 0, null, null, $"I am touching the tongue to the one of the other male now.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~(I'm licking ...... I am licking ... ...)");
            DoC(0045, 0, null, null, $"Feeling like licking a specially thick fingertip ... .... But, licking is not a finger.");
            DoC(0045, 0, null, null, $"Why is not Kohei-san?");
            DoC(0045, 0, null, null, $"While suppressing the coming welled up is such a feeling, we desperately moving the tongue.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~lick"
                 ,OpEf.HidePrev(1));
            DoC(0047, 0, null, null, $"Fortunately, I did not have much dislike.");
            DoC(0047, 0, null, null, $"Mr. Minato is not taking a shower, but he does not feel the smell of the sweat or body odor. It does not taste unpleasant.");
            DoC(0047, 0, null, null, $"It was sad that I was licking, but I did not think it was particularly bad.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~lick");
            DoC(0047, 0, null, null, $"In a way I remember, I licked hard objects in front of my eyes many times.");
            DoC(0047, 0, null, null, $"Push the tongue firmly, slide it up and down, rub it sideways, and lick all the places that arrive.");
            DoC(0047, 0, null, null, $"I wonder if it is okay with such feeling.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0048, 0, null, null, $"{Girl}~lick",
                 OpEf.HidePrev(1));
            DoC(0048, 0, null, null, $"Mr. Minato is just leaving himself, nothing to say.");
            DoC(0048, 0, null, null, $"Occasionally, trembling the hips and waist at the time, I just look down at me and stay silent.");
            DoC(0048, 0, null, null, $"Even so, when I moved my tongue and kept licking, I felt it got harder.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0048, 0, null, null, $"{Girl}~lick");
            DoC(0048, 0, null, null, $"I wonder if I lick it like this, will it be out soon?");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0048, 0, null, null, $"{Girl}~(I wish I had studied more ... ... ... U. ..)");
            DoC(0048, 0, null, null, $"Of course for Mr. Kohei.");
            DoC(0048, 0, null, null, $"But it is late to regret such a thing at this time.");
            DoC(0048, 0, null, null, $"Anyway, I have to satisfy Mr. Minato anyway.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0048, 0, null, null, $"{Girl}~lick");
            DoC(0048, 0, null, null, $"However, I have little experience or knowledge and I am not sure if it is being done properly.");
            DoC(0048, 0, null, null, $"Mr. Minodo's stuff is hard and tightly stretched, but I wonder if it makes me feel good.");
            DoC(0048, 0, null, null, $"Remains of anxiety feelings, continue to lick anyway.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~Oh"
                 ,OpEf.HidePrev(1));
            DoC(0047, 0, null, null, $"Язык касается толстых кровеносных сосудов, дрожащих время от времени, дрожащих.");
            DoC(0047, 0, null, null, $"Стало тяжело, что стало тяжелее, что он стал сильным.");
            DoC(0047, 0, null, null, $"Но до сих пор человек тоже мокрый, но он этого не чувствует.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~Oh");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~(Наверное, потому что я слишком плохой ... ...?) $");
            DoC(0047, 0, null, null, $"Взглянув на меня, минато не шевелился.");
            DoC(0047, 0, null, null, $"Г-н Минато, похоже, имеет много опыта по-разному, и, возможно, он не чувствует его в моем служении.");
            DoC(0047, 0, null, null, $"Wistaria~....");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~Oh");
            DoC(0047, 0, null, null, $"Интересно, что я должен делать.");
            DoC(0047, 0, null, null, $"Я не могу закончить, как есть, меня могут спросить до будущего.");
            DoC(0047, 0, null, null, $"Во всяком случае, я должен что-то сделать.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~Ох ... ... О, это ... ... Разве это не удобно ...? Yayoi"
                , OpEf.HidePrev(1));
            DoC(0045, 0, null, null, $"Я осмелюсь спросить об этом.");
            DoC(0045, 0, null, null, $"Если вы не можете удовлетворить г-на Минодо, нет смысла держать его таким, каким оно есть.");
            DoC(0045, 0, null, null, $"Wistaria~Нет, это удобно, как есть.");
            DoC(0045, 0, null, null, $"Г-н Муто, который, наконец, говорил, был спокоен, но он казался счастливым где-то.");
            DoC(0045, 0, null, null, $"It seems that excitement is getting higher than at first");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~.....");
            DoC(0045, 0, null, null, $"Почему бы тебе не выпустить меня.");
            DoC(0045, 0, null, null, "Wistaria~What, you wanted to ejaculate?");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~っ て ......, потому что ... ... Если не так ... ... Хм, не так ли? Yayoi"
                , OpEf.HidePrev(1));
            DoC(0047, 0, null, null, $"{BadMan}~It 's like pre - play. I do not mind if you do not need another cum shot..");
            DoC(0047, 0, null, null, "Mr. Minato responded with a sense of frustration as she sees me.");
            DoC(0047, 0, null, null, "I wonder if it is such a thing.");
            DoC(0047, 0, null, null, "But as for me, that is a problem.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0047, 0, null, null, $"{Girl}~(Why, foreplay is ahead of that ... ... It is no good ...!)");
            DoC(0047, 0, null, null, $"Just by serving your mouth this way, you have to get satisfied somehow.");
            DoC(0047, 0, null, null, $"I will betray Kohei if I go further.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~I, ... ... I want to let Mr. Minato ... that ... ... so ... ... ... please, tell me ... How can you make me feel more comfortable ...?"
                , OpEf.HidePrev(1));
            DoC(0045, 0, null, null, $"It was Mr. Minodo who owned the answer.");
            DoC(0045, 0, null, null, $"So in search of the answer, I ask you so honestly.");
            DoC(0045, 0, null, null, $"Then Mr. Mitsuo had a meaningful expression and taught me with a small nod.");
            DoC(0045, 0, null, null, $"{BadMan}~Then, you have to get it sucked and sucked.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0046, 0, null, null, $"{Girl}~Shabu, suck ...! What? Uh ... that is ... ..", OpEf.HidePrev(1));
            DoC(0046, 0, null, null, $"Certainly it is useless as it is now, you only have to change the method, but it seems like it sucks huge.");
            DoC(0046, 0, null, null, $"In the first place, does such a big and hard one fits in my mouth?");
            DoC(0046, 0, null, null, $"Besides, it seems to have been successfully captured, what should be done from then on.");
            DoC(0046, 0, null, null, $"{BadMan}~If I do not like being caught, I will not force you otherwise.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0045, 0, null, null, $"{Girl}~(What to do ......! But, but ... ... if you do not ...) "
                , OpEf.HidePrev(1));
            DoC(0046, 0, null, null, $"If you do not satisfy Mr. Minato, I can not finish it.");
            DoC(0046, 0, null, null, $"It is absolutely necessary to avoid only that, and if you are hesitating to do so, you may lose more important things.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0046, 0, null, null, $"{Girl}~Wow .... OK, I ... ");
            DoC(0046, 0, null, null, $"I can not keep hesitating to have you satisfied with Mr. Minodo.");
            DoC(0046, 0, null, null, $"Borrow the power of liquor remaining in the body, decide the resolution and open your mouth.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            int g = 0050;
            DoC(g, 0, null, null, $"{Girl}~Uh ...... Humble ... ...! Uooh ... .... Poohu ... ...! "
                , OpEf.HidePrev(1));
            
            DoC(g, 0, null, null, $"Trying to get hold of it, the mouth filled with taste and smell that can not be said anything.");
            DoC(g, 0, null, null, $"When you are licking, the things you almost never minddelieated are intensely transmitted as soon as you include it in your mouth.");
            DoC(g, 0, null, null, $"Kohei-san was not only size and shape, its taste and smell were also different.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Even though he is the same man, this is so different ...!)");
            DoC(g, 0, null, null, $"I feel something quite a nasty taste.");
            DoC(g, 0, null, null, $"The smell and taste of raw, raw meat.");
            DoC(g, 0, null, null, $"It seems to get throbbing if you take a bit of a break.");
            DoC(g, 0, null, null, $"{BadMan}~Не подталкивайте себя слишком много? Вы не можете переносить рвоту и прикосновение.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"Keeping his eyes closed, Mr. Minoto's nodding.");
            DoC(g, 0, null, null, $"I got used to the size, I managed to breathe somehow.");
            DoC(g, 0, null, null, $"But if you surely get inside your mouth, you are going to hit your teeth if you are not careful.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Wow ... it's too big, your mouth is hard ... ...) ");
            DoC(g, 0, null, null, $"If you do not open your mouth firmly, you can not hold on properly.");
            DoC(g, 0, null, null, $"Besides, as Mr. Mito says, impossible, I hit my throat and get vomited.");
            g = 0051;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Here ... sucking this ... ... ... ...)"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I was swallowed and swallowed my saliva.");
            DoC(g, 0, null, null, $"I wonder if I can do it.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Even just being held in your mouth desperately, you have to suck even further from here.");
            DoC(g, 0, null, null, $"{BadMan}~What happened? If it is impossible, you can stop it. ");
            DoC(g, 0, null, null, $"I do not know if I can do it, but I can not afford to hesitate.");
            g = 0049;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Move the tongue and try to make it crawl in the mouth.");
            DoC(g, 0, null, null, $"After all it was because of the size, I tried sucking hard and endured desperately to get coughing.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Больно...");
            DoC(g, 0, null, null, $"Because it seems that the mouth is open to the full, it seems that a burden is also burdened on the jaw, and I can not stand it, I can not get power well.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"Still suffering suffering, I am suddenly sucking suddenly.");
            DoC(g, 0, null, null, $"With the tongue pressed as much as possible, accompany the lips and cheeks, using the whole mouth, try rubbing mumps.");
            DoC(g, 0, null, null, $"I do not even know if this sucking method is good, but I have to work hard anyway.");
            g = 0051;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Then little by little, something began to bleed from the former.");
            DoC(g, 0, null, null, $"It was a little tenacious it was that it leaks from the tip when a man gets pleasant.");
            DoC(g, 0, null, null, $"Maybe Mr. Minato may finally feel comfortable.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Okay, good ... ....)");
            DoC(g, 0, null, null, $"Anxiety is slightly thin, I feel something like a response.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"It also got used to the movement that suddenly sucked.");
            DoC(g, 0, null, null, $"Even though it was only painful at the beginning, it was getting naturally sucked little by little.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh(Do not put too much force on your neck, while softly moving ... ...) ");
            DoC(g, 0, null, null, $"I feel like I treat it with my lips.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"If it is only that, the stimulus will be weak, so strongly suck it up, try tangling the tongue, try trial and error.");
            DoC(g, 0, null, null, $"Then it seemed that it began to demonstrate its effect.");
            DoC(g, 0, null, null, $"{BadMan}~Ok, it is getting better.");
            DoC(g, 0, null, null, $"Unexpectedly Mr. Minato said that and praised me.");
            DoC(g, 0, null, null, $"I do not serve as I like it, but I will be pleased when praised.");
            g = 0049;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"The feeling that I want to be more pleasant has naturally risen within me.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"If you continue as it is, it will surely come out.");
            DoC(g, 0, null, null, $"Such a sense of expectation has also increased and more fever enters the service.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I also forgot that the other party is Kohei, sucked hardly anything in the mouth anyway.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"Saliva falls from the gap of the lip.");
            DoC(g, 0, null, null, $"I got wet to the chest and the valley grew slimy, but I could not afford to care about it.");
            DoC(g, 0, null, null, $"My head was filled with just that I had to satisfy Mr. Minodo.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(If you do not receive it for Mr. Minato ... ...!) ");
            DoC(g, 0, null, null, $"In order not to be asked for any further action, you have to be content with your mouth service alone.");
            g = 0051;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"The lips and tongue and the chin are getting tired gradually, but I can not stop whining.");
            DoC(g, 0, null, null, $"{BadMan}~Well ... it was a nice thing.");
            g = 0052;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(I'm surely a bit more ......) ", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Embracing such expectation somewhat by the voice of Mr. Minato and the feeling of tightening firmly in your mouth.");
            DoC(g, 0, null, null, $"I told myself that it would be over by a little more and continued to serve without rest.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(I'm surely a bit more ......) ", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Because I serve fiercely, somehow sake goes extra.");
            DoC(g, 0, null, null, $"It was a slightly mysterious feeling that my head came as a spin and the sensation was becoming paralyzed.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"My mouth is hot and it is very hot.");
            DoC(g, 0, null, null, $"It gets hot to the head and it gets bothered, and unnecessary things can not be conceived.");
            DoC(g, 0, null, null, $"A bitter taste spreading in your mouth, and a ragged feel touching the tongue.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"I want you to get out soon, I want you to finish as soon as possible.");
            DoC(g, 0, null, null, $"The inside of my head was filled with just that.");
            DoC(g, 0, null, null, $"{BadMan}~Mum ......");
            g = 0052;
            DoC(g, 0, null, null, $"Mr. Minato slightly leaks a voice when rubbing the stubborn part of the back with a tongue strongly."
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I wonder if he felt comfortable right now.");
            g = 0050;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I feel like I could see the light, and the pace goes up at once.");
            DoC(g, 0, null, null, $"I felt that my hands would reach reaching a little more, and expectations would be swelling.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Please, early ......!)");
            DoC(g, 0, null, null, $"Then Mr. Muto unexpectedly opens his mouth.");
            DoC(g, 0, null, null, $"{BadMan}~...... I will release it.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            g = 0050;
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"Before moving understand the meaning of Mr. Moto's words, it strikes the pulse in your mouth violently.");
            g = 0053;
            AddEffect1($"effect.arc_000150.wav", SoundPauseShort, false); // effect - splach also effect.arc_000142.wav,144-156,
            DoC(g, 0, null, null, $"Midori! Happy birthday! Happy birthday! Closed! !", OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"The sperm of Mr. Minato overflows vigorously.");
            DoC(g, 0, null, null, $"A massive mass was poured into his throat with intense momentum.");
            DoC(g, 0, null, null, $"I was already blank in my mind, desperate to catch it.");
            g = 0054;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Bikun, Bikun and strongly pulsate, firmly support with lips.");
            DoC(g, 0, null, null, $"It was also my first time to put it in your mouth, so I was surprised by the violent pulsation.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Shu, ejaculation is so fierce ... ....!)");
            DoC(g, 0, null, null, $"While being stunned, a sticky juice will overflow into your mouth more and more.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh");
            DoC(g, 0, null, null, $"Staying desperately to become coughing and taking it in anyhow frustrated anyhow.");
            DoC(g, 0, null, null, $"Too accumulate in your mouth, it will swallow just a little bit from suffocation.");
            g = 0055;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Fishy smell is missing from the nose, was I knew I would throat.");
            DoC(g, 0, null, null, $"Still take control of it all, make sure that ejaculation is over, and let go of your mouth.");
            g = 0056;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"The taste and smell of live warm semen spread all over your mouth, and I threw it all out.");
            DoC(g, 0, null, null, $"My breath is fishy and a little disgusting.");
            DoC(g, 0, null, null, $"I spit in a hurry, but it looks like I'm still tangled in my mouth.");
            DoC(g, 0, null, null, $"{BadMan}~Was it the first time to accept with your mouth? I was sorry, but it was not bad.");
            g = 0058;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa ... ... Haa ... .... Sure, is that so ... ... it was good ...", OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Although I can not afford to arrange the disturbed breath, still a sense of relief spreads.");
            DoC(g, 0, null, null, $"I managed to satisfy Mr. Minoda.");
            g = 0057;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uh", OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(I got out, it is over with this ... ...) ");
            DoC(g, 0, null, null, $"I managed to do it to the end somehow.");
            DoC(g, 0, null, null, $"With a feeling of relief that Mr. Minodo was able to satisfy, I will redeploy her heart.");
            DoC(g, 0, null, null, $"But as if laughing at my idea, Mr. Minodo starts taking off his suit.");
            DoC(g, 0, null, null, $"{BadMan}~Well, next time I will do well with you.");
            g = 0058;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Huh, huh ...... Eh ... ... Wow, I am ... another ... ...! ", OpEf.HidePrev(1));

            ClearSound(true, true, true);

        }
        private void Cartina_FinansistHotelFuck()
        {
            string BG = BG_LOVE_HOTEL; //
            string MAN = MAN2;

            currentGr = "18.Love Hotel - second part.";
            int i = 760; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000003.wav");
            //Music ============================

            // Decoration change -LOVE HOTEL
            //1
            DoC(0, 0, null, BG, $"I will be embarrassed to get me embarrassed and I will forcibly take off my clothes.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            S1 = 1100; X1 = -515; Y1 = 55;
            S2 = 0715; X2 = 1160; Y2 = 55;
            DoC(1063, 0, MAN, BG, $"{Girl}~Wait, wait ...... ",
                OpEf.AppCurr(1, "W..0>O.B.400.100*W..0>X.B.400.300"),
                OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.-300")
            );
            X1 = -215; X2 = 860;

            DoC(1063, 0, MAN, BG, $"{BadMan}~Remains were wearing clothes would become dirty? Well, it does not matter because the clothes are.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1063, 0, MAN, BG, $"{Girl}~Something like that...!Oh, ah...!");

            DoC(0, 0, null, BG, $"It not can also shake off their hands, very quickly I would be taken off all.",
                OpEf.HidPrev(1, "W..0>O.B.400.-100*W..0>Y.B.200.300"),
                OpEf.HidPrev(2, "W..0>O.B.400.-100*W..0>Y.B.200.300"));

            MAN = MAN3;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            S1 = 1100; X1 = -515; Y1 = 55;
            S2 = 0715; X2 = 1160; Y2 = 55;
            DoC(1097, 0, MAN, BG, $"{Girl}~I am in trouble ...... Such a brutal ... ...",
                OpEf.AppCurr(1, "W..0>O.B.400.100*W..0>X.B.400.300"),
                OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.-300"));
            X1 = -215; X2 = 860;

            DoC(1097, 0, MAN, BG, $"Have you come so far, there is no push? Come here. ");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1097, 0, MAN, BG, $"{Girl}~Wait ... ... Ahh ......!");
            DoC(1097, 0, MAN, BG, $"I thought that it would be done to the end as it was, but I panicked, but it was not so.");
            DoC(1097, 0, MAN, BG, $"Mr.Minodo took my hand and put it on the bed, I was made to a position I do not understand well.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(1097, 0, MAN, BG, $"{Girl}~(No, what are you planning to do ...... !?) ");
            X1 = 0; Y1 = 0; S1 = 1370;
            DoC(0, 0, null, null, $"", OpEf.HidePrev(0), OpEf.HidePrev(1), OpEf.HidePrev(2));
            DoC(0059, 0, null, null, $"What are you doing ...?!", OpEf.AppearCurrent(1));
            DoC(0059, 0, null, null, $"It felt like crossing the face of Mr. Muto who was lying on his back on the bed, I was wearing a cover over it.");
            DoC(0059, 0, null, null, $"{BadMan}~What, you do not know Six Nine, too?");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(0059, 0, null, null, $"{Girl}~I ... ... I do not have it any secret ...?");
            DoC(0059, 0, null, null, $"Somehow I have heard it, but I can not remember it a little.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            int g = 0061;
            DoC(g, 0, null, null, $"{Girl}~(I wonder what it was ...... But if this position ... ... ... ...) "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Mr. Minoto's breath was blown in my crotch.");
            DoC(g, 0, null, null, $"There is my crotch in front of Mr. Minato. Surely the embarrassed place must be visible.");
            DoC(g, 0, null, null, $"And before my eyes there was something that was held until a while ago.");
            DoC(g, 0, null, null, $"{BadMan}~Well, this is the act of caressing each other like this. ");
            g = 0060;
            i++;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~... ... to each other ...! What?"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"It is certainly such a position but I did not think that I should do it yet.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(But, I thought it would be the end if I put it out ...) ");
            DoC(g, 0, null, null, $"Kohei-san is always over when I put it out, and I thought that the man's man can only be issued once.");
            DoC(g, 0, null, null, $"But, Mr. Muto's thing is still firm.");
            DoC(g, 0, null, null, $"There is no other way than to say that my idea I did not know was sweet.");
            g = 0062;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Huh ... ... here in this kind of dress ... ...."
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"{BadMan}~That's why, please also serve well. ");
            g = 0060;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Uooh ...... Yes ... ..."
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Every time Mr. Minato speaks, I take a breath over there.");
            DoC(g, 0, null, null, $"Kohei - san is ashamed because he did not close his face so close.");
            g = 0061;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haa ......, Fuu ...... "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"But, as soon as I come here, I have to decide my mind and continue.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(2 times ...... If you put it out twice, surely ... ....) " );
            DoC(g, 0, null, null, $"Mr. Minodo was drinking as well at the bar and I wanted to think that I could not continue so much.");
            g = 0062;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Chu ...... Chu ...... Re ... .... Re ... ... "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I drove embarrassment to a corner of my head and stretched my tongue to Mr. Mr. Minato who was still stiff.");
            DoC(g, 0, null, null, $"The thick blood vessel rises, the tongue tip is aligned with the rugged portion, and it makes it crawl along the line.");
            DoC(g, 0, null, null, $"Was it a bit familiar or a feeling paralyzed just a little while ago, this time I will be licked without hesitation.");
            DoC(g, 0, null, null, $"I was not bothered by that it was covered with sperm and just slimy.");
            g = 0061;
            DoC(g, 0, null, null, $"To the other party is not a Mr. Kohei, I wonder why it is such a thing.", OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Chu ...... Chu ...... Re ... .... Re ... ... ");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"(Mi, because it's for everyone ...... Asahi-chan, Kohei-san ... ...)");
            DoC(g, 0, null, null, $"So let's tell themselves and try hard.");
            DoC(g, 0, null, null, $"I made up my mind and moved my tongue over and over.");
            DoC(g, 0, null, null, $"But with this position, I will be concerned about Mr. Minoto's line of sight.");
            g = 0060;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Mi......I've been watching ... ... ... ...) "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Even if not see directly into the shadow of the ass, body temperature transmitted to the skin, it will tell the movement of the face of Mr. Minafuji.");
            g = 0061;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haah ... .... Uoo, Huhu ...."
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Even though I made up my mind, when I feel a gaze over there, I can not concentrate on making my tongue crawl on that in front of me.");
            DoC(g, 0, null, null, $"I have already seen naked, but it is still more embarrassing than that.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haah ... .... Uoo, Huhu ....");
            DoC(g, 0, null, null, $"While service in Minafuji's, only that of the line-of-sight becomes mind.");
            DoC(g, 0, null, null, $"Even though I can not finish it unless I concentrate and try hard.");
            DoC(g, 0, null, null, $"{BadMan}~However, it has a beautiful color considerably. There is no collapse of the shape");
            g = 0060;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Like a inflame such a thing my shame, Mr. Minafuji was such a thing impressions in the mouth.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Yes, color or shape ... so ... ...!) ");
            DoC(g, 0, null, null, $"After all it was seen by Mr. Minato.");
            g = 0061;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I'm too embarrassed and it seems to get a fire from my face.");
            DoC(g, 0, null, null, $"Even Kohei-san, you have not been seen so close.");
            DoC(g, 0, null, null, $"{BadMan}~What's wrong, your mouth stopped?");
            g = 0060;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Ah, that ... ... Do not look so much ...... I ... ... it's too embarrassing ...... "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"{BadMan}~I can not do anything if I do not see it? I think the same thing is being watched by it.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~That ... ... ... ... Yes, but, but ... ");
            DoC(g, 0, null, null, $"{BadMan}~Well, I will not mind that at once.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Lie ...... That's ...!");
            DoC(g, 0, null, null, $"{BadMan}~Look here ......");
            g = 0064;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Cowrie ...! Hmm ... ... do not ... ...!"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Before I knew it well, Mr. Minato's finger suddenly came in me.");
            DoC(g, 0, null, null, $"{Girl}~Huhuu, the person behind you is moist. Did you get excited with my cock? ");

            AddEffect2($"effect.arc_000160.wav", SoundPauseShort, true);//Effect - squish

            DoC(g, 0, null, null, $"Mr. Minodo began to move his fingers inside so as to ascertain my feel.");
            g = 0063;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Sure, that ... ... hey, that's ...! Oh no, well ...!"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Even though Mr. Kohei could be touched, I never put my fingers inside like this.");
            DoC(g, 0, null, null, $"Moreover, it has been seen in front of you.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ahhh ... ...!");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(This shy is too embarrassing, I will manage somehow ...!) ");
            DoC(g, 0, null, null, $"It is embarrassing just to be seen, but I can not put it in my fingers.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Oh, no it ...! Please, please pull me out ...!");
            DoC(g, 0, null, null, $"I accidentally appealed to it with such words, but Mr. Minodo did not seem to get through at all.");
            g = 0064;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ahh...    no ...!"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"As the shape of the finger will be clearly Kanjitore, and strongly pressed against the inside, it continued to fuck.");
            DoC(g, 0, null, null, $"Even though I am ashamed of this, I felt like I was enjoying it.");
            CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
            DoC(g, 0, null, null, $"{BadMan}~Hmm ... ... for married people the tightness is also good. ");
            DoC(g, 0, null, null, $"I finally stop fingering, I mutter such things.");
            DoC(g, 0, null, null, $"It is terrible to express a woman 's body that way.");
            g = 0063;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Or, Mr. Minoto ...!"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"{BadMan}~Let's see which sensitivity you are.");
            DoC(g, 0, null, null, $"While saying that with a funny voice, Mr. Minoto's finger started moving slowly again.");
            g = 0064;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ahhh!"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"This time I will touch little by little, looking for something.");
            DoC(g, 0, null, null, $"It seems like I'm verifying my reaction while touching.");
            DoC(g, 0, null, null, $"If you are conscious of such a thing, you will be concerned only with Mr. Minato's fingers moving in that place.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ahhh!");
            DoC(g, 0, null, null, $"I wonder if my fingers are concerned, or because I am ashamed, I feel nervous and my breath does not stop.");
            DoC(g, 0, null, null, $"If you keep on keeping it like this, I will manage to do something.");
            g = 0063;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Wow ... I want to end it soon ... ...)"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"To that end, I have to lead Mr. Muto until ejaculation.");
            DoC(g, 0, null, null, $"If I think that I should try my best the same way, it just gets heavier.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(But, ... ... as it is ... .... Uuu ... ...) ");
            DoC(g, 0, null, null, $"I can not bear this embarrassing thing.");
            DoC(g, 0, null, null, $"As I escaped the reality from embarrassment in front of you, I resolved to prepare and I also got a thing of Mr. Minodo.");
            g = 0066;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"It sucks hard and deeply into it and sucks and sucks it deeper than before.");
            DoC(g, 0, null, null, $"I am used to getting acquainted and sucking licking.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"It has become quite accustomed to shape and size, so I was able to serve much more smoothly than before.");
            DoC(g, 0, null, null, $"However, even though I intend to concentrate on such a mouth service, I will be more concerned about what Mr. Muto is supposed to do.");
            g = 0067;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Ah ... ... well, do not stir it with your fingers so much ...!) ");
            DoC(g, 0, null, null, $"You can see that Mr. Maoto's fingers are moving in me.");
            DoC(g, 0, null, null, $"There just probably because you are in the mood, have become much more sensitive than usual.");
            DoC(g, 0, null, null, $"A bit of movement can be clearly felt.");
            DoC(g, 0, null, null, $"Just a bad feeling becomes stronger, do not be too concentrated in service.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~.....");
            DoC(g, 0, null, null, $"{BadMan}~Like suddenly, suck it tightly? I also do it well.");
            g = 0065;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(You do not have to do such a thing) ");
            DoC(g, 0, null, null, $"I could not say.");
            g = 0066;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I am embarrassed, I move my face in the way I just learned a little while ago, sucking hard and keep sucking it suddenly.");
            DoC(g, 0, null, null, $"Move your face with your head and slide your tongue, treat it with your lips and cheeks, and serve in a way that uses your whole mouth.");
            DoC(g, 0, null, null, $"But Muto's finger movements block it.");
            g = 0067;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"Movement that stirs slowly, has gradually turned into something different.");
            DoC(g, 0, null, null, $"The fingertips that moved as if to stroke inside crooked and started to move in and out while scratching.");
            DoC(g, 0, null, null, $"It makes me so irritated and strange that it gets dumpy.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"{BadMan}~According to the you of the service, I because I also'll be pleasant.");
            DoC(g, 0, null, null, $"In other words it, the more I work hard if hang in there, was that would come back to yourself.");
            g = 0065;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Well, such a trouble ... ...! Ay ... ...) ");
            DoC(g, 0, null, null, $"I just wanna satisfy Mr. Minoda.");
            DoC(g, 0, null, null, $"Separately I do not want you to feel pleasant.");
            DoC(g, 0, null, null, $"However, Mr. Minato will not stop the movement of the fingers put in me.");
            DoC(g, 0, null, null, $"If I did not do anything, it only lasted for a long time.");
            g = 0067;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"According to my sucking, Mr. Minoto's fingers moved again.");
            AddEffect2($"effect.arc_000162.wav", SoundPauseShort, true);//Effect - squish
            DoC(g, 0, null, null, $"Although it is slowly, when put in and out there, a sticky big sound leaks out.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Doing......Sounds horny...___ ___ ___");
            g = 0068;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I did not want to believe, had gotten have been wet enough to be heard clearly up to my ear."); 
            DoC(g, 0, null, null, $"{BadMan}~It's pretty sensitive, not bad.");
            g = 0066;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            AddEffect2($"effect.arc_000163.wav", SoundPauseShort, true);//Effect - squish
            DoC(g, 0, null, null, $"As service is intensified, Mr. Minoto's fingers also moves fancy, and embarrassing sounds are getting bigger and bigger.");
            DoC(g, 0, null, null, $"She seems to be saying that he wants me to feel more pleasant.");
            DoC(g, 0, null, null, $"Even though I do not plan to do that, it will result in that.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"I can not go on to not continue.");
            DoC(g, 0, null, null, $"I have to be satisfied with Mr. Minato before my body can not stand this feeling.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"Mr. Minato's finger movement is not intense, but over there will be getting more and more difficult.");
            DoC(g, 0, null, null, $"Before I knew it, my lower body was getting hot and it got hot.");
            DoC(g, 0, null, null, $"There is no feeling of well-being that makes the heart warm, like Kohei-san did, but that extra was exciting.");
            g = 0067;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"So as not to lose the stimulus from the Minafuji's, suck licking desperately.");
            DoC(g, 0, null, null, $"Somehow, but I learned a little about it.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"If you accumulate saliva in your mouth, it will be easier to suck up a little.");
            DoC(g, 0, null, null, $"But when I'm just sucking, my jaws get tired, so I will use my tongue at the same time and stimulate it.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            DoC(g, 0, null, null, $"Also coming is also blurred horny your juice, Mr. Minafuji is me properly become comfortably.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(If we work hard in this state...)");
            DoC(g, 0, null, null, $"Thinking that way, despite being desperate, Mr. Minodo's finger blocks that idea.");
            g = 0065;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"It was involuntarily stimulation of the more likely causes trembling waist.If you have not'm still painting mouth, maybe I had gotten out amazing voice.");
            AddEffect2($"effect.arc_000164.wav", SoundPauseShort, true);//Effect - squish
            DoC(g, 0, null, null, $"Mr. Minato's fingers are put in and out a little hard.");
            DoC(g, 0, null, null, $"{BadMan}~If you feel this much in the finger, that's variously expected to be likely. ");
            DoC(g, 0, null, null, $"While saying such a funny voice, I will blame me hard.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~uh");
            g = 0071;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Do not intensify ... ... Do not intensify... ...!)"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"I also have a lot of seasoned juice.");
            DoC(g, 0, null, null, $"It will not be fake for me so long as it will be this way."); 
            DoC(g, 0, null, null, $"To the fact that I felt, my heart is tightened with a sense of guilt.");
            DoC(g, 0, null, null, $"I do not forgive everything, but that does not make any excuse.");
            g = 0070;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"In order to escape from such guilt, I try to devote himself to the service before my eyes.");
            DoC(g, 0, null, null, $"Because too spicy and not to do so.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            DoC(g, 0, null, null, $"However, Mr. Minodo blamed me more intensely like laughing at my feelings.");
            AddEffect2($"effect.arc_000165.wav", SoundPauseShort, true);//Effect - squish
            g = 0071;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(ah)");
            DoC(g, 0, null, null, $"My fingers move fiercely more than the momentum I lick.");
            DoC(g, 0, null, null, $"It was roughly disturbed and the waist trembled.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            DoC(g, 0, null, null, $"Still, somehow, I will continue to serve hard so that I can not defeat the stimulus.");
            DoC(g, 0, null, null, $"It seemed that I could not do anything anymore if I took a rest for a while.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(But, ... ... I got it any longer ...!)");
            DoC(g, 0, null, null, $"Continue to serve Mr. Muto hard while enduring the culmination which gradually increases.");
            DoC(g, 0, null, null, $"Only the feeling which stiffly stretches in your mouth supported the tense feeling.");
            g = 0070;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Even, a little more ... ...!)"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"If Mr. Minodo issues it, it ends with that.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            DoC(g, 0, null, null, $"I just suck it and it sucks licking desperately.");
            DoC(g, 0, null, null, $"My jaw is also tired and salivation does not stop, and my sense of lips and tongue is getting dull.");
            DoC(g, 0, null, null, $"But now I can not stop whining.");
            g = 0071;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Oh, ah ......! Well, it's useless ... ...!) "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"Intense fingering's Minafuji to go cornered.");
            DoC(g, 0, null, null, $"I will not be able to endure any more.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~((Sorry, Kohei-san ... ...!) ) ");
            DoC(g, 0, null, null, $"While apologizing to Kohei's in my mind, decide prepared to become reached.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            DoC(g, 0, null, null, $"{BadMan}~I will release it soon ...!");
            DoC(g, 0, null, null, $"It was just after that that he heard that word.");

            g = 0073;
            ORGAZM = true;
            CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{ Girl}~ah"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"...");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{ Girl}~ah");
            DoC(g, 0, null, null, $"Mr. Maito's ejaculation begins at the beat that I opened my mouth without thinking.");
            DoC(g, 0, null, null, $"Suddenly overflowing from Mr. Mihito's pulsating in front of my eyes.");
            g = 0072;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah"
                , OpEf.HidePrev(1));
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Ah ... .... Ah, it's hot, so much ...!!)");
            DoC(g, 0, null, null, $"Even though I just got out earlier, I still wish I could have gone so much.");
            DoC(g, 0, null, null, $"Besides, I also reached it lightly with Mr. Minodo's ejaculation.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(Ah ... .... Ah, it's hot, so much ...!!)");
            DoC(g, 0, null, null, $"Besides, I also reached it lightly with Mr. Minodo's ejaculation.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"({Girl}~(Uoo, ... together until me ......) ");
            DoC(g, 0, null, null, $"It is embarrassing that we have reached together if it only serves.");
            DoC(g, 0, null, null, $"It makes me feel comfortable by being made by someone other than Kohei.");
            g = 0075;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah"
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"With the great smell of semen and the lingering finish of cum, the body is still hot.");
            DoC(g, 0, null, null, $"My head is getting bogged down and it seems I can not think about it properly.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"({Girl}~(Well ... but it was over with this ... ...?)");
            DoC(g, 0, null, null, $"I want to think so, but I was not very confident.");
            DoC(g, 0, null, null, $"Perhaps it is said that it will continue still.");
            DoC(g, 0, null, null, $"I have no confidence to satisfy with service alone.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~ah");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~(But, until the end ... that is only ... ...) ");
            DoC(g, 0, null, null, $"If you betray Kohei to that point, you will definitely not be able to match your face.");
            DoC(g, 0, null, null, $"At least with guilt, I did not have confidence to speak properly.");
            DoC(g, 0, null, null, $"{BadMan}~Well, it was not bad service");
            g = 0074;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Oh, thank you .... "
                , OpEf.HidePrev(1));
            DoC(g, 0, null, null, $"{BadMan}~Have you finished it properly?");
            DoC(g, 0, null, null, $"Maybe Mr. Minafuji is known, has come to hear so.");
            DoC(g, 0, null, null, $"I think surely and I want to admit it to me.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, null, $"{Girl}~Um ... ..., yes ...... Yayoi");
            DoC(g, 0, null, null, $"But I could not deny, I was nodding back.");
            DoC(g, 0, null, null, $"It is very embarrassing and I am sad when I think of Kohei but I am afraid to fail Mr. Moto's mood.");
            DoC(g, 0, null, null, $"Поэтому не решался лгать или обманывать.");
            DoC(g, 0, null, null, $"{BadMan}~Хуху, это правильно ... ");
            DoC(g, 0, null, null, $"Mr. Minodo leaks a satisfying smile to my answer.");
            DoC(g, 0, null, null, $"И это вызвало тело так, чтобы отклонить мое тело.");
            DoC(0, 0, null, null, $"");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            S1 = 1100; X1 = 750;  Y1 = 55;
            S2 = 0715; X2 = -50;  Y2 = 55;
            g = 1097;
            DoC(g, 0, MAN, BG, $"{Girl}~ ...... ",
                OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300"),
                OpEf.AppCurr(1, "W..0>O.B.400.100*W..0>X.B.400.-300")
            );
            X1 = 450; X2 = 250;
            DoC(g, 0, MAN, BG, $"I can not see how tired he is, so I wonder if he I can continue as it is.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, MAN, BG, $"{Girl}~(...oh....{GoodMan}....)");
            DoC(g, 0, MAN, BG, $"The leg trembles as if I think I will cross the last line.");
            DoC(g, 0, MAN, BG, $"But Mr. Mihito returned his heel on the spot and turned his back on me.");
            DoC(g, 0, MAN, BG, $"{BadMan}~I get back after taking a shower.Since check out is keep finished earlier, may you're back at you like timing.");
            g = 1094;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, MAN, BG, $"{Girl}~Well ... but, but ... ", OpEf.HidePrev(1));
            DoC(g, 0, MAN, BG, $"Swallow the word whether it does not have to be done to the end.");
            DoC(g, 0, MAN, BG, $"And put it in his mouth, it was afraid that become snake.");
            DoC(g, 0, null, BG, $"Mr. Minato enters the bath, as it is.",
                OpEf.HidPrev(2, "W..0>O.B.400.-100*W..0>X.B.400.-300"));
            g = 1095;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, BG, $"{Girl}~... I wonder what it is ... ...", OpEf.HidePrev(1));
            DoC(g, 0, null, BG, $"I do not quite understand it, but I did not go beyond the last one line.");
            DoC(g, 0, null, BG, $"While relieving to that, it also makes me uneasy.");
            DoC(g, 0, null, BG, $"Because I was not sure what Mr. Mito thought.");
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, null, BG, $"{Girl}~(Perhaps, I was already satisfied ... ...?)");
            DoC(g, 0, null, BG, $"I wanted to think so because it was issued twice, but I do not understand well because there is no object compared to except Mr. Kohei.");
            DoC(g, 0, null, BG, $"Mr. Mito finishes showering and comes back while I am confused as to what I should do.");
            MAN = MAN2; X2 = -50;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC(g, 0, MAN, BG, $"{Girl}~ ......  ......  ......  ......  ...... ",
               OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300")          
               );
            MAN = MAN1; X2 = -50;
            DoC(g, 0, MAN, BG, $"And in front of my eyes I changed to a suit again."                
                , OpEf.HidPrev(2, "W..0000>O.B.400.-100*W..0000>X.B.400.-300")
                , OpEf.AppCurr(2, "W..1000>O.B.400.+100*W..1000>X.B.400.+300")
               );
            X2 = 250;
            DoC(g, 0, MAN, BG, $"{BadMan}~Well then, I will contact you again.");
            //DoC(g, 0, null, BG, $"");
            //DoC(g, 0, null, BG, $"");
            //DoC(g, 0, null, BG, $"");
            //DoC(g, 0, null, BG, $"");
            //DoC(g, 0, null, BG, $"");
            //DoC(g, 0, null, BG, $"");
        }


        private void AddEffect1(string effect1, int effect1Pause, bool effect1Loop)
        {
            if (!string.IsNullOrEmpty(effect1))
            {
                CurrentSounds.RemoveAll(x => x.Name == "EFFECT1");
                CurrentSounds.Add(new seSo()
                { File = $"{PATH_E}{effect1}",
                    Name = "EFFECT1",
                    V = VOLUME_E,
                    IsLoop = effect1Loop,
                    StartPlay = 0,
                    T = $"W..{effect1Pause}>p.A.0.1" });
            }
        }
        // add prolonged effect (Loop=true)
        private void AddEffect2(string effect, int effectPause, bool effectLoop)
        {
            if (!string.IsNullOrEmpty(effect))
            {
                CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
                CurrentSounds.Add(new seSo()
                {
                    File = $"{PATH_E}{effect}",
                    Name = "EFFECT2",
                    V = VOLUME_E2,
                    IsLoop = effectLoop,
                    StartPlay = 0,
                    T = $"W..{effectPause}>p.A.0.1"
                });
            }
        }
        private void AddVoice(string voice, int voicePause, bool voiceLoop)
        {
            if (!string.IsNullOrEmpty(voice))
            {
                CurrentSounds.RemoveAll(x => x.Name == "VOICE");
                CurrentSounds.Add(new seSo()
                { File = $"{PATH_V}{voice}",
                    Name = "VOICE",
                    V = VOLUME_V,
                    IsLoop = voiceLoop,
                    StartPlay = 0,
                    //T = $"W..{voicePause}>p"
                    T = $"W..{voicePause}>p.A.0.1"
                });
            }
        }
        private void RemoveEffect2()
        {
            CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
        }

        private void RemoveMusic()
        {
            CurrentSounds.RemoveAll(x => x.Name == "MUSIC");
        }
        private void AddMusic(string file)
        {
            RemoveMusic();
            CurrentSounds.Add(new seSo()
            { File = $"{PATH_M}{file}",
                Name = "MUSIC",
                StartPlay = 1,
                IsLoop = true,
                V = VOLUME_M });
        }
        private void ClearSound()
        {
            ClearSound(true,true, true);
        }
        private void ClearSound(bool music, bool effect1, bool voice)
        {
            if (music)
            CurrentSounds.RemoveAll(x => x.Name == "MUSIC");
            if (effect1)
            CurrentSounds.RemoveAll(x => x.Name == "EFFECT1");
            if (voice)
            CurrentSounds.RemoveAll(x => x.Name == "VOICE");
        }

        private void AddCadr(int index, string Bg, string text, OpEf op = null)
        { DoC(index, 0, null, Bg, text , op); }
        private void AddCadr(int index, string Bg, string text)
        { AddCadr(index, null, Bg, text); }
        private void AddCadr(int index, string man, string Bg, string text)
        { DoC(index, 0, man, Bg, text); }
        private void AddCadr(int index, int index1, string Bg, string text)
        { DoC(index, index1, null, Bg, text); }
        private void DoC(int index, int index1, string man, string Bg, string text)
        {
            DoC(index, index1, man, Bg, text, null);
        }

        private void DoC(int index,int index1, string man,string Bg, string text, params OpEf[] oefa)
        {
            
            if (string.IsNullOrEmpty(Bg))
                Bg = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";

            List<DifData> cdata = null;            

            cdata = new List<DifData>()
            { 
               new DifData(Bg) { S = s, F = 0}
            };

            #region Z Staff
            if (Z3 == 3)
            {
                if (index1 > 0)
                {
                    cdata.Add(new DifData(data[index1 - 1]) { S = S3, X = X3, Y = Y3 });
                }
            }
            else if (Z2 == 3)
            {
                if (!string.IsNullOrEmpty(man))
                {
                    cdata.Add(new DifData(man) { S = S2, X = X2, Y = Y2 });
                }
            }
            else if (Z1 == 3)
            {
                if (index > 0)
                {
                    cdata.Add(new DifData(data[index - 1]) { S = S1, X = X1, Y = Y1 });
                }
            }

            if (Z3 == 2)
            {
                if (index1 > 0)
                {
                    cdata.Add(new DifData(data[index1 - 1]) { S = S3, X = X3, Y = Y3 });
                }
            }
            else if (Z2 == 2)
            {
                if (!string.IsNullOrEmpty(man))
                {
                    cdata.Add(new DifData(man) { S = S2, X = X2, Y = Y2 });
                }
            }
            else if (Z1 == 2)
            {
                if (index > 0)
                {
                    cdata.Add(new DifData(data[index - 1]) { S = S1, X = X1, Y = Y1 });
                }
            }

            if (Z3 == 1)
            {
                if (index1 > 0)
                {
                    cdata.Add(new DifData(data[index1 - 1]) { S = S3, X = X3, Y = Y3 });
                }
            }
            else if (Z2 == 1)
            {
                if (!string.IsNullOrEmpty(man))
                {
                    cdata.Add(new DifData(man) { S = S2, X = X2, Y = Y2 });
                }
            }
            else if (Z1 == 1)
            {
                if (index > 0)
                {
                    cdata.Add(new DifData(data[index - 1]) { S = S1, X = X1, Y = Y1 });
                }
            }

            #endregion

            if (oefa != null)
            {
                foreach (var oef in oefa)
                {
                    if (oef != null)
                    {
                        DifData d = null;
                        if (!oef.P)
                        {
                            d = cdata[oef.L];
                        }
                        else
                        {
                            var old = this.AlignList.Last().AlignList[oef.L];
                            d = new DifData();
                            d.AssingFrom(old);
                            d.Name = old.Name;
                            d.Parent = old.Parent;
                            d.S = old.S;
                            cdata.Add(d);
                        }
                        if (oef.Tran != null)
                        {
                            d.O = oef.O;
                            d.T = oef.Tran;
                        }
                        else
                        {
                            if (oef.D)
                            {
                                if (d != null)
                                {
                                    d.O = 100;
                                    d.T = $"W..{oef.W}>O.B.{oef.T}.-100";
                                }
                            }
                            else
                            {
                                if (d != null)
                                {
                                    d.O = 0;
                                    d.T = $"W..{oef.W}>O.B.{oef.T}.100";
                                }
                            }
                        }
                    }
                }
            }
           
            if (ORGAZM)
            {
                cdata.Add(new DifData() { Name = "FLASH_BG",O=0, S=1370, T=Transition.Test_Opacity});
                ORGAZM = false;
            }

            AddLocal(currentGr, text, cdata, this.CurrentSounds);
            this.ClearSound(false,true,true);
        }

        private void AddCadre2(int index, string text, int? Xx = null)
        {
            string im = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
            if (index > 0)
                im = data[index - 1];
            List<DifData> cdata = null;
            if (Xx.HasValue)
            {
                cdata = new List<DifData>()
                {
                    new DifData(im) {X = -95, S = 1525, F = 0},
                };
            }
            else
            {
                cdata = new List<DifData>()
                {
                    new DifData(im) {X = -95, S = 1525, F = 0},
                };
            }
            AddLocal(currentGr, text, cdata);
        }
        private void AddCadreAoiKohei(int index,string gm, string text)
        {
            List<DifData> cdata = new List<DifData>() {
            new DifData(data[index - 1]) { X = 0, S = s, F = 0},
            new DifData(gm) { Y = 540, S = 230, F = 0},
            }; AddLocal(currentGr, text, cdata);
        }
        private void AddCadre(int index, string text, int? Xx = null)
        {
            string im = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
            if (index > 0)
                im = data[index - 1];
            List<DifData> cdata = null;
            if (Xx.HasValue)
            {
                cdata = new List<DifData>()
                {
                    new DifData(im) {X = Xx, S = s, F = 0},
                };
            }
            else
            {
                cdata = new List<DifData>()
                {
                    new DifData(im) { S = s, F = 0},
                };
            }
            AddLocal(currentGr, text, cdata);
        }
        private void AddCadreAoiMinodo(int index, string text)
        {
            List<DifData> cdata = new List<DifData>() {
             new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -115, Y = -15, S = 2095, F = 0},
             new DifData(data[index - 1]) { X = -425, S = 1500, F = 0},
            }; AddLocal(currentGr, text, cdata);
        }
        private void AddCadreAoiAsahi(int index,int index1, string text)
        {
            List<DifData>  cdata = new List<DifData>() {
            new DifData(data[index - 1]) { X = 385, S = s, F = 0},
            new DifData(data[index1 - 1]) { X = -330, S = s, F = 0},
            }; AddLocal(currentGr, text, cdata);
        }
        private void AddCadreAoiAsahiKimishima(int index, int index1, int index2, string text)
        {
            List<DifData> cdata = new List<DifData>() {
            new DifData(data[index1 - 1]) { X = 450, S = 1230, F = 0},
            new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -485, Y = 5, S = 1540, F = 0},
            new DifData(data[index - 1]) { X = 65, S = 1230, F = 0},
            }; AddLocal(currentGr, text, cdata);
        }
        private void AddCadreAoiAsahiKimishim2(int index, int index1, int index2, string text)
        {
            List<DifData> cdata = new List<DifData>() {
            new DifData(data[index1 - 1]) { X = 320, S = 1500, F = 0},
            new DifData("SILKYS_SAKURA_OttoNoInuMaNi_BM01") {X = -695, Y = -15, S = 2095, F = 0},
            new DifData(data[index - 1]) { X = -35, S = 1500, F = 0},
            }; AddLocal(currentGr, text, cdata);
        }
       


        protected override void DoFilter(string cadregroup)
        {       
            string[] cd = new string[] {
                "18.Love Hotel - second part."
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }

    public class HumanName
    {
        public HumanName(string i)
        {
            this.I = i;
        }
        public override string ToString()
        {
            return this.I;
        }
        public string I;
        public string R;
        public string V;
        public string T;
        public string D;
        public string P;
    }
}
