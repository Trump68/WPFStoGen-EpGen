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
using System.IO;

namespace StoGen.Classes
{
    public partial class frmLoadClipsFromDirectory : DevExpress.XtraEditors.XtraForm
    {
        public static DialogResult Run(out List<SgClip> AddedClips)
        {
            AddedClips = new List<SgClip>();
            DialogResult result = DialogResult.Cancel;
            using (frmLoadClipsFromDirectory frm = new frmLoadClipsFromDirectory())
            {
               
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddedClips = frm.AddedClips;
                }
            }
            return result;
        }
        public frmLoadClipsFromDirectory()
        {
            InitializeComponent();
        }
        public List<SgClip> AddedClips = new List<SgClip>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.ceRefreshProps.Checked = true;
            this.ceOnlyNew.Checked = true;
            Go();
        }
        private void sbUpdatePath_Click(object sender, EventArgs e)
        {
            this.ceRefreshProps.Checked = false;
            this.ceOnlyNew.Checked = false;
            Go();
        }
        private void sbRefreshProps_Click(object sender, EventArgs e)
        {
            this.ceRefreshProps.Checked = true;
            this.ceOnlyNew.Checked = false;
            Go();
        }
        private void Go()
        {
            AddedClips.Clear();
            string dir = teDirectory.Text;
            if (!Directory.Exists(dir))
            {
                MessageBox.Show($"нет такого каталога {dir}");
                return;
            }
            string[] files = Directory.GetFiles(dir);
            foreach (string item in files)
            {
                string fn = Path.GetFileName(item);
                string path = Path.GetFullPath(item);

                List<SgClip> list = new List<SgClip>();
                if (SGDataBase.GetClipList(list, 0, 0, 0, path, fn))
                {
                    SgClip clip = null;
                    if (list.Count == 0)
                    {

                        clip = new SgClip();
                        AddedClips.Add(clip);
                    }
                    else
                    {
                        if (ceOnlyNew.Checked) continue;
                        clip = list[0];
                        SGDataBase.LoadClip(clip);
                    }
                    clip.Path = path;
                    clip.OldFileName = fn;

                    if (this.ceRefreshProps.Checked)
                    {
                        clip.SetType = ProductionTypeEnum.Movie;
                        clip.SetId = Convert.ToInt32(this.teSetId.Text);
                        if (!string.IsNullOrEmpty(this.teActorId.Text))
                        {
                            if (clip.MainRole == null)
                            {
                                clip.ActorRoleList = new List<SgActorRole>();
                                clip.ActorRoleList.Add(new SgActorRole());
                            }
                            clip.MainRole.ActorId = Convert.ToInt32(this.teActorId.Text);
                        }
                        if (string.IsNullOrEmpty(clip.Description))
                        {
                            clip.Description = Path.GetFileNameWithoutExtension(fn);
                            if (!string.IsNullOrEmpty(this.teDescription.Text))
                            {
                                clip.Description = this.teDescription.Text;
                            }
                        }
                    }
                    //SGDataBase.SaveClip(clip);
                    if (!SGDataBase.ConvertClipName(clip))
                    {
                        SGDataBase.SaveClip(clip);
                    }
                }

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SgMovie movie;
            if (frmMovieList.Showlist(out movie) == DialogResult.OK)
            {
                this.teSetId.Text = $"{movie.Id}";
                this.teSetName.Text = movie.Name;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SgActor actor;
            frmActorList.Showlist(0, out actor);
            if (actor == null) return;
            this.teActorId.Text = $"{actor.Id}";
            this.teActorName.Text = actor.Name;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton2.Enabled = simpleButton3.Enabled = this.ceRefreshProps.Checked;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            List<SgActor> actors = new List<SgActor>();
            SGDataBase.GetActorList(actors, 0);
            List<SgMovie> movies = new List<SgMovie>();
            SGDataBase.GetMovieList(movies);

            this.teSetId.Text = $"{movies[0].Id}";
            this.teSetName.Text = movies[0].Name;

            this.teActorId.Text = $"{actors[0].Id}";
            this.teActorName.Text = actors[0].Name;

        }


    }
}