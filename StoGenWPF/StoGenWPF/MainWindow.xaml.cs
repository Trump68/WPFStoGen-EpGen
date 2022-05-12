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
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Media;
using StoGenerator;
using StoGen.Classes.Data.Games;
using StoGen.Classes;
using System.Linq;
using StoGen.Classes.Scene;
using StoGen.Classes.SceneCadres;
using StoGenMake;

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
        private MediaPlayer Sound06 = new MediaPlayer();
        private MediaPlayer Sound07 = new MediaPlayer();
        private MediaPlayer Sound08 = new MediaPlayer();
        private MediaPlayer Sound09 = new MediaPlayer();
        private MediaPlayer Sound10 = new MediaPlayer();
        private MediaPlayer Sound11 = new MediaPlayer();
        private MediaPlayer Sound12 = new MediaPlayer();
        private MediaPlayer Sound13 = new MediaPlayer();
        private MediaPlayer Sound14 = new MediaPlayer();
        private MediaPlayer Sound15 = new MediaPlayer();
        private MediaPlayer Sound16 = new MediaPlayer();
        private MediaPlayer Sound17 = new MediaPlayer();
        private MediaPlayer Sound18 = new MediaPlayer();
        private MediaPlayer Sound19 = new MediaPlayer();
        private MediaPlayer Sound20 = new MediaPlayer();
        public BaseScene Scene;
        
        public bool StartOnLoad { get; set; } = true;
        SoundOptions SoundOptionsForm = new SoundOptions();

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

            Projector.TextCanvas2 = this.TextCanvas2;
            Projector.Border21 = this.Brd21;
            Projector.Border22 = this.Brd22;
            Projector.Border23 = this.Brd23;
            Projector.Border24 = this.Brd24;
            Projector.TextBlock21 = this.Tb21;
            Projector.TextBlock22 = this.Tb22;
            Projector.TextBlock23 = this.Tb23;
            Projector.TextBlock24 = this.Tb24;
            Projector.dropShadowEffect21 = (DropShadowEffect)this.Tb21.Effect;
            Projector.dropShadowEffect22 = (DropShadowEffect)this.Tb22.Effect;
            Projector.dropShadowEffect23 = (DropShadowEffect)this.Tb23.Effect;
            Projector.dropShadowEffect24 = (DropShadowEffect)this.Tb24.Effect;

            Projector.TextCanvas3 = this.TextCanvas3;
            Projector.Border31 = this.Brd31;
            Projector.Border32 = this.Brd32;
            Projector.Border33 = this.Brd33;
            Projector.Border34 = this.Brd34;
            Projector.TextBlock31 = this.Tb31;
            Projector.TextBlock32 = this.Tb32;
            Projector.TextBlock33 = this.Tb33;
            Projector.TextBlock34 = this.Tb34;
            Projector.dropShadowEffect31 = (DropShadowEffect)this.Tb31.Effect;
            Projector.dropShadowEffect32 = (DropShadowEffect)this.Tb32.Effect;
            Projector.dropShadowEffect33 = (DropShadowEffect)this.Tb33.Effect;
            Projector.dropShadowEffect34 = (DropShadowEffect)this.Tb34.Effect;

            Projector.TextCanvas4 = this.TextCanvas4;
            Projector.Border41 = this.Brd41;
            Projector.Border42 = this.Brd42;
            Projector.Border43 = this.Brd43;
            Projector.Border44 = this.Brd44;
            Projector.TextBlock41 = this.Tb41;
            Projector.TextBlock42 = this.Tb42;
            Projector.TextBlock43 = this.Tb43;
            Projector.TextBlock44 = this.Tb44;
            Projector.dropShadowEffect41 = (DropShadowEffect)this.Tb41.Effect;
            Projector.dropShadowEffect42 = (DropShadowEffect)this.Tb42.Effect;
            Projector.dropShadowEffect43 = (DropShadowEffect)this.Tb43.Effect;
            Projector.dropShadowEffect44 = (DropShadowEffect)this.Tb44.Effect;


            Projector.NumberText = this.NumberBox;
            Projector.ClipSound = new MediaPlayer();
            Projector.Sound.Add(this.Sound01);
            Projector.Sound.Add(this.Sound02);
            Projector.Sound.Add(this.Sound03);
            Projector.Sound.Add(this.Sound04);
            Projector.Sound.Add(this.Sound05);
            Projector.Sound.Add(this.Sound06);
            Projector.Sound.Add(this.Sound07);
            Projector.Sound.Add(this.Sound08);
            Projector.Sound.Add(this.Sound09);
            Projector.Sound.Add(this.Sound10);
            Projector.Sound.Add(this.Sound11);
            Projector.Sound.Add(this.Sound12);
            Projector.Sound.Add(this.Sound13);
            Projector.Sound.Add(this.Sound14);
            Projector.Sound.Add(this.Sound15);
            Projector.Sound.Add(this.Sound16);
            Projector.Sound.Add(this.Sound17);
            Projector.Sound.Add(this.Sound18);
            Projector.Sound.Add(this.Sound19);
            Projector.Sound.Add(this.Sound20);
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




        private bool isAutonomus = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var CommandArgs = System.Environment.GetCommandLineArgs().ToList();
            if (CommandArgs.Count > 1 && CommandArgs[1].Contains(".epcatsi")) 
            {
                
                string fileToRun = CommandArgs[1];              
                if (!string.IsNullOrEmpty(fileToRun))
                {
                    SCENARIO story = new SCENARIO();
                    List<string> clipsinstr = new List<string>(File.ReadAllLines(fileToRun));
                    story.FullFileName = fileToRun;
                    story.CatalogPath = Path.GetDirectoryName(story.FullFileName);
                    story.FileName = Path.GetFileNameWithoutExtension(fileToRun);                    
                    story.LoadFrom(clipsinstr);                    
                    StoryScene scene = new StoryScene();

                    scene.CatalogPath = Path.GetDirectoryName(fileToRun);
                    List<INFO_SceneCadre> list = new List<INFO_SceneCadre>();
                    foreach (var group in story.GroupList.OrderBy(x => x.Order))
                    {
                        list.AddRange(group.Cadres.OrderBy(x => x.Order));
                    }
                    scene.SetScenario(story, list);
                    GlobalMenuCreator = GameWorldFactory.GameWorld;
                    Scene = scene;
                    StartPageNum = 0;
                    StartOnLoad = true;
                    isAutonomus = true;
                }
                
            }
            if (StartOnLoad)
                this.Start(StartPageNum);           
        }
        static bool paused = false;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (e.Key == Key.Z)
            {
                SGManager.ProcessPrevCadre();
            }
            else if (e.Key == Key.X || e.Key == Key.Enter)
            {
                SGManager.ProcessNextCadre();
                //DoScreenShot(30, false);
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
                //InfoLocation.Visibility = (InfoLocation.Visibility ==Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
                //InfoDate.Visibility = (InfoDate.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
                //DoScreenShot(30, true);
            }
            else if (e.Key == Key.F6)
            {
                if (!SoundOptionsForm.Visible)
                    SoundOptionsForm.ShowDialog();
                else
                    SoundOptionsForm.Hide();
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
                if (FrameImage.LoopProcessed)
                {
                    Projector.PicContainer.Clip.Position = TimeSpan.FromSeconds(FrameImage.ClipStartPos);
                    FrameImage.LoopProcessed = false;
                    Projector.PicContainer.Clip.Play();
                }
                else
                {

                    if (paused)
                        Projector.PicContainer.Clip.Play();

                    else
                        Projector.PicContainer.Clip.Pause();
                    paused = !paused;
                }
            }
            else if (e.Key == Key.F3)
            {
                SGManager.ChangeVisibleChoiceMenu(MenuType.Common); // full
            }
            else if (e.Key == Key.Escape)
            {
                this.Hide();
                Stop();
                if (isAutonomus) this.Close();
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
                            StartPageNum = (--val);
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


        /// <summary>
        /// Take screenshot of a Window.
        /// </summary>
        /// <remarks>
        /// - Usage example: screenshot icon in every window header.                
        /// - Keep well away from any Windows Forms based methods that involve screen pixels. You will run into scaling issues at different
        ///   monitor DPI values. Quote: "Keep in mind though that WPF units aren't pixels, they're device-independent @ 96DPI
        ///   "pixelish-units"; so really what you want, is the scale factor between 96DPI and the current screen DPI (so like 1.5 for
        ///   144DPI) - Paul Betts."
        /// </remarks>
        public async Task<bool> TryScreenshotToClipboardAsync(FrameworkElement frameworkElement, int quality, bool force)
        {
            if (!force)
            {
                var cp = SGManager.CurrProc.Scene.CatalogPath;
                if (!string.IsNullOrEmpty(cp))
                {
                    string scd = Path.Combine(cp, "StoryCaps");
                    string group = SGManager.CurrProc.Scene.CadreDataList[SGManager.CurrProc.CurrentCadreNum()].OriginalInfo[0].Group;
                    string fn = $"{(SGManager.CurrProc.Scene as StoryScene).Story.FileName}-{group}.jpg";
                    fn = Path.Combine(scd, fn);
                    if (File.Exists(fn)) return false;
                }                
            }
            
            frameworkElement.ClipToBounds = true; // Can remove if everything still works when the screen is maximised.

            Rect relativeBounds = VisualTreeHelper.GetDescendantBounds(frameworkElement);
            double areaWidth = frameworkElement.RenderSize.Width; // Cannot use relativeBounds.Width as this may be incorrect if a window is maximised.
            double areaHeight = frameworkElement.RenderSize.Height; // Cannot use relativeBounds.Height for same reason.
            double XLeft = relativeBounds.X;
            double XRight = XLeft + areaWidth;
            double YTop = relativeBounds.Y;
            double YBottom = YTop + areaHeight;
            var bitmap = new RenderTargetBitmap((int)Math.Round(XRight, MidpointRounding.AwayFromZero),
                                                (int)Math.Round(YBottom, MidpointRounding.AwayFromZero),
                                                96, 96, PixelFormats.Default);

            // Render framework element to a bitmap. This works better than any screen-pixel-scraping methods which will pick up unwanted
            // artifacts such as the taskbar or another window covering the current window.
            var dv = new DrawingVisual();
            using (DrawingContext ctx = dv.RenderOpen())
            {
                var vb = new VisualBrush(frameworkElement);
                ctx.DrawRectangle(vb, null, new Rect(new Point(XLeft, YTop), new Point(XRight, YBottom)));
            }
            bitmap.Render(dv);

            return await TryCopyBitmapToFile(bitmap, quality);
        }
        private static async Task<bool> TryCopyBitmapToClipboard(BitmapSource bmpCopied)
        {
            var tries = 3;
            while (tries-- > 0)
            {
                try
                {
                    // This must be executed on the calling dispatcher.
                    Clipboard.SetImage(bmpCopied);
                    return true;
                }
                catch (COMException)
                {
                    // Windows clipboard is optimistic concurrency. On fail (as in use by another process), retry.
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            }
            return false;
        }
        private static async Task<bool> TryCopyBitmapToFile(BitmapSource bmpCopied, int quality)
        {
            try
            {
                
                var cp = SGManager.CurrProc.Scene.CatalogPath;
                if (!string.IsNullOrEmpty(cp))
                {
                    string scd = Path.Combine(cp, "StoryCaps");
                    if (!Directory.Exists(scd))
                    {
                        Directory.CreateDirectory(scd);
                    }
                    string group = SGManager.CurrProc.Scene.CadreDataList[SGManager.CurrProc.CurrentCadreNum()].OriginalInfo[0].Group;
                    string fn = $"{(SGManager.CurrProc.Scene as StoryScene).Story.FileName}-{group}.jpg";
                    fn = Path.Combine(scd,fn);
                    if (File.Exists(fn))
                        File.Delete(fn);
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    BitmapFrame outputFrame = BitmapFrame.Create(bmpCopied);
                    encoder.Frames.Add(outputFrame);
                    encoder.QualityLevel = quality;
                    using (var stream = new FileStream(fn, FileMode.Create))
                    {
                        encoder.Save(stream);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
                    
        }
        public async void DoScreenShot(int quality, bool force)
        {
            try
            {
                var result = await this.TryScreenshotToClipboardAsync(this.MainGrid, quality, force);
                if (result && force)
                {
                    SystemSounds.Beep.Play();
                }

            }
            catch (Exception)
            {
                
            }
        }
    }
    
}
