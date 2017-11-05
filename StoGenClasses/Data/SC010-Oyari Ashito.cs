using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Persona;
namespace StoGenMake.Scenes
{
    public class SC010_OyariAshito : BaseScene
    {
        
        private static Lady_EriAyase_Face01 _Lady_EriAyase_Face01;
        public static Lady_EriAyase_Face01 Lady_EriAyase_Face01
        {
            get
            {
                if (_Lady_EriAyase_Face01 == null)
                    _Lady_EriAyase_Face01 = new Lady_EriAyase_Face01(Instance, "EriAyase_OyariAshito_001");
                return _Lady_EriAyase_Face01;
            }
        }

        private static Lady_EriAyase_Face02 _Lady_EriAyase_Face02;
        public static Lady_EriAyase_Face02 Lady_EriAyase_Face02
        {
            get
            {
                if (_Lady_EriAyase_Face02 == null)
                    _Lady_EriAyase_Face02 = new Lady_EriAyase_Face02(Instance, "EriAyase_OyariAshito_002");
                return _Lady_EriAyase_Face02;
            }
        }

        private static Lady_EriAyase_Face03 _Lady_EriAyase_Face03;
        public static Lady_EriAyase_Face03 Lady_EriAyase_Face03
        {
            get
            {
                if (_Lady_EriAyase_Face03 == null)
                    _Lady_EriAyase_Face03 = new Lady_EriAyase_Face03(Instance, "EriAyase_OyariAshito_003");
                return _Lady_EriAyase_Face03;
            }
        }
        private static Lady_EriAyase_Face04 _Lady_EriAyase_Face04;
        public static Lady_EriAyase_Face04 Lady_EriAyase_Face04
        {
            get
            {
                if (_Lady_EriAyase_Face04 == null)
                    _Lady_EriAyase_Face04 = new Lady_EriAyase_Face04(Instance, "EriAyase_OyariAshito_004");
                return _Lady_EriAyase_Face04;
            }
        }
        private static Lady_EriAyase_Face05 _Lady_EriAyase_Face05;
        public static Lady_EriAyase_Face05 Lady_EriAyase_Face05
        {
            get
            {
                if (_Lady_EriAyase_Face05 == null)
                    _Lady_EriAyase_Face05 = new Lady_EriAyase_Face05(Instance, "EriAyase_OyariAshito_005");
                return _Lady_EriAyase_Face05;
            }
        }
        private static Lady_EriAyase_Face06 _Lady_EriAyase_Face06;
        public static Lady_EriAyase_Face06 Lady_EriAyase_Face06
        {
            get
            {
                if (_Lady_EriAyase_Face06 == null)
                    _Lady_EriAyase_Face06 = new Lady_EriAyase_Face06(Instance,"EriAyase_OyariAshito_006");
                return _Lady_EriAyase_Face06;
            }
        }



        private static SC010_OyariAshito Instance;
        public SC010_OyariAshito() : base()
        {
            Name = "SC010_OyariAshito";
            EngineHiVer = 1;
            EngineLoVer = 0;
            Instance = this;
        }
        protected override void LoadData()
        {
            string path = null;

            string src = null;
            string fn = null;
            int ss = 970;
            string gr = null;

            #region OyariAshito_KawaikuteShikatagaNai2

            gr = "OyariAshito_KawaikuteShikatagaNai2";
            path = @"z:\ARTIST\Oyari Ashito\OyariAshito_KawaikuteShikatagaNai2\";
            //path = @"d:\PicWork\";
            for (int i = 1; i <= 20; i++)
            {
                src = $"OyariAshito_KawaikuteShikatagaNai2_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 20; i++)
            {
                
                src = $"OyariAshito_KawaikuteShikatagaNai2_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion            
        }

        protected override void MakeCadres(string cadregroup)
        {
            cadregroup = "OyariAshito_KawaikuteShikatagaNai2";
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
    }
  
   

   

    public class Lady_EriAyase_Face01 : Personality
    {
        #region Text
        public string Story1 =
          "'Крис!' - умоляюще воскликнула Мария."
         + "~~Звала на помощь, или просила уйти?"
         + "- он так и не узнал."
         + "~~-Он не будет мешать, деточка."
         + "-проговорил Рабе и значительно посмотрел на Криса."
         + "~А Мария отвела взгляд. Что было делать, кроме как уйти?"
       ;
        #endregion
        public Lady_EriAyase_Face01(BaseScene scene, string name) : base(scene,name )
        {
            this.Name = "EriAyase_OyariAshito_001";

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_001");
            #endregion

            #region Face
            FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_002");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S = 3840},
            new DifData(FaceList[0],BodyList[0]) {X = 40, S = 825, F=0},
            });
            #endregion

            #region Lips           
            LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_003");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 825 },
            new DifData(LipsList[0], FaceList[0]) { X = 200, Y = 595, S = 64, F=0 },
            });

