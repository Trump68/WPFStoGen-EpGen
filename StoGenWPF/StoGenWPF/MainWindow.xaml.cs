using StoGen.Classes.Interfaces;
using StoGen.ModelClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using StoGenMake.Scenes.Base;

namespace StoGenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public IMenuCreator GlobalMenuCreator = null;
        MediaElement ClipElement;
        

        private MediaPlayer Sound01 = new MediaPlayer();
        private MediaPlayer Sound02 = new MediaPlayer();
        private MediaPlayer Sound03 = new MediaPlayer();
        private MediaPlayer Sound04 = new MediaPlayer();
        private MediaPlayer Sound05 = new MediaPlayer();
        public BaseScene Scene;

        

        public MainWindow()
        {
            InitializeComponent();
            Projector.Owner = this;
            Projector.PicContainer.Clip = this.Clip1;
            Projector.TextCanvas = this.TextCanvas;
            Projector.TextBlock1 = this.Tb1;
            Projector.TextBlock2 = this.Tb2;
            Projector.TextBlock3 = this.Tb3;
            Projector.TextBlock4 = this.Tb4;
            Projector.NumberText = this.NumberBox;
            Projector.ClipSound = new MediaPlayer();
            Projector.Sound.Add(this.Sound01);
            Projector.Sound.Add(this.Sound02);
            Projector.Sound.Add(this.Sound03);
            Projector.Sound.Add(this.Sound04);
            Projector.Sound.Add(this.Sound05);
            Projector.PicContainer.PicList.Add(this.Picture1);
            Projector.PicContainer.PicList.Add(this.Picture2);
            Projector.PicContainer.PicList.Add(this.Picture3);
            Projector.PicContainer.PicList.Add(this.Picture4);
            Projector.PicContainer.PicList.Add(this.Picture5);
            Projector.PicContainer.PicList.Add(this.Picture6);
            Projector.PicContainer.PicList.Add(this.Picture7);
            Projector.PicContainer.PicList.Add(this.Picture8);
            Projector.PicContainer.PicList.Add(this.Picture9);
            Projector.PicContainer.PicList.Add(this.Picture10);
            Projector.PicContainer.PicList.Add(this.Picture11);
            Projector.PicContainer.PicList.Add(this.Picture12);
            Projector.PicContainer.PicList.Add(this.Picture13);
            Projector.PicContainer.PicList.Add(this.Picture14);
            Projector.PicContainer.PicList.Add(this.Picture15);
            Projector.PicContainer.PicList.Add(this.Picture16);
            Projector.PicContainer.OwnerCanvas = this.CanvasControl;
            Projector.PicContainer.OwnerViewbox = this.ViewboxControl;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            PictureCadreDS.Visibility = Visibility.Hidden;
            PictureCadreDS.DataContext = Projector.ImageCadre;

            SGManager.StartMainProc(Scene, GlobalMenuCreator);
            
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (e.Key == Key.Z)
            {
                SGManager.ProcessPrevCadre();
            }
            else if (e.Key == Key.X)
            {
                SGManager.ProcessNextCadre();
            }
            else if (e.Key == Key.F12)
            {
                Projector.TextVisibleEnabled = !Projector.TextVisibleEnabled;
            }
            else if (e.Key == Key.F11)
            {
                Projector.TimerEnabled = !Projector.TimerEnabled;
                LmpAuto.Visibility =  !Projector.TimerEnabled ?  Visibility.Visible :  Visibility.Hidden;
               
            }
            else if (e.Key == Key.F9)
            {
                Projector.EndlessVideo = !Projector.EndlessVideo;
                LmpEndless.Visibility = Projector.EndlessVideo ? Visibility.Visible : Visibility.Hidden;
            }
            else if (e.Key == Key.F8)
            {
                Projector.EditorMode = !Projector.EditorMode;
                PictureCadreDS.Visibility = Projector.EditorMode ? Visibility.Visible : Visibility.Hidden;
            }
            else if (e.Key == Key.Q)
            {
                
            }           
           
            else if (e.Key == Key.Space)
            {
               
            }
            else if (e.Key == Key.F3)
            {
                SGManager.ChangeVisibleChoiceMenu();
            }
            else if (e.Key == Key.Enter)
            {
                SGManager.ApplayVisibleChoiceMenu();
            }
            else if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (
                e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 
                || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9
                || e.Key == Key.A || e.Key == Key.S || e.Key == Key.D || e.Key == Key.F || e.Key == Key.G || e.Key == Key.H || e.Key == Key.J || e.Key == Key.K
                || e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4
                || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9
                || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right
                || e.Key == Key.OemPlus || e.Key == Key.OemMinus || e.Key == Key.OemComma || e.Key == Key.OemPeriod
                )
            {
                SGManager.ProcessKey(e.Key);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
