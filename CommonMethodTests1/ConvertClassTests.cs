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
    public class ConvertClassTests
    {
        [TestMethod()]
        public void BitOperation_BitwiseNOTTest()
        {
            UInt32 intValue = 1;
            UInt32 intResult = ConvertClass.BitOperation_BitwiseNOT(intValue);
            Assert.AreEqual(intResult, 1);
        }
    }
}