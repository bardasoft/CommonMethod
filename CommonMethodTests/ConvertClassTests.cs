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
        public void Special_BytesToStrHexTest()
        {
            byte[] byts = new byte[] { 0X01, 0X02, 0X03, 0XFF };
            string strValue = ConvertClass.Special_BytesToStrHex(byts);
            Assert.AreEqual(strValue, 1);
        }

        [TestMethod()]
        public void StringToAsciiTest()
        {
            string strOperatString = "313131313131";
            string strResult = ConvertClass.StringToAscii(strOperatString);
            Assert.AreEqual(strResult, "1");
        }

        [TestMethod()]
        public void BytesToStrTest()
        {
            Byte[] bytsValue = new byte[] { 0X31, 0X31, 0X31, 0X31, 0X31, 0X31 };
            string strResult = ConvertClass.BytesToCharStr(bytsValue);
            Assert.AreEqual(strResult, "1");
        }
    }
}