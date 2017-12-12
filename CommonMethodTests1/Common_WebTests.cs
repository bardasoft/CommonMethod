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
    }
}