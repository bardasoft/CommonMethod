﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public static class Common
    {
        #region 延时操作
        /// <summary>
        /// 延时操作秒_秒 161014
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns></returns>
        public static bool Delay_Second(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        /// <summary>
        /// 延时操作_毫秒
        /// </summary>
        /// <param name="Millisecond"></param>
        public static void Delay_Millisecond(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        #endregion

        #region 添加水印文字
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字 
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }

        #endregion

        #region 网络相关

        /// <summary>
        /// Telnet命令
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="intPort"></param>
        /// <param name="intMillisecond"></param>
        /// <returns></returns>
        public static bool CmdTelnet(IPAddress ip, int intPort, int intTimeout_Millisecond = 1000)
        {
            try
            {
                TimeOutSocket.Connect(new IPEndPoint(ip, intPort), intTimeout_Millisecond);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ping命令
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool CmdPing(IPAddress ip, int intTimeout_Millisecond = 1000)
        {
            try
            {
                Ping ping = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string s = "";
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                return (ping.Send(ip, intTimeout_Millisecond, bytes, options).Status.ToString() == "Success");
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 获取Dictionary对象 首个对象Key
        /// </summary>
        /// <returns></returns>
        public static object GetDictionaryFirstKey(System.Collections.IDictionary dic)
        {
            foreach (System.Collections.DictionaryEntry entry in dic)
            {
                return entry.Key;
            }
            return null;
        }

        /// <summary>
        /// 复制文件夹 文件
        /// 目录中的文件以及文件夹复制到指定目录中（不包含根目录）
        /// </summary>
        /// <param name="srcPath">原文件夹</param>
        /// <param name="aimPath">目的路径</param>
        public static int CopyDir(string srcPath, string aimPath)
        {
            // 检查目标目录是否以目录分割字符结束如果不是则添加
            if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            {
                aimPath += System.IO.Path.DirectorySeparatorChar;
            }
            // 判断目标目录是否存在如果不存在则新建
            if (!System.IO.Directory.Exists(aimPath))
            {
                System.IO.Directory.CreateDirectory(aimPath);
            }
            // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
            // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
            // string[] fileList = Directory.GetFiles（srcPath）；
            string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
            // 遍历所有的文件和目录
            foreach (string file in fileList)
            {
                // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                if (System.IO.Directory.Exists(file))
                {
                    CopyDir(file, aimPath + System.IO.Path.GetFileName(file));
                }
                // 否则直接Copy文件
                else
                {
                    System.IO.File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                }
            }

            return 1;
        }


        /// <summary>
        /// 删除文件夹文件(不删除根目录)
        /// </summary>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        public static int DeleteDir(string srcPath)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)            //判断是否文件夹
                {
                    DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                    subdir.Delete(true);          //删除子目录和文件
                }
                else
                {
                    File.Delete(i.FullName);      //删除指定文件
                }
            }
            return 1;
        }


        /// <summary>
        /// 深度拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }


        /// <summary>
        /// 创建文件地址
        /// </summary>
        /// <param name="strFolderPath"></param>
        /// <returns></returns>
        public static bool CreateFolder(string strFolderPath)
        {
            int Temp_intIndex = strFolderPath.LastIndexOf("\\");
            if (Temp_intIndex == -1)
            {
                Temp_intIndex = strFolderPath.LastIndexOf("/");
            }
            string Temp_strUpperLevelFolderPath = strFolderPath.Substring(0, Temp_intIndex);
            if (!Directory.Exists(Temp_strUpperLevelFolderPath))
            {
                CreateFolder(Temp_strUpperLevelFolderPath);
            }
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }
            return true;
        }

        /// <summary>
        /// 获取所有下级子节点
        /// </summary>
        /// <param name="tn"></param>
        /// <returns></returns>
        public static List<TreeNode> GetSelectNodes(TreeNode tn)
        {
            List<TreeNode> lstTn = new List<TreeNode>();
            foreach (TreeNode tnn in tn.Nodes)
            {
                if (tnn.Nodes.Count > 0)
                {
                    lstTn.AddRange(GetSelectNodes(tnn));
                }
                else
                {
                    if (tnn.Checked)
                    {
                        lstTn.Add(tnn);
                    }
                }
            }
            return lstTn;
        }
        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetInternetIP()
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Credentials = CredentialCache.DefaultCredentials;
                    byte[] pageDate = webClient.DownloadData("http://pv.sohu.com/cityjson?ie=utf-8");
                    String ip = Encoding.UTF8.GetString(pageDate);
                    webClient.Dispose();

                    Match rebool = Regex.Match(ip, @"\d{2,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                    return rebool.Value;
                }
                catch (Exception e)
                {
                    return "";
                }

            }
        }
    }
}

//缺少编译器要求的成员“System.Runtime.CompilerServices.ExtensionAttribute..ctor”
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}