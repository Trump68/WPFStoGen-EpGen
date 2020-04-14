using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;

namespace StoGen.Classes
{
    [Serializable]
    public class PictureItem
    {
        public Image image { get; set; }
        public PictureSourceProps Props { get; set; }
        public PictureItem()
        {
            this.Props = new PictureSourceProps();
        }    
    }
    public class PictureSourceDataProps : PictureSourceProps
    {

        public PictureSourceDataProps():base()
        {

        }

        public PictureSourceDataProps(string fnname)
            : base(fnname)
        {

        }

        public PictureSourceDataProps(string fnname, PictureProps position): base(fnname,position)
        {

        }
        
        public string RawData { get; set; }
        
    }
    public class PictureSourceProps : PictureProps
    {
        internal bool SizeChanged = false;

        

        //public System.Windows.Point ScreenCenter { get; internal set; }

        public PictureSourceProps() : base() { } 
        public PictureSourceProps(PictureProps sourceApperance)
            : this()
        {
            this.Assign(sourceApperance);
        }
        public PictureSourceProps(PictureSourceProps sourceApperance)
            : this()
        {
            this.Assign(sourceApperance);
        }
        public void Assign(PictureProps sourceApperance)
        {
            if (sourceApperance.X !=0) this.X = sourceApperance.X;
            if (sourceApperance.Y != 0) this.Y = sourceApperance.Y;
            if (sourceApperance.SizeX != 0) this.SizeX = sourceApperance.SizeX;
            if (sourceApperance.SizeY != 0) this.SizeY = sourceApperance.SizeY;
            this.Z = sourceApperance.Z;
            this.Level = sourceApperance.Level;
            this.Rotate = sourceApperance.Rotate;
            this.Align = sourceApperance.Align;
            this.SizeMode = sourceApperance.SizeMode;
            this.BackColor = sourceApperance.BackColor;
            this.BackFileName = sourceApperance.BackFileName;
            this.NextCadre = sourceApperance.NextCadre;
            this.Opacity = sourceApperance.Opacity;
            this.SetName = sourceApperance.SetName;
            this.Flip = sourceApperance.Flip;
            this.Merge = sourceApperance.Merge;
            this.Timer = sourceApperance.Timer;
            this.Timer2 = sourceApperance.Timer2;
            this.Blur = sourceApperance.Blur;
            this.isVideo = sourceApperance.isVideo;
            this.Active = sourceApperance.Active;
            this.OnlyName = sourceApperance.OnlyName;
            this.Description = sourceApperance.Description;
            this.isMain = sourceApperance.isMain;
            this.Reload = sourceApperance.Reload;
            this.Flash = sourceApperance.Flash;
            this.ClipH = sourceApperance.ClipH;
            this.ClipW = sourceApperance.ClipW;
            this.ClipX = sourceApperance.ClipX;
            this.ClipY = sourceApperance.ClipY;
            this.Transition = sourceApperance.Transition;
            this.ParFlip = sourceApperance.ParFlip;
            this.Animations.Clear();
            this.Animations.AddRange(sourceApperance.Animations);
            this.Parent = sourceApperance.Parent;
        }
        public void Assign(PictureSourceProps sourceApperance)
        {
            this.Assign(sourceApperance as PictureProps);
            this.FileName = sourceApperance.FileName;
        }
        public PictureSourceProps(string fn, PictureProps sourceApperance)
            : this(sourceApperance)
        {
            this.FileName = fn;
        }
        public PictureSourceProps(string fn)
            : this()
        {
            this.FileName = fn;
        }

    }

    public class PictureProps : PictureBaseProp
    {
      
