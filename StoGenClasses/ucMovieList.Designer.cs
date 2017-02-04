namespace StoGen.Classes
{
    partial class ucMovieList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainGrid = new DevExpress.XtraGrid.GridControl();
            this.BS = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenreType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDirector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerieName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerieSeason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerieEpisode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptionShort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptionLong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAliace = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGrid
            // 
            this.MainGrid.DataSource = this.BS;
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(0, 0);
            this.MainGrid.MainView = this.gridView1;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.Size = new System.Drawing.Size(771, 322);
            this.MainGrid.TabIndex = 1;
            this.MainGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // BS
            // 
            this.BS.DataSource = typeof(StoGen.Classes.SgMovie);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colProductionYear,
            this.colGenre,
            this.colGenreType,
            this.colCountry,
            this.colStudio,
            this.colDirector,
            this.colScore,
            this.colProductionType,
            this.colSerieName,
            this.colSerieSeason,
            this.colSerieEpisode,
            this.colDescriptionShort,
            this.colDescriptionLong,
            this.gcAliace});
            this.gridView1.GridControl = this.MainGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MaxWidth = 30;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 24;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 150;
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0}")});
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 150;
            // 
            // colProductionYear
            // 
            this.colProductionYear.FieldName = "ProductionYear";
            this.colProductionYear.MaxWidth = 50;
            this.colProductionYear.Name = "colProductionYear";
            this.colProductionYear.Visible = true;
            this.colProductionYear.VisibleIndex = 3;
            this.colProductionYear.Width = 45;
            // 
            // colGenre
            // 
            this.colGenre.FieldName = "Genre";
            this.colGenre.MaxWidth = 60;
            this.colGenre.Name = "colGenre";
            this.colGenre.Visible = true;
            this.colGenre.VisibleIndex = 5;
            this.colGenre.Width = 53;
            // 
            // colGenreType
            // 
            this.colGenreType.FieldName = "GenreType";
            this.colGenreType.MaxWidth = 60;
            this.colGenreType.Name = "colGenreType";
            this.colGenreType.Visible = true;
            this.colGenreType.VisibleIndex = 4;
            this.colGenreType.Width = 53;
            // 
            // colCountry
            // 
            this.colCountry.FieldName = "Country";
            this.colCountry.MaxWidth = 60;
            this.colCountry.Name = "colCountry";
            this.colCountry.Visible = true;
            this.colCountry.VisibleIndex = 6;
            this.colCountry.Width = 53;
            // 
            // colStudio
            // 
            this.colStudio.FieldName = "Studio";
            this.colStudio.Name = "colStudio";
            this.colStudio.Visible = true;
            this.colStudio.VisibleIndex = 7;
            this.colStudio.Width = 74;
            // 
            // colDirector
            // 
            this.colDirector.FieldName = "Director";
            this.colDirector.Name = "colDirector";
            this.colDirector.Visible = true;
            this.colDirector.VisibleIndex = 8;
            this.colDirector.Width = 74;
            // 
            // colScore
            // 
            this.colScore.FieldName = "Score";
            this.colScore.MaxWidth = 20;
            this.colScore.Name = "colScore";
            this.colScore.Visible = true;
            this.colScore.VisibleIndex = 1;
            this.colScore.Width = 20;
            // 
            // colProductionType
            // 
            this.colProductionType.FieldName = "ProductionType";
            this.colProductionType.MaxWidth = 60;
            this.colProductionType.Name = "colProductionType";
            this.colProductionType.Visible = true;
            this.colProductionType.VisibleIndex = 10;
            this.colProductionType.Width = 53;
            // 
            // colSerieName
            // 
            this.colSerieName.FieldName = "SerieName";
            this.colSerieName.Name = "colSerieName";
            // 
            // colSerieSeason
            // 
            this.colSerieSeason.FieldName = "SerieSeason";
            this.colSerieSeason.Name = "colSerieSeason";
            // 
            // colSerieEpisode
            // 
            this.colSerieEpisode.FieldName = "SerieEpisode";
            this.colSerieEpisode.Name = "colSerieEpisode";
            // 
            // colDescriptionShort
            // 
            this.colDescriptionShort.FieldName = "DescriptionShort";
            this.colDescriptionShort.Name = "colDescriptionShort";
            this.colDescriptionShort.Visible = true;
            this.colDescriptionShort.VisibleIndex = 9;
            // 
            // colDescriptionLong
            // 
            this.colDescriptionLong.FieldName = "DescriptionLong";
            this.colDescriptionLong.Name = "colDescriptionLong";
            // 
            // gcAliace
            // 
            this.gcAliace.Caption = "Aliace";
            this.gcAliace.FieldName = "Aliace";
            this.gcAliace.Name = "gcAliace";
            this.gcAliace.Visible = true;
            this.gcAliace.VisibleIndex = 11;
            this.gcAliace.Width = 79;
            // 
            // ucMovieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainGrid);
            this.Name = "ucMovieList";
            this.Size = new System.Drawing.Size(771, 322);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MainGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionYear;
        private DevExpress.XtraGrid.Columns.GridColumn colGenre;
        private DevExpress.XtraGrid.Columns.GridColumn colGenreType;
        private DevExpress.XtraGrid.Columns.GridColumn colCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colStudio;
        private DevExpress.XtraGrid.Columns.GridColumn colDirector;
        private DevExpress.XtraGrid.Columns.GridColumn colScore;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionType;
        private DevExpress.XtraGrid.Columns.GridColumn colSerieName;
        private DevExpress.XtraGrid.Columns.GridColumn colSerieSeason;
        private DevExpress.XtraGrid.Columns.GridColumn colSerieEpisode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriptionShort;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriptionLong;
        internal System.Windows.Forms.BindingSource BS;
        private DevExpress.XtraGrid.Columns.GridColumn gcAliace;
    }
}
