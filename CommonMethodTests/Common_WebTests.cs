using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class Common_WebTests
    {
        private static readonly Encoding DEFAULTENCODE = Encoding.UTF8;
        [TestMethod()]
        public void HttpUploadFileTest()
        {
            string strUrl = @"http://192.168.2.19:8008/SK_VideoRecord/0001/";
            string[] strsFilePath = new string[]
            {
                @"C:\Users\thankyou_1996\Desktop\TIM图片20180826223916.png",
                @"C:\Users\thankyou_1996\Desktop\发布_接警客户端V2.9更新包_180822_02.zip",
            };
            //NameValueCollection data = new NameValueCollection();
            //data.Add("name", "test");
            //data.Add("url", strUrl);
            NameValueCollection data = null;
            string strResult = Common_Web.HFSHttpUploadFile(strUrl, strsFilePath, data, DEFAULTENCODE);
            Assert.AreEqual(strResult, "");
        }

        [TestMethod()]
        public void HttpPostTest()
        {
            string x = "http://192.168.2.19:8008/SK_VideoRecord/0001/5/?mode=section&id=ajax.mkdir&";
            string formdata = "name=2&token=0.899592403555289";
            string strResult = Common_Web.HttpPost(x, formdata);
            Assert.AreEqual(strResult, 1);
        }

        [TestMethod()]
        public void HFSHttpTestTest()
        {
            string strUrl = @"http://192.168.2.19:8008/SK_VideoRecord/0001/5/?mode=section&id=ajax.mkdir";
            string[] strsFilePath = new string[]
            {
                //@"C:\Users\thankyou_1996\Desktop\TIM图片20180826223916.png",
                //@"C:\Users\thankyou_1996\Desktop\发布_接警客户端V2.9更新包_180822_02.zip",
            };
            //NameValueCollection data = new NameValueCollection();
            //data.Add("name", "test");
            //data.Add("url", strUrl);
            NameValueCollection data = new NameValueCollection();
            data.Add("name", "12345");
            data.Add("token", "0.899592403555289");
            string strResult = Common_Web.HFSHttpUploadFile(strUrl, strsFilePath, data, DEFAULTENCODE);
            Assert.AreEqual(strResult, "");
        }

        [TestMethod()]
        public void HttpGetTest()
        {
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk/ezviz/";
            string strResult = Common_Web.HttpGet(strUrl, "");
            Assert.AreEqual(strResult, "");
        }

        [TestMethod()]
        public void HFSHttpGetFileNameListTest()
        {
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk";
            List<HFSDownLoadFileInfo> result = Common_Web.HFSHttpGetFileNameList(strUrl);
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod()]
        public void HFSHttpGetFileTest()
        {
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk";
            string strLocalPath = @"C:\Users\thankyou_1996\Desktop\新建文件夹";
            bool bolResult = Common_Web.HFSHttpGetFile(strUrl, strLocalPath);
            Assert.IsTrue(bolResult);
        }
    }
}