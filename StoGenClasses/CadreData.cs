using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{

    public class CadrePicData
    {
        public PictureSourceDataProps GetByName(string name)
        {
            PictureSourceDataProps result = null;
            if (PictureDataList.Count > 0) PictureDataList.FirstOrDefault(data => data.Name == name);
            return result;
        }
        public List<PictureSourceDataProps> PictureDataList = new List<PictureSourceDataProps>();
        public CadrePicData(List<CadrePicData> list)
            : this()
        {
            list.Add(this);
        }
        public CadrePicData()
        {

        }
        public PictureSourceDataProps Add(string fnname)
        {
           return Add( string.Empty,fnname);
        }
        public PictureSourceDataProps Add(string name,string fnname)
        {
            PictureSourceDataProps data = new PictureSourceDataProps(fnname);
            data.Name = name;
            this.PictureDataList.Add(data);
            return data;
        }
        public PictureSourceDataProps Add(string fnname, PictureProps Position)
        {
            PictureSourceDataProps data = new PictureSourceDataProps(fnname, Position);
            this.PictureDataList.Add(data);
            return data;
        }
        public PictureSourceDataProps Add(string fnname, int x, int y)
        {
            return this.Add(fnname, x, 0);
        }
        public PictureSourceDataProps Add(PictureSourceDataProps p)
        {
            this.PictureDataList.Add(p);
            return p;
        }
        public PictureSourceDataProps Add(string fnname, int x, int y, int z)
        {
            PictureSourceDataProps data = new PictureSourceDataProps(fnname);
            data.X = x;
            data.Y = y;
            data.Z = z;
            this.PictureDataList.Add(data);
            return data;
        }
        //public PictureSourceDataProps Add(string fnname, AnimationRate rate)
        //{
        //    PictureSourceDataProps data = new PictureSourceDataProps(fnname);
        //    data.Rate = rate;
        //    this.PictureDataList.Add(data);
        //    return data;
        //}
        public void Assign(CadrePicData cadreData)
        {
            this.PictureDataList.Clear();
            this.PictureDataList.AddRange(cadreData.PictureDataList);
        }
        internal void Remove(PictureSourceDataProps result)
        {
            this.PictureDataList.Remove(result);
        }
        internal void Clear()
        {
            this.PictureDataList.Clear();
        }


    }
}
