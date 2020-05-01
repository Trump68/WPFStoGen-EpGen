using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using StoGenWPF;
using System.Windows.Media.Effects;

namespace StoGen.ModelClasses
{
    public class Projector
    {
        
        public static PicturesControl PicContainer = new PicturesControl();
        //public static List<Tuple<AxWindowsMediaPlayer, LayoutControlItem>> Clips = new List<Tuple<AxWindowsMediaPlayer, LayoutControlItem>>();
        public static List<System.Windows.Media.MediaPlayer> Sound = new List<System.Windows.Media.MediaPlayer>();
        //public static Tuple<RadioGroup, LayoutControlItem> Choice;
        public static System.Windows.Controls.Canvas TextCanvas;
        public static System.Windows.Controls.TextBlock TextBlock1;
        public static System.Windows.Controls.TextBlock TextBlock2;
        public static System.Windows.Controls.TextBlock TextBlock3;
        public static System.Windows.Controls.TextBlock TextBlock4;
        public static System.Windows.Controls.Border Border1;
        public static System.Windows.Controls.Border Border2;
        public static System.Windows.Controls.Border Border3;
        public static System.Windows.Controls.Border Border4;
        public static DropShadowEffect dropShadowEffect1;
        public static DropShadowEffect dropShadowEffect2;
        public static DropShadowEffect dropShadowEffect3;
        public static DropShadowEffect dropShadowEffect4;
        public static System.Windows.Controls.TextBox NumberText;

        private static bool textVisibleEnabled = true;
        public static bool TextVisibleEnabled
        {
            get { return textVisibleEnabled; }
            set
            {

                textVisibleEnabled = value;
                if (textVisibleEnabled)
                {
                    Projector.TextCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    Projector.TextCanvas.Visibility = Visibility.Hidden;
                }
            }
        }
        public static bool TextVisible
        {
            get { return Projector.TextCanvas.Visibility == Visibility.Visible; }
            set
            {                
                if (value && textVisibleEnabled)
                {
                    Projector.TextCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    Projector.TextCanvas.Visibility = Visibility.Hidden;
                }
            }
        }
        public static void SetShadowEffect(bool enabled)
        {
            int val = 0;
            if (enabled) val = 1;
            dropShadowEffect1.Opacity = val;
            dropShadowEffect2.Opacity = val;
            dropShadowEffect3.Opacity = val;
            dropShadowEffect4.Opacity = val;
        }
        public static bool TimerEnabled { get; set; } = true;
        public static bool EndlessVideo { get; set; } = false;
        public static bool EditorMode { get; set; } = false;
       
        private static ImageCadreViewModel imageCadre;
        public static System.Windows.Media.MediaPlayer ClipSound;

        public static ImageCadreViewModel ImageCadre
        {
            get
            {
                if (imageCadre == null)
                    imageCadre = new ImageCadreViewModel();
                return imageCadre;
            }
        }

        public static Window Owner { get; set; }

        private static bool _MovieCtrlVisible = false;
        public static bool MovieCtrlVisible
        {
            get
            {
                return _MovieCtrlVisible;
            }
            set
            {
                _MovieCtrlVisible = value;
                
            }
        }

        public static System.Windows.Window ProjectorWindow { get; set; }

        public static void Clear()
        {
            //Projector.PicContainer.Lci.Parent.Visibility = LayoutVisibility.Never;
            //Projector.Text.Visible = false;
            //Projector.Choice.Item2.Parent.Visibility = LayoutVisibility.Never;

        }
    }
    public class PicturesControl
    {
        public List<System.Windows.Controls.Image> PicList = new List<System.Windows.Controls.Image>();
        public Canvas OwnerCanvas;        
        public MediaElement Clip;
        public Viewbox OwnerViewbox;
    }
}
