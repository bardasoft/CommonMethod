using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CommonMethod
{
    public class FileOperat
    {
        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="strFilePath">文件地址</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(string strFilePath)
        {
            SKFileInfo result = new SKFileInfo();


            return result;
        }


        /// <summary>
        /// 获取文件夹地址
        /// </summary>
        /// <param name="fileinfo">文件信息</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(FileInfo fileinfo)
        {
            SKFileInfo result = new SKFileInfo();


            return result;
        }



        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="element">节点属性</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(XmlElement element)
        {
            SKFileInfo result = new SKFileInfo();


            return result;
        }


        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="node">节点信息</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(XmlNode node)
        {
            SKFileInfo result = new SKFileInfo();


            return result;
        }

        /// <summary>
        /// 获取文件信息列表
        /// </summary>
        /// <param name="strFolderName">文件夹名称</param>
        /// <returns></returns>
        public static List<SKFileInfo> GetSKFileInfoList(string  strFolderName)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            return reuslt;
        }

        /// <summary>
        /// 获取文件信息列表
        /// </summary>
        /// <param name="fileinfos">系统文件列表</param>
        /// <returns></returns>
        public static List<SKFileInfo> GetSKFileInfoList(FileInfo[] fileinfos)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();



            return reuslt;
        }

        public static List<SKFileInfo> GetSKFileInfoList_ByXmlFilePath(string srtXMLFilePath)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            return reuslt;
        }
        public static List<SKFileInfo> GetSKFileInfoList_ByRootNode(XmlNode rootNode)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            return reuslt;
        }

    }

    public class SKFileInfo
    {

    }
}
