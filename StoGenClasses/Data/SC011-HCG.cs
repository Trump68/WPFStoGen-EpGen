using StoGenMake.Persona;
using StoGenMake.Scenes;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;
using System.Linq;
using StoGen.Classes.Transition;
namespace StoGen.Classes.Data
{
    public class SC011_HCG : BaseScene
    {
        public static string Lips01 = "ERECTLIP_BakunyuuOnsen_PNG_008";
        public static string Lips02 = "ERECTLIP_BakunyuuOnsen_PNG_012";
        public static string Lips03 = "ERECTLIP_BakunyuuOnsen_PNG_014";
        public static string Lips04 = "ERECTLIP_BakunyuuOnsen_PNG_016";
        public static string Lips05 = "ERECTLIP_BakunyuuOnsen_PNG_018";
        public static string Lips06 = "ERECTLIP_BakunyuuOnsen_PNG_022";
        public static string Lips07 = "ERECTLIP_BakunyuuOnsen_PNG_023";
        public static string Lips08 = "ERECTLIP_BakunyuuOnsen_PNG_025";
        public static string Lips09 = "ERECTLIP_BakunyuuOnsen_PNG_026";
        public class Lady_LinaMoana_Face01 : Personality
        {
            #region Text
            public static string Story1 = "";
            #endregion
            public static string CName = "Lady_LinaMoana_Face01";
            public static int Variants = 2;
            public Lady_LinaMoana_Face01(BaseScene scene, string name) : base(scene,name)
            {
                #region Body            
                BodyList.Add("ERECTLIP_BakunyuuOnsen_PNG_001");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(BodyList[0],this.Name) {S = 740, F = 0},
                });
                #endregion

