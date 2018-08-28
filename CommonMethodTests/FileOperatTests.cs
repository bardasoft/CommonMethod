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
        public List<SKFileInfo> GetSKFileInfoListTest()
        {
            string FilePath = @"C:\Users\Administrator\Desktop\测试_接警客户端V2.9更新包_180815_01";
            List<SKFileInfo> sKFileInfos = FileOperat.GetSKFileInfoList(FilePath);

            return sKFileInfos;
            //Assert.AreEqual(sKFileInfos.Count, 1);

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
            string XMLFilePath = @"C:\Users\Administrator\Desktop";
            List<SKFileInfo> sKFileInfos = GetSKFileInfoListTest();
            bool OK = FileOperat.Creater(XMLFilePath, sKFileInfos);
            Assert.IsTrue(OK);
        }
    }
}