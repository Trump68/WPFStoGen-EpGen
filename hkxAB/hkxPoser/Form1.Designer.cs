namespace hkxPoser
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                viewer.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFindBone = new System.Windows.Forms.ToolStripMenuItem();
            this.serializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restorePoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.CadreN = new System.Windows.Forms.TextBox();
            this.tRotations = new System.Windows.Forms.TextBox();
            this.numCurrent = new System.Windows.Forms.NumericUpDown();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.numEnd = new System.Windows.Forms.NumericUpDown();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.btnSetEnd = new System.Windows.Forms.Button();
            this.btnInterpolate = new System.Windows.Forms.Button();
            this.numPoint1 = new System.Windows.Forms.NumericUpDown();
            this.numPoint2 = new System.Windows.Forms.NumericUpDown();
            this.btnPoint1 = new System.Windows.Forms.Button();
            this.btnPoint2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numTrim = new System.Windows.Forms.NumericUpDown();
            this.btnTrimStart = new System.Windows.Forms.Button();
            this.btnTrimEnd = new System.Windows.Forms.Button();
            this.btnAddStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.restoreFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 35;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.miFindBone,
            this.serializeToolStripMenuItem,
            this.restorePoseToolStripMenuItem,
            this.restoreFullToolStripMenuItem,
            this.restoreAllToolStripMenuItem,
            this.setRotationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // miFindBone
            // 
            this.miFindBone.Name = "miFindBone";
            this.miFindBone.Size = new System.Drawing.Size(72, 20);
            this.miFindBone.Text = "Find bone";
            this.miFindBone.Click += new System.EventHandler(this.miFindBone_Click);
            // 
            // serializeToolStripMenuItem
            // 
            this.serializeToolStripMenuItem.Name = "serializeToolStripMenuItem";
            this.serializeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.serializeToolStripMenuItem.Text = "SaveP";
            this.serializeToolStripMenuItem.Click += new System.EventHandler(this.serializeToolStripMenuItem_Click);
            // 
            // restorePoseToolStripMenuItem
            // 
            this.restorePoseToolStripMenuItem.Name = "restorePoseToolStripMenuItem";
            this.restorePoseToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.restorePoseToolStripMenuItem.Text = "RestoreP";
            this.restorePoseToolStripMenuItem.Click += new System.EventHandler(this.restorePoseToolStripMenuItem_Click);
            // 
            // restoreAllToolStripMenuItem
            // 
            this.restoreAllToolStripMenuItem.Name = "restoreAllToolStripMenuItem";
            this.restoreAllToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.restoreAllToolStripMenuItem.Text = "RestoreAll";
            this.restoreAllToolStripMenuItem.Click += new System.EventHandler(this.restoreAllToolStripMenuItem_Click);
            // 
            // setRotationsToolStripMenuItem
            // 
            this.setRotationsToolStripMenuItem.Name = "setRotationsToolStripMenuItem";
            this.setRotationsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.setRotationsToolStripMenuItem.Text = "Applay";
            this.setRotationsToolStripMenuItem.Click += new System.EventHandler(this.setRotationsToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(12, 704);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(963, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(0, 27);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(301, 20);
            this.InputBox.TabIndex = 2;
            // 
            // CadreN
            // 
            this.CadreN.Location = new System.Drawing.Point(0, 79);
            this.CadreN.Name = "CadreN";
            this.CadreN.Size = new System.Drawing.Size(301, 20);
            this.CadreN.TabIndex = 3;
            // 
            // tRotations
            // 
            this.tRotations.Location = new System.Drawing.Point(0, 53);
            this.tRotations.Name = "tRotations";
            this.tRotations.Size = new System.Drawing.Size(301, 20);
            this.tRotations.TabIndex = 4;
            // 
            // numCurrent
            // 
            this.numCurrent.Location = new System.Drawing.Point(12, 105);
            this.numCurrent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCurrent.Name = "numCurrent";
            this.numCurrent.Size = new System.Drawing.Size(67, 20);
            this.numCurrent.TabIndex = 5;
            this.numCurrent.ValueChanged += new System.EventHandler(this.numCurrent_ValueChanged);
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(12, 131);
            this.numStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(67, 20);
            this.numStart.TabIndex = 6;
            // 
            // numEnd
            // 
            this.numEnd.Location = new System.Drawing.Point(12, 240);
            this.numEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEnd.Name = "numEnd";
            this.numEnd.Size = new System.Drawing.Size(67, 20);
            this.numEnd.TabIndex = 7;
            // 
            // btnSetStart
            // 
            this.btnSetStart.Location = new System.Drawing.Point(85, 128);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(53, 23);
            this.btnSetStart.TabIndex = 8;
            this.btnSetStart.Text = "Start";
            this.btnSetStart.UseVisualStyleBackColor = true;
            this.btnSetStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSetEnd
            // 
            this.btnSetEnd.Location = new System.Drawing.Point(85, 240);
            this.btnSetEnd.Name = "btnSetEnd";
            this.btnSetEnd.Size = new System.Drawing.Size(53, 23);
            this.btnSetEnd.TabIndex = 9;
            this.btnSetEnd.Text = "End";
            this.btnSetEnd.UseVisualStyleBackColor = true;
            this.btnSetEnd.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // btnInterpolate
            // 
            this.btnInterpolate.Location = new System.Drawing.Point(12, 285);
            this.btnInterpolate.Name = "btnInterpolate";
            this.btnInterpolate.Size = new System.Drawing.Size(67, 23);
            this.btnInterpolate.TabIndex = 10;
            this.btnInterpolate.Text = "Interpolate";
            this.btnInterpolate.UseVisualStyleBackColor = true;
            this.btnInterpolate.Click += new System.EventHandler(this.btnInterpolate_Click);
            // 
            // numPoint1
            // 
            this.numPoint1.Location = new System.Drawing.Point(12, 174);
            this.numPoint1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPoint1.Name = "numPoint1";
            this.numPoint1.Size = new System.Drawing.Size(67, 20);
            this.numPoint1.TabIndex = 11;
            // 
            // numPoint2
            // 
            this.numPoint2.Location = new System.Drawing.Point(12, 200);
            this.numPoint2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPoint2.Name = "numPoint2";
            this.numPoint2.Size = new System.Drawing.Size(67, 20);
            this.numPoint2.TabIndex = 12;
            // 
            // btnPoint1
            // 
            this.btnPoint1.Location = new System.Drawing.Point(85, 171);
            this.btnPoint1.Name = "btnPoint1";
            this.btnPoint1.Size = new System.Drawing.Size(53, 23);
            this.btnPoint1.TabIndex = 13;
            this.btnPoint1.Text = "Point1";
            this.btnPoint1.UseVisualStyleBackColor = true;
            this.btnPoint1.Click += new System.EventHandler(this.btnPoint1_Click);
            // 
            // btnPoint2
            // 
            this.btnPoint2.Location = new System.Drawing.Point(85, 200);
            this.btnPoint2.Name = "btnPoint2";
            this.btnPoint2.Size = new System.Drawing.Size(53, 23);
            this.btnPoint2.TabIndex = 14;
            this.btnPoint2.Text = "Point2";
            this.btnPoint2.UseVisualStyleBackColor = true;
            this.btnPoint2.Click += new System.EventHandler(this.btnPoint2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numTrim
            // 
            this.numTrim.Location = new System.Drawing.Point(12, 409);
            this.numTrim.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTrim.Name = "numTrim";
            this.numTrim.Size = new System.Drawing.Size(67, 20);
            this.numTrim.TabIndex = 16;
            // 
            // btnTrimStart
            // 
            this.btnTrimStart.Location = new System.Drawing.Point(12, 444);
            this.btnTrimStart.Name = "btnTrimStart";
            this.btnTrimStart.Size = new System.Drawing.Size(67, 23);
            this.btnTrimStart.TabIndex = 17;
            this.btnTrimStart.Text = "Trim start";
            this.btnTrimStart.UseVisualStyleBackColor = true;
            this.btnTrimStart.Click += new System.EventHandler(this.btnTrimStart_Click);
            // 
            // btnTrimEnd
            // 
            this.btnTrimEnd.Location = new System.Drawing.Point(12, 473);
            this.btnTrimEnd.Name = "btnTrimEnd";
            this.btnTrimEnd.Size = new System.Drawing.Size(67, 23);
            this.btnTrimEnd.TabIndex = 18;
            this.btnTrimEnd.Text = "Trim end";
            this.btnTrimEnd.UseVisualStyleBackColor = true;
            this.btnTrimEnd.Click += new System.EventHandler(this.btnTrimEnd_Click);
            // 
            // btnAddStart
            // 
            this.btnAddStart.Location = new System.Drawing.Point(12, 502);
            this.btnAddStart.Name = "btnAddStart";
            this.btnAddStart.Size = new System.Drawing.Size(67, 23);
            this.btnAddStart.TabIndex = 19;
            this.btnAddStart.Text = "Add start";
            this.btnAddStart.UseVisualStyleBackColor = true;
            this.btnAddStart.Click += new System.EventHandler(this.btnAddStart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Add end";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(665, 4);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(67, 20);
            this.numSpeed.TabIndex = 21;
            this.numSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // restoreFullToolStripMenuItem
            // 
            this.restoreFullToolStripMenuItem.Name = "restoreFullToolStripMenuItem";
            this.restoreFullToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.restoreFullToolStripMenuItem.Text = "RestoreFull";
            this.restoreFullToolStripMenuItem.Click += new System.EventHandler(this.restoreFullToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 749);
            this.Controls.Add(this.numSpeed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddStart);
            this.Controls.Add(this.btnTrimEnd);
            this.Controls.Add(this.btnTrimStart);
            this.Controls.Add(this.numTrim);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPoint2);
            this.Controls.Add(this.btnPoint1);
            this.Controls.Add(this.numPoint2);
            this.Controls.Add(this.numPoint1);
            this.Controls.Add(this.btnInterpolate);
            this.Controls.Add(this.btnSetEnd);
            this.Controls.Add(this.btnSetStart);
            this.Controls.Add(this.numEnd);
            this.Controls.Add(this.numStart);
            this.Controls.Add(this.numCurrent);
            this.Controls.Add(this.tRotations);
            this.Controls.Add(this.CadreN);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "hkxPoser";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem miFindBone;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.ToolStripMenuItem serializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restorePoseToolStripMenuItem;
        private System.Windows.Forms.TextBox CadreN;
        private System.Windows.Forms.TextBox tRotations;
        private System.Windows.Forms.ToolStripMenuItem setRotationsToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numCurrent;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnSetEnd;
        private System.Windows.Forms.Button btnInterpolate;
        private System.Windows.Forms.NumericUpDown numPoint1;
        private System.Windows.Forms.NumericUpDown numPoint2;
        private System.Windows.Forms.Button btnPoint1;
        private System.Windows.Forms.Button btnPoint2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numTrim;
        private System.Windows.Forms.Button btnTrimStart;
        private System.Windows.Forms.Button btnTrimEnd;
        private System.Windows.Forms.Button btnAddStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem restoreAllToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.ToolStripMenuItem restoreFullToolStripMenuItem;
    }
}

