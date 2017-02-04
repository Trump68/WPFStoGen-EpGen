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
    public partial class frmClipList : DevExpress.XtraEditors.XtraForm
    {
        public frmClipList()
        {
            InitializeComponent();
        }

        public static DialogResult Showlist(out SgClip m)
        {
            m = null;
            DialogResult result = DialogResult.Cancel;
            using (frmClipList frm = new frmClipList())
            {

                List<SgClip> list = new List<SgClip>();
                SGDataBase.GetClipList(list,0,0,0,null,null);
                frm.ucClipList.BS.DataSource = list;

                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (frm.ucClipList.BS.Current != null)
                        m = (SgClip)frm.ucClipList.BS.Current;
                }
            }
            return result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SgClip m = new SgClip();
            if (frmClipEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveClip(m))
                {
                    this.ucClipList.BS.Add(m);
                    this.ucClipList.BS.ResetBindings(false);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.ucClipList.BS.Current == null) return;
            SgClip m = (SgClip)this.ucClipList.BS.Current;
            SGDataBase.LoadClip(m);
            if (frmClipEdit.Edit(m) == DialogResult.OK)
            {
                if (SGDataBase.SaveClip(m))
                {
                    this.ucClipList.BS.ResetBindings(false);
                }
            }
        }

        private void frmMovieList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<SgClip> AddedClips;
            if (frmLoadClipsFromDirectory.Run(out AddedClips) == DialogResult.OK)
            {
                foreach (SgClip addedClip in AddedClips)
                {
                    this.ucClipList.BS.Add(addedClip);
                    
                }
                this.ucClipList.BS.ResetBindings(false);
                this.ucClipList.RefreshDS();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           if (XtraMessageBox.Show("Уверен?", "Уверен?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)!= DialogResult.Yes) return;
            List<SgClip> list = this.ucClipList.BS.DataSource as List<SgClip>;
            foreach (SgClip sgClip in list)
            {
                SGDataBase.LoadClip(sgClip);
                SGDataBase.ConvertClipName(sgClip);
            }
            XtraMessageBox.Show("Готово", "Готово", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SgClip m = (SgClip)this.ucClipList.BS.Current;
            if (m == null) return;

            this.Clip1.URL =m.Path;
            this.Clip1.Ctlcontrols.play();

        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            SgActor actor;
            frmActorList.Showlist(0, out actor);
            if (actor == null) return;

            List<SgClip> list = this.ucClipList.GetSelectedList();

            foreach (SgClip sgClip in list)
            {
                SGDataBase.LoadClip(sgClip);
                bool found = false;
                List<SgActor> actlist = sgClip.ActorRoleList.Select(X => X.Actor)?.ToList();
                if (actlist != null)
                {
                    foreach (SgActor sgActor in actlist)
                    {
                        if (sgActor.Id == actor.Id)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (found) continue;
                SgActorRole role = new SgActorRole();
                role.Actor = actor;
                role.ActorId = actor.Id;
                role.ClipId = sgClip.Id;
                role.RoleType = 0;
                sgClip.ActorRoleList.Add(role);
                SGDataBase.SaveClip(sgClip);
               
            }

            this.ucClipList.BS.ResetBindings(false);
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Уверен?", "Уверен?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            List<SgClip> list = this.ucClipList.GetSelectedList();

            foreach (SgClip sgClip in list)
            {
                SGDataBase.LoadClip(sgClip);             
                sgClip.ActorRoleList.Clear();
                SGDataBase.SaveClip(sgClip);

            }

            this.ucClipList.BS.ResetBindings(false);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            // if (XtraMessageBox.Show("Уверен?", "Уверен?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            string descr;
            if (frmInputBox.ShowInputBox(out descr) == DialogResult.OK)
            {

                List<SgClip> list = this.ucClipList.GetSelectedList();

                foreach (SgClip sgClip in list)
                {
                    SGDataBase.LoadClip(sgClip);
                    sgClip.Description = descr;
                    SGDataBase.SaveClip(sgClip);

                }

                this.ucClipList.BS.ResetBindings(false);
            }
        }
    }
}