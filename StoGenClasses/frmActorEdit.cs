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
    public partial class frmActorEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmActorEdit()
        {
            InitializeComponent();
        }
        public static DialogResult Edit(SgActor m)
        {
            DialogResult result = DialogResult.Cancel;
            using (frmActorEdit frm = new frmActorEdit())
            {
                frm.ucActorEdit1.SetActor(m);
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    m  = frm.ucActorEdit1.GetActor();
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

        private void frmActorEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}