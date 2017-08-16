using DevExpress.XtraEditors.Controls;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
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
            ProcedureBase procpreg = new ProcedureBase(null, ownerproc.Level + 1);
            procpreg.ShowContextMenuOnInit = false;
            this.CurrentProc = procpreg;
            this.CurrentProc.OnKeyData += OnKeyData;
            procpreg.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, isAdd);
            cadre.GetProcFrame().Proc = procpreg;
            if (PreProcessFileLists(cadre))
            {

            }
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

        private void Reload(Cadre cadre)
        {
            this.CurrentProc.Clear();
            PreProcessFileLists(cadre);
        }

        #region Add data

        public Cadre GetMainCadre(PictureSourceDataProps picdata)
        {
            Cadre cadre = new Cadre(this.CurrentProc, true);
            cadre.PicFrameData.PictureDataList.Add(picdata);
            return cadre;
        }

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
        public virtual bool PreProcessFileLists(Cadre cadre)
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
                ProcessFileLists(cadre, fn, part);
                return true;
            }

            return false;
        }

      
      

        
        public virtual bool ProcessFileLists(Cadre cadre, string fn, string part)
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
                        LastCadre = FillMainPicsFromString(item);
                        LastCadre.Name = item.Mark;
                    }
                    else if (item.Complete.StartsWith(@"CadreText=")) StoGenParser.FillCadreText(item.Complete, LastCadre.TextFrameData, null, null, fn,this.DefaultPath);
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
                catch
                {
                    XtraMessageBox.Show(item.Complete, "!!!!!!", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
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
      
        private Cadre FillMainPicsFromString(StringDataContainer itemCont)
        {
            Cadre cadre = null;
            int order = int.MaxValue;
            string item = itemCont.Complete;

            string path = this.DefaultPath;
            if (itemCont.Original.StartsWith(@"File#"))
            {
                path = Path.GetDirectoryName(itemCont.Original.Replace(@"File#", string.Empty));
            }

            PictureSourceDataProps psp = StoGenParser.GetPSPFromString(item,path, ref order);

            if (psp != null)
            {
                psp.isMain = true;
                //create main picture data
                PictureSourceDataProps mainPsp = new PictureSourceDataProps();
                // apply common main data
                if (MainProps != null) mainPsp.Assign(MainProps);
                // apply spec main data
                mainPsp.Assign(psp);
                // add main pic
                cadre = this.GetMainCadre(mainPsp);
                if (order < int.MaxValue) cadre.SortOrder = order;

            }
            return cadre;
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
                PictureSourceDataProps existing = null;
                if (list.Count > 0 && !string.IsNullOrEmpty(psp.Name)) existing = list.FirstOrDefault(data => data.Name == psp.Name);
                if (existing == null) list.Add(psp);
                else existing.Assign(psp);
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
        private static List<SoundItem> GetSoundlist()
        {
            List<SoundItem> soundlist = new List<SoundItem>();
            soundlist.Add(new SoundItem { Name = "Action-001", Description = "Action fast,v=30", FileName = @"d:\Process2\!Sound\Action\Action-001.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Action-002", Description = "Action slow,v=30", FileName = @"d:\Process2\!Sound\Action\Action-002.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Action-003", Description = "Action slow,v=30", FileName = @"d:\Process2\!Sound\Action\Action-003.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Sadness-01", Description = "Sadness romantic,v=30", FileName = @"d:\Process2\!Sound\Sadness\Sadness-01.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Sadness-02", Description = "Sadness classic,v=30", FileName = @"d:\Process2\!Sound\Sadness\Sadness-02.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Candid 01", Description = "Candid moan, with slaps,v=100", FileName = @"d:\Process2\!Sound\Candid\03 Action.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Candid 02", Description = "Candid moan, with slaps,v=100", FileName = @"d:\Process2\!Sound\Candid\04 Action.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Candid 03", Description = "Candid moan,v=100", FileName = @"d:\Process2\!Sound\Candid\09 Action.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Candid 04", Description = "Candid moan,v=100", FileName = @"d:\Process2\!Sound\Candid\Moaning in Barcelona.mp3", Volume = 100 });

            soundlist.Add(new SoundItem { Name = "Skrip 01", Description = "Candid slow scrip,v=100", FileName = @"d:\Process2\!Sound\Candid\Skrip 01.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 02", Description = "Candid fast scrip,v=100", FileName = @"d:\Process2\!Sound\Candid\Skrip 02.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 03", Description = "Scrip slow,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip01.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 04", Description = "Scrip fast,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip02.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 05", Description = "Scrip slow,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip04.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 06", Description = "Scrip slow,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip05.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Skrip 07", Description = "Scrip fast,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip06.mp3", Volume = 100 });

            soundlist.Add(new SoundItem { Name = "Skrip with moans 01", Description = "Scrip with moans,v=100", FileName = @"d:\Process2\!Sound\Skrip\Skrip01a.mp3", Volume = 100 });

            soundlist.Add(new SoundItem { Name = "Classic music 01", Description = "Tatyana aria,v=30", FileName = @"d:\Process2\!Sound\Classic\Classic-01.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Club music 01", Description = "Club (moy body,my pussy),v=30", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Club music 02", Description = "Club,v=30", FileName = @"d:\Process2\!Sound\Club\Club02.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Club music 03", Description = "Club,v=30", FileName = @"d:\Process2\!Sound\Club\Club03.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Club music 04", Description = "Club,v=30", FileName = @"d:\Process2\!Sound\Club\Club04.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Club music 05", Description = "Club,v=30", FileName = @"d:\Process2\!Sound\Club\Club05.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Fuck 01", Description = "TOT (Pelmen,Alena),v=100", FileName = @"d:\Process2\!Sound\FuckAction\[TOT]-Alena (HI).mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Moan 01", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 001.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Moan 02", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 002.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Moan 03", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 003.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Moan 04", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 004.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Moan 05", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 005.mp3", Volume = 30 });

            soundlist.Add(new SoundItem { Name = "Romantic 01", Description = "Romantic music,v=30", FileName = @"d:\Process2\!Sound\Romantic\Romantic-01.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Romantic 02", Description = "Romantic, uneasy music,v=30", FileName = @"d:\Process2\!Sound\Romantic\Romantic-02.mp3", Volume = 30 });
            soundlist.Add(new SoundItem { Name = "Romantic 03", Description = "Romantic (saksofon) ,v=30", FileName = @"d:\Process2\!Sound\Romantic\Romantic-03.mp3", Volume = 30 });

            soundlist.Add(new SoundItem { Name = "Wisper 01", Description = "Wisper and kissing ,v=100", FileName = @"d:\Process2\!Sound\Wisper\Close Up- kisses and whispering.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Wispering talk 01", Description = "Wispering talk russian ,v=100", FileName = @"d:\Process2\!Sound\Wisper\RusWisper01long.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Wispering talk 02", Description = "Wispering talk russian ,v=100", FileName = @"d:\Process2\!Sound\Wisper\АСМР на русском Шепот Болтовня-2.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Wispering talk 03", Description = "Wispering talk russian ,v=100", FileName = @"d:\Process2\!Sound\Wisper\АСМР на русском Шепот Болтовня-3.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Wispering talk kisses", Description = "Wispering talk kisses russian ,v=100", FileName = @"d:\Process2\!Sound\Wisper\АСМР на русском kisses 03.mp3", Volume = 100 });
            soundlist.Add(new SoundItem { Name = "Wispering role play medical exam", Description = "Wispering talk kisses russian ,v=100", FileName = @"d:\Process2\!Sound\Wisper\Role play for Sleep Medical exam.mp3", Volume = 100 });
            return soundlist;
        }
        private static List<List<SoundItem>> GetSoundCombinationlist()
        {
            List<List<SoundItem>> soundcombinationlist = new List<List<SoundItem>>();
            List<SoundItem> soundlist = null;

            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Action 01 & Moan 01", Description = "Action-01 (v10) and Moan-01 (v100)", FileName = @"d:\Process2\!Sound\Action\Action-001.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 01", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 001.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Action 02 & Moan 01", Description = "Action-02 (v10) and Moan-01 (v100)", FileName = @"d:\Process2\!Sound\Action\Action-002.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 01", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 001.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Action 03 & Moan 01", Description = "Action-03 (v10) and Moan-01 (v100)", FileName = @"d:\Process2\!Sound\Action\Action-003.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 01", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 001.mp3", Volume = 100 }});

            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Club-01 & Moan-01", Description = "Club-01 (v10) and Moan-01 (v100)", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 01", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 001.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Club-01 & Moan-02", Description = "Club-01 (v10) and Moan-02 (v100)", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 02", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 002.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Club-01 & Moan-03", Description = "Club-01 (v10) and Moan-03 (v100)", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 03", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 003.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Club-01 & Moan-04", Description = "Club-01 (v10) and Moan-04 (v100)", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 04", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 004.mp3", Volume = 100 }});
            soundcombinationlist.Add(new List<SoundItem> {
            new SoundItem { Name = "Club-01 & Moan-05", Description = "Club-01 (v10) and Moan-05 (v100)", FileName = @"d:\Process2\!Sound\Club\Club01.mp3", Volume = 10 },
            new SoundItem { Name = "Moan 05", Description = "Fem moaning,v=30", FileName = @"d:\Process2\!Sound\Moans\Moan 005.mp3", Volume = 100 }});




            return soundcombinationlist;
        }

        private bool CreateMenuSound(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = null;

            List<SoundItem> soundlist = GetSoundlist();
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
                Reload(this.CurrentProc.Cadres[0]);
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
                Reload(this.CurrentProc.Cadres[0]);
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
                Reload(this.CurrentProc.Cadres[0]);
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






    public class CycleProc : ProcedureBase
    {
        public List<Set_View> sets = new List<Set_View>();
        public List<CycleProc> setsA = new List<CycleProc>();
        public CycleProc(int level)
            : base(null, level)
        {
            this.CurrentContext = new Context();
            this.MenuCreator = CreateMenu;
        }
        public CycleProc(string fn)
           : base(null, 0)
        {
            this.CurrentContext = new Context();
            this.MenuCreator = CreateMenu;
            AddNewSet("DUMMY", "DUMMY", fn, null, null, null, null);
            ProcedureBase innerproc = this.setsA.First().sets.First().InsertAsProcedureTo(this, true);
            //innerproc.MenuCreator = ((Set_View)data).CreateMenu;
            this.GetNextCadre();
        }
        ProcedureBase ParentProc = null;
        public ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc)
        {
            this.Clear(); // remove first empty cadre
            Cadre cadre = new Cadre(ownerproc, true);
            cadre.GetProcFrame().Proc = this;
            this.ParentProc = ownerproc;
            return this;
        }
        public override bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            foreach (Set_View set in sets)
            {
                item = new ChoiceMenuItem(
                    set.Name, set,
                    new MenuDescriptopnItem("Period", set.Period),
                    new MenuDescriptopnItem("Country", set.Country),
                    new MenuDescriptopnItem("Studio", set.Studio),
                    new MenuDescriptopnItem("Description", set.Description)
                    );
                item.Executor = delegate (object data)
                {
                    ProcedureBase innerproc = ((Set_View)data).InsertAsProcedureTo(this, true);
                    innerproc.MenuCreator = ((Set_View)data).CreateMenu;                    
                    this.GetNextCadre();
                    //innerproc.ShowContextMenu();
                };
                itemlist.Add(item);
            }
            foreach (CycleProc cyc in setsA)
            {
                item = new ChoiceMenuItem(cyc.Name, cyc);
                item.Executor = delegate (object data)
                {
                    ProcedureBase innerproc = ((CycleProc)data).InsertAsProcedureTo(this);
                    innerproc.MenuCreator = ((CycleProc)data).CreateMenu;
                    this.GetNextCadre();
                };
                itemlist.Add(item);
            }

            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {
                this.ParentProc.InnerProc = null;
                this.ParentProc.ShowContextMenu();
            }
            return true;
        }
        public CycleProc AddNewCycle(string name)
        {
            CycleProc cyc = new CycleProc(this.Level);
            cyc.Name = name;
            this.setsA.Add(cyc);
            return cyc;
        }
        public Set_View AddNewSet(string name, string path, CycleProc cyc, string country, string period, string studio, string description = null)
        {
            Set_View set = new Set_View();
            set.Init(name, path, country, period, studio, description);
            cyc.sets.Add(set);
            return set;
        }
        public Set_View AddNewSet(string nameCyc, string nameSet, string path, string country, string period, string studio, string description = null)
        {
            CycleProc cyc = this.setsA.FirstOrDefault(c => c.Name == nameCyc);
            if (cyc == null) cyc = this.AddNewCycle(nameCyc);
            return this.AddNewSet(nameSet, path, cyc, country, period, studio, description);
        }

        public string Description { get; set; }
    }
    public class StringDataContainer
    {
        public string Original;
        public string Complete;
        public string Mark;
        public StringDataContainer(string original, string complete) { Original = original;Complete = complete; }
    }
    public static class StoGenParser
    {
        public static List<StringDataContainer> GetProcessedFile(string fn, string part, KeyVarDataContainer KeyVarContainer, string original, out List<string> header)
        {
            header = new List<string>();
            bool headerend = false;
            List<string> datalist = Universe.LoadFileToStringList(fn.Trim());
            List<StringDataContainer> listtoprocess = new List<StringDataContainer>();
            bool checkpart = !string.IsNullOrEmpty(part);
            bool checkpartOk = false;
            string currentmark = null;
            foreach (string item in datalist)
            {
                if (item.Trim().StartsWith(@"PartSta#"))
                {
                    currentmark = item.Trim().Replace(@"PartSta#", string.Empty);
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
                    var pf = ApplayFile(item, KeyVarContainer, originalitem);
                    listtoprocess.AddRange(pf);
                }
                else if (item.StartsWith(@"#"))
                {
                    var it = new StringDataContainer(originalitem, ApplayInline(item, KeyVarContainer));
                    it.Mark = currentmark;
                    listtoprocess.Add(it);
                }
                else
                {
                    var it = new StringDataContainer(originalitem, item);
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
        private static List<StringDataContainer> ApplayFile(string item, KeyVarDataContainer KeyVarContainer, string original)
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
                result = GetProcessedFile(vals[1], part, KeyVarContainer, originalitem, out header);
            }
            return result;
        }

        private static void AddInline(string item,KeyVarDataContainer KeyVarContainer)
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
                else if (vals[0] == "Width")
                {
                    data.Width = Convert.ToInt32(vals[1]);
                }
                else if (vals[0] == "ClearBack")
                {
                    data.ClearBack = Convert.ToInt32(vals[1])==1;
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
                    p = new PictureSourceDataProps(Universe.GetFullPath(val, DefaultPath));
                }
                else if (mark == "CommonPics" || mark == "DetailPics")
                {
                    p = new PictureSourceDataProps(Universe.GetFullPath(val, DefaultPath));
                    p.Active = true;
                }
                else if (mark == "MainProps")
                {
                    p = new PictureSourceDataProps(string.Empty);
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
                else if (mark == "X") p.X = Convert.ToInt32(val);
                else if (mark == "Y") p.Y = Convert.ToInt32(val);
                else if (mark == "SizeX") p.SizeX = Convert.ToInt32(val);
                else if (mark == "SizeY") p.SizeY = Convert.ToInt32(val);
                else if (mark == "Rotate") p.Rotate = Convert.ToInt32(val);
                else if (mark == "Flip") p.Flip = (RotateFlipType)Convert.ToInt32(val);
                else if (mark == "R") p.R = Convert.ToInt32(val);
                else if (mark == "Blur") p.Blur = Convert.ToInt32(val);
                else if (mark == "Level")
                {
                    p.Level = (PicLevel)(Convert.ToInt32(val));
                }
                else if (mark == "Opacity") p.Opacity = Convert.ToInt32(val);
                else if (mark == "Flash") p.Flash = val;
                else if (mark == "Name") p.Name = val;
                else if (mark == "Desc") p.Description = val;
                else if (mark == "SetName")
                {
                    p.SetName = val;
                }
                else if (mark == "Timer") p.Timer = Convert.ToInt32(val);
                else if (mark == "Timer2") p.Timer2 = Convert.ToInt32(val);
                else if (mark == "SizeMode") p.SizeMode = (PictureSizeMode)Convert.ToInt32(val);
                else if (mark.Trim() == "Active")
                {
                    if (val.Trim() == "0") p.Active = false;
                    else p.Active = true;
                }
                else if (mark.Trim() == "Reload")
                {
                    if (val.Trim() == "0") p.Reload = false;
                    else p.Reload = true;
                }
                else if (mark.Trim() == "IsLoop")
                {
                    p.isLoop = Convert.ToInt32(val);
                }
                else if (mark.Trim() == "PP")
                {
                    p.PP1 = Convert.ToInt32(val);
                    p.PP2 = p.PP1;
                }
                else if (mark.Trim() == "PP1")
                {
                    p.PP1 = Convert.ToInt32(val);
                }
                else if (mark.Trim() == "PP2")
                {
                    p.PP2 = Convert.ToInt32(val);
                }
                else if (mark.Trim() == "Rate")
                {
                    p.Rate = (AnimationRate)Convert.ToInt32(val);
                }
                else if (mark.Trim() == "Core")
                {
                    if (val.Trim() == "0") p.isMain = false;
                    else p.isMain = true;
                }
                else if (mark.Trim() == "StartPos")
                {
                    if (!string.IsNullOrEmpty(val))
                        p.StartPos = Convert.ToDouble(val);
                }
                else if (mark.Trim() == "EndPos")
                {
                    if (!string.IsNullOrEmpty(val))
                        p.EndPos = Convert.ToDouble(val);
                }
                else if (mark.Trim() == "NextCadre")
                {
                    p.NextCadre = Convert.ToDouble(val);
                }
                else if (mark == "Order") CadreOrder = Convert.ToInt32(val);

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

            if (si != null) soundlist.Add(si);
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
                else if (vals[0] == "Name")
                {
                    si.Name = vals[1];
                }
                else if (vals[0] == "Position")
                {
                    si.Position = Convert.ToInt32(vals[1]);
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
    }
}
