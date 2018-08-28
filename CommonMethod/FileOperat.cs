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
        /// <param name="RelativePath">相对路径</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(FileInfo fileinfo, string RelativePath)
        {
            SKFileInfo result = new SKFileInfo();

            //如果相对路径为空返回的文件信息为绝对路径，否则为相对路径
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
                if (RelativePath == "")
                {
                    result.path = fileInfo.FullName;
                }
                else
                {
                    result.path = fileInfo.FullName.Replace(RelativePath, "."); //绝对路径中的初始路径改为 . 形成相对路径
                }
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

            }
            // 末尾空一行
            //Console.WriteLine();
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

            //由单元素获取此元素内的文件信息
            result.name = element.Attributes["name"].Value;
            result.fileversion = element.Attributes["fileversion"].Value;
            result.productversion = element.Attributes["productversion"].Value;
            result.path = element.Attributes["path"].Value;
            result.createtime = element.Attributes["createtime"].Value;
            result.modifytime = element.Attributes["modifytime"].Value;
            result.description = element.Attributes["description"].Value;
            result.size = element.Attributes["size"].Value;
            result.type = element.Attributes["type"].Value;
            result.remark = element.Attributes["remark"].Value;

            return result;
        }


        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="node">节点信息</param>
        /// <returns></returns>
        public static SKFileInfo GetSKFileInfo(XmlNode node)
        {

            //节点为元素类型，即一个元素占一个属性
            SKFileInfo result = new SKFileInfo();
            XmlNodeList xmlNodeList = node.ChildNodes; //获取所有子节点

            result.name = xmlNodeList[0].InnerText;
            result.fileversion = xmlNodeList[1].InnerText;
            result.productversion = xmlNodeList[2].InnerText;
            result.path = xmlNodeList[3].InnerText;
            result.createtime = xmlNodeList[4].InnerText;
            result.modifytime = xmlNodeList[5].InnerText;
            result.description = xmlNodeList[6].InnerText;
            result.size = xmlNodeList[7].InnerText;
            result.type = xmlNodeList[8].InnerText;
            result.remark = xmlNodeList[9].InnerText;
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

            reuslt.AddRange(ReadFile(strFolderName, strFolderName));     //使用递归

            return reuslt;
        }

        /// <summary>
        /// 获取文件信息列表
        /// </summary>
        /// <param name="fileinfos">系统文件列表</param>
        /// <returns></returns>
        public static List<SKFileInfo> GetSKFileInfoList(FileInfo[] fileinfos, string RelativePath = "")
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();
            //前提：确保FileInfo中没有文件夹否则将无法获取文件夹内的信息
            FileInfo[] fileInfo = fileinfos;
            for (int i = 0; i < fileInfo.Length; i++)
            {
                SKFileInfo ClientInfo = GetSKFileInfo(fileInfo[i], RelativePath);

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
            FileStream fs = new FileStream(srtXMLFilePath, FileMode.Open);  //打开XML文件
            XmlSerializer xs = new XmlSerializer(typeof(List<SKFileInfo>));  //XML序列化
            reuslt = xs.Deserialize(fs) as List<SKFileInfo>;  //将文件流反序列化到实例对象
            fs.Close(); //关闭文件流
            return reuslt;

        }
        public static List<SKFileInfo> GetSKFileInfoList_ByRootNode(XmlNode rootNode)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            //传入的节点为根节点 
            XmlNodeList xmlNodeList = rootNode.ChildNodes; //获取所有子节点
            foreach (XmlNode xn in xmlNodeList)
            {
                XmlElement xe = (XmlElement)xn;
                SKFileInfo Info = new SKFileInfo();
                Info.name = xe.Attributes["name"].Value;
                Info.fileversion = xe.Attributes["fileversion"].Value;
                Info.productversion = xe.Attributes["productversion"].Value;
                Info.path = xe.Attributes["path"].Value;
                Info.createtime = xe.Attributes["createtime"].Value;
                Info.modifytime = xe.Attributes["modifytime"].Value;
                Info.description = xe.Attributes["description"].Value;
                Info.size = xe.Attributes["size"].Value;
                Info.type = xe.Attributes["type"].Value;
                Info.remark = xe.Attributes["remark"].Value;
                reuslt.Add(Info);
            }


            return reuslt;
        }



        /// <summary>
        /// 读取文件夹路径内所有子文件
        /// </summary>
        /// <param name="strFilePath">文件夹路径</param>
        /// <param name="RelativePath">相对路径</param>
        /// <returns>所有子文件信息</returns>
        private static List<SKFileInfo> ReadFile(string strFilePath, string RelativePath)
        {
            List<SKFileInfo> reuslt = new List<SKFileInfo>();

            DirectoryInfo theFolder = new DirectoryInfo(strFilePath);
            DirectoryInfo[] arrFir = theFolder.GetDirectories();
            foreach (FileSystemInfo i in arrFir) //如果存在文件夹，进入递归
            {
                reuslt.AddRange(ReadFile(i.FullName, RelativePath));     //使用递归
            }

            FileInfo[] fileInfo = theFolder.GetFiles();
            reuslt.AddRange(GetSKFileInfoList(fileInfo, RelativePath));

            return reuslt;
        }

        /// <summary>
        /// 保存为XML文件
        /// </summary>
        /// <param name="XMLFilePath">保存文件的路径</param>
        /// <param name="sKFileInfos">文件列表</param>
        /// <returns></returns>
        public static bool Creater(string XMLFilePath, List<SKFileInfo> sKFileInfos)
        {
            bool reuslt = false;

            if (sKFileInfos != null)
            {
                XMLFilePath += "\\" + "FileVerInfo.xml";
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", ""); //除去声明头
                FileStream fs = new FileStream(XMLFilePath, FileMode.Create, FileAccess.Write); //创建文件流
                XmlSerializer ResSerializer = new XmlSerializer(typeof(List<SKFileInfo>));  //声明XML序列化
                ResSerializer.Serialize(fs, sKFileInfos, ns); //将文件列表XML序列化到文件流并保存文件
                fs.Close(); //关闭文件流

                reuslt = true;
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
