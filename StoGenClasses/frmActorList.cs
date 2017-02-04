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
    public partial class frmActorList : DevExpress.XtraEditors.XtraForm
    {
        public frmActorList()
        {
            InitializeComponent();
        }

        public static DialogResult Showlist(int MovieId,out SgActor actor)
        {
            actor = null;
            DialogResult result = DialogResult.Cancel;
            using (frmActorList frm = new frmActorList())
            {

                List<SgActor> list = new List<SgActor>();
                SGDataBase.GetActorList(list, MovieId);
                frm.ucActorList1.BS.DataSource = list;

                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (frm.ucActorList1.BS.Current != null)
                        actor = (SgActor)frm.ucActorList1.BS.Current;
                }
            }
            return result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SgActor m = new SgActor();
            if (frmActorEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveActor(m))
                {
                    this.ucActorList1.BS.Add(m);
                    this.ucActorList1.BS.ResetBindings(false);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.ucActorList1.BS.Current == null) return;
            SgActor m = (SgActor)this.ucActorList1.BS.Current;
            SGDataBase.LoadActor(m);
            if (frmActorEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveActor(m))
                {
                    this.ucActorList1.BS.ResetBindings(false);
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmActorList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}