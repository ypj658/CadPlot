using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{
    public class CadPaper
    {
        private readonly IDictionary<string, string> PaperSizeDic;

        public CadPaper()
        {
            PaperSizeDic = new Dictionary<string, string>();
            Dictionary<string, CadDrawingConfigElement>.ValueCollection items =
                AppConfig.CadPapreConfigDictionary.Values;
            foreach (CadDrawingConfigElement item in items)
            {
                string size = item.PaperSize;
                string[] s = size.Split(Convert.ToChar("*"));
                PaperSizeDic[string.Format("{0}*{1}", s[0], s[1])] = item.Name;
                PaperSizeDic[string.Format("{0}*{1}", s[1], s[0])] = item.Name;
            }
        }

        [DisplayName(@"已打印")]
        public bool IsPrinted
        {
            get { return PrintedNum > 0; }
        }


        /// <summary>
        ///     文件路径
        /// </summary>
        [DisplayName(@"文件路径")]
        public string FileFullName { get; set; }

        /// <summary>
        ///     图幅
        /// </summary>
        [DisplayName(@"图幅")]
        public string FormatName
        {
            get
            {
                if (Width == 0 || Height == 0)
                    return "OTHER";
                try
                {
                    return PaperSizeDic.ContainsKey(string.Format("{0}*{1}", Width, Height))
                        ? PaperSizeDic[string.Format("{0}*{1}", Width, Height)]
                        : "OTHER";
                }
                catch (Exception)
                {
                    return "OTHER";
                }
            }
        }

        /// <summary>
        ///     文件名
        /// </summary>
        [DisplayName(@"文件名")]
        public string FileShortName
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FileFullName)
                    ? FileFullName.Substring(FileFullName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                    : "";
            }
        }

        /// <summary>
        ///     比例
        /// </summary>
        [DisplayName(@"比例")]
        public double Scale { get; set; }

        /// <summary>
        ///     角度
        /// </summary>
        [DisplayName(@"角度")]
        public int Angle { get; set; }

        /// <summary>
        ///     已打印份数
        /// </summary>
        [DisplayName(@"已打印")]
        public int PrintedNum { get; set; }

        /// <summary>
        ///     宽度
        /// </summary>
        [DisplayName(@"宽度")]
        public int Width { get; set; }

        /// <summary>
        ///     高度
        /// </summary>
        [DisplayName(@"高度")]
        public int Height { get; set; }

        /// <summary>
        ///     折合A4
        /// </summary>
        [DisplayName(@"折合A4")]
        public virtual int ForA4
        {
            //get { return ForA4Dic[FormatName.ToUpper()]; }
            get { return int.Parse(AppConfig.CadPapreConfigDictionary[FormatName].ForA4); }
        }

        /// <summary>
        ///     打印机
        /// </summary>
        [DisplayName(@"打印机")]
        public virtual string PlotConfigName
        {
            get { return AppConfig.CadPapreConfigDictionary[FormatName].Printer; }
        }

        /// <summary>
        ///     打印图纸尺寸名称
        /// </summary>
        [DisplayName(@"打印尺寸")]
        public virtual string CanonicalMediaName
        {
            get { return AppConfig.CadPapreConfigDictionary[FormatName].CanonicalMediaName; }
        }

        [DisplayName(@"图纸尺寸")]
        public virtual string LocalCanonicalMediaName
        {
            get { return AppConfig.CadPapreConfigDictionary[FormatName].LocaleMediaName; }

        }

        /// <summary>
        ///     打印样式表
        /// </summary>
        [DisplayName(@"打印样式")]
        public virtual string StyleSheet
        {
            get { return AppConfig.CadPapreConfigDictionary[FormatName].StyleSheet; }
        }

        /// <summary>
        ///     读取配置文件制定图幅大小的配置
        /// </summary>
        /// <param name="sectionName">图幅名称</param>
        /// <returns></returns>
        public static IDictionary PlotSetting(string sectionName)
        {
            var setting = (IDictionary) ConfigurationManager.GetSection(sectionName);
            return setting;
        }

        public static string GetPaperFormatPriterSetting(string formatName)
        {
            if (string.IsNullOrEmpty(formatName))
                return "";
            try
            {
                return (string) PlotSetting(formatName.ToUpper())["Printer"];
            }
            catch (Exception)
            {
                return "";
            }
        }

        //public static IDictionary<string, int> ForA4Dic = new Dictionary<string, int>
        //    {
        //        {"A0", 16},
        //        {"A1", 8},
        //        {"A2", 4},
        //        {"A3", 2},
        //        {"A33", 6},
        //        {"A34", 8},
        //        {"A4", 1},
        //        {"A43", 3},
        //        {"A44", 4},
        //        {"OTHER",0}
        //    };
        //public static IDictionary<string, string> PaperSizeDic = new Dictionary<string, string>
        //    {
        //        {"210*297", "A4"},
        //        {"297*210", "A4"},
        //        {"420*297","A3"},
        //        {"297*420", "A3"},
        //        {"594*420", "A2"},
        //        {"420*594", "A2"},
        //        {"840*594", "A1"},
        //        {"594*840", "A1"},
        //        {"1189*841", "A0"},
        //        {"297*630", "A43"},
        //        {"630*297", "A43"},
        //        {"297*840", "A44"},
        //        {"840*297", "A44"},
        //        {"420*891", "A33"},
        //        {"891*420", "A33"},
        //        {"420*1188", "A34"},
        //    };
        public virtual void Plot()
        {
            using (var cad = new AutoCadConnector())
            {
                try
                {
                    AcadDocument doc = cad.Application.Documents.Open(FileFullName);
                    AcadLayout layout = doc.ModelSpace.Layout;

                    #region Autocad.Layout对象的属性及方法，主要用于打印输出

                    //Application 
                    //Block 
                    //CanonicalMediaName 
                    //CenterPlot 
                    //ConfigName 
                    //Document 
                    //GetCanonicalMediaNames 
                    //GetLocaleMediaName 
                    //GetPlotDeviceNames 
                    //GetPlotStyleTableNames 
                    //Handle 
                    //HasExtensionDictionary 
                    //ModelType 
                    //Name 
                    //ObjectID 
                    //ObjectName 
                    //OwnerID 
                    //PaperUnits 
                    //PlotHidden 
                    //PlotOrigin 
                    //PlotRotation 
                    //PlotType 
                    //PlotViewportBorders 
                    //PlotViewportsFirst 
                    //PlotWithLineweights 
                    //PlotWithPlotStyles 
                    //RefreshPlotDeviceInfo 
                    //ScaleLineweights 
                    //ShowPlotStyles 
                    //StandardScale 
                    //StyleSheet 
                    //TabOrder 
                    //UseStandardScale 
                    //ViewToPlot  

                    #endregion

                    layout.RefreshPlotDeviceInfo();

                    //ConfigName    指定打印机配置名。用于布局或打印配置的 PC3 文件或打印设备的名称。 
                    layout.ConfigName = PlotConfigName;

                    layout.StyleSheet = StyleSheet;

                    #region

                    /*
                //PlotType  指定布局或打印配置的类型。
                //acDisplay 打印当前显示的所有对象。
                //acExtents 打印当前选定空间范围内的所有对象。
                //acLimits 打印当前空间界限内的所有对象。
                //acView 打印在ViewToPlot属性中命名的视口。
                //acWindow 打印在SetWindowToPlot方法中指定的窗口中的所有对象。
                //acLayout 打印指定纸张尺寸边界内的所有对象，它的原点是由布局选项卡中从坐标(0,0)计算得到。该选项在从模型空间打印时不可用。
                
                 * */

                    #endregion

                    layout.PlotType = AcPlotType.acExtents;

                    //PlotWithPlotStyles:指定对象是按在打印样式文件中分配的配置打印，还是按图形文件中的配置打印。
                    layout.PlotWithPlotStyles = true;

                    //CanonicalMediaName    按名称指定图纸尺寸.String[字符串]; 可读写,图纸尺寸的名称
                    layout.CanonicalMediaName = CanonicalMediaName;

                    layout.PlotOrigin = new double[] {0, 0};
                    layout.UseStandardScale = true;
                    layout.StandardScale = AcPlotScale.acScaleToFit;
                    layout.PlotRotation = Angle == 90 ? AcPlotRotation.ac90degrees : AcPlotRotation.ac0degrees;
                    doc.Plot.PlotToDevice(null);
                    doc.Close(false);

                    PrintedNum++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("调用CAD执行批量打印时发生错误！\n错误描述：{0}", ex.Message), @"批量打印",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        public static void Open(string filepath)
        {
            var cad = new AutoCadConnector();
            cad.Application.Documents.Open(filepath);
            cad.Application.Visible = true;
        }
    }
}