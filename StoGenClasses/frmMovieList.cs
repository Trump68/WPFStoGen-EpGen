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
    public partial class frmMovieList : DevExpress.XtraEditors.XtraForm
    {
        public frmMovieList()
        {
            InitializeComponent();
        }

        public static DialogResult Showlist(out SgMovie m)
        {
            m = null;
            DialogResult result = DialogResult.Cancel;
            using (frmMovieList frm = new frmMovieList())
            {

                List<SgMovie> list = new List<SgMovie>();
                SGDataBase.GetMovieList(list);
                frm.ucMovieList.BS.DataSource = list;

                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (frm.ucMovieList.BS.Current != null)
                        m = (SgMovie)frm.ucMovieList.BS.Current;
                }
            }
            return result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SgMovie m = new SgMovie();
            if (frmMovieEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveMovie(m))
                {
                    this.ucMovieList.BS.Add(m);
                    this.ucMovieList.BS.ResetBindings(false);
                    this.ucMovieList.RefreshDS();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            EditMovie();
        }

        private void EditMovie()
        {
            if (this.ucMovieList.BS.Current == null) return;
            SgMovie m = (SgMovie)this.ucMovieList.BS.Current;
            SGDataBase.LoadMovie(m);
            if (frmMovieEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveMovie(m))
                {
                    this.ucMovieList.BS.ResetBindings(false);
                }
            }
        }
        private void frmMovieList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }else if (e.KeyCode == Keys.Enter)
            {
                EditMovie();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}