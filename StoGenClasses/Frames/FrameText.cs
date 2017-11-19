using System;
using System.Collections.Generic;
using StoGen.ModelClasses;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;
using StoGenMake.Elements;
using System.Linq;
using StoGen.Classes.Transition;

namespace StoGen.Classes
{
    public class FrameText : Frame
    {
        public List<string> TextList { get; set; }
        public string Text
        {
            set
            {
                TextList.Clear();
                TextList.Add(value);
            }
        }
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public Color BackColor { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Bottom { get; set; }
        public string Transition { get; set; }
        public int Opacity { get; set; }
        public int Shift { get; set; }
        public int Aligh { get; set; }
        public bool ClearBack { get; set; } = false;
        public System.Threading.Timer timer;
        public static TransitionManager tranManager = new TransitionManager();
        public FrameText() : base()
        {
            TextList = new List<string>();
            timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 500, 500);
        }
        private void TimerProc(object state)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            RunNext op1 = new RunNext(FrameText.ProcessLoopDelegate);
            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);

            if (timer != null) timer.Change(500, 500);
        }
        public static void ProcessLoopDelegate()
        {
            //Transition
            FrameText.tranManager.Process();
        }
        public override Cadre Repaint()
        {
            
            base.Repaint();
            FrameText.tranManager.Clear();
            Projector.TextBlock1.TextWrapping  = TextWrapping.Wrap;            
            Projector.TextBlock2.TextWrapping = TextWrapping.Wrap;
            Projector.TextBlock3.TextWrapping = TextWrapping.Wrap;
            Projector.TextBlock4.TextWrapping = TextWrapping.Wrap;

            if (Size > 0)
            {
                Projector.TextCanvas.Height = Size;
                if (Width > 0) Projector.TextCanvas.Width = Width;
                else Projector.TextCanvas.Width = 800;
                Projector.TextBlock1.Width = Projector.TextCanvas.Width;
                Projector.TextBlock2.Width = Projector.TextCanvas.Width;
                Projector.TextBlock3.Width = Projector.TextCanvas.Width;
                Projector.TextBlock4.Width = Projector.TextCanvas.Width;

                double bm = Bottom;
                double tm = Projector.TextCanvas.Margin.Top;
                Projector.TextCanvas.Margin = new System.Windows.Thickness(Shift, tm, Projector.TextCanvas.Margin.Right, bm);
            }
            if (!string.IsNullOrEmpty(Transition))
            {
                TransitionData trandata = new TransitionData();
                trandata.Parse(Transition,2);
                FrameImage.tranManager.Add(trandata);
            }
            //if (!ClearBack)
            //    Projector.TextCanvas.Background = new SolidColorBrush(this.BackColor);
            //else
            //    Projector.TextCanvas.Background = null;

            if (!string.IsNullOrWhiteSpace(FontName))
            {
                FontFamily font = new FontFamily(FontName);
                Projector.TextBlock1.FontFamily = font;
                Projector.TextBlock2.FontFamily = font;
                Projector.TextBlock3.FontFamily = font;
                Projector.TextBlock4.FontFamily = font;
            }
            if (FontSize > 0)
            {
                Projector.TextBlock1.FontSize = FontSize;
                Projector.TextBlock2.FontSize = FontSize;
                Projector.TextBlock3.FontSize = FontSize;
                Projector.TextBlock4.FontSize = FontSize;
            }

            if (Aligh == 1)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Right;
            }
            else if (Aligh == 0)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Left;
            }
            else if (Aligh == 2)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Center;
            }            

            if (!string.IsNullOrEmpty(FontColor))
            {
                SolidColorBrush br = System.Windows.Media.Brushes.White;
                if (FontColor == "Black")
                    br = System.Windows.Media.Brushes.Black;
                else if (FontColor == "White")
                    br = System.Windows.Media.Brushes.White;
                else if (FontColor == "Red")
                    br = System.Windows.Media.Brushes.Red;
                else if (FontColor == "Blue")
                    br = System.Windows.Media.Brushes.Blue;
                else if (FontColor == "Yellow")
                    br = System.Windows.Media.Brushes.Yellow;
                else                   
                  br = new System.Windows.Media.SolidColorBrush(
                      (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(FontColor));

                Projector.TextBlock1.Foreground = br;
                Projector.TextBlock2.Foreground = br;
                Projector.TextBlock3.Foreground = br;
                Projector.TextBlock4.Foreground = br;
            }

            Projector.TextCanvas.Opacity = this.Opacity / 100;
            //Projector.Text.Opacity = 0;
            Projector.TextVisible = true;
            
            string txt = string.Join(Environment.NewLine, TextList.ToArray());
            TypewriteTextblock(txt, Projector.TextBlock1, new TimeSpan(0, 0, 3));
            TypewriteTextblock(txt, Projector.TextBlock2, new TimeSpan(0, 0, 3));
            TypewriteTextblock(txt, Projector.TextBlock3, new TimeSpan(0, 0, 3));
            TypewriteTextblock(txt, Projector.TextBlock4, new TimeSpan(0, 0, 3));

            return this.Owner;
        }

        internal void SetData(seTe data)
        {
            this.TextList.AddRange(data.Text.Split('~').ToList());
            //this.BackColor = data.BackColor;
            this.FontName = data.FontName;
            this.FontSize = data.FontSize;
            this.FontColor = data.FontColor;
            this.Size = data.Size;
            this.Shift = data.Shift;
            this.Bottom = data.Bottom;
            this.Width = data.Width;
            this.ClearBack = data.ClearBack;
            this.AutoShow = data.AutoShow;
            //this.Rtf = data.Rtf;
            //this.Aligh = data.Align;
            this.Opacity = data.Opacity;
            this.Transition = data.T;

        }

  
        private void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
        {
            Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.HoldEnd;
            //story.RepeatBehavior = RepeatBehavior.Forever;
            story.RepeatBehavior = new RepeatBehavior(1);

            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);
            story.Begin(txt);
        }
        public bool AutoShow { get; set; }
        public override void SetVisible(bool show)
        {
            
                Projector.TextVisible = show;


        }
      
        public bool Html { get; set; }
        public bool Rtf { get; set; }
    }
 
}
