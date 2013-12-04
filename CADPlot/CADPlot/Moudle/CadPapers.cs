using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CADPlot.Moudle
{
    public class CadPapers : List<CadPaper>
    {
        public delegate void CadPaperProgressEventHandler(object sender, CadPaperProgressEventArgs args);
        public enum CadPaperProgressEventSender
        {
            plot,check
        }
        /// <summary>
        ///     折合A4张数
        /// </summary>
        public virtual int ForA4Count
        {
            get
            {
                return this.Where(papre => papre.FormatName != "other")
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

        public event CadPaperProgressEventHandler PlotingEvent;

        protected virtual void OnPlotingEvent(CadPaperProgressEventArgs args)
        {
            CadPaperProgressEventHandler handler = PlotingEvent;
            if (handler != null) handler(this, args);
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
                        cadpaper.Plot();
                        Thread.Sleep(500);
                        var args = new CadPaperProgressEventArgs
                        {
                            Count = Count,
                            CurrentPoint = i++,
                            CurrentPaper=cadpaper,
                            SenderMethod = CadPaperProgressEventSender.plot
                        };
                        OnPlotingEvent(args);
                        Application.DoEvents();
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
        }

        public struct CadPaperProgressEventArgs
        {
            public CadPaperProgressEventArgs(CadPaperProgressEventSender senderMethod, CadPaper currentCadPaper, int count, int currentPoint)
                : this()
            {
                Count = count;
                CurrentPoint = currentPoint;
                SenderMethod = senderMethod;
                CurrentPaper = currentCadPaper;
            }

            public int Count { get; set; }
            public int CurrentPoint { get; set; }

            public CadPaperProgressEventSender SenderMethod { get; set; }
            public CadPaper CurrentPaper { get; set; }
        }
    }
}