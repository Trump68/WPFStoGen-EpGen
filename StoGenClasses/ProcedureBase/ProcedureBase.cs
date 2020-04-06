using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using StoGenMake.Scenes.Base;

namespace StoGen.Classes
{
    public class ProcedureBase
    {
        public ProcedureBase(int level)
        {
            InnerProc = null;
            Cadres = new List<Cadre>();
            this.Level = level;
            this.NestedCadreId = -1;
            this.MenuCreator = this.CreateMenu;
        }
        // General
        public string Name { get; set; }
        public int Level = 0;
        public BaseScene Scene;
        public List<Cadre> Cadres { get; set; }        
        public Cadre CurrentCadre
        {
            get
            {
                if (this.Cadres.Count < 1 || this.NestedCadreId<0) return null;
                return this.Cadres[this.NestedCadreId];
            }
        }
        public virtual void Clear()
        {
            //if (this.CurrentCadreMaker != null) this.CurrentCadreMaker.Selectors.Clear();
            this.Cadres.Clear();
            //this.Variants.Clear();
            this.InnerProc = null;
            this.NestedCadreId = 0;
        }
        public ProcedureBase InnerProc { get; set; }
        public ProcedureBase GetLastProc()
        {
            if (this.InnerProc == null) return this;
            return this.InnerProc.GetLastProc();
        }
        public int NestedCadreId { get; set; } 
        protected bool isInitialized = false;
        // Navigation
        public bool AllowedForward
        {
            get
            {
                if (this.NestedCadreId == (this.Cadres.Count - 1))
                {
                    return false;
                }
                if (this.InnerProc == null)
                {
                    if (this.Cadres.Count == 0) return true;
                    return this.Cadres[this.Cadres.Count - 1].AllowedForward;
                }
                else return this.InnerProc.AllowedForward;
            }
        }
        public bool AllowedBackward
        {
            get
            {
                if (this.NestedCadreId == 0) return false;
                if (this.InnerProc == null)
                {
                    if (this.Cadres.Count == 0 || this.CurrentCadre == null) return false;
                    int idx = this.Cadres.IndexOf(this.CurrentCadre) - 1;
                    if (idx > -1)
                    {
                        if (this.Cadres[idx].IsProc) return false;
                    }
                    return this.CurrentCadre.AllowedBackward;
                }
                else return this.InnerProc.AllowedBackward;
            }
        }
        public virtual void Init()
        {
            if (ShowContextMenuOnInit && !isInitialized) this.ShowContextMenu(true,null);
            isInitialized = true;
        }
        public Cadre GoFirstCadre()
        {
            NestedCadreId = -1;
            return GetNextCadre();
        }
        public virtual Cadre GetNextCadre()
        {

            Cadre result = null;            
            if (NestedCadreId >= 0 && NestedCadreId <= Cadres.Count - 1)
            {
                //Cadres[NestedCadreId].BeforeLeave();
                if (!Cadres[NestedCadreId].AllowedForward) return result;
            }
            if (this.InnerProc != null)
            {
                result = this.InnerProc.GetNextCadre();
                if (result != null) return result;
                else if (this.AllowedForward)
                {
                    // delete inner proc
                    this.InnerProc = null;
                    if (NestedCadreId > 0)
                    {
                        Cadres.RemoveAt(NestedCadreId);
                        NestedCadreId = NestedCadreId - 1;
                    }
                    if (Cadres.Count > NestedCadreId + 1) result = Cadres[NestedCadreId];
                    else if (Cadres.Count > NestedCadreId)
                    {
                        return Cadres[NestedCadreId];
                        //return null;
                    }
                    else
                    {
                        NestedCadreId = -1;
                        //isInitialized = false;
                        return this.GetNextCadre();
                    }
                }
            }
            else if (NestedCadreId < Cadres.Count - 1)
            {
                result = Cadres[NestedCadreId + 1];
                NestedCadreId++;
                if (result.IsProc)
                {
                    this.InnerProc = result.ProcFr.Proc;
                    if (this.InnerProc != null)
                    {
                        if (this.InnerProc.NestedCadreId == 0) this.InnerProc.NestedCadreId = -1;
                        return this.InnerProc.GetNextCadre();
                    }
                }
            }
            else if (Cadres.Count > 0 && (NestedCadreId == Cadres.Count - 1))
            {
                return null;
            }

            if (!isInitialized)
            {
                Init();
            }
            if (result != null) result.Repaint(true);
            else
            {
                SystemSounds.Beep.Play();
            }
            //(Projector.Text.TopLevelControl as Form).Text = this.Level.ToString() + ":" + NestedCadreId;

            return result;
        }
        public virtual Cadre GetPrevCadre()
        {

            Cadre result = null;
            if (!this.GetLastProc().AllowedBackward)
            {
                SystemSounds.Beep.Play();
                return result;
            }
            //if (!this.AllowedBackward)
            //{
            //    SystemSounds.Beep.Play();
            //    return result;
            //}
            if (this.InnerProc != null)
            {
                if (this.InnerProc.NestedCadreId > 0)
                    return this.InnerProc.GetPrevCadre();
                else
                {
                    ProcedureBase bp = this.InnerProc;
                    while (bp.InnerProc != null)
                    {
                        bp = bp.InnerProc;
                        //bp.NestedCadreId = 0;
                        bp.NestedCadreId = bp.NestedCadreId - 1;
                    }
                    if (bp.NestedCadreId < 0)
                    {
                        // delete inner proc
                        this.InnerProc = null;
                        Cadres.RemoveAt(NestedCadreId);
                        NestedCadreId = NestedCadreId - 1;
                    }
                    else
                    {
                        result = bp.Cadres[bp.NestedCadreId];

                    }
                }
            }

            if (result == null)
            {
                if (NestedCadreId >= 1)
                {
                    if (!Cadres[NestedCadreId - 1].AllowedBackward) return result;
                    //Cadres[NestedCadreId].BeforeLeave();
                    result = Cadres[NestedCadreId - 1];
                    NestedCadreId--;
                    while (result != null && result.IsProc)
                    {
                        result = Cadres[NestedCadreId];
                        NestedCadreId--;
                        if (NestedCadreId < 0)
                        {
                            return result;
                        }
                    }
                }
                else if (NestedCadreId == 0)
                {
                    if (Cadres.Count > 0) result = Cadres[NestedCadreId];
                }

            }


            if (result != null)
            {
                result.Repaint(true);
                //(Projector.Text.TopLevelControl as Form).Text = result.Owner.Level.ToString() + ":" + result.Owner.NestedCadreId;
            }

            return result;
        }
        // Key handling
        public EventHandler OnKeyData;        
        public void ProcessKeyData(int v)
        {
            if (this.InnerProc != null) this.InnerProc.ProcessKeyData(v);
            else if (OnKeyData != null)
            {
                OnKeyData(v, null);
            }
        }
        public void ProcessKey(Key e)
        {
            ProcessKey(e, null);
        }
        public void ProcessKey(Key e, ProcedureBase parent)
        {
            if (this.InnerProc != null) this.InnerProc.ProcessKey(e, this);
            else
            {
                if (e == Key.Back)
                {
                    if (parent != null)
                    {
                        parent.InnerProc = null;
                        parent.ShowContextMenu(true,null);
                    }
                    else
                    {
                        this.ShowContextMenu(true, null);
                    }
                }
                else if (this.CurrentCadre != null) this.CurrentCadre.ProcessKey(e);
            }
        }
        // Menu
        public object MenuCreatorData;
        public MenuCreatorDelegate OldMenuCreator;
        public MenuCreatorDelegate MenuCreator;
        public virtual bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            return false;
        }
        public bool ShowContextMenuOnInit = true;
        public virtual bool ShowContextMenu(bool show, object Data)
        {
            isInitialized = true;
            if (this.InnerProc != null && this.InnerProc.MenuCreator != null)
            {
                return this.InnerProc.ShowContextMenu(show,Data);
            }
            if (MenuCreator != null)
            {
                return MenuCreator(this, show, null, Data);
            }
            return false;
        }
        public void ApplyContextMenu()
        {
            if (this.InnerProc != null)
            {
                this.InnerProc.ApplyContextMenu();
                return;
            }
            if (this.CurrentCadre == null)
            {
                this.GetNextCadre();
            }
            //if (this.CurrentCadre.GetRadioGroupFrame().isVisible)
            //{
            //    this.CurrentCadre.GetRadioGroupFrame().PerformExec();
            //}
        }
    }
    public delegate bool MenuCreatorDelegate(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data);
}
