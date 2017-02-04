using System;
using System.Collections.Generic;

namespace StoGen.Classes
{
    partial class ucClipList
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
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ceGroupByActor = new DevExpress.XtraEditors.CheckEdit();
            this.ceGroupBySet = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGroupByActor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGroupBySet.Properties)).BeginInit();
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
            this.BS.DataSource = typeof(StoGen.Classes.SgClip);
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
            this.gcDescription,
            this.colActor,
            this.colFile,
            this.gridColumn3,
            this.colRole});
            this.gridView1.GridControl = this.MainGrid;
            this.gridView1.GroupFormat = "{1} {2}";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", null, "({0})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
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
            this.colId.Width = 20;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.Caption = "Фильм";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 150;
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0}")});
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 150;
            // 
            // colProductionYear
            // 
            this.colProductionYear.Caption = "Год";
            this.colProductionYear.FieldName = "ProductionYear";
            this.colProductionYear.MaxWidth = 40;
            this.colProductionYear.MinWidth = 40;
            this.colProductionYear.Name = "colProductionYear";
            this.colProductionYear.Visible = true;
            this.colProductionYear.VisibleIndex = 2;
            this.colProductionYear.Width = 40;
            // 
            // colGenre
            // 
            this.colGenre.FieldName = "Genre";
            this.colGenre.MaxWidth = 60;
            this.colGenre.Name = "colGenre";
            this.colGenre.Visible = true;
            this.colGenre.VisibleIndex = 9;
            this.colGenre.Width = 20;
            // 
            // colGenreType
            // 
            this.colGenreType.FieldName = "GenreType";
            this.colGenreType.MaxWidth = 60;
            this.colGenreType.Name = "colGenreType";
            this.colGenreType.Visible = true;
            this.colGenreType.VisibleIndex = 10;
            this.colGenreType.Width = 20;
            // 
            // colCountry
            // 
            this.colCountry.FieldName = "Country";
            this.colCountry.MaxWidth = 60;
            this.colCountry.Name = "colCountry";
            this.colCountry.Visible = true;
            this.colCountry.VisibleIndex = 8;
            this.colCountry.Width = 20;
            // 
            // colStudio
            // 
            this.colStudio.FieldName = "Studio";
            this.colStudio.MaxWidth = 50;
            this.colStudio.Name = "colStudio";
            this.colStudio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStudio.Visible = true;
            this.colStudio.VisibleIndex = 7;
            this.colStudio.Width = 20;
            // 
            // gcDescription
            // 
            this.gcDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gcDescription.AppearanceCell.Options.UseFont = true;
            this.gcDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gcDescription.AppearanceHeader.Options.UseFont = true;
            this.gcDescription.Caption = "Описание";
            this.gcDescription.FieldName = "Description";
            this.gcDescription.Name = "gcDescription";
            // 
            // colActor
            // 
            this.colActor.Caption = "Актер";
            this.colActor.FieldName = "ActorName";
            this.colActor.Name = "colActor";
            this.colActor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colActor.Visible = true;
            this.colActor.VisibleIndex = 4;
            this.colActor.Width = 60;
            // 
            // colFile
            // 
            this.colFile.Caption = "файл";
            this.colFile.FieldName = "OldFileName";
            this.colFile.MaxWidth = 110;
            this.colFile.MinWidth = 110;
            this.colFile.Name = "colFile";
            this.colFile.Visible = true;
            this.colFile.VisibleIndex = 5;
            this.colFile.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Описание";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.MinWidth = 300;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 300;
            // 
            // colRole
            // 
            this.colRole.Caption = "Роль";
            this.colRole.FieldName = "ActorRole";
            this.colRole.MaxWidth = 150;
            this.colRole.MinWidth = 100;
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 3;
            this.colRole.Width = 100;
            // 
            // ceGroupByActor
            // 
            this.ceGroupByActor.Location = new System.Drawing.Point(321, 3);
            this.ceGroupByActor.Name = "ceGroupByActor";
            this.ceGroupByActor.Properties.Caption = "По актеру";
            this.ceGroupByActor.Size = new System.Drawing.Size(75, 19);
            this.ceGroupByActor.TabIndex = 2;
            this.ceGroupByActor.CheckedChanged += new System.EventHandler(this.ceGroupByActor_CheckedChanged);
            // 
            // ceGroupBySet
            // 
            this.ceGroupBySet.Location = new System.Drawing.Point(402, 3);
            this.ceGroupBySet.Name = "ceGroupBySet";
            this.ceGroupBySet.Properties.Caption = "По сету";
            this.ceGroupBySet.Size = new System.Drawing.Size(75, 19);
            this.ceGroupBySet.TabIndex = 3;
            this.ceGroupBySet.CheckedChanged += new System.EventHandler(this.ceGroupBySet_CheckedChanged);
            // 
            // ucClipList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ceGroupBySet);
            this.Controls.Add(this.ceGroupByActor);
            this.Controls.Add(this.MainGrid);
            this.Name = "ucClipList";
            this.Size = new System.Drawing.Size(771, 322);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGroupByActor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGroupBySet.Properties)).EndInit();
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
        internal System.Windows.Forms.BindingSource BS;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActor;
        private DevExpress.XtraGrid.Columns.GridColumn colFile;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.CheckEdit ceGroupByActor;
        private DevExpress.XtraEditors.CheckEdit ceGroupBySet;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
    }
}
