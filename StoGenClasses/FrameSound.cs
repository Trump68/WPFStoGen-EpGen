﻿using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;

namespace StoGen.Classes
{

    public class FrameSound : Frame
    {
        public static SoundItem[] PlayingItems = new SoundItem[] { null, null, null, null, null };

        public List<SoundItem> SoundList { get; set; }
        public Timer timer;
        public static TransitionManager tranManager = new TransitionManager();

        public static void ProcessLoopDelegate()
        {
            //Transition
            FrameSound.tranManager.Process();
        }

        private void TimerProc(object state)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            RunNext op1 = new RunNext(FrameSound.ProcessLoopDelegate);
            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);

            if (timer != null) timer.Change(500, 500);            
        }

        private void FrameSound_MediaEnded(object sender, EventArgs e)
        {
            int index = Projector.Sound.IndexOf((sender as System.Windows.Media.MediaPlayer));
            if (PlayingItems[index].isLoop)
            {
                (sender as System.Windows.Media.MediaPlayer).Position = TimeSpan.Zero;
                (sender as System.Windows.Media.MediaPlayer).Play();
            }
        }

        public FrameSound()
            : base()
        {
            SoundList = new List<SoundItem>();
            timer = new Timer(new TimerCallback(TimerProc), null, 100, 100);
        }

        private void StopPlayer(int Position, bool force)
        {
            
            if (PlayingItems[Position] != null && (force || (PlayingItems[Position].isLoop == false)))
            {
                Projector.Sound[Position].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[4].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[Position].Stop();
                            Projector.Sound[4].MediaEnded += FrameSound_MediaEnded;
                        }));
            }
        }
        public override Cadre Repaint()
        {

            foreach (SoundItem item in this.SoundList)
            {
                    SetSoundOneItem(item.Position, item);                    
            }

            return Owner;
        }

        SoundItem CurrItem0;
        SoundItem CurrItem1;
        SoundItem CurrItem2;
        SoundItem CurrItem3;
        SoundItem CurrItem4;

        private void StartPlayer(int N, SoundItem item)
        {
            string soundfile = item.FileName;
            Projector.Sound[N].Dispatcher.Invoke(new Action(
            () =>
            {
                Projector.Sound[N].MediaEnded -= FrameSound_MediaEnded;
                Projector.Sound[N].Volume = (double)item.Volume / 100;
                Projector.Sound[N].Open(new Uri(soundfile));
                Projector.Sound[N].MediaEnded += FrameSound_MediaEnded;
                if (item.Start)
                Projector.Sound[N].Play();
            }));          
        }
        private void SetSoundOneItem(int position, SoundItem item)
        {
            Projector.Sound[position].Volume = (double)item.Volume / 100;
            Projector.Sound[position].IsMuted = item.isMute;
            PlayingItems[position] = item;
            if (!string.IsNullOrEmpty(item.Transition))
            {
                TransitionData trandata = new TransitionData();
                trandata.Level = item.Position;
                trandata.Parse(item.Transition);
                FrameImage.tranManager.Add(trandata);
            }
            if (item.FileName == "STOP")
            {
                StopPlayer(position,true);
            }          
            else if (!string.IsNullOrWhiteSpace(item.FileName))
            {
                if ((Projector.Sound[position].Source == null || (Projector.Sound[position].Source.LocalPath != item.FileName) || !item.isLoop))
                {
                    if (position == 0)      { CurrItem0 = item; StartPlayer(0, item); }
                    else if (position == 1) { CurrItem1 = item; StartPlayer(1, item); }
                    else if (position == 2) { CurrItem2 = item; StartPlayer(2, item); }
                    else if (position == 3) { CurrItem3 = item; StartPlayer(3, item); }                
                    else if (position == 4) { CurrItem4 = item; StartPlayer(4, item); }
                }
            }
            else
            {                
                Projector.Sound[position].Stop();
            }
        }

    }
    [Serializable]
    public class SoundItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SoundItem()
        {
            isLoop = true;
            Volume = 0;
            isMute = false;
        }
        public string FileName { get; set; }
        public int Volume { get; set; }
        public bool isLoop { get; set; }
        public int Position { get; set; } = -1;
        public bool isMute { get; set; }
        public int Silence { get; set; }
        public string RawData { get; set; }

        public List<SoundItem> List = null;
        public int CurrentIndex;
        internal string Transition { get; set; }

        internal bool Start { get; set; } = true;
    }

  
}
