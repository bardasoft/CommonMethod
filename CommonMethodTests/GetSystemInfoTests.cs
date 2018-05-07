using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class GetSystemInfoTests
    {
        [TestMethod()]
        public void GetMACAddressTest()
        {
            string Temp_strMacAddr = GetSystemInfo.GetMACAddress();
            Assert.AreEqual(Temp_strMacAddr, "1");
        }
    }
}