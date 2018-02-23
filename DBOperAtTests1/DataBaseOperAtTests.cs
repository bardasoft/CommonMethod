using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBOperAt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBOperAt.Tests
{
    [TestClass()]
    public class DataBaseOperAtTests
    {
        public DataBaseOperAtTests()
        {
            DataBaseOperAt.SetDBInfo("192.168.2.19 ", 3306, "skl9000test3", "root", "security999", Enum_DataBase.MySQL);
        }
        [TestMethod()]
        public void ExecSQLTest()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            int intIndex = 0;
            int intResult = 0;
            while (intIndex < 1000000)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT T_Device(Cen_Code,Dev_UniqueCode) Value ");
                for (int i = 0; i < 100000; i++)
                {
                    sbExecSQL.Append("('05950002','" + intIndex.ToString().PadLeft(14, '0') + "'),");
                    intIndex++;
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }
        [TestMethod()]
        public void ExecSQLTest1()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            int intIndex = 0;
            int intResult = 0;
            while (intIndex < 100000)
            {
                sbExecSQL = new StringBuilder();
                sbExecSQL.Append("INSERT T_EventRecord(Cen_Code,Dev_ID,Ev_Content) Value ");
                for (int i = 0; i < 10000; i++)
                {
                    sbExecSQL.Append("('05950002','00000000011000','测试数据" + intIndex + "'),");
                    intIndex++;
                }
                sbExecSQL.Length = sbExecSQL.Length - 1;
                intResult = DataBaseOperAt.ExecSQL(sbExecSQL.ToString());
            }
            Assert.AreEqual(intResult, 1);
        }
    }
}