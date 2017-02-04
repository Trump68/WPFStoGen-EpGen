using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit.Utils;
using PerPixelAlphaBlend;
using StoGen.Extension;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WMPLib;

namespace StoGen.Classes
{
    public class FlashData
    {
        internal Form FlashForm = null;
        internal List<FlashItem> Flashes = new List<FlashItem>();
        //internal double Started = 0;
        internal double Counter = 0;
        internal double Started = 0;
    }
    public class FlashItem
    {
        internal double Wait = 0;
        internal double Period = 1000;
    }
    public delegate void RunNext();
    public class FrameImage : Frame, IDisposable
    {


        private int CanvasShiftY = 0;//25;
        private int CanvasShiftX = 0;//10;
        public static System.Threading.Timer timer;
        public static FlashData CurrentFlash = null;
        public static ProcedureBase CurrentProc;
        public static volatile bool LoopProcessed = false;
        public static int debugcount = 0;

        public static void RunNextDelegate()
        {
            FrameImage.CurrentProc.GetNextCadre();
        }
        /*
        public static void FreezeDelegate()
        {
            Projector.PicContainer.Clip.Ctlcontrols.pause();
        }
        public static void SetPositionDelegate()
        {
            Projector.PicContainer.Clip.Ctlcontrols.currentPosition = FrameImage.ClipStartPos;
        }*/
        static DateTime lastupdated;
        public static int TimerPeriod = 40;
        public static int PausePeriod1 = 200;
        public static int PausePeriod2 = 200;
        public static int TimeToNext = -1;
        public static int WaitStart = -1;
        public static int WaitEnd = -1;
        public static void ProcessLoopDelegate()
        {
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
            Projector.PicContainer.Clip.Dispatcher.Invoke(op1);

            /*
            if (CurrentFlash != null)
            {
                if (CurrentFlash.Flashes.Count == 0)
                {
                    CurrentFlash = null;
                }
                else
                {
                    double Passed = DateTime.Now.TimeOfDay.TotalMilliseconds - CurrentFlash.Started;
                    FlashItem fi = CurrentFlash.Flashes.First();
                    if (fi.Wait > 0)
                    {
                        fi.Wait = fi.Wait - Passed;
                    }
                    else
                    {
                        if (CurrentFlash.Counter == 0)
                        {
                            //SetFormOpacity(CurrentFlash.FlashForm, 1);
                            CurrentFlash.Started = DateTime.Now.TimeOfDay.TotalMilliseconds;
                            CurrentFlash.Counter = fi.Period;
                        }
                        else
                        {
                            if (CurrentFlash.Counter <= 0)
                            {
                                SetFormOpacity(CurrentFlash.FlashForm, 0);
                                CurrentFlash.Flashes.Remove(fi);
                                CurrentFlash.Counter = 0;
                            }
                            else
                            {
                                CurrentFlash.Counter = CurrentFlash.Counter - (DateTime.Now.TimeOfDay.TotalMilliseconds - CurrentFlash.Started);
                                if (CurrentFlash.Counter > 0)
                                {
                                    double a = CurrentFlash.Counter;
                                    double b = fi.Period;
                                    double op = (a / b);
                                    SetFormOpacity(CurrentFlash.FlashForm, op);
                                }
                            }
                        }

                    }

                }
            }
            */
            if (timer != null) timer.Change(TimerPeriod, TimerPeriod);
        }

