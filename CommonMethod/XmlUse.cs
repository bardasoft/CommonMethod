﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace CommonMethod
{
    public class XmlUse
    {
        public static bool CreateXmlFile(string strFilePath,string strRootNodeName)
        {
                XmlDocument xmlDoc = new XmlDocument();
                //根节点
                XmlElement rootElement = xmlDoc.CreateElement(strRootNodeName);
                xmlDoc.AppendChild(rootElement);
                xmlDoc.Save(strFilePath);
                return true;
        }

        #region 数据更新
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strParentName"></param>
        /// <param name="strNodeName"></param>
        /// <param name="strsField"></param>
        /// <param name="strsValue"></param>
        /// <returns></returns>
        public static bool AddNodeInfo(string strFilePath, string strParentName, string strNodeName, string[] strsField, string[] strsValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode ParentNode = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlElement element = xmlDoc.CreateElement(strNodeName);
            for (int i = strsField.Length - 1; i >= 0; i--) //倒叙，文件中显示正序
            {
                element.SetAttribute(strsField[i].Trim(), strsValue[i].Trim());
            }
            ParentNode.AppendChild(element);
            xmlDoc.Save(strFilePath);
            return true;
        }


        public static bool UpdateNodeInfo(string strFilePath, string strParentName, string strNodeName, string[] strsField, string[] strsValue, bool bolAutoAdd = false)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlNode node = nodeParent.SelectSingleNode(strNodeName);
            for (int i = strsField.Length - 1; i >= 0; i--) //倒叙，文件中显示正序
            {
                node.Attributes[strsField[i].Trim()].Value = strsValue[i];
            }
            xmlDoc.Save(strFilePath);
            return true;
        }

        public static bool UpdateNodeInfo(string strFilePath, string strParentName, string strNodeName, string strField, string strValue, bool bolAutoAdd = true)
        {
            XmlElement element;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlNode node = nodeParent.SelectSingleNode(strNodeName);
            if (node == null)
            {
                element = xmlDoc.CreateElement(strNodeName);
                element.SetAttribute(strField, strValue);
                nodeParent.AppendChild(element);
            }
            else
            {
                XmlAttribute attr = node.Attributes[strField];
                if (attr == null && bolAutoAdd)
                {
                    element = (XmlElement)node;
                    element.SetAttribute(strField, strValue);
                    //attr = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, strField, strValue);
                    //node.Attributes.SetNamedItem(attr);
                }
                else
                {
                    attr.Value = strValue;
                }
            }
            xmlDoc.Save(strFilePath);
            return true;
        }

        public static bool UpdateNodeInfo(string strFilePath, string strParentName, XmlNode xn)
        {
            bool bolResult = false;
            XmlElement element;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlNode node = nodeParent.SelectSingleNode(xn.Name);
            if (node == null)
            {
                nodeParent.AppendChild(xn);
            }
            else
            {
                foreach (XmlAttribute attr in xn.Attributes)
                {
                    XmlAttribute Temp_attr = node.Attributes[attr.Name];
                    if (Temp_attr == null )
                    {
                        element = (XmlElement)node;
                        element.SetAttribute(attr.Name, attr.Value);
                    }
                    else
                    {
                        Temp_attr.Value = attr.Value;
                    }
                }
            }
            xmlDoc.Save(strFilePath);

            return bolResult;
        }

        public static bool UpdateNodeInfo(string strFilePath, string strParentName, XmlElement xe)
        {
            bool bolResult = false;
            XmlElement element;
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(strFilePath);
            XmlDocument xmlDoc = xe.OwnerDocument;
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlNode node = nodeParent.SelectSingleNode(xe.Name);
            if (node == null)
            {
                nodeParent.AppendChild(xe);
            }
            else
            {
                foreach (XmlAttribute attr in xe.Attributes)
                {
                    XmlAttribute Temp_attr = node.Attributes[attr.Name];
                    if (Temp_attr == null)
                    {
                        element = (XmlElement)node;
                        element.SetAttribute(attr.Name, attr.Value);
                    }
                    else
                    {
                        Temp_attr.Value = attr.Value;
                    }
                }
            }
            xmlDoc.Save(strFilePath);

            return bolResult;
        }

        #endregion

        #region 数据获取

        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strParentName"></param>
        /// <param name="strNodeName"></param>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static string GetNodeInfo(string strFilePath, string strParentName, string strNodeName, string strField)
        {
            string strResult = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);
                XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
                XmlNode node = nodeParent.SelectSingleNode(strNodeName);
                strResult = node.Attributes[strField].Value;
            }
            catch
            {
                strResult = "";
            }
            return strResult;
        }

        public static XmlNode GetNodeInfo(string strFilePath, string strParentName, string strNodeName)
        {
            XmlNode result = null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            result = nodeParent.SelectSingleNode(strNodeName);
            return result;
        }

        #endregion

        #region 对象更新

        /// <summary>
        /// 添加节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static bool AddNodeInfo<T>(T t, string strFilePath)
        {
            bool bolResult = false;


            return bolResult;
        }

        /// <summary>
        /// 更新节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strFilePath"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static bool UpdateNodeInfo<T>(T t, string strFilePath, string strKey)
        {
            bool bolResult = false;


            return bolResult;
        }



        #endregion



    }
}
