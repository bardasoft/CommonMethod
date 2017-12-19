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
    public class Common_WebTests
    {
        [TestMethod()]
        public void HttpPostTest()
        {
            string strUrl = "https://open.ys7.com/api/lapp/token/get";
            string strData = "appKey=1acd8ddc451f48a4b8b4666716e8f9ce&appSecret=518335cd3421f16a4b4e88164225c432";

            string strResulr = Common_Web.HttpPost(strUrl, strData);
            Assert.AreEqual(strResulr, 1);
        }

        [TestMethod()]
        public void GetNetDataTimeTest()
        {
            string strResult = Common_Web.GetNetDataTime();
            DateTime tim = Convert.ToDateTime(strResult);
            Assert.AreEqual(tim, "1");
        }

        [TestMethod()]
        public void HttpGetTest()
        {
            string strUrl = "https://sp0.baidu.com/8aQDcjqpAAV3otqbppnN2DJv/api.php?";
            string strData = "cb=jQuery1102033239549674370017_1513645089824&resource_name=guishudi&query=15159772128&_=1513645089826";
            string strResulr = Common_Web.HttpGet(strUrl, strData);
            Assert.AreEqual(strResulr, "1");
        }

        [TestMethod()]
        public void HttpPostTest1()
        {
            string strUrl = "https://sp0.baidu.com/8aQDcjqpAAV3otqbppnN2DJv/api.php?";
            string strData = "cb=jQuery1102033239549674370017_1513645089824&resource_name=guishudi&query=151597722128&_=1513645089826";
            string strResulr = Common_Web.HttpPost(strUrl, strData, "gb2312", "gb2312");
            Assert.AreEqual(strResulr, "1");
        }

        [TestMethod()]
        public void QueryPhoneAttributionTest()
        {
            string strResult = Common_Web.QueryPhoneAttribution("15159772128");
            Assert.AreEqual(strResult, "1");
        }
    }
}