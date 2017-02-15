using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit;
using StoGen.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxWMPLib;
using PerPixelAlphaBlend;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using StoGenWPF;

namespace StoGen.ModelClasses
{
    public class Projector
    {
        public static void SetPng(Bitmap png)
        {
            PerPixelAlphaForm TestForm = new PerPixelAlphaForm();
            TestForm.Width = 500;
            TestForm.Height = 500;
            TestForm.TopMost = true;
            TestForm.Show();
            TestForm.SetBitmap(png, 255);
        }
        public static PicturesControl PicContainer = new PicturesControl();
        //public static List<Tuple<AxWindowsMediaPlayer, LayoutControlItem>> Clips = new List<Tuple<AxWindowsMediaPlayer, LayoutControlItem>>();
        public static List<System.Windows.Media.MediaPlayer> Sound = new List<System.Windows.Media.MediaPlayer>();
        //public static Tuple<RadioGroup, LayoutControlItem> Choice;
        public static System.Windows.Controls.TextBox Text;

        private static bool textVisibleEnabled = true;
        public static bool TextVisibleEnabled
        {
            get { return textVisibleEnabled; }
            set
            {

                textVisibleEnabled = value;
                if (textVisibleEnabled)
                {
                    Projector.Text.Visibility = Visibility.Visible;
                }
                else
                {
                    Projector.Text.Visibility = Visibility.Hidden;
                }
            }
        }
        public static bool TextVisible
        {
            get { return Projector.Text.Visibility == Visibility.Visible; }
            set
            {                
                if (value && textVisibleEnabled)
                {
                    Projector.Text.Visibility = Visibility.Visible;
                }
                else
                {
                    Projector.Text.Visibility = Visibility.Hidden;
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
        //public List<PerPixelAlphaForm> FormList = new List<PerPixelAlphaForm>();
        //   public LayoutControlItem Lci;
        public MediaElement Clip;
    }
}
