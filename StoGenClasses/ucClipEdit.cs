using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace StoGen.Classes
{
    public partial class ucClipEdit : UserControl
    {
        public ucClipEdit()
        {
            InitializeComponent();

            this.ucActorList1.RoleColVisible = true;
        }
        internal SgClip CurrentClip;
        List<SgActor> Actorlist;
        public void SetMovie(SgClip m)
        {
            CurrentClip = m;
            seId.Text = $"{m.Id}";
            teClipDescription.Text = m.Description;
            teFile.Text = m.OldFileName;
            tePath.Text = m.Path;
            teClipDescription.Text = m.Description;
            if (this.CurrentClip.Movie!=null) this.ucMovieEdit1.SetMovie(this.CurrentClip.Movie);
            Actorlist = m.ActorRoleList.Select(x => x.Actor)?.ToList();
            if (Actorlist!= null) this.ucActorList1.SetList(Actorlist);

        }
        public SgClip GetClip()
        {
            CurrentClip.Description = teClipDescription.Text;
            CurrentClip.Path = tePath.Text;
            CurrentClip.ActorRoleList.Clear();
            foreach (SgActor sgActor in Actorlist)
            {
                SgActorRole role = new SgActorRole();
                role.Actor = sgActor;
                role.ActorId = sgActor.Id;
                role.ClipId = CurrentClip.Id;
                role.RoleType = 0;
                CurrentClip.ActorRoleList.Add(role);
            }
            return this.CurrentClip;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SgMovie movie;
            if (frmMovieList.Showlist(out movie) == DialogResult.OK)
            {
                CurrentClip.Movie = movie;
                this.ucMovieEdit1.SetMovie(this.CurrentClip.Movie);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SgActor actor;
            frmActorList.Showlist(0, out actor);
            if (actor == null) return;
            foreach (SgActor sgActor in Actorlist)
            {
                if (sgActor.Id == actor.Id) return;
            }
            Actorlist.Add(actor);
            this.ucActorList1.SetList(Actorlist);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.CurrentActor != null)
            {
                Actorlist.Remove(this.ucActorList1.CurrentActor);
                this.ucActorList1.SetList(Actorlist);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.CurrentActor != null)
            {
                this.ucActorList1.CurrentActor.RoleRelation = RoleRelationEnum.ГолосПодходит;
                this.ucActorList1.SetList(Actorlist);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.CurrentActor != null)
            {
                this.ucActorList1.CurrentActor.RoleRelation = RoleRelationEnum.АктерПодходит;
                this.ucActorList1.SetList(Actorlist);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.CurrentActor != null)
            {
                this.ucActorList1.CurrentActor.RoleRelation = RoleRelationEnum.Актер;
                this.ucActorList1.SetList(Actorlist);
            }
        }
    }
}
