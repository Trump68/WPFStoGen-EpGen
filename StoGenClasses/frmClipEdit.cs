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
    public partial class frmClipEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmClipEdit()
        {
            InitializeComponent();
        }
        public static DialogResult Edit(SgClip m)
        {
            DialogResult result = DialogResult.Cancel;
            using (frmClipEdit frm = new frmClipEdit())
            {
                frm.ucClipEdit1.SetMovie(m);
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    m  = frm.ucClipEdit1.GetClip();
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