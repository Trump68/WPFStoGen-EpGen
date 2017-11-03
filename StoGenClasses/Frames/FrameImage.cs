﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace StoGen.Classes
{

    public delegate void RunNext();
    public class FrameImage : Frame, IDisposable
    {
        public static System.Threading.Timer timer;
        public static TransitionManager tranManager = new TransitionManager();
        public static ProcedureBase CurrentProc;
        public static FrameImage Instance;
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
            if (FrameImage.tranManager.Process())
            {
                // repaint
                //Instance.RecreateAndRefreshImage(pi.Props);                
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


        public List<PictureItem> Pics { get; set; }
        public bool AutoShift { get; set; }

        public FrameImage()
            : base()
        {
            this.Pics = new List<PictureItem>();
            this.AutoShift = false;
            if (timer == null) timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, TimerPeriod, TimerPeriod);
            Instance = this;
        }


        private void RecreateImage(int index)
        {
            var it = Projector.PicContainer.PicList[index];
            Projector.PicContainer.OwnerCanvas.Children.Remove(it);
            Projector.PicContainer.PicList.RemoveAt(index);
            Image im = new Image();
            im.Name = $"Picture{index}";
            im.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            im.VerticalAlignment = VerticalAlignment.Top;
            im.Width = 0;
            im.Height = 0;
            im.ClipToBounds = false;
            im.Margin = new Thickness(0, 0, 0, 0);

            Projector.PicContainer.OwnerCanvas.Children.Insert(index, im);
            Projector.PicContainer.PicList.Insert(index, im);
        }
        public override Cadre Repaint()
        {
            for (int i = 0; i < 15; i++)
            {
                RecreateImage(i);
            }

            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Projector.NumberText.Text = $"{this.Owner.Owner.Cadres.IndexOf(this.Owner) + 1}/{this.Owner.Owner.Cadres.Count}";
            Projector.Owner.Background = new SolidColorBrush(Colors.Black);

            FrameImage.LoopProcessed = false;
            FrameImage.CurrentProc = this.Proc;
            FrameImage.NextCadre = 0;

            bool isPrevious = false;
            if (Pics[0].Props.FileName == "SKIP") return this.Owner;
            FrameImage.tranManager.Clear();
            if (Pics[0].Props.FileName == "PREVIOUS")
            {
                Pics.RemoveAt(0);
                isPrevious = true;
                int indexEmpty = Projector.PicContainer.PicList.IndexOf(Projector.PicContainer.PicList.First(x => x.Tag == null));
                Pics.ForEach(x => x.Props.Level = (PicLevel)(indexEmpty++));
            }
            else
            {
                foreach (System.Windows.Controls.Image item in Projector.PicContainer.PicList)
                {
                    item.Tag = null;
                }
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

                if (pi.Props.FileName.EndsWith("WHITE"))
                {
                    Projector.Owner.Background = new SolidColorBrush(Colors.White);
                    continue;
                }
                if (Projector.PicContainer.PicList[(int)pi.Props.Level].Tag != null
                    &&
                    ((PictureSourceProps)Projector.PicContainer.PicList[(int)pi.Props.Level].Tag).FileName == fn
                    && !pi.Props.Reload)
                {
                    Projector.PicContainer.PicList[(int)pi.Props.Level].Tag = pi.Props;
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

                #region Video
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

                    Projector.PicContainer.Clip.IsMuted = Pics[i].Props.Mute;
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

                    Projector.PicContainer.Clip.Margin = new System.Windows.Thickness(Pics[i].Props.X + 0, Pics[i].Props.Y + 0, 0, 0);
                    runClip = true;
                    //FrameImage.debugcount++;
                    if (Pics[i].Props.PP1 > 0) PausePeriod1 = Pics[i].Props.PP1;
                    else PausePeriod1 = 40;
                    if (Pics[i].Props.PP2 > 0) PausePeriod2 = Pics[i].Props.PP2;
                    else PausePeriod2 = 40;
                    continue;
                }
                #endregion


                BitmapImage imageSource = new BitmapImage(new Uri(fn));
                Projector.PicContainer.PicList[(int)pi.Props.Level].Source = imageSource;

                #region Opacity
                // Opacity
                if (pi.Props.Opacity > -1) Projector.PicContainer.PicList[(int)pi.Props.Level].Opacity = (pi.Props.Opacity / 100.0);

                #endregion

                #region Blur

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
                #endregion

                #region Transition
                // Transition
                if (!string.IsNullOrEmpty(pi.Props.Transition))
                {
                    TransitionData trandata = new TransitionData();
                    trandata.Level = (int)pi.Props.Level;
                    trandata.Parse(pi.Props.Transition, 0);
                    FrameImage.tranManager.Add(trandata);
                }

                #endregion

                #region Size
                DoResize(pi.Props, imageSource.PixelWidth, imageSource.PixelHeight);
                #endregion

                #region Clip
                // Clip
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
                #endregion

                Projector.PicContainer.PicList[(int)pi.Props.Level].Tag = pi.Props;
            }



            if (CadreShifted < 0) CadreShifted = this.Pics.Count - 1;
            for (int j = 0; j < Projector.PicContainer.PicList.Count; j++)
            {
                if (Projector.PicContainer.PicList[j].Tag == null)
                    Projector.PicContainer.PicList[j].Visibility = Visibility.Hidden;
            }

            DoTransformAll();
            if (!runClip)
                timer.Change(TimerPeriod, TimerPeriod);
            FrameImage.TimeStarted = DateTime.Now;

            return this.Owner;

        }
        private void DoResize(PictureSourceProps pi, int imW, int imH)
        {
            if (pi.SizeX == -1 || pi.SizeY == -1)
            {
                if (pi.SizeX == -1) pi.SizeX = imW;
                if (pi.SizeY == -1) pi.SizeY = imH;
                Projector.PicContainer.PicList[(int)pi.Level].Stretch = Stretch.Uniform;
            }
            else if (pi.SizeX == -2 || pi.SizeY == -2)
            {
                pi.SizeX = 1600;
                pi.SizeY = 900;
                Projector.PicContainer.PicList[(int)pi.Level].Stretch = Stretch.Uniform;
            }
            else
            {
                if (pi.SizeMode == PictureSizeMode.Clip)
                    Projector.PicContainer.PicList[(int)pi.Level].Stretch = Stretch.Fill;
            }
            Projector.PicContainer.PicList[(int)pi.Level].Width = pi.SizeX;
            Projector.PicContainer.PicList[(int)pi.Level].ClipToBounds = false;
            Projector.PicContainer.PicList[(int)pi.Level].Height = pi.SizeY;
        }
        private void RefreshImage(PictureSourceProps sourceProps)
        {
            var current = Projector.PicContainer.PicList[(int)sourceProps.Level];
            TransformGroup tg = current.RenderTransform as TransformGroup;
            if (tg == null)
                tg = new TransformGroup();

            #region Move

            DoLocation(sourceProps, tg);

            #endregion

            #region Rotate
            DoRotateFlip(sourceProps, tg);
            #endregion

            #region Parent rotation
            if (!string.IsNullOrEmpty(sourceProps.ParRot))
            {
                string[] vals = sourceProps.ParRot.Split(',');

                foreach (var item in vals)
                {
                    string[] vals2 = item.Split('@');
                    string parname = vals2[0];
                    int parvalue = Convert.ToInt32(vals2[1]);
                    var parent = Pics.Where(x => x.Props.Name == parname).FirstOrDefault();
                    if (parent != null)
                    {
                        var ctrl = Projector.PicContainer.PicList[(int)parent.Props.Level];
                        var controlCenter = new System.Windows.Point(
                               (ctrl.Width / 2) + parent.Props.X,
                               (ctrl.Height / 2) + parent.Props.Y);

                        var sss = ctrl.PointToScreen(controlCenter);

                        var childControlCenter = current.PointFromScreen(sss);
                        var rTransform = new RotateTransform();
                        rTransform.Angle = parvalue;
                        rTransform.CenterX = childControlCenter.X;
                        rTransform.CenterY = childControlCenter.Y;
                        tg.Children.Add(rTransform);
                    }
                }
                //sourceProps.ParRot = null;
            }
            #endregion

            #region Parent flip
            if (!string.IsNullOrEmpty(sourceProps.ParFlip))
            {
                string[] vals = sourceProps.ParFlip.Split(',');
                foreach (var item in vals)
                {
                    string parname = item;
                    var parent = Pics.Where(x => x.Props.Name == parname).FirstOrDefault();
                    if (parent != null)
                    {
                        var ctrl = Projector.PicContainer.PicList[(int)parent.Props.Level];
                        var controlCenter = new System.Windows.Point(
                               (ctrl.Width / 2) + parent.Props.X,
                               (ctrl.Height / 2) + parent.Props.Y);
                        var sss = ctrl.PointToScreen(controlCenter);

                        var childControlCenter = current.PointFromScreen(sss);

                        ScaleTransform flipTrans = new ScaleTransform();
                        flipTrans.CenterX = childControlCenter.X;
                        flipTrans.CenterY = childControlCenter.Y;
                        flipTrans.ScaleX = -1;
                        tg.Children.Add(flipTrans);
                    }
                }
                sourceProps.ParFlip = null;
            }
            #endregion

            current.RenderTransform = tg;
        }
        private void RecreateAndRefreshImage(PictureSourceProps sourceProps)
        {
            RecreateImage((int)sourceProps.Level);
            BitmapImage imageSource = new BitmapImage(new Uri(sourceProps.FileName));
            Projector.PicContainer.PicList[(int)sourceProps.Level].Source = imageSource;
            DoResize(sourceProps, imageSource.PixelWidth, imageSource.PixelHeight);
            RefreshImage(sourceProps);
        }
        private void DoRotateFlip(PictureSourceProps pi, TransformGroup tg)
        {
            var current = Projector.PicContainer.PicList[(int)pi.Level];
            var controlCenter = new System.Windows.Point(current.Width / 2, current.Height / 2);
            if (pi.Rotate != 0)
            {
                var roateTransform = new RotateTransform();
                roateTransform.Angle = pi.Rotate;
                roateTransform.CenterX = controlCenter.X + pi.X;
                roateTransform.CenterY = controlCenter.Y + pi.Y;
                tg.Children.Add(roateTransform);
            }
            if ((int)pi.Flip > 0)
            {

                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.CenterX = controlCenter.X + pi.X;
                flipTrans.CenterY = controlCenter.Y + pi.Y;
                if ((int)pi.Flip == 1)
                {
                    flipTrans.ScaleX = -1;
                }
                else if ((int)pi.Flip == 2)
                {
                    flipTrans.ScaleY = -1;
                }
                tg.Children.Add(flipTrans);
            }
        }
        private void DoLocation(PictureSourceProps pi, TransformGroup tg)
        {
            //if (pi.ParRot != null) return;
            #region Location
            // Location
            //Canvas.SetLeft(
            //    Projector.PicContainer.PicList[(int)pi.Level],
            //    pi.X);
            //Canvas.SetTop(
            //    Projector.PicContainer.PicList[(int)pi.Level],
            //    pi.Y);
            //Projector.PicContainer.PicList[(int)pi.Level].Margin =
            //    new System.Windows.Thickness(pi.X, pi.Y, 0, 0);


            TranslateTransform tt = new TranslateTransform();
            tt.X = pi.X;
            tt.Y = pi.Y;
            tg.Children.Add(tt);

            #endregion
        }
        private void DoTransformAll()
        {
            for (int j = 0; j < Projector.PicContainer.PicList.Count; j++)
            {
                var current = Projector.PicContainer.PicList[j];
                if (current.Tag != null)
                {
                    PictureSourceProps sourceProps = current.Tag as PictureSourceProps;
                    RefreshImage(sourceProps);
                }
            }
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

            timer.Change(Timeout.Infinite, Timeout.Infinite);

            Projector.PicContainer.Clip.Visibility = System.Windows.Visibility.Hidden;

        }
        public override void BeforeLeave()
        {
            FrameImage.tranManager.Clear();

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
            int step = 40;
            double stepZoom = 0.2;
            if (!Projector.EditorMode)
            {
                if (e == Key.Right)
                {
                    foreach (var item in this.Pics)
                    {
                        item.Props.X = item.Props.X + step;
                    }
                }
                else if (e == Key.Left)
                {
                    foreach (var item in this.Pics)
                    {
                        item.Props.X = item.Props.X - step;
                    }
                }
                else if (e == Key.Up)
                {
                    foreach (var item in this.Pics)
                    {
                        item.Props.Y = item.Props.Y - step;
                    }
                }
                else if (e == Key.Down)
                {
                    foreach (var item in this.Pics)
                    {
                        item.Props.Y = item.Props.Y + step;
                    }
                }
                else if (e == Key.OemPlus)
                {
                    Projector.PicContainer.OwnerViewbox.Width =
                    Projector.PicContainer.OwnerViewbox.Height =
                    (int)(Projector.PicContainer.OwnerViewbox.Height * (1 + stepZoom));

                }
                else if (e == Key.OemMinus)
                {
                    Projector.PicContainer.OwnerViewbox.Width =
                    Projector.PicContainer.OwnerViewbox.Height =
                    (int)(Projector.PicContainer.OwnerViewbox.Height / (1 + stepZoom));
                }
                this.Repaint();
                return;
            }
            bool increase = false;
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (e == Key.OemPlus)
                {
                    Projector.ImageCadre.PropStep = Projector.ImageCadre.PropStep + 1;
                    return;
                }
                if (e == Key.OemMinus)
                {
                    if (Projector.ImageCadre.PropStep > 0)
                        Projector.ImageCadre.PropStep = Projector.ImageCadre.PropStep - 1;
                    return;
                }
            }

            if (e == Key.D0)
            {
                Projector.ImageCadre.LayerIndex = 0;
            }
            else if (e == Key.D1)
            {
                Projector.ImageCadre.LayerIndex = 1;
            }
            else if (e == Key.D2)
            {
                Projector.ImageCadre.LayerIndex = 2;
            }
            else if (e == Key.D3)
            {
                Projector.ImageCadre.LayerIndex = 3;
            }
            else if (e == Key.D4)
            {
                Projector.ImageCadre.LayerIndex = 4;
            }
            else if (e == Key.D5)
            {
                Projector.ImageCadre.LayerIndex = 5;
            }
            else if (e == Key.D6)
            {
                Projector.ImageCadre.LayerIndex = 6;
            }
            else if (e == Key.D7)
            {
                Projector.ImageCadre.LayerIndex = 7;
            }
            else if (e == Key.D8)
            {
                Projector.ImageCadre.LayerIndex = 8;
            }
            else if (e == Key.D9)
            {
                Projector.ImageCadre.LayerIndex = 9;
            }
            else if (e == Key.NumPad6 || e == Key.Right)
            {
                Projector.ImageCadre.PropIndex = 1;
                increase = true;
            }
            else if (e == Key.NumPad4 || e == Key.Left)
            {
                Projector.ImageCadre.PropIndex = 1;
                increase = false;
            }
            else if (e == Key.NumPad2 || e == Key.Down)
            {
                Projector.ImageCadre.PropIndex = 2;
                increase = true;
            }
            else if (e == Key.NumPad8 || e == Key.Up)
            {
                Projector.ImageCadre.PropIndex = 2;
                increase = false;
            }
            else if (e == Key.NumPad7 || e == Key.OemPlus)
            {
                Projector.ImageCadre.PropIndex = 3;
                increase = true;
            }
            else if (e == Key.NumPad9 || e == Key.OemMinus)
            {
                Projector.ImageCadre.PropIndex = 3;
                increase = false;
            }
            else if (e == Key.NumPad1 || e == Key.OemComma)
            {
                Projector.ImageCadre.PropIndex = 4;
                increase = true;
            }
            else if (e == Key.NumPad3 || e == Key.OemPeriod)
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

            if (Projector.ImageCadre.PropIndex == 1) //location
            {
                if (increase)
                    pi.Props.X += Projector.ImageCadre.PropStep;
                else
                    pi.Props.X -= Projector.ImageCadre.PropStep;
                RecreateAndRefreshImage(pi.Props);
            }
            else if (Projector.ImageCadre.PropIndex == 2)
            {
                if (increase)
                    pi.Props.Y += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Y -= Projector.ImageCadre.PropStep;
                RecreateAndRefreshImage(pi.Props);
            }
            else if (Projector.ImageCadre.PropIndex == 3) //size
            {
                if (increase)
                    pi.Props.SizeX += Projector.ImageCadre.PropStep;
                else
                    pi.Props.SizeX -= Projector.ImageCadre.PropStep;
                pi.Props.SizeY = pi.Props.SizeX;
                RecreateAndRefreshImage(pi.Props);
            }
            else if (Projector.ImageCadre.PropIndex == 4)
            {
                if (increase)
                    pi.Props.Rotate += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Rotate -= Projector.ImageCadre.PropStep;
                RecreateAndRefreshImage(pi.Props);
            }
            else if (Projector.ImageCadre.PropIndex == 5) //size
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
            else if (Projector.ImageCadre.PropIndex == 7) //clip
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
                RecreateAndRefreshImage(pi.Props);
                //Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
            }
            else
            {
                //Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = null;
            }
            List<string> rez = new List<string>();
            if (pi.Props.ClipX != 0) rez.Add($"ClipX = {pi.Props.ClipX}");
            if (pi.Props.ClipW != 0) rez.Add($"ClipW = {pi.Props.ClipW}");
            if (pi.Props.ClipY != 0) rez.Add($"ClipY = {pi.Props.ClipY}");
            if (pi.Props.ClipH != 0) rez.Add($"ClipH = {pi.Props.ClipH}");
            {// Position
                if (pi.Props.X != 0) rez.Add($"X = {pi.Props.X}");
                if (pi.Props.Y != 0) rez.Add($"Y = {pi.Props.Y}");
            }
            rez.Add($"S = {Math.Max(pi.Props.SizeX, pi.Props.SizeY)}");
            if (pi.Props.Rotate != 0) rez.Add($"R = {pi.Props.Rotate}");
            rez.Add($"F = {(int)pi.Props.Flip}");
            Projector.ImageCadre.ResultString = string.Join(", ", rez.ToArray());
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

}
