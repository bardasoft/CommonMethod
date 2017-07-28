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
    public class GPSCoordinateConvertTests
    {
        [TestMethod()]
        public void WGSToBD_encryptTest()
        {
            double dblWGSLon = 0.0;
            double dblWGPSLat = 0.0;
            double dblBDLon = 0.0;
            double dblBDLat = 0.0;
            GPSCoordinateConvert.WGSToBD_encrypt(dblWGSLon, dblWGPSLat, out dblBDLon, out dblBDLat);
            Assert.AreEqual(0, dblBDLat);
            Assert.Fail();
        }
    }
}