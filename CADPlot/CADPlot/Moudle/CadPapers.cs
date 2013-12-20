using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{

    public delegate void CadPaperProgressEventHandler(CadPaperProgressEventArgs args);

    public enum CadPaperProgressSender
    {
        打印,
        筛选,
        打印完成,
        筛选完成,
        运行错误
    }

    public class CadPaperProgressEventArgs:EventArgs
    {
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
            if (handler != null)
            {
                handler(args);
            }
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
                        if (cadpaper.MapSheet.ToLower()=="other")
                            continue;
                        cadpaper.Print();
                        //Thread.Sleep(500);
                        var args = new CadPaperProgressEventArgs
                        {
                            Count = Count,
                            CurrentPoint = i++,
                            CurrentPaper = cadpaper,
                            SenderMethod = CadPaperProgressSender.打印
                        };
                        OnCadPaperProgress(args);
                    }
                    catch (COMException ex)
                    {
                        MessageBox.Show(string.Format("调用CAD程序进行批量打印时出错!\n请先手工打开Autocad界面再尝试重新筛选！\n错误描述:{0}", ex.Message), @"CAD批量打印",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnCadPaperProgress(new CadPaperProgressEventArgs { SenderMethod = CadPaperProgressSender.运行错误 });
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("CAD批量打印输出时出错！\n错误描述:{0}",ex.Message),@"CAD批量打印",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        OnCadPaperProgress(new CadPaperProgressEventArgs { SenderMethod = CadPaperProgressSender.运行错误 });
                        break;
                    }
                }
            }
            OnCadPaperProgress(new CadPaperProgressEventArgs { SenderMethod = CadPaperProgressSender.打印完成 });
        }

        public void Screen()
        {
            //var startDate=DateTime.Now;
            using (AutoCadConnector  cad = new AutoCadConnector())
            {
                int i = 1;
                foreach (CadPaper paper in this)
                {
                    try
                    {
                        //AcadDocument doc = cad.Application.Documents.Open(paper.FileFullName);
                        //paper.Scale = Convert.ToDouble(doc.GetVariable("DIMSCALE"));

                        //var points = (double[]) doc.Limits;

                        //var width = (int) Math.Ceiling((points[2] - points[0])/paper.Scale);
                        //var height = (int) Math.Ceiling((points[3] - points[1])/paper.Scale);

                        //doc.Close(false, "");
                        //paper.Angle = width > height ? 90 : 0;
                        //paper.Width = width;
                        //paper.Height = height;
                        //paper.PrintedNum = 0;

                        paper.Screen();
                        var args = new CadPaperProgressEventArgs
                        {
                            Count = Count,
                            CurrentPoint = i++,
                            CurrentPaper = paper,
                            SenderMethod = CadPaperProgressSender.筛选
                        };
                        //Console.WriteLine(@"begin invoke OnCadPaperProgress ,id:{0},{1}",Thread.CurrentThread.ManagedThreadId,i);
                        OnCadPaperProgress(args);
                    }
                    catch (COMException ex)
                    {
                        MessageBox.Show(string.Format("调用CAD程序图幅筛选时出错!\n请先手工打开Autocad界面再尝试重新筛选！\n错误描述:{0}", ex.Message), @"CAD批量打印",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnCadPaperProgress(new CadPaperProgressEventArgs { SenderMethod = CadPaperProgressSender.运行错误 });
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("程序在图幅筛选时出错！\n错误描述:{0}", ex.Message), @"CAD批量打印",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnCadPaperProgress(new CadPaperProgressEventArgs {SenderMethod = CadPaperProgressSender.运行错误});
                        break;
                    }
                }
            }

            OnCadPaperProgress(new CadPaperProgressEventArgs{ SenderMethod = CadPaperProgressSender.筛选完成});
            //Console.WriteLine(@"end invoke OnCadPaperProgress");
            //var endTime = DateTime.Now;
            //var n = endTime.Subtract(startDate).TotalSeconds;
            //Console.WriteLine(@"总共耗时：{0}",n);
        }
    }
}