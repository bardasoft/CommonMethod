using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Xml;

namespace CommonMethod
{
    public class XmlUse
    {
        public static bool CreateXmlFile(string strFilePath, string strRootNodeName)
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

        public static XmlNodeList GetNodeListInfo(string strFilePath, string strParentName, string strNodeName)
        {
            XmlNodeList result = null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode nodeParent = xmlDoc.SelectSingleNode(strParentName);   //父节点
            result = nodeParent.SelectNodes(strNodeName);
            return result;
        }

        #endregion

        #region 对象更新

        /// <summary>
        /// 添加节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strFilePath">文件地址</param>
        /// <param name="strParentName">父节点名称</param>
        /// <returns></returns>
        public static bool AddNodeInfo<T>(T t, string strFilePath,string strParentName)
        {
            bool bolResult = true;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode ParentNode = xmlDoc.SelectSingleNode(strParentName);   //父节点
            XmlElement element = xmlDoc.CreateElement(typeof(T).Name);
            string tempName = "";
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;
                if (!pi.CanWrite)
                {
                    continue;
                }
                object obj = pi.GetValue(t, null);
                if (pi.PropertyType.IsEnum)
                {
                    obj = obj.GetHashCode();
                }
                element.SetAttribute(pi.Name, Convert.ToString(obj));
            }
            ParentNode.AppendChild(element);
            xmlDoc.Save(strFilePath);
            return bolResult;
        }

        /// <summary>
        /// 更新节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strParentName">父节点名称</param>
        /// <param name="strFilePath">Xml文件地址</param>
        /// <param name="strField">字段名称</param>
        /// <param name="strKey">字段值</param>
        /// <returns></returns>
        private static bool UpdateNodeInfo<T>(T t, string strFilePath,string strParentName, string strField,string strKey)
        {
            bool bolResult = false;


            return bolResult;
        }

        /// <summary>
        /// 删除节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strFilePath"></param>
        /// <param name="strParentName"></param>
        /// <returns></returns>
        public static bool DeleteNodeInfo<T>(T t, string strFilePath, string strParentName)
        {
            bool bolResult = false;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode ParentNode = xmlDoc.SelectSingleNode(strParentName);   //父节点
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            XmlNode nodeDelete = null;
            foreach (XmlNode node in ParentNode.ChildNodes)
            {
                if (NodeEqual(t, node, propertys))
                {
                    nodeDelete = node;
                    break;
                }
            }
            if (nodeDelete != null)
            {
                ParentNode.RemoveChild(nodeDelete);
                xmlDoc.Save(strFilePath);
                bolResult = true;
            }
            return bolResult;
        }


        private static bool NodeEqual<T>(T t,XmlNode node, PropertyInfo[] propertys)
        {
            string tempName = "";
            foreach (PropertyInfo pi in propertys)
            {
                if (!pi.CanWrite)
                {
                    continue;
                }
                tempName = pi.Name;
                if (node.Attributes[tempName] == null)
                {
                    return false;
                }
                string Temp_strValue = Convert.ToString(pi.GetValue(t, null));
                if (node.Attributes[tempName].Value != Temp_strValue)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 对象获取
        /// <summary>
        /// XMLNode获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        public static T GetObjectInfo<T>(XmlNode node)
        {
            T reuslt = System.Activator.CreateInstance<T>();
            PropertyInfo[] propertys = reuslt.GetType().GetProperties();// 获得此模型的公共属性
            foreach (var pi in propertys)
            {
                string Temp_strFieldName = pi.Name;
                XmlAttribute attr = node.Attributes[Temp_strFieldName];
                if (attr != null && pi.CanWrite)
                {
                    object value = attr.Value;
                    value = PropertyInfoConvertHelper.GetPropertyValue(pi, value);
                    pi.SetValue(reuslt, value, null);
                }
            }
            return reuslt;
        }

        /// <summary>
        /// List<XMLNode>获取List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstNode"></param>
        /// <returns></returns>
        public static List<T> GetObjectListInfo<T>(XmlNodeList lstNode)
        {
            List<T> result = new List<T>();
            foreach (XmlNode node in lstNode)
            {
                result.Add(GetObjectInfo<T>(node));
            }
            return result;
        }
        #endregion

    }
}
