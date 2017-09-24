using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public class ScenarioSet
    {
        public KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        public List<PictureSourceDataProps> CommonPics = new List<PictureSourceDataProps>();
        public ProcedureBase CurrentProc;
        public string DefaultPath;
        public string ScenarioFile;
        public virtual void Init(string path)
        {
            string fn = null;
            try
            {
                fn = Path.GetFileName(path);
            }
            catch (Exception)
            {

                string fn1 = path;
            }

            if (string.IsNullOrEmpty(fn))
            {
                this.DefaultPath = path;
            }
            else
            {
                this.ScenarioFile = path;
                this.DefaultPath = Path.GetFullPath(this.ScenarioFile);
            }
        }
        public virtual ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc, bool isAdd)
        {
            ProcedureBase procpreg = new ProcedureBase(ownerproc.Level + 1);
            procpreg.ShowContextMenuOnInit = false;
            this.CurrentProc = procpreg;           
            procpreg.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, isAdd);
            cadre.GetProcFrame().Proc = procpreg;
            PreProcessFileLists();          
            return procpreg;
        }

        #region Add data


        public virtual PictureSourceDataProps GetPic(int num, string format)
        {
            return GetPic(String.Format("{1}{0,3:D3}.{2}", num, DefaultPath, format));
        }
        public virtual PictureSourceDataProps GetPic(string fn)
        {
            PictureSourceDataProps psp
                = new PictureSourceDataProps(fn);
            psp.Level = PicLevel.Foreground;
            psp.SizeX = 800;
            psp.SizeY = 600;
            psp.isVideo = false;
            return psp;
        }
        #endregion

        #region Fill cadres from filelist
        public virtual bool PreProcessFileLists()
        {
            string fn = string.Empty;
            string part = null;

            if (!string.IsNullOrEmpty(ScenarioFile))
            {
                fn = ScenarioFile;
                DefaultPath = fn.Replace(Path.GetFileName(fn), string.Empty);
            }


            if (File.Exists(fn))
            {
                ProcessFileLists(this.CurrentProc, fn, part);
                return true;
            }

            return false;
        }
        public virtual bool ProcessFileLists(ProcedureBase proc, string fn, string part)
        {
            List<string> header;
            List<StringDataContainer> datalist = new List<StringDataContainer>();
            string commonFile = $"{ this.DefaultPath}{"Common.stogen"}";
            if (File.Exists(commonFile))
            {
                datalist.AddRange(StoGenParser.GetProcessedFile(commonFile, part, this.KeyVarContainer, null, out header));
            }
            datalist.AddRange(StoGenParser.GetProcessedFile(fn, part, this.KeyVarContainer, null, out header));
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
                        if (this.KeyVarContainer.TextInlines.ContainsKey(key))
                        {
                            key = "dontadd";
                        }
                        else
                        {
                            this.KeyVarContainer.TextInlines.Add(key, string.Empty);
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
                            this.KeyVarContainer.TextInlines[key] = this.KeyVarContainer.TextInlines[key] + item;
                    }

                    else if (item.Complete.StartsWith(@"Scenario#")) FillStoryFromString(item.Complete);
                    else if (item.Complete.StartsWith(@"ScenarioParam#")) FillStoryParamFromString(item.Complete);
                    else if (item.Complete.StartsWith(@"CommonPics=")) FillPicsFromString(item, CommonPics);
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
                            FillPicsFromString(item, LastCadre.PicFrameData.PictureDataList);
                        }
                    }
                    else if (item.Complete.StartsWith(@"CadreText="))
                    {
                        StoGenParser.FillCadreText(item.Complete, LastCadre.TextFrameData, null, null, fn, this.DefaultPath);
                    }
                    else if (item.Complete.StartsWith(@"CadreSound="))
                    {
                        FillCadreSound(item.Complete, LastCadre.SoundFrameData);
                    }
                    else if (item.Complete.StartsWith(@"CadreName=")) FillCadreName(item.Complete, LastCadre);
                    else if (item.Complete.StartsWith(@"DetailPics=") && LastCadre != null)
                    {
                        FillPicsFromString(item, LastCadre.PicFrameData.PictureDataList);
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

        private void AddToCodeVar(KeyVarDataContainer.KeyVarData codevar, string item, List<StringDataContainer> datalist)
        {
            bool found = false;
            foreach (KeyVarDataContainer.KeyVarData keyVarData in this.KeyVarContainer.keyVarList)
            {
                if (keyVarData.Key == codevar.Key)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                this.KeyVarContainer.keyVarList.Add(codevar);
            if (item.StartsWith(@"CadreSound=")) StoGenParser.FillCadreSound(item, this.KeyVarContainer.SoundVariableList, codevar.Key.ToString(), this.DefaultPath);
            else if (item.StartsWith(@"DetailPics=")) FillPicsFromString(new StringDataContainer(item, item), this.CommonPics, codevar.Key.ToString());
            else if (item.StartsWith(@"CadreText=")) StoGenParser.FillCadreText(item, this.KeyVarContainer.TextVariableList, datalist.Select(x => x.Complete).ToList(), codevar.Key.ToString(), null, this.DefaultPath);
        }
        private void FillStoryFromString(string item)
        {
            string[] vals1 = item.Split('#');
            this.KeyVarContainer.StoryList.Add(new KeyVarDataContainer.StoryData() { Group = vals1[1], Name = vals1[2], Path = vals1[3], Description = vals1[4] });
        }
        private void FillStoryParamFromString(string item)
        {
            this.KeyVarContainer.StoryList.Last().ParamList.Add(item.Replace("ScenarioParam#", string.Empty));
        }
        private void SortCadres()
        {
            this.CurrentProc.Cadres.Sort(delegate (Cadre x, Cadre y)
            {
                return x.SortOrder.CompareTo(y.SortOrder);
            });
        }
        PictureSourceDataProps MainProps;
        private void FillMainPropsFromString(string item)
        {
            int order = int.MaxValue;
            MainProps = StoGenParser.GetPSPFromString(item, this.DefaultPath, ref order);

        }
        private void FillCadreSound(string item, List<SoundItem> soundlist)
        {
            StoGenParser.FillCadreSound(item, soundlist, null, this.DefaultPath);
        }

        private void FillCadreName(string item, Cadre LastCadre)
        {
            string[] vals = item.Split('=');
            if (vals.Length > 1)
            {
                LastCadre.Name = vals[1];
            }
        }
      

        private void FillMainPicsFromString(StringDataContainer itemCont, Cadre cadre)
        {
            int order = int.MaxValue;
            string item = itemCont.Complete;

            string path = this.DefaultPath;
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
        private void FillPicsFromString(StringDataContainer itemCont, List<PictureSourceDataProps> list)
        {
            FillPicsFromString(itemCont, list, null);
        }
        private void FillPicsFromString(StringDataContainer itemCont, List<PictureSourceDataProps> list, string name)
        {
            string item = itemCont.Complete;

            string path = this.DefaultPath;
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

        private void CreateFileList()
        {
            string fn = String.Format("{0}FileList.txt", DefaultPath);
            frmTextEdit.ShowForm(fn, null, false);
        }
        #endregion
    }
}
