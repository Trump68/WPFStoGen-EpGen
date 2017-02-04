using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StoGen.Classes
{
    public partial class frmMovieEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmMovieEdit()
        {
            InitializeComponent();
        }
        public static DialogResult Edit(SgMovie m)
        {
            DialogResult result = DialogResult.Cancel;
            using (frmMovieEdit frm = new frmMovieEdit())
            {
                frm.ucMovieEdit1.SetMovie(m);
                frm.ucActorList1.BS.DataSource = m.ActorList;
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    m  = frm.ucMovieEdit1.GetMovie();
                }
            }
            return result;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SgActor actor;
            frmActorList.Showlist(0,out actor);
            if (actor == null) return;
            foreach (SgActor sgActor in this.ucMovieEdit1.CurrentMovie.ActorList)
            {
                if (sgActor.Id == actor.Id) return;
            }
            this.ucMovieEdit1.CurrentMovie.ActorList.Add(actor);
            this.ucActorList1.BS.DataSource = this.ucMovieEdit1.CurrentMovie.ActorList;
            this.ucActorList1.BS.ResetBindings(false);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.BS.Current == null) return;
            this.ucActorList1.BS.RemoveCurrent();
            this.ucActorList1.BS.ResetBindings(false);
            // this.ucActorList1.BS.DataSource = this.ucMovieEdit1.CurrentMovie.ActorList;
        }

        private void frmMovieEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}