        public string FileName { get; set; }
        private string _Name = string.Empty;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_Name))
                {
                    return this.FileName;
                }
                return _Name;
            }
            set { _Name = value; }
        }
        public string Description = string.Empty;
        public string OnlyName
        {
            get
            {
                return _Name;
            }
            set { _Name = value; }
        }
        public string Parent { get; set; }
        internal string SetName { get; set; }
        public bool AutoShift { get; set; }
        

        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public bool ScreenStretch { get; set; } = false;
        public int Opacity { get; set; } = 100;
    
        public double NextCadre { get; set; }

        public int Rotate { get; set; }

        public int Zoom
        {
            get { return Z; }
            set { Z = value; }
        }
        public ContentAlignment Align { get; set; }
        public PictureSizeMode SizeMode { get; set; }
        public string BackFileName { get; set; }
        public System.Drawing.Color BackColor { get; set; }
        public RotateFlipType Flip { get; set; }


        public PictureProps()
        {
            BackColor = System.Drawing.Color.Transparent;
            this.Align = ContentAlignment.TopLeft;
            this.SizeMode = PictureSizeMode.Clip;
            this.Zoom = 100;
            this.Rotate = 0;
            //this.RateMax = AnimationRate.VeryFast;
            //this.RateMin = AnimationRate.VerySlow;
            //this.Rate = AnimationRate.Default;
            this.Flip = RotateFlipType.RotateNoneFlipNone;
        }
        internal bool isMain = false;
        public string Flash = null;
        public string Transition = null;
        public string ParFlip = null;
        public List<AP> Animations = new List<AP>();
        private AP _CurrentAnimation;
        public AP CurrentAnimation
        {
            get
            {
                if (_CurrentAnimation == null)
                {
                    _CurrentAnimation = Animations.FirstOrDefault();
                }
                return _CurrentAnimation;
            }
        }
    }
    public class AP
    {
        public AP() { }
        public AP(string file):this()
        {
            this.File = file;
        }
        public string File { set; get; }
        public int AR { set; get; } = 100;//animation ratio
        public int AV { set; get; } = 100;//animation volume
        public double APS { set; get; } //animation start pos
        public double APE { set; get; } //animation end pos
        public int AWS { set; get; } //animation wait start
        public int AWE { set; get; } //animation wait end
        public int ALM { set; get; } = -1;//animation loop mode
        public int ALC { set; get; } = 0; //loop count, 0 - endless
        public string Source { get; set; } = null;
    }
    public class PictureBaseProp
    {
        public PictureBaseProp()
        {

        }
        public PictureBaseProp(int x, int y, int zoom, PicLevel level)
        {
            this.X = x;
            this.Y = y;
            this.Z = zoom;
            this.Level = level;
        }
        public double ClipW { get; set; }
        public double ClipH { get; set; }
        public double ClipX { get; set; }
        public double ClipY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public PicLevel Level { get; set; } = PicLevel.None;
        public bool Merge = false;
        public int Timer = 0;
        public int Timer2 = 0;
        public int Blur = 0;
        public bool isVideo = false;
        public bool Active = true;
        public bool Reload = false;
    }

    public enum PicLevel : int
    {
        None = -1,
        Background = 0,
        OnBackground = 1,
        UnderActor0 = 2,
        Actor0 = 3,
        OnActor0 = 4,
        UnderActor1 = 5,
        Actor1 = 6,
        OnActor1 = 7,
        UnderActor2 = 8,
        Actor2 = 9,
        OnActor2 = 10,
        Foreground = 11,
        L01 =12,
        L02 = 13,
        L03 = 14,
        L04 = 15,
        L05 = 16,
        L06 = 17,
        L07 = 18,
        L08 = 19,
        L09 = 20
    }

    public static class ImageHelper
    {
      
        public static Bitmap Blur(Image image, Int32 blurSize)
        {            
            return Blur(new Bitmap(image), new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }
        public static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    Int32 avgR = 0, avgG = 0, avgB = 0;
                    Int32 blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (Int32 x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (Int32 y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            System.Drawing.Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (Int32 x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        for (Int32 y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                            blurred.SetPixel(x, y, System.Drawing.Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
        /// <summary>
        /// method to rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise
        /// negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new System.Drawing.Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
        public static Image ChangeColor(Image img, System.Drawing.Color colorfrom, System.Drawing.Color colorto)
        {

            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

        // Set the image attribute's color mappings
        ColorMap[] colorMap = new ColorMap[1];
        colorMap[0] = new ColorMap();
        colorMap[0].OldColor = colorfrom;
        colorMap[0].NewColor = colorto;
        ImageAttributes attr = new ImageAttributes();
        attr.SetRemapTable(colorMap);
        // Draw using the color map
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        gfx.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);


            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new System.Drawing.Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
        public static Bitmap CombineBitmap(string[] files)
        {
            //read all images into memory
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    //create a Bitmap from the file and add it to the list
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

                    //update the size of the final bitmap
                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Transparent);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                       // offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
        public static Image ResizeImage(Image imgToResize, System.Drawing.Size size)
        {

            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
     
        public static void Test()
        {
            //GifHelper gh = new GifHelper();            
            
        }
        

    }
    public enum AnimationRate : int
    {
        Random = -1,
        Default = 0,
        VeryFast = 1,
        Fast1 = 2,
        Fast2 = 3,
        Fast3 = 4,
        Medium1 = 5,
        Medium2 = 6,
        Medium3 = 7,
        Slow1 = 8,
        Slow2 = 9,
        Slow3 = 10,
        VerySlow = 11
    }

    public class ImageTools
    {
        public static Bitmap GrayScaleFilter(Image image)
        {
            Bitmap grayScale = new Bitmap(image.Width, image.Height);
            Bitmap SourceImage = new Bitmap(image);

            for (Int32 y = 0; y < grayScale.Height; y++)
                for (Int32 x = 0; x < grayScale.Width; x++)
                {
                    System.Drawing.Color c = SourceImage.GetPixel(x, y);

                    Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    grayScale.SetPixel(x, y, System.Drawing.Color.FromArgb(gs, gs, gs));
                }
           
            return grayScale;
        }
        public static Image FastBlur(Image im, int radius)
        {
            Bitmap SourceImage = new Bitmap(im);
            var rct = new Rectangle(0, 0, SourceImage.Width, SourceImage.Height);
            var dest = new int[rct.Width * rct.Height];
            var source = new int[rct.Width * rct.Height];
            var bits = SourceImage.LockBits(rct, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Marshal.Copy(bits.Scan0, source, 0, source.Length);
            SourceImage.UnlockBits(bits);

            if (radius < 1) return SourceImage;

            int w = rct.Width;
            int h = rct.Height;
            int wm = w - 1;
            int hm = h - 1;
            int wh = w * h;
            int div = radius + radius + 1;
            var r = new int[wh];
            var g = new int[wh];
            var b = new int[wh];
            int rsum, gsum, bsum, x, y, i, p1, p2, yi;
            var vmin = new int[max(w, h)];
            var vmax = new int[max(w, h)];

            var dv = new int[256 * div];
            for (i = 0; i < 256 * div; i++)
            {
                dv[i] = (i / div);
            }

            int yw = yi = 0;

            for (y = 0; y < h; y++)
            { // blur horizontal
                rsum = gsum = bsum = 0;
                for (i = -radius; i <= radius; i++)
                {
                    int p = source[yi + min(wm, max(i, 0))];
                    rsum += (p & 0xff0000) >> 16;
                    gsum += (p & 0x00ff00) >> 8;
                    bsum += p & 0x0000ff;
                }
                for (x = 0; x < w; x++)
                {

                    r[yi] = dv[rsum];
                    g[yi] = dv[gsum];
                    b[yi] = dv[bsum];

                    if (y == 0)
                    {
                        vmin[x] = min(x + radius + 1, wm);
                        vmax[x] = max(x - radius, 0);
                    }
                    p1 = source[yw + vmin[x]];
                    p2 = source[yw + vmax[x]];

                    rsum += ((p1 & 0xff0000) - (p2 & 0xff0000)) >> 16;
                    gsum += ((p1 & 0x00ff00) - (p2 & 0x00ff00)) >> 8;
                    bsum += (p1 & 0x0000ff) - (p2 & 0x0000ff);
                    yi++;
                }
                yw += w;
            }

            for (x = 0; x < w; x++)
            { // blur vertical
                rsum = gsum = bsum = 0;
                int yp = -radius * w;
                for (i = -radius; i <= radius; i++)
                {
                    yi = max(0, yp) + x;
                    rsum += r[yi];
                    gsum += g[yi];
                    bsum += b[yi];
                    yp += w;
                }
                yi = x;
                for (y = 0; y < h; y++)
                {
                    dest[yi] = (int)(0xff000000u | (uint)(dv[rsum] << 16) | (uint)(dv[gsum] << 8) | (uint)dv[bsum]);
                    if (x == 0)
                    {
                        vmin[y] = min(y + radius + 1, hm) * w;
                        vmax[y] = max(y - radius, 0) * w;
                    }
                    p1 = x + vmin[y];
                    p2 = x + vmax[y];

                    rsum += r[p1] - r[p2];
                    gsum += g[p1] - g[p2];
                    bsum += b[p1] - b[p2];

                    yi += w;
                }
            }

            // copy back to image
            var bits2 = SourceImage.LockBits(rct, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            SourceImage.UnlockBits(bits);
            return SourceImage;

        }

        private static int min(int a, int b) { return Math.Min(a, b); }
        private static int max(int a, int b) { return Math.Max(a, b); }
    }
}
