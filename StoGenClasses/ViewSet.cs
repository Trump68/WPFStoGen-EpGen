using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StoGen.Classes
{

    public class Set_View: ScenarioSet
    {

       
        public Set_View():base()
        {
        }
        public string Name { get; set; }
        public string Period { get; set; }
        public string Studio { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public override bool PreProcessFileLists(string ScenarioFile)
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
                StoGenParser.DefaultPath = fn.Replace(Path.GetFileName(fn), string.Empty);
            }


            if (File.Exists(fn))
            {
                StoGenParser.AddCadresToProcFromFile(this.CurrentProc, fn, part, StoGenParser.DefaultPath);
                return true;
            }

            return false;
        }
        public int TopPicNum = 0;

        
        public string FirstCadreName = null;
        public override ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc, bool isAdd)
        {
            ProcedureBase procpreg = base.InsertAsProcedureTo(ownerproc, isAdd);

            this.CurrentProc.OnKeyData += OnKeyData;
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
            base.Init(path);
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
            foreach (SoundItem soundItem in StoGenParser.KeyVarContainer.SoundVariableList)
            {
                if (soundItem.Name == code)
                {
                    soundItem.Position = this.CurrentProc.CurrentCadre.SoundFrameData.Count;
                    this.CurrentProc.CurrentCadre.SoundFrameData.Add(soundItem);
                }
            }
            foreach (PictureSourceDataProps commonPic in StoGenParser.CommonPics)
            {
                if (commonPic.Name == code)
                {
                    this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList.Add(commonPic);
                }
            }
            foreach (TextData textData in StoGenParser.KeyVarContainer.TextVariableList)
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

       

     

        //#region Menus


        public override bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            //ChoiceMenuItem item = null;
            //if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            //item = new ChoiceMenuItem("File List", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuFileList;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);

            //item = new ChoiceMenuItem("Spec effects", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuSpecEffects;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);

            //item = new ChoiceMenuItem("Arrange Pics", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuArrangePics;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);

            //item = new ChoiceMenuItem("Edit file.. ", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuEditFile;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);

            //item = new ChoiceMenuItem("Set properties.. ", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateSetProperties;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);



            //item = new ChoiceMenuItem("Select Key pack.. ", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuSelectKeyVar;
            //    proc.ShowContextMenu(doShowMenu, data);
            //};
            //itemlist.Add(item);

            //item = new ChoiceMenuItem("Select Story.. ", this);
            //item.Executor = data =>
            //{
            //    proc.MenuCreator = CreateMenuSelectStory;
            //    proc.ShowContextMenu();
            //};
            //itemlist.Add(item);


            //item = new ChoiceMenuItem("Clear Sound.. ", this);
            //item.Executor = data =>
            //{
            //    proc.CurrentCadre.SoundFrameData.Clear();
            //    proc.CurrentCadre.GetSoundFrame().SoundList.Clear();
            //    proc.CurrentCadre.GetSoundFrame().Repaint();
            //};
            //itemlist.Add(item);
            //if (doShowMenu)
            //{
            //    if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
            //    {
            //        // proc.CurrentCadre.Repaint(true);
            //    }
            //}
            return true;
        }


        //private bool CreateMenuSound(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    ChoiceMenuItem item = null;

        //    List<SoundItem> soundlist = new List<SoundItem>();
        //    foreach (SoundItem si in soundlist)
        //    {
        //        item = new ChoiceMenuItem();
        //        item.Name = si.Name;
        //        item.itemData = si;
        //        item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", si.Description) };
        //        item.Executor = data =>
        //        {
        //            proc.CurrentCadre.SoundFrameData.Clear();
        //            proc.CurrentCadre.GetSoundFrame().SoundList.Clear();
        //            proc.CurrentCadre.SoundFrameData.Add((SoundItem)data);
        //        };
        //        itemlist.Add(item);
        //        proc.MenuCreator = CreateMenu;
        //    }
        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);

        //    return true;
        //}
        //private bool CreateMenuSelectStory(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (StoGenParser.KeyVarContainer.StoryList.Count == 0)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //    }
        //    else
        //    {
        //        if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //        foreach (KeyVarDataContainer.StoryData storyData in StoGenParser.KeyVarContainer.StoryList)
        //        {

        //            item = new ChoiceMenuItem();
        //            item.Name = storyData.Name.ToString();
        //            item.itemData = storyData;
        //            item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", storyData.Description), new MenuDescriptopnItem("Set", storyData.Group,true) };
        //            item.Executor = delegate (object data)
        //            {
        //               // this.CreateStory((KeyVarDataContainer.StoryData)data);
        //            };
        //            itemlist.Add(item);
        //            proc.MenuCreator = CreateMenu;
        //        }
        //        if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //        {
        //            proc.MenuCreator = CreateMenu;
        //            proc.ShowContextMenu();
        //        }
        //        //else proc.CurrentCadre.Repaint(true);

        //    }
        //    return true;
        //}
        //private bool CreateMenuSelectKeyVar(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (StoGenParser.KeyVarContainer.keyVarList.Count == 0)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //    }
        //    else
        //    {
        //        if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

        //        foreach (KeyVarDataContainer.KeyVarData variant in StoGenParser.KeyVarContainer.keyVarList)
        //        {
        //            item = new ChoiceMenuItem();
        //            item.Name = variant.Key.ToString();
        //            item.itemData = variant;
        //            item.Props = new MenuDescriptopnItem[] { new MenuDescriptopnItem("Description", variant.Description) };
        //            item.Executor = delegate (object data)
        //            {
        //                this.OnKeyData(((KeyVarDataContainer.KeyVarData)data).Key, EventArgs.Empty);
        //                //proc.CurrentVariant = (ProcVariant)data;
        //            };
        //            itemlist.Add(item);
        //            proc.MenuCreator = CreateMenu;
        //        }
        //        if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //        {
        //            proc.MenuCreator = CreateMenu;
        //            proc.ShowContextMenu();
        //        }
        //        else proc.CurrentCadre.Repaint(true);

        //    }
        //    return true;
        //}
        //private bool CreateMenuSpecEffects(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

        //    ChoiceMenuItem item = null;
        //    string caption = "Set blink 10";
        //    if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blink";
        //    item = new ChoiceMenuItem(caption, this);
        //    item.Executor = delegate (object data)
        //    {
        //        int timer = proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer;
        //        if (timer == 0) proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 10;
        //        else proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 0;
        //        proc.MenuCreator = CreateMenu;
        //    };
        //    itemlist.Add(item);

        //    caption = "Set blur 10";
        //    if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blur";
        //    item = new ChoiceMenuItem(caption, this);
        //    item.Executor = delegate (object data)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        int timer = proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer;
        //        if (timer == 0) proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 10;
        //        else proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer = 0;
        //    };
        //    itemlist.Add(item);

        //    caption = "Show/hide clip controls";
        //    //if (proc.CurrentCadre.PicFrameData.PictureDataList[0].Timer == 0) caption = "Remove blur";
        //    item = new ChoiceMenuItem(caption, this);
        //    item.Executor = delegate (object data)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //       // if (Projector.PicContainer.Clip.uiMode == "none") Projector.PicContainer.Clip.uiMode = "full";
        //       // else { Projector.PicContainer.Clip.uiMode = "none"; }
        //    };
        //    itemlist.Add(item);

        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);
        //    return true;
        //}
        //private bool CreateMenuArrangePics(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    foreach (PictureSourceDataProps commonPic in this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList)
        //    {

        //        item = new ChoiceMenuItem();
        //        item.Name = "OFF " + Path.GetFileName(commonPic.Name);
        //        if (!commonPic.Active) item.Name = "ON " + Path.GetFileName(commonPic.Name);
        //        item.itemData = this;
        //        item.Executor = delegate (object data)
        //        {
        //            proc.MenuCreator = CreateMenu;
        //            commonPic.Active = !commonPic.Active;
        //        };
        //        itemlist.Add(item);
        //        proc.MenuCreator = CreateMenu;
        //    }
        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);
        //    return true;
        //}
        //private bool CreateMenuEditFile(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    ChoiceMenuItem item = new ChoiceMenuItem();
        //    item = new ChoiceMenuItem();
        //    item.Name = "Scenario";
        //    item.itemData = this;
        //    item.Executor = delegate (object data)
        //    {
        //        string fn = String.Format("{0}FileList.txt", StoGenParser.DefaultPath);
        //        frmTextEdit.ShowForm(fn, null, false);
        //        Reload();
        //        proc.MenuCreator = CreateMenu;
        //    };
        //    itemlist.Add(item);

        //    item = new ChoiceMenuItem();
        //    item = new ChoiceMenuItem();
        //    item.Name = "Add files to scenario";
        //    item.itemData = this;
        //    item.Executor = delegate (object data)
        //    {
        //        string fn = String.Format("{0}FileList.txt", StoGenParser.DefaultPath);
        //        frmTextEdit.AddFiles(fn);
        //        Reload();
        //        proc.MenuCreator = CreateMenu;
        //    };
        //    itemlist.Add(item);

        //    item = new ChoiceMenuItem();
        //    item.Name = "Text";
        //    item.itemData = this;
        //    item.Executor = delegate (object data)
        //    {
        //        string fn = string.Empty;

        //        //TextData textdata = this.CurrentProc.CurrentCadre.GetTextDataByVariant(this.CurrentProc.CurrentVariant);
        //        //if (textdata != null && !string.IsNullOrEmpty(textdata.FileName))
        //        //{
        //        //    fn = textdata.FileName;
        //        //}
        //        if (string.IsNullOrEmpty(fn))
        //        {
        //            fn = String.Format("{0}{1}.txt", StoGenParser.DefaultPath, Path.GetFileNameWithoutExtension(CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0].FileName));
        //        }
        //        frmTextEdit.ShowForm(fn, null, false);
        //        Reload();
        //        proc.MenuCreator = CreateMenu;
        //    };
        //    itemlist.Add(item);


        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);
        //    return true;
        //}
        //private bool CreateMenuFileList(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
        //    int i = 0;
        //    foreach (Cadre cadre in this.CurrentProc.Cadres)
        //    {

        //        item = new ChoiceMenuItem();
        //        item.Name = i.ToString();
        //        item.Props = new MenuDescriptopnItem[]
        //        {
        //           // new MenuDescriptopnItem("FN", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].OnlyName) ,
        //            new MenuDescriptopnItem("Description", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].Description) ,
        //            new MenuDescriptopnItem("SetName", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].SetName,true) 
        //           // new MenuDescriptopnItem("File", this.CurrentProc.Cadres[i].PicFrameData.PictureDataList[0].FileName),
        //            //new MenuDescriptopnItem("Order", this.CurrentProc.Cadres[i].SortOrder.ToString())
        //        };

        //        item.itemData = i;
        //        item.Executor = delegate (object data)
        //        {
        //            proc.MenuCreator = CreateMenu;
        //            int pos = (int)data;
        //            proc.NestedCadreId = pos - 1;
        //            proc.GetNextCadre();
        //        };
        //        i++;
        //        itemlist.Add(item);
        //    }

        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);

        //    return true;
        //}
        //private bool CreateSetProperties(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();


        //    item = new ChoiceMenuItem("Main file.. ", this);
        //    item.Executor = delegate (object data)
        //    {
        //        bool forAll = false;
        //        DialogResult dr = PicPropsEdit.ShowProps(this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0], ref forAll);
        //        if (dr == DialogResult.OK)
        //        {
        //            string fn = String.Format("{0}FileList.txt", StoGenParser.DefaultPath);
        //            frmTextEdit.ShowForm(fn, this.CurrentProc.CurrentCadre.PicFrameData.PictureDataList[0], forAll);
        //            proc.CurrentCadre.Repaint(true);
        //        }
        //        proc.MenuCreator = CreateMenu;
        //    };
        //    itemlist.Add(item);

        //    if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
        //    {
        //        proc.MenuCreator = CreateMenu;
        //        proc.ShowContextMenu();
        //    }
        //    else proc.CurrentCadre.Repaint(true);
        //    return true;
        //}
        //#endregion
    }

}
