using StoGen.ModelClasses;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;
using StoGen.Classes.Transition;

namespace StoGen.Classes
{

    public class FrameSound : Frame
    {
        public static SoundItem[] PlayingItems = new SoundItem[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        public List<SoundItem> SoundList { get; set; }
        public Timer timer;
        public static TransitionManager tranManager = new TransitionManager();

        public override Cadre Repaint()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            base.Stopped = false;

            FrameSound.tranManager.Clear();
            GroupItems.Clear();
            foreach (SoundItem item in this.SoundList)
            {
                if (!string.IsNullOrEmpty(item.Group))
                {
                    GroupItems.Add(item);
                    if (GroupItems.Where(x => x.Group == item.Group).ToList().Count > 1)
                    {
                        continue;
                    }
                }
                SetSoundOneItem(item.Position, item);
            }
            timer.Change(500, 500);
            return Owner;
        }

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
            if (!base.Stopped)
                if (timer != null) timer.Change(500, 500);            
        }

        private void FrameSound_MediaEnded(object sender, EventArgs e)
        {
            int index = Projector.Sound.IndexOf((sender as System.Windows.Media.MediaPlayer));         
            if (PlayingItems[index] != null && PlayingItems[index].isLoop)
            {
                (sender as System.Windows.Media.MediaPlayer).Position = TimeSpan.Zero;
                (sender as System.Windows.Media.MediaPlayer).Play();
            }
            else
            {
                // Set up next sound in the group
/*                if (!string.IsNullOrEmpty(PlayingItems[index].Group))
                {
                    GroupItems.Remove(PlayingItems[index]);
                    if (GroupItems.Any(x => x.Group == PlayingItems[index].Group))
                    {
                        var item = GroupItems.Where(x => x.Group == PlayingItems[index].Group).First();
                        item.Position = PlayingItems[index].Position;
                        SetSoundOneItem(item.Position, item);
                    }
                }
                else 
                {
*/                    StopPlayer(index, true);
                    //this.SoundList.RemoveAt(index);
                ///}
            }
        }

        public FrameSound()
            : base()
        {
            SoundList = new List<SoundItem>();
            timer = new Timer(new TimerCallback(TimerProc), null, 500, 500);
        }

        internal void ClearPlayedCount()
        {
            for (int i = 0; i < PlayingItems.Length; i++)
            {
                if (PlayingItems[i] != null)
                {
                    var existing = SoundList.Where(x => x != null && x.FileName == PlayingItems[i].FileName).FirstOrDefault();
                    if (existing == null)
                    {
                        StopPlayer(i,true);
                        PlayingItems[i] = null;
                    }
                }
            }
        }

