﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit.Utils;
using PerPixelAlphaBlend;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WMPLib;

namespace StoGen.Classes
{

    public class TransitionData
    {

        public void Parse(string strdata)
        {
            List<string> series = strdata.Split('*').ToList();
            this.Transitions = new List<List<TransitionItem>>();
            foreach (var serie in series)
            {
                bool isEndless = false;
                string s = serie;
                if (serie.EndsWith("~"))
                {
                    s = serie.Replace("~", string.Empty);
                    isEndless = true;
                }
                List<string> elements = s.Split('>').ToList();
                List<TransitionItem> elementList = new List<TransitionItem>();
                foreach (var element in elements)
                {
                    elementList.AddRange(CreateTransitionItem(element, this.Level));
                }
                elementList.Last().IsEndless = isEndless;
                Transitions.Add(elementList);
            }
        }
        private static List<TransitionItem> CreateTransitionItem(string data, int level)
        {
            List<TransitionItem> result = new List<TransitionItem>();

            string[] vals = data.Split('.');
            if (vals[0].StartsWith("O"))
            {
                result.Add(new TransitionOpacity(vals, level));
            }
            else if (vals[0].StartsWith("X"))
            {
                result.Add(new TransitionXY(vals, level) { isYcoord = false });
            }
            else if (vals[0].StartsWith("Y"))
            {
                result.Add(new TransitionXY(vals, level) { isYcoord = true });
            }
            else if (vals[0].StartsWith("W"))
            {
                result.Add(new TransitionWait(vals, level));
            }
            else if (vals[0].StartsWith("A"))
            {
                result.Add(new TransitionScaleXY(vals, level) { isYCoord = false });
                result.Add(new TransitionScaleXY(vals, level) { isYCoord = true });
            }
            else if (vals[0].StartsWith("S"))
            {
                result.Add(new TransitionScaleXY(vals, level) { isYCoord = false });
            }
            else if (vals[0].StartsWith("C"))
            {
                result.Add(new TransitionScaleXY(vals, level) { isYCoord = true });
            }
            else if (vals[0].StartsWith("R"))
            {
                result.Add(new TransitionRotate(vals, level));
            }
            return result;
        }
        public class TransitionItem
        {
            TransitionCalculator calculator;
            public TransitionItem(string[] vals, int level)
            {
                this.Level = level;
                if (vals[0].EndsWith("r")) this.IsRelative = true;
                if (vals.Length > 1 && !string.IsNullOrEmpty(vals[1]))
                {
                    this.Option = vals[1];
                }
                if (vals.Length > 2 && !string.IsNullOrEmpty(vals[2])) this.Span = long.Parse(vals[2]);
                if (vals.Length > 3 && !string.IsNullOrEmpty(vals[3])) this.REnd = long.Parse(vals[3]);
                this.calculator = TransitionCalculator.GetCalculator(this);
            }
            internal double Counter = 0;
            internal double Started = 0;
            public long Span;
            public double Begin;
            public double End;
            public double REnd;
            public string Option;
            public bool Active = true;
            public int Level;
            public bool IsEndless = false;
            public bool IsRelative = false;
            public bool isReverse = false;
            public virtual bool Execute()
            {
                return true;
            }
            public void Close()
            {
                Counter = 0;
                Started = 0;                
                this.Active = false;
            }
            public virtual double CurrentVal
            {
                get
                { return 0; }
                set
                { }
            }
            public double CalcTran()
            {
                return calculator.Calc();
            }
        }
        public class TransitionCalculator
        {
            protected TransitionItem Owner;

