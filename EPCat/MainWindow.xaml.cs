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

namespace EPCat
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       
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
        }
        void Serialization_Loaded(object sender, RoutedEventArgs e)
        {
            RestoreLayout();
        }
        void SaveLayout()
        {
            string commandf = "GridLayout.xml";
            string[] cla = Environment.GetCommandLineArgs();
            if (cla.Length > 2) commandf = cla[2];

            this.GV.SaveLayoutToXml(commandf);
        }
        void RestoreLayout()
        {
            try
            {
                string commandf = "GridLayout.xml";
                string[] cla = Environment.GetCommandLineArgs();
                if (cla.Length > 2) commandf = cla[2];
                this.GV.RestoreLayoutFromXml(commandf);
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
            ViewModel.Close();
            SaveLayout();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
                Dispatcher.BeginInvoke(new Action(() => {
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
            ViewModel.SetCapsViewMode(rgCapsMode.SelectedIndex);
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
           if (e.Key == Key.Space)
            {
                if (this.rgCapsMode.SelectedIndex == 0) this.rgCapsMode.SelectedIndex = 1;
                else this.rgCapsMode.SelectedIndex = 0;
                RefreshCapsMode();
            }
        }

        private void RefreshGroup(object sender, SelectedItemChangedEventArgs e)
        {
            if (!ViewModel.CurrentCapsForGroup.Any()) return;
            foreach (FrameworkElement elem in layoutGroupCaps.Children)
            {
                
                if (elem.DataContext == ViewModel.CurrentCapsForGroup.First())
                {
                    layoutGroupCaps.MaximizedElement= elem;
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
    }
   
}
