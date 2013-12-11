using System;
using System.Collections.Generic;
using System.Configuration;

namespace CADPlot
{
    public sealed class AppConfig
    {
        private static readonly Configuration Config =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        static AppConfig()
        {
            //#if(DEBUG)
                Console.WriteLine(@"配置文件路径：{0}", FilePath);
            //#endif
        }

        public static Dictionary<string, CadDrawingConfigElement> CadPapreConfigDictionary
        {
            get { return GetOptionItemsDictionary(); }
        }

        public static string FilePath
        {
            get { return Config.FilePath; }
        }

        private static Dictionary<string, CadDrawingConfigElement> GetOptionItemsDictionary()
        {
            try
            {
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationManager.RefreshSection("CadDrawingConfig");
                var cadDrawingConfig = Config.GetSection("CadDrawingConfig") as CadDrawingConfigSection;
                if (cadDrawingConfig == null) return null;
                var optionDic = new Dictionary<string, CadDrawingConfigElement>();
                foreach (CadDrawingConfigElement item in cadDrawingConfig.CadDrawings)
                {
                    optionDic[item.Name] = item;
                }
                return optionDic;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Save()
        {
            Config.Save(ConfigurationSaveMode.Modified);
        }
    }

    public class CadDrawingConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("caddrawings")]
        public CadDrawingConfigElementCollection CadDrawings
        {
            get { return this["caddrawings"] as CadDrawingConfigElementCollection; }
            set { this["caddrawings"] = value; }
        }
    }

    /// <summary>
    /// dwg图纸配置元素
    /// </summary>
    public class CadDrawingConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("printer", DefaultValue = "", IsRequired = true)]
        public string Printer
        {
            get { return this["printer"].ToString(); }
            set { this["printer"] = value; }
        }

        [ConfigurationProperty("canonicalmediaName", DefaultValue = "", IsRequired = true)]
        public string CanonicalMediaName
        {
            get { return this["canonicalmediaName"].ToString(); }
            set { this["canonicalmediaName"] = value; }
        }

        [ConfigurationProperty("LocaleMediaName", DefaultValue = "", IsRequired = true)]
        public string LocaleMediaName
        {
            get { return this["LocaleMediaName"].ToString(); }
            set { this["LocaleMediaName"] = value; }
        }
        [ConfigurationProperty("fora4", DefaultValue = "", IsRequired = true)]
        public string ForA4
        {
            get { return this["fora4"].ToString(); }
            set { this["fora4"] = value; }
        }

        [ConfigurationProperty("papersize", DefaultValue = "", IsRequired = true)]
        public string PaperSize
        {
            get { return this["papersize"].ToString(); }
            set { this["papersize"] = value; }
        }

        [ConfigurationProperty("stylesheet", DefaultValue = "", IsRequired = true)]
        public string StyleSheet
        {
            get { return this["stylesheet"].ToString(); }
            set { this["stylesheet"] = value; }
        }
    }

    public class CadDrawingConfigElementCollection : ConfigurationElementCollection
    {
        public new CadDrawingConfigElement this[string name]
        {
            get { return BaseGet(name) as CadDrawingConfigElement; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CadDrawingConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CadDrawingConfigElement) element).Name;
        }
    }
}