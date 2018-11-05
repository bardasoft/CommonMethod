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
    public class VerificationTests
    {
        [TestMethod()]
        public void IsDomainNameTest()
        {
            string strDomainName = "121.41.87.203";
            //bool bolResult = Verification.isIP(strDomainName);
            //Assert.IsTrue(bolResult);
            bool bolResult = Verification.IsDomainName(strDomainName);

            IPHostEntry hostInfo = Dns.GetHostEntry("lr.mmall.com");
            string ip = hostInfo.AddressList[0].ToString();
            Assert.AreEqual(ip, "1");
        }

        [TestMethod()]
        public void isNumberTest()
        {
            bool bolResult = CommonMethod.Verification.isNumber("123");
            Assert.IsTrue(bolResult);
        }
    }
}