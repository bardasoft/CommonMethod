﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //Byte[] bytsValue = new byte[] { 0X31, 0X31, 0X31, 0X31, 0X31, 0X31 };
            //Byte[] bytsValue = new byte[] { 0XFF, 0XFF, 0XFF, 0XFF, 0XFF, 0XFF };
            Byte[] bytsValue = new byte[] { 0X00, 0XFF, 0XFF, 0XFF, 0XFF, 0XFF };
            string strResult = ConvertClass.BytesToCharStr(bytsValue);
            Assert.AreEqual(strResult, "1");
        }

        [TestMethod()]
        public void LinuxToTimeTest()
        {
            //long l = 1526886082;
            long l = 1569218833000;
            DateTime timResult = ConvertClass.UnixTimestampToDateTime(l);
            Assert.AreEqual(timResult, DateTime.Now);
        }

        [TestMethod()]
        public void DateTimeToUnixTimestampTest()
        {
            //long l = 1526886082;
            long l = 1569218833000;
            DateTime timResult = ConvertClass.UnixTimestampToDateTime(l);
            long lResult = ConvertClass.DateTimeToUnixTimestamp(timResult);
            Assert.AreEqual(l, lResult);
            //ch01_00000000001041800
        }

        [TestMethod()]
        public void GetWeekOfDataTimeTest()
        {
            //DateTime tim = DateTime.Now;
            //DateTime tim = DateTime.Parse("2018-12-30 11:11:11");

            DateTime tim = DateTime.Now.AddDays(-1);
            int intWeek = ConvertClass.GetWeekOfDataTime(tim);
            Assert.AreEqual(intWeek, 1);
        }

        [TestMethod()]
        public void GetWeekofDateTimeValueTest()
        {

            DateTime tim = DateTime.Now.AddDays(-6);
            int intWeek = ConvertClass.GetWeekofDateTimeValue(tim.DayOfWeek);
            Assert.AreEqual(intWeek, 1);
        }

        [TestMethod()]
        public void GetMonthDateTimeTest()
        {
            DateTime tim1 = DateTime.Today;
            DateTime result = ConvertClass.GetMonthDateTime(tim1);
            Assert.AreEqual(result, DateTime.Now);
        }

        [TestMethod()]
        public void GetDataToDayTest()
        {
            DateTime tim = DateTime.Now;
            DateTime timResult = ConvertClass.GetDataTimeToDay(tim);
            Assert.AreEqual(timResult, "123");
        }

        [TestMethod()]
        public void GetWeekOfYearTest()
        {
            DateTime tim = DateTime.Now;
            int intWeekValue = ConvertClass.GetWeekOfDataTime(tim);
            Assert.AreEqual(intWeekValue, 1);
        }

        [TestMethod()]
        public void GetWeekNumInMonthTest()
        {
            DateTime tim = DateTime.Now;
            int intWeekValue = ConvertClass.GetWeekNumInMonth(tim);
            Assert.AreEqual(intWeekValue, 1);
        }

        [TestMethod()]
        public void GetWeekOfYearTest1()
        {
            DateTime tim = DateTime.Now;
            int intWeekValue = ConvertClass.GetWeekOfYear(tim);
            Assert.AreEqual(intWeekValue, 1);
        }
    }
}