        private void StopPlayer(int Position, bool force)
        {
            
            if (PlayingItems[Position] != null && (force || (PlayingItems[Position].isLoop == false)))
            {
               
                Projector.Sound[Position].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[Position].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[Position].Stop();
                            Projector.Sound[Position].MediaEnded += FrameSound_MediaEnded;
                        }));
            }
        }


        SoundItem CurrItem0;
        SoundItem CurrItem1;
        SoundItem CurrItem2;
        SoundItem CurrItem3;
        SoundItem CurrItem4;
        SoundItem CurrItem5;
        SoundItem CurrItem6;
        SoundItem CurrItem7;
        SoundItem CurrItem8;
        SoundItem CurrItem9;
        SoundItem CurrItem10;
        SoundItem CurrItem11;
        SoundItem CurrItem12;
        SoundItem CurrItem13;
        SoundItem CurrItem14;
        SoundItem CurrItem15;
        SoundItem CurrItem16;
        SoundItem CurrItem17;
        SoundItem CurrItem18;
        SoundItem CurrItem19;

        List<SoundItem> GroupItems = new List<SoundItem>();

        private void StartPlayer(int N, SoundItem item)
        {
            string soundfile = item.FileName;
            if (item.PlayedCound > 0 && !item.isLoop)
                return;
            Projector.Sound[N].Dispatcher.Invoke(new Action(
            () =>
            {
                
                Projector.Sound[N].MediaEnded -= FrameSound_MediaEnded;
                Projector.Sound[N].Volume = (double)item.Volume / 100;
                Projector.Sound[N].Open(new Uri(soundfile));
                Projector.Sound[N].MediaEnded += FrameSound_MediaEnded;
                if (item.Start)
                    StartSound(N);
            }));          
        }
        public static void StartSound(int N) 
        {
            int pos = 0;
            if (PlayingItems[N].isRandom)
            {
                while (!Projector.Sound[N].NaturalDuration.HasTimeSpan)
                {
                    Thread.SpinWait(100);
                }
                double total = Math.Floor(Projector.Sound[N].NaturalDuration.TimeSpan.TotalSeconds);
                Random rnd = new Random();
                int val = rnd.Next(100);
                pos = Convert.ToInt32((total * val) / 100);
            }
                Projector.Sound[N].Position = new TimeSpan(0, 0, pos);
                Projector.Sound[N].Play();
                Projector.Sound[N].Volume = (double)PlayingItems[N].Volume / 100;
                PlayingItems[N].PlayedCound = PlayingItems[N].PlayedCound + 1;
        }

        private void SetSoundOneItem(int position, SoundItem item)
        {
            
            Projector.Sound[position].IsMuted = item.isMute;
            Projector.Sound[position].Volume = (double)item.Volume / 100;
            if (PlayingItems[position] == null || (PlayingItems[position].FileName != item.FileName))
                PlayingItems[position] = item;
            PlayingItems[position].Volume = item.Volume;
            if (!string.IsNullOrEmpty(PlayingItems[position].Transition))
            {
                TransitionData trandata = new TransitionData();
                trandata.Level = item.Position;
                trandata.Parse(item.Transition,1);
                FrameSound.tranManager.Add(trandata);
                PlayingItems[position].Transition = null;
            }
            if (item.FileName == "STOP")
            {
                StopPlayer(position,true);
            }          
            else if (!string.IsNullOrWhiteSpace(item.FileName))
            {
                if ((Projector.Sound[position].Source == null || (Projector.Sound[position].Source.LocalPath != item.FileName) || !item.isLoop))
                {
                    if (position == 0)      { CurrItem0 = item; StartPlayer(0, PlayingItems[position]); }
                    else if (position == 1) { CurrItem1 = item; StartPlayer(1, PlayingItems[position]); }
                    else if (position == 2) { CurrItem2 = item; StartPlayer(2, PlayingItems[position]); }
                    else if (position == 3) { CurrItem3 = item; StartPlayer(3, PlayingItems[position]); }                
                    else if (position == 4) { CurrItem4 = item; StartPlayer(4, PlayingItems[position]); }                   
                    else if (position == 5) { CurrItem5 = item; StartPlayer(5, PlayingItems[position]); }
                    else if (position == 6) { CurrItem6 = item; StartPlayer(6, PlayingItems[position]); }
                    else if (position == 7) { CurrItem7 = item; StartPlayer(7, PlayingItems[position]); }
                    else if (position == 8) { CurrItem8 = item; StartPlayer(8, PlayingItems[position]); }
                    else if (position == 9) { CurrItem9 = item; StartPlayer(9, PlayingItems[position]); }
                    else if (position == 10) { CurrItem10 = item; StartPlayer(10, PlayingItems[position]); }
                    else if (position == 11) { CurrItem11 = item; StartPlayer(11, PlayingItems[position]); }
                    else if (position == 12) { CurrItem12 = item; StartPlayer(12, PlayingItems[position]); }
                    else if (position == 13) { CurrItem13 = item; StartPlayer(13, PlayingItems[position]); }
                    else if (position == 14) { CurrItem14 = item; StartPlayer(14, PlayingItems[position]); }
                    else if (position == 15) { CurrItem15 = item; StartPlayer(15, PlayingItems[position]); }
                    else if (position == 16) { CurrItem16 = item; StartPlayer(16, PlayingItems[position]); }
                    else if (position == 17) { CurrItem17 = item; StartPlayer(17, PlayingItems[position]); }
                    else if (position == 18) { CurrItem18 = item; StartPlayer(18, PlayingItems[position]); }
                    else if (position == 19) { CurrItem19 = item; StartPlayer(19, PlayingItems[position]); }

                }
                else if (Projector.Sound[position].Source.LocalPath == item.FileName)
                {
                    Projector.Sound[position].Volume = (double)item.Volume / 100;
                }
            }
            else
            {                
                Projector.Sound[position].Stop();
            }
        }
        public override void BeforeLeave()
        {
            base.Stopped = true;
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            FrameSound.tranManager.Clear();
        }
        public override void Dispose()
        {
            base.Dispose();
            foreach (SoundItem item in PlayingItems)
            {
                if (item != null)
                {
                    item.PlayedCound = 0;
                    Projector.Sound[item.Position].Close();
                    StopPlayer(item.Position, true);
                }
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
        public bool isRandom { get; set; } = false;
        public int Silence { get; set; }
        public string RawData { get; set; }

        public List<SoundItem> List = null;
        public int CurrentIndex;
        internal string Transition { get; set; }

        internal bool Start { get; set; } = true;
        public string Group { get; internal set; }
        public int PlayedCound = 0;
    }

  
}
