using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Persona
{
    public class Personality
    {
        public string Name;
        protected BaseScene Scene;
        public int Variant;

        protected DifData _Canvas;
        protected DifData Canvas
        {
            get
            {
                if (_Canvas == null)
                {
                    _Canvas = new DifData(this.Name) { S = 100 };
                }
                return _Canvas;
            }
        }            
        public Personality(BaseScene scene, string name)
        {
            this.Scene = scene;
            this.Name = name;
            // canvas
            this.Scene.AddToGlobalImage(this.Name, "CANVAS", null);
        }

        protected List<string> BodyList = new List<string>();
        protected List<string> FaceList = new List<string>();
        protected List<string> LipsList = new List<string>();
        protected List<string> PartList = new List<string>();
        private DifData _Body;
        private string bodyName;
        public Personality SetBody(DifData dif)
        {
            return this.SetBody(null, dif);
        }
        public Personality SetBody(string name, DifData dif = null)
        {
            bodyName = name;
            if (name != null)
                this.Body = GameWorld.ImageStorage.Where(x => x.Name == this.bodyName).FirstOrDefault()?.DefaultAlign;
            else if (dif == null)
                this.Body = null;
            this.Body?.AssingFrom(dif);
            return this;
        }
        public Personality SetBody(int index, DifData dif = null)
        {
            if (this.BodyList.Count < index + 1) return this;
            return SetBody(this.BodyList[index], dif);
        }
        private string headName;
        public Personality SetHead(DifData dif)
        {
            return this.SetHead(null, dif);
        }
        public Personality SetHead(int index, DifData dif = null)
        {
            if (this.FaceList.Count < index + 1) return this;
            return SetHead(this.FaceList[index], dif);
        }
        public Personality SetHead(string name, DifData dif = null)
        {
            headName = name;
            if (name != null)
                this.Face = GameWorld.ImageStorage.Where(x => x.Name == this.headName).FirstOrDefault()?.DefaultAlign;
            else if (dif == null)
                this.Face = null;
            this.Face?.AssingFrom(dif);
            return this;
        }
        private string lipsName;
        public Personality SetLips(DifData dif) { return this.SetLips(null,dif); }
        public Personality SetLips(int index, DifData dif = null)
        {
            if (this.LipsList.Count < index + 1) return this;
            return SetLips(this.LipsList[index], dif);
        }
        public Personality SetLips(string name, DifData dif = null)
        {
            lipsName = name;
            if (name != null)            
                this.Lips = GameWorld.ImageStorage.Where(x => x.Name == this.lipsName).FirstOrDefault()?.DefaultAlign;            
            else if (dif == null)
                this.Lips = null;
            this.Lips?.AssingFrom(dif);
            return this;
        }

        public DifData Body
        {
            get
            {
                return _Body;
            }
            set
            {
                //if (value != null)
                //{
                //    var existing = this.BodyList.Where(x => x.Name == value.Name).FirstOrDefault();
                //    if (existing != null)
                //        existing.AssingFrom(value);
                //    else
                //        this.BodyList.Add(value);
                //}
                _Body = value;
            }
        }
        private DifData _Face;
        public DifData Face
        {
            get
            {
                return _Face;
            }
            set
            {
                //if (value != null)
                //{
                //    var existing = this.FaceList.Where(x => x.Name == value.Name).FirstOrDefault();
                //    if (existing != null)
                //        existing.AssingFrom(value);
                //    else
                //        this.FaceList.Add(value);
                //}
                _Face = value;
            }
        }
        private DifData _Lips;
        public DifData Lips
        {
            get
            {
                return _Lips;
            }
            set
            {              
                _Lips = value;
            }
        }

        public virtual List<DifData> Get(DifData delta)
        {
        
            List<DifData> result = new List<DifData>();
            DifData canvas = Canvas;            
            canvas.AssingFrom(delta);
            result.Add(canvas);

            if (Body != null)
            {
                DifData newbody = new DifData();
                newbody.AssingFrom(Body, true);
                newbody.Parent = this.Name;
                newbody.Name = Body.Name;
                newbody.AssingFrom(delta);
                result.Add(newbody);
            }
            if (Face != null)
            {
                DifData newface = new DifData();
                newface.AssingFrom(Face, true);
                newface.Name = Face.Name;
                newface.Parent = this.Name;
                result.Add(newface);
            }
            if (Lips != null)
            {
                DifData newlips = new DifData();
                newlips.AssingFrom(Lips, true);
                newlips.Name = Lips.Name;
                if (Face != null)
                    newlips.Parent = Face.Name;
                else 
                    newlips.Parent = this.Name;
                result.Add(newlips);
            }
            return result;
        }
    }
}
