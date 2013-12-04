using System.Collections.Generic;
using System.Configuration;
using CADPlot;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 AppConfigTest 的测试类，旨在
    ///包含所有 AppConfigTest 单元测试
    ///</summary>
    [TestClass()]
    public class AppConfigTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Save 的测试
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            var test = AppConfig.CadPapreConfigDictionary;
            Console.WriteLine(string.Format("配置文件路径：{0}",AppConfig.FilePath));
            foreach (var item in test.Values)
            {
                Console.WriteLine(@"名称:{0},打印机:{1},图幅:{2},折合A4:{3}", item.Name, item.Printer, item.CanonicalMediaName, item.ForA4);

            }
            test["A4"].Printer = "sdfasfdasfd";
            test["A3"].PaperSize = "234234*42342";
            test["A3"].Printer = "asdfwesdfwecxvart232cawwr2";
            AppConfig.Save();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationManager.RefreshSection("CadDrawingConfig");
            var cadDrawingConfig = config.GetSection("CadDrawingConfig") as CadDrawingConfigSection;
            var optionDic = new Dictionary<string, CadDrawingConfigElement>();
            if (cadDrawingConfig != null)
                foreach (CadDrawingConfigElement item in cadDrawingConfig.CadDrawings)
                {
                    optionDic[item.Name] = item;
                }
            Console.WriteLine(@"--------------------------------");
            foreach (var item in optionDic.Values)
            {
                Console.WriteLine(@"名称:{0},打印机:{1},图幅:{2},折合A4:{3}", item.Name, item.Printer, item.CanonicalMediaName, item.ForA4);

            }
            Assert.AreEqual(optionDic["A4"].Printer, "sdfasfdasfd");
        }
    }
}
