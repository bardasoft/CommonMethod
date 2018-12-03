using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class FileOperatTests
    {
        [TestMethod()]
        public void GetSKFileInfoListTest()
        {
            string XMLFilePath = @"G:\Working\Maintenance\SK3000\RemoteUpdatePackage\Trunk";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList(XMLFilePath);
            Assert.AreEqual(sKFileInfos.Count, 1);

        }

        [TestMethod()]
        public void GetSKFileInfoList_ByXmlFilePathTest()
        {
            string XMLFileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);
            Assert.AreEqual(sKFileInfos.Count, 1);
        }

        [TestMethod()]
        public void GetSKFileInfoTest()
        {
            string FileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";
            SKFileInfo sKFileInfo = FileOperat.GetSKFileInfo(FileName);
            Assert.AreEqual(sKFileInfo.name, "");
        }

        [TestMethod()]
        public void GetSKFileInfoTest1()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(@"C:\Users\Administrator\Desktop\FileVerInfo.xml", settings);
            xmlDoc.Load(reader);
            XmlNodeList root = xmlDoc.GetElementsByTagName("SKFileInfo");

            XmlNode xn = root[0];
            XmlElement XE = (XmlElement)xn;

            SKFileInfo sKFileInfo = FileOperat.GetSKFileInfo(XE);
            Assert.AreEqual(sKFileInfo.name, "");
        }

        [TestMethod()]
        public void GetSKFileInfoTest2()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(@"C:\Users\Administrator\Desktop\FileVerInfo1.xml", settings);
            xmlDoc.Load(reader);
            XmlNodeList root = xmlDoc.GetElementsByTagName("SKFileInfo");
            XmlNode xn = root[0];
            SKFileInfo sKFileInfo = FileOperat.GetSKFileInfo(xn);
            Assert.AreEqual(sKFileInfo.name, "");
        }

        [TestMethod()]
        public void GetSKFileInfoList_ByRootNodeTest()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(@"C:\Users\Administrator\Desktop\FileVerInfo.xml", settings);
            xmlDoc.Load(reader);
            XmlNode root = xmlDoc.SelectSingleNode("ArrayOfSKFileInfo");
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByRootNode(root);
            Assert.AreEqual(sKFileInfos.Count, 1);
        }

        [TestMethod()]
        public void CreaterTest()
        {
            string XMLFileName = "FileVerInfo";
            //string XMLFilePath = @"G:\Working\Maintenance\SK3000\UpdatePackage\CU\RemoteUpdatePackage\BranchXY";
            //string XMLFilePath = @"G:\Working\Maintenance\SK3000\UpdatePackage\CU\RemoteUpdatePackage\Trunk";
            //string XMLFilePath = @"G:\Working\Maintenance\SK3000\CU\CUGenerateInstallationPackage\ReleaseFile_XY";
            string XMLFilePath = @"G:\Working\Maintenance\SK3000\CU\CUGenerateInstallationPackage\ReleaseFile_XY - 副本";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList(XMLFilePath);
            bool OK = FileOperat.CreateSKFileInfoXML(XMLFileName, XMLFilePath, sKFileInfos);
            Assert.IsTrue(OK);
        }

        [TestMethod()]
        public void ContrastTest()
        {
            string XMLFileName = @"C:\Users\Administrator\Desktop\新建文件夹 (2)\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            XMLFileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos1 = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            List<SKFileInfo> AddOrUpList = new List<SKFileInfo>();
            List<SKFileInfo> DelList = new List<SKFileInfo>();
            FileOperat.ContrastSKFileInfo(sKFileInfos, sKFileInfos1, ref AddOrUpList, ref DelList);

            Assert.AreEqual(sKFileInfos.Count, sKFileInfos.Count);
        }

        [TestMethod()]
        public void ContrastTest1()
        {
            string XMLFileName = @"C:\Users\thankyou_1996\Desktop\新建文件夹\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            XMLFileName = @"C:\Users\thankyou_1996\Desktop\新建文件夹\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos1 = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);


            string Key = "name";
            string[] Contrast = { "modifytime" };

            List<SKFileInfo> returnList = FileOperat.ContrastSKFileInfo(sKFileInfos, sKFileInfos1, Key, Contrast);

            Assert.AreEqual(sKFileInfos.Count, sKFileInfos.Count);

        }

        [TestMethod()]
        public void GetSKFileInfoListTest1()
        {
            List<string> IgnoreFileList = new List<string>();
            IgnoreFileList.Add("用户布防.wav");
            string XMLFilePath = @"C:\Users\Administrator\Desktop\新建文件夹 (4)";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList(XMLFilePath, IgnoreFileList);



            string XMLFileName = "FileVerInfo";
            XMLFilePath = @"C:\Users\Administrator\Desktop";

            bool OK = FileOperat.CreateSKFileInfoXML(XMLFileName, XMLFilePath, sKFileInfos);

            Assert.IsTrue(OK);
            //Assert.AreEqual(sKFileInfos.Count, sKFileInfos.Count);
        }

        [TestMethod()]
        public void ContrastSKFileInfoTest()
        {
            //string XMLFileName = @"C:\Users\Administrator\Desktop\新建文件夹 (2)\FileVerInfo.xml";
            string XMLFileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            XMLFileName = @"C:\Users\Administrator\Desktop\FileVerInfo.xml";
            List<SKFileInfo> sKFileInfos1 = FileOperat.GetSKFileInfoList_ByXmlFilePath(XMLFileName);

            bool OK = FileOperat.ContrastSKFileInfo(sKFileInfos, sKFileInfos1);

            Assert.IsTrue(OK);
        }


        [TestMethod]
        public void RemoteContrast()
        {
            //1.获取本地文件信息
            //2.或者远程文件信息
            //3.对比（bool）
            //4.对比（文件列表）
            //5.获取需要下载的远程文件
            //6.获取无法下载的列表
            //7.提示/下载



            Assert.Fail();
        }
    }
}