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
            // prepare standing pose
            p = new SkyrimScene(currStage++, new string[] { "ea939d85-5e08-4226-ae83-eb41f9823282", "2932ceaf-10b5-4a56-a4de-3f115aa8e863" });
            p.Repeatable = false;
            p.Poses[1].X = -100;
            p.Poses[1].rotZ = 180;
            scenes.Add(p);
            //START MOTION

            // head forward eyes left
            p = new SkyrimScene(currStage++, new string[] { "9af61c9a-936a-4b5a-a9fa-8fbd5cd16f55", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true);
            scenes.Add(p);
            // head forward eyes forward
            p = new SkyrimScene(currStage++, new string[] { "9af61c9a-936a-4b5a-a9fa-8fbd5cd16f55", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true, 0);
            scenes.Add(p);
            // head up
            p = new SkyrimScene(currStage++, new string[] { "3d3d4161-0bbf-44d3-bab0-2c57686b2aa9", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // acyclic transfer head
            p = new SkyrimScene(currStage++, new string[] { "e7f77544-57b5-4cf6-9653-1f42ad3cfffd", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Acycle = true;
            p.Timer = 6.7M;
            scenes.Add(p);
            // head down
            p = new SkyrimScene(currStage++, new string[] { "5543ebca-e4d3-42e7-bea1-109f11b2aea5", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // head left eyes left down
            p = new SkyrimScene(currStage++, new string[] { "7bcd82f0-9ee5-4d5f-bded-68ffb335fc5f", "4ba48803-5ed6-411b-b371-249c5e27a461" });
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
                p = new SkyrimScene(currStage++, new string[] { "ea939d85-5e08-4226-ae83-eb41f9823282", "2932ceaf-10b5-4a56-a4de-3f115aa8e863" });
                p.Repeatable = false;
                scenes.Add(p);
            }
            //START MOTION
            // head up
            p = new SkyrimScene(currStage++, new string[] { "3d3d4161-0bbf-44d3-bab0-2c57686b2aa9", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // head down
            p = new SkyrimScene(currStage++, new string[] { "5543ebca-e4d3-42e7-bea1-109f11b2aea5", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            scenes.Add(p);
            // lick
            p = new SkyrimScene(currStage++, new string[] { "e44eadc6-e0b2-40e5-9dee-05ca8f1c6c60", "4d6f3ea2-8583-495d-b2cd-fa9099ab39cd" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.CloseEyes();
            scenes.Add(p);
            // head left eyes left down
            p = new SkyrimScene(currStage++, new string[] { "7bcd82f0-9ee5-4d5f-bded-68ffb335fc5f", "4ba48803-5ed6-411b-b371-249c5e27a461" });
            p.Actor(0).Emotion.SetEmotion(emotion);
            p.Actor(0).Emotion.EyesLeft(true);
            p.Actor(0).Emotion.EyesDown(false);
            scenes.Add(p);
            // lick
            p = new SkyrimScene(currStage++, new string[] { "e44eadc6-e0b2-40e5-9dee-05ca8f1c6c60", "4d6f3ea2-8583-495d-b2cd-fa9099ab39cd" });
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
                p = new SkyrimScene(currStage++, new string[] { "ea939d85-5e08-4226-ae83-eb41f9823282", "2932ceaf-10b5-4a56-a4de-3f115aa8e863" });
                p.Repeatable = false;
                scenes.Add(p);
            }
            //START MOTION
            p = new SkyrimScene(currStage++, new string[] { "f7236838-96e9-4f40-ae24-b9df56f43ffd", "33ec28cf-add3-42a8-bcaf-495b29d825c2" });
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
            p = new SkyrimScene(currStage++, new string[] { "241d5f1b-d839-49c4-8da5-5b1e319bc786", "dc6d9c94-b6f2-4cfd-b68e-c00891363e63" });
            scenes.Add(p);
            p = new SkyrimScene(currStage++, new string[] { "e656a5f1-6fe9-42b5-af24-8c95b3649c95", "dc6d9c94-b6f2-4cfd-b68e-c00891363e63" });
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
            p = new SkyrimScene(currStage++, new string[] { "9e63d179-35b4-4804-b7be-841526c8c0c7", "9a8d3d91-bc47-480c-b1e2-233c875fd78a" });
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
            p = new SkyrimScene(currStage++, new string[] { "eaf748ae-236b-4141-9269-fb2b6fce755c", "2d82a3f4-a4d4-48ba-9dcd-e73cd70ba04c" });
            scenes.Add(p);
            p = new SkyrimScene(currStage++, new string[] { "0d9b3b87-b000-4e1d-9c7d-f950cddaaae4", "2d82a3f4-a4d4-48ba-9dcd-e73cd70ba04c" });
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
