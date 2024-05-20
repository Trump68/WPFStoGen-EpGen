using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.ConditionalFormatting.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EPCat
{
    public class StandardIconSetFormatInfoExExtension : StandardIconSetFormatInfoExtension
    {


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var key = (new FormatThemeKeyExExtension() { ResourceKey = FormatName }).ProvideValue(serviceProvider);
            var formatInfo = new FormatInfoEx(GetDescription(), GetGroupName());
            formatInfo.FormatName = this.FormatName;
            formatInfo.Format = new StaticResourceExtension(key).ProvideValue(serviceProvider);
            //formatInfo.DisplayName = ConditionalFormattingLocalizer.GetString((ConditionalFormattingStringId)Enum.Parse(typeof(ConditionalFormattingStringId), (GetStringIdPrefix() + FormatName)));
            formatInfo.DisplayName = "AB Icons";
            formatInfo.Icon = GetIcon();
            formatInfo.GroupName = "AB";
                //Description = GetDescription(),
                //GroupName = GetGroupName(),
            
            formatInfo.Freeze();
            return formatInfo;
        }

    }

    public class FormatInfoEx : FormatInfo
    {
        public FormatInfoEx(string description, string group)
        {
            this.Description = description;
            this.GroupName = group;
        }
    }

    public class FormatThemeKeyExExtension : FormatThemeKeyExtension { }

    public class QuickIconSetFormatExExtension : QuickIconSetFormatExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var format = new IconSetFormat();
            TryPopulate(format);
            format.Freeze();
            return format;
        }

        public string NameEx { get; set; }

        void TryPopulate(IconSetFormat format)
        {
            if (ElementCount == 0 || string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(NameEx))
                return;
            foreach (var index in Enumerable.Range(0, ElementCount))
            {
                var element = new IconSetElement();
                element.Threshold = 100d * (ElementCount - 1 - index) / ElementCount;
                  BitmapImage bi = new BitmapImage();
                  bi.BeginInit();
                  bi.UriSource = new Uri(Path + NameEx + (index + 1).ToString() + ".png", UriKind.Absolute);
                  bi.DecodePixelHeight = 20;
                  bi.EndInit();
                  element.Icon = bi;                
                format.Elements.Add(element);
            }
            format.IconSetType = XlIconSetType;
        }
    }

}
