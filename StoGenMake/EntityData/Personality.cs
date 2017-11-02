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
        public Personality(BaseScene scene)
        {
            this.Scene = scene;
        }

        //public List<DifData> BodyList = new List<DifData>();
        //public List<DifData> FaceList = new List<DifData>();
        //public List<DifData> LipsList = new List<DifData>();
        private DifData _Body;
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
                //if (value != null)
                //{
                //    var existing = this.LipsList.Where(x => x.Name == value.Name).FirstOrDefault();
                //    if (existing != null)
                //        existing.AssingFrom(value);
                //    else
                //        this.LipsList.Add(value);
                //}
                _Lips = value;
            }
        }
        //public Personality SetBody(DifData val)
        //{
        //    this.Body = val;
        //    return this;
        //}
        //public Personality SetFace(DifData val)
        //{
        //    this.Face = val;
        //    return this;
        //}
        //public Personality SetLips(DifData val)
        //{
        //    this.Lips = val;
        //    return this;
        //}

        public virtual List<DifData> Get(DifData delta)
        {
            if (!string.IsNullOrEmpty(this.bodyName))
            {
                var al = this.Scene.AlignList.Where(
                    x => x.MarkList.Contains($"{this.Name}Body{bodyName}")).FirstOrDefault();
                if (al != null)
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
            List<DifData> result = new List<DifData>();
            if (Body != null)
            {
                DifData newbody = new DifData();
                newbody.AssingFrom(Body, true);
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
