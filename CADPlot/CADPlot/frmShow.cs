using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CADPlot.Moudle;

namespace CADPlot
{
    public partial class frmShow : Form
    {
        public delegate void FilterOrPrintPaperDelegate();

        private static readonly Dictionary<string, string> PaperDictionary = new Dictionary<string, string>
        {
            {"ALL", "所有图纸"},
            {"A4", "A4"},
            {"A3", "A3"},
            {"A2", "A2"},
            {"A1", "A1"},
            {"A0", "A0"},
            {"A43", "A4×3"},
            {"A44", "A4×4"},
            {"A33", "A3×3"},
            {"A34", "A3×4"},
            {"OTHER", "未知图幅"},
        };

        private readonly CadPaperToPrint cadPapersToPrint = new CadPaperToPrint();

        private bool IsBusy;

        private string _currentFormatName = "";
        private CadPapers currentPapers;

        public frmShow()
        {
            InitializeComponent();
            SetDataViewFormat();
            Initialize();

            cadPapersToPrint.PlotingEvent += OnPlotingEvent;
        }

        private void SetDataViewFormat()
        {
            #region

            //dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            //dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            //dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            // 
            // dgPaperList
            // 
            //dgPaperList.AllowUserToAddRows = false;
            //dgPaperList.AllowUserToDeleteRows = false;
            //dgPaperList.Anchor =
            //    ((AnchorStyles.Top | AnchorStyles.Bottom)
            //     | AnchorStyles.Left)
            //    | AnchorStyles.Right;
            //dgPaperList.AutoGenerateColumns = false;
            //dgPaperList.BorderStyle = BorderStyle.Fixed3D;
            //var dataGridViewCellStyle1 = new DataGridViewCellStyle
            //{
            //    Alignment = DataGridViewContentAlignment.MiddleCenter,
            //    BackColor = SystemColors.Control,
            //    Font =
            //        new Font("宋体", 9F, FontStyle.Regular,
            //            GraphicsUnit.Point, 134),
            //    ForeColor = SystemColors.WindowText,
            //    SelectionBackColor = SystemColors.Highlight,
            //    SelectionForeColor = SystemColors.HighlightText,
            //    WrapMode = DataGridViewTriState.False
            //};
            //dgPaperList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            //dgPaperList.ColumnHeadersHeightSizeMode =
            //    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dgPaperList.Columns.AddRange(new DataGridViewColumn[]
            //{
            //    dataGridViewCheckBoxColumn1,
            //    dataGridViewTextBoxColumn2,
            //    dataGridViewTextBoxColumn3,
            //    dataGridViewTextBoxColumn4,
            //    dataGridViewTextBoxColumn5,
            //    dataGridViewTextBoxColumn6,
            //    dataGridViewTextBoxColumn7,
            //    dataGridViewTextBoxColumn8,
            //    dataGridViewTextBoxColumn9,
            //    dataGridViewTextBoxColumn10,
            //    dataGridViewTextBoxColumn11,
            //    dataGridViewTextBoxColumn1,
            //    dataGridViewTextBoxColumn12
            //});
            //this.dgPaperList.DataSource = this.cadPapersBindingSource;
            //dgPaperList.Location = new Point(164, 142);
            //dgPaperList.Name = "dgPaperList";
            //dgPaperList.ReadOnly = true;
            //dgPaperList.RowHeadersWidth = 20;
            //dgPaperList.RowHeadersWidthSizeMode =
            //    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //dgPaperList.RowTemplate.Height = 23;
            //dgPaperList.RowTemplate.ReadOnly = true;
            //dgPaperList.RowTemplate.Resizable = DataGridViewTriState.False;
            //dgPaperList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgPaperList.Size = new Size(538, 450);
            //dgPaperList.TabIndex = 9;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            //dataGridViewCheckBoxColumn1.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewCheckBoxColumn1.DataPropertyName = "IsPrinted";
            //dataGridViewCheckBoxColumn1.HeaderText = @"已打印";
            //dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            //dataGridViewCheckBoxColumn1.ReadOnly = true;
            //dataGridViewCheckBoxColumn1.Width = 47;

            // dataGridViewTextBoxColumn2

            //dataGridViewTextBoxColumn2.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn2.DataPropertyName = "FormatName";
            //dataGridViewTextBoxColumn2.HeaderText = @"图幅";
            //dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            //dataGridViewTextBoxColumn2.ReadOnly = true;
            //dataGridViewTextBoxColumn2.Width = 54;

            // dataGridViewTextBoxColumn3

            //dataGridViewTextBoxColumn3.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridViewTextBoxColumn3.DataPropertyName = "FileShortName";
            //dataGridViewTextBoxColumn3.HeaderText = @"文件名";
            //dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            //dataGridViewTextBoxColumn3.ReadOnly = true;
            //dataGridViewTextBoxColumn3.Width = 66;

            // dataGridViewTextBoxColumn4

            //dataGridViewTextBoxColumn4.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn4.DataPropertyName = "Scale";
            //dataGridViewTextBoxColumn4.HeaderText = @"比例";
            //dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            //dataGridViewTextBoxColumn4.ReadOnly = true;
            //dataGridViewTextBoxColumn4.Width = 54;

            // dataGridViewTextBoxColumn5

            //dataGridViewTextBoxColumn5.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn5.DataPropertyName = "Angle";
            //dataGridViewTextBoxColumn5.HeaderText = @"角度";
            //dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            //dataGridViewTextBoxColumn5.ReadOnly = true;
            //dataGridViewTextBoxColumn5.Width = 54;

            // dataGridViewTextBoxColumn6

            //dataGridViewTextBoxColumn6.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn6.DataPropertyName = "PrintedNum";
            //dataGridViewTextBoxColumn6.HeaderText = @"打印数量";
            //dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            //dataGridViewTextBoxColumn6.ReadOnly = true;
            //dataGridViewTextBoxColumn6.Width = 78;

            // dataGridViewTextBoxColumn7

            //dataGridViewTextBoxColumn7.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn7.DataPropertyName = "Width";
            //dataGridViewTextBoxColumn7.HeaderText = @"宽度";
            //dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            //dataGridViewTextBoxColumn7.ReadOnly = true;
            //dataGridViewTextBoxColumn7.Width = 54;

            // dataGridViewTextBoxColumn8

            //dataGridViewTextBoxColumn8.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn8.DataPropertyName = "Height";
            //dataGridViewTextBoxColumn8.HeaderText = @"高度";
            //dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            //dataGridViewTextBoxColumn8.ReadOnly = true;
            //dataGridViewTextBoxColumn8.Width = 54;

            // dataGridViewTextBoxColumn9

            //dataGridViewTextBoxColumn9.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dataGridViewTextBoxColumn9.DataPropertyName = "ForA4";
            //dataGridViewTextBoxColumn9.HeaderText = @"折合A4";
            //dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            //dataGridViewTextBoxColumn9.ReadOnly = true;
            //dataGridViewTextBoxColumn9.Width = 66;

            // dataGridViewTextBoxColumn10

            //dataGridViewTextBoxColumn10.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridViewTextBoxColumn10.DataPropertyName = "PlotConfigName";
            //dataGridViewTextBoxColumn10.HeaderText = @"打印机";
            //dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            //dataGridViewTextBoxColumn10.ReadOnly = true;
            //dataGridViewTextBoxColumn10.Width = 66;

            // dataGridViewTextBoxColumn11

            //dataGridViewTextBoxColumn11.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridViewTextBoxColumn11.DataPropertyName = "CanonicalMediaName";
            //dataGridViewTextBoxColumn11.HeaderText = @"图纸尺寸";
            //dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            //dataGridViewTextBoxColumn11.ReadOnly = true;
            //dataGridViewTextBoxColumn11.Width = 78;

            // dataGridViewTextBoxColumn1

            //dataGridViewTextBoxColumn1.DataPropertyName = "FileFullName";
            //dataGridViewTextBoxColumn1.HeaderText = @"文件路径";
            //dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            //dataGridViewTextBoxColumn1.ReadOnly = true;

            // dataGridViewTextBoxColumn12

            //dataGridViewTextBoxColumn12.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridViewTextBoxColumn12.DataPropertyName = "StyleSheet";
            //dataGridViewTextBoxColumn12.HeaderText = @"打印样式";
            //dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            //dataGridViewTextBoxColumn12.ReadOnly = true;
            //dataGridViewTextBoxColumn12.Width = 78;

            #endregion

            lvDataView.Columns.AddRange(new[]
            {
                new ColumnHeader
                {
                    Name = "isprinted",
                    Text = @"序号",
                    Width = 40,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "name",
                    Text = @"文件名",
                    Width = 120
                },
                new ColumnHeader
                {
                    Name = "tufu",
                    Text = @"图幅",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "dysl",
                    Text = @"已打印",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "jiaodu",
                    Text = @"角度",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "bili",
                    Text = @"比例",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "kuandu",
                    Text = @"宽度",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "gaodu",
                    Text = @"高度",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "wenjianlujing",
                    Text = @"文件路径",
                    Width = 180
                },
                new ColumnHeader
                {
                    Name = "dayinji",
                    Text = @"打印机",
                    Width = 100
                },
                new ColumnHeader
                {
                    Name = "dayinchicun",
                    Text = @"打印尺寸",
                    Width = 60,
                    TextAlign = HorizontalAlignment.Center
                },
                new ColumnHeader
                {
                    Name = "dayinyangshi",
                    Text = @"打印样式",
                    Width = 100,
                    TextAlign = HorizontalAlignment.Center
                }
            });
        }

