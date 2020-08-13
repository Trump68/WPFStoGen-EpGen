using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGenWPF
{
    public partial class SoundOptions : Form
    {
        public SoundOptions()
        {
            InitializeComponent();                        
        }
        public void SetIndicators()
        {
            this.ISound1.Checked = !Projector.Sound[0].IsMuted && (Projector.Sound[0].Source != null);
            this.ISound2.Checked = !Projector.Sound[1].IsMuted && (Projector.Sound[1].Source != null);
            this.ISound3.Checked = !Projector.Sound[2].IsMuted && (Projector.Sound[2].Source != null);
            this.ISound4.Checked = !Projector.Sound[3].IsMuted && (Projector.Sound[3].Source != null);
            this.ISound5.Checked = !Projector.Sound[4].IsMuted && (Projector.Sound[4].Source != null);
            this.ISound6.Checked = !Projector.Sound[5].IsMuted && (Projector.Sound[5].Source != null);
            this.ISound7.Checked = !Projector.Sound[6].IsMuted && (Projector.Sound[6].Source != null);
            this.ISound8.Checked = !Projector.Sound[7].IsMuted && (Projector.Sound[7].Source != null);
            this.ISound9.Checked = !Projector.Sound[8].IsMuted && (Projector.Sound[8].Source != null);
            this.ISound10.Checked = !Projector.Sound[9].IsMuted && (Projector.Sound[9].Source != null);
            this.ISound11.Checked = !Projector.Sound[10].IsMuted && (Projector.Sound[10].Source != null);
            this.ISound12.Checked = !Projector.Sound[11].IsMuted && (Projector.Sound[11].Source != null);
            this.ISound13.Checked = !Projector.Sound[12].IsMuted && (Projector.Sound[12].Source != null);
            this.ISound14.Checked = !Projector.Sound[13].IsMuted && (Projector.Sound[13].Source != null);
            this.ISound15.Checked = !Projector.Sound[14].IsMuted && (Projector.Sound[14].Source != null);
            this.ISound16.Checked = !Projector.Sound[15].IsMuted && (Projector.Sound[15].Source != null);
            this.ISound17.Checked = !Projector.Sound[16].IsMuted && (Projector.Sound[16].Source != null);
            this.ISound18.Checked = !Projector.Sound[17].IsMuted && (Projector.Sound[17].Source != null);
            this.ISound19.Checked = !Projector.Sound[18].IsMuted && (Projector.Sound[18].Source != null);
            this.ISound20.Checked = !Projector.Sound[19].IsMuted && (Projector.Sound[19].Source != null);
            setText(0, ISound1);
            setText(1, ISound2);
            setText(2, ISound3);
            setText(3, ISound4);
            setText(4, ISound5);
            setText(5, ISound6);
            setText(6, ISound7);
            setText(7, ISound8);
            setText(8, ISound9);
            setText(9, ISound10);
            setText(10, ISound11);
            setText(11, ISound12);
            setText(12, ISound13);
            setText(13, ISound14);
            setText(14, ISound15);
            setText(15, ISound16);
            setText(16, ISound17);
            setText(17, ISound18);
            setText(18, ISound19);
            setText(19, ISound20);
        }
        bool activated = true;
        private void SoundOptions_Activated(object sender, EventArgs e)
        {
            SetIndicators();
            activated = true;
        }

        private void set(int n, CheckBox cb)
        {
            var s = Projector.Sound[n];
            var v = cb;
            if (activated)
                s.IsMuted = !v.Checked;
            if (s.Source != null)
                v.Text = s.Source.ToString();
            else
                v.Text = "none";
        }
        private void setText(int n, CheckBox cb)
        {
            var s = Projector.Sound[n];
            var v = cb;
            if (s.Source != null)
                v.Text = s.Source.ToString();
            else
                v.Text = "none";
        }
        private void ISound1_CheckStateChanged(object sender, EventArgs e)
        {
            set(0, sender as CheckBox);
        }

        private void ISound2_CheckStateChanged(object sender, EventArgs e)
        {
            set(1, sender as CheckBox);
        }

        private void ISound3_CheckStateChanged(object sender, EventArgs e)
        {
            set(2, sender as CheckBox);
        }

        private void ISound4_CheckStateChanged(object sender, EventArgs e)
        {
            set(3, sender as CheckBox);
        }

        private void ISound5_CheckStateChanged(object sender, EventArgs e)
        {
            set(4, sender as CheckBox);
        }

        private void ISound6_CheckStateChanged(object sender, EventArgs e)
        {
            set(5, sender as CheckBox);
        }

        private void ISound7_CheckStateChanged(object sender, EventArgs e)
        {
            set(6, sender as CheckBox);
        }

        private void ISound8_CheckStateChanged(object sender, EventArgs e)
        {
            set(7, sender as CheckBox);
        }

        private void ISound9_CheckStateChanged(object sender, EventArgs e)
        {
            set(8, sender as CheckBox);
        }

        private void ISound10_CheckStateChanged(object sender, EventArgs e)
        {
            set(9, sender as CheckBox);
        }

        private void ISound11_CheckStateChanged(object sender, EventArgs e)
        {
            set(10, sender as CheckBox);
        }

        private void ISound12_CheckStateChanged(object sender, EventArgs e)
        {
            set(11, sender as CheckBox);
        }

        private void ISound13_CheckStateChanged(object sender, EventArgs e)
        {
            set(12, sender as CheckBox);
        }

        private void ISound14_CheckStateChanged(object sender, EventArgs e)
        {
            set(13, sender as CheckBox);
        }

        private void ISound15_CheckStateChanged(object sender, EventArgs e)
        {
            set(14, sender as CheckBox);
        }

        private void ISound16_CheckStateChanged(object sender, EventArgs e)
        {
            set(15, sender as CheckBox);
        }

        private void ISound17_CheckStateChanged(object sender, EventArgs e)
        {
            set(16, sender as CheckBox);
        }

        private void ISound18_CheckStateChanged(object sender, EventArgs e)
        {
            set(17, sender as CheckBox);
        }

        private void ISound19_CheckStateChanged(object sender, EventArgs e)
        {
            set(18, sender as CheckBox);
        }

        private void ISound20_CheckStateChanged(object sender, EventArgs e)
        {
            set(19, sender as CheckBox);
        }
    }
}