            public static TransitionCalculator GetCalculator(TransitionItem owner)
            {
                if (owner.Option == null)
                {
                    return null;
                }
                else if (owner.Option.StartsWith("A"))
                {
                    return new TransitionCalculatorTrigger() { Owner = owner };
                }
                else if (owner.Option.StartsWith("B"))
                {
                    return new TransitionCalculatorLinear() { Owner = owner };
                }
                else if (owner.Option.StartsWith("C"))
                {
                    return new TransitionCalculatorPower() { Owner = owner };
                }
                return null;
            }
            public virtual double Calc()
            {
                return 0;
            }
        }
        public class TransitionCalculatorTrigger : TransitionCalculator
        {
            public override double Calc()
            {
                double result = 0;
                double delta = Owner.End - Owner.Begin; // всего значения
                if (Owner.Counter >= Owner.Span) return delta;
                return result;
            }
        }
        public class TransitionCalculatorLinear : TransitionCalculator
        {
            public override double Calc()
            {
                double result = 0;
                double delta = Owner.End - Owner.Begin; // всего значения
                double timedelta = (Owner.Counter / Owner.Span); // доля приращения, в конце должна быть 1 (pass = span * timedelta)               
                result = delta * timedelta;
                return result;
            }
        }
        public class TransitionCalculatorPower : TransitionCalculator
        {
            private float _Power = -1;
            private float Power
            {
                get
                {
                    if (_Power == -1)
                    {
                        _Power = float.Parse(Owner.Option.Substring(1, 2)) / 10;
                    }
                    return _Power;
                }
            }
            private int _Threshhold = -1;
            private int Threshhold
            {
                get
                {
                    if (_Threshhold == -1)
                    {
                        if (Owner.Option.Length < 3)
                            _Threshhold = 0;
                        else
                            _Threshhold = int.Parse(Owner.Option.Remove(0, 3));
                    }
                    return _Threshhold;
                }
            }
            public override double Calc()
            {
                double result = 0;
                double delta = Owner.End - Owner.Begin; // всего значения
                double timedelta = (Owner.Counter / Owner.Span); // доля приращения, в конце должна быть 1 (pass = span * timedelta)               
                result = delta * Math.Pow(timedelta, Power);
                if (Threshhold > 0)
                {                   
                    if (Math.Abs(result) < Math.Abs(Threshhold))
                    {
                        if (result > 0)
                            result = Threshhold;
                        else
                            result = -Threshhold;
                    }
                }                
                return result;
            }
        }
        public class TransitionWait : TransitionItem
        {
            public TransitionWait(string[] vals, int level) : base(vals, level) { }

            public override bool Execute()
            {
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
               
                if (this.Started == 0)
                {
                    this.Started = now;                   
                    return false;
                }
                if (now >= this.Started +this.Span)
                {                   
                    this.Close();
                    return true;
                }
                return false;
            }
        }
        public class TransitionXY : TransitionItem
        {
            public TransitionXY(string[] vals, int level) : base(vals, level) { }
            public bool isYcoord = false;


