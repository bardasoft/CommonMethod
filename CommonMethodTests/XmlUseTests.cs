using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonMethod.Tests
{
    [TestClass()]
    public class XmlUseTests
    {
        [TestMethod()]
        public void CreateXmlFileTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strRootName = "LayoutSetting";
            bool bolResult = XmlUse.CreateXmlFile(strFilePath, strRootName);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void AddNodeInfoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo";
            string[] strsField = new string[] { "key", "value", "defaultvalue", "describe", "tag", "ramark", "remark1", "remark2", "remark3" };
            string[] strsValue = new string[] { "key", "value", "defaultvalue", "describe", "tag", "ramark", "remark1", "remark2", "remark3" };
            bool bolResult = XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void GetNodeInfoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo";
            string strKeyName = "key";
            string strResult = XmlUse.GetNodeInfo(strFilePath, strParertName, strNodeName, strKeyName);
            Assert.AreEqual(strResult, "123");
        }

        [TestMethod()]
        public void UpdateNodeInfoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo1";
            string strField = "key1";
            string strValue = "123";
            bool bolResult = XmlUse.UpdateNodeInfo(strFilePath, strParertName, strNodeName, strField, strValue, true);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void UpdateNodeInfoTest1()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo";
            string[] strsField = new string[] { "key", "value", "defaultvalue" };
            string[] strsValue = new string[] { "123", "123", "123" };
            bool bolResult = XmlUse.UpdateNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void GetNodeIofoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo123123";
            string[] strsField = new string[] { "key", "value", "defaultvalue" };
            string[] strsValue = new string[] { "123", "123", "123" };
            XmlNode node = XmlUse.GetNodeInfo(strFilePath, strParertName, strNodeName);
            Assert.AreEqual(node.Attributes["key"].Value, "1");
        }

        [TestMethod()]
        public void UpdateNodeInfoTest2()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo";
            XmlNode node = XmlUse.GetNodeInfo(strFilePath, strParertName, strNodeName);
            //node.Attributes.Append(new XmlAttribute)
            XmlElement element = (XmlElement)node;
            element.SetAttribute("TestAttr", "TestAttrValue");
            bool bolResult = XmlUse.UpdateNodeInfo(strFilePath, strParertName, node);
            Assert.IsTrue(bolResult);

        }

        [TestMethod()]
        public void UpdateNodeInfoTest3()
        {
            string strFilePath = Environment.CurrentDirectory + "\\LayoutSetting.xml";
            string strParertName = "LayoutSetting";
            string strNodeName = "SetingInfo";
            XmlNode node = XmlUse.GetNodeInfo(strFilePath, strParertName, strNodeName);
            //node.Attributes.Append(new XmlAttribute)
            XmlElement element = (XmlElement)node;
            element.SetAttribute("TestAttr111", "TestAttrValue");
            bool bolResult = XmlUse.UpdateNodeInfo(strFilePath, strParertName, element);
            Assert.IsTrue(bolResult);
        }
    }
}