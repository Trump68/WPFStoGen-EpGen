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
using StoGenMake.Elements;
using StoGenMake;
using Menu.Classes;

namespace StoGen.Classes
{
    public class CadreController
    {
        public BaseScene Scene;
        public CadreController(BaseScene scene, int startpage)
        {
            Cadres = new List<Cadre>();
            Scene = scene;
            foreach (var ad in Scene.CadreDataList)
            {
                CreateCadre();
            }
            this.CadreId = -1;
            while (this.CadreId < startpage)
            {
                this.GetNextCadre();
            }
            //bool LiveMenu = (startpage == Cadres.Count()-1);
            //this.OldMenuCreator = this.MenuCreator;
            //this.MenuCreator = this.Scene.GetMenuCreator(LiveMenu);
        }
        public void CreateCadre()
        {
            var AppCadre = new Cadre(this, true);
            AppCadre.ImageFr.ShowMovieControls = true;
        }
        // General
        public string Name { get; set; }
        public List<Cadre> Cadres { get; set; }        
        public Cadre CurrentCadre
        {
            get
            {
                if (this.Cadres.Count < 1 || this.CadreId<0) return null;
                return this.Cadres[this.CadreId];
            }
        }
        public virtual void Clear()
        {
            Stop();
            this.CadreId = 0;
        }

        public void Stop()
        {
            foreach (var cadre in Cadres)
            {
                cadre.Stop();
            }
        }

        public int CadreId { get; set; } 
        // Navigation
        public bool AllowedForward
        {
            get
            {
                if (this.CadreId == (this.Cadres.Count - 1))
                {
                    return false;
                }
                return true;
            }
        }
        public bool AllowedBackward
        {
            get
            {
                if (this.CadreId == 0) return false;
                    if (this.Cadres.Count == 0 || this.CurrentCadre == null) return false;
                    int idx = this.Cadres.IndexOf(this.CurrentCadre) - 1;

                    return this.CurrentCadre.AllowedBackward;
            }
        }


        public Cadre GoToCadre(int num)
        {
            //CadreId = num - 1;
            CadreId = num;
            return GetNextCadre();
        }
        public int CurrentCadreNum()
        {
            return CadreId;
        }

        // Key handling
        public EventHandler OnKeyData;        
        public void ProcessKeyData(int v)
        {
          
            if (OnKeyData != null)
            {
                OnKeyData(v, null);
            }
        }


        public virtual Cadre GetNextCadre()
        {
            CreateNextCadres();
            CadreId++;
            Cadre result = null;
            if (CadreId >= 0 && CadreId <= Cadres.Count - 1)
            {
                if (!Cadres[CadreId].AllowedForward) return result;
            }

            if (CadreId <= Cadres.Count - 1)
            {
                if (CadreId > 0)
                {
                    var prev = Cadres[CadreId - 1];
                    prev.Stop();
                }
                result = Cadres[CadreId];
            }
            else if (Cadres.Count > 0 && (CadreId == Cadres.Count - 1))
            {
                return null;
            }
            if (result != null) RepaintCadre(result);
            else
            {
                SystemSounds.Beep.Play();
            }
            return result;
        }
   


        public virtual Cadre GetPrevCadre()
        {
            Cadre result = null;
            if (CadreId == 0)
            {
                SystemSounds.Beep.Play();
                return result;
            }
            if (result == null)
            {
                if (CadreId >= 1)
                {
                    if (!Cadres[CadreId - 1].AllowedBackward) return result;
                    result = Cadres[CadreId - 1];
                    CadreId--;
                }
                else if (CadreId == 0)
                {
                    if (Cadres.Count > 0) result = Cadres[CadreId];
                }
            }
            if (result != null)
            {
                this.RepaintCadre(result);      
            }
            
            return result;
        }
        // Menu

        //public bool ShowContextMenuOnInit = true;
        public virtual bool ShowContextMenu(bool show, MenuType type)
        {
            bool LiveMenu = (CadreId == Cadres.Count()-1);
            var MenuCreator = this.Scene.GetMenuCreator(LiveMenu);
            if (MenuCreator != null)
            {
                return MenuCreator(this, show, null, type, true);
            }
            return false;
        }
        public void ApplyContextMenu()
        {
            if (this.CurrentCadre == null)
            {
                this.GetNextCadre();
            }
        }

        // Magic here (TO DO: recode this)
        public CadreInfo MakeCadre(CadreData item)
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
        // => Here the magic happens (TO DO: recode this)
        public CadreInfo CreateCadre(CadreData item, bool isWhite = false, seTe text = null)
        {
            var cadre = new CadreInfo();
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

        public void CreateNextCadres()
        {
            if (CadreId == Cadres.Count - 1)
            {          
                List<CadreData> nextcadredata = this.Scene.GetNextCadreData(this, (CadreId + 1));
                if (nextcadredata != null)
                {
                    foreach (var item in nextcadredata)
                    {
                        this.CreateCadre();
                    }
                }
            }
        }
        public void RepaintCadre(Cadre cadre)
        {
            var info = this.MakeCadre(Scene.CadreDataList[CadreId]);
            cadre.Repaint(info);
        }

        public void RefreshCurrentCadre()
        {
            CadreId--;
            GetNextCadre();
        }
    }
  
}
