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
        private static bool Movie_Leito_69()
        {
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01(false, poses.Where(x => x.Position == 1).Count() + 1));                // stage 1            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_02(false, poses.Where(x => x.Position == 1).Count() + 1));  // stage 2            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_03(false, poses.Where(x => x.Position == 1).Count() + 1));  // stage 3            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_04(false, poses.Where(x => x.Position == 1).Count() + 1));  // stage 4
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_05(false, poses.Where(x => x.Position == 1).Count() + 1));  // stage 4
            foreach (var pose in poses)
            {
                pose.CopyToDestination();
            }
            poses.Where(x => x.Label == "Stage1" && x.Position == 1).ToList().ForEach(x => x.Emotion.EyesLeft(true));
            poses.Where(x => x.Label == "Stage2" && x.Position == 1).ToList().ForEach(x => x.Emotion.OpenMoutn());
            poses.Where(x => x.Label == "Stage3" && x.Position == 1).ToList().ForEach(x => x.Emotion.CloseEyes());
            RebuildScript(poses);
            return true;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.AddRange(StageGenerate(false, currStage, new string[] { "ea939d85-5e08-4226-ae83-eb41f9823282", "64e9ddea-ed26-4339-b298-16ac694d1939" }));  // stage 2            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_01(poses.Where(x => x.Position == 1).Count() + 1));           
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_02(poses.Where(x=> x.Position == 1).Count()  + 1));                       
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_03(poses.Where(x => x.Position == 1).Count() + 1));            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_04(poses.Where(x => x.Position == 1).Count() + 1));
            poses.ForEach(x => x.Label = "Stage1");
            
            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_02(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_02_00(currStage));
            poses.ForEach(x => x.Label = "Stage2");
            currStage++;
            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_03(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_03_00(currStage));
            poses.ForEach(x => x.Label = "Stage3");

            currStage++;
            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_04(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_04_01(currStage));
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_04_02(poses.Where(x => x.Position == 1).Count() + stageStart));
            poses.ForEach(x => x.Label = "Stage4");

            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_05(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_05_00(currStage));
            poses.ForEach(x => x.Label = "Stage5");

            currStage++;
            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_01(int currStage)
        {
            string fP01 = "7bcd82f0-9ee5-4d5f-bded-68ffb335fc5f"; // look backward on male
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            var f = new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 };
            f.Emotion.EyesLeft(true);
            f.Emotion.EyesDown(false);
            poses.Add(f);
            var m = new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 0 };
            poses.Add(m);
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_02(int currStage)
        {
            string fP01 = "9af61c9a-936a-4b5a-a9fa-8fbd5cd16f55"; // look down on cock
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            var f = new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 };
            f.Emotion.EyesLeft(true);
            poses.Add(f);
            var m = new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 0 };
            poses.Add(m);
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_03(int currStage)
        {
            string fP01 = "3d3d4161-0bbf-44d3-bab0-2c57686b2aa9"; // look straight forward
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 0 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_04(int currStage)
        {
            string fP01 = "5543ebca-e4d3-42e7-bea1-109f11b2aea5"; // look straight forward
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 0 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_02_00(int currStage)
        {
            string fP01 = "e44eadc6-e0b2-40e5-9dee-05ca8f1c6c60"; // 
            string mP01 = "4d6f3ea2-8583-495d-b2cd-fa9099ab39cd"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_03_00(int currStage)
        {
            string fP01 = "f7236838-96e9-4f40-ae24-b9df56f43ffd"; // 
            string mP01 = "33ec28cf-add3-42a8-bcaf-495b29d825c2"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_04_01(int currStage)
        {
            string fP01 = "241d5f1b-d839-49c4-8da5-5b1e319bc786"; // 
            string mP01 = "dc6d9c94-b6f2-4cfd-b68e-c00891363e63"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_04_02(int currStage)
        {
            string fP01 = "e656a5f1-6fe9-42b5-af24-8c95b3649c95"; // 
            string mP01 = "dc6d9c94-b6f2-4cfd-b68e-c00891363e63"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_05_00(int currStage)
        {
            string fP01 = "9e63d179-35b4-4804-b7be-841526c8c0c7"; // 
            string mP01 = "9a8d3d91-bc47-480c-b1e2-233c875fd78a"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        #endregion
        
        #region Leito Anal Doggy 2

        private static bool Movie_Leito_AnalDoggy2()
        {
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.AddRange(ScenGenerate_Leito_AnalDoggy2_stage_01(false, 1));                // stage 1            
            poses.AddRange(StageGenerate(false, poses.Count + 1, new string[] { "910cba42-1eda-4c71-9a8f-84994d07ceea", "64e9ddea-ed26-4339-b298-16ac694d1939" }));  // stage 2            
            poses.AddRange(StageGenerate(false, poses.Count + 1, new string[] { "193e8465-4e8a-4696-b520-df54784329f9", "52d545ba-3c78-42fd-8efa-c4bd78e0081d" }));  // stage 3            
            poses.AddRange(StageGenerate(false, poses.Count + 1, new string[] { "20b26dc0-6133-4821-a6bd-0662e8598149", "42aeae85-5d68-4cad-bea1-6836603a0f14" }));
            poses.AddRange(StageGenerate(false, poses.Count + 1, new string[] { "4d1da02e-74cd-4da8-97e8-4402c625fc83", "b760614c-dd23-43ab-8948-c669ee3fd036" }));
            foreach (var pose in poses)
            {
                pose.CopyToDestination();
            }
            RebuildScript(poses);
            return true;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_AnalDoggy2_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            // 
            poses.AddRange(ScenGenerate_Leito_AnalDoggy2_stage_01_01(currStage));
            currStage++;
            poses.AddRange(ScenGenerate_Leito_AnalDoggy2_stage_01_02(currStage));
            currStage++;
            if (complete)
            {
                foreach (var pose in poses)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(poses);
            }
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_AnalDoggy2_stage_01_01(int currStage)
        {
            string fP01 = "eaf748ae-236b-4141-9269-fb2b6fce755c"; // 
            string mP01 = "2d82a3f4-a4d4-48ba-9dcd-e73cd70ba04c"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_AnalDoggy2_stage_01_02(int currStage)
        {
            string fP01 = "0d9b3b87-b000-4e1d-9c7d-f950cddaaae4"; // 
            string mP01 = "2d82a3f4-a4d4-48ba-9dcd-e73cd70ba04c"; //            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }

        #endregion
        
        #endregion

    }
}
