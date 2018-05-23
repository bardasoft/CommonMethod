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
    public class LogWriteTests
    {
        [TestMethod()]
        public void WriteEventLogTest()
        {
            string s = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name;
            Assert.AreEqual(s, "1");
        }

        [TestMethod()]
        public void WritExceptionLogTest()
        {
            try
            {
                string[] s = new string[1];
                string x = s[12];
            }
            catch(Exception ex)
            {
                string Temp_strLog = Environment.CurrentDirectory+"/test.log";
                Assert.IsTrue(LogWrite.WritExceptionLog("123",ex, Temp_strLog));
            }
        }

        [TestMethod()]
        public void WriteEventLogTest1()
        {
            string Temp_strLog = Environment.CurrentDirectory+"\\RemoveAlarmException";
            Assert.IsTrue(LogWrite.WriteEventLog("123", "312", Temp_strLog));
        }
    }
}