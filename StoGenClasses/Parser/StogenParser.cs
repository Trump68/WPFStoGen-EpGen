using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class StringDataContainer
    {
        public string Original;
        public string Complete;
        public string Mark;
        public StringDataContainer(string original, string complete) { Original = original; Complete = complete; }
    }
    public class KeyVarDataContainer
    {
        public class KeyVarData
        {
            public int Key;
            public string Description;
        }
        public class StoryData
        {
            public string Name;
            public string Description;
            public string Path;
            public string Group;
            public List<string> ParamList = new List<string>();
        }
        public List<SoundItem> SoundVariableList = new List<SoundItem>();
        public List<TextData> TextVariableList = new List<TextData>();
        public List<KeyVarData> keyVarList = new List<KeyVarData>();
        public List<StoryData> StoryList = new List<StoryData>();
        public Dictionary<string, string> Inlines = new Dictionary<string, string>();
        public Dictionary<string, string> TextInlines = new Dictionary<string, string>();
        //public List<string> TextVariablesKeys;
        //public List<string> TextVariablesValues;
    }
    public static class StoGenParser
    {
        public static string DefaultPath;
        public static List<PictureSourceDataProps> CommonPics = new List<PictureSourceDataProps>();
        public static KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        public static List<StringDataContainer> GetProcessedFile(string fn, string part, KeyVarDataContainer KeyVarContainer, string original, out List<string> header)
        {
            header = new List<string>();
            bool headerend = false;
            List<string> datalist = Universe.LoadFileToStringList(fn.Trim());
            List<StringDataContainer> listtoprocess = new List<StringDataContainer>();
            bool checkpart = !string.IsNullOrEmpty(part);
            bool checkpartOk = false;
            string currentmark = null;
            string path = Path.GetDirectoryName(fn);
            int AutoMark = 0;
            foreach (string item in datalist)
            {

                if (item.Trim().StartsWith(@"PartSta#"))
                {
                    currentmark = item.Trim().Replace(@"PartSta#", string.Empty);
                    if (string.IsNullOrEmpty(currentmark))
                        currentmark = $"{AutoMark++}";
                }
                else if (item.Trim().StartsWith(@"PartEnd#"))
                {
                    currentmark = null;
                }

                string originalitem = original;
                if (originalitem == null) originalitem = item;

                if (string.IsNullOrEmpty(item) || item.StartsWith(@"//")) { }
                else if (checkpart && !checkpartOk)
                {
                    if (item.Trim().StartsWith(@"PartStaCommon#"))
                    {
                        checkpartOk = true;
                    }
                    else if (item.Trim().StartsWith(@"PartSta#" + part))
                    {
                        checkpartOk = true;
                        currentmark = item.Trim().Replace(@"PartSta#", string.Empty);
                    }
                }

                else if (checkpart && (item.Trim().StartsWith(@"PartEnd#" + part) || item.Trim().StartsWith(@"PartEndCommon#")))
                {
                    checkpartOk = false;
                    currentmark = null;
                }
                else if (item.StartsWith(@"Inline#")) AddInline(item, KeyVarContainer);
                else if (item.StartsWith(@"File#"))
                {
                    var pf = ApplayFile(item, KeyVarContainer, originalitem, path);
                    listtoprocess.AddRange(pf);
                }
                else if (item.StartsWith(@"#"))
                {
                    var it = new StringDataContainer(fn, ApplayInline(item, KeyVarContainer));
                    it.Mark = currentmark;
                    listtoprocess.Add(it);
                }
                else
                {
                    var it = new StringDataContainer(fn, item);
                    it.Mark = currentmark;
                    listtoprocess.Add(it);
                };

                if (item.Trim().StartsWith(@"PartSta#" + part))
                {
                    headerend = true;
                }

                if (!headerend) header.Add(item);

            }
            return listtoprocess;
        }
        private static List<StringDataContainer> ApplayFile(string item, KeyVarDataContainer KeyVarContainer, string original, string path)
        {
            List<StringDataContainer> result = new List<StringDataContainer>();
            string[] vals = item.Split('#');
            if (vals.Length >= 2)
            {
                string originalitem = original;
                if (originalitem == null) originalitem = item;

                string part = null;
                if (vals.Length == 3) part = vals[2];
                List<string> header;
                string fn = vals[1];
                if (!Path.IsPathRooted(fn))
                {
                    fn = Path.GetFullPath(Path.Combine(path, fn));
                }
                result = GetProcessedFile(fn, part, KeyVarContainer, originalitem, out header);
            }
            return result;
        }
        private static void AddInline(string item, KeyVarDataContainer KeyVarContainer)
        {

            string[] vals = item.Split(new char[] { '#' }, 3);
            if (vals.Length == 3)
            {
                if (!KeyVarContainer.Inlines.ContainsKey(vals[1]))
                {
                    string keyval = vals[0] + "#" + vals[1] + "#";
                    keyval = item.Replace(keyval, string.Empty).Trim();
                    while (keyval.StartsWith(@"#"))
                    {
                        keyval = ApplayInline(keyval, KeyVarContainer);
                    }
                    KeyVarContainer.Inlines.Add(vals[1], keyval);
                }
            }
        }
        public static string ApplayInline(string item, KeyVarDataContainer KeyVarContainer)
        {
            string result = string.Empty;

            string[] vals = item.Remove(0, 1).Split('#');
            if (vals.Length >= 2)
            {
                if (KeyVarContainer.Inlines.ContainsKey(vals[0]))
                {
                    result = KeyVarContainer.Inlines[vals[0]] + vals[1];

                }
            }
            return result;
        }
        public static void FillCadreText(string item, List<TextData> listtextdata, List<string> stringlist, string name, string filename, string DefaultPath)
        {
            listtextdata.Clear();
            TextData data = new TextData();
            if (name != null) data.Name = name;
            data.Size = 600;
            data.FontSize = 25;
            data.AutoShow = true;
            string[] vals2 = item.Split(';');
            foreach (string it in vals2)
            {

                string[] vals = it.Split('=');
                if (vals[0] == "CadreText")
                {
                    string fn = null;
                    if (vals[1] == "this")
                    {
                        fn = null;
                        if (stringlist == null)
                        {
                            stringlist = Universe.LoadFileToStringList(filename);
                        }
                    }
                    else fn = Universe.GetFullPath(vals[1], DefaultPath);
                    if (File.Exists(fn))
                    {
                        data.FileName = fn;
                        stringlist = Universe.LoadFileToStringList(fn);
                    }
                }
                else if (vals[0] == "FontName")
                {
                    data.FontName = vals[1];
                }
                else if (vals[0] == "FontColor")
                {
                    data.FontColor = vals[1];
                }
                else if (vals[0] == "FontSize")
                {
                    data.FontSize = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "Opacity")
                {
                    data.Opacity = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "TRN")
                {
                    data.Transition = vals[1];
                }
                else if (vals[0] == "Width")
                {
                    data.Width = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "ClearBack")
                {
                    data.ClearBack = Convert.ToInt32(vals[1]) == 1;
                }
                else if (vals[0] == "Size")
                {
                    string[] vals3 = vals[1].Split('-');
                    data.Size = Convert.ToInt32(vals3[0]);
                    if (vals3.Length > 1) data.Shift = Convert.ToInt32(vals3[1]);
                }
                else if (vals[0] == "Rtf")
                {
                    data.Rtf = (Convert.ToInt32(vals[1]) == 1);
                }
                else if (vals[0] == "Part")
                {
                    data.Part = vals[1];
                }
                else if (vals[0] == "Align")
                {
                    data.Align = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "Shift")
                {
                    data.Shift = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "Bottom")
                {
                    data.Bottom = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "~")
                {
                    stringlist = vals[1].Split('~').ToList();
                }
            }
            if (stringlist != null) data.LoadfromStringList(stringlist);
            string sum = string.Join(Environment.NewLine, data.TextList.ToArray());
            /*
            if (sum.Contains("TEXTVAR:"))
            {
                foreach (KeyValuePair<string, string> vvv in this.KeyVarContainer.TextInlines)
                {
                    sum = sum.Replace("TEXTVAR:" + vvv.Key, vvv.Value);
                }
                string[] valss = sum.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                data.TextList.Clear();
                foreach (string vals in valss)
                {
                    data.TextList.Add(vals);
                }
            }
            */
            listtextdata.Add(data);
        }
        public static PictureSourceDataProps GetPSPFromString(string item, string DefaultPath, ref int CadreOrder)
        {
            PictureSourceDataProps p = null;
            string[] valsComma = item.Split(';');
            foreach (string str in valsComma)
            {
                string[] valsEqual = str.Split('=');
                string mark = valsEqual[0];
                string val = valsEqual[1];
                if (mark == "MainPics")
                {
                    if (val == "SKIP") return new PictureSourceDataProps(val);
                    else if (val == "PREVIOUS") return new PictureSourceDataProps(val);
                    p = new PictureSourceDataProps(Universe.GetFullPath(val, DefaultPath));
                }
                else if (mark == "MainProps")
                {
                    p = new PictureSourceDataProps(string.Empty);
                }
                else if (mark == "CommonPics" || mark == "DetailPics")
                {
                    p = new PictureSourceDataProps(Universe.GetFullPath(val, DefaultPath));
                    p.Active = true;
                }
                else if (mark == "AutoPics")
                {
                    if (val == "SKIP") return new PictureSourceDataProps(val);
                    else if (val == "PREVIOUS") return new PictureSourceDataProps(val);
                    p = new PictureSourceDataProps(Universe.GetFullPath(val, DefaultPath));
                    p.Active = true;
                }
                else if (mark == "ClipH") p.ClipH = Convert.ToDouble(val);
                else if (mark == "ClipW") p.ClipW = Convert.ToDouble(val);
                else if (mark == "ClipX")
                {
                    p.ClipX = Convert.ToDouble(val);
                }
                else if (mark == "ClipY")
                {
                    p.ClipY = Convert.ToDouble(val);
                }
                else if (mark == "X") p.X = Convert.ToInt32(val.Trim());
                else if (mark == "Y") p.Y = Convert.ToInt32(val.Trim());
                else if (mark == "SizeX") p.SizeX = Convert.ToInt32(val.Trim());
                else if (mark == "SizeY") p.SizeY = Convert.ToInt32(val.Trim());
                else if (mark == "Rot") p.Rotate = Convert.ToInt32(val.Trim());
                else if (mark == "Flip") p.Flip = (RotateFlipType)Convert.ToInt32(val.Trim());
                else if (mark == "R") p.R = Convert.ToInt32(val.Trim());
                else if (mark == "Blur") p.Blur = Convert.ToInt32(val.Trim());
                else if (mark == "Level")
                {
                    p.Level = (PicLevel)(Convert.ToInt32(val.Trim()));
                }
                else if (mark == "Opacity")
                {
                    p.Opacity = Convert.ToInt32(val.Trim());
                }
                else if (mark == "Flash") p.Flash = val;
                else if (mark == "Name") p.Name = val;
                else if (mark == "Desc") p.Description = val;
                else if (mark == "SetName")
                {
                    p.SetName = val;
                }
                else if (mark == "Timer") p.Timer = Convert.ToInt32(val.Trim());
                else if (mark == "Timer2") p.Timer2 = Convert.ToInt32(val.Trim());
                else if (mark == "SizeMode") p.SizeMode = (PictureSizeMode)Convert.ToInt32(val.Trim());
                else if (mark.Trim() == "Active")
                {
                    if (val.Trim() == "0") p.Active = false;
                    else p.Active = true;
                }
                else if (mark.Trim() == "Mute")
                {
                    if (val.Trim() == "0") p.Mute = false;
                    else p.Mute = true;
                }
                else if (mark.Trim() == "Reload")
                {
                    if (val.Trim() == "0") p.Reload = false;
                    else p.Reload = true;
                }
                else if (mark.Trim() == "IsLoop")
                {
                    p.isLoop = Convert.ToInt32(val.Trim());
                }
                else if (mark.Trim() == "PP")
                {
                    p.PP1 = Convert.ToInt32(val.Trim());
                    p.PP2 = p.PP1;
                }
                else if (mark.Trim() == "PP1")
                {
                    p.PP1 = Convert.ToInt32(val.Trim());
                }
                else if (mark.Trim() == "PP2")
                {
                    p.PP2 = Convert.ToInt32(val.Trim());
                }
                else if (mark.Trim() == "Rate")
                {
                    p.Rate = (AnimationRate)Convert.ToInt32(val.Trim());
                }
                else if (mark.Trim() == "Core")
                {
                    if (val.Trim() == "0") p.isMain = false;
                    else p.isMain = true;
                }
                else if (mark.Trim() == "StartPos")
                {
                    if (!string.IsNullOrEmpty(val))
                        p.StartPos = Convert.ToDouble(val.Trim());
                }
                else if (mark.Trim() == "EndPos")
                {
                    if (!string.IsNullOrEmpty(val))
                        p.EndPos = Convert.ToDouble(val.Trim());
                }
                else if (mark.Trim() == "NextCadre")
                {
                    p.NextCadre = Convert.ToDouble(val);
                }
                else if (mark == "Parent") p.Parent = val.Trim();
                else if (mark == "ParFlip") p.ParFlip = val.Trim();
                else if (mark == "TRN") p.Transition = val.Trim();
                else if (mark == "Order") CadreOrder = Convert.ToInt32(val.Trim());                
            }
            return p;
        }
        public static void FillCadreSound(string item, List<SoundItem> soundlist, string name, string DefaultPath)
        {
            SoundItem si = null;
            string[] vals2 = item.Split(';');
            string[] vals;
            if (vals2.Length > 0)
            {
                vals = vals2[0].Split('=');
                if (vals[1] == "STOP")
                {
                    si = new SoundItem();
                    si.FileName = "STOP";
                }
                else
                {
                    string fn = Universe.GetFullPath(vals[1], DefaultPath);
                    if (File.Exists(fn))
                    {
                        si = new SoundItem();
                        si.FileName = fn;
                        if (name != null) si.Name = name;
                    }
                }
            }

            if (vals2.Length > 1 && si != null)
            {
                for (int i = 1; i < vals2.Length; i++)
                {
                    ParseSountTerm(vals2[i], si);
                }
            }

            if (si != null)
            {
                if (si.Position < 0)
                {
                    si.Position = soundlist.Count;
                }
                soundlist.Add(si);
            }
        }
        private static void ParseSountTerm(string term, SoundItem si)
        {
            string[] vals;
            vals = term.Split('=');
            if (vals.Length > 1)
            {
                if (vals[0] == "V" || vals[0] == "v")
                {
                    si.Volume = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "TRN")
                {
                    si.Transition = vals[1];
                }
                else if (vals[0] == "Name")
                {
                    si.Name = vals[1];
                }
                else if (vals[0] == "Group")
                {
                    si.Group = vals[1];
                }
                else if (vals[0] == "Position")
                {
                    si.Position = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "Start")
                {
                    si.Start = !(Convert.ToInt32(vals[1]) == 0);
                }
                else if (vals[0] == "IsLoop")
                {
                    if (Convert.ToInt32(vals[1]) == 0)
                    {
                        si.isLoop = false;
                    }
                    else
                    {
                        si.isLoop = true;
                    }
                }
            }
        }

        public static bool AddCadresToProcFromFile(ProcedureBase proc, string fn, string part, string defaultPath)
        {
            proc.NestedCadreId = 0;
            while (proc.Cadres.Count > 1)
            proc.Cadres.RemoveAt(proc.Cadres.Count-1);

            List<string> header;
            List<StringDataContainer> datalist = new List<StringDataContainer>();
            string commonFile = $"{defaultPath}{"Common.stogen"}";
            if (File.Exists(commonFile))
            {
                datalist.AddRange(StoGenParser.GetProcessedFile(commonFile, part, KeyVarContainer, null, out header));
            }
            datalist.AddRange(StoGenParser.GetProcessedFile(fn, part, KeyVarContainer, null, out header));
            Cadre LastCadre = null;
            string key = null;
            //string laskey = string.Empty;
            KeyVarDataContainer.KeyVarData codevar = null;
            //int pos = 0;
            foreach (StringDataContainer item in datalist)
            {
                try
                {
                    if (string.IsNullOrEmpty(item.Complete) || item.Complete.StartsWith(@"//")) { }
                    else if (item.Complete.StartsWith(@"$TEXTVAR:"))
                    {
                        string[] vals = item.Complete.Split(':');
                        key = vals[1].Trim();
                        if (KeyVarContainer.TextInlines.ContainsKey(key))
                        {
                            key = "dontadd";
                        }
                        else
                        {
                            KeyVarContainer.TextInlines.Add(key, string.Empty);
                        }
                    }
                    else if (item.Complete.StartsWith(@"$TEXTVAR"))
                    {
                        key = null;
                    }
                    else if (item.Complete.StartsWith(@"$CODEVAR:"))
                    {
                        codevar = new KeyVarDataContainer.KeyVarData();
                        string[] vals = item.Complete.Split(':');
                        codevar.Key = Convert.ToInt32(vals[1].Trim());
                        if (vals.Length > 2)
                            codevar.Description = vals[2];
                    }
                    else if (item.Complete.StartsWith(@"$CODEVAR"))
                    {
                        codevar = null;
                    }
                    else if (codevar != null)
                    {
                        AddToCodeVar(codevar, item.Complete, datalist);
                    }
                    else if (key != null)
                    {
                        if (key != "dontadd")
                            //this.KeyVarContainer.TextInlines[key] = this.KeyVarContainer.TextInlines[key] + Environment.NewLine + item;
                            KeyVarContainer.TextInlines[key] = KeyVarContainer.TextInlines[key] + item;
                    }
                    else if (item.Complete.StartsWith(@"MainProps="))
                    {
                        FillMainPropsFromString(item.Complete);
                    }
                    else if (item.Complete.StartsWith(@"MainPics="))
                    {
                        LastCadre = new Cadre(proc, true);
                        FillMainPicsFromString(item, LastCadre);
                        LastCadre.Name = item.Mark;
                    }
                    else if (item.Complete.StartsWith(@"AutoPics="))
                    {
                        if (LastCadre == null || LastCadre.Name != item.Mark)
                        {
                            LastCadre = new Cadre(proc, true);
                            FillMainPicsFromString(item, LastCadre);
                            LastCadre.Name = item.Mark;
                        }
                        else
                        {
                            FillPicsFromString(item, LastCadre.PicFrameData.PictureDataList, null,DefaultPath);
                        }
                    }
                    else if (item.Complete.StartsWith(@"CadreText="))
                    {
                        StoGenParser.FillCadreText(item.Complete.Replace(@"CadreText=", string.Empty), LastCadre.TextFrameData, null, null, fn, DefaultPath);
                    }
                    else if (item.Complete.StartsWith(@"CadreSound="))
                    {
                        FillCadreSound(item.Complete, LastCadre.SoundFrameData);
                    }
                    else if (item.Complete.StartsWith(@"CadreName=")) FillCadreName(item.Complete, LastCadre);
                    else if (item.Complete.StartsWith(@"DetailPics=") && LastCadre != null)
                    {
                        FillPicsFromString(item, LastCadre.PicFrameData.PictureDataList,null,  DefaultPath);
                    }


                    else { };
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(item.Complete, "!!!!!!" + ex.Message, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // SortCadres();

            return true;
        }
        private static void AddToCodeVar(KeyVarDataContainer.KeyVarData codevar, string item, List<StringDataContainer> datalist)
        {
            bool found = false;
            foreach (KeyVarDataContainer.KeyVarData keyVarData in KeyVarContainer.keyVarList)
            {
                if (keyVarData.Key == codevar.Key)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                KeyVarContainer.keyVarList.Add(codevar);
            if (item.StartsWith(@"CadreSound=")) StoGenParser.FillCadreSound(item, KeyVarContainer.SoundVariableList, codevar.Key.ToString(), DefaultPath);
            else if (item.StartsWith(@"DetailPics=")) StoGenParser.FillPicsFromString(new StringDataContainer(item, item), StoGenParser.CommonPics, codevar.Key.ToString(), StoGenParser.DefaultPath);
            else if (item.StartsWith(@"CadreText=")) StoGenParser.FillCadreText(item, KeyVarContainer.TextVariableList, datalist.Select(x => x.Complete).ToList(), codevar.Key.ToString(), null, DefaultPath);
        }
        private static void FillPicsFromString(StringDataContainer itemCont, List<PictureSourceDataProps> list, string name, string defaultPath)
        {
            string item = itemCont.Complete;

            string path = defaultPath;
            if (itemCont.Original.StartsWith(@"File#"))
            {
                path = Path.GetDirectoryName(itemCont.Original.Replace(@"File#", string.Empty));
            }

            int order = int.MaxValue;
            PictureSourceDataProps psp = StoGenParser.GetPSPFromString(item, path, ref order);
            if (name != null) psp.Name = name;
            if (psp != null)
            {
                if (psp.Level == PicLevel.None)
                {
                    psp.Level = (PicLevel)list.Count();
                }
                PictureSourceDataProps existing = null;
                if (list.Count > 0 && !string.IsNullOrEmpty(psp.Name)) existing = list.FirstOrDefault(data => data.Name == psp.Name);
                if (existing == null) list.Add(psp);
                else
                {
                    list.Add(psp);
                    // было сделано чтобы не загружать заново то же самое а просто добавить свойства
                    //existing.Assign(psp);
                }
            }
        }
        public static PictureSourceDataProps MainProps;
        private static void FillMainPropsFromString(string item)
        {
            int order = int.MaxValue;
            MainProps = StoGenParser.GetPSPFromString(item, DefaultPath, ref order);

        }
        private static void FillCadreSound(string item, List<SoundItem> soundlist)
        {
            StoGenParser.FillCadreSound(item, soundlist, null, DefaultPath);
        }
        private static void FillCadreName(string item, Cadre LastCadre)
        {
            string[] vals = item.Split('=');
            if (vals.Length > 1)
            {
                LastCadre.Name = vals[1];
            }
        }
        private static void FillMainPicsFromString(StringDataContainer itemCont, Cadre cadre)
        {
            int order = int.MaxValue;
            string item = itemCont.Complete;

            string path = DefaultPath;
            if (itemCont.Original.StartsWith(@"File#") || Path.IsPathRooted(itemCont.Original))
            {
                path = Path.GetDirectoryName(itemCont.Original.Replace(@"File#", string.Empty));
            }

            PictureSourceDataProps psp = StoGenParser.GetPSPFromString(item, path, ref order);

            if (psp != null)
            {
                psp.isMain = true;
                if (psp.Level == PicLevel.None)
                {
                    psp.Level = (PicLevel)0;
                }
                //create main picture data
                PictureSourceDataProps mainPsp = new PictureSourceDataProps();
                // apply common main data
                if (MainProps != null) mainPsp.Assign(MainProps);
                // apply spec main data
                mainPsp.Assign(psp);
                // add main pic
                //cadre = this.GetMainCadre(mainPsp);
                //cadre = new Cadre(this.CurrentProc, true);                
                cadre.PicFrameData.PictureDataList.Add(mainPsp);
                if (order < int.MaxValue) cadre.SortOrder = order;
            }

        }
    }
}
