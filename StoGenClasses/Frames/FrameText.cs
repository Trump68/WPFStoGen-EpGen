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
using System.Windows.Media.Effects;

namespace StoGen.Classes
{

    public class FrameText : Frame
    {
        private seTe textdata1;
        private seTe textdata2;
        private seTe textdata3;
        private seTe textdata4;

        public static bool Blocked = false;
        //public static List<string> TextList { get; set; }
        /*
        public string Text
        {
            set
            {
                TextList.Clear();
                TextList.Add(value);
            }
        }
        */
        //public string FontName { get; set; }
        //public int FontSize { get; set; }
        //public int FontStyle { get; set; }
        //public string FontColor { get; set; }
        //public Color BackColor { get; set; }
        //public int Size { get; set; }
        //public int Width { get; set; }
        //public int Bottom { get; set; }
        //public string Transition { get; set; }
        //public int Opacity { get; set; }
        //public int Shift { get; set; }
        //public int HAlig { get; set; }
        //public int VAlig { get; set; }
        public static bool Animated { get; set; } = true;
        public bool ClearBack { get; set; } = false;
        public System.Threading.Timer timer;
        public System.Threading.Timer timer2;
        public static TransitionManager tranManager = new TransitionManager();
        public static int LetterPause = 5;


        public FrameText() : base()
        {
            //TextList = new List<string>();
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

            RunNext op1 = new RunNext(ProcessLoopDelegate2);

            Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);
            if (!base.Stopped)
                if (timer2 != null) timer2.Change(LetterPause, LetterPause);
        }
        public static void ProcessLoopDelegate()
        {
            //Transition
            FrameText.tranManager.Process();
        }

