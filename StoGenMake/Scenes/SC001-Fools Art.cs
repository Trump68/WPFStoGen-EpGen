using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenMake.GameWorld;

namespace StoGenMake.Scenes.Base
{
    public class SC001_FoolsArt : BaseScene
    {

        public SC001_FoolsArt() : base()
        {
            Name = "Fools Art (Homare)";
            EngineHiVer = 1;
            EngineLoVer = 0;

        }

        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
        }
        public static string Path = @"z:\ARTIST\FoolsArt (Homare)\Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~\";
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            //#region Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~
            string path = null;
            path = Path; 
            //path = @"D:\Temp\";
            string src = null;
            string fn = null;
            string gr = null;

            #region Raw data
            for (int i = 1; i <= 141; i++)
            {
                src = $"LADY_Body_1710082{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { sX = 800, sY = 800 });
                AddLocal(new string[] { "All raw data", $"Raw pic {i.ToString("D3")}" }, new DifData[] { new DifData(src) });
            }
            #endregion

            #region Evils data
            Ga01_Evils(path);
            #endregion

            #region Mouth
            Ga02_Mouth(path);
            #endregion

            #region Heads
            Ga03_Heads(path);
            #endregion

            #region Other Lady Staff
            Ga04_OtherLadyStaff(path);
            #endregion
            
            #region Posing legs parted
            La01_PosingLegsParted(path);
            #endregion

            #region Fuck doggy
            La02_FuckDoggy(path);
            #endregion

            La03_FuckMissionare(path);

            La04_OralOnKnees(path);

            La05_OralOnKneesFace(path);

            La06_OralOnKneesAnal(path);

            La07_GroupingTits(path);

            La08_DoggyFace(path);

