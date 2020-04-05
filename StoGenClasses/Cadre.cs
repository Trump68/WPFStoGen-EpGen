using StoGen.ModelClasses;
using System.Collections.Generic;
using System.Windows.Input;
using StoGenMake.Scenes.Base;
using StoGenMake.Elements;

namespace StoGen.Classes
{
    public class Cadre
    {
        public int SortOrder = int.MaxValue;
        public string Name = string.Empty;
        internal CadreData AlignData;
        private bool AlignDataProcessed = false;


        public List<Frame> Frames { set; get; }
        public bool IsProc { get; set; }
        public ProcedureBase Owner{ get; set; }
        public bool AllowedForward { get; set; }
        public bool AllowedBackward { get; set; }
     
        private Cadre() 
        {
            Frames = new List<Frame>();
            Frames.Add(this.ProcFr);
            Frames.Add(this.TextFr);
            Frames.Add(this.SoundFr);
            Frames.Add(this.ImageFr);
            this.ImageFr.Owner = this;
            this.ProcFr.Owner = this;
            this.SoundFr.Owner = this;
            this.TextFr.Owner = this;
            IsProc = false;
            AllowedForward = true;
            AllowedBackward = true;
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

        public FrameText TextFr = new FrameText();
        public FrameImage ImageFr = new FrameImage();
        public FrameProc ProcFr = new FrameProc();
        public FrameSound SoundFr = new FrameSound();

        public virtual Cadre Repaint(bool doRecalculate) 
        {            
            Cadre result = this;
            //if (this.TextFr == null)
            Projector.TextVisible = true;
            if (this.AlignData != null && !this.AlignDataProcessed)
            {
                this.AlignDataProcessed = true;
                ScenCadre cdr =  this.Owner.Scene.MakeCadre(this.AlignData);
                foreach (seIm data in cdr.VisionList)
                {                   
                    var ids = data.ToPictureDataSource();
                    ids.Level = (PicLevel)(cdr.VisionList.IndexOf(data));
                    PictureItem pic = new PictureItem();
                    pic.Props = new PictureSourceProps(ids);
                    this.ImageFr.Pics.Add(pic);
                    
                }
                foreach (seSo data in cdr.SoundList)
                {
                    var sds = data.ToSoundDataSource();
                    sds.Position = cdr.SoundList.IndexOf(data);
                    this.SoundFr.SoundList.Add(sds);                    
                }
                foreach (seTe dataTe in cdr.TextList)
                {
                    this.TextFr.SetData(dataTe);
                }                
            }
            foreach (Frame item in Frames)
            {
                Cadre temp = item.Repaint();
            }            
            return result;
        }             
        internal void ProcessKey(Key keys)
        {
            for (int i = 0; i < Frames.Count; i++)
            {
                if (Frames[i] is FrameImage)
                    (Frames[i] as FrameImage).ProcessKey(keys);

            }            
        }
   
    }

   }
