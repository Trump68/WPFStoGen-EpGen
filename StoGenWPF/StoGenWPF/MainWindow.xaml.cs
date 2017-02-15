using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace StoGenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        MediaElement ClipElement;
        
        private MediaPlayer Sound01 = new MediaPlayer();
        private MediaPlayer Sound02 = new MediaPlayer();
        private MediaPlayer Sound03 = new MediaPlayer();
        private MediaPlayer Sound04 = new MediaPlayer();
        private MediaPlayer Sound05 = new MediaPlayer();
        
        public MainWindow()
        {
            InitializeComponent();

            Projector.PicContainer.Clip = this.Clip1;
            Projector.Text = this.TextBox;

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string startfile = null;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) startfile = args[1];

            SGManager.StartMainProc(startfile);


            PictureCadreDS.Visibility = Visibility.Hidden;
            PictureCadreDS.DataContext = Projector.ImageCadre;
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
            else if (e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9) 
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
