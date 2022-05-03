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
        public static bool Blocked = false;
        public static List<string> TextList { get; set; }
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
        public int FontStyle { get; set; }
        public string FontColor { get; set; }
        public Color BackColor { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Bottom { get; set; }
        public string Transition { get; set; }
        public int Opacity { get; set; }
        public int Shift { get; set; }
        public int HAlig { get; set; }
        public int VAlig { get; set; }
        public static bool Animated { get; set; } = true;
        public bool ClearBack { get; set; } = false;
        public System.Threading.Timer timer;
        public System.Threading.Timer timer2;
        public static TransitionManager tranManager = new TransitionManager();
        public static int LetterPause = 5;
        public FrameText() : base()
        {
            TextList = new List<string>();
            timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 100, 100);
            timer2 = new System.Threading.Timer(new TimerCallback(Timer2Proc), null, LetterPause, LetterPause);
        }
        private void TimerProc(object state)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            RunNext op1 = new RunNext(FrameText.ProcessLoopDelegate);
            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);
            if (!base.Stopped)
                if (timer != null) timer.Change(100, 100);
        }
        private void Timer2Proc(object state)
        {
            timer2.Change(Timeout.Infinite, Timeout.Infinite);

            RunNext op1 = new RunNext(FrameText.ProcessLoopDelegate2);

            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);
            if (!base.Stopped)
                if (timer2 != null) timer2.Change(LetterPause, LetterPause);
        }
        public static void ProcessLoopDelegate()
        {
            //Transition
            FrameText.tranManager.Process();
        }

        public static string rest_text = string.Empty;
        public static string show_text = string.Empty;
        public static void ProcessLoopDelegate2()
        {
            if (!string.IsNullOrEmpty(rest_text)) 
            {
                show_text = show_text + rest_text[0];
                rest_text = rest_text.Remove(0,1);
                Projector.TextBlock1.Text = show_text;
                Projector.TextBlock2.Text = show_text;
                Projector.TextBlock3.Text = show_text;
                Projector.TextBlock4.Text = show_text;

                if (string.IsNullOrEmpty(rest_text)) 
                {
                    show_text = string.Empty;
                    Blocked = false;
                }
            }

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
                Projector.Border1.Height = Size;
                Projector.Border2.Height = Size;
                Projector.Border3.Height = Size;
                Projector.Border4.Height = Size;

                if (Width > 0) Projector.TextCanvas.Width = Width;
                else Projector.TextCanvas.Width = 800;

                Projector.Border1.Width = Projector.TextCanvas.Width;
                Projector.Border2.Width = Projector.TextCanvas.Width;
                Projector.Border3.Width = Projector.TextCanvas.Width;
                Projector.Border4.Width = Projector.TextCanvas.Width;

                double bm = Bottom;
                double tm = Projector.TextCanvas.Margin.Top;
                Projector.TextCanvas.Margin = new System.Windows.Thickness(Shift, tm, Projector.TextCanvas.Margin.Right, bm);
            }
            if (!string.IsNullOrEmpty(Transition))
            {
                TransitionData trandata = new TransitionData();
                trandata.Parse(Transition,2);
                FrameText.tranManager.Add(trandata);
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
            if (FontStyle == 0)
            {
                Projector.TextBlock1.FontStyle = FontStyles.Normal;
                Projector.TextBlock2.FontStyle = FontStyles.Normal;
                Projector.TextBlock3.FontStyle = FontStyles.Normal;
                Projector.TextBlock4.FontStyle = FontStyles.Normal;
                Projector.TextBlock1.FontWeight = FontWeights.Normal;
                Projector.TextBlock2.FontWeight = FontWeights.Normal;
                Projector.TextBlock3.FontWeight = FontWeights.Normal;
                Projector.TextBlock4.FontWeight = FontWeights.Normal;
            }
            else if (FontStyle == 1)
            {
                Projector.TextBlock1.FontStyle = FontStyles.Italic;
                Projector.TextBlock2.FontStyle = FontStyles.Italic;
                Projector.TextBlock3.FontStyle = FontStyles.Italic;
                Projector.TextBlock4.FontStyle = FontStyles.Italic;
                Projector.TextBlock1.FontWeight = FontWeights.Normal;
                Projector.TextBlock2.FontWeight = FontWeights.Normal;
                Projector.TextBlock3.FontWeight = FontWeights.Normal;
                Projector.TextBlock4.FontWeight = FontWeights.Normal;
            }
            else if (FontStyle == 2)
            {
                Projector.TextBlock1.FontStyle = FontStyles.Normal;
                Projector.TextBlock2.FontStyle = FontStyles.Normal;
                Projector.TextBlock3.FontStyle = FontStyles.Normal;
                Projector.TextBlock4.FontStyle = FontStyles.Normal;
                Projector.TextBlock1.FontWeight = FontWeights.Bold;
                Projector.TextBlock2.FontWeight = FontWeights.Bold;
                Projector.TextBlock3.FontWeight = FontWeights.Bold;
                Projector.TextBlock4.FontWeight = FontWeights.Bold;
            }
            else if (FontStyle == 3)
            {
                Projector.TextBlock1.FontStyle = FontStyles.Italic;
                Projector.TextBlock2.FontStyle = FontStyles.Italic;
                Projector.TextBlock3.FontStyle = FontStyles.Italic;
                Projector.TextBlock4.FontStyle = FontStyles.Italic;
                Projector.TextBlock1.FontWeight = FontWeights.Bold;
                Projector.TextBlock2.FontWeight = FontWeights.Bold;
                Projector.TextBlock3.FontWeight = FontWeights.Bold;
                Projector.TextBlock4.FontWeight = FontWeights.Bold;
            }

            if (HAlig == 1)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Right;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Right;
            }
            else if (HAlig == 0)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Left;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Left;
            }
            else if (HAlig == 2)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Center;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Center;
            }
            else if (HAlig == 3)
            {
                Projector.TextBlock1.TextAlignment = System.Windows.TextAlignment.Justify;
                Projector.TextBlock2.TextAlignment = System.Windows.TextAlignment.Justify;
                Projector.TextBlock3.TextAlignment = System.Windows.TextAlignment.Justify;
                Projector.TextBlock4.TextAlignment = System.Windows.TextAlignment.Justify;
            }

            if (VAlig == 0)
            {
                Projector.Border1.VerticalAlignment = VerticalAlignment.Top;
                Projector.Border2.VerticalAlignment = VerticalAlignment.Top;
                Projector.Border3.VerticalAlignment = VerticalAlignment.Top;
                Projector.Border4.VerticalAlignment = VerticalAlignment.Top;
                Projector.TextBlock1.VerticalAlignment = VerticalAlignment.Top;
                Projector.TextBlock2.VerticalAlignment = VerticalAlignment.Top;
                Projector.TextBlock3.VerticalAlignment = VerticalAlignment.Top;
                Projector.TextBlock4.VerticalAlignment = VerticalAlignment.Top;
            }
            else if (VAlig == 1)
            {
                Projector.Border1.VerticalAlignment = VerticalAlignment.Stretch;
                Projector.Border2.VerticalAlignment = VerticalAlignment.Stretch;
                Projector.Border3.VerticalAlignment = VerticalAlignment.Stretch;
                Projector.Border4.VerticalAlignment = VerticalAlignment.Stretch;
                Projector.TextBlock1.VerticalAlignment = VerticalAlignment.Center;
                Projector.TextBlock2.VerticalAlignment = VerticalAlignment.Center;
                Projector.TextBlock3.VerticalAlignment = VerticalAlignment.Center;
                Projector.TextBlock4.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (VAlig == 2)
            {
                Projector.Border1.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.Border2.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.Border3.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.Border4.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.TextBlock1.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.TextBlock2.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.TextBlock3.VerticalAlignment = VerticalAlignment.Bottom;
                Projector.TextBlock4.VerticalAlignment = VerticalAlignment.Bottom;
            }


            if (!string.IsNullOrEmpty(FontColor))
            {
                SolidColorBrush br = System.Windows.Media.Brushes.White;
                Projector.SetShadowEffect(true);
                Projector.TextBlock2.Visibility = Visibility.Visible;
                Projector.TextBlock3.Visibility = Visibility.Visible;
                Projector.TextBlock4.Visibility = Visibility.Visible;
                if (FontColor.ToUpper() == "BLACK")
                {
                    br = System.Windows.Media.Brushes.Black;
                    Projector.SetShadowEffect(false);
                    Projector.TextBlock2.Visibility = Visibility.Hidden;
                    Projector.TextBlock3.Visibility = Visibility.Hidden;
                    Projector.TextBlock4.Visibility = Visibility.Hidden;
                }
                else if (FontColor.ToUpper() == "WHITE")
                {
                    br = System.Windows.Media.Brushes.White;
                }
                else if (FontColor.ToUpper() == "RED")
                    br = System.Windows.Media.Brushes.Red;
                else if (FontColor.ToUpper() == "BLUE")
                    br = System.Windows.Media.Brushes.Blue;
                else if (FontColor.ToUpper() == "YELLOW")
                    br = System.Windows.Media.Brushes.Yellow;
                else if (FontColor.ToUpper() == "CYAN")
                    br = System.Windows.Media.Brushes.Cyan;
                else if (FontColor.ToUpper() == "CORAL")
                    br = System.Windows.Media.Brushes.Coral;
                else
                {
                    try
                    {
                        br = new System.Windows.Media.SolidColorBrush(
                                               (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(FontColor));
                    }
                    catch (Exception)
                    {


                    }
                }
                   
                Projector.TextBlock1.Foreground = br;
                Projector.TextBlock2.Foreground = br;
                Projector.TextBlock3.Foreground = br;
                Projector.TextBlock4.Foreground = br;
            }

            Projector.TextCanvas.Opacity = this.Opacity / 100;
            //Projector.Text.Opacity = 0;
            Projector.TextVisible = true;
            
            

            
            if (Animated)
            {
                Blocked = true;
                rest_text = string.Join(Environment.NewLine, TextList.ToArray());
                /*                string txt = string.Join(Environment.NewLine, TextList.ToArray());
                                int letters = txt.Count();
                                var ts = TimeSpan.FromSeconds(letters * 0.05);
                                TypewriteTextblock(txt, Projector.TextBlock1, ts, 0);
                                TypewriteTextblock(txt, Projector.TextBlock2, ts, 1);
                                TypewriteTextblock(txt, Projector.TextBlock3, ts, 2);
                                TypewriteTextblock(txt, Projector.TextBlock4, ts, 3);
                */
            }
            else
            {
                ShowText();
            }
            

            timer.Change(100, 100);
            timer2.Change(LetterPause, LetterPause);
            return this.Owner;
        }

        internal void SetData(seTe data)
        {
            if (string.IsNullOrEmpty(data.Text)) return;
            TextList.AddRange(data.Text.Split('~').ToList());
            //this.BackColor = data.BackColor;
            this.FontName = data.FontName;
            this.FontSize = data.FontSize;
            this.FontColor = data.FontColor;
            this.FontStyle = data.FontStyle;
            this.Size = data.Size;
            this.Shift = data.Shift;
            this.Bottom = data.Bottom;
            //this.Animated = (data.Animated == 1);
            this.Width = data.Width;
            this.ClearBack = data.ClearBack;
            this.AutoShow = data.AutoShow;
            //this.Rtf = data.Rtf;
            this.HAlig = data.Align;
            this.VAlig = data.VAlign;
            this.Opacity = data.Opacity;
            this.Transition = data.T;

        }

        private static Storyboard[] storylist = new Storyboard[4];
        private void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan, int i)
        {

            Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.Stop;
            //story.RepeatBehavior = RepeatBehavior.Forever;
            story.RepeatBehavior = new RepeatBehavior(1); 
            story.Completed -= Story_Completed;
            story.Completed += Story_Completed;
            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;//KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 5)); //KeyTime.Paced;// 
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);
            story.Begin(txt);
            storylist[i] = story;
        }


        private void Story_Completed(object sender, EventArgs e)
        {
            Blocked = false;
        }

        public bool AutoShow { get; set; }
        public override void SetVisible(bool show)
        {            
                Projector.TextVisible = show;
        }
      
        public bool Html { get; set; }
        public bool Rtf { get; set; }
        public override void BeforeLeave()
        {

            base.Stopped = true;
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer2.Change(Timeout.Infinite, Timeout.Infinite);
            rest_text = string.Empty;
            show_text = string.Empty;
            FrameText.tranManager.Clear();
        }
        public static void ShowText() 
        {
            rest_text = string.Empty;
            show_text = string.Empty;
            string txt = string.Join(Environment.NewLine, TextList.ToArray());
            Projector.TextBlock1.Text = txt;
            Projector.TextBlock2.Text = txt;
            Projector.TextBlock3.Text = txt;
            Projector.TextBlock4.Text = txt;
            Blocked = false;
        }
    }
 
}
