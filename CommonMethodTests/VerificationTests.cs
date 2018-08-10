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
    public class VerificationTests
    {
        [TestMethod()]
        public void IsDomainNameTest()
        {
            string strDomainName = "12avs3.com";
            //bool bolResult = Verification.isIP(strDomainName);
            //Assert.IsTrue(bolResult);
            bool bolResult = Verification.IsDomainName(strDomainName);
            Assert.IsTrue(bolResult);
        }
    }
}