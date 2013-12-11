using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{

    public delegate void CadPaperProgressEventHandler(CadPaperProgressEventArgs args);

    public enum CadPaperProgressSender
    {
        打印,
        筛选
    }

    public struct CadPaperProgressEventArgs
    {
        public CadPaperProgressEventArgs(CadPaperProgressSender senderMethod, CadPaper currentCadPaper, int count,
            int currentPoint)
            : this()
        {
            Count = count;
            CurrentPoint = currentPoint;
            SenderMethod = senderMethod;
            CurrentPaper = currentCadPaper;
        }

        public int Count { get; set; }
        public int CurrentPoint { get; set; }

        public CadPaperProgressSender SenderMethod { get; set; }
        public CadPaper CurrentPaper { get; set; }
    }

    public class CadPapers : List<CadPaper>
    {
        public event CadPaperProgressEventHandler CadPaperProgress;

        /// <summary>
        ///     折合A4张数
        /// </summary>
        public virtual int ForA4Count
        {
            get
            {
                return this.Where(papre => papre.MapSheet != "other")
                    .Aggregate(0, (current, papre) => current + papre.ForA4);
            }
        }

        /// <summary>
        ///     自然张数
        /// </summary>
        public virtual int NatureCount
        {
            get { return this.Count(); }
        }

        protected virtual void OnCadPaperProgress(CadPaperProgressEventArgs args)
        {
            CadPaperProgressEventHandler handler = CadPaperProgress;
            if (handler != null) handler(args);
        }

        public virtual void Plot()
        {
            using (new AutoCadConnector())
            {
                int i = 1;
                foreach (CadPaper cadpaper in this)
                {
                    try
                    {
                        cadpaper.Print();
                        Thread.Sleep(500);
                        var args = new CadPaperProgressEventArgs
                        {
                            Count = Count,
                            CurrentPoint = i++,
                            CurrentPaper = cadpaper,
                            SenderMethod = CadPaperProgressSender.打印
                        };
                        OnCadPaperProgress(args);
                        Application.DoEvents();
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
        }

        public void Screen()
        {
            using (new AutoCadConnector())
            {
                int i = 1;
                foreach (CadPaper paper in this)
                {
                    paper.Screen();
                    Application.DoEvents();

                    var args = new CadPaperProgressEventArgs
                    {
                        Count = Count,
                        CurrentPoint = i++,
                        CurrentPaper = paper,
                        SenderMethod = CadPaperProgressSender.筛选
                    };
                    OnCadPaperProgress(args);
                }
            }
        }
    }
}