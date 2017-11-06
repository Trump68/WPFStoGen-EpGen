using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        int s = 1230;
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
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_1", "GM01_1.png", path);
	        AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_2", "GM01_2.png", path);
            AddToGlobalImage("SILKYS_SAKURA_OttoNoInuMaNi_GM01_3", "GM01_3.png", path);

            this.DefaultSceneText.Size = 100;
            this.DefaultSceneText.Width = 1346;
            this.DefaultSceneText.FontSize = 20;
            this.DefaultSceneText.Size = 75;
            this.DefaultSceneText.Shift = 10;

            currentGr = "Save2-1";
            DoScenario();
        }
        string currentGr;

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
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
            //AddCadre(1048, "{Evening livingroom}Yayoi~");
        }
        private void AddCadreAoiKohei(int index,string gm, string text)
        {
            List<DifData> cdata = new List<DifData>() {
            new DifData(data[index - 1]) { X = 0, S = s, F = 0},
            new DifData(gm) { Y = 540, S = 230, F = 0},
            }; AddLocal(currentGr, text, cdata);
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
