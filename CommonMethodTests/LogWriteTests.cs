using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
namespace CommonMethod.Tests
{
    [TestClass()]
    public class LogWriteTests
    {

       


        [TestMethod()]
        public void WritExceptionLogTest()
        {
            try
            {
                string s = "123";
                char c = s[5];
            }
            catch (Exception ex)
            {
                //MessageBox.Show("1");
                LogWrite.WritExceptionLog("测试", ex);
            }

            Assert.Fail();
            
        }

        [TestMethod()]
        public void WriteEventLogTest()
        {
            LogWrite.WriteEventLog("test", "test");
            Assert.Fail();
        }

        
    }
}
