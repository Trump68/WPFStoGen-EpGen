using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using EPCat.Model;
using Microsoft.Win32;
using StoGen.Classes;
using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace EPCat
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow Instance;
        EpCatViewModel ViewModel
        {
            get
            {
                return (this.DataContext as EpCatViewModel);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            (GV.View as GridViewBase).CellValueChanged += MainWindow_CellValueChanged;
            Loaded += new RoutedEventHandler(Serialization_Loaded);
            Instance = this;
        }
        void Serialization_Loaded(object sender, RoutedEventArgs e)
        {
            if (PathToGridSave == null)
            {
                PathToGridSave = "D:\temp\temp.xml";
            }
            RestoreLayout(PathToGridSave);
            var CommandArgs = System.Environment.GetCommandLineArgs().ToList();
            if (CommandArgs.Where(x => x.ToUpper() == "LOAD").Any())
            {
                ViewModel.ProcessScriptFile();
            }
        }
        void SaveLayout()
        {
            if (PathToGridSave == null)
            {
                PathToGridSave = @"d:\temp\temp.xml";
            }
            this.GV.SaveLayoutToXml(PathToGridSave);
        }
        string PathToGridSave = null;
        public void RestoreLayout(string path)
        {
            try
            {
                PathToGridSave = path;
                this.GV.RestoreLayoutFromXml(PathToGridSave);
                //int i = ;
                //var visiblerowH = GV.GetRowHandleByVisibleIndex(0);
                //GV.IsGroupRowHandle()
                //GV.SelectItem(visiblerowH);
                //var dd = GV.GetRow(visiblerowH);
            }
            catch (Exception)
            {
            }
        }
        private void MainWindow_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            UpdateEpItem();
        }
        public void UpdateEpItem()
        {
            ViewModel.UpdateCurrentItem();
        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ProcessScriptFile();
            this.GV.RefreshData();
            //layoutImages.ItemsSource = this.ViewModel.CurrentCaps;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Close(ViewModel.IsSavingAllowed);
            SaveLayout();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);

            if ((this.DataContext as EpCatViewModel).ClipToProcess != null)
            {
                minionPlayer.Source = new Uri((this.DataContext as EpCatViewModel).ClipToProcess);
                minionPlayer.Play();
            }
            //(this.DataContext as ECadreListViewModel).RefreshStart = RefreshStart;
        }

        private void minionPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            minionPlayer.MediaOpened -= minionPlayer_MediaOpened;
            minionPlayer.Volume = 100;
            sbarSeek.Minimum = 0;
            sbarSeek.Maximum = ScrollFactor1;
            sbarSeek.Value = (int)(sbarSeek.Maximum / 2);

            sbarScale.Minimum = 0;
            sbarScale.Maximum = ScrollFactor2;
            sbarScale.Value = (int)(sbarScale.Maximum / 2);
            sbarScale.Visibility = Visibility.Visible;

            sbarPosition.Minimum = 0;
            sbarPosition.Maximum = minionPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;

            PresentationSource src = PresentationSource.FromVisual(this);
            double dpiX = 96.0;
            double dpiY = 96.0;
            if (src != null)
            {
                dpiX = 96.0 * src.CompositionTarget.TransformToDevice.M11;
                dpiY = 96.0 * src.CompositionTarget.TransformToDevice.M22;
            }

            minionPlayer.Width = minionPlayer.NaturalVideoWidth * (96.0 / dpiX);
            minionPlayer.Height = minionPlayer.NaturalVideoHeight * (96.0 / dpiY);

            txtPosition.Text = ClipPosition.ToString();
            minionPlayer.Pause();
            RestoreVideoPosition();
        }

        private void Collapse_Click(object sender, RoutedEventArgs e)
        {
            if (MainDetail.Visibility == Visibility.Collapsed)
                MainDetail.Visibility = Visibility.Visible;
            else
                MainDetail.Visibility = Visibility.Collapsed;
        }

        private void TabPageChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            if (e.NewSelectedItem == EditTab)
            {
                RestoreVideoPosition();
                RestoreVideoPosition();
            }
        }



        private void SetCapsMode(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {

        }
        private void RefreshCapsMode()
        {

        }

        private void SetCurrentImagePassort(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {


        }


        private void GidJPGBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyJPGNameToClipboard();
        }

        private void ShowVideoBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ShowClip();
        }
        private void ShowSceneBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveScenario();
            ViewModel.ShowScene();
        }

        public static double ClipPosition = 0.0;
        private void LoadClip(double position)
        {
            this.NavTabGroup.SelectedContainer = this.EditTab;
            string path = null;
            if ((this.DataContext as EpCatViewModel).CurrentClip != null && string.IsNullOrEmpty(ViewModel.ClipToProcess))
            {
                var videos = (this.DataContext as EpCatViewModel).CurrentFolder.Videos;
                if (videos.Any())
                {
                    path = videos.First();
                    ViewModel.ClipToProcess = path;
                }
            }
            if (!string.IsNullOrEmpty(ViewModel.ClipToProcess))
            {
                path = ViewModel.ClipToProcess;
                TicTakToe.ClipTemplate.File = path;
            }

            if (string.IsNullOrEmpty(path)) return;



            minionPlayer.MediaOpened -= minionPlayer_MediaOpened;
            minionPlayer.MediaOpened += minionPlayer_MediaOpened;

            minionPlayer.Stop();
            minionPlayer.Source = new Uri(ViewModel.ClipToProcess);
            ClipPosition = position;
            //minionPlayer.Play();

            //minionPlayer.Pause();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            LoadClip(0.0);
        }


        #region Video element

        public double CurrentPosition;
        public int ScrollFactor1 { get; set; } = 200;
        public int ScrollFactor2 { get; set; } = 200;

        private void sbarSeek_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds((sbarSeek.Maximum / 2) - sbarSeek.Value);
            minionPlayer.Position = TimeSpan.FromMilliseconds(CurrentPosition).Add(-timespan);
            ShowPosition();
        }
        private void ShowPosition()
        {
            sbarPosition.Value = minionPlayer.Position.TotalSeconds;
            txtPosition.Text = minionPlayer.Position.TotalSeconds.ToString("0.0");
        }
        private void sbarScale_PreviewMouseDown(object sender,
   MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarScale.Minimum = 0;
            sbarScale.Maximum = ScrollFactor2;
            sbarScale.Value = (int)(sbarScale.Maximum / 2);
        }
        private void sbarSeek_PreviewMouseDown(object sender,
         MouseButtonEventArgs e)
        {
            CurrentPosition = minionPlayer.Position.TotalMilliseconds;
            sbarSeek.Minimum = 0;
            sbarSeek.Maximum = ScrollFactor1;
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

        private void sbarScale_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(((sbarScale.Maximum / 2) - sbarScale.Value) / 10);
            minionPlayer.Position = TimeSpan.FromMilliseconds(CurrentPosition).Add(-timespan);
            ShowPosition();
        }
        private void sbarPosition_PreviewMouseDown(object sender,
        MouseButtonEventArgs e)
        {
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
                //txtPositionStart.Text = TicTakToe.ClipTemplate.PositionStart.ToString();                
                minionPlayer.Play();

                RestoreVideoPosition();
                EnableButtons(true);
            }
        }


        private void EnableButtons(bool is_playing)
        {
            if (!is_playing)
            {
                btnPlay.Opacity = 0.5;
            }
            else
            {
                btnPlay.Opacity = 1.0;
            }
            timerVideoTime.IsEnabled = is_playing;
        }
        private DispatcherTimer timerVideoTime;

        private void btnSetPosition_Click(object sender, RoutedEventArgs e)
        {
            RestoreVideoPosition();
        }

        private void btnScreenshot_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot(false, false, false);
        }
        private void MadeShot(bool addGroup, bool Gray, bool simple)
        {
            string path =
                System.IO.Path.GetDirectoryName(this.minionPlayer.Source.LocalPath)
                + System.IO.Path.DirectorySeparatorChar.ToString() + "CLIPCAPS";
            string str3 = string.Empty;
            if (simple)
            {
                str3 = System.IO.Path.Combine(path, "image.png");
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if ((this.DataContext as EpCatViewModel).CurrentClip != null)
                {
                    int num = 0;
                    string str2 = num.ToString("D4");
                    str3 = System.IO.Path.Combine(path, $"{str2}.{(this.DataContext as EpCatViewModel).CurrentClip.ID}.png");
                    while (File.Exists(str3))
                    {
                        num++;
                        str2 = num.ToString("D4");
                        str3 = System.IO.Path.Combine(path, $"{str2}.{(this.DataContext as EpCatViewModel).CurrentClip.ID}.png");
                    }
                }
                else
                {
                    path = path + System.IO.Path.DirectorySeparatorChar.ToString() + "SC";

                    int num = 0;
                    string str2 = num.ToString("D4");
                    str3 = $"{path}-{str2}.png";
                    while (File.Exists(str3))
                    {
                        num++;
                        str2 = num.ToString("D4");
                        str3 = $"{path}-{str2}.png";
                    }
                }
            }
            TicTakToe.SetClipScreenShot(str3);
            this.ImportMedia(str3, Gray);
            if (addGroup)
            {
                ViewModel.CopyGroup(true, false, 0, true);
            }
        }
        private void ImportMedia(string path, bool isGrayscale = false)
        {

            PresentationSource src = PresentationSource.FromVisual(this);
            double dpiX = 96.0;
            double dpiY = 96.0;
            if (src != null)
            {
                dpiX = 96.0 * src.CompositionTarget.TransformToDevice.M11;
                dpiY = 96.0 * src.CompositionTarget.TransformToDevice.M22;
            }

            RenderTargetBitmap source =
                new RenderTargetBitmap(
                    //Convert.ToInt32(this.minionPlayer.RenderSize.Width),
                    //Convert.ToInt32(this.minionPlayer.RenderSize.Height),
                    Convert.ToInt32(this.minionPlayer.RenderSize.Width * (dpiX / 96.0)),
                    Convert.ToInt32(this.minionPlayer.RenderSize.Height * (dpiY / 96.0)),
                    //this.minionPlayer.NaturalVideoWidth,
                    //this.minionPlayer.NaturalVideoHeight,
                    dpiX,
                    dpiY,
                    PixelFormats.Pbgra32);
            source.Render(this.minionPlayer);
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(stream);
                using (Bitmap bitmap = new Bitmap(stream))
                {
                    if (isGrayscale)
                    {
                        using (Bitmap gray = ImageTools.GrayScaleFilter(bitmap))
                        {
                            BitmapExtensions.SaveJPG100(gray, path);
                        }
                    }
                    else
                        BitmapExtensions.SaveJPG100(bitmap, path);
                }
            }


            source.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private bool isNavigationByKey = true;
        #endregion


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.NavTabGroup.SelectedTabItem == this.EditTab)
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
                    this.MadeShot(false, false, false);
                }
                else if (e.Key == Key.N)
                {
                    this.MadeShot(false, false, true);
                }
                else if (e.Key == Key.LeftShift)
                {
                    this.ProcessSpace();
                }
                else
                {
                    return;
                }
                e.Handled = true;
                this.ShowPosition();
            }
        }



        private void btnSetPositionStart_Click(object sender, RoutedEventArgs e)
        {
            TicTakToe.ClipTemplate.PositionStart = Decimal.Parse(txtPosition.Text);
            txtPositionStart.Text = TicTakToe.ClipTemplate.PositionStart.ToString();
        }

        private void btnSetPositionEnd_Click(object sender, RoutedEventArgs e)
        {
            TicTakToe.ClipTemplate.PositionEnd = Decimal.Parse(txtPosition.Text);
            txtPositionEnd.Text = TicTakToe.ClipTemplate.PositionEnd.ToString();
        }

        private void btnSetPositionReset_Click(object sender, RoutedEventArgs e)
        {
            TicTakToe.ClipTemplate.PositionStart = 0;
            txtPositionStart.Text = TicTakToe.ClipTemplate.PositionStart.ToString();

            TicTakToe.ClipTemplate.PositionEnd = 0;
            txtPositionEnd.Text = TicTakToe.ClipTemplate.PositionEnd.ToString();
        }



        private void EditVideoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavTabGroup.SelectedContainer = this.EditTab;
            txtPosition.Text = (this.DataContext as EpCatViewModel).CurrentClip.PositionStart.ToString();
        }
        private void EditEndVideoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavTabGroup.SelectedContainer = this.EditTab;
            txtPosition.Text = (this.DataContext as EpCatViewModel).CurrentClip.PositionEnd.ToString();
        }


        private void ProcessSpace()
        {
            if (TicTakToe.ClipTemplate.PositionStart == 0)
            {
                btnSetPositionStart_Click(null, null);
            }
            else if (TicTakToe.ClipTemplate.PositionEnd == 0)
            {
                btnSetPositionEnd_Click(null, null);
                btnSetPositionSave_Click(null, null);
                MadeShot(false, false, false);
            }
        }

        private void AddSceneBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true, true, 0, -1, true);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundBtn_Click(object sender, RoutedEventArgs e)
        {
            //copy
            (this.DataContext as EpCatViewModel).CopyCombinedScene(false);
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true, false, 0, 6, true);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true, false, 0, 7, true);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddClipBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCombinedScene(false, true, 0, -1, true);
            ViewModel.RefreshFolder();
        }
        private void AddSceneHeaderBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(false, false, 0, 1, true);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneCtrlBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(false, false, 0, 10, true);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }

        private void CopySceneBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EpCatViewModel).CopyCombinedScene(false);
        }


        private void btnSetPositionSave_Click(object sender, RoutedEventArgs e)
        {
            //save
            ViewModel.CopyGroup(false, false, 0, true);
            //save
            ViewModel.SaveClipTemplate();
            // reset
            //btnSetPositionReset_Click(null, null);
            (this.DataContext as EpCatViewModel).RefreshFolder();
            // MadeShot();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
        }

        private void AdMediaBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddMedia();
        }


        private void SaveCurrentClipBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveCurrentClipList();
        }



        private void RestoreVideoPosition()
        {
            if (string.IsNullOrEmpty(txtPosition.Text))
                return;

            double val = 0.0;
            try
            {
                val = double.Parse(txtPosition.Text);
            }
            catch (Exception)
            {

            }

            TimeSpan timespan = TimeSpan.FromSeconds(val);
            minionPlayer.Position = timespan;
            ShowPosition();
        }

        private void btnScreenshotAddGroup_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot(true, false, false);
        }



        private void SaveScenesToFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveScenario();
        }

        private void LoadOneSceneFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            string fn = null;
            if (ViewModel.CurrentFolder == null) return;
            var files = Directory.GetFiles(ViewModel.CurrentFolder.ItemDirectory, "*.epcatsi");
            if (files.Length == 1)
            {
                fn = files[0];
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = ViewModel.CurrentFolder.ItemDirectory;
                openFileDialog.Filter = "Scenes|*.epcatsi";
                if (openFileDialog.ShowDialog() == true)
                {
                    fn = openFileDialog.FileName;
                }
            }
            if (!string.IsNullOrEmpty(fn))
            {
                ViewModel.LoadScenario(fn, ViewModel.CurrentFolder);
            }
        }




        public void SetGVCurrent(int ind)
        {
            GVCombScen2.View.FocusedRowHandle = GVCombScen2.GetRowHandleByListIndex(ind);
        }

        private void ReloadScenarioFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ReloadScenario();
        }

        private void CompileScenarioBtn_Click(object sender, RoutedEventArgs e)
        {
            SCENARIO.PackScenario(ViewModel.Story, ViewModel.CurrentFolder.ItemDirectory);
        }
        private void CopyGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyGroup(false, true, 0, true);
        }

        private void CopyGroupBtn1_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyGroup(false, false, 0, true);
        }



        private void btnGoGenerate_Click(object sender, RoutedEventArgs e)
        {
            //GenerateScenario(null);
            ViewModel.CompileOne();

        }

        //private void GenerateScenario(EpItem item)
        //{
        //    var fn = ViewModel.GoGenerateScenario(item);
        //    if (!string.IsNullOrEmpty(fn))
        //        ViewModel.LoadScenario(fn, item);
        //}
        //private void btnGoGenerateDefault_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ViewModel.CurrentFolder != null)
        //        GenerateScenario(ViewModel.CurrentFolder);
        //}

        private void CopyGroupBtn2_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyCombinedScene(true);
        }

        private void GVCombScen_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CopyGroupBtn3_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyGroup(false, false, 1, true);
        }

        //private void CopyDescrBtn1_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.CopyPasteDescriptionGroup();
        //}

        private void btnSetPositionSaveSceneVideo_Click(object sender, RoutedEventArgs e)
        {

            if (ViewModel.Story == null)
                return;
            ViewModel.SaveClipTemplate();
            ViewModel.CopyGroup(false, false, 0, true);
            //var col = ViewModel.Story.SceneInfos.Where(x => x.Group == ViewModel.CurrentInfo.Group && x.Kind == 8);
            //if (col.Any())
            //{
            //    col.First().PositionStart = (TicTakToe.ClipTemplate.PositionStart + (decimal)0.1).ToString();
            //    col.First().PositionEnd = (TicTakToe.ClipTemplate.PositionEnd - (decimal)0.1).ToString();
            //    col.First().File = TicTakToe.ClipTemplate.File;
            //}
            //else
            //{
            ViewModel.AddCombinedScene(false, true, 0, 8, true);
            //}
            ViewModel.RefreshFolder();

        }
        private void MainGridView_HiddenEditor(object sender, EditorEventArgs e)
        {
            if (ViewModel.CurrentFolder != null)
                ViewModel.CurrentFolder.Edited = true;
        }

        private void btnGoCalculateRating_Click(object sender, RoutedEventArgs e)
        {
            string dd = JAV.CalculateRating(ViewModel._FolderList);
            ViewModel.SetRatingText(dd);
        }

        private void CopyPoster_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentFolder == null) return;
            string poster1 = ViewModel.CurrentFolder.PosterPath.ToLower();
            string poster2 = poster1.Replace(".jpg", "2.jpg");
            if (!File.Exists(poster1)) return;
            BitmapSource bmpCopied = null;
            if (File.Exists(poster2))
                bmpCopied = new BitmapImage(new Uri(poster2));
            else
                bmpCopied = new BitmapImage(new Uri(poster1));
            var tries = 3;
            while (tries-- > 0)
            {
                try
                {
                    // This must be executed on the calling dispatcher.
                    Clipboard.SetImage(bmpCopied);

                }
                catch (COMException)
                {
                    // Windows clipboard is optimistic concurrency. On fail (as in use by another process), retry.
                    Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            }
        }

        private void CopyPosterName_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentFolder == null) return;
            Clipboard.SetText(ViewModel.CurrentFolder.PosterPath);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentFolder == null) return;
            ViewModel.CurrentFolder.ToDelete = !ViewModel.CurrentFolder.ToDelete;
            ViewModel.RefreshFolder();
        }


        private void btnCameraPosition_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CalculateCameraPosition();
        }

        private void btnReformat_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ReformatMotion();
        }

        private void CollapseGroup_Click(object sender, RoutedEventArgs e)
        {
            this.GVCombScen3.CollapseAllGroups();
        }

        private void ExpandGroup_Click(object sender, RoutedEventArgs e)
        {
            this.GVCombScen3.ExpandAllGroups();
        }
        private void btnUpdateJAV_Click(object sender, RoutedEventArgs e)
        {
            JAV.JavUpdate();
        }
        private void btnGoRepeatText3_Click(object sender, RoutedEventArgs e)
        {
            JAV.JavLibraryDo(ViewModel.RepeatedText, ViewModel.RepeatedTextStart, ViewModel.RatingText, 10, 3);

        }

        private void btnJAVbat_Click(object sender, RoutedEventArgs e)
        {
            JAV.JavLibraryMakeBat(ViewModel.RepeatedText);
        }

        private void JAVupdatefiltered_Click(object sender, RoutedEventArgs e)
        {
            StarRating.LoadJAVActress(@"n:\!CATALOG\JAV");
            var list = ViewModel.FolderListView.ToList();
            foreach (var item in list)
            {
                StarRating.SetRating(item);
            }
            ViewModel._Loader.SaveCatalog(ref list);
            Application.Current.MainWindow.Close();
            //List<string> list = new List<string>();
            //for (int i = 0; i < GV.VisibleRowCount; i++)
            //{
            //    int rowHandle = GV.GetRowHandleByVisibleIndex(i);
            //    if (!GV.IsGroupRowExpanded(rowHandle))
            //    {
            //        var val = GV.GetCellValue(rowHandle, gcSerie);
            //        if (val != null)
            //        {
            //            string s = Convert.ToString(val);
            //            if (!list.Contains(s))
            //                list.Add(s);
            //        }
            //    }                              
            //}
            //JAV.UpdateBySerieList(list);
        }

        private void btnScreenshots_Click(object sender, RoutedEventArgs e)
        {
            double pos = 0;
            if (!string.IsNullOrEmpty(txtPosition.Text))
            {
                pos = double.Parse(txtPosition.Text);
            }
            while (sbarPosition.Maximum > pos)
            {
                TimeSpan timespan = TimeSpan.FromSeconds(pos);
                minionPlayer.Position = timespan;
                ShowPosition();
                //Thread.Sleep(300);
                bool ischecked = false;
                if (cbGray.IsChecked.HasValue)
                {
                    ischecked = cbGray.IsChecked.Value;
                }
                this.MadeShot(false, ischecked, false);
                pos = pos + 0.5;
            }
        }

        private void CopyGroupBtn1_10_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ViewModel.CopyGroup(false, false, 0, false);
            }
        }

        private void btnScreenshotSimple_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot(false, false, true);
        }

        private void GoToClip(object sender, RoutedEventArgs e)
        {
            var cadre = ViewModel.CurrentCadre;
            if (ViewModel.CurrentCadre.KindName != "Mov")
            {
                cadre = ViewModel.CurrentGroup.Cadres.Where(x => x.KindName == "Mov").FirstOrDefault();
            }
            if (cadre == null) return;

            var info = cadre.Infos.FirstOrDefault(x => x.KindName == "Mov");

            if (info == null) return;

            double val;
            if (double.TryParse(info.PositionStart, out val))
            {
                if (!string.IsNullOrEmpty(info.File))
                {
                    string clipfile = info.File;
                    if (clipfile.StartsWith("__"))
                    {
                        string filepath = Path.Combine(this.ViewModel.CurrentFolder.ItemDirectory, "parameters.txt");
                        if (File.Exists(filepath))
                        {
                            var lines = File.ReadAllLines(filepath);
                            foreach (string line in lines)
                            {
                                if (!line.StartsWith("//"))
                                {
                                    var vals = line.Split('=');
                                    if (vals[0] == clipfile)
                                    {
                                        clipfile = vals[1];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    NavTabGroup.SelectTabItem(EditTab);
                    if (string.IsNullOrEmpty(ClipFile.Text))
                    {
                        ClipFile.Text = clipfile;

                    }
                    LoadClip(val);
                }
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddGroup();
        }

        private void CopyGroupBtn4_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyCombinedScene(true);
            ViewModel.AddCombinedScene(false, true, 0, -1, true);
            GVCombScen3.RefreshData();
        }

        private void CopyGroupBtn5_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                ViewModel.CopyCombinedScene(true);
                ViewModel.AddCombinedScene(false, true, 0, -1, true);
            }
            GVCombScen3.RefreshData();
        }
        
        public void ReloadDataScenes()
        {
            //GVCombScen2.RefreshData();
            //var si = GVCombScen2.SelectedItem;
            if (GVCombScen2.SelectedItem != null)
            {
                var ddd = CombinedScenGV2.GetSelectedRows().FirstOrDefault();
                if (ddd != null) 
                {
                    GVCombScen2.SelectItem(0);
                    GVCombScen2.SelectItem(ddd.RowHandle);
                }
               
            }

        }

        private void RunScenario_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentFolder == null) return;
            ViewModel.RunScenario();
            ViewModel.LoadScenario(Path.Combine(ViewModel.CurrentFolder.ItemDirectory, $"Generated.epcatsi"), ViewModel.CurrentFolder);            
            
        }
    }
}
