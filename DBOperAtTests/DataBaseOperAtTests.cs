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
        [TestMethod()]
        public void SetDBInfoTest()
        {
            DataBaseOperAt.SetDBInfo("192.168.2.18", 3306, "alarmsystem", "root", "mypassword", Enum_DataBase.MySQL);
            string str = DBHelpMySql.connectionString;
            Assert.AreEqual("1", str);
        }
    }
}