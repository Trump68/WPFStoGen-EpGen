﻿using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoGen.Classes.Transition
{
    public class TransitionManager
    {
        public List<TransitionData> TransitionList = new List<TransitionData>();
        internal void Clear()
        {
            TransitionList.Clear();
            isStarted = false;
        }
        public void Stop() 
        {
            foreach (var datalist in TransitionList)
            {
                foreach (var objectTransitionList in datalist.Transitions)
                {
                        objectTransitionList.ForEach(x => x.ForceComplete = true);
                }
            }
        }
        internal void Add(TransitionData trandata)
        {
            TransitionList.Add(trandata);
        }
        public bool isStarted = false;
        internal bool Process()
        {            
            bool completed = true;
            foreach (var datalist in TransitionList)
            {
                foreach (var objectTransitionList in datalist.Transitions)
                {
                    if (!isStarted)
                    {
                        objectTransitionList.ForEach(x => x.Init());                        
                    }
                    var activeTransition = objectTransitionList.Where(x => x.Active).FirstOrDefault();
                    if (activeTransition != null)
                    {
                        completed = false;
                        bool rn;
                        if (activeTransition.Execute(out rn))
                        {
                            if (activeTransition.ExecutionsCountRestricted) 
                            {
                                activeTransition.ExecutionsLeft = activeTransition.ExecutionsLeft - 1;
                            }
                            if (activeTransition.IsEndless)
                            {
                                objectTransitionList.ForEach(x => 
                                {
                                    if (!x.ExecutionsCountRestricted || x.ExecutionsLeft>0)
                                        x.Init(); 
                                });                                
                            }
                        }
                    }
                }
            }
            isStarted = true;
            return completed;
        }        
    }
    public class TransitionData
    {
        static Random rnd = new Random();
        public List<List<TransitionItem>> Transitions;
        internal int Level = 0;
        public void Parse(string strdata, int cadreType)
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
                    elementList.AddRange(CreateTransitionItem(element, Level, cadreType));
                }
                elementList.Last().IsEndless = isEndless;
                Transitions.Add(elementList);
            }
        }
        private static List<TransitionItem> CreateTransitionItem(string data, int level, int cadreType)
        {
            // cadreType
            // 0 - image
            // 1 - sound
            // 2 - text
            // 3 - video
            List<TransitionItem> result = new List<TransitionItem>();

            string[] vals = data.Split('.');
            if (vals[0].StartsWith("O"))
            {
                if (cadreType == 0)
                    result.Add(new TransitionOpacityImage(vals, level));
                else if (cadreType == 2)
                    result.Add(new TransitionOpacityText(vals, level));
                else if (cadreType == 3)
                    result.Add(new TransitionOpacityVideo(vals, level));
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
            else if (vals[0].StartsWith("F"))
            {
                result.Add(new TransitionFlip(vals, level));
            }
            else if (vals[0].StartsWith("p"))
            {
                result.Add(new TransitionPlaySound(vals, level));
            }
            else if (vals[0].StartsWith("v"))
            {
                result.Add(new TransitionVolume(vals, level));
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
                if (vals.Length > 2 && !string.IsNullOrEmpty(vals[2]))
                {
                    if (vals[2].StartsWith("$")) // random run-time calculation
                    {
                        var items = vals[2].Split('-');
                        if (items.Length == 1) 
                        {
                            this.SpanMax = long.Parse(items[0].Substring(1));
                        }
                        else if (items.Length > 1)
                        {
                            this.SpanMin = long.Parse(items[0].Substring(1));
                            this.SpanMax = long.Parse(items[1]);
                        }
                    }
                    else
                    {
                        this.Span = long.Parse(vals[2]);
                    }
                }
                if (vals.Length > 3 && !string.IsNullOrEmpty(vals[3]) && !vals[3].StartsWith("c"))
                {
                    this.REnd = long.Parse(vals[3]);
                }
                if (vals.Last().StartsWith("c"))
                {
                    ExecutionsCountRestricted = true;
                    ExecutionsLeft = int.Parse(vals.Last().Substring(1));
                }
                this.calculator = TransitionCalculator.GetCalculator(this);
            }
            internal double Counter = 0;
            internal double Started = 0;
            public int ExecutionsLeft;
            public bool ExecutionsCountRestricted = false;
            public long Span;
            public long SpanMin;
            public long SpanMax;
            public double Begin;
            public double End;
            public double REnd;
            public string Option;
            public bool Active = false;
            public int Level;
            public bool IsEndless = false;
            public bool IsRelative = false;
            public bool isReverse = false;
            public virtual bool Execute(out bool repaintNeed)
            {                
                repaintNeed = false;
                return false;
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

            public bool ForceComplete { get; internal set; } = false;

            public double CalcTran()
            {
                return calculator.Calc();
            }
            public void Init() 
            {
                ForceComplete = false;
                if (SpanMax > 0) 
                {                    
                    Span = rnd.Next(Convert.ToInt32(SpanMin), Convert.ToInt32(SpanMax));
                }
                Active = true;
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
                        string v = Owner.Option.Substring(1, 2);
                        _Power = float.Parse(v) / 10;
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
                        {
                            _Threshhold = 0;
                            //_Threshhold = int.Parse(Owner.Option.Remove(0, 3));
                        }
                           
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
        //Basic transitions
        public class TransitionWait : TransitionItem
        {
            public TransitionWait(string[] vals, int level) : base(vals, level) { }

            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;

                if (this.Started == 0)
                {
                    this.Started = now;
                    return false;
                }
                if (ForceComplete || now >= this.Started + this.Span)
                {
                    this.Close();
                    return true;
                }
                return false;
            }
        }
        public class TransitionPercent : TransitionItem
        {
            public TransitionPercent(string[] vals, int level) : base(vals, level) { }
            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
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
                if (ForceComplete || ((!this.isReverse && cr >= this.End) || (this.isReverse && cr <= this.End)))
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
                    if (ForceComplete || CurrentVal == this.Begin) 
                    {
                        CurrentVal = this.End;
                        this.Close();
                        return true;
                    }                        
                }
                return false;
            }
        }
        // Image transitions
        public class TransitionXY : TransitionItem
        {
            public TransitionXY(string[] vals, int level) : base(vals, level) { }
            public bool isYcoord = false;
            private double _initVal;
            private double _CurrentVal;
            bool init = false;
            public override double CurrentVal
            {
                get
                {
                    if (!init)
                    {
                        if (!isYcoord)
                            _initVal = VisualTreeHelper.GetOffset(Projector.PicContainer.PicList[this.Level]).X;
                        else
                            _initVal = VisualTreeHelper.GetOffset(Projector.PicContainer.PicList[this.Level]).Y;
                        init = true;
                    }
                    return 0;
                    //return Canvas.GetTop(Projector.PicContainer.PicList[this.Level]);
                }
                set
                {
                    _CurrentVal = value;
                    if (!isYcoord)
                        Canvas.SetLeft(Projector.PicContainer.PicList[this.Level], _initVal + value);
                    else
                        Canvas.SetTop(Projector.PicContainer.PicList[this.Level], _initVal + value);
                }
            }

            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                //double cr = CurrentVal;

                if (this.Started == 0)
                {
                    this.Started = now;
                    this.Begin = CurrentVal;
                    this.End = this.Begin + this.REnd;
                    this.isReverse = this.Begin > this.End;
                    //if (isReverse)
                    //    this.End = this.End * (-1);
                    return false;
                }
                repaintNeed = true;
                if (isReverse)
                {
                    if (ForceComplete || CurrentVal <= this.End)
                    {
                        CurrentVal = this.End;
                        this.Close();
                        return true;
                    }
                }
                else
                {
                    if (ForceComplete || CurrentVal >= this.End)
                    {
                        CurrentVal = this.End;
                        this.Close();
                        return true;
                    }
                }


                this.Counter = now - this.Started;
                double delta = this.CalcTran();
                if (delta != 0)
                {
                    var rez = this.Begin + delta;
                    if (this.isReverse)
                    {
                        if (ForceComplete || rez <= this.End)
                        {
                            CurrentVal = this.End;
                            this.Close();
                            return true;
                        }
                    }
                    else
                    {
                        if (ForceComplete || rez >= this.End)
                        {
                            CurrentVal = this.End;
                            this.Close();
                            return true;
                        }
                    }
                    CurrentVal = rez;
                }
                return false;
            }
        }
        public class TransitionOpacityImage : TransitionPercent
        {
            public TransitionOpacityImage(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    if (Projector.PicContainer.PicList[this.Level].Opacity > 1)
                        return 100;
                    return Projector.PicContainer.PicList[this.Level].Opacity * 100;
                }
                set
                {
                    if (value > 100)
                        Projector.PicContainer.PicList[this.Level].Opacity = 1;
                    else
                        Projector.PicContainer.PicList[this.Level].Opacity = value / 100;
                }
            }
        }
        public class TransitionOpacityVideo : TransitionPercent
        {
            public TransitionOpacityVideo(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    if (Projector.PicContainer.Clip.Opacity > 1)
                        return 100;
                    return Projector.PicContainer.Clip.Opacity * 100;
                }
                set
                {
                    if (value > 100)
                        Projector.PicContainer.Clip.Opacity = 1;
                    else
                        Projector.PicContainer.Clip.Opacity = value / 100;
                }
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
            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
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
                repaintNeed = true;
                if (ForceComplete || (!this.isReverse && cr >= this.End) || (this.isReverse && cr <= this.End))
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
        public class TransitionRotate : TransitionItem
        {

            public TransitionRotate(string[] vals, int level) : base(vals, level) { }
            private double _CurrentVal;
            public override double CurrentVal
            {
                get
                {
                    return _CurrentVal;
                }
                set
                {
                    _CurrentVal = value;
                    var current = Projector.PicContainer.PicList[this.Level];
                    FrameImage.Pics.Where(it => it.Props.Level == this.Level).FirstOrDefault().Props.Rotate = Convert.ToInt32(value);
                    FrameImage.DoRotateFlip(null, this.Level);
                }
            }
            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
                double now = DateTime.Now.TimeOfDay.TotalMilliseconds;
                //double cr = CurrentVal;

                if (this.Started == 0)
                {
                    this.Started = now;
                    this.Begin = CurrentVal;
                    this.End = this.Begin + this.REnd;
                    this.isReverse = this.Begin > this.End;
                    //if (isReverse)
                    //    this.End = this.End * (-1);
                    return false;
                }
                repaintNeed = true;
                if (isReverse)
                {
                    if (ForceComplete || CurrentVal <= this.End)
                    {
                        CurrentVal = this.End;
                        this.Close();
                        return true;
                    }
                }
                else
                {
                    if (ForceComplete || CurrentVal >= this.End)
                    {
                        CurrentVal = this.End;
                        this.Close();
                        return true;
                    }
                }


                this.Counter = now - this.Started;
                double delta = this.CalcTran();
                if (delta != 0)
                {
                    var rez = this.Begin + delta;
                    if (this.isReverse)
                    {
                        if (ForceComplete || rez <= this.End)
                        {
                            CurrentVal = this.End;
                            this.Close();
                            return true;
                        }
                    }
                    else
                    {
                        if (ForceComplete || rez >= this.End)
                        {
                            CurrentVal = this.End;
                            this.Close();
                            return true;
                        }
                    }
                    CurrentVal = rez;
                }
                return false;
            }
        }
        public class TransitionFlip : TransitionItem
        {

            public TransitionFlip(string[] vals, int level) : base(vals, level) { }
            private double _CurrentVal;
            public override double CurrentVal
            {
                get
                {
                    return _CurrentVal;
                }
                set
                {
                    _CurrentVal = value;
                    var current = Projector.PicContainer.PicList[this.Level];
                    FrameImage.Pics.Where(it => it.Props.Level == this.Level).FirstOrDefault().Props.Flip = (RotateFlipType)value;
                    FrameImage.DoRotateFlip(null, this.Level);
                }
            }

            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = true;
                CurrentVal = this.REnd;
                this.Close();
                return true;
            }
        }
        // Sound transitions
        public class TransitionPlaySound : TransitionItem
        {
            public TransitionPlaySound(string[] vals, int level) : base(vals, level) { }
            private bool Playng = false;
            public override double CurrentVal
            {
                get
                {
                    if (FrameSound.PlayingItems[Level] != null)
                    {
                        Playng = true;
                        return 1;
                    }
                    else
                    {
                        Playng = false;
                        return 0;
                    }
                    //double val = Projector.Sound[Level].Position.TotalMilliseconds;
                    //if (val > 0) return 1;
                    //return 0;
                }
                set
                {


                    Projector.Sound[Level].Dispatcher.Invoke(new Action(
                     () =>
                     {
                         if ((ForceComplete || value>0) && !Playng)
                         {
                             FrameSound.StartSound(Level);
                             Playng = true;
                         }
                         else if ((ForceComplete || value > 0) && Playng)
                         {
                             Projector.Sound[Level].Stop();
                             Playng = false;
                         }                         
                     }));
                    this.Active = false;
                }
            }
            public override bool Execute(out bool repaintNeed)
            {
                repaintNeed = false;
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
                repaintNeed = true;
                if ((!this.isReverse && cr >= this.End) || (this.isReverse && cr <= this.End))
                {
                    this.Close();
                    return true;
                }

                this.Counter = now - this.Started;
                double delta = this.CalcTran();
                if (delta != 0)
                {
                    if (cr == 0)
                        CurrentVal = 1;
                    else
                        CurrentVal = 0;
                }
                return false;
            }
        }
        public class TransitionVolume : TransitionPercent
        {
            public TransitionVolume(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {
                    return Projector.Sound[Level].Volume * 100;
                }
                set
                {

                    Projector.Sound[Level].Dispatcher.Invoke(new Action(
                     () =>
                     {
                         Projector.Sound[Level].Volume = (value / 100);
                     }));
                }
            }
        }
        // Text transitions
        public class TransitionOpacityText : TransitionPercent
        {
            public TransitionOpacityText(string[] vals, int level) : base(vals, level) { }
            public override double CurrentVal
            {
                get
                {                    
                    if (this.Level == 1)
                        return Projector.TextCanvas.Opacity * 100;
                    else if (this.Level == 2)
                        return Projector.TextCanvas2.Opacity * 100;
                    else if (this.Level == 3)
                        return Projector.TextCanvas3.Opacity * 100;
                    else
                        return Projector.TextCanvas4.Opacity * 100;
                }
                set
                {
                    if (this.Level == 1)
                        Projector.TextCanvas.Opacity = value / 100;
                    else if (this.Level == 2)
                        Projector.TextCanvas2.Opacity = value / 100;
                    else if (this.Level == 3)
                        Projector.TextCanvas3.Opacity = value / 100;
                    else if (this.Level == 4)
                        Projector.TextCanvas4.Opacity = value / 100;
                }
            }
        }
    }
}
