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
            FrameImage.tranManager.Process();


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

        public List<PictureItem> Pics { get; set; }
        public bool AutoShift { get; set; }

        public FrameImage()
            : base()
        {
            this.Pics = new List<PictureItem>();

            this.AutoShift = false;
            if (timer == null) timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, TimerPeriod, TimerPeriod);
        }


        public override Cadre Repaint()
        {
            for (int i = 0; i < 15; i++)
            {
                var it = Projector.PicContainer.PicList[i];
                Projector.PicContainer.OwnerCanvas.Children.Remove(it);                
            }
            Projector.PicContainer.PicList.Clear();
            Image im;
            for (int i = 0; i < 15; i++)
            {

                im = new Image();
                im.Name = $"Picture{i}";
                im.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                im.VerticalAlignment = VerticalAlignment.Top;
                im.Width = 0;
                im.Height = 0;
                Projector.PicContainer.OwnerCanvas.Children.Add(im);
                Projector.PicContainer.PicList.Add(im);
            }

            for (int j = 1; j < Projector.PicContainer.PicList.Count; j++)
            {
                var current = Projector.PicContainer.PicList[j];
                current.Visibility = System.Windows.Visibility.Visible;                
                current.Height = 0;
                current.Width = 0;                                
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
                Projector.PicContainer.PicList[(int)pi.Props.Level].Width = pi.Props.SizeX;
                Projector.PicContainer.PicList[(int)pi.Props.Level].Height = pi.Props.SizeY;

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
                //Projector.PicContainer.PicList[j].SizeChanged += this.SizeChanged;
            }

            if (!runClip)
                timer.Change(TimerPeriod, TimerPeriod);
            FrameImage.TimeStarted = DateTime.Now;
            DoTransform(null);
            
            return this.Owner;

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
        private void DoTransform(string name)
        {            
            for (int j = 0; j < Projector.PicContainer.PicList.Count; j++)
            {
                var current = Projector.PicContainer.PicList[j];
               

                if (current.Tag != null)
                {
                    PictureSourceProps sourceProps = current.Tag as PictureSourceProps;

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

            }
           
        }
        private void SizeChanged(object sender, EventArgs e)
        {
            var s = (sender as System.Windows.Controls.Image).Tag as PictureSourceProps;
            if (s != null)
            {
                var name = s.Name;
                DoTransform(name);
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
            else if (e == Key.NumPad9)
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

            if (Projector.ImageCadre.PropIndex == 1) //location
            {
                if (increase)
                    pi.Props.X += Projector.ImageCadre.PropStep;
                else
                    pi.Props.X -= Projector.ImageCadre.PropStep;

                AdjustXY(pi);
            }
            else if (Projector.ImageCadre.PropIndex == 2)
            {
                if (increase)
                    pi.Props.Y += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Y -= Projector.ImageCadre.PropStep;

                AdjustXY(pi);
            }
            else if (Projector.ImageCadre.PropIndex == 3) //size
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
                TransformGroup transformGroup = Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform as TransformGroup;
                //Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform = null;
                if (transformGroup == null) transformGroup = new TransformGroup();

                transformGroup.Children.Clear();

                if (increase)
                    pi.Props.Rotate += Projector.ImageCadre.PropStep;
                else
                    pi.Props.Rotate -= Projector.ImageCadre.PropStep;
                var current = Projector.PicContainer.PicList[(int)pi.Props.Level];
                var controlCenter = new System.Windows.Point(current.Width / 2, current.Height / 2);

                //if (pi.Props.Rotate > 0)  //rotate
                {
                    var roateTransform = new RotateTransform(
                        pi.Props.Rotate,
                        controlCenter.X,
                       controlCenter.Y);
                    transformGroup.Children.Add(roateTransform);
                }

                if (pi.Props.Flip != 0)
                {
                    ScaleTransform flipTrans = new ScaleTransform();
                    flipTrans.CenterX = controlCenter.X;
                    flipTrans.CenterY = controlCenter.Y;
                    if ((int)pi.Props.Flip == 1)
                    {
                        flipTrans.ScaleX = -1;
                    }
                    else if ((int)pi.Props.Flip == 2)
                    {
                        flipTrans.ScaleY = -1;
                    }
                    transformGroup.Children.Add(flipTrans);
                }
                Projector.PicContainer.PicList[(int)pi.Props.Level].RenderTransform = transformGroup;
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
                Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
            }
            else
            {
                Projector.PicContainer.PicList[(int)pi.Props.Level].Clip = null;
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
            rez.Add($"s = {pi.Props.SizeX}");
            if (pi.Props.Rotate != 0) rez.Add($"Rot={pi.Props.Rotate}");
            rez.Add($"Flip={(int)pi.Props.Flip}");
            Projector.ImageCadre.ResultString = string.Join(", ", rez.ToArray());
            System.Windows.Clipboard.SetText(Projector.ImageCadre.ResultString);
        }
        private void AdjustXY(PictureItem pi)
        {
            var sceenP = Projector.PicContainer.PicList[(int)pi.Props.Level].PointToScreen(
                new Point(0, 
                0              
               ));
            double ex = Projector.PicContainer.PicList[(int)pi.Props.Level].Margin.Left;
            double ey = Projector.PicContainer.PicList[(int)pi.Props.Level].Margin.Top;
            Projector.PicContainer.PicList[(int)pi.Props.Level].Margin =
            new System.Windows.Thickness(pi.Props.X + ex - sceenP.X, pi.Props.Y + ey - sceenP.Y , 0, 0);
            // here fully repaint
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

    public class PicLevelComparer : IComparer<PictureItem>
    {

        public int Compare(PictureItem x, PictureItem y)
        {
            return x.Props.Level.CompareTo(y.Props.Level);
        }
    }
}
