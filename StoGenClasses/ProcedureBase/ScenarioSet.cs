using DevExpress.XtraEditors;
using StoGen.Classes.Interfaces;
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
                StoGenParser.DefaultPath = path;
            }
            else
            {
                this.ScenarioFile = path;
                StoGenParser.DefaultPath = Path.GetFullPath(this.ScenarioFile);
            }
        }
        public virtual ProcedureBase InsertAsProcedureTo(ProcedureBase ownerproc, bool isAdd)
        {
            //this.CurrentProc = new ProcedureBase(ownerproc.Level + 1);
            //this.CurrentProc.ShowContextMenuOnInit = false;
            //this.CurrentProc.Clear(); // remove first empty cadre

            this.CurrentProc = ownerproc;
            this.CurrentProc.ShowContextMenuOnInit = false;
            this.CurrentProc.Clear();

            Cadre cadre = new Cadre(this.CurrentProc, isAdd);
            cadre.GetProcFrame().Proc = this.CurrentProc;
            this.CurrentProc.MenuCreator = this.CreateMenu;
            PreProcessFileLists(this.ScenarioFile);          
            return this.CurrentProc;
        }



        #region Fill cadres from filelist
        public virtual bool PreProcessFileLists(string ScenarioFile)
        {
            string fn = string.Empty;
            string part = null;

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

        #endregion

        public void Reload()
        {
            this.CurrentProc.Clear();
            PreProcessFileLists(this.ScenarioFile);
        }

        public virtual bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            this.GlobalMenuCreator.CreateMenu(proc, doShowMenu, itemlist);

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
