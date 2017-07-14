using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class ScreenPosionCalculationTests
    {
        [TestMethod()]
        public void GetMosuerInPercentageTest()
        {
            Point pointMousePos = new Point(44, 1);
            Size siezWindow = new Size(235, 100);
            double dblPercentageWidth, dblPercentageHeight;
            int intPercentageWidth, intPercentageHeight;
            ScreenPosionCalculation.GetMosuerInPercentage(pointMousePos, siezWindow, out intPercentageWidth, out intPercentageHeight);
            Assert.AreEqual(intPercentageWidth, 0.99);
            //Assert.Fail();
        }
    }
}