using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CADPlot.Moudle;

namespace CADPlot
{
    public delegate void UpdateUIAttrib();

    public partial class frmShow : Form
    {
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

        private readonly CadPaperForPrinting _cadPapersForPrinting = new CadPaperForPrinting();
        private bool _hasFillter;
        private bool _isBusy;
        private string _currentMapSheet = "";
        private CadPapers _currentPapers;

        public frmShow()
        {
            InitializeComponent();
            SetDataViewFormat();
            Initialize();

            _cadPapersForPrinting.CadPaperProgress += OnCadPaperProgress;
            menuDelSelected.Click += menuDelSelected_Click;
            menuPrintSelected.Click += menuPrintSelected_Click;
        }

        private void Initialize()
        {
            btA0.Text = CadPaper.PaperNameDictionary["A0"];
            btA1.Text = CadPaper.PaperNameDictionary["A1"];
            btA2.Text = CadPaper.PaperNameDictionary["A2"];
            btA3.Text = CadPaper.PaperNameDictionary["A3"];
            btA4.Text = CadPaper.PaperNameDictionary["A4"];
            btA43.Text = CadPaper.PaperNameDictionary["A43"];
            btA44.Text = CadPaper.PaperNameDictionary["A44"];
            btA33.Text = CadPaper.PaperNameDictionary["A33"];
            btA34.Text = CadPaper.PaperNameDictionary["A34"];
            btOther.Text = CadPaper.PaperNameDictionary["OTHER"];

            SetControlEnable(false);
            tbAdd.Enabled = true;

            lblCurrentFolder.Text = @"文件夹:";
            lblTotal.Text = @"自然张数:0";
            lblForA4.Text = @"折合A4:0";

            statusStrip1.Items.Add(lblCurrentFolder);
            statusStrip1.Items.Add(lblTotal);
            statusStrip1.Items.Add(lblForA4);
            statusStrip1.Items.Add(toolStripProgressBar1);

            _hasFillter = false;
        }

        private void lvDataView_DoubleClick(object sender, EventArgs e)
        {
            if (lvDataView.SelectedItems.Count > 0)
            {
                CadPaper.Open(lvDataView.SelectedItems[0].SubItems[(int) DataViewColumn.文件路径].Text);
            }
        }

