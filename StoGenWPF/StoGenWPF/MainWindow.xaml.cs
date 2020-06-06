using StoGen.Classes.Interfaces;
using StoGen.ModelClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using StoGenMake.Scenes.Base;
using System.Windows.Media.Effects;
using System.IO;
using System.Collections.Generic;
using Menu.Classes;

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
        
        public bool StartOnLoad { get; set; } = true;

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
            Projector.Border1 = this.Brd1;
            Projector.Border2 = this.Brd2;
            Projector.Border3 = this.Brd3;
            Projector.Border4 = this.Brd4;
            Projector.dropShadowEffect1 = (DropShadowEffect)this.Tb1.Effect;
            Projector.dropShadowEffect2 = (DropShadowEffect)this.Tb2.Effect;
            Projector.dropShadowEffect3 = (DropShadowEffect)this.Tb3.Effect;
            Projector.dropShadowEffect4 = (DropShadowEffect)this.Tb4.Effect;
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
            Projector.PicContainer.PicList.Add(this.Picture17);
            Projector.PicContainer.PicList.Add(this.Picture18);
            Projector.PicContainer.PicList.Add(this.Picture19);
            Projector.PicContainer.PicList.Add(this.Picture20);
            Projector.PicContainer.PicList.Add(this.Picture21);
            Projector.PicContainer.PicList.Add(this.Picture22);
            Projector.PicContainer.PicList.Add(this.Picture23);
            Projector.PicContainer.PicList.Add(this.Picture24);
            Projector.PicContainer.PicList.Add(this.Picture25);
            Projector.PicContainer.PicList.Add(this.Picture26);
            Projector.PicContainer.PicList.Add(this.Picture27);
            Projector.PicContainer.PicList.Add(this.Picture28);
            Projector.PicContainer.PicList.Add(this.Picture29);
            Projector.PicContainer.PicList.Add(this.Picture30);
            Projector.PicContainer.PicList.Add(this.Picture31);
            Projector.PicContainer.PicList.Add(this.Picture32);
            Projector.PicContainer.PicList.Add(this.Picture33);
            Projector.PicContainer.PicList.Add(this.Picture34);
            Projector.PicContainer.PicList.Add(this.Picture35);
            Projector.PicContainer.PicList.Add(this.Picture36);
            Projector.PicContainer.PicList.Add(this.Picture37);
            Projector.PicContainer.PicList.Add(this.Picture38);
            Projector.PicContainer.PicList.Add(this.Picture39);
            Projector.PicContainer.PicList.Add(this.Picture40);
            Projector.PicContainer.OwnerCanvas = this.CanvasControl;
            Projector.PicContainer.OwnerViewbox = this.ViewboxControl;
            
        }

        
        
    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartOnLoad)
                this.Start(StartPageNum);           
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
            else if (e.Key == Key.F7)
            {
                InfoLocation.Visibility = (InfoLocation.Visibility ==Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
                InfoDate.Visibility = (InfoDate.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            else if (e.Key == Key.OemPeriod)
            {
                var p = Projector.PicContainer.Clip.Position;
                p = p.Add(new TimeSpan(0, 0, 20));
                Projector.PicContainer.Clip.Position = p;

            }
            else if (e.Key == Key.OemComma)
            {
                var p = Projector.PicContainer.Clip.Position;
                p = p.Subtract(new TimeSpan(0, 0, 20));
                Projector.PicContainer.Clip.Position = p;
            }
            else if (e.Key == Key.Q)
            {
                
            }           
           
            else if (e.Key == Key.Space)
            {
                SGManager.ChangeVisibleChoiceMenu(MenuType.Cell); // move
            }
            else if (e.Key == Key.F3)
            {
                SGManager.ChangeVisibleChoiceMenu(MenuType.Common); // full
            }
            else if (e.Key == Key.Enter)
            {
                SGManager.ApplayVisibleChoiceMenu(); 
            }
            else if (e.Key == Key.Escape)
            {
                this.Hide();
                Stop();             
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

        private static string startfile;
        private static int StartPageNum = 1;
        private static bool FixPageNum = false;
        private static string GetIniFile(string file)
        {
            string backupath = Path.Combine(Path.GetDirectoryName(file), "_TMP");
            if (!Directory.Exists(backupath))
                Directory.CreateDirectory(backupath);
            string fileoptions = Path.Combine(backupath, Path.GetFileName(Path.ChangeExtension(file, ".ini")));
            return fileoptions;
        }
        public static void ReadIni(string file)
        {
            if (string.IsNullOrEmpty(file)) return;
            startfile = file;
            string fileoptions = GetIniFile(file);
            if (File.Exists(fileoptions))
            {
                List<string> textlist = new List<string>(File.ReadAllLines(fileoptions));
                foreach (var item in textlist)
                {
                    if (item.StartsWith("PAGE="))
                    {
                        int val;
                        if (int.TryParse(item.Replace("PAGE=", string.Empty), out val))
                        {
                            StartPageNum = val;
                        }
                    }
                    else if (item.StartsWith("FIXPAGE="))
                    {
                        int val;
                        if (int.TryParse(item.Replace("FIXPAGE=", string.Empty), out val))
                        {
                            FixPageNum = (val==1);
                        }
                    }

                }
            }
        }
        public static void WriteIni()
        {
            if (FixPageNum) return;
            if (string.IsNullOrEmpty(startfile)) return;
            string fileoptions = GetIniFile(startfile);
            List<string> lines = new List<string>();
            lines.Add($"PAGE={SGManager.CurrProc.CurrentCadreNum()+1}");
            lines.Add($"FIXPAGE=0");
            File.WriteAllLines(fileoptions, lines);          
        }
        public static void Stop()
        {
            SGManager.Stop();
            Projector.ClipSound.Stop();
            Projector.PicContainer.Clip.Stop();
            foreach (var item in Projector.Sound)
            {
                item.Stop();
            }
            
            WriteIni();
        }
        public void Start(int startpage)
        {
            PictureCadreDS.Visibility = Visibility.Hidden;
            PictureCadreDS.DataContext = Projector.ImageCadre;
            InfoLocation.DataContext = Projector.ImageCadre;
            InfoDate.DataContext = Projector.ImageCadre;
            SGManager.StartMainProc(Scene, startpage);
        }
        public void Start()
        {
            Start(0);
        }
    }
}
