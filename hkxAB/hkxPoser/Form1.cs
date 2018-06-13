using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hkxPoser
{
    public partial class Form1 : Form
    {
        internal Viewer viewer = null;

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(640, 640);
            viewer = new Viewer();
            viewer.LoadAnimationEvent += delegate(object sender, EventArgs args)
            {
                trackBar1.Maximum = viewer.GetNumFrames()-1;
                trackBar1.Value = 0;
            };
            if (viewer.InitializeGraphics(this))
            {
                timer1.Enabled = true;
            }
            viewer.InputBox = this.InputBox;
            viewer.RotationsText = this.tRotations;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            viewer.Update();
            viewer.Render();
            trackBar1.Value = viewer.current_pose_i;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewer.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewer.Redo();
        }
        private string openedAnimationFile;
        private string openedAnimationFilePath;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "hkx files|*.hkx";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string source_file = dialog.FileName;
                viewer.LoadAnimation(source_file,1);
                openedAnimationFile = Path.GetFileNameWithoutExtension(source_file);
                openedAnimationFilePath = Path.GetDirectoryName(source_file);
                CadreN.Text = $"{viewer.anim.numOriginalFrames}-{viewer.anim.duration}";
                viewer.ClearPatch();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "out.hkx";
            dialog.Filter = "hkx files|*.hkx";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string dest_file = dialog.FileName;
                int speed = (int)numSpeed.Value;
                viewer.SaveAnimation(dest_file, speed);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            viewer.SetCurrentPose(trackBar1.Value);
            this.numCurrent.Value = trackBar1.Value;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string source_file in (string[])e.Data.GetData(DataFormats.FileDrop))
                    viewer.LoadAnimation(source_file,1);
            }
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
        }

        private void miFindBone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text))
                return;
            //NPC Neck [Neck]
            viewer.FindBoneByName((InputBox.Text.Trim().ToLower()));
        }

        int direction = 1;
        private void DoWork()
        {
            //string tofind = null;
            //if (openedAnimationFile == "rape_A1_S1")
            //{
            //    tofind = "NPC Neck [Neck]";
            //    viewer.FindBoneByName(tofind.Trim().ToLower());
            //    RotationZ(0.10F);
            //    tofind = "NPC Head [Head]";
            //    viewer.FindBoneByName(tofind.Trim().ToLower());
            //    RotationZ(0.10F);

            //    string dest_file = Path.Combine(this.openedAnimationFilePath, $"AB001-{openedAnimationFile}.hkx");
            //    viewer.SaveAnimation(dest_file,100);
            //}
        }

        private void RotationZ(float val)
        {
            if (viewer.selected_bone == null) return;
            viewer.selected_bone.patch.rotation.Z = viewer.selected_bone.patch.rotation.Z + val;
        }
        private void RotationX(float val)
        {
            if (viewer.selected_bone == null) return;
            viewer.selected_bone.patch.rotation.X = viewer.selected_bone.patch.rotation.X + val;
        }
        private void RotationY(float val)
        {
            if (viewer.selected_bone == null) return;
            viewer.selected_bone.patch.rotation.Y = viewer.selected_bone.patch.rotation.Y + val;
        }

        private void oWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoWork();
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nodetofind = this.InputBox.Text;
            if (nodetofind.Contains("NPC COM"))
                nodetofind = null;
            this.viewer.SerializatePose(trackBar1.Value, nodetofind);
        }

           
        private void button1_Click(object sender, EventArgs e)
        {           
            this.numStart.Value = trackBar1.Value;
            this.viewer.ApplyPatchForcadre(trackBar1.Value);
        }

        private void btnSetEnd_Click(object sender, EventArgs e)
        {
            this.numEnd.Value = trackBar1.Value;
            this.viewer.ApplyPatchForcadre(trackBar1.Value);
        }       

     

        private void numCurrent_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(this.numCurrent.Value);
            viewer.SetCurrentPose(trackBar1.Value);
            this.numCurrent.Value = trackBar1.Value;
        }

        private void btnPoint1_Click(object sender, EventArgs e)
        {
            this.numPoint1.Value = trackBar1.Value;
            this.viewer.ApplyPatchForcadre(trackBar1.Value);
        }

        private void btnPoint2_Click(object sender, EventArgs e)
        {
            this.numPoint2.Value = trackBar1.Value;
            this.viewer.ApplyPatchForcadre(trackBar1.Value);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.viewer.isRunAnimation = !this.viewer.isRunAnimation;
        }

        private void btnTrimStart_Click(object sender, EventArgs e)
        {
            int n = (int)numTrim.Value;
            if (n < 1) return;
            this.viewer.Clip(n, true);
            trackBar1.Maximum = viewer.GetNumFrames() - 1;
            trackBar1.Value = 0;

        }

        private void btnTrimEnd_Click(object sender, EventArgs e)
        {
            int n = (int)numTrim.Value;
            if (n < 1) return;
            this.viewer.Clip(n, false);
            trackBar1.Maximum = viewer.GetNumFrames() - 1;
            trackBar1.Value = 0;
        }

        private void btnAddStart_Click(object sender, EventArgs e)
        {
            int n = (int)numTrim.Value;
            if (n < 1) return;
            this.viewer.Add(n, true);
            trackBar1.Maximum = viewer.GetNumFrames() - 1;
            trackBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = (int)numTrim.Value;
            if (n < 1) return;
            this.viewer.Add(n, false);
            trackBar1.Maximum = viewer.GetNumFrames() - 1;
            trackBar1.Value = 0;
        }

        private void restoreAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewer.DeserializatePose(trackBar1.Value, true, false);
        }
        private void restorePoseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewer.DeserializatePose(trackBar1.Value, false, false);
        }

        private void restoreFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewer.DeserializatePose(trackBar1.Value, false, true);
        }

        private void openSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "hkx files|*.hkx";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string source_file = dialog.FileName;
                viewer.LoadSecondSkeleton();
                viewer.LoadAnimation(source_file,2);
            }
        }

        private void setRotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewer.DeserializatePose2(trackBar1.Value, false);
        }

        private void applyFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewer.DeserializatePose2(trackBar1.Value, true);
        }

        private void btnInterpolate_Click(object sender, EventArgs e)
        {
            viewer.Interpolate(Convert.ToInt32(this.numStart.Value), Convert.ToInt32(this.numPoint1.Value), Convert.ToInt32(this.numPoint2.Value), Convert.ToInt32(this.numEnd.Value));
        }

      
    }
}
