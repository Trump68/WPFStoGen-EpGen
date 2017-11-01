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
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 20; i++)
            {
                path = @"d:\PicWork\";
                src = $"OyariAshito_KawaikuteShikatagaNai2_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
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
        
        private static string body01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_001";
        private static string body02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_005";
        private static string body03 = "OyariAshito_KawaikuteShikatagaNai2_PNG_008";

        private static string face01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_002";
        private static string face02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_006";
        private static string lips01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_003";
        private static string lips02 = "OyariAshito_KawaikuteShikatagaNai2_PNG_007";
        private static string lips001 = Mouth.Sensual_001;
        private static string part01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_004"; // hand of body1
        
        public Lady_EriAyase(BaseScene scene): base(scene)
        {
            this.Name = "EriAyase_OyariAshito_001";
            
            //lips to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face01) { s = 825 },
            new DifData(lips01, face01) { X = 200, Y = 595, s = 64, Flip=0 },
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face02) { s = 825 },
            new DifData(lips02, face02) { X = 330, Y = 595, s = 55, Flip=0 },
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face01) { s = 825 },
            new DifData(lips001, face01) {X = 200, Y = 585, s = 60, Rot=25, Flip=1},
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face02) { s = 825 },
            new DifData(lips001, face02) {X = 320, Y = 580, s = 62, Rot=45, Flip=1},
            });
            //face to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { s = 3840},
            new DifData(face01,body01) {X = 40, s = 825, Flip=0},
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body02)  { s = 3800},
            new DifData(face02,body02) {X = 235, Y = 45, s = 793, Flip=0},
            });
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { s = 3800},
            new DifData(face02,body01) {X = -60, Y = 5, s = 804, Flip=0},
            });
            //hand to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { s=3840},
            new DifData(part01,body01) { X = 45, Y = 590, s = 266, Flip=0},
            });

            this.Scene.AddLocal($"{this.Name}Body001", new DifData(body01) { s= 3840 });
            this.Scene.AddLocal($"{this.Name}Body002", new DifData(body02) { s = 3800 });
            this.Scene.AddLocal($"{this.Name}Body003", new DifData(body03) { s = 2300 });

            this.Scene.AddLocal($"{this.Name}Face001", new DifData(face01) { s= 825 });
            this.Scene.AddLocal($"{this.Name}Face002", new DifData(face02) { s = 838 });

            this.Scene.AddLocal($"{this.Name}Lips001", new DifData(lips01) { s = 64 });
            this.Scene.AddLocal($"{this.Name}Lips002", new DifData(lips02) { s = 55 });
            this.Scene.AddLocal($"{this.Name}Lips_001", new DifData(lips001) { });
        }
        private string bodyName;
        public Personality SetBody(string name)
        {
            bodyName = name;
            return this;
        }
        private string headName;
        public Personality SetHead(string name)
        {
            headName = name;
            return this;
        }
        private string lipsName;
        public Personality SetLips(string name)
        {
            lipsName = name;
            return this;
        }
        public override List<DifData> Get(DifData delta)
        {
            if (!string.IsNullOrEmpty(this.bodyName))
            {
                var al = this.Scene.AlignList.Where(
                    x => x.MarkList.Contains($"{this.Name}Body{bodyName}")).FirstOrDefault();
                if (al!= null)
                    this.Body = al.AlignList.First();
            }
            else this.Body = null;
            if (!string.IsNullOrEmpty(this.headName))
            {
                var al = this.Scene.AlignList.Where(
                    x => x.MarkList.Contains($"{this.Name}Face{headName}")).FirstOrDefault();
                if (al != null)
                    this.Face = al.AlignList.First();
            }
            else this.Face = null;
            if (!string.IsNullOrEmpty(this.lipsName))
            {
                var al = this.Scene.AlignList.Where(
                    x => x.MarkList.Contains($"{this.Name}Lips{lipsName}")).FirstOrDefault();
                if (al != null)
                    this.Lips = al.AlignList.First();
            }
            else this.Lips = null;
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
