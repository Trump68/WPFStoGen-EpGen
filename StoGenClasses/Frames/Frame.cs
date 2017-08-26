using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class Frame: IDisposable
    {
        public bool isVisible { set; get; }
        public Cadre Owner;
        public EventHandler OnRepaint;
        public Frame() 
        {
            isVisible = true;
            Owner = null;
        }
        public ProcedureBase Proc
        {
            get { return this.Owner.Owner; }
        }
        public virtual void SetVisible(bool show)
        {
            isVisible = show;
        }
        public virtual Cadre Repaint() 
        {
            if (OnRepaint != null) OnRepaint(this, EventArgs.Empty);
            return null;
        }
        public virtual void BeforeLeave() { }

        public virtual void Dispose()
        {
            OnRepaint = null;
        }
    }
}