        private void lvDataView_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isBusy) return;
            if (e.Button == MouseButtons.Right)
                lvDataView.ContextMenuStrip = contextMenuStrip1;
        }

        private void menuPrintSelected_Click(object sender, EventArgs e)
        {
            if (_isBusy || !_hasFillter) return;
            CadPapers selectedPapers = GetCurrentSelectedCadPapers();
            if (selectedPapers != null)
            {
                _isBusy = true;
                selectedPapers.CadPaperProgress += OnCadPaperProgress;
                selectedPapers.Plot();
            }
        }

        private void menuDelSelected_Click(object sender, EventArgs e)
        {
            if (_isBusy) return;
            CadPapers selectedPapers = GetCurrentSelectedCadPapers();
            if (selectedPapers != null)
            {
                foreach (CadPaper selectedPaper in selectedPapers)
                {
                    _cadPapersForPrinting.Remove(selectedPaper);
                }
                AddDataToListView(_cadPapersForPrinting);
            }
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (fbdOpen.ShowDialog() != DialogResult.OK) return;
                if (fbdOpen.SelectedPath == null) return;
                _cadPapersForPrinting.RootPath = fbdOpen.SelectedPath;
                _cadPapersForPrinting.ReadFilesForPrinting();

                AddDataToListView(_cadPapersForPrinting);

                Initialize();

                lblCurrentFolder.Text = string.Format("文件夹：{0}", fbdOpen.SelectedPath);
                lblTotal.Text = string.Format("自然张数：{0}", _cadPapersForPrinting.NatureCount);
                tbFilter.Enabled = _cadPapersForPrinting.NatureCount>0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("程序运行发生错误\n错误描述:{0}", exception.Message));
            }
        }

        private void tbFilter_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_cadPapersForPrinting.Count == 0)
            {
                MessageBox.Show(@"需要先打开文件夹，然后再筛选！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetControlEnable(false);

            Thread screenThread = new Thread(_cadPapersForPrinting.Screen);
            screenThread.Start();
        }

        private void OnMapSheetClick(object sender, EventArgs e)
        {
            if (sender == null || _cadPapersForPrinting == null) return;
            if (_isBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btPrint.Enabled = true;
            tbPrint.Enabled = true;
            switch (((ToolStripDropDownItem) sender).Name)
            {
                case "btAll":
                    _currentPapers = _cadPapersForPrinting;
                    btPrint.Enabled = false;
                    tbPrint.Enabled = false;
                    _currentMapSheet = "All";
                    break;
                case "btA4":
                    _currentPapers = _cadPapersForPrinting.A4S;
                    _currentMapSheet = "A4";
                    break;
                case "btA3":
                    _currentPapers = _cadPapersForPrinting.A3S;
                    _currentMapSheet = "A3";
                    break;
                case "btA2":
                    _currentPapers = _cadPapersForPrinting.A2S;
                    _currentMapSheet = "A2";
                    break;
                case "btA1":
                    _currentPapers = _cadPapersForPrinting.A1S;
                    _currentMapSheet = "A1";
                    break;
                case "btA0":
                    _currentPapers = _cadPapersForPrinting.A0S;
                    _currentMapSheet = "A0";
                    break;
                case "btA43":
                    _currentPapers = _cadPapersForPrinting.A43S;
                    _currentMapSheet = "A43";
                    break;
                case "btA44":
                    _currentPapers = _cadPapersForPrinting.A44S;
                    _currentMapSheet = "A44";
                    break;
                case "btA33":
                    _currentPapers = _cadPapersForPrinting.A33S;
                    _currentMapSheet = "A33";
                    break;
                case "btA34":
                    _currentPapers = _cadPapersForPrinting.A34S;
                    _currentMapSheet = "A34";
                    break;
                case "btOther":
                    _currentPapers = _cadPapersForPrinting.OtherSizePapers;
                    _currentMapSheet = "OTHER";
                    btPrint.Enabled = false;
                    tbPrint.Enabled = false;
                    break;

            }

            AddDataToListView(_currentPapers);

            if (AppConfig.CadPapreConfigDictionary.ContainsKey(_currentMapSheet))
            {
                txtPrinter.Text = AppConfig.CadPapreConfigDictionary[_currentMapSheet].Printer;
                txtPrintSize.Text = AppConfig.CadPapreConfigDictionary[_currentMapSheet].LocaleMediaName;
            }
        }

        private void tbSetting_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show(@"打印机正在工作，请稍后再重试！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new OptionsDialog();
            f.ShowDialog();

            if (AppConfig.CadPapreConfigDictionary.ContainsKey(_currentMapSheet))
            {
                txtPrinter.Text = AppConfig.CadPapreConfigDictionary[_currentMapSheet].Printer;
                txtPrintSize.Text = AppConfig.CadPapreConfigDictionary[_currentMapSheet].CanonicalMediaName;
            }
        }

        private void OnPrint_Click(object sender, EventArgs e)
        {
            if (_isBusy || _currentPapers == null) return;
            //if (currentPapers == null) return;
            _isBusy = true;
            _currentPapers.CadPaperProgress += OnCadPaperProgress;
            _currentPapers.Plot();
        }

        /// <summary>
        /// 设置ListView控件显示格式
        /// </summary>
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

        private void CompleteScreen()
        {
            #region 设置图幅菜单属性

            //if (_cadPapersForPrinting.A4S.Count > 0)
            //{
            //    btA4.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A4"],
            //        _cadPapersForPrinting.A4S.Count,
            //        _cadPapersForPrinting.A4S.ForA4Count);
            //    btA4.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A3S.Count > 0)
            //{
            //    btA3.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A3"],
            //        _cadPapersForPrinting.A3S.Count,
            //        _cadPapersForPrinting.A3S.ForA4Count);
            //    btA3.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A2S.Count > 0)
            //{
            //    btA2.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A2"],
            //        _cadPapersForPrinting.A2S.Count,
            //        _cadPapersForPrinting.A2S.ForA4Count);
            //    btA2.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A1S.Count > 0)
            //{
            //    btA1.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A1"],
            //        _cadPapersForPrinting.A1S.Count,
            //        _cadPapersForPrinting.A1S.ForA4Count);
            //    btA1.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A0S.Count > 0)
            //{
            //    btA0.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A0"],
            //        _cadPapersForPrinting.A0S.Count,
            //        _cadPapersForPrinting.A0S.ForA4Count);
            //    btA0.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A43S.Count > 0)
            //{
            //    btA43.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A43"],
            //        _cadPapersForPrinting.A43S.Count,
            //        _cadPapersForPrinting.A43S.ForA4Count);
            //    btA43.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A44S.Count > 0)
            //{
            //    btA44.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A44"],
            //        _cadPapersForPrinting.A44S.Count,
            //        _cadPapersForPrinting.A44S.ForA4Count);
            //    btA44.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A33S.Count > 0)
            //{
            //    btA33.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A33"],
            //        _cadPapersForPrinting.A33S.Count,
            //        _cadPapersForPrinting.A0S.ForA4Count);
            //    btA33.Enabled = true;
            //}
            //if (_cadPapersForPrinting.A34S.Count > 0)
            //{
            //    btA34.Text = string.Format("{0}({1}|{2})", CadPaper.PaperNameDictionary["A34"],
            //        _cadPapersForPrinting.A34S.Count,
            //        _cadPapersForPrinting.A0S.ForA4Count);
            //    btA34.Enabled = true;
            //}
            //if (_cadPapersForPrinting.OtherSizePapers.Count > 0)
            //{
            //    btOther.Text = string.Format("{0}({1})", CadPaper.PaperNameDictionary["OTHER"],
            //        _cadPapersForPrinting.OtherSizePapers.Count);
            //    btOther.Enabled = true;
            //}

            #endregion

            btA0.Enabled = _cadPapersForPrinting.A0S.Count>0;
            btA1.Enabled = _cadPapersForPrinting.A1S.Count>0;
            btA2.Enabled = _cadPapersForPrinting.A2S.Count>0;
            btA3.Enabled = _cadPapersForPrinting.A3S.Count>0;
            btA4.Enabled = _cadPapersForPrinting.A4S.Count>0;
            btA43.Enabled = _cadPapersForPrinting.A43S.Count>0;
            btA44.Enabled = _cadPapersForPrinting.A44S.Count>0;
            btA33.Enabled = _cadPapersForPrinting.A33S.Count>0;
            btA34.Enabled = _cadPapersForPrinting.A33S.Count>0;
            btOther.Enabled = _cadPapersForPrinting.OtherSizePapers.Count>0;

            lblForA4.Text = string.Format("折合A4：{0}", _cadPapersForPrinting.ForA4Count);

            MessageBox.Show(@"所有图纸已经筛选完成", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbAdd.Enabled = true;
            tbFilter.Enabled = true;
            tbMapSheet.Enabled = true;
            btPrint.Enabled = true;
            tbPrint.Enabled = true;
            _isBusy = false;
            _hasFillter = true;
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
                    paper.FileShortName, paper.MapSheet, paper.PrintedNum.ToString(), paper.Angle.ToString(),
                    paper.Scale.ToString(), paper.Width.ToString(), paper.Height.ToString(), paper.FileFullName,
                    paper.PlotConfigName, paper.CanonicalMediaName, paper.StyleSheet
                });
                i++;
            }
        }

        private void OnCadPaperProgress(CadPaperProgressEventArgs args)
        {
            Invoke(new CadPaperProgressEventHandler(UpdateUI), args);
        }

        private void UpdateUI(object invokeArgs)
        {
            CadPaperProgressEventArgs args = (CadPaperProgressEventArgs) invokeArgs;
            CadPaper paper = args.CurrentPaper;
            switch (args.SenderMethod)
            {
                case CadPaperProgressSender.筛选:
                {
                    ListViewItem item = lvDataView.Items[args.CurrentPoint - 1];
                    if (item.SubItems[(int) DataViewColumn.文件名].Text == paper.FileShortName)
                    {
                        item.SubItems[(int) DataViewColumn.图幅].Text = paper.MapSheet;
                        item.SubItems[(int) DataViewColumn.已打印].Text =
                            paper.PrintedNum.ToString(CultureInfo.InvariantCulture);
                        item.SubItems[(int) DataViewColumn.角度].Text = paper.Angle.ToString(CultureInfo.InvariantCulture);
                        item.SubItems[(int) DataViewColumn.比例].Text = paper.Scale.ToString(CultureInfo.InvariantCulture);
                        item.SubItems[(int) DataViewColumn.宽度].Text = paper.Width.ToString(CultureInfo.InvariantCulture);
                        item.SubItems[(int) DataViewColumn.高度].Text = paper.Height.ToString(CultureInfo.InvariantCulture);
                        item.SubItems[(int) DataViewColumn.打印机].Text = paper.PlotConfigName;
                        item.SubItems[(int) DataViewColumn.打印尺寸].Text = paper.CanonicalMediaName;
                        item.SubItems[(int) DataViewColumn.打印样式].Text = paper.StyleSheet;
                    }
                    break;
                }
                case CadPaperProgressSender.打印:
                {
                    ListViewItem item = lvDataView.Items[args.CurrentPoint - 1];
                    if (item.SubItems[(int) DataViewColumn.文件名].Text == paper.FileShortName)
                    {
                        item.SubItems[(int) DataViewColumn.是否已打印].Text = string.Format("{0}{1}", "*",
                            item.SubItems[0].Text);
                        item.SubItems[(int) DataViewColumn.已打印].Text =
                            paper.PrintedNum.ToString(CultureInfo.InvariantCulture);
                    }
                    break;
                }
                case CadPaperProgressSender.筛选完成:
                {
                    CompleteScreen();
                    break;
                }
                case CadPaperProgressSender.打印完成:
                {
                    _isBusy=false;
                    break;
                }
                case CadPaperProgressSender.运行错误:
                {
                    _isBusy = false;
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
        }

        private CadPapers GetCurrentSelectedCadPapers()
        {
            if (lvDataView.SelectedItems.Count == 0)
                return null;
            var selectedPapers = new CadPapers();
            selectedPapers.AddRange(from ListViewItem selectedItem in lvDataView.SelectedItems
                from item in _cadPapersForPrinting
                where item.FileFullName == selectedItem.SubItems[(int) DataViewColumn.文件路径].Text
                select item);
            return selectedPapers;
        }

        private void SetControlEnable(bool value)
        {
            btA0.Enabled = value;
            btA1.Enabled = value;
            btA2.Enabled = value;
            btA3.Enabled = value;
            btA4.Enabled = value;
            btA43.Enabled = value;
            btA44.Enabled = value;
            btA33.Enabled = value;
            btA34.Enabled = value;
            btOther.Enabled = value;

            btPrint.Enabled = value;
            tbPrint.Enabled = value;

            tbAdd.Enabled = value;
            tbFilter.Enabled = value;
        }

        private void tbCount_Click(object sender, EventArgs e)
        {
            CountForm f = new CountForm(_cadPapersForPrinting);
            f.ShowDialog();
        }
    }
}
