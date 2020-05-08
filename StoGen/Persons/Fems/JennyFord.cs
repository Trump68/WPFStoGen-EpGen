using StoGen.Classes;
using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGen.Classes.Scene;
using StoGenerator.Stories;
using StoGen.Classes.Persons;

namespace StoGenerator.Persons
{
    public class JennyFord : Person //Kazoku ~Haha To Shimai No Kyousei~
    {
        public enum JennyFord_Eyes
        {
            Eyes2_78,
            Eyes1_70,
            Eyes1_67,
            Eyes1_68,
            Eyes1_69,
            Eyes1_71,
            Eyes1_72,
            Eyes1_73,
            Eyes1_74,
            Eyes1_75,
            Eyes1_76,
            Eyes1_77,
            EyesBlink1,
            EyesBlink2,
            Eyes2_80,
            Eyes2_83,
            Eyes2_81,
            Eyes2_84,
            Eyes2_79,
            Eyes2_82,
            Eyes2_85,
            Eyes2_87,
            Eyes2_86,
            Eyes2_88,
        }
        public enum JennyFord_Mouth
        {
            Mouth2_78,
            Mouth1_70,
            Mouth1_67,
            Mouth1_68,
            Mouth1_71,
            Mouth1_69,
            Mouth1_72,
            Mouth1_74,
            Mouth1_73,
            Mouth1_75,
            Mouth1_77,
            Mouth1_76,
            Mouth2_79,
            Mouth2_80,
            Mouth2_81,
            Mouth2_83,
            Mouth2_84,
            Mouth2_85,
            Mouth2_82,
            Mouth2_86,
            Mouth2_88,
            Mouth2_87
        }

        public JennyFord() : base()
        {
            ImagePath = @"e:\!STOGENDB\READY\CHR\F\JennyFord\";
            Name = "Jenny Ford";
            Tribe = "Kazoku ~Haha To Shimai No Kyousei~";
            Age = 36;
            Sex = 'F';
        }
        public static JennyFord Load()
        {
            JennyFord person = new JennyFord();

            person.Positions.Add(new Info_Scene() { S = "1200", X = "400", Y = "70", Z = "1", Story = "Default" });

            int i = 1;
            
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{OutfitName.OutfitHome_I}", $@"{person.ImagePath}DefaultHome_I_1.png", "Вечерний домашний наряд - халатик", "1", person.Name)); ++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{OutfitName.OutfitDressing_I}", $@"{person.ImagePath}DefaultHome_I_2.png", "Вечерний домашний наряд - халатик", "2", person.Name)); ++i;

