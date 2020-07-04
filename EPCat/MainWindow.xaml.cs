using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.LayoutControl;
using EPCat.Model;
using Microsoft.Win32;
using StoGen.Classes;
using StoGen.Classes.Scene;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            if (PathToGridSave != null)
            {
                PathToGridSave = "D:\temp\temp.xml";
            }
            RestoreLayout(PathToGridSave);
            var CommandArgs = System.Environment.GetCommandLineArgs().ToList();
            if (CommandArgs.Where(x=>x.ToUpper() == "LOAD").Any())
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
            minionPlayer.Pause();
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
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            this.NavTabGroup.SelectedContainer = this.EditTab;
            if ((this.DataContext as EpCatViewModel).CurrentClip == null) return;
            var videos = (this.DataContext as EpCatViewModel).CurrentFolder.Videos;
            if (!videos.Any()) return;
            string path = videos.First();
            (this.DataContext as EpCatViewModel).ClipToProcess = path;
            minionPlayer.MediaOpened -= minionPlayer_MediaOpened;
            minionPlayer.MediaOpened += minionPlayer_MediaOpened;
            if (!string.IsNullOrEmpty((this.DataContext as EpCatViewModel).ClipToProcess))
            {
                minionPlayer.Stop();
                minionPlayer.Source = new Uri((this.DataContext as EpCatViewModel).ClipToProcess);
                minionPlayer.Play();
                minionPlayer.Pause();
            }
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
                minionPlayer.Play();
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
            this.MadeShot();
        }
        private void MadeShot(bool addGroup = false)
        {
            string path = 
                System.IO.Path.GetDirectoryName(this.minionPlayer.Source.LocalPath)
                + System.IO.Path.DirectorySeparatorChar.ToString() + "CLIPCAPS";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str3 = string.Empty;
            if ((this.DataContext as EpCatViewModel).CurrentClip != null)
            {
                int num = 0;
                string str2 = num.ToString("D4");
                str3 = System.IO.Path.Combine(path,$"{str2}.{(this.DataContext as EpCatViewModel).CurrentClip.ID}.jpg");
                while (File.Exists(str3))
                {
                    num++;
                    str2 = num.ToString("D4");
                    str3 = System.IO.Path.Combine(path, $"{str2}.{(this.DataContext as EpCatViewModel).CurrentClip.ID}.jpg");
                }
            }
            else
            {
                path = path + System.IO.Path.DirectorySeparatorChar.ToString() + "SC";

                int num = 0;
                string str2 = num.ToString("D4");
                 str3 = $"{path}-{str2}.jpg";
                while (File.Exists(str3))
                {
                    num++;
                    str2 = num.ToString("D4");
                    str3 = $"{path}-{str2}.jpg";
                }
            }

            TicTakToe.SetClipScreenShot(str3);
            this.ImportMedia(str3);
            if (addGroup)
            {
                this.CopyGroup(true,false,0);
            }
        }
        private void ImportMedia(string path)
        {
            RenderTargetBitmap source = 
                new RenderTargetBitmap(
                    Convert.ToInt32(this.minionPlayer.RenderSize.Width),
                    Convert.ToInt32(this.minionPlayer.RenderSize.Height),
                    96.0,
                    96.0,
                    PixelFormats.Pbgra32);
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
                    this.MadeShot();
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
                btnSetPositionStart_Click(null,null);
            }
           else if (TicTakToe.ClipTemplate.PositionEnd == 0)
            {
                btnSetPositionEnd_Click(null, null);
                btnSetPositionSave_Click(null, null);
                MadeShot();
            }
        }

        private void AddSceneBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true,true,0,null);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundBtn_Click(object sender, RoutedEventArgs e)
        {
            //copy
            (this.DataContext as EpCatViewModel).CopyCombinedScene(false);
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true,false,0,6);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true,false,0,7);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddClipBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(true,false,0,8);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneHeaderBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(false,false,0,1);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneCtrlBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(false, false,0, 10);
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
            CopyGroup(false,false,0);
            //save
            (this.DataContext as EpCatViewModel).SaveClipTemplate();            
            // reset
            btnSetPositionReset_Click(null, null);
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


        public void CopyGroup(bool atEnd, bool toEnd, int group)
        {
            if (atEnd)
            {
                ViewModel.CurrentCombinedScene =
                ViewModel.Story.SceneInfos.LastOrDefault();
            }
            //save
            ViewModel.CopyCombinedScene(true);
            ViewModel.AddCombinedScene(false, toEnd, group, null);
            // reset
            ViewModel.RefreshFolder();
        }
        private void RestoreVideoPosition()
        {
            TimeSpan timespan = TimeSpan.FromSeconds(double.Parse(txtPosition.Text));
            minionPlayer.Position = timespan;
            ShowPosition();
        }

        private void btnScreenshotAddGroup_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot(true);
        }



        private void SaveScenesToFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveScenario();
        }

        private void LoadOneSceneFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ViewModel.CurrentFolder.ItemDirectory;
            openFileDialog.Filter = "Scenes|*.epcatsi";
            if (openFileDialog.ShowDialog() == true)
            {
                ViewModel.LoadScenario(openFileDialog.FileName, ViewModel.CurrentFolder);
            }
        }


        public void SetGVCurrent(int ind)
        {
            GVCombScen.View.FocusedRowHandle = GVCombScen.GetRowHandleByListIndex(ind);
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
            CopyGroup(false, true,0);
        }

        private void CopyGroupBtn1_Click(object sender, RoutedEventArgs e)
        {
            CopyGroup(false, false,0);
        }

        private void btnGoRepeatText_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.GoRepeatText();
        }

        private void btnGoGenerate_Click(object sender, RoutedEventArgs e)
        {
            GenerateScenario(null);
        }
        //private void GenerateScenario(string name)
        //{
        //    var fn = ViewModel.GoGenerateScenario(name);
        //    if (!string.IsNullOrEmpty(fn))
        //            ViewModel.LoadScenario(fn, name);
        //}
        private void GenerateScenario(EpItem item)
        {
            var fn = ViewModel.GoGenerateScenario(item);
            if (!string.IsNullOrEmpty(fn))
                ViewModel.LoadScenario(fn, item);
        }
        private void btnGoGenerateDefault_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentFolder != null)
                GenerateScenario(ViewModel.CurrentFolder);
        }

        private void CopyGroupBtn2_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyCombinedScene(true);
            ViewModel.AddCombinedScene(false, true,0, null);
            // reset
            ViewModel.RefreshFolder();
        }

        private void GVCombScen_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void GVCombScen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && (e.KeyboardDevice.Modifiers == ModifierKeys.Control))
            {
                ViewModel.SaveScenario();
                ViewModel.ShowScene();
            }
        }

        private void CopyGroupBtn3_Click(object sender, RoutedEventArgs e)
        {
            CopyGroup(false, false,1);
        }

        private void CopyDescrBtn1_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyPasteDescriptionGroup();
        }
    }
}
