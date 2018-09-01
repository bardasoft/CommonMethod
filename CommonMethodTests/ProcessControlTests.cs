using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class ProcessControlTests
    {
        [TestMethod()]
        public void KillProcessTest()
        {
            ProcessControl.KillProcess("WatchDog");
            Assert.Fail();
        }
    }
}