
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using StoGen.Classes;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StoGen.Classes
{
    public class Cadre : IDisposable
    {
        public int SortOrder = int.MaxValue;
        public string Name = string.Empty;
        public List<Frame> Frames { get; set; }
        public bool IsProc { get; set; }
        public ProcedureBase Owner{ get; set; }
        public bool AllowedForward { get; set; }
        public bool AllowedBackward { get; set; }
        // pic data
        //public CadreData CoreCadreData { get; set; }
        public CadrePicData PicFrameData { get; set; }
        // text data        
        public List<TextData> TextFrameData { get; set; }
        // sound data
        public List<SoundItem> SoundFrameData { get; set; }

        public List<PictureBaseProp> PicPostProcessingData { get; set; }

        private Cadre() 
        {
            Frames = new List<Frame>();
            IsProc = false;
            AllowedForward = true;
            AllowedBackward = true;
            PicFrameData = new CadrePicData();
            PicPostProcessingData = new List<PictureBaseProp>();
            SoundFrameData = new List<SoundItem>();
            TextFrameData = new List<TextData>();
        }
        public Cadre(ProcedureBase owner, bool isAdd)
            : this()
        {
            this.Owner = owner;
            if (this.Owner != null)
            {
                if (isAdd) this.Owner.Cadres.Add(this);
                else
                {
                    if (this.Owner.NestedCadreId == this.Owner.Cadres.Count) this.Owner.Cadres.Insert(this.Owner.NestedCadreId, this);
                    else this.Owner.Cadres.Insert(this.Owner.NestedCadreId + 1, this);
                }
            }
        }

        public FrameText GetTextFrame() 
        {
            FrameText result = this.TextFr;
            if (result == null)
            {
                result = new FrameText();
                result.Owner = this;
                Frames.Add(result);
            }
            return result;
        }
        public FrameText TextFr
        {
            get
            {
                foreach (Frame item in Frames)
                {
                    if (item is FrameText) return (item as FrameText);
                };
                return null;
            }
        }
        public FrameImage GetImageFrame()
        {
            FrameImage result = this.ImageFr;
            if (result == null)
            {
                result = new FrameImage();
                result.Owner = this;
                Frames.Add(result);
            }
            return result;
        }
        public FrameImage ImageFr
        {
            get
            {
                foreach (Frame item in Frames)
                {
                    if (item is FrameImage) return (item as FrameImage);
                };
                return null;
            }
        }
        public FrameProc GetProcFrame()
        {
            FrameProc result = ProcFr;
            if (result == null)
            {
                result = new FrameProc();
                result.Owner = this;
                this.IsProc = true;
                Frames.Add(result);
            }
            return result;
        }
        public FrameProc ProcFr
        {
            get
            {
                foreach (Frame item in Frames)
                {
                    if (item is FrameProc) return (item as FrameProc);
                };
                return null;
            }
        }
        public FrameSound GetSoundFrame()
        {
            FrameSound result = this.SoundFr;
            if (result == null)
            {
                result = new FrameSound();
                result.Owner = this;
                Frames.Add(result);
            }
            return result;
        }
        public FrameSound SoundFr
        {
            get
            {
                foreach (Frame item in Frames)
                {
                    if (item is FrameSound) return (item as FrameSound);
                };
                return null;
            }
        }



        public virtual Cadre Repaint(bool doRecalculate) 
        {

            
            Cadre result = this;
            if (doRecalculate) this.Owner.BeforePaintCadre(this, new CadreEventArgs(this));
            if (this.TextFr == null) Projector.TextVisible = false;
            foreach (Frame item in Frames)
            {
                Cadre temp = item.Repaint();
                //if (temp != this)
                //{
                //    result = temp;
                //    result.Repaint(doRecalculate);
                //}
            }
            
            return result;
        }
        public void Clear(bool withCalculateData)
        {
            if (withCalculateData)
            {
                if (this.SoundFrameData != null) this.SoundFrameData.Clear();
                if (this.PicFrameData != null) this.PicFrameData.Clear();
                this.TextFrameData = null;                
            }
            Frames.Clear();
            GC.Collect();    
        }
        public void BeforeLeave()
        {
            if (this.TextFr != null) this.TextFr.BeforeLeave();
            if (this.SoundFr != null) this.SoundFr.BeforeLeave();
            if (this.ProcFr != null) this.ProcFr.BeforeLeave();
            if (this.ImageFr != null) this.ImageFr.BeforeLeave();

            GC.Collect();    
        }
        public void ProcessKeyData(int v)
        {
           
        }
        internal void ProcessKey(Key keys)
        {
            for (int i = 0; i < Frames.Count; i++)
            {
                if (Frames[i] is FrameImage)
                    (Frames[i] as FrameImage).ProcessKey(keys);

            }            
        }

        public PictureItem InsertImage(string FileName, int ShiftX, int ShiftY, int zoom)
        {
            return InsertImage(FileName, new PictureProps(ShiftX,ShiftY,zoom));
        }
        public PictureItem InsertImage(string FileName, PictureProps position)
        {
            FrameImage Fi = this.GetImageFrame();
            PictureItem pic = new PictureItem();
            pic.Props.FileName = FileName;
            pic.Props.SizeMode = PictureSizeMode.Clip;
            pic.Props.Align = ContentAlignment.TopLeft;
            pic.Props.isLoop = 1;
            pic.Props.X = position.X;
            pic.Props.Y = position.Y;
            pic.Props.Zoom = position.Z;
            pic.Props.R = position.R;
            pic.Props.BackColor = Color.Black;
            Fi.Pics.Add(pic);
            return pic;
        }
        public PictureItem InsertImage(PictureSourceProps pps)
        {
            FrameImage Fi = this.GetImageFrame();
            PictureItem pic = new PictureItem();            
            pic.Props = new PictureSourceProps(pps);
            Fi.Pics.Add(pic);
            return pic;
        }
        public PictureItem InsertImage(string FileName)
        {
            return InsertImage(FileName, 0, 0, 100);
        }

        public SoundItem InsertSound(string fileName, int volume)
        {
            FrameSound Fi = this.GetSoundFrame();
            SoundItem sound = new SoundItem();
            sound.FileName = fileName;
            sound.Volume = volume;
            sound.Position = Fi.SoundList.Count;
            Fi.SoundList.Add(sound);
            return sound;
        }

        public void Dispose()
        {

        }



    }

    public class CadreEventArgs:
        EventArgs
    {
        public Cadre Cadre {get;set;}
        public CadreEventArgs():base(){}
        public CadreEventArgs(Cadre cadre):this()
        {
            this.Cadre = cadre;
        }

    }
}
