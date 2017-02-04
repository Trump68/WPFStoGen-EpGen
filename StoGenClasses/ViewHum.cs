//SgInclude d:\Process2\!CSUnits\Common\SelectorConstants.cs
//SgInclude d:\Process2\!CSUnits\Common\BackgroundHelper.cs
//SgInclude d:\Process2\!CSUnits\Common\SoundHelper.cs

using System.Collections.Generic;
using System.Linq;
using StoGen.Classes;
using StoGen.ModelClasses;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.IO;

namespace Work
{
    public class Hum_View
    {
        public ProcedureBase CurrentProc;
        public TLocation DefaultLocation;
        private List<HeadEmoData> _EmoData;
        public List<HeadEmoData> EmoData
        {
            get
            {
                if (_EmoData == null) _EmoData = new List<HeadEmoData>();
                return _EmoData;
            }
        }
        private List<FigSitData> _FigData;
        public List<FigSitData> FigData
        {
            get
            {
                if (_FigData == null) _FigData = new List<FigSitData>();
                return _FigData;
            }
        }

        private List<FigSitData> _SiluetteFigData;
        public List<FigSitData> SiluetteFigData
        {
            get
            {
                if (_SiluetteFigData == null) _SiluetteFigData = new List<FigSitData>();
                return _SiluetteFigData;
            }
        }
        private List<HeadEmoData> _SiluetteHeadData;
        public List<HeadEmoData> SiluetteHeadData
        {
            get
            {
                if (_SiluetteHeadData == null) _SiluetteHeadData = new List<HeadEmoData>();
                return _SiluetteHeadData;
            }
        }
        public ObjectName PersName { set; get; }
        public Occupation Occupation { set; get; }
        // =========== Dynamic situation data
        //List<SitType> CurrentPossibleSits = new List<SitType>();
        int CurrentFigIndex = 0;
        // ===========
        public Hum_View()
        {

        }
        public string SimpleName = null;
        public string Name
        {
            get
            {
                if (PersName == null)
                {
                    return "Имя неизвестно";
                }
                else return PersName.FullName;
            }
        }
        public string DefaultPath;
        public string Origin = string.Empty;

