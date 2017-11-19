using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGen.Classes;
using System.Windows.Input;
using MVVMApp.Commands;
using MVVMApp.Model;

namespace MVVMApp.ViewModels
{
    internal class ECadreViewModel : ViewModelBase
    {
        internal ECadre ecadre;
        public ECadreViewModel(ECadre ecadre)
        {
            this.ecadre = ecadre;
        }
        #region Exposed props
        public string Mark
        {
            get { return ecadre.Mark; }
            set
            {
                ecadre.Mark = value;
                OnPropertyChanged("Mark");
            }
        }
        
        //public int StartPos_H
        //{
        //    get { return TimeSpan.FromSeconds(StartPos).Hours; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours(value);
        //        TimeSpan valM = TimeSpan.FromMinutes((TimeSpan.FromSeconds(StartPos).Minutes));
        //        TimeSpan valS = TimeSpan.FromSeconds((TimeSpan.FromSeconds(StartPos).Seconds));
        //        ecadre.PicData[0].StartPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("StartPos_H");
        //        OnPropertyChanged("StartPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public int EndPos_H
        //{
        //    get { return TimeSpan.FromSeconds(EndPos).Hours; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours(value);
        //        TimeSpan valM = TimeSpan.FromMinutes((TimeSpan.FromSeconds(EndPos).Minutes));
        //        TimeSpan valS = TimeSpan.FromSeconds((TimeSpan.FromSeconds(EndPos).Seconds));
        //        //ecadre.PicData[0].EndPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("EndPos_H");
        //        OnPropertyChanged("EndPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public int StartPos_M
        //{
        //    get { return TimeSpan.FromSeconds(StartPos).Minutes; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours((TimeSpan.FromSeconds(StartPos).Hours));
        //        TimeSpan valM = TimeSpan.FromMinutes(value);
        //        TimeSpan valS = TimeSpan.FromSeconds((TimeSpan.FromSeconds(StartPos).Seconds));
        //       // ecadre.PicData[0].StartPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("StartPos_M");
        //        OnPropertyChanged("StartPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public int EndPos_M
        //{
        //    get { return TimeSpan.FromSeconds(EndPos).Minutes; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours((TimeSpan.FromSeconds(EndPos).Hours));
        //        TimeSpan valM = TimeSpan.FromMinutes(value);
        //        TimeSpan valS = TimeSpan.FromSeconds((TimeSpan.FromSeconds(EndPos).Seconds));
        //        //ecadre.PicData[0].EndPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("EndPos_M");
        //        OnPropertyChanged("EndPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public int StartPos_S
        //{
        //    get { return TimeSpan.FromSeconds(StartPos).Seconds; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours((TimeSpan.FromSeconds(StartPos).Hours));
        //        TimeSpan valM = TimeSpan.FromMinutes((TimeSpan.FromSeconds(StartPos).Minutes));
        //        TimeSpan valS = TimeSpan.FromSeconds(value);
        //        ecadre.PicData[0].StartPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("StartPos_S");
        //        OnPropertyChanged("StartPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public int EndPos_S
        //{
        //    get { return TimeSpan.FromSeconds(EndPos).Seconds; }
        //    set
        //    {
        //        TimeSpan valH = TimeSpan.FromHours((TimeSpan.FromSeconds(EndPos).Hours));
        //        TimeSpan valM = TimeSpan.FromMinutes((TimeSpan.FromSeconds(EndPos).Minutes));
        //        TimeSpan valS = TimeSpan.FromSeconds(value);
        //        //ecadre.PicData[0].EndPos = (valH + valM + valS).TotalSeconds;
        //        OnPropertyChanged("EndPos_S");
        //        OnPropertyChanged("EndPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public double StartPos
        //{
        //    get { return ecadre.PicData[0].StartPos; }
        //    set
        //    {
        //        ecadre.PicData[0].StartPos = value;
        //        OnPropertyChanged("StartPos");
        //        OnPropertyChanged("Length");
        //    }
        //}
        //public double EndPos
        //{
        //    get { return ecadre.PicData[0].EndPos; }
        //    set
        //    {
        //        ecadre.PicData[0].EndPos = value;
        //        OnPropertyChanged("EndPos");
        //        OnPropertyChanged("Length");
        //    }
        //}

        //public int Length
        //{
        //    get { return (int)(ecadre.PicData[0].EndPos - ecadre.PicData[0].StartPos); }          
        //}
        public string MainFileName
        {
            get { return ecadre.MainFileName; }
            set
            {
                ecadre.MainFileName = value;
                OnPropertyChanged("MainFileName");
            }
        }
        public string Text
        {
            get { return ecadre.Text; }
            set
            {
                ecadre.Text = value;
            }
        }
        //public string TextSplitted
        //{
        //    get
        //    {
        //        return ecadre.Text.Replace("~",Environment.NewLine);
        //    }
        //    set
        //    {
        //        ecadre.Text = value.Replace(Environment.NewLine, "~");
        //        //OnPropertyChanged("TextSplitted");
        //        OnPropertyChanged("Text");
        //    }
        //}
        #endregion

        #region Commands
        private ICommand dumeCommand;
        public ICommand DumeCommand
        {
            get
            {
                if (dumeCommand == null)
                {
                    dumeCommand = new DelegateCommand(DoDume, CanDoDume);
                }
                return dumeCommand;
            }
        }
        #endregion

        #region Command handlers and data operations
        private void DoDume()
        {
            //VMBusinessLogic.UpdateCustomer(customer);
        }
        private bool CanDoDume()
        {
            return true;
        }
        #endregion
    }
}
