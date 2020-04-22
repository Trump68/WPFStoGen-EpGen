using StoGen.Classes;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.ModelClasses
{
    public class FrameProc : Frame
    {


        public CadreController Proc { get; set; }
        public FrameProc()
            : base()
        {
            this.Proc = null;
        }
        public override Cadre Repaint()
        {
            //if (this.Proc != null)
            //{
            //    return this.Proc.GetNextCadre();
            //}
            return this.Owner;
        }
        public override void SetVisible(bool show)
        {
            base.SetVisible(show);
        }
    }
}
