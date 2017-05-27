using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.LayoutControl;
using EPCat.Model;
using System;
using System.Collections.Generic;
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
    /*
    public class ImageContainer : ContentControlBase
    {
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (Controller.IsMouseLeftButtonDown)
            {
                var layoutControl = Parent as FlowLayoutControl;
                if (layoutControl != null)
                {
                    Controller.IsMouseEntered = false;
                    layoutControl.MaximizedElement = layoutControl.MaximizedElement == this ? null : this;
                }
            }
        }
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            if (!double.IsNaN(Width) && !double.IsNaN(Height))
                if (e.NewSize.Width != e.PreviousSize.Width)
                    Height = double.NaN;
                else
                    Width = double.NaN;
        }
    }
    */
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

        private void GroupBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var im = (sender as System.Windows.Controls.Image);
            var s = (im.TemplatedParent as ContentPresenter);
            var s1 = (s.TemplatedParent as DXContentPresenter);            

            var groupBox = (DevExpress.Xpf.LayoutControl.GroupBox)s1.TemplatedParent;
            groupBox.State = groupBox.State == GroupBoxState.Normal ? GroupBoxState.Maximized : GroupBoxState.Normal;
        }


        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            var layoutControl = (sender as Control).Parent as FlowLayoutControl;
            if (layoutControl != null)
            {
                layoutControl.MaximizedElement = layoutControl.MaximizedElement == (sender as FrameworkElement)? null : (sender as FrameworkElement);
            }
        }

        private void TabPageChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            if (e.NewSelectedItem == TabCaps) this.ViewModel.RefreshCaps();
            else this.ViewModel.UpdateCapsFile();
        }

        private void SetCapsMode(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            ViewModel.SetCapsViewMode(rgCapsMode.SelectedIndex);
        }

        private void SetCurrentImagePassort(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            ViewModel.SetCurrentImagePassort(rgCapsPassport.SelectedIndex);
            
        }
    }
   
}
