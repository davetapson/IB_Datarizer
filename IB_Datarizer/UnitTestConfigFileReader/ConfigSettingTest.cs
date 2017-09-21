using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigFileReader;

namespace UnitTestConfigFileReader
{
    [TestClass]
    public class ConfigSettingTest
    {
        [TestMethod]
        public void GetSetting_shouldgetsettingfromfileline()
        {
            // arrange
            string line = "key=value";
            ConfigSetting configSetting;

            // act
            configSetting = new ConfigSetting(line);

            // assert
            Assert.AreEqual("key", configSetting.Key);
            Assert.AreEqual("value", configSetting.Value);
        }
    }
}
