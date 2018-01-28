using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicClassCurrency;
using SKVideoRecordConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKVideoRecordConvert.Tests
{
    [TestClass()]
    public class SK3000VideoRecordConvertTests
    {
        [TestMethod()]
        public void GetVideoRecordInfo_ByFileNameTest()
        {
            string Temp_strAxisVideoRecordFileName = @"G:\上班汇总\Working\维护项目\公用项目\VideoPlayControl\VideoPlayControl\VideoPlayControl\VideoPlayControl_UseDemo\bin\Debug\AxisRecord\000601_00_20180127085739_06.bin";
            VideoRecordInfo v = SK3000VideoRecordConvert.GetVideoRecordInfo_ByFileName(Temp_strAxisVideoRecordFileName);
            Assert.AreEqual(v.DVSNumber, "000601");
        }
    }
}