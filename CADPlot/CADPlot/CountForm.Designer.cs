namespace CADPlot
{
    partial class CountForm
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
            this.lsvShowCountDate = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvShowCountDate
            // 
            this.lsvShowCountDate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvShowCountDate.Location = new System.Drawing.Point(9, 10);
            this.lsvShowCountDate.Name = "lsvShowCountDate";
            this.lsvShowCountDate.Size = new System.Drawing.Size(271, 195);
            this.lsvShowCountDate.TabIndex = 0;
            this.lsvShowCountDate.UseCompatibleStateImageBehavior = false;
            this.lsvShowCountDate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图幅";
            this.columnHeader1.Width = 67;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "自然张数";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "折合A4";
            this.columnHeader3.Width = 78;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(106, 211);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(73, 29);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // CountForm
            // 
            this.AcceptButton = this.btClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(288, 244);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lsvShowCountDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图纸打印数量统计";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvShowCountDate;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btClose;
    }
}