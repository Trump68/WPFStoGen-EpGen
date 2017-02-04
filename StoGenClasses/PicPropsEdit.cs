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
    public partial class PicPropsEdit : Form
    {
        PictureSourceDataProps Psp;
        public static DialogResult ShowProps(PictureSourceDataProps psp, ref bool isforall)
        {
            DialogResult dr = DialogResult.Cancel;
            using (PicPropsEdit frm = new PicPropsEdit()) 
            {
                frm.Psp = psp;
                frm.ePositionX.Value = psp.X;
                frm.ePositionY.Value = psp.Y;
                frm.eSizeX.Value = psp.SizeX;
                frm.eSizeY.Value = psp.SizeY;
                frm.teName.Text = psp.Name;
                frm.ceForAll.Checked = isforall;                
                dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    psp.X = Convert.ToInt32(frm.ePositionX.Value);
                    psp.Y = Convert.ToInt32(frm.ePositionY.Value);
                    psp.SizeY = Convert.ToInt32(frm.eSizeY.Value);
                    psp.SizeX = Convert.ToInt32(frm.eSizeX.Value);
                    isforall = frm.ceForAll.Checked;
                    if (!isforall)
                    {
                        psp.OnlyName = frm.teName.Text;
                    }
                }
                frm.Dispose();
            }
            return dr;
        }
        public PicPropsEdit()
        {
            InitializeComponent();
        }

        private void PicPropsEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
    }
}
