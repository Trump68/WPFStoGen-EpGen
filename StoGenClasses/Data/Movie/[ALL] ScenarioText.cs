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
        public void Cartina_FinansistHotelFuck(Dictionary<string, DifData> Pictures, Dictionary<string, MorfableName> names)
        {
            MorfableName Girl = names["Girl"];
            MorfableName BadMan = names["BadMan"];
            MorfableName GoodMan = names["GoodMan"];
            MorfableName Penis = names["Penis"];

            int i = 760; // voice indexer
            CurrentSounds = new List<seSo>();
            //Music ============================
            AddMusic("music.arc_000003.wav");
            //Music ============================

            DoC2($"Он стал раздевать меня.",
                new List<DifData>() { Pictures["BACKGROUND"] });

            Pictures["EVENT_1063"].S = 1100;Pictures["EVENT_1063"].X = -515;Pictures["EVENT_1063"].Y = 55;
            Pictures["MAN1_FIGURE2"].S = 0715;Pictures["MAN1_FIGURE2"].X = 1160;Pictures["MAN1_FIGURE2"].Y = 55;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~Wait, wait ...... ",
                new List<DifData>() {
                { Pictures["BACKGROUND"] },
                { Pictures["EVENT_1063"] },
                { Pictures["MAN1_FIGURE2"] },
                },
                new List<OpEf>() {
                        OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300"),
                        OpEf.AppCurr(3, "W..0>O.B.400.100*W..0>X.B.400.-300")
                });
            Pictures["EVENT_1063"].X = -215;
            Pictures["MAN1_FIGURE2"].X = 860;

            DoC2($"{BadMan}~Если останешся в одежде, то она запачкается? Но мне все равно, я могу и так.",
                new List<DifData>() { Pictures["BACKGROUND"] , Pictures["EVENT_1063"] , Pictures["MAN1_FIGURE2"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~как то так, охххх...!",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1063"], Pictures["MAN1_FIGURE2"] });

            DoC2($"Я не смогла избежать его рук, и скоро оказалась совершенно обнаженной.",
                new List<DifData>() { Pictures["BACKGROUND"] },
                new List<OpEf>() { OpEf.HidPrev(2, "W..0>O.B.400.-100*W..0>Y.B.200.300"), OpEf.HidPrev(3, "W..0>O.B.400.-100*W..0>Y.B.200.300") });

            Pictures["EVENT_1097"].S = 1100; Pictures["EVENT_1097"].X = -515; Pictures["EVENT_1097"].Y = 55;
            Pictures["MAN1_FIGURE3"].S = 0715; Pictures["MAN1_FIGURE3"].X = 1160; Pictures["MAN1_FIGURE3"].Y = 55;
            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~Я не знаю ...... я не готова ... ...",
                new List<DifData>()
                { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] },
                new List<OpEf>() {
                        OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300"),
                        OpEf.AppCurr(3, "W..0>O.B.400.100*W..0>X.B.400.-300")
                });
            Pictures["EVENT_1097"].X = -215;
            Pictures["MAN1_FIGURE3"].X = 860;

            DoC2($"{BadMan}~Ты сама сюда пришла, я не заставлял.",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~я ... ... ах ......!",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] });

            DoC2($"Я думала, что все уже позади, но это оказалось не так, и я паниковала.",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] });

            DoC2($"{BadMan} взял меня за руку, положил на кровать, и поставил в незнакомую для меня позицию.",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(о нет, что он хочет сделать ...... !?) ",
                new List<DifData>() { Pictures["BACKGROUND"], Pictures["EVENT_1097"], Pictures["MAN1_FIGURE3"] });

            //posX1 = 0; posY1 = 0; Size1 = 1370;
            //DoC(0, 0, null, null, $"", OpEf.HidePrev(0), OpEf.HidePrev(1), OpEf.HidePrev(2));

            //DoC(0059, 0, null, null, $"What are you doing ...?!", OpEf.AppearCurrent(1));
            //DoC(0059, 0, null, null, $"It felt like crossing the face of Mr. Muto who was lying on his back on the bed, I was wearing a cover over it.");
            //DoC(0059, 0, null, null, $"{BadMan}~What, you do not know Six Nine, too?");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(0059, 0, null, null, $"{Girl}~I ... ... I do not have it any secret ...?");
            //DoC(0059, 0, null, null, $"Somehow I have heard it, but I can not remember it a little.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //int g = 0061;
            //DoC(g, 0, null, null, $"{Girl}~(I wonder what it was ...... But if this position ... ... ... ...) "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Mr. Minoto's breath was blown in my crotch.");
            //DoC(g, 0, null, null, $"There is my crotch in front of Mr. Minato. Surely the embarrassed place must be visible.");
            //DoC(g, 0, null, null, $"And before my eyes there was something that was held until a while ago.");
            //DoC(g, 0, null, null, $"{BadMan}~Well, this is the act of caressing each other like this. ");
            //g = 0060;
            //i++;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~... ... to each other ...! What?"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"It is certainly such a position but I did not think that I should do it yet.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(But, I thought it would be the end if I put it out ...) ");
            //DoC(g, 0, null, null, $"Kohei-san is always over when I put it out, and I thought that the man's man can only be issued once.");
            //DoC(g, 0, null, null, $"But, Mr. Muto's thing is still firm.");
            //DoC(g, 0, null, null, $"There is no other way than to say that my idea I did not know was sweet.");
            //g = 0062;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Huh ... ... here in this kind of dress ... ...."
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"{BadMan}~That's why, please also serve well. ");
            //g = 0060;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Uooh ...... Yes ... ..."
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Every time Mr. Minato speaks, I take a breath over there.");
            //DoC(g, 0, null, null, $"Kohei - san is ashamed because he did not close his face so close.");
            //g = 0061;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haa ......, Fuu ...... "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"But, as soon as I come here, I have to decide my mind and continue.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(2 times ...... If you put it out twice, surely ... ....) ");
            //DoC(g, 0, null, null, $"Mr. Minodo was drinking as well at the bar and I wanted to think that I could not continue so much.");
            //g = 0062;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Chu ...... Chu ...... Re ... .... Re ... ... "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"I drove embarrassment to a corner of my head and stretched my tongue to Mr. Mr. Minato who was still stiff.");
            //DoC(g, 0, null, null, $"The thick blood vessel rises, the tongue tip is aligned with the rugged portion, and it makes it crawl along the line.");
            //DoC(g, 0, null, null, $"Was it a bit familiar or a feeling paralyzed just a little while ago, this time I will be licked without hesitation.");
            //DoC(g, 0, null, null, $"I was not bothered by that it was covered with sperm and just slimy.");
            //g = 0061;
            //DoC(g, 0, null, null, $"To the other party is not a Mr. Kohei, I wonder why it is such a thing.", OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Chu ...... Chu ...... Re ... .... Re ... ... ");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"(Mi, because it's for everyone ...... Asahi-chan, Kohei-san ... ...)");
            //DoC(g, 0, null, null, $"So let's tell themselves and try hard.");
            //DoC(g, 0, null, null, $"I made up my mind and moved my tongue over and over.");
            //DoC(g, 0, null, null, $"But with this position, I will be concerned about Mr. Minoto's line of sight.");
            //g = 0060;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Mi......I've been watching ... ... ... ...) "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Even if not see directly into the shadow of the ass, body temperature transmitted to the skin, it will tell the movement of the face of Mr. Minafuji.");
            //g = 0061;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haah ... .... Uoo, Huhu ...."
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Even though I made up my mind, when I feel a gaze over there, I can not concentrate on making my tongue crawl on that in front of me.");
            //DoC(g, 0, null, null, $"I have already seen naked, but it is still more embarrassing than that.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Haah ... .... Uoo, Huhu ....");
            //DoC(g, 0, null, null, $"While service in Minafuji's, only that of the line-of-sight becomes mind.");
            //DoC(g, 0, null, null, $"Even though I can not finish it unless I concentrate and try hard.");
            //DoC(g, 0, null, null, $"{BadMan}~However, it has a beautiful color considerably. There is no collapse of the shape");
            //g = 0060;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Like a inflame such a thing my shame, Mr. Minafuji was such a thing impressions in the mouth.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Yes, color or shape ... so ... ...!) ");
            //DoC(g, 0, null, null, $"After all it was seen by Mr. Minato.");
            //g = 0061;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"I'm too embarrassed and it seems to get a fire from my face.");
            //DoC(g, 0, null, null, $"Even Kohei-san, you have not been seen so close.");
            //DoC(g, 0, null, null, $"{BadMan}~What's wrong, your mouth stopped?");
            //g = 0060;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Ah, that ... ... Do not look so much ...... I ... ... it's too embarrassing ...... "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"{BadMan}~I can not do anything if I do not see it? I think the same thing is being watched by it.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~That ... ... ... ... Yes, but, but ... ");
            //DoC(g, 0, null, null, $"{BadMan}~Well, I will not mind that at once.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Lie ...... That's ...!");
            //DoC(g, 0, null, null, $"{BadMan}~Look here ......");
            //g = 0064;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Cowrie ...! Hmm ... ... do not ... ...!"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Before I knew it well, Mr. Minato's finger suddenly came in me.");
            //DoC(g, 0, null, null, $"{Girl}~Huhuu, the person behind you is moist. Did you get excited with my cock? ");

            //AddEffect2($"effect.arc_000160.wav", SoundPauseShort, true);//Effect - squish

            //DoC(g, 0, null, null, $"Mr. Minodo began to move his fingers inside so as to ascertain my feel.");
            //g = 0063;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Sure, that ... ... hey, that's ...! Oh no, well ...!"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Even though Mr. Kohei could be touched, I never put my fingers inside like this.");
            //DoC(g, 0, null, null, $"Moreover, it has been seen in front of you.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ahhh ... ...!");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(This shy is too embarrassing, I will manage somehow ...!) ");
            //DoC(g, 0, null, null, $"It is embarrassing just to be seen, but I can not put it in my fingers.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Oh, no it ...! Please, please pull me out ...!");
            //DoC(g, 0, null, null, $"I accidentally appealed to it with such words, but Mr. Minodo did not seem to get through at all.");
            //g = 0064;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ahh...    no ...!"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"As the shape of the finger will be clearly Kanjitore, and strongly pressed against the inside, it continued to fuck.");
            //DoC(g, 0, null, null, $"Even though I am ashamed of this, I felt like I was enjoying it.");
            //CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
            //DoC(g, 0, null, null, $"{BadMan}~Hmm ... ... for married people the tightness is also good. ");
            //DoC(g, 0, null, null, $"I finally stop fingering, I mutter such things.");
            //DoC(g, 0, null, null, $"It is terrible to express a woman 's body that way.");
            //g = 0063;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Or, Mr. Minoto ...!"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"{BadMan}~Let's see which sensitivity you are.");
            //DoC(g, 0, null, null, $"While saying that with a funny voice, Mr. Minoto's finger started moving slowly again.");
            //g = 0064;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ahhh!"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"This time I will touch little by little, looking for something.");
            //DoC(g, 0, null, null, $"It seems like I'm verifying my reaction while touching.");
            //DoC(g, 0, null, null, $"If you are conscious of such a thing, you will be concerned only with Mr. Minato's fingers moving in that place.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ahhh!");
            //DoC(g, 0, null, null, $"I wonder if my fingers are concerned, or because I am ashamed, I feel nervous and my breath does not stop.");
            //DoC(g, 0, null, null, $"If you keep on keeping it like this, I will manage to do something.");
            //g = 0063;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Wow ... I want to end it soon ... ...)"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"To that end, I have to lead Mr. Muto until ejaculation.");
            //DoC(g, 0, null, null, $"If I think that I should try my best the same way, it just gets heavier.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(But, ... ... as it is ... .... Uuu ... ...) ");
            //DoC(g, 0, null, null, $"I can not bear this embarrassing thing.");
            //DoC(g, 0, null, null, $"As I escaped the reality from embarrassment in front of you, I resolved to prepare and I also got a thing of Mr. Minodo.");
            //g = 0066;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"It sucks hard and deeply into it and sucks and sucks it deeper than before.");
            //DoC(g, 0, null, null, $"I am used to getting acquainted and sucking licking.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"It has become quite accustomed to shape and size, so I was able to serve much more smoothly than before.");
            //DoC(g, 0, null, null, $"However, even though I intend to concentrate on such a mouth service, I will be more concerned about what Mr. Muto is supposed to do.");
            //g = 0067;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Ah ... ... well, do not stir it with your fingers so much ...!) ");
            //DoC(g, 0, null, null, $"You can see that Mr. Maoto's fingers are moving in me.");
            //DoC(g, 0, null, null, $"There just probably because you are in the mood, have become much more sensitive than usual.");
            //DoC(g, 0, null, null, $"A bit of movement can be clearly felt.");
            //DoC(g, 0, null, null, $"Just a bad feeling becomes stronger, do not be too concentrated in service.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~.....");
            //DoC(g, 0, null, null, $"{BadMan}~Like suddenly, suck it tightly? I also do it well.");
            //g = 0065;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(You do not have to do such a thing) ");
            //DoC(g, 0, null, null, $"I could not say.");
            //g = 0066;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"I am embarrassed, I move my face in the way I just learned a little while ago, sucking hard and keep sucking it suddenly.");
            //DoC(g, 0, null, null, $"Move your face with your head and slide your tongue, treat it with your lips and cheeks, and serve in a way that uses your whole mouth.");
            //DoC(g, 0, null, null, $"But Muto's finger movements block it.");
            //g = 0067;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"Movement that stirs slowly, has gradually turned into something different.");
            //DoC(g, 0, null, null, $"The fingertips that moved as if to stroke inside crooked and started to move in and out while scratching.");
            //DoC(g, 0, null, null, $"It makes me so irritated and strange that it gets dumpy.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"{BadMan}~According to the you of the service, I because I also'll be pleasant.");
            //DoC(g, 0, null, null, $"In other words it, the more I work hard if hang in there, was that would come back to yourself.");
            //g = 0065;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Well, such a trouble ... ...! Ay ... ...) ");
            //DoC(g, 0, null, null, $"I just wanna satisfy Mr. Minoda.");
            //DoC(g, 0, null, null, $"Separately I do not want you to feel pleasant.");
            //DoC(g, 0, null, null, $"However, Mr. Minato will not stop the movement of the fingers put in me.");
            //DoC(g, 0, null, null, $"If I did not do anything, it only lasted for a long time.");
            //g = 0067;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"According to my sucking, Mr. Minoto's fingers moved again.");
            //AddEffect2($"effect.arc_000162.wav", SoundPauseShort, true);//Effect - squish
            //DoC(g, 0, null, null, $"Although it is slowly, when put in and out there, a sticky big sound leaks out.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Doing......Sounds horny...___ ___ ___");
            //g = 0068;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"I did not want to believe, had gotten have been wet enough to be heard clearly up to my ear.");
            //DoC(g, 0, null, null, $"{BadMan}~It's pretty sensitive, not bad.");
            //g = 0066;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //AddEffect2($"effect.arc_000163.wav", SoundPauseShort, true);//Effect - squish
            //DoC(g, 0, null, null, $"As service is intensified, Mr. Minoto's fingers also moves fancy, and embarrassing sounds are getting bigger and bigger.");
            //DoC(g, 0, null, null, $"She seems to be saying that he wants me to feel more pleasant.");
            //DoC(g, 0, null, null, $"Even though I do not plan to do that, it will result in that.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"I can not go on to not continue.");
            //DoC(g, 0, null, null, $"I have to be satisfied with Mr. Minato before my body can not stand this feeling.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"Mr. Minato's finger movement is not intense, but over there will be getting more and more difficult.");
            //DoC(g, 0, null, null, $"Before I knew it, my lower body was getting hot and it got hot.");
            //DoC(g, 0, null, null, $"There is no feeling of well-being that makes the heart warm, like Kohei-san did, but that extra was exciting.");
            //g = 0067;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"So as not to lose the stimulus from the Minafuji's, suck licking desperately.");
            //DoC(g, 0, null, null, $"Somehow, but I learned a little about it.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"If you accumulate saliva in your mouth, it will be easier to suck up a little.");
            //DoC(g, 0, null, null, $"But when I'm just sucking, my jaws get tired, so I will use my tongue at the same time and stimulate it.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //DoC(g, 0, null, null, $"Also coming is also blurred horny your juice, Mr. Minafuji is me properly become comfortably.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(If we work hard in this state...)");
            //DoC(g, 0, null, null, $"Thinking that way, despite being desperate, Mr. Minodo's finger blocks that idea.");
            //g = 0065;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"It was involuntarily stimulation of the more likely causes trembling waist.If you have not'm still painting mouth, maybe I had gotten out amazing voice.");
            //AddEffect2($"effect.arc_000164.wav", SoundPauseShort, true);//Effect - squish
            //DoC(g, 0, null, null, $"Mr. Minato's fingers are put in and out a little hard.");
            //DoC(g, 0, null, null, $"{BadMan}~If you feel this much in the finger, that's variously expected to be likely. ");
            //DoC(g, 0, null, null, $"While saying such a funny voice, I will blame me hard.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~uh");
            //g = 0071;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Do not intensify ... ... Do not intensify... ...!)"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"I also have a lot of seasoned juice.");
            //DoC(g, 0, null, null, $"It will not be fake for me so long as it will be this way.");
            //DoC(g, 0, null, null, $"To the fact that I felt, my heart is tightened with a sense of guilt.");
            //DoC(g, 0, null, null, $"I do not forgive everything, but that does not make any excuse.");
            //g = 0070;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"In order to escape from such guilt, I try to devote himself to the service before my eyes.");
            //DoC(g, 0, null, null, $"Because too spicy and not to do so.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //DoC(g, 0, null, null, $"However, Mr. Minodo blamed me more intensely like laughing at my feelings.");
            //AddEffect2($"effect.arc_000165.wav", SoundPauseShort, true);//Effect - squish
            //g = 0071;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(ah)");
            //DoC(g, 0, null, null, $"My fingers move fiercely more than the momentum I lick.");
            //DoC(g, 0, null, null, $"It was roughly disturbed and the waist trembled.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //DoC(g, 0, null, null, $"Still, somehow, I will continue to serve hard so that I can not defeat the stimulus.");
            //DoC(g, 0, null, null, $"It seemed that I could not do anything anymore if I took a rest for a while.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(But, ... ... I got it any longer ...!)");
            //DoC(g, 0, null, null, $"Continue to serve Mr. Muto hard while enduring the culmination which gradually increases.");
            //DoC(g, 0, null, null, $"Only the feeling which stiffly stretches in your mouth supported the tense feeling.");
            //g = 0070;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Even, a little more ... ...!)"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"If Mr. Minodo issues it, it ends with that.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //DoC(g, 0, null, null, $"I just suck it and it sucks licking desperately.");
            //DoC(g, 0, null, null, $"My jaw is also tired and salivation does not stop, and my sense of lips and tongue is getting dull.");
            //DoC(g, 0, null, null, $"But now I can not stop whining.");
            //g = 0071;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Oh, ah ......! Well, it's useless ... ...!) "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"Intense fingering's Minafuji to go cornered.");
            //DoC(g, 0, null, null, $"I will not be able to endure any more.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~((Sorry, Kohei-san ... ...!) ) ");
            //DoC(g, 0, null, null, $"While apologizing to Kohei's in my mind, decide prepared to become reached.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //DoC(g, 0, null, null, $"{BadMan}~I will release it soon ...!");
            //DoC(g, 0, null, null, $"It was just after that that he heard that word.");

            //g = 0073;
            //ORGAZM = true;
            //CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{ Girl}~ah"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"...");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{ Girl}~ah");
            //DoC(g, 0, null, null, $"Mr. Maito's ejaculation begins at the beat that I opened my mouth without thinking.");
            //DoC(g, 0, null, null, $"Suddenly overflowing from Mr. Mihito's pulsating in front of my eyes.");
            //g = 0072;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah"
            //    , OpEf.HidePrev(1));
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(Ah ... .... Ah, it's hot, so much ...!!)");
            //DoC(g, 0, null, null, $"Even though I just got out earlier, I still wish I could have gone so much.");
            //DoC(g, 0, null, null, $"Besides, I also reached it lightly with Mr. Minodo's ejaculation.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"({Girl}~(Uoo, ... together until me ......) ");
            //DoC(g, 0, null, null, $"It is embarrassing that we have reached together if it only serves.");
            //DoC(g, 0, null, null, $"It makes me feel comfortable by being made by someone other than Kohei.");
            //g = 0075;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah"
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"With the great smell of semen and the lingering finish of cum, the body is still hot.");
            //DoC(g, 0, null, null, $"My head is getting bogged down and it seems I can not think about it properly.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"({Girl}~(Well ... but it was over with this ... ...?)");
            //DoC(g, 0, null, null, $"I want to think so, but I was not very confident.");
            //DoC(g, 0, null, null, $"Perhaps it is said that it will continue still.");
            //DoC(g, 0, null, null, $"I have no confidence to satisfy with service alone.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~ah");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~(But, until the end ... that is only ... ...) ");
            //DoC(g, 0, null, null, $"If you betray Kohei to that point, you will definitely not be able to match your face.");
            //DoC(g, 0, null, null, $"At least with guilt, I did not have confidence to speak properly.");
            //DoC(g, 0, null, null, $"{BadMan}~Well, it was not bad service");
            //g = 0074;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Haa ...... Haa ...... Oh, thank you .... "
            //    , OpEf.HidePrev(1));
            //DoC(g, 0, null, null, $"{BadMan}~Have you finished it properly?");
            //DoC(g, 0, null, null, $"Maybe Mr. Minafuji is known, has come to hear so.");
            //DoC(g, 0, null, null, $"I think surely and I want to admit it to me.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, null, $"{Girl}~Um ... ..., yes ...... Yayoi");
            //DoC(g, 0, null, null, $"But I could not deny, I was nodding back.");
            //DoC(g, 0, null, null, $"It is very embarrassing and I am sad when I think of Kohei but I am afraid to fail Mr. Moto's mood.");
            //DoC(g, 0, null, null, $"Поэтому не решался лгать или обманывать.");
            //DoC(g, 0, null, null, $"{BadMan}~Хуху, это правильно ... ");
            //DoC(g, 0, null, null, $"Mr. Minodo leaks a satisfying smile to my answer.");
            //DoC(g, 0, null, null, $"И это вызвало тело так, чтобы отклонить мое тело.");
            //DoC(0, 0, null, null, $"");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //Size1 = 1100; posX1 = 750; posY1 = 55;
            //Size2 = 0715; posX2 = -50; posY2 = 55;
            //g = 1097;
            //DoC(g, 0, MAN, BG, $"{Girl}~ ...... ",
            //    OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300"),
            //    OpEf.AppCurr(1, "W..0>O.B.400.100*W..0>X.B.400.-300")
            //);
            //posX1 = 450; posX2 = 250;
            //DoC(g, 0, MAN, BG, $"I can not see how tired he is, so I wonder if he I can continue as it is.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, MAN, BG, $"{Girl}~(...oh....{GoodMan}....)");
            //DoC(g, 0, MAN, BG, $"The leg trembles as if I think I will cross the last line.");
            //DoC(g, 0, MAN, BG, $"But Mr. Mihito returned his heel on the spot and turned his back on me.");
            //AddMusic("music.arc_000007.wav");
            //DoC(g, 0, MAN, BG, $"{BadMan}~I get back after taking a shower.Since check out is keep finished earlier, may you're back at you like timing.");
            //g = 1094;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, MAN, BG, $"{Girl}~Well ... but, but ... ", OpEf.HidePrev(1));
            //DoC(g, 0, MAN, BG, $"Swallow the word whether it does not have to be done to the end.");
            //DoC(g, 0, MAN, BG, $"And put it in his mouth, it was afraid that become snake.");
            //DoC(g, 0, null, BG, $"Mr. Minato enters the bath, as it is.",
            //    OpEf.HidPrev(2, "W..0>O.B.400.-100*W..0>X.B.400.-300"));
            //AddEffect1($"effect.arc_000020.wav", SoundPauseShort, false);//Effect - shoot door            
            //g = 1095;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, BG, $"{Girl}~... I wonder what it is ... ...", OpEf.HidePrev(1));
            //AddEffect2($"effect.arc_000108.wav", SoundPauseNone, false);//Effect - shower   (also effect.arc_000106.wav)         
            //DoC(g, 0, null, BG, $"I do not quite understand it, but I did not go beyond the last one line.");
            //DoC(g, 0, null, BG, $"While relieving to that, it also makes me uneasy.");
            //DoC(g, 0, null, BG, $"Because I was not sure what Mr. Mito thought.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, BG, $"{Girl}~(Perhaps, I was already satisfied ... ...?)");
            //DoC(g, 0, null, BG, $"I wanted to think so because it was issued twice, but I do not understand well because there is no object compared to except Mr. Kohei.");
            //CurrentSounds.RemoveAll(x => x.Name == "EFFECT2");
            //AddEffect1($"effect.arc_000020.wav", SoundPauseShort, false);//Effect - shoot door
            //DoC(g, 0, null, BG, $"Mr. Mito finishes showering and comes back while I am confused as to what I should do.");
            //MAN = MAN2; posX2 = -50;
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, MAN, BG, $"{Girl}~ ......  ......  ......  ......  ...... ",
            //   OpEf.AppCurr(2, "W..0>O.B.400.100*W..0>X.B.400.300")
            //   );
            //MAN = MAN1; posX2 = -50;
            //DoC(g, 0, MAN, BG, $"And in front of my eyes I changed to a suit again."
            //    , OpEf.HidPrev(2, "W..0000>O.B.400.-100*W..0000>X.B.400.-300")
            //    , OpEf.AppCurr(2, "W..1000>O.B.400.+100*W..1000>X.B.400.+300")
            //   );
            //posX2 = 250;
            //DoC(g, 0, MAN, BG, $"{BadMan}~Well then, I will contact you again.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, MAN, BG, $"{Girl}~ ......  ...... yes ......  ......  ...... ");

            //DoC(g, 0, null, BG, $"And, as it was, he really left the room."
            //    , OpEf.HidPrev(2, "W..0000>O.B.400.-100*W..0000>X.B.400.-300"));
            //AddEffect1($"effect.arc_000020.wav", SoundPauseShort, false);//Effect - shoot door
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, BG, $"{Girl}~Did you finish? truly……?");
            //DoC(g, 0, null, BG, $"While seeing the door where Mr. Mihara disappeared, power came through from the whole body at a stretch.");
            //DoC(g, 0, null, BG, $"I did not understand well before I ended up.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, BG, $"{Girl}~It was good ...");
            //DoC(g, 0, null, BG, $"I was able to survive on day one.");
            //DoC(g, 0, null, BG, $"I do not know what will become of him from tomorrow, but I am filled with a feeling of relief that I just did not go beyond the last one line.");
            //AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            //DoC(g, 0, null, BG, $"{Girl}~Let me take a shower and go home ......");

            //Size2 = 1500; posX2 = 0; posY2 = 0;
            //MAN = "SILKYS_SAKURA_OttoNoInuMaNi_PLACEHOLDER";
            //DoC(g, 0, MAN, BG, $"",
            //    OpEf.AppCurr(2, "W..0>O.B.2000.+100"));

        }
        public void Common_Blowjob_01(Dictionary<string,DifData> Pictures, Dictionary<string, MorfableName> names)
        {
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

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Забыв о {GoodMan.P}, я увлеченно сосала то, что было у меня во рту.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Cлюна стекала с края губ.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"На груди уже было влажное пятно, но я не обращала внимания.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я думала только о том, чтобы заставить {BadMan.R} кончить.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Нужно полностью удовлетворить его ... ...!) ",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Для того, чтобы больше ничего не было,надо все сделать ртом.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.....",
                new List<DifData>() { Pictures["EVENT_0051"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Губы и язык устали, но я продолжала.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan}~Хорошо ... очень хорошо.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Надо еще ......) ",
                new List<DifData>() { Pictures["EVENT_0052"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"По голосу {BadMan.R} и по тому, как напрягся его {Penis}, я поняла, что скоро будет",
                new List<DifData>() { Pictures["EVENT_0052"] });

            DoC2($"И продолжила ласки без остановки.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Вот, еще ......) ",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Из {Penis.R} стало сочиться.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"У меня начала кружиться голова, а все чувства парализовало.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Во рту стало горячо.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Весь мир исчез для меня.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Горький вкус растекался по рту и обжигал язык.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я хотела, чтобы он кончил прямо сейчас.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"Я думала только об этом.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan}~ммммммммм ......",
                new List<DifData>() { Pictures["EVENT_0050"] });

            DoC2($"{BadMan} застонал, а я сильно прижала его {Penis} языком.",
                new List<DifData>() { Pictures["EVENT_0052"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Наверно это было приятно.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.............. ",
                new List<DifData>() { Pictures["EVENT_0052"] });

            DoC2($"Я почувствовала, что конец близко и стала ласкать быстрей.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            DoC2($"Он положил руку мне на голову и стал давить.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Ну давай ......!)",
                new List<DifData>() { Pictures["EVENT_0052"] });

            DoC2($"Рот {BadMan.R} вдруг открылся.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            DoC2($"{BadMan}~...... Я кончаю.",
                new List<DifData>() { Pictures["EVENT_0052"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......",
                new List<DifData>() { Pictures["EVENT_0050"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......",
                new List<DifData>() { Pictures["EVENT_0050"] });
                

            DoC2($"Я почувствовала сильную пульсацию во рту.",
                new List<DifData>() { Pictures["EVENT_0050"] });

            AddEffect1($"effect.arc_000150.wav", SoundPauseShort, false); // effect - splach also effect.arc_000142.wav,144-156,
            DoC2($"Сплат! Сплат! Сплат! Сплат!",
                new List<DifData>() { Pictures["EVENT_0053"],
                new DifData() { Name = "FLASH_BG", O = 0, S = 1370, T = Transitions.Orgazm } }, // orgazm
                new List<OpEf>() { OpEf.HidePrev(1) }                
                );

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~......",
                new List<DifData>() { Pictures["EVENT_0053"] });

            DoC2($"Сперма из {Penis.R} {BadMan.R} стала выплескиваться мощными толчками.",
                new List<DifData>() { Pictures["EVENT_0053"] });

            DoC2($"Ее струи, одна за другой, били мне в горло.",
                new List<DifData>() { Pictures["EVENT_0053"] });

            DoC2($"Приходилось глотать.",
                 new List<DifData>() { Pictures["EVENT_0053"] });

            DoC2($"{Girl}~.........",
                new List<DifData>() { Pictures["EVENT_0054"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Я крепко обхватила губами сильно пульсирующий {Penis}.",
                 new List<DifData>() { Pictures["EVENT_0054"] });

            DoC2($"Первый раз в жизни я принимала эякуляцию прямо в рот, и была поражена  пульсацией.",
                 new List<DifData>() { Pictures["EVENT_0054"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Оооох, какая мощная эякуляция... ....!)",
                new List<DifData>() { Pictures["EVENT_0054"] });

            DoC2($"Я была ошеломлена, не могла двигаться, клейкая масса все наполняла мне рот.",
                 new List<DifData>() { Pictures["EVENT_0054"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.........",
                new List<DifData>() { Pictures["EVENT_0054"] });

            DoC2($"Я старалась не закашляться от спермы",
                 new List<DifData>() { Pictures["EVENT_0054"] });

            DoC2($"Когда рот стал полон, пришлось понемногу проглатывать, чтобы не задохнуться.",
                 new List<DifData>() { Pictures["EVENT_0054"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.........",
                new List<DifData>() { Pictures["EVENT_0055"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Сперма текла даже из носа ",
                 new List<DifData>() { Pictures["EVENT_0055"] });

            DoC2($"Наконец, эякуляция закончилась, и {Penis} был вынут.",
                 new List<DifData>() { Pictures["EVENT_0055"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~.........",
                new List<DifData>() { Pictures["EVENT_0056"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Вкус и запах теплой спермы наполнял мой рот, и я сразу постаралась очистить его.",
                 new List<DifData>() { Pictures["EVENT_0056"] });

            DoC2($"Мое дыхание пахло неприятно.",
                 new List<DifData>() { Pictures["EVENT_0056"] });

            DoC2($"Я быстро сплюнула, много еще оставалось во рту.",
                 new List<DifData>() { Pictures["EVENT_0056"] });

            DoC2($"{BadMan}~Ты правда первый раз приняла в рот? Неплохо.",
                 new List<DifData>() { Pictures["EVENT_0056"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~а ... ... а ... .... а да, было ... ... хорошо ...",
                new List<DifData>() { Pictures["EVENT_0058"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            DoC2($"Еще не получалось восстановить дыхание, но я чувствовала облегчение.",
                 new List<DifData>() { Pictures["EVENT_0058"] });

            DoC2($"Я смогла удовлетворить {BadMan.V}.",
                 new List<DifData>() { Pictures["EVENT_0058"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~...........",
                new List<DifData>() { Pictures["EVENT_0057"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~(Я справилась, все закончилось ... ...)",
                new List<DifData>() { Pictures["EVENT_0057"] });

            DoC2($"Я смогла пройти через это.",
                 new List<DifData>() { Pictures["EVENT_0057"] });

            DoC2($"От того, что я смогла довести {BadMan.V} до эякуляции, на сердце стало легко.",
                 new List<DifData>() { Pictures["EVENT_0057"] });

            DoC2($"И словно в насмешку над моими надеждами, {BadMan} стал раздеваться.",
                 new List<DifData>() { Pictures["EVENT_0057"] });

            DoC2($"{BadMan}~А теперь я тебе сделаю приятно.",
                 new List<DifData>() { Pictures["EVENT_0057"] });

            AddVoice($"voice.arc_000{i++}.ogg", SoundPauseNone, false);
            DoC2($"{Girl}~....., .... ...... ... это .....это не все? ... ...!",
                new List<DifData>() { Pictures["EVENT_0058"] },
                new List<OpEf>() { OpEf.HidePrev(1) });

            ClearSound(true, true, true);
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
