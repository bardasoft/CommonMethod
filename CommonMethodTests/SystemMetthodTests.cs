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
    public class SystemMetthodTests
    {
        [TestMethod()]
        public void FindWindowTest()
        {
            IntPtr iResult = SystemMetthod.FindWindow(null, "多方通话");
            Assert.AreEqual(iResult, IntPtr.Zero);
        }

        [TestMethod()]
        public void SetWindowPosTest()
        {
            //IntPtr iResult = SystemMetthod.FindWindow(null, "多方通话");
            //IntPtr iResult = SystemMetthod.FindWindow(null, "多方通话");
            //IntPtr iZ=new IntPtr(-1);
            //int intResult = SystemMetthod.SetWindowPos(iResult, -1, 1, 1, 1,1,3);
            //intResult = SystemMetthod.SetWindowPos(iResult, 1, 1, 1, 781, 484, 1);
            //Assert.AreEqual(intResult, 1);
        }
    }
}