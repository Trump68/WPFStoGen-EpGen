using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StoGen.Classes
{
    public class ProcedureBase
    {
        public MenuCreatorDelegate OldMenuCreator;
        public MenuCreatorDelegate MenuCreator;
        public object MenuCreatorData;
        public List<Cadre> Cadres { get; set; }
        //public List<ProcVariant> Variants = new List<ProcVariant>();
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

        public int Level = 0;
        public ProcedureBase(int level)
        {
            InnerProc = null;
            Cadres = new List<Cadre>();
            this.Level = level;
            this.NestedCadreId = -1;
            this.MenuCreator = this.CreateMenu;
        }
        public virtual bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            return false;
        }
        public ProcedureBase InnerProc { get; set; }
        public ProcedureBase GetLastProc()
        {
            if (this.InnerProc == null) return this;
            return this.InnerProc.GetLastProc();
        }
        public int NestedCadreId { get; set; } 
        protected bool isInitialized = false;
        public string Name { get; set; }
        public bool ShowContextMenuOnInit = true;        
        public virtual void Run() { }

        public virtual void Init()
        {
            if (ShowContextMenuOnInit && !isInitialized) this.ShowContextMenu();
            isInitialized = true;
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
                    this.InnerProc = result.GetProcFrame().Proc;
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
                    Cadres[NestedCadreId].BeforeLeave();
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
                        parent.ShowContextMenu();
                    }
                    else
                    {
                        this.ShowContextMenu();
                    }
                }
                else if (this.CurrentCadre != null) this.CurrentCadre.ProcessKey(e);
            }
        }

        // Cadre Managing
        // refresh cadre according cadre data
        public virtual void BeforePaintCadre(object sender, CadreEventArgs e)
        {
            Cadre cadre = e.Cadre;
            cadre.Clear(false);

            foreach (PictureSourceDataProps pictureSourceDataProps in cadre.PicFrameData.PictureDataList)
            {
                cadre.InsertImage(pictureSourceDataProps);
            }
            

            if (cadre.SoundFrameData != null && cadre.SoundFrameData.Count > 0)
            {
                FrameSound fs = cadre.GetSoundFrame();
                fs.SoundList.Clear();
                fs.SoundList.AddRange(cadre.SoundFrameData);
            }
            PrepareTextData(cadre);
        }
        public virtual void PrepareTextData(Cadre cadre)
        {
            if (cadre.TextFrameData.Count > 0)
            {
                //TextData data = this.CurrentCadre.GetTextDataByVariant(this.CurrentVariant);
                TextData data = cadre.TextFrameData[0];
                if (data != null)
                {
                    FrameText ft = cadre.GetTextFrame();
                    ft.TextList.AddRange(data.TextList);

                    ft.BackColor = data.BackColor;
                    ft.FontName = data.FontName;
                    ft.FontSize = data.FontSize;
                    ft.FontColor = data.FontColor;
                    ft.Size = data.Size;
                    ft.Shift = data.Shift;
                    ft.Bottom = data.Bottom;
                    ft.Width = data.Width;
                    ft.ClearBack = data.ClearBack;
                    ft.AutoShow = data.AutoShow;
                    ft.Rtf = data.Rtf;
                    ft.Aligh = data.Align;
                    ft.Opacity = data.Opacity;
                    ft.Transition = data.Transition;
                }
            }
        }
        public virtual bool ShowContextMenu()
        {
            isInitialized = true;
            if (this.InnerProc != null && this.InnerProc.MenuCreator != null)
            {
                return this.InnerProc.ShowContextMenu();
            }
            if (MenuCreator != null)
            {
                return MenuCreator(this, true, null);
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
       
    }
    public delegate bool MenuCreatorDelegate(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist);
}
