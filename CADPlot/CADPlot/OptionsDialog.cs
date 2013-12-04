using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AutoCAD;
using CADPlot.Moudle;

namespace CADPlot
{
    public partial class OptionsDialog : Form
    {
        private bool IsInit;
        private readonly Dictionary<string, string> mediaNameDictionary = new Dictionary<string, string>();

        public OptionsDialog()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            //PrinterSettings.StringCollection p = PrinterSettings.InstalledPrinters;
            
            //foreach (object i in p)
            //    cbPrinterList.Items.Add(i.ToString());

            //currentOptionItems = AppConfig.GetOptionItems();
            IsInit = true;
            foreach (var item in AppConfig.CadPapreConfigDictionary)
                cbSettingFor.Items.Add(item.Value.Name);
            foreach (var i in GetPrinterList())
                cbPrinterList.Items.Add(i);
            IsInit = false;

        }

        private static IEnumerable<string> GetPrinterList()
        {
            try
            {
                using (var cad = new AutoCadConnector())
                {
                    AcadDocument doc;
                    if (cad.Application.Documents.Count > 0)
                        doc = cad.Application.Documents.Item(0) ?? cad.Application.Documents.Add();
                    else
                        doc = cad.Application.Application.Documents.Add();

                    AcadLayout layout = doc.ModelSpace.Layout;

                    layout.RefreshPlotDeviceInfo();
                    var plots = (string[]) layout.GetPlotDeviceNames();

                    if (cad.Application.Documents.Count > 0)
                        doc.Close(false, "");
                    return plots;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("程序运行出错，错误描述：{0}", ex.Message), @"批量打印", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        private void cbPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsInit) return;
            if (cbPrinterList.SelectedIndex < 0)
                return;

            using (var cad = new AutoCadConnector())
            {
                try
                {
                    AcadDocument doc;
                    if (cad.Application.Documents.Count > 0)
                        doc = cad.Application.Documents.Item(0) ?? cad.Application.Documents.Add();
                    else
                        doc = cad.Application.Application.Documents.Add();

                    AcadLayout layout = doc.ModelSpace.Layout;

                    if (cbPrinterList.Text != @"无" || string.IsNullOrEmpty(cbPrinterList.Text))
                    {

                        layout.RefreshPlotDeviceInfo();
                        layout.ConfigName = cbPrinterList.Text;
                        var p = (string[]) layout.GetCanonicalMediaNames();
                        cbSize.Items.Clear();
                        mediaNameDictionary.Clear();
                        foreach (var s in p)
                        {
                            var LocaleMediaName = layout.GetLocaleMediaName(s);
                            cbSize.Items.Add(LocaleMediaName);
                            mediaNameDictionary[LocaleMediaName] = s;

                        }
                        //cbSize.DataSource = p;
                    }
                    else
                    {
                        cbSize.Items.Clear();
                        mediaNameDictionary.Clear();
                    }
                    doc.Close(false, "");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("调用CAD程序出错！\n错误描述:{0}",ex.Message), @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            //var item=new AppConfig.OptionItem
            //{
            //    Name=cbSettingFor.Text,Printer=cbPrinterList.Text,CanonicalMediaName=cbSize.Text
            //};
            //item.SaveToConfig();;
            string paperName = cbSettingFor.Text;
            if (AppConfig.CadPapreConfigDictionary.ContainsKey(paperName))
            {
                AppConfig.CadPapreConfigDictionary[paperName].Printer = cbPrinterList.Text;
                if (mediaNameDictionary.ContainsKey(cbSize.Text))
                {
                    AppConfig.CadPapreConfigDictionary[paperName].CanonicalMediaName = mediaNameDictionary[cbSize.Text];
                    AppConfig.CadPapreConfigDictionary[paperName].LocaleMediaName = cbSize.Text;
                }
                AppConfig.Save();
            }
        }

        private void cbSettingFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFormatName = cbSettingFor.Text;
            if (AppConfig.CadPapreConfigDictionary.ContainsKey(selectedFormatName))
            {
                CadDrawingConfigElement settingfor = AppConfig.CadPapreConfigDictionary[selectedFormatName];

                cbPrinterList.SelectedIndex = -1;
                for (int i = 0; i < cbPrinterList.Items.Count; i++)
                {
                    if (cbPrinterList.Items[i].ToString() == settingfor.Printer)
                    {
                        cbPrinterList.SelectedIndex = i;
                        break;
                    }
                }

                if (cbSize.Items.Count > 0)
                    cbSize.SelectedIndex = -1;
                for (int i = 0; i < cbSize.Items.Count; i++)
                {
                    if (cbSize.Items[i].ToString() == settingfor.CanonicalMediaName)
                    {
                        cbSize.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}