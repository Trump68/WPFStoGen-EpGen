using StoGen.ModelClasses;
using System.Collections.Generic;
using System.Windows.Input;
using StoGenMake.Scenes.Base;
using StoGenMake.Elements;
using System;

namespace StoGen.Classes
{
    public class Cadre
    {
        public int SortOrder = int.MaxValue;
        public string Name = string.Empty;
        //internal CadreData Data;
        private bool AlignDataProcessed = false;


        public List<Frame> Frames { set; get; }
        public CadreController Owner{ get; set; }
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
            AllowedForward = true;
            AllowedBackward = true;
        }
        public Cadre(CadreController owner, bool isAdd)
            : this()
        {
            this.Owner = owner;
            if (this.Owner != null)
            {
                if (isAdd) this.Owner.Cadres.Add(this);
                else
                {
                    if (this.Owner.CadreId == this.Owner.Cadres.Count) this.Owner.Cadres.Insert(this.Owner.CadreId, this);
                    else this.Owner.Cadres.Insert(this.Owner.CadreId + 1, this);
                }
            }
        }

        public FrameText TextFr = new FrameText();
        public FrameImage ImageFr = new FrameImage();
        public FrameProc ProcFr = new FrameProc();
        public FrameSound SoundFr = new FrameSound();
        //public CadreInfo CadreInfo;

        public virtual Cadre Repaint(CadreInfo info) 
        {            
            Cadre result = this;
            Projector.TextVisible = true;
            if (!this.AlignDataProcessed)
            {
                this.AlignDataProcessed = true;
                foreach (seIm data in info.VisionList)
                {                   
                    var ids = data.ToPictureDataSource();
                    ids.Level = (PicLevel)(info.VisionList.IndexOf(data));
                    PictureItem pic = new PictureItem();
                    pic.Props = new PictureSourceProps(ids);
                    FrameImage.Pics.Add(pic);
                    
                }
                foreach (seSo data in info.SoundList)
                {
                    var sds = data.ToSoundDataSource();
                    sds.Position = info.SoundList.IndexOf(data);
                    this.SoundFr.SoundList.Add(sds);                    
                }
                foreach (seTe dataTe in info.TextList)
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

        internal void Stop()
        {
            foreach (Frame item in Frames)
            {
                item.BeforeLeave();
            }
        }
    }

   }
