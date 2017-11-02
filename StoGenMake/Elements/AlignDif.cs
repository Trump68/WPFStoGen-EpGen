using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenMake.GameWorld;

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
        public AlignDif(AlignData item, DifData parentItem)
        {
            this.Source = item.Name;
            this.SourceIm = new DifData(item);
            this.Parent = item.Parent;
            if (parentItem != null)
            {
                this.Parent = parentItem.Name;
                this.ParentIm = parentItem;
            }
        }
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
                if (this.ParentIm == null || !this.ParentIm.X.HasValue)
                    return this.SourceIm.X.Value;
                else
                   return this.SourceIm.X.Value - this.ParentIm.X.Value;
        }
        public int GetDifY()
        {
            if (this.ParentIm == null || !this.ParentIm.Y.HasValue)
                return this.SourceIm.Y.Value;
            else
                return this.SourceIm.Y.Value - this.ParentIm.Y.Value;
        }
        public void Applay(seIm sourceIm, AlignData processed)
        {
            Applay(sourceIm, processed, null);
        }
        public void Applay(seIm target, AlignData processed, seIm actualParent)
        {
            float modX = 1;
            float modY = 1;
            
            if (this.ParentIm != null && actualParent != null)
            {
                if (this.SourceIm.Sx.HasValue || this.SourceIm.Sy.HasValue)
                {
                    if (this.SourceIm.Sx.HasValue && this.ParentIm.Sx.HasValue)
                    {
                        modX = ((float)actualParent.sX / (float)this.ParentIm.Sx);
                        target.sX = Convert.ToInt32(this.SourceIm.Sx * modX);
                    }
                    if (this.SourceIm.Sy.HasValue && this.ParentIm.Sy.HasValue)
                    {
                        modY = ((float)actualParent.sY / (float)this.ParentIm.Sy);
                        target.sY = Convert.ToInt32(this.SourceIm.Sy * modY);
                    }                                
                }
                // Parent rotation
                {
                    target.ParentRotations.Clear();
                    int rot = 0;
                    if (actualParent != null && actualParent.ParentRotations!=null)
                    {
                        target.ParentRotations.AddRange(actualParent.ParentRotations);
                    }
                    if (this.ParentIm.R.HasValue) rot = this.ParentIm.R.Value;
                    if ( rot != actualParent.R)
                    {
                        target.ParentRotations.Add(new Tuple<string, int>(this.ParentIm.Name, actualParent.R - rot));
                    }
                }
            }
            else
            {
                if (this.SourceIm.Sx.HasValue) target.sX = this.SourceIm.Sx.Value;
                if(this.SourceIm.Sy.HasValue) target.sY = this.SourceIm.Sy.Value;

                if (processed.Im != null && processed.Im.Sx.HasValue) target.sX = processed.Im.Sx.Value;
                if (processed.Im != null && processed.Im.Sy.HasValue) target.sY = processed.Im.Sy.Value;
            }

            { // X,Y coord
                if (processed.Im != null)
                {
                    if (processed.Im.X.HasValue)
                        target.X = processed.Im.X.Value;
                    if (processed.Im.Y.HasValue)
                        target.Y = processed.Im.Y.Value;
                }
                else
                {
                    int xDif = 0;
                    int yDif = 0;


                    if (this.SourceIm.X.HasValue)
                        xDif = this.SourceIm.X.Value;
                    if (this.SourceIm.Y.HasValue)
                        yDif = this.SourceIm.Y.Value;

                    if (this.ParentIm != null && this.ParentIm.X.HasValue)
                        xDif = xDif - this.ParentIm.X.Value;
                    if (this.ParentIm != null && this.ParentIm.Y.HasValue)
                        yDif = yDif - this.ParentIm.Y.Value;

                    target.X = target.X + (int)(xDif * modX);
                    target.Y = target.Y + (int)(yDif * modY);

                    if (actualParent != null)
                        target.X = target.X + actualParent.X;

                    if (actualParent != null)
                        target.Y = target.Y + actualParent.Y;

                    if (processed.Fact != null)
                    {
                        target.X = target.X + processed.Fact.X;
                    }
                    else if (processed.Im != null && processed.Im.X.HasValue)
                    {
                        target.X = target.X + processed.Im.X.Value;
                    }

                    if (processed.Fact != null)
                    {
                        target.Y = target.Y + processed.Fact.Y;
                    }
                    else if (processed.Im != null && processed.Im.Y.HasValue)
                    {
                        target.Y = target.Y + processed.Im.Y.Value;
                    }
                }
            }


            if (this.SourceIm.R.HasValue) target.R = this.SourceIm.R.Value;
            if (processed.Im != null && processed.Im.R.HasValue) target.R = processed.Im.R.Value;

            if (this.SourceIm.F.HasValue) target.Flip = this.SourceIm.F.Value;
            if (processed.Im != null && processed.Im.F.HasValue)
                target.Flip = processed.Im.F.Value;
            else
            {
                //if (this.ParentIm != null && actualParent != null)
                //{
                //    if (!this.ParentIm.Flip.HasValue || this.ParentIm.Flip!= actualParent.Flip)
                //    {
                //        if (this.SourceIm.Flip.HasValue)
                //        {
                //            if (SourceIm.Flip == 0) SourceIm.Flip = 1;
                //            else SourceIm.Flip = 0;
                //        }
                //        else
                //        {
                //            SourceIm.Flip = actualParent.Flip;
                //        }                          
                //    }                    
                //}
            }

        }





    }
}