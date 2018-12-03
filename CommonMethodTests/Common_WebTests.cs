using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Data;

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
            //string x = "http://192.168.2.19:8008/SK_VideoRecord/0001/5/?mode=section&id=ajax.mkdir&";
            //string formdata = "name=2&token=0.899592403555289";
            //StringBuilder sbExecSQL = new StringBuilder();
            //sbExecSQL.Append("ExecSQL=delete FROM T_VideoTable where DVSNumber=000001 ");
            //sbExecSQL.Append(" UPDATE  T_HostEventSet SET T_HostEventSet.linkagedvs=null WHERE ( T_HostEventSet.linkagedvs like '000001%') and (T_HostEventSet.hostnumber='0000')");
            //string strUrl = "http://localhost:4827/SK3000WebServiceCore/api/DataBase/ExecData";
            StringBuilder sbData = new StringBuilder();
            sbData.AppendFormat("appId={0}", "808f1db7");
            sbData.AppendFormat("&appSecret={0}", "f6e914c40c850b2c76c5001066c799424167bedc");
            sbData.AppendFormat("&username={0}", "50007876");
            sbData.AppendFormat("&password={0}", "gqSYPm5ZF9H0%2Btk0zhodTA=="); //密码需要进行加密
            //sbData.AppendFormat("&username={0}", "50003019");
            //sbData.AppendFormat("&password={0}", "zAHOv0QUK10yqzWmCemXxw=="); //密码需要进行加密
            //gqSYPm5ZF9H0+tk0zhodTA==
            //zAHOv0QUK10yqzWmCemXxw==
            //sbData.Append("&imageCode=''");
            string strUrl = "https://urms.mmall.com/passport/login/app";
            string strResult = Common_Web.HttpPost(strUrl, sbData.ToString());
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
            StringBuilder sbExecSQL = new StringBuilder();
            sbExecSQL.Append("SELECT * FROM 报警基本信息 ORDER BY 主机编号 ");
            //string strUrl = "https://lr.mmall.com/SK3000WebServiceCore/api/DataBase/GetData?ExecSQL=" + StringEncrypt.Encrypt(sbExecSQL.ToString());
            string Temp_str = StringEncrypt.Base64Encode(sbExecSQL.ToString()).Replace("+", "%2B");
            string strUrl = "http://localhost:4827/SK3000WebServiceCore/api/DataBase/GetData?ExecSQL=" + Temp_str;
            DateTime tim = DateTime.Now;
            string strResult = Common_Web.HttpGet(strUrl, "");
            DateTime tim1 = DateTime.Now;
            TimeSpan ts = tim1 - tim;
            Assert.AreEqual(strResult.Length, 100);
        }
        [TestMethod()]
        public void HttpGetTest1()
        {
            StringBuilder sbExecSQL = new StringBuilder();
            sbExecSQL.Append("delete FROM T_VideoTable where DVSNumber=000001 ");
            sbExecSQL.Append(" UPDATE  T_HostEventSet SET T_HostEventSet.linkagedvs=null WHERE ( T_HostEventSet.linkagedvs like '000001%') and (T_HostEventSet.hostnumber='0000')");
            string strUrl = "http://localhost:4827/SK3000WebServiceCore/api/DataBase/GetData?ExecSQL=" + sbExecSQL.ToString();

            DateTime tim = DateTime.Now;
            string strResult = Common_Web.HttpGet(strUrl, "");
            DateTime tim1 = DateTime.Now;
            TimeSpan ts = tim1 - tim;
            Assert.AreEqual(strResult.Length, 100);
        }
        [TestMethod()]
        public void HFSHttpGetFileNameListTest()
        {
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk";
            List<HFSDownLoadFileInfo> result = Common_Web.HFSHttpGetFileNameList(strUrl);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Count; i++)
            {
                sb.Append(result[i].SaveName);
                sb.Append(Environment.NewLine);
            }
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod()]
        public void HFSHttpGetFileTest()
        {
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk";
            string strLocalPath = @"C:\Users\Administrator\Desktop\新建文件夹 (3)";
            bool bolResult = Common_Web.HFSHttpGetFile(strUrl, strLocalPath);
            Assert.IsTrue(bolResult);
        }


        [TestMethod()]
        public void HFSHttpFileTest()
        {
            //先对比得出要添加或更新的东西
            string XMLFileName = @"C:\Users\Administrator\Desktop\新建文件夹 (2)\FileVerInfo.xml";  //服务器上的XML文件
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            XMLFileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";  //本地的XML文件
            List<SKFileInfo> sKFileInfos1 = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);


            string Key = "name";
            string[] Contrasts = { "path", "fileversion", "size" };

            List<SKFileInfo> returnList = FileOperat.ContrastSKFileInfo(sKFileInfos, sKFileInfos1, Key, Contrasts);

            //获取HFS文件列表
            string strUrl = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk"; //获取的链接
            string strLocalPath = @"C:\Users\Administrator\Desktop\新建文件夹 (4)"; //下载到本地的路径

            List<HFSDownLoadFileInfo> result = Common_Web.HFSHttpGetFileNameList(strUrl);

            //对比查出要下载的列表
            List<HFSDownLoadFileInfo> DownList = new List<HFSDownLoadFileInfo>();
            foreach (SKFileInfo SKFile in returnList)
            {
                foreach (HFSDownLoadFileInfo HFSFile in result)
                {
                    //if (SKFile.path.Replace(@".\", "").Replace(@"\", "/") == HFSFile.SaveName)
                    if (SKFile.path == HFSFile.SaveName)
                    {
                        HFSFile.SaveName = strLocalPath + "/" + HFSFile.SaveName;
                        HFSFile.DownName = strUrl + "/" + HFSFile.DownName;
                        DownList.Add(HFSFile);
                        break;
                    }
                }
            }

            //下载文件列表
            if (DownList != null && DownList.Count > 0)
            {
                bool bolResult = Common_Web.HFSHttpGetFile(DownList);
            }


        }

        [TestMethod()]
        public void HFSHttpGetFileTest1()
        {
            string Temp_str = "http://192.168.2.19:8008/SK3000ClientRemoteUpdate/Trunk/FileVerInfo.xml";
            string Temp_str1 = @"C:\Users\thankyou_1996\Desktop\新建文件夹 (2)\FileVerInfo.xml";
            HFSDownLoadFileInfo h = new HFSDownLoadFileInfo
            {
                DownName = Temp_str,
                SaveName = Temp_str1
            };
            bool bolResule = Common_Web.HFSHttpGetFile(h);
            Assert.IsTrue(bolResule);
        }

        [TestMethod()]
        public void ConvertToUrlParaTest()
        {
            HFSDownLoadFileInfo h = new HFSDownLoadFileInfo
            {
                DownName = "",
                SaveName = "32"
            };
            string str = Common_Web.ConvertToUrlPara<HFSDownLoadFileInfo>(h);

            Assert.AreEqual(str, "1");
        }

        [TestMethod()]
        public void HttpGetTest3()
        {
            string strUrl = "http://localhost:4827/SK3000WebServiceCore/api/Host/AppendHostInfo";
            string strData = "token=123&HostId=0001&编程15=测试";
            string str = Common_Web.HttpPost(strUrl, strData, "utf-8", "utf-8");
            Assert.AreEqual(str, "1");
        }

        [TestMethod()]
        public void GetDataTableByJsonDataTest()
        {
       
        }
    }
}