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
            string strlpClassName = null;
            string strlpWindowName = "VSPlayer";
            IntPtr i = SystemMetthod.FindWindow(strlpClassName, strlpWindowName);
            Assert.AreEqual(IntPtr.Zero, i);
        }

        [TestMethod()]
        public void SetWindowPosTest()
        {
            string strlpClassName = null;
            string strlpWindowName = "Vsplayer";
            //C:\SHIKE_Video\6000\20180109190947\600001_01_20180109190951_12.mp4
            IntPtr i = SystemMetthod.FindWindow(strlpClassName, strlpWindowName);
            //int intResult= SystemMetthod.SetWindowPos(i, new IntPtr(-1), 100, 100, 500, 500, 0x0001);
            int intResult = SystemMetthod.SetWindowPos(i, new IntPtr(-1), 100, 100, 500, 500, 0x0001);
            Assert.AreEqual(intResult,1);
        }
    }
}