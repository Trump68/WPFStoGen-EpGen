using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC010_OyariAshito : BaseScene
    {
        private static Lady_Olga _Lady_Olga;
        public static Lady_Olga Lady_Olga
        {
            get
            {
                if (_Lady_Olga == null)  
                     _Lady_Olga = new Lady_Olga(Instance);
                return _Lady_Olga;
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
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            string src = null;
            string fn = null;
            int ss = 700;
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
    public class Lady_Olga : Personality
    {       
        private static string face01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_002";
        private static string body01 = "OyariAshito_KawaikuteShikatagaNai2_001";
        private static string part01 = "OyariAshito_KawaikuteShikatagaNai2_PNG_001"; // hand of body1
        private static string lips01 = Mouth.Sensual_001;
        public Lady_Olga(BaseScene scene): base(scene)
        {
            this.Name = "Olya_OyariAshito_001";
            // to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(face01) { Flip = 1},
            new DifData(lips01, face01) { X = 355, Y = 490, s = 60, Rot = 30, Flip = 1},
            });
            //face to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { X = 0, Y = -5, s = 850, Flip=0 },
            new DifData(face01,body01) {X = -30, Y = -5, s = 183, Flip=1},
            });
            //hand to body layout
            this.Scene.AddGlobal(new string[] { null }, new DifData[] {
            new DifData(body01)  { X = 0, Y = -5, s = 850, Flip=0 },
            new DifData(part01,body01) { X = 1, Y = -2, s = 828, Flip=0 },
            });

            this.Body = new DifData(body01);
            this.Face = new DifData(face01);
            this.Lips = new DifData(lips01);
        }
        public override List<DifData> Get(DifData delta)
        {
            
            List<DifData> result = base.Get(delta);
            if (this.Body.Name == body01)
            {
                // add hand
                result.Add(new DifData(part01,body01));
            }
            return result;
        }
    }
    public class Personality
{
        public string Name;
    protected BaseScene Scene;
    public Personality(BaseScene scene)
    {
            this.Scene = scene;
    }

    public List<DifData> BodyList = new List<DifData>();
    public List<DifData> FaceList = new List<DifData>();
    public List<DifData> LipsList = new List<DifData>();
    private DifData _Body;
    public DifData Body
    {
        get
        {
            if (_Body == null)
                return BodyList.FirstOrDefault();
            return _Body;
        }
        set
        {
            if (value == null)
                return;
            var existing = this.BodyList.Where(x => x.Name == value.Name).FirstOrDefault();
            if (existing != null)
                existing.AssingFrom(value);
            else
                this.BodyList.Add(value);
            _Body = value;
        }
    }
    private DifData _Face;
    public DifData Face
    {
        get
        {
            if (_Face == null)
                return FaceList.FirstOrDefault();
            return _Face;
        }
        set
        {
            if (value == null)
                return;
            var existing = this.FaceList.Where(x => x.Name == value.Name).FirstOrDefault();
            if (existing != null)
                existing.AssingFrom(value);
            else
                this.FaceList.Add(value);
            _Face = value;
        }
    }
    private DifData _Lips;
    public DifData Lips
    {
        get
        {
            if (_Lips == null)
                return LipsList.FirstOrDefault();
            return _Lips;
        }
        set
        {
            if (value == null)
                return;
            var existing = this.LipsList.Where(x => x.Name == value.Name).FirstOrDefault();
            if (existing != null)
                existing.AssingFrom(value);
            else
                this.LipsList.Add(value);
            _Lips = value;
        }
    }
    public Personality SetBody(DifData val)
    {
        this.Body = val;
        return this;
    }
    public Personality SetFace(DifData val)
    {
        this.Face = val;
        return this;
    }
    public Personality SetLips(DifData val)
    {
        this.Lips = val;
        return this;
    }
    
    public virtual List<DifData> Get(DifData delta)
    {
            this.Body.Clear();
            this.Face.Clear();
            this.Lips.Clear();
            List<DifData> result = new List<DifData>();
            if (Body != null)
            {
                DifData newbody = new DifData();
                newbody.AssingFrom(Body,true);
                newbody.AssingFrom(delta);
                result.Add(newbody);
            }
            if (Face != null)
            {
                DifData newface = new DifData();
                newface.AssingFrom(Face, true);
                if (Body != null)
                    newface.Parent = Body.Name;
                else
                    newface.AssingFrom(delta);
                result.Add(newface);
            }
            if (Lips != null)
            {
                DifData newlips = new DifData();
                newlips.AssingFrom(Lips, true);
                if (Face != null)
                    newlips.Parent = Face.Name;
                else if (Body != null)
                    newlips.Parent = Body.Name;
                result.Add(newlips);
            }
        return result;
    }
}
}
