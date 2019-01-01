using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMethodTests;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class DBRelevantTests
    {
        [TestMethod()]
        public void GetDBOperatStr_InsertTest()
        {
            T_Fingerprint fp = new T_Fingerprint
            {
                fp_enable = true,
                fp_remark = "123",
                fp_content = new byte[] { 0x01, 0x02 },
                
            };
            string strExecSQL = CommonMethod.DBRelevant.GetDBOperatStr_Insert_FilterField<T_Fingerprint>(fp, "T_Fingerprint", "fp_id", new string[] { "fp_inserttime", "fp_updatetime" });
            Assert.AreEqual(strExecSQL, "");
        }
    }
}