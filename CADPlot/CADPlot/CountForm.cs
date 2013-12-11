using System;
using System.Globalization;
using System.Windows.Forms;
using CADPlot.Moudle;

namespace CADPlot
{
    public partial class CountForm : Form
    {
        public CountForm(CadPaperForPrinting papers)
        {
            InitializeComponent();
            if (papers != null)
            {

                ListViewItem item = lsvShowCountDate.Items.Add("A0");
                item.SubItems.AddRange(new[]
                {
                    papers.A0S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A0S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A1");
                item.SubItems.AddRange(new[]
                {
                    papers.A1S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A1S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A2");
                item.SubItems.AddRange(new[]
                {
                    papers.A2S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A2S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A3");
                item.SubItems.AddRange(new[]
                {
                    papers.A3S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A3S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A4");
                item.SubItems.AddRange(new[]
                {
                    papers.A4S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A4S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A43");
                item.SubItems.AddRange(new[]
                {
                    papers.A43S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A43S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A44");
                item.SubItems.AddRange(new[]
                {
                    papers.A44S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A44S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A33");
                item.SubItems.AddRange(new[]
                {
                    papers.A33S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A33S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("A34");
                item.SubItems.AddRange(new[]
                {
                    papers.A34S.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.A34S.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });
                item = lsvShowCountDate.Items.Add("其它");
                item.SubItems.AddRange(new[]
                {
                    papers.OtherSizePapers.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.OtherSizePapers.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });

                item = lsvShowCountDate.Items.Add("合计");
                item.SubItems.AddRange(new[]
                {
                    papers.NatureCount.ToString(CultureInfo.InvariantCulture),
                    papers.ForA4Count.ToString(CultureInfo.InvariantCulture)
                });

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

