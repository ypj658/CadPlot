using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{
    public class CadPaperToPrint : CadPapers
    {
        public CadPaperToPrint()
        {
        }

        public CadPaperToPrint(string rootPath)
        {
            RootPath = rootPath;
        }

        /// <summary>
        ///     待打印图纸目录
        /// </summary>
        public string RootPath { get; set; }

        public CadPapers A0S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A0"));
                return paperList;
            }
        }

        public CadPapers A1S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A1"));
                return paperList;
            }
        }

        public CadPapers A2S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A2"));
                return paperList;
            }
        }

        public CadPapers A3S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A3"));
                return paperList;
            }
        }

        public CadPapers A4S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A4"));
                return paperList;
            }
        }

        public CadPapers A33S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A33"));
                return paperList;
            }
        }

        public CadPapers A34S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A34"));
                return paperList;
            }
        }

        public CadPapers A43S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A43"));
                return paperList;
            }
        }

        public CadPapers A44S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "A44"));
                return paperList;
            }
        }

        public CadPapers OtherSizePapers
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.FormatName == "other".ToUpper()));
                return paperList;
            }
        }

        /// <summary>
        ///     读取所有待打印文件列表
        /// </summary>
        private void SelectFiles(string papterRootPath)
        {
            try
            {
                if (string.IsNullOrEmpty(papterRootPath)) return;
                var rootFolder = new DirectoryInfo(papterRootPath);
                FileInfo[] files = rootFolder.GetFiles("*.dwg");
                foreach (CadPaper p in files.Select(fileInfo => new CadPaper {FileFullName = fileInfo.FullName}))
                {
                    Add(p);
                }

                foreach (DirectoryInfo folder in rootFolder.GetDirectories())
                {
                    SelectFiles(folder.FullName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("读取文件发生错误，错误描述：{0}", ex.Message));
            }
        }

        /// <summary>
        ///     获取待打印图纸列表
        /// </summary>
        public void GetPaperToPrintList()
        {
            Clear();
            SelectFiles(RootPath);
        }

        /// <summary>
        ///     筛选图纸，确定图幅大小
        /// </summary>
        public void CheckPaperSize()
        {
            using (var cad = new AutoCadConnector())
            {
                int i = 1;
                foreach (CadPaper  paper  in this)
                {
                    AcadDocument doc = cad.Application.Documents.Open(paper.FileFullName);
                    paper.Scale = Convert.ToDouble(doc.GetVariable("DIMSCALE"));

                    var points = (double[]) doc.Limits;

                    var width = (int) Math.Ceiling((points[2] - points[0])/paper.Scale);
                    var height = (int) Math.Ceiling((points[3] - points[1])/paper.Scale);

                    doc.Close(false, "");
                    paper.Angle = width > height ? 90 : 0;
                    paper.Width = width;
                    paper.Height = height;
                    paper.PrintedNum = 0;

                    Application.DoEvents();
                    Thread.Sleep(500);

                    var args = new CadPaperProgressEventArgs
                    {
                        Count = Count,
                        CurrentPoint = i++,
                        CurrentPaper=paper,
                        SenderMethod=CadPaperProgressEventSender.check
                    };
                    OnPlotingEvent(args);
                }
            }
        }

        public void Print(CadPapers cadPapers)
        {
            foreach (CadPaper paper in cadPapers)
            {
                paper.Plot();
            }
        }

        /// <summary>
        ///     按照指定的图幅打印输出
        /// </summary>
        /// <param name="cadPapers">待打印的图纸列表</param>
        /// <param name="formatName">指定打印图幅名称</param>
        public void Print(CadPapers cadPapers, string formatName)
        {
        }
    }
}