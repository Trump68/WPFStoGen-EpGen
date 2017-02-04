using MVVMApp.Commands;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMApp.ViewModels
{
    internal class ECadreListViewModel : ViewModelBase
    {
        //ProcedureBase procedure;
        public ECadreListViewModel()
        {

        }
        #region Exposed props

        private ICollectionView eCadres;
        public ICollectionView ECadres
        {
            get { return eCadres; }
        }
        private string scenarioFileName;
        public string ScenarioFileName
        {
            get { return scenarioFileName; }
            set
            {
                scenarioFileName = value;

                OnPropertyChanged("ScenarioFileName");
            }
        }
        public string PicTemplate { get; set; }
        public string SoundTemplate { get; set; }
        public string TextTemplate { get; set; }
        public string AddNewSetTemplate { get; set; }
        private string _AddNewSet;
        public string AddNewSet
        {
            get
            {
                return _AddNewSet;
            }
            set
            {
                _AddNewSet = value;
                OnPropertyChanged("AddNewSet");
            }
        }

        string addNewSetResult;
        public string AddNewSetResult
        {
            get { return addNewSetResult; }
            set
            {
                addNewSetResult = value;
                OnPropertyChanged("AddNewSetResult");
            }
        }
        #endregion
        #region Commands
        private ICommand addCadreCommand;
        private ICommand deleteCadreCommand;
        private ICommand saveCadreListCommand;
        private ICommand loadFileCommand;
        private ICommand saveFileCommand;
        private ICommand getSeriePicsCommand;
        public ICommand LoadFileCommand
        {
            get
            {
                if (loadFileCommand == null)
                {
                    loadFileCommand = new DelegateCommand(LoadFile, CanLoadFile);
                }
                return loadFileCommand;
            }
        }
        public ICommand SaveFileCommand
        {
            get
            {
                if (saveFileCommand == null)
                {
                    saveFileCommand = new DelegateCommand(SaveFile, CanSaveFile);
                }
                return saveFileCommand;
            }
        }
        public ICommand AddCadreCommand
        {
            get
            {
                if (addCadreCommand == null)
                {
                    addCadreCommand = new DelegateCommand(AddCadre, CanAddCadre);
                }
                return addCadreCommand;
            }
        }
        public ICommand DeleteCadreCommand
        {
            get
            {
                if (deleteCadreCommand == null)
                {
                    deleteCadreCommand = new DelegateCommand(DeleteCadre, CanDeleteCadre);
                }
                return deleteCadreCommand;
            }
        }
        public ICommand SaveCadreListCommand
        {
            get
            {
                if (saveCadreListCommand == null)
                {
                    saveCadreListCommand = new DelegateCommand(SaveFile, CanSaveCadreList);
                }
                return saveCadreListCommand;
            }
        }

        public ICommand GetSeriePicsCommand
        {
            get
            {
                if (getSeriePicsCommand == null)
                {
                    getSeriePicsCommand = new DelegateCommand(GetSeriePics);
                }
                return getSeriePicsCommand;
            }
        }

        private ICommand createFilmografyCommand;
        public ICommand CreateFilmografyCommand
        {
            get
            {
                if (createFilmografyCommand == null)
                {
                    createFilmografyCommand = new DelegateCommand(CreateFimmografy);
                }
                return createFilmografyCommand;
            }
        }
        private ICommand copySetsCommand;
        public ICommand CopySetsCommand
        {
            get
            {
                if (copySetsCommand == null)
                {
                    copySetsCommand = new DelegateCommand(CopySets);
                }
                return copySetsCommand;
            }
        }
        private ICommand copyPosStrCommand;
        public ICommand CopyPosStrCommand
        {
            get
            {
                if (copyPosStrCommand == null)
                {
                    copyPosStrCommand = new DelegateCommand(CopyPosStr);
                }
                return copyPosStrCommand;
            }
        }
        

        public string LinkForPicsTemplate { get; set; }
        public string CompanyNum { get; set; }
        public string SeriePrefix { get; set; }
        public string StartId { get; set; }
        public string EndId { get; set; }
        private string currentId;
        public string CurrentId
        {
            get { return currentId; }
            set
            {
                currentId = value;
                OnPropertyChanged("CurrentId");
            }
        }

        public string SavePicToDir { get; set; }
        public string TemplateDigits { get; set; }
        public string ClipToProcess { get; set; }
        public int ScrollFactor1 { get; set; }
        public int ScrollFactor2 { get; set; }
        #endregion
        #region Command handlers and data processing

        public void AddCadre()
        {
            if ((eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().Any())
            {
                SaveFile();
            }
            int lastMarkCounter = 0;
            (eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().ForEach(x =>
            {
                if (x.Mark.StartsWith("M") && x.Mark.Length == 4)
                {
                    int val = Convert.ToInt32(x.Mark.Remove(0, 1));
                    if (val > lastMarkCounter) lastMarkCounter = val;
                }
            }
            );


            Model.ECadre cadre = new Model.ECadre() { PicTemplate = this.PicTemplate, SoundTemplate = this.SoundTemplate, TextTemplate = this.TextTemplate };
            cadre.Mark = $"M{(++lastMarkCounter).ToString("000")}";


            PictureSourceDataProps pp = new PictureSourceDataProps();

            if ((eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().Any())
            {
                pp.StartPos = ((eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().Last().EndPos);
                pp.EndPos = pp.StartPos;
            }
            cadre.PicData.Add(pp);

            cadre.SoundData.Add(new SoundItem());

            TextData td = new TextData();
            if ((eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().Any())
            {
                ECadreViewModel ecvm = (eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().Last();
                if (!string.IsNullOrWhiteSpace(ecvm.Text) && ecvm.Text.Length > 1 && ecvm.Text != ecvm.Mark)
                {
                    td.TextList.Add(ecvm.Text);
                }
                else
                {
                    td.TextList.Add(cadre.Mark);
                }

            }
            else
            {
                td.TextList.Add(cadre.Mark);
            }

            cadre.TextFrameData.Add(td);

            VMBusinessLogic.AddCadre(eCadres, cadre);
            eCadres.MoveCurrentToLast();
        }
        private void DeleteCadre()
        {
            VMBusinessLogic.DeleteCadre(eCadres);
        }

        internal void LoadFile()
        {
            eCadres = VMBusinessLogic.GetCadres(ScenarioFileName, eCadres);
            if (!string.IsNullOrEmpty(ScenarioFileName)) AddUpdateAppSettings("ScenarioFileName", ScenarioFileName);
            this.ECadres.CurrentChanged += ECadres_CurrentChanged;
        }

        public Action RefreshStart;
        private void ECadres_CurrentChanged(object sender, EventArgs e)
        {
            this.AddNewSet = GetCurrentNewSet(eCadres.CurrentItem as ECadreViewModel);
            if (RefreshStart != null) RefreshStart.Invoke();
        }

        internal void SaveFile()
        {
            VMBusinessLogic.SaveCadres(ScenarioFileName, eCadres);
            if (!string.IsNullOrEmpty(this.PicTemplate)) AddUpdateAppSettings("PicTemplate", this.PicTemplate);
            if (!string.IsNullOrEmpty(this.SoundTemplate)) AddUpdateAppSettings("SoundTemplate", this.SoundTemplate);
            if (!string.IsNullOrEmpty(this.TextTemplate)) AddUpdateAppSettings("TextTemplate", this.TextTemplate);
            if (!string.IsNullOrEmpty(this.AddNewSetTemplate)) AddUpdateAppSettings("AddNewSetTemplate", this.AddNewSetTemplate);
            if (!string.IsNullOrEmpty(this.ClipToProcess)) AddUpdateAppSettings("ClipToProcess", this.ClipToProcess);
            AddUpdateAppSettings("ScrollFactor1", this.ScrollFactor1.ToString());
            AddUpdateAppSettings("ScrollFactor2", this.ScrollFactor2.ToString());

          
        }
        
        internal void CopyPosStr()
        {
            Clipboard.SetText($"{(eCadres.CurrentItem as ECadreViewModel).StartPos};EndPos={(eCadres.CurrentItem as ECadreViewModel).EndPos}");
        }
        internal void CopySets()
        {
            (eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).ToList().ForEach(x =>
            {
                AddNewSetResult = $"{AddNewSetResult}{Environment.NewLine}{GetCurrentNewSet(x)}";
            }
           );
            Clipboard.SetText(AddNewSetResult);
        }
        private string GetCurrentNewSet(ECadreViewModel x)
        {
            if (x == null) return null;
            string txt = x.Text;
            if (txt.Length > 30)
                txt = txt.Substring(0,30) + "...";
            return $"{AddNewSetTemplate.Replace("$FN0", txt).Replace("$FN1", "\t\t\t\t\t").Replace("$FN2", Path.GetFileName(ScenarioFileName)).Replace("$FN3", "null").Replace("$FN4", x.Mark).Replace(@"'", @"""")}";
        }
        internal void CreateFimmografy()
        {
            VMBusinessLogic.CreateFimmografy();
        }

        internal void GetSeriePics()
        {

            if (!string.IsNullOrEmpty(this.CompanyNum)) AddUpdateAppSettings("CompanyNum", this.CompanyNum);
            AddUpdateAppSettings("SeriePrefix", this.SeriePrefix);
            if (!string.IsNullOrEmpty(this.StartId)) AddUpdateAppSettings("StartId", this.StartId);
            if (!string.IsNullOrEmpty(this.EndId)) AddUpdateAppSettings("EndId", this.EndId);
            if (!string.IsNullOrEmpty(this.LinkForPicsTemplate)) AddUpdateAppSettings("LinkForPicsTemplate", this.LinkForPicsTemplate);
            if (!string.IsNullOrEmpty(this.SavePicToDir)) AddUpdateAppSettings("SavePicToDir", this.SavePicToDir);


            int CurrId = Convert.ToInt32(StartId);
            int LastId = Convert.ToInt32(EndId);

            while (CurrId <= LastId)
            {
                string CurrentFileId = CurrId.ToString("000");
                CurrentId = CurrId.ToString("000");
                string CurrentId2 = CurrId.ToString("00");
                string localFilename = $@"d:\temp\5\{SeriePrefix.ToUpper()}-{CurrentFileId}.jpg";




                string address = LinkForPicsTemplate.Replace("$FN0", CompanyNum).Replace("$FN1", SeriePrefix.ToLower()).Replace("$FN2", CurrentId);
                if (!File.Exists(localFilename))
                {
                    bool ok = false;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if ((response.ContentLength > 10000))
                        {
                            SaveFileToD(response, localFilename);
                            ok = true;
                        }

                    }
                    if (!ok)
                    {
                        address = LinkForPicsTemplate.Replace("$FN0", CompanyNum).Replace("$FN1", SeriePrefix.ToLower()).Replace("$FN2", CurrentId2);
                        request = (HttpWebRequest)WebRequest.Create(address);
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            if ((response.ContentLength > 10000))
                            {
                                SaveFileToD(response, localFilename);
                            }
                        }
                    }
                }
                CurrId++;
            }


        }


        private void SaveFileToD(HttpWebResponse response, string localFilename)
        {
            // if the remote file was found, download oit
            using (Stream inputStream = response.GetResponseStream())
            using (Stream outputStream = File.OpenWrite(localFilename))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                do
                {
                    bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                    outputStream.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);
            }
        }

        private bool CanAddCadre()
        {
            return true;
        }
        private bool CanDeleteCadre()
        {
            return !eCadres.IsEmpty;
        }
        private bool CanSaveCadreList()
        {
            return true;
        }
        private bool CanLoadFile()
        {
            return true;
        }
        private bool CanSaveFile()
        {
            return true;
        }
        #endregion



        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
