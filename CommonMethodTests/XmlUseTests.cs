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

        [TestMethod()]
        public void AddNodeInfoTest1()
        {
            bool bolResult = false;
            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            XmlUse.CreateXmlFile(strFilePath, strParertName);

            string strNodeName;
            string[] strsField;
            string[] strsValue;

            strNodeName = "EntranceType";
            strsField = new string[] { "Key", "Key1", "Name", "ProgValue", "Describe" };
            strsValue = new string[] { "21", "21E0", "联动门外门", "DoubleDoorFinger", "" };
            XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);


            strNodeName = "EntranceType";
            strsField = new string[] { "Key", "Key1", "Name", "ProgValue", "Describe" };
            strsValue = new string[] { "25", "21E1", "联动门内门", "DoubleInDoorFinger", "" };
            XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);

            strNodeName = "EntranceType";
            strsField = new string[] { "Key", "Key1", "Name", "ProgValue", "Describe" };
            strsValue = new string[] { "22", "22E1", "业务库金库门", "MoneyRoomFinger", "" };
            XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);


            strNodeName = "EntranceType";
            strsField = new string[] { "Key", "Key1", "Name", "ProgValue", "Describe" };
            strsValue = new string[] { "24", "22E0", "业务库隔离门", "SplitDoorFinger", "" };
            XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);

            strNodeName = "EntranceType";
            strsField = new string[] { "Key", "Key1", "Name", "Progvalue", "Describe" };
            strsValue = new string[] { "23", "23E0", "加钞间", "AddMoneyFinger", "" };
            XmlUse.AddNodeInfo(strFilePath, strParertName, strNodeName, strsField, strsValue);

            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void GetNodeInfo_ByElementTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            string strNodeName = "EntranceType";
            XmlNodeList x = XmlUse.GetNodeListInfo(strFilePath, strParertName, strNodeName);
            Assert.AreEqual(x.Count, 2);
        }

        public class EntranceType
        {
            public string Key
            {
                get; set;
            }

            public string Key1
            {
                get;
            }
            public string Key2
            {
                get; set;
            }
        }

        [TestMethod()]
        public void GetObjectInfoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            string strNodeName = "EntranceType";
            XmlNodeList x = XmlUse.GetNodeListInfo(strFilePath, strParertName, strNodeName);
            XmlNode node = x[0];
            EntranceType result = XmlUse.GetObjectInfo<EntranceType>(node);
            Assert.AreEqual(result.Key1, "1");
        }



        [TestMethod()]
        public void GetObjectListInfoTest()
        {

            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            string strNodeName = "EntranceType";
            XmlNodeList x = XmlUse.GetNodeListInfo(strFilePath, strParertName, strNodeName);

            List<EntranceType> result = XmlUse.GetObjectListInfo<EntranceType>(x);
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod()]
        public void AddNodeInfoTest2()
        {
            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            string strNodeName = "EntranceType";
            EntranceType e = new EntranceType
            {
                Key = "11",
                Key2 = "12"
            };
            bool bolResult = XmlUse.AddNodeInfo(e, strFilePath, strParertName);
            Assert.IsTrue(bolResult);
        }

        [TestMethod()]
        public void DeleteNodeInfoTest()
        {
            string strFilePath = Environment.CurrentDirectory + "\\EntranceTypeInfo.xml";
            string strParertName = "EntranceTypeInfo";
            string strNodeName = "EntranceType";
            EntranceType e = new EntranceType
            {
                Key = "11",
                Key2 = "12"
            };
            bool bolResult = XmlUse.DeleteNodeInfo(e, strFilePath, strParertName);
            Assert.IsTrue(bolResult);
        }
    }
}