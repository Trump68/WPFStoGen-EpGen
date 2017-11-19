using MVVMApp.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MVVMApp.Views
{
    /// <summary>
    /// Interaction logic for ViewList.xaml
    /// </summary>
    public partial class ViewList : Window
    {
        public ViewList()
        {
            InitializeComponent();
        }

        // A timer to display the video's location.
        private DispatcherTimer timerVideoTime;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            minionPlayer.MediaOpened += minionPlayer_MediaOpened;
            minionPlayer.Source = new Uri((this.DataContext as ECadreListViewModel).ClipToProcess);
            minionPlayer.Play();
            (this.DataContext as ECadreListViewModel).RefreshStart = RefreshStart;
            
        }
        public void RefreshStart()
        {
            //if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            //{
            //    string fp = System.IO.Path.GetDirectoryName(minionPlayer.Source.LocalPath);
            //    string nfp = System.IO.Path.GetDirectoryName(((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).MainFileName);
            //    if (string.IsNullOrEmpty(nfp))
            //    {
            //        nfp = minionPlayer.Source.LocalPath;
            //        ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).MainFileName = System.IO.Path.GetFileName(nfp);
            //    }
            //    if (minionPlayer.Source.LocalPath != nfp)
            //    {
            //        if (!string.IsNullOrEmpty(nfp))
            //        {
            //            (this.DataContext as ECadreListViewModel).ClipToProcess = nfp;
            //            minionPlayer.Source = new Uri(nfp);
            //            minionPlayer.Play();
            //        }
            //    }
            //    minionPlayer.Position = TimeSpan.FromSeconds((((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).StartPos));                
            //    CurrentPosition = minionPlayer.Position.TotalMilliseconds;               
            //    ShowPosition();
            //}
        }
        private void minionPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
           
            sbarSeek.Minimum = 0;
            sbarSeek.Maximum = (this.DataContext as ECadreListViewModel).ScrollFactor1;
            sbarSeek.Value = (int)(sbarSeek.Maximum / 2);

            sbarScale.Minimum = 0;
            sbarScale.Maximum = (this.DataContext as ECadreListViewModel).ScrollFactor2;
            sbarScale.Value = (int)(sbarScale.Maximum / 2);
            sbarScale.Visibility = Visibility.Visible;

            sbarPosition.Minimum = 0;
            sbarPosition.Maximum = minionPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;
            minionPlayer.Pause();
        }

       

        // Enable and disable appropriate buttons.
        private void EnableButtons(bool is_playing)
        {
            if (!is_playing)
            {
                //btnPlay.IsEnabled = false;
                // btnPause.IsEnabled = true;
                btnPlay.Opacity = 0.5;
                // btnPause.Opacity = 1.0;                
            }
            else
            {
               // btnPlay.IsEnabled = true;
               // btnPause.IsEnabled = false;
                btnPlay.Opacity = 1.0;
                //btnPause.Opacity = 0.5;
            }
            timerVideoTime.IsEnabled = is_playing;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (btnPlay.Opacity == 1)
            {                
                minionPlayer.Pause();
                EnableButtons(false);
            }
            else
            {
                minionPlayer.Play();
                EnableButtons(true);
            }
            
        }
     
     

        private void btnSetPosition_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(double.Parse(txtPosition.Text));
            minionPlayer.Position = timespan;
            ShowPosition();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Stop();
            minionPlayer.Source = new Uri((this.DataContext as ECadreListViewModel).ClipToProcess);
            minionPlayer.Play();
            minionPlayer.Pause();
        }
        // Pause before the user moves the scroll bar.
        private void sbarPosition_PreviewMouseDown(object sender,
            MouseButtonEventArgs e)
        {
            //minionPlayer.Pause();
        }
        public double CurrentPosition;
        private void sbarScale_PreviewMouseDown(object sender,
           MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarScale.Minimum = 0;
            sbarScale.Maximum = (this.DataContext as ECadreListViewModel).ScrollFactor2;
            sbarScale.Value = (int)(sbarScale.Maximum / 2);
        }
        private void sbarSeek_PreviewMouseDown(object sender,
         MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarSeek.Minimum = 0;
            sbarSeek.Maximum = (this.DataContext as ECadreListViewModel).ScrollFactor1;
            sbarSeek.Value = (int)(sbarSeek.Maximum / 2);


        }
        private void sbarScale_PreviewMouseUp(object sender,
        MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarScale.Value = (int)(sbarScale.Maximum / 2); 
        }
        private void sbarSeek_PreviewMouseUp(object sender,
       MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarSeek.Value = (int)(sbarSeek.Maximum / 2);
        }
        private void sbarPosition_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            RefreshClipPosition();
        }
        private void sbarScale_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(((sbarScale.Maximum / 2) - sbarScale.Value)/10);            
            minionPlayer.Position = TimeSpan.FromMilliseconds(CurrentPosition).Add(-timespan);
            ShowPosition();
        }
        private void sbarSeek_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds((sbarSeek.Maximum / 2) - sbarSeek.Value);
            minionPlayer.Position = TimeSpan.FromMilliseconds(CurrentPosition).Add(-timespan);
            ShowPosition();
        }
        private void RefreshClipPosition()
        {
            TimeSpan timespan = TimeSpan.FromSeconds(sbarPosition.Value);
            minionPlayer.Position = timespan;
            ShowPosition();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            ShowPosition();
        }
        // Show the play position in the ScrollBar and TextBox.
        private void ShowPosition()
        {
            sbarPosition.Value = minionPlayer.Position.TotalSeconds;
            txtPosition.Text = minionPlayer.Position.TotalSeconds.ToString("0.0");
        }
        private void btnSaveStart_Click(object sender, RoutedEventArgs e)
        {
            //if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            //{
            //    ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).StartPos = sbarPosition.Value;
            //}
        }
        private void btnSaveEnd_Click(object sender, RoutedEventArgs e)
        {
            //if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            //{
            //    ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).EndPos = sbarPosition.Value;
            //    ((this.DataContext as ECadreListViewModel)).CopyPosStr();
            //}
        }
        private void btnSaveEndAndAdd_Click(object sender, RoutedEventArgs e)
        {
            //if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            //{
            //    ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).EndPos = sbarPosition.Value;
            //    ((this.DataContext as ECadreListViewModel)).CopyPosStr();
            //    (this.DataContext as ECadreListViewModel).AddCadre();
            //}
        }
        private void btnScreenshot_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot();

        }
        private void MadeShot()
        {
            string path = System.IO.Path.GetDirectoryName(this.minionPlayer.Source.LocalPath) + System.IO.Path.DirectorySeparatorChar.ToString() + "CAPS";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if ((base.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            {
                path = path + System.IO.Path.DirectorySeparatorChar.ToString() + ((base.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).Mark;
            }
            else
            {
                path = path + System.IO.Path.DirectorySeparatorChar.ToString() + "SC";
            }
            int num = 0;
            string str2 = num.ToString("D4");
            string str3 = $"{path}-{str2}.jpg";
            while (File.Exists(str3))
            {
                num++;
                str2 = num.ToString("D4");
                str3 = $"{path}-{str2}.jpg";
            }
            this.ImportMedia(str3);
        }



        private void ImportMedia(string path)
        {
            RenderTargetBitmap source = new RenderTargetBitmap(Convert.ToInt32(this.minionPlayer.RenderSize.Width), Convert.ToInt32(this.minionPlayer.RenderSize.Height), 96.0, 96.0, PixelFormats.Pbgra32);
            source.Render(this.minionPlayer);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                new JpegBitmapEncoder
                {
                    QualityLevel = 100,
                    Frames = { BitmapFrame.Create(source) }
                }.Save(stream);
            }
        }
        private bool isNavigationByKey = true;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.isNavigationByKey)
            {
                TimeSpan ts = new TimeSpan(0, 0, 0, 0, 0);
                if (e.Key == Key.Q)
                {
                    ts = new TimeSpan(0, 0, 0, 0, 0x3e8);
                    TimeSpan span2 = this.minionPlayer.Position.Add(-ts);
                    if (span2 >= TimeSpan.MinValue)
                    {
                        this.minionPlayer.Position = span2;
                    }
                    else
                    {
                        this.minionPlayer.Position = new TimeSpan(0L);
                    }
                }
                else if (e.Key == Key.W)
                {
                    ts = new TimeSpan(0, 0, 0, 0, 0x3e8);
                    TimeSpan span4 = this.minionPlayer.Position.Add(ts);
                    if (span4 < this.minionPlayer.NaturalDuration)
                    {
                        this.minionPlayer.Position = span4;
                    }
                    else
                    {
                        this.minionPlayer.Position = this.minionPlayer.NaturalDuration.TimeSpan;
                    }
                }
                else if (e.Key == Key.A)
                {
                    ts = new TimeSpan(0, 0, 0, 0, 50);
                    TimeSpan span5 = this.minionPlayer.Position.Add(-ts);
                    if (span5 >= TimeSpan.MinValue)
                    {
                        this.minionPlayer.Position = span5;
                    }
                    else
                    {
                        this.minionPlayer.Position = new TimeSpan(0L);
                    }
                }
                else if (e.Key == Key.S)
                {
                    ts = new TimeSpan(0, 0, 0, 0, 50);
                    TimeSpan span6 = this.minionPlayer.Position.Add(ts);
                    if (span6 < this.minionPlayer.NaturalDuration)
                    {
                        this.minionPlayer.Position = span6;
                    }
                    else
                    {
                        this.minionPlayer.Position = this.minionPlayer.NaturalDuration.TimeSpan;
                    }
                }
                else if (e.Key == Key.M)
                {
                    this.MadeShot();
                }
                else
                {
                    return;
                }
                e.Handled = true;
                this.ShowPosition();
            }

        }
    }
}
