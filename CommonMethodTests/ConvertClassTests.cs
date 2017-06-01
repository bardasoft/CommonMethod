using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CommonMethod.Tests
{
    [TestClass()]
    public class ConvertClassTests
    {
        [TestMethod()]
        public void StringToAsciiTest()
        {
            string strOperat = "1234";
            string strResult = CommonMethod.ConvertClass.StringToAscii(strOperat);
            Assert.AreEqual(strResult, "1");
            //Assert.Fail();
        }

        [TestMethod()]
        public void Special_BytesToStrHexTest()
        {
            byte[] bytTest = new byte[] { 0X01, 0X02, 0X03, 0X04, 0X05, 0X06 };
            string strResult = CommonMethod.ConvertClass.Special_BytesToStrHex(bytTest);
            Assert.AreEqual(strResult, "1");
        }
    }
}