        //是否已打印，1文件名，2图幅，3已打印，4角度，5比例，6宽度，7高度，8文件路径，9打印机，10打印尺寸，11打印样式
        private void AddDataToListView(IEnumerable<CadPaper> cadPapers)
        {
            lvDataView.Items.Clear();
            int i = 1;
            foreach (CadPaper paper in cadPapers)
            {
                ListViewItem item = lvDataView.Items.Add(string.Format("{0}{1}", paper.IsPrinted ? "*" : "", i));
                item.SubItems.AddRange(new[]
                {
                    paper.FileShortName, paper.FormatName, paper.PrintedNum.ToString(), paper.Angle.ToString(),
                    paper.Scale.ToString(), paper.Width.ToString(), paper.Height.ToString(), paper.FileFullName,
                    paper.PlotConfigName, paper.CanonicalMediaName, paper.StyleSheet
                });
                i++;
            }
        }

        public void OnPlotingEvent(object sender, CadPapers.CadPaperProgressEventArgs args)
        {
            CadPaper paper = args.CurrentPaper;
            switch (args.SenderMethod)
            {
                case CadPapers.CadPaperProgressEventSender.check: //筛选文件
                {
                    ListViewItem item = lvDataView.Items[args.CurrentPoint - 1];
                    if (item.SubItems[(int) DataViewColumn.文件名].Text == paper.FileShortName)
                    {
                        item.SubItems[(int) DataViewColumn.图幅].Text = paper.FormatName;
                        item.SubItems[(int) DataViewColumn.已打印].Text = paper.PrintedNum.ToString();
                        item.SubItems[(int) DataViewColumn.角度].Text = paper.Angle.ToString();
                        item.SubItems[(int) DataViewColumn.比例].Text = paper.Scale.ToString();
                        item.SubItems[(int) DataViewColumn.宽度].Text = paper.Width.ToString();
                        item.SubItems[(int) DataViewColumn.高度].Text = paper.Height.ToString();
                        item.SubItems[(int) DataViewColumn.打印机].Text = paper.PlotConfigName;
                        item.SubItems[(int) DataViewColumn.打印尺寸].Text = paper.CanonicalMediaName;
                        item.SubItems[(int) DataViewColumn.打印样式].Text = paper.StyleSheet;
                    }
                    break;
                }
                case CadPapers.CadPaperProgressEventSender.plot:
                {
                    //var item = lvDataView.Items.Find(paper.FileShortName, false);
                    //item[0].Text = @"*";
                    ListViewItem item = lvDataView.Items[args.CurrentPoint - 1];
                    if (item.SubItems[(int) DataViewColumn.文件名].Text == paper.FileShortName)
                    {
                        item.SubItems[(int) DataViewColumn.是否已打印].Text = string.Format("{0}{1}", "*",
                            item.SubItems[0].Text);
                        item.SubItems[(int) DataViewColumn.已打印].Text = paper.PrintedNum.ToString();
                    }
                    break;
                }
            }

            if (args.CurrentPoint < args.Count)
            {
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Maximum = args.Count;
                toolStripProgressBar1.Value = args.CurrentPoint;
            }
            else
                toolStripProgressBar1.Visible = false;
            //dgPaperList.Refresh();
        }

