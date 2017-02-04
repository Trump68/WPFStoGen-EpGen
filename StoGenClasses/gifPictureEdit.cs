using DevExpress.Utils;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Extension
{


    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemGifPictureEdit : RepositoryItemPictureEdit
    {

        //The static constructor that calls the registration method 
        static RepositoryItemGifPictureEdit() { RegisterCustomEdit(); }

        //Initialize new properties 
        public RepositoryItemGifPictureEdit()
        {
            //useDefaultMode = true;
        }

        //The unique name for the custom editor 
        public const string GifPictureEditName = "gifPictureEdit";

        //Return the unique name 
        public override string EditorTypeName { get { return GifPictureEditName; } }

        //Register the editor 
        public static void RegisterCustomEdit()
        {
            //Icon representing the editor within a container editor's Designer 
            //Image img = null;
            //try
            //{
            //    img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
            //      GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            //}
            //catch
            //{
            //}
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(GifPictureEditName,
              typeof(gifPictureEdit), typeof(RepositoryItemGifPictureEdit),
              typeof(gifPictureEditViewInfo), new PictureEditPainter(), false, null));
        }


    }

     [ToolboxItem(true)]
    public class gifPictureEdit : PictureEdit
    {
        public string FileName= string.Empty;
        public bool CadreLoaded = false;
         //The static constructor that calls the registration method 
        static gifPictureEdit() { RepositoryItemGifPictureEdit.RegisterCustomEdit(); }
          //Initialize the new instance 
        public gifPictureEdit():base()
        {
            isLoop = false;

        }
        public int ShiftX
        {
            get { return this.ViewInfo.ShiftX; }
            set 
            {
                this.ViewInfo.ShiftX = value; 
            }
        }
        public int ShiftY
        {
            get { return this.ViewInfo.ShiftY; }
            set { this.ViewInfo.ShiftY = value; }
        }

        public int Rate
        {
            get { return this.ViewInfo.Rate; }
            set { this.ViewInfo.Rate = value; }
        }

         public bool isLoop 
         {
             get { return this.ViewInfo.isLoop; }
             set { this.ViewInfo.isLoop = value; }
         }

         public EventHandler OnStop
         {
             get { return this.ViewInfo.OnStop; }
             set { this.ViewInfo.OnStop = value; }
         }
         protected internal new gifPictureEditViewInfo ViewInfo 
        {
            get
            {
                return base.ViewInfo as gifPictureEditViewInfo; 
            } 
        }
        //Return the unique name 
        public override string EditorTypeName
        {
            get
            {
                return
                    RepositoryItemGifPictureEdit.GifPictureEditName;
            }
        }

        //Override the Properties property 
        //Simply type-cast the object to the custom repository item type 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemGifPictureEdit Properties
        {
            get { return base.Properties as RepositoryItemGifPictureEdit; }
        }
    }

     public class gifPictureEditViewInfo : PictureEditViewInfo, IHeightAdaptable, IAnimatedItem, ISupportXtraAnimationEx, ISupportContextItems
    {
         public gifPictureEditViewInfo(RepositoryItem item)
			: base(item) {
		}
        public bool isLoop = false;
        AnimationType AnimationType {
            get 
            {
                if (isLoop) return DevExpress.Utils.Drawing.Animation.AnimationType.Cycle;
                else  return AnimationType.Simple;
            } 
        }
         public EventHandler OnStop;
         public int ShiftX { get; set; }
         public int ShiftY { get; set; }
         public int Rate { get; set; }
         protected override void CalcContentRect(Rectangle bounds)
         {
             base.CalcContentRect(bounds);
             fContentRect.X += ShiftX;
             fContentRect.Y += ShiftY;
             CalcPictureBounds();
		 }
         int[] IAnimatedItem.AnimationIntervals
         { 
             get 
             {
                 if (Rate == 0) return ImageHelper.AnimationIntervals;
                 List<int> intervals = new List<int>();
                 foreach (int item in ImageHelper.AnimationIntervals)
                 {
                     intervals.Add(Rate * 100000);
                 }
                 return intervals.ToArray(); 
             } 
         }
         int IAnimatedItem.AnimationInterval
         { 
             get 
             {
                 if (Rate == 0) return ImageHelper.AnimationInterval;
                 return Rate * 100000; 
             } 
         }
         protected override void OnImageAnimation(BaseAnimationInfo animInfo)
        {
            IAnimatedItem animItem = this;
            EditorAnimationInfo info = animInfo as EditorAnimationInfo;
            if (Image == null || OwnerEdit == null || info == null) return;
            if (!info.IsFinalFrame)
            {
                Image.SelectActiveFrame(FrameDimension.Time, info.CurrentFrame);
                OwnerEdit.Invalidate(animItem.AnimationBounds);
                info.AnimationType = AnimationType;
            }
            else
            {
                StopAnimation();
                if (info.AnimationType == AnimationType.Cycle)
                {
                    StartAnimation(); 
                }
                else
                {
                    if (this.OnStop!=null) OnStop(null,EventArgs.Empty);
                }
            }
        }
    }
}
