namespace StoGen.Classes
{
    partial class ucActorList
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
            this.colAliace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBornCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBornYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBodyType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivityType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptionShort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptionLong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaceImage1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.MainGrid.Size = new System.Drawing.Size(669, 322);
            this.MainGrid.TabIndex = 1;
            this.MainGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // BS
            // 
            this.BS.DataSource = typeof(StoGen.Classes.SgActor);
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
            this.colAliace,
            this.colGender,
            this.colBornCountry,
            this.colBornYear,
            this.colRace,
            this.colFaceType,
            this.colBodyType,
            this.colActivityType,
            this.colScore,
            this.colDescriptionShort,
            this.colDescriptionLong,
            this.colRole});
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
            this.colId.MaxWidth = 50;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 30;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 250;
            this.colName.Name = "colName";
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0}")});
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 250;
            // 
            // colAliace
            // 
            this.colAliace.FieldName = "Aliace";
            this.colAliace.Name = "colAliace";
            this.colAliace.Visible = true;
            this.colAliace.VisibleIndex = 2;
            // 
            // colGender
            // 
            this.colGender.FieldName = "Gender";
            this.colGender.MaxWidth = 50;
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 3;
            this.colGender.Width = 50;
            // 
            // colBornCountry
            // 
            this.colBornCountry.FieldName = "BornCountry";
            this.colBornCountry.MaxWidth = 100;
            this.colBornCountry.Name = "colBornCountry";
            this.colBornCountry.Visible = true;
            this.colBornCountry.VisibleIndex = 4;
            // 
            // colBornYear
            // 
            this.colBornYear.FieldName = "BornYear";
            this.colBornYear.MaxWidth = 70;
            this.colBornYear.Name = "colBornYear";
            this.colBornYear.Visible = true;
            this.colBornYear.VisibleIndex = 5;
            this.colBornYear.Width = 70;
            // 
            // colRace
            // 
            this.colRace.FieldName = "Race";
            this.colRace.MaxWidth = 60;
            this.colRace.Name = "colRace";
            this.colRace.Visible = true;
            this.colRace.VisibleIndex = 6;
            this.colRace.Width = 60;
            // 
            // colFaceType
            // 
            this.colFaceType.FieldName = "FaceType";
            this.colFaceType.MaxWidth = 150;
            this.colFaceType.Name = "colFaceType";
            this.colFaceType.Visible = true;
            this.colFaceType.VisibleIndex = 7;
            // 
            // colBodyType
            // 
            this.colBodyType.FieldName = "BodyType";
            this.colBodyType.MaxWidth = 150;
            this.colBodyType.Name = "colBodyType";
            this.colBodyType.Visible = true;
            this.colBodyType.VisibleIndex = 8;
            // 
            // colActivityType
            // 
            this.colActivityType.FieldName = "ActivityType";
            this.colActivityType.MaxWidth = 100;
            this.colActivityType.Name = "colActivityType";
            this.colActivityType.Visible = true;
            this.colActivityType.VisibleIndex = 9;
            // 
            // colScore
            // 
            this.colScore.FieldName = "Score";
            this.colScore.MaxWidth = 40;
            this.colScore.Name = "colScore";
            this.colScore.Visible = true;
            this.colScore.VisibleIndex = 10;
            this.colScore.Width = 40;
            // 
            // colDescriptionShort
            // 
            this.colDescriptionShort.FieldName = "DescriptionShort";
            this.colDescriptionShort.Name = "colDescriptionShort";
            this.colDescriptionShort.Visible = true;
            this.colDescriptionShort.VisibleIndex = 11;
            // 
            // colDescriptionLong
            // 
            this.colDescriptionLong.FieldName = "DescriptionLong";
            this.colDescriptionLong.Name = "colDescriptionLong";
            // 
            // colRole
            // 
            this.colRole.Caption = "Роль";
            this.colRole.FieldName = "RoleRelation";
            this.colRole.MaxWidth = 150;
            this.colRole.MinWidth = 150;
            this.colRole.Name = "colRole";
            this.colRole.Width = 150;
            // 
            // colFaceImage1
            // 
            this.colFaceImage1.FieldName = "FaceImage1";
            this.colFaceImage1.Name = "colFaceImage1";
            // 
            // ucActorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainGrid);
            this.Name = "ucActorList";
            this.Size = new System.Drawing.Size(669, 322);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MainGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        internal System.Windows.Forms.BindingSource BS;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAliace;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colBornCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colBornYear;
        private DevExpress.XtraGrid.Columns.GridColumn colRace;
        private DevExpress.XtraGrid.Columns.GridColumn colFaceType;
        private DevExpress.XtraGrid.Columns.GridColumn colBodyType;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityType;
        private DevExpress.XtraGrid.Columns.GridColumn colScore;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriptionShort;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriptionLong;
        private DevExpress.XtraGrid.Columns.GridColumn colFaceImage1;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
    }
}
