using StoGen.Classes.Data.Games;
using StoGen.Classes.Transition;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _ALL__ScenarioText : BaseScene
    {
        public _ALL__ScenarioText(): base()
        {
            this.DefaultSceneText.Size = 200;
            this.DefaultSceneText.Width = 1000;
            this.DefaultSceneText.FontSize = 32;
            this.DefaultSceneText.Shift = 250;
            this.DefaultSceneText.FontColor = "White";
        }
        protected override void LoadData()
        {
        }
        public void Cartina_FinansistHotelBlowjob(Dictionary<string,DifData> Pictures, Dictionary<string, MorfableName> names)
        {
            string BG = Pictures["BACKGROUND"].Name; //background
            string MAN = Pictures["MAN1_FIGURE1"].Name;
            string gg = Pictures["EVENT_0042"].Name;
            MorfableName Girl = names["Girl"];
            MorfableName BadMan = names["BadMan"];
            MorfableName GoodMan = names["GoodMan"];
            MorfableName Penis = names["Penis"];

            int i = 686; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000003.wav");
            //Music ============================


            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~ ... ... ... ... ",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"Я оказалась на коленях, перед пахом {BadMan.R}.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~ ... ... ... ... ",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"Что делать дальше, я не понимала.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"По сравнению с {GoodMan.T} все было по-другому, я растерялась.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"{BadMan}~Может быть, пора его уже достать? ",
                new List<DifData>() { Pictures["EVENT_0042"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~ ... ... ... ... ",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"{BadMan} приподнялся и выпятил пах.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"Достать это из его брюк ... ... мне на самом деле нужно это сделать?",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"Я не делала такого даже с {GoodMan.T}.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Я должна ... ... должна ...) ",
                new List<DifData>() { Pictures["EVENT_0042"] });

            DoC2($"Пальцы осторожно берут застежку молнии и медленно тянут ее вниз.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            AddEffect1($"effect.arc_000075.wav", SoundPauseShort, false); // effect - zipper
            DoC2($"Ширинка раскрывается, и оттуда с силой выпрыгивает {Penis} {BadMan.R}.",
                new List<DifData>() { Pictures["EVENT_0042"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~ ... ... ... ... ",
                new List<DifData>() { Pictures["EVENT_0044"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Прямо перед моими глазами - {Penis} мужчины, и притом - не моего мужа.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Я не была ни с кем, кроме {GoodMan.R}, поэтому, возможно, что мне было чуть-чуть любопытно.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"{Girl}~ ... ... ... ... ",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"{BadMan}~Впечатляет?",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Интонация голоса {BadMan.R} была насмешливая.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"{BadMan} явно забавлялся моей реакцией.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Такая реакция была бы неуместна для опытной женщины, у меня же это было в первый раз.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(... ... вот как он выглядит у других мужчин... ... ...!?)",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Хоть еще не полностью возбужденный, он был кпупней, чем у {GoodMan.R}, и выглядел пугающе.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Даже не прикасаясь к нему, я чувствовала, какой он мощный.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"К тому же он был весь увит толстыми фиолетовыми венами.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Интересно, наверно они разные, потому, что {BadMan} старше, чем {GoodMan} ...)",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"Так как я раньше видела 'его' только у {GoodMan.V}, то не могла сказать, среднего он размера, или большого.",
                new List<DifData>() { Pictures["EVENT_0044"] });

            DoC2($"{BadMan}~Долго будем разглядывать?",
                new List<DifData>() { Pictures["EVENT_0044"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~... ... ...... ... ... ",
                new List<DifData>() { Pictures["EVENT_0043"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я на самом деле немного увлеклась, рассматривая его {Penis}.",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"Я догадалась, что работать ртом - это значит целовать {Penis} у мужчины.",
                new List<DifData>() { Pictures["EVENT_0043"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~..........",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"Если бы это был {GoodMan}, я бы делала это, несмотря на стыд.",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"Но как делать такое с другим, чужим мужчиной?",
                new List<DifData>() { Pictures["EVENT_0043"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Если я сделаю это, то пути назад уже может не быть ... ...)",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"После этого он может захотеть большего, чем просто поцелуев там.",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"Но ... ... Но если постараться, он будет удовлетворен, и тогда самое важное будет спасено.",
                new List<DifData>() { Pictures["EVENT_0043"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(... ... я должна все для этого сделать ... ... ...)",
                new List<DifData>() { Pictures["EVENT_0043"] });

            DoC2($"Приняв это важное решение я осторожно коснулась губами {BadMan.R}.",
                new List<DifData>() { Pictures["EVENT_0043"] });


            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0045"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Он был очень горячий и твердый.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Наверно, если бы не ликер, я бы никогда не стала такого делать....",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Целовать {Penis} другого мужчины.....",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....если потрогать его языком....полизать....",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Это как будто лизать толстый палец ... .... но это не палец.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Почему это не {GoodMan}?",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Стараясь подавить вину в своем сердце, я ласкаю {Penis} языком.",
                new List<DifData>() { Pictures["EVENT_0045"] });


            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0047"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"К счастью, это оказалось не очень противно.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"{BadMan} не пошел в душ, но неприятного запаха не было.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"В сердце все равно были печаль и стыд, но хотя бы не отвращение.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Поэтому я лизала твердую и горячую штуку, торчащую передо мной.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Вверх и вниз, по бокам, некоторые места было сложно достать.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"{BadMan.D} должно было быть приятно.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0048"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"{BadMan} молчал и сидел расслабленно.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Время от времени его бедра дергались, но он все так же молча смотрел сверху на меня.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"От моих поцелуев и ласк, его {Penis} все больше твердел.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Интересно, сколько надо так ласкать, чтобы он кончил?",
                new List<DifData>() { Pictures["EVENT_0048"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Мне надо было попробовать это раньше ... ... ... )",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"То есть, я имею в виду, с {GoodMan.T}.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Жаль, что я поняла это только сейчас...",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Когда мне надо удовлетворить {BadMan.R}...",
                new List<DifData>() { Pictures["EVENT_0048"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"И теперь у меня нет опыта, чтобы сделать все правильно.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Хоть {Penis} {BadMan.R} и был очень тверд и напряжен, но я все равно не знала наверняка, что ему это нравится.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            DoC2($"Так, гадая, я и продолжала лизать его {Penis}.",
                new List<DifData>() { Pictures["EVENT_0048"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0047"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я стала чувствовать, как пульсируют его вены.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"{Penis} все твердел и увеличивался.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"На кончике появилась капля.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Наверное, у меня плохо получается ... ...?)",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"{BadMan} по прежнему молча смотрел на меня.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Наверно, я все же недостаточно хороша для мужчины, у которого было много женщин.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"{BadMan}~....",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~....",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"И что теперь делать?",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Я не могу прекратить, или он захочет чего другого",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Мне надо что-то придумать",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~... ... ... ва ... ... вам нравится ...?",
                new List<DifData>() { Pictures["EVENT_0045"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Набравшись смелости, я спросила прямо.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Если {BadMan.V} не получится удовлетворить этим способом, то нет смысла продолжать.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"{BadMan}~Нравится-нравится, продолжай!",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"{BadMan}, наконец, заговорил, и голос его был неровный, но довольный",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Кажется, он возбудился",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~....",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Скорей бы он кончил.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"{BadMan}~Хочешь, чтобы я сейчас кончил?",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......, так было бы ... ... наверно  лучше, да?... ... ",
                new List<DifData>() { Pictures["EVENT_0047"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"{BadMan}~Мы только начали. Но если готова сначала в рот принять..",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Произнеся эти слова,{BadMan} как-то странно посмотрел на меня.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Я не поняла, отчего.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Но я поняла, что есть проблема.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Боже, если это только начало ... ... это плохо...!)",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Я должна как-то удовлетворить его орально.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            DoC2($"Если сделать это интимным местом, то это будет предательством {GoodMan.R}.",
                new List<DifData>() { Pictures["EVENT_0047"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~я, ... ... я хочу чтобы вы... что ... ... прошу сказать мне... как вы хотите, чтобы я сделала ...?",
                new List<DifData>() { Pictures["EVENT_0045"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Об этом знал только сам {BadMan}.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Поэтому я и просила его сказать мне прямо.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"{BadMan} важно кивнул.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"{BadMan}~Ты должна взять в рот и сосать.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~боже, сосать...! но как ?  ... это же... так ... ..",
                new List<DifData>() { Pictures["EVENT_0046"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Но если продолжать лизать бесполезно, надо как-то по-другому...но как?",
                new List<DifData>() { Pictures["EVENT_0046"] });

            DoC2($"Во-первых, как такой большой и твердый {Penis} поместится у меня во рту?",
                new List<DifData>() { Pictures["EVENT_0046"] });

            DoC2($"И что делать, когда он там окажется?",
                new List<DifData>() { Pictures["EVENT_0046"] });

            DoC2($"{BadMan}~Поспеши.",
                new List<DifData>() { Pictures["EVENT_0046"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(что же делать ......! но ведь ... ... если отказаться, то ...)",
                new List<DifData>() { Pictures["EVENT_0045"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Если я не смогу удовлетворить {BadMan.R}, то все будет зря.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Этого не должно случиться, а если я не сделаю того, чего он хочет, то будет еще хуже.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~д.. .... да, я ...сейчас... ",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Чтобы удовлетворить {BadMan.R}, мне нельзя сомневаться.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            DoC2($"Я собрала все смелость, оставшуюся от выпитого ликера, и раскрыла рот.",
                new List<DifData>() { Pictures["EVENT_0045"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~ ...... ... ...!  ... ....  ... ...!",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Рот наполнился вкусом и запахом, который трудно описать словами.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Странно, но как только {Penis} оказался у меня во рту, я уже не могла думать ни о чем другом.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Он очень сильно отличался от {Penis.R} {GoodMan.R} не только размером и формой, но также и вкусом, и запахом.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Как сильно отличаются мужчины ...!)",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{Penis} {BadMan.R} на вкус казался каким-то очень развратным.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"В нем было что-то животное, звериное.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я ощупала его языком, и почувствовал как он запульсировал.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan}~Не заглатывай слишком много, а то может затошнить.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Закрыв глаза, {BadMan} кивнул.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я немного приспособилась к размеру, и могла уже нормально дышать.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Приходилось быть осторожной, потому что я боялась случайно прикусить его.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~( ... он такой крупный, у меня заболели скулы ... ...)",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Рот приходилось открывать очень широко, иначе {Penis} не входил.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"К тому же я старалась делать так, чтобы он прошел до горла, а то меня могло затошнить.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(...все ... я сосу {Penis} ... ... ... ...)",
                new List<DifData>() { Pictures["EVENT_0051"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Приходилось все время глотать слюну.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            DoC2($"Неужели я это делаю.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я старалась сосать, даже когда он был глубоко.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan}~В чем дело? Если трудно, то можешь остановиться. ",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Но я не могла позволить себе сомневаться и прекратить, хоть и не знала, справлюсь ли.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0049"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Помогая себе языком, я старалась перекатывать {Penis} во рту.",
                new List<DifData>() { Pictures["EVENT_0049"] });

            DoC2($"Несколько раз я чуть не закашлялась.",
                new List<DifData>() { Pictures["EVENT_0049"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.... Больно...",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Лицевые мышцы тоже заболели.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.......",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Надо было терпеть и продолжать сосать этот {Penis}.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я трогала его, языком, губами, всем ртом",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Не знаю, хорошо ли у меня получалось, но я старалась изо всех сил.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0051"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Его {Penis} стал сочиться каплями с кончика.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            DoC2($"Я знаю, что так бывает, когда мужчина получает удовольствие.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            DoC2($"Наверно, {BadMan.D} понравились ласки.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0051"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Вот так лучше ... ....)",
                new List<DifData>() { Pictures["EVENT_0051"] });

            DoC2($"Я стала чувствовать его ответную реакцию.",
                new List<DifData>() { Pictures["EVENT_0051"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я приспособилась в конце концов.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"В начале было болезненно, но постепенно я привыкла.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Надо стараться двигать шеей как можно плавней... ...) ",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я чувствовала, как работают мои губы.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Для лучшего результата надо работать и языком.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"И это оказалось верно.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan}~Да, так уже хорошо.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan.D} понравилось.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Признаюсь, я люблю когда меня хвалят.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0049"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я вдруг поняла, что мне приятна и эта похвала.",
                new List<DifData>() { Pictures["EVENT_0049"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0049"] });

            DoC2($"Если продолжать, я точно добьюсь своего.",
                new List<DifData>() { Pictures["EVENT_0049"] });

            DoC2($"Это ожидание росло во мне, и я старалась все азартнее.",
                new List<DifData>() { Pictures["EVENT_0049"] });
            

            //g = 0050;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~...."
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Я уже не вспоминала о {GoodMan.P}, а увлеченно сосала то, что было у меня во рту.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~..........");
            //DoC(g, 0, null, null, $"В уголке губ скопилась слюна.");
            //DoC(g, 0, null, null, $"На груди было влажное пятно, но это даже меня не заботило.");
            //DoC(g, 0, null, null, $"Я думала только о том, чтобы заставить {BadMan.R} кончить.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Я должна полностью удовлетворить его ... ...!) ");
            //DoC(g, 0, null, null, $"Для того чтобы не быть вынужденной идти дальше, мне надо все сделать ртом.");

            //g = 0051;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~..........");
            //DoC(g, 0, null, null, $"Губы и язык уставали, но это меня не могло остановить.");
            //DoC(g, 0, null, null, $"{BadMan}~Прекоасно ... это просто чудесно.");

            //g = 0052;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Надо постараться еще немного ......) ", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Я поняла, что близка к цели по голосу {BadMan.R} и по тому, как напрягся его {Penis} в моем рту.");
            //DoC(g, 0, null, null, $"Я сказала себе, что нужно еще немного, и продолжила ласки без остановки.");

            //g = 0050;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Вот, еще ......) ", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Я отчаянно ласкала, и из {Penis.R} стало сочиться.");
            //DoC(g, 0, null, null, $"Странно, от этого у меня начала кружиться голова, а все чувства парализовало.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~......");
            //DoC(g, 0, null, null, $"Во рту стало очень горячо.");
            //DoC(g, 0, null, null, $"Весь мир исчез для меня.");
            //DoC(g, 0, null, null, $"Горький вкус растекался по рту и обжигал язык.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~.......");
            //DoC(g, 0, null, null, $"Я страстно желала, чтобы брызнул прямо сейчас.");
            //DoC(g, 0, null, null, $"Я думала только об этом.");
            //DoC(g, 0, null, null, $"{BadMan}~ммммммммм ......");

            //g = 0052;            
            //DoC(g, 0, null, null, $"{BadMan} застонал, и я языком сильно прижала его {Penis} к небу."
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Наверно это было очень приятно.");

            //g = 0050;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~..............", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Я почувствовала, что развязка близко и стала ласкать быстрей.");
            //DoC(g, 0, null, null, $"Он положил руку мне на голову и стал давить.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Прошу быстрей ......!)");
            //DoC(g, 0, null, null, $"И вот рот {BadMan.R} вдруг открылся.");
            //DoC(g, 0, null, null, $"{BadMan}~...... Я кончаю.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);

            //g = 0050;
            //DoC(g, 0, null, null, $"{Girl}~......", OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~......");
            //DoC(g, 0, null, null, $"Я еще не поняла смысл слов {BadMan.R}, но почувствовала сильную пульсацию во рту.");
            //g = 0053;

            //AddEffect1($"effect.arc_000150.wav", SoundPauseShort, false); // effect - splach also effect.arc_000142.wav,144-156,
            //ORGAZM = true;
            //DoC(g, 0, null, null, $"Сплат! Сплат! Сплат! Сплат!", OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~.......");

            //DoC(g, 0, null, null, $"Сперма {BadMan.R} стала выплескиваться мощными толчками.");
            //DoC(g, 0, null, null, $"Струи, одна за другой, били мне в горло.");
            //DoC(g, 0, null, null, $"Бездумно, я старалась проглотить их.");
            //g = 0054;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~.........", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Я крепко обхватила губами сильно пульсирующий {Penis}.");
            //DoC(g, 0, null, null, $"Первый раз в жизни я принимала его извержение прямо в рот, и была поражена  пульсацией.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Оооох, эякуляция настолько мощная ... ....!)");
            //DoC(g, 0, null, null, $"Я была ошеломлена, не могла двигаться, клейкая масса все наполняла мне рот.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~...");
            //DoC(g, 0, null, null, $"Стараясь не закашляться, я принимала ее.");
            //DoC(g, 0, null, null, $"Когда рот был заполнен до конца, мне пришлось понемногу глотать, чтобы не задохнуться.");
            //g = 0055;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~.....", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Немного протекло даже из носа через носоглотку.");
            //DoC(g, 0, null, null, $"Я дождалась, когда эякуляция закончится, и {Penis} был убран.");
            //g = 0056;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~......", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Вкус и запах теплой спермы наполнял мой рот, и я сразу постаралась освободить его.");
            //DoC(g, 0, null, null, $"Мое дыхание пахло неприятно.");
            //DoC(g, 0, null, null, $"Я быстро сплюнула, много еще оставалось во рту.");
            //DoC(g, 0, null, null, $"{BadMan}~Ты правда первый раз приняла в рот? Это было неплохо.");
            //g = 0058;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~а ... ... а ... .... а да, было ... ... хорошо ...", OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Мне еще не удалось восстановить дыхание, но я чувствовала облегчение.");
            //DoC(g, 0, null, null, $"Я смогла удовлетворить {BadMan.V}.");
            //g = 0057;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~...........", OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Я справилась, все закончилось ... ...)");
            //DoC(g, 0, null, null, $"Я смогла пройти через это.");
            //DoC(g, 0, null, null, $"От чувства удовлетворения, что я смогла довести {BadMan.V} до эякуляции, на сердце стало легко.");
            //DoC(g, 0, null, null, $"Но тут, как в насмешку над моими надеждами, {BadMan} стал раздеваться.");
            //DoC(g, 0, null, null, $"{BadMan}~Я теперь я сделаю тебе хорошо.");
            //g = 0058;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~....., .... ...... ... это .....это не все? ... ...! ", OpEf.HidePrev(1));

            ClearSound(true, true, true);

        }


        public void VideoFrame800(List<AP> anims,List<string> music)
        {
            AddMusic(music[0]);
            DifData size = new DifData() { S = 800 };
            foreach (var item in anims)
            {
                AddAnim(item.File,string.Empty, size, item);
            }            
        }
        public void VideoFrame800(List<List<AP>> anims, List<string> music)
        {
            AddMusic(music[0]);
            DifData size = new DifData() { S = 800 };
            foreach (var item in anims)
            {
                AddAnim(item[0].File, string.Empty, size, item.ToArray());
            }
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Scene1"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