            La09_DoggyTreesome(path);
        }
        private void Ga01_Evils(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;

            // Evil Body
           
            src = $"FullsArt_NetorareTsuma_EvilManBody_002"; fn = $"EVIL_BODY_02.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil b 02" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_EvilManBody_003"; fn = $"EVIL_BODY_03.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil b 03" }, new DifData[] { new DifData(src) });

            // Evil Head
            src = $"FullsArt_NetorareTsuma_EvilManHead_001"; fn = $"EVIL_HEAD_01.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil h 01" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_EvilManHead_002"; fn = $"EVIL_HEAD_02.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil h 02" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_EvilManHead_003"; fn = $"EVIL_HEAD_03.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil h 03" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_EvilManHead_004"; fn = $"EVIL_HEAD_04.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil h 04" }, new DifData[] { new DifData(src) });


            // Evil Hands
            src = $"FullsArt_NetorareTsuma_EvilManHands_001"; fn = $"HANDS_01.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil hand 01" }, new DifData[] { new DifData(src) });


            // Evil Pot
            src = $"FullsArt_NetorareTsuma_EvilManPot_001"; fn = $"EVIL_POT_01.png";
            AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All evils", $"Evil pot 01" }, new DifData[] { new DifData(src) });

        }
        private void Ga04_OtherLadyStaff(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;

            // Panty
            src = $"FullsArt_NetorareTsuma_LadyPanty_001"; fn = $"PANTY_01.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All panty", $"Panty 01" }, new DifData[] { new DifData(src) });


            src = $"FullsArt_NetorareTsuma_LadyPanty_002"; fn = $"PANTY_02.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { "All panty", $"Panty 02" }, new DifData[] { new DifData(src) });

        }
        private void Ga02_Mouth(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
        //Z:\ARTIST\FoolsArt(Homare)\Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~\MOUTH_01.png
       // Mouth

            src = $"FullsArt_NetorareTsuma_LadyMouth_002"; fn = $"MOUTH_02.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 02" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyMouth_003"; fn = $"MOUTH_04.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 03" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyMouth_004"; fn = $"MOUTH_05.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 04" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyMouth_005"; fn = $"MOUTH_06.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 05" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyMouth_006"; fn = $"MOUTH_07.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 06" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyMouth_007"; fn = $"MOUTH_08.png"; AddToGlobalImage(src, fn, path, new DifData() { s = 100 });
            AddLocal(new string[] { "All moutn", $"Mouth 07" }, new DifData[] { new DifData(src) });

        }
        private void Ga03_Heads(string path)
        {
            // Heads
            string src = null;
            string fn = null;
            string gr = null;

            src = $"FullsArt_NetorareTsuma_LadyHead_001"; fn = $"003_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 01" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 01 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });
            AddGlobal(new string[] { gr, "Head 02 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_002", src) });
            AddGlobal(new string[] { gr, "Head 03 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_003", src) });
            AddGlobal(new string[] { gr, "Head 04 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_004", src) });
            AddGlobal(new string[] { gr, "Head 05 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_005", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_002"; fn = $"002_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 06" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_003"; fn = $"004_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 07" }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_004"; fn = $"005_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 08" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 08 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_005"; fn = $"006_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 09" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 09 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_006"; fn = $"007a_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 10" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 10 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });
            AddGlobal(new string[] { gr, "Head 10 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_007", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_007"; fn = $"007b_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 11" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 11 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });
            AddGlobal(new string[] { gr, "Head 11 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_007", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_008"; fn = $"007c_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 12" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 12 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });
            AddGlobal(new string[] { gr, "Head 12 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_007", src) });

            src = $"FullsArt_NetorareTsuma_LadyHead_009"; fn = $"008_head.png"; gr = "All heads"; AddToGlobalImage(src, fn, path, new DifData() { s = 500 });
            AddLocal(new string[] { gr, $"Head 13" }, new DifData[] { new DifData(src) });
            AddGlobal(new string[] { gr, "Head 13 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_001", src) });
            AddGlobal(new string[] { gr, "Head 13 combo align" },
                      new DifData[] { new DifData(src), new DifData("FullsArt_NetorareTsuma_LadyMouth_007", src) });

        }
        private void La01_PosingLegsParted(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_PosingLegsParted";

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_003"; fn = $"003.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_004"; fn = $"003a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_005"; fn = $"003b.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_006"; fn = $"003c.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_007"; fn = $"003d.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_008"; fn = $"003e.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_009"; fn = $"003f.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_010"; fn = $"003g.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_011"; fn = $"003h.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_PosingLegsParted_012"; fn = $"003j.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

        }
        private void La02_FuckDoggy(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_FuckDoggy";

            src = $"FullsArt_NetorareTsuma_FuckDoggy_001"; fn = $"018.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckDoggy_002"; fn = $"018a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckDoggy_003"; fn = $"018b.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckDoggy_004"; fn = $"018c.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckDoggy_005"; fn = $"018d.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckDoggy_006"; fn = $"018e.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
        }

        private void La03_FuckMissionare(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_FuckMissionare";

            src = $"FullsArt_NetorareTsuma_FuckMissionare_001"; fn = $"024a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckMissionare_002"; fn = $"025a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckMissionare_003"; fn = $"026a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_FuckMissionare_004"; fn = $"027a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
        }

        private void La04_OralOnKnees(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_OralOnKnees";

            src = $"FullsArt_NetorareTsuma_OralOnKnees_001"; fn = $"028.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKnees_002"; fn = $"029.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKnees_003"; fn = $"034.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKnees_004"; fn = $"035.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });            
        }


        private void La05_OralOnKneesFace(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_OralOnKneesFace";

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_001"; fn = $"041.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_002"; fn = $"042.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_003"; fn = $"043.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_004"; fn = $"044.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_005"; fn = $"045.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesFace_006"; fn = $"046.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
        }

        private void La06_OralOnKneesAnal(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_OralOnKneesAnal";

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_001"; fn = $"031.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_002"; fn = $"032.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_003"; fn = $"033.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_004"; fn = $"034.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_005"; fn = $"035.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_006"; fn = $"036.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_007"; fn = $"037.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_008"; fn = $"038.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_OralOnKneesAnal_009"; fn = $"039.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
        }


        private void La07_GroupingTits(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_GroupingTits";

            src = $"FullsArt_NetorareTsuma_GroupingTits_001"; fn = $"047a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_GroupingTits_002"; fn = $"047.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_GroupingTits_003"; fn = $"048.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });            
        }

        private void La08_DoggyFace(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_DoggyFace";

            src = $"FullsArt_NetorareTsuma_DoggyFace_001"; fn = $"049.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_DoggyFace_002"; fn = $"050.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_DoggyFace_003"; fn = $"051.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_DoggyFace_004"; fn = $"052.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_DoggyFace_005"; fn = $"060.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
        }

        private void La09_DoggyTreesome(string path)
        {
            string src = null;
            string fn = null;
            string gr = null;
            int ss = 995;

            gr = "NetorareTsuma_DoggyTreesome";

            src = $"FullsArt_NetorareTsuma_DoggyTreesome_001"; fn = $"070.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });

            src = $"FullsArt_NetorareTsuma_DoggyTreesome_002"; fn = $"071.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });            
        }
    }
}
