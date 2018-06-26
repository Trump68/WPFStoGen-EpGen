using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EPCat.Model
{
    public static class Skyrim
    {
        public static ObservableCollection<EpItem> Items;
        public static string destinationPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\ABAnims01\";

        #region Old logic
        private static void GenerateMotionOld(EpItem epitem, ObservableCollection<EpItem> items)
        {
            Items = items;

            List<SkyrimPosePositionInfo> valid = new List<SkyrimPosePositionInfo>();
            foreach (var item in epitem.PosePositions)
            {
                if (!item.Active) continue;
                if (string.IsNullOrEmpty(item.Path)) continue;
                valid.Add(item);
            }
            List<SkyrimPosePositionInfo> valid0 = valid.Where(x => x.Position == 0).ToList();
            List<SkyrimPosePositionInfo> valid1 = valid.Where(x => x.Position == 1).ToList();
            List<SkyrimPosePositionInfo> valid2 = valid.Where(x => x.Position == 2).ToList();
            //Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo> possible
            //    = new Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo>(null, null, null);
            List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>> possible =
                new List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>>();


            foreach (var item0 in valid0)
            {
                if (valid1.Any())
                {
                    foreach (var item1 in valid1)
                    {
                        if (valid2.Any())
                        {
                            foreach (var item2 in valid2)
                            {
                                possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, item2));

                            }
                        }
                        else
                        {
                            possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, null));
                        }
                    }
                }
                else
                {
                    possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, null, null));
                }
            }


            int stage = 0;
            string destinationPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\ABAnims01\";

            List<int> erections = new List<int>();
            foreach (var item in possible)
            {
                stage++;
                if (item.Item1 != null)
                {
                    docopyfile(item.Item1.Path, destinationPath, stage, 1);
                    erections.Add(item.Item1.SOS);
                }
                if (item.Item2 != null)
                {
                    docopyfile(item.Item2.Path, destinationPath, stage, 2);
                    erections.Add(item.Item2.SOS);
                }
                if (item.Item3 != null)
                {
                    docopyfile(item.Item3.Path, destinationPath, stage, 3);
                    erections.Add(item.Item3.SOS);
                }
            }
            RebuildSkript(erections, possible);
        }
        private static void docopyfile(string path, string destpath, int stage, int position)
        {
            string dest = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dest))
            {
                string file = Directory.GetFiles(dest, "*.hkx").FirstOrDefault();
                if (!string.IsNullOrEmpty(file))
                {
                    File.Copy(file, Path.Combine(destpath, $"AB01_Fuck_A{position}_S{stage}.hkx"), true);
                }
            }
        }
        private static void runBuild()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @"d:\SteamLibrary\steamapps\common\Skyrim\Papyrus Compiler\ScriptCompileAdv.bat";
            pProcess.StartInfo.Arguments = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc"; //argument
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            //pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd(); //The output result
            pProcess.WaitForExit();
            MessageBox.Show(output);
        }
        private static void RebuildSkript(List<int> erections, List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>> possible)
        {
            string sourceFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\sslThreadController.psc";
            //string destFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc";
            List<string> raw = new List<string>(File.ReadAllLines(sourceFile));

            List<string> source = new List<string>();
            foreach (var item in raw)
            {
                source.Add(item);
                if (item.Contains("; ++++++++++++++++++++++++++++++++AB SECTION++++++++++++++++++++++++++++++++++++++++++++"))
                {
                    break;
                }
            }
            source.Add(@"function AB_SetParams()");
            source.Add(@"     Erection = new int[128]");

            int i = 0;
            foreach (var item in erections)
            {
                if (item != 0)
                {
                    source.Add($@"     Erection[{i}] = {item}");

                }
                i++;
            }

            source.Add($@"     AB_RestartStage = {possible.Count}");
            source.Add(@"endFunction");

            File.WriteAllLines(sourceFile, source);

            runBuild();
        }
        #endregion

        #region New logic

        public static void GenerateMotion(EpItem epitem, ObservableCollection<EpItem> items)
        {
            Items = items;
            string sgid = epitem.GID.ToString();
            if      (sgid == "f34fe029-737e-47b6-8a9a-b7a578db3950")   ScenGenerate_Leito_Leito_69_stage_01(true, 1);            
            else if (sgid == "06ca88ef-9d82-4f89-b0c2-75488fa6536e")   ScenGenerate_Leito_Leito_69_stage_02(true, 1);            
            else if (sgid == "722fac8f-0596-4c12-b323-449467b1980c")   ScenGenerate_Leito_Leito_69_stage_03(true, 1);            
            else if (sgid == "e934d4ee-5f7c-4ce3-acb3-be5ca3f68cdd")   ScenGenerate_Leito_Leito_69_stage_04(true, 1);            
            else if (sgid == "3869be1c-978e-4180-8b3c-a891a4f4b1cd")   ScenGenerate_Leito_Leito_69_stage_05(true, 1);
            else if (sgid == "7546245a-f333-49b1-bb84-d5a77b3031dc")   ScenGenerate_Leito_AnalDoggy2_stage_01(true, 1);
            else if (sgid == "1325bfb5-c26c-4dc1-8549-79578ab73081") StageGenerate(true, 1, new string[] { "910cba42-1eda-4c71-9a8f-84994d07ceea", "64e9ddea-ed26-4339-b298-16ac694d1939" });
            else if (sgid == "8320e8b3-19c3-4421-8135-44c408566b96") StageGenerate(true, 1, new string[] { "193e8465-4e8a-4696-b520-df54784329f9", "52d545ba-3c78-42fd-8efa-c4bd78e0081d" });
            else if (sgid == "b249fa52-770b-4128-a692-16cf7e0d1a39") StageGenerate(true, 1, new string[] { "20b26dc0-6133-4821-a6bd-0662e8598149", "42aeae85-5d68-4cad-bea1-6836603a0f14" });
            else if (sgid == "2db7b202-29f3-4b41-87d5-5899b3db9fd6") StageGenerate(true, 1, new string[] { "4d1da02e-74cd-4da8-97e8-4402c625fc83", "b760614c-dd23-43ab-8948-c669ee3fd036" });            
            else GenerateMotionOld(epitem, items);


        }
        private static void reBuild()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @"d:\SteamLibrary\steamapps\common\Skyrim\Papyrus Compiler\ScriptCompileAdv.bat";
            pProcess.StartInfo.Arguments = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\sslThreadController.psc"; //argument
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            //pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd(); //The output result
            pProcess.WaitForExit();
            MessageBox.Show(output);
        }
        private static void RebuildScript(List<SkyrimActorPose> poses)
        {
            string sourceFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\sslThreadController.psc";
            List<string> raw = new List<string>(File.ReadAllLines(sourceFile));
            List<string> source = new List<string>();
            foreach (var item in raw)
            {
                source.Add(item);
                if (item.Contains("AB SECTION"))
                {
                    break;
                }
            }
            source.Add(@"function AB_SetParams()");
            source.Add(@"    If       (Stage == 0)");
            int stage = 0;
            foreach (var item in poses)
            {
                if (item.Stage != stage)
                {
                    stage = item.Stage;
                    source.Add($@"    ElseIf   (Stage == {stage})");                    
                }
                if (item.SOS != 0)
                {                    
                    source.Add($@"      ActorAlias(Positions[{item.Position-1}]).AB_SetSchlong({item.SOS})");
                }                
            }
            source.Add(@"    Endif");
            source.Add($@"    AB_RestartStage = {poses.Count}");
            source.Add(@"endFunction");

            File.WriteAllLines(sourceFile, source);
            reBuild();
        }
        private static List<SkyrimActorPose> ScenGenerate(int currStage, params string[] posArray)
        {
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            int i = 1;
            foreach (var item in posArray)
            {
                poses.Add(new SkyrimActorPose(item) { Position = i, Stage = currStage, SOS = 0 });
                i++;
            }
            return poses;
        }
        private static List<SkyrimActorPose> StageGenerate(bool complete, int stageStart, params string[] posArray)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            // 
            poses.AddRange(ScenGenerate(currStage, posArray));
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
        #endregion

        #region Code generation

        static string animationListPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\AnimationsByLeito";
        static string animationSerie    = @"AnimationsByLeito";
        static string catalogPathPose   = @"d:\!CATALOG\SKY\Pose";
        static string catalogPathMotion  = @"d:\!CATALOG\SKY\Motion";
        static string animationListName = @"LoadList.txt";
        static List<string> codeGenerated;
        public static void GenerateCode()
        {
            codeGenerated = new List<string>();
            List<string> raw = new List<string>(File.ReadAllLines(Path.Combine(animationListPath, animationListName)));
            foreach (var item in raw)
            {
                var vals = item.Split(' ');
                DoOnePose(vals[0], Convert.ToInt16(vals[1]), Convert.ToInt16(vals[2]));
            }
            File.WriteAllLines(Path.Combine(catalogPathMotion, "RESULT.TXT"), codeGenerated);
        }
        private static void DoOnePose(string name, int posN, int staN)
        {            
            for (int sta = 1; sta <= staN; sta++) 
            {
                List<string> gids = new List<string>();
                for (int pos = 1; pos <= posN; pos++)
                {
                    // dir creation and file copy
                    string fn = $"{name}_A{pos}_S{sta}";                    
                    string fulldirpath = Path.Combine(catalogPathPose, animationSerie, fn);
                    if (!Directory.Exists(fulldirpath))
                    {
                        Directory.CreateDirectory(fulldirpath);
                    }
                    fn = $"{fn}.hkx";
                    File.Copy(Path.Combine(animationListPath, fn), Path.Combine(fulldirpath, fn), true);
                    
                    // EpItem creation
                    EpItem newItem = new EpItem(0);
                    newItem.Name = $"{name}_A{pos}_S{sta}";
                    newItem.Catalog = "SKY";
                    newItem.Kind = "POSE";
                    newItem.Stage = $"{sta}";
                    var passport = EpItem.SetToPassport(newItem);
                    File.WriteAllLines(Path.Combine(fulldirpath, "PASSPORT.TXT"), passport);

                    gids.Add("''" + newItem.GID.ToString() + "''");

                    // Motion creation
                    if (sta == staN)
                    {
                        fn = $"{name} S{sta}";
                        fulldirpath = Path.Combine(catalogPathMotion, animationSerie, name);
                        if (!Directory.Exists(fulldirpath))
                        {
                            Directory.CreateDirectory(fulldirpath);
                        }
                        // EpItem creation
                        newItem = new EpItem(0);
                        newItem.Name = $"{name} S{sta}";
                        newItem.Catalog = "SKY";
                        newItem.Kind = "MOTION";
                        newItem.Stage = $"{staN}";
                        passport = EpItem.SetToPassport(newItem);
                        File.WriteAllLines(Path.Combine(fulldirpath, "PASSPORT.TXT"), passport);
                        string gidss = string.Join(",", gids.ToArray());
                        string line = @"else if (sgid == ''" + newItem.GID.ToString() + "'') StageGenerate(true, 1, new string[] { " + gidss + " });";
                        codeGenerated.Add(line);
                    }

                }
            }            
        }

        #endregion

        #region Standart motions   
        #region Leito Leito_69
        private static bool ScenGenerate_Leito_Leito_69()
        {
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01(false, 1));                // stage 1            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_02(false, poses.Count + 1));  // stage 2            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_03(false, poses.Count + 1));  // stage 3            
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_04(false, poses.Count + 1));  // stage 4
            foreach (var pose in poses)
            {
                pose.CopyToDestination();
            }
            RebuildScript(poses);
            return true;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01(bool complete, int stageStart = 1)
        {
            int currStage = stageStart;
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();

            // 
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_01(currStage));
            currStage++;
            //     
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_02(currStage));
            currStage++;
            // 
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_03(currStage));
            currStage++;
            // 
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_01_04(currStage));
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
            currStage++;
            poses.AddRange(ScenGenerate_Leito_Leito_69_stage_04_02(currStage));
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
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_02(int currStage)
        {
            string fP01 = "9af61c9a-936a-4b5a-a9fa-8fbd5cd16f55"; // look down on cock
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_03(int currStage)
        {
            string fP01 = "3d3d4161-0bbf-44d3-bab0-2c57686b2aa9"; // look straight forward
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
            return poses;
        }
        private static List<SkyrimActorPose> ScenGenerate_Leito_Leito_69_stage_01_04(int currStage)
        {
            string fP01 = "5543ebca-e4d3-42e7-bea1-109f11b2aea5"; // look straight forward
            string mP01 = "4ba48803-5ed6-411b-b371-249c5e27a461"; // default            
            List<SkyrimActorPose> poses = new List<SkyrimActorPose>();
            poses.Add(new SkyrimActorPose(fP01) { Position = 1, Stage = currStage, SOS = 0 });
            poses.Add(new SkyrimActorPose(mP01) { Position = 2, Stage = currStage, SOS = 1 });
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

        private static bool ScenGenerate_Leito_AnalDoggy2()
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
