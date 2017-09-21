using ConfigFileReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestConfigFileReader
{
    [TestClass]
    public class ConfigFileReaderTest
    {
        [TestMethod]
        public void ConfigFileReader_shouldreadvalidsettingfromfile()
        {
            // arrange
            string fileDirectory = "C:\\temp";
            string fileName = fileDirectory + "\\TestConfigSettings.config";
            string[] lines = new string[2] { "MyKey1=MyValue1", "MyKey2=MyValue2" };

            Directory.CreateDirectory(fileDirectory);

            File.Delete(fileName);
            File.WriteAllLines(fileName, lines);

            // act
            ConfigFile configFile = new ConfigFile(fileName);

            // assert
            Assert.AreEqual(2, configFile.ConfigSettings.Count);

            ConfigSetting configSetting = configFile.ConfigSettings[0];
            Assert.AreEqual("MyKey1", configSetting.Key);
            Assert.AreEqual("MyValue1", configSetting.Value);

            configSetting = configFile.ConfigSettings[1];
            Assert.AreEqual("MyKey2", configSetting.Key);
            Assert.AreEqual("MyValue2", configSetting.Value);
        }

        [TestMethod]
        public void ConfigFileReader_shouldnotreadblankfile()
        {
            // arrange
            string fileDirectory = "C:\\temp";
            string fileName = fileDirectory + "\\TestConfigSettings.config";

            Directory.CreateDirectory(fileDirectory);

            File.Delete(fileName);
            File.WriteAllText(fileName, "");

            // act
            ConfigFile configFile = new ConfigFile(fileName);

            // assert
            Assert.AreEqual(0, configFile.ConfigSettings.Count);
        }

        [TestMethod]
        public void ConfigFileReader_shouldnotreadinvalidsettingfromfile()
        {
            // arrange
            string fileDirectory = "C:\\temp";
            string fileName = fileDirectory + "\\TestConfigSettings.config";
            string[] lines = new string[4] { "MyKey1=", "=MyValue2", "", " " };

            Directory.CreateDirectory(fileDirectory);

            File.Delete(fileName);
            File.WriteAllLines(fileName, lines);

            // act
            ConfigFile configFile = new ConfigFile(fileName);

            // assert
            Assert.AreEqual(0, configFile.ConfigSettings.Count);
        }
    }
}