        private void Initialize()
        {
            btA0.Text = PaperDictionary["A0"];
            btA1.Text = PaperDictionary["A1"];
            btA2.Text = PaperDictionary["A2"];
            btA3.Text = PaperDictionary["A3"];
            btA4.Text = PaperDictionary["A4"];
            btA43.Text = PaperDictionary["A43"];
            btA44.Text = PaperDictionary["A44"];
            btA33.Text = PaperDictionary["A33"];
            btA34.Text = PaperDictionary["A34"];
            btOther.Text = PaperDictionary["OTHER"];

            btA0.Enabled = false;
            btA1.Enabled = false;
            btA2.Enabled = false;
            btA3.Enabled = false;
            btA4.Enabled = false;
            btA43.Enabled = false;
            btA44.Enabled = false;
            btA33.Enabled = false;
            btA34.Enabled = false;
            btOther.Enabled = false;

            lblCurrentFolder.Text = @"文件夹:";
            lblTotal.Text = @"自然张数:0";
            lblForA4.Text = @"折合A4:0";

            btPrint.Enabled = false;
            statusStrip1.Items.Add(lblCurrentFolder);
            statusStrip1.Items.Add(lblTotal);
            statusStrip1.Items.Add(lblForA4);
            statusStrip1.Items.Add(toolStripProgressBar1);
        }

