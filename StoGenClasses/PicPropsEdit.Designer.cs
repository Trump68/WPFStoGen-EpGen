namespace StoGen.Classes
{
    partial class PicPropsEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ceForAll = new DevExpress.XtraEditors.CheckEdit();
            this.eSizeY = new DevExpress.XtraEditors.SpinEdit();
            this.eSizeX = new DevExpress.XtraEditors.SpinEdit();
            this.ePositionY = new DevExpress.XtraEditors.SpinEdit();
            this.ePositionX = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceForAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSizeY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSizeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePositionY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePositionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.teName);
            this.layoutControl1.Controls.Add(this.ceForAll);
            this.layoutControl1.Controls.Add(this.eSizeY);
            this.layoutControl1.Controls.Add(this.eSizeX);
            this.layoutControl1.Controls.Add(this.ePositionY);
            this.layoutControl1.Controls.Add(this.ePositionX);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(605, 143);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ceForAll
            // 
            this.ceForAll.Location = new System.Drawing.Point(12, 84);
            this.ceForAll.Name = "ceForAll";
            this.ceForAll.Properties.Caption = "For all main pics";
            this.ceForAll.Size = new System.Drawing.Size(581, 19);
            this.ceForAll.StyleController = this.layoutControl1;
            this.ceForAll.TabIndex = 8;
            // 
            // eSizeY
            // 
            this.eSizeY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eSizeY.Location = new System.Drawing.Point(214, 36);
            this.eSizeY.MaximumSize = new System.Drawing.Size(100, 0);
            this.eSizeY.Name = "eSizeY";
            this.eSizeY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.eSizeY.Properties.IsFloatValue = false;
            this.eSizeY.Properties.Mask.EditMask = "N00";
            this.eSizeY.Size = new System.Drawing.Size(100, 20);
            this.eSizeY.StyleController = this.layoutControl1;
            this.eSizeY.TabIndex = 7;
            // 
            // eSizeX
            // 
            this.eSizeX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eSizeX.Location = new System.Drawing.Point(61, 36);
            this.eSizeX.MaximumSize = new System.Drawing.Size(100, 0);
            this.eSizeX.Name = "eSizeX";
            this.eSizeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.eSizeX.Properties.IsFloatValue = false;
            this.eSizeX.Properties.Mask.EditMask = "N00";
            this.eSizeX.Size = new System.Drawing.Size(100, 20);
            this.eSizeX.StyleController = this.layoutControl1;
            this.eSizeX.TabIndex = 6;
            // 
            // ePositionY
            // 
            this.ePositionY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ePositionY.Location = new System.Drawing.Point(214, 12);
            this.ePositionY.MaximumSize = new System.Drawing.Size(100, 0);
            this.ePositionY.Name = "ePositionY";
            this.ePositionY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ePositionY.Properties.IsFloatValue = false;
            this.ePositionY.Properties.Mask.EditMask = "N00";
            this.ePositionY.Size = new System.Drawing.Size(100, 20);
            this.ePositionY.StyleController = this.layoutControl1;
            this.ePositionY.TabIndex = 5;
            // 
            // ePositionX
            // 
            this.ePositionX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ePositionX.Location = new System.Drawing.Point(61, 12);
            this.ePositionX.MaximumSize = new System.Drawing.Size(100, 0);
            this.ePositionX.Name = "ePositionX";
            this.ePositionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ePositionX.Properties.IsFloatValue = false;
            this.ePositionX.Properties.Mask.EditMask = "N00";
            this.ePositionX.Size = new System.Drawing.Size(100, 20);
            this.ePositionX.StyleController = this.layoutControl1;
            this.ePositionX.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 143);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ePositionX;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem1.Text = "Position X";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ePositionY;
            this.layoutControlItem2.Location = new System.Drawing.Point(153, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem2.Text = "Position Y";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.eSizeX;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem3.Text = "Size X";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.eSizeY;
            this.layoutControlItem4.Location = new System.Drawing.Point(153, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem4.Text = "Size Y";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ceForAll;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(585, 51);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(61, 60);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(532, 20);
            this.teName.StyleController = this.layoutControl1;
            this.teName.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.teName;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem6.Text = "Name";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(46, 13);
            // 
            // PicPropsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 143);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "PicPropsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Props Edit";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PicPropsEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceForAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSizeY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSizeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePositionY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePositionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit ePositionY;
        private DevExpress.XtraEditors.SpinEdit ePositionX;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit eSizeY;
        private DevExpress.XtraEditors.SpinEdit eSizeX;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.CheckEdit ceForAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}