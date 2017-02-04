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
    public partial class ucMovieList : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMovieList()
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
            else if (e.Column == colProductionType)
            {
                e.DisplayText = Enum.GetName(typeof(ProductionTypeEnum), e.CellValue ?? 0);
            }
        }
        internal void RefreshDS()
        {
            this.MainGrid.RefreshDataSource();
        }
    }
}
