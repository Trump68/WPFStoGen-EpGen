using StoGen.Classes.Transition;
using StoGenerator.Art;
using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenerator.Person;

namespace StoGenerator.Stories
{
    public class Works_Momofuki_Rio : StoryBase
    {
        public static string StoryName = "Momofuki Rio Works";
        protected ART_Momofuki_Rio Art;
        protected override string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=1200;DefTextShift=1000;DefTextWidth=900;DefFontSize=32;DefFontColor=Cyan;DefTextAlignH=3;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 1200; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
        public Works_Momofuki_Rio() : base()
        {
            this.Name = Works_Momofuki_Rio.StoryName;
            this.FileName = this.Name;
            Art = ART_Momofuki_Rio.Load();
            FCurrentPosition.Z = "1";
            FCurrentPosition.S = "1200";
            FCurrentPosition.X = "0";
            FCurrentPosition.Y = "0";
        }
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);
            //MakeTitle();
            FillData();
        }
        protected override void FillData()
        {
            int fs = 32;
            CE_Location.AddWithMusic(this, "Romantic 001", "Cream Satin with Bow", "Печальная тема 01", null);

            for (int i = 1; i <= 83; i++)
            {
                F_Posture = Art.SetFeature(null, $"{Feature.FeatureFigure}{i}", Trans.Dissapearing(1000), Trans.Appearing(1000), true);
                MakeNextCadre(Teller.Female, fs, @"Любимый, наша жизнь теперь сильно изменится.Завтра приезжает мой новый муж, чтобы предъявить свои права на меня.~И ты должен понять.что я могу спариваться только с ним.~~До тех пор, пока я не рожу ему 2 детей, а может и больше, если он так захочет.~~~Теперь мы не сможем видется часто, ведь Уложение Жезла и Браслета гласит что~'Новобрачная Жена всегда должна быть рядом со своим Альфа Супругом и готова для спаривания с ним в любое удобное тому время.'~При том, 'Альфа Супруг должен как можно чаще укладывать Новобрачную Жену на супружеское ложе и наполнять семенем до тех пор, пока она не понесет.'~~~ Милый, я сейчас люблю тебя еще сильнее, ведь ты даришь мне счастье. Я знаю что мы выдержим эти 2 года и будем вместе.");
            }
        }
    }
}
