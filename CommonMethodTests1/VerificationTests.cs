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
        public void isTimeNum_HourTest()
        {
            string strHostNum = "25";
            Assert.IsTrue(Verification.isTimeNum_Hour(strHostNum));
        }

        [TestMethod()]
        public void isTimeNum_MinuteTest()
        {
            string strMinuteNum = "60";
            Assert.IsTrue(Verification.isTimeNum_Minute(strMinuteNum));
        }

        [TestMethod()]
        public void isTimeNum_SecondTest()
        {
            string stSecondNum = "00";
            Assert.IsTrue(Verification.isTimeNum_Second(stSecondNum));
        }
    }
}