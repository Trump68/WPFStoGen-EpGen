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
    public static partial class Skyrim
    {
        public static ObservableCollection<EpItem> Items;
        public static string destinationPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\ABAnims01\";

        #region Old logic
        //private static void GenerateMotionOld(EpItem epitem, ObservableCollection<EpItem> items)
        //{
        //    Items = items;

        //    List<SkyrimPosePositionInfo> valid = new List<SkyrimPosePositionInfo>();
        //    foreach (var item in epitem.PosePositions)
        //    {
        //        if (!item.Active) continue;
        //        if (string.IsNullOrEmpty(item.Path)) continue;
        //        valid.Add(item);
        //    }
        //    List<SkyrimPosePositionInfo> valid0 = valid.Where(x => x.Position == 0).ToList();
        //    List<SkyrimPosePositionInfo> valid1 = valid.Where(x => x.Position == 1).ToList();
        //    List<SkyrimPosePositionInfo> valid2 = valid.Where(x => x.Position == 2).ToList();
        //    //Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo> possible
        //    //    = new Tuple<PosePositionInfo, PosePositionInfo, PosePositionInfo>(null, null, null);
        //    List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>> possible =
        //        new List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>>();


        //    foreach (var item0 in valid0)
        //    {
        //        if (valid1.Any())
        //        {
        //            foreach (var item1 in valid1)
        //            {
        //                if (valid2.Any())
        //                {
        //                    foreach (var item2 in valid2)
        //                    {
        //                        possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, item2));

        //                    }
        //                }
        //                else
        //                {
        //                    possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, item1, null));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            possible.Add(new Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>(item0, null, null));
        //        }
        //    }


        //    int stage = 0;
        //    string destinationPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\ABAnims01\";

        //    List<int> erections = new List<int>();
        //    foreach (var item in possible)
        //    {
        //        stage++;
        //        if (item.Item1 != null)
        //        {
        //            docopyfile(item.Item1.Path, destinationPath, stage, 1);
        //            erections.Add(item.Item1.SOS);
        //        }
        //        if (item.Item2 != null)
        //        {
        //            docopyfile(item.Item2.Path, destinationPath, stage, 2);
        //            erections.Add(item.Item2.SOS);
        //        }
        //        if (item.Item3 != null)
        //        {
        //            docopyfile(item.Item3.Path, destinationPath, stage, 3);
        //            erections.Add(item.Item3.SOS);
        //        }
        //    }
        //    RebuildSkript(erections, possible);
        //}
        //private static void docopyfile(string path, string destpath, int stage, int position)
        //{
        //    string dest = Path.GetDirectoryName(path);
        //    if (!string.IsNullOrEmpty(dest))
        //    {
        //        string file = Directory.GetFiles(dest, "*.hkx").FirstOrDefault();
        //        if (!string.IsNullOrEmpty(file))
        //        {
        //            File.Copy(file, Path.Combine(destpath, $"AB01_Fuck_A{position}_S{stage}.hkx"), true);
        //        }
        //    }
        //}
        //private static void runBuild()
        //{
        //    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        //    pProcess.StartInfo.FileName = @"d:\SteamLibrary\steamapps\common\Skyrim\Papyrus Compiler\ScriptCompileAdv.bat";
        //    pProcess.StartInfo.Arguments = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc"; //argument
        //    pProcess.StartInfo.UseShellExecute = false;
        //    pProcess.StartInfo.RedirectStandardOutput = true;
        //    //pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        //    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //    pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
        //    pProcess.Start();
        //    string output = pProcess.StandardOutput.ReadToEnd(); //The output result
        //    pProcess.WaitForExit();
        //    MessageBox.Show(output);
        //}
        //private static void RebuildSkript(List<int> erections, List<Tuple<SkyrimPosePositionInfo, SkyrimPosePositionInfo, SkyrimPosePositionInfo>> possible)
        //{
        //    string sourceFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\sslThreadController.psc";
        //    //string destFile = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\scripts\source\SexLabFramework.psc";
        //    List<string> raw = new List<string>(File.ReadAllLines(sourceFile));

        //    List<string> source = new List<string>();
        //    foreach (var item in raw)
        //    {
        //        source.Add(item);
        //        if (item.Contains("; ++++++++++++++++++++++++++++++++AB SECTION++++++++++++++++++++++++++++++++++++++++++++"))
        //        {
        //            break;
        //        }
        //    }
        //    source.Add(@"function AB_SetParams()");
        //    source.Add(@"     Erection = new int[128]");

        //    int i = 0;
        //    foreach (var item in erections)
        //    {
        //        if (item != 0)
        //        {
        //            source.Add($@"     Erection[{i}] = {item}");

        //        }
        //        i++;
        //    }

        //    source.Add($@"     AB_RestartStage = {possible.Count}");
        //    source.Add(@"endFunction");

        //    File.WriteAllLines(sourceFile, source);

        //    runBuild();
        //}
        #endregion

        #region New logic

        public static void GenerateMotion(EpItem epitem, ObservableCollection<EpItem> items)
        {
            //GenerateCode();
            //return;

            Items = items;
            string sgid = epitem.GID.ToString();
            // Leito_69 S1
            if (sgid == "f34fe029-737e-47b6-8a9a-b7a578db3950") ScenGenerate_Leito_Leito_69_stage_01(true, 1);
            // Leito_69 S2
            else if (sgid == "06ca88ef-9d82-4f89-b0c2-75488fa6536e") ScenGenerate_Leito_Leito_69_stage_02(true, 1);
            // Leito_69 S3
            else if (sgid == "722fac8f-0596-4c12-b323-449467b1980c") ScenGenerate_Leito_Leito_69_stage_03(true, 1);
            // Leito_69 S4
            else if (sgid == "e934d4ee-5f7c-4ce3-acb3-be5ca3f68cdd") ScenGenerate_Leito_Leito_69_stage_04(true, 1);
            // Leito_69 S5
            else if (sgid == "3869be1c-978e-4180-8b3c-a891a4f4b1cd") ScenGenerate_Leito_Leito_69_stage_05(true, 1);
            // Leito_69 Movie
            else if (sgid == "f7e0e8b5-2518-47ed-becc-50d006e5ac5d") Movie_Leito_69();

            // Anal_Doggy_2 S1
            else if (sgid == "7546245a-f333-49b1-bb84-d5a77b3031dc") ScenGenerate_Leito_AnalDoggy2_stage_01(true, 1);
            // Anal_Doggy_2 S2
            else if (sgid == "1325bfb5-c26c-4dc1-8549-79578ab73081") SceneGenerate(true, 1, new string[] { "910cba42-1eda-4c71-9a8f-84994d07ceea", "64e9ddea-ed26-4339-b298-16ac694d1939" });
            // Anal_Doggy_2 S3
            else if (sgid == "8320e8b3-19c3-4421-8135-44c408566b96") SceneGenerate(true, 1, new string[] { "193e8465-4e8a-4696-b520-df54784329f9", "52d545ba-3c78-42fd-8efa-c4bd78e0081d" });
            // Anal_Doggy_2 S4
            else if (sgid == "b249fa52-770b-4128-a692-16cf7e0d1a39") SceneGenerate(true, 1, new string[] { "20b26dc0-6133-4821-a6bd-0662e8598149", "42aeae85-5d68-4cad-bea1-6836603a0f14" });
            // Anal_Doggy_2 S5
            else if (sgid == "2db7b202-29f3-4b41-87d5-5899b3db9fd6") SceneGenerate(true, 1, new string[] { "4d1da02e-74cd-4da8-97e8-4402c625fc83", "b760614c-dd23-43ab-8948-c669ee3fd036" });
            // Anal_Doggy_2 Movie
            else if (sgid == "f7e0e8b5-2518-47ed-becc-50d006e5ac5d") Movie_Leito_AnalDoggy2();

            // Leito_Anal_Missionary_A2_S1
            else if (sgid == "50019b6a-fcd7-4ef7-981f-5c444a206fa3") SceneGenerate(true, 1, new string[] { "3fad1d78-c644-4ff6-970d-30eabe10550a", "7b843aea-2251-4fbc-b0d5-76c666e7a842" });
            // Leito_Anal_Missionary_A2_S2
            else if (sgid == "5b04d121-3683-4c84-8836-a7cc1cf62d66") SceneGenerate(true, 1, new string[] { "2b7229f7-6dc8-4204-80dd-49ea6bbf9256", "9f7e918c-6418-44b8-ae51-010e6c96562a" });
            // Leito_Anal_Missionary_A2_S3
            else if (sgid == "103eac4a-38a5-4a4a-89a3-b44cb0a7e986") SceneGenerate(true, 1, new string[] { "b58e6b82-20a5-44c8-b1de-9da3014ba26a", "cb17f2f2-d0ae-4e42-9a2f-c606228f9c33" });
            // Leito_Anal_Missionary_A2_S4
            else if (sgid == "3d425661-e0cb-4db8-98ca-095b2786a363") SceneGenerate(true, 1, new string[] { "c178dbb3-6705-4c2e-bc91-397431cf3715", "f4414fcc-f348-4cb4-9620-c6166a3cafdf" });
            // Leito_Anal_Missionary_A2_S5
            else if (sgid == "ab2bed66-09d0-447b-961b-8e2dea3424e0") SceneGenerate(true, 1, new string[] { "75536ca4-6c8d-4617-9b52-03af7f5b7f46", "bab68dd5-9e0d-4578-8a4c-3776a5698d5e" });
            // Leito_Anal_Missionary Movie
            else if (sgid == "48abaaa3-4a3c-4c28-8b21-7b29e8720c15") MoviewGenerate(new List<List<string>>() { new List<string>() { "3fad1d78-c644-4ff6-970d-30eabe10550a", "7b843aea-2251-4fbc-b0d5-76c666e7a842" }, new List<string>() { "2b7229f7-6dc8-4204-80dd-49ea6bbf9256", "9f7e918c-6418-44b8-ae51-010e6c96562a" }, new List<string>() { "b58e6b82-20a5-44c8-b1de-9da3014ba26a", "cb17f2f2-d0ae-4e42-9a2f-c606228f9c33" }, new List<string>() { "c178dbb3-6705-4c2e-bc91-397431cf3715", "f4414fcc-f348-4cb4-9620-c6166a3cafdf" }, new List<string>() { "75536ca4-6c8d-4617-9b52-03af7f5b7f46", "bab68dd5-9e0d-4578-8a4c-3776a5698d5e" } });
            // Leito_Anal_Missionary_2_A2_S1
            else if (sgid == "8e258ab7-b63e-40f4-9a9d-1b94f1147a5c") SceneGenerate(true, 1, new string[] { "55115332-2981-41f9-bd90-25fedeffc099", "57abbbdf-88f6-4bd1-ba92-887e5c31a034" });
            // Leito_Anal_Missionary_2_A2_S2
            else if (sgid == "cfab52be-b06f-4832-81e9-fda132e3460e") SceneGenerate(true, 1, new string[] { "c10f53be-3654-43f0-b5a8-17ee7a5bb09c", "08c9dff4-930a-4426-ae76-c4711bb3df05" });
            // Leito_Anal_Missionary_2_A2_S3
            else if (sgid == "b1862ec4-ee89-4e67-a0c0-2a3ea1887f24") SceneGenerate(true, 1, new string[] { "cbaf2f46-3c70-4d65-bea3-ad326ad660ad", "2df40ea0-9d17-4859-95c0-315bcffbcfd9" });
            // Leito_Anal_Missionary_2_A2_S4
            else if (sgid == "378b1595-73b6-4ded-9485-98ec7114afe5") SceneGenerate(true, 1, new string[] { "56917e59-1ce2-49c9-8493-324d020301db", "f209ebf8-0d19-4f7e-8456-3db983f4b581" });
            // Leito_Anal_Missionary_2_A2_S5
            else if (sgid == "81e08bec-f4ff-4330-a2d9-6a08b5745357") SceneGenerate(true, 1, new string[] { "cab3d358-1b9a-4772-a68a-505e5d08e558", "b905a26d-d594-4a6c-8dda-e75d752ede58" });
            // Leito_Anal_Missionary_2 Movie
            else if (sgid == "c1500eca-eed6-480f-97a1-062a4d279c3b") MoviewGenerate(new List<List<string>>() { new List<string>() { "55115332-2981-41f9-bd90-25fedeffc099", "57abbbdf-88f6-4bd1-ba92-887e5c31a034" }, new List<string>() { "c10f53be-3654-43f0-b5a8-17ee7a5bb09c", "08c9dff4-930a-4426-ae76-c4711bb3df05" }, new List<string>() { "cbaf2f46-3c70-4d65-bea3-ad326ad660ad", "2df40ea0-9d17-4859-95c0-315bcffbcfd9" }, new List<string>() { "56917e59-1ce2-49c9-8493-324d020301db", "f209ebf8-0d19-4f7e-8456-3db983f4b581" }, new List<string>() { "cab3d358-1b9a-4772-a68a-505e5d08e558", "b905a26d-d594-4a6c-8dda-e75d752ede58" } });
            // Leito_Anal_Powerbomb_A2_S1
            else if (sgid == "f9683719-471b-4c99-9d76-9688a389d21b") SceneGenerate(true, 1, new string[] { "7161d04b-c8b2-47d1-826a-51b164ff9a97", "cfec8971-1db8-47fc-9d43-605badd0d465" });
            // Leito_Anal_Powerbomb_A2_S2
            else if (sgid == "9a5c630d-c4b3-4510-b6cd-c68a2ac66c79") SceneGenerate(true, 1, new string[] { "b6711b4f-2f5a-4c10-a8a6-43c5a59beea7", "028af9a2-6176-4667-8f87-63b77ca5c5f2" });
            // Leito_Anal_Powerbomb_A2_S3
            else if (sgid == "0a91c24a-e189-41d9-a795-057a149eb22a") SceneGenerate(true, 1, new string[] { "2629c136-914d-4886-bad7-2b82a15d3eb7", "40060b25-1f7d-43cf-bccd-3f9ebe929839" });
            // Leito_Anal_Powerbomb_A2_S4
            else if (sgid == "7d8c2fcc-376f-4d9b-9f75-f6889fa835d0") SceneGenerate(true, 1, new string[] { "4947dca4-3726-4348-860e-b92addbf6c8c", "0134626b-bf7b-47d6-97db-56b97c72a5f8" });
            // Leito_Anal_Powerbomb_A2_S5
            else if (sgid == "3392419e-518e-42f1-b7dd-d4b1ea26171d") SceneGenerate(true, 1, new string[] { "1ac6b17a-b5ce-464d-ab17-24572e216c9e", "3113209c-21e3-42e3-a4ce-c9d27ec7bd32" });
            // Leito_Anal_Powerbomb Movie
            else if (sgid == "684b943c-a57e-43e4-a17b-181864ef5e17") MoviewGenerate(new List<List<string>>() { new List<string>() { "7161d04b-c8b2-47d1-826a-51b164ff9a97", "cfec8971-1db8-47fc-9d43-605badd0d465" }, new List<string>() { "b6711b4f-2f5a-4c10-a8a6-43c5a59beea7", "028af9a2-6176-4667-8f87-63b77ca5c5f2" }, new List<string>() { "2629c136-914d-4886-bad7-2b82a15d3eb7", "40060b25-1f7d-43cf-bccd-3f9ebe929839" }, new List<string>() { "4947dca4-3726-4348-860e-b92addbf6c8c", "0134626b-bf7b-47d6-97db-56b97c72a5f8" }, new List<string>() { "1ac6b17a-b5ce-464d-ab17-24572e216c9e", "3113209c-21e3-42e3-a4ce-c9d27ec7bd32" } });
            // Leito_Anal_Re_Cow_A2_S1
            else if (sgid == "8d7b1312-2ffc-4a41-bf02-8376f9c4a837") SceneGenerate(true, 1, new string[] { "0c5ce523-ef82-4bc7-978f-3441a14d8b95", "fdc5e6cb-2e6c-40d5-9cd2-d1795ac64d19" });
            // Leito_Anal_Re_Cow_A2_S2
            else if (sgid == "4df46ed9-9fbd-4d59-93c0-0ad969a2f756") SceneGenerate(true, 1, new string[] { "1c24bc89-85c9-4aed-a0ac-89b5ce2f1fec", "59b63f1b-e0c8-46b6-84d3-ddf95d2511e6" });
            // Leito_Anal_Re_Cow_A2_S3
            else if (sgid == "8c230ef1-4d26-48c8-ab3e-128fc2198681") SceneGenerate(true, 1, new string[] { "0191be15-08ea-4c60-a5d5-81668134afb7", "260282bf-c802-49ef-97a4-313a8a856aaa" });
            // Leito_Anal_Re_Cow_A2_S4
            else if (sgid == "c9ff3d3c-5a79-4084-aee2-1cdef46d2884") SceneGenerate(true, 1, new string[] { "f8e4fb94-7f28-48ee-b633-17736ba01cbf", "8ed105ab-f92d-44c3-96f9-7dec21df6129" });
            // Leito_Anal_Re_Cow_A2_S5
            else if (sgid == "5e901dd9-84fe-472d-9f69-e4038aac73b5") SceneGenerate(true, 1, new string[] { "63bde70b-b1aa-44d0-bdd7-3b8e191d724a", "6e8f3967-bcc0-4fd0-ab2a-5b33d4e87daa" });
            // Leito_Anal_Re_Cow Movie
            else if (sgid == "4ec37ecd-bab2-430e-a863-61d533140c9a") MoviewGenerate(new List<List<string>>() { new List<string>() { "0c5ce523-ef82-4bc7-978f-3441a14d8b95", "fdc5e6cb-2e6c-40d5-9cd2-d1795ac64d19" }, new List<string>() { "1c24bc89-85c9-4aed-a0ac-89b5ce2f1fec", "59b63f1b-e0c8-46b6-84d3-ddf95d2511e6" }, new List<string>() { "0191be15-08ea-4c60-a5d5-81668134afb7", "260282bf-c802-49ef-97a4-313a8a856aaa" }, new List<string>() { "f8e4fb94-7f28-48ee-b633-17736ba01cbf", "8ed105ab-f92d-44c3-96f9-7dec21df6129" }, new List<string>() { "63bde70b-b1aa-44d0-bdd7-3b8e191d724a", "6e8f3967-bcc0-4fd0-ab2a-5b33d4e87daa" } });
            // Leito_Lesbian_1_A2_S1
            else if (sgid == "9487cb71-025a-494d-a9d9-3d5cbe661852") SceneGenerate(true, 1, new string[] { "e3ee06f9-998b-4a76-9af8-3c6e853eb92c", "4c458b4f-2e34-44f2-a1a5-49a99f42103a" });
            // Leito_Lesbian_1_A2_S2
            else if (sgid == "a1e5e00a-444e-436f-a326-015a81554929") SceneGenerate(true, 1, new string[] { "b2b7b205-ff29-4008-b59a-3d5a5c7c25f0", "3b24e530-194e-4f11-8a8a-fba680ccf19c" });
            // Leito_Lesbian_1_A2_S3
            else if (sgid == "e209ad7d-7a30-4413-8913-ac8d1b4915b5") SceneGenerate(true, 1, new string[] { "8c1e8e71-ddd2-4976-83ff-a5310a13d378", "fe87a55f-939c-43d7-9f9d-9e8e1db5361f" });
            // Leito_Lesbian_1_A2_S4
            else if (sgid == "1e276e3b-e9b6-4a69-84ee-3264cdc9a3f0") SceneGenerate(true, 1, new string[] { "26d30574-13de-416a-a125-bf9c51910d4c", "09864f07-36ed-43dc-ba4a-f812c09541ef" });
            // Leito_Lesbian_1_A2_S5
            else if (sgid == "d51067e9-39d0-43f1-b8c8-521fa37f826f") SceneGenerate(true, 1, new string[] { "8c798b55-3053-4811-835f-035f5b5fa2e8", "2be0f136-aeb6-4806-9357-52407ffedff0" });
            // Leito_Lesbian_1 Movie
            else if (sgid == "b6054905-d94b-472b-bd4b-a10f551f820c") MoviewGenerate(new List<List<string>>() { new List<string>() { "e3ee06f9-998b-4a76-9af8-3c6e853eb92c", "4c458b4f-2e34-44f2-a1a5-49a99f42103a" }, new List<string>() { "b2b7b205-ff29-4008-b59a-3d5a5c7c25f0", "3b24e530-194e-4f11-8a8a-fba680ccf19c" }, new List<string>() { "8c1e8e71-ddd2-4976-83ff-a5310a13d378", "fe87a55f-939c-43d7-9f9d-9e8e1db5361f" }, new List<string>() { "26d30574-13de-416a-a125-bf9c51910d4c", "09864f07-36ed-43dc-ba4a-f812c09541ef" }, new List<string>() { "8c798b55-3053-4811-835f-035f5b5fa2e8", "2be0f136-aeb6-4806-9357-52407ffedff0" } });
            // Leito_Lesbian_2_A2_S1
            else if (sgid == "6ad7d329-653d-4175-8998-3ecb9d15f2e5") SceneGenerate(true, 1, new string[] { "a31fe42c-fcab-4e08-b91d-2ca56414b19a", "75bb17fa-8d7f-4dc4-8358-e4cd21ec47ab" });
            // Leito_Lesbian_2_A2_S2
            else if (sgid == "bfa5c194-1f8c-4211-917f-604eb5fb7919") SceneGenerate(true, 1, new string[] { "4a0d5f3d-3208-46ac-aa20-62534214ec79", "80ec3287-69b6-47d0-8671-86e45f49b2c8" });
            // Leito_Lesbian_2_A2_S3
            else if (sgid == "91c8791b-b67f-494d-a544-e62b3695801d") SceneGenerate(true, 1, new string[] { "5059db0b-d662-4ea1-a12c-9065417df1ff", "8059a8b8-4528-471f-a446-63041d99d5f0" });
            // Leito_Lesbian_2_A2_S4
            else if (sgid == "42a42927-a57a-4d41-853f-0c995bf2d81b") SceneGenerate(true, 1, new string[] { "426b6844-56b6-4980-8298-e0776e6792fc", "da56e351-c1dc-418c-af37-60b5d163b498" });
            // Leito_Lesbian_2_A2_S5
            else if (sgid == "9f454eca-b951-49e5-ae9f-1f079c223770") SceneGenerate(true, 1, new string[] { "de0aed5d-3c91-468a-8993-b6f32be1c958", "77d83528-5348-4f09-a519-ad187361545a" });
            // Leito_Lesbian_2 Movie
            else if (sgid == "9b61c243-a4ab-4738-afc5-2f3cac811a79") MoviewGenerate(new List<List<string>>() { new List<string>() { "a31fe42c-fcab-4e08-b91d-2ca56414b19a", "75bb17fa-8d7f-4dc4-8358-e4cd21ec47ab" }, new List<string>() { "4a0d5f3d-3208-46ac-aa20-62534214ec79", "80ec3287-69b6-47d0-8671-86e45f49b2c8" }, new List<string>() { "5059db0b-d662-4ea1-a12c-9065417df1ff", "8059a8b8-4528-471f-a446-63041d99d5f0" }, new List<string>() { "426b6844-56b6-4980-8298-e0776e6792fc", "da56e351-c1dc-418c-af37-60b5d163b498" }, new List<string>() { "de0aed5d-3c91-468a-8993-b6f32be1c958", "77d83528-5348-4f09-a519-ad187361545a" } });
            // Leito_Lesbian_Dildo_1_A2_S1
            else if (sgid == "48f6bb66-d995-4ab8-a8a7-c0f512035f2f") SceneGenerate(true, 1, new string[] { "c17605bf-3e77-48b7-bb2e-3af097841d69", "b62a7fcd-acbe-4778-b966-a1ba24634d49" });
            // Leito_Lesbian_Dildo_1_A2_S2
            else if (sgid == "96320ba1-0a7c-4c22-aee8-770ef97ebb9c") SceneGenerate(true, 1, new string[] { "ea9f24c2-ec8c-492d-84e3-2adae03ecdc7", "d81fb335-eca6-4cdb-b6f7-032079a7da18" });
            // Leito_Lesbian_Dildo_1_A2_S3
            else if (sgid == "95cf3fb6-bf88-4dd2-be6d-62c9ab9cd223") SceneGenerate(true, 1, new string[] { "d202e13f-a0aa-45e3-97df-ad25e5a82e4a", "e08a6e08-5d26-46e7-958e-b7bd3f74977a" });
            // Leito_Lesbian_Dildo_1_A2_S4
            else if (sgid == "7dbc36d0-2ade-449a-868f-6ef60fa3b3d0") SceneGenerate(true, 1, new string[] { "08b6c81a-4b64-4331-a5be-fa7f9ab96614", "fc9787f4-5fdc-435c-9864-e4a1db25a489" });
            // Leito_Lesbian_Dildo_1_A2_S5
            else if (sgid == "8b8b0886-9602-48c7-b134-d30317028083") SceneGenerate(true, 1, new string[] { "b7cafa2b-3ce4-4e6d-9faf-58448281dad0", "17d2255f-aef6-4cd2-add6-7211eace9d26" });
            // Leito_Lesbian_Dildo_1 Movie
            else if (sgid == "cafb99a1-74c8-4802-964d-14518fa62cf5") MoviewGenerate(new List<List<string>>() { new List<string>() { "c17605bf-3e77-48b7-bb2e-3af097841d69", "b62a7fcd-acbe-4778-b966-a1ba24634d49" }, new List<string>() { "ea9f24c2-ec8c-492d-84e3-2adae03ecdc7", "d81fb335-eca6-4cdb-b6f7-032079a7da18" }, new List<string>() { "d202e13f-a0aa-45e3-97df-ad25e5a82e4a", "e08a6e08-5d26-46e7-958e-b7bd3f74977a" }, new List<string>() { "08b6c81a-4b64-4331-a5be-fa7f9ab96614", "fc9787f4-5fdc-435c-9864-e4a1db25a489" }, new List<string>() { "b7cafa2b-3ce4-4e6d-9faf-58448281dad0", "17d2255f-aef6-4cd2-add6-7211eace9d26" } });
            // Leito_Lesbian_Dildo_2_A2_S1
            else if (sgid == "3cfe9228-144f-42ee-a074-1ad214711e5a") SceneGenerate(true, 1, new string[] { "00736bcb-57f1-44af-97a9-35cbed9eb00a", "7102d347-3a22-47b6-9a57-62d71eb12796" });
            // Leito_Lesbian_Dildo_2_A2_S2
            else if (sgid == "ba9469fb-9e6f-4fca-b633-80467329f4d2") SceneGenerate(true, 1, new string[] { "5f019cd5-8b15-4ed6-9cb1-8544237ba022", "1411b693-656e-4060-8414-5677931f8ab8" });
            // Leito_Lesbian_Dildo_2_A2_S3
            else if (sgid == "4ae6de17-106a-4b9e-a5b5-8279a288ad8b") SceneGenerate(true, 1, new string[] { "f5dcf288-69f1-4ec7-ba4f-b93ae4cffd22", "2bb3e0c4-cc11-4e05-a8e1-ca449deeb7d4" });
            // Leito_Lesbian_Dildo_2_A2_S4
            else if (sgid == "39733c95-6c70-4e74-9dcf-8953df61f834") SceneGenerate(true, 1, new string[] { "094fd77d-44e4-45d6-bf9e-c8fa05c85bc2", "2c4f4b4e-5bef-4c4c-bc81-f0636a054025" });
            // Leito_Lesbian_Dildo_2_A2_S5
            else if (sgid == "2652e9df-d1e1-46d8-b823-bfd245dcdea1") SceneGenerate(true, 1, new string[] { "61bc61c5-fd2a-422c-ae03-1e613d847fd7", "8129b842-d3b8-4e57-b177-056f2e1bf6fe" });
            // Leito_Lesbian_Dildo_2 Movie
            else if (sgid == "2e4a917c-a145-4dec-b085-6fdcd1ca1571") MoviewGenerate(new List<List<string>>() { new List<string>() { "00736bcb-57f1-44af-97a9-35cbed9eb00a", "7102d347-3a22-47b6-9a57-62d71eb12796" }, new List<string>() { "5f019cd5-8b15-4ed6-9cb1-8544237ba022", "1411b693-656e-4060-8414-5677931f8ab8" }, new List<string>() { "f5dcf288-69f1-4ec7-ba4f-b93ae4cffd22", "2bb3e0c4-cc11-4e05-a8e1-ca449deeb7d4" }, new List<string>() { "094fd77d-44e4-45d6-bf9e-c8fa05c85bc2", "2c4f4b4e-5bef-4c4c-bc81-f0636a054025" }, new List<string>() { "61bc61c5-fd2a-422c-ae03-1e613d847fd7", "8129b842-d3b8-4e57-b177-056f2e1bf6fe" } });
            // Leito_BJ2_A2_S1
            else if (sgid == "9090b192-0c6e-49ce-a18f-15ec857efc6e") SceneGenerate(true, 1, new string[] { "51a38437-cd2f-4b0c-8a7e-d9b7e65a0fa2", "ca1ee4de-68ce-4f7f-b7d8-a3d15d9357c5" });
            // Leito_BJ2_A2_S2
            else if (sgid == "266e40f5-60e1-4b2a-a250-e26c1adb07fd") SceneGenerate(true, 1, new string[] { "183439d2-16bc-4199-ac25-0341b46043ea", "801dd7e6-8766-414b-ae4f-8d986edb15b9" });
            // Leito_BJ2_A2_S3
            else if (sgid == "706dcf7d-9bd0-48f1-9b93-6d6a07d0f9c4") SceneGenerate(true, 1, new string[] { "a1b5495c-4ea5-478a-a63b-e42b768d26a2", "6252a52a-2f88-42bb-ba90-2f0d2e23fcbc" });
            // Leito_BJ2_A2_S4
            else if (sgid == "161f22bf-4928-4a10-b753-e0bb9da2aad7") SceneGenerate(true, 1, new string[] { "5432fdad-3a47-40ce-a9b1-60259f08013c", "e832bd86-e750-44b4-bdae-c128f52997cd" });
            // Leito_BJ2_A2_S5
            else if (sgid == "374a3e13-a771-42fa-bc78-8031565d8ecf") SceneGenerate(true, 1, new string[] { "220b8518-f833-44f5-ac97-e18e91148de3", "4d50d920-7b0f-40aa-996b-6c265db1a502" });
            // Leito_BJ2 Movie
            else if (sgid == "a88e2fda-e5cf-4e42-98d6-f71f652edc6e") MoviewGenerate(new List<List<string>>() { new List<string>() { "51a38437-cd2f-4b0c-8a7e-d9b7e65a0fa2", "ca1ee4de-68ce-4f7f-b7d8-a3d15d9357c5" }, new List<string>() { "183439d2-16bc-4199-ac25-0341b46043ea", "801dd7e6-8766-414b-ae4f-8d986edb15b9" }, new List<string>() { "a1b5495c-4ea5-478a-a63b-e42b768d26a2", "6252a52a-2f88-42bb-ba90-2f0d2e23fcbc" }, new List<string>() { "5432fdad-3a47-40ce-a9b1-60259f08013c", "e832bd86-e750-44b4-bdae-c128f52997cd" }, new List<string>() { "220b8518-f833-44f5-ac97-e18e91148de3", "4d50d920-7b0f-40aa-996b-6c265db1a502" } });
            // Leito_BJ3_A2_S1
            else if (sgid == "d9da70a8-4c3c-4730-9669-512508115b11") SceneGenerate(true, 1, new string[] { "731c0cb8-33ea-4a53-9d5b-58605a552b4d", "0029cb6c-6fd2-49c6-b723-5bbe4acc80c7" });
            // Leito_BJ3_A2_S2
            else if (sgid == "48e86b0c-7adc-4e47-b0a0-c9a69a3a7bd1") SceneGenerate(true, 1, new string[] { "38ef4dfd-6881-464f-b964-0777c83f92c7", "78e40e34-40dc-49c8-ba79-dbf5b9bf8ed4" });
            // Leito_BJ3_A2_S3
            else if (sgid == "b8a30239-c38a-40ed-a6dd-005b20f69a9d") SceneGenerate(true, 1, new string[] { "35f3e72d-3478-43b8-8f9a-05a7707315d7", "4bf2a8ec-7a58-4670-b1fd-7b9280a8706f" });
            // Leito_BJ3_A2_S4
            else if (sgid == "4cf88dbc-4535-4b70-b351-4281f547d1b9") SceneGenerate(true, 1, new string[] { "7b25f18a-8e34-41ee-9a08-65817074a713", "9e93107d-7cce-4227-91cc-30276d65bdac" });
            // Leito_BJ3_A2_S5
            else if (sgid == "cc7b544b-2719-4cd5-8ca2-93bc892c95b2") SceneGenerate(true, 1, new string[] { "5c4f3aa6-44b8-4585-a7a5-11a907292392", "e91bc557-c0fe-4327-94ca-efbd03ab97e4" });
            // Leito_BJ3 Movie
            else if (sgid == "97f32a7a-d818-4ba3-8a7d-b6159aacf825") MoviewGenerate(new List<List<string>>() { new List<string>() { "731c0cb8-33ea-4a53-9d5b-58605a552b4d", "0029cb6c-6fd2-49c6-b723-5bbe4acc80c7" }, new List<string>() { "38ef4dfd-6881-464f-b964-0777c83f92c7", "78e40e34-40dc-49c8-ba79-dbf5b9bf8ed4" }, new List<string>() { "35f3e72d-3478-43b8-8f9a-05a7707315d7", "4bf2a8ec-7a58-4670-b1fd-7b9280a8706f" }, new List<string>() { "7b25f18a-8e34-41ee-9a08-65817074a713", "9e93107d-7cce-4227-91cc-30276d65bdac" }, new List<string>() { "5c4f3aa6-44b8-4585-a7a5-11a907292392", "e91bc557-c0fe-4327-94ca-efbd03ab97e4" } });
            // Leito_Cunnilingus2_A2_S1
            else if (sgid == "32b163d8-a011-4986-ba7d-2e7ce8298517") SceneGenerate(true, 1, new string[] { "0ddcea5a-a3dd-4ac3-a89e-7f80edcf856b", "9ca76bc6-9922-49fe-9dfd-61a496900028" });
            // Leito_Cunnilingus2_A2_S2
            else if (sgid == "22f950cd-af0c-4f8f-a8ad-b17e2cdd602d") SceneGenerate(true, 1, new string[] { "8a39debc-5fa1-4890-91c9-712dd8385cbc", "3cd76e32-c6df-43b0-9a36-52e905b2143d" });
            // Leito_Cunnilingus2_A2_S3
            else if (sgid == "ad999a2c-0805-41ae-b4eb-14c55798d0e4") SceneGenerate(true, 1, new string[] { "5646c057-0ada-4ffa-9467-b4e779738bd0", "378f0e38-8ab1-4453-9ee5-aecaca90c8b7" });
            // Leito_Cunnilingus2_A2_S4
            else if (sgid == "032ba93a-806a-40f0-bd23-21f35166c5ff") SceneGenerate(true, 1, new string[] { "28a1483e-052f-4b5c-8d1e-51cd749fa42b", "bbfbb320-4c79-434e-bba1-5d90e0dd895c" });
            // Leito_Cunnilingus2_A2_S5
            else if (sgid == "50097d91-1add-4c61-8bcc-6ae2fcb71d4c") SceneGenerate(true, 1, new string[] { "16a75913-c782-48ef-9896-4b9b22f3ffd2", "ce188b91-8f1d-4c9a-aa19-dd6043b81a71" });
            // Leito_Cunnilingus2 Movie
            else if (sgid == "a1216f26-d413-4acf-911b-57caa0699a0b") MoviewGenerate(new List<List<string>>() { new List<string>() { "0ddcea5a-a3dd-4ac3-a89e-7f80edcf856b", "9ca76bc6-9922-49fe-9dfd-61a496900028" }, new List<string>() { "8a39debc-5fa1-4890-91c9-712dd8385cbc", "3cd76e32-c6df-43b0-9a36-52e905b2143d" }, new List<string>() { "5646c057-0ada-4ffa-9467-b4e779738bd0", "378f0e38-8ab1-4453-9ee5-aecaca90c8b7" }, new List<string>() { "28a1483e-052f-4b5c-8d1e-51cd749fa42b", "bbfbb320-4c79-434e-bba1-5d90e0dd895c" }, new List<string>() { "16a75913-c782-48ef-9896-4b9b22f3ffd2", "ce188b91-8f1d-4c9a-aa19-dd6043b81a71" } });
            // Leito_Kissing_Female_Start_A2_S1
            else if (sgid == "120d69ad-7e8c-4fa1-bb2f-2d06bf1e1305") SceneGenerate(true, 1, new string[] { "5d1d46e8-ba6a-4cf6-b5af-9d7f480fa361", "603523f7-dbc2-4462-a860-48eb815b3b9c" });
            // Leito_Kissing_Female_Start_A2_S2
            else if (sgid == "9c2ae4aa-6a26-4264-9b92-1bfd593e7de2") SceneGenerate(true, 1, new string[] { "85803188-eef9-417b-afca-73b48711c081", "fdabad34-2e2b-4765-a5af-2abae59095a5" });
            // Leito_Kissing_Female_Start_A2_S3
            else if (sgid == "e80f048a-bc9b-40f7-8574-cabc521fbaf9") SceneGenerate(true, 1, new string[] { "c457f61f-11a8-4db4-a496-3b1d7c09a422", "000fa7cf-1d22-40b9-aa43-a707cf6c8195" });
            // Leito_Kissing_Female_Start Movie
            else if (sgid == "47dc1a49-fad8-4675-818e-d293815c3bb9") MoviewGenerate(new List<List<string>>() { new List<string>() { "5d1d46e8-ba6a-4cf6-b5af-9d7f480fa361", "603523f7-dbc2-4462-a860-48eb815b3b9c" }, new List<string>() { "85803188-eef9-417b-afca-73b48711c081", "fdabad34-2e2b-4765-a5af-2abae59095a5" }, new List<string>() { "c457f61f-11a8-4db4-a496-3b1d7c09a422", "000fa7cf-1d22-40b9-aa43-a707cf6c8195" } });
            // Leito_f_solo_dildo_anal_A1_S1
            else if (sgid == "bbec7fea-e486-4db8-8942-b865f6ea0244") SceneGenerate(true, 1, new string[] { "3f5a4317-9024-4958-a492-65bb2333c04c" });
            // Leito_f_solo_dildo_anal_A1_S2
            else if (sgid == "4e163d36-19a2-428e-b0a5-d507652c58c9") SceneGenerate(true, 1, new string[] { "3c0ece83-c33b-454f-a470-c94c26169ee2" });
            // Leito_f_solo_dildo_anal_A1_S3
            else if (sgid == "4f86a152-8b2b-407e-839c-a143e2317741") SceneGenerate(true, 1, new string[] { "8df704b6-ccf2-4b0a-8c9d-1e1f8a07ddd9" });
            // Leito_f_solo_dildo_anal_A1_S4
            else if (sgid == "edb1f227-dd09-4fe9-a0c3-b3d79a43a6a8") SceneGenerate(true, 1, new string[] { "0f1de1cf-42e4-4a9b-909c-2a18ee1d1fbf" });
            // Leito_f_solo_dildo_anal_A1_S5
            else if (sgid == "41a70dbd-41a7-4c83-803b-9e75c336381c") SceneGenerate(true, 1, new string[] { "348f4604-9b6e-445e-b8fc-4bc32e8bf0ba" });
            // Leito_f_solo_dildo_anal Movie
            else if (sgid == "8bc06b2e-6a3e-42f5-8fe7-fd3cdd137963") MoviewGenerate(new List<List<string>>() { new List<string>() { "3f5a4317-9024-4958-a492-65bb2333c04c" }, new List<string>() { "3c0ece83-c33b-454f-a470-c94c26169ee2" }, new List<string>() { "8df704b6-ccf2-4b0a-8c9d-1e1f8a07ddd9" }, new List<string>() { "0f1de1cf-42e4-4a9b-909c-2a18ee1d1fbf" }, new List<string>() { "348f4604-9b6e-445e-b8fc-4bc32e8bf0ba" } });
            // Leito_f_solo_dildo_vag_A1_S1
            else if (sgid == "a9defc06-1e72-45db-9e3b-ee13e8e271fc") SceneGenerate(true, 1, new string[] { "893f7f3e-23d9-4357-992a-12c4ad2ca1e6" });
            // Leito_f_solo_dildo_vag_A1_S2
            else if (sgid == "50a5e1cd-cc54-4d59-b63a-ccc0906cf41c") SceneGenerate(true, 1, new string[] { "6f96f6f5-eccc-4061-804d-8c450234a5a3" });
            // Leito_f_solo_dildo_vag_A1_S3
            else if (sgid == "667ebec6-2994-49ca-a598-3c8dcbb322b8") SceneGenerate(true, 1, new string[] { "73aa6483-07a1-48a0-a1ab-ed1fd797df6d" });
            // Leito_f_solo_dildo_vag_A1_S4
            else if (sgid == "a247d11a-d5eb-4087-83dc-e4f18f74bd0d") SceneGenerate(true, 1, new string[] { "56e30ee6-24a6-433b-80ae-a47ef3afdeb2" });
            // Leito_f_solo_dildo_vag_A1_S5
            else if (sgid == "ea5dc8fb-3656-43fe-8132-37d57c3635ff") SceneGenerate(true, 1, new string[] { "93a85bd0-3668-4c6b-93c0-3c45150b9ad3" });
            // Leito_f_solo_dildo_vag Movie
            else if (sgid == "ae676168-cba1-4a9c-90ac-e5366722fe54") MoviewGenerate(new List<List<string>>() { new List<string>() { "893f7f3e-23d9-4357-992a-12c4ad2ca1e6" }, new List<string>() { "6f96f6f5-eccc-4061-804d-8c450234a5a3" }, new List<string>() { "73aa6483-07a1-48a0-a1ab-ed1fd797df6d" }, new List<string>() { "56e30ee6-24a6-433b-80ae-a47ef3afdeb2" }, new List<string>() { "93a85bd0-3668-4c6b-93c0-3c45150b9ad3" } });
            // Leito_f_solo_toy_cowgirl_vag_A1_S1
            else if (sgid == "2bbdf9b1-ee36-4fd0-b07a-a0ac5bb08d8a") SceneGenerate(true, 1, new string[] { "646a8a43-f229-4162-a052-c077996499d7" });
            // Leito_f_solo_toy_cowgirl_vag_A1_S2
            else if (sgid == "dce19c94-b0de-459e-b47a-7c8db7f64a07") SceneGenerate(true, 1, new string[] { "e6b54375-84f1-4529-8e6a-6ce58fc31b35" });
            // Leito_f_solo_toy_cowgirl_vag_A1_S3
            else if (sgid == "01fe3204-6097-40c1-84f6-d6898651c223") SceneGenerate(true, 1, new string[] { "1b46d102-0ade-424e-a9dd-735428a13b64" });
            // Leito_f_solo_toy_cowgirl_vag_A1_S4
            else if (sgid == "42829cfc-9240-4fe6-847c-be90ee394c0d") SceneGenerate(true, 1, new string[] { "11150cad-3fed-4505-9f8e-dd1f6aa87c11" });
            // Leito_f_solo_toy_cowgirl_vag_A1_S5
            else if (sgid == "83354d37-c1a3-4998-979e-7dc716fad0bb") SceneGenerate(true, 1, new string[] { "31c407f9-d995-4342-a2c4-1a6588e7d6aa" });
            // Leito_f_solo_toy_cowgirl_vag_A1_S6
            else if (sgid == "c6747ac6-b37c-465e-b5f5-95c7745d092a") SceneGenerate(true, 1, new string[] { "106ef26a-9647-4eda-bf58-8475b281d509" });
            // Leito_f_solo_toy_cowgirl_vag Movie
            else if (sgid == "62f220f5-6171-4837-8594-58921988a611") MoviewGenerate(new List<List<string>>() { new List<string>() { "646a8a43-f229-4162-a052-c077996499d7" }, new List<string>() { "e6b54375-84f1-4529-8e6a-6ce58fc31b35" }, new List<string>() { "1b46d102-0ade-424e-a9dd-735428a13b64" }, new List<string>() { "11150cad-3fed-4505-9f8e-dd1f6aa87c11" }, new List<string>() { "31c407f9-d995-4342-a2c4-1a6588e7d6aa" }, new List<string>() { "106ef26a-9647-4eda-bf58-8475b281d509" } });
            // Leito_f_solo_toy_re_cow_anal_A1_S1
            else if (sgid == "c8d861c7-ae10-4337-adc8-b258e24198d1") SceneGenerate(true, 1, new string[] { "b0f06bf8-ca6d-4f11-afaa-1b259440631f" });
            // Leito_f_solo_toy_re_cow_anal_A1_S2
            else if (sgid == "a655f4b4-9ad8-417d-95c5-36f59d270d25") SceneGenerate(true, 1, new string[] { "f6882624-18c8-42bf-a566-70760582b3a3" });
            // Leito_f_solo_toy_re_cow_anal_A1_S3
            else if (sgid == "1fa8601e-2d73-451f-b451-802924325974") SceneGenerate(true, 1, new string[] { "861f5c57-e7e2-41b9-b604-1f64542934dc" });
            // Leito_f_solo_toy_re_cow_anal_A1_S4
            else if (sgid == "d850f39c-96ae-4518-a6a5-2951bb0936a5") SceneGenerate(true, 1, new string[] { "93e8720b-3869-4941-a621-1dda329032b6" });
            // Leito_f_solo_toy_re_cow_anal_A1_S5
            else if (sgid == "52e98e8c-f4cf-4b89-bb0f-e3ae146eacb8") SceneGenerate(true, 1, new string[] { "1043128d-5156-4803-a163-b92ccdf3d9ca" });
            // Leito_f_solo_toy_re_cow_anal_A1_S6
            else if (sgid == "62a32b66-65eb-486d-95ce-b369a80ae5ab") SceneGenerate(true, 1, new string[] { "259af42e-576d-4a4e-bda0-ac22a83f9f6b" });
            // Leito_f_solo_toy_re_cow_anal Movie
            else if (sgid == "6b8a8ddb-bb51-4f31-8ec5-92eeeecb06c2") MoviewGenerate(new List<List<string>>() { new List<string>() { "b0f06bf8-ca6d-4f11-afaa-1b259440631f" }, new List<string>() { "f6882624-18c8-42bf-a566-70760582b3a3" }, new List<string>() { "861f5c57-e7e2-41b9-b604-1f64542934dc" }, new List<string>() { "93e8720b-3869-4941-a621-1dda329032b6" }, new List<string>() { "1043128d-5156-4803-a163-b92ccdf3d9ca" }, new List<string>() { "259af42e-576d-4a4e-bda0-ac22a83f9f6b" } });
            // Leito_ffm_1_A3_S1
            else if (sgid == "896203cb-54b8-48b7-a488-e4e9b0e73b0d") SceneGenerate(true, 1, new string[] { "921c762b-ed0a-4ada-9a1a-23d8cd82e5ae", "6aa99d02-1cf0-4f37-9b86-459396047941", "7890f460-7e97-4dc5-a14c-7a0224c4a1b4" });
            // Leito_ffm_1_A3_S2
            else if (sgid == "875561e0-7aa6-488a-b01b-0bc1725a0e9a") SceneGenerate(true, 1, new string[] { "e1da54e0-9f07-4bbc-ba2b-139752b8f136", "bb9588da-e04a-40a5-8c8a-d04dadc2b275", "533688a1-6550-4fc6-b174-1fc1963fcb8c" });
            // Leito_ffm_1_A3_S3
            else if (sgid == "16ba5ffa-840a-414a-8363-b8deebb3d766") SceneGenerate(true, 1, new string[] { "16d2879e-3d9c-42e3-9625-adca852595cf", "ea0f5edd-b148-449e-afda-20b8ead9378f", "3072f80a-2f73-41d0-80f9-4136ed610427" });
            // Leito_ffm_1_A3_S4
            else if (sgid == "91188859-bee0-413f-a743-949928d5ba71") SceneGenerate(true, 1, new string[] { "32b6e66e-e062-43f1-a268-979e722f0022", "147b6324-ffed-4547-8aa0-4617cca28b62", "4e91ac75-2b14-4b54-8ff6-e5d29d183dad" });
            // Leito_ffm_1_A3_S5
            else if (sgid == "8e9d596c-6fa7-4486-a7ed-edab847398f7") SceneGenerate(true, 1, new string[] { "e0a3b730-42ee-4fe9-ba3b-414802da255c", "6ee40e15-2215-4524-9e63-03044aa36184", "07da546e-b7ae-4191-b0ed-9cc63252d2a4" });
            // Leito_ffm_1 Movie
            else if (sgid == "f4c353c7-a5cd-49e7-886b-94f6a679cb70") MoviewGenerate(new List<List<string>>() { new List<string>() { "921c762b-ed0a-4ada-9a1a-23d8cd82e5ae", "6aa99d02-1cf0-4f37-9b86-459396047941", "7890f460-7e97-4dc5-a14c-7a0224c4a1b4" }, new List<string>() { "e1da54e0-9f07-4bbc-ba2b-139752b8f136", "bb9588da-e04a-40a5-8c8a-d04dadc2b275", "533688a1-6550-4fc6-b174-1fc1963fcb8c" }, new List<string>() { "16d2879e-3d9c-42e3-9625-adca852595cf", "ea0f5edd-b148-449e-afda-20b8ead9378f", "3072f80a-2f73-41d0-80f9-4136ed610427" }, new List<string>() { "32b6e66e-e062-43f1-a268-979e722f0022", "147b6324-ffed-4547-8aa0-4617cca28b62", "4e91ac75-2b14-4b54-8ff6-e5d29d183dad" }, new List<string>() { "e0a3b730-42ee-4fe9-ba3b-414802da255c", "6ee40e15-2215-4524-9e63-03044aa36184", "07da546e-b7ae-4191-b0ed-9cc63252d2a4" } });
            // Leito_ffm_2_A3_S1
            else if (sgid == "c75242e8-dc5c-4b64-8174-1631d3048eff") SceneGenerate(true, 1, new string[] { "f2fdd6ed-61bf-4725-88a3-ff2d12a4db3b", "d6ad4056-afc7-4a8b-b7b4-be3f205c56fe", "cf85e34b-af82-42a8-bbdd-f0e1367ee086" });
            // Leito_ffm_2_A3_S2
            else if (sgid == "61a15ff0-9fac-45d3-bedf-25290c8735d6") SceneGenerate(true, 1, new string[] { "800b33fd-1dad-4526-a96a-c7fb3742a0bc", "de6e0d06-914e-4279-ae34-650d7d4be527", "e3b0d2f0-c0af-4a98-b40e-6677d6c4ab2f" });
            // Leito_ffm_2_A3_S3
            else if (sgid == "5724cfa9-fa73-4089-984a-ccdfe6de458d") SceneGenerate(true, 1, new string[] { "48094eb5-cc95-426e-baed-2d5996ce2aa5", "59470082-fdb2-4874-9fdd-87003f387eec", "b0222ac0-f8d7-4118-9781-0309693f54ab" });
            // Leito_ffm_2_A3_S4
            else if (sgid == "ca592d3b-3a02-4e4f-96f0-fc15ca240ba9") SceneGenerate(true, 1, new string[] { "1492b8bd-8075-4cf7-a7da-5d222da3d389", "c1e02565-3578-42c9-9e68-0940d6618914", "e3d49d68-2660-4951-86c6-304ee9623beb" });
            // Leito_ffm_2_A3_S5
            else if (sgid == "e4ebafee-3479-4915-9954-422e43084e00") SceneGenerate(true, 1, new string[] { "a8d87c4e-b62a-4e1d-ae01-87499e5c3022", "22b75d14-0b27-4642-850a-1466686da1bf", "169982b5-bd75-4aa1-91c8-7fc69da1ee5f" });
            // Leito_ffm_2 Movie
            else if (sgid == "58736620-e9b8-450f-97a9-d424873bc1f2") MoviewGenerate(new List<List<string>>() { new List<string>() { "f2fdd6ed-61bf-4725-88a3-ff2d12a4db3b", "d6ad4056-afc7-4a8b-b7b4-be3f205c56fe", "cf85e34b-af82-42a8-bbdd-f0e1367ee086" }, new List<string>() { "800b33fd-1dad-4526-a96a-c7fb3742a0bc", "de6e0d06-914e-4279-ae34-650d7d4be527", "e3b0d2f0-c0af-4a98-b40e-6677d6c4ab2f" }, new List<string>() { "48094eb5-cc95-426e-baed-2d5996ce2aa5", "59470082-fdb2-4874-9fdd-87003f387eec", "b0222ac0-f8d7-4118-9781-0309693f54ab" }, new List<string>() { "1492b8bd-8075-4cf7-a7da-5d222da3d389", "c1e02565-3578-42c9-9e68-0940d6618914", "e3d49d68-2660-4951-86c6-304ee9623beb" }, new List<string>() { "a8d87c4e-b62a-4e1d-ae01-87499e5c3022", "22b75d14-0b27-4642-850a-1466686da1bf", "169982b5-bd75-4aa1-91c8-7fc69da1ee5f" } });
            // Leito_ffm_3_A3_S1
            else if (sgid == "a2280e66-b01c-4d8b-8b71-dd35bbc3f589") SceneGenerate(true, 1, new string[] { "8341b237-5d13-4517-8b96-86ccff1c90ea", "3ab22749-6004-473c-b9f7-e0c6b81ab241", "30652522-d638-46d0-9e0d-2aff01ba8a7e" });
            // Leito_ffm_3_A3_S2
            else if (sgid == "2e925182-bed0-4db6-94d7-f6a05f655f14") SceneGenerate(true, 1, new string[] { "6e28b052-7355-4ff7-9ed3-1046092e2389", "d041edf6-7b10-4c89-b253-79db02b77316", "0437afa6-34e9-49b7-bc3a-147b54afd196" });
            // Leito_ffm_3_A3_S3
            else if (sgid == "de2f17c6-64e3-49ff-9925-334f513e90b5") SceneGenerate(true, 1, new string[] { "b3373d0e-7229-45fa-8821-2438ce4d6317", "5dda5870-8fa9-40d9-8748-2156b23f7459", "66479f6f-c5d7-4af8-bd4f-67eaf4c0cfc6" });
            // Leito_ffm_3_A3_S4
            else if (sgid == "bb774f5e-b117-48a6-8d2c-59cfd32d8b35") SceneGenerate(true, 1, new string[] { "08236774-17b9-4545-b77f-891d46ac8fa3", "2ff53731-d0ef-43b8-ad4d-78738785ab49", "c568da6a-4bd8-4c3b-b729-a398a7565d73" });
            // Leito_ffm_3_A3_S5
            else if (sgid == "ca7cacd2-0cf5-43be-8529-d181a824e7de") SceneGenerate(true, 1, new string[] { "0c7f2d21-c993-44f8-aeef-c56383a754c3", "9ed872de-be44-47af-b74c-bb756649ad69", "6a406c33-e7ac-4228-ba32-1e6bf8c0a026" });
            // Leito_ffm_3 Movie
            else if (sgid == "62c983ae-0f04-4d1e-bc0f-61afcb0daef9") MoviewGenerate(new List<List<string>>() { new List<string>() { "8341b237-5d13-4517-8b96-86ccff1c90ea", "3ab22749-6004-473c-b9f7-e0c6b81ab241", "30652522-d638-46d0-9e0d-2aff01ba8a7e" }, new List<string>() { "6e28b052-7355-4ff7-9ed3-1046092e2389", "d041edf6-7b10-4c89-b253-79db02b77316", "0437afa6-34e9-49b7-bc3a-147b54afd196" }, new List<string>() { "b3373d0e-7229-45fa-8821-2438ce4d6317", "5dda5870-8fa9-40d9-8748-2156b23f7459", "66479f6f-c5d7-4af8-bd4f-67eaf4c0cfc6" }, new List<string>() { "08236774-17b9-4545-b77f-891d46ac8fa3", "2ff53731-d0ef-43b8-ad4d-78738785ab49", "c568da6a-4bd8-4c3b-b729-a398a7565d73" }, new List<string>() { "0c7f2d21-c993-44f8-aeef-c56383a754c3", "9ed872de-be44-47af-b74c-bb756649ad69", "6a406c33-e7ac-4228-ba32-1e6bf8c0a026" } });
            // Leito_mmf_1_A3_S1
            else if (sgid == "eb9e51ad-a052-4236-8eaf-20e572db9962") SceneGenerate(true, 1, new string[] { "b649bb08-9fdf-47ce-87dc-28eed16970bc", "37b314d1-4142-47bc-b4ed-5534b5935cd2", "ec118c48-d1eb-4556-af22-84c97ca78126" });
            // Leito_mmf_1_A3_S2
            else if (sgid == "7e1e55ee-a85b-434b-bd10-d6baf19d4151") SceneGenerate(true, 1, new string[] { "3d1874cb-81c2-4ce4-9f55-089fa8871288", "d8b1522e-8470-4651-b800-98408d9ca0e5", "809325c2-00ca-49e5-b05a-48a97e448365" });
            // Leito_mmf_1_A3_S3
            else if (sgid == "473522cf-f84d-46f2-bf27-39210fee39d4") SceneGenerate(true, 1, new string[] { "3620064f-4e03-4774-a0e1-f1b8ff13f2ef", "3a7b1ac4-599e-41a0-8a6a-c37417ea89cd", "6cbef803-45af-43cb-967f-24c2e2de4bce" });
            // Leito_mmf_1_A3_S4
            else if (sgid == "2d277d1f-db7e-425e-8d1b-fcd3aa3ed690") SceneGenerate(true, 1, new string[] { "09828945-5e2d-4c9a-a20e-0e46d316802e", "8999c499-8df1-403f-aff0-a9f72b195133", "524c1584-699c-42af-a9c5-c3a4942b9891" });
            // Leito_mmf_1_A3_S5
            else if (sgid == "c0f18d6e-f186-4604-ba0f-795508734bc1") SceneGenerate(true, 1, new string[] { "541a561c-18a8-436a-a6ae-7481b9b4d7ee", "a4e296ce-27d8-4329-9ab2-bfba6a36cca3", "27182e0f-6a04-40d7-9beb-ada736a88a6a" });
            // Leito_mmf_1 Movie
            else if (sgid == "758e75ff-c55f-4563-b686-e5afe505a961") MoviewGenerate(new List<List<string>>() { new List<string>() { "b649bb08-9fdf-47ce-87dc-28eed16970bc", "37b314d1-4142-47bc-b4ed-5534b5935cd2", "ec118c48-d1eb-4556-af22-84c97ca78126" }, new List<string>() { "3d1874cb-81c2-4ce4-9f55-089fa8871288", "d8b1522e-8470-4651-b800-98408d9ca0e5", "809325c2-00ca-49e5-b05a-48a97e448365" }, new List<string>() { "3620064f-4e03-4774-a0e1-f1b8ff13f2ef", "3a7b1ac4-599e-41a0-8a6a-c37417ea89cd", "6cbef803-45af-43cb-967f-24c2e2de4bce" }, new List<string>() { "09828945-5e2d-4c9a-a20e-0e46d316802e", "8999c499-8df1-403f-aff0-a9f72b195133", "524c1584-699c-42af-a9c5-c3a4942b9891" }, new List<string>() { "541a561c-18a8-436a-a6ae-7481b9b4d7ee", "a4e296ce-27d8-4329-9ab2-bfba6a36cca3", "27182e0f-6a04-40d7-9beb-ada736a88a6a" } });
            // Leito_mmf_2_A3_S1
            else if (sgid == "3c526946-52aa-48aa-84b9-c2490b7597c6") SceneGenerate(true, 1, new string[] { "589dda1f-2f6f-411c-853d-cf12054cc3c7", "436de71c-5f48-421b-8e72-618a17090839", "aa5416ad-0f1a-4e7e-b97f-79518d0bba62" });
            // Leito_mmf_2_A3_S2
            else if (sgid == "38cc991a-f6a7-4338-b2d3-8d0518805d66") SceneGenerate(true, 1, new string[] { "8fe4f381-40c9-45ea-8e9e-8a4f5cb5fd67", "a1ab7e28-2a66-466b-9b3e-fafac8209584", "ceb0af98-fca7-438e-9038-f073a073c927" });
            // Leito_mmf_2_A3_S3
            else if (sgid == "017dfcd2-da6c-4440-9d1e-8f8b8862c328") SceneGenerate(true, 1, new string[] { "2df781ce-d6a9-44a2-be68-8baa1a5515f7", "7a40fe6b-ce59-4357-a5d7-3ae43bd166fb", "86be56a5-3d03-4c50-899e-3741d8e3ab1e" });
            // Leito_mmf_2_A3_S4
            else if (sgid == "92ee34be-6fa9-4418-b0b0-b7166e70ef2f") SceneGenerate(true, 1, new string[] { "b2fd3d66-bd32-46ef-bafc-4b641755c43f", "a94fa0a9-a49c-4abb-8dc8-99959c21bb13", "70cb720e-145c-47ad-82f1-403b124737d9" });
            // Leito_mmf_2_A3_S5
            else if (sgid == "80a50afc-ac24-48c5-9ec0-1f8f4243e36a") SceneGenerate(true, 1, new string[] { "dc558115-4cd6-4a0a-a5f2-483a4358d034", "6a56ca52-ada2-4001-b2fc-2978a771ddb5", "293bd19e-7585-490e-bff4-430dbf22acf7" });
            // Leito_mmf_2 Movie
            else if (sgid == "326774a3-f186-4d9e-b6cf-d6bfe471f7c4") MoviewGenerate(new List<List<string>>() { new List<string>() { "589dda1f-2f6f-411c-853d-cf12054cc3c7", "436de71c-5f48-421b-8e72-618a17090839", "aa5416ad-0f1a-4e7e-b97f-79518d0bba62" }, new List<string>() { "8fe4f381-40c9-45ea-8e9e-8a4f5cb5fd67", "a1ab7e28-2a66-466b-9b3e-fafac8209584", "ceb0af98-fca7-438e-9038-f073a073c927" }, new List<string>() { "2df781ce-d6a9-44a2-be68-8baa1a5515f7", "7a40fe6b-ce59-4357-a5d7-3ae43bd166fb", "86be56a5-3d03-4c50-899e-3741d8e3ab1e" }, new List<string>() { "b2fd3d66-bd32-46ef-bafc-4b641755c43f", "a94fa0a9-a49c-4abb-8dc8-99959c21bb13", "70cb720e-145c-47ad-82f1-403b124737d9" }, new List<string>() { "dc558115-4cd6-4a0a-a5f2-483a4358d034", "6a56ca52-ada2-4001-b2fc-2978a771ddb5", "293bd19e-7585-490e-bff4-430dbf22acf7" } });
            // Leito_mmf_3_A3_S1
            else if (sgid == "d830ed02-c0de-4824-bc44-26443532f98a") SceneGenerate(true, 1, new string[] { "b3781910-45db-41a1-bd2b-a62346b0827d", "70f994f4-0e5f-4dd4-9c48-21fa534e5c3a", "cf67daf0-e26d-454a-817b-c2ae73fa6647" });
            // Leito_mmf_3_A3_S2
            else if (sgid == "e9820ac9-1d01-4d57-82ee-f50289626953") SceneGenerate(true, 1, new string[] { "a548efdf-d137-4e0b-9641-8b98f89d6af3", "3e13798f-f332-4aed-83e5-b9799e8321de", "20efa819-a140-4491-8d09-eb5bb623db1f" });
            // Leito_mmf_3_A3_S3
            else if (sgid == "84a87800-743c-433a-96e5-6baf05015c76") SceneGenerate(true, 1, new string[] { "3ecc4951-5da0-49cb-ad67-b9b01d4432c7", "4930fc90-a458-432c-ad41-dae205dfc0dc", "a1ddcda9-5004-4f6a-8fdc-021c29c6fdac" });
            // Leito_mmf_3_A3_S4
            else if (sgid == "556953ef-51ca-44ff-aa78-051af0d15e4c") SceneGenerate(true, 1, new string[] { "a06bbbdb-bb3a-44f8-b3a0-f0b12ef3106c", "8029d0de-f710-4799-aaa6-20cfd8cc5bc6", "0f96acbe-94a2-42b0-86f5-1397cd10cf4b" });
            // Leito_mmf_3_A3_S5
            else if (sgid == "8046e897-d8d9-49d7-a2d5-301950508993") SceneGenerate(true, 1, new string[] { "99747260-34f2-4f5d-8f7b-4c4bdb9aa7f5", "fddaf3c7-a844-4063-acc5-ffb02fa29c7e", "964231d3-b3af-487d-8dfa-7a8251347ee9" });
            // Leito_mmf_3 Movie
            else if (sgid == "1161e728-69ad-46e2-8bae-cedf6c621802") MoviewGenerate(new List<List<string>>() { new List<string>() { "b3781910-45db-41a1-bd2b-a62346b0827d", "70f994f4-0e5f-4dd4-9c48-21fa534e5c3a", "cf67daf0-e26d-454a-817b-c2ae73fa6647" }, new List<string>() { "a548efdf-d137-4e0b-9641-8b98f89d6af3", "3e13798f-f332-4aed-83e5-b9799e8321de", "20efa819-a140-4491-8d09-eb5bb623db1f" }, new List<string>() { "3ecc4951-5da0-49cb-ad67-b9b01d4432c7", "4930fc90-a458-432c-ad41-dae205dfc0dc", "a1ddcda9-5004-4f6a-8fdc-021c29c6fdac" }, new List<string>() { "a06bbbdb-bb3a-44f8-b3a0-f0b12ef3106c", "8029d0de-f710-4799-aaa6-20cfd8cc5bc6", "0f96acbe-94a2-42b0-86f5-1397cd10cf4b" }, new List<string>() { "99747260-34f2-4f5d-8f7b-4c4bdb9aa7f5", "fddaf3c7-a844-4063-acc5-ffb02fa29c7e", "964231d3-b3af-487d-8dfa-7a8251347ee9" } });
            // Leito_Cowgirl_2_A2_S1
            else if (sgid == "bac56fd0-54fe-4d62-822c-4e8a34a4d8de") SceneGenerate(true, 1, new string[] { "5955657c-9437-4c26-86f9-ebec1091bb1f", "d00c5b98-2a2f-4b96-9347-75136cc65dd5" });
            // Leito_Cowgirl_2_A2_S2
            else if (sgid == "31b6a4e6-481e-4255-845b-8a6310ad6415") SceneGenerate(true, 1, new string[] { "57723efd-c7f8-4b06-b3a5-656cce7d540f", "1a2a66b7-9391-4088-a076-342025e6afa4" });
            // Leito_Cowgirl_2_A2_S3
            else if (sgid == "43e20868-2c45-479a-a885-c9bf2fdb1611") SceneGenerate(true, 1, new string[] { "8c8f7b39-00bd-4cba-adcd-9ab6bfd702d6", "2ad2d22c-bdca-49ad-9f59-945a9dea84d5" });
            // Leito_Cowgirl_2_A2_S4
            else if (sgid == "69e66395-8f30-4e02-9545-d7020e314c31") SceneGenerate(true, 1, new string[] { "86d662a6-18b6-49fb-8316-e8906de2e43f", "c6c813a6-2844-4741-a9f0-9330e739f690" });
            // Leito_Cowgirl_2_A2_S5
            else if (sgid == "7c4bf0a5-96c7-4aa7-8ea3-79b8a1b8ad5e") SceneGenerate(true, 1, new string[] { "33498298-46cc-4856-a3ad-da1093990f39", "05bf46e9-97dd-43df-a7c0-e89b48a0c190" });
            // Leito_Cowgirl_2 Movie
            else if (sgid == "626ceb8f-ad43-4734-ad52-bccbdba1d838") MoviewGenerate(new List<List<string>>() { new List<string>() { "5955657c-9437-4c26-86f9-ebec1091bb1f", "d00c5b98-2a2f-4b96-9347-75136cc65dd5" }, new List<string>() { "57723efd-c7f8-4b06-b3a5-656cce7d540f", "1a2a66b7-9391-4088-a076-342025e6afa4" }, new List<string>() { "8c8f7b39-00bd-4cba-adcd-9ab6bfd702d6", "2ad2d22c-bdca-49ad-9f59-945a9dea84d5" }, new List<string>() { "86d662a6-18b6-49fb-8316-e8906de2e43f", "c6c813a6-2844-4741-a9f0-9330e739f690" }, new List<string>() { "33498298-46cc-4856-a3ad-da1093990f39", "05bf46e9-97dd-43df-a7c0-e89b48a0c190" } });
            // Leito_Doggy_2_A2_S1
            else if (sgid == "77c843d2-720a-4109-b857-8d3a87082663") SceneGenerate(true, 1, new string[] { "0113faa3-1eb9-4481-9d9d-623b967141e4", "b0845755-bf07-46e9-b8e1-781128d2d4c7" });
            // Leito_Doggy_2_A2_S2
            else if (sgid == "af08e238-40d5-442d-a27e-d22ed3a900bc") SceneGenerate(true, 1, new string[] { "21bff716-18e4-449a-9b9d-ea3a0eae1303", "1a99c7f4-1be6-4a30-82de-52aeb21cb67e" });
            // Leito_Doggy_2_A2_S3
            else if (sgid == "eef9ead5-d671-4ef9-96b1-f7caef86d4b9") SceneGenerate(true, 1, new string[] { "b1e7fcd2-c189-4f1a-b7cc-3743bfc2c847", "f0abf8b1-8cdd-41f1-8ded-15d1f95a5596" });
            // Leito_Doggy_2_A2_S4
            else if (sgid == "f2c30940-26e6-4fa6-8763-8b111e47f76f") SceneGenerate(true, 1, new string[] { "340bc64f-7bfd-4595-8e23-a1b6a853ca39", "d04c3816-74ac-49db-94d0-378a2c356477" });
            // Leito_Doggy_2_A2_S5
            else if (sgid == "0d28488e-1b18-4ddd-9f06-a8315c2e903f") SceneGenerate(true, 1, new string[] { "be6ff94b-b84e-4e97-abc5-4d72105c7b06", "5976e999-1da4-4ad5-8121-781310be63ba" });
            // Leito_Doggy_2 Movie
            else if (sgid == "91d9b3d9-d804-4fa9-8afc-44439f2f3401") MoviewGenerate(new List<List<string>>() { new List<string>() { "0113faa3-1eb9-4481-9d9d-623b967141e4", "b0845755-bf07-46e9-b8e1-781128d2d4c7" }, new List<string>() { "21bff716-18e4-449a-9b9d-ea3a0eae1303", "1a99c7f4-1be6-4a30-82de-52aeb21cb67e" }, new List<string>() { "b1e7fcd2-c189-4f1a-b7cc-3743bfc2c847", "f0abf8b1-8cdd-41f1-8ded-15d1f95a5596" }, new List<string>() { "340bc64f-7bfd-4595-8e23-a1b6a853ca39", "d04c3816-74ac-49db-94d0-378a2c356477" }, new List<string>() { "be6ff94b-b84e-4e97-abc5-4d72105c7b06", "5976e999-1da4-4ad5-8121-781310be63ba" } });
            // Leito_Lotus_A2_S1
            else if (sgid == "9f446b62-9e87-46bd-8182-e9e8fb343ffc") SceneGenerate(true, 1, new string[] { "86913856-290c-49a2-913c-003671b2983a", "b7439044-f9d9-4b2f-96d0-2a4843148b2b" });
            // Leito_Lotus_A2_S2
            else if (sgid == "959b08ae-d8a5-4468-a428-e1b3681da7ff") SceneGenerate(true, 1, new string[] { "9f960214-c399-4bb7-8615-d76c58624aa8", "4fbc38fc-cb2e-4f3a-be04-f6e737b3951c" });
            // Leito_Lotus_A2_S3
            else if (sgid == "ad6948ac-348e-408e-8408-41133566cdac") SceneGenerate(true, 1, new string[] { "7b102218-9b13-4aa8-a053-625b6dc449d8", "4cd875bf-0a20-4878-bd1f-a273b558eb40" });
            // Leito_Lotus_A2_S4
            else if (sgid == "b6797202-7f98-4794-bc72-8c8b13e85d72") SceneGenerate(true, 1, new string[] { "7b974166-821c-47f9-a8b6-8a48c95f8003", "72e02319-57b0-40cd-aba2-54a68cab7965" });
            // Leito_Lotus_A2_S5
            else if (sgid == "0658758c-dd7a-4c88-9596-42c0f35505d7") SceneGenerate(true, 1, new string[] { "2dc84dce-238d-4997-9812-155e95a7ca42", "e4d5ae83-1156-433c-a67b-776a4ae44ee8" });
            // Leito_Lotus Movie
            else if (sgid == "e935cf4e-97eb-40c3-9057-a5c560876449") MoviewGenerate(new List<List<string>>() { new List<string>() { "86913856-290c-49a2-913c-003671b2983a", "b7439044-f9d9-4b2f-96d0-2a4843148b2b" }, new List<string>() { "9f960214-c399-4bb7-8615-d76c58624aa8", "4fbc38fc-cb2e-4f3a-be04-f6e737b3951c" }, new List<string>() { "7b102218-9b13-4aa8-a053-625b6dc449d8", "4cd875bf-0a20-4878-bd1f-a273b558eb40" }, new List<string>() { "7b974166-821c-47f9-a8b6-8a48c95f8003", "72e02319-57b0-40cd-aba2-54a68cab7965" }, new List<string>() { "2dc84dce-238d-4997-9812-155e95a7ca42", "e4d5ae83-1156-433c-a67b-776a4ae44ee8" } });
            // Leito_Missionary_3_A2_S1
            else if (sgid == "b7e4924e-9b97-4375-958a-e29c6b3efddd") SceneGenerate(true, 1, new string[] { "be466a17-52e6-4a64-86ca-88b8e7e03038", "68a60e4b-e9ac-4298-a407-1cb715ea2e8a" });
            // Leito_Missionary_3_A2_S2
            else if (sgid == "e4860150-4a59-495a-a84b-5d168c756461") SceneGenerate(true, 1, new string[] { "706800b3-f9c2-4d90-8502-efd698fa15c9", "60e2d43e-af1b-4975-8cbf-300b3c4c2851" });
            // Leito_Missionary_3_A2_S3
            else if (sgid == "14f39d1f-1bf0-4f47-b2ba-6ceca3100d02") SceneGenerate(true, 1, new string[] { "8aa46033-ef76-4d98-8c1f-66a77853754e", "bb85cc13-a291-4e75-85ab-d8d8f0657eb4" });
            // Leito_Missionary_3_A2_S4
            else if (sgid == "7fad3d8b-af2f-4ef1-9ebf-02e553d8ae71") SceneGenerate(true, 1, new string[] { "e05e252f-2faa-4386-ac95-6edc1e2c4654", "e03b7b43-48ae-4306-849c-fb323532055e" });
            // Leito_Missionary_3_A2_S5
            else if (sgid == "65d9b742-f0ec-4a23-914a-602d32ae3be3") SceneGenerate(true, 1, new string[] { "e29e086d-f2b9-4377-a199-aab1e3ad42f3", "6d0f4f6e-d48c-48e9-9028-8de48eb6f790" });
            // Leito_Missionary_3 Movie
            else if (sgid == "c8973570-b72d-4557-8f42-adeef76c25a9") MoviewGenerate(new List<List<string>>() { new List<string>() { "be466a17-52e6-4a64-86ca-88b8e7e03038", "68a60e4b-e9ac-4298-a407-1cb715ea2e8a" }, new List<string>() { "706800b3-f9c2-4d90-8502-efd698fa15c9", "60e2d43e-af1b-4975-8cbf-300b3c4c2851" }, new List<string>() { "8aa46033-ef76-4d98-8c1f-66a77853754e", "bb85cc13-a291-4e75-85ab-d8d8f0657eb4" }, new List<string>() { "e05e252f-2faa-4386-ac95-6edc1e2c4654", "e03b7b43-48ae-4306-849c-fb323532055e" }, new List<string>() { "e29e086d-f2b9-4377-a199-aab1e3ad42f3", "6d0f4f6e-d48c-48e9-9028-8de48eb6f790" } });
            // Leito_Standing_2_A2_S1
            else if (sgid == "e8e31894-2845-47cc-91ee-04d0885ae82e") SceneGenerate(true, 1, new string[] { "aa3af0a5-99bc-4582-b551-529dc84740d8", "6d601768-b220-4ca7-b7d2-149227cef9ad" });
            // Leito_Standing_2_A2_S2
            else if (sgid == "ca8fd780-fca4-42a8-94a2-100917a7f158") SceneGenerate(true, 1, new string[] { "57f3a7a4-7ebc-4923-8f17-cf90b91768bb", "1abee37d-b70e-4922-afec-a04d4f7658ab" });
            // Leito_Standing_2_A2_S3
            else if (sgid == "c0ebbbcf-9605-4fee-bfdb-63135fb0bc23") SceneGenerate(true, 1, new string[] { "f125fd6f-590a-4eac-8cda-33bc85dd6aaa", "cc5fc990-222c-4194-b119-9b57a1d505b8" });
            // Leito_Standing_2_A2_S4
            else if (sgid == "b7800bf4-7622-4036-8b42-886074d262ce") SceneGenerate(true, 1, new string[] { "a50f0114-2ba9-4912-9fe1-a5f1756da18d", "4ab7e7e7-f066-4639-a7c0-c5f29c2035a8" });
            // Leito_Standing_2_A2_S5
            else if (sgid == "0d78dd96-d159-4b55-85d3-e81e956fd6b2") SceneGenerate(true, 1, new string[] { "8cfbb186-c515-46f6-9f25-1ed81891d918", "e46d18ab-0348-4540-9b30-de183d054b3c" });
            // Leito_Standing_2 Movie
            else if (sgid == "edd4c8a0-8b33-4a88-8151-b7c252225ad9") MoviewGenerate(new List<List<string>>() { new List<string>() { "aa3af0a5-99bc-4582-b551-529dc84740d8", "6d601768-b220-4ca7-b7d2-149227cef9ad" }, new List<string>() { "57f3a7a4-7ebc-4923-8f17-cf90b91768bb", "1abee37d-b70e-4922-afec-a04d4f7658ab" }, new List<string>() { "f125fd6f-590a-4eac-8cda-33bc85dd6aaa", "cc5fc990-222c-4194-b119-9b57a1d505b8" }, new List<string>() { "a50f0114-2ba9-4912-9fe1-a5f1756da18d", "4ab7e7e7-f066-4639-a7c0-c5f29c2035a8" }, new List<string>() { "8cfbb186-c515-46f6-9f25-1ed81891d918", "e46d18ab-0348-4540-9b30-de183d054b3c" } });



            //else GenerateMotionOld(epitem, items);


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
        private static void RebuildScript(List<SkyrimScene> scenes)
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
            foreach (var item in scenes)
            {
                source.Add($@"    ElseIf   (Stage == {item.Stage})");
                source.Add($@"    Acycle[{item.Stage}] = {item.Acycle}");
                foreach (var pose in item.Poses)
                {
                    source.Add($@"      ActorAlias(Positions[{pose.Position - 1}]).AB_SetSchlong({pose.SOS})");
                }
            }
            source.Add(@"    Endif");
            source.Add($@"    AB_RestartStage = {scenes.Count() + 1}");
            source.Add($@"    AB_RestartTo = {scenes.IndexOf(scenes.Where(x=>x.Repeatable).FirstOrDefault())}");

            source.Add(@"endFunction");
            for (int i = 0; i < 4; i++)
            {
                source.Add($@"function RefreshEmotion{i}()");
                source.Add(@"    If       (Stage == 0)");
                foreach (var item in scenes)
                {
                    source.Add($@"    ElseIf   (Stage == {item.Stage})");
                    var actor = item.Actor(i);
                    if (actor != null)
                    {
                        source.AddRange(actor.GetEmotionData());
                    }
                }
                source.Add(@"    Endif");
                source.Add(@"endFunction");
            }

            for (int i = 0; i < 4; i++)
            {
                source.Add($@"function RefreshCloth{i}()");
                source.Add(@"    If       (Stage == 0)");
                foreach (var item in scenes)
                {
                    source.Add($@"    ElseIf   (Stage == {item.Stage})");
                    var actor = item.Actor(i);
                    if (actor != null)
                    {
                        source.AddRange(actor.GetClothData());
                    }
                }
                source.Add(@"    Endif");
                source.Add(@"endFunction");
            }

            File.WriteAllLines(sourceFile, source);
            reBuild();
        }

        private static List<SkyrimScene> SceneGenerate(bool complete, int stageStart, params string[] posArray)
        {
            int currStage = stageStart;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            SkyrimScene p;
            p = new SkyrimScene(currStage++, posArray);
            scenes.Add(p);
            currStage++;
            if (complete)
            {
                foreach (var pose in scenes)
                {
                    pose.CopyToDestination();
                }
                RebuildScript(scenes);
            }
            return scenes;
        }
        private static bool MoviewGenerate(List<List<string>> data)
        {
            int currStage = 1;
            List<SkyrimScene> scenes = new List<SkyrimScene>();
            foreach (var item in data)
            {
                SkyrimScene p;
                p = new SkyrimScene(currStage++, item.ToArray());
                scenes.Add(p);
            }

            foreach (var pose in scenes)
            {
                pose.CopyToDestination();
            }
            RebuildScript(scenes);
            return true;
        }

        #endregion

        #region Code generation

        static string animationListPath = @"d:\SteamLibrary\steamapps\common\Skyrim\Data\Meshes\actors\character\animations\AnimationsByLeito";
        static string animationSerie = @"AnimationsByLeito";
        static string catalogPathPose = @"d:\!CATALOG\SKY\Pose";
        static string catalogPathMotion = @"d:\!CATALOG\SKY\Motion";
        static string catalogPathMovie = @"d:\!CATALOG\SKY\Movie";
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
            List<string> moviePairs = new List<string>();
            for (int sta = 1; sta <= staN; sta++)
            {
                List<string> gids = new List<string>();
                for (int pos = 1; pos <= posN; pos++)
                {
                    // dir creation and file copy
                    string fn = $"{name}_A{pos}_S{sta}";
                    string fulldirpath = Path.Combine(catalogPathPose, animationSerie, name, fn);
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

                    gids.Add($@"""{newItem.GID.ToString()}""");

                    // Motion creation
                    if (pos == posN)
                    {
                        fn = $"{name} S{sta}";
                        fulldirpath = Path.Combine(catalogPathMotion, animationSerie, name, $"{name} S{sta}");
                        if (!Directory.Exists(fulldirpath))
                        {
                            Directory.CreateDirectory(fulldirpath);
                        }
                        // EpItem creation
                        newItem = new EpItem(0);
                        newItem.Name = $"{name} S{sta}";
                        newItem.Catalog = "SKY";
                        newItem.Kind = "MOTION";
                        newItem.Stage = $"{sta}";
                        passport = EpItem.SetToPassport(newItem);
                        File.WriteAllLines(Path.Combine(fulldirpath, "PASSPORT.TXT"), passport);

                        string gidss = string.Join(",", gids.ToArray());
                        moviePairs.Add("new List<string>() {" + gidss + "}");

                        string line = $"// {name}_A{pos}_S{sta}";
                        codeGenerated.Add(line);
                        line = @"else if (sgid == """ + newItem.GID.ToString() + @""") SceneGenerate(true, 1, new string[] { " + gidss + " });";
                        codeGenerated.Add(line);

                        // Movie creation
                        if (sta == staN)
                        {
                            fulldirpath = Path.Combine(catalogPathMovie, animationSerie, name);
                            if (!Directory.Exists(fulldirpath))
                            {
                                Directory.CreateDirectory(fulldirpath);
                            }
                            // EpItem creation
                            newItem = new EpItem(0);
                            newItem.Name = name;
                            newItem.Catalog = "SKY";
                            newItem.Kind = "MOVIE";
                            newItem.Stage = $"{staN}";
                            passport = EpItem.SetToPassport(newItem);
                            File.WriteAllLines(Path.Combine(fulldirpath, "PASSPORT.TXT"), passport);

                            line = $"// {name} Movie";
                            codeGenerated.Add(line);
                            line = @"else if (sgid == """ + newItem.GID.ToString() + @""") MoviewGenerate(new List<List<string>>() {" + string.Join(",", moviePairs.ToArray()) + "} );";
                            codeGenerated.Add(line);

                        }
                    }

                }
            }
        }

        #endregion

    }
}
