namespace CADPlot
{
    partial class frmShow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow));
            this.txtPrintSize = new System.Windows.Forms.TextBox();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.fbdOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.lvDataView = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbMapSheet = new System.Windows.Forms.ToolStripDropDownButton();
            this.btA4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA0 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA43 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA44 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA33 = new System.Windows.Forms.ToolStripMenuItem();
            this.btA34 = new System.Windows.Forms.ToolStripMenuItem();
            this.btOther = new System.Windows.Forms.ToolStripMenuItem();
            this.btAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSetting = new System.Windows.Forms.ToolStripButton();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblForA4 = new System.Windows.Forms.ToolStripStatusLabel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.txtPrintSize);
            groupBox1.Controls.Add(this.txtPrinter);
            groupBox1.Controls.Add(this.checkBox1);
            groupBox1.Controls.Add(this.btPrint);
            groupBox1.Controls.Add(this.numericUpDown1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(0, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(703, 82);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "打印设置";
            // 
            // txtPrintSize
            // 
            this.txtPrintSize.Location = new System.Drawing.Point(69, 54);
            this.txtPrintSize.Name = "txtPrintSize";
            this.txtPrintSize.ReadOnly = true;
            this.txtPrintSize.Size = new System.Drawing.Size(205, 21);
            this.txtPrintSize.TabIndex = 10;
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(69, 22);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.ReadOnly = true;
            this.txtPrinter.Size = new System.Drawing.Size(206, 21);
            this.txtPrinter.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(299, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "允许重复打印";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Image = global::CADPlot.Properties.Resources.printer;
            this.btPrint.Location = new System.Drawing.Point(420, 20);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(110, 55);
            this.btPrint.TabIndex = 6;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.OnPrint_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(353, 23);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(295, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 12);
            label3.TabIndex = 4;
            label3.Text = "打印份数：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 59);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 12);
            label2.TabIndex = 2;
            label2.Text = "图纸尺寸：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label1.Location = new System.Drawing.Point(10, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 12);
            label1.TabIndex = 0;
            label1.Text = "打印设备：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = false;
            this.lblCurrentFolder.AutoToolTip = true;
            this.lblCurrentFolder.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblCurrentFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(200, 21);
            this.lblCurrentFolder.Text = "文件夹：";
            this.lblCurrentFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoToolTip = true;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 20);
            this.toolStripProgressBar1.Visible = false;
            // 
            // lvDataView
            // 
            this.lvDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDataView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvDataView.FullRowSelect = true;
            this.lvDataView.GridLines = true;
            this.lvDataView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDataView.Location = new System.Drawing.Point(0, 130);
            this.lvDataView.Name = "lvDataView";
            this.lvDataView.Size = new System.Drawing.Size(703, 423);
            this.lvDataView.TabIndex = 11;
            this.lvDataView.TileSize = new System.Drawing.Size(150, 100);
            this.lvDataView.UseCompatibleStateImageBehavior = false;
            this.lvDataView.View = System.Windows.Forms.View.Details;
            this.lvDataView.DoubleClick += new System.EventHandler(this.lvDataView_DoubleClick);
            this.lvDataView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvDataView_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrintSelected,
            this.menuDelSelected});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 48);
            // 
            // menuPrintSelected
            // 
            this.menuPrintSelected.Name = "menuPrintSelected";
            this.menuPrintSelected.Size = new System.Drawing.Size(94, 22);
            this.menuPrintSelected.Text = "打印";
            // 
            // menuDelSelected
            // 
            this.menuDelSelected.Name = "menuDelSelected";
            this.menuDelSelected.Size = new System.Drawing.Size(94, 22);
            this.menuDelSelected.Text = "删除";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbFilter,
            this.toolStripSeparator2,
            this.tbMapSheet,
            this.tbCount,
            this.toolStripSeparator1,
            this.tbSetting,
            this.tbPrint,
            this.lblTotal,
            this.lblForA4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(703, 39);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbAdd
            // 
            this.tbAdd.Image = global::CADPlot.Properties.Resources.add;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(65, 36);
            this.tbAdd.Text = "打开";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Image = global::CADPlot.Properties.Resources.filter;
            this.tbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(65, 36);
            this.tbFilter.Text = "筛选";
            this.tbFilter.Click += new System.EventHandler(this.tbFilter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tbMapSheet
            // 
            this.tbMapSheet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btA4,
            this.btA3,
            this.btA2,
            this.btA1,
            this.btA0,
            this.btA43,
            this.btA44,
            this.btA33,
            this.btA34,
            this.btOther,
            this.btAll});
            this.tbMapSheet.Image = global::CADPlot.Properties.Resources.books;
            this.tbMapSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbMapSheet.Name = "tbMapSheet";
            this.tbMapSheet.Size = new System.Drawing.Size(74, 36);
            this.tbMapSheet.Text = "图幅";
            // 
            // btA4
            // 
            this.btA4.Name = "btA4";
            this.btA4.Size = new System.Drawing.Size(152, 22);
            this.btA4.Text = "A4";
            this.btA4.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA3
            // 
            this.btA3.Name = "btA3";
            this.btA3.Size = new System.Drawing.Size(152, 22);
            this.btA3.Text = "A3";
            this.btA3.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA2
            // 
            this.btA2.Name = "btA2";
            this.btA2.Size = new System.Drawing.Size(152, 22);
            this.btA2.Text = "A2";
            this.btA2.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA1
            // 
            this.btA1.Name = "btA1";
            this.btA1.Size = new System.Drawing.Size(152, 22);
            this.btA1.Text = "A1";
            this.btA1.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA0
            // 
            this.btA0.Name = "btA0";
            this.btA0.Size = new System.Drawing.Size(152, 22);
            this.btA0.Text = "A0";
            this.btA0.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA43
            // 
            this.btA43.Name = "btA43";
            this.btA43.Size = new System.Drawing.Size(152, 22);
            this.btA43.Text = "A4*3";
            this.btA43.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA44
            // 
            this.btA44.Name = "btA44";
            this.btA44.Size = new System.Drawing.Size(152, 22);
            this.btA44.Text = "A4*4";
            this.btA44.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA33
            // 
            this.btA33.Name = "btA33";
            this.btA33.Size = new System.Drawing.Size(152, 22);
            this.btA33.Text = "A3*3";
            this.btA33.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btA34
            // 
            this.btA34.Name = "btA34";
            this.btA34.Size = new System.Drawing.Size(152, 22);
            this.btA34.Text = "A3*4";
            this.btA34.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btOther
            // 
            this.btOther.Name = "btOther";
            this.btOther.Size = new System.Drawing.Size(152, 22);
            this.btOther.Text = "其它";
            this.btOther.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // btAll
            // 
            this.btAll.Name = "btAll";
            this.btAll.Size = new System.Drawing.Size(152, 22);
            this.btAll.Text = "全部";
            this.btAll.Click += new System.EventHandler(this.OnMapSheetClick);
            // 
            // tbCount
            // 
            this.tbCount.Image = global::CADPlot.Properties.Resources.money;
            this.tbCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(65, 36);
            this.tbCount.Text = "统计";
            this.tbCount.Click += new System.EventHandler(this.tbCount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tbSetting
            // 
            this.tbSetting.Image = global::CADPlot.Properties.Resources.admintools;
            this.tbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSetting.Name = "tbSetting";
            this.tbSetting.Size = new System.Drawing.Size(65, 36);
            this.tbSetting.Text = "设置";
            this.tbSetting.Click += new System.EventHandler(this.tbSetting_Click);
            // 
            // tbPrint
            // 
            this.tbPrint.Image = global::CADPlot.Properties.Resources.Print;
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(65, 36);
            this.tbPrint.Text = "打印";
            this.tbPrint.Click += new System.EventHandler(this.OnPrint_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = false;
            this.lblTotal.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblTotal.Image = global::CADPlot.Properties.Resources.pin_blue;
            this.lblTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 21);
            this.lblTotal.Text = "自然张数：0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForA4
            // 
            this.lblForA4.AutoSize = false;
            this.lblForA4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblForA4.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblForA4.Image = global::CADPlot.Properties.Resources.pin_green;
            this.lblForA4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblForA4.Name = "lblForA4";
            this.lblForA4.Size = new System.Drawing.Size(100, 21);
            this.lblForA4.Text = "折合A4：0";
            this.lblForA4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 579);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvDataView);
            this.Controls.Add(groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShow";
            this.Text = "CAD批量打印";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentFolder;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblForA4;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.FolderBrowserDialog fbdOpen;
        private System.Windows.Forms.TextBox txtPrintSize;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListView lvDataView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPrintSelected;
        private System.Windows.Forms.ToolStripMenuItem menuDelSelected;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbFilter;
        private System.Windows.Forms.ToolStripButton tbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton tbMapSheet;
        private System.Windows.Forms.ToolStripMenuItem btA4;
        private System.Windows.Forms.ToolStripMenuItem btA3;
        private System.Windows.Forms.ToolStripMenuItem btA2;
        private System.Windows.Forms.ToolStripMenuItem btA1;
        private System.Windows.Forms.ToolStripMenuItem btA43;
        private System.Windows.Forms.ToolStripMenuItem btA44;
        private System.Windows.Forms.ToolStripMenuItem btA33;
        private System.Windows.Forms.ToolStripMenuItem btA34;
        private System.Windows.Forms.ToolStripMenuItem btOther;
        private System.Windows.Forms.ToolStripMenuItem btAll;
        private System.Windows.Forms.ToolStripMenuItem btA0;
        private System.Windows.Forms.ToolStripButton tbCount;
    }
}