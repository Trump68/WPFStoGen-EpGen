using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public static partial class Skyrim
    {

        #region Standart motions   
     
        #region Leito Leito_69
        private static bool LeitiAnimations_Leito_69()
        {
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            scenes.AddRange(LeitoAnimations_Leito_69_stage_01(false, scenes.Count() + 1));                // stage 1            
            scenes.AddRange(LeitoAnimations_Leito_69_stage_02(false, scenes.Count() + 1));  // stage 2            
            scenes.AddRange(LeitoAnimations_Leito_69_stage_03(false, scenes.Count() + 1));  // stage 3            
            scenes.AddRange(LeitoAnimations_Leito_69_stage_04(false, scenes.Count() + 1));  // stage 4
            scenes.AddRange(LeitoAnimations_Leito_69_stage_05(false, scenes.Count() + 1));  // stage 4
            foreach (var scen in scenes)
            {
                scen.CopyToDestination();
            }
            RebuildScript(scenes);
            return true;
        }

        private static List<SkyrimScene> LeitoAnimations_Leito_69_stage_01(bool complete, int stageStart = 1, Emotion emotion = Emotion.None)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            int sos = 2;
            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //START MOTION

            // head forward eyes left
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v01, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true);
            scenes.Add(p);
            // head forward eyes forward
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v01, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true, 0);
            scenes.Add(p);
            // head up
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v02, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // acyclic transfer head
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v03, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Acycle = true;
            p.Timer = 6.7M;
            scenes.Add(p);
            // head down
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v04, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // head left eyes left down
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v05, Pose.Leito.SixNine_M01 });
            p.Actor(1).SOS = sos;
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true);
            p.Actor(0).Emotion.EyesDown(false);
            scenes.Add(p);


            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_69_stage_02(bool complete, int stageStart = 1, Emotion emotion = Emotion.None)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            if (complete)
            {
                // prepare standing pose
                p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
                p.Repeatable = false;
                scenes.Add(p);
            }
            //START MOTION
            // head up
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v02, Pose.Leito.SixNine_M01 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // head down
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v04, Pose.Leito.SixNine_M01 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // lick
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F02_v01, Pose.Leito.SixNine_M02 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.CloseEyes();
            scenes.Add(p);
            // head left eyes left down
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F01_v05, Pose.Leito.SixNine_M01 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true);
            p.Actor(0).Emotion.EyesDown(false);
            scenes.Add(p);
            // lick
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F02_v01, Pose.Leito.SixNine_M02 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.CloseEyes();
            scenes.Add(p);
            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_69_stage_03(bool complete, int stageStart = 1, Emotion emotion = Emotion.None)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            if (complete)
            {
                // prepare standing pose
                p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
                p.Repeatable = false;
                scenes.Add(p);
            }
            //START MOTION
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F03_v01, Pose.Leito.SixNine_M03 });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.OpenMoutn();
            scenes.Add(p);
            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_69_stage_04(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F03_v02, Pose.Leito.SixNine_M04 });
            scenes.Add(p);
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F04_v01, Pose.Leito.SixNine_M04 });
            scenes.Add(p);
            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_69_stage_05(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            p = new SkyrimScene(currStage++, new string[] { Pose.Leito.SixNine_F05_v01, Pose.Leito.SixNine_M05 });
            scenes.Add(p);
            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }

        #endregion
        
        #region Leito Anal Doggy 2

        private static bool Movie_Leito_AnalDoggy2()
        {
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            scenes.AddRange(ScenGenerate_Leito_AnalDoggy2_stage_01(false, 1));                // stage 1    
            SkyrimScene p;
            p = new SkyrimScene(scenes.Count + 1, new string[] { "910cba42-1eda-4c71-9a8f-84994d07ceea", "64e9ddea-ed26-4339-b298-16ac694d1939" });
            scenes.Add(p);
            p = new SkyrimScene(scenes.Count + 1, new string[] { "193e8465-4e8a-4696-b520-df54784329f9", "52d545ba-3c78-42fd-8efa-c4bd78e0081d" });
            scenes.Add(p);
            p = new SkyrimScene(scenes.Count + 1, new string[] { "20b26dc0-6133-4821-a6bd-0662e8598149", "42aeae85-5d68-4cad-bea1-6836603a0f14" });
            scenes.Add(p);
            p = new SkyrimScene(scenes.Count + 1, new string[] { "4d1da02e-74cd-4da8-97e8-4402c625fc83", "b760614c-dd23-43ab-8948-c669ee3fd036" });
            scenes.Add(p);            
            foreach (var pose in scenes)
            {
                pose.CopyToDestination();
            }
            RebuildScript(scenes);
            return true;
        }
        private static List<SkyrimScene> ScenGenerate_Leito_AnalDoggy2_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            p = new SkyrimScene(currStage++, new string[] { "eaf748ae-236b-4141-9269-fb2b6fce755c", Pose.Leito.AnalDoggy2_M01 });
            scenes.Add(p);
            p = new SkyrimScene(currStage++, new string[] { "0d9b3b87-b000-4e1d-9c7d-f950cddaaae4", Pose.Leito.AnalDoggy2_M01 });
            scenes.Add(p);   
            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }

        #endregion

        #region Leito Anal Missionary
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "3fad1d78-c644-4ff6-970d-30eabe10550a", "7b843aea-2251-4fbc-b0d5-76c666e7a842" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary_stage_02(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "2b7229f7-6dc8-4204-80dd-49ea6bbf9256", "9f7e918c-6418-44b8-ae51-010e6c96562a" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary_stage_03(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "b58e6b82-20a5-44c8-b1de-9da3014ba26a", "cb17f2f2-d0ae-4e42-9a2f-c606228f9c33" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary_stage_04(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
           
            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "c178dbb3-6705-4c2e-bc91-397431cf3715", "f4414fcc-f348-4cb4-9620-c6166a3cafdf" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary_stage_05(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "75536ca4-6c8d-4617-9b52-03af7f5b7f46", "bab68dd5-9e0d-4578-8a4c-3776a5698d5e" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        #endregion

        #region Leito Anal Missionary 2
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary2_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "55115332-2981-41f9-bd90-25fedeffc099", "57abbbdf-88f6-4bd1-ba92-887e5c31a034" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary2_stage_02(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "c10f53be-3654-43f0-b5a8-17ee7a5bb09c", "08c9dff4-930a-4426-ae76-c4711bb3df05" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary2_stage_03(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "cbaf2f46-3c70-4d65-bea3-ad326ad660ad", "2df40ea0-9d17-4859-95c0-315bcffbcfd9" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary2_stage_04(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "56917e59-1ce2-49c9-8493-324d020301db", "f209ebf8-0d19-4f7e-8456-3db983f4b581" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Missionary2_stage_05(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "cab3d358-1b9a-4772-a68a-505e5d08e558", "b905a26d-d594-4a6c-8dda-e75d752ede58" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        #endregion


        #region Leito Anal Powerbomb
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Powerbomb_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "7161d04b-c8b2-47d1-826a-51b164ff9a97", "cfec8971-1db8-47fc-9d43-605badd0d465" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Powerbomb_stage_02(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "b6711b4f-2f5a-4c10-a8a6-43c5a59beea7", "028af9a2-6176-4667-8f87-63b77ca5c5f2" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Powerbomb_stage_03(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "2629c136-914d-4886-bad7-2b82a15d3eb7", "40060b25-1f7d-43cf-bccd-3f9ebe929839" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Powerbomb_stage_04(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "4947dca4-3726-4348-860e-b92addbf6c8c", "0134626b-bf7b-47d6-97db-56b97c72a5f8" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static List<SkyrimScene> LeitoAnimations_Leito_Anal_Powerbomb_stage_05(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;

            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { Pose.MKPoser.F01_MK1P03_a, Pose.PinupPoser.M01_PinupsMStand1 });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //

            p = new SkyrimScene(currStage++, new string[] { "1ac6b17a-b5ce-464d-ab17-24572e216c9e", "3113209c-21e3-42e3-a4ce-c9d27ec7bd32" });
            p.Poses[1].SOS = -8;
            scenes.Add(p);

            if (complete)
            {
                foreach (var scen in scenes)
                {
                    scen.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        #endregion

        #endregion

    }
}
