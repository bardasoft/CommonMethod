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
    public class LogWriteTests
    {
        [TestMethod()]
        public void WriteEventLogTest()
        {
            string s = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name;
            Assert.AreEqual(s, "1");
        }
    }
}