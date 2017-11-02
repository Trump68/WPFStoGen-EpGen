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
        private static Lady_EriAyase _Lady_EriAyase;
        public static Lady_EriAyase Lady_EriAyase
        {
            get
            {
                if (_Lady_EriAyase == null)  
                     _Lady_EriAyase = new Lady_EriAyase(Instance);
                return _Lady_EriAyase;
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
            for (int i = 1; i <= 20; i++)
            {
                src = $"OyariAshito_KawaikuteShikatagaNai2_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 20; i++)
            {
                path = @"d:\PicWork\";
                src = $"OyariAshito_KawaikuteShikatagaNai2_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { S = ss });
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
    public class Lady_EriAyase : Personality
    {
        string body01=null;
        string part01 = null;
        public Lady_EriAyase(BaseScene scene): base(scene)
        {
            this.Name = "EriAyase_OyariAshito_001";

            #region Body            
            body01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_001";
            this.Scene.AddLocal($"{this.Name}Body001", new DifData(body01) { S = 3840 });

            string body02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_005";
            this.Scene.AddLocal($"{this.Name}Body002", new DifData(body02) { S = 3800 });

            string body03 = "OyariAshito_KawaikuteShikatagaNai2_PNG_008";
            this.Scene.AddLocal($"{this.Name}Body003", new DifData(body03) { S = 2300 });
            #endregion

            #region Face
            //  face 01
            string face01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_002";
            this.Scene.AddLocal($"{this.Name}Face001", new DifData(face01) { S = 825 });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { S = 3840},
            new DifData(face01,body01) {X = 40, S = 825, F=0},
            });

            // face02
            string face02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_006";
            // default
            this.Scene.AddLocal($"{this.Name}Face002", new DifData(face02) { S = 838 });
            // rotated on 45
            this.Scene.AddLocal($"{this.Name}Face002a", new DifData(face02) { S = 838, Rd = 45 });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body02)  { S = 3800},
            new DifData(face02,body02) {X = 235, Y = 45, S = 793, F=0},
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { S = 3800},
            new DifData(face02,body01) {X = -60, Y = 5, S = 804, F=0},
            });

            //  face 03
            string face03 = "OyariAshito_KawaikuteShikatagaNai2_PNG_009";
            this.Scene.AddLocal($"{this.Name}Face003", new DifData(face03) { S = 858 });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body03)  { S = 2300},
            new DifData(face03,body03) { X = 75, S = 858, F=0},
            });
            #endregion

            #region Lips           
            #region Original           
            #region Lips01
            string lips01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_003";
            this.Scene.AddLocal($"{this.Name}Lips001", new DifData(lips01) { S = 64 });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face01) { S = 825 },
            new DifData(lips01, face01) { X = 200, Y = 595, S = 64, F=0 },
            });

            #endregion
                #region Lips02
            string lips02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_007";
            this.Scene.AddLocal($"{this.Name}Lips002", new DifData(lips02) { S = 55 });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face02) { S = 825 },
            new DifData(lips02, face02) { X = 330, Y = 595, S = 55, F=0 },
            });


            #endregion            #endregion
              #endregion
              #region Imported
                #region Lips_001            
            string lips001 = Mouth.Sensual_001;
            this.Scene.AddLocal($"{this.Name}Lips_001", new DifData(lips001) { });
            this.Scene.AddLocal($"{this.Name}Lips_001+R10", new DifData(lips001) { Rd = 10});
            this.Scene.AddLocal($"{this.Name}Lips_001-R10", new DifData(lips001) { Rd = -10 });

            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face01) { S = 825 },
            new DifData(lips001, face01) {X = 200, Y = 585, S = 60, R=25, F=1},
            });

            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face02) { S = 825 },
            new DifData(lips001, face02) {X = 320, Y = 580, S = 62, R=45, F=1},
            });
            #endregion
            #endregion
            #endregion

            #region Body parts   
            //hand of body01
            part01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_004";
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { S=3840},
            new DifData(part01,body01) { X = 45, Y = 590, S = 266, F=0},
            });
            #endregion
        }
        public override List<DifData> Get(DifData delta)
        {          
            List<DifData> result = base.Get(delta);
            if (this.Body.Name == body01)
            {
                //add hand
                result.Add(new DifData(part01,body01));
            }
            return result;
        }
    }  
}
