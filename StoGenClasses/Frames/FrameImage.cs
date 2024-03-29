﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using StoGen.Classes.Transition;
using StoGen.ModelClasses;
using StoGenMake.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StoGen.Classes
{

    public delegate void RunNext();
   
    public class FrameImage : Frame, IDisposable
    {
        private static seCtrl _ControlData = new seCtrl();
        public static seCtrl ControlData
        {
            set
            {
                _ControlData = value;
                if (_ControlData.TimeToShiftMax == 0 && _ControlData.TimeToShift > 0)
                    TimeShift = _ControlData.TimeToShift;
                else if (_ControlData.TimeToShiftMax > 0 && _ControlData.TimeToShift > 0 && _ControlData.TimeToShiftMax >= _ControlData.TimeToShift)
                {
                    Random rnd = new Random();
                    TimeShift = rnd.Next(_ControlData.TimeToShift, _ControlData.TimeToShiftMax);
                }

            }
        }
        static int TimeShift = 0;

        public static System.Threading.Timer timer;
        public static TransitionManager tranManager = new TransitionManager();
        public static CadreController CurrentProc;
        public static FrameImage Instance;
        public static volatile bool LoopProcessed = false;
        public static bool videoactive = false;        

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
        
        public static bool Blocked = false;
        public static void ProcessLoopDelegate()
        {
            //Control data
            if (Projector.TimerEnabled && (TimeShift > 0))
            {
                if (FrameImage.TimeStarted.AddMilliseconds(TimeShift) <= DateTime.Now)
                {
                    int num = CurrentProc.CadreId + _ControlData.ShiftStep - 1;
                    CurrentProc.GoToCadre(num);
                    return;
                }
            }

            if (true) // - disabled for spped of animation - test!!!!!!!!!
            {
                //Transition
                Blocked = !FrameImage.tranManager.Process();
                if (FrameImage.Animations == null) return;
                #region Other
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

                #endregion

                if (!videoactive) return;

                #region Reverse loops
                    if (!FrameImage.LoopProcessed && FrameImage.ClipEndPos > 0)
                    {
                        if (FrameImage.IsLoop == 3) //назад
                        {
                            if (!FrameImage.NowReverse && Projector.PicContainer.Clip.Position >= TimeSpan.FromSeconds(FrameImage.ClipEndPos))
                            {
                                FrameImage.Loops++;
                                if (FrameImage.Animations[FrameImage.AnimationIndex].ALC <= FrameImage.Loops)
                                {
                                    FrameImage.IsLoop = 1;
                                    FrameImage.LoopProcessed = true;
                                }
                                else
                                {
                                    Projector.PicContainer.Clip.Pause();
                                    //Projector.ClipSound.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                                    //Projector.ClipSound.Play();
                                    FrameImage.NowReverse = !FrameImage.NowReverse;
                                    Thread.Sleep(PausePeriod1);
                                    lastupdated = DateTime.Now;
                                    return;
                                }
                            }
                            else if (FrameImage.NowReverse && Projector.PicContainer.Clip.Position <= TimeSpan.FromSeconds(FrameImage.ClipStartPos))
                            {
                                FrameImage.Loops++;
                                if (FrameImage.Animations[FrameImage.AnimationIndex].ALC < FrameImage.Loops)
                                { FrameImage.IsLoop = 1; }
                                else
                                {
                                    Thread.Sleep((int)(PausePeriod2 * Projector.PicContainer.Clip.SpeedRatio));
                                    Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                                    Projector.PicContainer.Clip.Play();
                                    //Projector.ClipSound.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                                    //Projector.ClipSound.Play();
                                    FrameImage.NowReverse = !FrameImage.NowReverse;
                                    return;
                                }
                            }
                            else if (FrameImage.NowReverse)
                            {
                                Projector.PicContainer.Clip.Position = Projector.PicContainer.Clip.Position.Subtract(TimeSpan.FromMilliseconds(DateTime.Now.Subtract(lastupdated).TotalMilliseconds * Projector.PicContainer.Clip.SpeedRatio));
                                //Projector.ClipSound.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                                lastupdated = DateTime.Now;
                                return;
                            }
                        }
                    }
                    #endregion
            }


            #region Normal loops
            if (!videoactive) return;
            TimeSpan ts1 = Projector.PicContainer.Clip.Position;
            TimeSpan ts2 = TimeSpan.FromSeconds(FrameImage.ClipEndPos);
            bool isEnded = false;
            if (Projector.PicContainer.Clip.NaturalDuration.HasTimeSpan)
                isEnded = (Projector.PicContainer.Clip.NaturalDuration.TimeSpan <= Projector.PicContainer.Clip.Position);
            if (FrameImage.IsLoop != 3 && (ts1 >= ts2 || isEnded))
            {
                if (FrameImage.IsLoop == 0 && !Projector.EndlessVideo)//остановить
                {
                    FrameImage.LoopProcessed = true;
                    Projector.PicContainer.Clip.Pause();
                    //Projector.ClipSound.Pause();

                    if (FrameImage.WaitEnd > 0)// замереть на время
                    {
                        FrameImage.IsLoop = 4;
                        FrameImage.WaitStart = FrameImage.WaitEnd;
                        FrameImage.WaitEnd = -1;
                        FrameImage.TimeStarted = DateTime.Now;
                    }
                    else// перейти дальше
                    {
                        Thread.Sleep(PausePeriod1);
                        FrameImage.CurrentProc.GetNextCadre();
                    }

                    return;
                }
                else if (FrameImage.IsLoop == 2 && !Projector.EndlessVideo)//остановить
                {
                    FrameImage.LoopProcessed = true;
                    Projector.PicContainer.Clip.Pause();
                    //Projector.ClipSound.Pause();
                }
                else if (FrameImage.IsLoop == 1)// в начало
                {
                    
                    if (FrameImage.Animations.Count() > (FrameImage.AnimationIndex + 1))
                        FrameImage.AnimationIndex++;
                    else
                        FrameImage.AnimationIndex = 0;

                    FrameImage.Loops = 0;
                    FrameImage.LoopProcessed = false;
                    if (!string.IsNullOrEmpty(FrameImage.Animations[FrameImage.AnimationIndex].Source))
                    {
                        if (Projector.PicContainer.Clip.Source != new Uri(FrameImage.Animations[FrameImage.AnimationIndex].Source))
                        {
                            Projector.PicContainer.Clip.Source = new Uri(FrameImage.Animations[FrameImage.AnimationIndex].Source);
                            Projector.PicContainer.Clip.Play();
                            //Projector.ClipSound.Open(new Uri(FrameImage.Animations[FrameImage.AnimationIndex].Source));
                            //Projector.ClipSound.Play();
                        }
                        //Projector.ClipSound.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                    }

                    FrameImage.IsLoop = FrameImage.Animations[FrameImage.AnimationIndex].ALM;
                    FrameImage.ClipStartPos = FrameImage.Animations[FrameImage.AnimationIndex].APS;
                    FrameImage.ClipEndPos = FrameImage.Animations[FrameImage.AnimationIndex].APE;
                    FrameImage.WaitStart = FrameImage.Animations[FrameImage.AnimationIndex].AWS;
                    FrameImage.WaitEnd = FrameImage.Animations[FrameImage.AnimationIndex].AWE;
                    Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                    //Projector.ClipSound.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                    //Projector.ClipSound.Volume = ((float)FrameImage.Animations[FrameImage.AnimationIndex].AV /100);
                    float rate = ((float)FrameImage.Animations[FrameImage.AnimationIndex].AR / 100);
                    Projector.PicContainer.Clip.SpeedRatio = rate;
                }
            }
            #endregion

        }


        private void TimerProc(object state)
        {
            try
            {
                if (timer != null)
                {
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                }
                RunNext op1 = new RunNext(FrameImage.ProcessLoopDelegate);
                Projector.PicContainer.Clip.Dispatcher.Invoke(op1, System.Windows.Threading.DispatcherPriority.Render);

                if (timer != null)
                {
                    timer.Change(TimerPeriod, TimerPeriod);
                }
            }
            catch (Exception)
            {
            }
        }


        public static List<PictureItem> Pics { get; set; }
        public bool AutoShift { get; set; }

        public FrameImage()
            : base()
        {
            Pics = new List<PictureItem>();
            this.AutoShift = false;
            if (timer == null) timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, TimerPeriod, TimerPeriod);
            Instance = this;
        }


        private void RecreateImage(int index)
        {
            var it = Projector.PicContainer.PicList[index];
            it.RenderTransform = new TransformGroup();
        }

        //If you get 'dllimport unknown'-, then add 'using System.Runtime.InteropServices;'
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
        public override Cadre Repaint()
        {
            Stopped = false;
            //Projector.PicContainer.Clip.Opacity = 0;
            for (int i = 0; i < 40; i++)
            {
                RecreateImage(i);
            }
            if (timer == null) timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, TimerPeriod, TimerPeriod);
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Projector.NumberText.Text = $"{this.Owner.Owner.Cadres.IndexOf(this.Owner) + 1}/{this.Owner.Owner.Cadres.Count}";
            Projector.Owner.Background = new SolidColorBrush(Colors.Black);

            FrameImage.LoopProcessed = false;
            FrameImage.CurrentProc = this.Proc;
            FrameImage.NextCadre = 0;
            FrameImage.Animations = null;

            bool isPrevious = false;
            if (!Pics.Any() || Pics[0].Props.FileName == "SKIP") return this.Owner;
            FrameImage.tranManager.Clear();
            if (Pics[0].Props.FileName == "PREVIOUS")
            {
                Pics.RemoveAt(0);
                isPrevious = true;
                int indexEmpty = Projector.PicContainer.PicList.IndexOf(Projector.PicContainer.PicList.First(x => x.Tag == null));
                Pics.ForEach(x => x.Props.Level = (indexEmpty++));
            }
            else
            {
                foreach (System.Windows.Controls.Image item in Projector.PicContainer.PicList)
                {
                    item.Tag = null;
                }
            }

            bool runClip = false;
            videoactive = false;
            FrameImage.TimeToNext = -1;
            FrameImage.WaitStart = -1;
            FrameImage.WaitEnd = -1;
            bool videoPresent = false;
            for (int i = 0; i < Pics.Count; i++)
            {
                if (Pics[i].Props.NextCadre > 0) FrameImage.NextCadre = Pics[i].Props.NextCadre;
                if (!Pics[i].Props.Active)
                {
                    FrameImage.IsLoop = Pics[i].Props.CurrentAnimation.ALM;
                    continue;
                }


                PictureItem pi = Pics[i];
                string fn = pi.Props.FileName;

                if (pi.Props.FileName.EndsWith("$$WHITE$$"))
                {
                    Projector.Owner.Background = new SolidColorBrush(Colors.White);
                    continue;
                }

                if (Projector.PicContainer.PicList[pi.Props.Level].Tag != null
                    &&
                    ((PictureSourceProps)Projector.PicContainer.PicList[pi.Props.Level].Tag).FileName == fn
                    && !pi.Props.Reload)
                {
                    Projector.PicContainer.PicList[pi.Props.Level].Tag = pi.Props;
                    continue;
                }

                
                

                if (string.IsNullOrEmpty(Pics[i].Props.FileName) || string.IsNullOrEmpty((Path.GetFileName(Pics[i].Props.FileName))))
                {
                    continue;
                }
                
                else if (!Pics[i].Props.FileName.EndsWith("CANVAS") && !File.Exists(Pics[i].Props.FileName))
                {
                    XtraMessageBox.Show(Pics[i].Props.FileName, "File not exists", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                string ext = Path.GetExtension(Pics[i].Props.FileName);
                if (pi.Props.Timer > 0)
                    FrameImage.TimeToNext = pi.Props.Timer;

                #region Transition

                
                #region Video
                if ((pi.Props.CurrentAnimation != null) && (Pics[i].Props.isVideo || ext == ".mp4" || ext == ".mpg" || ext == ".avi" || ext == ".wmv" || ext == ".m4v"))
                {
                    videoPresent = true;
                    FrameImage.TimeToNext = -1;
                    videoactive = true;

                    FrameImage.Loops = 0;
                    FrameImage.AnimationIndex = 0;
                    FrameImage.Animations = pi.Props.Animations;
                        FrameImage.IsLoop = pi.Props.CurrentAnimation.ALM;
                        FrameImage.ClipStartPos = pi.Props.CurrentAnimation.APS;
                        FrameImage.ClipEndPos = pi.Props.CurrentAnimation.APE;
                        FrameImage.WaitStart = pi.Props.CurrentAnimation.AWS;
                        FrameImage.WaitEnd = pi.Props.CurrentAnimation.AWE;
                    if (Projector.PicContainer.Clip.Source == null || (Projector.PicContainer.Clip.Source.LocalPath.ToLower() != Pics[i].Props.FileName.ToLower()))
                    {
                        Projector.PicContainer.Clip.LoadedBehavior = MediaState.Manual;
                       
                        Projector.PicContainer.Clip.MediaOpened -= Clip_MediaOpened;
                        Projector.PicContainer.Clip.MediaOpened += Clip_MediaOpened;
                        Projector.PicContainer.Clip.Source = new Uri(Pics[i].Props.FileName);
                    }
                    else
                    {
                        SetClip();
                    }
                    Projector.PicContainer.Clip.Volume = 0;

                    float rate = ((float)Pics[i].Props.CurrentAnimation.AR / 100);
                    Projector.PicContainer.Clip.SpeedRatio = rate;

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
                    if (Pics[i].Props.CurrentAnimation.AWS > 0)
                        PausePeriod1 = Pics[i].Props.CurrentAnimation.AWS;
                    if (Pics[i].Props.CurrentAnimation.AWE > 0)
                        PausePeriod2 = Pics[i].Props.CurrentAnimation.AWE;
                    else PausePeriod2 = 40;

                    // Transition video
                    if (!string.IsNullOrEmpty(pi.Props.Transition))
                    {
                        TransitionData trandata = new TransitionData();
                        trandata.Level = pi.Props.Level;
                        trandata.Parse(pi.Props.Transition, 3);
                        FrameImage.tranManager.Add(trandata);
                    }

                    // Opacity
                    if (pi.Props.Opacity > -1)
                        Projector.PicContainer.Clip.Opacity = (pi.Props.Opacity / 100.0);


                    continue;
                }
                #endregion     
             
                // Transition image
                if (!string.IsNullOrEmpty(pi.Props.Transition))
                {
                    TransitionData trandata = new TransitionData();
                    trandata.Level = pi.Props.Level;
                    trandata.Parse(pi.Props.Transition, 0);
                    FrameImage.tranManager.Add(trandata);
                }

                #region Opacity
                // Opacity
                if (pi.Props.Opacity > -1) Projector.PicContainer.PicList[pi.Props.Level].Opacity = (pi.Props.Opacity / 100.0);

                #endregion

                #region Blur

                if (pi.Props.Blur > 0)
                {
                    System.Windows.Media.Effects.BlurEffect be = new System.Windows.Media.Effects.BlurEffect();
                    be.Radius = pi.Props.Blur;
                    Projector.PicContainer.PicList[pi.Props.Level].Effect = be;
                }
                else
                {
                    Projector.PicContainer.PicList[pi.Props.Level].Effect = null;
                }
                #endregion
                

                #endregion

                int ImW = 0;
                int ImH = 0;
                if (!Pics[i].Props.FileName.EndsWith("CANVAS"))
                {
                    try
                    {
                        Bitmap bm = new Bitmap(fn);

                        //BitmapImage imageSource = new BitmapImage();
                        //imageSource = new BitmapImage(new Uri(fn));
                        
                        Projector.PicContainer.PicList[pi.Props.Level].Source = ImageSourceFromBitmap(bm);                        
                        ImW = bm.Width;
                        ImH = bm.Height;
                    }
                    catch (Exception e)
                    {
                        XtraMessageBox.Show(Pics[i].Props.FileName,e.Message, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }

                #region Size
                DoResize(pi.Props, ImW, ImH);
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
                    Projector.PicContainer.PicList[pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
                }
                else
                {
                    Projector.PicContainer.PicList[pi.Props.Level].Clip = null;
                }
                #endregion

                Projector.PicContainer.PicList[pi.Props.Level].Tag = pi.Props;
            }

            if (!videoPresent)
            {
                Projector.PicContainer.Clip.Opacity = 0;
            }

            if (CadreShifted < 0) CadreShifted = Pics.Count - 1;
            for (int j = 0; j < Projector.PicContainer.PicList.Count; j++)
            {
                if (Projector.PicContainer.PicList[j].Tag == null)
                    Projector.PicContainer.PicList[j].Visibility = Visibility.Hidden;
                else
                    Projector.PicContainer.PicList[j].Visibility = Visibility.Visible;
            }

           DoTransformAll();

            if (!runClip)
                timer.Change(TimerPeriod, TimerPeriod);
            FrameImage.TimeStarted = DateTime.Now;

            return this.Owner;

        }
        private void DoResize(PictureSourceProps pi, int imW, int imH)
        {
            Projector.PicContainer.PicList[pi.Level].Stretch = Stretch.Uniform;
            if (pi.SizeX == -1 || pi.SizeY == -1)
            {
                if (pi.SizeX == -1) pi.SizeX = imW;
                if (pi.SizeY == -1) pi.SizeY = imH;
            }
            else if (pi.SizeY == -2 || pi.SizeY == -2 || pi.ScreenStretch)
            {
                //System.Windows.Window w = Projector.ProjectorWindow;
                //if (w == null)
                //    w = System.Windows.Application.Current.MainWindow;

                //var interopHelper = new WindowInteropHelper(w);
                //var activeScreen = Screen.FromHandle(interopHelper.Handle);
                //pi.SizeX = activeScreen.WorkingArea.Width;
                //pi.SizeY = activeScreen.WorkingArea.Height;
                //pi.SizeMode = PictureSizeMode.Stretch;
                pi.SizeX = pi.X;
                pi.SizeY = pi.Y;
                pi.X = 0;
                pi.Y = 0;
                pi.ScreenStretch = true;
                Projector.PicContainer.PicList[pi.Level].Stretch = Stretch.Fill;

            }
            else
            {
                if (pi.SizeMode == PictureSizeMode.Clip)
                    Projector.PicContainer.PicList[pi.Level].Stretch = Stretch.Fill;
            }
            Projector.PicContainer.PicList[pi.Level].Width = pi.SizeX;
            Projector.PicContainer.PicList[pi.Level].ClipToBounds = false;
            Projector.PicContainer.PicList[pi.Level].Height = pi.SizeY;
        }
        
        private void RecreateAndRefreshImage(PictureSourceProps sourceProps)
        {
            if (sourceProps.FileName.EndsWith("CANVAS")) return;
            RecreateImage(sourceProps.Level);
            BitmapImage imageSource = new BitmapImage(new Uri(sourceProps.FileName));
            Projector.PicContainer.PicList[(int)sourceProps.Level].Source = imageSource;
            DoResize(sourceProps, imageSource.PixelWidth, imageSource.PixelHeight);
            RefreshImage(sourceProps);
        }
        private void RotateAroundParent(string parent, TransformGroup tg)
        {
            var item = Pics.Where(x => x.Props.Name == parent).FirstOrDefault();
            if (item != null)
            {
                var pi = item.Props;
                if (pi.Rotate != 0)
                {
                    var ctrl = Projector.PicContainer.PicList[pi.Level];
                    var controlCenter = new System.Windows.Point(ctrl.Width / 2, ctrl.Height / 2);
                    double x = controlCenter.X + pi.X;
                    double y = controlCenter.Y + pi.Y;
                    //DoRotate(x, y, pi.Rotate, tg);
                }
                if (!string.IsNullOrEmpty(pi.Parent))
                {
                    this.RotateAroundParent(pi.Parent, tg);
                }
            }
        }
        private static void DoRotate(System.Windows.Controls.Image current,double xc, double yc, int angle, TransformGroup tg)
        {
           
            if (tg == null)
                tg = current.RenderTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
                current.RenderTransform = tg;
            }
            var roateTransform = new RotateTransform();
            roateTransform.Angle = angle;
            //current.RenderTransformOrigin = new Point(0.5, 0.5);
            roateTransform.CenterX = xc;
            roateTransform.CenterY = yc;
            var old = tg.Children.Where(x => x is RotateTransform).FirstOrDefault();
            while (old != null)
            {
                tg.Children.Remove(old);
                old = tg.Children.Where(x => x is RotateTransform).FirstOrDefault();
            }
            tg.Children.Add(roateTransform);
        }
        private static void DoFlip(System.Windows.Controls.Image current, int val, TransformGroup tg)
        {
            current.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            if (tg == null)
                tg = current.LayoutTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
                current.LayoutTransform = tg;
            }

            var roateTransform = new ScaleTransform();           
            var old = tg.Children.Where(x => x is ScaleTransform 
            && 
            (((x as ScaleTransform).ScaleX == -1 && val == 1)
            ||
            ((x as ScaleTransform).ScaleY == -1 && val == 2))
            ).FirstOrDefault();
            if (old != null)
            {               
                tg.Children.Remove(old);
            }
            else
            {
                if (val == 1)
                {
                    roateTransform.ScaleX = -1;
                }
                else if (val == 2)
                {
                    roateTransform.ScaleY = -1;
                }
                tg.Children.Add(roateTransform);
            }
        }
        public static void DoRotateFlip(TransformGroup tg, int level)
        {
            System.Windows.Controls.Image im = Projector.PicContainer.PicList[(int)level];
            //var controlCenter = new System.Windows.Point((im.Source as BitmapImage).PixelWidth / 2
            //    , (im.Source as BitmapImage).PixelHeight / 2);
             var controlCenter = new System.Windows.Point(im.Width / 2, im.Height / 2);
            var d = Pics.Where(it => it.Props.Level == level).FirstOrDefault().Props;
            double x = controlCenter.X + (d.X / 2);
            double y = controlCenter.Y + (d.Y / 2);
            if (d.Rotate != 0)
            {
                DoRotate(im, x, y, d.Rotate, tg);
            }
            if (d.Flip > 0)
            {
                DoFlip(im, (int)d.Flip, tg);
            }
        }
        private void DoLocation(PictureSourceProps pi, TransformGroup tg)
        {
            #region Location      
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
        private void RefreshImage(PictureSourceProps sourceProps)
        {
            var current = Projector.PicContainer.PicList[(int)sourceProps.Level];
            TransformGroup tg = current.RenderTransform as TransformGroup;
            if (tg == null)
                tg = new TransformGroup();

            //#region Move

            DoLocation(sourceProps, tg);

            //#endregion

            #region Rotate
            DoRotateFlip(tg, sourceProps.Level);
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
        private void Clip_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            SetClip();
        }
        private void SetClip()
        {
            
            Projector.PicContainer.Clip.MediaOpened -= Clip_MediaOpened;
            FrameImage.TimeStarted = DateTime.Now;
            if (timer != null)
            {
                timer.Change(TimerPeriod, TimerPeriod);
                Projector.PicContainer.Clip.Play();
                Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                if (FrameImage.IsLoop == 4 || FrameImage.WaitStart > 0)
                {
                    Projector.PicContainer.Clip.Pause();
                }
            }
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
        }
        public override void BeforeLeave()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            FrameImage.tranManager.Clear();
            Stopped = true;
        }

        int CadreShifted = -1;
        public static double ClipStartPos;
        public static double ClipEndPos;
        private static double NextCadre;
        private static DateTime TimeStarted;
        private static int IsLoop = 0;
        private static bool NowReverse = false;
        private static List<AP> Animations;
        private static int AnimationIndex;
        private static int Loops;
        internal bool ShowMovieControls;

        internal void ProcessKey(Key e)
        {
            int step = 40;
            double stepZoom = 0.2;
            if (!Projector.EditorMode)
            {
                if (e == Key.Right)
                {
                    foreach (var item in Pics)
                    {
                        item.Props.X = item.Props.X + step;
                    }
                }
                else if (e == Key.Left)
                {
                    foreach (var item in Pics)
                    {
                        item.Props.X = item.Props.X - step;
                    }
                }
                else if (e == Key.Up)
                {
                    foreach (var item in Pics)
                    {
                        item.Props.Y = item.Props.Y - step;
                    }
                }
                else if (e == Key.Down)
                {
                    foreach (var item in Pics)
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
                //Projector.PicContainer.PicList[pi.Props.Level].Clip = new RectangleGeometry(new System.Windows.Rect(pi.Props.ClipX, pi.Props.ClipY, clipW, clipH));
            }
            else
            {
                //Projector.PicContainer.PicList[pi.Props.Level].Clip = null;
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
                for (int i = Pics.Count - 1; i > 0; i--)
                {
                    if (Pics[i].Props.Active) return Pics[i];
                }
                return Pics[0];
            }
        }


        public override void Dispose()
        {
            Blocked = false;
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
            for (int j = 0; j < Projector.PicContainer.PicList.Count; j++)
            {
               Projector.PicContainer.PicList[j].Visibility = Visibility.Hidden;
            }
            Pics.Clear();
            base.Dispose();
        }


    }

}
