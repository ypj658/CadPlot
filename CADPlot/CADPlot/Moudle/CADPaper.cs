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
        /// <summary>
        /// 存放dwg图纸尺寸对应的图幅名称
        /// </summary>
        private readonly IDictionary<string, string> PaperSizeDic;
        public static readonly Dictionary<string, string> PaperNameDictionary = new Dictionary<string, string>
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
            {"OTHER", "其它"},
        };

        public CadPaper()
        {
            //读取配置文件，将配置中的图纸尺寸与图幅名称对应
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

        [DisplayName(@"文件路径")]
        public string FileFullName { get; set; }

        [DisplayName(@"图幅")]
        public string MapSheet
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

        [DisplayName(@"比例")]
        public double Scale { get; set; }

        [DisplayName(@"角度")]
        public int Angle { get; set; }

        [DisplayName(@"已打印")]
        public int PrintedNum { get; set; }

        [DisplayName(@"宽度")]
        public int Width { get; set; }

        [DisplayName(@"高度")]
        public int Height { get; set; }

        [DisplayName(@"折合A4")]
        public int ForA4
        {
            //get { return ForA4Dic[FormatName.ToUpper()]; }
            get { return int.Parse(AppConfig.CadPapreConfigDictionary[MapSheet].ForA4); }
        }

        [DisplayName(@"打印机")]
        public string PlotConfigName
        {
            get { return AppConfig.CadPapreConfigDictionary[MapSheet].Printer; }
        }

        [DisplayName(@"打印尺寸")]
        public string CanonicalMediaName
        {
            get { return AppConfig.CadPapreConfigDictionary[MapSheet].CanonicalMediaName; }
        }

        [DisplayName(@"图纸尺寸")]
        public string LocalCanonicalMediaName
        {
            get { return AppConfig.CadPapreConfigDictionary[MapSheet].LocaleMediaName; }

        }

        [DisplayName(@"打印样式")]
        public string StyleSheet
        {
            get { return AppConfig.CadPapreConfigDictionary[MapSheet].StyleSheet; }
        }

        public void Print()
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

        public void Screen()
        {
            using (var cad = new AutoCadConnector())
            {
                try
                {
                    AcadDocument doc = cad.Application.Documents.Open(FileFullName);
                    Scale = Convert.ToDouble(doc.GetVariable("DIMSCALE"));

                    var points = (double[]) doc.Limits;

                    var width = (int) Math.Ceiling((points[2] - points[0])/Scale);
                    var height = (int) Math.Ceiling((points[3] - points[1])/Scale);

                    doc.Close(false, "");
                    Angle = width > height ? 90 : 0;
                    Width = width;
                    Height = height;
                    PrintedNum = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("调用CAD执行图纸筛选时时发生错误！\n错误描述：{0}", ex.Message), @"批量打印",
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

        public void Open()
        {
            if(string.IsNullOrEmpty(FileFullName.Trim()))
            {
                var cad = new AutoCadConnector();
                cad.Application.Documents.Open(FileFullName);
                cad.Application.Visible = true;
            }
        }
    }
}