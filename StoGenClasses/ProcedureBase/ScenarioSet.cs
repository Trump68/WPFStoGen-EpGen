using DevExpress.XtraEditors;
using StoGen.Classes.Interfaces;
using StoGenMake.Elements;
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
        public IMenuCreator GlobalMenuCreator = null;
        
        
        public ProcedureBase CurrentProc;

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
                //StoGenParser.DefaultPath = path;
            }
            else
            {
                this.ScenarioFile = path;
                //StoGenParser.DefaultPath = Path.GetFullPath(this.ScenarioFile);
            }
        }
        public virtual ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc, bool isAdd)
        {
  
            this.CurrentProc = ownerproc;
            this.CurrentProc.ShowContextMenuOnInit = false;
            this.CurrentProc.Clear();

            Cadre cadre = new Cadre(this.CurrentProc, isAdd);
            cadre.ProcFr.Proc = this.CurrentProc;
            this.CurrentProc.MenuCreator = this.CreateMenu;

            //PreProcessFileLists(this.ScenarioFile);          
            PreProcessFileLists();
            return this.CurrentProc;
        }



        #region Fill cadres from filelist
        // Replace from SCENE !!!!!!
        //public virtual bool PreProcessFileLists(string ScenarioFile)
        //{
        //    string fn = string.Empty;
        //    string part = null;

        //    if (!string.IsNullOrEmpty(ScenarioFile))
        //    {
        //        fn = ScenarioFile;
        //        StoGenParser.DefaultPath = fn.Replace(Path.GetFileName(fn), string.Empty);
        //    }


        //    if (File.Exists(fn))
        //    {
        //        StoGenParser.AddCadresToProcFromFile(this.CurrentProc, fn, part, StoGenParser.DefaultPath);
        //        return true;
        //    }

        //    return false;
        //}

        public virtual bool PreProcessFileLists(string ScenarioFile)
        {
            return false;
        }
        public virtual bool PreProcessFileLists()
        {
            var i = 0;
            foreach (var ad in this.CurrentProc.Scene.AlignList)
            {                
                var AppCadre = new Cadre(this.CurrentProc, true);
                AppCadre.AlignData = ad;
                //foreach (seIm data in cdr.VisionList)
                //{
                //    var ids = data.ToPictureDataSource();
                //    ids.Level = (PicLevel)(cdr.VisionList.IndexOf(data));
                //    AppCadre.PicFrameData.PictureDataList.Add(ids);
                //}
                //foreach (seSo data in cdr.SoundList)
                //{
                //    var sds = data.ToSoundDataSource();
                //    sds.Position = cdr.SoundList.IndexOf(data);
                //    AppCadre.SoundFrameData.Add(sds);
                //}
                //foreach (seTe data in cdr.TextList)
                //{
                //    AppCadre.TextFrameData.Add(data.ToTextDataSource());
                //}
            }
            return true;         
        }

        #endregion

        //public void Reload()
        //{
        //    this.CurrentProc.Clear();
        //    PreProcessFileLists(this.ScenarioFile);
        //}

        public virtual bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            this.GlobalMenuCreator.CreateMenu(proc, doShowMenu, itemlist, Data);

            //if (doShowMenu)
            //{
            //    if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
            //    {
            //        // proc.CurrentCadre.Repaint(true);
            //    }
            //}

            return true;
        }

      
    }
}
