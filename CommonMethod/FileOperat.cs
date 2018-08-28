using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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


            FileInfo fileInfo = new FileInfo(strFilePath);
            if (fileInfo != null && fileInfo.Exists)
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(fileInfo.FullName);
                result.name = fileInfo.Name;
                if (info.FileVersion == null)
                {
                    result.fileversion = " ";
                }
                else
                {
                    result.fileversion = info.FileVersion;
                }
                if (info.ProductVersion == null)
                {
                    result.productversion = " ";
                }
                else
                {
                    result.productversion = info.ProductVersion;
                }
                //result.path = fileInfo.FullName.Replace(Path, "."); //绝对路径中的初始路径改为 .. 形成相对路径
                result.path = fileInfo.FullName;
                result.createtime = fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
                result.modifytime = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (info.FileDescription == null)
                {
                    result.description = " ";
                }
                else
                {
                    result.description = info.FileDescription;
                }
                result.size = fileInfo.Length.ToString();
                result.type = "1";
                result.remark = " ";
            }
            return result;
        }


        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="fileinfo">文件信息</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(FileInfo fileinfo)
        {
            SKFileInfo result = new SKFileInfo();

            //返回的文件信息路径为绝对路径，因为没有给出相对路径
            FileInfo fileInfo = fileinfo;

            // 如果文件存在
            if (fileInfo != null && fileInfo.Exists)
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(fileInfo.FullName);
                result.name = fileInfo.Name;
                if (info.FileVersion == null)
                {
                    result.fileversion = " ";
                }
                else
                {
                    result.fileversion = info.FileVersion;
                }
                if (info.ProductVersion == null)
                {
                    result.productversion = " ";
                }
                else
                {
                    result.productversion = info.ProductVersion;
                }
                //clientInfo.path = fileInfo.FullName.Replace(Path, "."); //绝对路径中的初始路径改为 . 形成相对路径
                result.path = fileInfo.FullName;
                result.createtime = fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
                result.modifytime = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (info.FileDescription == null)
                {
                    result.description = " ";
                }
                else
                {
                    result.description = info.FileDescription;
                }
                result.size = fileInfo.Length.ToString();
                result.type = "1";
                result.remark = " ";

            }
            else
            {
                Console.WriteLine("指定的文件路径不正确!");
            }
            // 末尾空一行
            Console.WriteLine();
            //return clientInfo;



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
        public static List<SKFileInfo> GetSKFileInfoList(string strFolderName)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();
            //List<string> l = new List<string>();
            //foreach (string s in l)
            //{
            //    reuslt.Add(GetSKFileInfo(s)); 
            //}

            reuslt.AddRange(ReadFile(strFolderName));     //使用递归

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
            //前提：确保FileInfo中没有文件夹否则将无法获取文件夹内的信息
            FileInfo[] fileInfo = fileinfos;
            for (int i = 0; i < fileInfo.Length; i++)
            {
                //SKFileInfo ClientInfo = FileInfo(fileInfo[i], fileInfo[i].FullName);
                SKFileInfo ClientInfo = GetSKFileInfo(fileInfo[i]);

                if (ClientInfo != null)
                {
                    reuslt.Add(ClientInfo);
                }
            }

            return reuslt;
        }

        public static List<SKFileInfo> GetSKFileInfoList_ByXmlFilePath(string srtXMLFilePath)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            //前提：XML文件格式与 SKFileInfo 格式相同，直接反序列化
            FileStream fs = new FileStream(srtXMLFilePath, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(List<SKFileInfo>));
            reuslt = xs.Deserialize(fs) as List<SKFileInfo>;

            return reuslt;
        }
        public static List<SKFileInfo> GetSKFileInfoList_ByRootNode(XmlNode rootNode)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            return reuslt;
        }


        /// <summary>
        /// 获取子文件信息
        /// </summary>
        /// <param name="File"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private static SKFileInfo FileInfo(FileInfo File, string Path)
        {
            FileInfo fileInfo = File;
            SKFileInfo clientInfo = new SKFileInfo();

            // 如果文件存在
            if (fileInfo != null && fileInfo.Exists)
            {
                System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(fileInfo.FullName);
                clientInfo.name = fileInfo.Name;
                if (info.FileVersion == null)
                {
                    clientInfo.fileversion = " ";
                }
                else
                {
                    clientInfo.fileversion = info.FileVersion;
                }
                if (info.ProductVersion == null)
                {
                    clientInfo.productversion = " ";
                }
                else
                {
                    clientInfo.productversion = info.ProductVersion;
                }
                clientInfo.path = fileInfo.FullName.Replace(Path, "."); //绝对路径中的初始路径改为 . 形成相对路径
                clientInfo.createtime = fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
                clientInfo.modifytime = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (info.FileDescription == null)
                {
                    clientInfo.description = " ";
                }
                else
                {
                    clientInfo.description = info.FileDescription;
                }
                clientInfo.size = fileInfo.Length.ToString();
                clientInfo.type = "1";
                clientInfo.remark = " ";

            }
            else
            {
                Console.WriteLine("指定的文件路径不正确!");
            }
            // 末尾空一行
            Console.WriteLine();
            return clientInfo;
        }

        /// <summary>
        /// 读取文件夹路径内所有子文件
        /// </summary>
        /// <param name="strFilePath">文件夹路径</param>
        /// <returns>所有子文件</returns>
        private static List<SKFileInfo> ReadFile(string strFilePath)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();
            DirectoryInfo theFolder = new DirectoryInfo(strFilePath);
            DirectoryInfo[] arrFir = theFolder.GetDirectories();
            foreach (FileSystemInfo i in arrFir) //如果存在文件夹，进入递归
            {
                reuslt.AddRange(ReadFile(i.FullName));     //使用递归
            }

            FileInfo[] fileInfo = theFolder.GetFiles();
            for (int i = 0; i < fileInfo.Length; i++)
            {
                //SKFileInfo ClientInfo = FileInfo(fileInfo[i], fileInfo[i].FullName);
                SKFileInfo ClientInfo = GetSKFileInfo(fileInfo[i]);
                if (ClientInfo != null)
                {
                    reuslt.Add(ClientInfo);
                }
            }

            return reuslt;
        }
    }

    /// <summary>
    /// 文件信息类
    /// </summary>
    public class SKFileInfo
    {
        #region 属性
        /// <summary>
        /// 文件名称_带后缀
        /// </summary>
        [XmlAttribute("name")]
        public string name { get; set; }

        /// <summary>
        /// 文件版本
        /// </summary>
        [XmlAttribute("fileversion")]
        public string fileversion { get; set; }

        /// <summary>
        /// 产品版本
        /// </summary>
        [XmlAttribute("productversion")]
        public string productversion { get; set; }

        /// <summary>
        /// 文件地址_相对路径
        /// </summary>
        [XmlAttribute("path")]
        public string path { get; set; }

        /// <summary>
        /// 创建时间_yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlAttribute("createtime")]
        public string createtime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlAttribute("modifytime")]
        public string modifytime { get; set; }

        /// <summary>
        /// 文件说明
        /// </summary>
        [XmlAttribute("description")]
        public string description { get; set; }

        /// <summary>
        /// 文件大小_b
        /// </summary>
        [XmlAttribute("size")]
        public string size { get; set; }

        /// <summary>
        /// 文件类型_统一1，预留
        /// </summary>
        [XmlAttribute("type")]
        public string type { get; set; }

        /// <summary>
        /// 标注说明_为空，预留
        /// </summary>
        [XmlAttribute("remark")]
        public string remark { get; set; }

        #endregion
    }
}