        public static string rest_text1 = string.Empty;
        public static string show_text1 = string.Empty;
        public static string rest_text2 = string.Empty;
        public static string show_text2 = string.Empty;
        public static string rest_text3 = string.Empty;
        public static string show_text3 = string.Empty;
        public static string rest_text4 = string.Empty;
        public static string show_text4 = string.Empty;
        public void ProcessLoopDelegate2()
        {
            if (!string.IsNullOrEmpty(rest_text1)) 
            {
                show_text1 = show_text1 + rest_text1[0];
                rest_text1 = rest_text1.Remove(0,1);
                Projector.TextBlock1.Text = show_text1;
                Projector.TextBlock2.Text = show_text1;
                Projector.TextBlock3.Text = show_text1;
                Projector.TextBlock4.Text = show_text1;
                if (string.IsNullOrEmpty(rest_text1)) 
                {
                    show_text1 = string.Empty;
                }
            }
            if (!string.IsNullOrEmpty(rest_text2))
            {
                show_text2 = show_text2 + rest_text2[0];
                rest_text2 = rest_text2.Remove(0, 1);
                Projector.TextBlock21.Text = show_text2;
                Projector.TextBlock22.Text = show_text2;
                Projector.TextBlock23.Text = show_text2;
                Projector.TextBlock24.Text = show_text2;

                if (string.IsNullOrEmpty(rest_text2))
                {
                    show_text2 = string.Empty;                   
                }
            }
            if (!string.IsNullOrEmpty(rest_text3))
            {
                show_text3 = show_text3 + rest_text3[0];
                rest_text3 = rest_text3.Remove(0, 1);
                Projector.TextBlock31.Text = show_text3;
                Projector.TextBlock32.Text = show_text3;
                Projector.TextBlock33.Text = show_text3;
                Projector.TextBlock34.Text = show_text3;

                if (string.IsNullOrEmpty(rest_text3))
                {
                    show_text3 = string.Empty;
                }
            }
            if (!string.IsNullOrEmpty(rest_text4))
            {
                show_text4 = show_text4 + rest_text4[0];
                rest_text4 = rest_text4.Remove(0, 1);
                Projector.TextBlock41.Text = show_text4;
                Projector.TextBlock42.Text = show_text4;
                Projector.TextBlock43.Text = show_text4;
                Projector.TextBlock44.Text = show_text4;

                if (string.IsNullOrEmpty(rest_text4))
                {
                    show_text4 = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(rest_text1) && string.IsNullOrEmpty(rest_text2) && string.IsNullOrEmpty(rest_text3) && string.IsNullOrEmpty(rest_text4))
                Blocked = false;
        }

        private void SetTextData(int index, seTe data, Canvas canvas, Border brd1, Border brd2, Border brd3, Border brd4,
            TextBlock tb1, TextBlock tb2, TextBlock tb3, TextBlock tb4,
            DropShadowEffect dse1, DropShadowEffect dse2, DropShadowEffect dse3, DropShadowEffect dse4) 
        {
            if (data != null)
            {
                if (data.Size > 0)
                {
                    tb1.TextWrapping = TextWrapping.Wrap;
                    tb2.TextWrapping = TextWrapping.Wrap;
                    tb3.TextWrapping = TextWrapping.Wrap;
                    tb4.TextWrapping = TextWrapping.Wrap;

                    
                    canvas.Height = data.Size;
                    brd1.Height = data.Size;
                    brd2.Height = data.Size;
                    brd3.Height = data.Size;
                    brd4.Height = data.Size;

                    if (data.Width > 0) canvas.Width = data.Width;
                    else canvas.Width = 800;

                    brd1.Width = canvas.Width;
                    brd2.Width = canvas.Width;
                    brd3.Width = canvas.Width;
                    brd4.Width = canvas.Width;

                    double bm = data.Bottom;
                    double tm = canvas.Margin.Top;
                    canvas.Margin = new System.Windows.Thickness(data.Shift, tm, canvas.Margin.Right, bm);
                    
                }
                if (!string.IsNullOrEmpty(data.T))
                {
                    TransitionData trandata = new TransitionData();
                    trandata.Level = index;
                    trandata.Parse(data.T, 2);
                    FrameText.tranManager.Add(trandata);
                }

                if (!string.IsNullOrWhiteSpace(data.FontName))
                {
                    FontFamily font = new FontFamily(data.FontName);                    
                    tb1.FontFamily = font;
                    tb2.FontFamily = font;
                    tb3.FontFamily = font;
                    tb4.FontFamily = font;
                }
                if (data.FontSize > 0)
                {
                    tb1.FontSize = data.FontSize;
                    tb2.FontSize = data.FontSize;
                    tb3.FontSize = data.FontSize;
                    tb4.FontSize = data.FontSize;
                }
                if (data.FontStyle == 0)
                {
                    tb1.FontStyle = FontStyles.Normal;
                    tb2.FontStyle = FontStyles.Normal;
                    tb3.FontStyle = FontStyles.Normal;
                    tb4.FontStyle = FontStyles.Normal;
                    tb1.FontWeight = FontWeights.Normal;
                    tb2.FontWeight = FontWeights.Normal;
                    tb3.FontWeight = FontWeights.Normal;
                    tb4.FontWeight = FontWeights.Normal;
                }
                else if (data.FontStyle == 1)
                {
                    tb1.FontStyle = FontStyles.Italic;
                    tb2.FontStyle = FontStyles.Italic;
                    tb3.FontStyle = FontStyles.Italic;
                    tb4.FontStyle = FontStyles.Italic;
                    tb1.FontWeight = FontWeights.Normal;
                    tb2.FontWeight = FontWeights.Normal;
                    tb3.FontWeight = FontWeights.Normal;
                    tb4.FontWeight = FontWeights.Normal;
                }
                else if (data.FontStyle == 2)
                {
                    tb1.FontStyle = FontStyles.Normal;
                    tb2.FontStyle = FontStyles.Normal;
                    tb3.FontStyle = FontStyles.Normal;
                    tb4.FontStyle = FontStyles.Normal;
                    tb1.FontWeight = FontWeights.Bold;
                    tb2.FontWeight = FontWeights.Bold;
                    tb3.FontWeight = FontWeights.Bold;
                    tb4.FontWeight = FontWeights.Bold;
                }
                else if (data.FontStyle == 3)
                {
                    tb1.FontStyle = FontStyles.Italic;
                    tb2.FontStyle = FontStyles.Italic;
                    tb3.FontStyle = FontStyles.Italic;
                    tb4.FontStyle = FontStyles.Italic;
                    tb1.FontWeight = FontWeights.Bold;
                    tb2.FontWeight = FontWeights.Bold;
                    tb3.FontWeight = FontWeights.Bold;
                    tb4.FontWeight = FontWeights.Bold;
                }

                if (data.Align == 1)
                {
                    tb1.TextAlignment = System.Windows.TextAlignment.Right;
                    tb2.TextAlignment = System.Windows.TextAlignment.Right;
                    tb3.TextAlignment = System.Windows.TextAlignment.Right;
                    tb4.TextAlignment = System.Windows.TextAlignment.Right;
                }
                else if (data.Align == 0)
                {
                    tb1.TextAlignment = System.Windows.TextAlignment.Left;
                    tb2.TextAlignment = System.Windows.TextAlignment.Left;
                    tb3.TextAlignment = System.Windows.TextAlignment.Left;
                    tb4.TextAlignment = System.Windows.TextAlignment.Left;
                }
                else if (data.Align == 2)
                {
                    tb1.TextAlignment = System.Windows.TextAlignment.Center;
                    tb2.TextAlignment = System.Windows.TextAlignment.Center;
                    tb3.TextAlignment = System.Windows.TextAlignment.Center;
                    tb4.TextAlignment = System.Windows.TextAlignment.Center;
                }
                else if (data.Align == 3)
                {
                    tb1.TextAlignment = System.Windows.TextAlignment.Justify;
                    tb2.TextAlignment = System.Windows.TextAlignment.Justify;
                    tb3.TextAlignment = System.Windows.TextAlignment.Justify;
                    tb4.TextAlignment = System.Windows.TextAlignment.Justify;
                }

                if (data.VAlign == 0)
                {
                    brd1.VerticalAlignment = VerticalAlignment.Top;
                    brd2.VerticalAlignment = VerticalAlignment.Top;
                    brd3.VerticalAlignment = VerticalAlignment.Top;
                    brd4.VerticalAlignment = VerticalAlignment.Top;
                    tb1.VerticalAlignment = VerticalAlignment.Top;
                    tb2.VerticalAlignment = VerticalAlignment.Top;
                    tb3.VerticalAlignment = VerticalAlignment.Top;
                    tb4.VerticalAlignment = VerticalAlignment.Top;
                }
                else if (data.VAlign == 1)
                {
                    brd1.VerticalAlignment = VerticalAlignment.Stretch;
                    brd2.VerticalAlignment = VerticalAlignment.Stretch;
                    brd3.VerticalAlignment = VerticalAlignment.Stretch;
                    brd4.VerticalAlignment = VerticalAlignment.Stretch;
                    tb1.VerticalAlignment = VerticalAlignment.Center;
                    tb2.VerticalAlignment = VerticalAlignment.Center;
                    tb3.VerticalAlignment = VerticalAlignment.Center;
                    tb4.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (data.VAlign == 2)
                {
                    brd1.VerticalAlignment = VerticalAlignment.Bottom;
                    brd2.VerticalAlignment = VerticalAlignment.Bottom;
                    brd3.VerticalAlignment = VerticalAlignment.Bottom;
                    brd4.VerticalAlignment = VerticalAlignment.Bottom;
                    tb1.VerticalAlignment = VerticalAlignment.Bottom;
                    tb2.VerticalAlignment = VerticalAlignment.Bottom;
                    tb3.VerticalAlignment = VerticalAlignment.Bottom;
                    tb4.VerticalAlignment = VerticalAlignment.Bottom;
                }


                if (!string.IsNullOrEmpty(data.FontColor))
                {
                    SolidColorBrush br = System.Windows.Media.Brushes.White;
                    Projector.SetShadowEffect(true, dse1, dse2, dse3, dse4);
                    tb2.Visibility = Visibility.Visible;
                    tb3.Visibility = Visibility.Visible;
                    tb4.Visibility = Visibility.Visible;
                    if (data.FontColor.ToUpper() == "BLACK")
                    {
                        br = System.Windows.Media.Brushes.Black;
                        Projector.SetShadowEffect(false, dse1, dse2, dse3, dse4);
                        tb2.Visibility = Visibility.Hidden;
                        tb3.Visibility = Visibility.Hidden;
                        tb4.Visibility = Visibility.Hidden;
                    }
                    else if (data.FontColor.ToUpper() == "WHITE")
                    {
                        br = System.Windows.Media.Brushes.White;
                    }
                    else if (data.FontColor.ToUpper() == "RED")
                        br = System.Windows.Media.Brushes.Red;
                    else if (data.FontColor.ToUpper() == "BLUE")
                        br = System.Windows.Media.Brushes.Blue;
                    else if (data.FontColor.ToUpper() == "YELLOW")
                        br = System.Windows.Media.Brushes.Yellow;
                    else if (data.FontColor.ToUpper() == "CYAN")
                        br = System.Windows.Media.Brushes.Cyan;
                    else if (data.FontColor.ToUpper() == "CORAL")
                        br = System.Windows.Media.Brushes.Coral;
                    else
                    {
                        try
                        {
                            br = new System.Windows.Media.SolidColorBrush(
                                                   (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(data.FontColor));
                        }
                        catch (Exception)
                        {


                        }
                    }

                    tb1.Foreground = br;
                    tb2.Foreground = br;
                    tb3.Foreground = br;
                    tb4.Foreground = br;
                }

                canvas.Opacity = data.Opacity / 100;
            }
        }
        public override Cadre Repaint()
        {

            base.Repaint();
            FrameText.tranManager.Clear();

            SetTextData(1, textdata1, Projector.TextCanvas, Projector.Border1, Projector.Border2, Projector.Border3, Projector.Border4,
                Projector.TextBlock1, Projector.TextBlock2, Projector.TextBlock3, Projector.TextBlock4,
                Projector.dropShadowEffect1, Projector.dropShadowEffect2, Projector.dropShadowEffect3, Projector.dropShadowEffect4);
            SetTextData(2, textdata2, Projector.TextCanvas2, Projector.Border21, Projector.Border22, Projector.Border23, Projector.Border24,
                Projector.TextBlock21, Projector.TextBlock22, Projector.TextBlock23, Projector.TextBlock24,
                Projector.dropShadowEffect21, Projector.dropShadowEffect22, Projector.dropShadowEffect23, Projector.dropShadowEffect24);
            SetTextData(3, textdata3, Projector.TextCanvas3, Projector.Border31, Projector.Border32, Projector.Border33, Projector.Border34,
                Projector.TextBlock31, Projector.TextBlock32, Projector.TextBlock33, Projector.TextBlock34,
                Projector.dropShadowEffect31, Projector.dropShadowEffect32, Projector.dropShadowEffect33, Projector.dropShadowEffect34);
            SetTextData(4, textdata4, Projector.TextCanvas4, Projector.Border41, Projector.Border42, Projector.Border43, Projector.Border44,
                Projector.TextBlock41, Projector.TextBlock42, Projector.TextBlock43, Projector.TextBlock44,
                Projector.dropShadowEffect41, Projector.dropShadowEffect42, Projector.dropShadowEffect43, Projector.dropShadowEffect44);

            Projector.TextVisible = true;
            
            

            
            if (Animated)
            {
                Blocked = true;
                if (textdata1 != null && textdata1.Text != null) 
                {
                    rest_text1 = string.Join(Environment.NewLine, textdata1.Text.Split('~'));
                }
                if (textdata2 != null && textdata2.Text != null)
                {
                    rest_text2 = string.Join(Environment.NewLine, textdata2.Text.Split('~'));
                }
                if (textdata3 != null && textdata3.Text != null)
                {
                    rest_text3 = string.Join(Environment.NewLine, textdata3.Text.Split('~'));
                }
                if (textdata4 != null && textdata4.Text != null)
                {
                    rest_text4 = string.Join(Environment.NewLine, textdata4.Text.Split('~'));
                }

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

        internal void SetData(List<seTe> data)
        {
            if (!data.Any()) return;            
            textdata1 = data[0];
            if (data.Count > 1) textdata2 = data[1];
            if (data.Count > 2) textdata3 = data[2];
            if (data.Count > 3) textdata4 = data[3];

            /*
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
            */
        }

        //private static Storyboard[] storylist = new Storyboard[4];
        /*
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
        */

        private void Story_Completed(object sender, EventArgs e)
        {
            Blocked = false;
        }

        public bool AutoShow { get; set; }
        public override void SetVisible(bool show)
        {            
                Projector.TextVisible = show;
        }
      
        //public bool Html { get; set; }
        //public bool Rtf { get; set; }
        public override void BeforeLeave()
        {

            base.Stopped = true;
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer2.Change(Timeout.Infinite, Timeout.Infinite);
            rest_text1 = string.Empty;
            show_text1 = string.Empty;
            rest_text2 = string.Empty;
            show_text2 = string.Empty;
            rest_text3 = string.Empty;
            show_text3 = string.Empty;
            rest_text4 = string.Empty;
            show_text4 = string.Empty;
            FrameText.tranManager.Clear();
        }
        public void ShowText() 
        {
            if (textdata1 != null)
            {
                rest_text1 = string.Empty;
                show_text1 = string.Empty;
                string txt1 = string.Join(Environment.NewLine, textdata1.Text.Split('~'));
                Projector.TextBlock1.Text = txt1;
                Projector.TextBlock2.Text = txt1;
                Projector.TextBlock3.Text = txt1;
                Projector.TextBlock4.Text = txt1;
            }
            if (textdata2 != null)
            {
                rest_text2 = string.Empty;
                show_text2 = string.Empty;
                string txt1 = string.Join(Environment.NewLine, textdata2.Text.Split('~'));
                Projector.TextBlock21.Text = txt1;
                Projector.TextBlock22.Text = txt1;
                Projector.TextBlock23.Text = txt1;
                Projector.TextBlock24.Text = txt1;
            }
            if (textdata3 != null)
            {
                rest_text3 = string.Empty;
                show_text3 = string.Empty;
                string txt1 = string.Join(Environment.NewLine, textdata3.Text.Split('~'));
                Projector.TextBlock31.Text = txt1;
                Projector.TextBlock32.Text = txt1;
                Projector.TextBlock33.Text = txt1;
                Projector.TextBlock34.Text = txt1;
            }
            if (textdata4 != null)
            {
                rest_text4 = string.Empty;
                show_text4 = string.Empty;
                string txt1 = string.Join(Environment.NewLine, textdata4.Text.Split('~'));
                Projector.TextBlock41.Text = txt1;
                Projector.TextBlock42.Text = txt1;
                Projector.TextBlock43.Text = txt1;
                Projector.TextBlock44.Text = txt1;
            }
            Blocked = false;
        }
    }
 
}
