using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class CommonTests
    {
        [TestMethod()]
        public void CmdTelnetTest()
        {
            IPAddress ip = IPAddress.Parse("121.41.87.203");
            Assert.IsTrue(Common.CmdPing(ip));
        }

        [TestMethod()]
        public void CmdPingTest()
        {
            IPAddress ip = IPAddress.Parse("121.41.87.203");
            int intPort = 50000;

            Assert.IsTrue(Common.CmdTelnet(ip, intPort));
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetDictionaryFirstKeyTest()
        {
            Dictionary<string , string > dic = new Dictionary<string , string >();
            dic["2"] = "0";
            dic["1"] = "1";
            object obj = Common.GetDictionaryFirstKey(dic);
            string s = Convert.ToString(obj);
            Assert.AreEqual(s,"0");
        }
    }
}