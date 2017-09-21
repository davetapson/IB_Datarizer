using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigFileReader
{
    public class ConfigFile
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<ConfigSetting> ConfigSettings { get; set; }

        public ConfigFile(string fileName)
        {
            //logger.Info("ConfigSettings create from " + fileName);

            if (File.Exists(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);

                    ConfigSettings = GetSettings(lines);
                }
                catch (Exception e)
                {
                    //logger.Error("Error: ConfigSettings file read error for: " + fileName +
                    //    "\n" + e.Message);
                }
            }
            else
            {
                //logger.Error("Error: ConfigSettings file does not exist: " + fileName);
            }
        }

        private List<ConfigSetting> GetSettings(string[] lines)
        {
            List<ConfigSetting> configSettings = new List<ConfigSetting>();

            foreach(string line in lines) {
                if(!string.IsNullOrWhiteSpace(line) &&
                    line.Substring(0,2) != "--")
                {
                    ConfigSetting configSetting = new ConfigSetting(line);
                    if(!string.IsNullOrWhiteSpace(configSetting.Key) &&
                       !string.IsNullOrWhiteSpace(configSetting.Value))
                    configSettings.Add(configSetting);
                }
            }

            return configSettings;
        }
    }    
}