        public virtual ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc)
        {
            ProcedureBase procpreg = new ProcedureBase(null, ownerproc.Level + 1);
            this.CurrentProc = procpreg;
            procpreg.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, true);
            cadre.GetProcFrame().Proc = procpreg;
            return procpreg;
        }
        public virtual void CreateMenu(ProcedureBase proc)
        {
            //FrameRadioGroup rg = proc.Cadres[proc.NestedCadreId].GetRadioGroupFrame();
            //rg.Clear();
            //rg.Items.Add(new RgItem(@"Personal info {1}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    proc.MenuCreator = CreateMenuPersonalInfo;
            //    _rg.SetVisible(true);
            //    return false;
            //}));
            //rg.Items.Add(new RgItem(@"Next possible casual fig {2}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    Hum_View hum = (Hum_View)_ri.Data;
            //    hum.FillCadreNextPossibleFig(ref cadre, EmoType.Neitral, null, new SitType[] { SitType.Nak, SitType.Ling });
            //    cadre.Repaint(true);
            //    _rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Items.Add(new RgItem(@"Next possible int fig {3}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    Hum_View hum = (Hum_View)_ri.Data;
            //    hum.FillCadreNextPossibleFig(ref cadre, EmoType.Neitral, new SitType[] { SitType.Nak, SitType.Ling }, null);
            //    cadre.Repaint(true);
            //    _rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Items.Add(new RgItem(@"Next possible siluette {4}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    Hum_View hum = (Hum_View)_ri.Data;
            //    hum.FillCadreNextPossibleFig(ref cadre, EmoType.Neitral,
            //        new SitType[] { SitType.Nak, SitType.Ling, SitType.Sport,
            //            SitType.CasualHome, SitType.CasualStreet, SitType.Medic,
            //            SitType.Maid, SitType.School},
            //            null, true);
            //    cadre.Repaint(true);
            //    _rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Repaint();
        }
        public virtual void CreateMenuPersonalInfo(ProcedureBase proc)
        {
            //FrameRadioGroup rg = proc.Cadres[proc.NestedCadreId].GetRadioGroupFrame();
            //rg.Clear();
            //rg.Items.Add(new RgItem(@"Страница 1 {1}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    cadre.TextFrameData = new TextData();
            //    cadre.TextFrameData.TextList.Add(getPersonalInfoTitle());
            //    cadre.TextFrameData.Size = 600;
            //    cadre.TextFrameData.FontSize = 20;
            //    cadre.TextFrameData.FontName = "1 Balmoral LET";
            //    cadre.TextFrameData.FontName = "a_Majestic";
            //    cadre.TextFrameData.BackColor = Color.LightGray;
            //    cadre.TextFrameData.Html = true;
            //    //_rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Items.Add(new RgItem(@"Страница 2 {2}", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    cadre.TextFrameData = new TextData();
            //    cadre.TextFrameData.TextList.Add("Page 1 data");
            //    cadre.TextFrameData.Size = 600;
            //    cadre.TextFrameData.FontSize = 20;
            //    cadre.TextFrameData.FontName = "1 Balmoral LET";
            //    cadre.TextFrameData.FontName = "a_Majestic";
            //    cadre.TextFrameData.BackColor = Color.LightGray;
            //    cadre.TextFrameData.Html = true;
            //    //_rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Items.Add(new RgItem(@"Закрыть", this, delegate(FrameRadioGroup _rg, RgItem _ri)
            //{
            //    Cadre cadre = proc.Cadres[proc.NestedCadreId];
            //    cadre.Clear(true);

            //    proc.MenuCreator = CreateMenu;
            //    _rg.SetVisible(false);
            //    return false;
            //}));
            //rg.Repaint();
        }
        private string getPersonalInfoTitle()
        {
            List<string> sl = new List<string>();
            this.PersName.Mark = this.PersName.Mark;

            string fullname = this.PersName.Mark + ObjectName._ATT_NT + TextProcessor2._INC_N;
            string gender = this.PersName.Mark + ObjectName._ATT_GT + TextProcessor2._INC_G;
            string occupation = string.Empty;
            if (this.Occupation != null) occupation = this.PersName.Mark + Occupation._ATT_ONT + TextProcessor2._INC_N;


            //Mon Amour One,1 Balmoral LET
            string line = @"<Center><font size='5' color='black' face='a_Romanus'>Дело № 8424-23<br></Center>";
            if (!string.IsNullOrEmpty(this.PersName.IdImage))
            {
                line = line + @"<img src='" + this.PersName.IdImage + "'  width='100' height='100'>";
            }
            line = line +
            @"<table cellspacing=0 cellpadding=0>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>Имя: <font size='5' face='Mon Amour One'>" + fullname + @"</td></tr>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>Полу: <font size='5' face='Mon Amour One'>" + gender + @"</td></tr>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>Лет полных: <font size='5' face='Mon Amour One'>" + this.PersName.Age + @"</td></tr>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>Место рождения: <font size='5' face='Mon Amour One'>" + this.Origin + @"</td></tr>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>Место проживания: <font size='5' face='Mon Amour One'>" + this.DefaultLocation.Name + @"</td></tr>"
            + @"<tr><td><font size='5' color='black' face='a_Romanus'>По роду занятий: <font size='5' face='Mon Amour One'>" + occupation + @"</td></tr>";

            for (int i = 0; i < 10; i++)
            {
                line = line + @"<tr><td><font size='5' color='black' face='a_Romanus'> <font size='5' face='Mon Amour One'> </td></tr>";
            }
            line = line + @"</table>";
            line = line + @"</font><br><br><br><font size='3' face='a_Romanus'><Center>Конфиденциально. Разглашение не допускается.</Center></font>";
            sl.Add(line);
            sl = StoGen.Classes.TextProcessor2.ProcessText(sl, new List<IDescptible>() { this.PersName, this.Occupation });
            return string.Join("", sl.ToArray());
        }

        public Cadre GetMainCadre(PictureSourceDataProps picdata)
        {
            Cadre cadre = new Cadre(this.CurrentProc, true);
            cadre.PicFrameData.Add(picdata);

            TextData data = new TextData();
            data.TextList.Add(Name);
            data.Size = 1000;
            data.FontSize = 20;
            data.AutoShow = false;
            cadre.TextFrameData.Add(data);
            return cadre;
        }
        public virtual PictureSourceDataProps GetPic(int num, string format)
        {
            PictureSourceDataProps psp
                = new PictureSourceDataProps(String.Format("{1}{0,3:D3}.{2}", num, DefaultPath, format));
            psp.Level = PicLevel.Actor0;
            psp.SizeX = 800;
            psp.SizeY = 600;
            return psp;
        }

        #region Default fig head generation
        // temporary for test?
        public Cadre CreateDefaultLocationFigEmoCadre()
        {
            Cadre cadre = new Cadre(this.CurrentProc, true);
            FillDefaultLocationFigEmoCadre(ref cadre);
            return cadre;
        }
        // temporary for test?
        public void FillDefaultLocationFigEmoCadre(ref Cadre cadre)
        {
            FillDefaultLocationFigEmoCadre(ref cadre, SitType.None, EmoType.None);
        }
        // temporary for test?
        public void FillDefaultLocationFigEmoCadre(ref Cadre cadre, SitType st, EmoType et)
        {
            if (this.DefaultLocation != null)
            {
                BackgroundHelper.BackgroundChange(cadre, this.DefaultLocation.GetRandomSectionAndView().Id, null);
            }
            if (this.FigData.Count > 0)
            {
                FillCadreByFigHead(ref cadre, null, st, et);
            }
        }
        #endregion

        public bool FillCadreByFigHead(ref Cadre cadre, string setname, SitType sit, EmoType emo)
        {
            PictureSourceDataProps psp;
            if (FillCadreByFig(ref cadre, setname, sit, out psp))
            {
                return FillCadreByHead(ref cadre, setname, emo);
            }
            return false;
        }

        public PictureSourceDataProps FillCadre(ref Cadre cadre, FigSitData fig)
        {
            cadre.PicFrameData.PictureDataList.Add(fig.PicData);
            return fig.PicData;
        }
        public bool FillCadreByFig(ref Cadre cadre, string setname, SitType sit, int force, out PictureSourceDataProps psp)
        {
            psp = null;
            foreach (FigSitData figData in FigData)
            {
                if (setname == null || setname == figData.SetName)
                {
                    foreach (PersSit persSit in figData.SitList)
                    {
                        if ((persSit.EType == sit) && (force == 0 || persSit.Force == force))
                        {
                            psp = FillCadre(ref cadre, figData);
                            return true;
                        }
                    }
                }
            }
            if (FillCadreByFig(ref cadre, setname, sit, out psp)) return true;
            return false;
        }
        public bool FillCadreByFig(ref Cadre cadre, string setname, SitType sit, out PictureSourceDataProps psp)
        {
            psp = null;
            foreach (FigSitData figData in FigData)
            {
                if (setname == null || setname == figData.SetName)
                {
                    foreach (PersSit persSit in figData.SitList)
                    {
                        if (sit == SitType.None || persSit.EType == sit)
                        {
                            cadre.PicFrameData.Add(figData.PicData);
                            psp = figData.PicData;
                            return true;
                        }
                    }
                }
            }
            if (FillCadreByFig(ref cadre, setname, out psp)) return true;
            return false;
        }
        public bool FillCadreByFig(ref Cadre cadre, string setname, out PictureSourceDataProps psp)
        {
            psp = null;
            foreach (FigSitData figData in FigData)
            {
                if (setname == null || setname == figData.SetName)
                {
                    cadre.PicFrameData.Add(figData.PicData);
                    psp = figData.PicData;
                    return true;
                }
            }
            return false;
        }
        public bool FillCadreByHead(ref Cadre cadre, string setname, EmoType emo, int force)
        {
            foreach (HeadEmoData headEmoData in EmoData)
            {
                if (setname == null || setname == headEmoData.SetName)
                {
                    foreach (PersEmo persEmo in headEmoData.EmoList)
                    {
                        if ((emo == EmoType.None || persEmo.EType == emo) && (force == 0 || persEmo.Force == force))
                        {
                            cadre.PicFrameData.Add(headEmoData.PicData);
                            return true;
                        }
                    }
                }
            }
            if (FillCadreByHead(ref cadre, setname, emo)) return true;
            return false;
        }
        public bool FillCadreByHead(ref Cadre cadre, string setname, EmoType emo)
        {
            foreach (HeadEmoData headEmoData in EmoData)
            {
                if (setname == null || setname == headEmoData.SetName)
                {
                    foreach (PersEmo persEmo in headEmoData.EmoList)
                    {
                        if (emo == EmoType.None || persEmo.EType == emo)
                        {
                            cadre.PicFrameData.Add(headEmoData.PicData);
                            return true;
                        }
                    }
                }
            }
            if (FillCadreByHead(ref cadre, setname)) return true;
            return false;
        }
        public bool FillCadreByHead(ref Cadre cadre, string setname, bool isSiluette = false)
        {
            List<HeadEmoData> list = this.EmoData;
            if (isSiluette) list = this.SiluetteHeadData;
            foreach (HeadEmoData headEmoData in list)
            {
                if (setname == null || setname == headEmoData.SetName)
                {
                    cadre.PicFrameData.Add(headEmoData.PicData);
                    return true;
                }
            }
            return false;
        }
        protected void AddHead(string fn, EmoType emotype, string set, int force, int x, int y, bool isSuluette = false)
        {
            AddHead(fn, new EmoType[] { emotype }, set, force, x, y, isSuluette);
        }
        protected void AddHead(string fn, EmoType[] emotype, string set, int force, int x, int y, bool isSuluette = false)
        {
            HeadEmoData head = new HeadEmoData();
            head.SetName = set;
            foreach (EmoType emoType in emotype)
            {
                head.EmoList.Add(new PersEmo(emoType, force));
            }
            if (Path.IsPathRooted(fn))
                head.PicData = new PictureSourceDataProps(fn);

            else
                head.PicData = new PictureSourceDataProps(this.DefaultPath + fn);
            head.PicData.X = x;
            head.PicData.Y = y;
            //head.PicData.Merge = isSuluette;
            if (!isSuluette) { this.EmoData.Add(head); }
            else { this.SiluetteHeadData.Add(head); }
        }
        protected void AddFigure(string fn, SitType sittype, string set, int force, bool isSuluette = false)
        {
            AddFigure(fn, new SitType[] { sittype }, set, force, isSuluette);
        }
        protected void AddFigure(string fn, SitType[] sittype, string set, int force, int x, int y, bool isSuluette = false)
        {
            FigSitData figure = new FigSitData();
            figure.SetName = set;
            foreach (SitType sitType in sittype)
            {
                figure.SitList.Add(new PersSit(sitType, force));
            }
            if (Path.IsPathRooted(fn))
                figure.PicData = new PictureSourceDataProps(fn);

            else
                figure.PicData = new PictureSourceDataProps(this.DefaultPath + fn);

            figure.PicData.X = x;
            figure.PicData.Y = y;
            //figure.PicData.Merge = isSuluette;
            if (!isSuluette) { this.FigData.Add(figure); }
            else { this.SiluetteFigData.Add(figure); }
        }
        protected void AddFigure(string fn, SitType[] sittype, string set, int force, bool isSuluette = false)
        {
            AddFigure(fn, sittype, set, force, 0, 0, isSuluette);
        }
        public int GetBySitType(SitType[] sits, List<FigSitData> list, bool isSiluette = false)
        {
            List<FigSitData> flist = this.FigData;
            if (isSiluette) flist = this.SiluetteFigData;

            int result = 0;
            foreach (FigSitData figData in flist)
            {
                PersSit sit = figData.GetSitType(sits);
                if (sit != null) { list.Add(figData); result++; }
            }
            return result;
        }
        public int GetMostSuitbleClothed(SitType[] sits, List<FigSitData> list, SitType maxType)
        {
            int found = GetBySitType(sits, list);
            if (found < 1)
            {
                SitType max = SitType.Nak;
                // if not found - get most clothed searched                
                foreach (SitType sit in sits) { if (sit > max) max = sit; }
                while (found < 1)
                {
                    found = GetBySitType(new SitType[] { max }, list);
                    max++; if (max > maxType) return 0;
                }
            }
            return found;
        }
        public int GetMostSuitbleUnClothed(SitType[] sits, List<FigSitData> list, SitType minType)
        {
            int found = GetBySitType(sits, list);
            if (found < 1)
            {
                SitType min = SitType.Medic;
                // if not found - get most unclothed searched                
                foreach (SitType sit in sits) { if (sit < min) min = sit; }
                while (found < 1)
                {
                    found = GetBySitType(new SitType[] { min }, list);
                    min--; if (min < minType) return 0;
                }
            }
            return found;
        }
        public int GetMostSuitbleAny(SitType[] sits, List<FigSitData> list, SitType minType, SitType maxType)
        {
            if (GetMostSuitbleClothed(sits, list, maxType) < 1)
            {
                return GetMostSuitbleUnClothed(sits, list, minType);
            }
            return 0;
        }
        public int GetAllExcept(SitType[] exceptlist, List<FigSitData> list, bool isSiluette = false)
        {
            Array vals = Enum.GetValues(typeof(SitType));
            List<SitType> typelist = new List<SitType>();
            foreach (SitType item in vals)
            {
                if (!exceptlist.Contains(item)) typelist.Add(item);
            }
            return GetBySitType(typelist.ToArray(), list, isSiluette);
        }
        public void FillCadreNextPossibleFig(ref Cadre cadre, EmoType emotype, SitType[] list, SitType[] exceptlist, bool isSiluette = false)
        {
            List<FigSitData> figlist = new List<FigSitData>();
            int count = 0;
            if (exceptlist != null) count = GetAllExcept(exceptlist, figlist, isSiluette);
            else count = GetBySitType(list, figlist, isSiluette);
            if (count > 0)
            {
                this.CurrentFigIndex++;
                if (this.CurrentFigIndex >= figlist.Count) this.CurrentFigIndex = 0;
                this.FillCadre(ref cadre, figlist[this.CurrentFigIndex]);
                this.FillCadreByHead(ref cadre, figlist[this.CurrentFigIndex].SetName, isSiluette);
            }
        }
    }

    public class FigSitData
    {
        public FigSitData()
        {
            PicData = new PictureSourceDataProps();
            SitList = new List<PersSit>();
        }
        public string SetName;
        public PictureSourceDataProps PicData;
        public List<PersSit> SitList;
        public ClothPeaceSet ClothSet;
        public PersSit GetSitType(SitType[] types)
        {
            foreach (PersSit persSit in SitList)
            {
                if (types.Contains(persSit.EType)) return persSit;
            }
            return null;
        }
    }
    public class PersSit
    {
        public PersSit(SitType type, int force)
        {
            this.EType = type;
            this.Force = force;

        }
        public SitType EType = SitType.Nak;
        public int Force = 0;
    }
    public enum SitType : int
    {
        None = -1,
        Nak = 0,
        Ling = 1,
        Sport = 2,
        Maid = 3,
        CasualHome = 4,
        School = 5,
        CasualStreet = 6,
        Medic = 7
    }


    public class HeadEmoData
    {
        public HeadEmoData()
        {
            PicData = new PictureSourceDataProps();
            EmoList = new List<PersEmo>();
        }
        public string SetName;
        public PictureSourceDataProps PicData;
        public List<PersEmo> EmoList;
    }
    public class PersEmo
    {
        public PersEmo(EmoType type, int force)
        {
            this.EType = type;
            this.Force = force;

        }
        public EmoType EType = EmoType.Neitral;
        public int Force = 0;
    }
    public enum EmoType : int
    {
        None = -1,
        Neitral = 0,
        Smile = 1,
        Puzzled = 2,
        Worried = 3,
        Sorry = 4,
        Surprized = 5,
        Scared = 6
    }

    public class ClothPeaceSet
    {
        public List<ClothPeaceSetKind> CSetKind = new List<ClothPeaceSetKind>();
        public string CName = string.Empty;
        public string CDescription = string.Empty;
        public List<Color> CColor = new List<Color>();
        public ClothPeaceSet()
        {

        }
    }

    public class ClothPeace
    {
        public List<ClothPeaceType> CType = new List<ClothPeaceType>();
        public List<ClothPeaceKind> CKind = new List<ClothPeaceKind>();
        public List<ClothPeaceSetKind> CSetKind = new List<ClothPeaceSetKind>();
        public string CName = string.Empty;
        public string CDescription = string.Empty;
        public List<Color> CColor = new List<Color>();
        public ClothPeace()
        {

        }
    }
    public enum ClothPeaceType : int
    {
        Street = 0,
        Home = 1,
        Under = 2,
        Any = 99
    }
    public enum ClothPeaceKind : int
    {
        SuiteTop = 0,
        SuiteButtom = 1,
        UniformTop = 2,
        UniformButtom = 3,
        Any = 99
    }
    public enum ClothPeaceSetKind : int
    {
        SetSuite = 0,
        SetUniform = 1,
        Any = 99
    }

}