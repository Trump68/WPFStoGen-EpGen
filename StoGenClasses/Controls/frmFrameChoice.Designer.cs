namespace StoGen.Classes
{
    partial class frmFrameChoice
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFrameChoice));
            this.TileViewName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.LabelText = new System.Windows.Forms.Label();
            this.Grid = new DevExpress.XtraGrid.GridControl();
            this.BS = new System.Windows.Forms.BindingSource();
            this.ViewTiles = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.TileViewPicture = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.ViewGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // TileViewName
            // 
            this.TileViewName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileViewName.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TileViewName.AppearanceCell.Options.UseFont = true;
            this.TileViewName.AppearanceCell.Options.UseForeColor = true;
            this.TileViewName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileViewName.AppearanceHeader.Options.UseFont = true;
            this.TileViewName.Caption = "Name";
            this.TileViewName.FieldName = "Name";
            this.TileViewName.Name = "TileViewName";
            this.TileViewName.Visible = true;
            this.TileViewName.VisibleIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.LabelText);
            this.layoutControl1.Controls.Add(this.Grid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 250);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // LabelText
            // 
            this.LabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelText.Location = new System.Drawing.Point(2, 2);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(796, 20);
            this.LabelText.TabIndex = 5;
            this.LabelText.Text = "Choose Menu ";
            // 
            // Grid
            // 
            this.Grid.DataSource = this.BS;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(2, 26);
            this.Grid.MainView = this.ViewTiles;
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(796, 222);
            this.Grid.TabIndex = 4;
            this.Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewTiles,
            this.ViewGrid});
            // 
            // ViewTiles
            // 
            this.ViewTiles.Appearance.ItemFocused.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewTiles.Appearance.ItemFocused.FontSizeDelta = 1;
            this.ViewTiles.Appearance.ItemFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ViewTiles.Appearance.ItemFocused.Options.UseFont = true;
            this.ViewTiles.Appearance.ItemFocused.Options.UseForeColor = true;
            this.ViewTiles.Appearance.ItemNormal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewTiles.Appearance.ItemNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ViewTiles.Appearance.ItemNormal.Options.UseFont = true;
            this.ViewTiles.Appearance.ItemNormal.Options.UseForeColor = true;
            this.ViewTiles.Appearance.ItemSelected.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewTiles.Appearance.ItemSelected.FontSizeDelta = 1;
            this.ViewTiles.Appearance.ItemSelected.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this.ViewTiles.Appearance.ItemSelected.Options.UseFont = true;
            this.ViewTiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TileViewName,
            this.TileViewPicture});
            this.ViewTiles.ColumnSet.BackgroundImageColumn = this.TileViewPicture;
            this.ViewTiles.GridControl = this.Grid;
            this.ViewTiles.Name = "ViewTiles";
            this.ViewTiles.OptionsTiles.HighlightFocusedTileOnGridLoad = true;
            this.ViewTiles.OptionsTiles.IndentBetweenItems = 0;
            this.ViewTiles.OptionsTiles.ItemBackgroundImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            this.ViewTiles.OptionsTiles.ItemSize = new System.Drawing.Size(200, 200);
            this.ViewTiles.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.ViewTiles.TileRows.Add(tableRowDefinition1);
            tileViewItemElement1.Column = this.TileViewName;
            tileViewItemElement1.Text = "TileViewName";
            this.ViewTiles.TileTemplate.Add(tileViewItemElement1);
            // 
            // TileViewPicture
            // 
            this.TileViewPicture.Caption = "tileViewColumn2";
            this.TileViewPicture.FieldName = "Picture";
            this.TileViewPicture.Name = "TileViewPicture";
            this.TileViewPicture.Visible = true;
            this.TileViewPicture.VisibleIndex = 1;
            // 
            // ViewGrid
            // 
            this.ViewGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewGrid.Appearance.Row.Options.UseFont = true;
            this.ViewGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName});
            this.ViewGrid.GridControl = this.Grid;
            this.ViewGrid.Name = "ViewGrid";
            this.ViewGrid.OptionsBehavior.Editable = false;
            this.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.ViewGrid.OptionsView.ShowColumnHeaders = false;
            this.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.ViewGrid.PaintStyleName = "Skin";
            this.ViewGrid.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.ViewGrid.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 250);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Grid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(800, 226);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.LabelText;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(800, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmFrameChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 250);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmFrameChoice";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options Menu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFrameChoice_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewGrid;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private System.Windows.Forms.BindingSource BS;
        private System.Windows.Forms.Label LabelText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Views.Tile.TileView ViewTiles;
        private DevExpress.XtraGrid.Columns.TileViewColumn TileViewName;
        private DevExpress.XtraGrid.Columns.TileViewColumn TileViewPicture;
    }
}