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
        public seIm SourceIm;
        public seIm ParentIm;

        public AlignDif(string source, string parent, string tag, seIm imSource, seIm imParent)
        {
            Parent = parent;
            Source = source;
            Tag = tag;
            SourceIm = imSource;
            ParentIm = imParent;
        }
        public AlignDif(string source, string parent, string tag, seIm imSource) : this(source, parent, tag, imSource, null) { }

        public AlignDif(string source, string tag, seIm imSource) : this(source, null, tag, imSource, null) { }
        public AlignDif(string source, seIm imSource) : this(source, null, null, imSource, null) { }



        public AlignDif(AlignData item, AlignData parentItem)
        {
            this.Source = item.Name;
            this.SourceIm = item.Im;
            this.Parent = item.Parent;
            if (parentItem != null)
            {
                this.Parent = parentItem.Name;
                this.ParentIm = parentItem.Im;
            }

        }

        public int GetDifX()
        {
            if (this.ParentIm == null) return this.SourceIm.X;
            else return this.SourceIm.X - this.ParentIm.X;
        }
        public int GetDifY()
        {
            if (this.ParentIm == null) return this.SourceIm.Y;
            else return this.SourceIm.Y - this.ParentIm.Y;
        }
        public void Applay(seIm sourceIm)
        {
            Applay(sourceIm, null);
        }
        public void Applay(seIm target, seIm actualParent)
        {

            target.X += GetDifX();
            if (actualParent != null) target.X += actualParent.X;

            target.Y += GetDifY();
            if (actualParent != null) target.Y += actualParent.Y;

            target.sX = this.SourceIm.sX;
            target.sY = this.SourceIm.sY;

            target.Rot = this.SourceIm.Rot;
            target.Flip = this.SourceIm.Flip;

        }
    }

}