            public override double CurrentVal
            {
                get
                {
                    if (!isYcoord)
                        return Projector.PicContainer.PicList[this.Level].Margin.Left;
                    else
                        return Projector.PicContainer.PicList[this.Level].Margin.Top;
                }
                set
                {
                    if (!isYcoord)
                        Projector.PicContainer.PicList[this.Level].Margin = new System.Windows.Thickness(value, Projector.PicContainer.PicList[this.Level].Margin.Top, 0, 0);
                    else
                        Projector.PicContainer.PicList[this.Level].Margin = new System.Windows.Thickness(Projector.PicContainer.PicList[this.Level].Margin.Left, value, 0, 0);
                }
            }
            public override bool Execute()
            {

                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                double cr = CurrentVal;

                if (this.Started == 0)
                {
                    this.Started = now;
                    this.Begin = cr;
                    this.End = this.Begin + this.REnd;
                    this.isReverse = this.Begin > this.End;
                    return false;
                }
                if ((!this.isReverse && cr >= this.End) || (this.isReverse && cr <= this.End))
                {
                    CurrentVal = this.End;
                    this.Close();
                    return true;
                }

                this.Counter = now - this.Started;
                double delta = this.CalcTran();
                if (delta != 0)
                {
                    CurrentVal = this.Begin + delta;
                }
                return false;
            }
        }
        public class TransitionScaleXY : TransitionItem
        {
            public bool isYCoord = false;
            public TransitionScaleXY(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    if (!isYCoord)
                        return Projector.PicContainer.PicList[this.Level].Width;
                    else
                        return Projector.PicContainer.PicList[this.Level].Height;
                }
                set
                {
                    if (!isYCoord)
                        Projector.PicContainer.PicList[this.Level].Width = value;
                    else
                        Projector.PicContainer.PicList[this.Level].Height = value;
                }
            }
            public override bool Execute()
            {
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                double cr = CurrentVal;

                if (this.Started == 0)
                {
                    this.Started = now;
                    this.Begin = cr;
                    this.End = this.Begin * (this.REnd / 100);
                    this.isReverse = this.Begin > this.End;
                    return false;
                }
                if ((!this.isReverse && cr >= this.End) || (this.isReverse && cr <= this.End))
                {
                    CurrentVal = this.End;
                    this.Close();
                    return true
                }

                this.Counter = now - this.Started;
                double delta = this.CalcTran();
                if (delta != 0)
                {
                    CurrentVal = this.Begin + delta;
                }
                return false;
            }
        }
        public class TransitionOpacity : TransitionItem
        {
            public TransitionOpacity(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    return Projector.PicContainer.PicList[this.Level].Opacity;
                }
                set
                {
                    Projector.PicContainer.PicList[this.Level].Opacity = value;
                }
            }
            public override bool Execute()
            {
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                if (this.Started == 0)
                {
                    this.Started = now;
                    if (IsRelative)
                    {
                        this.Begin = CurrentVal + this.Begin;
                        this.End = CurrentVal + this.End;
                    }
                }
                if (now < (this.Started)) return false;
                this.Counter = this.Started + this.Span - now;
                if (this.Counter <= 0)
                {
                    CurrentVal = (this.End / 100.1);
                    return true;
                }
                else
                {
                    double delta = this.CalcTran();

                    CurrentVal = ((this.Begin + delta) / 100.1);
                }
                return false;
            }
        }
 
        public class TransitionRotate : TransitionItem
        {

            public TransitionRotate(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    var trn = (Projector.PicContainer.PicList[this.Level].RenderTransform as TransformGroup);
                    if (trn == null) return 0;
                    return (trn.Children.First() as RotateTransform).Angle;
                }
                set
                {
                    var transformGroup = new TransformGroup();
                    var roateTransform = new RotateTransform(value);
                    transformGroup.Children.Add(roateTransform);
                    Projector.PicContainer.PicList[this.Level].RenderTransform = transformGroup;
                }
            }
            public override bool Execute()
            {

                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                if (this.Started == 0)
                {
                    this.Started = now;
                    if (IsRelative)
                    {
                        this.Begin = this.Begin;
                        this.End = this.End;
                    }
                }
                //if (now < (this.Started)) return false;
                this.Counter = this.Started + this.Span - now;
                if (this.Counter <= 0)
                {
                    CurrentVal = this.End;
                    return true;
                }
                else if (this.Counter != this.Span)
                {
                    if (!this.Option.StartsWith("A"))
                    {
                        double delta = this.CalcTran();
                        CurrentVal = this.Begin + delta;
                        var transformGroup = new TransformGroup();
                    }
                }
                return false;
            }
        }
       

        public List<List<TransitionItem>> Transitions;
        internal int Level = 0;
    }


    public delegate void RunNext();
    public class FrameImage : Frame, IDisposable
    {

        private int CanvasShiftY = 0;//25;
        private int CanvasShiftX = 0;//10;
        public static System.Threading.Timer timer;

        public static List<TransitionData> CurrentTransitionList = new List<TransitionData>();
        public static ProcedureBase CurrentProc;
        public static volatile bool LoopProcessed = false;
        public static int debugcount = 0;

        public static void RunNextDelegate()
        {
            FrameImage.CurrentProc.GetNextCadre();
        }

        static DateTime lastupdated;
        public static int TimerPeriod = 20;
        public static int PausePeriod1 = 200;
        public static int PausePeriod2 = 200;
        public static int TimeToNext = -1;
        public static int WaitStart = -1;
        public static int WaitEnd = -1;
        public static void ProcessLoopDelegate()
        {
            //Transition
            if (CurrentTransitionList != null)
            {
                foreach (var TranSeriesForImage in CurrentTransitionList)
                {
                    foreach (var TranSeries in TranSeriesForImage.Transitions)
                    {
                        var tran = TranSeries.Where(x => x.Active).FirstOrDefault();
                        if (tran != null)
                        {
                            if (tran.Execute())
                            {
                                if (tran.IsEndless)
                                {
                                    TranSeries.ForEach(x => x.Active = true);
                                }
                            }
                        }
                    }

                }
            }


            if (Projector.TimerEnabled && (FrameImage.TimeToNext > 0))
            {
                if (FrameImage.TimeStarted.AddMilliseconds(FrameImage.TimeToNext) <= DateTime.Now)
                {
                    FrameImage.CurrentProc.GetNextCadre();
                    return;
                }
            }
            if (Projector.TimerEnabled && (FrameImage.WaitStart > 0))
            {
                if (FrameImage.TimeStarted.AddMilliseconds(FrameImage.WaitStart) <= DateTime.Now)
                {
                    if (FrameImage.IsLoop == 4)
                    {
                        FrameImage.CurrentProc.GetNextCadre();
                    }
                    else
                    {
                        FrameImage.WaitStart = -1;
                        Projector.PicContainer.Clip.Play();
                        FrameImage.TimeStarted = DateTime.Now;
                    }
                    return;
                }
            }

            if (!FrameImage.LoopProcessed && FrameImage.ClipEndPos > 0)
            {
                if (FrameImage.IsLoop == 3) //назад
                {
                    if (!FrameImage.NowReverse && Projector.PicContainer.Clip.Position >= TimeSpan.FromSeconds(FrameImage.ClipEndPos))
                    {
                        Projector.PicContainer.Clip.Pause();
                        FrameImage.NowReverse = !FrameImage.NowReverse;
                        Thread.Sleep((int)(PausePeriod1 * Projector.PicContainer.Clip.SpeedRatio));
                        lastupdated = DateTime.Now;
                    }
                    else if (FrameImage.NowReverse)
                    {
                        if (Projector.PicContainer.Clip.Position <= TimeSpan.FromSeconds(FrameImage.ClipStartPos))
                        {
                            Thread.Sleep((int)(PausePeriod2 * Projector.PicContainer.Clip.SpeedRatio));
                            Projector.PicContainer.Clip.Play();
                            FrameImage.NowReverse = !FrameImage.NowReverse;
                        }
                        else
                        {
                            Projector.PicContainer.Clip.Position = Projector.PicContainer.Clip.Position.Subtract(TimeSpan.FromMilliseconds(DateTime.Now.Subtract(lastupdated).TotalMilliseconds * Projector.PicContainer.Clip.SpeedRatio));
                            lastupdated = DateTime.Now;
                        }
                    }
                }
                else
                {
                    if (Projector.PicContainer.Clip.Position >= TimeSpan.FromSeconds(FrameImage.ClipEndPos))
                    {
                        if (FrameImage.IsLoop == 0 && !Projector.EndlessVideo)//остановить
                        {
                            FrameImage.LoopProcessed = true;
                            Projector.PicContainer.Clip.Pause();

                            if (FrameImage.WaitEnd > 0)// замереть на время
                            {
                                FrameImage.IsLoop = 4;
                                FrameImage.WaitStart = FrameImage.WaitEnd;
                                FrameImage.WaitEnd = -1;
                                FrameImage.TimeStarted = DateTime.Now;
                            }
                            else// перейти дальше
                            {
                                Thread.Sleep((int)(PausePeriod1 * Projector.PicContainer.Clip.SpeedRatio));
                                FrameImage.CurrentProc.GetNextCadre();
                            }

                            return;
                        }
                        else if (FrameImage.IsLoop == 2 && !Projector.EndlessVideo)//остановить
                        {
                            FrameImage.LoopProcessed = true;
                            Projector.PicContainer.Clip.Pause();
                        }
                        else // в начало
                        {
                            Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                        }
                    }

                }
            }
        }

        private void TimerProc(object state)
        {

            timer.Change(Timeout.Infinite, Timeout.Infinite);

            RunNext op1 = new RunNext(FrameImage.ProcessLoopDelegate);
            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);

            if (timer != null) timer.Change(TimerPeriod, TimerPeriod);
        }

        PicLevelComparer sorter = new PicLevelComparer();
        public List<PictureBaseProp> PostProcessingData { get; set; }
        public List<PictureItem> Pics { get; set; }
        public bool AutoShift { get; set; }

        public FrameImage()
            : base()
        {
            this.Pics = new List<PictureItem>();
            this.PostProcessingData = new List<PictureBaseProp>();
            this.AutoShift = false;
            if (timer == null) timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, TimerPeriod, TimerPeriod);
        }
        List<TimeData> TimerPeriods = new List<TimeData>();

        public override Cadre Repaint()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            FrameImage.LoopProcessed = false;

            FrameImage.CurrentProc = this.Proc;
            FrameImage.NextCadre = 0;

            if (Pics[0].Props.FileName == "SKIP") return this.Owner;



            CurrentTransitionList.Clear();
            base.Repaint();
            Pics.Sort(sorter);

            foreach (System.Windows.Controls.Image item in Projector.PicContainer.PicList)
            {
                item.Tag = null;
            }
            bool runClip = false;
            bool videoactive = false;
            FrameImage.TimeToNext = -1;
            FrameImage.WaitStart = -1;
            FrameImage.WaitEnd = -1;
            for (int i = 0; i < Pics.Count; i++)
            {
                if (Pics[i].Props.NextCadre > 0) FrameImage.NextCadre = Pics[i].Props.NextCadre;
                if (!Pics[i].Props.Active)
                {
                    FrameImage.IsLoop = Pics[i].Props.isLoop;
                    continue;
                }


                PictureItem pi = Pics[i];
                string fn = pi.Props.FileName;

                //System.Windows.Controls.Image gf = Projector.PicContainer.PicList[(int)pi.Props.Level];
                if (Projector.PicContainer.PicList[(int)pi.Props.Level].Tag != null && (string)Projector.PicContainer.PicList[(int)pi.Props.Level].Tag == fn && !pi.Props.Reload)
                {
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Tag = fn;
                    continue;
                }



                if (!File.Exists(Pics[i].Props.FileName))
                {
                    XtraMessageBox.Show(Pics[i].Props.FileName, "File not exists", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                string ext = Path.GetExtension(Pics[i].Props.FileName);
                if (pi.Props.Timer > 0)
                    FrameImage.TimeToNext = pi.Props.Timer;

                if (Pics[i].Props.isVideo || ext == ".mp4" || ext == ".mpg" || ext == ".avi" || ext == ".wmv" || ext == ".m4v")
                {
                    FrameImage.TimeToNext = -1;
                    videoactive = true;
                    FrameImage.IsLoop = pi.Props.isLoop;
                    FrameImage.ClipStartPos = Pics[i].Props.StartPos;
                    FrameImage.ClipEndPos = Pics[i].Props.EndPos;
                    FrameImage.WaitStart = Pics[i].Props.Timer;
                    FrameImage.WaitEnd = Pics[i].Props.Timer2;
                    if (Projector.PicContainer.Clip.Source == null || (Projector.PicContainer.Clip.Source.LocalPath != Pics[i].Props.FileName))
                    {
                        Projector.PicContainer.Clip.Source = new Uri(Pics[i].Props.FileName);
                        Projector.PicContainer.Clip.MediaOpened -= Clip_MediaOpened;
                        Projector.PicContainer.Clip.MediaOpened += Clip_MediaOpened;
                        Projector.PicContainer.Clip.Play();
                        //if (FrameImage.IsLoop==4)  Projector.PicContainer.Clip.Stop();
                    }
                    else
                    {
                        SetClip();
                    }

                    Projector.PicContainer.Clip.IsMuted = true;
                    if (Pics[i].Props.Rate > 0)
                    {
                        float rate = ((float)Pics[i].Props.R / 100);
                        Projector.PicContainer.Clip.SpeedRatio = rate;
                    }
                    if (Pics[i].Props.SizeX == -2 || Pics[i].Props.SizeY == -2)
                    {
                        Pics[i].Props.SizeX = Projector.PicContainer.Clip.NaturalVideoWidth;
                        Pics[i].Props.SizeY = Projector.PicContainer.Clip.NaturalVideoHeight;
                    }
                    if (Pics[i].Props.SizeX == -1 || Pics[i].Props.SizeY == -1)
                    {
                        Pics[i].Props.SizeX = Projector.PicContainer.Clip.NaturalVideoWidth;
                        Pics[i].Props.SizeY = Projector.PicContainer.Clip.NaturalVideoHeight;
                    }
                    if (Pics[i].Props.SizeX > 0 && Pics[i].Props.SizeY > 0)
                    {
                        System.Drawing.Size NewSize = new System.Drawing.Size(Pics[i].Props.SizeX, Pics[i].Props.SizeY);
                        Projector.PicContainer.Clip.Height = NewSize.Height;
                        Projector.PicContainer.Clip.Width = NewSize.Width;
                    }

                    if (pi.Props.ClipX > 0 || pi.Props.ClipY > 0 || pi.Props.ClipW > 0 || pi.Props.ClipH > 0)
                    {
                        double clipW = pi.Props.ClipW;
                        double clipH = pi.Props.ClipH;
                        if (clipW == -1) { clipW = pi.Props.SizeX - pi.Props.ClipX; }
                        else if (clipW == 0)
                        {
                            clipW = pi.Props.SizeX;
                        }
                        if (clipH == -1) { clipH = pi.Props.SizeY - pi.Props.ClipY; }
                        else if (clipH == 0)
                        {
                            clipH = pi.Props.SizeY;
                        }
                        Projector.PicContainer.Clip.Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
                    }
                    else
                    {
                        Projector.PicContainer.Clip.Clip = null;
                    }

                    Projector.PicContainer.Clip.Margin = new System.Windows.Thickness(Pics[i].Props.X + CanvasShiftX, Pics[i].Props.Y + CanvasShiftY, 0, 0);
                    runClip = true;
                    //FrameImage.debugcount++;
                    if (Pics[i].Props.PP1 > 0) PausePeriod1 = Pics[i].Props.PP1;
                    else PausePeriod1 = 40;
                    if (Pics[i].Props.PP2 > 0) PausePeriod2 = Pics[i].Props.PP2;
                    else PausePeriod2 = 40;
                    continue;
                }

                BitmapImage imageSource = new BitmapImage(new Uri(fn));

                if (pi.Props.Opacity > 0) Projector.PicContainer.PicList[(int)pi.Props.Level].Opacity = (pi.Props.Opacity / 100.0);
                if (pi.Props.Blur > 0)
                {
                    System.Windows.Media.Effects.BlurEffect be = new System.Windows.Media.Effects.BlurEffect();
                    be.Radius = pi.Props.Blur;
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Effect = be;
                }
                else
                {
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Effect = null;
                }
                // resize



                if (pi.Props.SizeX == -1 || pi.Props.SizeY == -1)
                {
                    if (pi.Props.SizeX == -1) pi.Props.SizeX = imageSource.PixelWidth;
                    if (pi.Props.SizeY == -1) pi.Props.SizeY = imageSource.PixelHeight;
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Stretch = Stretch.Uniform;
                }
                else if (pi.Props.SizeX == -2 || pi.Props.SizeY == -2)
                {
                    //if (image.Size.Width > 1600)
                    pi.Props.SizeX = 1600;
                    //if (image.Size.Height > 900)
                    pi.Props.SizeY = 900;
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Stretch = Stretch.Uniform;
                }
                else
                {
                    if (pi.Props.SizeMode == PictureSizeMode.Clip) Projector.PicContainer.PicList[(int)pi.Props.Level].Stretch = Stretch.Fill;
                }


                if (!string.IsNullOrEmpty(pi.Props.Transition))
                {
                    TransitionData trandata = new TransitionData();
                    trandata.Level = (int)pi.Props.Level;
                    trandata.Parse(pi.Props.Transition);
                    FrameImage.CurrentTransitionList.Add(trandata);
                }

                Projector.PicContainer.PicList[(int)pi.Props.Level].Source = imageSource;

                Projector.PicContainer.PicList[(int)pi.Props.Level].Width = pi.Props.SizeX;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Height = pi.Props.SizeY;



                Projector.PicContainer.PicList[(int)pi.Props.Level].Margin = new System.Windows.Thickness(pi.Props.X, pi.Props.Y, 0, 0);
                Projector.PicContainer.PicList[(int)pi.Props.Level].Visibility = System.Windows.Visibility.Visible;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Tag = fn;
                //Projector.PicContainer.PicList[(int)pi.Props.Level]

                if (pi.Props.ClipX > 0 || pi.Props.ClipY > 0 || pi.Props.ClipW > 0 || pi.Props.ClipH > 0)
                {
                    double clipW = pi.Props.ClipW;
                    double clipH = pi.Props.ClipH;
                    if (clipW == -1) { clipW = pi.Props.SizeX - pi.Props.ClipX; }
                    else if (clipW == 0)
                    {
                        clipW = pi.Props.SizeX;
                    }
                    if (clipH == -1) { clipH = pi.Props.SizeY - pi.Props.ClipY; }
                    else if (clipH == 0)
                    {
                        clipH = pi.Props.SizeY;
                    }
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
                }
                else
                {
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = null;
                }


                var transformGroup = new TransformGroup();
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                if ((int)pi.Props.Flip == 1)
                {
                    ScaleTransform flipTrans = new ScaleTransform();
                    flipTrans.ScaleX = -1;
                    transformGroup.Children.Add(flipTrans);
                }
                else if ((int)pi.Props.Flip == 2)
                {

                    ScaleTransform flipTrans = new ScaleTransform();
                    flipTrans.ScaleY = -1;
                    transformGroup.Children.Add(flipTrans);
                }

                if (pi.Props.Rotate > 0)
                {
                    var roateTransform = new RotateTransform(pi.Props.Rotate);
                    transformGroup.Children.Add(roateTransform);
                }
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform = transformGroup;


            }
            if (CadreShifted < 0) CadreShifted = this.Pics.Count - 1;


            SetVisible(this.isVisible);

            if (!videoactive) Projector.PicContainer.Clip.Visibility = System.Windows.Visibility.Hidden;
            for (int j = 1; j < Projector.PicContainer.PicList.Count; j++)
            {

                if (Projector.PicContainer.PicList[j].Tag == null)
                {
                    Projector.PicContainer.PicList[j].Source = null;
                    Projector.PicContainer.PicList[j].Visibility = System.Windows.Visibility.Hidden;

                }
                else
                {
                    bool ok = true;
                }
            }


            if (!runClip)
                timer.Change(TimerPeriod, TimerPeriod);
            FrameImage.TimeStarted = DateTime.Now;

            return this.Owner;
        }

        private void Clip_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            SetClip();
        }
        private void SetClip()
        {
            Projector.PicContainer.Clip.MediaOpened -= Clip_MediaOpened;
            Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
            Projector.PicContainer.Clip.Visibility = System.Windows.Visibility.Visible;
            FrameImage.TimeStarted = DateTime.Now;
            timer.Change(TimerPeriod, TimerPeriod);
            Projector.PicContainer.Clip.Play();
            if (FrameImage.IsLoop == 4 || FrameImage.WaitStart > 0) Projector.PicContainer.Clip.Pause();
        }


        private void OnAnimationStop(object sender, EventArgs e)
        {
            if (this.AutoShift)
            {
                this.Owner.AllowedForward = true;
                this.Proc.GetNextCadre();
            }
        }
        public void Clear()
        {
            TimerPeriods.Clear();
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            Projector.PicContainer.Clip.Visibility = System.Windows.Visibility.Hidden;

        }
        public override void BeforeLeave()
        {
            CurrentTransitionList.Clear();
            PostProcessingData.Clear();
            TimerPeriods.Clear();
        }
        public override void SetVisible(bool show)
        {


        }

        int CadreShifted = -1;
        public static double ClipStartPos;
        public static double ClipEndPos;
        private static double NextCadre;
        private static DateTime TimeStarted;
        private static int IsLoop = 0;
        private static bool NowReverse = false;

        internal void ProcessKey(Key e)
        {
            if (!Projector.EditorMode) return;
            bool increase = false;

            if (e == Key.NumPad6)
            {
                Projector.ImageCadre.PropIndex = 1;
                increase = true;
            }
            else if (e == Key.NumPad4)
            {
                Projector.ImageCadre.PropIndex = 1;
                increase = false;
            }
            else if (e == Key.NumPad2)
            {
                Projector.ImageCadre.PropIndex = 2;
                increase = true;
            }
            else if (e == Key.NumPad8)
            {
                Projector.ImageCadre.PropIndex = 2;
                increase = false;
            }
            else if (e == Key.NumPad7)
            {
                Projector.ImageCadre.PropIndex = 3;
                increase = true;
            }
            else if (e == Key.NumPad8)
            {
                Projector.ImageCadre.PropIndex = 3;
                increase = false;
            }
            else if (e == Key.NumPad1)
            {
                Projector.ImageCadre.PropIndex = 4;
                increase = true;
            }
            else if (e == Key.NumPad3)
            {
                Projector.ImageCadre.PropIndex = 4;
                increase = false;
            }
            else if (e == Key.A)
            {
                Projector.ImageCadre.PropIndex = 5;
                increase = true;
            }
            else if (e == Key.S)
            {
                Projector.ImageCadre.PropIndex = 5;
                increase = false;
            }
            else if (e == Key.D)
            {
                Projector.ImageCadre.PropIndex = 6;
                increase = true;
            }
            else if (e == Key.F)
            {
                Projector.ImageCadre.PropIndex = 6;
                increase = false;
            }
            else if (e == Key.G)
            {
                Projector.ImageCadre.PropIndex = 7;
                increase = true;
            }
            else if (e == Key.H)
            {
                Projector.ImageCadre.PropIndex = 7;
                increase = false;
            }
            else if (e == Key.J)
            {
                Projector.ImageCadre.PropIndex = 8;
                increase = true;
            }
            else if (e == Key.K)
            {
                Projector.ImageCadre.PropIndex = 8;
                increase = false;
            }

            int lev = Projector.ImageCadre.LayerIndex;
            PictureItem pi = Pics.First(p => (int)p.Props.Level == lev);
            if (pi == null) return;

            if (Projector.ImageCadre.PropIndex == 1)
            {
                if (increase)
                    pi.Props.X += Projector.ImageCadre.PropStep;
                else
                    pi.Props.X -= Projector.ImageCadre.PropStep;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Margin = new System.Windows.Thickness(pi.Props.X, pi.Props.Y, 0, 0);
            }
            else if (Projector.ImageCadre.PropIndex == 2)
            {
                if (increase)
                    pi.Props.Y += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Y -= Projector.ImageCadre.PropStep;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Margin = new System.Windows.Thickness(pi.Props.X, pi.Props.Y, 0, 0);
            }
            else if (Projector.ImageCadre.PropIndex == 3)
            {
                if (increase)
                    pi.Props.SizeX += Projector.ImageCadre.PropStep;
                else
                    pi.Props.SizeX -= Projector.ImageCadre.PropStep;

                pi.Props.SizeY = pi.Props.SizeX;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Width = pi.Props.SizeX;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Height = pi.Props.SizeY;

            }
            else if (Projector.ImageCadre.PropIndex == 4)
            {
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform = null;
                var transformGroup = new TransformGroup();
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);


                if (increase)
                    pi.Props.Rotate += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Rotate -= Projector.ImageCadre.PropStep;


                if ((int)pi.Props.Flip == 1)
                {
                    ScaleTransform flipTrans = new ScaleTransform();
                    flipTrans.ScaleX = -1;
                    transformGroup.Children.Add(flipTrans);
                }
                else if ((int)pi.Props.Flip == 2)
                {

                    ScaleTransform flipTrans = new ScaleTransform();
                    flipTrans.ScaleY = -1;
                    transformGroup.Children.Add(flipTrans);
                }

                if (pi.Props.Rotate > 0)
                {
                    var roateTransform = new RotateTransform(pi.Props.Rotate);
                    transformGroup.Children.Add(roateTransform);
                }
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform = transformGroup;
            }
            else if (Projector.ImageCadre.PropIndex == 5)
            {
                if (increase)
                    pi.Props.ClipX += Projector.ImageCadre.PropStep;
                else
                    pi.Props.ClipX -= Projector.ImageCadre.PropStep;
            }
            else if (Projector.ImageCadre.PropIndex == 6)
            {
                if (increase)
                    pi.Props.ClipW += Projector.ImageCadre.PropStep;
                else
                    pi.Props.ClipW -= Projector.ImageCadre.PropStep;
                if (pi.Props.ClipW < 0)
                    pi.Props.ClipW = 0;
            }
            else if (Projector.ImageCadre.PropIndex == 7)
            {
                if (increase)
                    pi.Props.ClipY += Projector.ImageCadre.PropStep;
                else
                    pi.Props.ClipY -= Projector.ImageCadre.PropStep;
            }
            else if (Projector.ImageCadre.PropIndex == 8)
            {
                if (increase)
                    pi.Props.ClipH += Projector.ImageCadre.PropStep;
                else
                    pi.Props.ClipH -= Projector.ImageCadre.PropStep;
                if (pi.Props.ClipH < 0)
                    pi.Props.ClipH = 0;
            }

            if (pi.Props.ClipX > 0 || pi.Props.ClipY > 0 || pi.Props.ClipW > 0 || pi.Props.ClipH > 0)
            {
                double clipW = pi.Props.ClipW;
                double clipH = pi.Props.ClipH;
                if (clipW == -1) { clipW = pi.Props.SizeX - pi.Props.ClipX; }
                else if (clipW == 0)
                {
                    clipW = pi.Props.SizeX;
                }
                if (clipH == -1) { clipH = pi.Props.SizeY - pi.Props.ClipY; }
                else if (clipH == 0)
                {
                    clipH = pi.Props.SizeY;
                }
                Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
            }
            else
            {
                Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = null;
            }

            Projector.ImageCadre.ResultString = $";ClipX={pi.Props.ClipX};ClipW={pi.Props.ClipW};ClipY={pi.Props.ClipY};ClipH={pi.Props.ClipH};X={pi.Props.X};Y={pi.Props.Y};SizeX={pi.Props.SizeX};SizeY={pi.Props.SizeY};Rotate={pi.Props.Rotate}";
            System.Windows.Clipboard.SetText(Projector.ImageCadre.ResultString);
        }
        private PictureItem TopImage
        {
            get
            {
                for (int i = this.Pics.Count - 1; i > 0; i--)
                {
                    if (this.Pics[i].Props.Active) return this.Pics[i];
                }
                return this.Pics[0];
            }
        }
        public override void Dispose()
        {

            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            foreach (PictureItem pic in Pics)
            {
                if (pic.image != null)
                {
                    pic.image.Dispose();
                    pic.image = null;
                }

            }
            /*
            foreach (System.Windows.Controls.Image item in Projector.PicContainer.PicList)
            {
                if (item.Source != null)
                {
                    item.Image.Dispose();
                    item.Image = null;
                }
            }
            */
            this.Pics.Clear();
            base.Dispose();
        }


    }
    public class TimeData
    {
        public int Pos;
        public int Period;
        public int Elasped;
    }
    public class PicLevelComparer : IComparer<PictureItem>
    {

        public int Compare(PictureItem x, PictureItem y)
        {
            return x.Props.Level.CompareTo(y.Props.Level);
        }
    }
}
