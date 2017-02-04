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

namespace StoGenWPF
{
    public partial class frmCompileErrors : DevExpress.XtraEditors.XtraForm
    {
        public frmCompileErrors()
        {
            InitializeComponent();
        }

        public static void ShowError(List<string> errors) 
        {
            frmCompileErrors frm = new frmCompileErrors();
            using (frm)
            {
                frm.Memo1.Lines = errors.ToArray();
                frm.ShowDialog();
            }
        }

    }
}