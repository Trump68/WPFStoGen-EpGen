﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StoGen.Classes
{

    public class Set_View
    {
        public ProcedureBase CurrentProc;
        KeyVarDataContainer KeyVarContainer = new KeyVarDataContainer();
        public Set_View()
        {
        }
        public string Name { get; set; }
        public string Period { get; set; }
        public string Studio { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }


        public int TopPicNum = 0;
        public string DefaultPath;
        public string ScenarioFile;
        List<PictureSourceDataProps> CommonPics = new List<PictureSourceDataProps>();
        public string FirstCadreName = null;
        public virtual ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc, bool isAdd)
        {
            ProcedureBase procpreg = new ProcedureBase(ownerproc.Level + 1);
            procpreg.ShowContextMenuOnInit = false;
            this.CurrentProc = procpreg;
            this.CurrentProc.OnKeyData += OnKeyData;
            procpreg.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, isAdd);
            cadre.GetProcFrame().Proc = procpreg;
            PreProcessFileLists();
            if (!string.IsNullOrEmpty(this.FirstCadreName))
            {
                Cadre cdr = this.CurrentProc.Cadres.FirstOrDefault(x => x.Name == FirstCadreName);
                if (cdr != null)
                {
                    this.CurrentProc.NestedCadreId = this.CurrentProc.Cadres.IndexOf(cdr) - 1;
                }
            }
            
            return procpreg;
        }
   
        public void Init(string name, string path, string country, string period, string studio, string description = null)
        {
            this.Name = name;
            this.Description = description;
            this.Country = country;
            this.Period = period;
            this.Studio = studio;
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
        private void OnKeyData(object sender, EventArgs e)
        {
            this.CurrentProc.CurrentCadre.SoundFrameData.Clear();
            this.CurrentProc.CurrentCadre.GetSoundFrame().SoundList.Clear();
            this.CurrentProc.CurrentCadre.TextFrameData.Clear();

            for (int i = 0; i < this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList.Count; i++)
            {
                if (!this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList[i].isMain)
                {
                    this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList.RemoveAt(i);
                    i--;
                }
            }
            string code = Convert.ToInt32(sender).ToString();
            foreach (SoundItem soundItem in KeyVarContainer.SoundVariableList)
            {
                if (soundItem.Name == code)
                {
                    soundItem.Position = this.CurrentProc.CurrentCadre.SoundFrameData.Count;
                    this.CurrentProc.CurrentCadre.SoundFrameData.Add(soundItem);
                }
            }
            foreach (PictureSourceDataProps commonPic in CommonPics)
            {
                if (commonPic.Name == code)
                {
                    this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList.Add(commonPic);
                }
            }
            foreach (TextData textData in KeyVarContainer.TextVariableList)
            {
                if (textData.Name == code)
                {
                    this.CurrentProc.CurrentCadre.TextFrameData.Add(textData);
                }
            }
            // this.CurrentProc.CurrentCadre.GetTextFrame().Repaint();
            this.CurrentProc.CurrentCadre.GetSoundFrame().Repaint();
            //this.CurrentProc.CurrentCadre.GetImageFrame().Repaint();
            this.CurrentProc.CurrentCadre.Repaint(true);
        }

        private void Reload()
        {
            this.CurrentProc.Clear();
            PreProcessFileLists();
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
            if (ScenarioFile.Contains("~"))
            {
                string[] vals = ScenarioFile.Split('~');
                if (vals.Length == 2)
                {
                    ScenarioFile = vals[0];
                    this.FirstCadreName = vals[1];
                }
            }
            else if (ScenarioFile.Contains("#"))
            {
                string[] vals = ScenarioFile.Split('#');
                if (vals.Length == 2)
                {
                    ScenarioFile = vals[0];
                    part = vals[1];
                }
            }
            if (!string.IsNullOrEmpty(ScenarioFile))
            {
                fn = ScenarioFile;
                DefaultPath = fn.Replace(Path.GetFileName(fn), string.Empty);
            }
           

            if (File.Exists(fn))
            {
                ProcessFileLists(this.CurrentProc,fn, part);
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
            datalist.AddRange(StoGenParser.GetProcessedFile(fn,part,this.KeyVarContainer,null, out header));
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
                        FillMainPicsFromString(item,LastCadre);
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
                    else if (item.Complete.StartsWith(@"RemoveCommon=") && LastCadre != null) RemovePicFromCommon(item.Complete);
                    //else if (item.StartsWith(@"Variant=")) SetVariant(item);

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
            if (item.StartsWith(@"CadreSound=")) StoGenParser.FillCadreSound(item, this.KeyVarContainer.SoundVariableList, codevar.Key.ToString(),this.DefaultPath);
            else if (item.StartsWith(@"DetailPics=")) FillPicsFromString(new StringDataContainer(item,item), this.CommonPics, codevar.Key.ToString());
            else if (item.StartsWith(@"CadreText=")) StoGenParser.FillCadreText(item, this.KeyVarContainer.TextVariableList, datalist.Select(x=>x.Complete).ToList(), codevar.Key.ToString(), null, this.DefaultPath);
        }
        private void FillStoryFromString(string item)
        {
            string[] vals1 = item.Split('#');
            this.KeyVarContainer.StoryList.Add(new KeyVarDataContainer.StoryData() { Group = vals1[1], Name = vals1[2], Path = vals1[3], Description = vals1[4]});
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
            StoGenParser.FillCadreSound(item, soundlist, null,this.DefaultPath);
        }
     
        private void FillCadreName(string item, Cadre LastCadre)
        {
            string[] vals = item.Split('=');
            if (vals.Length > 1)
            {
                LastCadre.Name = vals[1];
            }
        }
        private void RemovePicFromCommon(string item)
        {
            string[] vals = item.Split('=');
            if (vals.Length > 1)
            {
                PictureSourceDataProps existing = null;
                if (CommonPics.Count > 0 && !string.IsNullOrEmpty(vals[1]))
                {
                    existing = CommonPics.FirstOrDefault(data => data.Name == vals[1]);
                    if (existing == null)
                    {
                        string fn = Universe.GetFullPath(vals[1], DefaultPath);
                        existing = CommonPics.FirstOrDefault(data => data.Name == fn);
                    }
                }

                if (existing != null) CommonPics.Remove(existing);
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

            PictureSourceDataProps psp = StoGenParser.GetPSPFromString(item,path, ref order);

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

        #region Menus


        public virtual bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem("File List", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuFileList;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Spec effects", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuSpecEffects;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Arrange Pics", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuArrangePics;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Edit file.. ", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuEditFile;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Set properties.. ", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateSetProperties;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);



            item = new ChoiceMenuItem("Select Key pack.. ", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuSelectKeyVar;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem("Select Story.. ", this);
            item.Executor = data =>
            {
                proc.MenuCreator = CreateMenuSelectStory;
                proc.ShowContextMenu();
            };
            itemlist.Add(item);


            item = new ChoiceMenuItem("Clear Sound.. ", this);
            item.Executor = data =>
            {
                proc.CurrentCadre.SoundFrameData.Clear();
                proc.CurrentCadre.GetSoundFrame().SoundList.Clear();
                proc.CurrentCadre.GetSoundFrame().Repaint();
            };
            itemlist.Add(item);
            if (doShowMenu)
            {
                if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
                {
                    // proc.CurrentCadre.Repaint(true);
                }
            }
            return true;
        }


        private bool CreateMenuSound(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            List<SoundItem> soundlist = new List<SoundItem>();
            foreach (SoundItem si in soundlist)
            {
                item = new ChoiceMenuItem();
                item.Name = si.Name;
                item.Data = si;
                item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", si.Description) };
                item.Executor = data =>
                {
                    proc.CurrentCadre.SoundFrameData.Clear();
                    proc.CurrentCadre.GetSoundFrame().SoundList.Clear();
                    proc.CurrentCadre.SoundFrameData.Add((SoundItem)data);
                };
                itemlist.Add(item);
                proc.MenuCreator = CreateMenu;
            }
            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);

            return true;
        }
        private bool CreateMenuSelectStory(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (this.KeyVarContainer.StoryList.Count == 0)
            {
                proc.MenuCreator = CreateMenu;
            }
            else
            {
                if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
                foreach (KeyVarDataContainer.StoryData storyData in this.KeyVarContainer.StoryList)
                {

                    item = new ChoiceMenuItem();
                    item.Name = storyData.Name.ToString();
                    item.Data = storyData;
                    item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", storyData.Description), new MenuDescriptopnItem("Set", storyData.Group,true) };
                    item.Executor = delegate (object data)
                    {
                       // this.CreateStory((KeyVarDataContainer.StoryData)data);
                    };
                    itemlist.Add(item);
                    proc.MenuCreator = CreateMenu;
                }
                if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
                {
                    proc.MenuCreator = CreateMenu;
                    proc.ShowContextMenu();
                }
                //else proc.CurrentCadre.Repaint(true);

            }
            return true;
        }



        private bool CreateMenuSelectKeyVar(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (this.KeyVarContainer.keyVarList.Count == 0)
            {
                proc.MenuCreator = CreateMenu;
            }
            else
            {
                if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

                foreach (KeyVarDataContainer.KeyVarData variant in this.KeyVarContainer.keyVarList)
                {
                    item = new ChoiceMenuItem();
                    item.Name = variant.Key.ToString();
                    item.Data = variant;
                    item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", variant.Description) };
                    item.Executor = delegate (object data)
                    {
                        this.OnKeyData(((KeyVarDataContainer.KeyVarData)data).Key, EventArgs.Empty);
                        //proc.CurrentVariant = (ProcVariant)data;
                    };
                    itemlist.Add(item);
                    proc.MenuCreator = CreateMenu;
                }
                if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
                {
                    proc.MenuCreator = CreateMenu;
                    proc.ShowContextMenu();
                }
                else proc.CurrentCadre.Repaint(true);

            }
            return true;
        }
        private bool CreateMenuSpecEffects(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            ChoiceMenuItem item = null;
            string caption = "Set blink 10";
            if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blink";
            item = new ChoiceMenuItem(caption, this);
            item.Executor = delegate (object data)
            {
                int timer = proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer;
                if (timer == 0) proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 10;
                else proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 0;
                proc.MenuCreator = CreateMenu;
            };
            itemlist.Add(item);

            caption = "Set blur 10";
            if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blur";
            item = new ChoiceMenuItem(caption, this);
            item.Executor = delegate (object data)
            {
                proc.MenuCreator = CreateMenu;
                int timer = proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer;
                if (timer == 0) proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 10;
                else proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 0;
            };
            itemlist.Add(item);

            caption = "Show/hide clip controls";
            //if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blur";
            item = new ChoiceMenuItem(caption, this);
            item.Executor = delegate (object data)
            {
                proc.MenuCreator = CreateMenu;
               // if (Projector.PicContainer.Clip.uiMode == "none") Projector.PicContainer.Clip.uiMode = "full";
               // else { Projector.PicContainer.Clip.uiMode = "none"; }
            };
            itemlist.Add(item);

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);
            return true;
        }
        private bool CreateMenuArrangePics(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            foreach (PictureSourceDataProps commonPic in this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList)
            {

                item = new ChoiceMenuItem();
                item.Name = "OFF " + Path.GetFileName(commonPic.Name);
                if (!commonPic.Active) item.Name = "ON " + Path.GetFileName(commonPic.Name);
                item.Data = this;
                item.Executor = delegate (object data)
                {
                    proc.MenuCreator = CreateMenu;
                    commonPic.Active = !commonPic.Active;
                };
                itemlist.Add(item);
                proc.MenuCreator = CreateMenu;
            }
            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);
            return true;
        }
        private bool CreateMenuEditFile(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = new ChoiceMenuItem();
            item = new ChoiceMenuItem();
            item.Name = "Scenario";
            item.Data = this;
            item.Executor = delegate (object data)
            {
                string fn = String.Format("{0}FileList.txt", DefaultPath);
                frmTextEdit.ShowForm(fn, null, false);
                Reload();
                proc.MenuCreator = CreateMenu;
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem();
            item = new ChoiceMenuItem();
            item.Name = "Add files to scenario";
            item.Data = this;
            item.Executor = delegate (object data)
            {
                string fn = String.Format("{0}FileList.txt", DefaultPath);
                frmTextEdit.AddFiles(fn);
                Reload();
                proc.MenuCreator = CreateMenu;
            };
            itemlist.Add(item);

            item = new ChoiceMenuItem();
            item.Name = "Text";
            item.Data = this;
            item.Executor = delegate (object data)
            {
                string fn = string.Empty;

                //TextData textdata = this.CurrentProc.CurrentCadre.GetTextDataByVariant(this.CurrentProc.CurrentVariant);
                //if (textdata != null && !string.IsNullOrEmpty(textdata.FileName))
                //{
                //    fn = textdata.FileName;
                //}
                if (string.IsNullOrEmpty(fn))
                {
                    fn = String.Format("{0}{1}.txt", DefaultPath, Path.GetFileNameWithoutExtension(CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0].FileName));
                }
                frmTextEdit.ShowForm(fn, null, false);
                Reload();
                proc.MenuCreator = CreateMenu;
            };
            itemlist.Add(item);


            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);
            return true;
        }
        private bool CreateMenuFileList(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            int i = 0;
            foreach (Cadre cadre in this.CurrentProc.Cadres)
            {

                item = new ChoiceMenuItem();
                item.Name = i.ToString();
                item.Props = new MenuDescriptopnItem[]
                {
                   // new MenuDescriptopnItem("FN", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].OnlyName) ,
                    new MenuDescriptopnItem("Description", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].Description) ,
                    new MenuDescriptopnItem("SetName", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].SetName,true) 
                   // new MenuDescriptopnItem("File", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].FileName),
                    //new MenuDescriptopnItem("Order", this.CurrentProc.Cadres[i].SortOrder.ToString())
                };

                item.Data = i;
                item.Executor = delegate (object data)
                {
                    proc.MenuCreator = CreateMenu;
                    int pos = (int)data;
                    proc.NestedCadreId = pos - 1;
                    proc.GetNextCadre();
                };
                i++;
                itemlist.Add(item);
            }

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);

            return true;
        }
        private bool CreateSetProperties(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();


            item = new ChoiceMenuItem("Main file.. ", this);
            item.Executor = delegate (object data)
            {
                bool forAll = false;
                DialogResult dr = PicPropsEdit.ShowProps(this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0], ref forAll);
                if (dr == DialogResult.OK)
                {
                    string fn = String.Format("{0}FileList.txt", DefaultPath);
                    frmTextEdit.ShowForm(fn, this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0], forAll);
                    proc.CurrentCadre.Repaint(true);
                }
                proc.MenuCreator = CreateMenu;
            };
            itemlist.Add(item);

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                proc.MenuCreator = CreateMenu;
                proc.ShowContextMenu();
            }
            else proc.CurrentCadre.Repaint(true);
            return true;
        }
        #endregion
    }

}
