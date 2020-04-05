using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.LayoutControl;
using EPCat.Model;
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

        private CapsItem CLPitem = null;
        private void GroupBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var im = (sender as System.Windows.Controls.Image);
            var s = (im.TemplatedParent as ContentPresenter);
            var s1 = (s.TemplatedParent as DXContentPresenter);

            DevExpress.Xpf.LayoutControl.GroupBox groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)s1.TemplatedParent;



            CapsItem item = groupBox.DataContext as CapsItem;


            FlowLayoutControl flc = (groupBox.Parent as FlowLayoutControl);




            //var itempos = (flc.ItemsSource as ObservableCollection<CapsItem>).Where(x=>x.Id==item.Id).First();
            var pos = (flc.ItemsSource as ObservableCollection<CapsItem>).IndexOf(item);




            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                CLPitem = item;
                e.Handled = true;
                return;
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                //string parentId = Clipboard.GetText().Trim();
                //if (string.IsNullOrEmpty(item.ParentId) && parentId.Length == 41 && parentId.Substring(4, 1) == ".")
                //{
                //    if (!item.ChildList.Any() && item.Id!= parentId) item.ParentId = parentId;
                //}
                if (string.IsNullOrEmpty(item.ParentId) && !item.ChildList.Any())
                {
                    if (CLPitem != null)
                    {
                        item.ParentId = CLPitem.Id;
                        item.Parent = CLPitem;
                        if (!CLPitem.ChildList.Contains(item)) CLPitem.ChildList.Add(item);
                        if (string.IsNullOrEmpty(CLPitem.Name))
                        {
                            CLPitem.Name = CLPitem.ShortId;
                        }
                    }
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt)
            {
                if (!item.ChildList.Any())
                {
                    item.ParentId = null;
                    item.Parent = null;
                    //
                    if (item.Owner != null)
                    {
                        if (!item.Owner.Where(x => x.ParentId == item.Id).Any())
                        {
                            item.Name = null;
                        }
                    }
                }
            }
            else
            {
                groupBox.State = groupBox.State == GroupBoxState.Normal ? GroupBoxState.Maximized : GroupBoxState.Normal;
                e.Handled = true;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    flc.Children[pos + 1].Focus();
                }), System.Windows.Threading.DispatcherPriority.Render);
            }


            RepaintGroupBox(groupBox, true);
        }
        private void GroupBox_NaximizeMinimize(object sender, MouseButtonEventArgs e)
        {
            var im = (sender as System.Windows.Controls.Image);
            var s = (im.TemplatedParent as ContentPresenter);
            var s1 = (s.TemplatedParent as DXContentPresenter);

            DevExpress.Xpf.LayoutControl.GroupBox groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)s1.TemplatedParent;

            CapsItem item = groupBox.DataContext as CapsItem;
            groupBox.State = groupBox.State == GroupBoxState.Normal ? GroupBoxState.Maximized : GroupBoxState.Normal;
            e.Handled = true;
        }

        private void TabPageChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            if (e.NewSelectedItem == TabCaps) this.ViewModel.RefreshCaps();
            else
            {
                this.ViewModel.UpdateCapsFile();
            }
        }

        private void SetCapsMode(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            RefreshCapsMode();
        }
        private void RefreshCapsMode()
        {
           // ViewModel.SetCapsViewMode(rgCapsMode.SelectedIndex);
        }

        private void SetCurrentImagePassort(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            ViewModel.SetCurrentImagePassort(rgCapsPassport.SelectedIndex);

        }


        private void GroupBox_Loaded(object sender, RoutedEventArgs e)
        {
            DevExpress.Xpf.LayoutControl.GroupBox groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)sender;
            RepaintGroupBox(groupBox, true);
        }
        private void GroupBox_Loaded2(object sender, RoutedEventArgs e)
        {
            DevExpress.Xpf.LayoutControl.GroupBox groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)sender;
            RepaintGroupBox(groupBox, false);
        }

        private void RepaintGroupBox(DevExpress.Xpf.LayoutControl.GroupBox gb, bool isHidingAvalible)
        {

            CapsItem item = gb.DataContext as CapsItem;

            if (!string.IsNullOrEmpty(item.ParentId))
            {
                gb.TitleBackground = new SolidColorBrush(Colors.YellowGreen);
                if (isHidingAvalible && this.ViewModel.CapsViewMode == 1)
                {
                    gb.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                if (gb.DataContext != null)
                {
                    if (string.IsNullOrEmpty(item.Name))
                    {
                        gb.TitleBackground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        gb.TitleBackground = new SolidColorBrush(Colors.OrangeRed);
                    }

                    if (isHidingAvalible) gb.Visibility = Visibility.Visible;
                }
            }
        }

        private void ShowHideChildCaps(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Space)
            //{
            //    if (this.rgCapsMode.SelectedIndex == 0) this.rgCapsMode.SelectedIndex = 1;
            //    else this.rgCapsMode.SelectedIndex = 0;
            //    RefreshCapsMode();
            //}
        }

        private void RefreshGroup(object sender, SelectedItemChangedEventArgs e)
        {
            if (!ViewModel.CurrentCapsForGroup.Any()) return;
            foreach (FrameworkElement elem in layoutGroupCaps.Children)
            {

                if (elem.DataContext == ViewModel.CurrentCapsForGroup.First())
                {
                    layoutGroupCaps.MaximizedElement = elem;
                }
            }


        }

        private void Caps_Delete(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsDeletingAllowed)
            {
                var im = (sender as Button);
                var s = (im.TemplatedParent as ContentPresenter);
                var s1 = (s.TemplatedParent as DXContentPresenter);
                DevExpress.Xpf.LayoutControl.GroupBox groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)s1.TemplatedParent;
                if (groupBox.DataContext != null)
                {
                    CapsItem item = groupBox.DataContext as CapsItem;
                    if (!string.IsNullOrEmpty(item.ParentId)) return;
                    if (item.Owner.Where(x => x.ParentId == item.Id).Any()) return;

                    item.Owner.Remove(item);
                    groupBox.DataContext = null;
                    groupBox.Visibility = Visibility.Collapsed;
                    string path = item.ItemPath;
                    item.ItemPath = null;
                    File.Delete(path);
                }
            }
        }

        private void UpdateGroup(object sender, CellValueChangedEventArgs e)
        {
            ViewModel.UpdateGroup();
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
            TimeSpan timespan = TimeSpan.FromSeconds(double.Parse(txtPosition.Text));
            minionPlayer.Position = timespan;
            ShowPosition();
        }
        
        private void btnSaveStart_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnSaveEnd_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnSaveEndAndAdd_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnScreenshot_Click(object sender, RoutedEventArgs e)
        {
            this.MadeShot();
        }
        private void MadeShot()
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

            this.ImportMedia(str3);
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
            (this.DataContext as EpCatViewModel).ClipTemplate.PositionStart = Decimal.Parse(txtPosition.Text);
            txtPositionStart.Text = (this.DataContext as EpCatViewModel).ClipTemplate.PositionStart.ToString();
        }

        private void btnSetPositionEnd_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EpCatViewModel).ClipTemplate.PositionEnd = Decimal.Parse(txtPosition.Text);
            txtPositionEnd.Text = (this.DataContext as EpCatViewModel).ClipTemplate.PositionEnd.ToString();
        }

        private void btnSetPositionReset_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EpCatViewModel).ClipTemplate.PositionStart = 0;
            txtPositionStart.Text = (this.DataContext as EpCatViewModel).ClipTemplate.PositionStart.ToString();

            (this.DataContext as EpCatViewModel).ClipTemplate.PositionEnd = 0;
            txtPositionEnd.Text = (this.DataContext as EpCatViewModel).ClipTemplate.PositionEnd.ToString();
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
           if ((this.DataContext as EpCatViewModel).ClipTemplate.PositionStart == 0)
            {
                btnSetPositionStart_Click(null,null);
            }
           else if ((this.DataContext as EpCatViewModel).ClipTemplate.PositionEnd == 0)
            {
                btnSetPositionEnd_Click(null, null);
                btnSetPositionSave_Click(null, null);
                MadeShot();
            }
        }

        private void AddSceneBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(null);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(6);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneSoundPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(7);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }
        private void AddSceneHeaderBtn_Click(object sender, RoutedEventArgs e)
        {
            //save
            (this.DataContext as EpCatViewModel).AddCombinedScene(1);
            // reset
            (this.DataContext as EpCatViewModel).RefreshFolder();
        }

        private void CopySceneBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EpCatViewModel).CopyCombinedScene();
        }


        private void btnSetPositionSave_Click(object sender, RoutedEventArgs e)
        {

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


        private void MothionGenerate(object sender, RoutedEventArgs e)
        {
            ViewModel.GenerateMotion();
        }

        private void SaveCurrentClipBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveCurrentClipList();
        }
    }
}
