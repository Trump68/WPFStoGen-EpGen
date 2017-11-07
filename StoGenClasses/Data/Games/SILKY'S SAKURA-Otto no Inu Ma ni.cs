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
        public SILKYS_SAKURA_OttoNoInuMaNi() : base()
        {
            Name = "SILKYS_SAKURA_OttoNoInuMaNi";
            EngineHiVer = 1;
            EngineLoVer = 0;
           
            //Shift = 1000,
            //FontSize = 26,
            //Size = 760,
            //Bottom = 0,
            //Width = 366,
        }



        List<string> data = new List<string>();
        int s = 1370;
        protected override void LoadData()
        {
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
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_BG09", "BG09.png", path);// { hight hotel}


            this.DefaultSceneText.Size = 100;
            this.DefaultSceneText.Width = 1150;
            this.DefaultSceneText.FontSize = 18;
            this.DefaultSceneText.Size = 75;
            this.DefaultSceneText.Shift = 210;
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
           
            List<DifData> cdata = null;
            string text = null;

            AddCadre(1001, "Kohei~Я доверяю тебе. Конечно, если тебе понадобится моя помощь, сразу скажи.");
            AddCadre(1001, "Yayoi~Да, в этот раз, пожалуйста ... ... Кохей-сан.");
            AddCadre(0991, "В ситуациях, когда я не могу стать силой, это, безусловно, будет поворот Кохей-сан.");
            AddCadre(0991, "Но я не полагаюсь на это с самого начала, я хочу делать то, что могу сделать для себя.");
            AddCadre(0991, "Я верил и признался, для Асахи.");
            AddCadre(0991, "Yayoi~Спасибо, Кохей-сан. Было хорошо поговорить.");
            AddCadre(0992, "Kohei~Благодарю за меня. Заботиться о моей сестре об этом ... ....");
            AddCadre(0992, "Yayoi~Потому что Асахи тоже важная сестра? Это естественно.");
            AddCadre(0991, "Kohei~Ха-ха, я буду рад, если ты так скажешь.");
            AddCadre(0991, "Yayoi~Хих");
            AddCadre(0991, "Я чувствую себя спокойно, несмотря на возможность поговорить с г-ном Кохеем.");
            AddCadre(0991, "Может быть, я был слишком в восторге от того, чтобы стать силой Асахи, может быть, это было немного сложно.");
            AddCadre(0991, "Yayoi~Что ж, если что-то я снова свяжусь с вами?");
            AddCadre(0991, "Kohei~Точно. Конечно, я зря беспокоюсь.");
            AddCadre(1011, "Yayoi~Спасибо, мистер Кохей ... Я люблю тебя. ");
            AddCadre(1014, "Kohei~Я тоже ... ... Я люблю тебя, Яой. Хорошо, спокойной ночи.");
            AddCadre(1014, "Yayoi~Да, спокойной ночи ... Yayoi");
            AddCadre(1014, "Встряхните маленькую руку на экране, Кохей-сан отрезал видео-чат.");
            AddCadre(1046, "{Evening bedroom} Yayoi~Итак ... Хорошо, давайте сделаем все возможное ...!");
            AddCadre(1046, "{Evening bedroom}~Давайте попробуем все возможное, чтобы сделать все возможное, чтобы восстановить полную улыбку Асахи.");
            AddCadre(1046, "{Evening bedroom}~В видеочате с Кохей я так чувствовал.");
            AddCadre(0000, "{Morning street}~Через два дня контакт Асахи-чан вошел в место владельца автомобиля вместе.");

            AddCadreAoiAsahi(1046, 1020, "{Morning street}Yayoi~Успокойся, Асахи-чан? Хорошо, потому что я буду говорить с вами правильно.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Асахи~Ну, да... ....Спасибо, мистер Яойи ... ...");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У Асахи есть взгляд, который выглядит довольно серьезным, и ее цвет лица выглядит как кровь.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Когда я подумал, что это было непросто, мое сердце сжалось.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Yayoi~(В конце концов я волнуюсь ... ...)");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Мне определенно нужно как-то справляться.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Асахи не просто сестра Кохея, у меня для меня особое чувство.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители г-на Кохей и Асахи строги.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Родители не выступали против себя в то время, когда они вступили в брак со мной, которая была супер-частью в то время, но они не активно благословляли меня агрессивно.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Среди них Асахи-чан просто сделал меня счастливым и благословил нас.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Нет ничего несчастного, как брак, который не благословляется от другой семьи.");
            AddCadreAoiAsahi(1049, 1020, "{Morning street}~Как я чувствовал это, благословение от Асахи было действительно счастливым.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Yayoi~(Асахи-чан был там, это как я поженился)");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Поскольку Асахи благословил меня, я думаю, что смог выйти замуж.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~У меня все еще мало обмена с родителями, но мне интересно, будут ли дети сделаны в будущем, это обязательно изменится.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Yayoi~(Потому что моя мама с нетерпением ждет этого ... ...)");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Для родителей Кохея также, если мы можем иметь детей, мы становимся первыми внуками.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}~Это наверняка понравится, и я почувствовал, что изменил бы то, как я отношусь к различным вещам.");
            AddCadreAoiAsahi(1046, 1020, "{Morning street}Asahi~Это похоже на это здание.");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}Яйой~Здесь ...");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Адрес, который сказал Асахи, был зданием скалы в месте, подобном району красного света в городе.");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}Yayoi~Ну, тогда пойдем ли мы?");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}Асахи~Ну, да ...");
            AddCadreAoiAsahi(1046, 1019, "{Morning street}~Я вошел в здание, чтобы привести Ашиги в нервное состояние.");


            AddCadre(000, "{Morning cabinet}~В комнате, казалось, был офис, который обставил мебель, которая, казалось, была высокой, и имела какую-то сомнительную атмосферу.");
            AddCadre(000, "{Morning cabinet}~В этой комнате Асахи-чан сталкивается с владельцем автомобиля, который поцарапан.");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}Wisterie~Добро пожаловать, г-н Кимишима. Там ... ... ");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Поговорив с Асахи-чан, человек владельца увидел меня");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}Yayoi~Это невестка Йошио Кимишимы. Сегодня я сопровождаю ее ...");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}~Позволь мне скрыть испуганного Асахи спиной, я пойду вперед и поприветствую.");
            AddCadreAoiAsahiKimishima(1046, 1020, 0, "{Morning cabinet}Yayoi~?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Вижу, я был женат ... ... Это было давно, вы знаете?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~После небольшого удивления, увидев меня, я так внезапно говорю.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Интересно, встретил ли я где-нибудь.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Разве ты не помнишь?");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Yayoi~... ... Ах!");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Я вспомнил. Конечно, этот человек является одним из партнеров, которые мои родители заимствовали.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}Yayoi~... ... конечно, мистер Миното ...?");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}Wisterie~Да, это так. Ни в коем случае, что ты был тем, кем был женат, был ее старший брат.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}~Глядя на Чирари и Асахи, которые прятались позади меня, Мидода говорит так и улыбается.");
            AddCadreAoiAsahiKimishima(1048, 1020, 0, "{Morning cabinet}Yayoi~Ну, это было давно ... Извините, я не могу сразу вспомнить ...");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Ну, я не собираюсь встречаться с тобой напрямую.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Г-н Ито был одним из партнеров, который смог занять деньги у родителей, которые не смогли выполнить проект в деньгах.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Я приходил домой несколько раз, и я обменивался приветствиями.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}~Но не было памяти, о которой я говорил правильно, и я едва мог вспомнить свое имя, но это почти исчезло из моей памяти.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Мистер Кимисима, нет, теперь ты Кимишима-сан. Я думал, что придут ее родители.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Yayoi~То, что обстоятельства ее родителей неудобны, интересно, послушаю ли я историю.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Wisterie~Хм ... Ну, может быть. Потому что есть и история, давайте сядем и поговорим об этом.");
            AddCadreAoiAsahiKimishima(1049, 1020, 0, "{Morning cabinet}Yayoi~Да, извините ... ... Асахи-чан? ");
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
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Yayoi~Да. Хм, я думал, что минодо поцарапал его машину ... поэтому мы попросили о консультациях по поводу расходов на ремонт. ");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Рассказ идет быстро, если вы его слушаете.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Минодо кивает и достает что-то вроде документа.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Wisterie~Это оценка ремонта, полученная от производителя.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Yayoi~Благодарю вас. ");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}~Документы с иностранными языками отмечены автомобилями, которые я не знаю.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~... ... Это ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я не знаю, где это, и я даже не знаю единицы денег в первую очередь.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Говорят, что это составляет около 30 тысяч евро, общая стоимость транспортировки и стоимость ремонта.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~Является ли ... ... 30 тысяч евро? ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если я попрошу эту сумму, я не прихожу с булавками.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Сколько будет стоить японская иена евро?");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Я наклонил шею рядом со мной, хорошо ли понял Асахи.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Сегодняшний курс ...... Это около 3750 000 иен, переведенных в японскую иену.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Рассматривая смартфон, г-н Сада сказал, что Сара такая.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Yayoi~Скажи, сноб.? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Что, Junjun!?");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Только с ограниченным цветом я не могу перекрасить только часть. Я должен перевезти его на родину и раскрасить.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Yayoi~Ну, но ... это так много ...?! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Вау, я, немного, просто царапина ...! ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Wisterie~Сама царапина была маленькой. Но сверх того, что я думал, было глубоко включено. Поверхностный ремонт не вернется к оригиналу.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Яйой~Это ... ... такое ... ... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~Как вы поживаете, Yayoi san ...... ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асахи полностью потерял кровь и имел бледно-синее лицо.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Поскольку это оценка ремонта от официального производителя, вы можете принять ее. Потому что вы можете это взять.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~Это так, или это ... ... Но эта сумма денег ... Это действительно необходимо ...? ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Учитывая цену кузова, она дешевая. Этот автомобиль, цена покупки более чем в десять раз больше.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Asahi~Ну, это дорого! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}Yayoi~Ю, в десять раз ... ... Я куплю тебе дом ...! ? ");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Я удивляюсь, когда собираются два человека.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Мне сказали, что это дорогая иномарка, но это был не такой роскошный автомобиль.");
            AddCadreAoiAsahiKimishim2(1048, 1018, 0, "{Morning cabinet}~Ноги Асахи, сидящие рядом со мной, дрожали от щетинок.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Не расстраивайся до меня до конца.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Это то, что я подумал, но, просто глядя на сумму денег, моя внутренняя часть головы стала белой.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~Должен ли я говорить о конкретной компенсации, если в ней нет проблемы?");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Yayoi~Ах, что ... ... сумма - это сумма, так зачем платить сразу ... ");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Г-н Кохей и г-н Кохей хранят столько, сколько они есть, но это не очень хорошо, но я не могу заплатить.");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}~Вероятно, я посоветуюсь с моими родителями, но я до сих пор не знаю, смогу ли я заплатить сразу.");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Хм ... ...");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Yayoi~Не решите ли вы заплатить, разделив ...? ");
            AddCadreAoiAsahiKimishim2(1051, 1019, 0, "{Morning cabinet}Wisterie~Если вы не заплатите расходы на ремонт, автомобиль не вернется ко мне, но должен ли я выполнять процедуру разделения самостоятельно?");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Яйой~Гм ... ... что, что ... ... ");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}~Разумеется, как говорит г-н Минато, место для оплаты стоимости ремонта - это автомагазин, поэтому мы должны попросить вас там.");
            AddCadreAoiAsahiKimishim2(1050, 1019, 0, "{Morning cabinet}Wisterie~Ну, затраты на ремонт могут быть погашены мной.");
            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}Yayoi~Это правда? ? ");
            AddCadreAoiAsahiKimishim2(1048, 1019, 0, "{Morning cabinet}Wisterie~У меня будут проблемы, если машина не вернется.");
            AddCadreAoiAsahiKimishim2(1046, 1019, 0, "{Morning cabinet}Yayoi~Это так? ... Мне жаль беспокоить вас, но я буду спасен, если вы это сделаете. ");
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
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~(Но на этот раз Kohei все еще работает ... ...) ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Wisterie~У меня не было много времени. Если это нормально держать в вертикальном положении, я бы хотел, чтобы вы ответили так.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Если вам интересно, что делать, г-н Миното также должен будет ответить.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Asahi~И Yayoi ... ...! ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Асака крепко держит мою руку.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Потная рука дрожала, и я почувствовал разочарование в глазах, глядя на меня.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~(Ну, во всяком случае, вы должны заплатить ... ne.) ");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}~Даже если родители Асахи были необоснованны, я должен был что-то сделать.");
            AddCadreAoiAsahiKimishim2(1049, 1019, 0, "{Morning cabinet}Yayoi~Ничего себе .... ОК. Я верну его, разделив, поэтому, пожалуйста, измените его. ");
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
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Yayoi~Я понимаю ... ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Меня радует нетерпеливый голос Асахи, я подписываю заимствованное письмо.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~...... Официальный документ находится на более позднем этапе, поэтому сегодня я его принимаю.");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Yayoi~Да ... ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Wisterie~Я хотел бы снова связаться с вами, но было ли лучше для вас, Яой?");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}Yayoi~Ну, это так, пожалуйста, сделайте это со мной. ");
            AddCadreAoiAsahiKimishima(1046, 1019, 0, "{Morning cabinet}~Мы обменялись контактами с г-ном Маото, и обсуждение расходов на ремонт завершено.");

            AddCadre(1016, "{Day street}Асахи~Yayoi, Большое вам спасибо ... Если бы я был один, я не мог бы говорить правильно ... ",-270);
            AddCadreAoiAsahi(1049, 1016, "{Day street}Yayoi~Хорошо, это примерно ...... ");
            AddCadreAoiAsahi(1049, 1016, "{Day street}~Асахи - чан, казалось, с облегчением почувствовала, решила ли она, что проблема решена.");
            AddCadreAoiAsahi(1049, 1016, "{Day street}~Но я знаю, это тяжелая работа с этого момента.");

            AddCadre(0000, "{Blue sky}~Через несколько дней после подписания взятой записки -");
            AddCadre(0000, "{Blue sky}~Когда мне сказали, что я хотел бы поговорить о погашении, я пошел в кабинет минодо.");

            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~О ... о ... да ... Извините. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Ну, это мгновение ... ... вкус не должен быть плохим.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот почему сам мистер Ми Ито сам кофе.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Не было абсолютно никакого места, чтобы осмотреться, но в этом офисе есть только стол мистера Миното.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Гм ... ... Ты работаешь одна? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~── О, я был один.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Это так правильно? ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~У меня есть вещи в доме моих родителей и даю мне деньги, но какая работа вы здесь делаете?");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Место, где это место, также является местом, которое находится на одном шагу от входа в центр города, а не в офисный город.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это было многолюдное здание с несколько подозрительной атмосферой, и была атмосфера, в которой я ничего не мог сказать.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я хотел бы подтвердить это как можно скорее. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Да ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Г-н Минато так сказал и достал документ.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Письмо было напечатано и написано как соглашение о заимствовании.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Хм, это ...? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~На днях я заимствовал написанное вами письмо, сделав его официальным документом.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Это официальный документ ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Вот что я сказал, я снова посмотрю на это.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Что-то трудное написано, и я даже не знаю, с чего смотреть.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Хорошо, давайте проверим их. Если есть моменты, о которых стоит беспокоиться, вы можете поговорить позже позже.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Да ... ... Пожалуйста ... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато также сел на диван и объяснил о соглашении о заимствовании.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Контент состоял в том, что я заплачу все деньги, которые он взял за ремонт автомобиля, заимствованный у мистера Мито.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Это означает, что мы заимствуем у мистера Мито, используя его для расходов на ремонт ... не так ли? ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~О, вот и все. И ты вернешь его мне. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Да ... ... Но эта сумма ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Сумма, написанная там, была больше, чем предыдущая история.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Кроме того, доля, называемая процентными ставками, увеличивается, а в части, записанной как ежемесячная сумма погашения, была написана сумма, которую я не представлял.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Из-за обесценения йены на нее влияет обменный курс. Кроме того, это только оценка до последней.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Ну, это правильно .... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я не совсем понимаю, интересно, это что-то в этом роде.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Конечно, по телевизионным новостям, я чувствую, что обесценивание йены продолжается, и импортируемые продукты растут, я говорил о такой истории.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Стоимость ремонта автомобиля может быть такой же.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Но проблема была не в сумме, а в ежемесячной сумме погашения.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Yayoi~Ах, это ... ... Это ежемесячная сумма погашения, но ее трудно заплатить ... ... Можете ли вы продлить срок погашения еще немного ...? ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~В текущем документе период погашения составляет один год.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Ежемесячная сумма погашения была больше, чем бюджет нашей семьи.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Но у меня не было больше времени на погашение.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~Это ... ... Такое ... ... Но эта сумма невозможна ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~У вас нет проблем, даже если вы так говорите. Вы сказали, что заплатите, разделив вас, и вы ничего не сказали о периоде погашения?");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Yayoi~Это ...! Да, но ... ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Тонус г-на Минато спокоен, и голос ее холодный.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Я помню атмосферу, когда я был где-то в доме родителей.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(В те дни, когда я разговаривал с отцами, это было так ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Это было потрясающе, и это не стало эмоциональным, но было такое впечатление, что остров не существует.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Яйой~(Интересно, что я должен делать ...... Такая сумма, не очень ... но ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Разумеется, вам, возможно, придется подумать о том, как погасить его, консультируясь с Kohei-san и вашими родителями.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Асахи может не нравиться, но я не мог сделать ничего, что мог.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Ну, пока это консультации по конкретному методу погашения, я не соглашусь, конечно. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Эх ...... ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Есть много способов оплаты. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минато сказал так и улыбнулся.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Это должна быть улыбка, но это выглядело как очень ослепительное выражение.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Yayoi~(Что вы делаете ... ...) ");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Интересно, следует ли мне поговорить с г-ном Минато о методе погашения, как есть.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Однако, похоже, это не простой метод погашения.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Когда я услышал эту историю, я почувствовал, что больше не могу вернуться.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Wisterie~Вы решаете, что делать, вы решаете.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Yayoi~Это ... ... "); 
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Минато говорит так, но я не думаю, что у меня есть варианты.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Конечно, может быть, я действительно понял, что говорю, но я не могу избавиться от беспокойства.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}Yayoi~(...... Kohei Mi)");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Лицо Коэи перешло мне в голову, когда меня мысленно преследовали.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Если Кохей-сан, он может как-то справиться.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Даже г-н Минато может обсудить это должным образом.");
            AddCadreAoiMinodo(1050, "{Morning cabinet}~Хотя я не хочу неудобств, если я не проконсультируюсь здесь, это может вызвать еще большие неудобства.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Yayoi~Ах ... ... это ... Пожалуйста, позвольте мне поговорить с моей семьей однажды ... ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Мне удалось выжать мой голос и рассказать Миото.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~...... Где будут меняться условия консультаций?");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Yayoi~Да, но ... время от времени ... Я просто хочу поговорить ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Чтобы не пить власть минодо, отчаянно старайтесь отважиться.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Если вы можете доверять г-ну Кохеи, вы наверняка сумеете что-то сделать.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Я могу сделать это, чтобы не спешить с заключением здесь, но как-нибудь вернуться домой.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Wisterie~Это так? В этом случае давайте подождем ответ до конца этой недели.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}Яйой~Ох ... О, спасибо ... ");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Наконец г-н Минато принял мою просьбу.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~Отчаянно стимулируйте освобождение и держите его в секрете, не ставя его на лицо.");
            AddCadreAoiMinodo(1051, "{Morning cabinet}~С этим мне удалось заработать время, чтобы поговорить с Kohei-san каким-то образом.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Yayoi~Хорошо, тогда я извиню себя. ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Я был в отчаянии говорить спокойно, так что я не мог понять, когда я торопился.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Wisterie~Я ожидаю ответа как можно скорее.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~Минодо не выражает ничего выражения, и я не совсем уверен, что вы думаете.");
            AddCadreAoiMinodo(1049, "{Morning cabinet}Яйой~(Во всяком случае, давайте поговорим с Кохей ... ...) ");
            AddCadreAoiMinodo(1049, "{Morning cabinet}~С этой мыслью я быстро пришел домой.");

            AddCadre(0000, "{Evening bedroom}~Ночью той ночью я был готов ругать Кохея, и я все признал.");
            AddCadre(0998, "KoheiЭто должно было случиться. ");
            AddCadre(0998, "Yayoi~Мне очень жаль, я что-то ранил ... Я не хотел беспокоить вас дополнительными неудобствами, но так получилось ... ");
            AddCadre(0998, "Мне было очень жаль, что он не беспокоил мистера Кохея, который занят работой.");
            AddCadre(0997, "Kohei~Потому что ты собираешься думать об Асахи, не так ли? Все в порядке, я знаю. ");
            AddCadre(1002, "Яйой~Кохей-сан ...! Э-э ... Э-э ... Го ... ... ");
            AddCadre(1002, "Это был предел, который я мог переносить своими слезами.");
            AddCadre(1001, "Kohei~Тебе не нужно плакать, я не думаю об этом. ");
            AddCadre(0996, "Yayoi~Но, я ... .... ");
            AddCadre(0997, "Kohei~Вместо этого, я хочу проверить, что это похоже на этот контракт, поэтому я хочу, чтобы вы отправили его на персональный компьютер и отправили его ... .... ");
            AddCadre(0997, "Yayoi~Ну, ты можешь это сделать ... ....? ");
            AddCadre(0997, "Я чувствовал, что мне кое-что было сказано несколько сложнее.");
            AddCadre(0997, "Kohei~Это не так сложно, так что все в порядке. Рядом с компьютером есть принтер, верно? ");
            AddCadre(0997, "Yayoi~Принтер об этом ... ...? ");
            AddCadre(0997, "Kohei~Правильно. Когда откроется это место, мне интересно, разместите ли вы там документ. ");
            AddCadre(1002, "Yayoi~Er ... ... документ ...... ");
            AddCadre(1002, "Будучи объясненным Кохей, я сделаю то, что сказал.");
            AddCadre(1002, "Г-н Кохей научил меня осторожно, не используя как можно больше технических терминов.");
            AddCadre(0000, "{Black screen}~....");
            AddCadre(0000, "{Black screen}~.... ....");
            AddCadre(0000, "{Black screen}~.... .... ....");
            AddCadre(0991, "Yayoi~Итак, нажмите здесь, в конце ... ... Ах, это сработало! ");
            AddCadre(0991, "Kohei~Да, это звучит неплохо. Он автоматически переключился на мой смартфон, так что все в порядке. ");
            AddCadre(0991, "Yayoi~Это так? Это было хорошо ...");
            AddCadre(0993, "Kohei~Действительно, соглашение о заимствовании ... ... Хм ... ...");
            AddCadre(0993, "Г-н Кохей смотрит на документы, которые я взял, и имеет сложное выражение.");
            AddCadre(0998, "Yayoi~(Kohei-san ......)");
            AddCadre(0998, "Я молчал и уставился на экран моего компьютера, чтобы это не мешало этой идее.");
            AddCadre(0998, "Kohei~Контактный номер другой стороны - это номер, написанный здесь, не так ли? ");
            AddCadre(0998, "Яйой~Эх, да .... ");
            AddCadre(0997, "Kohei~Я понимаю. Хорошо, тогда я попытаюсь как-нибудь попытаться. ");
            AddCadre(1002, "Yayoi~ぅ ...... Извините, я занят ... ");
            AddCadre(1002, "Kohei~Первоначально это проблема, поднятая Асахи, вам не нужно столько страдать.");
            AddCadre(1002, "Yayoi~Кохей-сан ...... ");
            AddCadre(1001, "Kohei~Я свяжусь с вами снова, если что-то будет. В любом случае, мне больше не нужно волноваться, поэтому не смотрите на меня так, я хочу, чтобы вы улыбались, как обычно. ");
            AddCadre(1006, "Yayoi~... .... Да, спасибо ... ... ты. ");
            AddCadre(1006, "Слезы, казалось, переполнились добрыми словами Кохея.");
            AddCadre(1006, "Но если ты заплачешь, Кохей-сан будет грустно.");
            AddCadre(1006, "С чувством сожаления и благодарности, на мой взгляд, я улыбнулся.");
            AddCadre(1009, "Kohei~Да, улыбка - лучшая для Яйоя. Ну тогда, спокойной ночи ... Я люблю тебя. ");
            AddCadre(1014, "Yayoi~Я тоже тебя люблю, ты ... ... Не подталкивай себя? ");
            AddCadre(1011, "Хорошо, даже если вы выглядите так, ваше тело сильное.");
            AddCadre(1011, "Несмотря на то, что я занят только работой, я действительно занят, полагаясь на неприятные вещи.");
            AddCadre(1011, "Тем не менее, Кохей-сан улыбался с другой стороны экрана ПК, сказав это.");
            AddCadre(1011, "Яйой~(На самом деле спасибо, Кохей-сан ... ...) ");

            AddCadre(0000, "{Evening livingroom}~После нескольких дней Кохей-сан получил телефонный звонок.");
            AddCadre(1049, "{Evening livingroom}Yayoi~Алло ......?");
            AddCadreAoiKohei(1049,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1","{Evening livingroom}Kohei~Я подумал, что было бы лучше спешить, поэтому я позвонил ей. Теперь все в порядке?");
            AddCadre(1049, "{Evening livingroom}Yayoi~Эх, да .... ");
            AddCadre(1049, "{Evening livingroom}~Потому что я знаю, что это мистер Минодо, я нервничаю, когда звоню с Кохеем.");
            AddCadre(1049, "{Evening livingroom}~Рука с телефоном слегка дрожала.");
            AddCadreAoiKohei(1049,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Скажу до заключения? Что касается расходов на ремонт, я думаю, что я уменьшу сумму.");
            AddCadre(1048, "{Evening livingroom}Yayoi~Эх ...! ? Это так ...? ");
            AddCadreAoiKohei(1048,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~В документах были различные недостатки, я указал, что мы тоже пришли с другой стороны.");
            AddCadre(1048, "{Evening livingroom}Yayoi~Я вижу ... ничего себе ... ... ");
            AddCadre(1048, "{Evening livingroom}Yayoi~В моем сознании не было ничего, чтобы выяснить легитимность суммы.");           
            AddCadre(1048, "{Evening livingroom}Yayoi~I think that Mr. Kohei is great, after all, to think of such a thing.");
            AddCadreAoiKohei(1048,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Although it can not be said that repair expenses are escaped as expected, I think that it can be suppressed to some extent");
	        AddCadre(1048, "{Evening livingroom}Yayoi~Thank you, Kohei-san ... I can not believe it. I am sorry, let me take time and effort on this ... ... ");
            AddCadreAoiKohei(1046,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~No, I am the one who apologizes. I'm really sorry I can not stay by my side");
            AddCadre(1046, "{Evening livingroom}Yayoi~When I apologize at the phone entrance, on the contrary Kohei apologizes to Mr. Kohei.");
            AddCadre(1050, "{Evening livingroom}Yayoi~It was a feeling that my heart was tightened to that voice that seemed to be sorry.");   
            AddCadre(1050, "{Evening livingroom}Yayoi~No, that's not the case ....");
	        AddCadreAoiKohei(1050,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~But I guess I was worrying a lot? I was able to do something if I was by my side ... ... ");
            AddCadre(1050, "{Evening livingroom}Yayoi~You ... ...");	    
            AddCadre(1050, "{Evening livingroom}Yayoi~Tears seemed to be overflowing with the thought of Kohei's me.");
	        AddCadre(1050, "{Evening livingroom}Yayoi~(I can not bother you any more any more ... ...)");
            AddCadre(1050, "{Evening livingroom}Yayoi~Even though I am busy with work, I do not want to put an extra burden.");
            AddCadreAoiKohei(1050,"SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~The problem is the remaining amount and how to repay it ..");
            AddCadre(1050, "{Evening livingroom}Yayoi~... ... Do not worry, you. If I can keep even the amount, I will have it.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "{Evening livingroom}Kohei~Is that so?");
            AddCadre(1050, "{Evening livingroom}Yayoi~Yes. Mr. Minoto also does not know anything at all, so I will say that the concrete repayment method will ride in consultation.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~I see ... okay, but are you all right?");
            AddCadre(1050, "{Evening livingroom}Yayoi~Kohei - san 's voice on the phone's door seemed really worried.");
            AddCadre(1050, "{Evening livingroom}Yayoi~Even just listening to such a voice, I feel sorry and my chest tightened.");
            AddCadre(1050, "{Evening livingroom}Yayoi~Uhufu, all right. But thank you very much. Thanks to Kohei - san, it is likely to manage somehow. ");
            AddCadre(1050, "{Evening livingroom}Yayoi~It was good not to be a video chat.");
            AddCadre(1050, "{Evening livingroom}Yayoi~I can do it with words, but I did not have confidence to pretend to expressions.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~...... If Yayoi says so, I will believe it.");
            AddCadre(1050, "{Evening livingroom}Yayoi~Thank you, you ... ....");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~...... But if it seems to be a difficult thing, do not hesitate to ask me for consultation. I am going to do not want labor if it is for you. ");
            AddCadre(1050, "{Evening livingroom}Yayoi~... Yeah, I know.");
            AddCadre(1050, "{Evening livingroom}~Kohei-san said that, I decided to do something about it myself.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Well then, please contact me if there is something again.");
            AddCadre(1050, "{Evening livingroom}Yayoi~Yes, I know. Um ... ... Thank you for your concern, you. ");
            AddCadre(1050, "{Evening livingroom}~To the voice worried voice of the phone mouth, with the meaning of making the peace of mind, put it in words and convey it.");
            AddCadre(1050, "{Evening livingroom}Yayoi~I really appreciate Mr. Kohei.");
            AddCadre(1050, "{Evening livingroom}Yayoi~I always feel annoying and burdening always, I think I'm really sorry, I wonder if I can return it properly.");
            AddCadreAoiKohei(1050, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~We are couple, so do not say anything strangely like that. ");
            AddCadre(1050, "{Evening livingroom}~Finally it got a little light tone, Kohei-san said so.");
            AddCadre(1046, "{Evening livingroom}Yayoi~Hehe ... ... That's right, it is a couple.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~that's right. I think that it is a couple who will help each other.");
            AddCadre(1046, "{Evening livingroom}Yayoi~I think so too .... ");
            AddCadre(1046, "{Evening livingroom}~That is why I also want to become Kohei's power properly.");
            AddCadre(1046, "{Evening livingroom}~In order to support Kohei - san who is tough work, I also have to work hard so that I do not increase the extra burden.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "{Evening livingroom}Kohei~Well then, I have preparation for tomorrow, so I will cut it soon.");
            AddCadre(1046, "{Evening livingroom}Yayoi~Yeah ... Good night, Kohei-san.");
            AddCadreAoiKohei(1046, "SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "{Evening livingroom}Kohei~Good night, Yayoi.");
            AddCadre(1046, "{Evening livingroom}~Kohei's voice, saying good night, is really relieved.");
            AddCadre(1046, "{Evening livingroom}~I'd like to listen forever, but surely I will be busy working tomorrow, so it is not good to tell me.");
            AddCadre(1046, "{Evening livingroom}~I trimmed my disappointing feeling behind my heart and I softly pushed the call button.");
            AddCadre(1046, "{Evening livingroom}Yayoi~Fuh ... ... Thank you so much, Kohei-san ......");
            AddCadre(1046, "{Evening livingroom}~After that I have to do something with my own power.");
            AddCadre(1046, "{Evening livingroom}Yayoi~I clutched the broken phone and I thought so strongly.");

            // ANTRACT=============================================================
            S1 = 1500; X1 = -70;
            // music.arc_000007.wav
            //voice?
            AddCadreBG(1049, null, "{Morning street}Yayoi~(I have to work hard to negotiate ... ...) ");
            AddCadreBG(1049, null, "{Morning street}~I have thought of various things, but after all we have to pay by dividing.");
            AddCadreBG(1049, null, "{Morning street}~Because of Kohei - san, it seems that the amount can be lowered, but it is still not an amount that can be paid in bulk.");
            AddCadreBG(1049, null, "{Morning street}~The problem is the repayment period of the money borrowed from Mr. Mito.");
            AddCadreBG(1049, null, "{Morning street}~I can not pay for it unless I keep it as long as possible.");
            AddCadreBG(1049, null, "{Morning street}~Of course I did not mean to pay Kohei-san's salary, I planned to go to the part again.");
            //voice?
            AddCadreBG(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "Yayoi~(The store manager says it is not enough manpower ... ...)");
            AddCadreBG(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG01", "The amount of repayment about the amount that can be earned for the part at the supermarket was my ideal.");
            AddCadreBG(0, null, "...");
            AddCadreBG(0, null, "... ...");
            AddCadreBG(0, null, "... ... ...");
            //music.arc_000005.wav
            AddCadreBG(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When I visited Mr. Minodo's office, I was kept waiting a while because I was working.");
            AddCadreBG(0, "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even while sitting on the sofa and waiting, the tension is rising.");
            S1 = 1500; X1 = 300;
            S2 = 0715; X2 = 155; Y2 = 55;
            //effect.arc_000020.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I am sorry, I have kept you waiting.");
            //voice? voice.arc_000550.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Good, but... ...");
            //voice? voice.arc_000551.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you talk with sincerity, you should know Mr. Minodo.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I thought so, but the idea was a bit sweeter.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I received a message from my husband. You seemed to know a lot?");
            //voice? voice.arc_000552.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Oh ... oh, yes ... ... that job, finance related work ...");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Indeed, that's what it is.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Although I do not show much on facial expressions, Mr. Muto's voice seemed a little sullen.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps what asked to Mr. Kohei might have been damaged by tantrums.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~So, can we talk a specific story today?");
            //voice?  voice.arc_000553.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Yes ... .... Um, I can not pay in bulk, so I thought that I would like to split ... so we pay monthly payment ...... ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If the previous borrowing agreement is invalid, there is no reason to accept it.");
            //voice? voice.arc_000554.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Well ... but, but ... ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The money may be the one the husband has said, but instead you will be paid in bulk.");
            //voice? voice.arc_000555.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Well ... that! I can not do it ...!");
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, if you say that you can not pay, you just have to pay her again.");
            //voice? voice.arc_000556.ogg
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~She's ... Asahi-chan! What? Such a terrible ... ...! ");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~What is terrible? Do you think that the victim is me?");
            //voice? voice.arc_000557.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Well, that was ... .... Well, it was ... .... Excuse me ......");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even though the tone was calm, there was a tremendous force in the voice.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as Mr. Minato is surely the one who has been hurt by the car, it is incorrect to say that it is awful.");
            //voice? voice.arc_000558.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~But Asahi-chan .... It's impossible for her, please somehow split it ... ....?");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I wonder if she has parents, too? If that is difficult, you may consult your husband again.");
            //voice? voice.arc_000559.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Well, that's in trouble ....");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wonder what I should do.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is not the amount that I can pay for Asahi and I'm sorry to consult Kohei.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you go to the home of the Kimishima family to consult, Asahi will also be sad, and as a result it places a burden on Kohei.");
            //voice? voice.arc_000560.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(I want to manage it by myself, but ... ...)");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I would like to make it monthly repayment at some amount to earn part-time.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "How can I accept Mr. Muto from it?");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While I felt my back getting wet with cold sweat, I was desperately thinking.");
            //voice?  voice.arc_000561.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~I will do anything I can ... ... I will pay all the repair expenses as well, so why can not you do something ...?");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But I can not think of anything in my head.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As Kohei-san, there was nothing to solve the problem.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~That's right.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Then, Mr. Minoto starts looking at something with a difficult expression.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps, will he step up.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "So expecting while waiting, I will look like Mr. Minoto's sharp eyes shoot through me.");
            //voice?  voice.arc_000562.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~ぅ ...");
            //music.arc_000004.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~If you ... ... If Yayoi will be mine for only a week, I do not mind drinking that condition.");
            //voice?  voice.arc_000563.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~! What?");
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Even if it is dull, I know what it means.");
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I do not think that I should say such a thing, I am surprised that I will not speak at once.");
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~what will you do?");
            //voice?   voice.arc_000564.ogg
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Mum ... It is impossible! I can not do that ...! Wow, my husband is ... ...!");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "When refusing to return to me, unexpectedly Mr. Minoto nods with conviction.");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Well, it will be.");
            //voice?  voice.arc_000565.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Well then, then ...... ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Then, I will just give out the condition for her. ");
            //voice?  voice.arc_000566.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Become What? Oh, Asahi is still a student! What?");
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Is not it a wonderful adult anymore? At least, the body. ");
            //voice?  voice.arc_000567.ogg
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Huh! ! ");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "No way, Mr. Minoto was a person to say such a thing.");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I also thought that they were a bad joke, but they seem to be seriously saying.");
            //voice?  voice.arc_000568.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(What do you do ... ... such ... ...)");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "At least, I can not let such a condition by Asahi.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I think that I must manage to do something, but I was unlikely to get an answer soon.");
            //voice?  voice.arc_0005669.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~прошу вас....позвольте мне все обдумать....");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~I do not mind it, but I am busy too. Oh yeah ... the time to divide for you is another 10 minutes.");
            //voice?  voice.arc_000570.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~... that, such a ... ...");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I can not do such a conclusion in ten minutes.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "As I said before, I thought after going home once, but Mr. Motoi did not seem to forgive it.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Perhaps last time I brought the documents home and consulted with Kohei might also be affecting.");
            //voice? voice.arc_000571.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(Maybe you do not want to talk to Mr. Kohei ... ...) ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If you would like to talk to Kohei-san, I have to call this place now.");
            //voice? voice.arc_000572.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(But, this time Kohei-san is also working ... ...)");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I wish it was at least a lunch break or overtime time.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "It is painful to call Kohei-san who is working while troubling you.");
            //voice? voice.arc_000573.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(ооо ...... что же мне делать ... ....!?)");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Only time will pass as I can not answer anything.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Every time Mr. Minato saw the wrist watch, I felt that he was going to be hunted down.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~... ... It's only five minutes.");
            //voice? voice.arc_000574.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~хлюп! !");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "We have to decide whether to accept Mr. Minodo's request or not.");
            //voice? voice.arc_000575.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~это будет .... только неделю ... это так ...?");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Oh, no doubt. I do not mind letting you keep it in writing properly if you wish. ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If Mr. Minodo says so, I think that it is only one week indeed.");
            //voice? voice.arc_000576.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~...пожалуйста, если вас не затруднит ...");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Wait a while.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Mr. Minodo said so, operated the personal computer, printed out the document and brought it.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~This is the document. Because it is not a contract, it is like a letter. ");
            //voice? voice.arc_000577.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~...хо..хорошо ...");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There, it says that I will leave to myself about payment of repair costs instead of becoming Freedom of Mr. Minato for only a week.");
            //voice? voice.arc_000578.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~... ... а как отменить это соглашение? ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~You only have to pay for your good. ");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "While saying that, Mr. Minato sat down next to me.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I got my body beyond necessity and put my hands around my thighs.");
            //voice? voice.arc_000579.ogg
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~...");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~No matter how many times you pay, it does not matter about the amount of each time.");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "I was concerned about Mr. Minodo's hand, but desperately I listened to that word and followed the letters of the document.");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "There may be something inconvenient to me.");
            AddCadreBG(1051, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "But, as far as I see, the papers have written only what is convenient for me.");
            //voice? voice.arc_000580.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(Well, this is really okay .... If this is the case, I can do anything without inconveniencing anyone ....)");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Of course, the price is great.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~It is you who decide, Yayoi. If you accept this, please sign it.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "If I drink this condition, everything can be solved well.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Asahi is not worrying about it, nor does it rely on your parents.");
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "And above all, I did not put unnecessary inconvenience to Kohei-san.");
            //voice? voice.arc_000581.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~ .... окей, я согласна ...");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "You only have to endure it for a week and endure it.");
            //voice? voice.arc_000582.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~(Прости меня Кохей... ...)");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Apologizing to Mr. Kohei in my mind, I signed the document.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~...... Then, it is established with this. ");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Make sure the document I signed, Mister Mutsu muttered.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~The period is a week from tomorrow. I will contact you as soon as time comes, so you can come here.");
            //voice? voice.arc_000583.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~Yes, ...");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Although it is over talk, is there something?");
            //voice? voice.arc_000584.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Yayoi~нет ... ... мне наверно уже пора ......");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "Wistaria~Ah.");
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG02", "After finishing talking with Mr. Minato, I left the office.");
            // ANTRACT =====================

            // ANTRACT=============================================================
            // music.arc_000001.wav
            S1 = 1100; X1 = 135; Y1 = 55;            
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The sun had already begun to slip out of us how long it took us so long.");
            //effect.arc_000014.wav
            //voice.arc_000585.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "……");
            //effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I am walking with a hula while thinking about the signed documents.");
            //effect.arc_000014.wav
            //voice.arc_000586.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~(С завтрашнего дня, я ... .... принадлежу мистеру Минато ... ...)");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The feelings I regret as soon as they come in, it becomes painful just by thinking.");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I wonder if I did something terribly inevitable.");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "I guess that is probably the case.");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But in that situation there was no other answer and I could not afford to consult anyone.");
            // effect.arc_000014.wav
            //voice.arc_000587.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~(But what shall I do ... ... I promised that kind of ... ...) ");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Perhaps it was better for you to trust Mr. Kohei obediently, without thinking about doing anything by yourself.");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even though I thought so, I felt like it is now.");
            // effect.arc_000014.wav
            //voice.arc_000588.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~(I do not want to put a burden on Kohei-san any more any more ... ...) ");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Though thinking about the future with me, I am doing my best while working hard.");
            // effect.arc_000014.wav
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "However, I may be betraying that kind of Kohei as a result.");
            // effect.arc_000014.wav
            //voice.arc_000589.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~.... хлюп.... Я......");
            // effect.arc_000014.wav
            //voice.arc_000590.ogg
            AddCadreBG(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~Ой...");
            // effect.arc_000014.wav
            AddCadreBG(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Maybe because I was disappointed, my feet were hula and I was sticking out to the roadway.");
            // effect.arc_000014.wav
            //voice.arc_000591.ogg
            AddCadreBG(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~(Hit run ...... !?)");
            // effect.arc_000014.wav
            AddCadreBG(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Even if I look at the car coming close to me, my body does not move at all.");
            // effect.arc_000014.wav
            AddCadreBG(1048, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The moment I thought it was no good, suddenly someone was pulling my arm.");
            S2 = 655; X2 = 125; Y2 = 115;  
            // effect.arc_000014.wav
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Oops! It is dangerous!");
            // effect.arc_000014.wav
            //voice.arc_000592.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~Ах ...!");
            //// effect.arc_000014.wav
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Driver~Watch out! Do you want to be run over! driver");
            //// effect.arc_000014.wav
            //voice.arc_000593.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~I'm sorry ...");
            // effect.arc_000014.wav
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The car stopped at the limit, but if I stayed in the carriage as it was, it may have been ruined in safety.");
            X1 = 480;            
            // effect.arc_000014.wav
            //voice.arc_000594.ogg
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~Oh, thank you ...... ");
            // effect.arc_000014.wav
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Was it okay?");
            // effect.arc_000014.wav
            AddCadreBG(1050, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "So I was told that I was the manager who helped me.");
            // effect.arc_000014.wav
            //voice.arc_000595.ogg
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~Oh, the store manager san ...... ");
            // effect.arc_000014.wav
            AddCadreBG(1048, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~I was worried because I was walking with the hula. Well, it was good to make it in time. ");
            // effect.arc_000014.wav
            //voice.arc_000596.ogg
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~I'm sorry, I am worried ... ... ");
            // effect.arc_000014.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If the manager did not notice me, what was going on?");
            // effect.arc_000014.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Is he feeling ill? Or was there something? ");
            // effect.arc_000014.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "The manager is worried about me and he puts such words.");
            // effect.arc_000014.wav
            AddCadreBG(1049, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "But it is not like I can talk very much.");
            // effect.arc_000014.wav
            //voice.arc_000597.ogg
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~I was a little bait ... ... It's okay. I'm really thankful to you. ");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Make a smile somehow, cheat the manager.");
            //effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Did you believe it, the manager did not ask you anything more than that?");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~That's fine ...... Husband's on a business trip? If something happens, do not hesitate to tell me. ");
            // effect.arc_000014.wav
            //voice.arc_000598.ogg 
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~I will do ... Yes, thank you. ");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "If I can tell you the problem I am having, what kind of face will the manager say?");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Suddenly such a thing passed the mind, but of course I could not say it.");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Nankai~Well then, I will return to the store.");
            // effect.arc_000014.wav
            //voice.arc_000599.ogg 
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~Oh, yes ... I will excuse you. ");
            // effect.arc_000014.wav
            AddCadreBG(1046, "SILKYS_SAKURA_OttoNoInuMaNi_BM02_2", "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Lower his head to the store manager who helped me and leave that place.");
            // effect.arc_000014.wav
            //voice.arc_000600.ogg 
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Yayoi~(If you do not stand firm ... ...) ");
            // effect.arc_000014.wav
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "My head was full of Mr. Mihara, but I will tell myself so.");
            // effect.arc_000014.wav
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Let's at least think after returning home.");
            // effect.arc_000014.wav
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG03", "Because it is supposed to be irreparable when it comes to accidents.");


            // ANTRACT=============================================================
            X1 = 135;
            // music.arc_000009.wav
            // evening livingroom
            //voice.arc_000601.ogg 
            AddCadreBG(1049, null, null, "Yayoi~Fuh ... ... this time already ...... ");
            AddCadreBG(1049, null, null, "By the time I came back home, the outside of the window was completely dark.");
            AddCadreBG(1049, null, null, "I should prepare dinner soon, but I could not feel like that.");
            AddCadreBG(1049, null, null, "To begin with, I have only one person, and I do not have an appetite now.");
            AddCadreBG(1049, null, null, "As I thought, my head was full of promises with Mr. Koto.");
            //voice.arc_000602.ogg 
            AddCadreBG(1050, null, null, "Yayoi~(Tomorrow I have to go to Mr. Mioto's place ...) ");
            AddCadreBG(1050, null, null, "I wonder what exactly is done.");
            AddCadreBG(1050, null, null, "I think that there is nothing to injure, but after all it may be necessary to prepare.");
            // voice.arc_000603.ogg
            AddCadreBG(1050, null, null, "Yayoi~(That's ... that's right, surely ... ....) ");
            AddCadreBG(1050, null, null, "Because Mr. Minato is a man and saying that I will make a woman free, I think that it is what I imagined.");
            // voice.arc_000604.ogg
            AddCadreBG(1050, null, null, "Yayoi~Ah  !");
            AddCadreBG(1050, null, null, "It may be too late if I regret it now.");
            AddCadreBG(1050, null, null, "I already signed the document and there is no other way to pay the repair cost.");
            AddCadreBG(1050, null, null, "I want to think that it was an unavoidable choice, but feelings depressed.");
            AddCadreBG(1050, null, null, "I could not suppress my feelings of regret as if I should have confided to Mr. Kohei.");
            // voice.arc_000605.ogg
            AddCadreBG(1050, null, null, "Yayoi~(I wonder what I should do ... ...) ");
            AddCadreBG(1050, null, null, "No matter how much I think, the answer is unlikely.");
            AddCadreBG(1050, null, null, "While I was doing it, it was time for video chatting with Kohei when I noticed it.");
            // voice.arc_000606.ogg
            AddCadreBG(1048, null, null, "Yayoi~I can not hurry ... ");
            AddCadreBG(1048, null, null, "If you have a depressed face, you surely understand to Kohei.");
            //effect.arc_000020.wav
            AddCadreBG(0, null, null, "While heading to the bedroom where the personal computer is placed, I try to smile frantically.");
            AddCadreBG(0, null, null, "But I was laughing properly, even if I looked in the mirror I could not understand myself well.");


            // evening bedroom
            // voice.arc_000607.ogg
            AddCadreBG(1049, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~It is almost time ... ");
            S1 = 1370;X1 = 0;Y1 = 0; 
            // voice.arc_000608.ogg
            //effect.arc_000039.wav
            AddCadreBG(0991, null, null, "Yayoi~... .... Good work, you. How is your job?");
            AddCadreBG(0991, null, null, "Kohei~Thank you. Well, is the worker doing well? ");
            AddCadreBG(0991, null, null, "Try not to think about Mr. Minato and speak as normally as possible.");
            // voice.arc_000609.ogg
            AddCadreBG(0991, null, null, "Yayoi~(Okay, unless you realize Kohei ... ...) ");
            AddCadreBG(0991, null, null, "It's a small screen on a personal computer, and even if it looks a little strange, I can not notice it.");
            AddCadreBG(0991, null, null, "So talking to myself, talk to Kohei-san in the screen.");
            AddCadreBG(0991, null, null, "Kohei~By the way, what happened to the other case? ");
            AddCadreBG(0991, null, null, "But from Kohei-san, it was cut out.");
            AddCadreBG(0991, null, null, "I did not want to talk much, but I can not ignore it.");
            // voice.arc_000610.ogg
            AddCadreBG(1001, null, null, "Yayoi~(What shall I do ......) ");

            //============================================
            // CHOICE 3-2
            //============================================

            // voice.arc_000611.ogg
            AddCadreBG(1001, null, null, "Yayoi~ah");
            AddCadreBG(1001, null, null, "To be honest, I would like to talk to Mr. Kohei.");
            AddCadreBG(1001, null, null, "After all it is a problem in my hand and I think I can not do any more.");
            AddCadreBG(1001, null, null, "It is better for Kohei to be scolded by Mr. Kohei as it is supposed to be as free as his freedom for only a week as it is.");
            // voice.arc_000612.ogg
            AddCadreBG(1001, null, null, "Yayoi~(But I'm busy with work ... I'm getting tired.)");
            AddCadreBG(1001, null, null, "I felt something like tiredness different from what I usually do, looking anxiously.");
            AddCadreBG(1001, null, null, "It's a long business trip and maybe I'm not getting tired well.");
            AddCadreBG(1001, null, null, "As I thought, it seems as though I was sorry for any further burden.");
            // voice.arc_000613.ogg
            AddCadreBG(1001, null, null, "Yayoi~(Because of me, I can not put any further inconvenience ... ...) ");
            AddCadreBG(1001, null, null, "It is my wife 's job to protect the house while my husband is out.");
            AddCadreBG(1001, null, null, "Because I told myself to do something, I have to work hard until the end.");
            // voice.arc_000614.ogg
            AddCadreBG(1007, null, null, "Yayoi~Yeah, I managed to repay it in part.");
            AddCadreBG(1008, null, null, "Kohei~Is that so? ");
            // voice.arc_000615.ogg
            AddCadreBG(1008, null, null, "Yayoi~Yup. Well .... I do not want to put too much strain on household budget, so I'd like to part time again ... is it good?");
            AddCadreBG(1008, null, null, "Kohei~Of course it does not matter, but at that supermarket? ");
            // voice.arc_000616.ogg
            AddCadreBG(1008, null, null, "Yayoi~Is that so. Because the manager was lamenting because they were short of people, I am indebted to him in various ways and thinking of going to help me just because it is good.");
            AddCadreBG(1008, null, null, "I am surprised even by myself that a lie will come out as irregularities.");
            AddCadreBG(1008, null, null, "Of course, I also thought that the store manager would seem hard to have thought of going out to the part again.");
            AddCadreBG(1008, null, null, "But I have not thought about anything concrete yet, why can you say such a thing towards Mr. Kohei?");
            // voice.arc_000617.ogg
            AddCadreBG(1003, null, null, "Yayoi~(I'm lying to Kohei-san ... ...)");
            AddCadreBG(1003, null, null, "My heart aches with that fact.");
            AddCadreBG(1003, null, null, "I never had ever lied to Kohei-san.");
            AddCadreBG(1002, null, null, "Kohei~I see ... I guess it is OK, but if it seems to be tough, I would like you to say it properly. ");
            // voice.arc_000618.ogg
            AddCadreBG(1007, null, null, "Yayoi~Of course, Kohei-san.");
            // voice.arc_000619.ogg
            AddCadreBG(0992, null, null, "Yayoi~Well then, are you eating properly? It looks somewhat pale face ...");
            AddCadreBG(0992, null, null, "To avoid pursuit from Kohei, on the other hand, I will tell it from my side.");
            AddCadreBG(0993, null, null, "Kohei~Ah ... no, I am busy ... ... ");
            // voice.arc_000620.ogg
            AddCadreBG(0993, null, null, "Yayoi~You can not afford a lunch box at a convenience store? At least let's eat something proper in the store? ");
            AddCadreBG(0993, null, null, "Kohei~That's right, there is a set menu restaurant in the neighborhood, so I will go there as much as possible. ");
            // voice.arc_000621.ogg
            AddCadreBG(0993, null, null, "Yayoi~I think that is good. Please come back fine, Kohei-san?");
            AddCadreBG(0991, null, null, "Kohei~Yes, I will be careful. Well then ... ... ");
            // voice.arc_000622.ogg
            AddCadreBG(0991, null, null, "Yayoi~Yeah ... Good luck with your work, good night, you.");
            AddCadreBG(0991, null, null, "Kohei~I think that Yayoi is too hard, but do not push yourself? Well then, good night. ");
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "In the end they smiled at each other and finished the video chat.");
            S1 = 1100; X1 = 135; Y1 = 55;
            // voice.arc_000623.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~ahh");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "When I cut off my PC, my chest is tightened again.");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "It was the first time I was born, I lied to Kohei-san.");
            // voice.arc_000624.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~But if you confidently tell the truth, I will put more burden ... ...");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I do not think I'm sorry, but I could not do anything else.");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Anyway, now I have to solve the problem of Asahi and return to life as soon as possible.");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "I am worried about things from tomorrow, but I have to decide my resolution.");
            // voice.arc_000625.ogg
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~(I'm sorry, Mr. Kohei ... ... When is your time ... ...) ");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "As a result it may cause more inconvenience, but let's try hard as much as possible.");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Because I still do not know what Mr. Minodo will ask me.");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~");
            AddCadreBG(1050, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG04", "Yayoi~");
            // ANTRACT=============================================================



            // ANTRACT=============================================================
            X1 = -215;
            X3 = 520;Y3 = 60; S3 = 1000;
            // music.arc_000001.wav
            AddCadreBG(0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Today is Asahi came from the morning as school was closed.");
            // voice.arc_000626.ogg
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~I'm glad you came to visit us, Asahi.");
            // voice?
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~ah");
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Of course, it just did not come to play normally.");
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "You can also tell from Mr. Muto's point of view about his facial expressions.");
            // voice?
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um, Yayoi ... ... What has become of it from that ... ....? ");
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "As I thought, I asked with an uneasy expression.");
            // voice.arc_000627.ogg
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~Even if you do not worry it's okay, as we have already discussed with Mr. Nioto. ");
            // voice?
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~But money, ... ");
            // voice.arc_000628.ogg
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~It was decided to pay by splitting, but I do not have to worry about that either ... ... is it? ");
            // voice?
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Um ... ... I'm sorry, it's because of me ... But, is it really okay ...? ");
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Although I said that I was not worried, I was still anxious.");
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I wonder if I can not depend on them any more.");
            // voice.arc_000629.ogg
            AddCadreBG(1046, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~...... Actually, I also consulted Kohei-san.");

            //music.arc_000006.wav
            // voice?
            AddCadreBG(1046, 1018, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Er ...... Onii-chan! What? ");
            // voice.arc_000630.ogg
            AddCadreBG(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~Yes. Kohei-san negotiated, the repair expenses also cheaper?");
            AddCadreBG(1047, 1019, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "To resolve Asahi's anxiety, speak brightly with a smile on purpose.");
            // voice?
            AddCadreBG(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~I see, Onii-chan ... ... ");
            AddCadreBG(1047, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi, who had been making her feel uneasy, also healed his expression as soon as Kohei-san's story came out.");
            // voice.arc_000631.ogg
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~(You really trust me, Mr. Kohei)");
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I can understand that feeling as well.");
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Mr. Kohei is calm and calm all the time, so he is a very reliable person.");
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "If Kohei-san deals with it, it seems that it has already been solved.");
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi who stayed together much longer than me, maybe the size of that trust is more than me.");
            // voice.arc_000632.ogg
            AddCadreBG(1046, 1016, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Yayoi~... ... So you are already safe?");
            // voice?
            AddCadreBG(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi~Yeah ... but, thanks a lot, Yayoi. ");
            AddCadreBG(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "Asahi seems relieved and smiles anyhow.");
            AddCadreBG(1046, 1017, "SILKYS_SAKURA_OttoNoInuMaNi_BG05", "I finally seemed able to regain a smile and I was happy.");


            // ANTRAKT=================
            // day livingroom
            // music.arc_000001.wav

            // voice.arc_000633.ogg
            AddCadreBG(1046, 1016, null, "Yayoi~Oh, I am sorry, Asahi-chan. I have to go out soon.");
            // voice?
            AddCadreBG(1046, 1016, null, "Asahi~Was it already such a time? I have to go home soon ... I will come to play again, Mr. Yayoi. ");
            // voice.arc_000634.ogg
            AddCadreBG(1047, 1016, null, "Yayoi~Yeah, come back to visit anytime.");
            //effect.arc_000020.wav
            AddCadreBG(1047, 0, null, "Asahi goes out of the room with a dash.");
            AddCadreBG(1047, 0, null, "I enjoyed talking with Asahi slowly after a long absence.");
            AddCadreBG(1047, 0, null, "But it is about time we promised to Mr. Muto.");
            AddCadreBG(1050, 0, null, "Yayoi~I have to go make up properly ...");
            AddCadreBG(1050, 0, null, "It is usually about a base makeup, I do not do very well.");
            AddCadreBG(1050, 0, null, "But as expected it did not go that way.");
            AddCadreBG(1050, 0, null, "Although I am cheerful if I think about what will happen, I can not translate without going beyond what I have promised.");
            // voice.arc_000635.ogg
            AddCadreBG(1050, 0, null, "Yayoi~(Even Minato is not that bad so far ... ...)");
            AddCadreBG(1050, 0, null, "I was hoping for a little bit that he would not do seriously serious things.");

            // ANTRAKT=================
            Z1 = 2;
            S2 = 680; X2 = -70; Y2 = 525; Z2 = 1;

            // evening cabinet
            // music.arc_000005.wav
            //effect.arc_000020.wav
            // voice.arc_000636.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Excuse me ...... ");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "When I got in the way while being nervous more than before, Mr. Minoda was still working.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~I will not finish, but please wait for a while.");
            // voice.arc_000637.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~....yes....");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Mr. Minato heading to the desk sometimes has a difficult face while turning through the document.");
            // voice.arc_000638.ogg
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~(I wonder if it is a hard work ...)");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I heard that you are working in financial affairs, but I wonder if I can do it personally.");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "After all it may be an investment or such thing.");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "While waiting while watching the situation for a while, Mr. Muto stands up with the documents cleared up.");
            X2 = 845; Y2 = 55;   S2 = 715;
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~You made me wait.");
            // voice.arc_000639.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~No... ....");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~I have clothes ready, can you change my clothes?.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Look at me, pointing to a paper bag under my feet.");
            // voice.arc_000640.ogg
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Are you changing clothes ...?");
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I never expected to be asked for such a thing.");
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~The size should match.");
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Mr. Minoto told paper bags again with impressive power.");
            // voice.arc_000641.ogg
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Yes, I understand ... ...");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I do not know why I need to change clothes, but I have to do exactly what I told you.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Because I promised that Mr. Minodo would be free for a week from today.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~The change of clothes is contained in the paper bag there. You do not mind using the toilet.");
            // voice.arc_000642.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Is this……? ");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I picked up a paper bag containing the name of the brand and tried inside.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "If you check the contents, you surely have clothes.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "But I was amazed at the design of the clothes.");
            // voice.arc_000643.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Huh ... really, this ...!! What?");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~Ah. I thought that it would become you.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Mr. Minato seems to be in a straight line and says such a thing.");
            // voice.arc_000644.ogg
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Um ... um ... Is that so ... I understand ");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "You only have to finish by wearing this clothes, but surely not.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "It was an atmosphere that I could not say not to change clothes.");

            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "... ...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "... ... ...");
            // voice.arc_000645.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Oh, that... ...I've changed my clothes ...... ");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Clothes prepared by Mr. Minato was very flashy.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "The line of the body is exposed exactly, the exposure of the skin is large, it seems to be visible to the underwear.");
            // voice.arc_000646.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~(Huh, embarrassing ......) ");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "My figure as seen in the mirror of the toilet was as extravagantly flashy as she was.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~── Oh, it is just as I thought, it suits you");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "However, Mr. Minato smiled happily somewhere looking at me like that.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "It may be the first time to see such expression.");
            // voice.arc_000647.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Well, then ... what will I do ...... ");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I wonder what kind of things Muto, who smiles at enjoyment, demands me.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "With anxiety and tension, the sweat drips gently on the palm of your hand.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~Oh yeah, shall we go out for a meal for the time being? I am too busy eating nothing from noon.");
            // voice.arc_000648.ogg
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Huh ...... Dinner ... ....?");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~Did you finish it already?");
            // voice.arc_000649.ogg
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~No, but ... yet ...");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Because of the tension I did not have appetite, I also ate lunch with Asahi.");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~Then, just good. I have a French restaurant that I often use, so I will go there.");
            // voice.arc_000650.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~Is this you in this shape ...?");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~There is no problem as it is a shop with atmosphere.");
            // voice.arc_000651.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~But");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I am too embarrassed that you go out for dinner after you have gone out with such gorgeous clothes.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "And it's French restaurant.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Because it is about Mr. Minodo, I think that it is surely a great shop.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Wistaria~Here we go. ");
            // voice.arc_000652.ogg
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "Yayoi~(If I go out in such a dress, it might be really outraged ... ... ...)");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "But I can not say that I do not want to disagree with Mr. Muto, who seems to be in a good mood, because he is embarrassed.");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG06", "I was embarrassed to go outside, but I decided to go along with it.");

            //Change decorations
            //effect.arc_000017.wav
            X1 = 470;
            X2 = 155;
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "After having finished eating at the French restaurant, Mr. Maoto took me to the city of the night.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~The atmosphere was good, and the taste was not bad, was it?");
            // voice.arc_000654.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Yes, yes ... Well, it was delicious ......");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "While walking side-by-side, Mr. Minoto calls out.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I talked to each other so that the conversation would not be interrupted, but I did not really know the taste.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I knew only that it was a luxurious meal, but it seems that everyone, including the shop people, is watching me, it was not where I could taste it.");
            // voice.arc_000655.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(I do not feel like eating ......)");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Even if I walk in the streets of the night like this, the line of sight of a man passing by hurts.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "It may be natural as well because it has such a big flashy appearance of such exposure.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~............ ");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Perhaps Mr. Minoto is enjoying watching me shy.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Mr. Muto seems to have fun all the time as far as it seems.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~It is a little early to go to the bar ... ... Do you go to the movies?");
            // voice.arc_000656.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Huh……?");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Mr. Muto who muttered so as to look at the clock, turning his hand to my waist while saying so.");
            // voice.arc_000657.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Huh……");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "It was a place that was difficult to judge, whether the hand was touching it, waist or buttocks.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "When I noticed it and leaked a small voice, I touched it as if to stroke it.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~Shall we walk away from nearby?");
            // voice.arc_000658.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Is ... ... Yes ... ...");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I can not even shake off my hands strongly, I walk a lot while being touched by my butt.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I wonder what people are watching from people around.");
            // voice.arc_000659.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(Huh ... ... Please, do not meet people you know ... ...)");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I kept praying in my mind while being embarrassed.");

            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Even after finishing watching the movie, I keep walking around the streets of the night while taking me by Mr. Minato.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~It is only music that is good, neither the script nor the production is satisfactory.");
            // voice.arc_000660.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Well, that's right ......");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "To somehow, Mr. Minato talks about the movie, I feel something offended.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "The movie was a long time ago, but content with meals never comes into the head.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "It was a foreign movie I do not understand well, but I only remembered the beautiful images.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "While you were watching, Mr. Minoto's hand was touching the thighs, and I was concerned only with it.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~There is a bar to go near here. Can you drink sake?");
            // voice.arc_000661.ogg
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Huh ......, Yes ... ... If only a little ... ... ");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Apparently, I guess I will go to the bar next time. I wonder if she is going to drink as it is.");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Because Kohei does not drink, I do not drink much.");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "When I was living in my parents house, I was about dating my dad's drink.");
            // voice.arc_000662.ogg
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(I have to try not to drink too much ......)");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "For now, Mr. Minato comes into contact with the body, but his attitude was very gentleman.");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "But I do not think that it will end like this.");
            // voice.arc_000663.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(Drunk me ... or something ... I wonder ... )");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "If so, I have to make sure I do not get drunk.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~Well then, let's go.");
            // voice.arc_000664.ogg
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Yes, ...");
            AddCadreBG(1070, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I have to be firm on my own so that it will not be attached.");


            // Decoration change

            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ... ...");
            // voice.arc_000665.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Oh");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~Well, Walking a little while waking up drunk.");
            // voice.arc_000666.ogg
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Ah ... ... Yes ... ... ");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Thanks to preparing and entering the shop, there was nothing to be badly intoxicated.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Of course there is an influence of liquor, but the head is still firm.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "And yet, Mr. Minoto's hand touched the neighborhood of my ass.");

            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ...");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ... ...");

            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "The way I went walking while being prompted was a corner where loud neon was lining up.");
            X1 = -435; Y1 = 435;
            // voice.arc_000667.ogg
            AddCadreBG(1070, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(Here, here ... ... That's like that ... ...?)");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "On the signboards letters such as breaks and lodgings lined up, and the people going are walking so as not to see eyes with people around them.");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "And the sense of tension increased and the body stiffened to the appearance of the man and woman entering the building.");
            // voice.arc_000668.ogg
            AddCadreBG(1071, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(Huh ...... What shall I do ...... But I ... ....) ");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I do not want to do something like betraying Kohei.");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "But if you come and refuse so far, everything may get ruined..");
            // voice.arc_000669.ogg
            AddCadreBG(1072, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(At least ... at least only the last of the clear distinction ......) ");
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Whether they come out the influence of liquor, I determine the ready while I think so.");
            
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Wistaria~...... Are you going to be here?");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Mr. Minato stops his legs in front of the buildings in line.");
            // voice.arc_000670.ogg
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~Huh!");
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "That was definitely a love hotel.");
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "When the leg stopped and stopped, Mr. Minoto's hand strongly pushed my back.");
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "I feel that I can not return to the power of that hand.");
            // voice.arc_000671.ogg
            AddCadreBG(1071, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "Yayoi~(You ... ... Kohei-san ... ...! Please protect me ... ...!)");
            AddCadreBG(1071, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG07", "While taking a step towards the entrance, I prayed to shout in my mind.");

            // Decoration change -LOVE HOTEL
            S1 = 1100; X1 = 135; Y1 = 55;
            // music.arc_000007.wav
            // voice.arc_000672.ogg            
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~(This, what is looks like ...)");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Also time you are Kohei's and dating, we not that actually entered.");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "The interior of a love hotel that I first joined is a little confused.");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Even though I thought that it was like anything with a more flashy feeling.");
            // voice.arc_000673.ogg    
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~(It is surprisingly ordinary ....) ");
            AddCadreBG(1073, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I am surprised by myself who can think of such a thing in this situation.");
            X1 = 470;
            X2 = 155;
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~Yayoi?");
            // voice.arc_000674.ogg  
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Huh ... Yes! ");
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~It is good to take a shower first.");
            // voice.arc_000675.ogg  
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Well ... OK, I ... ... ");
            AddCadreBG(1069, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "That said so, the tension rises at once.");
            AddCadreBG(1073, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I thought that time was coming, and my legs trembled a little.");
            //effect.arc_000106.wav  //shower
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "...");
            //effect.arc_000106.wav  //shower
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ...");
            //effect.arc_000106.wav  //shower
            AddCadreBG(0, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG08", "... ... ...");
            // voice.arc_000676.ogg  
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~O ... ... Thank you for waiting ...... ");
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I took a shower and changed my clothes.");
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I am trying to express things intention at least for me that I do not plan to forgive everything.");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~What, have you changed clothes? ");
            // voice.arc_000677.ogg 
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Yes ... um, that ... ... ");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~……HM. Well, I do not mind. ");
            // voice.arc_000678.ogg
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~I'm sorry ... ");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I do not intend to become Mr. Minodo's thing ... ... Although I was prepared for that kind of thing, when Mr. Mito pointed out, I could not say anything.");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "When looking at that line of sight, the back muscles trembling.");
            // voice.arc_000679.ogg
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~ Мне старшно... ");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I think that it is a person with a mysterious atmosphere, but it feels the first time so.");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "This may be the first time that I felt scared of men.");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~Well ... ... Well, will you serve with your mouth?");
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "While saying that, Mr. Minato sits down on the edge of the bed.");
            // voice.arc_000680.ogg
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Eh... ...Serving... ...");
            X2 = -15; Y2 = 475;
            AddCadreBG(1048, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~Have you ever experienced blowjobs? I'm busy getting riddled. Let me refresh.");
            // voice.arc_000681.ogg
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~!!!");
            AddCadreBG(1050, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Surely, I can not ask for such a thing.");
            AddCadreBG(1050, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~What happened? ");
            // voice.arc_000682.ogg
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Oh, no ... ... that ... ... I do not have much experience ... ... ");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I think for Mr. Kohei, there is that you have to study a little bit.");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "But when I actually did it, I tried my best and made it go away, it came to be withhold from Kohei-san.");
            AddCadreBG(1049, 0, "SILKYS_SAKURA_OttoNoInuMaNi_BM01_1", "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Wistaria~I see ... Well, I do not expect anything like that.");
            // voice.arc_000683.ogg
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Yes, ... ");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Although I intended to say it was impossible to drive around, Mr. Muto did not nod me.");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "I am afraid of what to do ... but maybe it's convenient for me.");
            // voice.arc_000684.ogg
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~(If you do your best and you can satisfy Mr. Minoto, then ... ...) ");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "If you can lead it to ejaculation with your mouth, you will not worry about crossing the last line.");
            // voice.arc_000685.ogg
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "Yayoi~Well then, then ... ... I will let you ... ... ");
            AddCadreBG(1049, 0, null, "SILKYS_SAKURA_OttoNoInuMaNi_BG09", "While I muttered so, I kneeled down to Mr. Minoto.");

            //CHANGE DECO BJ
            //music.arc_000003.wav
            // voice.arc_000686.ogg
            X1 = 0;Y1 = 0; S1 = 1370;
            AddCadreBG(0042, 0, null, null, "Yayoi~Oh ... oh, er ... ... that ... ... ");
            AddCadreBG(0042, 0, null, null, "I tried kneeling in front of Mr.Minato 's crotch, but stopped there.");
            // voice.arc_000687.ogg
            AddCadreBG(0042, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0042, 0, null, null, "From here I do not know what to do.");
            AddCadreBG(0042, 0, null, null, "Everything was different from Kohei-san at all, I did not understand her own way.");
            AddCadreBG(0042, 0, null, null, "Wistaria~You do not mind, so please let me out. ");
            // voice.arc_000688.ogg
            AddCadreBG(0042, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0042, 0, null, null, "Mr. Minato lifts his back and pushes the crotch forward.");
            AddCadreBG(0042, 0, null, null, "I say put out, that is, from suit pants ... ... I wonder if I have to do it all.");
            AddCadreBG(0042, 0, null, null, "Even though Kohei has never done that.");
            // voice.arc_000689.ogg
            AddCadreBG(0042, 0, null, null, "Yayoi~(But, I have to ... ... I have to ...) ");
            AddCadreBG(0042, 0, null, null, "I never reach out to the fasteners of my pants and slowly drop down.");
            // effect - zipping!
            AddCadreBG(0042, 0, null, null, "Then, from the pants of the window, vigorously's Minafuji of it has been jumped.");

            AddCadreBG(0043, 0, null, null, ""); //- this is transferring to next
            // voice.arc_000690.ogg
            AddCadreBG(0044, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0044, 0, null, null, "Something of another man who appeared suddenly before my eyes.");
            AddCadreBG(0044, 0, null, null, "I do not know anything other than Kohei, so I am surprised just by seeing it.");
            // voice.arc_000691.ogg
            AddCadreBG(0044, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0044, 0, null, null, "Wistaria~Is not it such a surprising thing?");
            AddCadreBG(0044, 0, null, null, "In a somewhat laughing voice, Mr. Minato says so.");
            AddCadreBG(0044, 0, null, null, "Muto, familiar feeling throughout all the time, has plenty of room to spare.");
            AddCadreBG(0044, 0, null, null, "But it may be true for a woman who is experiencing various things, for me it is my first experience.");
            // voice.arc_000692.ogg
            AddCadreBG(0044, 0, null, null, "Yayoi~(But, ... ... other people are so ... ... ...!?)");
            AddCadreBG(0044, 0, null, null, "Although it seems not to be completely hard yet, it is bigger than Kohei, and it is somewhat rugged.");
            AddCadreBG(0044, 0, null, null, "Even without touching with your fingers, you know that it is very hard.");
            AddCadreBG(0044, 0, null, null, "I wonder if such because they lifted the thick blood vessels.");
            // voice.arc_000693.ogg
            AddCadreBG(0044, 0, null, null, "Yayoi~(This, because the body is also larger than Kohei's, because of that I wonder ...)");
            AddCadreBG(0044, 0, null, null, "Since I have never seen any other man in the first place, I do not know exactly what is the average size or whether it is special.");
            AddCadreBG(0044, 0, null, null, "Wistaria~How long are you staring at that?");
            // voice.arc_000694.ogg
            AddCadreBG(0043, 0, null, null, "Yayoi~Ah ... ... yes ...... um ... ... ");
            AddCadreBG(0043, 0, null, null, "To encourage earlier, I had been staring at.");
            AddCadreBG(0043, 0, null, null, "To serve with your mouth you have to lick it.");
            // voice.arc_000695.ogg
            AddCadreBG(0043, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0043, 0, null, null, "If this is Kohei, I can do my best despite being ashamed.");
            AddCadreBG(0043, 0, null, null, "But I wonder what other men can do such a thing.");
            // voice.arc_000696.ogg
            AddCadreBG(0043, 0, null, null, "Yayoi~(But I will not be able to return if I do ... ...)");
            AddCadreBG(0043, 0, null, null, "You may be asked for more than licking.");
            AddCadreBG(0043, 0, null, null, "Then ... ... If you can do your best and get satisfied, you can protect only important places.");
            // voice.arc_000697.ogg
            AddCadreBG(0043, 0, null, null, "Yayoi~(... ... I have to work hard ... Uoo ... ...)");
            AddCadreBG(0043, 0, null, null, "I decide my resolution and I will extend my tongue to Mr. Maoto.");
            // voice.arc_000698.ogg  -lick start
            AddCadreBG(0045, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0045, 0, null, null, "Tongue touched hot and hard one.");
            AddCadreBG(0045, 0, null, null, "If you have not been drinking liquor Maybe, I think I could not be such a thing.");
            AddCadreBG(0045, 0, null, null, "I am touching the tongue to the one of the other male now.");
            // voice.arc_000699.ogg
            AddCadreBG(0045, 0, null, null, "Yayoi~(I'm licking ...... I am licking ... ...)");
            AddCadreBG(0045, 0, null, null, "Feeling like licking a specially thick fingertip ... .... But, licking is not a finger.");
            AddCadreBG(0045, 0, null, null, "Why is not Kohei-san?");
            AddCadreBG(0045, 0, null, null, "While suppressing the coming welled up is such a feeling, we desperately moving the tongue.");
            // voice.arc_000700.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~lick");
            AddCadreBG(0047, 0, null, null, "Fortunately, I did not have much dislike.");
            AddCadreBG(0047, 0, null, null, "Mr. Minato is not taking a shower, but he does not feel the smell of the sweat or body odor. It does not taste unpleasant.");
            AddCadreBG(0047, 0, null, null, "It was sad that I was licking, but I did not think it was particularly bad.");
            // voice.arc_000700.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~lick");
            AddCadreBG(0047, 0, null, null, "In a way I remember, I licked hard objects in front of my eyes many times.");
            AddCadreBG(0047, 0, null, null, "Push the tongue firmly, slide it up and down, rub it sideways, and lick all the places that arrive.");
            AddCadreBG(0047, 0, null, null, "I wonder if it is okay with such feeling.");
            // voice.arc_000701.ogg
            AddCadreBG(0048, 0, null, null, "Yayoi~lick");
            AddCadreBG(0048, 0, null, null, "Mr. Minato is just leaving himself, nothing to say.");
            AddCadreBG(0048, 0, null, null, "Occasionally, trembling the hips and waist at the time, I just look down at me and stay silent.");
            AddCadreBG(0048, 0, null, null, "Even so, when I moved my tongue and kept licking, I felt it got harder.");
            // voice.arc_000702.ogg
            AddCadreBG(0048, 0, null, null, "Yayoi~lick");
            AddCadreBG(0048, 0, null, null, "I wonder if I lick it like this, will it be out soon?");
            // voice.arc_000703.ogg
            AddCadreBG(0048, 0, null, null, "Yayoi~(I wish I had studied more ... ... ... U. ..)");
            AddCadreBG(0048, 0, null, null, "Of course for Mr. Kohei.");
            AddCadreBG(0048, 0, null, null, "But it is late to regret such a thing at this time.");
            AddCadreBG(0048, 0, null, null, "Anyway, I have to satisfy Mr. Minato anyway.");
            // voice.arc_000704.ogg
            AddCadreBG(0048, 0, null, null, "Yayoi~lick");
            AddCadreBG(0048, 0, null, null, "However, I have little experience or knowledge and I am not sure if it is being done properly.");
            AddCadreBG(0048, 0, null, null, "Mr. Minodo's stuff is hard and tightly stretched, but I wonder if it makes me feel good.");
            AddCadreBG(0048, 0, null, null, "Remains of anxiety feelings, continue to lick anyway.");
            // voice.arc_000705.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0047, 0, null, null, "Язык касается толстых кровеносных сосудов, дрожащих время от времени, дрожащих.");
            AddCadreBG(0047, 0, null, null, "Стало тяжело, что стало тяжелее, что он стал сильным.");
            AddCadreBG(0047, 0, null, null, "Но до сих пор человек тоже мокрый, но он этого не чувствует.");
            // voice.arc_000706.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~Oh");
            // voice.arc_000708.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~(Наверное, потому что я слишком плохой ... ...?) ");
            AddCadreBG(0047, 0, null, null, "Взглянув на меня, минато не шевелился.");
            AddCadreBG(0047, 0, null, null, "Г-н Минато, похоже, имеет много опыта по-разному, и, возможно, он не чувствует его в моем служении.");
            AddCadreBG(0047, 0, null, null, "Wistaria~....");
            // voice.arc_000709.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0047, 0, null, null, "Интересно, что я должен делать.");
            AddCadreBG(0047, 0, null, null, "Я не могу закончить, как есть, меня могут спросить до будущего.");
            AddCadreBG(0047, 0, null, null, "Во всяком случае, я должен что-то сделать.");
            // voice.arc_000710.ogg
            AddCadreBG(0047, 0, null, null, "Yayoi~Ох ... ... О, это ... ... Разве это не удобно ...? Yayoi");
            AddCadreBG(0047, 0, null, null, "Я осмелюсь спросить об этом.");
            AddCadreBG(0047, 0, null, null, "Если вы не можете удовлетворить г-на Минодо, нет смысла держать его таким, каким оно есть.");
            AddCadreBG(0047, 0, null, null, "Wistaria~Нет, это удобно, как есть.");
            AddCadreBG(0047, 0, null, null, "Г-н Муто, который, наконец, говорил, был спокоен, но он казался счастливым где-то.");
            AddCadreBG(0047, 0, null, null, "Передано состояние, в котором возбуждение становится выше, чем начало.");
            AddCadreBG(0047, 0, null, null, "Yayoi~Oh");
            AddCadreBG(0047, 0, null, null, "Yayoi~Oh");
        }
        
        private void AddCadreBG(int index, string Bg, string text)
        { AddCadreBG(index, null, Bg, text); }
        private void AddCadreBG(int index, string man, string Bg, string text)
        { AddCadreBG(index, 0, man, Bg, text); }
        private void AddCadreBG(int index, int index1, string Bg, string text)
        { AddCadreBG(index, index1, null, Bg, text); }
        private void AddCadreBG(int index,int index1, string man,string Bg, string text)
        {
            
            if (string.IsNullOrEmpty(Bg))
                Bg = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";

            List<DifData> cdata = null;
          
            cdata = new List<DifData>()
            { 
               new DifData(Bg) { S = s, F = 0}
            };

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


            AddLocal(currentGr, text, cdata);
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
       


        protected override void MakeCadres(string cadregroup)
        {       
            string[] cd = new string[] {
                currentGr
            };
            base.MakeCadres(cd);
            this.Cadres.Reverse();
        }
    }
}
