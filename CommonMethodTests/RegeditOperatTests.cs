using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class RegeditOperatTests
    {
        [TestMethod()]
        public void CreateTest()
        {

            RegistryKey software1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            software1.SetValue("MapControlUse.exe", 0X2710, RegistryValueKind.DWord);
            software1.Close();
            Assert.Fail();
        }
    }
}