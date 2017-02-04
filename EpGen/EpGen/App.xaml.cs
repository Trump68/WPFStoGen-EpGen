using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EpGen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            
            // Create the ViewModel       
            MVVMApp.ViewModels.ECadreListViewModel listViewModel = new MVVMApp.ViewModels.ECadreListViewModel();           
           
            // Load data
            listViewModel.LoadFile();           
            listViewModel.ScenarioFileName = ConfigurationManager.AppSettings["ScenarioFileName"];
            listViewModel.PicTemplate = ConfigurationManager.AppSettings["PicTemplate"];
            listViewModel.SoundTemplate = ConfigurationManager.AppSettings["SoundTemplate"];
            listViewModel.TextTemplate = ConfigurationManager.AppSettings["TextTemplate"];
            listViewModel.AddNewSetTemplate = ConfigurationManager.AppSettings["AddNewSetTemplate"];

            listViewModel.LinkForPicsTemplate = ConfigurationManager.AppSettings["LinkForPicsTemplate"];
            listViewModel.CompanyNum = ConfigurationManager.AppSettings["CompanyNum"];
            listViewModel.SeriePrefix = ConfigurationManager.AppSettings["SeriePrefix"];
            listViewModel.StartId = ConfigurationManager.AppSettings["StartId"];
            listViewModel.EndId = ConfigurationManager.AppSettings["EndId"];
            listViewModel.SavePicToDir = ConfigurationManager.AppSettings["SavePicToDir"];
            listViewModel.TemplateDigits = ConfigurationManager.AppSettings["TemplateDigits"];
            listViewModel.ClipToProcess = ConfigurationManager.AppSettings["ClipToProcess"];
            listViewModel.ScrollFactor1 = (int.Parse((ConfigurationManager.AppSettings["ScrollFactor1"])));
            listViewModel.ScrollFactor2 = (int.Parse((ConfigurationManager.AppSettings["ScrollFactor2"])));


            MVVMApp.Views.ViewList view = new MVVMApp.Views.ViewList();
            view.DataContext = listViewModel;
            view.Show();

            Application.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
           // AddUpdateAppSettings("ScenarioFileName", "fff");
        }
       
    }
}