                #region Face
                FaceList.Add("ERECTLIP_BakunyuuOnsen_PNG_002");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(FaceList[0], this.Name) {X = 370, Y = -62, S = 370, F = 0},
                });
                #endregion

                #region Lips           
                LipsList.Add(SC011_HCG.Lips01);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 370 },
                new DifData(LipsList[0], FaceList[0]) {X = 105, Y = 240, S = 41, F = 0},
                });
                #endregion

                #region Parts   
                //hand right of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_003");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[0],this.Name) { X = 252, Y = 253, S = 151, F = 0},
                });
                //hand left of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_004");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[1],this.Name) {  X = 385, Y = 274, S = 421, F = 0 },
                 });
                //bust of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_005");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[2],this.Name) {   X = 81, Y = 315, S = 518, F = 0 },
                });
                //left leg of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_006");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[3],this.Name) {  X = 495, Y = 560, S = 194, F = 0 },
                });
                //right leg of body01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_007");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[4],this.Name) {  X = 20, Y = 610, S = 359, F = 0 },
                });
                //Closed eyes head01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_009");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0])  { S=370},
                new DifData(PartList[5],FaceList[0]) { O = 0, X = 46, Y = 133, S = 155, F = 0 },
                });
                #endregion

                Canvas.Y = 50;
                // set default body
                SetBody(BodyList[0]);
                // set default head
                SetHead(FaceList[0]);
                // set default lips
                SetLips(LipsList[0]);
            }
            public static List<DifData> Get(BaseScene scene, int var, DifData delta = null)
            {
                Lady_LinaMoana_Face01 inst = new Lady_LinaMoana_Face01(scene, CName);
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
                        result.Insert(2, new DifData(PartList[0], this.Name) { Xd = 50, Yd = -20, S = 151, R = -14, F = 0 });
                        //hand left   X = 385, Y = 274 (X = 347, Y = 257, S = 421, R = 12, F = 0)
                        result.Insert(2, new DifData(PartList[1], this.Name) { Xd = -38, Yd = -17, S = 421, R = 12, F = 0 });
                        //bust X = 81, Y = 315,
                        result.Insert(2, new DifData(PartList[2], this.Name) { Xd = 170, Yd = -40, S = 343 });
                        //left leg X = 495, Y = 560 (X = 460, Y = 397, S = 194, F = 0)
                        result.Insert(2, new DifData(PartList[3], this.Name) { Xd = -35, Yd = -163, S = 194, F = 0 });
                        //right leg X = 20, Y = 610 (X = 120, Y = 445, S = 359, F = 0)
                        result.Insert(2, new DifData(PartList[4], this.Name) { Xd = 100, Yd = -165, S = 359, F = 0 });
                    }
                    else
                    {
                        //hand right
                        result.Insert(2, new DifData(PartList[0], this.Name));
                        //hand left
                        result.Insert(2, new DifData(PartList[1], this.Name));
                        //bust
                        result.Insert(2, new DifData(PartList[2], this.Name));
                        //left leg
                        result.Insert(2, new DifData(PartList[3], this.Name));
                        //right leg
                        result.Insert(2, new DifData(PartList[4], this.Name));
                    }
                }
                if (this.Face.Name == this.FaceList[0])
                {
                    // closed eyes
                    result.Insert(result.IndexOf(result.Where(x => x.Name == Face.Name).FirstOrDefault()) + 1,
                        new DifData(PartList[5], FaceList[0]) { O = 1, T = Transitions.Eyes_Blink });
                }
                result.Add(new DifData(Devil.ManOld_001) { X = 740, Y = -5, S = 1000, F = 0 });
                return result;
            }
        }
        public class Lady_LinaMoana_Face02 : Personality
        {
            #region Text
            public static string Story1 = "";
            #endregion
            public static string CName = "Lady_LinaMoana_Face02";
            public static int Variants = 3;
            public Lady_LinaMoana_Face02(BaseScene scene, string name) : base(scene,name)
            {

                #region Body            
                BodyList.Add("ERECTLIP_BakunyuuOnsen_PNG_010");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(BodyList[0],this.Name) {X=-300, Y=180, S = 1104, F = 0},
                });
                #endregion

                #region Face
                FaceList.Add("ERECTLIP_BakunyuuOnsen_PNG_011");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(FaceList[0],Name) { X = 90, Y = -25, S = 448, R = 10, F = 0 },
                });
                #endregion

                #region Lips           
                LipsList.Add(SC011_HCG.Lips02);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 448 },
                new DifData(LipsList[0], FaceList[0]) { X = 112, Y = 305, S = 58, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips03);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 448 },
                new DifData(LipsList[1], FaceList[0]) { X = 111, Y = 298, S = 51, R = 50, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips01);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 448 },
                new DifData(LipsList[2], FaceList[0]) {X = 121, Y = 307, S = 51, R = 8, F = 0},
                });
                #endregion


                // set default body
                SetBody(BodyList[0], new DifData() { X = -295, Y = 170, S = 1104, R = 45, F = 0 });
                // set default head
                SetHead(FaceList[0], new DifData() { S = 448 });
                // set default lips
                SetLips(LipsList[0]);
            }
            public static List<DifData> Get(BaseScene scene, int var, DifData delta = null)
            {
                Lady_LinaMoana_Face02 inst = new Lady_LinaMoana_Face02(scene,CName);
                inst.Variant = var;
                return inst.Get(delta);
            }
            public override List<DifData> Get(DifData delta = null)
            {
                if (this.Variant == 1)
                    SetLips(LipsList[1], new DifData() { Rd = -10 });
                else if (this.Variant == 2)
                    SetLips(LipsList[2], new DifData() { Xd = -5 });

                List<DifData> result = base.Get(delta);

                result.Add(new DifData(Devil.ManOld_001) { X = 740, Y = -5, S = 900, F = 0 });
                return result;
            }
        }
        public class Lady_LinaMoana_Face03 : Personality
        {
            #region Text
            public static string Story1 = "";
            #endregion
            public static string CName = "Lady_LinaMoana_Face03";
            public static int Variants = 6;
            public Lady_LinaMoana_Face03(BaseScene scene, string name) : base(scene,name)
            {

                #region Body            
                // BodyList.Add("ERECTLIP_BakunyuuOnsen_PNG_010");
                #endregion

                #region Face
                FaceList.Add("ERECTLIP_BakunyuuOnsen_PNG_015");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(FaceList[0],Name) { X = 60, Y = 55, S = 323, R = 5, F = 0 },
                });
                #endregion

                #region Lips           
                LipsList.Add(SC011_HCG.Lips04);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 323 },
                new DifData(LipsList[0], FaceList[0]) { X = 44, Y = 185, S = 66, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips03);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 323 },
                new DifData(LipsList[1], FaceList[0]) { X = 46, Y = 185, S = 47, R = 48, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips02);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 323 },
                new DifData(LipsList[2], FaceList[0]) { X = 39, Y = 195, S = 56, R = 20, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips01);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 323 },
                new DifData(LipsList[3], FaceList[0]) { X = 43, Y = 195, S = 52, R = 18, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips05);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 323 },
                new DifData(LipsList[4], FaceList[0]) { X = 48, Y = 190, S = 49, R = 18, F = 0},
                });
                //
                #endregion

                #region Parts                   
                //Closed eyes head01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_017");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0])  { S=323 },
                new DifData(PartList[0],FaceList[0]) { O = 0, X = 21, Y = 60, S = 172, F = 0 },
                });
                //HalfClosed eyes head01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_019");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0])  { S=323 },
                new DifData(PartList[1],FaceList[0]) {X = 19, Y = 62, S = 159, F = 0 },
                });
                #endregion


                // set default body
                // SetBody(BodyList[0], new DifData() { X = -295, Y = 170, S = 1104, R = 45, F = 0 });
                // set default head
                SetHead(FaceList[0], new DifData() { S = 323 });
                // set default lips
                SetLips(LipsList[0]);
            }
            public static List<DifData> Get(BaseScene scene, int var, bool getBody = true, DifData delta = null)
            {
                Lady_LinaMoana_Face03 inst = new Lady_LinaMoana_Face03(scene,CName);
                if (!getBody) inst.Body = null;
                inst.Variant = var;
                return inst.Get(delta);
            }
            public override List<DifData> Get(DifData delta = null)
            {
                if (this.Variant == 1)
                    SetLips(LipsList[1], new DifData() { });
                else if (this.Variant == 2)
                    SetLips(LipsList[2], new DifData() { });
                else if (this.Variant == 3)
                    SetLips(LipsList[3], new DifData() { });
                else if (this.Variant == 4)
                    SetLips(LipsList[4], new DifData() { });


                List<DifData> result = base.Get(delta);
                if (this.Face.Name == this.FaceList[0])
                {
                    if (this.Variant == 5)
                        result.Add(new DifData(PartList[1], FaceList[0]) { });

                    // closed eyes
                    result.Add(new DifData(PartList[0], FaceList[0]) { O = 0, T = Transitions.Eyes_Blink });
                }
                return result;
            }
        }
        public class Lady_LinaMoana_Face04 : Personality
        {
            #region Text
            public static string Story1 = "";
            #endregion
            public static string CName = "Lady_LinaMoana_Face04";
            public static int Variants = 7;
            public Lady_LinaMoana_Face04(BaseScene scene, string name) : base(scene, name)
            {

                #region Body                             
                BodyList.Add("ERECTLIP_BakunyuuOnsen_PNG_020");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(BodyList[0],Name) {S = 2003, F = 0},
                });
                #endregion

                #region Face
                FaceList.Add("ERECTLIP_BakunyuuOnsen_PNG_021");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(FaceList[0],Name) { X = 420, S = 487, F = 0 },
                });
                #endregion

                #region Lips   
                LipsList.Add(SC011_HCG.Lips06);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 487 },
                new DifData(LipsList[0], FaceList[0]) { X = 167, Y = 366, S = 65, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips07);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 487 },
                new DifData(LipsList[1], FaceList[0]) { X = 167, Y = 361, S = 65, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips08);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 487 },
                new DifData(LipsList[2], FaceList[0]) { X = 167, Y = 361, S = 65, F = 0},
                });
                LipsList.Add(SC011_HCG.Lips09);
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0]) { S = 487 },
                new DifData(LipsList[3], FaceList[0]) { X = 167, Y = 361, S = 61, F = 0},
                });
                #endregion

                #region Parts    
                //Closed eyes head01
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_024");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0])  { S=487 },
                new DifData(PartList[0],FaceList[0]) {  O = 0,  X = 57, Y = 198, S = 255, F = 0 },
                });
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_027");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                new DifData(FaceList[0])  { S=487 },
                new DifData(PartList[1],FaceList[0]) { X = 59, Y = 209, S = 239, F = 0 },
                });
                // half naked body
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_028");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[2],Name) { X = -10, Y = -45, S = 2048, F = 0 },
                });
                // naked body
                PartList.Add("ERECTLIP_BakunyuuOnsen_PNG_029");
                this.Scene.AddGlobal(new string[] { null }, new DifData[] {
                Canvas,
                new DifData(PartList[3],Name) { X = -5, Y = -45, S = 2048, F = 0 },
                });
                #endregion

                // set default body
                SetBody(BodyList[0]);
                // set default head
                SetHead(FaceList[0]);
                // set default lips
                SetLips(LipsList[0]);
            }
            public static List<DifData> Get(BaseScene scene, int var, bool getBody = true, DifData delta = null)
            {
                Lady_LinaMoana_Face04 inst = new Lady_LinaMoana_Face04(scene,CName);
                inst.BodyEnabled = getBody;
                inst.Variant = var;
                return inst.Get(delta);
            }
            public override List<DifData> Get(DifData delta = null)
            {
                if (this.Variant == 1)
                    SetLips(LipsList[1], new DifData() { });
                else if (this.Variant == 2)
                    SetLips(LipsList[2], new DifData() { });
                else if (this.Variant == 3)
                    SetLips(LipsList[3], new DifData() { });
                else if (this.Variant == 5)
                {
                    if (BodyEnabled)
                        SetBody(PartList[2], new DifData() { });
                }
                else if (this.Variant == 6)
                {
                    if (BodyEnabled)
                        SetBody(PartList[3], new DifData() { });
                }
                List<DifData> result = base.Get(delta);


                if (this.Face.Name == this.FaceList[0])
                {
                    if (this.Variant == 4)
                        result.Add(new DifData(PartList[1], FaceList[0]) { });
                    // closed eyes
                    result.Add(new DifData(PartList[0], FaceList[0]) { O = 0, T = Transitions.Eyes_Blink });
                }

                result.Add(new DifData(Devil.ManOld_001) { X = 885, Y = 65, S = 1125, F = 0 });
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
            path = @"z:\HCG\ERECTLIP\Bakunyuu Onsen ~Inran Okami Etsuraku no Yu Hen~\";
            for (int i = 1; i <= 38; i++)
            {
                src = $"ERECTLIP_BakunyuuOnsen_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path);
                //AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion            
        }
    }

}
