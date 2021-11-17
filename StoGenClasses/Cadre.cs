using StoGen.ModelClasses;
using System.Collections.Generic;
using System.Windows.Input;
using StoGenMake.Elements;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Threading;
using System.Threading;

namespace StoGen.Classes
{
    public class Cadre
    {
        public int SortOrder = int.MaxValue;
        public string Name = string.Empty;
        //internal CadreData Data;
        private bool AlignDataProcessed = false;


        public List<Frame> Frames { set; get; }
        public CadreController Owner { get; set; }
        public bool AllowedForward { get; set; }
        public bool AllowedBackward { get; set; }

        private Cadre()
        {
            Frames = new List<Frame>();
            Frames.Add(this.ProcFr);
            Frames.Add(this.TextFr);
            Frames.Add(this.SoundFr);
            Frames.Add(this.ImageFr);
            //Frames.Add(this.ControlFr);
            this.ImageFr.Owner = this;
            this.ProcFr.Owner = this;
            this.SoundFr.Owner = this;
            this.TextFr.Owner = this;
            //this.ControlFr.Owner = this;
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
        // public FrameControl ControlFr = new FrameControl();
        //public CadreInfo CadreInfo;

        public virtual Cadre Repaint(CadreInfo info, bool isForward, bool paint)
        {
            Cadre result = this;
            Projector.TextVisible = true;
            FrameImage.PausePeriod1 = info.DefClipPause1;
            //if (!this.AlignDataProcessed)
            //{
                if (paint)
                {
                    this.AlignDataProcessed = true;
                    FrameImage.Pics.Clear();
                    foreach (seIm data in info.VisionList)
                    {
                        var ids = data.ToPictureDataSource();
                        //ids.Level = info.VisionList.IndexOf(data);
                        ids.Level = data.Z;
                        PictureItem pic = new PictureItem();
                        pic.Props = new PictureSourceProps(ids);
                        FrameImage.Pics.Add(pic);
                    }
                    FrameImage.ControlData = info.Control;
                }
                this.SoundFr.SoundList.Clear();
                foreach (seSo data in info.SoundList)
                {
                    var sds = data.ToSoundDataSource();
                    sds.Position = info.SoundList.IndexOf(data);
                    this.SoundFr.SoundList.Add(sds);
                }
                if (!isForward)
                    this.SoundFr.ClearPlayedCount();
                this.TextFr.TextList.Clear();
                foreach (seTe dataTe in info.TextList)
                {
                    this.TextFr.SetData(dataTe);
                }
            //}

            //this.ControlFr.SetData(info.Control);


            if (paint)
            {                                

                var fi = Frames.FirstOrDefault(x => (x is FrameImage));
                if (fi != null)
                    fi.Repaint();
                foreach (Frame item in Frames.Where(x => !(x is FrameImage)))
                {

                    Cadre temp = item.Repaint();
                }
            }
            //FrameControl.SetData(info.Control);
            //FrameControl.Repaint();
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
        internal void Destroy()
        {
            foreach (Frame item in Frames)
            {
                item.Dispose();
            }
        }
    }

   }
