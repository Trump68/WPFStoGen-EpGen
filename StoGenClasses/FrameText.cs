using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraLayout.Utils;
using StoGen.ModelClasses;
//using System.Drawing;
//using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Word;
using DevExpress.XtraRichEdit.API.Native;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace StoGen.Classes
{
    public class FrameText : Frame
    {
        public List<string> TextList { get; set; }
        public string Text
        {
            set
            {
                TextList.Clear();
                TextList.Add(value);
            }
        }
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public Color BackColor { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Bottom { get; set; }
        public int Shift { get; set; }
        public int Aligh { get; set; }
        public bool ClearBack { get; set; } = false;
        public FrameText() : base()
        {
            TextList = new List<string>();
            //BackColor = Color.PaleGoldenrod;
        }
        public override Cadre Repaint()
        {
            
            base.Repaint();
            if (Rtf)
            {
                //Projector.Text.RtfText = string.Join(Environment.NewLine, TextList.ToArray());
            }
            else
            {
               
                /*if (TextList.Count == 1)
                {
                    Projector.Text.Appearance.Text.Options.UseFont = false;
                    Projector.Text.Appearance.Text.Options.UseForeColor = false;
                    Projector.Text.Appearance.Text.Options.UseTextOptions = false;
                    Projector.Text.HtmlText = TextList[0];
                }
                else*/
                {
                   // Projector.Text.Appearance.Text.Options.UseFont = true;
                   // Projector.Text.Appearance.Text.Options.UseForeColor = true;
                   // Projector.Text.Appearance.Text.Options.UseTextOptions = true;

                    //Projector.Text.Text = string.Join(Environment.NewLine, TextList.ToArray());

                  
                }
              

            }
            if (Size > 0)
            {
                Projector.Text.Height = Size;
                if (Width>0) Projector.Text.Width = Width;
                else Projector.Text.Width = 800;
                double bm = Bottom;                
                double tm = Projector.Text.Margin.Top;
                Projector.Text.Margin  = new System.Windows.Thickness(Shift, tm, Projector.Text.Margin.Right, bm);
            }






            if (!ClearBack)
                Projector.Text.Background = new SolidColorBrush(this.BackColor);
            else
                Projector.Text.Background = null;
            if (!string.IsNullOrWhiteSpace(FontName))
            {
                FontFamily font = new FontFamily(FontName);
                Projector.Text.FontFamily = font;
            }
            if (FontSize > 0)
            {
                Projector.Text.FontSize = FontSize;
            }

            if (Aligh == 1)
            {
                Projector.Text.TextAlignment = System.Windows.TextAlignment.Right;
            }
            else if (Aligh == 0)
            {
                Projector.Text.TextAlignment = System.Windows.TextAlignment.Left;
            }
            else if (Aligh == 2)
            {
                Projector.Text.TextAlignment = System.Windows.TextAlignment.Center;
            }            
            Projector.Text.Text = string.Join(Environment.NewLine, TextList.ToArray());
            if (!string.IsNullOrEmpty(FontColor))
            {
                if (FontColor == "Black")
                    Projector.Text.Foreground = Brushes.Black;
                else if (FontColor == "White")
                    Projector.Text.Foreground = Brushes.White;
                else if (FontColor == "Red")
                    Projector.Text.Foreground = Brushes.Red;
                else if (FontColor == "Blue")
                    Projector.Text.Foreground = Brushes.Blue;
                else if (FontColor == "Yellow")
                    Projector.Text.Foreground = Brushes.Yellow;
            }


            Projector.TextVisible = true;
            return this.Owner;
        }
        public bool AutoShow { get; set; }
        public override void SetVisible(bool show)
        {
            
                Projector.TextVisible = show;


        }
        internal void ProcessKey(Key e)
        {
            /*
            if (e.KeyCode == Keys.F12)
            {
                this.FontName = FontHelper.GetNextFont(this.FontName);
            }
            else if (e.KeyCode == Keys.F11)
            {
                this.BackColor = FontHelper.GetNextColor(this.BackColor);
            }
            else { return; }
            Repaint();
            */
        }
        public bool Html { get; set; }
        public bool Rtf { get; set; }
    }
    public class TextData
    {
        public TextData()
        {
            TextList = new List<string>();
            BackColor = Colors.Tan;
            AutoShow = true;
            Rtf = false;
        }
        public List<string> TextList;
        public string FileName;
        internal string Part;
        internal string Name;

        public string FontName { get; set; }
        public int FontSize { get; set; }
        public Color BackColor { get; set; }
        public int Size { get; set; }
        public int Shift { get; set; } = 200;
        public bool AutoShow { get; set; }
        public bool Rtf { get; set; }
        public bool Html { get; set; }
        public int Align { get; internal set; }
        public string RawData { get; set; }
        public int Width { get; internal set; }
        public bool ClearBack { get; internal set; }
        public int Bottom { get; internal set; }
        public string FontColor { get; internal set; }

        public void LoadfromFile(string fn)
        {            
            List<string> tt = Universe.LoadFileToStringList(fn);
            LoadfromStringList(tt);
        }
        public void LoadfromStringList(List<string> data)
        {
            if (!string.IsNullOrEmpty(Part))
            {
                bool found = false;
                foreach (string item in data)
                {
                    if (!found && !item.StartsWith(@"@@" + Part) && !item.StartsWith(@"#" + Part))
                    {
                        continue;
                    }
                    if (!found)
                    {
                        found = true;
                        continue;
                    }
                    if (item.StartsWith(@"@@") || item.StartsWith(@"#")) break;
                    this.TextList.Add(item);
                }

            }
            else
            {
                this.TextList = data;
            }

        }
    }
    static class FontHelper
    {
        private static List<string> _fonts = new List<string>()
        {
            "Mon Amour One",
            "Mon Amour Two",
            "Majestic",
            "Menuet script",
            "VivaldiD CL",
            "Venski sad One",
            "Rosamunda Two",
            "Margarita script",
            "Classica One",
            "Bikham Cyr Script",
            "Bolero script",
            "1 Balmoral LET Plain1.0",
            "DisneyPark",//Disney
            "Shlapak Script",//Gothic
            "PaladinPCRus Medium",//Gothic
            "Deutsch Gothic",//Gothic
            "CyrillicGoth Medium", //Gothic
            "ChinaCyr", //china
            "AsylbekM29.kz",//arabic
            "DS Arabic", //arabic
            "Devanagari Normal",//alien
            "SpriteGraffitiShadow",//graffity
            "SpriteGraffiti",//graffity
            "NfS MW",//graffity
            "RAZMAHONT Bold",//graffity
            "Liana",//decor
            "m_Brody",//decor
            "RupsterScriptFree",//decor
            "AngryBirds Regular",//decor
            "Victoriana",//decor
            "Xiomara",//decor
            "a_Romanus",//decor
            "Korinna Normal-Italic",//decor
            "Korinna_SU Italic",//decor
            "ER Architect 1251",//decor
            "Briolin"//decor
        };

        public static string GetNextFont(string current)
        {
            int pos = _fonts.IndexOf(current);
            if (pos == (_fonts.Count - 1)) pos = 0;
            else pos++;
            return _fonts[pos];
        }

        public static Color GetNextColor(Color current)
        {
            return current;
            /*
            List<string> fontnames = new List<string>();
            fontnames.AddRange(Enum.GetNames(typeof(KnownColor)));
            int pos = fontnames.IndexOf(current.Name);
            if (pos == (fontnames.Count - 1)) pos = 0;
            else pos++;
            return Color.FromName(fontnames[pos]);
            */
        }

    }

}
