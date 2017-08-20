using StoGen.ModelClasses;
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
        private int Silent0 = 0;
        private int Silent1 = 0;
        private int Silent2 = 0;
        private int Silent3 = 0;
        private int Silent4 = 0;
        private bool[] ChangeList = new[] { false, false, false, false, false };
        private void TimerProc(object state)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            if (ChangeList[0])
            {
                if (CurrItem0 != null)
                {
                    Silent0--;
                    if (Silent0 <= 0)
                    {
                        ChangeList[0] = false;
                        string soundfile = CurrItem0.FileName;
                        loadingPlayer[0] = true;
                        Projector.Sound[0].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[0].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[0].Volume = (double)CurrItem0.Volume / 100;
                            Projector.Sound[0].Open(new Uri(soundfile));                           
                            Projector.Sound[0].MediaEnded += FrameSound_MediaEnded;
                            Projector.Sound[0].Play();

                        }));
                        if (CurrItem0.Silence > 0) Silent0 = Universe.Rnd.Next(CurrItem0.Silence);
                        else Silent0 = 0;
                    }
                }
            }
            if (ChangeList[1])
            {
                if (CurrItem1 != null)
                {
                    Silent1--;
                    if (Silent1 <= 0)
                    {
                        ChangeList[1] = false;
                        string soundfile = CurrItem1.FileName;
                        loadingPlayer[1] = true;
                        Projector.Sound[1].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[1].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[1].Volume = (double)CurrItem1.Volume / 100;
                            Projector.Sound[1].Open(new Uri(soundfile));                            
                            Projector.Sound[1].MediaEnded += FrameSound_MediaEnded;
                            Projector.Sound[1].Play();
                        }));
                        if (CurrItem1.Silence > 0) Silent1 = Universe.Rnd.Next(CurrItem1.Silence);
                        else Silent1 = 0;
                    }
                }
            }
            if (ChangeList[2])
            {
                if (CurrItem2 != null)
                {
                    Silent2--;
                    if (Silent2 <= 0)
                    {
                        ChangeList[2] = false;
                        string soundfile = CurrItem2.FileName;
                        loadingPlayer[2] = true;
                        Projector.Sound[2].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[2].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[2].Volume = (double)CurrItem2.Volume / 100;
                            Projector.Sound[2].Open(new Uri(soundfile));                           
                            Projector.Sound[2].MediaEnded += FrameSound_MediaEnded;
                            Projector.Sound[2].Play();
                        }));
                        if (CurrItem2.Silence > 0) Silent2 = Universe.Rnd.Next(CurrItem2.Silence);
                        else Silent2 = 0;
                    }
                }
            }
            if (ChangeList[3])
            {
                if (CurrItem3 != null)
                {
                    Silent3--;
                    if (Silent3 <= 0)
                    {
                        ChangeList[3] = false;
                        string soundfile = CurrItem3.FileName;
                        loadingPlayer[3] = true;
                        Projector.Sound[3].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[3].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[3].Volume = (double)CurrItem3.Volume / 100;
                            Projector.Sound[3].Open(new Uri(soundfile));                           
                            Projector.Sound[3].MediaEnded += FrameSound_MediaEnded;
                            Projector.Sound[3].Play();
                        }));
                        if (CurrItem3.Silence > 0) Silent3 = Universe.Rnd.Next(CurrItem3.Silence);
                        else Silent3 = 0;
                    }
                }
            }
            if (ChangeList[4])
            {
                if (CurrItem4 != null)
                {
                    Silent4--;
                    if (Silent4 <= 0)
                    {
                        ChangeList[4] = false;
                        string soundfile = CurrItem4.FileName;
                        loadingPlayer[4] = true;
                        Projector.Sound[4].Dispatcher.Invoke(new Action(
                        () =>
                        {
                            Projector.Sound[4].MediaEnded -= FrameSound_MediaEnded;
                            Projector.Sound[4].Volume = (double)CurrItem4.Volume / 100;
                            Projector.Sound[4].Open(new Uri(soundfile));                           
                            Projector.Sound[4].MediaEnded += FrameSound_MediaEnded;
                            Projector.Sound[4].Play();
                        }));
                        if (CurrItem4.Silence > 0) Silent4 = Universe.Rnd.Next(CurrItem4.Silence);
                        else Silent4 = 0;
                    }
                }
            }
            timer.Change(500, 500);
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
        bool[] loadingPlayer = new bool[] { false, false, false, false, false };
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
            //StopPlayer(0);
            //StopPlayer(1);
            //StopPlayer(2);
            //StopPlayer(3);
            //StopPlayer(4);
            int i = 0;
            List<int> startedPlayers = new List<int>();
            foreach (SoundItem item in this.SoundList)
            {
                
                if (item.List == null || item.List.Count == 0)
                {
                    SetSoundOneItem(item.Position, item);
                    startedPlayers.Add(item.Position);
                }
                else
                {
                    item.CurrentIndex = Universe.Rnd.Next(item.List.Count);
                    SetSoundOneItem(item.Position, item.List[item.CurrentIndex]);
                }
                i++;
            }
            if (!startedPlayers.Contains(0)) StopPlayer(0,false);
            if (!startedPlayers.Contains(1)) StopPlayer(1, false);
            if (!startedPlayers.Contains(2)) StopPlayer(2, false);
            if (!startedPlayers.Contains(3)) StopPlayer(3, false);
            if (!startedPlayers.Contains(4)) StopPlayer(4, false);
            return Owner;
        }

        SoundItem CurrItem0;
        //bool Change0 = false;

        SoundItem CurrItem1;
        //bool Change1 = false;

        SoundItem CurrItem2;
        SoundItem CurrItem3;
        SoundItem CurrItem4;
        //bool Change2 = false;

        private void SetSoundOneItem(int position, SoundItem item)
        {
            Projector.Sound[position].Volume = (double)item.Volume / 100;
            Projector.Sound[position].IsMuted = item.isMute;
            PlayingItems[position] = item;
            if (item.FileName == "STOP")
            {
                StopPlayer(position,true);
            }
            else if (!string.IsNullOrWhiteSpace(item.FileName))
            {
                if ((Projector.Sound[position].Source == null || (Projector.Sound[position].Source.LocalPath != item.FileName) || !item.isLoop))
                {
                    if (position == 0) { CurrItem0 = item; ChangeList[0] = true; }
                    else if (position == 1) { CurrItem1 = item; ChangeList[1] = true; }
                    else if (position == 2) { CurrItem2 = item; ChangeList[2] = true; }
                    else if (position == 3) { CurrItem3 = item; ChangeList[3] = true; }                
                    else if (position == 4) { CurrItem4 = item; ChangeList[4] = true; }
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
    }

  
}
