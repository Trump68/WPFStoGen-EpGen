using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Elements
{
    public class AlignDif
    {
        public string Parent;
        public string Source;
        public string Tag;
        public DifData SourceIm;
        public DifData ParentIm;
        
        public AlignDif(string source, string parent, string tag, DifData imSource, DifData imParent)
        {
            Parent = parent;
            Source = source;
            Tag = tag;
            SourceIm = imSource;
            ParentIm = imParent;
        }
        public AlignDif(string source, string parent, string tag, DifData imSource) : this(source, parent, tag, imSource, null) { }

        public AlignDif(string source, string tag, DifData imSource) : this(source, null, tag, imSource, null) { }
        public AlignDif(string source, DifData imSource) : this(source, null, null, imSource, null) { }



        public AlignDif(DifData item, DifData parentItem)
        {
            this.Source = item.Name;
            this.SourceIm = item;
            this.Parent = item.Parent;
            if (parentItem != null)
            {
                this.Parent = parentItem.Name;
                this.ParentIm = parentItem;
            }
        }

        public AlignDif(AlignData item, AlignData parentItem)
        {
            this.Source = item.Name;
            this.SourceIm = new DifData(item);
            this.Parent = item.Parent;
            if (parentItem != null)
            {
                this.Parent = parentItem.Name;
                this.ParentIm = new DifData(parentItem);
            }
        }

        public int GetDifX()
        {
                if (this.ParentIm == null) return this.SourceIm.X.Value;
                else return this.SourceIm.X.Value - this.ParentIm.X.Value;
        }
        public int GetDifY()
        {
            if (this.ParentIm == null) return this.SourceIm.Y.Value;
            else return this.SourceIm.Y.Value - this.ParentIm.Y.Value;
        }
        public void Applay(seIm sourceIm)
        {
            Applay(sourceIm, null);
        }
        public void Applay(seIm target, DifData actualParent)
        {
            float modX = 1;
            float modY = 1;
            if (this.ParentIm != null && actualParent != null)
            {
                if (this.SourceIm.sX.HasValue)
                {
                    modX = ((float)actualParent.sX / (float)this.ParentIm.sX);
                    target.sX = Convert.ToInt32(this.SourceIm.sX * modX);
                }
                if (this.SourceIm.sY.HasValue)
                {
                    modY = ((float)actualParent.sY / (float)this.ParentIm.sY);
                    target.sY = Convert.ToInt32(this.SourceIm.sY * modY);
                }
            }
            else
            {
                if (this.SourceIm.sX.HasValue) target.sX = this.SourceIm.sX.Value;
                if(this.SourceIm.sY.HasValue) target.sY = this.SourceIm.sY.Value;
            }

            if (this.SourceIm.X.HasValue)
            {
                target.X += Convert.ToInt32((GetDifX() * modX));
                if (actualParent != null && actualParent.X.HasValue) target.X += actualParent.X.Value;
            }
            if (this.SourceIm.Y.HasValue)
            {
                target.Y += Convert.ToInt32((GetDifY() * modY));
                if (actualParent != null && actualParent.Y.HasValue) target.Y += actualParent.Y.Value;
            }
            if (this.SourceIm.Rot.HasValue) target.Rot = this.SourceIm.Rot.Value;
            if (this.SourceIm.Flip.HasValue) target.Flip = this.SourceIm.Flip.Value;
        }
    }
}