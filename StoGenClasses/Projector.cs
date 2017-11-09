using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using StoGenWPF;

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

        public static bool TimerEnabled { get; set; } = true;
        public static bool EndlessVideo { get; set; } = false;
        public static bool EditorMode { get; set; } = false;
        private static ImageCadreViewModel imageCadre;
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
