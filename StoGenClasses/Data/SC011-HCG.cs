using StoGenMake.Persona;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data
{
    public class SC011_HCG: BaseScene
    {
        public class Lady_LinaMoana_Face01 : Personality
        {
            #region Text
            public static string Story1 = "";
            #endregion
            public static string CName = "Lady_LinaMoana_Face01";
            public static int Variants = 2;
            public Lady_LinaMoana_Face01(BaseScene scene) : base(scene)
            {
                this.Name = CName;

                #region Body            
                BodyList.Add("ERECTLIP_BakunyuuOnsen_PNG_001");
                #endregion

                #region Face
                FaceList.Add("ERECTLIP_BakunyuuOnsen_PNG_002");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  {   S = 740},
            new DifData(FaceList[0],BodyList[0]) {X = 370, Y = -62, S = 370, F = 0},
            });
                #endregion

                #region Lips           
                LipsList.Add("ERECTLIP_BakunyuuOnsen_PNG_008");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 370 },
                new DifData(LipsList[0], FaceList[0]) {X = 100, Y = 240, S = 41, F = 0},
                });
                #endregion

                #region Parts   
                //hand right of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_003");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=740},
            new DifData(PartList[0],BodyList[0]) { X = 252, Y = 253, S = 151, F = 0},
            });
                //hand left of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_004");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=740},
            new DifData(PartList[1],BodyList[0]) {  X = 385, Y = 274, S = 421, F = 0 },
            });
                //bust of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_005");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=740},
            new DifData(PartList[2],BodyList[0]) {   X = 81, Y = 315, S = 518, F = 0 },
            });
                //left leg of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_006");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=740},
            new DifData(PartList[3],BodyList[0]) {  X = 495, Y = 560, S = 194, F = 0 },
            });
                //right leg of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_007");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=740},
            new DifData(PartList[4],BodyList[0]) {  X = 20, Y = 610, S = 359, F = 0 },
            });
                #endregion

                // set default body
                SetBody(BodyList[0], new DifData() { Y=50, S = 740 });
                // set default head
                SetHead(FaceList[0]);
                // set default lips
                SetLips(LipsList[0]);
            }
            public static List<DifData> Get(BaseScene scene, int var, DifData delta = null)
            {
                Lady_LinaMoana_Face01 inst = new Lady_LinaMoana_Face01(scene);
                inst.Variant = var;
                return inst.Get(delta);
            }
            public override List<DifData> Get(DifData delta = null)
            {
                List<DifData> result = base.Get(delta);
                if (this.Body.Name == this.BodyList[0])
                {
                    if (Variant == 1)
                    {
                        //hand right  X = 252, Y = 253 (X = 302, Y = 233)
                        result.Insert(1, new DifData(PartList[0], BodyList[0]) { Xd = 50, Yd = -20, S = 151, R = -14, F = 0 });
                        //hand left   X = 385, Y = 274 (X = 347, Y = 257, S = 421, R = 12, F = 0)
                        result.Insert(1, new DifData(PartList[1], BodyList[0]) { Xd = -38, Yd = -17, S = 421, R = 12, F = 0 });
                        //bust X = 81, Y = 315,
                        result.Insert(1, new DifData(PartList[2], BodyList[0]) {  Xd=170, Yd=-40, S = 343});
                        //left leg X = 495, Y = 560 (X = 460, Y = 397, S = 194, F = 0)
                        result.Insert(1, new DifData(PartList[3], BodyList[0]) { Xd = -35, Yd = -163, S = 194, F = 0 });
                        //right leg X = 20, Y = 610 (X = 120, Y = 445, S = 359, F = 0)
                        result.Insert(1, new DifData(PartList[4], BodyList[0]) { Xd = 100, Yd = -165, S = 359, F = 0 });
                    }
                    else
                    {
                        //hand right
                        result.Insert(1, new DifData(PartList[0], BodyList[0]));
                        //hand left
                        result.Insert(1, new DifData(PartList[1], BodyList[0]));
                        //bust
                        result.Insert(1, new DifData(PartList[2], BodyList[0]));
                        //left leg
                        result.Insert(1, new DifData(PartList[3], BodyList[0]));
                        //right leg
                        result.Insert(1, new DifData(PartList[4], BodyList[0]));
                    }
                }
                result.Add(new DifData(Devil.ManOld_001) { X = 740, Y = -5, S = 1000, F = 0 });
                return result;
            }
        }

        public SC011_HCG() : base()
        {
            Name = "SC011_HCG";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void LoadData()
        {
            string path = null;

            string src = null;
            string fn = null;          
            string gr = null;

            #region [ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~

            gr = "[ERECTLIP] Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~2";
            //path = @"z:\HCG\ERECTLIP\Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~\";
            path = @"d:\PicWork\";
            for (int i = 1; i <= 38; i++)
            {
                src = $"ERECTLIP_BakunyuuOnsen_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion            
        }
    }

}
