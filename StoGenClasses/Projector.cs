﻿using System.Collections.Generic;
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

        public static System.Windows.Controls.Canvas TextCanvas2;
        public static System.Windows.Controls.TextBlock TextBlock21;
        public static System.Windows.Controls.TextBlock TextBlock22;
        public static System.Windows.Controls.TextBlock TextBlock23;
        public static System.Windows.Controls.TextBlock TextBlock24;
        public static System.Windows.Controls.Border Border21;
        public static System.Windows.Controls.Border Border22;
        public static System.Windows.Controls.Border Border23;
        public static System.Windows.Controls.Border Border24;
        public static DropShadowEffect dropShadowEffect21;
        public static DropShadowEffect dropShadowEffect22;
        public static DropShadowEffect dropShadowEffect23;
        public static DropShadowEffect dropShadowEffect24;

        public static System.Windows.Controls.Canvas TextCanvas3;
        public static System.Windows.Controls.TextBlock TextBlock31;
        public static System.Windows.Controls.TextBlock TextBlock32;
        public static System.Windows.Controls.TextBlock TextBlock33;
        public static System.Windows.Controls.TextBlock TextBlock34;
        public static System.Windows.Controls.Border Border31;
        public static System.Windows.Controls.Border Border32;
        public static System.Windows.Controls.Border Border33;
        public static System.Windows.Controls.Border Border34;
        public static DropShadowEffect dropShadowEffect31;
        public static DropShadowEffect dropShadowEffect32;
        public static DropShadowEffect dropShadowEffect33;
        public static DropShadowEffect dropShadowEffect34;

        public static System.Windows.Controls.Canvas TextCanvas4;
        public static System.Windows.Controls.TextBlock TextBlock41;
        public static System.Windows.Controls.TextBlock TextBlock42;
        public static System.Windows.Controls.TextBlock TextBlock43;
        public static System.Windows.Controls.TextBlock TextBlock44;
        public static System.Windows.Controls.Border Border41;
        public static System.Windows.Controls.Border Border42;
        public static System.Windows.Controls.Border Border43;
        public static System.Windows.Controls.Border Border44;
        public static DropShadowEffect dropShadowEffect41;
        public static DropShadowEffect dropShadowEffect42;
        public static DropShadowEffect dropShadowEffect43;
        public static DropShadowEffect dropShadowEffect44;

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
                    //Projector.TextCanvas2.Visibility = Visibility.Visible;
                }
                else
                {
                    Projector.TextCanvas.Visibility = Visibility.Hidden;
                    //Projector.TextCanvas2.Visibility = Visibility.Hidden;
                }
            }
        }
        public static void SetShadowEffect(bool enabled, DropShadowEffect ef1, DropShadowEffect ef2, DropShadowEffect ef3, DropShadowEffect ef4)
        {
            int val = 0;
            if (enabled) val = 1;
            ef1.Opacity = val;
            ef2.Opacity = val;
            ef3.Opacity = val;
            ef4.Opacity = val;
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
        //public MediaElement Clip2;
        public Viewbox OwnerViewbox;
    }
}