            LipsList.Add(Mouth.Sensual_001);
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 825 },
            new DifData(LipsList[1],FaceList[0]) {X = 200, Y = 585, S = 60, R=25, F=1},
            });          
            #endregion

            #region Parts   
            //hand of body01
            PartList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_004");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S=3840},
            new DifData(PartList[0],BodyList[0]) { X = 45, Y = 590, S = 266, F=0},
            });
            #endregion

            // set default body
            SetBody(BodyList[0], new DifData() { S = 3840 });
            // set default head
            SetHead(FaceList[0]);
            // set default lips
            SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            if (this.Body != null && this.Body.Name == BodyList[0])
            {
                //add hand
                result.Add(new DifData(PartList[0], BodyList[0]));
            }
            return result;
        }
    }
    public class Lady_EriAyase_Face02 : Personality
    {
        #region Text
        public string Story1 =
          "'Крис!' - умоляюще воскликнула Мария."
         + "~~Звала на помощь, или просила уйти?"
         + "- он так и не узнал."
         + "~~-Он не будет мешать, деточка."
         + "-проговорил Рабе и значительно посмотрел на Криса."
         + "~А Мария отвела взгляд. Что было делать, кроме как уйти?"
       ;
        #endregion
        public Lady_EriAyase_Face02(BaseScene scene, string name) : base(scene, name)
        {
            this.Name = "EriAyase_OyariAshito_002";

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_005");
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_001");
            #endregion

            #region Face
            FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_006");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S = 3800},
            new DifData(FaceList[0],BodyList[0]) {X = 235, Y = 45, S = 793, F=0},
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[1])  { S = 3840},
            new DifData(FaceList[0],BodyList[1]) {X = 40, S = 825, F=0},
            });
            #endregion

            #region Lips           
            LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_007");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 825 },
            new DifData(LipsList[0], FaceList[0]) { X = 330, Y = 595, S = 55, F=0 },
            });
            LipsList.Add(Mouth.Sensual_001);
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 825 },
            new DifData(LipsList[1], FaceList[0]) {X = 320, Y = 580, S = 62, R=45, F=1},
            });

            #endregion


            // set default body
            SetBody(BodyList[0], new DifData() { S = 3800 });
            // set default head
            SetHead(FaceList[0]);
            // set default lips
            SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            return result;
        }
    }
    public class Lady_EriAyase_Face03 : Personality
    {
        #region Text
        public string Story1 =
           "Поев, Рабе решил проверить, насколько послушна новая служанка."
         + "Вся обслуга женского пола в доме не должна была носить нижнего белья."
         + "И теперь он потребовал от девушки показать, что правила выполняются."
       ;
        #endregion
        public Lady_EriAyase_Face03(BaseScene scene, string name) : base(scene, name)
        {
            this.Name = "EriAyase_OyariAshito_003";

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_008");
            #endregion

            #region Face
            FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_009");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S = 2300},
            new DifData(FaceList[0],BodyList[0]) { X = 75, S = 858, F=0},
            });
            #endregion

            #region Lips           
            LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_010");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 858 },
            new DifData(LipsList[0], FaceList[0]) { X = 275, Y = 595, S = 39, F=0 },
            });
            #endregion


            // set default body
            SetBody(BodyList[0], new DifData() { S = 2300 });
            // set default head
            SetHead(FaceList[0]);
            // set default lips
            SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            return result;
        }
    }
    public class Lady_EriAyase_Face04 : Personality
    {
        #region Text
        public string Story1 =
           "Поев, Рабе решил проверить, насколько послушна новая служанка."
         + "Вся обслуга женского пола в доме не должна была носить нижнего белья."
         + "И теперь он потребовал от девушки показать, что правила выполняются."
       ;
        #endregion
        public Lady_EriAyase_Face04(BaseScene scene, string name) : base(scene, name)
        {
            this.Name = "EriAyase_OyariAshito_004";

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_011");
            #endregion

            #region Face
            FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_012");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S = 1200},
            new DifData(FaceList[0],BodyList[0]) { X = 75, S = 270, F=0},
            });
            #endregion

            #region Lips           
            LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_013");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 270 },
            new DifData(LipsList[0], FaceList[0]) { X = 120, Y = 185, S = 32, F=0 },
            });
            #endregion


            // set default body
            SetBody(BodyList[0], new DifData() { S = 1200 });
            // set default head
            SetHead(FaceList[0]);
            // set default lips
            SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            return result;
        }
    }
    public class Lady_EriAyase_Face05 : Personality
    {
        #region Text
        public string Story1 ="";
        #endregion
        public Lady_EriAyase_Face05(BaseScene scene, string name) : base(scene, name)
        {

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_014");
            #endregion

            #region Face
            FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_015");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(BodyList[0])  { S = 1913},
            new DifData(FaceList[0],BodyList[0]) {X = 605, S = 586, F = 0},
            });
            #endregion

            #region Lips           
            LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_016");
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(FaceList[0]) { S = 586 },
            new DifData(LipsList[0], FaceList[0]) {X = 235, Y = 410, S = 25, F = 0},
            });
            #endregion


            // set default body
            SetBody(BodyList[0], new DifData() { S = 1913 });
            // set default head
            SetHead(FaceList[0]);
            // set default lips
            SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            return result;
        }
    }
    public class Lady_EriAyase_Face06 : Personality
    {
        #region Text
        public string Story1 = "";
        #endregion
        public Lady_EriAyase_Face06(BaseScene scene, string name) : base(scene, name)
        {
            this.Name = "EriAyase_OyariAshito_006";

            #region Body            
            BodyList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_017");
            #endregion

            //#region Face
            //FaceList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_017");
            //this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            //new DifData(BodyList[0])  { S = 1913},
            //new DifData(FaceList[0],BodyList[0]) {X = 605, S = 586, F = 0},
            //});
            //#endregion

            //#region Lips           
            //LipsList.Add("OyariAshito_KawaikuteShikatagaNai2_PNG_016");
            //this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            //new DifData(FaceList[0]) { S = 586 },
            //new DifData(LipsList[0], FaceList[0]) {X = 235, Y = 410, S = 25, F = 0},
            //});
            //#endregion


            // set default body
            SetBody(BodyList[0], new DifData() { S = 721 });
            // set default head
            //SetHead(FaceList[0]);
            // set default lips
            //SetLips(LipsList[0]);
        }
        public override List<DifData> Get(DifData delta = null)
        {
            List<DifData> result = base.Get(delta);
            return result;
        }
    }
}