            person.Files.Add(new ItemData($"{FaceName.FaceSmile_I}", $@"{Eyes.EyesVar}{67},{Mouth.MouthVar}{67},{Feature.FeatureBlink}{1}", "По умолчанию", "1", person.Name)); ++i;
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.MouthVar}{67}", $@"{person.ImagePath}Mouth_1_067.png", null, $"1", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.EyesVar}{67}", $@"{person.ImagePath}Eyes_1_067.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlinkGeneric},{Feature.FeatureBlink}{1}", $@"{person.ImagePath}Eyes_1_blink1.png", null, $"{Poses.Pose}{1}", person.Name));

            person.Files.Add(new ItemData($"{FaceName.FaceNeitral_I}", $@"{Eyes.EyesVar}{68},{Mouth.MouthVar}{68},{Feature.FeatureBlink}{2}", "По умолчанию", "2", person.Name)); ++i;
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{Mouth.MouthVar}{68}", $@"{person.ImagePath}Mouth_2_068.png", null, $"2", person.Name));            
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{Eyes.EyesVar}{68}", $@"{person.ImagePath}Eyes_2_068.png", null, $"2", person.Name));

            

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}", $@"{person.ImagePath}Figure001_1.png", "Голая", "Поза 1",person.Name)); ++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1}",
                "Соски", "Поза 1,голая",person.Name)); ++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1}",
                "Соски,обр.кольцо(г)", "Поза 1,голая", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                 $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PubicNormal}{1}",
                "Соски,обр.кольцо(г), pubic 1", "Поза 1,голая", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{1}",
                "Соски,обр.кольцо(г),трусики 1(кружева)", "Поза 1,в трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{2}",
                "Соски,обр.кольцо(г),трусики 2(бикини)", "Поза 1,в трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{3}",
                "Соски,обр.кольцо(г),трусики 3(кружева)", "Поза 1,в трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{4}",
                "Соски,обр.кольцо(г),трусики 4(кружева)", "Поза 1,в трусиках", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{1},{Feature.BluseNormal}{1}",
                "Обр.кольцо(г),трусики 1(кружева),блузка 1", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{2},{Feature.BluseNormal}{1}",
                "Обр.кольцо(г),трусики 2(бикини),блузка 1", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{3},{Feature.BluseNormal}{1}",
                "Обр.кольцо(г),трусики 3(кружева),блузка 1", "Поза 1,в трусиках и блузке", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{1},{Feature.BluseNormal}{2}",
                "Обр.кольцо(г),трусики 1(кружева),блузка 2", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{2},{Feature.BluseNormal}{2}",
                "Обр.кольцо(г),трусики 2(бикини),блузка 2", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{3},{Feature.BluseNormal}{2}",
                "Обр.кольцо(г),трусики 3(кружева),блузка 2", "Поза 1,в трусиках и блузке", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                           $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{1},{Feature.BluseNormal}{3}",
                           "Обр.кольцо(г),трусики 1(кружева),блузка 3", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{2},{Feature.BluseNormal}{3}",
                "Обр.кольцо(г),трусики 2(бикини),блузка 3", "Поза 1,в трусиках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalPanty}{3},{Feature.BluseNormal}{3}",
                "Обр.кольцо(г),трусики 3(кружева),блузка 3", "Поза 1,в трусиках и блузке", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{1}",
                "Соски,обр.кольцо(г),колготки 1", "Поза 1,в колготках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{2}",
                "Соски,обр.кольцо(г),колготки 2", "Поза 1,в колготках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{3}",
                "Соски,обр.кольцо(г),колготки 3", "Поза 1,в колготках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{4}",
                "Соски,обр.кольцо(г),колготки 4", "Поза 1,в колготках", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                           $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{1},{Feature.BluseNormal}{2}",
                           "Обр.кольцо(г),колготки 1,блузка 2", "Поза 1,в колготках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                           $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{2},{Feature.BluseNormal}{2}",
                           "Обр.кольцо(г),колготки 2,блузка 2", "Поза 1,в колготках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                           $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{3},{Feature.BluseNormal}{2}",
                           "Обр.кольцо(г),колготки 3,блузка 2", "Поза 1,в колготках и блузке", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                           $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.PantyhoseNormal}{4},{Feature.BluseNormal}{2}",
                           "Обр.кольцо(г),колготки 4,блузка 2", "Поза 1,в колготках и блузке", person.Name));++i;


            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{1}",
                "Обр.кольцо(г),бра 1(кружева)", "Поза 1,в бра", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{2}",
                "Обр.кольцо(г),бра 2(бикини)", "Поза 1,в бра", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{3}",
                "Обр.кольцо(г),бра 3(кружева)", "Поза 1,в бра", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{4}",
                "Обр.кольцо(г),бра 4(кружева)", "Поза 1,в бра", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{1},{Feature.PantyhoseNormal}{1},{Feature.SkirtNormal}{1},{Feature.ShoesNormal}{1}",
                "Обр.кольцо(г),бра 4(кружева),колготки 1, юбка 1, туфли 1", "Поза 1,в бра, колготках и юбке, туфли 1", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{1},{Feature.PantyhoseNormal}{2},{Feature.SkirtNormal}{1},{Feature.ShoesNormal}{1}",
                "Обр.кольцо(г),бра 4(кружева),колготки 2, юбка 1, туфли 1", "Поза 1,в бра, колготках и юбке, туфли 1", person.Name));++i;

            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{1},{Feature.NormalPanty}{1}",
                "Обр.кольцо(г),бра,трусики 1(кружева)", "Поза 1,в бра и трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{2},{Feature.NormalPanty}{2}",
                "Обр.кольцо(г),бра,трусики 2(бикини)", "Поза 1,в бра и трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{3},{Feature.NormalPanty}{3}",
                "Обр.кольцо(г),бра,трусики 3(кружева)", "Поза 1,в бра и трусиках", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.WeddingRing}{1},{Feature.NormalBra}{4},{Feature.NormalPanty}{4}",
                "Обр.кольцо(г),бра,трусики 4(кружева)", "Поза 1,в бра и трусиках", person.Name));++i;


            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PregnantTammy}{1}",
                "Соски,обр.кольцо(г)", "Поза 1,беременная,голая", person.Name));++i;
            person.Files.Add(new ItemData($"{Generic.FigureGeneric},{Feature.FeatureFigure}{i}",
                $@"{Feature.FeatureFigure}{1},{Feature.FeatureNipples}{1},{Feature.WeddingRing}{1},{Feature.PregnantTammy}{1},{Feature.PregnantPanty}{1}",
                "Соски,обр.кольцо(г),трусики 1(кружева)", "Поза 1,беременная,в трусиках", person.Name));++i;



            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.NipplesGeneric},{Feature.FeatureNipples}{1}", $@"{person.ImagePath}Nipple001_1.png", "Соски 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.WeddingRingGeneric},{Feature.WeddingRing}{1}", $@"{person.ImagePath}FingerRing001_1.png", "Кольцо обручальное", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PregnantTammyGeneric},{Feature.PregnantTammy}{1}", $@"{person.ImagePath}PregnantTammyNaked001_1.png", "Животик 1 (прег)", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyGeneric},{Feature.PregnantPanty}{1}", $@"{person.ImagePath}PregnantPanty001_1.png", "Трусики 1 (прег)", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyGeneric},{Feature.NormalPanty}{1}", $@"{person.ImagePath}Panty001_1.png", "Трусики 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyGeneric},{Feature.NormalPanty}{2}", $@"{person.ImagePath}Panty002_1.png", "Трусики 2", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyGeneric},{Feature.NormalPanty}{3}", $@"{person.ImagePath}Panty003_1.png", "Трусики 3", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyGeneric},{Feature.NormalPanty}{4}", $@"{person.ImagePath}Panty004_1.png", "Трусики 4", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BraGeneric},{Feature.NormalBra}{1}", $@"{person.ImagePath}Bra001_1.png", "Бра 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BraGeneric},{Feature.NormalBra}{2}", $@"{person.ImagePath}Bra002_1.png", "Бра 2", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BraGeneric},{Feature.NormalBra}{3}", $@"{person.ImagePath}Bra003_1.png", "Бра 3", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BraGeneric},{Feature.NormalBra}{4}", $@"{person.ImagePath}Bra004_1.png", "Бра 4", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyhoseGeneric},{Feature.PantyhoseNormal}{1}", $@"{person.ImagePath}Pantyhose001_1.png", "Колготки 1 черные", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyhoseGeneric},{Feature.PantyhoseNormal}{2}", $@"{person.ImagePath}Pantyhose002_1.png", "Колготки 2", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyhoseGeneric},{Feature.PantyhoseNormal}{3}", $@"{person.ImagePath}Pantyhose003_1.png", "Колготки 3", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PantyhoseGeneric},{Feature.PantyhoseNormal}{4}", $@"{person.ImagePath}Pantyhose004_1.png", "Колготки 4", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BluseGeneric},{Feature.BluseNormal}{1}", $@"{person.ImagePath}Bluse001_1.png", "Блузка 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BluseGeneric},{Feature.BluseNormal}{2}", $@"{person.ImagePath}Bluse002_1.png", "Блузка 2", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BluseGeneric},{Feature.BluseNormal}{3}", $@"{person.ImagePath}Bluse003_1.png", "Блузка 3", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.SkirtGeneric},{Feature.SkirtNormal}{1}", $@"{person.ImagePath}Skirt001_1.png", "Юбка 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.ShoesGeneric},{Feature.ShoesNormal}{1}", $@"{person.ImagePath}Shoes001_1.png", "Туфли 1", $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.PubicGeneric},{Feature.PubicNormal}{1}", $@"{person.ImagePath}Pubic001_1.png", "Pubic 1", $"{Poses.Pose}{1}", person.Name));





            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_67}", $@"{person.ImagePath}Mouth_1_067.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_68}", $@"{person.ImagePath}Mouth_1_068.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_69}", $@"{person.ImagePath}Mouth_1_069.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_70}", $@"{person.ImagePath}Mouth_1_070.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_71}", $@"{person.ImagePath}Mouth_1_071.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_72}", $@"{person.ImagePath}Mouth_1_072.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_73}", $@"{person.ImagePath}Mouth_1_073.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_74}", $@"{person.ImagePath}Mouth_1_074.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_75}", $@"{person.ImagePath}Mouth_1_075.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_76}", $@"{person.ImagePath}Mouth_1_076.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth1_77}", $@"{person.ImagePath}Mouth_1_077.png", null, $"{Poses.Pose}{1}", person.Name));


            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_67}", $@"{person.ImagePath}Eyes_1_067.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_68}", $@"{person.ImagePath}Eyes_1_068.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_69}", $@"{person.ImagePath}Eyes_1_069.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_70}", $@"{person.ImagePath}Eyes_1_070.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_71}", $@"{person.ImagePath}Eyes_1_071.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_72}", $@"{person.ImagePath}Eyes_1_072.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_73}", $@"{person.ImagePath}Eyes_1_073.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_74}", $@"{person.ImagePath}Eyes_1_074.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_75}", $@"{person.ImagePath}Eyes_1_075.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_76}", $@"{person.ImagePath}Eyes_1_076.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes1_77}", $@"{person.ImagePath}Eyes_1_077.png", null, $"{Poses.Pose}{1}", person.Name));

            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlinkGeneric},{Feature.FeatureBlink}{1}", $@"{person.ImagePath}Eyes_1_blink1.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1}", $@"{person.ImagePath}Blush_1_001.png", null, $"{Poses.Pose}{1}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlinkGeneric},{JennyFord_Eyes.EyesBlink2}", $@"{person.ImagePath}Eyes_2_blink1.png", null, $"{Poses.Pose}{2}", person.Name));

            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_78}", $@"{person.ImagePath}Mouth_2_078.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_79}", $@"{person.ImagePath}Mouth_2_079.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_80}", $@"{person.ImagePath}Mouth_2_080.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_81}", $@"{person.ImagePath}Mouth_2_081.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_82}", $@"{person.ImagePath}Mouth_2_082.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_83}", $@"{person.ImagePath}Mouth_2_083.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_84}", $@"{person.ImagePath}Mouth_2_084.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_85}", $@"{person.ImagePath}Mouth_2_085.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_86}", $@"{person.ImagePath}Mouth_2_086.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_87}", $@"{person.ImagePath}Mouth_2_087.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.MouthGeneric},{JennyFord_Mouth.Mouth2_88}", $@"{person.ImagePath}Mouth_2_088.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_78}", $@"{person.ImagePath}Eyes_2_078.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_79}", $@"{person.ImagePath}Eyes_2_079.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_80}", $@"{person.ImagePath}Eyes_2_080.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_81}", $@"{person.ImagePath}Eyes_2_081.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_82}", $@"{person.ImagePath}Eyes_2_082.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_83}", $@"{person.ImagePath}Eyes_2_083.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_84}", $@"{person.ImagePath}Eyes_2_084.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_85}", $@"{person.ImagePath}Eyes_2_085.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_86}", $@"{person.ImagePath}Eyes_2_086.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_87}", $@"{person.ImagePath}Eyes_2_087.png", null, $"{Poses.Pose}{2}", person.Name));
            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.EyesGeneric},{JennyFord_Eyes.Eyes2_88}", $@"{person.ImagePath}Eyes_2_088.png", null, $"{Poses.Pose}{2}", person.Name));

            person.Files.Add(new ItemData($"{Generic.FeatureGeneric},{Generic.BlushGeneric},{Feature.FeatureBlush}{1}", $@"{person.ImagePath}Blush_1_001.png", null, $"{Poses.Pose}{1}", person.Name));

            return person;
        }



     
        public List<Info_Scene> AddBlink(List<Info_Scene> posture, JennyFord_Eyes eyes, Info_Scene position)
        {
            //Poses pose = (!posture.Any() || posture.First().Tags.Contains($"{Poses.Pose}{1}")) ? Poses.Stand1 : Poses.Stand2;
            posture = base.AddBlink(posture, eyes.ToString(), position);
            posture.Last().O = "100";
            return posture;
        }
        internal List<Info_Scene> Blush(List<Info_Scene> posture, Info_Scene position, bool reverse = false, int? speed = null)
        {
            //Poses pose = (!posture.Any() || posture.First().Tags.Contains(Poses.Stand1.ToString())) ? Poses.Stand1 : Poses.Stand2;
            string transition = null;
            if (speed.HasValue)
            {
                transition = Trans.Appearing(speed.Value);
                if (reverse)
                    transition = Trans.Dissapearing(speed.Value);
            }
            posture = SetFeature(posture, Feature.FeatureBlush.ToString() + "1", null, transition, false, position);
            posture.Last().O = "0";
            if (reverse)
            {
                posture.Last().O = "100";
            }
            return posture;
        }
        internal List<Info_Scene> RemoveBlush(List<Info_Scene> posture)
        {
            posture.RemoveAll(x => x.Tags.Contains(Feature.FeatureBlush.ToString() + "1"));
            return posture;
        }


        public override List<Tuple<string, string>> GetAllFaceCombinations()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            for (int m = 67; m <= 77; m++)
            {
                for (int y = 67; y <= 77; y++)
                {
                    list.Add(new Tuple<string, string>($"Mouth1_{m}", $"Eyes1_{y}"));
                }
            }
            return list;
        }
    }
}
