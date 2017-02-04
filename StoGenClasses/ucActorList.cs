using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StoGen.Classes
{
    public partial class ucActorList : DevExpress.XtraEditors.XtraUserControl
    {
        public bool RoleColVisible
        {
            get { return this.colRole.Visible; }
            set
            {
                this.colRole.Visible = value;
                if (this.colRole.Visible)
                    this.colRole.VisibleIndex = 1;
            }
        }
        public ucActorList()
        {
            InitializeComponent();
            this.gridView1.CustomDrawCell += gridView1_CustomDrawCell;
        }
        public void SetList(List<SgActor> ds)
        {
            this.BS.DataSource = ds;
        }
        public SgActor CurrentActor
        {
            get { return this.BS.Current as SgActor; }
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colBornCountry)
            {
                e.DisplayText = Enum.GetName(typeof(CountryEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colGender)
            {
                e.DisplayText = Enum.GetName(typeof(GenderEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colFaceType)
            {
                e.DisplayText = Enum.GetName(typeof(FaceTypeEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colBodyType)
            {
                e.DisplayText = Enum.GetName(typeof(BodyTypeEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colRole)
            {
                e.DisplayText = Enum.GetName(typeof(RoleRelationEnum), e.CellValue ?? 0);
            }
        }
    }
}
