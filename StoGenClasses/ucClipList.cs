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
    public partial class ucClipList : DevExpress.XtraEditors.XtraUserControl
    {
        public ucClipList()
        {
            InitializeComponent();
            this.gridView1.CustomDrawCell += gridView1_CustomDrawCell;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colCountry)
            {
                e.DisplayText = Enum.GetName(typeof(CountryEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colGenre)
            {
                e.DisplayText = Enum.GetName(typeof(GenreEnum), e.CellValue ?? 0);
            }
            else if (e.Column == colGenreType)
            {
                e.DisplayText = Enum.GetName(typeof(GenreTypeEnum), e.CellValue ?? 0);
            }
            //else if (e.Column == colProductionType)
            //{
            //    e.DisplayText = Enum.GetName(typeof(ProductionTypeEnum), e.CellValue ?? 0);
            //}
        }
        internal void RefreshDS()
        {
            this.MainGrid.RefreshDataSource();
        }
        internal List<SgClip> GetSelectedList()
        {
            List<SgClip> result = new List<SgClip>();
            int[] sr = this.gridView1.GetSelectedRows();

            foreach (int item in sr)
            {
                int dsri = this.gridView1.GetDataSourceRowIndex(item);
                if (dsri > 0)
                {
                    SgClip m = (SgClip)this.BS[dsri];
                    if (m != null)
                        result.Add(m);
                }
            }

            return result;
        }

        private void ceGroupByActor_CheckedChanged(object sender, EventArgs e)
        {
            
            this.gridView1.SortInfo.Clear();
            if (ceGroupByActor.Checked)
            {
                ceGroupBySet.Checked = false;
                this.gridView1.GroupCount = 2;
                this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                    new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colActor, DevExpress.Data.ColumnSortOrder.Ascending),
                     new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});           
            }
        }

        private void ceGroupBySet_CheckedChanged(object sender, EventArgs e)
        {
            
            this.gridView1.SortInfo.Clear();
            if (ceGroupBySet.Checked)
            {
                ceGroupByActor.Checked = false;
                this.gridView1.GroupCount = 2;
                this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                    new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGenre, DevExpress.Data.ColumnSortOrder.Ascending),
                     new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            }
        }
    }
}
