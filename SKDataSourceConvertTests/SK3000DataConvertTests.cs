using DBOperAt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicClassCurrency;
using SKDataSourceConvert;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDataSourceConvert.Tests
{
    [TestClass()]
    public class SK3000DataConvertTests
    {
        public SK3000DataConvertTests()
        {
            //DataBaseOperAt.SetDBInfo("121.41.87.203", 1433, "报警点基本信息", "sa", "security999", Enum_DataBase.MSSQLServer);
            DataBaseOperAt.SetDBInfo("192.168.2.19", 1433, "报警点基本信息", "sa", "security999", Enum_DataBase.MSSQLServer);
        }
        [TestMethod()]
        public void VideoInfo_DataRowToVideoInfoTest()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            sbExecSQL.Append("SELECT TOP 1 * FROM T_VideoTable ");
            sbExecSQL.Append("WHERE HostNumber ='4006' ");
            DataTable dtResult = DataBaseOperAt.QuerySQL(sbExecSQL.ToString()).Tables[0];
            VideoInfo v = SK3000DataConvert.VideoInfo_DataRowToVideoInfo(dtResult.Rows[0]);
            Assert.AreEqual(v.VideoType, Enum_VideoType.XMaiVideo);
        }
    }
}