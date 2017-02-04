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
        /*
        void FrameSound_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            int index = (int)((sender as AxWindowsMediaPlayer).Tag);
            if (loadingPlayer[index] && e.newState == 3)
            {


            }
            else if (e.newState == 8)//stop
            {
                foreach (SoundItem soundItem in this.SoundList)
                {
                    if (soundItem.Position == index)
                    {
                        if (soundItem.List != null && soundItem.List.Count > 0)
                        {
                            int posindex = Universe.Rnd.Next(soundItem.List.Count);
                            while (posindex == soundItem.CurrentIndex)
                            {
                                posindex = Universe.Rnd.Next(soundItem.List.Count);
                            }
                            soundItem.CurrentIndex = posindex;
                            if (soundItem.isLoop) Projector.Sound[soundItem.Position].settings.setMode("loop", true);
                            else Projector.Sound[soundItem.Position].settings.setMode("loop", false);
                            SetSoundOneItem(soundItem.Position, soundItem.List[soundItem.CurrentIndex]);
                        }
                        else
                        {
                            if (soundItem.isLoop) Projector.Sound[soundItem.Position].settings.setMode("loop", true);
                            //else Projector.Sound[soundItem.Position].settings.setMode("loop", false);
                            //SetSoundOneItem(soundItem.Position, soundItem);
                        }
                    }
                }
            }
        }
        */
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
        public int Position { get; set; }
        public bool isMute { get; set; }
        public int Silence { get; set; }
        public string RawData { get; set; }

        public List<SoundItem> List = null;
        public int CurrentIndex;
    }
    public static class SoundHelperOld
    {
        static List<SoundLibraryItem> _LibManTalk;
        public static List<SoundLibraryItem> ManTalk
        {
            get
            {
                if (_LibManTalk == null)
                {
                    _LibManTalk = new List<SoundLibraryItem>();
                    _LibManTalk.Add(new SoundLibraryItem("ManTalk-01", @"d:\Process2\!Sound\ManTalk\MT-001.mp3", SoundType.ManTalk));
                    _LibManTalk.Add(new SoundLibraryItem("ManTalk-02", @"d:\Process2\!Sound\ManTalk\MT-002.mp3", SoundType.ManTalk));
                    _LibManTalk.Add(new SoundLibraryItem("ManTalk-03", @"d:\Process2\!Sound\ManTalk\MT-003.mp3", SoundType.ManTalk));

                }
                return _LibManTalk;
            }
        }
        static List<SoundLibraryItem> _LibClassic;
        public static List<SoundLibraryItem> Classic
        {
            get
            {
                if (_LibClassic == null)
                {
                    _LibClassic = new List<SoundLibraryItem>();
                    _LibClassic.Add(new SoundLibraryItem("Classic-01", @"d:\Process2\!Sound\Classic\Classic-01.mp3", SoundType.MusicClassic));

                }
                return _LibClassic;
            }
        }
        static List<SoundLibraryItem> _LibMoan;
        public static List<SoundLibraryItem> Moan
        {
            get
            {
                if (_LibMoan == null)
                {
                    _LibMoan = new List<SoundLibraryItem>();
                    _LibMoan.Add(new SoundLibraryItem("Moan01", @"d:\Process2\!Sound\Moans\Moan 001.mp3", SoundType.Moan));
                    _LibMoan.Add(new SoundLibraryItem("Moan02", @"d:\Process2\!Sound\Moans\Moan 002.mp3", SoundType.Moan));
                    _LibMoan.Add(new SoundLibraryItem("Moan03", @"d:\Process2\!Sound\Moans\Moan 003.mp3", SoundType.Moan));
                    _LibMoan.Add(new SoundLibraryItem("Moan04", @"d:\Process2\!Sound\Moans\Moan 004.mp3", SoundType.Moan));
                    _LibMoan.Add(new SoundLibraryItem("Moan05", @"d:\Process2\!Sound\Moans\Moan 005.mp3", SoundType.Moan));
                }
                return _LibMoan;
            }
        }
        static List<SoundLibraryItem> _LibSadness;
        public static List<SoundLibraryItem> Sadness
        {
            get
            {
                if (_LibSadness == null)
                {
                    _LibSadness = new List<SoundLibraryItem>();
                    _LibSadness.Add(new SoundLibraryItem("Sadness-01", @"d:\Process2\!Sound\Sadness\Sadness-01.mp3", SoundType.MusicSorry));
                    _LibSadness.Add(new SoundLibraryItem("Sadness-02", @"d:\Process2\!Sound\Sadness\Sadness-02.mp3", SoundType.MusicSorry));


                }
                return _LibSadness;
            }
        }
        static List<SoundLibraryItem> _LibAction;
        public static List<SoundLibraryItem> Action
        {
            get
            {
                if (_LibAction == null)
                {
                    _LibAction = new List<SoundLibraryItem>();
                    _LibAction.Add(new SoundLibraryItem("Action01", @"d:\Process2\!Sound\Action\Action-001.mp3", SoundType.MusicAction));
                    _LibAction.Add(new SoundLibraryItem("Action02", @"d:\Process2\!Sound\Action\Action-002.mp3", SoundType.MusicAction));
                    _LibAction.Add(new SoundLibraryItem("Action03", @"d:\Process2\!Sound\Action\Action-003.mp3", SoundType.MusicAction));

                }
                return _LibAction;
            }
        }
        static List<SoundLibraryItem> _LibSkrip;
        public static List<SoundLibraryItem> Skrip
        {
            get
            {
                if (_LibSkrip == null)
                {
                    _LibSkrip = new List<SoundLibraryItem>();
                    _LibSkrip.Add(new SoundLibraryItem("Skrip01", @"d:\Process2\!Sound\Skrip\Skrip01.mp3", SoundType.Skrip));
                    _LibSkrip.Add(new SoundLibraryItem("Skrip01a", @"d:\Process2\!Sound\Skrip\Skrip01a.mp3", SoundType.Skrip));
                    _LibSkrip.Add(new SoundLibraryItem("Skrip02", @"d:\Process2\!Sound\Skrip\Skrip02.mp3", SoundType.Skrip));
                    _LibSkrip.Add(new SoundLibraryItem("Skrip04", @"d:\Process2\!Sound\Skrip\Skrip04.mp3", SoundType.Skrip));
                    _LibSkrip.Add(new SoundLibraryItem("Skrip05", @"d:\Process2\!Sound\Skrip\Skrip05.mp3", SoundType.Skrip));
                    _LibSkrip.Add(new SoundLibraryItem("Skrip06", @"d:\Process2\!Sound\Skrip\Skrip06.mp3", SoundType.Skrip));
                }
                return _LibSkrip;
            }
        }
        static List<SoundLibraryItem> _LibClub;
        public static List<SoundLibraryItem> Club
        {
            get
            {
                if (_LibClub == null)
                {
                    _LibClub = new List<SoundLibraryItem>();
                    _LibClub.Add(new SoundLibraryItem("Club01", @"d:\Process2\!Sound\Club\Club01.mp3", SoundType.MusicClub));
                    _LibClub.Add(new SoundLibraryItem("Club02", @"d:\Process2\!Sound\Club\Club02.mp3", SoundType.MusicClub));
                    _LibClub.Add(new SoundLibraryItem("Club03", @"d:\Process2\!Sound\Club\Club03.mp3", SoundType.MusicClub));
                    _LibClub.Add(new SoundLibraryItem("Club04", @"d:\Process2\!Sound\Club\Club04.mp3", SoundType.MusicClub));
                    _LibClub.Add(new SoundLibraryItem("Club05", @"d:\Process2\!Sound\Club\Club05.mp3", SoundType.MusicClub));
                }
                return _LibClub;
            }
        }
        static List<SoundLibraryItem> _LibRomantic;
        public static List<SoundLibraryItem> Romantic
        {
            get
            {
                if (_LibRomantic == null)
                {
                    _LibRomantic = new List<SoundLibraryItem>();
                    _LibRomantic.Add(new SoundLibraryItem("Romantic01", @"d:\Process2\!Sound\Romantic\Romantic-01.ogg", SoundType.MusicRomantic));
                    _LibRomantic.Add(new SoundLibraryItem("Romantic02", @"d:\Process2\!Sound\Romantic\Romantic-02.mp3", SoundType.MusicRomantic));
                    _LibRomantic.Add(new SoundLibraryItem("Romantic03", @"d:\Process2\!Sound\Romantic\Romantic-03.ogg", SoundType.MusicRomantic));
                }
                return _LibRomantic;
            }
        }

        public static void AddWisper01(SoundItem siwisper)
        {            
            for (int i = 1; i <= 35; i++)
            {
                addSoundItem(siwisper, i, @"d:\Process2\!Sound\Wisper\WisperEng 01\WisperEngPart");
            }
        }
        public static void AddSmallKiss01(SoundItem siwisper)
        {
            for (int i = 1; i <= 4; i++)
            {
                addSoundItem(siwisper, i, @"d:\Process2\!Sound\Wisper\SmallKiss 01\SmallKiss");
            }
        }
        public static void AddSmallMoan01(SoundItem siwisper)
        {
            for (int i = 1; i <= 6; i++)
            {
                addSoundItem(siwisper, i, @"d:\Process2\!Sound\Wisper\SmallMoan 01\SmallMoan");
            }
        }
        private static void addSoundItem(SoundItem siwisper, int num, string path)
        {
            SoundItem si = new SoundItem();
            si.FileName = String.Format(@"{1}{0,2:D2}.mp3", num, path);
            siwisper.List.Add(si);
        }
    }
    public class SoundLibraryItem
    {
        public SoundLibraryItem(string name, string fn, SoundType type)
        {
            this.Name = name;
            this.FileName = fn;
            this.TypeOfSound = type;
        }
        public string Name { get; set; }
        public string FileName { get; set; }
        public SoundType TypeOfSound { get; set; }
    }
    public enum SoundType
    {
        Moan,
        Whisper,
        Skrip,
        MusicAction,
        MusicSorry,
        MusicClub,
        MusicRomantic,
        MusicClassic,
        ManTalk
    }
}