        private void btGetFilesToPrint_Click(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (fbdOpen.ShowDialog() != DialogResult.OK) return;
                if (fbdOpen.SelectedPath == null) return;
                cadPapersToPrint.RootPath = fbdOpen.SelectedPath;
                cadPapersToPrint.GetPaperToPrintList();

                //dgPaperList.DataSource = _cadPapersToPrint;
                AddDataToListView(cadPapersToPrint);

                Initialize();
                lblCurrentFolder.Text = string.Format("文件夹：{0}", fbdOpen.SelectedPath);
                lblTotal.Text = string.Format("自然张数：{0}", cadPapersToPrint.NatureCount);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("程序运行发生错误\n错误描述:{0}", exception.Message));
            }
        }

        private void OptionButtonClick(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (IsBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btPrint.Enabled = true;
            switch (((Button) sender).Name)
            {
                case "ALL":
                    currentPapers = cadPapersToPrint;

                    break;
                case "btA4":
                    currentPapers = cadPapersToPrint.A4S;
                    _currentFormatName = "A4";
                    break;
                case "btA3":
                    currentPapers = cadPapersToPrint.A3S;
                    _currentFormatName = "A3";
                    break;
                case "btA2":
                    currentPapers = cadPapersToPrint.A2S;
                    _currentFormatName = "A2";
                    break;
                case "btA1":
                    currentPapers = cadPapersToPrint.A1S;
                    _currentFormatName = "A1";
                    break;
                case "btA0":
                    currentPapers = cadPapersToPrint.A0S;
                    _currentFormatName = "A0";
                    break;
                case "btA43":
                    currentPapers = cadPapersToPrint.A43S;
                    _currentFormatName = "A43";
                    break;
                case "btA44":
                    currentPapers = cadPapersToPrint.A44S;
                    _currentFormatName = "A44";
                    break;
                case "btA33":
                    currentPapers = cadPapersToPrint.A33S;
                    _currentFormatName = "A33";
                    break;
                case "btA34":
                    currentPapers = cadPapersToPrint.A34S;
                    _currentFormatName = "A34";
                    break;
                case "btOther":
                    currentPapers = cadPapersToPrint.OtherSizePapers;
                    _currentFormatName = "OTHER";
                    btPrint.Enabled = false;
                    break;
            }
            //dgPaperList.DataSource = currentPapers;
            AddDataToListView(currentPapers);

            txtPrinter.Text = AppConfig.CadPapreConfigDictionary[_currentFormatName].Printer;
            txtPrintSize.Text = AppConfig.CadPapreConfigDictionary[_currentFormatName].LocaleMediaName;
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            //Thread filter = new Thread(_cadPapersToPrint.CheckPaperSize);
            //filter.Start();
            if (IsBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cadPapersToPrint.Count == 0)
            {
                MessageBox.Show(@"需要先打开文件夹，然后再筛选！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IsBusy = true;

            cadPapersToPrint.CheckPaperSize();

            lstOptionList.Items.Clear();
            if (cadPapersToPrint.A4S.Count > 0)
            {
                btA4.Text = string.Format("{0}({1}|{2})", PaperDictionary["A4"], cadPapersToPrint.A4S.Count,
                    cadPapersToPrint.A4S.ForA4Count);
                btA4.Enabled = true;
            }
            if (cadPapersToPrint.A3S.Count > 0)
            {
                btA3.Text = string.Format("{0}({1}|{2})", PaperDictionary["A3"], cadPapersToPrint.A3S.Count,
                    cadPapersToPrint.A3S.ForA4Count);
                btA3.Enabled = true;
            }
            if (cadPapersToPrint.A2S.Count > 0)
            {
                btA2.Text = string.Format("{0}({1}|{2})", PaperDictionary["A2"], cadPapersToPrint.A2S.Count,
                    cadPapersToPrint.A2S.ForA4Count);
                btA2.Enabled = true;
            }
            if (cadPapersToPrint.A1S.Count > 0)
            {
                btA1.Text = string.Format("{0}({1}|{2})", PaperDictionary["A1"], cadPapersToPrint.A1S.Count,
                    cadPapersToPrint.A1S.ForA4Count);
                btA1.Enabled = true;
            }
            if (cadPapersToPrint.A0S.Count > 0)
            {
                btA0.Text = string.Format("{0}({1}|{2})", PaperDictionary["A0"], cadPapersToPrint.A0S.Count,
                    cadPapersToPrint.A0S.ForA4Count);
                btA0.Enabled = true;
            }
            if (cadPapersToPrint.A43S.Count > 0)
            {
                btA43.Text = string.Format("{0}({1}|{2})", PaperDictionary["A43"], cadPapersToPrint.A43S.Count,
                    cadPapersToPrint.A43S.ForA4Count);
                btA43.Enabled = true;
            }
            if (cadPapersToPrint.A44S.Count > 0)
            {
                btA44.Text = string.Format("{0}({1}|{2})", PaperDictionary["A44"], cadPapersToPrint.A44S.Count,
                    cadPapersToPrint.A44S.ForA4Count);
                btA44.Enabled = true;
            }
            if (cadPapersToPrint.A33S.Count > 0)
            {
                btA33.Text = string.Format("{0}({1}|{2})", PaperDictionary["A33"], cadPapersToPrint.A33S.Count,
                    cadPapersToPrint.A0S.ForA4Count);
                btA33.Enabled = true;
            }
            if (cadPapersToPrint.A34S.Count > 0)
            {
                btA34.Text = string.Format("{0}({1}|{2})", PaperDictionary["A34"], cadPapersToPrint.A34S.Count,
                    cadPapersToPrint.A0S.ForA4Count);
                btA34.Enabled = true;
            }
            if (cadPapersToPrint.OtherSizePapers.Count > 0)
            {
                btOther.Text = string.Format("{0}({1})", PaperDictionary["OTHER"],
                    cadPapersToPrint.OtherSizePapers.Count);
                btOther.Enabled = true;
            }

            lblForA4.Text = string.Format("折合A4：{0}", cadPapersToPrint.ForA4Count);

            MessageBox.Show(@"所有图纸已经筛选完成", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsBusy = false;
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new OptionsDialog();
            f.ShowDialog();

            if (AppConfig.CadPapreConfigDictionary.ContainsKey(_currentFormatName))
            {
                txtPrinter.Text = AppConfig.CadPapreConfigDictionary[_currentFormatName].Printer;
                txtPrintSize.Text = AppConfig.CadPapreConfigDictionary[_currentFormatName].CanonicalMediaName;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            IsBusy = true;
            currentPapers.PlotingEvent += OnPlotingEvent;
            currentPapers.Plot();
            IsBusy = false;
        }

        private void lvDataView_DoubleClick(object sender, EventArgs e)
        {
            if (lvDataView.SelectedItems.Count > 0)
            {
                CadPaper.Open(lvDataView.SelectedItems[0].SubItems[(int) DataViewColumn.文件路径].Text);
            }
        }

        private enum DataViewColumn
        {
            是否已打印 = 0,
            文件名 = 1,
            图幅 = 2,
            已打印 = 3,
            角度 = 4,
            比例 = 5,
            宽度 = 6,
            高度 = 7,
            文件路径 = 8,
            打印机 = 9,
            打印尺寸 = 10,
            打印样式 = 11
        }

        private void lblCurrentFolder_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}