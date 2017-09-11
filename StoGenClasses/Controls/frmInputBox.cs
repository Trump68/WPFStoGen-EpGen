using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
        }
        public static DialogResult ShowInputBox(out string m)
        {
            m = null;
            DialogResult result = DialogResult.Cancel;
            using (frmInputBox frm = new frmInputBox())
            {
               
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    m= frm.textEdit1.Text;
                }
            }
            return result;
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            this.textEdit1.Focus();
        }

        private void frmInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
