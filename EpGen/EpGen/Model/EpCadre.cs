using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.Model
{
    internal class ECadre
    {
        Cadre cadre;
        public ECadre() { }
        public ECadre(Cadre cadre) { this.cadre = cadre; }
        #region Exposed props
        //private string mainFileName;
        public string MainFileName
        {
            get
            {
                
                return this.PicData.FirstOrDefault().FileName;
            }
            set
            {
                if (!this.PicData.Any())
                    this.PicData.Add(new PictureSourceDataProps());
                this.PicData.FirstOrDefault().FileName = value;
            }
        }
        public string Text
        {
            get
            {

                return string.Join("~",this.TextFrameData.FirstOrDefault().TextList.ToArray());
            }
            set
            {
                if (!this.TextFrameData.Any())
                    this.TextFrameData.Add(new TextData());
                this.TextFrameData.FirstOrDefault().TextList = value.Split('~').ToList();
            }
        }
        public string Mark { get; internal set; }
        public List<TextData> TextFrameData { get; internal set; } = new List<TextData>();
        public List<PictureSourceDataProps> PicData { get; internal set; } = new List<PictureSourceDataProps>();
        public List<SoundItem> SoundData { get; internal set; } = new List<SoundItem>();
        public string PicTemplate { get; internal set; }
        public string SoundTemplate { get; internal set; }
        public string TextTemplate { get; internal set; }

        #endregion
    }
}
