using System;
using System.Collections.Generic;
using System.Linq;

namespace StoGen.Classes
{
    // for creating cadre according person data
    public class CadreMaker
    {
        //private string DATA_NAME_DIALOGUE_FIGURE = @"DATA_NAME_DIALOGUE_FIGURE";
        //private string DATA_NAME_DIALOGUE_FACE = @"DATA_NAME_DIALOGUE_FACE";


        //public CadreMaker()
        //{
        //    this.ModCadreDataList = new CadreData();

        //}
        //public CadreData ModCadreDataList { get; set; }



        //public void FillDialogueCadre(Cadre cadre, Context context)
        //{
        //    //cadre.CoreCadreData.Assign(ByCoreCadreDataName(DATA_NAME_DIALOGUE_FIGURE));
        //    //// get cadre modification data
        //    //cadre.ModCadreDataList.Clear();
        //    //CadreData cd = new CadreData();
        //    //cd.Assign(ByModCadreDataName(DATA_NAME_DIALOGUE_FACE));
        //    //cadre.ModCadreDataList.Add(cd);
        //}

        //List<SelectorBase> _Selectors;
        //public List<SelectorBase> Selectors
        //{
        //    get
        //    {
        //        if (_Selectors == null)
        //        {
        //            _Selectors = new List<SelectorBase>();

        //        }
        //        return _Selectors;
        //    }
        //}

        //public virtual bool RefreshCadre(Cadre cadre, Context context)
        //{
        //    if (cadre.PicFrameData != null)
        //    {
        //        int picdata = RunSelectors(cadre.PicFrameData.PictureDataList, context);
        //        PictureSourceDataProps picturesource = cadre.PicFrameData.PictureDataList[picdata];
        //        cadre.InsertImage(picturesource);
        //        if (cadre.PicPostProcessingData.Count > 0) cadre.ApplyPicPostProcesssing(cadre.PicPostProcessingData);
        //    }
        //    if (cadre.TextFrameData != null)
        //    {
        //        FrameText ft = cadre.GetTextFrame();
        //        ft.TextList.AddRange(cadre.TextFrameData.TextList);
        //        ft.BackColor = cadre.TextFrameData.BackColor;
        //        ft.FontName = cadre.TextFrameData.FontName;
        //        ft.FontSize = cadre.TextFrameData.FontSize;
        //        ft.Size = cadre.TextFrameData.Size;
        //        ft.AutoShow = cadre.TextFrameData.AutoShow;
        //        ft.Html = cadre.TextFrameData.Html;
        //    }
        //    if (cadre.SoundFrameData != null && cadre.SoundFrameData.Count > 0)
        //    {
        //        FrameSound fs = cadre.GetSoundFrame();
        //        fs.SoundList.Clear();
        //        fs.SoundList.AddRange(cadre.SoundFrameData);
        //    }

        //    return true;
        //}
        //public int RunSelectors(List<PictureSourceDataProps> picturedata, Context context)
        //{
        //    if (this.Selectors.Count == 0) return 0; //return first if no selectors
        //    int result = -1;
        //    // make selection according to CurrentSelectorParams and cadre.CoreCadreData.PictureDataList            
        //    foreach (SelectorBase selector in Selectors)
        //    {
        //        // Assign creterias from context to selector!!!!!!!!
        //        selector.CriteriaList.Clear();
        //        if (context != null)
        //        {
        //            foreach (List<SelectorData> listSelectorData in context.Data)
        //            {
        //                foreach (SelectorData selectorData in listSelectorData)
        //                {
        //                    if (selectorData.SelectorId == selector.Id)
        //                    {
        //                        List<SelectorData> andgroup = new List<SelectorData>();
        //                        andgroup.Add(selectorData);
        //                        selector.CriteriaList.Add(andgroup);

        //                    }
        //                }
        //            }
        //        }

        //        var data = picturedata.Select(x => x.SelectorDataList).ToList();
        //        int indexer = selector.Select(data);
        //        // for now return first appropriate positive result, TO DO: comparision for multiple positive results from several selectors
        //        if (indexer > -1) return indexer;
        //    }
        //    return result;
        //}

        //public virtual void FillCadre(Cadre cadre, Context context)
        //{

        //}
    }
}
