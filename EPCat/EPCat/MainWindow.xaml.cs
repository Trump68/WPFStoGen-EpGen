using DevExpress.Xpf.Grid;
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
            this.GV.SaveLayoutToXml("GridLayout.xml");         
        }
        void RestoreLayout()
        {
            try
            {
                this.GV.RestoreLayoutFromXml("GridLayout.xml");
            }
            catch (Exception)
            {               
            }
            
        }
        private void MainWindow_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ViewModel.UpdateCurrentItem();
        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ProcessScriptFile();
            this.GV.RefreshData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Close();
            SaveLayout();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
