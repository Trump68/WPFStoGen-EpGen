using MVVMApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
            if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            {
                if (minionPlayer.Source.LocalPath != ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).MainFileName)
                {
                    if (!string.IsNullOrEmpty(((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).MainFileName))
                    {
                        (this.DataContext as ECadreListViewModel).ClipToProcess = ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).MainFileName;
                        minionPlayer.Source = new Uri((this.DataContext as ECadreListViewModel).ClipToProcess);
                        minionPlayer.Play();
                    }
                }
                minionPlayer.Position = TimeSpan.FromSeconds((((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).StartPos));                
                CurrentPosition = minionPlayer.Position.TotalMilliseconds;               
                ShowPosition();
            }
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
            if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            {
                ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).StartPos = sbarPosition.Value;
            }
        }
        private void btnSaveEnd_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            {
                ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).EndPos = sbarPosition.Value;
                ((this.DataContext as ECadreListViewModel)).CopyPosStr();
            }
        }
        private void btnSaveEndAndAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem != null)
            {
                ((this.DataContext as ECadreListViewModel).ECadres.CurrentItem as ECadreViewModel).EndPos = sbarPosition.Value;
                ((this.DataContext as ECadreListViewModel)).CopyPosStr();
                (this.DataContext as ECadreListViewModel).AddCadre();
            }
        }
        


    }
}
