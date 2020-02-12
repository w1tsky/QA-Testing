using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GitHubAutomation.Services
{
    public static class TestDataReader
    {
        private static Configuration ConfigFile
        {
            get
            {
                var variableFromConsole = TestContext.Parameters.Get("environment");
                string file = string.IsNullOrEmpty(variableFromConsole) ? "dev" : variableFromConsole;
                var index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var customConfigMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index)
                                        + @"ConfigFiles\" + file + ".config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(customConfigMap, ConfigurationUserLevel.None);
            }
        }

        public static string GetTestData(string key)
        {
            return ConfigFile.AppSettings.Settings[key]?.Value;
        }
    }
}