        private void SetFormOpacity(Form frm, double op)
        {
            // ТУ БЫ НАДО ЛОЧИТЬ А НЕ ДАВИТЬ ЭКСЕПШЕН
            try
            {

                if (!frm.IsDisposed && !frm.Disposing)
                {
                    frm.Invoke(new Action(
                          () =>
                          {
                              if (!frm.IsDisposed && !frm.Disposing) frm.Opacity = op;
                          }));
                }
            }
            catch { }
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



            CurrentFlash = null;
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

                System.Windows.Controls.Image gf = Projector.PicContainer.PicList[(int)pi.Props.Level];
                if (gf.Tag != null && (string)gf.Tag == fn && !pi.Props.Reload)
                {
                    gf.Tag = fn;
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
                        Size NewSize = new Size(Pics[i].Props.SizeX, Pics[i].Props.SizeY);
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
                    gf.Stretch = Stretch.Uniform;
                }
                else if (pi.Props.SizeX == -2 || pi.Props.SizeY == -2)
                {
                    //if (image.Size.Width > 1600)
                    pi.Props.SizeX = 1600;
                    //if (image.Size.Height > 900)
                    pi.Props.SizeY = 900;
                    gf.Stretch = Stretch.Uniform;
                }
                else
                {
                    if (pi.Props.SizeMode == PictureSizeMode.Clip) gf.Stretch = Stretch.Fill;
                }
                gf.Source = imageSource;

                gf.Width = pi.Props.SizeX;
                gf.Height = pi.Props.SizeY;



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
            //if (Pics.Count == 0) Projector.PicContainer.Lci.Parent.Visibility = LayoutVisibility.Never;
            //Projector.PicContainer.Clip.URL = null;
            Projector.PicContainer.Clip.Visibility = System.Windows.Visibility.Hidden;
            /*
            foreach (gifPictureEdit item in Projector.PicContainer.PicList)
            {
               if (!item.CadreLoaded) item.Image = null;
            }
            
            foreach (PerPixelAlphaForm perPixelAlphaForm in Projector.PicContainer.FormList)
            {
                perPixelAlphaForm.Visible = false;
            }
            */
        }
        public override void BeforeLeave()
        {

            CurrentFlash = null;
            PostProcessingData.Clear();
            TimerPeriods.Clear();
        }
        public override void SetVisible(bool show)
        {

            //if (show) Projector.PicContainer.Lci.Parent.Visibility = LayoutVisibility.Always;
            //else Projector.PicContainer.Lci.Parent.Visibility = LayoutVisibility.Never;

            //base.SetVisible(show);
        }

        int CadreShifted = -1;
        public static double ClipStartPos;
        public static double ClipEndPos;
        private static double NextCadre;
        private static DateTime TimeStarted;
        private static int IsLoop = 0;
        private static bool NowReverse = false;

        internal void ProcessKey(KeyEventArgs e)
        {
            int i = 300;
            if (e.Control) i = 1;
            if (e.Alt) i = 10;
            PictureItem im = TopImage;
            CadreShifted = this.Pics.Count - 1;
            bool isRepaintNeed = false;
            if (e.Shift)
            {
                CadreShifted = 0;
                im = this.Pics[0];
            }
            if (e.KeyCode == Keys.Right || e.KeyValue == 102)
            {
                im.Props.X = im.Props.X + i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Left || e.KeyValue == 100)
            {
                im.Props.X = im.Props.X - i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyValue == 98)
            {
                im.Props.Y = im.Props.Y - i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyValue == 104)
            {
                im.Props.Y = im.Props.Y + i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                im.Props.Zoom = im.Props.Zoom - i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                im.Props.Zoom = im.Props.Zoom + i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Oem4)
            {
                im.Props.Rotate = im.Props.Rotate - i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.Oem6)
            {
                im.Props.Rotate = im.Props.Rotate + i;
                isRepaintNeed = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                string data = string.Empty;
                for (int ii = 0; ii < Pics.Count; i++)
                {
                    if (Pics[ii].Props.isMain)
                    {
                        data = $"MainPics={Pics[ii].Props.FileName};SizeX={Pics[ii].Props.SizeX};SizeY={Pics[ii].Props.SizeY};X={Pics[ii].Props.X};Y={Pics[ii].Props.Y}";
                        string ext = Path.GetExtension(Pics[ii].Props.FileName);
                        if (Pics[ii].Props.isVideo || ext == ".mp4" || ext == ".mpg" || ext == ".avi" || ext == ".wmv" || ext == ".gif")
                            data = $"{data};R={Pics[ii].Props.R}";
                        break;
                    }
                }
                if (string.IsNullOrEmpty(data)) { }
                Clipboard.SetText(data);
                isRepaintNeed = false;
            }
            if (isRepaintNeed) Repaint();
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
