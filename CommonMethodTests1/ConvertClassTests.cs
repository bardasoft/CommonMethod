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
        public void BCDToHexTest()
        {
            string strTest = "123457";
            int intX = int.Parse(strTest, System.Globalization.NumberStyles.HexNumber);
            byte[] bytResult = ConvertClass.BCDToHex(strTest, 3);
            Assert.AreEqual(bytResult[2], 12);
        }

        [TestMethod()]
        public void HexToBCDTest()
        {
            string strTest = "12345F";
            string strTest1 = "159";
            //byte[] bbytResult = ConvertClass.BCDToHex(strTest1, 1);
            int intX = int.Parse(strTest, System.Globalization.NumberStyles.HexNumber);
            byte[] bbytResult = ConvertClass.BCDToHex(strTest, 3);
            byte[] byt = new byte[] { 18, 52, 95 };

            for (int i = 0; i < 3; i++)
            {
                bbytResult[i] = Convert.ToByte(int.Parse(strTest.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber));
            }
            //string strResult = ConvertClass.HexToBCD(bbytResult);
            Assert.AreEqual(bbytResult[2], "5F");
        }

        [TestMethod()]
        public void BitOperation_BitwiseNOTTest()
        {
            UInt32 Temp_Value = 2147483648;
            UInt32 result = ConvertClass.BitOperation_BitwiseNOT(Temp_Value);
            Assert.AreEqual(result, 1);
        }

        [TestMethod()]
        public void Special_StringToBytesTest()
        {
            string strValue = "123456";
            byte[] result = ConvertClass.Special_StringToBytes(strValue);
            Assert.AreEqual(result.Length, 1);
        }
    }
}