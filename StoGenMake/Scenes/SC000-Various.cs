using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC000_Various : BaseScene
    {
  
        public SC000_Various() : base()
        {
            Name = "SC000-Various";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            

           
            string src = null;
            string fn = null;
            int ss = 700;
            string gr = null;

            #region artist Eriya-J
            string dsc = "artist Eriya-J";
            path = @"Z:\ARTIST\Eriya-J\DBR\";
            gr = " Eriya-J Raw data";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Eriya-J_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            gr = "Eriya-J Face";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Eriya-J_Face_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Codec
            dsc = "artist Codec";
            path = @"Z:\ARTIST\Codec\DBR\";
            gr = "Codec Raw data";
            for (int i = 1; i <= 3; i++)
            {
                src = $"Codec_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Dako 5
            dsc = "artist Dako 5";
            path = @"Z:\ARTIST\Dako 5\DBR\";
            gr = "Dako 5 data";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Dako_5_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Dcwj
            dsc = "artist Dcwj";
            path = @"Z:\ARTIST\Dcwj\DBR\";
            gr = "Dcwj data";
            for (int i = 1; i <= 6; i++)
            {
                src = $"Dcwj_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Destiny Child
            dsc = "artist Destiny Child";
            path = @"Z:\ARTIST\Destiny Child\DBR\";
            gr = "Destiny Child data";
            for (int i = 1; i <= 3; i++)
            {
                src = $"Destiny_Child_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Doxy
            dsc = "artist Doxy";
            path = @"Z:\ARTIST\Doxy\DBR\";
            gr = "Doxy data";
            for (int i = 1; i <= 7; i++)
            {
                src = $"Doxy_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Emyo
            dsc = "artist Emyo";
            path = @"Z:\ARTIST\Emyo\DBR\";
            gr = "Emyo data";
            for (int i = 1; i <= 5; i++)
            {
                src = $"Emyo_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            gr = "Emyo PNG";
            for (int i = 1; i <= 1; i++)
            {
                src = $"Emyo_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Firolian
            dsc = "artist Firolian";
            path = @"Z:\ARTIST\Firolian\DBR\";
            gr = "Firolian data";
            for (int i = 1; i <= 6; i++)
            {
                src = $"Firolian_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Frans Mensink
            dsc = "artist Frans Mensink";
            path = @"Z:\ARTIST\Frans Mensink\DBR\";
            gr = "Frans Mensink data";
            for (int i = 1; i <= 18; i++)
            {
                src = $"Frans_Mensink_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist G.m (gorgeous mushroom)
            dsc = "artist G.m (gorgeous mushroom)";
            path = @"Z:\ARTIST\G.m (gorgeous mushroom)\Pixiv\";
            gr = "G.m (gorgeous mushroom) data";
            for (int i = 1; i <= 4; i++)
            {
                src = $"G.m_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Geo Siador
            dsc = "artist Geo Siador";
            path = @"Z:\ARTIST\Geo Siador\DBR\";
            gr = "Geo Siador data";
            for (int i = 1; i <= 9; i++)
            {
                src = $"Geo_Siador_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Ghettoyouth
            dsc = "artist Ghettoyouth";
            path = @"Z:\ARTIST\Ghettoyouth\DBR\";
            gr = "Ghettoyouth data";
            for (int i = 1; i <= 34; i++)
            {
                src = $"Ghettoyouth_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 1; i++)
            {
                src = $"Ghettoyouth_Head_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion

        }


    }

}
