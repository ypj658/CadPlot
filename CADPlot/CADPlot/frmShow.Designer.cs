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
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Panel panel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblForA4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btSetting = new System.Windows.Forms.Button();
            this.btFilter = new System.Windows.Forms.Button();
            this.btGetFilesToPrint = new System.Windows.Forms.Button();
            this.fbdOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPrintSize = new System.Windows.Forms.TextBox();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btOther = new System.Windows.Forms.Button();
            this.btA34 = new System.Windows.Forms.Button();
            this.btA33 = new System.Windows.Forms.Button();
            this.btA44 = new System.Windows.Forms.Button();
            this.btA43 = new System.Windows.Forms.Button();
            this.btA0 = new System.Windows.Forms.Button();
            this.btA1 = new System.Windows.Forms.Button();
            this.btA2 = new System.Windows.Forms.Button();
            this.btA3 = new System.Windows.Forms.Button();
            this.btA4 = new System.Windows.Forms.Button();
            this.lstOptionList = new System.Windows.Forms.ListBox();
            this.lvDataView = new System.Windows.Forms.ListView();
            panel1 = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 26);
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
            this.lblCurrentFolder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCurrentFolder_MouseMove);
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoToolTip = true;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 20);
            this.toolStripProgressBar1.Visible = false;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(this.btSetting);
            panel1.Controls.Add(this.btFilter);
            panel1.Controls.Add(this.btGetFilesToPrint);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(704, 47);
            panel1.TabIndex = 2;
            // 
            // btSetting
            // 
            this.btSetting.Image = global::CADPlot.Properties.Resources.set;
            this.btSetting.Location = new System.Drawing.Point(606, 4);
            this.btSetting.Name = "btSetting";
            this.btSetting.Size = new System.Drawing.Size(95, 40);
            this.btSetting.TabIndex = 2;
            this.btSetting.Text = "设置(&S)";
            this.btSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSetting.UseVisualStyleBackColor = true;
            this.btSetting.Click += new System.EventHandler(this.btSetting_Click);
            // 
            // btFilter
            // 
            this.btFilter.Image = global::CADPlot.Properties.Resources.filter;
            this.btFilter.Location = new System.Drawing.Point(99, 4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(90, 40);
            this.btFilter.TabIndex = 1;
            this.btFilter.Text = "筛选(&F)";
            this.btFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // btGetFilesToPrint
            // 
            this.btGetFilesToPrint.Image = global::CADPlot.Properties.Resources.add;
            this.btGetFilesToPrint.Location = new System.Drawing.Point(3, 4);
            this.btGetFilesToPrint.Name = "btGetFilesToPrint";
            this.btGetFilesToPrint.Size = new System.Drawing.Size(90, 40);
            this.btGetFilesToPrint.TabIndex = 0;
            this.btGetFilesToPrint.Text = "打开(&O)";
            this.btGetFilesToPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGetFilesToPrint.UseVisualStyleBackColor = true;
            this.btGetFilesToPrint.Click += new System.EventHandler(this.btGetFilesToPrint_Click);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.txtPrintSize);
            groupBox1.Controls.Add(this.txtPrinter);
            groupBox1.Controls.Add(this.checkBox1);
            groupBox1.Controls.Add(this.btPrint);
            groupBox1.Controls.Add(this.numericUpDown1);
            groupBox1.Controls.Add(this.label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(164, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(538, 82);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "打印设置";
            // 
            // txtPrintSize
            // 
            this.txtPrintSize.Location = new System.Drawing.Point(67, 51);
            this.txtPrintSize.Name = "txtPrintSize";
            this.txtPrintSize.ReadOnly = true;
            this.txtPrintSize.Size = new System.Drawing.Size(205, 21);
            this.txtPrintSize.TabIndex = 10;
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(67, 19);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.ReadOnly = true;
            this.txtPrinter.Size = new System.Drawing.Size(206, 21);
            this.txtPrinter.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(297, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "允许重复打印";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Image = global::CADPlot.Properties.Resources.printer;
            this.btPrint.Location = new System.Drawing.Point(418, 17);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(110, 55);
            this.btPrint.TabIndex = 6;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(351, 20);
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
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "打印份数：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 12);
            label2.TabIndex = 2;
            label2.Text = "图纸尺寸：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label1.Location = new System.Drawing.Point(8, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 12);
            label1.TabIndex = 0;
            label1.Text = "打印设备：";
            // 
            // panel2
            // 
            panel2.Controls.Add(this.groupBox2);
            panel2.Location = new System.Drawing.Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(161, 538);
            panel2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btOther);
            this.groupBox2.Controls.Add(this.btA34);
            this.groupBox2.Controls.Add(this.btA33);
            this.groupBox2.Controls.Add(this.btA44);
            this.groupBox2.Controls.Add(this.btA43);
            this.groupBox2.Controls.Add(this.btA0);
            this.groupBox2.Controls.Add(this.btA1);
            this.groupBox2.Controls.Add(this.btA2);
            this.groupBox2.Controls.Add(this.btA3);
            this.groupBox2.Controls.Add(this.btA4);
            this.groupBox2.Controls.Add(this.lstOptionList);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 538);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图幅选择";
            // 
            // btOther
            // 
            this.btOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.btOther.Location = new System.Drawing.Point(3, 341);
            this.btOther.Name = "btOther";
            this.btOther.Size = new System.Drawing.Size(155, 36);
            this.btOther.TabIndex = 21;
            this.btOther.Tag = "OTHER";
            this.btOther.Text = "A4(0|0)";
            this.btOther.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOther.UseVisualStyleBackColor = true;
            this.btOther.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA34
            // 
            this.btA34.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA34.Location = new System.Drawing.Point(3, 305);
            this.btA34.Name = "btA34";
            this.btA34.Size = new System.Drawing.Size(155, 36);
            this.btA34.TabIndex = 20;
            this.btA34.Tag = "A34";
            this.btA34.Text = "A4(0|0)";
            this.btA34.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA34.UseVisualStyleBackColor = true;
            this.btA34.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA33
            // 
            this.btA33.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA33.Location = new System.Drawing.Point(3, 269);
            this.btA33.Name = "btA33";
            this.btA33.Size = new System.Drawing.Size(155, 36);
            this.btA33.TabIndex = 19;
            this.btA33.Tag = "A33";
            this.btA33.Text = "A4(0|0)";
            this.btA33.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA33.UseVisualStyleBackColor = true;
            this.btA33.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA44
            // 
            this.btA44.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA44.Location = new System.Drawing.Point(3, 233);
            this.btA44.Name = "btA44";
            this.btA44.Size = new System.Drawing.Size(155, 36);
            this.btA44.TabIndex = 18;
            this.btA44.Tag = "A44";
            this.btA44.Text = "A4(0|0)";
            this.btA44.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA44.UseVisualStyleBackColor = true;
            this.btA44.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA43
            // 
            this.btA43.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA43.Location = new System.Drawing.Point(3, 197);
            this.btA43.Name = "btA43";
            this.btA43.Size = new System.Drawing.Size(155, 36);
            this.btA43.TabIndex = 17;
            this.btA43.Tag = "A43";
            this.btA43.Text = "A4(0|0)";
            this.btA43.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA43.UseVisualStyleBackColor = true;
            this.btA43.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA0
            // 
            this.btA0.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA0.Location = new System.Drawing.Point(3, 161);
            this.btA0.Name = "btA0";
            this.btA0.Size = new System.Drawing.Size(155, 36);
            this.btA0.TabIndex = 16;
            this.btA0.Tag = "A0";
            this.btA0.Text = "A4(0|0)";
            this.btA0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA0.UseVisualStyleBackColor = true;
            this.btA0.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA1
            // 
            this.btA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA1.Location = new System.Drawing.Point(3, 125);
            this.btA1.Name = "btA1";
            this.btA1.Size = new System.Drawing.Size(155, 36);
            this.btA1.TabIndex = 15;
            this.btA1.Tag = "A1";
            this.btA1.Text = "A4(0|0)";
            this.btA1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA1.UseVisualStyleBackColor = true;
            this.btA1.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA2
            // 
            this.btA2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA2.Location = new System.Drawing.Point(3, 89);
            this.btA2.Name = "btA2";
            this.btA2.Size = new System.Drawing.Size(155, 36);
            this.btA2.TabIndex = 14;
            this.btA2.Tag = "A2";
            this.btA2.Text = "A4(0|0)";
            this.btA2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA2.UseVisualStyleBackColor = true;
            this.btA2.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA3
            // 
            this.btA3.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA3.Location = new System.Drawing.Point(3, 53);
            this.btA3.Name = "btA3";
            this.btA3.Size = new System.Drawing.Size(155, 36);
            this.btA3.TabIndex = 13;
            this.btA3.Tag = "A3";
            this.btA3.Text = "A4(0|0)";
            this.btA3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA3.UseVisualStyleBackColor = true;
            this.btA3.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // btA4
            // 
            this.btA4.Dock = System.Windows.Forms.DockStyle.Top;
            this.btA4.Location = new System.Drawing.Point(3, 17);
            this.btA4.Name = "btA4";
            this.btA4.Size = new System.Drawing.Size(155, 36);
            this.btA4.TabIndex = 12;
            this.btA4.Tag = "A4";
            this.btA4.Text = "A4(0|0)";
            this.btA4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btA4.UseVisualStyleBackColor = true;
            this.btA4.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // lstOptionList
            // 
            this.lstOptionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOptionList.FormattingEnabled = true;
            this.lstOptionList.ItemHeight = 12;
            this.lstOptionList.Location = new System.Drawing.Point(6, 383);
            this.lstOptionList.Name = "lstOptionList";
            this.lstOptionList.Size = new System.Drawing.Size(149, 148);
            this.lstOptionList.TabIndex = 11;
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
            this.lvDataView.Location = new System.Drawing.Point(166, 142);
            this.lvDataView.Name = "lvDataView";
            this.lvDataView.Size = new System.Drawing.Size(534, 449);
            this.lvDataView.TabIndex = 11;
            this.lvDataView.TileSize = new System.Drawing.Size(150, 80);
            this.lvDataView.UseCompatibleStateImageBehavior = false;
            this.lvDataView.View = System.Windows.Forms.View.Details;
            this.lvDataView.DoubleClick += new System.EventHandler(this.lvDataView_DoubleClick);
            // 
            // frmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 618);
            this.Controls.Add(this.lvDataView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(panel2);
            this.Controls.Add(groupBox1);
            this.Controls.Add(panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShow";
            this.Text = "CAD批量打印";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.Button btGetFilesToPrint;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentFolder;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblForA4;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.FolderBrowserDialog fbdOpen;
        private System.Windows.Forms.Button btSetting;
        private System.Windows.Forms.TextBox txtPrintSize;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btOther;
        private System.Windows.Forms.Button btA34;
        private System.Windows.Forms.Button btA33;
        private System.Windows.Forms.Button btA44;
        private System.Windows.Forms.Button btA43;
        private System.Windows.Forms.Button btA0;
        private System.Windows.Forms.Button btA1;
        private System.Windows.Forms.Button btA2;
        private System.Windows.Forms.Button btA3;
        private System.Windows.Forms.Button btA4;
        private System.Windows.Forms.ListBox lstOptionList;
        private System.Windows.Forms.ListView lvDataView;
    }
}