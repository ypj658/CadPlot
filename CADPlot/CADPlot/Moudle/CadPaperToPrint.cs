using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{
    public class CadPaperForPrinting : CadPapers
    {
        public CadPaperForPrinting()
        {
        }

        public CadPaperForPrinting(string rootPath)
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
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A0"));
                return paperList;
            }
        }

        public CadPapers A1S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A1"));
                return paperList;
            }
        }

        public CadPapers A2S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A2"));
                return paperList;
            }
        }

        public CadPapers A3S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A3"));
                return paperList;
            }
        }

        public CadPapers A4S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A4"));
                return paperList;
            }
        }

        public CadPapers A33S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A33"));
                return paperList;
            }
        }

        public CadPapers A34S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A34"));
                return paperList;
            }
        }

        public CadPapers A43S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A43"));
                return paperList;
            }
        }

        public CadPapers A44S
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "A44"));
                return paperList;
            }
        }

        public CadPapers OtherSizePapers
        {
            get
            {
                var paperList = new CadPapers();
                paperList.AddRange(this.Where(papre => papre.MapSheet == "other".ToUpper()));
                return paperList;
            }
        }

        /// <summary>
        ///     读取所有待打印文件列表
        /// </summary>
        private void SelectDwgFiles(string papterRootPath)
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
                    SelectDwgFiles(folder.FullName);
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
        public void ReadFilesForPrinting()
        {
            Clear();
            SelectDwgFiles(RootPath);
        }
    }
}