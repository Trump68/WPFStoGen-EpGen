﻿using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using StoGenMake.Scenes.Base;
using StoGenMake.Elements;
using StoGenMake;

namespace StoGen.Classes
{
    public class ProcedureBase
    {
        private BaseScene Scene;
        public ProcedureBase(BaseScene scene)
        {
            Cadres = new List<Cadre>();
            this.NestedCadreId = -1;
            this.MenuCreator = this.CreateMenu;
            Scene = scene;
            this.MenuCreator = CreateMenu;
            var i = 0;
            foreach (var ad in Scene.CadreDataList)
            {
                var AppCadre = new Cadre(this, true);
                AppCadre.ImageFr.ShowMovieControls = true;
                AppCadre.AlignData = ad;
            }
            this.ShowContextMenuOnInit = false;
            this.GoFirstCadre();
        }
        // General
        public string Name { get; set; }
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
            Stop();
            //this.Variants.Clear();
            this.InnerProc = null;
            this.NestedCadreId = 0;
        }

        public void Stop()
        {
            foreach (var cadre in Cadres)
            {
                cadre.Stop();
            }
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
            return GoToCadre(0);
        }
        public Cadre GoToCadre(int num)
        {
            NestedCadreId = num - 1;
            return GetNextCadre();
        }
        public int CurrentCadreNum()
        {
            return NestedCadreId;
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

        public virtual Cadre GetNextCadre()
        {
            CreateNextCadre();
            Cadre result = null;
            if (NestedCadreId >= 0 && NestedCadreId <= Cadres.Count - 1)
            {
                if (!Cadres[NestedCadreId].AllowedForward) return result;
            }

            if (NestedCadreId < Cadres.Count - 1)
            {
                if (NestedCadreId > -1)
                {
                    var prev = Cadres[NestedCadreId];
                    prev.Stop();
                }
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
        // Menu
        public object MenuCreatorData;
        public MenuCreatorDelegate OldMenuCreator;
        public MenuCreatorDelegate MenuCreator;
        public bool CreateMenu(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {

            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            if (frmFrameChoice.ShowOptionsmenu(itemlist) == DialogResult.Cancel)
            {

            }
            return true;
        }
        public bool ShowContextMenuOnInit = true;
        public virtual bool ShowContextMenu(bool show, object Data)
        {
            isInitialized = true;
           
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
        private void CreateNextCadre()
        {
    
        }
        // Magic here
        public ScenCadre MakeCadre(CadreData item)
        {

            seTe te = null;
            bool isWhite = false;
            if (item.IsGlobalAlign)
            {
                te = new seTe();
                te.FontSize = 60;
                te.Size = 100;
                te.Bottom = 0;
                te.Shift = 700;
                te.Text = "SETUP";
            }
            else
            {
                te = item.TextData;
            }
            return this.CreateCadre(item, isWhite, te);
        }
        // => Here the magic happens
        public ScenCadre CreateCadre(CadreData item, bool isWhite = false, seTe text = null)
        {
            var cadre = new ScenCadre();
            cadre.IsWhite = isWhite;
            cadre.Name = $"Cadre {this.Cadres.Count + 1}";
            foreach (var ai in item.AlignList)
            {
                //faind main image info in storage
                var isi = GameWorld.ImageStorage.Where(x => x.Name == ai.Name).FirstOrDefault();
                if (isi == null) continue;
                // create image
                seIm im = new seIm();
                im.Name = isi.Name;
                im.Parent = ai.Parent;
                im.File = isi.File;
                // there is 2 alt: assign from parent-child align or from delta align, not combined!
                if (!string.IsNullOrEmpty(ai.Parent)) //if has parent image
                {
                    // get parent-child proportion
                    var parentproportion = isi.Parents.Where(x => x.Parent == ai.Parent && x.Tag == ai.Tag).FirstOrDefault();
                    if (parentproportion != null)
                    {
                        // get real parent image from cadre
                        var realpar = cadre.VisionList.Where(x => x.Name == ai.Parent).FirstOrDefault();
                        if (realpar != null)
                        {
                            // assign to image parent-child proportion according with real parent 
                            seIm realparent = realpar as seIm;
                            parentproportion.ApplyTo(im, realparent, ai);
                        }
                    }
                }
                else // no parent image
                {
                    // assign default align to image
                    //im.AssignFrom(isi.DefaultAlign);
                    // assign delta align, if any
                    im.AssignFrom(ai);

                }
                // add image to cadre
                cadre.AddImage(im);
            }
            cadre.SoundList.AddRange(item.SoundList);
            if (text != null)
            {
                cadre.AddText(text);
            }
            return cadre;
        }
    }
    public delegate bool MenuCreatorDelegate(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data);


}
